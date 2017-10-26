using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//词条表配置数据类
public class CiTiaoElement
{
	public int ID;               	//词条	词条ID
	public string Name;          	//词条名称	词条名称
	public int Type;             	//显示方案	1普通2复合
	public int Attr1;            	//属性1	属性1
	public string MiaoShu1;      	//属性1描述	属性1描述
	public int FuHao1;           	//属性1是否有百分号	1有-1 没有
	public int Attr2;            	//属性2	属性2
	public string MiaoShu2;      	//属性2描述	属性2描述
	public int FuHao2;           	//属性2是否有百分号	属性2是否有百分号

	public bool IsValidate = false;
	public CiTiaoElement()
	{
		ID = -1;
	}
};

//词条表配置封装类
public class CiTiaoTable
{

	private CiTiaoTable()
	{
		m_mapElements = new Dictionary<int, CiTiaoElement>();
		m_emptyItem = new CiTiaoElement();
		m_vecAllElements = new List<CiTiaoElement>();
	}
	private Dictionary<int, CiTiaoElement> m_mapElements = null;
	private List<CiTiaoElement>	m_vecAllElements = null;
	private CiTiaoElement m_emptyItem = null;
	private static CiTiaoTable sInstance = null;

	public static CiTiaoTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new CiTiaoTable();
			return sInstance;
		}
	}

	public CiTiaoElement GetElement(int key)
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

  public List<CiTiaoElement> GetAllElement(Predicate<CiTiaoElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("CiTiao.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("CiTiao.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[CiTiao.bin]未找到");
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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("CiTiao.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CiTiao.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("CiTiao.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("CiTiao.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="Attr1"){Ex.Logger.Log("CiTiao.csv中字段[Attr1]位置不对应"); return false; }
		if(vecLine[4]!="MiaoShu1"){Ex.Logger.Log("CiTiao.csv中字段[MiaoShu1]位置不对应"); return false; }
		if(vecLine[5]!="FuHao1"){Ex.Logger.Log("CiTiao.csv中字段[FuHao1]位置不对应"); return false; }
		if(vecLine[6]!="Attr2"){Ex.Logger.Log("CiTiao.csv中字段[Attr2]位置不对应"); return false; }
		if(vecLine[7]!="MiaoShu2"){Ex.Logger.Log("CiTiao.csv中字段[MiaoShu2]位置不对应"); return false; }
		if(vecLine[8]!="FuHao2"){Ex.Logger.Log("CiTiao.csv中字段[FuHao2]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			CiTiaoElement member = new CiTiaoElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr1 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MiaoShu1);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FuHao1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Attr2 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MiaoShu2);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FuHao2 );

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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("CiTiao.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("CiTiao.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("CiTiao.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("CiTiao.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="Attr1"){Ex.Logger.Log("CiTiao.csv中字段[Attr1]位置不对应"); return false; }
		if(vecLine[4]!="MiaoShu1"){Ex.Logger.Log("CiTiao.csv中字段[MiaoShu1]位置不对应"); return false; }
		if(vecLine[5]!="FuHao1"){Ex.Logger.Log("CiTiao.csv中字段[FuHao1]位置不对应"); return false; }
		if(vecLine[6]!="Attr2"){Ex.Logger.Log("CiTiao.csv中字段[Attr2]位置不对应"); return false; }
		if(vecLine[7]!="MiaoShu2"){Ex.Logger.Log("CiTiao.csv中字段[MiaoShu2]位置不对应"); return false; }
		if(vecLine[8]!="FuHao2"){Ex.Logger.Log("CiTiao.csv中字段[FuHao2]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)9)
			{
				return false;
			}
			CiTiaoElement member = new CiTiaoElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Type=Convert.ToInt32(vecLine[2]);
			member.Attr1=Convert.ToInt32(vecLine[3]);
			member.MiaoShu1=vecLine[4];
			member.FuHao1=Convert.ToInt32(vecLine[5]);
			member.Attr2=Convert.ToInt32(vecLine[6]);
			member.MiaoShu2=vecLine[7];
			member.FuHao2=Convert.ToInt32(vecLine[8]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
