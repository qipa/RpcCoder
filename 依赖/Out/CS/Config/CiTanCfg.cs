using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//帮会刺探表配置数据类
public class CiTanElement
{
	public int ID;               	//玩家等级	玩家等级
	public int Reward;           	//奖励ID	奖励ID
	public int SpecialRewardId;  	//特殊奖励	特殊奖励的掉落列ID
	public int Num;              	//数量	奖励数量
	public int SpecialRewardPro; 	//特殊奖励概率	特殊奖励概率

	public bool IsValidate = false;
	public CiTanElement()
	{
		ID = -1;
	}
};

//帮会刺探表配置封装类
public class CiTanTable
{

	private CiTanTable()
	{
		m_mapElements = new Dictionary<int, CiTanElement>();
		m_emptyItem = new CiTanElement();
		m_vecAllElements = new List<CiTanElement>();
	}
	private Dictionary<int, CiTanElement> m_mapElements = null;
	private List<CiTanElement>	m_vecAllElements = null;
	private CiTanElement m_emptyItem = null;
	private static CiTanTable sInstance = null;

	public static CiTanTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new CiTanTable();
			return sInstance;
		}
	}

	public CiTanElement GetElement(int key)
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

  public List<CiTanElement> GetAllElement(Predicate<CiTanElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("CiTan.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("CiTan.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[CiTan.bin]未找到");
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
			Ex.Logger.Log("CiTan.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CiTan.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Reward"){Ex.Logger.Log("CiTan.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[2]!="SpecialRewardId"){Ex.Logger.Log("CiTan.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[3]!="Num"){Ex.Logger.Log("CiTan.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[4]!="SpecialRewardPro"){Ex.Logger.Log("CiTan.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			CiTanElement member = new CiTanElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Reward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SpecialRewardId );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num );
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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("CiTan.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CiTan.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Reward"){Ex.Logger.Log("CiTan.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[2]!="SpecialRewardId"){Ex.Logger.Log("CiTan.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[3]!="Num"){Ex.Logger.Log("CiTan.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[4]!="SpecialRewardPro"){Ex.Logger.Log("CiTan.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			CiTanElement member = new CiTanElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Reward=Convert.ToInt32(vecLine[1]);
			member.SpecialRewardId=Convert.ToInt32(vecLine[2]);
			member.Num=Convert.ToInt32(vecLine[3]);
			member.SpecialRewardPro=Convert.ToInt32(vecLine[4]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
