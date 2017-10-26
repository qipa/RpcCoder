using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//任务条件配置数据类
public class MissionTiaoJianElement
{
	public int ID;               	//编号	条件ID
	public int TiaoJian1;        	//目标1类型	1送信2杀怪3收集物品4使用物品5杀怪收集6采集7杀boss8达到特定等级
	public int CanShu1;          	//目标1	目标1
	public int Num1;             	//目标1数量	目标1数量
	public string DaoHang1;      	//目标导航1	目标导航1
	public string XunLu1;        	//寻路1	寻路1
	public int TiaoJian2;        	//目标2类型	目标2类型
	public int CanShu2;          	//目标2	目标2
	public int Num2;             	//目标2数量	目标2数量
	public string DaoHang2;      	//目标导航2	目标导航2
	public string XunLu2;        	//寻路1	寻路1
	public int TiaoJian3;        	//目标3类型	目标3类型
	public int CanShu3;          	//目标3	目标3
	public int Num3;             	//目标3数量	目标3数量
	public string DaoHang3;      	//目标导航3	目标导航3
	public string XunLu3;        	//寻路1	寻路1
	public string Finish;        	//完成导航	完成导航
	public string FinishXianShi; 	//完成导航显示文字	完成导航显示文字

	public bool IsValidate = false;
	public MissionTiaoJianElement()
	{
		ID = -1;
	}
};

//任务条件配置封装类
public class MissionTiaoJianTable
{

	private MissionTiaoJianTable()
	{
		m_mapElements = new Dictionary<int, MissionTiaoJianElement>();
		m_emptyItem = new MissionTiaoJianElement();
		m_vecAllElements = new List<MissionTiaoJianElement>();
	}
	private Dictionary<int, MissionTiaoJianElement> m_mapElements = null;
	private List<MissionTiaoJianElement>	m_vecAllElements = null;
	private MissionTiaoJianElement m_emptyItem = null;
	private static MissionTiaoJianTable sInstance = null;

	public static MissionTiaoJianTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MissionTiaoJianTable();
			return sInstance;
		}
	}

	public MissionTiaoJianElement GetElement(int key)
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

  public List<MissionTiaoJianElement> GetAllElement(Predicate<MissionTiaoJianElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MissionTiaoJian.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MissionTiaoJian.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[MissionTiaoJian.bin]未找到");
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
		if(vecLine.Count != 18)
		{
			Ex.Logger.Log("MissionTiaoJian.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MissionTiaoJian.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="TiaoJian1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[TiaoJian1]位置不对应"); return false; }
		if(vecLine[2]!="CanShu1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[CanShu1]位置不对应"); return false; }
		if(vecLine[3]!="Num1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[4]!="DaoHang1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[DaoHang1]位置不对应"); return false; }
		if(vecLine[5]!="XunLu1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[XunLu1]位置不对应"); return false; }
		if(vecLine[6]!="TiaoJian2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[TiaoJian2]位置不对应"); return false; }
		if(vecLine[7]!="CanShu2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[CanShu2]位置不对应"); return false; }
		if(vecLine[8]!="Num2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[9]!="DaoHang2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[DaoHang2]位置不对应"); return false; }
		if(vecLine[10]!="XunLu2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[XunLu2]位置不对应"); return false; }
		if(vecLine[11]!="TiaoJian3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[TiaoJian3]位置不对应"); return false; }
		if(vecLine[12]!="CanShu3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[CanShu3]位置不对应"); return false; }
		if(vecLine[13]!="Num3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[14]!="DaoHang3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[DaoHang3]位置不对应"); return false; }
		if(vecLine[15]!="XunLu3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[XunLu3]位置不对应"); return false; }
		if(vecLine[16]!="Finish"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Finish]位置不对应"); return false; }
		if(vecLine[17]!="FinishXianShi"){Ex.Logger.Log("MissionTiaoJian.csv中字段[FinishXianShi]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MissionTiaoJianElement member = new MissionTiaoJianElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiaoJian1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CanShu1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num1 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DaoHang1);
			readPos += GameAssist.ReadString( binContent, readPos, out member.XunLu1);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiaoJian2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CanShu2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num2 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DaoHang2);
			readPos += GameAssist.ReadString( binContent, readPos, out member.XunLu2);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiaoJian3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CanShu3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num3 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DaoHang3);
			readPos += GameAssist.ReadString( binContent, readPos, out member.XunLu3);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Finish);
			readPos += GameAssist.ReadString( binContent, readPos, out member.FinishXianShi);

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
		if(vecLine.Count != 18)
		{
			Ex.Logger.Log("MissionTiaoJian.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MissionTiaoJian.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="TiaoJian1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[TiaoJian1]位置不对应"); return false; }
		if(vecLine[2]!="CanShu1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[CanShu1]位置不对应"); return false; }
		if(vecLine[3]!="Num1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[4]!="DaoHang1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[DaoHang1]位置不对应"); return false; }
		if(vecLine[5]!="XunLu1"){Ex.Logger.Log("MissionTiaoJian.csv中字段[XunLu1]位置不对应"); return false; }
		if(vecLine[6]!="TiaoJian2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[TiaoJian2]位置不对应"); return false; }
		if(vecLine[7]!="CanShu2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[CanShu2]位置不对应"); return false; }
		if(vecLine[8]!="Num2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[9]!="DaoHang2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[DaoHang2]位置不对应"); return false; }
		if(vecLine[10]!="XunLu2"){Ex.Logger.Log("MissionTiaoJian.csv中字段[XunLu2]位置不对应"); return false; }
		if(vecLine[11]!="TiaoJian3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[TiaoJian3]位置不对应"); return false; }
		if(vecLine[12]!="CanShu3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[CanShu3]位置不对应"); return false; }
		if(vecLine[13]!="Num3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[14]!="DaoHang3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[DaoHang3]位置不对应"); return false; }
		if(vecLine[15]!="XunLu3"){Ex.Logger.Log("MissionTiaoJian.csv中字段[XunLu3]位置不对应"); return false; }
		if(vecLine[16]!="Finish"){Ex.Logger.Log("MissionTiaoJian.csv中字段[Finish]位置不对应"); return false; }
		if(vecLine[17]!="FinishXianShi"){Ex.Logger.Log("MissionTiaoJian.csv中字段[FinishXianShi]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)18)
			{
				return false;
			}
			MissionTiaoJianElement member = new MissionTiaoJianElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.TiaoJian1=Convert.ToInt32(vecLine[1]);
			member.CanShu1=Convert.ToInt32(vecLine[2]);
			member.Num1=Convert.ToInt32(vecLine[3]);
			member.DaoHang1=vecLine[4];
			member.XunLu1=vecLine[5];
			member.TiaoJian2=Convert.ToInt32(vecLine[6]);
			member.CanShu2=Convert.ToInt32(vecLine[7]);
			member.Num2=Convert.ToInt32(vecLine[8]);
			member.DaoHang2=vecLine[9];
			member.XunLu2=vecLine[10];
			member.TiaoJian3=Convert.ToInt32(vecLine[11]);
			member.CanShu3=Convert.ToInt32(vecLine[12]);
			member.Num3=Convert.ToInt32(vecLine[13]);
			member.DaoHang3=vecLine[14];
			member.XunLu3=vecLine[15];
			member.Finish=vecLine[16];
			member.FinishXianShi=vecLine[17];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
