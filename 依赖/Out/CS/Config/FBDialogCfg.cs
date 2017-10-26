using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//对话表配置数据类
public class FBDialogElement
{
	public int DialogID;         	//编号	对话ID
	public int Name1;            	//对话人1	对话人1（0：玩家 其他id：填写相应表id）
	public string Dialog1;       	//对话内容1	对话内容1
	public string BanShen;       	//半身像资源	半身像资源（其他的填，玩家自己的不填）
	public int Set;              	//头像位置左右	1 左 2 右
	public int Next;             	//下一段对话	下一段对话
	public float Time;           	//间隔时间	间隔时间

	public bool IsValidate = false;
	public FBDialogElement()
	{
		DialogID = -1;
	}
};

//对话表配置封装类
public class FBDialogTable
{

	private FBDialogTable()
	{
		m_mapElements = new Dictionary<int, FBDialogElement>();
		m_emptyItem = new FBDialogElement();
		m_vecAllElements = new List<FBDialogElement>();
	}
	private Dictionary<int, FBDialogElement> m_mapElements = null;
	private List<FBDialogElement>	m_vecAllElements = null;
	private FBDialogElement m_emptyItem = null;
	private static FBDialogTable sInstance = null;

	public static FBDialogTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FBDialogTable();
			return sInstance;
		}
	}

	public FBDialogElement GetElement(int key)
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

  public List<FBDialogElement> GetAllElement(Predicate<FBDialogElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("FBDialog.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("FBDialog.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[FBDialog.bin]未找到");
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
		if(vecLine.Count != 7)
		{
			Ex.Logger.Log("FBDialog.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="DialogID"){Ex.Logger.Log("FBDialog.csv中字段[DialogID]位置不对应"); return false; }
		if(vecLine[1]!="Name1"){Ex.Logger.Log("FBDialog.csv中字段[Name1]位置不对应"); return false; }
		if(vecLine[2]!="Dialog1"){Ex.Logger.Log("FBDialog.csv中字段[Dialog1]位置不对应"); return false; }
		if(vecLine[3]!="BanShen"){Ex.Logger.Log("FBDialog.csv中字段[BanShen]位置不对应"); return false; }
		if(vecLine[4]!="Set"){Ex.Logger.Log("FBDialog.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[5]!="Next"){Ex.Logger.Log("FBDialog.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[6]!="Time"){Ex.Logger.Log("FBDialog.csv中字段[Time]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FBDialogElement member = new FBDialogElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.DialogID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Name1 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Dialog1);
			readPos += GameAssist.ReadString( binContent, readPos, out member.BanShen);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Set );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Next );
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Time);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.DialogID] = member;
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
		if(vecLine.Count != 7)
		{
			Ex.Logger.Log("FBDialog.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="DialogID"){Ex.Logger.Log("FBDialog.csv中字段[DialogID]位置不对应"); return false; }
		if(vecLine[1]!="Name1"){Ex.Logger.Log("FBDialog.csv中字段[Name1]位置不对应"); return false; }
		if(vecLine[2]!="Dialog1"){Ex.Logger.Log("FBDialog.csv中字段[Dialog1]位置不对应"); return false; }
		if(vecLine[3]!="BanShen"){Ex.Logger.Log("FBDialog.csv中字段[BanShen]位置不对应"); return false; }
		if(vecLine[4]!="Set"){Ex.Logger.Log("FBDialog.csv中字段[Set]位置不对应"); return false; }
		if(vecLine[5]!="Next"){Ex.Logger.Log("FBDialog.csv中字段[Next]位置不对应"); return false; }
		if(vecLine[6]!="Time"){Ex.Logger.Log("FBDialog.csv中字段[Time]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)7)
			{
				return false;
			}
			FBDialogElement member = new FBDialogElement();
			member.DialogID=Convert.ToInt32(vecLine[0]);
			member.Name1=Convert.ToInt32(vecLine[1]);
			member.Dialog1=vecLine[2];
			member.BanShen=vecLine[3];
			member.Set=Convert.ToInt32(vecLine[4]);
			member.Next=Convert.ToInt32(vecLine[5]);
			member.Time=Convert.ToSingle(vecLine[6]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.DialogID] = member;
		}
		return true;
	}
};
