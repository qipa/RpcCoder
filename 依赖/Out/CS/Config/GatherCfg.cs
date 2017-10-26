using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//采集物配置数据类
public class GatherElement
{
	public int GatherID;         	//ID	排序ID
	public string Name;          	//采集物名称	采集物的名字
	public string Title;         	//采集物称号	采集物的称号
	public int Type;             	//采集物类型	1_草药，2_矿石，3_鱼塘
	public int ModelID;          	//模型ID	引用模型表数据
	public float ModelScaling;   	//模型缩放	采集物模型缩放
	public int Condition;        	//采集条件	-1_永久，1_任务，2_活动，3_状态
	public int Item;             	//产出物	索引ItemID
	public int Duration;         	//采集时长	采集该采集物一个所消耗时长，单位s
	public int Break;            	//可否被打断	1可以，-1不可以
	public int Times;            	//采集次数	-1_无限，可采集几次填几次
	public int Relive;           	//复活间隔	消失后再次刷新所需时间，单位s
	public float GatherR;        	//触发半径	可以触发采集动作的范围，单位:m
	public int ChangJing;        	//场景ID	场景ID
	public int Skill;            	//动作ID	动作ID

	public bool IsValidate = false;
	public GatherElement()
	{
		GatherID = -1;
	}
};

//采集物配置封装类
public class GatherTable
{

	private GatherTable()
	{
		m_mapElements = new Dictionary<int, GatherElement>();
		m_emptyItem = new GatherElement();
		m_vecAllElements = new List<GatherElement>();
	}
	private Dictionary<int, GatherElement> m_mapElements = null;
	private List<GatherElement>	m_vecAllElements = null;
	private GatherElement m_emptyItem = null;
	private static GatherTable sInstance = null;

	public static GatherTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new GatherTable();
			return sInstance;
		}
	}

	public GatherElement GetElement(int key)
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

  public List<GatherElement> GetAllElement(Predicate<GatherElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Gather.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Gather.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Gather.bin]未找到");
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
			Ex.Logger.Log("Gather.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="GatherID"){Ex.Logger.Log("Gather.csv中字段[GatherID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Gather.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Title"){Ex.Logger.Log("Gather.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Gather.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="ModelID"){Ex.Logger.Log("Gather.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[5]!="ModelScaling"){Ex.Logger.Log("Gather.csv中字段[ModelScaling]位置不对应"); return false; }
		if(vecLine[6]!="Condition"){Ex.Logger.Log("Gather.csv中字段[Condition]位置不对应"); return false; }
		if(vecLine[7]!="Item"){Ex.Logger.Log("Gather.csv中字段[Item]位置不对应"); return false; }
		if(vecLine[8]!="Duration"){Ex.Logger.Log("Gather.csv中字段[Duration]位置不对应"); return false; }
		if(vecLine[9]!="Break"){Ex.Logger.Log("Gather.csv中字段[Break]位置不对应"); return false; }
		if(vecLine[10]!="Times"){Ex.Logger.Log("Gather.csv中字段[Times]位置不对应"); return false; }
		if(vecLine[11]!="Relive"){Ex.Logger.Log("Gather.csv中字段[Relive]位置不对应"); return false; }
		if(vecLine[12]!="GatherR"){Ex.Logger.Log("Gather.csv中字段[GatherR]位置不对应"); return false; }
		if(vecLine[13]!="ChangJing"){Ex.Logger.Log("Gather.csv中字段[ChangJing]位置不对应"); return false; }
		if(vecLine[14]!="Skill"){Ex.Logger.Log("Gather.csv中字段[Skill]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			GatherElement member = new GatherElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GatherID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Title);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.ModelScaling);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Condition );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Duration );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Break );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Times );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Relive );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.GatherR);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ChangJing );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Skill );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.GatherID] = member;
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
			Ex.Logger.Log("Gather.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="GatherID"){Ex.Logger.Log("Gather.csv中字段[GatherID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Gather.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Title"){Ex.Logger.Log("Gather.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Gather.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="ModelID"){Ex.Logger.Log("Gather.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[5]!="ModelScaling"){Ex.Logger.Log("Gather.csv中字段[ModelScaling]位置不对应"); return false; }
		if(vecLine[6]!="Condition"){Ex.Logger.Log("Gather.csv中字段[Condition]位置不对应"); return false; }
		if(vecLine[7]!="Item"){Ex.Logger.Log("Gather.csv中字段[Item]位置不对应"); return false; }
		if(vecLine[8]!="Duration"){Ex.Logger.Log("Gather.csv中字段[Duration]位置不对应"); return false; }
		if(vecLine[9]!="Break"){Ex.Logger.Log("Gather.csv中字段[Break]位置不对应"); return false; }
		if(vecLine[10]!="Times"){Ex.Logger.Log("Gather.csv中字段[Times]位置不对应"); return false; }
		if(vecLine[11]!="Relive"){Ex.Logger.Log("Gather.csv中字段[Relive]位置不对应"); return false; }
		if(vecLine[12]!="GatherR"){Ex.Logger.Log("Gather.csv中字段[GatherR]位置不对应"); return false; }
		if(vecLine[13]!="ChangJing"){Ex.Logger.Log("Gather.csv中字段[ChangJing]位置不对应"); return false; }
		if(vecLine[14]!="Skill"){Ex.Logger.Log("Gather.csv中字段[Skill]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)15)
			{
				return false;
			}
			GatherElement member = new GatherElement();
			member.GatherID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Title=vecLine[2];
			member.Type=Convert.ToInt32(vecLine[3]);
			member.ModelID=Convert.ToInt32(vecLine[4]);
			member.ModelScaling=Convert.ToSingle(vecLine[5]);
			member.Condition=Convert.ToInt32(vecLine[6]);
			member.Item=Convert.ToInt32(vecLine[7]);
			member.Duration=Convert.ToInt32(vecLine[8]);
			member.Break=Convert.ToInt32(vecLine[9]);
			member.Times=Convert.ToInt32(vecLine[10]);
			member.Relive=Convert.ToInt32(vecLine[11]);
			member.GatherR=Convert.ToSingle(vecLine[12]);
			member.ChangJing=Convert.ToInt32(vecLine[13]);
			member.Skill=Convert.ToInt32(vecLine[14]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.GatherID] = member;
		}
		return true;
	}
};
