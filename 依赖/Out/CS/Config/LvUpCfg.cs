using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//等级提升配置数据类
public class LvUpElement
{
	public int LvID;             	//编号	等级
	public int Exp;              	//经验	升级所需经验
	public int Spirit;           	//体力	体力上限
	public int SkillLvUp;        	//技能1升级消耗金钱	技能1升级消耗金钱
	public int SkillLvUpMoney;   	//技能消耗金钱	技能消耗金钱
	public int XiuWei;           	//修为对应消耗经验	修为对应消耗经验

	public bool IsValidate = false;
	public LvUpElement()
	{
		LvID = -1;
	}
};

//等级提升配置封装类
public class LvUpTable
{

	private LvUpTable()
	{
		m_mapElements = new Dictionary<int, LvUpElement>();
		m_emptyItem = new LvUpElement();
		m_vecAllElements = new List<LvUpElement>();
	}
	private Dictionary<int, LvUpElement> m_mapElements = null;
	private List<LvUpElement>	m_vecAllElements = null;
	private LvUpElement m_emptyItem = null;
	private static LvUpTable sInstance = null;

	public static LvUpTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new LvUpTable();
			return sInstance;
		}
	}

	public LvUpElement GetElement(int key)
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

  public List<LvUpElement> GetAllElement(Predicate<LvUpElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("LvUp.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("LvUp.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[LvUp.bin]未找到");
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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("LvUp.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LvID"){Ex.Logger.Log("LvUp.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[1]!="Exp"){Ex.Logger.Log("LvUp.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[2]!="Spirit"){Ex.Logger.Log("LvUp.csv中字段[Spirit]位置不对应"); return false; }
		if(vecLine[3]!="SkillLvUp"){Ex.Logger.Log("LvUp.csv中字段[SkillLvUp]位置不对应"); return false; }
		if(vecLine[4]!="SkillLvUpMoney"){Ex.Logger.Log("LvUp.csv中字段[SkillLvUpMoney]位置不对应"); return false; }
		if(vecLine[5]!="XiuWei"){Ex.Logger.Log("LvUp.csv中字段[XiuWei]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			LvUpElement member = new LvUpElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Exp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Spirit );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillLvUp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillLvUpMoney );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiuWei );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LvID] = member;
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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("LvUp.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LvID"){Ex.Logger.Log("LvUp.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[1]!="Exp"){Ex.Logger.Log("LvUp.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[2]!="Spirit"){Ex.Logger.Log("LvUp.csv中字段[Spirit]位置不对应"); return false; }
		if(vecLine[3]!="SkillLvUp"){Ex.Logger.Log("LvUp.csv中字段[SkillLvUp]位置不对应"); return false; }
		if(vecLine[4]!="SkillLvUpMoney"){Ex.Logger.Log("LvUp.csv中字段[SkillLvUpMoney]位置不对应"); return false; }
		if(vecLine[5]!="XiuWei"){Ex.Logger.Log("LvUp.csv中字段[XiuWei]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			LvUpElement member = new LvUpElement();
			member.LvID=Convert.ToInt32(vecLine[0]);
			member.Exp=Convert.ToInt32(vecLine[1]);
			member.Spirit=Convert.ToInt32(vecLine[2]);
			member.SkillLvUp=Convert.ToInt32(vecLine[3]);
			member.SkillLvUpMoney=Convert.ToInt32(vecLine[4]);
			member.XiuWei=Convert.ToInt32(vecLine[5]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LvID] = member;
		}
		return true;
	}
};
