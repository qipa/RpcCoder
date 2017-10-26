using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//货运货物类别表配置数据类
public class CargoTypeElement
{
	public int Type;             	//货物类别	货物类别
	public int MinNum;           	//类别数量最小值	类别数量最小值
	public int MaxNum;           	//类别数量最大值	类别数量最大值
	public int Weight;           	//权重	权重

	public bool IsValidate = false;
	public CargoTypeElement()
	{
		Type = -1;
	}
};

//货运货物类别表配置封装类
public class CargoTypeTable
{

	private CargoTypeTable()
	{
		m_mapElements = new Dictionary<int, CargoTypeElement>();
		m_emptyItem = new CargoTypeElement();
		m_vecAllElements = new List<CargoTypeElement>();
	}
	private Dictionary<int, CargoTypeElement> m_mapElements = null;
	private List<CargoTypeElement>	m_vecAllElements = null;
	private CargoTypeElement m_emptyItem = null;
	private static CargoTypeTable sInstance = null;

	public static CargoTypeTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new CargoTypeTable();
			return sInstance;
		}
	}

	public CargoTypeElement GetElement(int key)
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

  public List<CargoTypeElement> GetAllElement(Predicate<CargoTypeElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("CargoType.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("CargoType.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[CargoType.bin]未找到");
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
			Ex.Logger.Log("CargoType.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Type"){Ex.Logger.Log("CargoType.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[1]!="MinNum"){Ex.Logger.Log("CargoType.csv中字段[MinNum]位置不对应"); return false; }
		if(vecLine[2]!="MaxNum"){Ex.Logger.Log("CargoType.csv中字段[MaxNum]位置不对应"); return false; }
		if(vecLine[3]!="Weight"){Ex.Logger.Log("CargoType.csv中字段[Weight]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			CargoTypeElement member = new CargoTypeElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MinNum );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MaxNum );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Weight );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Type] = member;
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
			Ex.Logger.Log("CargoType.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Type"){Ex.Logger.Log("CargoType.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[1]!="MinNum"){Ex.Logger.Log("CargoType.csv中字段[MinNum]位置不对应"); return false; }
		if(vecLine[2]!="MaxNum"){Ex.Logger.Log("CargoType.csv中字段[MaxNum]位置不对应"); return false; }
		if(vecLine[3]!="Weight"){Ex.Logger.Log("CargoType.csv中字段[Weight]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			CargoTypeElement member = new CargoTypeElement();
			member.Type=Convert.ToInt32(vecLine[0]);
			member.MinNum=Convert.ToInt32(vecLine[1]);
			member.MaxNum=Convert.ToInt32(vecLine[2]);
			member.Weight=Convert.ToInt32(vecLine[3]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Type] = member;
		}
		return true;
	}
};
