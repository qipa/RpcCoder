using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//师门奖励表配置数据类
public class ShimenRewardElement
{
	public int ID;               	//编号	仅仅是序号
	public int Lvl;              	//等级	玩家的等级
	public int Res;              	//环数	每轮的环数
	public int ExpReward;        	//经验	经验奖励
	public int MoneyReward;      	//金钱	金钱奖励
	public int SpecialRewardId;  	//特殊奖励	特殊奖励的掉落列ID
	public int SpecialRewardPro; 	//特殊奖励概率	特殊奖励概率万分比

	public bool IsValidate = false;
	public ShimenRewardElement()
	{
		ID = -1;
	}
};

//师门奖励表配置封装类
public class ShimenRewardTable
{

	private ShimenRewardTable()
	{
		m_mapElements = new Dictionary<int, ShimenRewardElement>();
		m_emptyItem = new ShimenRewardElement();
		m_vecAllElements = new List<ShimenRewardElement>();
	}
	private Dictionary<int, ShimenRewardElement> m_mapElements = null;
	private List<ShimenRewardElement>	m_vecAllElements = null;
	private ShimenRewardElement m_emptyItem = null;
	private static ShimenRewardTable sInstance = null;

	public static ShimenRewardTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ShimenRewardTable();
			return sInstance;
		}
	}

	public ShimenRewardElement GetElement(int key)
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

  public List<ShimenRewardElement> GetAllElement(Predicate<ShimenRewardElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("ShimenReward.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("ShimenReward.bin", out binTableContent ) )
		{
			Debug.Log("配置文件[ShimenReward.bin]未找到");
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
		if(vecLine.Count != 7)
		{
			Debug.Log("ShimenReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("ShimenReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Lvl"){Debug.Log("ShimenReward.csv中字段[Lvl]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Debug.Log("ShimenReward.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="ExpReward"){Debug.Log("ShimenReward.csv中字段[ExpReward]位置不对应"); return false; }
		if(vecLine[4]!="MoneyReward"){Debug.Log("ShimenReward.csv中字段[MoneyReward]位置不对应"); return false; }
		if(vecLine[5]!="SpecialRewardId"){Debug.Log("ShimenReward.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[6]!="SpecialRewardPro"){Debug.Log("ShimenReward.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ShimenRewardElement member = new ShimenRewardElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lvl );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Res );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ExpReward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyReward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SpecialRewardId );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SpecialRewardPro );

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
		if(vecLine.Count != 7)
		{
			Debug.Log("ShimenReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("ShimenReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Lvl"){Debug.Log("ShimenReward.csv中字段[Lvl]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Debug.Log("ShimenReward.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="ExpReward"){Debug.Log("ShimenReward.csv中字段[ExpReward]位置不对应"); return false; }
		if(vecLine[4]!="MoneyReward"){Debug.Log("ShimenReward.csv中字段[MoneyReward]位置不对应"); return false; }
		if(vecLine[5]!="SpecialRewardId"){Debug.Log("ShimenReward.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[6]!="SpecialRewardPro"){Debug.Log("ShimenReward.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)7)
			{
				return false;
			}
			ShimenRewardElement member = new ShimenRewardElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Lvl=Convert.ToInt32(vecLine[1]);
			member.Res=Convert.ToInt32(vecLine[2]);
			member.ExpReward=Convert.ToInt32(vecLine[3]);
			member.MoneyReward=Convert.ToInt32(vecLine[4]);
			member.SpecialRewardId=Convert.ToInt32(vecLine[5]);
			member.SpecialRewardPro=Convert.ToInt32(vecLine[6]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
