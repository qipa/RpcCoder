using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//地图表配置数据类
public class MapElement
{
	public int MapID;            	//地图ID	编号
	public string SceneConfigure;	//地图配置链接	地图配置链接
	public string SceneResource; 	//美术场景资源	美术场景资源
	public string MonsterConfigure;	//怪物配置链接	怪物配置链接
	public int MapType;          	//地图类型	1城市，2野外，3副本
	public string PKType;        	//容许的PK模式	1和平、2全体、3工会、4组队、5善恶
	public int LimitLevel;       	//进入等级	容许进入该场景的等级
	public string Thumb;         	//小地图配置	小地图文件配置

	public bool IsValidate = false;
	public MapElement()
	{
		MapID = -1;
	}
};

//地图表配置封装类
public class MapTable
{

	private MapTable()
	{
		m_mapElements = new Dictionary<int, MapElement>();
		m_emptyItem = new MapElement();
		m_vecAllElements = new List<MapElement>();
	}
	private Dictionary<int, MapElement> m_mapElements = null;
	private List<MapElement>	m_vecAllElements = null;
	private MapElement m_emptyItem = null;
	private static MapTable sInstance = null;

	public static MapTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MapTable();
			return sInstance;
		}
	}

	public MapElement GetElement(int key)
	{
		if( m_mapElements.ContainsKey(key) )
			return m_mapElements[key];
		return m_emptyItem;
	}

	public int GetElementCount()
	{
		return m_mapElements.Count;
	}
	public bool HasElement(int key)
	{
		return m_mapElements.ContainsKey(key);
	}

  public List<MapElement> GetAllElement(Predicate<MapElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Map.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Map.bin", out binTableContent ) )
		{
			Debug.Log("配置文件[Map.bin]未找到");
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
		if(vecLine.Count != 8)
		{
			Debug.Log("Map.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MapID"){Debug.Log("Map.csv中字段[MapID]位置不对应"); return false; }
		if(vecLine[1]!="SceneConfigure"){Debug.Log("Map.csv中字段[SceneConfigure]位置不对应"); return false; }
		if(vecLine[2]!="SceneResource"){Debug.Log("Map.csv中字段[SceneResource]位置不对应"); return false; }
		if(vecLine[3]!="MonsterConfigure"){Debug.Log("Map.csv中字段[MonsterConfigure]位置不对应"); return false; }
		if(vecLine[4]!="MapType"){Debug.Log("Map.csv中字段[MapType]位置不对应"); return false; }
		if(vecLine[5]!="PKType"){Debug.Log("Map.csv中字段[PKType]位置不对应"); return false; }
		if(vecLine[6]!="LimitLevel"){Debug.Log("Map.csv中字段[LimitLevel]位置不对应"); return false; }
		if(vecLine[7]!="Thumb"){Debug.Log("Map.csv中字段[Thumb]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MapElement member = new MapElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MapID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SceneConfigure);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SceneResource);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MonsterConfigure);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MapType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.PKType);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LimitLevel );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Thumb);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MapID] = member;
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
		if(vecLine.Count != 8)
		{
			Debug.Log("Map.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MapID"){Debug.Log("Map.csv中字段[MapID]位置不对应"); return false; }
		if(vecLine[1]!="SceneConfigure"){Debug.Log("Map.csv中字段[SceneConfigure]位置不对应"); return false; }
		if(vecLine[2]!="SceneResource"){Debug.Log("Map.csv中字段[SceneResource]位置不对应"); return false; }
		if(vecLine[3]!="MonsterConfigure"){Debug.Log("Map.csv中字段[MonsterConfigure]位置不对应"); return false; }
		if(vecLine[4]!="MapType"){Debug.Log("Map.csv中字段[MapType]位置不对应"); return false; }
		if(vecLine[5]!="PKType"){Debug.Log("Map.csv中字段[PKType]位置不对应"); return false; }
		if(vecLine[6]!="LimitLevel"){Debug.Log("Map.csv中字段[LimitLevel]位置不对应"); return false; }
		if(vecLine[7]!="Thumb"){Debug.Log("Map.csv中字段[Thumb]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)8)
			{
				return false;
			}
			MapElement member = new MapElement();
			member.MapID=Convert.ToInt32(vecLine[0]);
			member.SceneConfigure=vecLine[1];
			member.SceneResource=vecLine[2];
			member.MonsterConfigure=vecLine[3];
			member.MapType=Convert.ToInt32(vecLine[4]);
			member.PKType=vecLine[5];
			member.LimitLevel=Convert.ToInt32(vecLine[6]);
			member.Thumb=vecLine[7];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MapID] = member;
		}
		return true;
	}
};
