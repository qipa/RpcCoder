using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//技能基础表配置数据类
public class SkillElement
{
	public int SkillID;          	//技能ID	编号
	public string Name;          	//技能名称	技能名称
	public string SourceIcon;    	//技能图标	技能图标
	public int Hero;             	//所属英雄	所属英雄
	public int Type;             	//技能类型	技能类型（1普攻、2技能、3瞄准、4绝技、5被动属性（只要激活就加属性） 6被动 ）
	public int SkillType;        	//施法类型	1 瞬发 2 吟唱 3引导 4蓄力
	public string FenDuan;       	//蓄力分段	蓄力分段
	public string XuLiStart;     	//蓄力开始动作	蓄力开始动作
	public string XuLiXunHuan;   	//蓄力循环动作	蓄力循环动作
	public string XuLiSkill;     	//蓄力技能	蓄力技能
	public int YinChangTime;     	//吟唱时间	吟唱时间
	public string YinChangSkill; 	//吟唱动作	吟唱动作
	public int YinDaoTime;       	//引导时间	引导时间
	public string YinDaoSkill;   	//引导动作	引导动作
	public int HitType;          	//技能伤害类型	1伤害2 恢复
	public string SkillMana;     	//技能耗蓝	技能对蓝的消耗（基础消耗+等级*等级消耗系数）
	public int CD;               	//技能CD	技能的CD时常，单位为s
	public float AttackRange;    	//技能攻击范围	技能攻击范围
	public int HitRange;         	//技能伤害范围	技能伤害范围
	public string Tips;          	//技能描述	技能描述
	public int Set;              	//所属界面位置	绝技101 技能201 被动301 进阶被动401 修炼501 生活601
	public int LVMAX;            	//最高等级	技能最高等级
	public int LvUp;             	//升级消耗参数	升级消耗参数
	public int LvUpMoney;        	//升级消耗金钱	升级消耗金钱
	public int Attributes;       	//技能属性	技能属性（1物理2魔法）
	public int Limit;            	//技能限制	技能限制
	public int UnderAttack;      	//受击状态	受击状态
	public string AblityID;      	//技能文件	索引角色动作
	public int FriendNum;        	//友方目标个数	友方目标个数
	public string FriendBuffID;  	//友方BuffID	索引BUFF表，格式为{段数:BuffId1,BuffId2...}{段数:BuffId1,BuffId2...}…
	public string BuffID;        	//敌方BuffID	索引BUFF表，格式为{段数:BuffId1,BuffId2...}{段数:BuffId1,BuffId2...}…
	public string BuffRate;      	//敌方Buff概率	敌方Buff触发概率，格式为{段数:BuffId1概率,BuffId2概率...}{段数:BuffId1概率,BuffId2概率...}…
	public string AttBuffEle;    	//buff对应攻方属性	对应属性编号，-1为无对应，格式为{段数:BuffId1属性,BuffId2属性...}{段数:BuffId1属性,BuffId2属性...}…
	public string DefBuffEle;    	//buff对应守方属性	对应属性编号，-1为无对应，，格式为{段数:BuffId1属性,BuffId2属性...}{段数:BuffId1属性,BuffId2属性...}…
	public string TrapID;        	//陷阱ID	索引陷阱表，格式为{段数:陷阱Id1,陷阱Id2...}{段数:陷阱Id1,陷阱Id2...}…
	public float HatredCoefficient;	//仇恨系数	技能所造成伤害的绝对值 * 仇恨系数 = 仇恨值
	public float SkillHatred;    	//技能仇恨	释放该技能造成的固定仇恨值
	public int DamageRuduce;     	//伤害衰减率	多目标的伤害衰减（造成伤害*（1-伤害衰减率）=实际伤害）
	public string DamageNum;     	//基础伤害	技能基础攻击力+(技能等级增加的攻击力*等级)
	public int AttSpcialEle;     	//元素伤害对应攻方属性	对应属性编号，-1为无对应，1701火，1702电，1703风,1704冰,1705毒,1706光,1707暗
	public int DefSpcialEle;     	//元素伤害对应守方属性	对应属性编号，-1为无对应，1701火，1702电，1703风,1704冰,1705毒,1706光,1707暗
	public string SpcialDamageNum;	//元素伤害数值	基础属性伤害值
	public int SkillDistance;    	//攻击距离	技能攻击距离
	public int TargetOpt;        	//选中需求	是否需要选中释放
	public int TargetNum;        	//伤害目标个数	技能可以造成伤害的最大目标数量
	public string ParameterType; 	//被动参数类型	被动技能调用的参数类型
	public string ParameterNum;  	//被动参数数额	被动技能参数类型对应的数额
	public int TargetGroup;      	//目标阵营	1友，2敌，3全部 4全体队员
	public string DamageAmend;   	//伤害修正	伤害参数修正，用于特殊技能参数
	public int IsFanXiang;       	//是否有反向位移	1 有 -1 没有
	public int IsYiDong;         	//是否可以操作移动	1可以 -1不可以
	public int HandleType;       	//特殊技能类型	1攻击到的单位内生命最大单位 2 生命最小单位 3攻击目标数量大于3 4 己方血量最少 5 职业为医生、法师 6 目标生命大于自身生命 7隐身单位 8 血量低于50% 9 战士重斩 11战士冲锋 12战士先祖召唤 14猎人鹰击长空 15法师烈焰吐息 16法师炎爆术 101致命链接 102捆绑 103血量低于百分比
	public int Special;          	//特殊ID	特殊ID
	public int TargetArea;       	//是否选择施法目标区域	1 有 -1 没有
	public int DaoDi;            	//落地后是否倒地	1是-1否
	public int HitBack;          	//击退方向类型	1面朝方向2扩散
	public int ZiDong;           	//是否可以自动释放	是否可以自动释放

	public bool IsValidate = false;
	public SkillElement()
	{
		SkillID = -1;
	}
};

//技能基础表配置封装类
public class SkillTable
{

	private SkillTable()
	{
		m_mapElements = new Dictionary<int, SkillElement>();
		m_emptyItem = new SkillElement();
		m_vecAllElements = new List<SkillElement>();
	}
	private Dictionary<int, SkillElement> m_mapElements = null;
	private List<SkillElement>	m_vecAllElements = null;
	private SkillElement m_emptyItem = null;
	private static SkillTable sInstance = null;

	public static SkillTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SkillTable();
			return sInstance;
		}
	}

	public SkillElement GetElement(int key)
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

  public List<SkillElement> GetAllElement(Predicate<SkillElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Skill.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Skill.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Skill.bin]未找到");
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
		if(vecLine.Count != 57)
		{
			Ex.Logger.Log("Skill.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="SkillID"){Ex.Logger.Log("Skill.csv中字段[SkillID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Skill.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="SourceIcon"){Ex.Logger.Log("Skill.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[3]!="Hero"){Ex.Logger.Log("Skill.csv中字段[Hero]位置不对应"); return false; }
		if(vecLine[4]!="Type"){Ex.Logger.Log("Skill.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[5]!="SkillType"){Ex.Logger.Log("Skill.csv中字段[SkillType]位置不对应"); return false; }
		if(vecLine[6]!="FenDuan"){Ex.Logger.Log("Skill.csv中字段[FenDuan]位置不对应"); return false; }
		if(vecLine[7]!="XuLiStart"){Ex.Logger.Log("Skill.csv中字段[XuLiStart]位置不对应"); return false; }
		if(vecLine[8]!="XuLiXunHuan"){Ex.Logger.Log("Skill.csv中字段[XuLiXunHuan]位置不对应"); return false; }
		if(vecLine[9]!="XuLiSkill"){Ex.Logger.Log("Skill.csv中字段[XuLiSkill]位置不对应"); return false; }
		if(vecLine[10]!="YinChangTime"){Ex.Logger.Log("Skill.csv中字段[YinChangTime]位置不对应"); return false; }
		if(vecLine[11]!="YinChangSkill"){Ex.Logger.Log("Skill.csv中字段[YinChangSkill]位置不对应"); return false; }
		if(vecLine[12]!="YinDaoTime"){Ex.Logger.Log("Skill.csv中字段[YinDaoTime]位置不对应"); return false; }
		if(vecLine[13]!="YinDaoSkill"){Ex.Logger.Log("Skill.csv中字段[YinDaoSkill]位置不对应"); return false; }
		if(vecLine[14]!="HitType"){Ex.Logger.Log("Skill.csv中字段[HitType]位置不对应"); return false; }
		if(vecLine[15]!="SkillMana"){Ex.Logger.Log("Skill.csv中字段[SkillMana]位置不对应"); return false; }
		if(vecLine[16]!="CD"){Ex.Logger.Log("Skill.csv中字段[CD]位置不对应"); return false; }
		if(vecLine[17]!="AttackRange"){Ex.Logger.Log("Skill.csv中字段[AttackRange]位置不对应"); return false; }
		if(vecLine[18]!="HitRange"){Ex.Logger.Log("Skill.csv中字段[HitRange]位置不对应"); return false; }
		if(vecLine[19]!="Tips"){Ex.Logger.Log("Skill.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[20]!="Set"){Ex.Logger.Log("Skill.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[21]!="LVMAX"){Ex.Logger.Log("Skill.csv中字段[LVMAX]位置不对应"); return false; }
		if(vecLine[22]!="LvUp"){Ex.Logger.Log("Skill.csv中字段[LvUp]位置不对应"); return false; }
		if(vecLine[23]!="LvUpMoney"){Ex.Logger.Log("Skill.csv中字段[LvUpMoney]位置不对应"); return false; }
		if(vecLine[24]!="Attributes"){Ex.Logger.Log("Skill.csv中字段[Attributes]位置不对应"); return false; }
		if(vecLine[25]!="Limit"){Ex.Logger.Log("Skill.csv中字段[Limit]位置不对应"); return false; }
		if(vecLine[26]!="UnderAttack"){Ex.Logger.Log("Skill.csv中字段[UnderAttack]位置不对应"); return false; }
		if(vecLine[27]!="AblityID"){Ex.Logger.Log("Skill.csv中字段[AblityID]位置不对应"); return false; }
		if(vecLine[28]!="FriendNum"){Ex.Logger.Log("Skill.csv中字段[FriendNum]位置不对应"); return false; }
		if(vecLine[29]!="FriendBuffID"){Ex.Logger.Log("Skill.csv中字段[FriendBuffID]位置不对应"); return false; }
		if(vecLine[30]!="BuffID"){Ex.Logger.Log("Skill.csv中字段[BuffID]位置不对应"); return false; }
		if(vecLine[31]!="BuffRate"){Ex.Logger.Log("Skill.csv中字段[BuffRate]位置不对应"); return false; }
		if(vecLine[32]!="AttBuffEle"){Ex.Logger.Log("Skill.csv中字段[AttBuffEle]位置不对应"); return false; }
		if(vecLine[33]!="DefBuffEle"){Ex.Logger.Log("Skill.csv中字段[DefBuffEle]位置不对应"); return false; }
		if(vecLine[34]!="TrapID"){Ex.Logger.Log("Skill.csv中字段[TrapID]位置不对应"); return false; }
		if(vecLine[35]!="HatredCoefficient"){Ex.Logger.Log("Skill.csv中字段[HatredCoefficient]位置不对应"); return false; }
		if(vecLine[36]!="SkillHatred"){Ex.Logger.Log("Skill.csv中字段[SkillHatred]位置不对应"); return false; }
		if(vecLine[37]!="DamageRuduce"){Ex.Logger.Log("Skill.csv中字段[DamageRuduce]位置不对应"); return false; }
		if(vecLine[38]!="DamageNum"){Ex.Logger.Log("Skill.csv中字段[DamageNum]位置不对应"); return false; }
		if(vecLine[39]!="AttSpcialEle"){Ex.Logger.Log("Skill.csv中字段[AttSpcialEle]位置不对应"); return false; }
		if(vecLine[40]!="DefSpcialEle"){Ex.Logger.Log("Skill.csv中字段[DefSpcialEle]位置不对应"); return false; }
		if(vecLine[41]!="SpcialDamageNum"){Ex.Logger.Log("Skill.csv中字段[SpcialDamageNum]位置不对应"); return false; }
		if(vecLine[42]!="SkillDistance"){Ex.Logger.Log("Skill.csv中字段[SkillDistance]位置不对应"); return false; }
		if(vecLine[43]!="TargetOpt"){Ex.Logger.Log("Skill.csv中字段[TargetOpt]位置不对应"); return false; }
		if(vecLine[44]!="TargetNum"){Ex.Logger.Log("Skill.csv中字段[TargetNum]位置不对应"); return false; }
		if(vecLine[45]!="ParameterType"){Ex.Logger.Log("Skill.csv中字段[ParameterType]位置不对应"); return false; }
		if(vecLine[46]!="ParameterNum"){Ex.Logger.Log("Skill.csv中字段[ParameterNum]位置不对应"); return false; }
		if(vecLine[47]!="TargetGroup"){Ex.Logger.Log("Skill.csv中字段[TargetGroup]位置不对应"); return false; }
		if(vecLine[48]!="DamageAmend"){Ex.Logger.Log("Skill.csv中字段[DamageAmend]位置不对应"); return false; }
		if(vecLine[49]!="IsFanXiang"){Ex.Logger.Log("Skill.csv中字段[IsFanXiang]位置不对应"); return false; }
		if(vecLine[50]!="IsYiDong"){Ex.Logger.Log("Skill.csv中字段[IsYiDong]位置不对应"); return false; }
		if(vecLine[51]!="HandleType"){Ex.Logger.Log("Skill.csv中字段[HandleType]位置不对应"); return false; }
		if(vecLine[52]!="Special"){Ex.Logger.Log("Skill.csv中字段[Special]位置不对应"); return false; }
		if(vecLine[53]!="TargetArea"){Ex.Logger.Log("Skill.csv中字段[TargetArea]位置不对应"); return false; }
		if(vecLine[54]!="DaoDi"){Ex.Logger.Log("Skill.csv中字段[DaoDi]位置不对应"); return false; }
		if(vecLine[55]!="HitBack"){Ex.Logger.Log("Skill.csv中字段[HitBack]位置不对应"); return false; }
		if(vecLine[56]!="ZiDong"){Ex.Logger.Log("Skill.csv中字段[ZiDong]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SkillElement member = new SkillElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SourceIcon);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Hero );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.FenDuan);
			readPos += GameAssist.ReadString( binContent, readPos, out member.XuLiStart);
			readPos += GameAssist.ReadString( binContent, readPos, out member.XuLiXunHuan);
			readPos += GameAssist.ReadString( binContent, readPos, out member.XuLiSkill);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.YinChangTime );
			readPos += GameAssist.ReadString( binContent, readPos, out member.YinChangSkill);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.YinDaoTime );
			readPos += GameAssist.ReadString( binContent, readPos, out member.YinDaoSkill);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SkillMana);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CD );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.AttackRange);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitRange );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Tips);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Set );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LVMAX );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvUp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LvUpMoney );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attributes );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Limit );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.UnderAttack );
			readPos += GameAssist.ReadString( binContent, readPos, out member.AblityID);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FriendNum );
			readPos += GameAssist.ReadString( binContent, readPos, out member.FriendBuffID);
			readPos += GameAssist.ReadString( binContent, readPos, out member.BuffID);
			readPos += GameAssist.ReadString( binContent, readPos, out member.BuffRate);
			readPos += GameAssist.ReadString( binContent, readPos, out member.AttBuffEle);
			readPos += GameAssist.ReadString( binContent, readPos, out member.DefBuffEle);
			readPos += GameAssist.ReadString( binContent, readPos, out member.TrapID);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.HatredCoefficient);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.SkillHatred);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DamageRuduce );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DamageNum);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttSpcialEle );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DefSpcialEle );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SpcialDamageNum);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillDistance );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TargetOpt );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TargetNum );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ParameterType);
			readPos += GameAssist.ReadString( binContent, readPos, out member.ParameterNum);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TargetGroup );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DamageAmend);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsFanXiang );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsYiDong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HandleType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Special );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TargetArea );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DaoDi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitBack );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ZiDong );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.SkillID] = member;
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
		if(vecLine.Count != 57)
		{
			Ex.Logger.Log("Skill.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="SkillID"){Ex.Logger.Log("Skill.csv中字段[SkillID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Skill.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="SourceIcon"){Ex.Logger.Log("Skill.csv中字段[SourceIcon]位置不对应"); return false; }
		if(vecLine[3]!="Hero"){Ex.Logger.Log("Skill.csv中字段[Hero]位置不对应"); return false; }
		if(vecLine[4]!="Type"){Ex.Logger.Log("Skill.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[5]!="SkillType"){Ex.Logger.Log("Skill.csv中字段[SkillType]位置不对应"); return false; }
		if(vecLine[6]!="FenDuan"){Ex.Logger.Log("Skill.csv中字段[FenDuan]位置不对应"); return false; }
		if(vecLine[7]!="XuLiStart"){Ex.Logger.Log("Skill.csv中字段[XuLiStart]位置不对应"); return false; }
		if(vecLine[8]!="XuLiXunHuan"){Ex.Logger.Log("Skill.csv中字段[XuLiXunHuan]位置不对应"); return false; }
		if(vecLine[9]!="XuLiSkill"){Ex.Logger.Log("Skill.csv中字段[XuLiSkill]位置不对应"); return false; }
		if(vecLine[10]!="YinChangTime"){Ex.Logger.Log("Skill.csv中字段[YinChangTime]位置不对应"); return false; }
		if(vecLine[11]!="YinChangSkill"){Ex.Logger.Log("Skill.csv中字段[YinChangSkill]位置不对应"); return false; }
		if(vecLine[12]!="YinDaoTime"){Ex.Logger.Log("Skill.csv中字段[YinDaoTime]位置不对应"); return false; }
		if(vecLine[13]!="YinDaoSkill"){Ex.Logger.Log("Skill.csv中字段[YinDaoSkill]位置不对应"); return false; }
		if(vecLine[14]!="HitType"){Ex.Logger.Log("Skill.csv中字段[HitType]位置不对应"); return false; }
		if(vecLine[15]!="SkillMana"){Ex.Logger.Log("Skill.csv中字段[SkillMana]位置不对应"); return false; }
		if(vecLine[16]!="CD"){Ex.Logger.Log("Skill.csv中字段[CD]位置不对应"); return false; }
		if(vecLine[17]!="AttackRange"){Ex.Logger.Log("Skill.csv中字段[AttackRange]位置不对应"); return false; }
		if(vecLine[18]!="HitRange"){Ex.Logger.Log("Skill.csv中字段[HitRange]位置不对应"); return false; }
		if(vecLine[19]!="Tips"){Ex.Logger.Log("Skill.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[20]!="Set"){Ex.Logger.Log("Skill.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[21]!="LVMAX"){Ex.Logger.Log("Skill.csv中字段[LVMAX]位置不对应"); return false; }
		if(vecLine[22]!="LvUp"){Ex.Logger.Log("Skill.csv中字段[LvUp]位置不对应"); return false; }
		if(vecLine[23]!="LvUpMoney"){Ex.Logger.Log("Skill.csv中字段[LvUpMoney]位置不对应"); return false; }
		if(vecLine[24]!="Attributes"){Ex.Logger.Log("Skill.csv中字段[Attributes]位置不对应"); return false; }
		if(vecLine[25]!="Limit"){Ex.Logger.Log("Skill.csv中字段[Limit]位置不对应"); return false; }
		if(vecLine[26]!="UnderAttack"){Ex.Logger.Log("Skill.csv中字段[UnderAttack]位置不对应"); return false; }
		if(vecLine[27]!="AblityID"){Ex.Logger.Log("Skill.csv中字段[AblityID]位置不对应"); return false; }
		if(vecLine[28]!="FriendNum"){Ex.Logger.Log("Skill.csv中字段[FriendNum]位置不对应"); return false; }
		if(vecLine[29]!="FriendBuffID"){Ex.Logger.Log("Skill.csv中字段[FriendBuffID]位置不对应"); return false; }
		if(vecLine[30]!="BuffID"){Ex.Logger.Log("Skill.csv中字段[BuffID]位置不对应"); return false; }
		if(vecLine[31]!="BuffRate"){Ex.Logger.Log("Skill.csv中字段[BuffRate]位置不对应"); return false; }
		if(vecLine[32]!="AttBuffEle"){Ex.Logger.Log("Skill.csv中字段[AttBuffEle]位置不对应"); return false; }
		if(vecLine[33]!="DefBuffEle"){Ex.Logger.Log("Skill.csv中字段[DefBuffEle]位置不对应"); return false; }
		if(vecLine[34]!="TrapID"){Ex.Logger.Log("Skill.csv中字段[TrapID]位置不对应"); return false; }
		if(vecLine[35]!="HatredCoefficient"){Ex.Logger.Log("Skill.csv中字段[HatredCoefficient]位置不对应"); return false; }
		if(vecLine[36]!="SkillHatred"){Ex.Logger.Log("Skill.csv中字段[SkillHatred]位置不对应"); return false; }
		if(vecLine[37]!="DamageRuduce"){Ex.Logger.Log("Skill.csv中字段[DamageRuduce]位置不对应"); return false; }
		if(vecLine[38]!="DamageNum"){Ex.Logger.Log("Skill.csv中字段[DamageNum]位置不对应"); return false; }
		if(vecLine[39]!="AttSpcialEle"){Ex.Logger.Log("Skill.csv中字段[AttSpcialEle]位置不对应"); return false; }
		if(vecLine[40]!="DefSpcialEle"){Ex.Logger.Log("Skill.csv中字段[DefSpcialEle]位置不对应"); return false; }
		if(vecLine[41]!="SpcialDamageNum"){Ex.Logger.Log("Skill.csv中字段[SpcialDamageNum]位置不对应"); return false; }
		if(vecLine[42]!="SkillDistance"){Ex.Logger.Log("Skill.csv中字段[SkillDistance]位置不对应"); return false; }
		if(vecLine[43]!="TargetOpt"){Ex.Logger.Log("Skill.csv中字段[TargetOpt]位置不对应"); return false; }
		if(vecLine[44]!="TargetNum"){Ex.Logger.Log("Skill.csv中字段[TargetNum]位置不对应"); return false; }
		if(vecLine[45]!="ParameterType"){Ex.Logger.Log("Skill.csv中字段[ParameterType]位置不对应"); return false; }
		if(vecLine[46]!="ParameterNum"){Ex.Logger.Log("Skill.csv中字段[ParameterNum]位置不对应"); return false; }
		if(vecLine[47]!="TargetGroup"){Ex.Logger.Log("Skill.csv中字段[TargetGroup]位置不对应"); return false; }
		if(vecLine[48]!="DamageAmend"){Ex.Logger.Log("Skill.csv中字段[DamageAmend]位置不对应"); return false; }
		if(vecLine[49]!="IsFanXiang"){Ex.Logger.Log("Skill.csv中字段[IsFanXiang]位置不对应"); return false; }
		if(vecLine[50]!="IsYiDong"){Ex.Logger.Log("Skill.csv中字段[IsYiDong]位置不对应"); return false; }
		if(vecLine[51]!="HandleType"){Ex.Logger.Log("Skill.csv中字段[HandleType]位置不对应"); return false; }
		if(vecLine[52]!="Special"){Ex.Logger.Log("Skill.csv中字段[Special]位置不对应"); return false; }
		if(vecLine[53]!="TargetArea"){Ex.Logger.Log("Skill.csv中字段[TargetArea]位置不对应"); return false; }
		if(vecLine[54]!="DaoDi"){Ex.Logger.Log("Skill.csv中字段[DaoDi]位置不对应"); return false; }
		if(vecLine[55]!="HitBack"){Ex.Logger.Log("Skill.csv中字段[HitBack]位置不对应"); return false; }
		if(vecLine[56]!="ZiDong"){Ex.Logger.Log("Skill.csv中字段[ZiDong]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)57)
			{
				return false;
			}
			SkillElement member = new SkillElement();
			member.SkillID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.SourceIcon=vecLine[2];
			member.Hero=Convert.ToInt32(vecLine[3]);
			member.Type=Convert.ToInt32(vecLine[4]);
			member.SkillType=Convert.ToInt32(vecLine[5]);
			member.FenDuan=vecLine[6];
			member.XuLiStart=vecLine[7];
			member.XuLiXunHuan=vecLine[8];
			member.XuLiSkill=vecLine[9];
			member.YinChangTime=Convert.ToInt32(vecLine[10]);
			member.YinChangSkill=vecLine[11];
			member.YinDaoTime=Convert.ToInt32(vecLine[12]);
			member.YinDaoSkill=vecLine[13];
			member.HitType=Convert.ToInt32(vecLine[14]);
			member.SkillMana=vecLine[15];
			member.CD=Convert.ToInt32(vecLine[16]);
			member.AttackRange=Convert.ToSingle(vecLine[17]);
			member.HitRange=Convert.ToInt32(vecLine[18]);
			member.Tips=vecLine[19];
			member.Set=Convert.ToInt32(vecLine[20]);
			member.LVMAX=Convert.ToInt32(vecLine[21]);
			member.LvUp=Convert.ToInt32(vecLine[22]);
			member.LvUpMoney=Convert.ToInt32(vecLine[23]);
			member.Attributes=Convert.ToInt32(vecLine[24]);
			member.Limit=Convert.ToInt32(vecLine[25]);
			member.UnderAttack=Convert.ToInt32(vecLine[26]);
			member.AblityID=vecLine[27];
			member.FriendNum=Convert.ToInt32(vecLine[28]);
			member.FriendBuffID=vecLine[29];
			member.BuffID=vecLine[30];
			member.BuffRate=vecLine[31];
			member.AttBuffEle=vecLine[32];
			member.DefBuffEle=vecLine[33];
			member.TrapID=vecLine[34];
			member.HatredCoefficient=Convert.ToSingle(vecLine[35]);
			member.SkillHatred=Convert.ToSingle(vecLine[36]);
			member.DamageRuduce=Convert.ToInt32(vecLine[37]);
			member.DamageNum=vecLine[38];
			member.AttSpcialEle=Convert.ToInt32(vecLine[39]);
			member.DefSpcialEle=Convert.ToInt32(vecLine[40]);
			member.SpcialDamageNum=vecLine[41];
			member.SkillDistance=Convert.ToInt32(vecLine[42]);
			member.TargetOpt=Convert.ToInt32(vecLine[43]);
			member.TargetNum=Convert.ToInt32(vecLine[44]);
			member.ParameterType=vecLine[45];
			member.ParameterNum=vecLine[46];
			member.TargetGroup=Convert.ToInt32(vecLine[47]);
			member.DamageAmend=vecLine[48];
			member.IsFanXiang=Convert.ToInt32(vecLine[49]);
			member.IsYiDong=Convert.ToInt32(vecLine[50]);
			member.HandleType=Convert.ToInt32(vecLine[51]);
			member.Special=Convert.ToInt32(vecLine[52]);
			member.TargetArea=Convert.ToInt32(vecLine[53]);
			member.DaoDi=Convert.ToInt32(vecLine[54]);
			member.HitBack=Convert.ToInt32(vecLine[55]);
			member.ZiDong=Convert.ToInt32(vecLine[56]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.SkillID] = member;
		}
		return true;
	}
};
