using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//宝石羁绊配置数据类
public class BaoShiJiBanElement
{
	public int ID;               	//编号	羁绊ID
	public string Name;          	//羁绊名称	羁绊名称
	public int Set;              	//所属装备类型	所属装备类型
	public int Lv;               	//羁绊等级	羁绊等级
	public int KongShu;          	//激活孔数	激活孔数
	public string BaoShi;        	//激活所需宝石	激活所需宝石
	public string Attr;          	//属性类别	属性类别
	public string Num;           	//属性参数	属性参数

	public bool IsValidate = false;
	public BaoShiJiBanElement()
	{
		ID = -1;
	}
};

//宝石羁绊配置封装类
public class BaoShiJiBanTable
{

	private BaoShiJiBanTable()
	{
		m_mapElements = new Dictionary<int, BaoShiJiBanElement>();
		m_emptyItem = new BaoShiJiBanElement();
		m_vecAllElements = new List<BaoShiJiBanElement>();
	}
	private Dictionary<int, BaoShiJiBanElement> m_mapElements = null;
	private List<BaoShiJiBanElement>	m_vecAllElements = null;
	private BaoShiJiBanElement m_emptyItem = null;
	private static BaoShiJiBanTable sInstance = null;

	public static BaoShiJiBanTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BaoShiJiBanTable();
			return sInstance;
		}
	}

	public BaoShiJiBanElement GetElement(int key)
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

  public List<BaoShiJiBanElement> GetAllElement(Predicate<BaoShiJiBanElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BaoShiJiBan.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BaoShiJiBan.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BaoShiJiBan.bin]未找到");
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
		if(vecLine.Count != 8)
		{
			Ex.Logger.Log("BaoShiJiBan.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BaoShiJiBan.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Set"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[3]!="Lv"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[4]!="KongShu"){Ex.Logger.Log("BaoShiJiBan.csv中字段[KongShu]位置不对应"); return false; }
		if(vecLine[5]!="BaoShi"){Ex.Logger.Log("BaoShiJiBan.csv中字段[BaoShi]位置不对应"); return false; }
		if(vecLine[6]!="Attr"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Attr]位置不对应"); return false; }
		if(vecLine[7]!="Num"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Num]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BaoShiJiBanElement member = new BaoShiJiBanElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Set );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.KongShu );
			readPos += GameAssist.ReadString( binContent, readPos, out member.BaoShi);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Attr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num);

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
		if(vecLine.Count != 8)
		{
			Ex.Logger.Log("BaoShiJiBan.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BaoShiJiBan.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Set"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[3]!="Lv"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[4]!="KongShu"){Ex.Logger.Log("BaoShiJiBan.csv中字段[KongShu]位置不对应"); return false; }
		if(vecLine[5]!="BaoShi"){Ex.Logger.Log("BaoShiJiBan.csv中字段[BaoShi]位置不对应"); return false; }
		if(vecLine[6]!="Attr"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Attr]位置不对应"); return false; }
		if(vecLine[7]!="Num"){Ex.Logger.Log("BaoShiJiBan.csv中字段[Num]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)8)
			{
				return false;
			}
			BaoShiJiBanElement member = new BaoShiJiBanElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Set=Convert.ToInt32(vecLine[2]);
			member.Lv=Convert.ToInt32(vecLine[3]);
			member.KongShu=Convert.ToInt32(vecLine[4]);
			member.BaoShi=vecLine[5];
			member.Attr=vecLine[6];
			member.Num=vecLine[7];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
