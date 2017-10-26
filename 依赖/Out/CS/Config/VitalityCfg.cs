using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//活力表配置数据类
public class VitalityElement
{
	public int LvID;             	//编号	等级
	public int Vitality;         	//活力	活力上限

	public bool IsValidate = false;
	public VitalityElement()
	{
		LvID = -1;
	}
};

//活力表配置封装类
public class VitalityTable
{

	private VitalityTable()
	{
		m_mapElements = new Dictionary<int, VitalityElement>();
		m_emptyItem = new VitalityElement();
		m_vecAllElements = new List<VitalityElement>();
	}
	private Dictionary<int, VitalityElement> m_mapElements = null;
	private List<VitalityElement>	m_vecAllElements = null;
	private VitalityElement m_emptyItem = null;
	private static VitalityTable sInstance = null;

	public static VitalityTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new VitalityTable();
			return sInstance;
		}
	}

	public VitalityElement GetElement(int key)
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

  public List<VitalityElement> GetAllElement(Predicate<VitalityElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Vitality.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Vitality.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Vitality.bin]未找到");
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
			Ex.Logger.Log("Vitality.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LvID"){Ex.Logger.Log("Vitality.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[1]!="Vitality"){Ex.Logger.Log("Vitality.csv中字段[Vitality]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			VitalityElement member = new VitalityElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Vitality );

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
		if(vecLine.Count != 2)
		{
			Ex.Logger.Log("Vitality.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LvID"){Ex.Logger.Log("Vitality.csv中字段[LvID]位置不对应"); return false; }
		if(vecLine[1]!="Vitality"){Ex.Logger.Log("Vitality.csv中字段[Vitality]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)2)
			{
				return false;
			}
			VitalityElement member = new VitalityElement();
			member.LvID=Convert.ToInt32(vecLine[0]);
			member.Vitality=Convert.ToInt32(vecLine[1]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LvID] = member;
		}
		return true;
	}
};
