using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//随机名字配置数据类
public class RandomNameElement
{
	public int ID;               	//编号	等级
	public string LastName;      	//姓	姓
	public string FirstName;     	//名	名
	public string Symbol;        	//符号	符号
	public int gender;           	//性别（1男,2女,3通用）	性别（1男,2女,3通用）

	public bool IsValidate = false;
	public RandomNameElement()
	{
		ID = -1;
	}
};

//随机名字配置封装类
public class RandomNameTable
{

	private RandomNameTable()
	{
		m_mapElements = new Dictionary<int, RandomNameElement>();
		m_emptyItem = new RandomNameElement();
		m_vecAllElements = new List<RandomNameElement>();
	}
	private Dictionary<int, RandomNameElement> m_mapElements = null;
	private List<RandomNameElement>	m_vecAllElements = null;
	private RandomNameElement m_emptyItem = null;
	private static RandomNameTable sInstance = null;

	public static RandomNameTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new RandomNameTable();
			return sInstance;
		}
	}

	public RandomNameElement GetElement(int key)
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

  public List<RandomNameElement> GetAllElement(Predicate<RandomNameElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("RandomName.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("RandomName.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[RandomName.bin]未找到");
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
			Ex.Logger.Log("RandomName.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("RandomName.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="LastName"){Ex.Logger.Log("RandomName.csv中字段[LastName]位置不对应"); return false; }
		if(vecLine[2]!="FirstName"){Ex.Logger.Log("RandomName.csv中字段[FirstName]位置不对应"); return false; }
		if(vecLine[3]!="Symbol"){Ex.Logger.Log("RandomName.csv中字段[Symbol]位置不对应"); return false; }
		if(vecLine[4]!="gender"){Ex.Logger.Log("RandomName.csv中字段[gender]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			RandomNameElement member = new RandomNameElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.LastName);
			readPos += GameAssist.ReadString( binContent, readPos, out member.FirstName);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Symbol);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.gender );

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
			Ex.Logger.Log("RandomName.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("RandomName.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="LastName"){Ex.Logger.Log("RandomName.csv中字段[LastName]位置不对应"); return false; }
		if(vecLine[2]!="FirstName"){Ex.Logger.Log("RandomName.csv中字段[FirstName]位置不对应"); return false; }
		if(vecLine[3]!="Symbol"){Ex.Logger.Log("RandomName.csv中字段[Symbol]位置不对应"); return false; }
		if(vecLine[4]!="gender"){Ex.Logger.Log("RandomName.csv中字段[gender]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			RandomNameElement member = new RandomNameElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.LastName=vecLine[1];
			member.FirstName=vecLine[2];
			member.Symbol=vecLine[3];
			member.gender=Convert.ToInt32(vecLine[4]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
