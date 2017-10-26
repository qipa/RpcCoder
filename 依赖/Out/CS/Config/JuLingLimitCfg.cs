﻿using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//聚灵限制表配置数据类
public class JuLingLimitElement
{
	public int ID;               	//编号	炼星等级
	public int ShangGu;          	//上古技能数量	上古技能数量
	public int PuTong;           	//普通数量	普通数量
	public int Max;              	//等级上限	等级上限

	public bool IsValidate = false;
	public JuLingLimitElement()
	{
		ID = -1;
	}
};

//聚灵限制表配置封装类
public class JuLingLimitTable
{

	private JuLingLimitTable()
	{
		m_mapElements = new Dictionary<int, JuLingLimitElement>();
		m_emptyItem = new JuLingLimitElement();
		m_vecAllElements = new List<JuLingLimitElement>();
	}
	private Dictionary<int, JuLingLimitElement> m_mapElements = null;
	private List<JuLingLimitElement>	m_vecAllElements = null;
	private JuLingLimitElement m_emptyItem = null;
	private static JuLingLimitTable sInstance = null;

	public static JuLingLimitTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new JuLingLimitTable();
			return sInstance;
		}
	}

	public JuLingLimitElement GetElement(int key)
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

  public List<JuLingLimitElement> GetAllElement(Predicate<JuLingLimitElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("JuLingLimit.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("JuLingLimit.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[JuLingLimit.bin]未找到");
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
			Ex.Logger.Log("JuLingLimit.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("JuLingLimit.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ShangGu"){Ex.Logger.Log("JuLingLimit.csv中字段[ShangGu]位置不对应"); return false; }
		if(vecLine[2]!="PuTong"){Ex.Logger.Log("JuLingLimit.csv中字段[PuTong]位置不对应"); return false; }
		if(vecLine[3]!="Max"){Ex.Logger.Log("JuLingLimit.csv中字段[Max]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			JuLingLimitElement member = new JuLingLimitElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShangGu );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PuTong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Max );

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
			Ex.Logger.Log("JuLingLimit.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("JuLingLimit.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ShangGu"){Ex.Logger.Log("JuLingLimit.csv中字段[ShangGu]位置不对应"); return false; }
		if(vecLine[2]!="PuTong"){Ex.Logger.Log("JuLingLimit.csv中字段[PuTong]位置不对应"); return false; }
		if(vecLine[3]!="Max"){Ex.Logger.Log("JuLingLimit.csv中字段[Max]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			JuLingLimitElement member = new JuLingLimitElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.ShangGu=Convert.ToInt32(vecLine[1]);
			member.PuTong=Convert.ToInt32(vecLine[2]);
			member.Max=Convert.ToInt32(vecLine[3]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
