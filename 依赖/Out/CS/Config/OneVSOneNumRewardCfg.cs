using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//每次挑战的奖励配置数据类
public class OneVSOneNumRewardElement
{
	public int ID;               	//编号	等级
	public int LV;               	//等级	等级
	public int StartNum;         	//起始次数	次数
	public int EndNum;           	//结束次数	结束次数
	public int Score;            	//分数	分数
	public int Experience;       	//经验	经验
	public int ItemID;           	//物品id	物品id
	public int ItemNum;          	//物品数量	物品数量

	public bool IsValidate = false;
	public OneVSOneNumRewardElement()
	{
		ID = -1;
	}
};

//每次挑战的奖励配置封装类
public class OneVSOneNumRewardTable
{

	private OneVSOneNumRewardTable()
	{
		m_mapElements = new Dictionary<int, OneVSOneNumRewardElement>();
		m_emptyItem = new OneVSOneNumRewardElement();
		m_vecAllElements = new List<OneVSOneNumRewardElement>();
	}
	private Dictionary<int, OneVSOneNumRewardElement> m_mapElements = null;
	private List<OneVSOneNumRewardElement>	m_vecAllElements = null;
	private OneVSOneNumRewardElement m_emptyItem = null;
	private static OneVSOneNumRewardTable sInstance = null;

	public static OneVSOneNumRewardTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new OneVSOneNumRewardTable();
			return sInstance;
		}
	}

	public OneVSOneNumRewardElement GetElement(int key)
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

  public List<OneVSOneNumRewardElement> GetAllElement(Predicate<OneVSOneNumRewardElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("OneVSOneNumReward.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("OneVSOneNumReward.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[OneVSOneNumReward.bin]未找到");
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
		if(vecLine.Count != 8)
		{
			Ex.Logger.Log("OneVSOneNumReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="LV"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[2]!="StartNum"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[StartNum]位置不对应"); return false; }
		if(vecLine[3]!="EndNum"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[EndNum]位置不对应"); return false; }
		if(vecLine[4]!="Score"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[Score]位置不对应"); return false; }
		if(vecLine[5]!="Experience"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[Experience]位置不对应"); return false; }
		if(vecLine[6]!="ItemID"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[7]!="ItemNum"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[ItemNum]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			OneVSOneNumRewardElement member = new OneVSOneNumRewardElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LV );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.StartNum );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EndNum );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Score );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Experience );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum );

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
		if(vecLine.Count != 8)
		{
			Ex.Logger.Log("OneVSOneNumReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="LV"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[2]!="StartNum"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[StartNum]位置不对应"); return false; }
		if(vecLine[3]!="EndNum"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[EndNum]位置不对应"); return false; }
		if(vecLine[4]!="Score"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[Score]位置不对应"); return false; }
		if(vecLine[5]!="Experience"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[Experience]位置不对应"); return false; }
		if(vecLine[6]!="ItemID"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[7]!="ItemNum"){Ex.Logger.Log("OneVSOneNumReward.csv中字段[ItemNum]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)8)
			{
				return false;
			}
			OneVSOneNumRewardElement member = new OneVSOneNumRewardElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.LV=Convert.ToInt32(vecLine[1]);
			member.StartNum=Convert.ToInt32(vecLine[2]);
			member.EndNum=Convert.ToInt32(vecLine[3]);
			member.Score=Convert.ToInt32(vecLine[4]);
			member.Experience=Convert.ToInt32(vecLine[5]);
			member.ItemID=Convert.ToInt32(vecLine[6]);
			member.ItemNum=Convert.ToInt32(vecLine[7]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
