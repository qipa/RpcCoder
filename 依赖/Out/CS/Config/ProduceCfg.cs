using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//生活技能产出表配置数据类
public class ProduceElement
{
	public int ID;               	//编号	编号
	public int ProduceID;        	//生产道具ID	生产道具ID
	public int LifeSkills;       	//所属生活技能类型	所属生活技能类型（1采集2种植3钓鱼4饲养5炼药6烹饪）
	public int UnlockLevel ;     	//解锁等级	解锁等级
	public int EnergyConsumption;	//活力消耗	活力消耗
	public int Type;             	//获取类型	获取类型（1采集2配方制作）
	public string Data;          	//数据	采集类为坐标，生产类为材料道具ID
	public int Time;             	//生产时间	生产时间
	public int Capacity1;        	//产出数量	产出数量
	public int ZSSpecific;       	//战士特有产出	战士特有产出
	public int Capacity2;        	//产出数量	产出数量
	public int Probability1;     	//概率	概率
	public int FSSpecific;       	//法师特有产出	法师特有产出
	public int Capacity3;        	//产出数量	产出数量
	public int Probability2;     	//概率	概率
	public int GJSpecific;       	//弓手特有产出	弓手特有产出
	public int Capacity4;        	//产出数量	产出数量
	public int Probability3;     	//概率	概率
	public int QSSpecific;       	//拳师特有产出	拳师特有产出
	public int Capacity5;        	//产出数量	产出数量
	public int Probability4;     	//概率	概率
	public int MSSpecific;       	//牧师特有产出	牧师特有产出
	public int Capacity6;        	//产出数量	产出数量
	public int Probability5;     	//概率	概率

	public bool IsValidate = false;
	public ProduceElement()
	{
		ID = -1;
	}
};

//生活技能产出表配置封装类
public class ProduceTable
{

	private ProduceTable()
	{
		m_mapElements = new Dictionary<int, ProduceElement>();
		m_emptyItem = new ProduceElement();
		m_vecAllElements = new List<ProduceElement>();
	}
	private Dictionary<int, ProduceElement> m_mapElements = null;
	private List<ProduceElement>	m_vecAllElements = null;
	private ProduceElement m_emptyItem = null;
	private static ProduceTable sInstance = null;

	public static ProduceTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ProduceTable();
			return sInstance;
		}
	}

	public ProduceElement GetElement(int key)
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

  public List<ProduceElement> GetAllElement(Predicate<ProduceElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Produce.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Produce.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Produce.bin]未找到");
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
		if(vecLine.Count != 24)
		{
			Ex.Logger.Log("Produce.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Produce.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ProduceID"){Ex.Logger.Log("Produce.csv中字段[ProduceID]位置不对应"); return false; }
		if(vecLine[2]!="LifeSkills"){Ex.Logger.Log("Produce.csv中字段[LifeSkills]位置不对应"); return false; }
		if(vecLine[3]!="UnlockLevel "){Ex.Logger.Log("Produce.csv中字段[UnlockLevel ]位置不对应"); return false; }
		if(vecLine[4]!="EnergyConsumption"){Ex.Logger.Log("Produce.csv中字段[EnergyConsumption]位置不对应"); return false; }
		if(vecLine[5]!="Type"){Ex.Logger.Log("Produce.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[6]!="Data"){Ex.Logger.Log("Produce.csv中字段[Data]位置不对应"); return false; }
		if(vecLine[7]!="Time"){Ex.Logger.Log("Produce.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[8]!="Capacity1"){Ex.Logger.Log("Produce.csv中字段[Capacity1]位置不对应"); return false; }
		if(vecLine[9]!="ZSSpecific"){Ex.Logger.Log("Produce.csv中字段[ZSSpecific]位置不对应"); return false; }
		if(vecLine[10]!="Capacity2"){Ex.Logger.Log("Produce.csv中字段[Capacity2]位置不对应"); return false; }
		if(vecLine[11]!="Probability1"){Ex.Logger.Log("Produce.csv中字段[Probability1]位置不对应"); return false; }
		if(vecLine[12]!="FSSpecific"){Ex.Logger.Log("Produce.csv中字段[FSSpecific]位置不对应"); return false; }
		if(vecLine[13]!="Capacity3"){Ex.Logger.Log("Produce.csv中字段[Capacity3]位置不对应"); return false; }
		if(vecLine[14]!="Probability2"){Ex.Logger.Log("Produce.csv中字段[Probability2]位置不对应"); return false; }
		if(vecLine[15]!="GJSpecific"){Ex.Logger.Log("Produce.csv中字段[GJSpecific]位置不对应"); return false; }
		if(vecLine[16]!="Capacity4"){Ex.Logger.Log("Produce.csv中字段[Capacity4]位置不对应"); return false; }
		if(vecLine[17]!="Probability3"){Ex.Logger.Log("Produce.csv中字段[Probability3]位置不对应"); return false; }
		if(vecLine[18]!="QSSpecific"){Ex.Logger.Log("Produce.csv中字段[QSSpecific]位置不对应"); return false; }
		if(vecLine[19]!="Capacity5"){Ex.Logger.Log("Produce.csv中字段[Capacity5]位置不对应"); return false; }
		if(vecLine[20]!="Probability4"){Ex.Logger.Log("Produce.csv中字段[Probability4]位置不对应"); return false; }
		if(vecLine[21]!="MSSpecific"){Ex.Logger.Log("Produce.csv中字段[MSSpecific]位置不对应"); return false; }
		if(vecLine[22]!="Capacity6"){Ex.Logger.Log("Produce.csv中字段[Capacity6]位置不对应"); return false; }
		if(vecLine[23]!="Probability5"){Ex.Logger.Log("Produce.csv中字段[Probability5]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ProduceElement member = new ProduceElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ProduceID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LifeSkills );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.UnlockLevel  );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EnergyConsumption );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Data);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Time );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Capacity1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ZSSpecific );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Capacity2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Probability1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FSSpecific );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Capacity3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Probability2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GJSpecific );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Capacity4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Probability3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.QSSpecific );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Capacity5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Probability4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MSSpecific );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Capacity6 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Probability5 );

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
		if(vecLine.Count != 24)
		{
			Ex.Logger.Log("Produce.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Produce.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ProduceID"){Ex.Logger.Log("Produce.csv中字段[ProduceID]位置不对应"); return false; }
		if(vecLine[2]!="LifeSkills"){Ex.Logger.Log("Produce.csv中字段[LifeSkills]位置不对应"); return false; }
		if(vecLine[3]!="UnlockLevel "){Ex.Logger.Log("Produce.csv中字段[UnlockLevel ]位置不对应"); return false; }
		if(vecLine[4]!="EnergyConsumption"){Ex.Logger.Log("Produce.csv中字段[EnergyConsumption]位置不对应"); return false; }
		if(vecLine[5]!="Type"){Ex.Logger.Log("Produce.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[6]!="Data"){Ex.Logger.Log("Produce.csv中字段[Data]位置不对应"); return false; }
		if(vecLine[7]!="Time"){Ex.Logger.Log("Produce.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[8]!="Capacity1"){Ex.Logger.Log("Produce.csv中字段[Capacity1]位置不对应"); return false; }
		if(vecLine[9]!="ZSSpecific"){Ex.Logger.Log("Produce.csv中字段[ZSSpecific]位置不对应"); return false; }
		if(vecLine[10]!="Capacity2"){Ex.Logger.Log("Produce.csv中字段[Capacity2]位置不对应"); return false; }
		if(vecLine[11]!="Probability1"){Ex.Logger.Log("Produce.csv中字段[Probability1]位置不对应"); return false; }
		if(vecLine[12]!="FSSpecific"){Ex.Logger.Log("Produce.csv中字段[FSSpecific]位置不对应"); return false; }
		if(vecLine[13]!="Capacity3"){Ex.Logger.Log("Produce.csv中字段[Capacity3]位置不对应"); return false; }
		if(vecLine[14]!="Probability2"){Ex.Logger.Log("Produce.csv中字段[Probability2]位置不对应"); return false; }
		if(vecLine[15]!="GJSpecific"){Ex.Logger.Log("Produce.csv中字段[GJSpecific]位置不对应"); return false; }
		if(vecLine[16]!="Capacity4"){Ex.Logger.Log("Produce.csv中字段[Capacity4]位置不对应"); return false; }
		if(vecLine[17]!="Probability3"){Ex.Logger.Log("Produce.csv中字段[Probability3]位置不对应"); return false; }
		if(vecLine[18]!="QSSpecific"){Ex.Logger.Log("Produce.csv中字段[QSSpecific]位置不对应"); return false; }
		if(vecLine[19]!="Capacity5"){Ex.Logger.Log("Produce.csv中字段[Capacity5]位置不对应"); return false; }
		if(vecLine[20]!="Probability4"){Ex.Logger.Log("Produce.csv中字段[Probability4]位置不对应"); return false; }
		if(vecLine[21]!="MSSpecific"){Ex.Logger.Log("Produce.csv中字段[MSSpecific]位置不对应"); return false; }
		if(vecLine[22]!="Capacity6"){Ex.Logger.Log("Produce.csv中字段[Capacity6]位置不对应"); return false; }
		if(vecLine[23]!="Probability5"){Ex.Logger.Log("Produce.csv中字段[Probability5]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)24)
			{
				return false;
			}
			ProduceElement member = new ProduceElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.ProduceID=Convert.ToInt32(vecLine[1]);
			member.LifeSkills=Convert.ToInt32(vecLine[2]);
			member.UnlockLevel =Convert.ToInt32(vecLine[3]);
			member.EnergyConsumption=Convert.ToInt32(vecLine[4]);
			member.Type=Convert.ToInt32(vecLine[5]);
			member.Data=vecLine[6];
			member.Time=Convert.ToInt32(vecLine[7]);
			member.Capacity1=Convert.ToInt32(vecLine[8]);
			member.ZSSpecific=Convert.ToInt32(vecLine[9]);
			member.Capacity2=Convert.ToInt32(vecLine[10]);
			member.Probability1=Convert.ToInt32(vecLine[11]);
			member.FSSpecific=Convert.ToInt32(vecLine[12]);
			member.Capacity3=Convert.ToInt32(vecLine[13]);
			member.Probability2=Convert.ToInt32(vecLine[14]);
			member.GJSpecific=Convert.ToInt32(vecLine[15]);
			member.Capacity4=Convert.ToInt32(vecLine[16]);
			member.Probability3=Convert.ToInt32(vecLine[17]);
			member.QSSpecific=Convert.ToInt32(vecLine[18]);
			member.Capacity5=Convert.ToInt32(vecLine[19]);
			member.Probability4=Convert.ToInt32(vecLine[20]);
			member.MSSpecific=Convert.ToInt32(vecLine[21]);
			member.Capacity6=Convert.ToInt32(vecLine[22]);
			member.Probability5=Convert.ToInt32(vecLine[23]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
