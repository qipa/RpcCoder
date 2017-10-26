using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//活动日常配置数据类
public class HuoDongElement
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
	public string XunLu;         	//自动寻路导航	自动寻路导航
	public int TimeLimit;        	//时间限制	1有限制-1无限制
	public int Prompt;           	//功能开启是否需要提示	功能开启是否需要提示
	public int DanCi;            	//单次获得活力	单次获得活力
	public int DailyLimit;       	//每日活力上限	每日活力上限

	public bool IsValidate = false;
	public HuoDongElement()
	{
		ID = -1;
	}
};

//活动日常配置封装类
public class HuoDongTable
{

	private HuoDongTable()
	{
		m_mapElements = new Dictionary<int, HuoDongElement>();
		m_emptyItem = new HuoDongElement();
		m_vecAllElements = new List<HuoDongElement>();
	}
	private Dictionary<int, HuoDongElement> m_mapElements = null;
	private List<HuoDongElement>	m_vecAllElements = null;
	private HuoDongElement m_emptyItem = null;
	private static HuoDongTable sInstance = null;

	public static HuoDongTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new HuoDongTable();
			return sInstance;
		}
	}

	public HuoDongElement GetElement(int key)
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

  public List<HuoDongElement> GetAllElement(Predicate<HuoDongElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("HuoDong.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("HuoDong.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[HuoDong.bin]未找到");
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
		if(vecLine.Count != 22)
		{
			Ex.Logger.Log("HuoDong.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("HuoDong.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("HuoDong.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Tips"){Ex.Logger.Log("HuoDong.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[3]!="SourceIcon"){Ex.Logger.Log("HuoDong.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[4]!="CiShu"){Ex.Logger.Log("HuoDong.csv中字段[CiShu]位置不对应"); return false; }
		if(vecLine[5]!="Next"){Ex.Logger.Log("HuoDong.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[6]!="LV"){Ex.Logger.Log("HuoDong.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[7]!="Type"){Ex.Logger.Log("HuoDong.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[8]!="Title"){Ex.Logger.Log("HuoDong.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[9]!="HuoLi"){Ex.Logger.Log("HuoDong.csv中字段[HuoLi]位置不对应"); return false; }
		if(vecLine[10]!="Day"){Ex.Logger.Log("HuoDong.csv中字段[Day]位置不对应"); return false; }
		if(vecLine[11]!="StartTime"){Ex.Logger.Log("HuoDong.csv中字段[StartTime]位置不对应"); return false; }
		if(vecLine[12]!="EndTime"){Ex.Logger.Log("HuoDong.csv中字段[EndTime]位置不对应"); return false; }
		if(vecLine[13]!="Reward"){Ex.Logger.Log("HuoDong.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[14]!="In"){Ex.Logger.Log("HuoDong.csv中字段[In]位置不对应"); return false; }
		if(vecLine[15]!="NPC"){Ex.Logger.Log("HuoDong.csv中字段[NPC]位置不对应"); return false; }
		if(vecLine[16]!="Team"){Ex.Logger.Log("HuoDong.csv中字段[Team]位置不对应"); return false; }
		if(vecLine[17]!="XunLu"){Ex.Logger.Log("HuoDong.csv中字段[XunLu]位置不对应"); return false; }
		if(vecLine[18]!="TimeLimit"){Ex.Logger.Log("HuoDong.csv中字段[TimeLimit]位置不对应"); return false; }
		if(vecLine[19]!="Prompt"){Ex.Logger.Log("HuoDong.csv中字段[Prompt]位置不对应"); return false; }
		if(vecLine[20]!="DanCi"){Ex.Logger.Log("HuoDong.csv中字段[DanCi]位置不对应"); return false; }
		if(vecLine[21]!="DailyLimit"){Ex.Logger.Log("HuoDong.csv中字段[DailyLimit]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			HuoDongElement member = new HuoDongElement();
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
			readPos += GameAssist.ReadString( binContent, readPos, out member.XunLu);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TimeLimit );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Prompt );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DanCi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DailyLimit );

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
		if(vecLine.Count != 22)
		{
			Ex.Logger.Log("HuoDong.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("HuoDong.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("HuoDong.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Tips"){Ex.Logger.Log("HuoDong.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[3]!="SourceIcon"){Ex.Logger.Log("HuoDong.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[4]!="CiShu"){Ex.Logger.Log("HuoDong.csv中字段[CiShu]位置不对应"); return false; }
		if(vecLine[5]!="Next"){Ex.Logger.Log("HuoDong.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[6]!="LV"){Ex.Logger.Log("HuoDong.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[7]!="Type"){Ex.Logger.Log("HuoDong.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[8]!="Title"){Ex.Logger.Log("HuoDong.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[9]!="HuoLi"){Ex.Logger.Log("HuoDong.csv中字段[HuoLi]位置不对应"); return false; }
		if(vecLine[10]!="Day"){Ex.Logger.Log("HuoDong.csv中字段[Day]位置不对应"); return false; }
		if(vecLine[11]!="StartTime"){Ex.Logger.Log("HuoDong.csv中字段[StartTime]位置不对应"); return false; }
		if(vecLine[12]!="EndTime"){Ex.Logger.Log("HuoDong.csv中字段[EndTime]位置不对应"); return false; }
		if(vecLine[13]!="Reward"){Ex.Logger.Log("HuoDong.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[14]!="In"){Ex.Logger.Log("HuoDong.csv中字段[In]位置不对应"); return false; }
		if(vecLine[15]!="NPC"){Ex.Logger.Log("HuoDong.csv中字段[NPC]位置不对应"); return false; }
		if(vecLine[16]!="Team"){Ex.Logger.Log("HuoDong.csv中字段[Team]位置不对应"); return false; }
		if(vecLine[17]!="XunLu"){Ex.Logger.Log("HuoDong.csv中字段[XunLu]位置不对应"); return false; }
		if(vecLine[18]!="TimeLimit"){Ex.Logger.Log("HuoDong.csv中字段[TimeLimit]位置不对应"); return false; }
		if(vecLine[19]!="Prompt"){Ex.Logger.Log("HuoDong.csv中字段[Prompt]位置不对应"); return false; }
		if(vecLine[20]!="DanCi"){Ex.Logger.Log("HuoDong.csv中字段[DanCi]位置不对应"); return false; }
		if(vecLine[21]!="DailyLimit"){Ex.Logger.Log("HuoDong.csv中字段[DailyLimit]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)22)
			{
				return false;
			}
			HuoDongElement member = new HuoDongElement();
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
			member.XunLu=vecLine[17];
			member.TimeLimit=Convert.ToInt32(vecLine[18]);
			member.Prompt=Convert.ToInt32(vecLine[19]);
			member.DanCi=Convert.ToInt32(vecLine[20]);
			member.DailyLimit=Convert.ToInt32(vecLine[21]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
