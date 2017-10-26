using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//副本表配置数据类
public class DungeonsElement
{
	public int DungeonsID;       	//副本ID	副本ID
	public int FunctionID;       	//所属章节	副本所属的章节ID（1-普通剧情，2-英雄剧情，3-PVP，98-大逃杀，99-夺旗，91-1v1）
	public int Type;             	//副本类型	1PVE，2PVP，3主城，4野外,5世界副本,6帮会
	public string SceneResource; 	//美术场景资源	美术场景资源
	public string MonsterConfigure;	//怪物配置链接	怪物配置链接
	public string Name;          	//副本名称	副本的名字
	public string Music;         	//场景音乐	场景音乐
	public string Describe;      	//副本描述	副本描述
	public int RewardShow;       	//奖励显示	显示用的奖励
	public string MonsterIcon;   	//怪物头像	副本列表内的图片
	public int FBTime;           	//挑战时间	挑战时间
	public int ExitTime;         	//退出等待时间	退出等待时间
	public int Close;            	//中途退出	是否显示退出按钮
	public int CloseType;        	//关闭类型	退出特殊操作类型（前后端特用1特殊，0忽略）
	public string ShowMap;       	//地图显示	地图上显示的图标
	public string MapResource;   	//小地图配置	小地图文件配置，如果为空则没有小地图,主城
	public string MapLayer;      	//地图层	小地图层数据，名字加“,”隔开
	public string MapSkewing;    	//小地图偏移	格式X,Y,向量偏移
	public int MapRatio;         	//小地图缩放	填入的为像素，即1m=N像素
	public string PKType;        	//容许的PK模式	1和平、2全体、3工会、4组队、5善恶
	public int LimitLevel;       	//进入等级	容许进入该场景的等级
	public string ResetTime;     	//重置时间	副本次数重置时间
	public string OpenTime;      	//开放时间	副本的开放时间
	public int Team;             	//是否组队进入	是否组队进入（0不组队进 1组队进 2进入时退队 ）
	public int TeamMembers;      	//组队进入最少人数	组队进入最少人数
	public int ChallengeTimes;   	//可挑战次数	副本可免费挑战的次数
	public int BuyTimes;         	//最大可购买次数	副本最大可购买次数
	public int Reward1Star;      	//1星奖励	1星奖励
	public int Reward2Star;      	//2星奖励	2星奖励
	public int Reward3Star;      	//3星奖励	3星奖励
	public int StarLevel;        	//起始等级	副本动态变化的起始等级，如果为-1则副本不进行动态变化
	public int FinalLevel;       	//结束等级	副本动态变化的结束等级，如果为-1则副本不进行动态变化
	public int Relive;           	//复活方式	复活表的ID
	public int AutoMode;         	//自动战斗方式	-1.不自动自动战斗，1.本层自动战斗（有范围配置），2.全图自动战斗
	public int AutoScope;        	//索敌范围	单层自动战斗时配置范围，单位m
	public int Mission;          	//关联任务	关联任务

	public bool IsValidate = false;
	public DungeonsElement()
	{
		DungeonsID = -1;
	}
};

//副本表配置封装类
public class DungeonsTable
{

	private DungeonsTable()
	{
		m_mapElements = new Dictionary<int, DungeonsElement>();
		m_emptyItem = new DungeonsElement();
		m_vecAllElements = new List<DungeonsElement>();
	}
	private Dictionary<int, DungeonsElement> m_mapElements = null;
	private List<DungeonsElement>	m_vecAllElements = null;
	private DungeonsElement m_emptyItem = null;
	private static DungeonsTable sInstance = null;

	public static DungeonsTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new DungeonsTable();
			return sInstance;
		}
	}

	public DungeonsElement GetElement(int key)
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

  public List<DungeonsElement> GetAllElement(Predicate<DungeonsElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Dungeons.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Dungeons.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Dungeons.bin]未找到");
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
		if(vecLine.Count != 36)
		{
			Ex.Logger.Log("Dungeons.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="DungeonsID"){Ex.Logger.Log("Dungeons.csv中字段[DungeonsID]位置不对应"); return false; }
		if(vecLine[1]!="FunctionID"){Ex.Logger.Log("Dungeons.csv中字段[FunctionID]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("Dungeons.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="SceneResource"){Ex.Logger.Log("Dungeons.csv中字段[SceneResource]位置不对应"); return false; }
		if(vecLine[4]!="MonsterConfigure"){Ex.Logger.Log("Dungeons.csv中字段[MonsterConfigure]位置不对应"); return false; }
		if(vecLine[5]!="Name"){Ex.Logger.Log("Dungeons.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[6]!="Music"){Ex.Logger.Log("Dungeons.csv中字段[Music]位置不对应"); return false; }
		if(vecLine[7]!="Describe"){Ex.Logger.Log("Dungeons.csv中字段[Describe]位置不对应"); return false; }
		if(vecLine[8]!="RewardShow"){Ex.Logger.Log("Dungeons.csv中字段[RewardShow]位置不对应"); return false; }
		if(vecLine[9]!="MonsterIcon"){Ex.Logger.Log("Dungeons.csv中字段[MonsterIcon]位置不对应"); return false; }
		if(vecLine[10]!="FBTime"){Ex.Logger.Log("Dungeons.csv中字段[FBTime]位置不对应"); return false; }
		if(vecLine[11]!="ExitTime"){Ex.Logger.Log("Dungeons.csv中字段[ExitTime]位置不对应"); return false; }
		if(vecLine[12]!="Close"){Ex.Logger.Log("Dungeons.csv中字段[Close]位置不对应"); return false; }
		if(vecLine[13]!="CloseType"){Ex.Logger.Log("Dungeons.csv中字段[CloseType]位置不对应"); return false; }
		if(vecLine[14]!="ShowMap"){Ex.Logger.Log("Dungeons.csv中字段[ShowMap]位置不对应"); return false; }
		if(vecLine[15]!="MapResource"){Ex.Logger.Log("Dungeons.csv中字段[MapResource]位置不对应"); return false; }
		if(vecLine[16]!="MapLayer"){Ex.Logger.Log("Dungeons.csv中字段[MapLayer]位置不对应"); return false; }
		if(vecLine[17]!="MapSkewing"){Ex.Logger.Log("Dungeons.csv中字段[MapSkewing]位置不对应"); return false; }
		if(vecLine[18]!="MapRatio"){Ex.Logger.Log("Dungeons.csv中字段[MapRatio]位置不对应"); return false; }
		if(vecLine[19]!="PKType"){Ex.Logger.Log("Dungeons.csv中字段[PKType]位置不对应"); return false; }
		if(vecLine[20]!="LimitLevel"){Ex.Logger.Log("Dungeons.csv中字段[LimitLevel]位置不对应"); return false; }
		if(vecLine[21]!="ResetTime"){Ex.Logger.Log("Dungeons.csv中字段[ResetTime]位置不对应"); return false; }
		if(vecLine[22]!="OpenTime"){Ex.Logger.Log("Dungeons.csv中字段[OpenTime]位置不对应"); return false; }
		if(vecLine[23]!="Team"){Ex.Logger.Log("Dungeons.csv中字段[Team]位置不对应"); return false; }
		if(vecLine[24]!="TeamMembers"){Ex.Logger.Log("Dungeons.csv中字段[TeamMembers]位置不对应"); return false; }
		if(vecLine[25]!="ChallengeTimes"){Ex.Logger.Log("Dungeons.csv中字段[ChallengeTimes]位置不对应"); return false; }
		if(vecLine[26]!="BuyTimes"){Ex.Logger.Log("Dungeons.csv中字段[BuyTimes]位置不对应"); return false; }
		if(vecLine[27]!="Reward1Star"){Ex.Logger.Log("Dungeons.csv中字段[Reward1Star]位置不对应"); return false; }
		if(vecLine[28]!="Reward2Star"){Ex.Logger.Log("Dungeons.csv中字段[Reward2Star]位置不对应"); return false; }
		if(vecLine[29]!="Reward3Star"){Ex.Logger.Log("Dungeons.csv中字段[Reward3Star]位置不对应"); return false; }
		if(vecLine[30]!="StarLevel"){Ex.Logger.Log("Dungeons.csv中字段[StarLevel]位置不对应"); return false; }
		if(vecLine[31]!="FinalLevel"){Ex.Logger.Log("Dungeons.csv中字段[FinalLevel]位置不对应"); return false; }
		if(vecLine[32]!="Relive"){Ex.Logger.Log("Dungeons.csv中字段[Relive]位置不对应"); return false; }
		if(vecLine[33]!="AutoMode"){Ex.Logger.Log("Dungeons.csv中字段[AutoMode]位置不对应"); return false; }
		if(vecLine[34]!="AutoScope"){Ex.Logger.Log("Dungeons.csv中字段[AutoScope]位置不对应"); return false; }
		if(vecLine[35]!="Mission"){Ex.Logger.Log("Dungeons.csv中字段[Mission]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			DungeonsElement member = new DungeonsElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DungeonsID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FunctionID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SceneResource);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MonsterConfigure);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Music);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Describe);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RewardShow );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MonsterIcon);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FBTime );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ExitTime );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Close );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CloseType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ShowMap);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MapResource);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MapLayer);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MapSkewing);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MapRatio );
			readPos += GameAssist.ReadString( binContent, readPos, out member.PKType);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LimitLevel );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ResetTime);
			readPos += GameAssist.ReadString( binContent, readPos, out member.OpenTime);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Team );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TeamMembers );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ChallengeTimes );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BuyTimes );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Reward1Star );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Reward2Star );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Reward3Star );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.StarLevel );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FinalLevel );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Relive );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AutoMode );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AutoScope );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Mission );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.DungeonsID] = member;
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
		if(vecLine.Count != 36)
		{
			Ex.Logger.Log("Dungeons.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="DungeonsID"){Ex.Logger.Log("Dungeons.csv中字段[DungeonsID]位置不对应"); return false; }
		if(vecLine[1]!="FunctionID"){Ex.Logger.Log("Dungeons.csv中字段[FunctionID]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("Dungeons.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="SceneResource"){Ex.Logger.Log("Dungeons.csv中字段[SceneResource]位置不对应"); return false; }
		if(vecLine[4]!="MonsterConfigure"){Ex.Logger.Log("Dungeons.csv中字段[MonsterConfigure]位置不对应"); return false; }
		if(vecLine[5]!="Name"){Ex.Logger.Log("Dungeons.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[6]!="Music"){Ex.Logger.Log("Dungeons.csv中字段[Music]位置不对应"); return false; }
		if(vecLine[7]!="Describe"){Ex.Logger.Log("Dungeons.csv中字段[Describe]位置不对应"); return false; }
		if(vecLine[8]!="RewardShow"){Ex.Logger.Log("Dungeons.csv中字段[RewardShow]位置不对应"); return false; }
		if(vecLine[9]!="MonsterIcon"){Ex.Logger.Log("Dungeons.csv中字段[MonsterIcon]位置不对应"); return false; }
		if(vecLine[10]!="FBTime"){Ex.Logger.Log("Dungeons.csv中字段[FBTime]位置不对应"); return false; }
		if(vecLine[11]!="ExitTime"){Ex.Logger.Log("Dungeons.csv中字段[ExitTime]位置不对应"); return false; }
		if(vecLine[12]!="Close"){Ex.Logger.Log("Dungeons.csv中字段[Close]位置不对应"); return false; }
		if(vecLine[13]!="CloseType"){Ex.Logger.Log("Dungeons.csv中字段[CloseType]位置不对应"); return false; }
		if(vecLine[14]!="ShowMap"){Ex.Logger.Log("Dungeons.csv中字段[ShowMap]位置不对应"); return false; }
		if(vecLine[15]!="MapResource"){Ex.Logger.Log("Dungeons.csv中字段[MapResource]位置不对应"); return false; }
		if(vecLine[16]!="MapLayer"){Ex.Logger.Log("Dungeons.csv中字段[MapLayer]位置不对应"); return false; }
		if(vecLine[17]!="MapSkewing"){Ex.Logger.Log("Dungeons.csv中字段[MapSkewing]位置不对应"); return false; }
		if(vecLine[18]!="MapRatio"){Ex.Logger.Log("Dungeons.csv中字段[MapRatio]位置不对应"); return false; }
		if(vecLine[19]!="PKType"){Ex.Logger.Log("Dungeons.csv中字段[PKType]位置不对应"); return false; }
		if(vecLine[20]!="LimitLevel"){Ex.Logger.Log("Dungeons.csv中字段[LimitLevel]位置不对应"); return false; }
		if(vecLine[21]!="ResetTime"){Ex.Logger.Log("Dungeons.csv中字段[ResetTime]位置不对应"); return false; }
		if(vecLine[22]!="OpenTime"){Ex.Logger.Log("Dungeons.csv中字段[OpenTime]位置不对应"); return false; }
		if(vecLine[23]!="Team"){Ex.Logger.Log("Dungeons.csv中字段[Team]位置不对应"); return false; }
		if(vecLine[24]!="TeamMembers"){Ex.Logger.Log("Dungeons.csv中字段[TeamMembers]位置不对应"); return false; }
		if(vecLine[25]!="ChallengeTimes"){Ex.Logger.Log("Dungeons.csv中字段[ChallengeTimes]位置不对应"); return false; }
		if(vecLine[26]!="BuyTimes"){Ex.Logger.Log("Dungeons.csv中字段[BuyTimes]位置不对应"); return false; }
		if(vecLine[27]!="Reward1Star"){Ex.Logger.Log("Dungeons.csv中字段[Reward1Star]位置不对应"); return false; }
		if(vecLine[28]!="Reward2Star"){Ex.Logger.Log("Dungeons.csv中字段[Reward2Star]位置不对应"); return false; }
		if(vecLine[29]!="Reward3Star"){Ex.Logger.Log("Dungeons.csv中字段[Reward3Star]位置不对应"); return false; }
		if(vecLine[30]!="StarLevel"){Ex.Logger.Log("Dungeons.csv中字段[StarLevel]位置不对应"); return false; }
		if(vecLine[31]!="FinalLevel"){Ex.Logger.Log("Dungeons.csv中字段[FinalLevel]位置不对应"); return false; }
		if(vecLine[32]!="Relive"){Ex.Logger.Log("Dungeons.csv中字段[Relive]位置不对应"); return false; }
		if(vecLine[33]!="AutoMode"){Ex.Logger.Log("Dungeons.csv中字段[AutoMode]位置不对应"); return false; }
		if(vecLine[34]!="AutoScope"){Ex.Logger.Log("Dungeons.csv中字段[AutoScope]位置不对应"); return false; }
		if(vecLine[35]!="Mission"){Ex.Logger.Log("Dungeons.csv中字段[Mission]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)36)
			{
				return false;
			}
			DungeonsElement member = new DungeonsElement();
			member.DungeonsID=Convert.ToInt32(vecLine[0]);
			member.FunctionID=Convert.ToInt32(vecLine[1]);
			member.Type=Convert.ToInt32(vecLine[2]);
			member.SceneResource=vecLine[3];
			member.MonsterConfigure=vecLine[4];
			member.Name=vecLine[5];
			member.Music=vecLine[6];
			member.Describe=vecLine[7];
			member.RewardShow=Convert.ToInt32(vecLine[8]);
			member.MonsterIcon=vecLine[9];
			member.FBTime=Convert.ToInt32(vecLine[10]);
			member.ExitTime=Convert.ToInt32(vecLine[11]);
			member.Close=Convert.ToInt32(vecLine[12]);
			member.CloseType=Convert.ToInt32(vecLine[13]);
			member.ShowMap=vecLine[14];
			member.MapResource=vecLine[15];
			member.MapLayer=vecLine[16];
			member.MapSkewing=vecLine[17];
			member.MapRatio=Convert.ToInt32(vecLine[18]);
			member.PKType=vecLine[19];
			member.LimitLevel=Convert.ToInt32(vecLine[20]);
			member.ResetTime=vecLine[21];
			member.OpenTime=vecLine[22];
			member.Team=Convert.ToInt32(vecLine[23]);
			member.TeamMembers=Convert.ToInt32(vecLine[24]);
			member.ChallengeTimes=Convert.ToInt32(vecLine[25]);
			member.BuyTimes=Convert.ToInt32(vecLine[26]);
			member.Reward1Star=Convert.ToInt32(vecLine[27]);
			member.Reward2Star=Convert.ToInt32(vecLine[28]);
			member.Reward3Star=Convert.ToInt32(vecLine[29]);
			member.StarLevel=Convert.ToInt32(vecLine[30]);
			member.FinalLevel=Convert.ToInt32(vecLine[31]);
			member.Relive=Convert.ToInt32(vecLine[32]);
			member.AutoMode=Convert.ToInt32(vecLine[33]);
			member.AutoScope=Convert.ToInt32(vecLine[34]);
			member.Mission=Convert.ToInt32(vecLine[35]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.DungeonsID] = member;
		}
		return true;
	}
};
