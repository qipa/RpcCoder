using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//剧情表配置数据类
public class PlotElement
{
	public int ID;               	//ID	ID
	public string FileName;      	//文件名	文件名

	public bool IsValidate = false;
	public PlotElement()
	{
		ID = -1;
	}
};

//剧情表配置封装类
public class PlotTable
{

	private PlotTable()
	{
		m_mapElements = new Dictionary<int, PlotElement>();
		m_emptyItem = new PlotElement();
		m_vecAllElements = new List<PlotElement>();
	}
	private Dictionary<int, PlotElement> m_mapElements = null;
	private List<PlotElement>	m_vecAllElements = null;
	private PlotElement m_emptyItem = null;
	private static PlotTable sInstance = null;

	public static PlotTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new PlotTable();
			return sInstance;
		}
	}

	public PlotElement GetElement(int key)
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

  public List<PlotElement> GetAllElement(Predicate<PlotElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Plot.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Plot.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Plot.bin]未找到");
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
			Ex.Logger.Log("Plot.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Plot.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="FileName"){Ex.Logger.Log("Plot.csv中字段[FileName]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			PlotElement member = new PlotElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.FileName);

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
			Ex.Logger.Log("Plot.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Plot.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="FileName"){Ex.Logger.Log("Plot.csv中字段[FileName]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)2)
			{
				return false;
			}
			PlotElement member = new PlotElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.FileName=vecLine[1];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
