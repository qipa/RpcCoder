using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//复活表配置数据类
public class ReviveElement
{
	public int ID;               	//编号	等级
	public string Name;          	//说明	显示内容
	public string Desc;          	//描述	描述
	public int Type;             	//复活类型	1 手动复活 2 自动复活 3 原地+回城 4 不能复活
	public int Set;              	//复活点	1 主城 2 当前场景复活点 3 原地 4随机当前场景地点 5大逃杀复活
	public int HoldTime;         	//等待操作时间	等待操作时间
	public int Time;             	//等待复活时间	等待复活时间
	public int MoneyType;        	//消耗金钱	消耗金钱（对应货币表）
	public int XiaoHao;          	//复活消耗	复活消耗
	public int FreeTimes;        	//免费次数	免费次数：-1永久免费 0无免费 N固定次数
	public int BuffID;           	//BUFFID	复活后的状态
	public int TeamSharing;      	//TeamSharing	是否共享复活

	public bool IsValidate = false;
	public ReviveElement()
	{
		ID = -1;
	}
};

//复活表配置封装类
public class ReviveTable
{

	private ReviveTable()
	{
		m_mapElements = new Dictionary<int, ReviveElement>();
		m_emptyItem = new ReviveElement();
		m_vecAllElements = new List<ReviveElement>();
	}
	private Dictionary<int, ReviveElement> m_mapElements = null;
	private List<ReviveElement>	m_vecAllElements = null;
	private ReviveElement m_emptyItem = null;
	private static ReviveTable sInstance = null;

	public static ReviveTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ReviveTable();
			return sInstance;
		}
	}

	public ReviveElement GetElement(int key)
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

  public List<ReviveElement> GetAllElement(Predicate<ReviveElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Revive.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Revive.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Revive.bin]未找到");
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
			Ex.Logger.Log("Revive.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Revive.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Revive.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Desc"){Ex.Logger.Log("Revive.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Revive.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Set"){Ex.Logger.Log("Revive.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[5]!="HoldTime"){Ex.Logger.Log("Revive.csv中字段[HoldTime]位置不对应"); return false; }
		if(vecLine[6]!="Time"){Ex.Logger.Log("Revive.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[7]!="MoneyType"){Ex.Logger.Log("Revive.csv中字段[MoneyType]位置不对应"); return false; }
		if(vecLine[8]!="XiaoHao"){Ex.Logger.Log("Revive.csv中字段[XiaoHao]位置不对应"); return false; }
		if(vecLine[9]!="FreeTimes"){Ex.Logger.Log("Revive.csv中字段[FreeTimes]位置不对应"); return false; }
		if(vecLine[10]!="BuffID"){Ex.Logger.Log("Revive.csv中字段[BuffID]位置不对应"); return false; }
		if(vecLine[11]!="TeamSharing"){Ex.Logger.Log("Revive.csv中字段[TeamSharing]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ReviveElement member = new ReviveElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Desc);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Set );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HoldTime );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Time );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiaoHao );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FreeTimes );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BuffID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TeamSharing );

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
			Ex.Logger.Log("Revive.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Revive.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Revive.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Desc"){Ex.Logger.Log("Revive.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Revive.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Set"){Ex.Logger.Log("Revive.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[5]!="HoldTime"){Ex.Logger.Log("Revive.csv中字段[HoldTime]位置不对应"); return false; }
		if(vecLine[6]!="Time"){Ex.Logger.Log("Revive.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[7]!="MoneyType"){Ex.Logger.Log("Revive.csv中字段[MoneyType]位置不对应"); return false; }
		if(vecLine[8]!="XiaoHao"){Ex.Logger.Log("Revive.csv中字段[XiaoHao]位置不对应"); return false; }
		if(vecLine[9]!="FreeTimes"){Ex.Logger.Log("Revive.csv中字段[FreeTimes]位置不对应"); return false; }
		if(vecLine[10]!="BuffID"){Ex.Logger.Log("Revive.csv中字段[BuffID]位置不对应"); return false; }
		if(vecLine[11]!="TeamSharing"){Ex.Logger.Log("Revive.csv中字段[TeamSharing]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)12)
			{
				return false;
			}
			ReviveElement member = new ReviveElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Desc=vecLine[2];
			member.Type=Convert.ToInt32(vecLine[3]);
			member.Set=Convert.ToInt32(vecLine[4]);
			member.HoldTime=Convert.ToInt32(vecLine[5]);
			member.Time=Convert.ToInt32(vecLine[6]);
			member.MoneyType=Convert.ToInt32(vecLine[7]);
			member.XiaoHao=Convert.ToInt32(vecLine[8]);
			member.FreeTimes=Convert.ToInt32(vecLine[9]);
			member.BuffID=Convert.ToInt32(vecLine[10]);
			member.TeamSharing=Convert.ToInt32(vecLine[11]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
