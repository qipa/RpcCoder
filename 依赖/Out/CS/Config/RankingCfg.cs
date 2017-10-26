using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//排行榜配置数据类
public class RankingElement
{
	public int ID;               	//编号	编号
	public string SmallLabel;    	//小分类标签	小分类标签
	public int LargeLabel;       	//所属大分类	所属大分类（1个人信息2属性3帮会）
	public int Type;             	//标签类型	标签类型（1横2竖）

	public bool IsValidate = false;
	public RankingElement()
	{
		ID = -1;
	}
};

//排行榜配置封装类
public class RankingTable
{

	private RankingTable()
	{
		m_mapElements = new Dictionary<int, RankingElement>();
		m_emptyItem = new RankingElement();
		m_vecAllElements = new List<RankingElement>();
	}
	private Dictionary<int, RankingElement> m_mapElements = null;
	private List<RankingElement>	m_vecAllElements = null;
	private RankingElement m_emptyItem = null;
	private static RankingTable sInstance = null;

	public static RankingTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new RankingTable();
			return sInstance;
		}
	}

	public RankingElement GetElement(int key)
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

  public List<RankingElement> GetAllElement(Predicate<RankingElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Ranking.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Ranking.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Ranking.bin]未找到");
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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("Ranking.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Ranking.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SmallLabel"){Ex.Logger.Log("Ranking.csv中字段[SmallLabel]位置不对应"); return false; }
		if(vecLine[2]!="LargeLabel"){Ex.Logger.Log("Ranking.csv中字段[LargeLabel]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Ranking.csv中字段[Type]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			RankingElement member = new RankingElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.SmallLabel);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LargeLabel );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );

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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("Ranking.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Ranking.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SmallLabel"){Ex.Logger.Log("Ranking.csv中字段[SmallLabel]位置不对应"); return false; }
		if(vecLine[2]!="LargeLabel"){Ex.Logger.Log("Ranking.csv中字段[LargeLabel]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("Ranking.csv中字段[Type]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			RankingElement member = new RankingElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.SmallLabel=vecLine[1];
			member.LargeLabel=Convert.ToInt32(vecLine[2]);
			member.Type=Convert.ToInt32(vecLine[3]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
