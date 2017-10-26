using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//引导触发配置数据类
public class GuideElement
{
	public int ID;               	//指引触发器id	指引触发器id
	public string Name;          	//指引名字	指引名字
	public string GuideTrigger;  	//触发类型	0 任务接取[0,任务ID] 1：任务 完成 [1,任务ID] 2:进入主城[2,0] 3:打开某个界面[3,"view层的名字"] 4:进入副本[4,0]  5：完成对话[5,对话ID] 
	public int GuideReset;       	//未完成是否继续 0重置 1不重置	暂代参数
	public int GuideLinear;      	//是否是线性	0线性1非线性
	public string GuideSteps;    	//引导步骤组	引导步骤组[1,2,3]GuideSteps内的id

	public bool IsValidate = false;
	public GuideElement()
	{
		ID = -1;
	}
};

//引导触发配置封装类
public class GuideTable
{

	private GuideTable()
	{
		m_mapElements = new Dictionary<int, GuideElement>();
		m_emptyItem = new GuideElement();
		m_vecAllElements = new List<GuideElement>();
	}
	private Dictionary<int, GuideElement> m_mapElements = null;
	private List<GuideElement>	m_vecAllElements = null;
	private GuideElement m_emptyItem = null;
	private static GuideTable sInstance = null;

	public static GuideTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new GuideTable();
			return sInstance;
		}
	}

	public GuideElement GetElement(int key)
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

  public List<GuideElement> GetAllElement(Predicate<GuideElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Guide.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Guide.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Guide.bin]未找到");
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
			Ex.Logger.Log("Guide.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Guide.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Guide.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="GuideTrigger"){Ex.Logger.Log("Guide.csv中字段[GuideTrigger]位置不对应"); return false; }
		if(vecLine[3]!="GuideReset"){Ex.Logger.Log("Guide.csv中字段[GuideReset]位置不对应"); return false; }
		if(vecLine[4]!="GuideLinear"){Ex.Logger.Log("Guide.csv中字段[GuideLinear]位置不对应"); return false; }
		if(vecLine[5]!="GuideSteps"){Ex.Logger.Log("Guide.csv中字段[GuideSteps]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			GuideElement member = new GuideElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.GuideTrigger);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GuideReset );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GuideLinear );
			readPos += GameAssist.ReadString( binContent, readPos, out member.GuideSteps);

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
			Ex.Logger.Log("Guide.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Guide.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Guide.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="GuideTrigger"){Ex.Logger.Log("Guide.csv中字段[GuideTrigger]位置不对应"); return false; }
		if(vecLine[3]!="GuideReset"){Ex.Logger.Log("Guide.csv中字段[GuideReset]位置不对应"); return false; }
		if(vecLine[4]!="GuideLinear"){Ex.Logger.Log("Guide.csv中字段[GuideLinear]位置不对应"); return false; }
		if(vecLine[5]!="GuideSteps"){Ex.Logger.Log("Guide.csv中字段[GuideSteps]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)6)
			{
				return false;
			}
			GuideElement member = new GuideElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.GuideTrigger=vecLine[2];
			member.GuideReset=Convert.ToInt32(vecLine[3]);
			member.GuideLinear=Convert.ToInt32(vecLine[4]);
			member.GuideSteps=vecLine[5];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
