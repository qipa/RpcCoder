using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//物品配置数据类
public class ItemElement
{
	public int ItemID;           	//编号	物品ID
	public string Name;          	//物品名称	物品名称
	public string Type;          	//物品类别	物品类别
	public int FenLei;           	//物品细分类别	0无细分需求、1技能书2、副本增加次数3回复药4状态药5召唤帮主6偷窃帮会资金7帮会破坏8多开礼包9单开礼包99货币
	public string FenLeiParameter;	//参数	使用后的效果，对应前面分类，技能书对应技能ID，使用后可增加次数填写数字
	public int Cishu;            	//使用次数限制	使用次数限制
	public int Time;             	//使用时间	单位毫秒
	public int Timeliness;       	//时效性	道具使用次数限制的时间0无限制1天2周
	public string SourceID;      	//Item的资源id	Item的资源id
	public int LV;               	//等级	等级
	public int Colour;           	//初始品质	初始品质（1白色2绿色3蓝色4紫色5橙色6红色7真）
	public int ShiYong;          	//是否可使用	是否可使用
	public int HeCheng;          	//是否可合成	是否可合成
	public int IsSell;           	//是否可以买卖	0不可以 否则就是卖出的价钱
	public int ZiDong;           	//是否可自动使用	是否可自动使用
	public int IsBind;           	//是否绑定	1绑定0不绑定
	public int IsAdd;            	//是否可以累加	1可以 0不可以
	public int AddNum;           	//累加上限	累加上限
	public int Price;            	//价格	分解价格
	public int IsDel;            	//是否可以回收	1可以 0不可以
	public int DelPrice;         	//回收价格	回收价格
	public int BuyPrick;         	//取回价格	取回价格
	public string MiaoShu;       	//物品描述	物品描述
	public string BeiZhu;        	//物品备注	物品备注
	public int  Valuabl;         	//是否为珍贵物品	是否为珍贵物品
	public int ModelId;          	//模型ID	模型ID
	public string EffectID;      	//模型动画	模型动画
	public int Mission;          	//关联任务ID	关联任务ID
	public int Skill;            	//动作ID	动作ID
	public float ItenR;          	//触发半径	触发半径

	public bool IsValidate = false;
	public ItemElement()
	{
		ItemID = -1;
	}
};

//物品配置封装类
public class ItemTable
{

	private ItemTable()
	{
		m_mapElements = new Dictionary<int, ItemElement>();
		m_emptyItem = new ItemElement();
		m_vecAllElements = new List<ItemElement>();
	}
	private Dictionary<int, ItemElement> m_mapElements = null;
	private List<ItemElement>	m_vecAllElements = null;
	private ItemElement m_emptyItem = null;
	private static ItemTable sInstance = null;

	public static ItemTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ItemTable();
			return sInstance;
		}
	}

	public ItemElement GetElement(int key)
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

  public List<ItemElement> GetAllElement(Predicate<ItemElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Item.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Item.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Item.bin]未找到");
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
		if(vecLine.Count != 30)
		{
			Ex.Logger.Log("Item.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ItemID"){Ex.Logger.Log("Item.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Item.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("Item.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="FenLei"){Ex.Logger.Log("Item.csv中字段[FenLei]位置不对应"); return false; }
		if(vecLine[4]!="FenLeiParameter"){Ex.Logger.Log("Item.csv中字段[FenLeiParameter]位置不对应"); return false; }
		if(vecLine[5]!="Cishu"){Ex.Logger.Log("Item.csv中字段[Cishu]位置不对应"); return false; }
		if(vecLine[6]!="Time"){Ex.Logger.Log("Item.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[7]!="Timeliness"){Ex.Logger.Log("Item.csv中字段[Timeliness]位置不对应"); return false; }
		if(vecLine[8]!="SourceID"){Ex.Logger.Log("Item.csv中字段[SourceID]位置不对应"); return false; }
		if(vecLine[9]!="LV"){Ex.Logger.Log("Item.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[10]!="Colour"){Ex.Logger.Log("Item.csv中字段[Colour]位置不对应"); return false; }
		if(vecLine[11]!="ShiYong"){Ex.Logger.Log("Item.csv中字段[ShiYong]位置不对应"); return false; }
		if(vecLine[12]!="HeCheng"){Ex.Logger.Log("Item.csv中字段[HeCheng]位置不对应"); return false; }
		if(vecLine[13]!="IsSell"){Ex.Logger.Log("Item.csv中字段[IsSell]位置不对应"); return false; }
		if(vecLine[14]!="ZiDong"){Ex.Logger.Log("Item.csv中字段[ZiDong]位置不对应"); return false; }
		if(vecLine[15]!="IsBind"){Ex.Logger.Log("Item.csv中字段[IsBind]位置不对应"); return false; }
		if(vecLine[16]!="IsAdd"){Ex.Logger.Log("Item.csv中字段[IsAdd]位置不对应"); return false; }
		if(vecLine[17]!="AddNum"){Ex.Logger.Log("Item.csv中字段[AddNum]位置不对应"); return false; }
		if(vecLine[18]!="Price"){Ex.Logger.Log("Item.csv中字段[Price]位置不对应"); return false; }
		if(vecLine[19]!="IsDel"){Ex.Logger.Log("Item.csv中字段[IsDel]位置不对应"); return false; }
		if(vecLine[20]!="DelPrice"){Ex.Logger.Log("Item.csv中字段[DelPrice]位置不对应"); return false; }
		if(vecLine[21]!="BuyPrick"){Ex.Logger.Log("Item.csv中字段[BuyPrick]位置不对应"); return false; }
		if(vecLine[22]!="MiaoShu"){Ex.Logger.Log("Item.csv中字段[MiaoShu]位置不对应"); return false; }
		if(vecLine[23]!="BeiZhu"){Ex.Logger.Log("Item.csv中字段[BeiZhu]位置不对应"); return false; }
		if(vecLine[24]!=" Valuabl"){Ex.Logger.Log("Item.csv中字段[ Valuabl]位置不对应"); return false; }
		if(vecLine[25]!="ModelId"){Ex.Logger.Log("Item.csv中字段[ModelId]位置不对应"); return false; }
		if(vecLine[26]!="EffectID"){Ex.Logger.Log("Item.csv中字段[EffectID]位置不对应"); return false; }
		if(vecLine[27]!="Mission"){Ex.Logger.Log("Item.csv中字段[Mission]位置不对应"); return false; }
		if(vecLine[28]!="Skill"){Ex.Logger.Log("Item.csv中字段[Skill]位置不对应"); return false; }
		if(vecLine[29]!="ItenR"){Ex.Logger.Log("Item.csv中字段[ItenR]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ItemElement member = new ItemElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Type);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FenLei );
			readPos += GameAssist.ReadString( binContent, readPos, out member.FenLeiParameter);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Cishu );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Time );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Timeliness );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SourceID);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LV );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Colour );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShiYong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HeCheng );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsSell );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ZiDong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsBind );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsAdd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AddNum );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Price );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsDel );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DelPrice );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BuyPrick );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MiaoShu);
			readPos += GameAssist.ReadString( binContent, readPos, out member.BeiZhu);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member. Valuabl );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelId );
			readPos += GameAssist.ReadString( binContent, readPos, out member.EffectID);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Mission );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.ItenR);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ItemID] = member;
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
		if(vecLine.Count != 30)
		{
			Ex.Logger.Log("Item.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ItemID"){Ex.Logger.Log("Item.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Item.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("Item.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="FenLei"){Ex.Logger.Log("Item.csv中字段[FenLei]位置不对应"); return false; }
		if(vecLine[4]!="FenLeiParameter"){Ex.Logger.Log("Item.csv中字段[FenLeiParameter]位置不对应"); return false; }
		if(vecLine[5]!="Cishu"){Ex.Logger.Log("Item.csv中字段[Cishu]位置不对应"); return false; }
		if(vecLine[6]!="Time"){Ex.Logger.Log("Item.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[7]!="Timeliness"){Ex.Logger.Log("Item.csv中字段[Timeliness]位置不对应"); return false; }
		if(vecLine[8]!="SourceID"){Ex.Logger.Log("Item.csv中字段[SourceID]位置不对应"); return false; }
		if(vecLine[9]!="LV"){Ex.Logger.Log("Item.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[10]!="Colour"){Ex.Logger.Log("Item.csv中字段[Colour]位置不对应"); return false; }
		if(vecLine[11]!="ShiYong"){Ex.Logger.Log("Item.csv中字段[ShiYong]位置不对应"); return false; }
		if(vecLine[12]!="HeCheng"){Ex.Logger.Log("Item.csv中字段[HeCheng]位置不对应"); return false; }
		if(vecLine[13]!="IsSell"){Ex.Logger.Log("Item.csv中字段[IsSell]位置不对应"); return false; }
		if(vecLine[14]!="ZiDong"){Ex.Logger.Log("Item.csv中字段[ZiDong]位置不对应"); return false; }
		if(vecLine[15]!="IsBind"){Ex.Logger.Log("Item.csv中字段[IsBind]位置不对应"); return false; }
		if(vecLine[16]!="IsAdd"){Ex.Logger.Log("Item.csv中字段[IsAdd]位置不对应"); return false; }
		if(vecLine[17]!="AddNum"){Ex.Logger.Log("Item.csv中字段[AddNum]位置不对应"); return false; }
		if(vecLine[18]!="Price"){Ex.Logger.Log("Item.csv中字段[Price]位置不对应"); return false; }
		if(vecLine[19]!="IsDel"){Ex.Logger.Log("Item.csv中字段[IsDel]位置不对应"); return false; }
		if(vecLine[20]!="DelPrice"){Ex.Logger.Log("Item.csv中字段[DelPrice]位置不对应"); return false; }
		if(vecLine[21]!="BuyPrick"){Ex.Logger.Log("Item.csv中字段[BuyPrick]位置不对应"); return false; }
		if(vecLine[22]!="MiaoShu"){Ex.Logger.Log("Item.csv中字段[MiaoShu]位置不对应"); return false; }
		if(vecLine[23]!="BeiZhu"){Ex.Logger.Log("Item.csv中字段[BeiZhu]位置不对应"); return false; }
		if(vecLine[24]!=" Valuabl"){Ex.Logger.Log("Item.csv中字段[ Valuabl]位置不对应"); return false; }
		if(vecLine[25]!="ModelId"){Ex.Logger.Log("Item.csv中字段[ModelId]位置不对应"); return false; }
		if(vecLine[26]!="EffectID"){Ex.Logger.Log("Item.csv中字段[EffectID]位置不对应"); return false; }
		if(vecLine[27]!="Mission"){Ex.Logger.Log("Item.csv中字段[Mission]位置不对应"); return false; }
		if(vecLine[28]!="Skill"){Ex.Logger.Log("Item.csv中字段[Skill]位置不对应"); return false; }
		if(vecLine[29]!="ItenR"){Ex.Logger.Log("Item.csv中字段[ItenR]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)30)
			{
				return false;
			}
			ItemElement member = new ItemElement();
			member.ItemID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Type=vecLine[2];
			member.FenLei=Convert.ToInt32(vecLine[3]);
			member.FenLeiParameter=vecLine[4];
			member.Cishu=Convert.ToInt32(vecLine[5]);
			member.Time=Convert.ToInt32(vecLine[6]);
			member.Timeliness=Convert.ToInt32(vecLine[7]);
			member.SourceID=vecLine[8];
			member.LV=Convert.ToInt32(vecLine[9]);
			member.Colour=Convert.ToInt32(vecLine[10]);
			member.ShiYong=Convert.ToInt32(vecLine[11]);
			member.HeCheng=Convert.ToInt32(vecLine[12]);
			member.IsSell=Convert.ToInt32(vecLine[13]);
			member.ZiDong=Convert.ToInt32(vecLine[14]);
			member.IsBind=Convert.ToInt32(vecLine[15]);
			member.IsAdd=Convert.ToInt32(vecLine[16]);
			member.AddNum=Convert.ToInt32(vecLine[17]);
			member.Price=Convert.ToInt32(vecLine[18]);
			member.IsDel=Convert.ToInt32(vecLine[19]);
			member.DelPrice=Convert.ToInt32(vecLine[20]);
			member.BuyPrick=Convert.ToInt32(vecLine[21]);
			member.MiaoShu=vecLine[22];
			member.BeiZhu=vecLine[23];
			member. Valuabl=Convert.ToInt32(vecLine[24]);
			member.ModelId=Convert.ToInt32(vecLine[25]);
			member.EffectID=vecLine[26];
			member.Mission=Convert.ToInt32(vecLine[27]);
			member.Skill=Convert.ToInt32(vecLine[28]);
			member.ItenR=Convert.ToSingle(vecLine[29]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ItemID] = member;
		}
		return true;
	}
};
