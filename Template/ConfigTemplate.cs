using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//$CNName$����������
public class $Template$Element
{
$FieldDefine$
	public bool IsValidate = false;
	public $Template$Element()
	{
		$InitPrimaryField$
	}
};

//$CNName$���÷�װ��
public class $Template$Table
{

	private $Template$Table()
	{
		m_mapElements = new Dictionary<$PrimaryType$, $Template$Element>();
		m_emptyItem = new $Template$Element();
		m_vecAllElements = new List<$Template$Element>();
	}
	private Dictionary<$PrimaryType$, $Template$Element> m_mapElements = null;
	private List<$Template$Element>	m_vecAllElements = null;
	private $Template$Element m_emptyItem = null;
	private static $Template$Table sInstance = null;

	public static $Template$Table Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new $Template$Table();
			return sInstance;
		}
	}

	public $Template$Element GetElement($PrimaryType$ key)
	{
		if( m_mapElements.ContainsKey(key) )
			return m_mapElements[key];
		return null;
	}

	public int GetElementCount()
	{
		return m_mapElements.Count;
	}
	public bool HasElement($PrimaryType$ key)
	{
		return m_mapElements.ContainsKey(key);
	}

  public List<$Template$Element> GetAllElement(Predicate<$Template$Element> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("$Template$.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("$Template$.bin", out binTableContent ) )
		{
			Ex.Logger.Log("�����ļ�[$Template$.bin]δ�ҵ�");
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
		if(vecLine.Count != $ColCount$)
		{
			Ex.Logger.Log("$Template$.csv�������������ɵĴ��벻ƥ��!");
			return false;
		}
$CheckColName$
		for(int i=0; i<nRow; i++)
		{
			$Template$Element member = new $Template$Element();
$ReadBinColValue$
			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.$PrimaryKey$] = member;
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
		if(vecLine.Count != $ColCount$)
		{
			Ex.Logger.Log("$Template$.csv�������������ɵĴ��벻ƥ��!");
			return false;
		}
$CheckColName$
		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)$ColCount$)
			{
				return false;
			}
			$Template$Element member = new $Template$Element();
$ReadCsvColValue$
			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.$PrimaryKey$] = member;
		}
		return true;
	}
};
