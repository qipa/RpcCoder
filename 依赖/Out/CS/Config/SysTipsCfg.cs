using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//系统各种提示表配置数据类
public class SysTipsElement
{
	public int ID;               	//id	索引
	public string CN;            	//中文	中文
	public string EN;            	//英语	英语

	public bool IsValidate = false;
	public SysTipsElement()
	{
		ID = -1;
	}
};

//系统各种提示表配置封装类
public class SysTipsTable
{

	private SysTipsTable()
	{
		m_mapElements = new Dictionary<int, SysTipsElement>();
		m_emptyItem = new SysTipsElement();
		m_vecAllElements = new List<SysTipsElement>();
	}
	private Dictionary<int, SysTipsElement> m_mapElements = null;
	private List<SysTipsElement>	m_vecAllElements = null;
	private SysTipsElement m_emptyItem = null;
	private static SysTipsTable sInstance = null;

	public static SysTipsTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SysTipsTable();
			return sInstance;
		}
	}

	public SysTipsElement GetElement(int key)
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

  public List<SysTipsElement> GetAllElement(Predicate<SysTipsElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("SysTips.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("SysTips.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[SysTips.bin]未找到");
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
		if(vecLine.Count != 3)
		{
			Ex.Logger.Log("SysTips.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SysTips.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="CN"){Ex.Logger.Log("SysTips.csv中字段[CN]位置不对应"); return false; }
		if(vecLine[2]!="EN"){Ex.Logger.Log("SysTips.csv中字段[EN]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SysTipsElement member = new SysTipsElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.CN);
			readPos += GameAssist.ReadString( binContent, readPos, out member.EN);

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
		if(vecLine.Count != 3)
		{
			Ex.Logger.Log("SysTips.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SysTips.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="CN"){Ex.Logger.Log("SysTips.csv中字段[CN]位置不对应"); return false; }
		if(vecLine[2]!="EN"){Ex.Logger.Log("SysTips.csv中字段[EN]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)3)
			{
				return false;
			}
			SysTipsElement member = new SysTipsElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.CN=vecLine[1];
			member.EN=vecLine[2];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
