using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//技能效果表配置数据类
public class BuffElement
{
	public int BuffID;           	//BuffID	编号
	public string Name;          	//名字	BUFF的名字，主要策划识别用
	public string Describe;      	//描述	BUFF描述
	public int IconShow;         	//是否显示ICON	1显示2不显示
	public string IconName;      	//Icon	Icon路径配置
	public int EffectType;       	//BUFF效果类型	1增益，2减益
	public int DieEfficient;     	//死亡是否存续	Buff在角色死亡后能否继续存在（1是0否）
	public int TriggerPos;       	//触发位置	状态触发时播放特效的位置
	public string TriggerEffects;	//触发特效	状态触发时播放的特效
	public int SustainPos;       	//持续位置	状态持续时播放特效的位置1.原点2.头3.胸
	public string SustainEffects;	//持续特效	状态持续时播放的特效
	public int MaterialType;     	//特效材质	特效材质变化
	public string AblityID;      	//动作文件	动作的索引目录
	public int Type;             	//BUFF类	定义的类别（同类覆盖，不同共存）
	public int Priority;         	//优先级	同类的BUFF按照优先级覆盖，数字越大优先级越高，高能覆盖低，低不能覆盖高，同优先级的后一个BUFF覆盖前一个BUFF，-1为最低优先级
	public string ImmuneType;    	//抵抗的类	免疫该类的BUFF,可多项，逗号隔开
	public int Duration;         	//持续时间	BUFF的持续时间，-100为当前段，-200为当前技能时长
	public int Interval;         	//作用间隔	BUFF的作用间隔
	public int Steer;            	//摇杆操作效果	1相反，-1正常，0无效
	public int Target;           	//技能伤害目标	1敌，2友，3全,-1无效
	public int UseSkill;         	//能否释放技能	不能进行任何攻击为1，不能进行技能释放为0，不限制为-1
	public string Attribute1Type;	//属性1类型 1000以下是特殊BUFF功能，1000以上是角色属性	增加的属性类型 1 附加伤害 2 添加BUFF 3 由普攻触发加伤害 4 由普攻触发加BUFF 5 加百分比生命给攻击者 6 光属性或恢复技能增强百分比 7 受到的部分伤害转化为生命 8 目标生命值大于自身当前生命，则立刻治疗自己，治疗效果为本次伤害的百分比 9 使用技能 10吸血 101 致命链接
	public string Attribute1Value;	//属性1参数	增加的属性具体数值
	public int GoBack1;          	//是否撤回	1撤回，-1不撤回
	public string Attribute2Type;	//属性2类型	增加的属性类型
	public string Attribute2Value;	//属性2参数	增加的属性具体数值
	public int GoBack2;          	//是否撤回	1撤回，-1不撤回
	public string Attribute3Type;	//属性3类型	增加的属性类型
	public string Attribute3Value;	//属性3参数	增加的属性具体数值
	public int GoBack3;          	//是否撤回	1撤回，-1不撤回
	public string Attribute4Type;	//属性4类型	增加的属性类型
	public string Attribute4Value;	//属性4参数	增加的属性具体数值
	public int GoBack4;          	//是否撤回	1撤回，-1不撤回
	public int MarkType;         	//标记类型	1破甲2死亡3隐身4无敌5霸体6引燃7禁食8护甲转移攻击9无法打断吟唱技能10自动复活11忽略MISS计算
	public int SpecialTrigger;   	//BUFF触发结束条件	1能量盾，2次数盾，3受击次数触发，4下一击附加行为，5死亡触发，6结束触发技能
	public string DispelType;    	//驱散的类	调用Type字段

	public bool IsValidate = false;
	public BuffElement()
	{
		BuffID = -1;
	}
};

//技能效果表配置封装类
public class BuffTable
{

	private BuffTable()
	{
		m_mapElements = new Dictionary<int, BuffElement>();
		m_emptyItem = new BuffElement();
		m_vecAllElements = new List<BuffElement>();
	}
	private Dictionary<int, BuffElement> m_mapElements = null;
	private List<BuffElement>	m_vecAllElements = null;
	private BuffElement m_emptyItem = null;
	private static BuffTable sInstance = null;

	public static BuffTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BuffTable();
			return sInstance;
		}
	}

	public BuffElement GetElement(int key)
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

  public List<BuffElement> GetAllElement(Predicate<BuffElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Buff.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Buff.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Buff.bin]未找到");
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
			Ex.Logger.Log("Buff.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="BuffID"){Ex.Logger.Log("Buff.csv中字段[BuffID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Buff.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Describe"){Ex.Logger.Log("Buff.csv中字段[Describe]位置不对应"); return false; }
		if(vecLine[3]!="IconShow"){Ex.Logger.Log("Buff.csv中字段[IconShow]位置不对应"); return false; }
		if(vecLine[4]!="IconName"){Ex.Logger.Log("Buff.csv中字段[IconName]位置不对应"); return false; }
		if(vecLine[5]!="EffectType"){Ex.Logger.Log("Buff.csv中字段[EffectType]位置不对应"); return false; }
		if(vecLine[6]!="DieEfficient"){Ex.Logger.Log("Buff.csv中字段[DieEfficient]位置不对应"); return false; }
		if(vecLine[7]!="TriggerPos"){Ex.Logger.Log("Buff.csv中字段[TriggerPos]位置不对应"); return false; }
		if(vecLine[8]!="TriggerEffects"){Ex.Logger.Log("Buff.csv中字段[TriggerEffects]位置不对应"); return false; }
		if(vecLine[9]!="SustainPos"){Ex.Logger.Log("Buff.csv中字段[SustainPos]位置不对应"); return false; }
		if(vecLine[10]!="SustainEffects"){Ex.Logger.Log("Buff.csv中字段[SustainEffects]位置不对应"); return false; }
		if(vecLine[11]!="MaterialType"){Ex.Logger.Log("Buff.csv中字段[MaterialType]位置不对应"); return false; }
		if(vecLine[12]!="AblityID"){Ex.Logger.Log("Buff.csv中字段[AblityID]位置不对应"); return false; }
		if(vecLine[13]!="Type"){Ex.Logger.Log("Buff.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[14]!="Priority"){Ex.Logger.Log("Buff.csv中字段[Priority]位置不对应"); return false; }
		if(vecLine[15]!="ImmuneType"){Ex.Logger.Log("Buff.csv中字段[ImmuneType]位置不对应"); return false; }
		if(vecLine[16]!="Duration"){Ex.Logger.Log("Buff.csv中字段[Duration]位置不对应"); return false; }
		if(vecLine[17]!="Interval"){Ex.Logger.Log("Buff.csv中字段[Interval]位置不对应"); return false; }
		if(vecLine[18]!="Steer"){Ex.Logger.Log("Buff.csv中字段[Steer]位置不对应"); return false; }
		if(vecLine[19]!="Target"){Ex.Logger.Log("Buff.csv中字段[Target]位置不对应"); return false; }
		if(vecLine[20]!="UseSkill"){Ex.Logger.Log("Buff.csv中字段[UseSkill]位置不对应"); return false; }
		if(vecLine[21]!="Attribute1Type"){Ex.Logger.Log("Buff.csv中字段[Attribute1Type]位置不对应"); return false; }
		if(vecLine[22]!="Attribute1Value"){Ex.Logger.Log("Buff.csv中字段[Attribute1Value]位置不对应"); return false; }
		if(vecLine[23]!="GoBack1"){Ex.Logger.Log("Buff.csv中字段[GoBack1]位置不对应"); return false; }
		if(vecLine[24]!="Attribute2Type"){Ex.Logger.Log("Buff.csv中字段[Attribute2Type]位置不对应"); return false; }
		if(vecLine[25]!="Attribute2Value"){Ex.Logger.Log("Buff.csv中字段[Attribute2Value]位置不对应"); return false; }
		if(vecLine[26]!="GoBack2"){Ex.Logger.Log("Buff.csv中字段[GoBack2]位置不对应"); return false; }
		if(vecLine[27]!="Attribute3Type"){Ex.Logger.Log("Buff.csv中字段[Attribute3Type]位置不对应"); return false; }
		if(vecLine[28]!="Attribute3Value"){Ex.Logger.Log("Buff.csv中字段[Attribute3Value]位置不对应"); return false; }
		if(vecLine[29]!="GoBack3"){Ex.Logger.Log("Buff.csv中字段[GoBack3]位置不对应"); return false; }
		if(vecLine[30]!="Attribute4Type"){Ex.Logger.Log("Buff.csv中字段[Attribute4Type]位置不对应"); return false; }
		if(vecLine[31]!="Attribute4Value"){Ex.Logger.Log("Buff.csv中字段[Attribute4Value]位置不对应"); return false; }
		if(vecLine[32]!="GoBack4"){Ex.Logger.Log("Buff.csv中字段[GoBack4]位置不对应"); return false; }
		if(vecLine[33]!="MarkType"){Ex.Logger.Log("Buff.csv中字段[MarkType]位置不对应"); return false; }
		if(vecLine[34]!="SpecialTrigger"){Ex.Logger.Log("Buff.csv中字段[SpecialTrigger]位置不对应"); return false; }
		if(vecLine[35]!="DispelType"){Ex.Logger.Log("Buff.csv中字段[DispelType]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BuffElement member = new BuffElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BuffID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Describe);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IconShow );
			readPos += GameAssist.ReadString( binContent, readPos, out member.IconName);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EffectType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DieEfficient );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TriggerPos );
			readPos += GameAssist.ReadString( binContent, readPos, out member.TriggerEffects);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SustainPos );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SustainEffects);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MaterialType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.AblityID);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Priority );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ImmuneType);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Duration );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Interval );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Steer );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Target );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.UseSkill );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute1Type);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute1Value);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GoBack1 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute2Type);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute2Value);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GoBack2 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute3Type);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute3Value);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GoBack3 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute4Type);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute4Value);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GoBack4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MarkType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SpecialTrigger );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DispelType);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.BuffID] = member;
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
			Ex.Logger.Log("Buff.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="BuffID"){Ex.Logger.Log("Buff.csv中字段[BuffID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Buff.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Describe"){Ex.Logger.Log("Buff.csv中字段[Describe]位置不对应"); return false; }
		if(vecLine[3]!="IconShow"){Ex.Logger.Log("Buff.csv中字段[IconShow]位置不对应"); return false; }
		if(vecLine[4]!="IconName"){Ex.Logger.Log("Buff.csv中字段[IconName]位置不对应"); return false; }
		if(vecLine[5]!="EffectType"){Ex.Logger.Log("Buff.csv中字段[EffectType]位置不对应"); return false; }
		if(vecLine[6]!="DieEfficient"){Ex.Logger.Log("Buff.csv中字段[DieEfficient]位置不对应"); return false; }
		if(vecLine[7]!="TriggerPos"){Ex.Logger.Log("Buff.csv中字段[TriggerPos]位置不对应"); return false; }
		if(vecLine[8]!="TriggerEffects"){Ex.Logger.Log("Buff.csv中字段[TriggerEffects]位置不对应"); return false; }
		if(vecLine[9]!="SustainPos"){Ex.Logger.Log("Buff.csv中字段[SustainPos]位置不对应"); return false; }
		if(vecLine[10]!="SustainEffects"){Ex.Logger.Log("Buff.csv中字段[SustainEffects]位置不对应"); return false; }
		if(vecLine[11]!="MaterialType"){Ex.Logger.Log("Buff.csv中字段[MaterialType]位置不对应"); return false; }
		if(vecLine[12]!="AblityID"){Ex.Logger.Log("Buff.csv中字段[AblityID]位置不对应"); return false; }
		if(vecLine[13]!="Type"){Ex.Logger.Log("Buff.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[14]!="Priority"){Ex.Logger.Log("Buff.csv中字段[Priority]位置不对应"); return false; }
		if(vecLine[15]!="ImmuneType"){Ex.Logger.Log("Buff.csv中字段[ImmuneType]位置不对应"); return false; }
		if(vecLine[16]!="Duration"){Ex.Logger.Log("Buff.csv中字段[Duration]位置不对应"); return false; }
		if(vecLine[17]!="Interval"){Ex.Logger.Log("Buff.csv中字段[Interval]位置不对应"); return false; }
		if(vecLine[18]!="Steer"){Ex.Logger.Log("Buff.csv中字段[Steer]位置不对应"); return false; }
		if(vecLine[19]!="Target"){Ex.Logger.Log("Buff.csv中字段[Target]位置不对应"); return false; }
		if(vecLine[20]!="UseSkill"){Ex.Logger.Log("Buff.csv中字段[UseSkill]位置不对应"); return false; }
		if(vecLine[21]!="Attribute1Type"){Ex.Logger.Log("Buff.csv中字段[Attribute1Type]位置不对应"); return false; }
		if(vecLine[22]!="Attribute1Value"){Ex.Logger.Log("Buff.csv中字段[Attribute1Value]位置不对应"); return false; }
		if(vecLine[23]!="GoBack1"){Ex.Logger.Log("Buff.csv中字段[GoBack1]位置不对应"); return false; }
		if(vecLine[24]!="Attribute2Type"){Ex.Logger.Log("Buff.csv中字段[Attribute2Type]位置不对应"); return false; }
		if(vecLine[25]!="Attribute2Value"){Ex.Logger.Log("Buff.csv中字段[Attribute2Value]位置不对应"); return false; }
		if(vecLine[26]!="GoBack2"){Ex.Logger.Log("Buff.csv中字段[GoBack2]位置不对应"); return false; }
		if(vecLine[27]!="Attribute3Type"){Ex.Logger.Log("Buff.csv中字段[Attribute3Type]位置不对应"); return false; }
		if(vecLine[28]!="Attribute3Value"){Ex.Logger.Log("Buff.csv中字段[Attribute3Value]位置不对应"); return false; }
		if(vecLine[29]!="GoBack3"){Ex.Logger.Log("Buff.csv中字段[GoBack3]位置不对应"); return false; }
		if(vecLine[30]!="Attribute4Type"){Ex.Logger.Log("Buff.csv中字段[Attribute4Type]位置不对应"); return false; }
		if(vecLine[31]!="Attribute4Value"){Ex.Logger.Log("Buff.csv中字段[Attribute4Value]位置不对应"); return false; }
		if(vecLine[32]!="GoBack4"){Ex.Logger.Log("Buff.csv中字段[GoBack4]位置不对应"); return false; }
		if(vecLine[33]!="MarkType"){Ex.Logger.Log("Buff.csv中字段[MarkType]位置不对应"); return false; }
		if(vecLine[34]!="SpecialTrigger"){Ex.Logger.Log("Buff.csv中字段[SpecialTrigger]位置不对应"); return false; }
		if(vecLine[35]!="DispelType"){Ex.Logger.Log("Buff.csv中字段[DispelType]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)36)
			{
				return false;
			}
			BuffElement member = new BuffElement();
			member.BuffID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Describe=vecLine[2];
			member.IconShow=Convert.ToInt32(vecLine[3]);
			member.IconName=vecLine[4];
			member.EffectType=Convert.ToInt32(vecLine[5]);
			member.DieEfficient=Convert.ToInt32(vecLine[6]);
			member.TriggerPos=Convert.ToInt32(vecLine[7]);
			member.TriggerEffects=vecLine[8];
			member.SustainPos=Convert.ToInt32(vecLine[9]);
			member.SustainEffects=vecLine[10];
			member.MaterialType=Convert.ToInt32(vecLine[11]);
			member.AblityID=vecLine[12];
			member.Type=Convert.ToInt32(vecLine[13]);
			member.Priority=Convert.ToInt32(vecLine[14]);
			member.ImmuneType=vecLine[15];
			member.Duration=Convert.ToInt32(vecLine[16]);
			member.Interval=Convert.ToInt32(vecLine[17]);
			member.Steer=Convert.ToInt32(vecLine[18]);
			member.Target=Convert.ToInt32(vecLine[19]);
			member.UseSkill=Convert.ToInt32(vecLine[20]);
			member.Attribute1Type=vecLine[21];
			member.Attribute1Value=vecLine[22];
			member.GoBack1=Convert.ToInt32(vecLine[23]);
			member.Attribute2Type=vecLine[24];
			member.Attribute2Value=vecLine[25];
			member.GoBack2=Convert.ToInt32(vecLine[26]);
			member.Attribute3Type=vecLine[27];
			member.Attribute3Value=vecLine[28];
			member.GoBack3=Convert.ToInt32(vecLine[29]);
			member.Attribute4Type=vecLine[30];
			member.Attribute4Value=vecLine[31];
			member.GoBack4=Convert.ToInt32(vecLine[32]);
			member.MarkType=Convert.ToInt32(vecLine[33]);
			member.SpecialTrigger=Convert.ToInt32(vecLine[34]);
			member.DispelType=vecLine[35];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.BuffID] = member;
		}
		return true;
	}
};
