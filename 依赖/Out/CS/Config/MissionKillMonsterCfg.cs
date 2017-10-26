using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//杀怪任务配置数据类
public class MissionKillMonsterElement
{
	public int ID;               	//编号	物品ID
	public string Name;          	//任务名称	官阶名称
	public int MuBiao1;          	//目标怪物1	目标怪物2
	public int Num1;             	//怪物1数量	怪物2数量
	public int MuBiao2;          	//目标怪物2	目标怪物3
	public int Num2;             	//怪物2数量	怪物3数量
	public int MuBiao3;          	//目标怪物3	目标怪物4
	public int Num3;             	//怪物3数量	怪物4数量
	public string DaoHang;       	//任务导航	任务导航

	public bool IsValidate = false;
	public MissionKillMonsterElement()
	{
		ID = -1;
	}
};

//杀怪任务配置封装类
public class MissionKillMonsterTable
{

	private MissionKillMonsterTable()
	{
		m_mapElements = new Dictionary<int, MissionKillMonsterElement>();
		m_emptyItem = new MissionKillMonsterElement();
		m_vecAllElements = new List<MissionKillMonsterElement>();
	}
	private Dictionary<int, MissionKillMonsterElement> m_mapElements = null;
	private List<MissionKillMonsterElement>	m_vecAllElements = null;
	private MissionKillMonsterElement m_emptyItem = null;
	private static MissionKillMonsterTable sInstance = null;

	public static MissionKillMonsterTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MissionKillMonsterTable();
			return sInstance;
		}
	}

	public MissionKillMonsterElement GetElement(int key)
	{
		if( m_mapElements.ContainsKey(key) )
			return m_mapElements[key];
		return m_emptyItem;
	}

	public int GetElementCount()
	{
		return m_mapElements.Count;
	}
	public bool HasElement(int key)
	{
		return m_mapElements.ContainsKey(key);
	}

  public List<MissionKillMonsterElement> GetAllElement(Predicate<MissionKillMonsterElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MissionKillMonster.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MissionKillMonster.bin", out binTableContent ) )
		{
			Debug.Log("配置文件[MissionKillMonster.bin]未找到");
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
			Debug.Log("MissionKillMonster.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("MissionKillMonster.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Debug.Log("MissionKillMonster.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MuBiao1"){Debug.Log("MissionKillMonster.csv中字段[MuBiao1]位置不对应"); return false; }
		if(vecLine[3]!="Num1"){Debug.Log("MissionKillMonster.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[4]!="MuBiao2"){Debug.Log("MissionKillMonster.csv中字段[MuBiao2]位置不对应"); return false; }
		if(vecLine[5]!="Num2"){Debug.Log("MissionKillMonster.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[6]!="MuBiao3"){Debug.Log("MissionKillMonster.csv中字段[MuBiao3]位置不对应"); return false; }
		if(vecLine[7]!="Num3"){Debug.Log("MissionKillMonster.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[8]!="DaoHang"){Debug.Log("MissionKillMonster.csv中字段[DaoHang]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MissionKillMonsterElement member = new MissionKillMonsterElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao3 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num3 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.DaoHang);

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
			Debug.Log("MissionKillMonster.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("MissionKillMonster.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Debug.Log("MissionKillMonster.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MuBiao1"){Debug.Log("MissionKillMonster.csv中字段[MuBiao1]位置不对应"); return false; }
		if(vecLine[3]!="Num1"){Debug.Log("MissionKillMonster.csv中字段[Num1]位置不对应"); return false; }
		if(vecLine[4]!="MuBiao2"){Debug.Log("MissionKillMonster.csv中字段[MuBiao2]位置不对应"); return false; }
		if(vecLine[5]!="Num2"){Debug.Log("MissionKillMonster.csv中字段[Num2]位置不对应"); return false; }
		if(vecLine[6]!="MuBiao3"){Debug.Log("MissionKillMonster.csv中字段[MuBiao3]位置不对应"); return false; }
		if(vecLine[7]!="Num3"){Debug.Log("MissionKillMonster.csv中字段[Num3]位置不对应"); return false; }
		if(vecLine[8]!="DaoHang"){Debug.Log("MissionKillMonster.csv中字段[DaoHang]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)9)
			{
				return false;
			}
			MissionKillMonsterElement member = new MissionKillMonsterElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.MuBiao1=Convert.ToInt32(vecLine[2]);
			member.Num1=Convert.ToInt32(vecLine[3]);
			member.MuBiao2=Convert.ToInt32(vecLine[4]);
			member.Num2=Convert.ToInt32(vecLine[5]);
			member.MuBiao3=Convert.ToInt32(vecLine[6]);
			member.Num3=Convert.ToInt32(vecLine[7]);
			member.DaoHang=vecLine[8];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
