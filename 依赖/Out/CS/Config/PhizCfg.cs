using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//表情表配置数据类
public class PhizElement
{
	public int ID;               	//ID	ID
	public int SeriesNumber;     	//排列序号	排列序号
	public string ShortcutKey;   	//表情快捷键	表情快捷键
	public string ResourceName;  	//资源名称	资源名称
	public int Wide;             	//帧动画宽	1帧动画宽
	public int High;             	//帧动画高	1帧动画高
	public int AnimationFrameCount;	//帧总数	帧总数

	public bool IsValidate = false;
	public PhizElement()
	{
		ID = -1;
	}
};

//表情表配置封装类
public class PhizTable
{

	private PhizTable()
	{
		m_mapElements = new Dictionary<int, PhizElement>();
		m_emptyItem = new PhizElement();
		m_vecAllElements = new List<PhizElement>();
	}
	private Dictionary<int, PhizElement> m_mapElements = null;
	private List<PhizElement>	m_vecAllElements = null;
	private PhizElement m_emptyItem = null;
	private static PhizTable sInstance = null;

	public static PhizTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new PhizTable();
			return sInstance;
		}
	}

	public PhizElement GetElement(int key)
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

  public List<PhizElement> GetAllElement(Predicate<PhizElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Phiz.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Phiz.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Phiz.bin]未找到");
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
			Ex.Logger.Log("Phiz.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Phiz.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SeriesNumber"){Ex.Logger.Log("Phiz.csv中字段[SeriesNumber]位置不对应"); return false; }
		if(vecLine[2]!="ShortcutKey"){Ex.Logger.Log("Phiz.csv中字段[ShortcutKey]位置不对应"); return false; }
		if(vecLine[3]!="ResourceName"){Ex.Logger.Log("Phiz.csv中字段[ResourceName]位置不对应"); return false; }
		if(vecLine[4]!="Wide"){Ex.Logger.Log("Phiz.csv中字段[Wide]位置不对应"); return false; }
		if(vecLine[5]!="High"){Ex.Logger.Log("Phiz.csv中字段[High]位置不对应"); return false; }
		if(vecLine[6]!="AnimationFrameCount"){Ex.Logger.Log("Phiz.csv中字段[AnimationFrameCount]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			PhizElement member = new PhizElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SeriesNumber );
			readPos += GameAssist.ReadString( binContent, readPos, out member.ShortcutKey);
			readPos += GameAssist.ReadString( binContent, readPos, out member.ResourceName);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Wide );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.High );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AnimationFrameCount );

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
		if(vecLine.Count != 7)
		{
			Ex.Logger.Log("Phiz.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("Phiz.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="SeriesNumber"){Ex.Logger.Log("Phiz.csv中字段[SeriesNumber]位置不对应"); return false; }
		if(vecLine[2]!="ShortcutKey"){Ex.Logger.Log("Phiz.csv中字段[ShortcutKey]位置不对应"); return false; }
		if(vecLine[3]!="ResourceName"){Ex.Logger.Log("Phiz.csv中字段[ResourceName]位置不对应"); return false; }
		if(vecLine[4]!="Wide"){Ex.Logger.Log("Phiz.csv中字段[Wide]位置不对应"); return false; }
		if(vecLine[5]!="High"){Ex.Logger.Log("Phiz.csv中字段[High]位置不对应"); return false; }
		if(vecLine[6]!="AnimationFrameCount"){Ex.Logger.Log("Phiz.csv中字段[AnimationFrameCount]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)7)
			{
				return false;
			}
			PhizElement member = new PhizElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.SeriesNumber=Convert.ToInt32(vecLine[1]);
			member.ShortcutKey=vecLine[2];
			member.ResourceName=vecLine[3];
			member.Wide=Convert.ToInt32(vecLine[4]);
			member.High=Convert.ToInt32(vecLine[5]);
			member.AnimationFrameCount=Convert.ToInt32(vecLine[6]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
