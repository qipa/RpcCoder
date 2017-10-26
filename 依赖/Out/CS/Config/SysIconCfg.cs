using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//主界面图标配置配置数据类
public class SysIconElement
{
	public int ID;               	//图标的ID	图标的ID
	public string Name;          	//对应功能名称	对应功能名称
	public string Desc;          	//功能描述策划用	功能描述策划用
	public int Type;             	//图标位于的类别区域	图标位于的类别区域
	public int Order;            	//位置权重	位置权重
	public string Icon;          	//对应图标资源	对应图标资源
	public int ShowLv;           	//图标显示等级	图标显示等级
	public int ShowTaskRe;       	//图标显示需要接取的任务	图标显示需要接取的任务
	public int ShowTaskCo;       	//图标显示需要完成的任务	图标显示需要完成的任务
	public int OpenLv;           	//图标开启等级	图标开启等级
	public int OpenTaskRe;       	//图标开启需要接取的任务	图标开启需要接取的任务
	public int OpenTaskCo;       	//图标开启需要完成的任务	图标开启需要完成的任务
	public int Prompt;           	//功能开启是否需要提示	功能开启是否需要提示

	public bool IsValidate = false;
	public SysIconElement()
	{
		ID = -1;
	}
};

//主界面图标配置配置封装类
public class SysIconTable
{

	private SysIconTable()
	{
		m_mapElements = new Dictionary<int, SysIconElement>();
		m_emptyItem = new SysIconElement();
		m_vecAllElements = new List<SysIconElement>();
	}
	private Dictionary<int, SysIconElement> m_mapElements = null;
	private List<SysIconElement>	m_vecAllElements = null;
	private SysIconElement m_emptyItem = null;
	private static SysIconTable sInstance = null;

	public static SysIconTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SysIconTable();
			return sInstance;
		}
	}

	public SysIconElement GetElement(int key)
	{
		if( m_mapElements.ContainsKey(key) )
			return m_mapElements[key];
		return null;
	}

	public int GetElementCount()
	{
		return m_mapElements.Count;
	}
	public bool HasElement(int key)
	{
		return m_mapElements.ContainsKey(key);
	}

  public List<SysIconElement> GetAllElement(Predicate<SysIconElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("SysIcon.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("SysIcon.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[SysIcon.bin]未找到");
			return false;
		}
		return LoadBin(binTableContent);
	}


	public bool LoadBin(byte[] binContent)
	{
		m_mapElements.Clear();
		m_vecAllElements.Clear();
		int nCol, nRow;
		int readPos = 0;
		readPos += GameAssist.ReadInt32Variant( binContent, readPos, out nCol );
		readPos += GameAssist.ReadInt32Variant( binContent, readPos, out nRow );
		List<string> vecLine = new List<string>(nCol);
		List<int> vecHeadType = new List<int>(nCol);
        string tmpStr;
        int tmpInt;
		for( int i=0; i<nCol; i++ )
		{
            readPos += GameAssist.ReadString(binContent, readPos, out tmpStr);
            readPos += GameAssist.ReadInt32Variant(binContent, readPos, out tmpInt);
            vecLine.Add(tmpStr);
            vecHeadType.Add(tmpInt);
		}
		if(vecLine.Count != 13)
		{
			Ex.Logger.Log("SysIcon.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SysIcon.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("SysIcon.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Desc"){Ex.Logger.Log("SysIcon.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("SysIcon.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Order"){Ex.Logger.Log("SysIcon.csv中字段[Order]位置不对应"); return false; }
		if(vecLine[5]!="Icon"){Ex.Logger.Log("SysIcon.csv中字段[Icon]位置不对应"); return false; }
		if(vecLine[6]!="ShowLv"){Ex.Logger.Log("SysIcon.csv中字段[ShowLv]位置不对应"); return false; }
		if(vecLine[7]!="ShowTaskRe"){Ex.Logger.Log("SysIcon.csv中字段[ShowTaskRe]位置不对应"); return false; }
		if(vecLine[8]!="ShowTaskCo"){Ex.Logger.Log("SysIcon.csv中字段[ShowTaskCo]位置不对应"); return false; }
		if(vecLine[9]!="OpenLv"){Ex.Logger.Log("SysIcon.csv中字段[OpenLv]位置不对应"); return false; }
		if(vecLine[10]!="OpenTaskRe"){Ex.Logger.Log("SysIcon.csv中字段[OpenTaskRe]位置不对应"); return false; }
		if(vecLine[11]!="OpenTaskCo"){Ex.Logger.Log("SysIcon.csv中字段[OpenTaskCo]位置不对应"); return false; }
		if(vecLine[12]!="Prompt"){Ex.Logger.Log("SysIcon.csv中字段[Prompt]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SysIconElement member = new SysIconElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Desc);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Order );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Icon);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShowLv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShowTaskRe );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShowTaskCo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.OpenLv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.OpenTaskRe );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.OpenTaskCo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Prompt );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
	public bool LoadCsv(string strContent)
	{
		if( strContent.Length == 0 )
			return false;
		m_mapElements.Clear();
		m_vecAllElements.Clear();
		int contentOffset = 0;
		List<string> vecLine;
		vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
		if(vecLine.Count != 13)
		{
			Ex.Logger.Log("SysIcon.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SysIcon.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("SysIcon.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Desc"){Ex.Logger.Log("SysIcon.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("SysIcon.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Order"){Ex.Logger.Log("SysIcon.csv中字段[Order]位置不对应"); return false; }
		if(vecLine[5]!="Icon"){Ex.Logger.Log("SysIcon.csv中字段[Icon]位置不对应"); return false; }
		if(vecLine[6]!="ShowLv"){Ex.Logger.Log("SysIcon.csv中字段[ShowLv]位置不对应"); return false; }
		if(vecLine[7]!="ShowTaskRe"){Ex.Logger.Log("SysIcon.csv中字段[ShowTaskRe]位置不对应"); return false; }
		if(vecLine[8]!="ShowTaskCo"){Ex.Logger.Log("SysIcon.csv中字段[ShowTaskCo]位置不对应"); return false; }
		if(vecLine[9]!="OpenLv"){Ex.Logger.Log("SysIcon.csv中字段[OpenLv]位置不对应"); return false; }
		if(vecLine[10]!="OpenTaskRe"){Ex.Logger.Log("SysIcon.csv中字段[OpenTaskRe]位置不对应"); return false; }
		if(vecLine[11]!="OpenTaskCo"){Ex.Logger.Log("SysIcon.csv中字段[OpenTaskCo]位置不对应"); return false; }
		if(vecLine[12]!="Prompt"){Ex.Logger.Log("SysIcon.csv中字段[Prompt]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)13)
			{
				return false;
			}
			SysIconElement member = new SysIconElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Desc=vecLine[2];
			member.Type=Convert.ToInt32(vecLine[3]);
			member.Order=Convert.ToInt32(vecLine[4]);
			member.Icon=vecLine[5];
			member.ShowLv=Convert.ToInt32(vecLine[6]);
			member.ShowTaskRe=Convert.ToInt32(vecLine[7]);
			member.ShowTaskCo=Convert.ToInt32(vecLine[8]);
			member.OpenLv=Convert.ToInt32(vecLine[9]);
			member.OpenTaskRe=Convert.ToInt32(vecLine[10]);
			member.OpenTaskCo=Convert.ToInt32(vecLine[11]);
			member.Prompt=Convert.ToInt32(vecLine[12]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
