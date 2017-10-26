using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//文本颜色表配置数据类
public class ColorElement
{
	public int ID;               	//ID	ID
	public int Type;             	//类型	类型1.富文本（聊天超链接）2.装备名称3 其他
	public string Color;         	//色值	色值（例：#0A246A）
	public string Res;           	//图标	图标
	public string Desc;          	//描述	ID对应内容的描述

	public bool IsValidate = false;
	public ColorElement()
	{
		ID = -1;
	}
};

//文本颜色表配置封装类
public class ColorTable
{

	private ColorTable()
	{
		m_mapElements = new Dictionary<int, ColorElement>();
		m_emptyItem = new ColorElement();
		m_vecAllElements = new List<ColorElement>();
	}
	private Dictionary<int, ColorElement> m_mapElements = null;
	private List<ColorElement>	m_vecAllElements = null;
	private ColorElement m_emptyItem = null;
	private static ColorTable sInstance = null;

	public static ColorTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ColorTable();
			return sInstance;
		}
	}

	public ColorElement GetElement(int key)
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

  public List<ColorElement> GetAllElement(Predicate<ColorElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Color.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Color.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Color.bin]未找到");
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
			Ex.Logger.Log("Color.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Color.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("Color.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Color"){Ex.Logger.Log("Color.csv中字段[Color]位置不对应"); return false; }
		if(vecLine[3]!="Res"){Ex.Logger.Log("Color.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[4]!="Desc"){Ex.Logger.Log("Color.csv中字段[Desc]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ColorElement member = new ColorElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Color);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Desc);

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
			Ex.Logger.Log("Color.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Color.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("Color.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Color"){Ex.Logger.Log("Color.csv中字段[Color]位置不对应"); return false; }
		if(vecLine[3]!="Res"){Ex.Logger.Log("Color.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[4]!="Desc"){Ex.Logger.Log("Color.csv中字段[Desc]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			ColorElement member = new ColorElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Type=Convert.ToInt32(vecLine[1]);
			member.Color=vecLine[2];
			member.Res=vecLine[3];
			member.Desc=vecLine[4];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
