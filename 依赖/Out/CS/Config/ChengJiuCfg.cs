using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//成就表配置数据类
public class ChengJiuElement
{
	public int ChengJiuID;       	//编号	成就ID
	public string Name;          	//成就名称	成就名称
	public string Res;           	//成就图标	成就图标
	public int Type;             	//成就分类	成就分类（1成长 2 活动 3社交）
	public string MiaoShu;       	//成就描述	成就描述
	public int ReWard;           	//奖励类型	1 银两 2元宝 3 道具 
	public int Num;              	//奖励参数	奖励参数
	public int Item;             	//奖励道具	奖励道具
	public int TiaoJian;         	//解锁条件	1等级2装备强化
	public int CanShu;           	//条件参数	条件参数

	public bool IsValidate = false;
	public ChengJiuElement()
	{
		ChengJiuID = -1;
	}
};

//成就表配置封装类
public class ChengJiuTable
{

	private ChengJiuTable()
	{
		m_mapElements = new Dictionary<int, ChengJiuElement>();
		m_emptyItem = new ChengJiuElement();
		m_vecAllElements = new List<ChengJiuElement>();
	}
	private Dictionary<int, ChengJiuElement> m_mapElements = null;
	private List<ChengJiuElement>	m_vecAllElements = null;
	private ChengJiuElement m_emptyItem = null;
	private static ChengJiuTable sInstance = null;

	public static ChengJiuTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ChengJiuTable();
			return sInstance;
		}
	}

	public ChengJiuElement GetElement(int key)
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

  public List<ChengJiuElement> GetAllElement(Predicate<ChengJiuElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("ChengJiu.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("ChengJiu.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[ChengJiu.bin]未找到");
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
		if(vecLine.Count != 10)
		{
			Ex.Logger.Log("ChengJiu.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ChengJiuID"){Ex.Logger.Log("ChengJiu.csv中字段[ChengJiuID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("ChengJiu.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Ex.Logger.Log("ChengJiu.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("ChengJiu.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="MiaoShu"){Ex.Logger.Log("ChengJiu.csv中字段[MiaoShu]位置不对应"); return false; }
		if(vecLine[5]!="ReWard"){Ex.Logger.Log("ChengJiu.csv中字段[ReWard]位置不对应"); return false; }
		if(vecLine[6]!="Num"){Ex.Logger.Log("ChengJiu.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[7]!="Item"){Ex.Logger.Log("ChengJiu.csv中字段[Item]位置不对应"); return false; }
		if(vecLine[8]!="TiaoJian"){Ex.Logger.Log("ChengJiu.csv中字段[TiaoJian]位置不对应"); return false; }
		if(vecLine[9]!="CanShu"){Ex.Logger.Log("ChengJiu.csv中字段[CanShu]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ChengJiuElement member = new ChengJiuElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ChengJiuID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MiaoShu);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ReWard );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiaoJian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CanShu );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ChengJiuID] = member;
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
		if(vecLine.Count != 10)
		{
			Ex.Logger.Log("ChengJiu.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ChengJiuID"){Ex.Logger.Log("ChengJiu.csv中字段[ChengJiuID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("ChengJiu.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Ex.Logger.Log("ChengJiu.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("ChengJiu.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="MiaoShu"){Ex.Logger.Log("ChengJiu.csv中字段[MiaoShu]位置不对应"); return false; }
		if(vecLine[5]!="ReWard"){Ex.Logger.Log("ChengJiu.csv中字段[ReWard]位置不对应"); return false; }
		if(vecLine[6]!="Num"){Ex.Logger.Log("ChengJiu.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[7]!="Item"){Ex.Logger.Log("ChengJiu.csv中字段[Item]位置不对应"); return false; }
		if(vecLine[8]!="TiaoJian"){Ex.Logger.Log("ChengJiu.csv中字段[TiaoJian]位置不对应"); return false; }
		if(vecLine[9]!="CanShu"){Ex.Logger.Log("ChengJiu.csv中字段[CanShu]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)10)
			{
				return false;
			}
			ChengJiuElement member = new ChengJiuElement();
			member.ChengJiuID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Res=vecLine[2];
			member.Type=Convert.ToInt32(vecLine[3]);
			member.MiaoShu=vecLine[4];
			member.ReWard=Convert.ToInt32(vecLine[5]);
			member.Num=Convert.ToInt32(vecLine[6]);
			member.Item=Convert.ToInt32(vecLine[7]);
			member.TiaoJian=Convert.ToInt32(vecLine[8]);
			member.CanShu=Convert.ToInt32(vecLine[9]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ChengJiuID] = member;
		}
		return true;
	}
};
