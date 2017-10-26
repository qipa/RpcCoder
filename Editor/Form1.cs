﻿namespace Editor
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class Form1 : Form
    {
        private System.Windows.Forms.CheckBox ActEditor;
        private System.Windows.Forms.Button btnAddChildNode;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnCsvLoad;
        private System.Windows.Forms.Button btnDelNode;
        private System.Windows.Forms.Button btnSave;
        private ToolStripMenuItem buildFileToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAddGrid;
        private System.Windows.Forms.Button buttonDelGrid;
        private System.Windows.Forms.CheckBox C;
        private System.Windows.Forms.CheckBox Coffee;
        private ToolStripMenuItem collapseAllToolStripMenuItem;
        private IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private DataStruct.FieldDescriptor copyFd;
        private ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.CheckBox CS;
        private System.Windows.Forms.CheckBox CSCat;
        private DataGridView dataGridView1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem delNode;
        private ToolStripMenuItem editorToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem expandAllNodeToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private ImageList imageList1;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem1;
        private bool isChanged;
        private System.Windows.Forms.Label label1;
        private string lastDir = "";
        private System.Windows.Forms.CheckBox LUA;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private PropertyGrid propertyGrid1;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem1;
        private TreeView treeView1;

        public Form1()
        {
            this.InitializeComponent();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnCount = 2;
            this.dataGridView1.Columns[0].Name = "Id";
            this.dataGridView1.Columns[0].Width = 40;
            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[0].Selected = false;
            this.dataGridView1.Columns[1].Name = "Name";
            this.dataGridView1.Columns[1].Width = 280;
            this.C.Checked = GenLangFlags.CPP;
            this.CS.Checked = GenLangFlags.CS;
            this.LUA.Checked = GenLangFlags.LUA;
            this.Coffee.Checked = GenLangFlags.Coffee;
        }

        private void btnCsvLoad_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Name == "configFile")
            {
                this.LoadAllConfigFiles();
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog {
                    Filter = "表格文件|*.xlsx",
                    RestoreDirectory = true,
                    FilterIndex = 1
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = dialog.FileName;
                    Worksheet ws = ImpExcel(fileName);
                    if (ws == null)
                    {
                        MessageBox.Show("cant load not xlsx type file");
                    }
                    else
                    {
                        int num = fileName.LastIndexOf(@"\");
                        if (num > -1)
                        {
                            fileName = fileName.Substring(num + 1);
                        }
                        int index = fileName.IndexOf('_');
                        if (index < 0)
                        {
                            MessageBox.Show("file name must be [xxx_bbb.xlsx] format");
                        }
                        else
                        {
                            int num3 = fileName.ToLower().IndexOf(".xlsx", (int) (index + 1));
                            if (num3 < 0)
                            {
                                MessageBox.Show("file name must be [xxx_bbb.xlsx] format");
                            }
                            else
                            {
                                string str2 = fileName.Substring(index + 1, (num3 - index) - 1);
                                fileName = fileName.Substring(0, index);
                                TreeNode selectedNode = this.treeView1.SelectedNode;
                                ConfigFile tag = (ConfigFile) this.treeView1.SelectedNode.Tag;
                                if (tag != null)
                                {
                                    if (fileName != tag.ConfigName)
                                    {
                                        MessageBox.Show("cant reload [" + fileName + "] for [" + tag.ConfigName + "]");
                                        return;
                                    }
                                }
                                else if (ConfigFile.ContainsKey(fileName))
                                {
                                    MessageBox.Show("config file [" + fileName + "] already exist!!!");
                                    return;
                                }
                                Editor.Module module = (Editor.Module) this.treeView1.SelectedNode.Parent.Parent.Tag;
                                ConfigFile file2 = new ConfigFile();
                                file2.toSetConfigName(fileName);
                                file2.CNName = str2;
                                file2.module = module;
                                this.treeView1.SelectedNode.Text = fileName;
                                this.treeView1.SelectedNode.Name = "NewConfigFile";
                                this.treeView1.SelectedNode.Tag = file2;
                                if (tag != null)
                                {
                                    file2.CNName = tag.CNName;
                                    file2.Comment = tag.Comment;
                                    ConfigFile.ConfigFileDic.Remove(fileName);
                                    file2.module.configFiles.Remove(tag);
                                    this.treeView1.SelectedNode.Nodes.Clear();
                                }
                                ConfigFile.ConfigFileDic.Add(file2.ConfigName, file2);
                                file2.module.configFiles.Add(file2);
                                this.isChanged = true;
                                ArrayList list = this.readXlsxLine(ws, 1, 0);
                                foreach (string str3 in list)
                                {
                                    if (((str3 != null) && (str3.ToLower() != "int")) && ((str3.ToLower() != "string") && (str3.ToLower() != "float")))
                                    {
                                        MessageBox.Show("field type[" + str3 + "] invalid only be[int/string/float]");
                                        return;
                                    }
                                }
                                ArrayList list2 = this.readXlsxLine(ws, 2, list.Count);
                                ArrayList list3 = this.readXlsxLine(ws, 3, list.Count);
                                ArrayList list4 = this.readXlsxLine(ws, 4, list.Count);
                                ArrayList list5 = this.readXlsxLine(ws, 5, list.Count);
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (file2.ContainField((string) list3[i]))
                                    {
                                        MessageBox.Show("already contain field [" + ((string) list3[i]) + "]");
                                        return;
                                    }
                                    ConfigFile.ConfigField field = new ConfigFile.ConfigField();
                                    field.toSetFieldType(((string) list[i]).ToLower());
                                    field.toSetFieldName((string) list3[i]);
                                    field.toSetCnName((string) list4[i]);
                                    string str4 = (string) list5[i];
                                    if (str4 != null)
                                    {
                                        str4.Replace("\r\n", " ");
                                        str4.Replace("\n", " ");
                                    }
                                    field.toSetComment(str4);
                                    if (i == 0)
                                    {
                                        field.toSetIsPri(true);
                                        if (this.GetDefaultValue((string) list2[i]).Length > 0)
                                        {
                                            field.toSetDefaultValue(this.GetDefaultValue((string) list2[i]));
                                        }
                                    }
                                    else
                                    {
                                        field.toSetDefaultValue(this.GetDefaultValue((string) list2[i]));
                                    }
                                    field.toSetCheckIndex(this.GetCheck((string) list2[i]));
                                    field.toSetIsSvr(this.GetIsSvr((string) list2[i]));
                                    field.toSetIsDes(this.GetIsDes((string) list2[i]));
                                    field.toSetValueSet(this.GetValueSet((string) list2[i]));
                                    field.toSetValueSet(this.GetValueSet((string) list2[i]));
                                    field.toSetMaxValue(this.GetMaxValue((string) list2[i]));
                                    field.toSetMinValue(this.GetMinValue((string) list2[i]));
                                    field.configFile = file2;
                                    TreeNode node2 = this.treeView1.SelectedNode.Nodes.Add(field.FieldName);
                                    node2.Name = "NewConfigField";
                                    node2.Tag = field;
                                    file2.fieldItem.Add(field);
                                }
                                this.treeView1.SelectedNode = selectedNode.Parent;
                                this.treeView1.SelectedNode = selectedNode;
                                selectedNode.Expand();
                                Process process = new Process {
                                    StartInfo = { 
                                        FileName = "taskkill.exe",
                                        WindowStyle = ProcessWindowStyle.Hidden,
                                        Arguments = " /F /IM EXCEL.EXE"
                                    }
                                };
                                process.Start();
                                process.WaitForExit();
                            }
                        }
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Parent.Name == this.treeView1.SelectedNode.NextNode.Parent.Name)
            {
                TreeNode selectedNode = this.treeView1.SelectedNode;
                TreeNode nextNode = this.treeView1.SelectedNode.NextNode;
                selectedNode.Collapse(true);
                nextNode.Collapse(true);
                string name = selectedNode.Name;
                selectedNode.Name = nextNode.Name;
                nextNode.Name = name;
                string text = selectedNode.Text;
                selectedNode.Text = nextNode.Text;
                nextNode.Text = text;
                int imageIndex = selectedNode.ImageIndex;
                selectedNode.ImageIndex = nextNode.ImageIndex;
                nextNode.ImageIndex = imageIndex;
                object tag = selectedNode.Tag;
                selectedNode.Tag = nextNode.Tag;
                nextNode.Tag = tag;
                TreeNode[] dest = new TreeNode[selectedNode.Nodes.Count];
                TreeNode[] nodeArray2 = new TreeNode[nextNode.Nodes.Count];
                selectedNode.Nodes.CopyTo(dest, 0);
                nextNode.Nodes.CopyTo(nodeArray2, 0);
                selectedNode.Nodes.Clear();
                nextNode.Nodes.Clear();
                selectedNode.Nodes.AddRange(nodeArray2);
                nextNode.Nodes.AddRange(dest);
                this.swap_node(selectedNode, nextNode);
                this.treeView1.SelectedNode = nextNode;
                this.isChanged = true;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Parent.Name == this.treeView1.SelectedNode.PrevNode.Parent.Name)
            {
                TreeNode selectedNode = this.treeView1.SelectedNode;
                TreeNode prevNode = this.treeView1.SelectedNode.PrevNode;
                selectedNode.Collapse(true);
                prevNode.Collapse(true);
                string name = selectedNode.Name;
                selectedNode.Name = prevNode.Name;
                prevNode.Name = name;
                string text = selectedNode.Text;
                selectedNode.Text = prevNode.Text;
                prevNode.Text = text;
                int imageIndex = selectedNode.ImageIndex;
                selectedNode.ImageIndex = prevNode.ImageIndex;
                prevNode.ImageIndex = imageIndex;
                object tag = selectedNode.Tag;
                selectedNode.Tag = prevNode.Tag;
                prevNode.Tag = tag;
                TreeNode[] dest = new TreeNode[selectedNode.Nodes.Count];
                TreeNode[] nodeArray2 = new TreeNode[prevNode.Nodes.Count];
                selectedNode.Nodes.CopyTo(dest, 0);
                prevNode.Nodes.CopyTo(nodeArray2, 0);
                selectedNode.Nodes.Clear();
                prevNode.Nodes.Clear();
                selectedNode.Nodes.AddRange(nodeArray2);
                prevNode.Nodes.AddRange(dest);
                this.swap_node(selectedNode, prevNode);
                this.treeView1.SelectedNode = prevNode;
                this.isChanged = true;
            }
        }

        private void buildFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Name == "Struct")
            {
                if (this.doCheckCommDataStruct())
                {
                    XMLSerializer.Serialize(DataStructConverter.CommDataStruct, this.lastDir, this.label1);
                    XMLSerializer.SerializeXML(Editor.Module.ModuleDic, this.lastDir, this.label1);
                    this.label1.Text = "完成!!!";
                    MessageBox.Show("Finished!!!");
                }
            }
            else if (this.treeView1.SelectedNode.Name == "NewModule")
            {
                Editor.Module tag = (Editor.Module) this.treeView1.SelectedNode.Tag;
                if (this.doCheckModule(tag))
                {
                    string moduleAllName = "";
                    XMLSerializer.Serialize(tag, this.lastDir, this.label1);
                    ProtoSerializer.Serialize(tag, this.lastDir, this.label1, DataStruct.protoTypeE.RpcProto);
                    ProtoSerializer.Serialize(tag, this.lastDir, this.label1, DataStruct.protoTypeE.SyncProto);
                    ProtoSerializer.SerializeCS(tag, this.lastDir, this.label1, DataStruct.protoTypeE.RpcProto);
                    ProtoSerializer.SerializeCS(tag, this.lastDir, this.label1, DataStruct.protoTypeE.SyncProto);
                    ProtoSerializer.SerializeLUA(tag, this.lastDir, this.label1, DataStruct.protoTypeE.RpcProto);
                    ProtoSerializer.SerializeLUA(tag, this.lastDir, this.label1, DataStruct.protoTypeE.SyncProto);
                    CPPSerializer.Serialize(tag, ref moduleAllName, this.lastDir, this.label1);
                    CSSerializer.Serialize(tag, this.lastDir, this.label1);
                    LuaSerializer.Serialize(tag, this.lastDir, this.label1);
                    CoffeeSerializer.Serialize(tag, this.lastDir, this.label1);
                    this.label1.Text = "完成!!!";
                    MessageBox.Show("Finished!!!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.lastDir;
            if (DialogResult.Cancel != this.folderBrowserDialog1.ShowDialog())
            {
                string selectedPath = this.folderBrowserDialog1.SelectedPath;
                if (this.doCheck())
                {
                    this.doSerialize(selectedPath);
                    this.label1.Text = "完成!!!";
                    this.lastDir = selectedPath;
                    MessageBox.Show("Finished!!!");
                    this.isChanged = false;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
            {
                foreach (Editor.Module.Error error in pair.Value)
                {
                    if (error.name == "")
                    {
                        int num = (Convert.ToInt32(error.id) / 100) * 100;
                        Editor.Module.ErrorModuleName name = Editor.Module.moduleNameDic[num];
                        MessageBox.Show("[ " + name.en + " ]  [ " + name.cn + " ]  [ " + error.id + " ] is empty!!!");
                        return;
                    }
                }
            }
            this.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Insert();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Open();
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                this.treeView1.Nodes[i].Expand();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void buttonAddGrid_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
            {
                if (pair.Key == Editor.Module.key)
                {
                    foreach (Editor.Module.Error error in pair.Value)
                    {
                        if (error.name == "")
                        {
                            Editor.Module.ErrorModuleName name = Editor.Module.moduleNameDic[Editor.Module.key];
                            MessageBox.Show("[ " + name.en + " ]  [ " + name.cn + " ]  [ " + error.id + " ] is empty!!!");
                            return;
                        }
                    }
                }
            }
            int num = 0;
            int index = 0;
            foreach (KeyValuePair<int, ArrayList> pair2 in Editor.Module.errorDic)
            {
                if (pair2.Key != Editor.Module.key)
                {
                    continue;
                }
                Editor.Module.Error error2 = new Editor.Module.Error();
                if (pair2.Value.Count >= 2)
                {
                    int num3 = 0;
                    Editor.Module.Error error3 = pair2.Value[0] as Editor.Module.Error;
                    if (Convert.ToInt32(error3.id) != Editor.Module.key)
                    {
                        index = 0;
                    }
                    else
                    {
                        num3 = 0;
                        while (num3 < (pair2.Value.Count - 1))
                        {
                            Editor.Module.Error error4 = pair2.Value[num3] as Editor.Module.Error;
                            Editor.Module.Error error5 = pair2.Value[num3 + 1] as Editor.Module.Error;
                            int num5 = Convert.ToInt32(error4.id);
                            if ((Convert.ToInt32(error5.id) - num5) > 1)
                            {
                                index = num3 + 1;
                                break;
                            }
                            num3++;
                        }
                        if (num3 == (pair2.Value.Count - 1))
                        {
                            index = num3 + 1;
                        }
                    }
                }
                else if (pair2.Value.Count == 1)
                {
                    Editor.Module.Error error6 = pair2.Value[0] as Editor.Module.Error;
                    if (Convert.ToInt32(error6.id) != Editor.Module.key)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                else if (pair2.Value.Count == 0)
                {
                    index = 0;
                }
                num = Editor.Module.key + index;
                error2.id = num.ToString();
                error2.name = "";
                pair2.Value.Insert(index, error2);
                break;
            }
            string[] values = new string[] { Convert.ToString(num) };
            this.dataGridView1.Rows.Insert(index, values);
            this.isChanged = true;
        }

        private void buttonDelGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    int index = row.Index;
                    this.dataGridView1.Rows.Remove(row);
                    foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
                    {
                        if (pair.Key == Editor.Module.key)
                        {
                            pair.Value.RemoveAt(index);
                            break;
                        }
                    }
                }
            }
            this.isChanged = true;
        }

        private void C_CheckedChanged(object sender, EventArgs e)
        {
            GenLangFlags.CPP = this.C.Checked;
        }

        private void Coffee_CheckedChanged(object sender, EventArgs e)
        {
            GenLangFlags.Coffee = this.Coffee.Checked;
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.CollapseAll();
        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.SelectedNode.Collapse();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void Copy()
        {
            if (this.treeView1.SelectedNode.Name == "NewField")
            {
                DataStruct.FieldDescriptor tag = (DataStruct.FieldDescriptor) this.treeView1.SelectedNode.Tag;
                this.copyFd = tag;
                this.contextMenuStrip1.Items[4].Enabled = true;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[3].Enabled = true;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void CS_CheckedChanged(object sender, EventArgs e)
        {
            GenLangFlags.CS = this.CS.Checked;
            if (this.CS.Checked && this.CSCat.Checked)
            {
                this.CSCat.Checked = false;
                GenLangFlags.CSCat = false;
            }
        }

        private void CSCat_CheckedChanged(object sender, EventArgs e)
        {
            GenLangFlags.CSCat = this.CSCat.Checked;
            if (this.CS.Checked && this.CSCat.Checked)
            {
                this.CS.Checked = false;
                GenLangFlags.CS = false;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            int key = Editor.Module.key;
            foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
            {
                if (pair.Key == key)
                {
                    Editor.Module.Error error = new Editor.Module.Error();
                    Editor.Module.Error error2 = pair.Value[e.RowIndex] as Editor.Module.Error;
                    error.id = error2.id;
                    error.name = "";
                    string str = view[e.ColumnIndex, e.RowIndex].Value as string;
                    if (str != null)
                    {
                        error.name = str;
                    }
                    pair.Value.RemoveAt(e.RowIndex);
                    pair.Value.Insert(e.RowIndex, error);
                    break;
                }
            }
            this.isChanged = true;
        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Delete()
        {
            if (MessageBox.Show("确定删除？", "Delete", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                if (this.treeView1.SelectedNode.Name == "NewDataStruct")
                {
                    DataStruct tag = (DataStruct) this.treeView1.SelectedNode.Tag;
                    DataStruct.DataStructDic.Remove(tag.getFullName());
                    DataStructConverter.CommDataStruct.Remove(tag);
                    if (tag.module != null)
                    {
                        tag.module.moduleDataStruct.Remove(tag);
                    }
                }
                else if (this.treeView1.SelectedNode.Name == "NewField")
                {
                    ((DataStruct.FieldDescriptor) this.treeView1.SelectedNode.Tag).Remove();
                }
                else if (this.treeView1.SelectedNode.Name == "NewModule")
                {
                    Editor.Module module = (Editor.Module) this.treeView1.SelectedNode.Tag;
                    File.Delete(this.lastDir + @"\XML\" + module.ModuleName + ".xml");
                    Editor.Module.ModuleDic.Remove(module.ModuleName);
                    int startIdNum = module.StartIdNum;
                    Editor.Module.errorDic.Remove(startIdNum);
                    Editor.Module.moduleNameDic.Remove(startIdNum);
                }
                else if (this.treeView1.SelectedNode.Name == "NewOperate")
                {
                    ((Editor.Module.OperaterItem) this.treeView1.SelectedNode.Tag).Remove();
                }
                else if (this.treeView1.SelectedNode.Name == "NewSubOperate")
                {
                    ((Editor.Module.OperaterItem.SubOperaterItem) this.treeView1.SelectedNode.Tag).Remove();
                }
                else if (this.treeView1.SelectedNode.Name == "NewConfigFile")
                {
                    ConfigFile file = (ConfigFile) this.treeView1.SelectedNode.Tag;
                    if (file != null)
                    {
                        ConfigFile.ConfigFileDic.Remove(file.ConfigName);
                        if (file.module != null)
                        {
                            file.module.configFiles.Remove(file);
                        }
                    }
                }
                this.treeView1.SelectedNode.Remove();
                if (this.isDisableBuildBtn())
                {
                    this.btnBuild.Enabled = false;
                }
                this.isChanged = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
            {
                foreach (Editor.Module.Error error in pair.Value)
                {
                    if (error.name == "")
                    {
                        int num = (Convert.ToInt32(error.id) / 100) * 100;
                        Editor.Module.ErrorModuleName name = Editor.Module.moduleNameDic[num];
                        MessageBox.Show("[ " + name.en + " ]  [ " + name.cn + " ]  [ " + error.id + " ] is empty!!!");
                        return;
                    }
                }
            }
            this.Save();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool doCheck()
        {
            foreach (KeyValuePair<string, Editor.Module> pair in Editor.Module.ModuleDic)
            {
                if (!this.doCheckModule(pair.Value))
                {
                    return false;
                }
            }
            if (!this.doCheckCommDataStruct())
            {
                return false;
            }
            return true;
        }

        private bool doCheckCommDataStruct()
        {
            foreach (DataStruct struct2 in DataStructConverter.CommDataStruct)
            {
                if (struct2.CNName == "")
                {
                    MessageBox.Show("通用结构:" + struct2.StructName + "-->CName is empty!!!");
                    return false;
                }
                foreach (DataStruct.FieldDescriptor descriptor in struct2.fieldItem)
                {
                    if (descriptor.CNName == "")
                    {
                        MessageBox.Show("通用结构:" + struct2.StructName + "-->Field:" + descriptor.FieldName + "-->CName is empty!!!");
                        return false;
                    }
                    if (!DataStruct.ContainsKey(descriptor.FieldType))
                    {
                        MessageBox.Show("通用结构:" + struct2.StructName + "-->" + descriptor.FieldName + "-->FieldType: " + descriptor.FieldType + " does not exist!!!");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool doCheckModule(Editor.Module m)
        {
            if (m.CNName == "")
            {
                MessageBox.Show("Module:" + m.ModuleName + "-->CName is empty!!!");
                return false;
            }
            foreach (Editor.Module.OperaterItem item in m.operateItem)
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                if (item.CNName == "")
                {
                    MessageBox.Show("Module:" + m.ModuleName + "-->Operate:" + item.Name + "-->CName is empty!!!");
                    return false;
                }
                foreach (Editor.Module.OperaterItem.SubOperaterItem item2 in item.subOperateItem)
                {
                    if (item2.CNName == "")
                    {
                        MessageBox.Show("Module:" + m.ModuleName + "-->Operate:" + item.Name + "-->SubOperate-->CName is empty!!!");
                        return false;
                    }
                    DataStruct struct2 = null;
                    if (!(DataStruct.DataStructDic.TryGetValue(item2.DataStructName, out struct2) || DataStruct.DataStructDic.TryGetValue(m.ModuleName + item2.DataStructName, out struct2)))
                    {
                        MessageBox.Show(m.ModuleName + "-->" + item.Name + "-->" + item2.Name + "-->DataStruct :" + item2.DataStructName + " does not exist!!!");
                        return false;
                    }
                    if (item2.Type == Editor.Module.OperateType.OP_ASK)
                    {
                        num++;
                    }
                    else if (item2.Type == Editor.Module.OperateType.OP_REPLY)
                    {
                        num2++;
                    }
                    else if (((item2.Type == Editor.Module.OperateType.OP_NOTIFY) || (item2.Type == Editor.Module.OperateType.OP_DUPLEX_NOTIFY)) || ((item2.Type == Editor.Module.OperateType.OP_CLIENT_NOTIFY) || (item2.Type == Editor.Module.OperateType.OP_SERVER_NOTIFY)))
                    {
                        num3++;
                    }
                }
                if (((num > 1) || (num2 > 1)) || (num3 > 1))
                {
                    MessageBox.Show(m.ModuleName + "-->" + item.Name + "  Ask or Reply or Notify 定义超过一个");
                    return false;
                }
                if (((num + num2) + num3) == 0)
                {
                    MessageBox.Show(m.ModuleName + "-->" + item.Name + "  Ask or Reply or Notify 必须定义一个");
                    return false;
                }
                if (num3 == 0)
                {
                    if ((num + num2) != 2)
                    {
                        MessageBox.Show(m.ModuleName + "-->" + item.Name + "  Ask or Reply 不配对");
                        return false;
                    }
                }
                else if ((num + num2) != 0)
                {
                    MessageBox.Show(m.ModuleName + "-->" + item.Name + " Notify 不能与 Ask or Reply同时存在");
                    return false;
                }
            }
            int num4 = 0;
            int num5 = 0;
            foreach (DataStruct struct3 in m.moduleDataStruct)
            {
                if (struct3.ProtoType == DataStruct.protoTypeE.SyncProto)
                {
                    num4++;
                    if (((struct3.DataType == DataStruct.SyncType.CacheData) || (struct3.DataType == DataStruct.SyncType.UserData)) || (struct3.DataType == DataStruct.SyncType.ModuleData))
                    {
                        num5++;
                    }
                }
                if (struct3.CNName == "")
                {
                    MessageBox.Show("Module:" + m.ModuleName + "-->DataStruct-->CName is empty!!!");
                    return false;
                }
                foreach (DataStruct.FieldDescriptor descriptor in struct3.fieldItem)
                {
                    if (descriptor.CNName == "")
                    {
                        MessageBox.Show("Module:" + m.ModuleName + "-->DataStruct:" + struct3.StructName + "-->CName is empty!!!");
                        return false;
                    }
                    if (!DataStruct.ContainsKey(descriptor.FieldType) && !DataStruct.DataStructDic.ContainsKey(m.ModuleName + descriptor.FieldType))
                    {
                        MessageBox.Show(m.ModuleName + "-->" + struct3.StructName + "-->" + descriptor.FieldName + "-->FieldType: " + descriptor.FieldType + " does not exist!!!");
                        return false;
                    }
                }
            }
            if ((num4 > 0) && (num5 != 1))
            {
                MessageBox.Show("More than one struct define as [UserData/CacheData/ModuleData]");
                return false;
            }
            foreach (ConfigFile file in m.configFiles)
            {
                if (file.CNName.Length == 0)
                {
                    MessageBox.Show("config file [" + file.ConfigName + "] CNName is empty");
                    return false;
                }
            }
            return true;
        }

        private void doSerialize(string dir)
        {
            if ((this.treeView1.Nodes[0].Nodes.Count != 0) || (this.treeView1.Nodes[1].Nodes.Count != 0))
            {
                XMLSerializer.Serialize(DataStructConverter.CommDataStruct, dir, this.label1);
                XMLSerializer.SerializeXML(Editor.Module.ModuleDic, dir, this.label1);
                foreach (string str in Editor.Module.ModuleDic.Keys)
                {
                    LuaSerializer.Serialize(Editor.Module.ModuleDic[str], dir, this.label1);
                }
                foreach (TreeNode node in this.treeView1.Nodes)
                {
                    if (node.Name == "Module")
                    {
                        string str2 = "#ifndef __ALLMODULENAMES_H\n#define __ALLMODULENAMES_H\n#include <map>\n#include <string>\nusing namespace std;\nextern map<int,string> ModuleValue;\nvoid InitModuleValue();\nstring GetModuleValue(int);\n";
                        string str3 = "#include \"ModuleName.h\"\nmap<int, string> ModuleValue;\nvoid InitModuleValue()\n{\n";
                        string moduleAllName = "";
                        foreach (TreeNode node2 in node.Nodes)
                        {
                            Editor.Module tag = (Editor.Module) node2.Tag;
                            DrawPic.Draw(tag);
                            XMLSerializer.Serialize(tag, dir, this.label1);
                            ProtoSerializer.Serialize(tag, dir, this.label1, DataStruct.protoTypeE.RpcProto);
                            ProtoSerializer.Serialize(tag, dir, this.label1, DataStruct.protoTypeE.SyncProto);
                            ProtoSerializer.SerializeCS(tag, dir, this.label1, DataStruct.protoTypeE.RpcProto);
                            ProtoSerializer.SerializeCS(tag, dir, this.label1, DataStruct.protoTypeE.SyncProto);
                            ProtoSerializer.SerializeLUA(tag, dir, this.label1, DataStruct.protoTypeE.RpcProto);
                            ProtoSerializer.SerializeLUA(tag, dir, this.label1, DataStruct.protoTypeE.SyncProto);
                            CSSerializer.Serialize(tag, dir, this.label1);
                            CPPSerializer.Serialize(tag, ref moduleAllName, dir, this.label1);
                            CoffeeSerializer.Serialize(tag, dir, this.label1);
                        }
                        str3 = (((((str3 + moduleAllName) + "\n}\n" + "string GetModuleValue(int id)\n") + "{\n" + "\tmap<int, string>::iterator iter = ModuleValue.find(id);\n") + "\tif (iter != ModuleValue.end())\n" + "\t{\n") + "\t\treturn iter->second;\n" + "\t}\n") + "\treturn \"未知\";\n" + "}\n";
                        str2 = str2 + "\n#endif";
                        StreamWriter writer = null;
                        writer = new StreamWriter("Out/CPP/ModuleName.h", false, Encoding.UTF8);
                        writer.Write(str2);
                        writer.Close();
                        writer = null;
                        writer = new StreamWriter("Out/CPP/ModuleName.cpp", false, Encoding.UTF8);
                        writer.Write(str3);
                        writer.Close();
                    }
                }
            }
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void expandAllNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.SelectedNode.Expand();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArrayList list = new ArrayList();
            foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
            {
                list.Clear();
                int num = 0;
                foreach (Editor.Module.Error error in pair.Value)
                {
                    if (error.name == "")
                    {
                        list.Add(num);
                    }
                    num++;
                }
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    string str = list[i].ToString();
                    pair.Value.RemoveAt(Convert.ToInt32(str));
                }
            }
            if (this.isChanged)
            {
                switch (MessageBox.Show("是否保存？", "保存", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        this.Save();
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load("Template/Config.xml");
                foreach (XmlNode node in document.SelectSingleNode("Root").ChildNodes)
                {
                    if (node.Name == "Config")
                    {
                        foreach (XmlNode node2 in node.ChildNodes)
                        {
                            if (node2.Name == "LastDir")
                            {
                                node2.Attributes["dir"].Value = this.lastDir;
                            }
                            else if (node2.Name == "OutConfig")
                            {
                                int num3 = 0;
                                num3 |= this.C.Checked ? 1 : 0;
                                num3 |= this.CS.Checked ? 0x10 : 0;
                                num3 |= this.LUA.Checked ? 0x100 : 0;
                                num3 |= this.Coffee.Checked ? 0x1000 : 0;
                                num3 |= this.CSCat.Checked ? 0x10000 : 0;
                                node2.Attributes["out"].Value = (num3 | 0x100000).ToString();
                            }
                        }
                    }
                }
                document.Save("Template/Config.xml");
            }
            catch (Exception exception)
            {
                XmlDocument document2 = new XmlDocument();
                XmlNode newChild = document2.CreateXmlDeclaration("1.0", "utf-8", "");
                document2.AppendChild(newChild);
                XmlNode node4 = document2.CreateElement("Root");
                document2.AppendChild(node4);
                XmlNode node5 = document2.CreateElement("Config");
                node4.AppendChild(node5);
                XmlElement element = document2.CreateElement("LastDir");
                element.SetAttribute("dir", Directory.GetCurrentDirectory() + @"\Out");
                node5.AppendChild(element);
                XmlElement element2 = document2.CreateElement("OutConfig");
                int num4 = 0;
                num4 |= 1;
                num4 |= 0x10;
                num4 |= 0x100;
                num4 |= 0x1000;
                num4 |= 0x10000;
                element2.SetAttribute("out", (num4 | 0x100000).ToString());
                node5.AppendChild(element2);
                document2.Save("Template/Config.xml");
                string message = exception.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnBuild.Enabled = false;
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load("Template/Config.xml");
                foreach (XmlNode node in document.SelectSingleNode("Root").ChildNodes)
                {
                    if (node.Name == "Config")
                    {
                        foreach (XmlNode node2 in node.ChildNodes)
                        {
                            if (node2.Name == "LastDir")
                            {
                                this.lastDir = node2.Attributes["dir"].Value;
                            }
                            else if (node2.Name == "OutConfig")
                            {
                                int num = Convert.ToInt32(node2.Attributes["out"].Value);
                                if ((num & 1) == 0)
                                {
                                    this.C.Checked = false;
                                }
                                else
                                {
                                    this.C.Checked = true;
                                }
                                if ((num & 0x10) == 0)
                                {
                                    this.CS.Checked = false;
                                }
                                else
                                {
                                    this.CS.Checked = true;
                                }
                                if ((num & 0x100) == 0)
                                {
                                    this.LUA.Checked = false;
                                }
                                else
                                {
                                    this.LUA.Checked = true;
                                }
                                if ((num & 0x1000) == 0)
                                {
                                    this.Coffee.Checked = false;
                                }
                                else
                                {
                                    this.Coffee.Checked = true;
                                }
                                if ((num & 0x10000) == 0)
                                {
                                    this.CSCat.Checked = false;
                                }
                                else
                                {
                                    this.CSCat.Checked = true;
                                }
                                GenLangFlags.CS = this.CS.Checked;
                                GenLangFlags.CSCat = this.CSCat.Checked;
                                GenLangFlags.CPP = this.C.Checked;
                                GenLangFlags.LUA = this.LUA.Checked;
                                GenLangFlags.Coffee = this.Coffee.Checked;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private string GetCheck(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return "";
            }
            value = value.ToLower();
            string str = "<chk=";
            int index = value.IndexOf(str);
            if (index < 0)
            {
                return "";
            }
            int num2 = value.IndexOf(">", index);
            if (num2 < 0)
            {
                return "";
            }
            return value.Substring(index + str.Length, (num2 - index) - str.Length);
        }

        public bool GetCheckStatus(string name)
        {
            if (name == "C")
            {
                return this.C.Checked;
            }
            if (name == "CS")
            {
                return this.CS.Checked;
            }
            if (name == "LUA")
            {
                return this.LUA.Checked;
            }
            return ((name == "Coffee") && this.Coffee.Checked);
        }

        private string GetDefaultValue(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return "";
            }
            value = value.ToLower();
            string str = "<def=";
            int index = value.IndexOf(str);
            if (index < 0)
            {
                return "";
            }
            int num2 = value.IndexOf(">", index);
            if (num2 < 0)
            {
                return "";
            }
            return value.Substring(index + str.Length, (num2 - index) - str.Length);
        }

        private bool GetIsDes(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return false;
            }
            value = value.ToLower();
            return (value.IndexOf("<des>") > -1);
        }

        private bool GetIsSvr(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return false;
            }
            value = value.ToLower();
            return (value.IndexOf("<svr>") > -1);
        }

        private int GetMaxValue(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return 0x7fffffff;
            }
            value = value.ToLower();
            string str = "<max=";
            int index = value.IndexOf(str);
            if (index < 0)
            {
                return 0x7fffffff;
            }
            int num2 = value.IndexOf(">", index);
            if (num2 < 0)
            {
                return 0x7fffffff;
            }
            return Convert.ToInt32(value.Substring(index + str.Length, (num2 - index) - str.Length));
        }

        private int GetMinValue(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return -1;
            }
            value = value.ToLower();
            string str = "<min=";
            int index = value.IndexOf(str);
            if (index < 0)
            {
                return -1;
            }
            int num2 = value.IndexOf(">", index);
            if (num2 < 0)
            {
                return -1;
            }
            return Convert.ToInt32(value.Substring(index + str.Length, (num2 - index) - str.Length));
        }

        private string GetValueSet(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return "";
            }
            value = value.ToLower();
            string str = "<set=";
            int index = value.IndexOf(str);
            if (index < 0)
            {
                return "";
            }
            int num2 = value.IndexOf(">", index);
            if (num2 < 0)
            {
                return "";
            }
            return value.Substring(index + str.Length, (num2 - index) - str.Length);
        }

        public static Worksheet ImpExcel(string fileName)
        {
            Worksheet worksheet = null;
            try
            {
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass {
                    Workbooks = { fileName }
                };
                worksheet = (Worksheet) application.Worksheets.get_Item(1);
                int count = worksheet.UsedRange.Rows.Count;
                int num2 = worksheet.UsedRange.Columns.Count;
                string name = worksheet.Name;
                return worksheet;
            }
            catch (Exception exception)
            {
                MessageBox.Show("数据绑定Excel失败! 失败原因：" + exception.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return worksheet;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            this.treeView1 = new TreeView();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.delNode = new ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new ToolStripMenuItem();
            this.expandAllNodeToolStripMenuItem = new ToolStripMenuItem();
            this.copyToolStripMenuItem = new ToolStripMenuItem();
            this.pasteToolStripMenuItem = new ToolStripMenuItem();
            this.buildFileToolStripMenuItem = new ToolStripMenuItem();
            this.imageList1 = new ImageList(this.components);
            this.propertyGrid1 = new PropertyGrid();
            this.btnAddChildNode = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnDelNode = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new MenuStrip();
            this.editorToolStripMenuItem = new ToolStripMenuItem();
            this.insertToolStripMenuItem = new ToolStripMenuItem();
            this.deleteToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.editToolStripMenuItem = new ToolStripMenuItem();
            this.insertToolStripMenuItem1 = new ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new ToolStripMenuItem();
            this.dataGridView1 = new DataGridView();
            this.buttonAddGrid = new System.Windows.Forms.Button();
            this.buttonDelGrid = new System.Windows.Forms.Button();
            this.btnCsvLoad = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.CheckBox();
            this.CS = new System.Windows.Forms.CheckBox();
            this.LUA = new System.Windows.Forms.CheckBox();
            this.Coffee = new System.Windows.Forms.CheckBox();
            this.CSCat = new System.Windows.Forms.CheckBox();
            this.ActEditor = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new TreeNode[] { (TreeNode) resources.GetObject("treeView1.Nodes"), (TreeNode) resources.GetObject("treeView1.Nodes1") });
            this.treeView1.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseDown += new MouseEventHandler(this.treeView1_MouseDown);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.delNode, this.collapseAllToolStripMenuItem, this.expandAllNodeToolStripMenuItem, this.copyToolStripMenuItem, this.pasteToolStripMenuItem, this.buildFileToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening);
            this.delNode.Name = "delNode";
            resources.ApplyResources(this.delNode, "delNode");
            this.delNode.Click += new EventHandler(this.ddToolStripMenuItem_Click);
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            resources.ApplyResources(this.collapseAllToolStripMenuItem, "collapseAllToolStripMenuItem");
            this.collapseAllToolStripMenuItem.Click += new EventHandler(this.collapseAllToolStripMenuItem_Click);
            this.expandAllNodeToolStripMenuItem.Name = "expandAllNodeToolStripMenuItem";
            resources.ApplyResources(this.expandAllNodeToolStripMenuItem, "expandAllNodeToolStripMenuItem");
            this.expandAllNodeToolStripMenuItem.Click += new EventHandler(this.expandAllNodeToolStripMenuItem_Click);
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Click += new EventHandler(this.pasteToolStripMenuItem_Click);
            this.buildFileToolStripMenuItem.Name = "buildFileToolStripMenuItem";
            resources.ApplyResources(this.buildFileToolStripMenuItem, "buildFileToolStripMenuItem");
            this.buildFileToolStripMenuItem.Click += new EventHandler(this.buildFileToolStripMenuItem_Click);
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "breakpoint.bmp");
            this.imageList1.Images.SetKeyName(1, "12fixed.bmp");
            this.imageList1.Images.SetKeyName(2, "16-127-7.bmp");
            this.imageList1.Images.SetKeyName(3, "67fixed.bmp");
            this.imageList1.Images.SetKeyName(4, "74fixed.bmp");
            this.imageList1.Images.SetKeyName(5, "accept.bmp");
            this.imageList1.Images.SetKeyName(6, "add.bmp");
            this.imageList1.Images.SetKeyName(7, "domain_l.bmp");
            this.imageList1.Images.SetKeyName(8, "step.bmp");
            this.imageList1.Images.SetKeyName(9, "stopd.bmp");
            this.imageList1.Images.SetKeyName(10, "run.bmp");
            resources.ApplyResources(this.propertyGrid1, "propertyGrid1");
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            resources.ApplyResources(this.btnAddChildNode, "btnAddChildNode");
            this.btnAddChildNode.Name = "btnAddChildNode";
            this.btnAddChildNode.UseVisualStyleBackColor = true;
            this.btnAddChildNode.Click += new EventHandler(this.button2_Click);
            resources.ApplyResources(this.btnBuild, "btnBuild");
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new EventHandler(this.button1_Click);
            resources.ApplyResources(this.btnDelNode, "btnDelNode");
            this.btnDelNode.Name = "btnDelNode";
            this.btnDelNode.UseVisualStyleBackColor = true;
            this.btnDelNode.Click += new EventHandler(this.button3_Click);
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click_1);
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.button1_Click_1);
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.editorToolStripMenuItem, this.editToolStripMenuItem });
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.editorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.insertToolStripMenuItem, this.deleteToolStripMenuItem, this.toolStripMenuItem1, this.exitToolStripMenuItem });
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            resources.ApplyResources(this.editorToolStripMenuItem, "editorToolStripMenuItem");
            this.editorToolStripMenuItem.Click += new EventHandler(this.editorToolStripMenuItem_Click);
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            resources.ApplyResources(this.insertToolStripMenuItem, "insertToolStripMenuItem");
            this.insertToolStripMenuItem.Click += new EventHandler(this.insertToolStripMenuItem_Click);
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.insertToolStripMenuItem1, this.deleteToolStripMenuItem1, this.saveToolStripMenuItem1, this.pasteToolStripMenuItem1 });
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            resources.ApplyResources(this.insertToolStripMenuItem1, "insertToolStripMenuItem1");
            this.insertToolStripMenuItem1.Click += new EventHandler(this.insertToolStripMenuItem1_Click);
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            resources.ApplyResources(this.deleteToolStripMenuItem1, "deleteToolStripMenuItem1");
            this.deleteToolStripMenuItem1.Click += new EventHandler(this.deleteToolStripMenuItem1_Click);
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
            this.saveToolStripMenuItem1.Click += new EventHandler(this.saveToolStripMenuItem1_Click);
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            resources.ApplyResources(this.pasteToolStripMenuItem1, "pasteToolStripMenuItem1");
            this.pasteToolStripMenuItem1.Click += new EventHandler(this.pasteToolStripMenuItem1_Click);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            resources.ApplyResources(this.buttonAddGrid, "buttonAddGrid");
            this.buttonAddGrid.Name = "buttonAddGrid";
            this.buttonAddGrid.UseVisualStyleBackColor = true;
            this.buttonAddGrid.Click += new EventHandler(this.buttonAddGrid_Click);
            resources.ApplyResources(this.buttonDelGrid, "buttonDelGrid");
            this.buttonDelGrid.Name = "buttonDelGrid";
            this.buttonDelGrid.UseVisualStyleBackColor = true;
            this.buttonDelGrid.Click += new EventHandler(this.buttonDelGrid_Click);
            resources.ApplyResources(this.btnCsvLoad, "btnCsvLoad");
            this.btnCsvLoad.Name = "btnCsvLoad";
            this.btnCsvLoad.UseVisualStyleBackColor = true;
            this.btnCsvLoad.Click += new EventHandler(this.btnCsvLoad_Click);
            resources.ApplyResources(this.C, "C");
            this.C.Checked = true;
            this.C.CheckState = CheckState.Checked;
            this.C.Name = "C";
            this.C.UseVisualStyleBackColor = true;
            this.C.CheckedChanged += new EventHandler(this.C_CheckedChanged);
            resources.ApplyResources(this.CS, "CS");
            this.CS.Checked = true;
            this.CS.CheckState = CheckState.Checked;
            this.CS.Name = "CS";
            this.CS.UseVisualStyleBackColor = true;
            this.CS.CheckedChanged += new EventHandler(this.CS_CheckedChanged);
            resources.ApplyResources(this.LUA, "LUA");
            this.LUA.Checked = true;
            this.LUA.CheckState = CheckState.Checked;
            this.LUA.Name = "LUA";
            this.LUA.UseVisualStyleBackColor = true;
            this.LUA.CheckedChanged += new EventHandler(this.LUA_CheckedChanged);
            resources.ApplyResources(this.Coffee, "Coffee");
            this.Coffee.Checked = true;
            this.Coffee.CheckState = CheckState.Checked;
            this.Coffee.Name = "Coffee";
            this.Coffee.UseVisualStyleBackColor = true;
            this.Coffee.CheckedChanged += new EventHandler(this.Coffee_CheckedChanged);
            resources.ApplyResources(this.CSCat, "CSCat");
            this.CSCat.Checked = true;
            this.CSCat.CheckState = CheckState.Checked;
            this.CSCat.Name = "CSCat";
            this.CSCat.UseVisualStyleBackColor = true;
            this.CSCat.CheckedChanged += new EventHandler(this.CSCat_CheckedChanged);
            resources.ApplyResources(this.ActEditor, "ActEditor");
            this.ActEditor.Name = "ActEditor";
            this.ActEditor.UseVisualStyleBackColor = true;
            this.ActEditor.CheckedChanged += new EventHandler(this.SkillEditor_CheckedChanged);
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.ActEditor);
            base.Controls.Add(this.CSCat);
            base.Controls.Add(this.Coffee);
            base.Controls.Add(this.LUA);
            base.Controls.Add(this.CS);
            base.Controls.Add(this.C);
            base.Controls.Add(this.btnCsvLoad);
            base.Controls.Add(this.buttonDelGrid);
            base.Controls.Add(this.buttonAddGrid);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.menuStrip1);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.treeView1);
            base.Controls.Add(this.btnAddChildNode);
            base.Controls.Add(this.btnDelNode);
            base.Controls.Add(this.btnBuild);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.propertyGrid1);
            base.MainMenuStrip = this.menuStrip1;
            base.MaximizeBox = false;
            base.Name = "Form1";
            base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            base.Load += new EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Insert()
        {
            if ((this.treeView1.SelectedNode.Name == "syncData") || (this.treeView1.SelectedNode.Name == "rpcProto"))
            {
                Editor.Module tag = (Editor.Module) this.treeView1.SelectedNode.Parent.Tag;
                if (tag.CNName.Length == 0)
                {
                    MessageBox.Show("[CNName] cant be empty!!");
                    return;
                }
                if ((tag.ModuleName.Length >= 9) && (tag.ModuleName.Substring(0, 9) == "NewModule"))
                {
                    MessageBox.Show("[Name] cant head of[NewModule]!!");
                    return;
                }
                int num = 1;
                string str = "NewDataStruct" + num++;
                while (DataStruct.DataStructDic.ContainsKey(tag.ModuleName + str) || DataStruct.ContainsKey(str))
                {
                    str = "NewDataStruct" + num++;
                }
                TreeNode node = this.treeView1.SelectedNode.Nodes.Add(str);
                this.treeView1.SelectedNode.Expand();
                DataStruct struct2 = new DataStruct();
                tag.moduleDataStruct.Add(struct2);
                struct2.module = tag;
                struct2.StructName = str;
                if (this.treeView1.SelectedNode.Name == "syncData")
                {
                    struct2.ProtoType = DataStruct.protoTypeE.SyncProto;
                }
                else
                {
                    struct2.ProtoType = DataStruct.protoTypeE.RpcProto;
                }
                node.Name = "NewDataStruct";
                node.ImageIndex = 2;
                node.Tag = struct2;
                struct2.selfTreeNode = node;
                DataStruct.DataStructDic.Add(struct2.getFullName(), struct2);
                this.treeView1.SelectedNode = node;
                this.isChanged = true;
            }
            else if (this.treeView1.SelectedNode.Name == "configFile")
            {
                Editor.Module module1 = (Editor.Module) this.treeView1.SelectedNode.Parent.Tag;
                string text = "NewConfigFile";
                TreeNode node2 = this.treeView1.SelectedNode.Nodes.Add(text);
                this.treeView1.SelectedNode.Expand();
                node2.Name = "NewConfigFile";
                node2.ImageIndex = 2;
                this.treeView1.SelectedNode = node2;
            }
            else if (this.treeView1.SelectedNode.Name == "Struct")
            {
                for (int i = 0; i < this.treeView1.SelectedNode.Nodes.Count; i++)
                {
                    this.treeView1.SelectedNode.Nodes[i].Collapse();
                }
                int num3 = 1;
                string str3 = "NewDataStruct" + num3++;
                while (DataStruct.ContainsKey(str3) || Editor.Module.ContainsKey(str3))
                {
                    str3 = "NewDataStruct" + num3++;
                }
                TreeNode node3 = this.treeView1.SelectedNode.Nodes.Add(str3);
                this.treeView1.SelectedNode.Expand();
                DataStruct struct3 = new DataStruct {
                    StructName = str3,
                    ProtoType = DataStruct.protoTypeE.CommProto
                };
                node3.Name = "NewDataStruct";
                node3.ImageIndex = 2;
                node3.Tag = struct3;
                DataStructConverter.CommDataStruct.Add(struct3);
                DataStruct.DataStructDic.Add(struct3.getFullName(), struct3);
                this.treeView1.SelectedNode = node3;
            }
            else
            {
                Editor.Module.OperaterItem item;
                Editor.Module module4;
                int num8;
                string str6;
                bool flag2;
                if (this.treeView1.SelectedNode.Name != "NewDataStruct")
                {
                    if (this.treeView1.SelectedNode.Name == "Module")
                    {
                        for (int j = 0; j < this.treeView1.SelectedNode.Nodes.Count; j++)
                        {
                            this.treeView1.SelectedNode.Nodes[j].Collapse();
                        }
                        int num6 = 1;
                        string key = "NewModule" + num6++;
                        while (Editor.Module.ModuleDic.ContainsKey(key))
                        {
                            key = "NewModule" + num6++;
                        }
                        int startIdNum = 0;
                        foreach (Editor.Module module2 in Editor.Module.ModuleDic.Values)
                        {
                            if (module2.StartIdNum > startIdNum)
                            {
                                startIdNum = module2.StartIdNum;
                            }
                        }
                        startIdNum++;
                        TreeNode node5 = this.treeView1.SelectedNode.Nodes.Add(key);
                        this.treeView1.SelectedNode.Expand();
                        Editor.Module module3 = new Editor.Module {
                            ModuleName = key,
                            StartIdNum = startIdNum
                        };
                        node5.Name = "NewModule";
                        node5.ImageIndex = 4;
                        node5.Tag = module3;
                        Editor.Module.ModuleDic.Add(module3.ModuleName, module3);
                        ArrayList list = new ArrayList();
                        Editor.Module.errorDic.Add(startIdNum, list);
                        Editor.Module.ErrorModuleName name = new Editor.Module.ErrorModuleName {
                            en = module3.ModuleName,
                            cn = module3.CNName
                        };
                        Editor.Module.moduleNameDic.Add(startIdNum, name);
                        node5.Nodes.Add("Client RPC").Name = "clientRpc";
                        TreeNode node6 = node5.Nodes.Add("RPC Parameters");
                        module3.rpcProtoNode = node6;
                        node6.Name = "rpcProto";
                        node5.Nodes.Add("Module Data").Name = "syncData";
                        node5.Nodes.Add("Configuration Files").Name = "configFile";
                        node5.Expand();
                        this.treeView1.SelectedNode = node5;
                        goto Label_0A99;
                    }
                    if (this.treeView1.SelectedNode.Name != "clientRpc")
                    {
                        if (this.treeView1.SelectedNode.Name == "NewOperate")
                        {
                            Editor.Module.OperaterItem.SubOperaterItem item3 = new Editor.Module.OperaterItem.SubOperaterItem();
                            Editor.Module.OperaterItem item4 = (Editor.Module.OperaterItem) this.treeView1.SelectedNode.Tag;
                            if (item4.CNName.Length == 0)
                            {
                                MessageBox.Show("[CNName] cant be empty!!");
                                return;
                            }
                            if ((item4.Name.Length >= 10) && (item4.Name.Substring(0, 10) == "NewOperate"))
                            {
                                MessageBox.Show("[Name] cant head of[NewOperate]!!");
                                return;
                            }
                            int num9 = 1;
                            string str7 = "NewSubOperate" + num9++;
                            bool flag3 = true;
                            do
                            {
                                flag3 = true;
                                foreach (Editor.Module.OperaterItem.SubOperaterItem item5 in item4.subOperateItem)
                                {
                                    if (item5.Name == str7)
                                    {
                                        str7 = "NewSubOperate" + num9++;
                                        flag3 = false;
                                        break;
                                    }
                                }
                            }
                            while (!flag3);
                            TreeNode node8 = this.treeView1.SelectedNode.Nodes.Add(str7);
                            this.treeView1.SelectedNode.Expand();
                            item3.operaterItem = item4;
                            item3.Name = str7;
                            item4.subOperateItem.Add(item3);
                            node8.Name = "NewSubOperate";
                            node8.ImageIndex = 6;
                            node8.Tag = item3;
                            this.treeView1.SelectedNode = node8;
                        }
                        goto Label_0A99;
                    }
                    item = new Editor.Module.OperaterItem();
                    module4 = (Editor.Module) this.treeView1.SelectedNode.Parent.Tag;
                    if (module4.CNName.Length == 0)
                    {
                        MessageBox.Show("[CNName] cant be empty!!");
                        return;
                    }
                    if ((module4.ModuleName.Length >= 9) && (module4.ModuleName.Substring(0, 9) == "NewModule"))
                    {
                        MessageBox.Show("[Name] cant head of[NewModule]!!");
                        return;
                    }
                    num8 = 1;
                    str6 = "NewOperate" + num8++;
                    flag2 = true;
                }
                else
                {
                    DataStruct.FieldDescriptor descriptor = new DataStruct.FieldDescriptor();
                    DataStruct struct4 = (DataStruct) this.treeView1.SelectedNode.Tag;
                    if (struct4.CNName.Length == 0)
                    {
                        MessageBox.Show("[CNName] cant be empty!!");
                        return;
                    }
                    if ((struct4.StructName.Length >= 13) && (struct4.StructName.Substring(0, 13) == "NewDataStruct"))
                    {
                        MessageBox.Show("[Name] cant head of[NewDataStruct]!!");
                        return;
                    }
                    int num4 = 1;
                    string str4 = "NewField" + num4++;
                    bool flag = true;
                    do
                    {
                        flag = true;
                        foreach (DataStruct.FieldDescriptor descriptor2 in struct4.fieldItem)
                        {
                            if (descriptor2.FieldName == str4)
                            {
                                str4 = "NewField" + num4++;
                                flag = false;
                                break;
                            }
                        }
                    }
                    while (!flag);
                    TreeNode node4 = this.treeView1.SelectedNode.Nodes.Add(str4);
                    this.treeView1.SelectedNode.Expand();
                    descriptor.FieldId = struct4.GetMaxFieldId();
                    descriptor.dataStruct = struct4;
                    descriptor.FieldName = str4;
                    struct4.fieldItem.Add(descriptor);
                    node4.Name = "NewField";
                    node4.ImageIndex = 3;
                    node4.Tag = descriptor;
                    this.treeView1.SelectedNode = node4;
                    goto Label_0A99;
                }
                do
                {
                    flag2 = true;
                    foreach (Editor.Module.OperaterItem item2 in module4.operateItem)
                    {
                        if (item2.Name == str6)
                        {
                            str6 = "NewOperate" + num8++;
                            flag2 = false;
                            break;
                        }
                    }
                }
                while (!flag2);
                TreeNode node7 = this.treeView1.SelectedNode.Nodes.Add(str6);
                this.treeView1.SelectedNode.Expand();
                item.module = module4;
                item.Name = str6;
                module4.operateItem.Add(item);
                node7.Name = "NewOperate";
                node7.ImageIndex = 5;
                node7.Tag = item;
                this.treeView1.SelectedNode = node7;
            }
        Label_0A99:
            if (!this.isDisableBuildBtn())
            {
                this.btnBuild.Enabled = true;
            }
            this.isChanged = true;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Open();
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Insert();
        }

        private void insertToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private bool isDisableBuildBtn()
        {
            TreeNode node = this.treeView1.Nodes[0];
            TreeNode node2 = this.treeView1.Nodes[1];
            return ((node.Nodes.Count == 0) && (node2.Nodes.Count == 0));
        }

        private void LoadAllConfigFiles()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {
                Description = "请选择文件路径"
            };
            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            else
            {
                return;
            }
            this.treeView1.SelectedNode.Expand();
            Editor.Module tag = (Editor.Module) this.treeView1.SelectedNode.Parent.Tag;
            tag.configFiles.Clear();
            ConfigFile.ConfigFileDic.Clear();
            this.treeView1.SelectedNode.Nodes.Clear();
            string[] strArray = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            TreeNode selectedNode = this.treeView1.SelectedNode;
            foreach (string str2 in strArray)
            {
                string fileName = str2;
                int index = fileName.ToLower().IndexOf(".xlsx");
                int num2 = fileName.ToLower().IndexOf(@"\~$");
                if ((index >= 0) && (num2 <= 0))
                {
                    Worksheet ws = ImpExcel(fileName);
                    if (ws != null)
                    {
                        int num3 = fileName.LastIndexOf(@"\");
                        if (num3 > -1)
                        {
                            fileName = fileName.Substring(num3 + 1);
                        }
                        int length = fileName.IndexOf('_');
                        if (length < 0)
                        {
                            MessageBox.Show("file name [" + fileName + "] must be [xxx_bbb.xlsx] format");
                        }
                        else
                        {
                            int num5 = fileName.ToLower().IndexOf(".xlsx", (int) (length + 1));
                            if (num5 < 0)
                            {
                                MessageBox.Show("file name [" + fileName + "] must be [xxx_bbb.xlsx] format");
                            }
                            else
                            {
                                string str4 = fileName.Substring(length + 1, (num5 - length) - 1);
                                fileName = fileName.Substring(0, length);
                                if (ConfigFile.ContainsKey(fileName))
                                {
                                    MessageBox.Show("config file [" + fileName + "] already exist!!!");
                                }
                                else
                                {
                                    TreeNode node2 = selectedNode.Nodes.Add(fileName);
                                    node2.Name = "NewConfigFile";
                                    node2.ImageIndex = 2;
                                    ConfigFile file = new ConfigFile();
                                    file.toSetConfigName(fileName);
                                    file.CNName = str4;
                                    file.module = tag;
                                    node2.Text = fileName;
                                    node2.Name = "NewConfigFile";
                                    node2.Tag = file;
                                    ConfigFile.ConfigFileDic.Add(file.ConfigName, file);
                                    file.module.configFiles.Add(file);
                                    this.isChanged = true;
                                    ArrayList list = this.readXlsxLine(ws, 1, 0);
                                    foreach (string str5 in list)
                                    {
                                        if (((str5 != null) && (str5.ToLower() != "int")) && ((str5.ToLower() != "string") && (str5.ToLower() != "float")))
                                        {
                                            MessageBox.Show("field type[" + str5 + "] invalid only be[int/string/float]");
                                            break;
                                        }
                                    }
                                    ArrayList list2 = this.readXlsxLine(ws, 2, list.Count);
                                    ArrayList list3 = this.readXlsxLine(ws, 3, list.Count);
                                    ArrayList list4 = this.readXlsxLine(ws, 4, list.Count);
                                    ArrayList list5 = this.readXlsxLine(ws, 5, list.Count);
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        if (file.ContainField((string) list3[i]))
                                        {
                                            MessageBox.Show("already contain field [" + ((string) list3[i]) + "]");
                                            break;
                                        }
                                        ConfigFile.ConfigField field = new ConfigFile.ConfigField();
                                        field.toSetFieldType(((string) list[i]).ToLower());
                                        field.toSetFieldName((string) list3[i]);
                                        field.toSetCnName((string) list4[i]);
                                        string str6 = (string) list5[i];
                                        if (str6 != null)
                                        {
                                            str6.Replace("\r\n", " ");
                                            str6.Replace("\n", " ");
                                        }
                                        field.toSetComment(str6);
                                        if (i == 0)
                                        {
                                            field.toSetIsPri(true);
                                            if (this.GetDefaultValue((string) list2[i]).Length > 0)
                                            {
                                                field.toSetDefaultValue(this.GetDefaultValue((string) list2[i]));
                                            }
                                        }
                                        else
                                        {
                                            field.toSetDefaultValue(this.GetDefaultValue((string) list2[i]));
                                        }
                                        field.toSetCheckIndex(this.GetCheck((string) list2[i]));
                                        field.toSetIsSvr(this.GetIsSvr((string) list2[i]));
                                        field.toSetIsDes(this.GetIsDes((string) list2[i]));
                                        field.toSetValueSet(this.GetValueSet((string) list2[i]));
                                        field.toSetValueSet(this.GetValueSet((string) list2[i]));
                                        field.toSetMaxValue(this.GetMaxValue((string) list2[i]));
                                        field.toSetMinValue(this.GetMinValue((string) list2[i]));
                                        field.configFile = file;
                                        TreeNode node3 = node2.Nodes.Add(field.FieldName);
                                        node3.Name = "NewConfigField";
                                        node3.Tag = field;
                                        file.fieldItem.Add(field);
                                    }
                                    Process process = new Process {
                                        StartInfo = { 
                                            FileName = "taskkill.exe",
                                            WindowStyle = ProcessWindowStyle.Hidden,
                                            Arguments = " /F /IM EXCEL.EXE"
                                        }
                                    };
                                    process.Start();
                                    process.WaitForExit();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void loadXML(string dir)
        {
            XMLSerializer.Deserialize(this.treeView1, dir);
        }

        private void LUA_CheckedChanged(object sender, EventArgs e)
        {
            GenLangFlags.LUA = this.LUA.Checked;
        }

        private void Open()
        {
            if (!Directory.Exists(this.lastDir))
            {
                this.lastDir = Directory.GetCurrentDirectory() + @"\Out";
            }
            this.folderBrowserDialog1.SelectedPath = this.lastDir;
            if (DialogResult.Cancel != this.folderBrowserDialog1.ShowDialog())
            {
                this.lastDir = this.folderBrowserDialog1.SelectedPath;
                this.treeView1.Nodes[0].Nodes.Clear();
                this.treeView1.Nodes[1].Nodes.Clear();
                DataStructConverter.CommDataStruct.Clear();
                Editor.Module.ModuleDic.Clear();
                DataStruct.DataStructDic.Clear();
                Editor.Module.errorDic.Clear();
                string selectedPath = this.folderBrowserDialog1.SelectedPath;
                this.loadXML(selectedPath);
                ErrorSerializer.DeserializeErrorTab(selectedPath);
                this.isChanged = false;
                if (this.lastDir == "")
                {
                    this.lastDir = selectedPath;
                }
                if (this.isDisableBuildBtn())
                {
                    this.btnBuild.Enabled = false;
                }
                else
                {
                    this.btnBuild.Enabled = true;
                }
                this.button2.Enabled = false;
            }
        }

        private void Paste()
        {
            DataStruct tag;
            DataStruct.FieldDescriptor descriptor;
            if (this.copyFd != null)
            {
                tag = null;
                if (this.treeView1.SelectedNode.Name == "NewDataStruct")
                {
                    tag = (DataStruct) this.treeView1.SelectedNode.Tag;
                    goto Label_007E;
                }
                if (this.treeView1.SelectedNode.Parent.Name == "NewDataStruct")
                {
                    tag = (DataStruct) this.treeView1.SelectedNode.Parent.Tag;
                    goto Label_007E;
                }
            }
            return;
        Label_007E:
            descriptor = (DataStruct.FieldDescriptor) this.copyFd.Clone();
            int num = 1;
            string fieldName = descriptor.FieldName;
            bool flag = true;
            do
            {
                flag = true;
                foreach (DataStruct.FieldDescriptor descriptor2 in tag.fieldItem)
                {
                    if (descriptor2.FieldName == fieldName)
                    {
                        fieldName = descriptor.FieldName + num++;
                        flag = false;
                        break;
                    }
                }
            }
            while (!flag);
            TreeNode node = null;
            if (this.treeView1.SelectedNode.Name == "NewField")
            {
                node = this.treeView1.SelectedNode.Parent.Nodes.Add(fieldName);
            }
            else
            {
                node = this.treeView1.SelectedNode.Nodes.Add(fieldName);
            }
            this.treeView1.SelectedNode.Expand();
            descriptor.dataStruct = tag;
            descriptor.FieldName = fieldName;
            descriptor.FieldId = tag.GetMaxFieldId();
            tag.fieldItem.Add(descriptor);
            node.Name = "NewField";
            node.ImageIndex = 3;
            node.Tag = descriptor;
            this.isChanged = true;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.treeView1.SelectedNode.Text = this.treeView1.SelectedNode.Tag.ToString();
        }

        private ArrayList readCsvLine(string CsvContent, ref int offset)
        {
            ArrayList list = new ArrayList();
            bool flag = false;
            int length = CsvContent.Length;
            string str = "";
            while (offset < length)
            {
                if (!flag && (CsvContent[offset] == '"'))
                {
                    flag = true;
                    offset++;
                }
                else
                {
                    if (flag && (CsvContent[offset] == '"'))
                    {
                        if (CsvContent[offset + 1] == '"')
                        {
                            str = str + '"';
                            offset += 2;
                        }
                        else
                        {
                            flag = false;
                            offset++;
                        }
                        continue;
                    }
                    if (!flag)
                    {
                        if (CsvContent[offset] == ',')
                        {
                            list.Add(str);
                            offset++;
                            str = "";
                            continue;
                        }
                        if (CsvContent[offset] == '\r')
                        {
                            offset++;
                            continue;
                        }
                        if (CsvContent[offset] == '\n')
                        {
                            list.Add(str);
                            offset++;
                            return list;
                        }
                    }
                    str = str + CsvContent[offset];
                    offset++;
                }
            }
            return list;
        }

        private ArrayList readXlsxLine(Worksheet ws, int row, int colCount)
        {
            ArrayList list = new ArrayList();
            if (row <= ws.UsedRange.Rows.Count)
            {
                int count = ws.UsedRange.Columns.Count;
                if (colCount > 0)
                {
                    count = colCount;
                }
                for (int i = 0; i < count; i++)
                {
                    object obj2 = (ws.Cells[row, i + 1] as Microsoft.Office.Interop.Excel.Range).get_Value(Missing.Value);
                    if ((obj2 != null) || (colCount != 0))
                    {
                        list.Add(obj2);
                    }
                }
            }
            return list;
        }

        private void Save()
        {
            if (Editor.Module.ModuleDic.Count != 0)
            {
                XMLSerializer.Serialize(DataStructConverter.CommDataStruct, this.lastDir, this.label1);
                XMLSerializer.SerializeXML(Editor.Module.ModuleDic, this.lastDir, this.label1);
                foreach (TreeNode node in this.treeView1.Nodes)
                {
                    if (node.Name == "Module")
                    {
                        foreach (TreeNode node2 in node.Nodes)
                        {
                            Editor.Module tag = (Editor.Module) node2.Tag;
                            XMLSerializer.Serialize(tag, this.lastDir, this.label1);
                        }
                    }
                }
                this.label1.Text = "完成!!!";
                this.isChanged = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void SkillEditor_CheckedChanged(object sender, EventArgs e)
        {
            GenLangFlags.ActEditor = this.ActEditor.Checked;
        }

        private void swap_node(TreeNode node1, TreeNode node2)
        {
            if (node1.Name == node2.Name)
            {
                if (node1.Name == "NewDataStruct")
                {
                    DataStruct struct2 = null;
                    DataStruct struct3 = null;
                    if (node1.Parent.Name == "Struct")
                    {
                        foreach (DataStruct struct4 in DataStructConverter.CommDataStruct)
                        {
                            if (node1.Text == struct4.StructName)
                            {
                                struct2 = struct4;
                            }
                            else if (node2.Text == struct4.StructName)
                            {
                                struct3 = struct4;
                            }
                        }
                        int index = DataStructConverter.CommDataStruct.IndexOf(struct2, 0);
                        int num2 = DataStructConverter.CommDataStruct.IndexOf(struct3, 0);
                        DataStruct struct5 = null;
                        struct5 = (DataStruct) DataStructConverter.CommDataStruct[index];
                        DataStructConverter.CommDataStruct[index] = DataStructConverter.CommDataStruct[num2];
                        DataStructConverter.CommDataStruct[num2] = struct5;
                    }
                    else if (node1.Parent.Name == "NewModule")
                    {
                        Editor.Module tag = (Editor.Module) node1.Parent.Tag;
                        foreach (DataStruct struct6 in tag.moduleDataStruct)
                        {
                            if (node1.Text == struct6.StructName)
                            {
                                struct2 = struct6;
                            }
                            else if (node2.Text == struct6.StructName)
                            {
                                struct3 = struct6;
                            }
                        }
                        int num3 = tag.moduleDataStruct.IndexOf(struct2, 0);
                        int num4 = tag.moduleDataStruct.IndexOf(struct3, 0);
                        DataStruct struct7 = null;
                        struct7 = (DataStruct) tag.moduleDataStruct[num3];
                        tag.moduleDataStruct[num3] = tag.moduleDataStruct[num4];
                        tag.moduleDataStruct[num4] = struct7;
                    }
                }
                else if (node1.Name == "NewField")
                {
                    DataStruct struct8 = (DataStruct) node1.Parent.Tag;
                    DataStruct.FieldDescriptor descriptor = null;
                    DataStruct.FieldDescriptor descriptor2 = null;
                    foreach (DataStruct.FieldDescriptor descriptor3 in struct8.fieldItem)
                    {
                        if (node1.Text == descriptor3.FieldName)
                        {
                            descriptor = descriptor3;
                        }
                        else if (node2.Text == descriptor3.FieldName)
                        {
                            descriptor2 = descriptor3;
                        }
                    }
                    int num5 = struct8.fieldItem.IndexOf(descriptor, 0);
                    int num6 = struct8.fieldItem.IndexOf(descriptor2, 0);
                    DataStruct.FieldDescriptor descriptor4 = null;
                    descriptor4 = (DataStruct.FieldDescriptor) struct8.fieldItem[num5];
                    struct8.fieldItem[num5] = struct8.fieldItem[num6];
                    struct8.fieldItem[num6] = descriptor4;
                }
                else if (node1.Name == "NewOperate")
                {
                    Editor.Module module2 = (Editor.Module) node1.Parent.Tag;
                    Editor.Module.OperaterItem item = null;
                    Editor.Module.OperaterItem item2 = null;
                    foreach (Editor.Module.OperaterItem item3 in module2.operateItem)
                    {
                        if (node1.Text == item3.Name)
                        {
                            item = item3;
                        }
                        else if (node2.Text == item3.Name)
                        {
                            item2 = item3;
                        }
                    }
                    int num7 = module2.operateItem.IndexOf(item, 0);
                    int num8 = module2.operateItem.IndexOf(item2, 0);
                    Editor.Module.OperaterItem item4 = null;
                    item4 = (Editor.Module.OperaterItem) module2.operateItem[num7];
                    module2.operateItem[num7] = module2.operateItem[num8];
                    module2.operateItem[num8] = item4;
                }
                else if (node1.Name == "NewSubOperate")
                {
                    Editor.Module.OperaterItem item5 = (Editor.Module.OperaterItem) node1.Parent.Tag;
                    Editor.Module.OperaterItem.SubOperaterItem item6 = null;
                    Editor.Module.OperaterItem.SubOperaterItem item7 = null;
                    foreach (Editor.Module.OperaterItem.SubOperaterItem item8 in item5.subOperateItem)
                    {
                        if (node1.Text == item8.Name)
                        {
                            item6 = item8;
                        }
                        else if (node2.Text == item8.Name)
                        {
                            item7 = item8;
                        }
                    }
                    int num9 = item5.subOperateItem.IndexOf(item6, 0);
                    int num10 = item5.subOperateItem.IndexOf(item7, 0);
                    Editor.Module.OperaterItem.SubOperaterItem item9 = null;
                    item9 = (Editor.Module.OperaterItem.SubOperaterItem) item5.subOperateItem[num9];
                    item5.subOperateItem[num9] = item5.subOperateItem[num10];
                    item5.subOperateItem[num10] = item9;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.propertyGrid1.SelectedObject = this.treeView1.SelectedNode.Tag;
            if ((this.treeView1.SelectedNode.Name == "NewConfigFile") || (this.treeView1.SelectedNode.Name == "configFile"))
            {
                this.btnCsvLoad.Enabled = true;
            }
            else
            {
                this.btnCsvLoad.Enabled = false;
            }
            if ((((this.treeView1.SelectedNode.Name == "Struct") || (this.treeView1.SelectedNode.Name == "Module")) || ((this.treeView1.SelectedNode.Name == "clientRpc") || (this.treeView1.SelectedNode.Name == "rpcProto"))) || ((this.treeView1.SelectedNode.Name == "configFile") || (this.treeView1.SelectedNode.Name == "syncData")))
            {
                this.btnDelNode.Enabled = false;
                this.contextMenuStrip1.Items[0].Enabled = false;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[1].Enabled = false;
            }
            else
            {
                this.btnDelNode.Enabled = true;
                this.contextMenuStrip1.Items[0].Enabled = true;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[1].Enabled = true;
            }
            if (this.treeView1.SelectedNode.Name != "NewModule")
            {
                this.btnAddChildNode.Enabled = true;
                this.buttonAddGrid.Enabled = false;
                this.buttonDelGrid.Enabled = false;
                this.dataGridView1.Enabled = false;
            }
            else
            {
                this.btnAddChildNode.Enabled = false;
                this.buttonAddGrid.Enabled = true;
                this.buttonDelGrid.Enabled = true;
                this.dataGridView1.Enabled = true;
                this.dataGridView1.Rows.Clear();
                Editor.Module tag = this.treeView1.SelectedNode.Tag as Editor.Module;
                Editor.Module.key = tag.StartIdNum;
                foreach (KeyValuePair<int, ArrayList> pair in Editor.Module.errorDic)
                {
                    if (pair.Key == Editor.Module.key)
                    {
                        foreach (Editor.Module.Error error in pair.Value)
                        {
                            if (error.id != null)
                            {
                                string[] values = new string[] { error.id, error.name };
                                this.dataGridView1.Rows.Add(values);
                            }
                        }
                        break;
                    }
                }
            }
            if ((this.treeView1.SelectedNode.Name == "NewField") || (this.treeView1.SelectedNode.Name == "NewSubOperate"))
            {
                this.btnAddChildNode.Enabled = false;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[0].Enabled = false;
            }
            else
            {
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[0].Enabled = true;
            }
            if (this.treeView1.SelectedNode.Name == "NewDataStruct")
            {
                this.contextMenuStrip1.Items[3].Enabled = false;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[2].Enabled = false;
                if (this.copyFd != null)
                {
                    this.contextMenuStrip1.Items[4].Enabled = true;
                    ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[3].Enabled = true;
                }
            }
            else if (this.treeView1.SelectedNode.Name == "NewField")
            {
                this.contextMenuStrip1.Items[3].Enabled = true;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[2].Enabled = true;
                if (this.copyFd != null)
                {
                    this.contextMenuStrip1.Items[4].Enabled = true;
                    ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[3].Enabled = true;
                }
            }
            else
            {
                this.contextMenuStrip1.Items[3].Enabled = false;
                this.contextMenuStrip1.Items[4].Enabled = false;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[2].Enabled = false;
                ((ToolStripMenuItem) this.menuStrip1.Items[1]).DropDownItems[3].Enabled = false;
            }
            if (this.treeView1.SelectedNode.Name == "Struct")
            {
                if (this.treeView1.SelectedNode.Nodes.Count >= 1)
                {
                    this.contextMenuStrip1.Items[5].Enabled = true;
                }
                else
                {
                    this.contextMenuStrip1.Items[5].Enabled = false;
                }
            }
            else if (this.treeView1.SelectedNode.Name == "NewModule")
            {
                this.contextMenuStrip1.Items[5].Enabled = true;
            }
            else
            {
                this.contextMenuStrip1.Items[5].Enabled = false;
            }
            if ((this.treeView1.SelectedNode.Name == "NewConfigFile") || (this.treeView1.SelectedNode.Name == "NewConfigField"))
            {
                this.btnAddChildNode.Enabled = false;
                if (this.treeView1.SelectedNode.Name == "NewConfigField")
                {
                    this.btnDelNode.Enabled = false;
                }
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);
            TreeNode nodeAt = this.treeView1.GetNodeAt(pt);
            if (nodeAt != null)
            {
                this.treeView1.SelectedNode = nodeAt;
            }
        }
    }
}

