using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//副本列表配置数据类
public class CopyListElement
{
	public int ID;               	//编号	编号
	public int SmallLV;          	//等级区间1	等级区间1
	public int MaxLV;            	//等级区间2	等级区间2

	public bool IsValidate = false;
	public CopyListElement()
	{
		ID = -1;
	}
};

//副本列表配置封装类
public class CopyListTable
{

	private CopyListTable()
	{
		m_mapElements = new Dictionary<int, CopyListElement>();
		m_emptyItem = new CopyListElement();
		m_vecAllElements = new List<CopyListElement>();
	}
	private Dictionary<int, CopyListElement> m_mapElements = null;
	private List<CopyListElement>	m_vecAllElements = null;
	private CopyListElement m_emptyItem = null;
	private static CopyListTable sInstance = null;

	public static CopyListTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new CopyListTable();
			return sInstance;
		}
	}

	public CopyListElement GetElement(int key)
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

  public List<CopyListElement> GetAllElement(Predicate<CopyListElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("CopyList.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("CopyList.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[CopyList.bin]未找到");
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
			Ex.Logger.Log("CopyList.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CopyList.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SmallLV"){Ex.Logger.Log("CopyList.csv中字段[SmallLV]位置不对应"); return false; }
		if(vecLine[2]!="MaxLV"){Ex.Logger.Log("CopyList.csv中字段[MaxLV]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			CopyListElement member = new CopyListElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SmallLV );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MaxLV );

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
			Ex.Logger.Log("CopyList.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CopyList.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SmallLV"){Ex.Logger.Log("CopyList.csv中字段[SmallLV]位置不对应"); return false; }
		if(vecLine[2]!="MaxLV"){Ex.Logger.Log("CopyList.csv中字段[MaxLV]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)3)
			{
				return false;
			}
			CopyListElement member = new CopyListElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.SmallLV=Convert.ToInt32(vecLine[1]);
			member.MaxLV=Convert.ToInt32(vecLine[2]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
