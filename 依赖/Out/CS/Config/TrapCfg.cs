using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//陷阱表配置数据类
public class TrapElement
{
	public int TrapID;           	//陷阱ID	陷阱ID
	public string AblityID;      	//陷阱表现	索引陷阱资源
	public int TriggerType;      	//触发器类型	触发器的类型
	public string TriggerParameter1;	//触发器参数1	触发器参数1
	public string TriggerParameter2;	//触发器参数2	触发器参数2
	public int Times;            	//可触发次数	陷阱可触发的次数
	public int BuffID;           	//BUFFID	陷进触发后造成的效果

	public bool IsValidate = false;
	public TrapElement()
	{
		TrapID = -1;
	}
};

//陷阱表配置封装类
public class TrapTable
{

	private TrapTable()
	{
		m_mapElements = new Dictionary<int, TrapElement>();
		m_emptyItem = new TrapElement();
		m_vecAllElements = new List<TrapElement>();
	}
	private Dictionary<int, TrapElement> m_mapElements = null;
	private List<TrapElement>	m_vecAllElements = null;
	private TrapElement m_emptyItem = null;
	private static TrapTable sInstance = null;

	public static TrapTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new TrapTable();
			return sInstance;
		}
	}

	public TrapElement GetElement(int key)
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

  public List<TrapElement> GetAllElement(Predicate<TrapElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Trap.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Trap.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Trap.bin]未找到");
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
			Ex.Logger.Log("Trap.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="TrapID"){Ex.Logger.Log("Trap.csv中字段[TrapID]位置不对应"); return false; }
		if(vecLine[1]!="AblityID"){Ex.Logger.Log("Trap.csv中字段[AblityID]位置不对应"); return false; }
		if(vecLine[2]!="TriggerType"){Ex.Logger.Log("Trap.csv中字段[TriggerType]位置不对应"); return false; }
		if(vecLine[3]!="TriggerParameter1"){Ex.Logger.Log("Trap.csv中字段[TriggerParameter1]位置不对应"); return false; }
		if(vecLine[4]!="TriggerParameter2"){Ex.Logger.Log("Trap.csv中字段[TriggerParameter2]位置不对应"); return false; }
		if(vecLine[5]!="Times"){Ex.Logger.Log("Trap.csv中字段[Times]位置不对应"); return false; }
		if(vecLine[6]!="BuffID"){Ex.Logger.Log("Trap.csv中字段[BuffID]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			TrapElement member = new TrapElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TrapID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.AblityID);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TriggerType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.TriggerParameter1);
			readPos += GameAssist.ReadString( binContent, readPos, out member.TriggerParameter2);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Times );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BuffID );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.TrapID] = member;
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
			Ex.Logger.Log("Trap.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="TrapID"){Ex.Logger.Log("Trap.csv中字段[TrapID]位置不对应"); return false; }
		if(vecLine[1]!="AblityID"){Ex.Logger.Log("Trap.csv中字段[AblityID]位置不对应"); return false; }
		if(vecLine[2]!="TriggerType"){Ex.Logger.Log("Trap.csv中字段[TriggerType]位置不对应"); return false; }
		if(vecLine[3]!="TriggerParameter1"){Ex.Logger.Log("Trap.csv中字段[TriggerParameter1]位置不对应"); return false; }
		if(vecLine[4]!="TriggerParameter2"){Ex.Logger.Log("Trap.csv中字段[TriggerParameter2]位置不对应"); return false; }
		if(vecLine[5]!="Times"){Ex.Logger.Log("Trap.csv中字段[Times]位置不对应"); return false; }
		if(vecLine[6]!="BuffID"){Ex.Logger.Log("Trap.csv中字段[BuffID]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)7)
			{
				return false;
			}
			TrapElement member = new TrapElement();
			member.TrapID=Convert.ToInt32(vecLine[0]);
			member.AblityID=vecLine[1];
			member.TriggerType=Convert.ToInt32(vecLine[2]);
			member.TriggerParameter1=vecLine[3];
			member.TriggerParameter2=vecLine[4];
			member.Times=Convert.ToInt32(vecLine[5]);
			member.BuffID=Convert.ToInt32(vecLine[6]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.TrapID] = member;
		}
		return true;
	}
};
