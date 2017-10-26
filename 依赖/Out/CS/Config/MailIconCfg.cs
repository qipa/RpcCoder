using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//邮件标识配置数据类
public class MailIconElement
{
	public int ID;               	//索引用ID	索引用ID
	public string Desc;          	//描述	策划用备注
	public string Unread;        	//未读的资源ID	未读的资源ID
	public string Read;          	//已读资源ID	已读资源ID

	public bool IsValidate = false;
	public MailIconElement()
	{
		ID = -1;
	}
};

//邮件标识配置封装类
public class MailIconTable
{

	private MailIconTable()
	{
		m_mapElements = new Dictionary<int, MailIconElement>();
		m_emptyItem = new MailIconElement();
		m_vecAllElements = new List<MailIconElement>();
	}
	private Dictionary<int, MailIconElement> m_mapElements = null;
	private List<MailIconElement>	m_vecAllElements = null;
	private MailIconElement m_emptyItem = null;
	private static MailIconTable sInstance = null;

	public static MailIconTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MailIconTable();
			return sInstance;
		}
	}

	public MailIconElement GetElement(int key)
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

  public List<MailIconElement> GetAllElement(Predicate<MailIconElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("MailIcon.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("MailIcon.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[MailIcon.bin]未找到");
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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("MailIcon.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MailIcon.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Desc"){Ex.Logger.Log("MailIcon.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[2]!="Unread"){Ex.Logger.Log("MailIcon.csv中字段[Unread]位置不对应"); return false; }
		if(vecLine[3]!="Read"){Ex.Logger.Log("MailIcon.csv中字段[Read]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MailIconElement member = new MailIconElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Desc);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Unread);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Read);

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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("MailIcon.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("MailIcon.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Desc"){Ex.Logger.Log("MailIcon.csv中字段[Desc]位置不对应"); return false; }
		if(vecLine[2]!="Unread"){Ex.Logger.Log("MailIcon.csv中字段[Unread]位置不对应"); return false; }
		if(vecLine[3]!="Read"){Ex.Logger.Log("MailIcon.csv中字段[Read]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			MailIconElement member = new MailIconElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Desc=vecLine[1];
			member.Unread=vecLine[2];
			member.Read=vecLine[3];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
