using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//基础AI配置数据类
public class BaseAIElement
{
	public int baseAiId;         	//基础AIID	基础AIID
	public string Comment;       	//AI说明	AI具体描述(策划用字段，不会导出)
	public int canMove;          	//可否移动	是否可移动（-1不可，1可移动）
	public int attackType;       	//攻击类型	攻击类型：-1不主动攻击，1主动攻击
	public int aiCd;             	//CD时间	AI的CD时间（毫秒）
	public int MaxInterval;      	//最大攻击间隔	攻击间隔时间随机范围的最大值，单位毫秒
	public int MinInterval;      	//最小攻击间隔	攻击间隔时间随机范围的最小值，单位毫秒
	public int SkillInterval;    	//技能释放间隔	非普攻技能的释放间隔（单位，毫秒）
	public int MoveProbability;  	//移动概率	间隔期内移动的概率，万分比
	public int noAttack;         	//不可被攻击	是否不可被攻击：-1可被攻击，1不可攻击
	public int patrolRate;       	//巡逻概率	巡逻概率：-1不巡逻，1--100概率
	public int followPortal;     	//跟随传送	是否跟随目标进行传送(-1不跟随,1跟随)
	public int counterAttack;    	//可否还击	1还击-1不还击
	public int SkillPriority;    	//技能选取优先级	1伤害，2距离，3伤害范围
	public int GuardType;        	//警戒方式	1仅身前，2身前身后都有
	public int GuardScope;       	//警戒范围	以角色为原点做出的直线长度，单位m
	public int ReturnSpeed;      	//回归速度	BUFFID,如果-1则没有回归
	public int RaidScope;        	//追击范围	出生点为起始点，单位m
	public int BloodReturn;      	//脱战回血速度	n/s
	public int InterveneSkill;   	//应援技能	技能ID
	public int ExpandAI;         	//拓展AI	拓展AI组ID

	public bool IsValidate = false;
	public BaseAIElement()
	{
		baseAiId = -1;
	}
};

//基础AI配置封装类
public class BaseAITable
{

	private BaseAITable()
	{
		m_mapElements = new Dictionary<int, BaseAIElement>();
		m_emptyItem = new BaseAIElement();
		m_vecAllElements = new List<BaseAIElement>();
	}
	private Dictionary<int, BaseAIElement> m_mapElements = null;
	private List<BaseAIElement>	m_vecAllElements = null;
	private BaseAIElement m_emptyItem = null;
	private static BaseAITable sInstance = null;

	public static BaseAITable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BaseAITable();
			return sInstance;
		}
	}

	public BaseAIElement GetElement(int key)
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

  public List<BaseAIElement> GetAllElement(Predicate<BaseAIElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BaseAI.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BaseAI.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BaseAI.bin]未找到");
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
		if(vecLine.Count != 21)
		{
			Ex.Logger.Log("BaseAI.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="baseAiId"){Ex.Logger.Log("BaseAI.csv中字段[baseAiId]位置不对应"); return false; }
		if(vecLine[1]!="Comment"){Ex.Logger.Log("BaseAI.csv中字段[Comment]位置不对应"); return false; }
		if(vecLine[2]!="canMove"){Ex.Logger.Log("BaseAI.csv中字段[canMove]位置不对应"); return false; }
		if(vecLine[3]!="attackType"){Ex.Logger.Log("BaseAI.csv中字段[attackType]位置不对应"); return false; }
		if(vecLine[4]!="aiCd"){Ex.Logger.Log("BaseAI.csv中字段[aiCd]位置不对应"); return false; }
		if(vecLine[5]!="MaxInterval"){Ex.Logger.Log("BaseAI.csv中字段[MaxInterval]位置不对应"); return false; }
		if(vecLine[6]!="MinInterval"){Ex.Logger.Log("BaseAI.csv中字段[MinInterval]位置不对应"); return false; }
		if(vecLine[7]!="SkillInterval"){Ex.Logger.Log("BaseAI.csv中字段[SkillInterval]位置不对应"); return false; }
		if(vecLine[8]!="MoveProbability"){Ex.Logger.Log("BaseAI.csv中字段[MoveProbability]位置不对应"); return false; }
		if(vecLine[9]!="noAttack"){Ex.Logger.Log("BaseAI.csv中字段[noAttack]位置不对应"); return false; }
		if(vecLine[10]!="patrolRate"){Ex.Logger.Log("BaseAI.csv中字段[patrolRate]位置不对应"); return false; }
		if(vecLine[11]!="followPortal"){Ex.Logger.Log("BaseAI.csv中字段[followPortal]位置不对应"); return false; }
		if(vecLine[12]!="counterAttack"){Ex.Logger.Log("BaseAI.csv中字段[counterAttack]位置不对应"); return false; }
		if(vecLine[13]!="SkillPriority"){Ex.Logger.Log("BaseAI.csv中字段[SkillPriority]位置不对应"); return false; }
		if(vecLine[14]!="GuardType"){Ex.Logger.Log("BaseAI.csv中字段[GuardType]位置不对应"); return false; }
		if(vecLine[15]!="GuardScope"){Ex.Logger.Log("BaseAI.csv中字段[GuardScope]位置不对应"); return false; }
		if(vecLine[16]!="ReturnSpeed"){Ex.Logger.Log("BaseAI.csv中字段[ReturnSpeed]位置不对应"); return false; }
		if(vecLine[17]!="RaidScope"){Ex.Logger.Log("BaseAI.csv中字段[RaidScope]位置不对应"); return false; }
		if(vecLine[18]!="BloodReturn"){Ex.Logger.Log("BaseAI.csv中字段[BloodReturn]位置不对应"); return false; }
		if(vecLine[19]!="InterveneSkill"){Ex.Logger.Log("BaseAI.csv中字段[InterveneSkill]位置不对应"); return false; }
		if(vecLine[20]!="ExpandAI"){Ex.Logger.Log("BaseAI.csv中字段[ExpandAI]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BaseAIElement member = new BaseAIElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.baseAiId );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Comment);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.canMove );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.attackType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.aiCd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MaxInterval );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MinInterval );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillInterval );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoveProbability );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.noAttack );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.patrolRate );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.followPortal );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.counterAttack );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillPriority );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GuardType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GuardScope );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ReturnSpeed );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RaidScope );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BloodReturn );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.InterveneSkill );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ExpandAI );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.baseAiId] = member;
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
		if(vecLine.Count != 21)
		{
			Ex.Logger.Log("BaseAI.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="baseAiId"){Ex.Logger.Log("BaseAI.csv中字段[baseAiId]位置不对应"); return false; }
		if(vecLine[1]!="Comment"){Ex.Logger.Log("BaseAI.csv中字段[Comment]位置不对应"); return false; }
		if(vecLine[2]!="canMove"){Ex.Logger.Log("BaseAI.csv中字段[canMove]位置不对应"); return false; }
		if(vecLine[3]!="attackType"){Ex.Logger.Log("BaseAI.csv中字段[attackType]位置不对应"); return false; }
		if(vecLine[4]!="aiCd"){Ex.Logger.Log("BaseAI.csv中字段[aiCd]位置不对应"); return false; }
		if(vecLine[5]!="MaxInterval"){Ex.Logger.Log("BaseAI.csv中字段[MaxInterval]位置不对应"); return false; }
		if(vecLine[6]!="MinInterval"){Ex.Logger.Log("BaseAI.csv中字段[MinInterval]位置不对应"); return false; }
		if(vecLine[7]!="SkillInterval"){Ex.Logger.Log("BaseAI.csv中字段[SkillInterval]位置不对应"); return false; }
		if(vecLine[8]!="MoveProbability"){Ex.Logger.Log("BaseAI.csv中字段[MoveProbability]位置不对应"); return false; }
		if(vecLine[9]!="noAttack"){Ex.Logger.Log("BaseAI.csv中字段[noAttack]位置不对应"); return false; }
		if(vecLine[10]!="patrolRate"){Ex.Logger.Log("BaseAI.csv中字段[patrolRate]位置不对应"); return false; }
		if(vecLine[11]!="followPortal"){Ex.Logger.Log("BaseAI.csv中字段[followPortal]位置不对应"); return false; }
		if(vecLine[12]!="counterAttack"){Ex.Logger.Log("BaseAI.csv中字段[counterAttack]位置不对应"); return false; }
		if(vecLine[13]!="SkillPriority"){Ex.Logger.Log("BaseAI.csv中字段[SkillPriority]位置不对应"); return false; }
		if(vecLine[14]!="GuardType"){Ex.Logger.Log("BaseAI.csv中字段[GuardType]位置不对应"); return false; }
		if(vecLine[15]!="GuardScope"){Ex.Logger.Log("BaseAI.csv中字段[GuardScope]位置不对应"); return false; }
		if(vecLine[16]!="ReturnSpeed"){Ex.Logger.Log("BaseAI.csv中字段[ReturnSpeed]位置不对应"); return false; }
		if(vecLine[17]!="RaidScope"){Ex.Logger.Log("BaseAI.csv中字段[RaidScope]位置不对应"); return false; }
		if(vecLine[18]!="BloodReturn"){Ex.Logger.Log("BaseAI.csv中字段[BloodReturn]位置不对应"); return false; }
		if(vecLine[19]!="InterveneSkill"){Ex.Logger.Log("BaseAI.csv中字段[InterveneSkill]位置不对应"); return false; }
		if(vecLine[20]!="ExpandAI"){Ex.Logger.Log("BaseAI.csv中字段[ExpandAI]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)21)
			{
				return false;
			}
			BaseAIElement member = new BaseAIElement();
			member.baseAiId=Convert.ToInt32(vecLine[0]);
			member.Comment=vecLine[1];
			member.canMove=Convert.ToInt32(vecLine[2]);
			member.attackType=Convert.ToInt32(vecLine[3]);
			member.aiCd=Convert.ToInt32(vecLine[4]);
			member.MaxInterval=Convert.ToInt32(vecLine[5]);
			member.MinInterval=Convert.ToInt32(vecLine[6]);
			member.SkillInterval=Convert.ToInt32(vecLine[7]);
			member.MoveProbability=Convert.ToInt32(vecLine[8]);
			member.noAttack=Convert.ToInt32(vecLine[9]);
			member.patrolRate=Convert.ToInt32(vecLine[10]);
			member.followPortal=Convert.ToInt32(vecLine[11]);
			member.counterAttack=Convert.ToInt32(vecLine[12]);
			member.SkillPriority=Convert.ToInt32(vecLine[13]);
			member.GuardType=Convert.ToInt32(vecLine[14]);
			member.GuardScope=Convert.ToInt32(vecLine[15]);
			member.ReturnSpeed=Convert.ToInt32(vecLine[16]);
			member.RaidScope=Convert.ToInt32(vecLine[17]);
			member.BloodReturn=Convert.ToInt32(vecLine[18]);
			member.InterveneSkill=Convert.ToInt32(vecLine[19]);
			member.ExpandAI=Convert.ToInt32(vecLine[20]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.baseAiId] = member;
		}
		return true;
	}
};
