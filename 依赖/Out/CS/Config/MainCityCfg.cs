using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//主城表配置数据类
public class MainCityElement
{
	public int ID;               	//坑点ID	坑点ID
	public float X;              	//POSx	POSx
	public float Y;              	//POSy	POSy
	public float Z;              	//POSz	POSz
	public float Rx;             	//ROTx	ROTx
	public float Ry;             	//ROTy	ROTy
	public float Rz;             	//ROTz	ROTz
	public int Type;             	//类型	1Npc，2传送，3阻挡，4出生点
	public int NpcID;            	//NpcID	NpcID
	public float X2;             	//POS2x	POS2x
	public float Y2;             	//POS2y	POS2y
	public float Z2;             	//POS2z	POS2z

	public bool IsValidate = false;
	public MainCityElement()
	{
		ID = -1;
	}
};

//主城表配置封装类
public class MainCityTable
{

	private MainCityTable()
	{
		m_mapElements = new Dictionary<int, MainCityElement>();
		m_emptyItem = new MainCityElement();
		m_vecAllElements = new List<MainCityElement>();
	}
	private Dictionary<int, MainCityElement> m_mapElements = null;
	private List<MainCityElement>	m_vecAllElements = null;
	private MainCityElement m_emptyItem = null;
	private static MainCityTable sInstance = null;

	public static MainCityTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MainCityTable();
			return sInstance;
		}
	}

	public MainCityElement GetElement(int key)
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

  public List<MainCityElement> GetAllElement(Predicate<MainCityElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MainCity.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MainCity.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[MainCity.bin]未找到");
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
		if(vecLine.Count != 12)
		{
			Ex.Logger.Log("MainCity.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MainCity.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="X"){Ex.Logger.Log("MainCity.csv中字段[X]位置不对应"); return false; }
		if(vecLine[2]!="Y"){Ex.Logger.Log("MainCity.csv中字段[Y]位置不对应"); return false; }
		if(vecLine[3]!="Z"){Ex.Logger.Log("MainCity.csv中字段[Z]位置不对应"); return false; }
		if(vecLine[4]!="Rx"){Ex.Logger.Log("MainCity.csv中字段[Rx]位置不对应"); return false; }
		if(vecLine[5]!="Ry"){Ex.Logger.Log("MainCity.csv中字段[Ry]位置不对应"); return false; }
		if(vecLine[6]!="Rz"){Ex.Logger.Log("MainCity.csv中字段[Rz]位置不对应"); return false; }
		if(vecLine[7]!="Type"){Ex.Logger.Log("MainCity.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[8]!="NpcID"){Ex.Logger.Log("MainCity.csv中字段[NpcID]位置不对应"); return false; }
		if(vecLine[9]!="X2"){Ex.Logger.Log("MainCity.csv中字段[X2]位置不对应"); return false; }
		if(vecLine[10]!="Y2"){Ex.Logger.Log("MainCity.csv中字段[Y2]位置不对应"); return false; }
		if(vecLine[11]!="Z2"){Ex.Logger.Log("MainCity.csv中字段[Z2]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MainCityElement member = new MainCityElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.X);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Y);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Z);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Rx);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Ry);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Rz);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.NpcID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.X2);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Y2);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Z2);

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
		if(vecLine.Count != 12)
		{
			Ex.Logger.Log("MainCity.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MainCity.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="X"){Ex.Logger.Log("MainCity.csv中字段[X]位置不对应"); return false; }
		if(vecLine[2]!="Y"){Ex.Logger.Log("MainCity.csv中字段[Y]位置不对应"); return false; }
		if(vecLine[3]!="Z"){Ex.Logger.Log("MainCity.csv中字段[Z]位置不对应"); return false; }
		if(vecLine[4]!="Rx"){Ex.Logger.Log("MainCity.csv中字段[Rx]位置不对应"); return false; }
		if(vecLine[5]!="Ry"){Ex.Logger.Log("MainCity.csv中字段[Ry]位置不对应"); return false; }
		if(vecLine[6]!="Rz"){Ex.Logger.Log("MainCity.csv中字段[Rz]位置不对应"); return false; }
		if(vecLine[7]!="Type"){Ex.Logger.Log("MainCity.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[8]!="NpcID"){Ex.Logger.Log("MainCity.csv中字段[NpcID]位置不对应"); return false; }
		if(vecLine[9]!="X2"){Ex.Logger.Log("MainCity.csv中字段[X2]位置不对应"); return false; }
		if(vecLine[10]!="Y2"){Ex.Logger.Log("MainCity.csv中字段[Y2]位置不对应"); return false; }
		if(vecLine[11]!="Z2"){Ex.Logger.Log("MainCity.csv中字段[Z2]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)12)
			{
				return false;
			}
			MainCityElement member = new MainCityElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.X=Convert.ToSingle(vecLine[1]);
			member.Y=Convert.ToSingle(vecLine[2]);
			member.Z=Convert.ToSingle(vecLine[3]);
			member.Rx=Convert.ToSingle(vecLine[4]);
			member.Ry=Convert.ToSingle(vecLine[5]);
			member.Rz=Convert.ToSingle(vecLine[6]);
			member.Type=Convert.ToInt32(vecLine[7]);
			member.NpcID=Convert.ToInt32(vecLine[8]);
			member.X2=Convert.ToSingle(vecLine[9]);
			member.Y2=Convert.ToSingle(vecLine[10]);
			member.Z2=Convert.ToSingle(vecLine[11]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
