using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//帮会修炼配置数据类
public class BangHuiXiuLianElement
{
	public int ID;               	//编号	属性等级
	public int Type;             	//属性类型	属性类型
	public int Lv;               	//属性等级	属性等级
	public int JieMian;          	//所属界面	1基础属性2元素伤害3元素抗性4控制强化5控制抗性
	public int Exp;              	//所需经验	所需经验
	public int CanShu;           	//对应提升参数	对应提升参数

	public bool IsValidate = false;
	public BangHuiXiuLianElement()
	{
		ID = -1;
	}
};

//帮会修炼配置封装类
public class BangHuiXiuLianTable
{

	private BangHuiXiuLianTable()
	{
		m_mapElements = new Dictionary<int, BangHuiXiuLianElement>();
		m_emptyItem = new BangHuiXiuLianElement();
		m_vecAllElements = new List<BangHuiXiuLianElement>();
	}
	private Dictionary<int, BangHuiXiuLianElement> m_mapElements = null;
	private List<BangHuiXiuLianElement>	m_vecAllElements = null;
	private BangHuiXiuLianElement m_emptyItem = null;
	private static BangHuiXiuLianTable sInstance = null;

	public static BangHuiXiuLianTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BangHuiXiuLianTable();
			return sInstance;
		}
	}

	public BangHuiXiuLianElement GetElement(int key)
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

  public List<BangHuiXiuLianElement> GetAllElement(Predicate<BangHuiXiuLianElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BangHuiXiuLian.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BangHuiXiuLian.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BangHuiXiuLian.bin]未找到");
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
			Ex.Logger.Log("BangHuiXiuLian.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Lv"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[3]!="JieMian"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[JieMian]位置不对应"); return false; }
		if(vecLine[4]!="Exp"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[5]!="CanShu"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[CanShu]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BangHuiXiuLianElement member = new BangHuiXiuLianElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.JieMian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Exp );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CanShu );

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
		if(vecLine.Count != 6)
		{
			Ex.Logger.Log("BangHuiXiuLian.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="Lv"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[3]!="JieMian"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[JieMian]位置不对应"); return false; }
		if(vecLine[4]!="Exp"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[5]!="CanShu"){Ex.Logger.Log("BangHuiXiuLian.csv中字段[CanShu]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			BangHuiXiuLianElement member = new BangHuiXiuLianElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Type=Convert.ToInt32(vecLine[1]);
			member.Lv=Convert.ToInt32(vecLine[2]);
			member.JieMian=Convert.ToInt32(vecLine[3]);
			member.Exp=Convert.ToInt32(vecLine[4]);
			member.CanShu=Convert.ToInt32(vecLine[5]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
