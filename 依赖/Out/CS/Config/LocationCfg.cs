using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//坐标配置数据类
public class LocationElement
{
	public int ID;               	//坐标ID	坐标ID
	public float PosX;           	//坐标	坐标
	public int Dungeons;         	//场景ID	场景ID
	public int Layer;            	//层	层

	public bool IsValidate = false;
	public LocationElement()
	{
		ID = -1;
	}
};

//坐标配置封装类
public class LocationTable
{

	private LocationTable()
	{
		m_mapElements = new Dictionary<int, LocationElement>();
		m_emptyItem = new LocationElement();
		m_vecAllElements = new List<LocationElement>();
	}
	private Dictionary<int, LocationElement> m_mapElements = null;
	private List<LocationElement>	m_vecAllElements = null;
	private LocationElement m_emptyItem = null;
	private static LocationTable sInstance = null;

	public static LocationTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new LocationTable();
			return sInstance;
		}
	}

	public LocationElement GetElement(int key)
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

  public List<LocationElement> GetAllElement(Predicate<LocationElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Location.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Location.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Location.bin]未找到");
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
			Ex.Logger.Log("Location.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Location.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="PosX"){Ex.Logger.Log("Location.csv中字段[PosX]位置不对应"); return false; }
		if(vecLine[2]!="Dungeons"){Ex.Logger.Log("Location.csv中字段[Dungeons]位置不对应"); return false; }
		if(vecLine[3]!="Layer"){Ex.Logger.Log("Location.csv中字段[Layer]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			LocationElement member = new LocationElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.PosX);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Dungeons );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Layer );

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
			Ex.Logger.Log("Location.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Location.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="PosX"){Ex.Logger.Log("Location.csv中字段[PosX]位置不对应"); return false; }
		if(vecLine[2]!="Dungeons"){Ex.Logger.Log("Location.csv中字段[Dungeons]位置不对应"); return false; }
		if(vecLine[3]!="Layer"){Ex.Logger.Log("Location.csv中字段[Layer]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			LocationElement member = new LocationElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.PosX=Convert.ToSingle(vecLine[1]);
			member.Dungeons=Convert.ToInt32(vecLine[2]);
			member.Layer=Convert.ToInt32(vecLine[3]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
