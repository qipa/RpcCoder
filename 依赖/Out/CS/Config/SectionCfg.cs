using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//章节表配置数据类
public class SectionElement
{
	public int SectionID;        	//章节ID	章节ID
	public string Name;          	//章节名称	章节的名字
	public int SystemID;         	//从属系统ID	从属于哪个副本系统的ID（1剧情、2活动、3日常、90帮会
	public int Team;             	//可否组队	1可以，0不可以
	public string BackGround;    	//章节背景图	章节显示的背景图

	public bool IsValidate = false;
	public SectionElement()
	{
		SectionID = -1;
	}
};

//章节表配置封装类
public class SectionTable
{

	private SectionTable()
	{
		m_mapElements = new Dictionary<int, SectionElement>();
		m_emptyItem = new SectionElement();
		m_vecAllElements = new List<SectionElement>();
	}
	private Dictionary<int, SectionElement> m_mapElements = null;
	private List<SectionElement>	m_vecAllElements = null;
	private SectionElement m_emptyItem = null;
	private static SectionTable sInstance = null;

	public static SectionTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SectionTable();
			return sInstance;
		}
	}

	public SectionElement GetElement(int key)
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

  public List<SectionElement> GetAllElement(Predicate<SectionElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Section.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Section.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Section.bin]未找到");
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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("Section.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="SectionID"){Ex.Logger.Log("Section.csv中字段[SectionID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Section.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="SystemID"){Ex.Logger.Log("Section.csv中字段[SystemID]位置不对应"); return false; }
		if(vecLine[3]!="Team"){Ex.Logger.Log("Section.csv中字段[Team]位置不对应"); return false; }
		if(vecLine[4]!="BackGround"){Ex.Logger.Log("Section.csv中字段[BackGround]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SectionElement member = new SectionElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SectionID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SystemID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Team );
			readPos += GameAssist.ReadString( binContent, readPos, out member.BackGround);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.SectionID] = member;
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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("Section.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="SectionID"){Ex.Logger.Log("Section.csv中字段[SectionID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Section.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="SystemID"){Ex.Logger.Log("Section.csv中字段[SystemID]位置不对应"); return false; }
		if(vecLine[3]!="Team"){Ex.Logger.Log("Section.csv中字段[Team]位置不对应"); return false; }
		if(vecLine[4]!="BackGround"){Ex.Logger.Log("Section.csv中字段[BackGround]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			SectionElement member = new SectionElement();
			member.SectionID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.SystemID=Convert.ToInt32(vecLine[2]);
			member.Team=Convert.ToInt32(vecLine[3]);
			member.BackGround=vecLine[4];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.SectionID] = member;
		}
		return true;
	}
};
