using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//奖励表配置数据类
public class RewardElement
{
	public int RewardID;         	//奖励ID	奖励ID
	public int Item1;            	//道具1	道具1
	public int ItemNum1;         	//道具1数量	道具1数量
	public int Item2;            	//道具2	道具2
	public int ItemNum2;         	//道具2数量	道具2数量
	public int Item3;            	//道具3	道具3
	public int ItemNum3;         	//道具3数量	道具3数量
	public int Item4;            	//道具4	道具4
	public int ItemNum4;         	//道具4数量	道具4数量
	public int Item5;            	//道具5	道具5
	public int ItemNum5;         	//道具5数量	道具5数量

	public bool IsValidate = false;
	public RewardElement()
	{
		RewardID = -1;
	}
};

//奖励表配置封装类
public class RewardTable
{

	private RewardTable()
	{
		m_mapElements = new Dictionary<int, RewardElement>();
		m_emptyItem = new RewardElement();
		m_vecAllElements = new List<RewardElement>();
	}
	private Dictionary<int, RewardElement> m_mapElements = null;
	private List<RewardElement>	m_vecAllElements = null;
	private RewardElement m_emptyItem = null;
	private static RewardTable sInstance = null;

	public static RewardTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new RewardTable();
			return sInstance;
		}
	}

	public RewardElement GetElement(int key)
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

  public List<RewardElement> GetAllElement(Predicate<RewardElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Reward.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Reward.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Reward.bin]未找到");
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
		if(vecLine.Count != 11)
		{
			Ex.Logger.Log("Reward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="RewardID"){Ex.Logger.Log("Reward.csv中字段[RewardID]位置不对应"); return false; }
		if(vecLine[1]!="Item1"){Ex.Logger.Log("Reward.csv中字段[Item1]位置不对应"); return false; }
		if(vecLine[2]!="ItemNum1"){Ex.Logger.Log("Reward.csv中字段[ItemNum1]位置不对应"); return false; }
		if(vecLine[3]!="Item2"){Ex.Logger.Log("Reward.csv中字段[Item2]位置不对应"); return false; }
		if(vecLine[4]!="ItemNum2"){Ex.Logger.Log("Reward.csv中字段[ItemNum2]位置不对应"); return false; }
		if(vecLine[5]!="Item3"){Ex.Logger.Log("Reward.csv中字段[Item3]位置不对应"); return false; }
		if(vecLine[6]!="ItemNum3"){Ex.Logger.Log("Reward.csv中字段[ItemNum3]位置不对应"); return false; }
		if(vecLine[7]!="Item4"){Ex.Logger.Log("Reward.csv中字段[Item4]位置不对应"); return false; }
		if(vecLine[8]!="ItemNum4"){Ex.Logger.Log("Reward.csv中字段[ItemNum4]位置不对应"); return false; }
		if(vecLine[9]!="Item5"){Ex.Logger.Log("Reward.csv中字段[Item5]位置不对应"); return false; }
		if(vecLine[10]!="ItemNum5"){Ex.Logger.Log("Reward.csv中字段[ItemNum5]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			RewardElement member = new RewardElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RewardID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum4 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item5 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum5 );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.RewardID] = member;
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
		if(vecLine.Count != 11)
		{
			Ex.Logger.Log("Reward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="RewardID"){Ex.Logger.Log("Reward.csv中字段[RewardID]位置不对应"); return false; }
		if(vecLine[1]!="Item1"){Ex.Logger.Log("Reward.csv中字段[Item1]位置不对应"); return false; }
		if(vecLine[2]!="ItemNum1"){Ex.Logger.Log("Reward.csv中字段[ItemNum1]位置不对应"); return false; }
		if(vecLine[3]!="Item2"){Ex.Logger.Log("Reward.csv中字段[Item2]位置不对应"); return false; }
		if(vecLine[4]!="ItemNum2"){Ex.Logger.Log("Reward.csv中字段[ItemNum2]位置不对应"); return false; }
		if(vecLine[5]!="Item3"){Ex.Logger.Log("Reward.csv中字段[Item3]位置不对应"); return false; }
		if(vecLine[6]!="ItemNum3"){Ex.Logger.Log("Reward.csv中字段[ItemNum3]位置不对应"); return false; }
		if(vecLine[7]!="Item4"){Ex.Logger.Log("Reward.csv中字段[Item4]位置不对应"); return false; }
		if(vecLine[8]!="ItemNum4"){Ex.Logger.Log("Reward.csv中字段[ItemNum4]位置不对应"); return false; }
		if(vecLine[9]!="Item5"){Ex.Logger.Log("Reward.csv中字段[Item5]位置不对应"); return false; }
		if(vecLine[10]!="ItemNum5"){Ex.Logger.Log("Reward.csv中字段[ItemNum5]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)11)
			{
				return false;
			}
			RewardElement member = new RewardElement();
			member.RewardID=Convert.ToInt32(vecLine[0]);
			member.Item1=Convert.ToInt32(vecLine[1]);
			member.ItemNum1=Convert.ToInt32(vecLine[2]);
			member.Item2=Convert.ToInt32(vecLine[3]);
			member.ItemNum2=Convert.ToInt32(vecLine[4]);
			member.Item3=Convert.ToInt32(vecLine[5]);
			member.ItemNum3=Convert.ToInt32(vecLine[6]);
			member.Item4=Convert.ToInt32(vecLine[7]);
			member.ItemNum4=Convert.ToInt32(vecLine[8]);
			member.Item5=Convert.ToInt32(vecLine[9]);
			member.ItemNum5=Convert.ToInt32(vecLine[10]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.RewardID] = member;
		}
		return true;
	}
};
