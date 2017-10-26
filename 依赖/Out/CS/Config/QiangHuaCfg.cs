using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//装备强化配置数据类
public class QiangHuaElement
{
	public int LVID;             	//编号	等级ID
	public string Num;           	//阈值范围	阈值范围
	public string GaiLv;         	//取值概率	取值概率
	public int Item;             	//消耗道具	消耗道具
	public int ItemNum;          	//消耗数量	消耗数量
	public int ZhuanYi;          	//转移消耗	转移消耗元宝

	public bool IsValidate = false;
	public QiangHuaElement()
	{
		LVID = -1;
	}
};

//装备强化配置封装类
public class QiangHuaTable
{

	private QiangHuaTable()
	{
		m_mapElements = new Dictionary<int, QiangHuaElement>();
		m_emptyItem = new QiangHuaElement();
		m_vecAllElements = new List<QiangHuaElement>();
	}
	private Dictionary<int, QiangHuaElement> m_mapElements = null;
	private List<QiangHuaElement>	m_vecAllElements = null;
	private QiangHuaElement m_emptyItem = null;
	private static QiangHuaTable sInstance = null;

	public static QiangHuaTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new QiangHuaTable();
			return sInstance;
		}
	}

	public QiangHuaElement GetElement(int key)
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

  public List<QiangHuaElement> GetAllElement(Predicate<QiangHuaElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("QiangHua.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("QiangHua.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[QiangHua.bin]未找到");
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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("QiangHua.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LVID"){Ex.Logger.Log("QiangHua.csv中字段[LVID]位置不对应"); return false; }
		if(vecLine[1]!="Num"){Ex.Logger.Log("QiangHua.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[2]!="GaiLv"){Ex.Logger.Log("QiangHua.csv中字段[GaiLv]位置不对应"); return false; }
		if(vecLine[3]!="Item"){Ex.Logger.Log("QiangHua.csv中字段[Item]位置不对应"); return false; }
		if(vecLine[4]!="ItemNum"){Ex.Logger.Log("QiangHua.csv中字段[ItemNum]位置不对应"); return false; }
		if(vecLine[5]!="ZhuanYi"){Ex.Logger.Log("QiangHua.csv中字段[ZhuanYi]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			QiangHuaElement member = new QiangHuaElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LVID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Num);
			readPos += GameAssist.ReadString( binContent, readPos, out member.GaiLv);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Item );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ZhuanYi );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LVID] = member;
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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("QiangHua.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LVID"){Ex.Logger.Log("QiangHua.csv中字段[LVID]位置不对应"); return false; }
		if(vecLine[1]!="Num"){Ex.Logger.Log("QiangHua.csv中字段[Num]位置不对应"); return false; }
		if(vecLine[2]!="GaiLv"){Ex.Logger.Log("QiangHua.csv中字段[GaiLv]位置不对应"); return false; }
		if(vecLine[3]!="Item"){Ex.Logger.Log("QiangHua.csv中字段[Item]位置不对应"); return false; }
		if(vecLine[4]!="ItemNum"){Ex.Logger.Log("QiangHua.csv中字段[ItemNum]位置不对应"); return false; }
		if(vecLine[5]!="ZhuanYi"){Ex.Logger.Log("QiangHua.csv中字段[ZhuanYi]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			QiangHuaElement member = new QiangHuaElement();
			member.LVID=Convert.ToInt32(vecLine[0]);
			member.Num=vecLine[1];
			member.GaiLv=vecLine[2];
			member.Item=Convert.ToInt32(vecLine[3]);
			member.ItemNum=Convert.ToInt32(vecLine[4]);
			member.ZhuanYi=Convert.ToInt32(vecLine[5]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LVID] = member;
		}
		return true;
	}
};
