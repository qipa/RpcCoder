using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//排行榜的职业等级分组配置数据类
public class OneVSOneTopLVElement
{
	public int ID;               	//编号	等级
	public string Name;          	//组名字	组名字
	public int MinLV;            	//最低等级	最低等级
	public int MaxLV;            	//最高等级	最高等级
	public int Type;             	//类型	1 1VS1 2 五行旗

	public bool IsValidate = false;
	public OneVSOneTopLVElement()
	{
		ID = -1;
	}
};

//排行榜的职业等级分组配置封装类
public class OneVSOneTopLVTable
{

	private OneVSOneTopLVTable()
	{
		m_mapElements = new Dictionary<int, OneVSOneTopLVElement>();
		m_emptyItem = new OneVSOneTopLVElement();
		m_vecAllElements = new List<OneVSOneTopLVElement>();
	}
	private Dictionary<int, OneVSOneTopLVElement> m_mapElements = null;
	private List<OneVSOneTopLVElement>	m_vecAllElements = null;
	private OneVSOneTopLVElement m_emptyItem = null;
	private static OneVSOneTopLVTable sInstance = null;

	public static OneVSOneTopLVTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new OneVSOneTopLVTable();
			return sInstance;
		}
	}

	public OneVSOneTopLVElement GetElement(int key)
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

  public List<OneVSOneTopLVElement> GetAllElement(Predicate<OneVSOneTopLVElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("OneVSOneTopLV.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("OneVSOneTopLV.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[OneVSOneTopLV.bin]未找到");
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
			Ex.Logger.Log("OneVSOneTopLV.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MinLV"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[MinLV]位置不对应"); return false; }
		if(vecLine[3]!="MaxLV"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[MaxLV]位置不对应"); return false; }
		if(vecLine[4]!="Type"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[Type]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			OneVSOneTopLVElement member = new OneVSOneTopLVElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MinLV );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MaxLV );
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
		if(vecLine.Count != 5)
		{
			Ex.Logger.Log("OneVSOneTopLV.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MinLV"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[MinLV]位置不对应"); return false; }
		if(vecLine[3]!="MaxLV"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[MaxLV]位置不对应"); return false; }
		if(vecLine[4]!="Type"){Ex.Logger.Log("OneVSOneTopLV.csv中字段[Type]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			OneVSOneTopLVElement member = new OneVSOneTopLVElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.MinLV=Convert.ToInt32(vecLine[2]);
			member.MaxLV=Convert.ToInt32(vecLine[3]);
			member.Type=Convert.ToInt32(vecLine[4]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
