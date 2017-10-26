using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//英雄配置数据类
public class HeroElement
{
	public int Hero;             	//编号	编号
	public string Name;          	//名称	名称
	public int ModelID;          	//模型ID	模型ID
	public int Sex;              	//性别	1男2女
	public string HeadID;        	//选人界面头像素材	选人界面头像素材
	public string Zhu_HeadID;    	//主界面头像素材	主界面头像素材
	public string FB_HeadID;     	//副本头像素材	副本对话头像素材
	public string Career_Icon;   	//职业图标	职业图标
	public string ZhiYeIcon;     	//职业图标（选人）	职业图标（选人）
	public int XingJi;           	//上手难度星级	上手难度星级
	public int AttType;          	//攻击类型	0物理1法术
	public float HeroR;          	//英雄半径	英雄的模型大小，单位：m
	public int Type;             	//英雄类型（1力量2敏捷3智力4耐力5辅助）	英雄类型（1拳师2战士3射手4医生5法师）
	public float SpeedFuben;     	//副本中移动速度	副本中移动速度
	public float SpeedZhucheng;  	//主城中移动速度	主城中移动速度
	public int Colour;           	//初始颜色	初始颜色（1白2绿3蓝4紫5橙6红）
	public int Star;             	//初始星级	初始星级
	public int Suipian;          	//升星碎片	升星碎片
	public int Num;              	//合成所需碎片数量	合成所需碎片数量
	public string Skill;         	//技能	技能
	public int Skill1;           	//普通攻击1	普通攻击1
	public int Skill2;           	//普通攻击2	普通攻击2
	public int Skill3;           	//普通攻击3	普通攻击3
	public int Skill4;           	//技能1	技能1
	public int Skill5;           	//技能2	技能2
	public int Skill6;           	//技能3	技能3
	public int Skill7;           	//大技能	大技能
	public int Skill8;           	//合体技	合体技
	public int Skill9;           	//被动	被动
	public int AllowMove;        	//是否有受击动作	0无，1有
	public int STA;              	//根骨	根骨
	public int SPI;              	//精力	精力
	public int STR;              	//力量	力量
	public int INT;              	//智力	智力
	public int AGI;              	//敏捷	敏捷
	public int STALVUP;          	//根骨等级成长	根骨等级成长
	public int SPILVUP;          	//精力等级成长	精力等级成长
	public int STRLVUP;          	//力量等级成长	力量等级成长
	public int INTLVUP;          	//智力等级成长	智力等级成长
	public int AGILVUP;          	//敏捷等级成长	敏捷等级成长
	public string HP;            	//气血上限	气血上限
	public string reHP;          	//气血恢复速度	气血恢复速度
	public string MP;            	//法力上限	法力上限
	public string reMP;          	//法力恢复速度	法力恢复速度
	public string minPA;         	//最小物理攻击	最小物理攻击
	public string maxPA;         	//最大物理攻击	最大物理攻击
	public string minMA;         	//最小法术攻击	最小法术攻击
	public string maxMA;         	//最大法术攻击	最大法术攻击
	public string PD;            	//物理防御	物理防御
	public string MD;            	//法术防御	法术防御
	public string igPhi;         	//物理命中	物理命中
	public string igMdo;         	//法术命中	法术命中
	public string Pdo;           	//物理躲避	物理躲避
	public string Mdo;           	//法术躲避	法术躲避
	public float HitRate;        	//基础命中率	基础命中率
	public float CritRate;       	//基础暴击率	基础暴击率

	public bool IsValidate = false;
	public HeroElement()
	{
		Hero = -1;
	}
};

//英雄配置封装类
public class HeroTable
{

	private HeroTable()
	{
		m_mapElements = new Dictionary<int, HeroElement>();
		m_emptyItem = new HeroElement();
		m_vecAllElements = new List<HeroElement>();
	}
	private Dictionary<int, HeroElement> m_mapElements = null;
	private List<HeroElement>	m_vecAllElements = null;
	private HeroElement m_emptyItem = null;
	private static HeroTable sInstance = null;

	public static HeroTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new HeroTable();
			return sInstance;
		}
	}

	public HeroElement GetElement(int key)
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

  public List<HeroElement> GetAllElement(Predicate<HeroElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Hero.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Hero.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Hero.bin]未找到");
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
		if(vecLine.Count != 56)
		{
			Ex.Logger.Log("Hero.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Hero"){Ex.Logger.Log("Hero.csv中字段[Hero]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Hero.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="ModelID"){Ex.Logger.Log("Hero.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[3]!="Sex"){Ex.Logger.Log("Hero.csv中字段[Sex]位置不对应"); return false; }
		if(vecLine[4]!="HeadID"){Ex.Logger.Log("Hero.csv中字段[HeadID]位置不对应"); return false; }
		if(vecLine[5]!="Zhu_HeadID"){Ex.Logger.Log("Hero.csv中字段[Zhu_HeadID]位置不对应"); return false; }
		if(vecLine[6]!="FB_HeadID"){Ex.Logger.Log("Hero.csv中字段[FB_HeadID]位置不对应"); return false; }
		if(vecLine[7]!="Career_Icon"){Ex.Logger.Log("Hero.csv中字段[Career_Icon]位置不对应"); return false; }
		if(vecLine[8]!="ZhiYeIcon"){Ex.Logger.Log("Hero.csv中字段[ZhiYeIcon]位置不对应"); return false; }
		if(vecLine[9]!="XingJi"){Ex.Logger.Log("Hero.csv中字段[XingJi]位置不对应"); return false; }
		if(vecLine[10]!="AttType"){Ex.Logger.Log("Hero.csv中字段[AttType]位置不对应"); return false; }
		if(vecLine[11]!="HeroR"){Ex.Logger.Log("Hero.csv中字段[HeroR]位置不对应"); return false; }
		if(vecLine[12]!="Type"){Ex.Logger.Log("Hero.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[13]!="SpeedFuben"){Ex.Logger.Log("Hero.csv中字段[SpeedFuben]位置不对应"); return false; }
		if(vecLine[14]!="SpeedZhucheng"){Ex.Logger.Log("Hero.csv中字段[SpeedZhucheng]位置不对应"); return false; }
		if(vecLine[15]!="Colour"){Ex.Logger.Log("Hero.csv中字段[Colour]位置不对应"); return false; }
		if(vecLine[16]!="Star"){Ex.Logger.Log("Hero.csv中字段[Star]位置不对应"); return false; }
		if(vecLine[17]!="Suipian"){Ex.Logger.Log("Hero.csv中字段[Suipian]位置不对应"); return false; }
		if(vecLine[18]!="Num"){Ex.Logger.Log("Hero.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[19]!="Skill"){Ex.Logger.Log("Hero.csv中字段[Skill]位置不对应"); return false; }
		if(vecLine[20]!="Skill1"){Ex.Logger.Log("Hero.csv中字段[Skill1]位置不对应"); return false; }
		if(vecLine[21]!="Skill2"){Ex.Logger.Log("Hero.csv中字段[Skill2]位置不对应"); return false; }
		if(vecLine[22]!="Skill3"){Ex.Logger.Log("Hero.csv中字段[Skill3]位置不对应"); return false; }
		if(vecLine[23]!="Skill4"){Ex.Logger.Log("Hero.csv中字段[Skill4]位置不对应"); return false; }
		if(vecLine[24]!="Skill5"){Ex.Logger.Log("Hero.csv中字段[Skill5]位置不对应"); return false; }
		if(vecLine[25]!="Skill6"){Ex.Logger.Log("Hero.csv中字段[Skill6]位置不对应"); return false; }
		if(vecLine[26]!="Skill7"){Ex.Logger.Log("Hero.csv中字段[Skill7]位置不对应"); return false; }
		if(vecLine[27]!="Skill8"){Ex.Logger.Log("Hero.csv中字段[Skill8]位置不对应"); return false; }
		if(vecLine[28]!="Skill9"){Ex.Logger.Log("Hero.csv中字段[Skill9]位置不对应"); return false; }
		if(vecLine[29]!="AllowMove"){Ex.Logger.Log("Hero.csv中字段[AllowMove]位置不对应"); return false; }
		if(vecLine[30]!="STA"){Ex.Logger.Log("Hero.csv中字段[STA]位置不对应"); return false; }
		if(vecLine[31]!="SPI"){Ex.Logger.Log("Hero.csv中字段[SPI]位置不对应"); return false; }
		if(vecLine[32]!="STR"){Ex.Logger.Log("Hero.csv中字段[STR]位置不对应"); return false; }
		if(vecLine[33]!="INT"){Ex.Logger.Log("Hero.csv中字段[INT]位置不对应"); return false; }
		if(vecLine[34]!="AGI"){Ex.Logger.Log("Hero.csv中字段[AGI]位置不对应"); return false; }
		if(vecLine[35]!="STALVUP"){Ex.Logger.Log("Hero.csv中字段[STALVUP]位置不对应"); return false; }
		if(vecLine[36]!="SPILVUP"){Ex.Logger.Log("Hero.csv中字段[SPILVUP]位置不对应"); return false; }
		if(vecLine[37]!="STRLVUP"){Ex.Logger.Log("Hero.csv中字段[STRLVUP]位置不对应"); return false; }
		if(vecLine[38]!="INTLVUP"){Ex.Logger.Log("Hero.csv中字段[INTLVUP]位置不对应"); return false; }
		if(vecLine[39]!="AGILVUP"){Ex.Logger.Log("Hero.csv中字段[AGILVUP]位置不对应"); return false; }
		if(vecLine[40]!="HP"){Ex.Logger.Log("Hero.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[41]!="reHP"){Ex.Logger.Log("Hero.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[42]!="MP"){Ex.Logger.Log("Hero.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[43]!="reMP"){Ex.Logger.Log("Hero.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[44]!="minPA"){Ex.Logger.Log("Hero.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[45]!="maxPA"){Ex.Logger.Log("Hero.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[46]!="minMA"){Ex.Logger.Log("Hero.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[47]!="maxMA"){Ex.Logger.Log("Hero.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[48]!="PD"){Ex.Logger.Log("Hero.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[49]!="MD"){Ex.Logger.Log("Hero.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[50]!="igPhi"){Ex.Logger.Log("Hero.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[51]!="igMdo"){Ex.Logger.Log("Hero.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[52]!="Pdo"){Ex.Logger.Log("Hero.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[53]!="Mdo"){Ex.Logger.Log("Hero.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[54]!="HitRate"){Ex.Logger.Log("Hero.csv中字段[HitRate]位置不对应"); return false; }
		if(vecLine[55]!="CritRate"){Ex.Logger.Log("Hero.csv中字段[CritRate]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			HeroElement member = new HeroElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Hero );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Sex );
			readPos += GameAssist.ReadString( binContent, readPos, out member.HeadID);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Zhu_HeadID);
			readPos += GameAssist.ReadString( binContent, readPos, out member.FB_HeadID);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Career_Icon);
			readPos += GameAssist.ReadString( binContent, readPos, out member.ZhiYeIcon);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XingJi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttType );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.HeroR);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.SpeedFuben);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.SpeedZhucheng);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Colour );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Star );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Suipian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Skill);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill7 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill8 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill9 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AllowMove );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.STA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SPI );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.STR );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.INT );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AGI );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.STALVUP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SPILVUP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.STRLVUP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.INTLVUP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AGILVUP );
			readPos += GameAssist.ReadString( binContent, readPos, out member.HP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.reHP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.reMP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.minPA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.maxPA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.minMA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.maxMA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.PD);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MD);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igPhi);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igMdo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Pdo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Mdo);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.HitRate);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.CritRate);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Hero] = member;
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
		if(vecLine.Count != 56)
		{
			Ex.Logger.Log("Hero.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Hero"){Ex.Logger.Log("Hero.csv中字段[Hero]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Hero.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="ModelID"){Ex.Logger.Log("Hero.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[3]!="Sex"){Ex.Logger.Log("Hero.csv中字段[Sex]位置不对应"); return false; }
		if(vecLine[4]!="HeadID"){Ex.Logger.Log("Hero.csv中字段[HeadID]位置不对应"); return false; }
		if(vecLine[5]!="Zhu_HeadID"){Ex.Logger.Log("Hero.csv中字段[Zhu_HeadID]位置不对应"); return false; }
		if(vecLine[6]!="FB_HeadID"){Ex.Logger.Log("Hero.csv中字段[FB_HeadID]位置不对应"); return false; }
		if(vecLine[7]!="Career_Icon"){Ex.Logger.Log("Hero.csv中字段[Career_Icon]位置不对应"); return false; }
		if(vecLine[8]!="ZhiYeIcon"){Ex.Logger.Log("Hero.csv中字段[ZhiYeIcon]位置不对应"); return false; }
		if(vecLine[9]!="XingJi"){Ex.Logger.Log("Hero.csv中字段[XingJi]位置不对应"); return false; }
		if(vecLine[10]!="AttType"){Ex.Logger.Log("Hero.csv中字段[AttType]位置不对应"); return false; }
		if(vecLine[11]!="HeroR"){Ex.Logger.Log("Hero.csv中字段[HeroR]位置不对应"); return false; }
		if(vecLine[12]!="Type"){Ex.Logger.Log("Hero.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[13]!="SpeedFuben"){Ex.Logger.Log("Hero.csv中字段[SpeedFuben]位置不对应"); return false; }
		if(vecLine[14]!="SpeedZhucheng"){Ex.Logger.Log("Hero.csv中字段[SpeedZhucheng]位置不对应"); return false; }
		if(vecLine[15]!="Colour"){Ex.Logger.Log("Hero.csv中字段[Colour]位置不对应"); return false; }
		if(vecLine[16]!="Star"){Ex.Logger.Log("Hero.csv中字段[Star]位置不对应"); return false; }
		if(vecLine[17]!="Suipian"){Ex.Logger.Log("Hero.csv中字段[Suipian]位置不对应"); return false; }
		if(vecLine[18]!="Num"){Ex.Logger.Log("Hero.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[19]!="Skill"){Ex.Logger.Log("Hero.csv中字段[Skill]位置不对应"); return false; }
		if(vecLine[20]!="Skill1"){Ex.Logger.Log("Hero.csv中字段[Skill1]位置不对应"); return false; }
		if(vecLine[21]!="Skill2"){Ex.Logger.Log("Hero.csv中字段[Skill2]位置不对应"); return false; }
		if(vecLine[22]!="Skill3"){Ex.Logger.Log("Hero.csv中字段[Skill3]位置不对应"); return false; }
		if(vecLine[23]!="Skill4"){Ex.Logger.Log("Hero.csv中字段[Skill4]位置不对应"); return false; }
		if(vecLine[24]!="Skill5"){Ex.Logger.Log("Hero.csv中字段[Skill5]位置不对应"); return false; }
		if(vecLine[25]!="Skill6"){Ex.Logger.Log("Hero.csv中字段[Skill6]位置不对应"); return false; }
		if(vecLine[26]!="Skill7"){Ex.Logger.Log("Hero.csv中字段[Skill7]位置不对应"); return false; }
		if(vecLine[27]!="Skill8"){Ex.Logger.Log("Hero.csv中字段[Skill8]位置不对应"); return false; }
		if(vecLine[28]!="Skill9"){Ex.Logger.Log("Hero.csv中字段[Skill9]位置不对应"); return false; }
		if(vecLine[29]!="AllowMove"){Ex.Logger.Log("Hero.csv中字段[AllowMove]位置不对应"); return false; }
		if(vecLine[30]!="STA"){Ex.Logger.Log("Hero.csv中字段[STA]位置不对应"); return false; }
		if(vecLine[31]!="SPI"){Ex.Logger.Log("Hero.csv中字段[SPI]位置不对应"); return false; }
		if(vecLine[32]!="STR"){Ex.Logger.Log("Hero.csv中字段[STR]位置不对应"); return false; }
		if(vecLine[33]!="INT"){Ex.Logger.Log("Hero.csv中字段[INT]位置不对应"); return false; }
		if(vecLine[34]!="AGI"){Ex.Logger.Log("Hero.csv中字段[AGI]位置不对应"); return false; }
		if(vecLine[35]!="STALVUP"){Ex.Logger.Log("Hero.csv中字段[STALVUP]位置不对应"); return false; }
		if(vecLine[36]!="SPILVUP"){Ex.Logger.Log("Hero.csv中字段[SPILVUP]位置不对应"); return false; }
		if(vecLine[37]!="STRLVUP"){Ex.Logger.Log("Hero.csv中字段[STRLVUP]位置不对应"); return false; }
		if(vecLine[38]!="INTLVUP"){Ex.Logger.Log("Hero.csv中字段[INTLVUP]位置不对应"); return false; }
		if(vecLine[39]!="AGILVUP"){Ex.Logger.Log("Hero.csv中字段[AGILVUP]位置不对应"); return false; }
		if(vecLine[40]!="HP"){Ex.Logger.Log("Hero.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[41]!="reHP"){Ex.Logger.Log("Hero.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[42]!="MP"){Ex.Logger.Log("Hero.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[43]!="reMP"){Ex.Logger.Log("Hero.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[44]!="minPA"){Ex.Logger.Log("Hero.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[45]!="maxPA"){Ex.Logger.Log("Hero.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[46]!="minMA"){Ex.Logger.Log("Hero.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[47]!="maxMA"){Ex.Logger.Log("Hero.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[48]!="PD"){Ex.Logger.Log("Hero.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[49]!="MD"){Ex.Logger.Log("Hero.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[50]!="igPhi"){Ex.Logger.Log("Hero.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[51]!="igMdo"){Ex.Logger.Log("Hero.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[52]!="Pdo"){Ex.Logger.Log("Hero.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[53]!="Mdo"){Ex.Logger.Log("Hero.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[54]!="HitRate"){Ex.Logger.Log("Hero.csv中字段[HitRate]位置不对应"); return false; }
		if(vecLine[55]!="CritRate"){Ex.Logger.Log("Hero.csv中字段[CritRate]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)56)
			{
				return false;
			}
			HeroElement member = new HeroElement();
			member.Hero=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.ModelID=Convert.ToInt32(vecLine[2]);
			member.Sex=Convert.ToInt32(vecLine[3]);
			member.HeadID=vecLine[4];
			member.Zhu_HeadID=vecLine[5];
			member.FB_HeadID=vecLine[6];
			member.Career_Icon=vecLine[7];
			member.ZhiYeIcon=vecLine[8];
			member.XingJi=Convert.ToInt32(vecLine[9]);
			member.AttType=Convert.ToInt32(vecLine[10]);
			member.HeroR=Convert.ToSingle(vecLine[11]);
			member.Type=Convert.ToInt32(vecLine[12]);
			member.SpeedFuben=Convert.ToSingle(vecLine[13]);
			member.SpeedZhucheng=Convert.ToSingle(vecLine[14]);
			member.Colour=Convert.ToInt32(vecLine[15]);
			member.Star=Convert.ToInt32(vecLine[16]);
			member.Suipian=Convert.ToInt32(vecLine[17]);
			member.Num=Convert.ToInt32(vecLine[18]);
			member.Skill=vecLine[19];
			member.Skill1=Convert.ToInt32(vecLine[20]);
			member.Skill2=Convert.ToInt32(vecLine[21]);
			member.Skill3=Convert.ToInt32(vecLine[22]);
			member.Skill4=Convert.ToInt32(vecLine[23]);
			member.Skill5=Convert.ToInt32(vecLine[24]);
			member.Skill6=Convert.ToInt32(vecLine[25]);
			member.Skill7=Convert.ToInt32(vecLine[26]);
			member.Skill8=Convert.ToInt32(vecLine[27]);
			member.Skill9=Convert.ToInt32(vecLine[28]);
			member.AllowMove=Convert.ToInt32(vecLine[29]);
			member.STA=Convert.ToInt32(vecLine[30]);
			member.SPI=Convert.ToInt32(vecLine[31]);
			member.STR=Convert.ToInt32(vecLine[32]);
			member.INT=Convert.ToInt32(vecLine[33]);
			member.AGI=Convert.ToInt32(vecLine[34]);
			member.STALVUP=Convert.ToInt32(vecLine[35]);
			member.SPILVUP=Convert.ToInt32(vecLine[36]);
			member.STRLVUP=Convert.ToInt32(vecLine[37]);
			member.INTLVUP=Convert.ToInt32(vecLine[38]);
			member.AGILVUP=Convert.ToInt32(vecLine[39]);
			member.HP=vecLine[40];
			member.reHP=vecLine[41];
			member.MP=vecLine[42];
			member.reMP=vecLine[43];
			member.minPA=vecLine[44];
			member.maxPA=vecLine[45];
			member.minMA=vecLine[46];
			member.maxMA=vecLine[47];
			member.PD=vecLine[48];
			member.MD=vecLine[49];
			member.igPhi=vecLine[50];
			member.igMdo=vecLine[51];
			member.Pdo=vecLine[52];
			member.Mdo=vecLine[53];
			member.HitRate=Convert.ToSingle(vecLine[54]);
			member.CritRate=Convert.ToSingle(vecLine[55]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Hero] = member;
		}
		return true;
	}
};
