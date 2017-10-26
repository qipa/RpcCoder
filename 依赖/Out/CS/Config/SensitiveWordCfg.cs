using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//敏感字库配置数据类
public class SensitiveWordElement
{
	public int ID;               	//ID	ID
	public string Word;          	//敏感字	敏感字

	public bool IsValidate = false;
	public SensitiveWordElement()
	{
		ID = -1;
	}
};

//敏感字库配置封装类
public class SensitiveWordTable
{

	private SensitiveWordTable()
	{
		m_mapElements = new Dictionary<int, SensitiveWordElement>();
		m_emptyItem = new SensitiveWordElement();
		m_vecAllElements = new List<SensitiveWordElement>();
	}
	private Dictionary<int, SensitiveWordElement> m_mapElements = null;
	private List<SensitiveWordElement>	m_vecAllElements = null;
	private SensitiveWordElement m_emptyItem = null;
	private static SensitiveWordTable sInstance = null;

	public static SensitiveWordTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SensitiveWordTable();
			return sInstance;
		}
	}

	public SensitiveWordElement GetElement(int key)
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

  public List<SensitiveWordElement> GetAllElement(Predicate<SensitiveWordElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("SensitiveWord.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("SensitiveWord.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[SensitiveWord.bin]未找到");
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
		if(vecLine.Count != 2)
		{
			Ex.Logger.Log("SensitiveWord.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SensitiveWord.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Word"){Ex.Logger.Log("SensitiveWord.csv中字段[Word]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SensitiveWordElement member = new SensitiveWordElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Word);

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
		if(vecLine.Count != 2)
		{
			Ex.Logger.Log("SensitiveWord.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SensitiveWord.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Word"){Ex.Logger.Log("SensitiveWord.csv中字段[Word]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)2)
			{
				return false;
			}
			SensitiveWordElement member = new SensitiveWordElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Word=vecLine[1];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
