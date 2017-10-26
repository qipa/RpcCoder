using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//货运货物数据库配置数据类
public class CargoElement
{
	public int ID;               	//货物ID	货物ID
	public int GoodsId;          	//货物物品ID	货物物品ID
	public string Name;          	//货物名称	货物名称
	public int Number;           	//货物物品你数量	货物物品你数量
	public int Type;             	//类别	类别

	public bool IsValidate = false;
	public CargoElement()
	{
		ID = -1;
	}
};

//货运货物数据库配置封装类
public class CargoTable
{

	private CargoTable()
	{
		m_mapElements = new Dictionary<int, CargoElement>();
		m_emptyItem = new CargoElement();
		m_vecAllElements = new List<CargoElement>();
	}
	private Dictionary<int, CargoElement> m_mapElements = null;
	private List<CargoElement>	m_vecAllElements = null;
	private CargoElement m_emptyItem = null;
	private static CargoTable sInstance = null;

	public static CargoTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new CargoTable();
			return sInstance;
		}
	}

	public CargoElement GetElement(int key)
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

  public List<CargoElement> GetAllElement(Predicate<CargoElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Cargo.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Cargo.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Cargo.bin]未找到");
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
			Ex.Logger.Log("Cargo.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Cargo.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="GoodsId"){Ex.Logger.Log("Cargo.csv中字段[GoodsId]位置不对应"); return false; }
		if(vecLine[2]!="Name"){Ex.Logger.Log("Cargo.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[3]!="Number"){Ex.Logger.Log("Cargo.csv中字段[Number]位置不对应"); return false; }
		if(vecLine[4]!="Type"){Ex.Logger.Log("Cargo.csv中字段[Type]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			CargoElement member = new CargoElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GoodsId );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Number );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );

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
			Ex.Logger.Log("Cargo.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Cargo.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="GoodsId"){Ex.Logger.Log("Cargo.csv中字段[GoodsId]位置不对应"); return false; }
		if(vecLine[2]!="Name"){Ex.Logger.Log("Cargo.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[3]!="Number"){Ex.Logger.Log("Cargo.csv中字段[Number]位置不对应"); return false; }
		if(vecLine[4]!="Type"){Ex.Logger.Log("Cargo.csv中字段[Type]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			CargoElement member = new CargoElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.GoodsId=Convert.ToInt32(vecLine[1]);
			member.Name=vecLine[2];
			member.Number=Convert.ToInt32(vecLine[3]);
			member.Type=Convert.ToInt32(vecLine[4]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
