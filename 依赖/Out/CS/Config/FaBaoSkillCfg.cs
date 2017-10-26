using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//法宝技能配置数据类
public class FaBaoSkillElement
{
	public int ID;               	//编号	法宝技能ID
	public string Name;          	//技能名称	技能名称
	public int Lv;               	//技能等级	技能等级
	public string MiaoShu;       	//技能描述	技能描述

	public bool IsValidate = false;
	public FaBaoSkillElement()
	{
		ID = -1;
	}
};

//法宝技能配置封装类
public class FaBaoSkillTable
{

	private FaBaoSkillTable()
	{
		m_mapElements = new Dictionary<int, FaBaoSkillElement>();
		m_emptyItem = new FaBaoSkillElement();
		m_vecAllElements = new List<FaBaoSkillElement>();
	}
	private Dictionary<int, FaBaoSkillElement> m_mapElements = null;
	private List<FaBaoSkillElement>	m_vecAllElements = null;
	private FaBaoSkillElement m_emptyItem = null;
	private static FaBaoSkillTable sInstance = null;

	public static FaBaoSkillTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FaBaoSkillTable();
			return sInstance;
		}
	}

	public FaBaoSkillElement GetElement(int key)
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

  public List<FaBaoSkillElement> GetAllElement(Predicate<FaBaoSkillElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("FaBaoSkill.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("FaBaoSkill.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[FaBaoSkill.bin]未找到");
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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("FaBaoSkill.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FaBaoSkill.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("FaBaoSkill.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Lv"){Ex.Logger.Log("FaBaoSkill.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[3]!="MiaoShu"){Ex.Logger.Log("FaBaoSkill.csv中字段[MiaoShu]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FaBaoSkillElement member = new FaBaoSkillElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MiaoShu);

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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("FaBaoSkill.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FaBaoSkill.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("FaBaoSkill.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Lv"){Ex.Logger.Log("FaBaoSkill.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[3]!="MiaoShu"){Ex.Logger.Log("FaBaoSkill.csv中字段[MiaoShu]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			FaBaoSkillElement member = new FaBaoSkillElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Lv=Convert.ToInt32(vecLine[2]);
			member.MiaoShu=vecLine[3];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
