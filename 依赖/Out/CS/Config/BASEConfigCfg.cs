using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//基础配置配置数据类
public class BASEConfigElement
{
	public int ID;               	//编号	等级
	public string Name;          	//说明	字段说明
	public int Args1;            	//参数1	参数1
	public int Args2;            	//参数2	参数2

	public bool IsValidate = false;
	public BASEConfigElement()
	{
		ID = -1;
	}
};

//基础配置配置封装类
public class BASEConfigTable
{

	private BASEConfigTable()
	{
		m_mapElements = new Dictionary<int, BASEConfigElement>();
		m_emptyItem = new BASEConfigElement();
		m_vecAllElements = new List<BASEConfigElement>();
	}
	private Dictionary<int, BASEConfigElement> m_mapElements = null;
	private List<BASEConfigElement>	m_vecAllElements = null;
	private BASEConfigElement m_emptyItem = null;
	private static BASEConfigTable sInstance = null;

	public static BASEConfigTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BASEConfigTable();
			return sInstance;
		}
	}

	public BASEConfigElement GetElement(int key)
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

  public List<BASEConfigElement> GetAllElement(Predicate<BASEConfigElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BASEConfig.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BASEConfig.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BASEConfig.bin]未找到");
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
			Ex.Logger.Log("BASEConfig.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BASEConfig.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BASEConfig.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Args1"){Ex.Logger.Log("BASEConfig.csv中字段[Args1]位置不对应"); return false; }
		if(vecLine[3]!="Args2"){Ex.Logger.Log("BASEConfig.csv中字段[Args2]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BASEConfigElement member = new BASEConfigElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Args1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Args2 );

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
			Ex.Logger.Log("BASEConfig.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BASEConfig.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BASEConfig.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Args1"){Ex.Logger.Log("BASEConfig.csv中字段[Args1]位置不对应"); return false; }
		if(vecLine[3]!="Args2"){Ex.Logger.Log("BASEConfig.csv中字段[Args2]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			BASEConfigElement member = new BASEConfigElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Args1=Convert.ToInt32(vecLine[2]);
			member.Args2=Convert.ToInt32(vecLine[3]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
