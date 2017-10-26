using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//法宝炼星表配置数据类
public class FaBaoStarElement
{
	public int ID;               	//编号	法宝ID
	public int SuiPian1;         	//2星消耗碎片	3星消耗碎片
	public int Money1;           	//2星消耗金钱	2星消耗金钱
	public int Rate1;            	//2星成长倍率	2星成长倍率
	public int SuiPian2;         	//3星消耗碎片	4星消耗碎片
	public int Money2;           	//3星消耗金钱	3星消耗金钱
	public int Rate2;            	//3星成长倍率	3星成长倍率
	public int SuiPian3;         	//4星消耗碎片	5星消耗碎片
	public int Money3;           	//4星消耗金钱	4星消耗金钱
	public int Rate3;            	//4星成长倍率	4星成长倍率
	public int SuiPian4;         	//5星消耗碎片	6星消耗碎片
	public int Money4;           	//5星消耗金钱	5星消耗金钱
	public int Rate4;            	//5星成长倍率	5星成长倍率
	public int SuiPian5;         	//6星消耗碎片	7星消耗碎片
	public int Money5;           	//6星消耗金钱	6星消耗金钱
	public int Rate5;            	//6星成长倍率	6星成长倍率
	public int SuiPian6;         	//7星消耗碎片	8星消耗碎片
	public int Money6;           	//7星消耗金钱	7星消耗金钱
	public int Rate6;            	//7星成长倍率	7星成长倍率

	public bool IsValidate = false;
	public FaBaoStarElement()
	{
		ID = -1;
	}
};

//法宝炼星表配置封装类
public class FaBaoStarTable
{

	private FaBaoStarTable()
	{
		m_mapElements = new Dictionary<int, FaBaoStarElement>();
		m_emptyItem = new FaBaoStarElement();
		m_vecAllElements = new List<FaBaoStarElement>();
	}
	private Dictionary<int, FaBaoStarElement> m_mapElements = null;
	private List<FaBaoStarElement>	m_vecAllElements = null;
	private FaBaoStarElement m_emptyItem = null;
	private static FaBaoStarTable sInstance = null;

	public static FaBaoStarTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FaBaoStarTable();
			return sInstance;
		}
	}

	public FaBaoStarElement GetElement(int key)
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

  public List<FaBaoStarElement> GetAllElement(Predicate<FaBaoStarElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("FaBaoStar.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("FaBaoStar.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[FaBaoStar.bin]未找到");
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
		if(vecLine.Count != 19)
		{
			Ex.Logger.Log("FaBaoStar.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FaBaoStar.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SuiPian1"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian1]位置不对应"); return false; }
		if(vecLine[2]!="Money1"){Ex.Logger.Log("FaBaoStar.csv中字段[Money1]位置不对应"); return false; }
		if(vecLine[3]!="Rate1"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate1]位置不对应"); return false; }
		if(vecLine[4]!="SuiPian2"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian2]位置不对应"); return false; }
		if(vecLine[5]!="Money2"){Ex.Logger.Log("FaBaoStar.csv中字段[Money2]位置不对应"); return false; }
		if(vecLine[6]!="Rate2"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate2]位置不对应"); return false; }
		if(vecLine[7]!="SuiPian3"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian3]位置不对应"); return false; }
		if(vecLine[8]!="Money3"){Ex.Logger.Log("FaBaoStar.csv中字段[Money3]位置不对应"); return false; }
		if(vecLine[9]!="Rate3"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate3]位置不对应"); return false; }
		if(vecLine[10]!="SuiPian4"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian4]位置不对应"); return false; }
		if(vecLine[11]!="Money4"){Ex.Logger.Log("FaBaoStar.csv中字段[Money4]位置不对应"); return false; }
		if(vecLine[12]!="Rate4"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate4]位置不对应"); return false; }
		if(vecLine[13]!="SuiPian5"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian5]位置不对应"); return false; }
		if(vecLine[14]!="Money5"){Ex.Logger.Log("FaBaoStar.csv中字段[Money5]位置不对应"); return false; }
		if(vecLine[15]!="Rate5"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate5]位置不对应"); return false; }
		if(vecLine[16]!="SuiPian6"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian6]位置不对应"); return false; }
		if(vecLine[17]!="Money6"){Ex.Logger.Log("FaBaoStar.csv中字段[Money6]位置不对应"); return false; }
		if(vecLine[18]!="Rate6"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate6]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FaBaoStarElement member = new FaBaoStarElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Rate1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Rate2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Rate3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Rate4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Rate5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SuiPian6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Rate6 );

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
		if(vecLine.Count != 19)
		{
			Ex.Logger.Log("FaBaoStar.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("FaBaoStar.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SuiPian1"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian1]位置不对应"); return false; }
		if(vecLine[2]!="Money1"){Ex.Logger.Log("FaBaoStar.csv中字段[Money1]位置不对应"); return false; }
		if(vecLine[3]!="Rate1"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate1]位置不对应"); return false; }
		if(vecLine[4]!="SuiPian2"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian2]位置不对应"); return false; }
		if(vecLine[5]!="Money2"){Ex.Logger.Log("FaBaoStar.csv中字段[Money2]位置不对应"); return false; }
		if(vecLine[6]!="Rate2"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate2]位置不对应"); return false; }
		if(vecLine[7]!="SuiPian3"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian3]位置不对应"); return false; }
		if(vecLine[8]!="Money3"){Ex.Logger.Log("FaBaoStar.csv中字段[Money3]位置不对应"); return false; }
		if(vecLine[9]!="Rate3"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate3]位置不对应"); return false; }
		if(vecLine[10]!="SuiPian4"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian4]位置不对应"); return false; }
		if(vecLine[11]!="Money4"){Ex.Logger.Log("FaBaoStar.csv中字段[Money4]位置不对应"); return false; }
		if(vecLine[12]!="Rate4"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate4]位置不对应"); return false; }
		if(vecLine[13]!="SuiPian5"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian5]位置不对应"); return false; }
		if(vecLine[14]!="Money5"){Ex.Logger.Log("FaBaoStar.csv中字段[Money5]位置不对应"); return false; }
		if(vecLine[15]!="Rate5"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate5]位置不对应"); return false; }
		if(vecLine[16]!="SuiPian6"){Ex.Logger.Log("FaBaoStar.csv中字段[SuiPian6]位置不对应"); return false; }
		if(vecLine[17]!="Money6"){Ex.Logger.Log("FaBaoStar.csv中字段[Money6]位置不对应"); return false; }
		if(vecLine[18]!="Rate6"){Ex.Logger.Log("FaBaoStar.csv中字段[Rate6]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)19)
			{
				return false;
			}
			FaBaoStarElement member = new FaBaoStarElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.SuiPian1=Convert.ToInt32(vecLine[1]);
			member.Money1=Convert.ToInt32(vecLine[2]);
			member.Rate1=Convert.ToInt32(vecLine[3]);
			member.SuiPian2=Convert.ToInt32(vecLine[4]);
			member.Money2=Convert.ToInt32(vecLine[5]);
			member.Rate2=Convert.ToInt32(vecLine[6]);
			member.SuiPian3=Convert.ToInt32(vecLine[7]);
			member.Money3=Convert.ToInt32(vecLine[8]);
			member.Rate3=Convert.ToInt32(vecLine[9]);
			member.SuiPian4=Convert.ToInt32(vecLine[10]);
			member.Money4=Convert.ToInt32(vecLine[11]);
			member.Rate4=Convert.ToInt32(vecLine[12]);
			member.SuiPian5=Convert.ToInt32(vecLine[13]);
			member.Money5=Convert.ToInt32(vecLine[14]);
			member.Rate5=Convert.ToInt32(vecLine[15]);
			member.SuiPian6=Convert.ToInt32(vecLine[16]);
			member.Money6=Convert.ToInt32(vecLine[17]);
			member.Rate6=Convert.ToInt32(vecLine[18]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
