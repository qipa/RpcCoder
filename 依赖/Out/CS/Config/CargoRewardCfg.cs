using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//货运奖励配置数据类
public class CargoRewardElement
{
	public int ID;               	//ID	ID
	public int Type;             	//类别	类别
	public int Lvl;              	//等级	等级
	public int EXP;              	//单项填充经验	单项填充经验
	public int Contribution;     	//单项填充贡献	单项填充贡献
	public int Money;            	//单项填充金钱	单项填充金钱
	public string MEXP;          	//总共填充经验	总共填充经验
	public string MContribution; 	//总共填充贡献	总共填充贡献
	public string MMoney;        	//总共填充金钱	总共填充金钱

	public bool IsValidate = false;
	public CargoRewardElement()
	{
		ID = -1;
	}
};

//货运奖励配置封装类
public class CargoRewardTable
{

	private CargoRewardTable()
	{
		m_mapElements = new Dictionary<int, CargoRewardElement>();
		m_emptyItem = new CargoRewardElement();
		m_vecAllElements = new List<CargoRewardElement>();
	}
	private Dictionary<int, CargoRewardElement> m_mapElements = null;
	private List<CargoRewardElement>	m_vecAllElements = null;
	private CargoRewardElement m_emptyItem = null;
	private static CargoRewardTable sInstance = null;

	public static CargoRewardTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new CargoRewardTable();
			return sInstance;
		}
	}

	public CargoRewardElement GetElement(int key)
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

  public List<CargoRewardElement> GetAllElement(Predicate<CargoRewardElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("CargoReward.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("CargoReward.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[CargoReward.bin]未找到");
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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("CargoReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CargoReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("CargoReward.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Lvl"){Ex.Logger.Log("CargoReward.csv中字段[Lvl]位置不对应"); return false; }
		if(vecLine[3]!="EXP"){Ex.Logger.Log("CargoReward.csv中字段[EXP]位置不对应"); return false; }
		if(vecLine[4]!="Contribution"){Ex.Logger.Log("CargoReward.csv中字段[Contribution]位置不对应"); return false; }
		if(vecLine[5]!="Money"){Ex.Logger.Log("CargoReward.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[6]!="MEXP"){Ex.Logger.Log("CargoReward.csv中字段[MEXP]位置不对应"); return false; }
		if(vecLine[7]!="MContribution"){Ex.Logger.Log("CargoReward.csv中字段[MContribution]位置不对应"); return false; }
		if(vecLine[8]!="MMoney"){Ex.Logger.Log("CargoReward.csv中字段[MMoney]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			CargoRewardElement member = new CargoRewardElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lvl );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EXP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Contribution );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MEXP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MContribution);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MMoney);

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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("CargoReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CargoReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("CargoReward.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Lvl"){Ex.Logger.Log("CargoReward.csv中字段[Lvl]位置不对应"); return false; }
		if(vecLine[3]!="EXP"){Ex.Logger.Log("CargoReward.csv中字段[EXP]位置不对应"); return false; }
		if(vecLine[4]!="Contribution"){Ex.Logger.Log("CargoReward.csv中字段[Contribution]位置不对应"); return false; }
		if(vecLine[5]!="Money"){Ex.Logger.Log("CargoReward.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[6]!="MEXP"){Ex.Logger.Log("CargoReward.csv中字段[MEXP]位置不对应"); return false; }
		if(vecLine[7]!="MContribution"){Ex.Logger.Log("CargoReward.csv中字段[MContribution]位置不对应"); return false; }
		if(vecLine[8]!="MMoney"){Ex.Logger.Log("CargoReward.csv中字段[MMoney]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)9)
			{
				return false;
			}
			CargoRewardElement member = new CargoRewardElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Type=Convert.ToInt32(vecLine[1]);
			member.Lvl=Convert.ToInt32(vecLine[2]);
			member.EXP=Convert.ToInt32(vecLine[3]);
			member.Contribution=Convert.ToInt32(vecLine[4]);
			member.Money=Convert.ToInt32(vecLine[5]);
			member.MEXP=vecLine[6];
			member.MContribution=vecLine[7];
			member.MMoney=vecLine[8];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
