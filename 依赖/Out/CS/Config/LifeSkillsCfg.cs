using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//生活技能表配置数据类
public class LifeSkillsElement
{
	public int ID;               	//编号	编号
	public int LifeSkills;       	//生活技能	生活技能（1采集2种植3钓鱼4饲养5炼药6烹饪）
	public int LvID;             	//等级	等级
	public int Exp;              	//消耗帮贡	升级所需帮贡
	public int Money;            	//消耗银票	升级所需银票
	public string SourceIcon;    	//技能图片	技能图片
	public string ButtonName;    	//按钮名字	按钮名字
	public string LifeSkillsName;	//生活技能名字	生活技能名字
	public string describe;      	//描述	描述

	public bool IsValidate = false;
	public LifeSkillsElement()
	{
		ID = -1;
	}
};

//生活技能表配置封装类
public class LifeSkillsTable
{

	private LifeSkillsTable()
	{
		m_mapElements = new Dictionary<int, LifeSkillsElement>();
		m_emptyItem = new LifeSkillsElement();
		m_vecAllElements = new List<LifeSkillsElement>();
	}
	private Dictionary<int, LifeSkillsElement> m_mapElements = null;
	private List<LifeSkillsElement>	m_vecAllElements = null;
	private LifeSkillsElement m_emptyItem = null;
	private static LifeSkillsTable sInstance = null;

	public static LifeSkillsTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new LifeSkillsTable();
			return sInstance;
		}
	}

	public LifeSkillsElement GetElement(int key)
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

  public List<LifeSkillsElement> GetAllElement(Predicate<LifeSkillsElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("LifeSkills.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("LifeSkills.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[LifeSkills.bin]未找到");
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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("LifeSkills.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("LifeSkills.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="LifeSkills"){Ex.Logger.Log("LifeSkills.csv中字段[LifeSkills]位置不对应"); return false; }
		if(vecLine[2]!="LvID"){Ex.Logger.Log("LifeSkills.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[3]!="Exp"){Ex.Logger.Log("LifeSkills.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[4]!="Money"){Ex.Logger.Log("LifeSkills.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[5]!="SourceIcon"){Ex.Logger.Log("LifeSkills.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[6]!="ButtonName"){Ex.Logger.Log("LifeSkills.csv中字段[ButtonName]位置不对应"); return false; }
		if(vecLine[7]!="LifeSkillsName"){Ex.Logger.Log("LifeSkills.csv中字段[LifeSkillsName]位置不对应"); return false; }
		if(vecLine[8]!="describe"){Ex.Logger.Log("LifeSkills.csv中字段[describe]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			LifeSkillsElement member = new LifeSkillsElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LifeSkills );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Exp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SourceIcon);
			readPos += GameAssist.ReadString( binContent, readPos, out member.ButtonName);
			readPos += GameAssist.ReadString( binContent, readPos, out member.LifeSkillsName);
			readPos += GameAssist.ReadString( binContent, readPos, out member.describe);

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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("LifeSkills.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("LifeSkills.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="LifeSkills"){Ex.Logger.Log("LifeSkills.csv中字段[LifeSkills]位置不对应"); return false; }
		if(vecLine[2]!="LvID"){Ex.Logger.Log("LifeSkills.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[3]!="Exp"){Ex.Logger.Log("LifeSkills.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[4]!="Money"){Ex.Logger.Log("LifeSkills.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[5]!="SourceIcon"){Ex.Logger.Log("LifeSkills.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[6]!="ButtonName"){Ex.Logger.Log("LifeSkills.csv中字段[ButtonName]位置不对应"); return false; }
		if(vecLine[7]!="LifeSkillsName"){Ex.Logger.Log("LifeSkills.csv中字段[LifeSkillsName]位置不对应"); return false; }
		if(vecLine[8]!="describe"){Ex.Logger.Log("LifeSkills.csv中字段[describe]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)9)
			{
				return false;
			}
			LifeSkillsElement member = new LifeSkillsElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.LifeSkills=Convert.ToInt32(vecLine[1]);
			member.LvID=Convert.ToInt32(vecLine[2]);
			member.Exp=Convert.ToInt32(vecLine[3]);
			member.Money=Convert.ToInt32(vecLine[4]);
			member.SourceIcon=vecLine[5];
			member.ButtonName=vecLine[6];
			member.LifeSkillsName=vecLine[7];
			member.describe=vecLine[8];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
