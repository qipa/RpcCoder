using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//帮会升级配置数据类
public class BangHuiLvUpElement
{
	public int ID;               	//编号	成就ID
	public string Name;          	//建筑名称	建筑名称
	public int Type;             	//建筑类型	1大厅2库房3金库4练武堂
	public int MAX;              	//最大等级	最大等级
	public int Lv;               	//等级	等级
	public string Res;           	//建筑图标	建筑图标
	public int Money;            	//升级资金	升级资金
	public int Limit1;           	//限制1	限制1
	public int Limit2;           	//限制1	限制1
	public int XiaoHao;          	//每日消耗	每日消耗
	public int Function;         	//功能	1资金上限2成员上限3同时开启技能数量
	public int CanShu;           	//功能参数	功能参数
	public int Time;             	//升级时间	单位分钟
	public string FuliTips;      	//福利描述	
	public string LvUpTips;      	//升级描述	

	public bool IsValidate = false;
	public BangHuiLvUpElement()
	{
		ID = -1;
	}
};

//帮会升级配置封装类
public class BangHuiLvUpTable
{

	private BangHuiLvUpTable()
	{
		m_mapElements = new Dictionary<int, BangHuiLvUpElement>();
		m_emptyItem = new BangHuiLvUpElement();
		m_vecAllElements = new List<BangHuiLvUpElement>();
	}
	private Dictionary<int, BangHuiLvUpElement> m_mapElements = null;
	private List<BangHuiLvUpElement>	m_vecAllElements = null;
	private BangHuiLvUpElement m_emptyItem = null;
	private static BangHuiLvUpTable sInstance = null;

	public static BangHuiLvUpTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BangHuiLvUpTable();
			return sInstance;
		}
	}

	public BangHuiLvUpElement GetElement(int key)
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

  public List<BangHuiLvUpElement> GetAllElement(Predicate<BangHuiLvUpElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BangHuiLvUp.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BangHuiLvUp.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BangHuiLvUp.bin]未找到");
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
		if(vecLine.Count != 15)
		{
			Ex.Logger.Log("BangHuiLvUp.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BangHuiLvUp.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="MAX"){Ex.Logger.Log("BangHuiLvUp.csv中字段[MAX]位置不对应"); return false; }
		if(vecLine[4]!="Lv"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[5]!="Res"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[6]!="Money"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[7]!="Limit1"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Limit1]位置不对应"); return false; }
		if(vecLine[8]!="Limit2"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Limit2]位置不对应"); return false; }
		if(vecLine[9]!="XiaoHao"){Ex.Logger.Log("BangHuiLvUp.csv中字段[XiaoHao]位置不对应"); return false; }
		if(vecLine[10]!="Function"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Function]位置不对应"); return false; }
		if(vecLine[11]!="CanShu"){Ex.Logger.Log("BangHuiLvUp.csv中字段[CanShu]位置不对应"); return false; }
		if(vecLine[12]!="Time"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[13]!="FuliTips"){Ex.Logger.Log("BangHuiLvUp.csv中字段[FuliTips]位置不对应"); return false; }
		if(vecLine[14]!="LvUpTips"){Ex.Logger.Log("BangHuiLvUp.csv中字段[LvUpTips]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BangHuiLvUpElement member = new BangHuiLvUpElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MAX );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Limit1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Limit2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.XiaoHao );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Function );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CanShu );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Time );
			readPos += GameAssist.ReadString( binContent, readPos, out member.FuliTips);
			readPos += GameAssist.ReadString( binContent, readPos, out member.LvUpTips);

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
		if(vecLine.Count != 15)
		{
			Ex.Logger.Log("BangHuiLvUp.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BangHuiLvUp.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="MAX"){Ex.Logger.Log("BangHuiLvUp.csv中字段[MAX]位置不对应"); return false; }
		if(vecLine[4]!="Lv"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[5]!="Res"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[6]!="Money"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[7]!="Limit1"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Limit1]位置不对应"); return false; }
		if(vecLine[8]!="Limit2"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Limit2]位置不对应"); return false; }
		if(vecLine[9]!="XiaoHao"){Ex.Logger.Log("BangHuiLvUp.csv中字段[XiaoHao]位置不对应"); return false; }
		if(vecLine[10]!="Function"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Function]位置不对应"); return false; }
		if(vecLine[11]!="CanShu"){Ex.Logger.Log("BangHuiLvUp.csv中字段[CanShu]位置不对应"); return false; }
		if(vecLine[12]!="Time"){Ex.Logger.Log("BangHuiLvUp.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[13]!="FuliTips"){Ex.Logger.Log("BangHuiLvUp.csv中字段[FuliTips]位置不对应"); return false; }
		if(vecLine[14]!="LvUpTips"){Ex.Logger.Log("BangHuiLvUp.csv中字段[LvUpTips]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)15)
			{
				return false;
			}
			BangHuiLvUpElement member = new BangHuiLvUpElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Type=Convert.ToInt32(vecLine[2]);
			member.MAX=Convert.ToInt32(vecLine[3]);
			member.Lv=Convert.ToInt32(vecLine[4]);
			member.Res=vecLine[5];
			member.Money=Convert.ToInt32(vecLine[6]);
			member.Limit1=Convert.ToInt32(vecLine[7]);
			member.Limit2=Convert.ToInt32(vecLine[8]);
			member.XiaoHao=Convert.ToInt32(vecLine[9]);
			member.Function=Convert.ToInt32(vecLine[10]);
			member.CanShu=Convert.ToInt32(vecLine[11]);
			member.Time=Convert.ToInt32(vecLine[12]);
			member.FuliTips=vecLine[13];
			member.LvUpTips=vecLine[14];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
