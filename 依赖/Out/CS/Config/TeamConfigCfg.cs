using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//组队基础配置配置数据类
public class TeamConfigElement
{
	public int ID;               	//编号	等级
	public string Name;          	//说明	字段说明
	public int Args1;            	//参数1	下限等级
	public int Args2;            	//参数2	上限等级
	public int Args3;            	//参数3	等级差
	public int Set;              	//所属层级	所属层级 1普通副本 6 英雄副本
	public int ZhanKai;          	//是否可以展开	是否可以展开

	public bool IsValidate = false;
	public TeamConfigElement()
	{
		ID = -1;
	}
};

//组队基础配置配置封装类
public class TeamConfigTable
{

	private TeamConfigTable()
	{
		m_mapElements = new Dictionary<int, TeamConfigElement>();
		m_emptyItem = new TeamConfigElement();
		m_vecAllElements = new List<TeamConfigElement>();
	}
	private Dictionary<int, TeamConfigElement> m_mapElements = null;
	private List<TeamConfigElement>	m_vecAllElements = null;
	private TeamConfigElement m_emptyItem = null;
	private static TeamConfigTable sInstance = null;

	public static TeamConfigTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new TeamConfigTable();
			return sInstance;
		}
	}

	public TeamConfigElement GetElement(int key)
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

  public List<TeamConfigElement> GetAllElement(Predicate<TeamConfigElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("TeamConfig.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("TeamConfig.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[TeamConfig.bin]未找到");
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
			Ex.Logger.Log("TeamConfig.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("TeamConfig.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("TeamConfig.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Args1"){Ex.Logger.Log("TeamConfig.csv中字段[Args1]位置不对应"); return false; }
		if(vecLine[3]!="Args2"){Ex.Logger.Log("TeamConfig.csv中字段[Args2]位置不对应"); return false; }
		if(vecLine[4]!="Args3"){Ex.Logger.Log("TeamConfig.csv中字段[Args3]位置不对应"); return false; }
		if(vecLine[5]!="Set"){Ex.Logger.Log("TeamConfig.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[6]!="ZhanKai"){Ex.Logger.Log("TeamConfig.csv中字段[ZhanKai]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			TeamConfigElement member = new TeamConfigElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Args1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Args2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Args3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Set );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ZhanKai );

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
			Ex.Logger.Log("TeamConfig.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("TeamConfig.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("TeamConfig.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Args1"){Ex.Logger.Log("TeamConfig.csv中字段[Args1]位置不对应"); return false; }
		if(vecLine[3]!="Args2"){Ex.Logger.Log("TeamConfig.csv中字段[Args2]位置不对应"); return false; }
		if(vecLine[4]!="Args3"){Ex.Logger.Log("TeamConfig.csv中字段[Args3]位置不对应"); return false; }
		if(vecLine[5]!="Set"){Ex.Logger.Log("TeamConfig.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[6]!="ZhanKai"){Ex.Logger.Log("TeamConfig.csv中字段[ZhanKai]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)7)
			{
				return false;
			}
			TeamConfigElement member = new TeamConfigElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Args1=Convert.ToInt32(vecLine[2]);
			member.Args2=Convert.ToInt32(vecLine[3]);
			member.Args3=Convert.ToInt32(vecLine[4]);
			member.Set=Convert.ToInt32(vecLine[5]);
			member.ZhanKai=Convert.ToInt32(vecLine[6]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
