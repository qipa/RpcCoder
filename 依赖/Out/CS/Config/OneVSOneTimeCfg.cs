using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//排名时间配置数据类
public class OneVSOneTimeElement
{
	public int ID;               	//编号	等级
	public int Monty;            	//月份	每月-1为忽略月份
	public int Day;              	//日期	每天就是-1 0是周日6是周六
	public int Hour;             	//小时	小时
	public int Min;              	//分钟	分钟

	public bool IsValidate = false;
	public OneVSOneTimeElement()
	{
		ID = -1;
	}
};

//排名时间配置封装类
public class OneVSOneTimeTable
{

	private OneVSOneTimeTable()
	{
		m_mapElements = new Dictionary<int, OneVSOneTimeElement>();
		m_emptyItem = new OneVSOneTimeElement();
		m_vecAllElements = new List<OneVSOneTimeElement>();
	}
	private Dictionary<int, OneVSOneTimeElement> m_mapElements = null;
	private List<OneVSOneTimeElement>	m_vecAllElements = null;
	private OneVSOneTimeElement m_emptyItem = null;
	private static OneVSOneTimeTable sInstance = null;

	public static OneVSOneTimeTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new OneVSOneTimeTable();
			return sInstance;
		}
	}

	public OneVSOneTimeElement GetElement(int key)
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

  public List<OneVSOneTimeElement> GetAllElement(Predicate<OneVSOneTimeElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("OneVSOneTime.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("OneVSOneTime.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[OneVSOneTime.bin]未找到");
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
			Ex.Logger.Log("OneVSOneTime.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneTime.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Monty"){Ex.Logger.Log("OneVSOneTime.csv中字段[Monty]位置不对应"); return false; }
		if(vecLine[2]!="Day"){Ex.Logger.Log("OneVSOneTime.csv中字段[Day]位置不对应"); return false; }
		if(vecLine[3]!="Hour"){Ex.Logger.Log("OneVSOneTime.csv中字段[Hour]位置不对应"); return false; }
		if(vecLine[4]!="Min"){Ex.Logger.Log("OneVSOneTime.csv中字段[Min]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			OneVSOneTimeElement member = new OneVSOneTimeElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Monty );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Day );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Hour );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Min );

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
			Ex.Logger.Log("OneVSOneTime.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneTime.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Monty"){Ex.Logger.Log("OneVSOneTime.csv中字段[Monty]位置不对应"); return false; }
		if(vecLine[2]!="Day"){Ex.Logger.Log("OneVSOneTime.csv中字段[Day]位置不对应"); return false; }
		if(vecLine[3]!="Hour"){Ex.Logger.Log("OneVSOneTime.csv中字段[Hour]位置不对应"); return false; }
		if(vecLine[4]!="Min"){Ex.Logger.Log("OneVSOneTime.csv中字段[Min]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			OneVSOneTimeElement member = new OneVSOneTimeElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Monty=Convert.ToInt32(vecLine[1]);
			member.Day=Convert.ToInt32(vecLine[2]);
			member.Hour=Convert.ToInt32(vecLine[3]);
			member.Min=Convert.ToInt32(vecLine[4]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
