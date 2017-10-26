using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//聊天信息表配置数据类
public class ChatMsgElement
{
	public int ID;               	//信息的ID	信息的ID
	public int Type;             	//频道类型	1系统频道2世界频道3当前频道4门派频道5帮派频道6队伍频道7组队频道8邮件文本
	public int TabId;            	//频道页签	频道页签
	public int ShowType;         	//信息发送者	1页签加文字2角色气泡
	public string Comment;       	//模板注释	模板注释
	public string Msg;           	//文本信息	文本信息

	public bool IsValidate = false;
	public ChatMsgElement()
	{
		ID = -1;
	}
};

//聊天信息表配置封装类
public class ChatMsgTable
{

	private ChatMsgTable()
	{
		m_mapElements = new Dictionary<int, ChatMsgElement>();
		m_emptyItem = new ChatMsgElement();
		m_vecAllElements = new List<ChatMsgElement>();
	}
	private Dictionary<int, ChatMsgElement> m_mapElements = null;
	private List<ChatMsgElement>	m_vecAllElements = null;
	private ChatMsgElement m_emptyItem = null;
	private static ChatMsgTable sInstance = null;

	public static ChatMsgTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ChatMsgTable();
			return sInstance;
		}
	}

	public ChatMsgElement GetElement(int key)
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

  public List<ChatMsgElement> GetAllElement(Predicate<ChatMsgElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("ChatMsg.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("ChatMsg.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[ChatMsg.bin]未找到");
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
			Ex.Logger.Log("ChatMsg.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("ChatMsg.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("ChatMsg.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="TabId"){Ex.Logger.Log("ChatMsg.csv中字段[TabId]位置不对应"); return false; }
		if(vecLine[3]!="ShowType"){Ex.Logger.Log("ChatMsg.csv中字段[ShowType]位置不对应"); return false; }
		if(vecLine[4]!="Comment"){Ex.Logger.Log("ChatMsg.csv中字段[Comment]位置不对应"); return false; }
		if(vecLine[5]!="Msg"){Ex.Logger.Log("ChatMsg.csv中字段[Msg]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ChatMsgElement member = new ChatMsgElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TabId );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShowType );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Comment);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Msg);

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
			Ex.Logger.Log("ChatMsg.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("ChatMsg.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Type"){Ex.Logger.Log("ChatMsg.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[2]!="TabId"){Ex.Logger.Log("ChatMsg.csv中字段[TabId]位置不对应"); return false; }
		if(vecLine[3]!="ShowType"){Ex.Logger.Log("ChatMsg.csv中字段[ShowType]位置不对应"); return false; }
		if(vecLine[4]!="Comment"){Ex.Logger.Log("ChatMsg.csv中字段[Comment]位置不对应"); return false; }
		if(vecLine[5]!="Msg"){Ex.Logger.Log("ChatMsg.csv中字段[Msg]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			ChatMsgElement member = new ChatMsgElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Type=Convert.ToInt32(vecLine[1]);
			member.TabId=Convert.ToInt32(vecLine[2]);
			member.ShowType=Convert.ToInt32(vecLine[3]);
			member.Comment=vecLine[4];
			member.Msg=vecLine[5];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
