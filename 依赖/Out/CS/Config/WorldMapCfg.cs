using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//世界地图表配置数据类
public class WorldMapElement
{
	public int ID;               	//世界地图ID	世界地图ID
	public string Name;          	//世界地图名称	世界地图的名字
	public int DungeonID;        	//对应副本表的id	对应副本表的id
	public string PosName;       	//对应unity的按钮名字	对应unity的按钮名字
	public string BtnRes;        	//按钮资源	按钮资源
	public string NameRes;       	//名字资源	名字资源或者名字，待定名字，以后可能修改

	public bool IsValidate = false;
	public WorldMapElement()
	{
		ID = -1;
	}
};

//世界地图表配置封装类
public class WorldMapTable
{

	private WorldMapTable()
	{
		m_mapElements = new Dictionary<int, WorldMapElement>();
		m_emptyItem = new WorldMapElement();
		m_vecAllElements = new List<WorldMapElement>();
	}
	private Dictionary<int, WorldMapElement> m_mapElements = null;
	private List<WorldMapElement>	m_vecAllElements = null;
	private WorldMapElement m_emptyItem = null;
	private static WorldMapTable sInstance = null;

	public static WorldMapTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new WorldMapTable();
			return sInstance;
		}
	}

	public WorldMapElement GetElement(int key)
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

  public List<WorldMapElement> GetAllElement(Predicate<WorldMapElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("WorldMap.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("WorldMap.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[WorldMap.bin]未找到");
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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("WorldMap.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("WorldMap.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("WorldMap.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="DungeonID"){Ex.Logger.Log("WorldMap.csv中字段[DungeonID]位置不对应"); return false; }
		if(vecLine[3]!="PosName"){Ex.Logger.Log("WorldMap.csv中字段[PosName]位置不对应"); return false; }
		if(vecLine[4]!="BtnRes"){Ex.Logger.Log("WorldMap.csv中字段[BtnRes]位置不对应"); return false; }
		if(vecLine[5]!="NameRes"){Ex.Logger.Log("WorldMap.csv中字段[NameRes]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			WorldMapElement member = new WorldMapElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DungeonID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.PosName);
			readPos += GameAssist.ReadString( binContent, readPos, out member.BtnRes);
			readPos += GameAssist.ReadString( binContent, readPos, out member.NameRes);

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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("WorldMap.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("WorldMap.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("WorldMap.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="DungeonID"){Ex.Logger.Log("WorldMap.csv中字段[DungeonID]位置不对应"); return false; }
		if(vecLine[3]!="PosName"){Ex.Logger.Log("WorldMap.csv中字段[PosName]位置不对应"); return false; }
		if(vecLine[4]!="BtnRes"){Ex.Logger.Log("WorldMap.csv中字段[BtnRes]位置不对应"); return false; }
		if(vecLine[5]!="NameRes"){Ex.Logger.Log("WorldMap.csv中字段[NameRes]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			WorldMapElement member = new WorldMapElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.DungeonID=Convert.ToInt32(vecLine[2]);
			member.PosName=vecLine[3];
			member.BtnRes=vecLine[4];
			member.NameRes=vecLine[5];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
