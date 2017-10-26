using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//法宝表配置数据类
public class FaBaoElement
{
	public int ID;               	//编号	法宝ID
	public string Name;          	//法宝名称	法宝名称
	public string Res;           	//法宝图标	法宝图标
	public string MiaoShu;       	//法宝描述	法宝描述
	public int Model;            	//法宝模型	法宝模型
	public int Type;             	//法宝类型	法宝类型
	public int Max;              	//最大等级	最大等级
	public int Next;             	//下一级	下一级ID
	public int Star;             	//炼星ID	炼星ID
	public int SuiPian;          	//法宝碎片	ItemID
	public int PinZhi;           	//法宝品质	法宝品质
	public int Lv;               	//法宝等级	法宝等级
	public int Attr1;            	//属性1类别	属性1类别
	public int Num1;             	//属性1初始数值	属性1初始数值
	public int Attr2;            	//属性2类别	属性2类别
	public int Num2;             	//属性2初始数值	属性2初始数值
	public int Attr3;            	//属性3类别	属性3类别
	public int Num3;             	//属性3初始数值	属性3初始数值
	public int Exp;              	//拥有经验	拥有经验
	public int ExpMax;           	//升级所需经验	升级所需经验
	public int SkILL;            	//法宝技能	法宝技能
	public int Attr4;            	//收集属性1	收集属性1
	public int Num4;             	//收集属性1数值	收集属性1数值
	public int Attr5;            	//收集属性2	收集属性2
	public int Num5;             	//收集属性2数值	收集属性2数值
	public int Attr6;            	//收集属性3	收集属性3
	public int Num6;             	//收集属性3数值	收集属性3数值
	public int Sell;             	//回收价格	回收价格
	public int JuLing;           	//初始聚灵技能	初始聚灵技能

	public bool IsValidate = false;
	public FaBaoElement()
	{
		ID = -1;
	}
};

//法宝表配置封装类
public class FaBaoTable
{

	private FaBaoTable()
	{
		m_mapElements = new Dictionary<int, FaBaoElement>();
		m_emptyItem = new FaBaoElement();
		m_vecAllElements = new List<FaBaoElement>();
	}
	private Dictionary<int, FaBaoElement> m_mapElements = null;
	private List<FaBaoElement>	m_vecAllElements = null;
	private FaBaoElement m_emptyItem = null;
	private static FaBaoTable sInstance = null;

	public static FaBaoTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FaBaoTable();
			return sInstance;
		}
	}

	public FaBaoElement GetElement(int key)
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

  public List<FaBaoElement> GetAllElement(Predicate<FaBaoElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("FaBao.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("FaBao.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[FaBao.bin]未找到");
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
			Ex.Logger.Log("FaBao.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FaBao.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("FaBao.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Ex.Logger.Log("FaBao.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="MiaoShu"){Ex.Logger.Log("FaBao.csv中字段[MiaoShu]位置不对应"); return false; }
		if(vecLine[4]!="Model"){Ex.Logger.Log("FaBao.csv中字段[Model]位置不对应"); return false; }
		if(vecLine[5]!="Type"){Ex.Logger.Log("FaBao.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[6]!="Max"){Ex.Logger.Log("FaBao.csv中字段[Max]位置不对应"); return false; }
		if(vecLine[7]!="Next"){Ex.Logger.Log("FaBao.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[8]!="Star"){Ex.Logger.Log("FaBao.csv中字段[Star]位置不对应"); return false; }
		if(vecLine[9]!="SuiPian"){Ex.Logger.Log("FaBao.csv中字段[SuiPian]位置不对应"); return false; }
		if(vecLine[10]!="PinZhi"){Ex.Logger.Log("FaBao.csv中字段[PinZhi]位置不对应"); return false; }
		if(vecLine[11]!="Lv"){Ex.Logger.Log("FaBao.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[12]!="Attr1"){Ex.Logger.Log("FaBao.csv中字段[Attr1]位置不对应"); return false; }
		if(vecLine[13]!="Num1"){Ex.Logger.Log("FaBao.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[14]!="Attr2"){Ex.Logger.Log("FaBao.csv中字段[Attr2]位置不对应"); return false; }
		if(vecLine[15]!="Num2"){Ex.Logger.Log("FaBao.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[16]!="Attr3"){Ex.Logger.Log("FaBao.csv中字段[Attr3]位置不对应"); return false; }
		if(vecLine[17]!="Num3"){Ex.Logger.Log("FaBao.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[18]!="Exp"){Ex.Logger.Log("FaBao.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[19]!="ExpMax"){Ex.Logger.Log("FaBao.csv中字段[ExpMax]位置不对应"); return false; }
		if(vecLine[20]!="SkILL"){Ex.Logger.Log("FaBao.csv中字段[SkILL]位置不对应"); return false; }
		if(vecLine[21]!="Attr4"){Ex.Logger.Log("FaBao.csv中字段[Attr4]位置不对应"); return false; }
		if(vecLine[22]!="Num4"){Ex.Logger.Log("FaBao.csv中字段[Num4]位置不对应"); return false; }
		if(vecLine[23]!="Attr5"){Ex.Logger.Log("FaBao.csv中字段[Attr5]位置不对应"); return false; }
		if(vecLine[24]!="Num5"){Ex.Logger.Log("FaBao.csv中字段[Num5]位置不对应"); return false; }
		if(vecLine[25]!="Attr6"){Ex.Logger.Log("FaBao.csv中字段[Attr6]位置不对应"); return false; }
		if(vecLine[26]!="Num6"){Ex.Logger.Log("FaBao.csv中字段[Num6]位置不对应"); return false; }
		if(vecLine[27]!="Sell"){Ex.Logger.Log("FaBao.csv中字段[Sell]位置不对应"); return false; }
		if(vecLine[28]!="JuLing"){Ex.Logger.Log("FaBao.csv中字段[JuLing]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FaBaoElement member = new FaBaoElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MiaoShu);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Model );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Max );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Next );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Star );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PinZhi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Exp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ExpMax );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkILL );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Sell );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.JuLing );

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
		if(vecLine.Count != 29)
		{
			Ex.Logger.Log("FaBao.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FaBao.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("FaBao.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Ex.Logger.Log("FaBao.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="MiaoShu"){Ex.Logger.Log("FaBao.csv中字段[MiaoShu]位置不对应"); return false; }
		if(vecLine[4]!="Model"){Ex.Logger.Log("FaBao.csv中字段[Model]位置不对应"); return false; }
		if(vecLine[5]!="Type"){Ex.Logger.Log("FaBao.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[6]!="Max"){Ex.Logger.Log("FaBao.csv中字段[Max]位置不对应"); return false; }
		if(vecLine[7]!="Next"){Ex.Logger.Log("FaBao.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[8]!="Star"){Ex.Logger.Log("FaBao.csv中字段[Star]位置不对应"); return false; }
		if(vecLine[9]!="SuiPian"){Ex.Logger.Log("FaBao.csv中字段[SuiPian]位置不对应"); return false; }
		if(vecLine[10]!="PinZhi"){Ex.Logger.Log("FaBao.csv中字段[PinZhi]位置不对应"); return false; }
		if(vecLine[11]!="Lv"){Ex.Logger.Log("FaBao.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[12]!="Attr1"){Ex.Logger.Log("FaBao.csv中字段[Attr1]位置不对应"); return false; }
		if(vecLine[13]!="Num1"){Ex.Logger.Log("FaBao.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[14]!="Attr2"){Ex.Logger.Log("FaBao.csv中字段[Attr2]位置不对应"); return false; }
		if(vecLine[15]!="Num2"){Ex.Logger.Log("FaBao.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[16]!="Attr3"){Ex.Logger.Log("FaBao.csv中字段[Attr3]位置不对应"); return false; }
		if(vecLine[17]!="Num3"){Ex.Logger.Log("FaBao.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[18]!="Exp"){Ex.Logger.Log("FaBao.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[19]!="ExpMax"){Ex.Logger.Log("FaBao.csv中字段[ExpMax]位置不对应"); return false; }
		if(vecLine[20]!="SkILL"){Ex.Logger.Log("FaBao.csv中字段[SkILL]位置不对应"); return false; }
		if(vecLine[21]!="Attr4"){Ex.Logger.Log("FaBao.csv中字段[Attr4]位置不对应"); return false; }
		if(vecLine[22]!="Num4"){Ex.Logger.Log("FaBao.csv中字段[Num4]位置不对应"); return false; }
		if(vecLine[23]!="Attr5"){Ex.Logger.Log("FaBao.csv中字段[Attr5]位置不对应"); return false; }
		if(vecLine[24]!="Num5"){Ex.Logger.Log("FaBao.csv中字段[Num5]位置不对应"); return false; }
		if(vecLine[25]!="Attr6"){Ex.Logger.Log("FaBao.csv中字段[Attr6]位置不对应"); return false; }
		if(vecLine[26]!="Num6"){Ex.Logger.Log("FaBao.csv中字段[Num6]位置不对应"); return false; }
		if(vecLine[27]!="Sell"){Ex.Logger.Log("FaBao.csv中字段[Sell]位置不对应"); return false; }
		if(vecLine[28]!="JuLing"){Ex.Logger.Log("FaBao.csv中字段[JuLing]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)29)
			{
				return false;
			}
			FaBaoElement member = new FaBaoElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Res=vecLine[2];
			member.MiaoShu=vecLine[3];
			member.Model=Convert.ToInt32(vecLine[4]);
			member.Type=Convert.ToInt32(vecLine[5]);
			member.Max=Convert.ToInt32(vecLine[6]);
			member.Next=Convert.ToInt32(vecLine[7]);
			member.Star=Convert.ToInt32(vecLine[8]);
			member.SuiPian=Convert.ToInt32(vecLine[9]);
			member.PinZhi=Convert.ToInt32(vecLine[10]);
			member.Lv=Convert.ToInt32(vecLine[11]);
			member.Attr1=Convert.ToInt32(vecLine[12]);
			member.Num1=Convert.ToInt32(vecLine[13]);
			member.Attr2=Convert.ToInt32(vecLine[14]);
			member.Num2=Convert.ToInt32(vecLine[15]);
			member.Attr3=Convert.ToInt32(vecLine[16]);
			member.Num3=Convert.ToInt32(vecLine[17]);
			member.Exp=Convert.ToInt32(vecLine[18]);
			member.ExpMax=Convert.ToInt32(vecLine[19]);
			member.SkILL=Convert.ToInt32(vecLine[20]);
			member.Attr4=Convert.ToInt32(vecLine[21]);
			member.Num4=Convert.ToInt32(vecLine[22]);
			member.Attr5=Convert.ToInt32(vecLine[23]);
			member.Num5=Convert.ToInt32(vecLine[24]);
			member.Attr6=Convert.ToInt32(vecLine[25]);
			member.Num6=Convert.ToInt32(vecLine[26]);
			member.Sell=Convert.ToInt32(vecLine[27]);
			member.JuLing=Convert.ToInt32(vecLine[28]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
