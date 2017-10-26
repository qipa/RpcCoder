using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//Npc基础表配置数据类
public class NpcElement
{
	public int NpcID;            	//NpcID	编号
	public int ModelID;          	//模型ID	索引模型
	public float ModelScaling;   	//模型缩放	模型缩放比例，包含模型的所有东西进行缩放
	public string Name;          	//NPC名称	NPC名称
	public string Title;         	//NPC称号	NPC称号
	public string HeadIcon;      	//头像	NPC头像
	public int Level;            	//等级	NPC的等级
	public float NpcR;           	//半径	怪物模型的大小,单位：m
	public int DialogID;         	//对话ID	触发的对话ID
	public int FunctionID;       	//功能ID	调用哪个功能（1_PVE,2_PVP,3_武器店，4_装备店,5_药店，6_帮会副本,7师门8一条龙9江洋大盗10降妖除魔11帮会货运12大逃杀,21帮会刺探99跨场景传送）
	public string DungeonsID;    	//场景ID	决定传送到哪个场景
	public string Dialog;        	//默认对话	默认对话
	public float banjing;        	//模型半径	触发重叠光效的距离

	public bool IsValidate = false;
	public NpcElement()
	{
		NpcID = -1;
	}
};

//Npc基础表配置封装类
public class NpcTable
{

	private NpcTable()
	{
		m_mapElements = new Dictionary<int, NpcElement>();
		m_emptyItem = new NpcElement();
		m_vecAllElements = new List<NpcElement>();
	}
	private Dictionary<int, NpcElement> m_mapElements = null;
	private List<NpcElement>	m_vecAllElements = null;
	private NpcElement m_emptyItem = null;
	private static NpcTable sInstance = null;

	public static NpcTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new NpcTable();
			return sInstance;
		}
	}

	public NpcElement GetElement(int key)
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

  public List<NpcElement> GetAllElement(Predicate<NpcElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Npc.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Npc.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Npc.bin]未找到");
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
			Ex.Logger.Log("Npc.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="NpcID"){Ex.Logger.Log("Npc.csv中字段[NpcID]位置不对应"); return false; }
		if(vecLine[1]!="ModelID"){Ex.Logger.Log("Npc.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[2]!="ModelScaling"){Ex.Logger.Log("Npc.csv中字段[ModelScaling]位置不对应"); return false; }
		if(vecLine[3]!="Name"){Ex.Logger.Log("Npc.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[4]!="Title"){Ex.Logger.Log("Npc.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[5]!="HeadIcon"){Ex.Logger.Log("Npc.csv中字段[HeadIcon]位置不对应"); return false; }
		if(vecLine[6]!="Level"){Ex.Logger.Log("Npc.csv中字段[Level]位置不对应"); return false; }
		if(vecLine[7]!="NpcR"){Ex.Logger.Log("Npc.csv中字段[NpcR]位置不对应"); return false; }
		if(vecLine[8]!="DialogID"){Ex.Logger.Log("Npc.csv中字段[DialogID]位置不对应"); return false; }
		if(vecLine[9]!="FunctionID"){Ex.Logger.Log("Npc.csv中字段[FunctionID]位置不对应"); return false; }
		if(vecLine[10]!="DungeonsID"){Ex.Logger.Log("Npc.csv中字段[DungeonsID]位置不对应"); return false; }
		if(vecLine[11]!="Dialog"){Ex.Logger.Log("Npc.csv中字段[Dialog]位置不对应"); return false; }
		if(vecLine[12]!="banjing"){Ex.Logger.Log("Npc.csv中字段[banjing]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			NpcElement member = new NpcElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.NpcID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.ModelScaling);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Title);
			readPos += GameAssist.ReadString( binContent, readPos, out member.HeadIcon);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Level );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.NpcR);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DialogID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FunctionID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DungeonsID);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Dialog);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.banjing);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.NpcID] = member;
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
			Ex.Logger.Log("Npc.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="NpcID"){Ex.Logger.Log("Npc.csv中字段[NpcID]位置不对应"); return false; }
		if(vecLine[1]!="ModelID"){Ex.Logger.Log("Npc.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[2]!="ModelScaling"){Ex.Logger.Log("Npc.csv中字段[ModelScaling]位置不对应"); return false; }
		if(vecLine[3]!="Name"){Ex.Logger.Log("Npc.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[4]!="Title"){Ex.Logger.Log("Npc.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[5]!="HeadIcon"){Ex.Logger.Log("Npc.csv中字段[HeadIcon]位置不对应"); return false; }
		if(vecLine[6]!="Level"){Ex.Logger.Log("Npc.csv中字段[Level]位置不对应"); return false; }
		if(vecLine[7]!="NpcR"){Ex.Logger.Log("Npc.csv中字段[NpcR]位置不对应"); return false; }
		if(vecLine[8]!="DialogID"){Ex.Logger.Log("Npc.csv中字段[DialogID]位置不对应"); return false; }
		if(vecLine[9]!="FunctionID"){Ex.Logger.Log("Npc.csv中字段[FunctionID]位置不对应"); return false; }
		if(vecLine[10]!="DungeonsID"){Ex.Logger.Log("Npc.csv中字段[DungeonsID]位置不对应"); return false; }
		if(vecLine[11]!="Dialog"){Ex.Logger.Log("Npc.csv中字段[Dialog]位置不对应"); return false; }
		if(vecLine[12]!="banjing"){Ex.Logger.Log("Npc.csv中字段[banjing]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)13)
			{
				return false;
			}
			NpcElement member = new NpcElement();
			member.NpcID=Convert.ToInt32(vecLine[0]);
			member.ModelID=Convert.ToInt32(vecLine[1]);
			member.ModelScaling=Convert.ToSingle(vecLine[2]);
			member.Name=vecLine[3];
			member.Title=vecLine[4];
			member.HeadIcon=vecLine[5];
			member.Level=Convert.ToInt32(vecLine[6]);
			member.NpcR=Convert.ToSingle(vecLine[7]);
			member.DialogID=Convert.ToInt32(vecLine[8]);
			member.FunctionID=Convert.ToInt32(vecLine[9]);
			member.DungeonsID=vecLine[10];
			member.Dialog=vecLine[11];
			member.banjing=Convert.ToSingle(vecLine[12]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.NpcID] = member;
		}
		return true;
	}
};
