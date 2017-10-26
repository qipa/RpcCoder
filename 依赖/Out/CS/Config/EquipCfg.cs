using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//装备配置数据类
public class EquipElement
{
	public int EquipID;          	//编号	装备ID
	public int Type;             	//类型	装备类型（1武器2衣服3头盔4腰带5手套6鞋子7玉佩8副手9戒指10手镯）
	public string Name;          	//装备名称	装备名称
	public int LV;               	//装备等级	装备等级
	public string ZhiYe;         	//所属职业	所属职业
	public string Res;           	//装备资源	装备资源
	public int Colour;           	//初始品质	初始品质（2白色2绿色3蓝色4紫色5橙色6红色）
	public int XiangQian;        	//可镶嵌槽位	
	public int DaKong;           	//打孔道具	打孔道具
	public int XiLian;           	//洗炼道具	洗炼道具
	public int XiaoHao;          	//消耗数量	消耗数量
	public int JiChuXiLian;      	//基础洗炼	基础洗炼
	public int XiLianXiaoHao;    	//基础洗炼消耗	基础洗炼消耗
	public int ISGaiZao;         	//是否能改造	1可以-1不可以
	public int GaiZao;           	//装备改造	装备改造
	public int GaiZaoXiaoHao;    	//改造消耗	改造消耗
	public string Attribute;     	//属性	对应属性（1物理攻击2法术攻击3HP上限4物理防御5法术防御6暴击等级7必杀等级8破盾等级9格挡10格挡减免）
	public string Num1;          	//基础属性阈值1	基础属性阈值1
	public string Num2;          	//基础属性阈值2	基础属性阈值2
	public string Num3;          	//基础属性阈值3	基础属性阈值3
	public string Num4;          	//基础属性阈值4	基础属性阈值4
	public float JinHua;         	//每增加一条属性增加倍率	每增加一条属性增加倍率
	public string FuJia;         	//附加属性库	附加属性库
	public int MAX;              	//最大附加条数	最大附加条数
	public string GuDing;        	//固定附加	固定附加（白0，绿3，蓝4，紫5，橙5，红）
	public string FuJiaNum;      	//随机附加数量权值	随机附加数量权值
	public int Decompose;        	//分解	是否可分解
	public int DecomposeID;      	//分解道具	分解出的道具
	public int Nummin;           	//分解道具数量下限	分解道具数量
	public int Price;            	//价格	分解价格
	public int DelPrice;         	//回收价格	回收价格
	public int BuyPrick;         	//取回价格	取回价格
	public int  Valuabl;         	//是否为珍贵物品	是否为珍贵物品
	public int ModelId;          	//模型ID	模型ID
	public string EffectID;      	//模型动画	模型动画

	public bool IsValidate = false;
	public EquipElement()
	{
		EquipID = -1;
	}
};

//装备配置封装类
public class EquipTable
{

	private EquipTable()
	{
		m_mapElements = new Dictionary<int, EquipElement>();
		m_emptyItem = new EquipElement();
		m_vecAllElements = new List<EquipElement>();
	}
	private Dictionary<int, EquipElement> m_mapElements = null;
	private List<EquipElement>	m_vecAllElements = null;
	private EquipElement m_emptyItem = null;
	private static EquipTable sInstance = null;

	public static EquipTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new EquipTable();
			return sInstance;
		}
	}

	public EquipElement GetElement(int key)
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

  public List<EquipElement> GetAllElement(Predicate<EquipElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Equip.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Equip.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Equip.bin]未找到");
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
		if(vecLine.Count != 35)
		{
			Ex.Logger.Log("Equip.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="EquipID"){Ex.Logger.Log("Equip.csv中字段[EquipID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("Equip.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Name"){Ex.Logger.Log("Equip.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[3]!="LV"){Ex.Logger.Log("Equip.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[4]!="ZhiYe"){Ex.Logger.Log("Equip.csv中字段[ZhiYe]位置不对应"); return false; }
		if(vecLine[5]!="Res"){Ex.Logger.Log("Equip.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[6]!="Colour"){Ex.Logger.Log("Equip.csv中字段[Colour]位置不对应"); return false; }
		if(vecLine[7]!="XiangQian"){Ex.Logger.Log("Equip.csv中字段[XiangQian]位置不对应"); return false; }
		if(vecLine[8]!="DaKong"){Ex.Logger.Log("Equip.csv中字段[DaKong]位置不对应"); return false; }
		if(vecLine[9]!="XiLian"){Ex.Logger.Log("Equip.csv中字段[XiLian]位置不对应"); return false; }
		if(vecLine[10]!="XiaoHao"){Ex.Logger.Log("Equip.csv中字段[XiaoHao]位置不对应"); return false; }
		if(vecLine[11]!="JiChuXiLian"){Ex.Logger.Log("Equip.csv中字段[JiChuXiLian]位置不对应"); return false; }
		if(vecLine[12]!="XiLianXiaoHao"){Ex.Logger.Log("Equip.csv中字段[XiLianXiaoHao]位置不对应"); return false; }
		if(vecLine[13]!="ISGaiZao"){Ex.Logger.Log("Equip.csv中字段[ISGaiZao]位置不对应"); return false; }
		if(vecLine[14]!="GaiZao"){Ex.Logger.Log("Equip.csv中字段[GaiZao]位置不对应"); return false; }
		if(vecLine[15]!="GaiZaoXiaoHao"){Ex.Logger.Log("Equip.csv中字段[GaiZaoXiaoHao]位置不对应"); return false; }
		if(vecLine[16]!="Attribute"){Ex.Logger.Log("Equip.csv中字段[Attribute]位置不对应"); return false; }
		if(vecLine[17]!="Num1"){Ex.Logger.Log("Equip.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[18]!="Num2"){Ex.Logger.Log("Equip.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[19]!="Num3"){Ex.Logger.Log("Equip.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[20]!="Num4"){Ex.Logger.Log("Equip.csv中字段[Num4]位置不对应"); return false; }
		if(vecLine[21]!="JinHua"){Ex.Logger.Log("Equip.csv中字段[JinHua]位置不对应"); return false; }
		if(vecLine[22]!="FuJia"){Ex.Logger.Log("Equip.csv中字段[FuJia]位置不对应"); return false; }
		if(vecLine[23]!="MAX"){Ex.Logger.Log("Equip.csv中字段[MAX]位置不对应"); return false; }
		if(vecLine[24]!="GuDing"){Ex.Logger.Log("Equip.csv中字段[GuDing]位置不对应"); return false; }
		if(vecLine[25]!="FuJiaNum"){Ex.Logger.Log("Equip.csv中字段[FuJiaNum]位置不对应"); return false; }
		if(vecLine[26]!="Decompose"){Ex.Logger.Log("Equip.csv中字段[Decompose]位置不对应"); return false; }
		if(vecLine[27]!="DecomposeID"){Ex.Logger.Log("Equip.csv中字段[DecomposeID]位置不对应"); return false; }
		if(vecLine[28]!="Nummin"){Ex.Logger.Log("Equip.csv中字段[Nummin]位置不对应"); return false; }
		if(vecLine[29]!="Price"){Ex.Logger.Log("Equip.csv中字段[Price]位置不对应"); return false; }
		if(vecLine[30]!="DelPrice"){Ex.Logger.Log("Equip.csv中字段[DelPrice]位置不对应"); return false; }
		if(vecLine[31]!="BuyPrick"){Ex.Logger.Log("Equip.csv中字段[BuyPrick]位置不对应"); return false; }
		if(vecLine[32]!=" Valuabl"){Ex.Logger.Log("Equip.csv中字段[ Valuabl]位置不对应"); return false; }
		if(vecLine[33]!="ModelId"){Ex.Logger.Log("Equip.csv中字段[ModelId]位置不对应"); return false; }
		if(vecLine[34]!="EffectID"){Ex.Logger.Log("Equip.csv中字段[EffectID]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			EquipElement member = new EquipElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EquipID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LV );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ZhiYe);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Colour );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiangQian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DaKong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiLian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiaoHao );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.JiChuXiLian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiLianXiaoHao );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ISGaiZao );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GaiZao );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GaiZaoXiaoHao );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attribute);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num1);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num2);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num3);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num4);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.JinHua);
			readPos += GameAssist.ReadString( binContent, readPos, out member.FuJia);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MAX );
			readPos += GameAssist.ReadString( binContent, readPos, out member.GuDing);
			readPos += GameAssist.ReadString( binContent, readPos, out member.FuJiaNum);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Decompose );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DecomposeID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Nummin );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Price );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DelPrice );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BuyPrick );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member. Valuabl );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelId );
			readPos += GameAssist.ReadString( binContent, readPos, out member.EffectID);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.EquipID] = member;
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
		if(vecLine.Count != 35)
		{
			Ex.Logger.Log("Equip.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="EquipID"){Ex.Logger.Log("Equip.csv中字段[EquipID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("Equip.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Name"){Ex.Logger.Log("Equip.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[3]!="LV"){Ex.Logger.Log("Equip.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[4]!="ZhiYe"){Ex.Logger.Log("Equip.csv中字段[ZhiYe]位置不对应"); return false; }
		if(vecLine[5]!="Res"){Ex.Logger.Log("Equip.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[6]!="Colour"){Ex.Logger.Log("Equip.csv中字段[Colour]位置不对应"); return false; }
		if(vecLine[7]!="XiangQian"){Ex.Logger.Log("Equip.csv中字段[XiangQian]位置不对应"); return false; }
		if(vecLine[8]!="DaKong"){Ex.Logger.Log("Equip.csv中字段[DaKong]位置不对应"); return false; }
		if(vecLine[9]!="XiLian"){Ex.Logger.Log("Equip.csv中字段[XiLian]位置不对应"); return false; }
		if(vecLine[10]!="XiaoHao"){Ex.Logger.Log("Equip.csv中字段[XiaoHao]位置不对应"); return false; }
		if(vecLine[11]!="JiChuXiLian"){Ex.Logger.Log("Equip.csv中字段[JiChuXiLian]位置不对应"); return false; }
		if(vecLine[12]!="XiLianXiaoHao"){Ex.Logger.Log("Equip.csv中字段[XiLianXiaoHao]位置不对应"); return false; }
		if(vecLine[13]!="ISGaiZao"){Ex.Logger.Log("Equip.csv中字段[ISGaiZao]位置不对应"); return false; }
		if(vecLine[14]!="GaiZao"){Ex.Logger.Log("Equip.csv中字段[GaiZao]位置不对应"); return false; }
		if(vecLine[15]!="GaiZaoXiaoHao"){Ex.Logger.Log("Equip.csv中字段[GaiZaoXiaoHao]位置不对应"); return false; }
		if(vecLine[16]!="Attribute"){Ex.Logger.Log("Equip.csv中字段[Attribute]位置不对应"); return false; }
		if(vecLine[17]!="Num1"){Ex.Logger.Log("Equip.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[18]!="Num2"){Ex.Logger.Log("Equip.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[19]!="Num3"){Ex.Logger.Log("Equip.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[20]!="Num4"){Ex.Logger.Log("Equip.csv中字段[Num4]位置不对应"); return false; }
		if(vecLine[21]!="JinHua"){Ex.Logger.Log("Equip.csv中字段[JinHua]位置不对应"); return false; }
		if(vecLine[22]!="FuJia"){Ex.Logger.Log("Equip.csv中字段[FuJia]位置不对应"); return false; }
		if(vecLine[23]!="MAX"){Ex.Logger.Log("Equip.csv中字段[MAX]位置不对应"); return false; }
		if(vecLine[24]!="GuDing"){Ex.Logger.Log("Equip.csv中字段[GuDing]位置不对应"); return false; }
		if(vecLine[25]!="FuJiaNum"){Ex.Logger.Log("Equip.csv中字段[FuJiaNum]位置不对应"); return false; }
		if(vecLine[26]!="Decompose"){Ex.Logger.Log("Equip.csv中字段[Decompose]位置不对应"); return false; }
		if(vecLine[27]!="DecomposeID"){Ex.Logger.Log("Equip.csv中字段[DecomposeID]位置不对应"); return false; }
		if(vecLine[28]!="Nummin"){Ex.Logger.Log("Equip.csv中字段[Nummin]位置不对应"); return false; }
		if(vecLine[29]!="Price"){Ex.Logger.Log("Equip.csv中字段[Price]位置不对应"); return false; }
		if(vecLine[30]!="DelPrice"){Ex.Logger.Log("Equip.csv中字段[DelPrice]位置不对应"); return false; }
		if(vecLine[31]!="BuyPrick"){Ex.Logger.Log("Equip.csv中字段[BuyPrick]位置不对应"); return false; }
		if(vecLine[32]!=" Valuabl"){Ex.Logger.Log("Equip.csv中字段[ Valuabl]位置不对应"); return false; }
		if(vecLine[33]!="ModelId"){Ex.Logger.Log("Equip.csv中字段[ModelId]位置不对应"); return false; }
		if(vecLine[34]!="EffectID"){Ex.Logger.Log("Equip.csv中字段[EffectID]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)35)
			{
				return false;
			}
			EquipElement member = new EquipElement();
			member.EquipID=Convert.ToInt32(vecLine[0]);
			member.Type=Convert.ToInt32(vecLine[1]);
			member.Name=vecLine[2];
			member.LV=Convert.ToInt32(vecLine[3]);
			member.ZhiYe=vecLine[4];
			member.Res=vecLine[5];
			member.Colour=Convert.ToInt32(vecLine[6]);
			member.XiangQian=Convert.ToInt32(vecLine[7]);
			member.DaKong=Convert.ToInt32(vecLine[8]);
			member.XiLian=Convert.ToInt32(vecLine[9]);
			member.XiaoHao=Convert.ToInt32(vecLine[10]);
			member.JiChuXiLian=Convert.ToInt32(vecLine[11]);
			member.XiLianXiaoHao=Convert.ToInt32(vecLine[12]);
			member.ISGaiZao=Convert.ToInt32(vecLine[13]);
			member.GaiZao=Convert.ToInt32(vecLine[14]);
			member.GaiZaoXiaoHao=Convert.ToInt32(vecLine[15]);
			member.Attribute=vecLine[16];
			member.Num1=vecLine[17];
			member.Num2=vecLine[18];
			member.Num3=vecLine[19];
			member.Num4=vecLine[20];
			member.JinHua=Convert.ToSingle(vecLine[21]);
			member.FuJia=vecLine[22];
			member.MAX=Convert.ToInt32(vecLine[23]);
			member.GuDing=vecLine[24];
			member.FuJiaNum=vecLine[25];
			member.Decompose=Convert.ToInt32(vecLine[26]);
			member.DecomposeID=Convert.ToInt32(vecLine[27]);
			member.Nummin=Convert.ToInt32(vecLine[28]);
			member.Price=Convert.ToInt32(vecLine[29]);
			member.DelPrice=Convert.ToInt32(vecLine[30]);
			member.BuyPrick=Convert.ToInt32(vecLine[31]);
			member. Valuabl=Convert.ToInt32(vecLine[32]);
			member.ModelId=Convert.ToInt32(vecLine[33]);
			member.EffectID=vecLine[34];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.EquipID] = member;
		}
		return true;
	}
};
