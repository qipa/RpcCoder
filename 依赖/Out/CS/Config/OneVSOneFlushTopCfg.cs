using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//刷新排名的规则配置数据类
public class OneVSOneFlushTopElement
{
	public int ID;               	//编号	等级
	public int StartTop;         	//起始排名段	起始排名段
	public int EndTop;           	//结束排名段	结束排名段
	public int Type;             	//类型	1随机（随机的话就是自己名次到自己名次减去StartFront里随机）0固定（固定的话 就只能是区间寻找给与客户端）
	public int StartFront;       	//前面的起始段	前面的起始段
	public int EndFront;         	//前面的结束段	前面的结束段
	public int StartBack;        	//后面的起始段	后面的起始段
	public int Endback;          	//后面的结束段	后面的结束段

	public bool IsValidate = false;
	public OneVSOneFlushTopElement()
	{
		ID = -1;
	}
};

//刷新排名的规则配置封装类
public class OneVSOneFlushTopTable
{

	private OneVSOneFlushTopTable()
	{
		m_mapElements = new Dictionary<int, OneVSOneFlushTopElement>();
		m_emptyItem = new OneVSOneFlushTopElement();
		m_vecAllElements = new List<OneVSOneFlushTopElement>();
	}
	private Dictionary<int, OneVSOneFlushTopElement> m_mapElements = null;
	private List<OneVSOneFlushTopElement>	m_vecAllElements = null;
	private OneVSOneFlushTopElement m_emptyItem = null;
	private static OneVSOneFlushTopTable sInstance = null;

	public static OneVSOneFlushTopTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new OneVSOneFlushTopTable();
			return sInstance;
		}
	}

	public OneVSOneFlushTopElement GetElement(int key)
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

  public List<OneVSOneFlushTopElement> GetAllElement(Predicate<OneVSOneFlushTopElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("OneVSOneFlushTop.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("OneVSOneFlushTop.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[OneVSOneFlushTop.bin]未找到");
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
			Ex.Logger.Log("OneVSOneFlushTop.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="StartTop"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[StartTop]位置不对应"); return false; }
		if(vecLine[2]!="EndTop"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[EndTop]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="StartFront"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[StartFront]位置不对应"); return false; }
		if(vecLine[5]!="EndFront"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[EndFront]位置不对应"); return false; }
		if(vecLine[6]!="StartBack"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[StartBack]位置不对应"); return false; }
		if(vecLine[7]!="Endback"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[Endback]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			OneVSOneFlushTopElement member = new OneVSOneFlushTopElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.StartTop );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EndTop );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.StartFront );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.EndFront );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.StartBack );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Endback );

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
			Ex.Logger.Log("OneVSOneFlushTop.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="StartTop"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[StartTop]位置不对应"); return false; }
		if(vecLine[2]!="EndTop"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[EndTop]位置不对应"); return false; }
		if(vecLine[3]!="Type"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[4]!="StartFront"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[StartFront]位置不对应"); return false; }
		if(vecLine[5]!="EndFront"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[EndFront]位置不对应"); return false; }
		if(vecLine[6]!="StartBack"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[StartBack]位置不对应"); return false; }
		if(vecLine[7]!="Endback"){Ex.Logger.Log("OneVSOneFlushTop.csv中字段[Endback]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)8)
			{
				return false;
			}
			OneVSOneFlushTopElement member = new OneVSOneFlushTopElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.StartTop=Convert.ToInt32(vecLine[1]);
			member.EndTop=Convert.ToInt32(vecLine[2]);
			member.Type=Convert.ToInt32(vecLine[3]);
			member.StartFront=Convert.ToInt32(vecLine[4]);
			member.EndFront=Convert.ToInt32(vecLine[5]);
			member.StartBack=Convert.ToInt32(vecLine[6]);
			member.Endback=Convert.ToInt32(vecLine[7]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
