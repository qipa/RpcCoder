using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//技能特殊配置配置数据类
public class SkillConfigElement
{
	public int ID;               	//编号	等级
	public string Name;          	//说明	字段说明
	public string Args1;         	//参数1	参数1
	public string Args2;         	//参数2	参数2
	public string Args3;         	//参数3	参数3
	public string Args4;         	//参数4	参数4
	public string Args5;         	//参数5	参数5
	public string Args6;         	//参数6	参数6
	public string Args7;         	//参数7	参数7
	public string JieShi;        	//参数解释	参数解释

	public bool IsValidate = false;
	public SkillConfigElement()
	{
		ID = -1;
	}
};

//技能特殊配置配置封装类
public class SkillConfigTable
{

	private SkillConfigTable()
	{
		m_mapElements = new Dictionary<int, SkillConfigElement>();
		m_emptyItem = new SkillConfigElement();
		m_vecAllElements = new List<SkillConfigElement>();
	}
	private Dictionary<int, SkillConfigElement> m_mapElements = null;
	private List<SkillConfigElement>	m_vecAllElements = null;
	private SkillConfigElement m_emptyItem = null;
	private static SkillConfigTable sInstance = null;

	public static SkillConfigTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new SkillConfigTable();
			return sInstance;
		}
	}

	public SkillConfigElement GetElement(int key)
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

  public List<SkillConfigElement> GetAllElement(Predicate<SkillConfigElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("SkillConfig.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("SkillConfig.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[SkillConfig.bin]未找到");
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
		if(vecLine.Count != 10)
		{
			Ex.Logger.Log("SkillConfig.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SkillConfig.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("SkillConfig.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Args1"){Ex.Logger.Log("SkillConfig.csv中字段[Args1]位置不对应"); return false; }
		if(vecLine[3]!="Args2"){Ex.Logger.Log("SkillConfig.csv中字段[Args2]位置不对应"); return false; }
		if(vecLine[4]!="Args3"){Ex.Logger.Log("SkillConfig.csv中字段[Args3]位置不对应"); return false; }
		if(vecLine[5]!="Args4"){Ex.Logger.Log("SkillConfig.csv中字段[Args4]位置不对应"); return false; }
		if(vecLine[6]!="Args5"){Ex.Logger.Log("SkillConfig.csv中字段[Args5]位置不对应"); return false; }
		if(vecLine[7]!="Args6"){Ex.Logger.Log("SkillConfig.csv中字段[Args6]位置不对应"); return false; }
		if(vecLine[8]!="Args7"){Ex.Logger.Log("SkillConfig.csv中字段[Args7]位置不对应"); return false; }
		if(vecLine[9]!="JieShi"){Ex.Logger.Log("SkillConfig.csv中字段[JieShi]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			SkillConfigElement member = new SkillConfigElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args1);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args2);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args3);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args4);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args5);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args6);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Args7);
			readPos += GameAssist.ReadString( binContent, readPos, out member.JieShi);

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
		if(vecLine.Count != 10)
		{
			Ex.Logger.Log("SkillConfig.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("SkillConfig.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("SkillConfig.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Args1"){Ex.Logger.Log("SkillConfig.csv中字段[Args1]位置不对应"); return false; }
		if(vecLine[3]!="Args2"){Ex.Logger.Log("SkillConfig.csv中字段[Args2]位置不对应"); return false; }
		if(vecLine[4]!="Args3"){Ex.Logger.Log("SkillConfig.csv中字段[Args3]位置不对应"); return false; }
		if(vecLine[5]!="Args4"){Ex.Logger.Log("SkillConfig.csv中字段[Args4]位置不对应"); return false; }
		if(vecLine[6]!="Args5"){Ex.Logger.Log("SkillConfig.csv中字段[Args5]位置不对应"); return false; }
		if(vecLine[7]!="Args6"){Ex.Logger.Log("SkillConfig.csv中字段[Args6]位置不对应"); return false; }
		if(vecLine[8]!="Args7"){Ex.Logger.Log("SkillConfig.csv中字段[Args7]位置不对应"); return false; }
		if(vecLine[9]!="JieShi"){Ex.Logger.Log("SkillConfig.csv中字段[JieShi]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)10)
			{
				return false;
			}
			SkillConfigElement member = new SkillConfigElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Args1=vecLine[2];
			member.Args2=vecLine[3];
			member.Args3=vecLine[4];
			member.Args4=vecLine[5];
			member.Args5=vecLine[6];
			member.Args6=vecLine[7];
			member.Args7=vecLine[8];
			member.JieShi=vecLine[9];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
