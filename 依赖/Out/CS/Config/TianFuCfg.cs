using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//天赋表配置数据类
public class TianFuElement
{
	public int ID;               	//编号	ID
	public int Hero;             	//所属英雄	所属英雄
	public int Set;              	//所属天赋段	1 40-69 2 70-89 3 90-109 4 110-129
	public string Name;          	//名称	名称
	public string MiaoShu;       	//描述	描述

	public bool IsValidate = false;
	public TianFuElement()
	{
		ID = -1;
	}
};

//天赋表配置封装类
public class TianFuTable
{

	private TianFuTable()
	{
		m_mapElements = new Dictionary<int, TianFuElement>();
		m_emptyItem = new TianFuElement();
		m_vecAllElements = new List<TianFuElement>();
	}
	private Dictionary<int, TianFuElement> m_mapElements = null;
	private List<TianFuElement>	m_vecAllElements = null;
	private TianFuElement m_emptyItem = null;
	private static TianFuTable sInstance = null;

	public static TianFuTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new TianFuTable();
			return sInstance;
		}
	}

	public TianFuElement GetElement(int key)
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

  public List<TianFuElement> GetAllElement(Predicate<TianFuElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("TianFu.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("TianFu.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[TianFu.bin]未找到");
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
			Ex.Logger.Log("TianFu.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("TianFu.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Hero"){Ex.Logger.Log("TianFu.csv中字段[Hero]位置不对应"); return false; }
		if(vecLine[2]!="Set"){Ex.Logger.Log("TianFu.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[3]!="Name"){Ex.Logger.Log("TianFu.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[4]!="MiaoShu"){Ex.Logger.Log("TianFu.csv中字段[MiaoShu]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			TianFuElement member = new TianFuElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Hero );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Set );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("TianFu.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("TianFu.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Hero"){Ex.Logger.Log("TianFu.csv中字段[Hero]位置不对应"); return false; }
		if(vecLine[2]!="Set"){Ex.Logger.Log("TianFu.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[3]!="Name"){Ex.Logger.Log("TianFu.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[4]!="MiaoShu"){Ex.Logger.Log("TianFu.csv中字段[MiaoShu]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			TianFuElement member = new TianFuElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Hero=Convert.ToInt32(vecLine[1]);
			member.Set=Convert.ToInt32(vecLine[2]);
			member.Name=vecLine[3];
			member.MiaoShu=vecLine[4];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
