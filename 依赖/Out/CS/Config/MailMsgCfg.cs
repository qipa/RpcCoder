using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//邮件信息配置数据类
public class MailMsgElement
{
	public int ID;               	//索引用ID	索引用ID
	public int MailType;         	//邮件类型	1自动删除2手动删除
	public int IconType;         	//邮件图标类型	邮件图标类型
	public string MailTitle;     	//邮件标题	邮件标题
	public int MailText;         	//邮件文本	邮件文本

	public bool IsValidate = false;
	public MailMsgElement()
	{
		ID = -1;
	}
};

//邮件信息配置封装类
public class MailMsgTable
{

	private MailMsgTable()
	{
		m_mapElements = new Dictionary<int, MailMsgElement>();
		m_emptyItem = new MailMsgElement();
		m_vecAllElements = new List<MailMsgElement>();
	}
	private Dictionary<int, MailMsgElement> m_mapElements = null;
	private List<MailMsgElement>	m_vecAllElements = null;
	private MailMsgElement m_emptyItem = null;
	private static MailMsgTable sInstance = null;

	public static MailMsgTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MailMsgTable();
			return sInstance;
		}
	}

	public MailMsgElement GetElement(int key)
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

  public List<MailMsgElement> GetAllElement(Predicate<MailMsgElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MailMsg.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MailMsg.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[MailMsg.bin]未找到");
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
			Ex.Logger.Log("MailMsg.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MailMsg.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="MailType"){Ex.Logger.Log("MailMsg.csv中字段[MailType]位置不对应"); return false; }
		if(vecLine[2]!="IconType"){Ex.Logger.Log("MailMsg.csv中字段[IconType]位置不对应"); return false; }
		if(vecLine[3]!="MailTitle"){Ex.Logger.Log("MailMsg.csv中字段[MailTitle]位置不对应"); return false; }
		if(vecLine[4]!="MailText"){Ex.Logger.Log("MailMsg.csv中字段[MailText]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MailMsgElement member = new MailMsgElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MailType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IconType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.MailTitle);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MailText );

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
			Ex.Logger.Log("MailMsg.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MailMsg.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="MailType"){Ex.Logger.Log("MailMsg.csv中字段[MailType]位置不对应"); return false; }
		if(vecLine[2]!="IconType"){Ex.Logger.Log("MailMsg.csv中字段[IconType]位置不对应"); return false; }
		if(vecLine[3]!="MailTitle"){Ex.Logger.Log("MailMsg.csv中字段[MailTitle]位置不对应"); return false; }
		if(vecLine[4]!="MailText"){Ex.Logger.Log("MailMsg.csv中字段[MailText]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)5)
			{
				return false;
			}
			MailMsgElement member = new MailMsgElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.MailType=Convert.ToInt32(vecLine[1]);
			member.IconType=Convert.ToInt32(vecLine[2]);
			member.MailTitle=vecLine[3];
			member.MailText=Convert.ToInt32(vecLine[4]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
