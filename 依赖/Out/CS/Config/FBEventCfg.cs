using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//副本事件配置数据类
public class FBEventElement
{
	public int ID;               	//事件id	事件id
	public int TriggerType1;     	//触发类型1	1：时间，2：区域
	public int TriggerArgs1;     	//触发参数1	触发参数1
	public int TriggerType2;     	//触发类型2	触发类型2
	public int TriggerArgs2;     	//触发参数2	触发参数2
	public int ContinueTime;     	//持续时间	持续时间
	public int EventType;        	//触发事件类型	1：对话，2：AI行为
	public int EventArgs;        	//触发事件参数	触发事件参数(ai行为 1.开启AI 2.停止AI)
	public int EventTimes;       	//可触发次数	可触发次数
	public int Next;             	//下一个事件id	下一个事件id

	public bool IsValidate = false;
	public FBEventElement()
	{
		ID = -1;
	}
};

//副本事件配置封装类
public class FBEventTable
{

	private FBEventTable()
	{
		m_mapElements = new Dictionary<int, FBEventElement>();
		m_emptyItem = new FBEventElement();
		m_vecAllElements = new List<FBEventElement>();
	}
	private Dictionary<int, FBEventElement> m_mapElements = null;
	private List<FBEventElement>	m_vecAllElements = null;
	private FBEventElement m_emptyItem = null;
	private static FBEventTable sInstance = null;

	public static FBEventTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FBEventTable();
			return sInstance;
		}
	}

	public FBEventElement GetElement(int key)
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

  public List<FBEventElement> GetAllElement(Predicate<FBEventElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("FBEvent.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("FBEvent.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[FBEvent.bin]未找到");
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
		if(vecLine.Count != 10)
		{
			Ex.Logger.Log("FBEvent.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FBEvent.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="TriggerType1"){Ex.Logger.Log("FBEvent.csv中字段[TriggerType1]位置不对应"); return false; }
		if(vecLine[2]!="TriggerArgs1"){Ex.Logger.Log("FBEvent.csv中字段[TriggerArgs1]位置不对应"); return false; }
		if(vecLine[3]!="TriggerType2"){Ex.Logger.Log("FBEvent.csv中字段[TriggerType2]位置不对应"); return false; }
		if(vecLine[4]!="TriggerArgs2"){Ex.Logger.Log("FBEvent.csv中字段[TriggerArgs2]位置不对应"); return false; }
		if(vecLine[5]!="ContinueTime"){Ex.Logger.Log("FBEvent.csv中字段[ContinueTime]位置不对应"); return false; }
		if(vecLine[6]!="EventType"){Ex.Logger.Log("FBEvent.csv中字段[EventType]位置不对应"); return false; }
		if(vecLine[7]!="EventArgs"){Ex.Logger.Log("FBEvent.csv中字段[EventArgs]位置不对应"); return false; }
		if(vecLine[8]!="EventTimes"){Ex.Logger.Log("FBEvent.csv中字段[EventTimes]位置不对应"); return false; }
		if(vecLine[9]!="Next"){Ex.Logger.Log("FBEvent.csv中字段[Next]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FBEventElement member = new FBEventElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TriggerType1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TriggerArgs1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TriggerType2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TriggerArgs2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ContinueTime );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EventType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EventArgs );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EventTimes );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Next );

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
		if(vecLine.Count != 10)
		{
			Ex.Logger.Log("FBEvent.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FBEvent.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="TriggerType1"){Ex.Logger.Log("FBEvent.csv中字段[TriggerType1]位置不对应"); return false; }
		if(vecLine[2]!="TriggerArgs1"){Ex.Logger.Log("FBEvent.csv中字段[TriggerArgs1]位置不对应"); return false; }
		if(vecLine[3]!="TriggerType2"){Ex.Logger.Log("FBEvent.csv中字段[TriggerType2]位置不对应"); return false; }
		if(vecLine[4]!="TriggerArgs2"){Ex.Logger.Log("FBEvent.csv中字段[TriggerArgs2]位置不对应"); return false; }
		if(vecLine[5]!="ContinueTime"){Ex.Logger.Log("FBEvent.csv中字段[ContinueTime]位置不对应"); return false; }
		if(vecLine[6]!="EventType"){Ex.Logger.Log("FBEvent.csv中字段[EventType]位置不对应"); return false; }
		if(vecLine[7]!="EventArgs"){Ex.Logger.Log("FBEvent.csv中字段[EventArgs]位置不对应"); return false; }
		if(vecLine[8]!="EventTimes"){Ex.Logger.Log("FBEvent.csv中字段[EventTimes]位置不对应"); return false; }
		if(vecLine[9]!="Next"){Ex.Logger.Log("FBEvent.csv中字段[Next]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)10)
			{
				return false;
			}
			FBEventElement member = new FBEventElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.TriggerType1=Convert.ToInt32(vecLine[1]);
			member.TriggerArgs1=Convert.ToInt32(vecLine[2]);
			member.TriggerType2=Convert.ToInt32(vecLine[3]);
			member.TriggerArgs2=Convert.ToInt32(vecLine[4]);
			member.ContinueTime=Convert.ToInt32(vecLine[5]);
			member.EventType=Convert.ToInt32(vecLine[6]);
			member.EventArgs=Convert.ToInt32(vecLine[7]);
			member.EventTimes=Convert.ToInt32(vecLine[8]);
			member.Next=Convert.ToInt32(vecLine[9]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
