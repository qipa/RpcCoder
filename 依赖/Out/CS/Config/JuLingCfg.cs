using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//聚灵表配置数据类
public class JuLingElement
{
	public int ID;               	//编号	聚灵技能ID
	public int ItemID;           	//道具ID	道具ID
	public int SkillID;          	//被动技能ID	被动技能ID
	public int Type;             	//技能类型	1攻击2防御3敏捷4上古
	public int Lv;               	//等级	等级
	public int NextID;           	//下一级ID	下一级ID
	public int Money;            	//升级消耗金钱	升级消耗金钱
	public int ItemNum;          	//升级消耗道具数量	升级消耗道具数量

	public bool IsValidate = false;
	public JuLingElement()
	{
		ID = -1;
	}
};

//聚灵表配置封装类
public class JuLingTable
{

	private JuLingTable()
	{
		m_mapElements = new Dictionary<int, JuLingElement>();
		m_emptyItem = new JuLingElement();
		m_vecAllElements = new List<JuLingElement>();
	}
	private Dictionary<int, JuLingElement> m_mapElements = null;
	private List<JuLingElement>	m_vecAllElements = null;
	private JuLingElement m_emptyItem = null;
	private static JuLingTable sInstance = null;

	public static JuLingTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new JuLingTable();
			return sInstance;
		}
	}

	public JuLingElement GetElement(int key)
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

  public List<JuLingElement> GetAllElement(Predicate<JuLingElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("JuLing.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("JuLing.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[JuLing.bin]未找到");
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
			Ex.Logger.Log("JuLing.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("JuLing.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ItemID"){Ex.Logger.Log("JuLing.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[2]!="SkillID"){Ex.Logger.Log("JuLing.csv中字段[SkillID]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("JuLing.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Lv"){Ex.Logger.Log("JuLing.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[5]!="NextID"){Ex.Logger.Log("JuLing.csv中字段[NextID]位置不对应"); return false; }
		if(vecLine[6]!="Money"){Ex.Logger.Log("JuLing.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[7]!="ItemNum"){Ex.Logger.Log("JuLing.csv中字段[ItemNum]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			JuLingElement member = new JuLingElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.NextID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Money );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ItemNum );

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
			Ex.Logger.Log("JuLing.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("JuLing.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="ItemID"){Ex.Logger.Log("JuLing.csv中字段[ItemID]位置不对应"); return false; }
		if(vecLine[2]!="SkillID"){Ex.Logger.Log("JuLing.csv中字段[SkillID]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("JuLing.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="Lv"){Ex.Logger.Log("JuLing.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[5]!="NextID"){Ex.Logger.Log("JuLing.csv中字段[NextID]位置不对应"); return false; }
		if(vecLine[6]!="Money"){Ex.Logger.Log("JuLing.csv中字段[Money]位置不对应"); return false; }
		if(vecLine[7]!="ItemNum"){Ex.Logger.Log("JuLing.csv中字段[ItemNum]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)8)
			{
				return false;
			}
			JuLingElement member = new JuLingElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.ItemID=Convert.ToInt32(vecLine[1]);
			member.SkillID=Convert.ToInt32(vecLine[2]);
			member.Type=Convert.ToInt32(vecLine[3]);
			member.Lv=Convert.ToInt32(vecLine[4]);
			member.NextID=Convert.ToInt32(vecLine[5]);
			member.Money=Convert.ToInt32(vecLine[6]);
			member.ItemNum=Convert.ToInt32(vecLine[7]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
