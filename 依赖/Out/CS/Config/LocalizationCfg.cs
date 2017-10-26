using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//本地化配置数据类
public class LocalizationElement
{
	public int id;               	//id	索引
	public string key;           	//本地化键值	本地化键值
	public string cn;            	//中文	中文
	public string en;            	//英语	英语

	public bool IsValidate = false;
	public LocalizationElement()
	{
		id = -1;
	}
};

//本地化配置封装类
public class LocalizationTable
{

	private LocalizationTable()
	{
		m_mapElements = new Dictionary<int, LocalizationElement>();
		m_emptyItem = new LocalizationElement();
		m_vecAllElements = new List<LocalizationElement>();
	}
	private Dictionary<int, LocalizationElement> m_mapElements = null;
	private List<LocalizationElement>	m_vecAllElements = null;
	private LocalizationElement m_emptyItem = null;
	private static LocalizationTable sInstance = null;

	public static LocalizationTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new LocalizationTable();
			return sInstance;
		}
	}

	public LocalizationElement GetElement(int key)
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

  public List<LocalizationElement> GetAllElement(Predicate<LocalizationElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Localization.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Localization.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Localization.bin]未找到");
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
			Ex.Logger.Log("Localization.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="id"){Ex.Logger.Log("Localization.csv中字段[id]位置不对应"); return false; }
		if(vecLine[1]!="key"){Ex.Logger.Log("Localization.csv中字段[key]位置不对应"); return false; }
		if(vecLine[2]!="cn"){Ex.Logger.Log("Localization.csv中字段[cn]位置不对应"); return false; }
		if(vecLine[3]!="en"){Ex.Logger.Log("Localization.csv中字段[en]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			LocalizationElement member = new LocalizationElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.id );
			readPos += GameAssist.ReadString( binContent, readPos, out member.key);
			readPos += GameAssist.ReadString( binContent, readPos, out member.cn);
			readPos += GameAssist.ReadString( binContent, readPos, out member.en);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.id] = member;
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
			Ex.Logger.Log("Localization.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="id"){Ex.Logger.Log("Localization.csv中字段[id]位置不对应"); return false; }
		if(vecLine[1]!="key"){Ex.Logger.Log("Localization.csv中字段[key]位置不对应"); return false; }
		if(vecLine[2]!="cn"){Ex.Logger.Log("Localization.csv中字段[cn]位置不对应"); return false; }
		if(vecLine[3]!="en"){Ex.Logger.Log("Localization.csv中字段[en]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			LocalizationElement member = new LocalizationElement();
			member.id=Convert.ToInt32(vecLine[0]);
			member.key=vecLine[1];
			member.cn=vecLine[2];
			member.en=vecLine[3];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.id] = member;
		}
		return true;
	}
};
