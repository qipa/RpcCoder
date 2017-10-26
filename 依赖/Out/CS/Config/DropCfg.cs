using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//掉落表配置数据类
public class DropElement
{
	public int DropID;           	//掉落ID	掉落索引参数
	public string Desc;          	//描述	策划用备注该掉落列作用
	public int DropType;         	//掉落类型	1为概率掉落，2为权重掉落（权重之和为10000）
	public int MoneyType1;       	//1金钱类型	索引Money表（11-金币，12-钻石）
	public int MoneyMaxValue1;   	//1金钱最大值	金钱掉落随机区间的最大值
	public int MoneyMinValue1;   	//1金钱最小值	金钱掉落随机区间的最小值
	public int MoneyType2;       	//2金钱类型	索引Money表
	public int MoneyMaxValue2;   	//2金钱最大值	金钱掉落随机区间的最大值
	public int MoneyMinValue2;   	//2金钱最小值	金钱掉落随机区间的最小值
	public int BagType1;         	//1掉落包类型	1为掉落包，2为道具
	public int BagParamete1;     	//1掉落包参数	如果DropType为1则为万分比的概率值，如果为2则为权重值
	public int Bag1;             	//1掉落包内容	根据BagType确定是掉落包还是物品ID
	public int BagNum1;          	//1掉落包数量	掉落的数量
	public int BagType2;         	//2掉落包类型	1为掉落包，2为道具
	public int BagParamete2;     	//2掉落包参数	如果DropType为1则为万分比的概率值，如果为2则为权重值
	public int Bag2;             	//2掉落包内容	根据BagType确定是掉落包还是物品ID
	public int BagNum2;          	//2掉落包数量	掉落的数量
	public int BagType3;         	//3掉落包类型	1为掉落包，2为道具
	public int BagParamete3;     	//3掉落包参数	如果DropType为1则为万分比的概率值，如果为2则为权重值
	public int Bag3;             	//3掉落包内容	根据BagType确定是掉落包还是物品ID
	public int BagNum3;          	//3掉落包数量	掉落的数量
	public int BagType4;         	//4掉落包类型	1为掉落包，2为道具
	public int BagParamete4;     	//4掉落包参数	如果DropType为1则为万分比的概率值，如果为2则为权重值
	public int Bag4;             	//4掉落包内容	根据BagType确定是掉落包还是物品ID
	public int BagNum4;          	//4掉落包数量	掉落的数量
	public int BagType5;         	//5掉落包类型	1为掉落包，2为道具
	public int BagParamete5;     	//5掉落包参数	如果DropType为1则为万分比的概率值，如果为2则为权重值
	public int Bag5;             	//5掉落包内容	根据BagType确定是掉落包还是物品ID
	public int BagNum5;          	//5掉落包数量	掉落的数量

	public bool IsValidate = false;
	public DropElement()
	{
		DropID = -1;
	}
};

//掉落表配置封装类
public class DropTable
{

	private DropTable()
	{
		m_mapElements = new Dictionary<int, DropElement>();
		m_emptyItem = new DropElement();
		m_vecAllElements = new List<DropElement>();
	}
	private Dictionary<int, DropElement> m_mapElements = null;
	private List<DropElement>	m_vecAllElements = null;
	private DropElement m_emptyItem = null;
	private static DropTable sInstance = null;

	public static DropTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new DropTable();
			return sInstance;
		}
	}

	public DropElement GetElement(int key)
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

  public List<DropElement> GetAllElement(Predicate<DropElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Drop.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Drop.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Drop.bin]未找到");
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
		if(vecLine.Count != 29)
		{
			Ex.Logger.Log("Drop.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="DropID"){Ex.Logger.Log("Drop.csv中字段[DropID]位置不对应"); return false; }
		if(vecLine[1]!="Desc"){Ex.Logger.Log("Drop.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[2]!="DropType"){Ex.Logger.Log("Drop.csv中字段[DropType]位置不对应"); return false; }
		if(vecLine[3]!="MoneyType1"){Ex.Logger.Log("Drop.csv中字段[MoneyType1]位置不对应"); return false; }
		if(vecLine[4]!="MoneyMaxValue1"){Ex.Logger.Log("Drop.csv中字段[MoneyMaxValue1]位置不对应"); return false; }
		if(vecLine[5]!="MoneyMinValue1"){Ex.Logger.Log("Drop.csv中字段[MoneyMinValue1]位置不对应"); return false; }
		if(vecLine[6]!="MoneyType2"){Ex.Logger.Log("Drop.csv中字段[MoneyType2]位置不对应"); return false; }
		if(vecLine[7]!="MoneyMaxValue2"){Ex.Logger.Log("Drop.csv中字段[MoneyMaxValue2]位置不对应"); return false; }
		if(vecLine[8]!="MoneyMinValue2"){Ex.Logger.Log("Drop.csv中字段[MoneyMinValue2]位置不对应"); return false; }
		if(vecLine[9]!="BagType1"){Ex.Logger.Log("Drop.csv中字段[BagType1]位置不对应"); return false; }
		if(vecLine[10]!="BagParamete1"){Ex.Logger.Log("Drop.csv中字段[BagParamete1]位置不对应"); return false; }
		if(vecLine[11]!="Bag1"){Ex.Logger.Log("Drop.csv中字段[Bag1]位置不对应"); return false; }
		if(vecLine[12]!="BagNum1"){Ex.Logger.Log("Drop.csv中字段[BagNum1]位置不对应"); return false; }
		if(vecLine[13]!="BagType2"){Ex.Logger.Log("Drop.csv中字段[BagType2]位置不对应"); return false; }
		if(vecLine[14]!="BagParamete2"){Ex.Logger.Log("Drop.csv中字段[BagParamete2]位置不对应"); return false; }
		if(vecLine[15]!="Bag2"){Ex.Logger.Log("Drop.csv中字段[Bag2]位置不对应"); return false; }
		if(vecLine[16]!="BagNum2"){Ex.Logger.Log("Drop.csv中字段[BagNum2]位置不对应"); return false; }
		if(vecLine[17]!="BagType3"){Ex.Logger.Log("Drop.csv中字段[BagType3]位置不对应"); return false; }
		if(vecLine[18]!="BagParamete3"){Ex.Logger.Log("Drop.csv中字段[BagParamete3]位置不对应"); return false; }
		if(vecLine[19]!="Bag3"){Ex.Logger.Log("Drop.csv中字段[Bag3]位置不对应"); return false; }
		if(vecLine[20]!="BagNum3"){Ex.Logger.Log("Drop.csv中字段[BagNum3]位置不对应"); return false; }
		if(vecLine[21]!="BagType4"){Ex.Logger.Log("Drop.csv中字段[BagType4]位置不对应"); return false; }
		if(vecLine[22]!="BagParamete4"){Ex.Logger.Log("Drop.csv中字段[BagParamete4]位置不对应"); return false; }
		if(vecLine[23]!="Bag4"){Ex.Logger.Log("Drop.csv中字段[Bag4]位置不对应"); return false; }
		if(vecLine[24]!="BagNum4"){Ex.Logger.Log("Drop.csv中字段[BagNum4]位置不对应"); return false; }
		if(vecLine[25]!="BagType5"){Ex.Logger.Log("Drop.csv中字段[BagType5]位置不对应"); return false; }
		if(vecLine[26]!="BagParamete5"){Ex.Logger.Log("Drop.csv中字段[BagParamete5]位置不对应"); return false; }
		if(vecLine[27]!="Bag5"){Ex.Logger.Log("Drop.csv中字段[Bag5]位置不对应"); return false; }
		if(vecLine[28]!="BagNum5"){Ex.Logger.Log("Drop.csv中字段[BagNum5]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			DropElement member = new DropElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DropID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Desc);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DropType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyType1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyMaxValue1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyMinValue1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyType2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyMaxValue2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyMinValue2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagType1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagParamete1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Bag1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagNum1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagType2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagParamete2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Bag2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagNum2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagType3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagParamete3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Bag3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagNum3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagType4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagParamete4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Bag4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagNum4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagType5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagParamete5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Bag5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.BagNum5 );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.DropID] = member;
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
		if(vecLine.Count != 29)
		{
			Ex.Logger.Log("Drop.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="DropID"){Ex.Logger.Log("Drop.csv中字段[DropID]位置不对应"); return false; }
		if(vecLine[1]!="Desc"){Ex.Logger.Log("Drop.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[2]!="DropType"){Ex.Logger.Log("Drop.csv中字段[DropType]位置不对应"); return false; }
		if(vecLine[3]!="MoneyType1"){Ex.Logger.Log("Drop.csv中字段[MoneyType1]位置不对应"); return false; }
		if(vecLine[4]!="MoneyMaxValue1"){Ex.Logger.Log("Drop.csv中字段[MoneyMaxValue1]位置不对应"); return false; }
		if(vecLine[5]!="MoneyMinValue1"){Ex.Logger.Log("Drop.csv中字段[MoneyMinValue1]位置不对应"); return false; }
		if(vecLine[6]!="MoneyType2"){Ex.Logger.Log("Drop.csv中字段[MoneyType2]位置不对应"); return false; }
		if(vecLine[7]!="MoneyMaxValue2"){Ex.Logger.Log("Drop.csv中字段[MoneyMaxValue2]位置不对应"); return false; }
		if(vecLine[8]!="MoneyMinValue2"){Ex.Logger.Log("Drop.csv中字段[MoneyMinValue2]位置不对应"); return false; }
		if(vecLine[9]!="BagType1"){Ex.Logger.Log("Drop.csv中字段[BagType1]位置不对应"); return false; }
		if(vecLine[10]!="BagParamete1"){Ex.Logger.Log("Drop.csv中字段[BagParamete1]位置不对应"); return false; }
		if(vecLine[11]!="Bag1"){Ex.Logger.Log("Drop.csv中字段[Bag1]位置不对应"); return false; }
		if(vecLine[12]!="BagNum1"){Ex.Logger.Log("Drop.csv中字段[BagNum1]位置不对应"); return false; }
		if(vecLine[13]!="BagType2"){Ex.Logger.Log("Drop.csv中字段[BagType2]位置不对应"); return false; }
		if(vecLine[14]!="BagParamete2"){Ex.Logger.Log("Drop.csv中字段[BagParamete2]位置不对应"); return false; }
		if(vecLine[15]!="Bag2"){Ex.Logger.Log("Drop.csv中字段[Bag2]位置不对应"); return false; }
		if(vecLine[16]!="BagNum2"){Ex.Logger.Log("Drop.csv中字段[BagNum2]位置不对应"); return false; }
		if(vecLine[17]!="BagType3"){Ex.Logger.Log("Drop.csv中字段[BagType3]位置不对应"); return false; }
		if(vecLine[18]!="BagParamete3"){Ex.Logger.Log("Drop.csv中字段[BagParamete3]位置不对应"); return false; }
		if(vecLine[19]!="Bag3"){Ex.Logger.Log("Drop.csv中字段[Bag3]位置不对应"); return false; }
		if(vecLine[20]!="BagNum3"){Ex.Logger.Log("Drop.csv中字段[BagNum3]位置不对应"); return false; }
		if(vecLine[21]!="BagType4"){Ex.Logger.Log("Drop.csv中字段[BagType4]位置不对应"); return false; }
		if(vecLine[22]!="BagParamete4"){Ex.Logger.Log("Drop.csv中字段[BagParamete4]位置不对应"); return false; }
		if(vecLine[23]!="Bag4"){Ex.Logger.Log("Drop.csv中字段[Bag4]位置不对应"); return false; }
		if(vecLine[24]!="BagNum4"){Ex.Logger.Log("Drop.csv中字段[BagNum4]位置不对应"); return false; }
		if(vecLine[25]!="BagType5"){Ex.Logger.Log("Drop.csv中字段[BagType5]位置不对应"); return false; }
		if(vecLine[26]!="BagParamete5"){Ex.Logger.Log("Drop.csv中字段[BagParamete5]位置不对应"); return false; }
		if(vecLine[27]!="Bag5"){Ex.Logger.Log("Drop.csv中字段[Bag5]位置不对应"); return false; }
		if(vecLine[28]!="BagNum5"){Ex.Logger.Log("Drop.csv中字段[BagNum5]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)29)
			{
				return false;
			}
			DropElement member = new DropElement();
			member.DropID=Convert.ToInt32(vecLine[0]);
			member.Desc=vecLine[1];
			member.DropType=Convert.ToInt32(vecLine[2]);
			member.MoneyType1=Convert.ToInt32(vecLine[3]);
			member.MoneyMaxValue1=Convert.ToInt32(vecLine[4]);
			member.MoneyMinValue1=Convert.ToInt32(vecLine[5]);
			member.MoneyType2=Convert.ToInt32(vecLine[6]);
			member.MoneyMaxValue2=Convert.ToInt32(vecLine[7]);
			member.MoneyMinValue2=Convert.ToInt32(vecLine[8]);
			member.BagType1=Convert.ToInt32(vecLine[9]);
			member.BagParamete1=Convert.ToInt32(vecLine[10]);
			member.Bag1=Convert.ToInt32(vecLine[11]);
			member.BagNum1=Convert.ToInt32(vecLine[12]);
			member.BagType2=Convert.ToInt32(vecLine[13]);
			member.BagParamete2=Convert.ToInt32(vecLine[14]);
			member.Bag2=Convert.ToInt32(vecLine[15]);
			member.BagNum2=Convert.ToInt32(vecLine[16]);
			member.BagType3=Convert.ToInt32(vecLine[17]);
			member.BagParamete3=Convert.ToInt32(vecLine[18]);
			member.Bag3=Convert.ToInt32(vecLine[19]);
			member.BagNum3=Convert.ToInt32(vecLine[20]);
			member.BagType4=Convert.ToInt32(vecLine[21]);
			member.BagParamete4=Convert.ToInt32(vecLine[22]);
			member.Bag4=Convert.ToInt32(vecLine[23]);
			member.BagNum4=Convert.ToInt32(vecLine[24]);
			member.BagType5=Convert.ToInt32(vecLine[25]);
			member.BagParamete5=Convert.ToInt32(vecLine[26]);
			member.Bag5=Convert.ToInt32(vecLine[27]);
			member.BagNum5=Convert.ToInt32(vecLine[28]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.DropID] = member;
		}
		return true;
	}
};
