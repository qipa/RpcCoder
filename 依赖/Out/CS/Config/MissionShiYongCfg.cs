using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//使用道具任务配置数据类
public class MissionShiYongElement
{
	public int MissionID;        	//编号	物品ID
	public string Name;          	//任务名称	官阶名称
	public int MuBiao;           	//使用道具ID	使用道具ID
	public string ZuoBiao;       	//使用道具坐标	使用道具坐标
	public int IsTiShi;          	//是否弹出使用框	是否弹出使用框
	public int Time;             	//使用道具吟唱时长	使用道具吟唱时长
	public string DaoHang;       	//任务导航	任务导航

	public bool IsValidate = false;
	public MissionShiYongElement()
	{
		MissionID = -1;
	}
};

//使用道具任务配置封装类
public class MissionShiYongTable
{

	private MissionShiYongTable()
	{
		m_mapElements = new Dictionary<int, MissionShiYongElement>();
		m_emptyItem = new MissionShiYongElement();
		m_vecAllElements = new List<MissionShiYongElement>();
	}
	private Dictionary<int, MissionShiYongElement> m_mapElements = null;
	private List<MissionShiYongElement>	m_vecAllElements = null;
	private MissionShiYongElement m_emptyItem = null;
	private static MissionShiYongTable sInstance = null;

	public static MissionShiYongTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MissionShiYongTable();
			return sInstance;
		}
	}

	public MissionShiYongElement GetElement(int key)
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

  public List<MissionShiYongElement> GetAllElement(Predicate<MissionShiYongElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MissionShiYong.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MissionShiYong.bin", out binTableContent ) )
		{
			Debug.Log("配置文件[MissionShiYong.bin]未找到");
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
		if(vecLine.Count != 7)
		{
			Debug.Log("MissionShiYong.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MissionID"){Debug.Log("MissionShiYong.csv中字段[MissionID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Debug.Log("MissionShiYong.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MuBiao"){Debug.Log("MissionShiYong.csv中字段[MuBiao]位置不对应"); return false; }
		if(vecLine[3]!="ZuoBiao"){Debug.Log("MissionShiYong.csv中字段[ZuoBiao]位置不对应"); return false; }
		if(vecLine[4]!="IsTiShi"){Debug.Log("MissionShiYong.csv中字段[IsTiShi]位置不对应"); return false; }
		if(vecLine[5]!="Time"){Debug.Log("MissionShiYong.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[6]!="DaoHang"){Debug.Log("MissionShiYong.csv中字段[DaoHang]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MissionShiYongElement member = new MissionShiYongElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MissionID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ZuoBiao);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsTiShi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Time );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DaoHang);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MissionID] = member;
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
		if(vecLine.Count != 7)
		{
			Debug.Log("MissionShiYong.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MissionID"){Debug.Log("MissionShiYong.csv中字段[MissionID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Debug.Log("MissionShiYong.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MuBiao"){Debug.Log("MissionShiYong.csv中字段[MuBiao]位置不对应"); return false; }
		if(vecLine[3]!="ZuoBiao"){Debug.Log("MissionShiYong.csv中字段[ZuoBiao]位置不对应"); return false; }
		if(vecLine[4]!="IsTiShi"){Debug.Log("MissionShiYong.csv中字段[IsTiShi]位置不对应"); return false; }
		if(vecLine[5]!="Time"){Debug.Log("MissionShiYong.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[6]!="DaoHang"){Debug.Log("MissionShiYong.csv中字段[DaoHang]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)7)
			{
				return false;
			}
			MissionShiYongElement member = new MissionShiYongElement();
			member.MissionID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.MuBiao=Convert.ToInt32(vecLine[2]);
			member.ZuoBiao=vecLine[3];
			member.IsTiShi=Convert.ToInt32(vecLine[4]);
			member.Time=Convert.ToInt32(vecLine[5]);
			member.DaoHang=vecLine[6];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MissionID] = member;
		}
		return true;
	}
};
