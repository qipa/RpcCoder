using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//一条龙活动表配置数据类
public class YiTiaoLongElement
{
	public int ID;               	//完成次数	完成的副本次数
	public float ExpReward;      	//经验	针对boss掉落经验的倍率
	public string SpecialRewardId;	//特殊奖励	特殊奖励的掉落列ID
	public string Num;           	//数量	奖励数量
	public string SpecialRewardPro;	//特殊奖励概率	特殊奖励概率

	public bool IsValidate = false;
	public YiTiaoLongElement()
	{
		ID = -1;
	}
};

//一条龙活动表配置封装类
public class YiTiaoLongTable
{

	private YiTiaoLongTable()
	{
		m_mapElements = new Dictionary<int, YiTiaoLongElement>();
		m_emptyItem = new YiTiaoLongElement();
		m_vecAllElements = new List<YiTiaoLongElement>();
	}
	private Dictionary<int, YiTiaoLongElement> m_mapElements = null;
	private List<YiTiaoLongElement>	m_vecAllElements = null;
	private YiTiaoLongElement m_emptyItem = null;
	private static YiTiaoLongTable sInstance = null;

	public static YiTiaoLongTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new YiTiaoLongTable();
			return sInstance;
		}
	}

	public YiTiaoLongElement GetElement(int key)
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

  public List<YiTiaoLongElement> GetAllElement(Predicate<YiTiaoLongElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("YiTiaoLong.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("YiTiaoLong.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[YiTiaoLong.bin]未找到");
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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("YiTiaoLong.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("YiTiaoLong.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ExpReward"){Ex.Logger.Log("YiTiaoLong.csv中字段[ExpReward]位置不对应"); return false; }
		if(vecLine[2]!="SpecialRewardId"){Ex.Logger.Log("YiTiaoLong.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[3]!="Num"){Ex.Logger.Log("YiTiaoLong.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[4]!="SpecialRewardPro"){Ex.Logger.Log("YiTiaoLong.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			YiTiaoLongElement member = new YiTiaoLongElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.ExpReward);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SpecialRewardId);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SpecialRewardPro);

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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("YiTiaoLong.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("YiTiaoLong.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ExpReward"){Ex.Logger.Log("YiTiaoLong.csv中字段[ExpReward]位置不对应"); return false; }
		if(vecLine[2]!="SpecialRewardId"){Ex.Logger.Log("YiTiaoLong.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[3]!="Num"){Ex.Logger.Log("YiTiaoLong.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[4]!="SpecialRewardPro"){Ex.Logger.Log("YiTiaoLong.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			YiTiaoLongElement member = new YiTiaoLongElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.ExpReward=Convert.ToSingle(vecLine[1]);
			member.SpecialRewardId=vecLine[2];
			member.Num=vecLine[3];
			member.SpecialRewardPro=vecLine[4];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
