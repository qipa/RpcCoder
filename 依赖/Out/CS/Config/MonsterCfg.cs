using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//怪物基本表配置数据类
public class MonsterElement
{
	public int MonsterID;        	//NpcID	编号
	public int ModelID;          	//模型ID	索引模型
	public float ModelScaling;   	//模型缩放	模型缩放比例，包含模型的所有东西进行缩放
	public int AttType;          	//攻击类型	0物理1法术
	public string Name;          	//NPC名称	NPC名称
	public string HeadIcon;      	//怪物头像	怪物的头像文件
	public string Title;         	//NPC称号	NPC称号
	public int Level;            	//等级	NPC的等级
	public int Group;            	//组ID	区分组别ID,用来识别一类型的怪物
	public int Type;             	//怪物类型	1、小怪2boss3塔4范围塔
	public int BaseAI;           	//AIID	索引基础AIID
	public float MonsterR;       	//怪物半径	怪物半径
	public int PingPong;         	//受击抖动	Boss受击抖动(-1不抖动1抖动)
	public int MonsterExp;       	//怪物经验	击杀该怪物可获得的经验值
	public int DropID;           	//掉落ID	索引掉落表
	public int Skill1;           	//普攻1	普攻1
	public int Skill2;           	//普攻2	普攻2
	public int Skill3;           	//普攻3	普攻3
	public int Skill4;           	//普攻4	普攻4
	public int Skill5;           	//技能1	技能1
	public int Skill6;           	//技能2	技能2
	public int Skill7;           	//技能3	技能3
	public int Skill8;           	//技能4	技能4
	public int Skill9;           	//技能5	技能5
	public string Skill;         	//技能集合	技能总和
	public float movSP;          	//移动速度	移动的速度，单位：m/s
	public float attSP;          	//攻击速度	普通攻击的速度（暂没用
	public int AllowMove;        	//是否有受击动作	0无，1有
	public int HP;               	//气血上限	气血上限
	public int reHP;             	//气血恢复速度	气血恢复速度
	public int MP;               	//法力上限	法力上限
	public int reMP;             	//法力恢复速度	法力恢复速度
	public int minPA;            	//最小物理攻击	最小物理攻击
	public int maxPA;            	//最大物理攻击	最大物理攻击
	public int minMA;            	//最小法术攻击	最小法术攻击
	public int maxMA;            	//最大法术攻击	最大法术攻击
	public int PD;               	//物理防御	物理防御
	public int MD;               	//法术防御	法术防御
	public int igPhi;            	//物理命中	物理命中
	public int igMdo;            	//法术命中	法术命中
	public int Pdo;              	//物理躲避	物理躲避
	public int Mdo;              	//法术躲避	法术躲避
	public float HitRate;        	//基础命中率	基础命中率
	public float CritRate;       	//基础暴击率	基础暴击率
	public float igPcr;          	//物理致命	物理致命
	public float igMcr;          	//法术致命	法术致命
	public float Pcr;            	//抗物理致命	抗物理致命
	public float Mcr;            	//抗法术致命	抗法术致命
	public float igPrd;          	//物理致命伤害	物理致命伤害
	public float igMrd;          	//法术致命伤害	法术致命伤害
	public float Prd;            	//抗物理致命伤害	抗物理致命伤害
	public float Mrd;            	//抗法术致命伤害	抗法术致命伤害
	public float igBlo;          	//破盾	破盾
	public float Blo;            	//格挡	格挡
	public float igBrd;          	//忽视格挡伤害减免	忽视格挡伤害减免
	public float Brd;            	//格挡伤害减免	格挡伤害减免
	public float igVEr;          	//强眩晕	强眩晕
	public float igSLr;          	//强睡眠	强睡眠
	public float igCHr;          	//强混乱	强混乱
	public float igABr;          	//强禁食	强禁食
	public float igSIr;          	//强沉默	强沉默
	public float igGRr;          	//强束缚	强束缚
	public float igPEr;          	//强石化	强石化
	public float VEr;            	//眩晕抗性	眩晕抗性
	public float SLr;            	//睡眠抗性	睡眠抗性
	public float CHr;            	//混乱抗性	混乱抗性
	public float ABr;            	//禁食抗性	禁食抗性
	public float SIr;            	//沉默抗性	沉默抗性
	public float GRr;            	//束缚抗性	束缚抗性
	public float PEr;            	//石化抗性	石化抗性
	public float igFr;           	//忽视火抗	忽视火抗
	public float igEr;           	//忽视电抗	忽视电抗
	public float igWr;           	//忽视风抗	忽视风抗
	public float igCr;           	//忽视冰抗	忽视冰抗
	public float igPr;           	//忽视毒抗	忽视毒抗
	public float igLr;           	//忽视光抗	忽视光抗
	public float igDr;           	//忽视暗抗	忽视暗抗
	public float Fr;             	//火抗性	火抗性
	public float Er;             	//电抗性	电抗性
	public float Wr;             	//风抗性	风抗性
	public float Cr;             	//冰抗性	冰抗性
	public float Pr;             	//毒抗性	毒抗性
	public float Lr;             	//光抗性	光抗性
	public float Dr;             	//暗抗性	暗抗性

	public bool IsValidate = false;
	public MonsterElement()
	{
		MonsterID = -1;
	}
};

//怪物基本表配置封装类
public class MonsterTable
{

	private MonsterTable()
	{
		m_mapElements = new Dictionary<int, MonsterElement>();
		m_emptyItem = new MonsterElement();
		m_vecAllElements = new List<MonsterElement>();
	}
	private Dictionary<int, MonsterElement> m_mapElements = null;
	private List<MonsterElement>	m_vecAllElements = null;
	private MonsterElement m_emptyItem = null;
	private static MonsterTable sInstance = null;

	public static MonsterTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MonsterTable();
			return sInstance;
		}
	}

	public MonsterElement GetElement(int key)
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

  public List<MonsterElement> GetAllElement(Predicate<MonsterElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Monster.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Monster.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Monster.bin]未找到");
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
		if(vecLine.Count != 84)
		{
			Ex.Logger.Log("Monster.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MonsterID"){Ex.Logger.Log("Monster.csv中字段[MonsterID]位置不对应"); return false; }
		if(vecLine[1]!="ModelID"){Ex.Logger.Log("Monster.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[2]!="ModelScaling"){Ex.Logger.Log("Monster.csv中字段[ModelScaling]位置不对应"); return false; }
		if(vecLine[3]!="AttType"){Ex.Logger.Log("Monster.csv中字段[AttType]位置不对应"); return false; }
		if(vecLine[4]!="Name"){Ex.Logger.Log("Monster.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[5]!="HeadIcon"){Ex.Logger.Log("Monster.csv中字段[HeadIcon]位置不对应"); return false; }
		if(vecLine[6]!="Title"){Ex.Logger.Log("Monster.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[7]!="Level"){Ex.Logger.Log("Monster.csv中字段[Level]位置不对应"); return false; }
		if(vecLine[8]!="Group"){Ex.Logger.Log("Monster.csv中字段[Group]位置不对应"); return false; }
		if(vecLine[9]!="Type"){Ex.Logger.Log("Monster.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[10]!="BaseAI"){Ex.Logger.Log("Monster.csv中字段[BaseAI]位置不对应"); return false; }
		if(vecLine[11]!="MonsterR"){Ex.Logger.Log("Monster.csv中字段[MonsterR]位置不对应"); return false; }
		if(vecLine[12]!="PingPong"){Ex.Logger.Log("Monster.csv中字段[PingPong]位置不对应"); return false; }
		if(vecLine[13]!="MonsterExp"){Ex.Logger.Log("Monster.csv中字段[MonsterExp]位置不对应"); return false; }
		if(vecLine[14]!="DropID"){Ex.Logger.Log("Monster.csv中字段[DropID]位置不对应"); return false; }
		if(vecLine[15]!="Skill1"){Ex.Logger.Log("Monster.csv中字段[Skill1]位置不对应"); return false; }
		if(vecLine[16]!="Skill2"){Ex.Logger.Log("Monster.csv中字段[Skill2]位置不对应"); return false; }
		if(vecLine[17]!="Skill3"){Ex.Logger.Log("Monster.csv中字段[Skill3]位置不对应"); return false; }
		if(vecLine[18]!="Skill4"){Ex.Logger.Log("Monster.csv中字段[Skill4]位置不对应"); return false; }
		if(vecLine[19]!="Skill5"){Ex.Logger.Log("Monster.csv中字段[Skill5]位置不对应"); return false; }
		if(vecLine[20]!="Skill6"){Ex.Logger.Log("Monster.csv中字段[Skill6]位置不对应"); return false; }
		if(vecLine[21]!="Skill7"){Ex.Logger.Log("Monster.csv中字段[Skill7]位置不对应"); return false; }
		if(vecLine[22]!="Skill8"){Ex.Logger.Log("Monster.csv中字段[Skill8]位置不对应"); return false; }
		if(vecLine[23]!="Skill9"){Ex.Logger.Log("Monster.csv中字段[Skill9]位置不对应"); return false; }
		if(vecLine[24]!="Skill"){Ex.Logger.Log("Monster.csv中字段[Skill]位置不对应"); return false; }
		if(vecLine[25]!="movSP"){Ex.Logger.Log("Monster.csv中字段[movSP]位置不对应"); return false; }
		if(vecLine[26]!="attSP"){Ex.Logger.Log("Monster.csv中字段[attSP]位置不对应"); return false; }
		if(vecLine[27]!="AllowMove"){Ex.Logger.Log("Monster.csv中字段[AllowMove]位置不对应"); return false; }
		if(vecLine[28]!="HP"){Ex.Logger.Log("Monster.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[29]!="reHP"){Ex.Logger.Log("Monster.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[30]!="MP"){Ex.Logger.Log("Monster.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[31]!="reMP"){Ex.Logger.Log("Monster.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[32]!="minPA"){Ex.Logger.Log("Monster.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[33]!="maxPA"){Ex.Logger.Log("Monster.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[34]!="minMA"){Ex.Logger.Log("Monster.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[35]!="maxMA"){Ex.Logger.Log("Monster.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[36]!="PD"){Ex.Logger.Log("Monster.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[37]!="MD"){Ex.Logger.Log("Monster.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[38]!="igPhi"){Ex.Logger.Log("Monster.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[39]!="igMdo"){Ex.Logger.Log("Monster.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[40]!="Pdo"){Ex.Logger.Log("Monster.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[41]!="Mdo"){Ex.Logger.Log("Monster.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[42]!="HitRate"){Ex.Logger.Log("Monster.csv中字段[HitRate]位置不对应"); return false; }
		if(vecLine[43]!="CritRate"){Ex.Logger.Log("Monster.csv中字段[CritRate]位置不对应"); return false; }
		if(vecLine[44]!="igPcr"){Ex.Logger.Log("Monster.csv中字段[igPcr]位置不对应"); return false; }
		if(vecLine[45]!="igMcr"){Ex.Logger.Log("Monster.csv中字段[igMcr]位置不对应"); return false; }
		if(vecLine[46]!="Pcr"){Ex.Logger.Log("Monster.csv中字段[Pcr]位置不对应"); return false; }
		if(vecLine[47]!="Mcr"){Ex.Logger.Log("Monster.csv中字段[Mcr]位置不对应"); return false; }
		if(vecLine[48]!="igPrd"){Ex.Logger.Log("Monster.csv中字段[igPrd]位置不对应"); return false; }
		if(vecLine[49]!="igMrd"){Ex.Logger.Log("Monster.csv中字段[igMrd]位置不对应"); return false; }
		if(vecLine[50]!="Prd"){Ex.Logger.Log("Monster.csv中字段[Prd]位置不对应"); return false; }
		if(vecLine[51]!="Mrd"){Ex.Logger.Log("Monster.csv中字段[Mrd]位置不对应"); return false; }
		if(vecLine[52]!="igBlo"){Ex.Logger.Log("Monster.csv中字段[igBlo]位置不对应"); return false; }
		if(vecLine[53]!="Blo"){Ex.Logger.Log("Monster.csv中字段[Blo]位置不对应"); return false; }
		if(vecLine[54]!="igBrd"){Ex.Logger.Log("Monster.csv中字段[igBrd]位置不对应"); return false; }
		if(vecLine[55]!="Brd"){Ex.Logger.Log("Monster.csv中字段[Brd]位置不对应"); return false; }
		if(vecLine[56]!="igVEr"){Ex.Logger.Log("Monster.csv中字段[igVEr]位置不对应"); return false; }
		if(vecLine[57]!="igSLr"){Ex.Logger.Log("Monster.csv中字段[igSLr]位置不对应"); return false; }
		if(vecLine[58]!="igCHr"){Ex.Logger.Log("Monster.csv中字段[igCHr]位置不对应"); return false; }
		if(vecLine[59]!="igABr"){Ex.Logger.Log("Monster.csv中字段[igABr]位置不对应"); return false; }
		if(vecLine[60]!="igSIr"){Ex.Logger.Log("Monster.csv中字段[igSIr]位置不对应"); return false; }
		if(vecLine[61]!="igGRr"){Ex.Logger.Log("Monster.csv中字段[igGRr]位置不对应"); return false; }
		if(vecLine[62]!="igPEr"){Ex.Logger.Log("Monster.csv中字段[igPEr]位置不对应"); return false; }
		if(vecLine[63]!="VEr"){Ex.Logger.Log("Monster.csv中字段[VEr]位置不对应"); return false; }
		if(vecLine[64]!="SLr"){Ex.Logger.Log("Monster.csv中字段[SLr]位置不对应"); return false; }
		if(vecLine[65]!="CHr"){Ex.Logger.Log("Monster.csv中字段[CHr]位置不对应"); return false; }
		if(vecLine[66]!="ABr"){Ex.Logger.Log("Monster.csv中字段[ABr]位置不对应"); return false; }
		if(vecLine[67]!="SIr"){Ex.Logger.Log("Monster.csv中字段[SIr]位置不对应"); return false; }
		if(vecLine[68]!="GRr"){Ex.Logger.Log("Monster.csv中字段[GRr]位置不对应"); return false; }
		if(vecLine[69]!="PEr"){Ex.Logger.Log("Monster.csv中字段[PEr]位置不对应"); return false; }
		if(vecLine[70]!="igFr"){Ex.Logger.Log("Monster.csv中字段[igFr]位置不对应"); return false; }
		if(vecLine[71]!="igEr"){Ex.Logger.Log("Monster.csv中字段[igEr]位置不对应"); return false; }
		if(vecLine[72]!="igWr"){Ex.Logger.Log("Monster.csv中字段[igWr]位置不对应"); return false; }
		if(vecLine[73]!="igCr"){Ex.Logger.Log("Monster.csv中字段[igCr]位置不对应"); return false; }
		if(vecLine[74]!="igPr"){Ex.Logger.Log("Monster.csv中字段[igPr]位置不对应"); return false; }
		if(vecLine[75]!="igLr"){Ex.Logger.Log("Monster.csv中字段[igLr]位置不对应"); return false; }
		if(vecLine[76]!="igDr"){Ex.Logger.Log("Monster.csv中字段[igDr]位置不对应"); return false; }
		if(vecLine[77]!="Fr"){Ex.Logger.Log("Monster.csv中字段[Fr]位置不对应"); return false; }
		if(vecLine[78]!="Er"){Ex.Logger.Log("Monster.csv中字段[Er]位置不对应"); return false; }
		if(vecLine[79]!="Wr"){Ex.Logger.Log("Monster.csv中字段[Wr]位置不对应"); return false; }
		if(vecLine[80]!="Cr"){Ex.Logger.Log("Monster.csv中字段[Cr]位置不对应"); return false; }
		if(vecLine[81]!="Pr"){Ex.Logger.Log("Monster.csv中字段[Pr]位置不对应"); return false; }
		if(vecLine[82]!="Lr"){Ex.Logger.Log("Monster.csv中字段[Lr]位置不对应"); return false; }
		if(vecLine[83]!="Dr"){Ex.Logger.Log("Monster.csv中字段[Dr]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MonsterElement member = new MonsterElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MonsterID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.ModelScaling);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.HeadIcon);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Title);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Level );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Group );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BaseAI );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.MonsterR);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PingPong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MonsterExp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DropID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill7 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill8 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill9 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Skill);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.movSP);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.attSP);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AllowMove );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.reHP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.reMP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.minPA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.maxPA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.minMA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.maxMA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PD );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MD );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igPhi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igMdo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Pdo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Mdo );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.HitRate);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.CritRate);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igPcr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igMcr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Pcr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Mcr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igPrd);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igMrd);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Prd);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Mrd);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igBlo);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Blo);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igBrd);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Brd);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igVEr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igSLr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igCHr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igABr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igSIr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igGRr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igPEr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.VEr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.SLr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.CHr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.ABr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.SIr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.GRr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.PEr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igFr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igEr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igWr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igCr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igPr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igLr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.igDr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Fr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Er);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Wr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Cr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Pr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Lr);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Dr);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MonsterID] = member;
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
		if(vecLine.Count != 84)
		{
			Ex.Logger.Log("Monster.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MonsterID"){Ex.Logger.Log("Monster.csv中字段[MonsterID]位置不对应"); return false; }
		if(vecLine[1]!="ModelID"){Ex.Logger.Log("Monster.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[2]!="ModelScaling"){Ex.Logger.Log("Monster.csv中字段[ModelScaling]位置不对应"); return false; }
		if(vecLine[3]!="AttType"){Ex.Logger.Log("Monster.csv中字段[AttType]位置不对应"); return false; }
		if(vecLine[4]!="Name"){Ex.Logger.Log("Monster.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[5]!="HeadIcon"){Ex.Logger.Log("Monster.csv中字段[HeadIcon]位置不对应"); return false; }
		if(vecLine[6]!="Title"){Ex.Logger.Log("Monster.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[7]!="Level"){Ex.Logger.Log("Monster.csv中字段[Level]位置不对应"); return false; }
		if(vecLine[8]!="Group"){Ex.Logger.Log("Monster.csv中字段[Group]位置不对应"); return false; }
		if(vecLine[9]!="Type"){Ex.Logger.Log("Monster.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[10]!="BaseAI"){Ex.Logger.Log("Monster.csv中字段[BaseAI]位置不对应"); return false; }
		if(vecLine[11]!="MonsterR"){Ex.Logger.Log("Monster.csv中字段[MonsterR]位置不对应"); return false; }
		if(vecLine[12]!="PingPong"){Ex.Logger.Log("Monster.csv中字段[PingPong]位置不对应"); return false; }
		if(vecLine[13]!="MonsterExp"){Ex.Logger.Log("Monster.csv中字段[MonsterExp]位置不对应"); return false; }
		if(vecLine[14]!="DropID"){Ex.Logger.Log("Monster.csv中字段[DropID]位置不对应"); return false; }
		if(vecLine[15]!="Skill1"){Ex.Logger.Log("Monster.csv中字段[Skill1]位置不对应"); return false; }
		if(vecLine[16]!="Skill2"){Ex.Logger.Log("Monster.csv中字段[Skill2]位置不对应"); return false; }
		if(vecLine[17]!="Skill3"){Ex.Logger.Log("Monster.csv中字段[Skill3]位置不对应"); return false; }
		if(vecLine[18]!="Skill4"){Ex.Logger.Log("Monster.csv中字段[Skill4]位置不对应"); return false; }
		if(vecLine[19]!="Skill5"){Ex.Logger.Log("Monster.csv中字段[Skill5]位置不对应"); return false; }
		if(vecLine[20]!="Skill6"){Ex.Logger.Log("Monster.csv中字段[Skill6]位置不对应"); return false; }
		if(vecLine[21]!="Skill7"){Ex.Logger.Log("Monster.csv中字段[Skill7]位置不对应"); return false; }
		if(vecLine[22]!="Skill8"){Ex.Logger.Log("Monster.csv中字段[Skill8]位置不对应"); return false; }
		if(vecLine[23]!="Skill9"){Ex.Logger.Log("Monster.csv中字段[Skill9]位置不对应"); return false; }
		if(vecLine[24]!="Skill"){Ex.Logger.Log("Monster.csv中字段[Skill]位置不对应"); return false; }
		if(vecLine[25]!="movSP"){Ex.Logger.Log("Monster.csv中字段[movSP]位置不对应"); return false; }
		if(vecLine[26]!="attSP"){Ex.Logger.Log("Monster.csv中字段[attSP]位置不对应"); return false; }
		if(vecLine[27]!="AllowMove"){Ex.Logger.Log("Monster.csv中字段[AllowMove]位置不对应"); return false; }
		if(vecLine[28]!="HP"){Ex.Logger.Log("Monster.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[29]!="reHP"){Ex.Logger.Log("Monster.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[30]!="MP"){Ex.Logger.Log("Monster.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[31]!="reMP"){Ex.Logger.Log("Monster.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[32]!="minPA"){Ex.Logger.Log("Monster.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[33]!="maxPA"){Ex.Logger.Log("Monster.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[34]!="minMA"){Ex.Logger.Log("Monster.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[35]!="maxMA"){Ex.Logger.Log("Monster.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[36]!="PD"){Ex.Logger.Log("Monster.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[37]!="MD"){Ex.Logger.Log("Monster.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[38]!="igPhi"){Ex.Logger.Log("Monster.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[39]!="igMdo"){Ex.Logger.Log("Monster.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[40]!="Pdo"){Ex.Logger.Log("Monster.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[41]!="Mdo"){Ex.Logger.Log("Monster.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[42]!="HitRate"){Ex.Logger.Log("Monster.csv中字段[HitRate]位置不对应"); return false; }
		if(vecLine[43]!="CritRate"){Ex.Logger.Log("Monster.csv中字段[CritRate]位置不对应"); return false; }
		if(vecLine[44]!="igPcr"){Ex.Logger.Log("Monster.csv中字段[igPcr]位置不对应"); return false; }
		if(vecLine[45]!="igMcr"){Ex.Logger.Log("Monster.csv中字段[igMcr]位置不对应"); return false; }
		if(vecLine[46]!="Pcr"){Ex.Logger.Log("Monster.csv中字段[Pcr]位置不对应"); return false; }
		if(vecLine[47]!="Mcr"){Ex.Logger.Log("Monster.csv中字段[Mcr]位置不对应"); return false; }
		if(vecLine[48]!="igPrd"){Ex.Logger.Log("Monster.csv中字段[igPrd]位置不对应"); return false; }
		if(vecLine[49]!="igMrd"){Ex.Logger.Log("Monster.csv中字段[igMrd]位置不对应"); return false; }
		if(vecLine[50]!="Prd"){Ex.Logger.Log("Monster.csv中字段[Prd]位置不对应"); return false; }
		if(vecLine[51]!="Mrd"){Ex.Logger.Log("Monster.csv中字段[Mrd]位置不对应"); return false; }
		if(vecLine[52]!="igBlo"){Ex.Logger.Log("Monster.csv中字段[igBlo]位置不对应"); return false; }
		if(vecLine[53]!="Blo"){Ex.Logger.Log("Monster.csv中字段[Blo]位置不对应"); return false; }
		if(vecLine[54]!="igBrd"){Ex.Logger.Log("Monster.csv中字段[igBrd]位置不对应"); return false; }
		if(vecLine[55]!="Brd"){Ex.Logger.Log("Monster.csv中字段[Brd]位置不对应"); return false; }
		if(vecLine[56]!="igVEr"){Ex.Logger.Log("Monster.csv中字段[igVEr]位置不对应"); return false; }
		if(vecLine[57]!="igSLr"){Ex.Logger.Log("Monster.csv中字段[igSLr]位置不对应"); return false; }
		if(vecLine[58]!="igCHr"){Ex.Logger.Log("Monster.csv中字段[igCHr]位置不对应"); return false; }
		if(vecLine[59]!="igABr"){Ex.Logger.Log("Monster.csv中字段[igABr]位置不对应"); return false; }
		if(vecLine[60]!="igSIr"){Ex.Logger.Log("Monster.csv中字段[igSIr]位置不对应"); return false; }
		if(vecLine[61]!="igGRr"){Ex.Logger.Log("Monster.csv中字段[igGRr]位置不对应"); return false; }
		if(vecLine[62]!="igPEr"){Ex.Logger.Log("Monster.csv中字段[igPEr]位置不对应"); return false; }
		if(vecLine[63]!="VEr"){Ex.Logger.Log("Monster.csv中字段[VEr]位置不对应"); return false; }
		if(vecLine[64]!="SLr"){Ex.Logger.Log("Monster.csv中字段[SLr]位置不对应"); return false; }
		if(vecLine[65]!="CHr"){Ex.Logger.Log("Monster.csv中字段[CHr]位置不对应"); return false; }
		if(vecLine[66]!="ABr"){Ex.Logger.Log("Monster.csv中字段[ABr]位置不对应"); return false; }
		if(vecLine[67]!="SIr"){Ex.Logger.Log("Monster.csv中字段[SIr]位置不对应"); return false; }
		if(vecLine[68]!="GRr"){Ex.Logger.Log("Monster.csv中字段[GRr]位置不对应"); return false; }
		if(vecLine[69]!="PEr"){Ex.Logger.Log("Monster.csv中字段[PEr]位置不对应"); return false; }
		if(vecLine[70]!="igFr"){Ex.Logger.Log("Monster.csv中字段[igFr]位置不对应"); return false; }
		if(vecLine[71]!="igEr"){Ex.Logger.Log("Monster.csv中字段[igEr]位置不对应"); return false; }
		if(vecLine[72]!="igWr"){Ex.Logger.Log("Monster.csv中字段[igWr]位置不对应"); return false; }
		if(vecLine[73]!="igCr"){Ex.Logger.Log("Monster.csv中字段[igCr]位置不对应"); return false; }
		if(vecLine[74]!="igPr"){Ex.Logger.Log("Monster.csv中字段[igPr]位置不对应"); return false; }
		if(vecLine[75]!="igLr"){Ex.Logger.Log("Monster.csv中字段[igLr]位置不对应"); return false; }
		if(vecLine[76]!="igDr"){Ex.Logger.Log("Monster.csv中字段[igDr]位置不对应"); return false; }
		if(vecLine[77]!="Fr"){Ex.Logger.Log("Monster.csv中字段[Fr]位置不对应"); return false; }
		if(vecLine[78]!="Er"){Ex.Logger.Log("Monster.csv中字段[Er]位置不对应"); return false; }
		if(vecLine[79]!="Wr"){Ex.Logger.Log("Monster.csv中字段[Wr]位置不对应"); return false; }
		if(vecLine[80]!="Cr"){Ex.Logger.Log("Monster.csv中字段[Cr]位置不对应"); return false; }
		if(vecLine[81]!="Pr"){Ex.Logger.Log("Monster.csv中字段[Pr]位置不对应"); return false; }
		if(vecLine[82]!="Lr"){Ex.Logger.Log("Monster.csv中字段[Lr]位置不对应"); return false; }
		if(vecLine[83]!="Dr"){Ex.Logger.Log("Monster.csv中字段[Dr]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)84)
			{
				return false;
			}
			MonsterElement member = new MonsterElement();
			member.MonsterID=Convert.ToInt32(vecLine[0]);
			member.ModelID=Convert.ToInt32(vecLine[1]);
			member.ModelScaling=Convert.ToSingle(vecLine[2]);
			member.AttType=Convert.ToInt32(vecLine[3]);
			member.Name=vecLine[4];
			member.HeadIcon=vecLine[5];
			member.Title=vecLine[6];
			member.Level=Convert.ToInt32(vecLine[7]);
			member.Group=Convert.ToInt32(vecLine[8]);
			member.Type=Convert.ToInt32(vecLine[9]);
			member.BaseAI=Convert.ToInt32(vecLine[10]);
			member.MonsterR=Convert.ToSingle(vecLine[11]);
			member.PingPong=Convert.ToInt32(vecLine[12]);
			member.MonsterExp=Convert.ToInt32(vecLine[13]);
			member.DropID=Convert.ToInt32(vecLine[14]);
			member.Skill1=Convert.ToInt32(vecLine[15]);
			member.Skill2=Convert.ToInt32(vecLine[16]);
			member.Skill3=Convert.ToInt32(vecLine[17]);
			member.Skill4=Convert.ToInt32(vecLine[18]);
			member.Skill5=Convert.ToInt32(vecLine[19]);
			member.Skill6=Convert.ToInt32(vecLine[20]);
			member.Skill7=Convert.ToInt32(vecLine[21]);
			member.Skill8=Convert.ToInt32(vecLine[22]);
			member.Skill9=Convert.ToInt32(vecLine[23]);
			member.Skill=vecLine[24];
			member.movSP=Convert.ToSingle(vecLine[25]);
			member.attSP=Convert.ToSingle(vecLine[26]);
			member.AllowMove=Convert.ToInt32(vecLine[27]);
			member.HP=Convert.ToInt32(vecLine[28]);
			member.reHP=Convert.ToInt32(vecLine[29]);
			member.MP=Convert.ToInt32(vecLine[30]);
			member.reMP=Convert.ToInt32(vecLine[31]);
			member.minPA=Convert.ToInt32(vecLine[32]);
			member.maxPA=Convert.ToInt32(vecLine[33]);
			member.minMA=Convert.ToInt32(vecLine[34]);
			member.maxMA=Convert.ToInt32(vecLine[35]);
			member.PD=Convert.ToInt32(vecLine[36]);
			member.MD=Convert.ToInt32(vecLine[37]);
			member.igPhi=Convert.ToInt32(vecLine[38]);
			member.igMdo=Convert.ToInt32(vecLine[39]);
			member.Pdo=Convert.ToInt32(vecLine[40]);
			member.Mdo=Convert.ToInt32(vecLine[41]);
			member.HitRate=Convert.ToSingle(vecLine[42]);
			member.CritRate=Convert.ToSingle(vecLine[43]);
			member.igPcr=Convert.ToSingle(vecLine[44]);
			member.igMcr=Convert.ToSingle(vecLine[45]);
			member.Pcr=Convert.ToSingle(vecLine[46]);
			member.Mcr=Convert.ToSingle(vecLine[47]);
			member.igPrd=Convert.ToSingle(vecLine[48]);
			member.igMrd=Convert.ToSingle(vecLine[49]);
			member.Prd=Convert.ToSingle(vecLine[50]);
			member.Mrd=Convert.ToSingle(vecLine[51]);
			member.igBlo=Convert.ToSingle(vecLine[52]);
			member.Blo=Convert.ToSingle(vecLine[53]);
			member.igBrd=Convert.ToSingle(vecLine[54]);
			member.Brd=Convert.ToSingle(vecLine[55]);
			member.igVEr=Convert.ToSingle(vecLine[56]);
			member.igSLr=Convert.ToSingle(vecLine[57]);
			member.igCHr=Convert.ToSingle(vecLine[58]);
			member.igABr=Convert.ToSingle(vecLine[59]);
			member.igSIr=Convert.ToSingle(vecLine[60]);
			member.igGRr=Convert.ToSingle(vecLine[61]);
			member.igPEr=Convert.ToSingle(vecLine[62]);
			member.VEr=Convert.ToSingle(vecLine[63]);
			member.SLr=Convert.ToSingle(vecLine[64]);
			member.CHr=Convert.ToSingle(vecLine[65]);
			member.ABr=Convert.ToSingle(vecLine[66]);
			member.SIr=Convert.ToSingle(vecLine[67]);
			member.GRr=Convert.ToSingle(vecLine[68]);
			member.PEr=Convert.ToSingle(vecLine[69]);
			member.igFr=Convert.ToSingle(vecLine[70]);
			member.igEr=Convert.ToSingle(vecLine[71]);
			member.igWr=Convert.ToSingle(vecLine[72]);
			member.igCr=Convert.ToSingle(vecLine[73]);
			member.igPr=Convert.ToSingle(vecLine[74]);
			member.igLr=Convert.ToSingle(vecLine[75]);
			member.igDr=Convert.ToSingle(vecLine[76]);
			member.Fr=Convert.ToSingle(vecLine[77]);
			member.Er=Convert.ToSingle(vecLine[78]);
			member.Wr=Convert.ToSingle(vecLine[79]);
			member.Cr=Convert.ToSingle(vecLine[80]);
			member.Pr=Convert.ToSingle(vecLine[81]);
			member.Lr=Convert.ToSingle(vecLine[82]);
			member.Dr=Convert.ToSingle(vecLine[83]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MonsterID] = member;
		}
		return true;
	}
};
