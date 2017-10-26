using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//战斗公式配置数据类
public class FormulaElement
{
	public int FormulaID;        	//公式ID	公式ID
	public string Describe;      	//描述	描述
	public string VarsName;      	//变量名	变量名
	public string Formula;       	//公式	公式

	public bool IsValidate = false;
	public FormulaElement()
	{
		FormulaID = -1;
	}
};

//战斗公式配置封装类
public class FormulaTable
{

	private FormulaTable()
	{
		m_mapElements = new Dictionary<int, FormulaElement>();
		m_emptyItem = new FormulaElement();
		m_vecAllElements = new List<FormulaElement>();
	}
	private Dictionary<int, FormulaElement> m_mapElements = null;
	private List<FormulaElement>	m_vecAllElements = null;
	private FormulaElement m_emptyItem = null;
	private static FormulaTable sInstance = null;

	public static FormulaTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FormulaTable();
			return sInstance;
		}
	}

	public FormulaElement GetElement(int key)
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

  public List<FormulaElement> GetAllElement(Predicate<FormulaElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Formula.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Formula.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Formula.bin]未找到");
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
			Ex.Logger.Log("Formula.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="FormulaID"){Ex.Logger.Log("Formula.csv中字段[FormulaID]位置不对应"); return false; }
		if(vecLine[1]!="Describe"){Ex.Logger.Log("Formula.csv中字段[Describe]位置不对应"); return false; }
		if(vecLine[2]!="VarsName"){Ex.Logger.Log("Formula.csv中字段[VarsName]位置不对应"); return false; }
		if(vecLine[3]!="Formula"){Ex.Logger.Log("Formula.csv中字段[Formula]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FormulaElement member = new FormulaElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FormulaID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Describe);
			readPos += GameAssist.ReadString( binContent, readPos, out member.VarsName);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Formula);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.FormulaID] = member;
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
			Ex.Logger.Log("Formula.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="FormulaID"){Ex.Logger.Log("Formula.csv中字段[FormulaID]位置不对应"); return false; }
		if(vecLine[1]!="Describe"){Ex.Logger.Log("Formula.csv中字段[Describe]位置不对应"); return false; }
		if(vecLine[2]!="VarsName"){Ex.Logger.Log("Formula.csv中字段[VarsName]位置不对应"); return false; }
		if(vecLine[3]!="Formula"){Ex.Logger.Log("Formula.csv中字段[Formula]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			FormulaElement member = new FormulaElement();
			member.FormulaID=Convert.ToInt32(vecLine[0]);
			member.Describe=vecLine[1];
			member.VarsName=vecLine[2];
			member.Formula=vecLine[3];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.FormulaID] = member;
		}
		return true;
	}
};
