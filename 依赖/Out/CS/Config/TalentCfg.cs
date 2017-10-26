using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//天赋技能配置数据类
public class TalentElement
{
	public int LvID;             	//天赋技能ID	职业加等级
	public string Name;          	//天赋名称	天赋名称
	public string Desc;          	//描述	天赋效果描述
	public int Type;             	//类型	1被动；2光环被动；3技能效果；4主动技能
	public string Parameter;     	//参数	对应类型的参数

	public bool IsValidate = false;
	public TalentElement()
	{
		LvID = -1;
	}
};

//天赋技能配置封装类
public class TalentTable
{

	private TalentTable()
	{
		m_mapElements = new Dictionary<int, TalentElement>();
		m_emptyItem = new TalentElement();
		m_vecAllElements = new List<TalentElement>();
	}
	private Dictionary<int, TalentElement> m_mapElements = null;
	private List<TalentElement>	m_vecAllElements = null;
	private TalentElement m_emptyItem = null;
	private static TalentTable sInstance = null;

	public static TalentTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new TalentTable();
			return sInstance;
		}
	}

	public TalentElement GetElement(int key)
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

  public List<TalentElement> GetAllElement(Predicate<TalentElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Talent.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Talent.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Talent.bin]未找到");
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
			Ex.Logger.Log("Talent.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LvID"){Ex.Logger.Log("Talent.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Talent.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Desc"){Ex.Logger.Log("Talent.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Talent.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Parameter"){Ex.Logger.Log("Talent.csv中字段[Parameter]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			TalentElement member = new TalentElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Desc);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Parameter);

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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("Talent.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LvID"){Ex.Logger.Log("Talent.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Talent.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Desc"){Ex.Logger.Log("Talent.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Talent.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Parameter"){Ex.Logger.Log("Talent.csv中字段[Parameter]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			TalentElement member = new TalentElement();
			member.LvID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Desc=vecLine[2];
			member.Type=Convert.ToInt32(vecLine[3]);
			member.Parameter=vecLine[4];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LvID] = member;
		}
		return true;
	}
};
