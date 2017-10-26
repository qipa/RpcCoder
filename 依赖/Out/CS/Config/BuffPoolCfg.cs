using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//BUFF池配置数据类
public class BuffPoolElement
{
	public int ID;               	//池子id	池子id
	public string POS;           	//位置信息	x,z,layer
	public float TriggerRange;   	//触发区大小	触发区大小（以自身为原点的直径范围，米）
	public int RefreshType;      	//刷新类型	刷新类型(1固定时间刷新，2上一个消失之后时间刷新）
	public int RefreshCD;        	//刷新时间CD	刷新时间CD，单位毫秒
	public int GroupID;          	//组ID	组ID
	public int GroupMaxRefreshCount;	//组内随机最大刷新个数	组内随机最大刷新个数
	public string BuffIDList;    	//BUFF列表	BUFF列表
	public string Res;           	//显示资源	显示资源

	public bool IsValidate = false;
	public BuffPoolElement()
	{
		ID = -1;
	}
};

//BUFF池配置封装类
public class BuffPoolTable
{

	private BuffPoolTable()
	{
		m_mapElements = new Dictionary<int, BuffPoolElement>();
		m_emptyItem = new BuffPoolElement();
		m_vecAllElements = new List<BuffPoolElement>();
	}
	private Dictionary<int, BuffPoolElement> m_mapElements = null;
	private List<BuffPoolElement>	m_vecAllElements = null;
	private BuffPoolElement m_emptyItem = null;
	private static BuffPoolTable sInstance = null;

	public static BuffPoolTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BuffPoolTable();
			return sInstance;
		}
	}

	public BuffPoolElement GetElement(int key)
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

  public List<BuffPoolElement> GetAllElement(Predicate<BuffPoolElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BuffPool.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BuffPool.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BuffPool.bin]未找到");
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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("BuffPool.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BuffPool.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="POS"){Ex.Logger.Log("BuffPool.csv中字段[POS]位置不对应"); return false; }
		if(vecLine[2]!="TriggerRange"){Ex.Logger.Log("BuffPool.csv中字段[TriggerRange]位置不对应"); return false; }
		if(vecLine[3]!="RefreshType"){Ex.Logger.Log("BuffPool.csv中字段[RefreshType]位置不对应"); return false; }
		if(vecLine[4]!="RefreshCD"){Ex.Logger.Log("BuffPool.csv中字段[RefreshCD]位置不对应"); return false; }
		if(vecLine[5]!="GroupID"){Ex.Logger.Log("BuffPool.csv中字段[GroupID]位置不对应"); return false; }
		if(vecLine[6]!="GroupMaxRefreshCount"){Ex.Logger.Log("BuffPool.csv中字段[GroupMaxRefreshCount]位置不对应"); return false; }
		if(vecLine[7]!="BuffIDList"){Ex.Logger.Log("BuffPool.csv中字段[BuffIDList]位置不对应"); return false; }
		if(vecLine[8]!="Res"){Ex.Logger.Log("BuffPool.csv中字段[Res]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BuffPoolElement member = new BuffPoolElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.POS);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.TriggerRange);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RefreshType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RefreshCD );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GroupID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GroupMaxRefreshCount );
			readPos += GameAssist.ReadString( binContent, readPos, out member.BuffIDList);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);

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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("BuffPool.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BuffPool.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="POS"){Ex.Logger.Log("BuffPool.csv中字段[POS]位置不对应"); return false; }
		if(vecLine[2]!="TriggerRange"){Ex.Logger.Log("BuffPool.csv中字段[TriggerRange]位置不对应"); return false; }
		if(vecLine[3]!="RefreshType"){Ex.Logger.Log("BuffPool.csv中字段[RefreshType]位置不对应"); return false; }
		if(vecLine[4]!="RefreshCD"){Ex.Logger.Log("BuffPool.csv中字段[RefreshCD]位置不对应"); return false; }
		if(vecLine[5]!="GroupID"){Ex.Logger.Log("BuffPool.csv中字段[GroupID]位置不对应"); return false; }
		if(vecLine[6]!="GroupMaxRefreshCount"){Ex.Logger.Log("BuffPool.csv中字段[GroupMaxRefreshCount]位置不对应"); return false; }
		if(vecLine[7]!="BuffIDList"){Ex.Logger.Log("BuffPool.csv中字段[BuffIDList]位置不对应"); return false; }
		if(vecLine[8]!="Res"){Ex.Logger.Log("BuffPool.csv中字段[Res]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)9)
			{
				return false;
			}
			BuffPoolElement member = new BuffPoolElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.POS=vecLine[1];
			member.TriggerRange=Convert.ToSingle(vecLine[2]);
			member.RefreshType=Convert.ToInt32(vecLine[3]);
			member.RefreshCD=Convert.ToInt32(vecLine[4]);
			member.GroupID=Convert.ToInt32(vecLine[5]);
			member.GroupMaxRefreshCount=Convert.ToInt32(vecLine[6]);
			member.BuffIDList=vecLine[7];
			member.Res=vecLine[8];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
