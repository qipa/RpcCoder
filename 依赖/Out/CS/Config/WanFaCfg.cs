using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//玩法表配置数据类
public class WanFaElement
{
	public int ID;               	//活动ID	编号
	public string Name;          	//活动名称	活动名称
	public string Tips;          	//活动描述	活动描述
	public string SourceIcon;    	//活动图标	活动图标
	public int CiShu;            	//挑战次数	挑战次数
	public int Next;             	//是否可继续挑战	1可以 -1不可以
	public int LV;               	//挑战等级	挑战等级
	public int Type;             	//任务形式	1单人任务 2组队任务 3 单人/组队
	public int Title;            	//活动标签	1日常 2节日
	public int HuoLi;            	//单次挑战活力值	单次挑战活力值
	public string Day;           	//开放日期	1周一2周二3周三4周四5周五6周六7星期天8全天
	public string StartTime;     	//挑战开始时间	挑战开始时间
	public string EndTime;       	//挑战结束时间	挑战结束时间
	public int Reward;           	//活动奖励	活动奖励
	public int In;               	//入口ID	入口ID
	public int NPC;              	//关联NPC	关联NPC
	public int Team;             	//相关组队ID	相关组队ID

	public bool IsValidate = false;
	public WanFaElement()
	{
		ID = -1;
	}
};

//玩法表配置封装类
public class WanFaTable
{

	private WanFaTable()
	{
		m_mapElements = new Dictionary<int, WanFaElement>();
		m_emptyItem = new WanFaElement();
		m_vecAllElements = new List<WanFaElement>();
	}
	private Dictionary<int, WanFaElement> m_mapElements = null;
	private List<WanFaElement>	m_vecAllElements = null;
	private WanFaElement m_emptyItem = null;
	private static WanFaTable sInstance = null;

	public static WanFaTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new WanFaTable();
			return sInstance;
		}
	}

	public WanFaElement GetElement(int key)
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

  public List<WanFaElement> GetAllElement(Predicate<WanFaElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("WanFa.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("WanFa.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[WanFa.bin]未找到");
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
		if(vecLine.Count != 17)
		{
			Ex.Logger.Log("WanFa.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("WanFa.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("WanFa.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Tips"){Ex.Logger.Log("WanFa.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[3]!="SourceIcon"){Ex.Logger.Log("WanFa.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[4]!="CiShu"){Ex.Logger.Log("WanFa.csv中字段[CiShu]位置不对应"); return false; }
		if(vecLine[5]!="Next"){Ex.Logger.Log("WanFa.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[6]!="LV"){Ex.Logger.Log("WanFa.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[7]!="Type"){Ex.Logger.Log("WanFa.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[8]!="Title"){Ex.Logger.Log("WanFa.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[9]!="HuoLi"){Ex.Logger.Log("WanFa.csv中字段[HuoLi]位置不对应"); return false; }
		if(vecLine[10]!="Day"){Ex.Logger.Log("WanFa.csv中字段[Day]位置不对应"); return false; }
		if(vecLine[11]!="StartTime"){Ex.Logger.Log("WanFa.csv中字段[StartTime]位置不对应"); return false; }
		if(vecLine[12]!="EndTime"){Ex.Logger.Log("WanFa.csv中字段[EndTime]位置不对应"); return false; }
		if(vecLine[13]!="Reward"){Ex.Logger.Log("WanFa.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[14]!="In"){Ex.Logger.Log("WanFa.csv中字段[In]位置不对应"); return false; }
		if(vecLine[15]!="NPC"){Ex.Logger.Log("WanFa.csv中字段[NPC]位置不对应"); return false; }
		if(vecLine[16]!="Team"){Ex.Logger.Log("WanFa.csv中字段[Team]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			WanFaElement member = new WanFaElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Tips);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SourceIcon);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CiShu );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Next );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LV );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Title );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HuoLi );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Day);
			readPos += GameAssist.ReadString( binContent, readPos, out member.StartTime);
			readPos += GameAssist.ReadString( binContent, readPos, out member.EndTime);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Reward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.In );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.NPC );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Team );

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
		if(vecLine.Count != 17)
		{
			Ex.Logger.Log("WanFa.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("WanFa.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("WanFa.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Tips"){Ex.Logger.Log("WanFa.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[3]!="SourceIcon"){Ex.Logger.Log("WanFa.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[4]!="CiShu"){Ex.Logger.Log("WanFa.csv中字段[CiShu]位置不对应"); return false; }
		if(vecLine[5]!="Next"){Ex.Logger.Log("WanFa.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[6]!="LV"){Ex.Logger.Log("WanFa.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[7]!="Type"){Ex.Logger.Log("WanFa.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[8]!="Title"){Ex.Logger.Log("WanFa.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[9]!="HuoLi"){Ex.Logger.Log("WanFa.csv中字段[HuoLi]位置不对应"); return false; }
		if(vecLine[10]!="Day"){Ex.Logger.Log("WanFa.csv中字段[Day]位置不对应"); return false; }
		if(vecLine[11]!="StartTime"){Ex.Logger.Log("WanFa.csv中字段[StartTime]位置不对应"); return false; }
		if(vecLine[12]!="EndTime"){Ex.Logger.Log("WanFa.csv中字段[EndTime]位置不对应"); return false; }
		if(vecLine[13]!="Reward"){Ex.Logger.Log("WanFa.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[14]!="In"){Ex.Logger.Log("WanFa.csv中字段[In]位置不对应"); return false; }
		if(vecLine[15]!="NPC"){Ex.Logger.Log("WanFa.csv中字段[NPC]位置不对应"); return false; }
		if(vecLine[16]!="Team"){Ex.Logger.Log("WanFa.csv中字段[Team]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)17)
			{
				return false;
			}
			WanFaElement member = new WanFaElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Tips=vecLine[2];
			member.SourceIcon=vecLine[3];
			member.CiShu=Convert.ToInt32(vecLine[4]);
			member.Next=Convert.ToInt32(vecLine[5]);
			member.LV=Convert.ToInt32(vecLine[6]);
			member.Type=Convert.ToInt32(vecLine[7]);
			member.Title=Convert.ToInt32(vecLine[8]);
			member.HuoLi=Convert.ToInt32(vecLine[9]);
			member.Day=vecLine[10];
			member.StartTime=vecLine[11];
			member.EndTime=vecLine[12];
			member.Reward=Convert.ToInt32(vecLine[13]);
			member.In=Convert.ToInt32(vecLine[14]);
			member.NPC=Convert.ToInt32(vecLine[15]);
			member.Team=Convert.ToInt32(vecLine[16]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
