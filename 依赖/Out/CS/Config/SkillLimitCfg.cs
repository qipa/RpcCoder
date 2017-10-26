using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//技能限制配置数据类
public class SkillLimitElement
{
	public int LimitID;          	//限制ID	限制ID
	public int RoleLv;           	//角色等级	激活技能的角色等级限制
	public int Book;             	//激活所需技能书	激活所需技能书
	public int SkillLimit;       	//前置技能限制	前置技能限制
	public int LvUpLimitSkillLv; 	//升级技能所需前置技能等级	前置技能等级+x=当前技能等级
	public int LvUpRoleLv;       	//升级技能所需角色等级	技能每升1级所需人物等级提升等级

	public bool IsValidate = false;
	public SkillLimitElement()
	{
		LimitID = -1;
	}
};

//技能限制配置封装类
public class SkillLimitTable
{

	private SkillLimitTable()
	{
		m_mapElements = new Dictionary<int, SkillLimitElement>();
		m_emptyItem = new SkillLimitElement();
		m_vecAllElements = new List<SkillLimitElement>();
	}
	private Dictionary<int, SkillLimitElement> m_mapElements = null;
	private List<SkillLimitElement>	m_vecAllElements = null;
	private SkillLimitElement m_emptyItem = null;
	private static SkillLimitTable sInstance = null;

	public static SkillLimitTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SkillLimitTable();
			return sInstance;
		}
	}

	public SkillLimitElement GetElement(int key)
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

  public List<SkillLimitElement> GetAllElement(Predicate<SkillLimitElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("SkillLimit.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("SkillLimit.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[SkillLimit.bin]未找到");
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
			Ex.Logger.Log("SkillLimit.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LimitID"){Ex.Logger.Log("SkillLimit.csv中字段[LimitID]位置不对应"); return false; }
		if(vecLine[1]!="RoleLv"){Ex.Logger.Log("SkillLimit.csv中字段[RoleLv]位置不对应"); return false; }
		if(vecLine[2]!="Book"){Ex.Logger.Log("SkillLimit.csv中字段[Book]位置不对应"); return false; }
		if(vecLine[3]!="SkillLimit"){Ex.Logger.Log("SkillLimit.csv中字段[SkillLimit]位置不对应"); return false; }
		if(vecLine[4]!="LvUpLimitSkillLv"){Ex.Logger.Log("SkillLimit.csv中字段[LvUpLimitSkillLv]位置不对应"); return false; }
		if(vecLine[5]!="LvUpRoleLv"){Ex.Logger.Log("SkillLimit.csv中字段[LvUpRoleLv]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SkillLimitElement member = new SkillLimitElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LimitID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RoleLv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Book );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillLimit );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvUpLimitSkillLv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvUpRoleLv );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LimitID] = member;
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
			Ex.Logger.Log("SkillLimit.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LimitID"){Ex.Logger.Log("SkillLimit.csv中字段[LimitID]位置不对应"); return false; }
		if(vecLine[1]!="RoleLv"){Ex.Logger.Log("SkillLimit.csv中字段[RoleLv]位置不对应"); return false; }
		if(vecLine[2]!="Book"){Ex.Logger.Log("SkillLimit.csv中字段[Book]位置不对应"); return false; }
		if(vecLine[3]!="SkillLimit"){Ex.Logger.Log("SkillLimit.csv中字段[SkillLimit]位置不对应"); return false; }
		if(vecLine[4]!="LvUpLimitSkillLv"){Ex.Logger.Log("SkillLimit.csv中字段[LvUpLimitSkillLv]位置不对应"); return false; }
		if(vecLine[5]!="LvUpRoleLv"){Ex.Logger.Log("SkillLimit.csv中字段[LvUpRoleLv]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			SkillLimitElement member = new SkillLimitElement();
			member.LimitID=Convert.ToInt32(vecLine[0]);
			member.RoleLv=Convert.ToInt32(vecLine[1]);
			member.Book=Convert.ToInt32(vecLine[2]);
			member.SkillLimit=Convert.ToInt32(vecLine[3]);
			member.LvUpLimitSkillLv=Convert.ToInt32(vecLine[4]);
			member.LvUpRoleLv=Convert.ToInt32(vecLine[5]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LimitID] = member;
		}
		return true;
	}
};
