using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//送信任务配置数据类
public class MissionDialogElement
{
	public int ID;               	//编号	物品ID
	public string Name;          	//任务名称	官阶名称
	public int MuBiao1;          	//目标Npc1	目标Npc1
	public int MuBiao2;          	//目标Npc2	目标Npc2
	public int MuBiao3;          	//目标Npc3	目标Npc3
	public string DaoHang;       	//任务导航	任务导航

	public bool IsValidate = false;
	public MissionDialogElement()
	{
		ID = -1;
	}
};

//送信任务配置封装类
public class MissionDialogTable
{

	private MissionDialogTable()
	{
		m_mapElements = new Dictionary<int, MissionDialogElement>();
		m_emptyItem = new MissionDialogElement();
		m_vecAllElements = new List<MissionDialogElement>();
	}
	private Dictionary<int, MissionDialogElement> m_mapElements = null;
	private List<MissionDialogElement>	m_vecAllElements = null;
	private MissionDialogElement m_emptyItem = null;
	private static MissionDialogTable sInstance = null;

	public static MissionDialogTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MissionDialogTable();
			return sInstance;
		}
	}

	public MissionDialogElement GetElement(int key)
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

  public List<MissionDialogElement> GetAllElement(Predicate<MissionDialogElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MissionDialog.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MissionDialog.bin", out binTableContent ) )
		{
			Debug.Log("配置文件[MissionDialog.bin]未找到");
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
			Debug.Log("MissionDialog.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("MissionDialog.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Debug.Log("MissionDialog.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MuBiao1"){Debug.Log("MissionDialog.csv中字段[MuBiao1]位置不对应"); return false; }
		if(vecLine[3]!="MuBiao2"){Debug.Log("MissionDialog.csv中字段[MuBiao2]位置不对应"); return false; }
		if(vecLine[4]!="MuBiao3"){Debug.Log("MissionDialog.csv中字段[MuBiao3]位置不对应"); return false; }
		if(vecLine[5]!="DaoHang"){Debug.Log("MissionDialog.csv中字段[DaoHang]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MissionDialogElement member = new MissionDialogElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao1 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao2 );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MuBiao3 );
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
		if(vecLine.Count != 6)
		{
			Debug.Log("MissionDialog.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("MissionDialog.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Debug.Log("MissionDialog.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="MuBiao1"){Debug.Log("MissionDialog.csv中字段[MuBiao1]位置不对应"); return false; }
		if(vecLine[3]!="MuBiao2"){Debug.Log("MissionDialog.csv中字段[MuBiao2]位置不对应"); return false; }
		if(vecLine[4]!="MuBiao3"){Debug.Log("MissionDialog.csv中字段[MuBiao3]位置不对应"); return false; }
		if(vecLine[5]!="DaoHang"){Debug.Log("MissionDialog.csv中字段[DaoHang]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			MissionDialogElement member = new MissionDialogElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.MuBiao1=Convert.ToInt32(vecLine[2]);
			member.MuBiao2=Convert.ToInt32(vecLine[3]);
			member.MuBiao3=Convert.ToInt32(vecLine[4]);
			member.DaoHang=vecLine[5];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
