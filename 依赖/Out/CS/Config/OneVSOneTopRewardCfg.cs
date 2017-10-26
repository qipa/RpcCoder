using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//排名奖励配置数据类
public class OneVSOneTopRewardElement
{
	public int ID;               	//编号	等级
	public int StartTop;         	//起始名词	起始名词
	public int EndTop;           	//结束名次	结束名次
	public int Type;             	//分组类别	分组类别0总榜其他序号对应分组表中的ID
	public int Score;            	//分数	分数
	public int Experience;       	//经验	经验
	public int ItemID;           	//物品id	物品id
	public int ItemNum;          	//物品数量	物品数量

	public bool IsValidate = false;
	public OneVSOneTopRewardElement()
	{
		ID = -1;
	}
};

//排名奖励配置封装类
public class OneVSOneTopRewardTable
{

	private OneVSOneTopRewardTable()
	{
		m_mapElements = new Dictionary<int, OneVSOneTopRewardElement>();
		m_emptyItem = new OneVSOneTopRewardElement();
		m_vecAllElements = new List<OneVSOneTopRewardElement>();
	}
	private Dictionary<int, OneVSOneTopRewardElement> m_mapElements = null;
	private List<OneVSOneTopRewardElement>	m_vecAllElements = null;
	private OneVSOneTopRewardElement m_emptyItem = null;
	private static OneVSOneTopRewardTable sInstance = null;

	public static OneVSOneTopRewardTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new OneVSOneTopRewardTable();
			return sInstance;
		}
	}

	public OneVSOneTopRewardElement GetElement(int key)
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

  public List<OneVSOneTopRewardElement> GetAllElement(Predicate<OneVSOneTopRewardElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("OneVSOneTopReward.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("OneVSOneTopReward.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[OneVSOneTopReward.bin]未找到");
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
			Ex.Logger.Log("OneVSOneTopReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="StartTop"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[StartTop]位置不对应"); return false; }
		if(vecLine[2]!="EndTop"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[EndTop]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Score"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[Score]位置不对应"); return false; }
		if(vecLine[5]!="Experience"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[Experience]位置不对应"); return false; }
		if(vecLine[6]!="ItemID"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[7]!="ItemNum"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[ItemNum]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			OneVSOneTopRewardElement member = new OneVSOneTopRewardElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.StartTop );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EndTop );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
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
			Ex.Logger.Log("OneVSOneTopReward.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="StartTop"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[StartTop]位置不对应"); return false; }
		if(vecLine[2]!="EndTop"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[EndTop]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Score"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[Score]位置不对应"); return false; }
		if(vecLine[5]!="Experience"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[Experience]位置不对应"); return false; }
		if(vecLine[6]!="ItemID"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[7]!="ItemNum"){Ex.Logger.Log("OneVSOneTopReward.csv中字段[ItemNum]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)8)
			{
				return false;
			}
			OneVSOneTopRewardElement member = new OneVSOneTopRewardElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.StartTop=Convert.ToInt32(vecLine[1]);
			member.EndTop=Convert.ToInt32(vecLine[2]);
			member.Type=Convert.ToInt32(vecLine[3]);
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
