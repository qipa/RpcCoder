using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//帮会权限配置数据类
public class BangHuiManagerElement
{
	public int Type;             	//职位类型	1帮主 2 副帮主 3 左长老 4 右长老 5 青龙堂主 6白虎堂主 7朱雀堂主 8玄武堂主 9精英 10帮众
	public string Name;          	//职位名称	职位名称
	public int RenMing;          	//任命关系	最低为1，向下递减任命
	public int PiZhun;           	//批准申请	1可以-1 不可以
	public int YaoQing;          	//邀请其他人	1可以-1不可以
	public int TiChu;            	//踢出其他成员	1可以-1不可以
	public int IsRenMing;        	//是否可以任命	1可以-1不可以
	public int CiZhi;            	//是否可以辞职	1可以-1不可以
	public int Num;              	//职位数量	职位数量

	public bool IsValidate = false;
	public BangHuiManagerElement()
	{
		Type = -1;
	}
};

//帮会权限配置封装类
public class BangHuiManagerTable
{

	private BangHuiManagerTable()
	{
		m_mapElements = new Dictionary<int, BangHuiManagerElement>();
		m_emptyItem = new BangHuiManagerElement();
		m_vecAllElements = new List<BangHuiManagerElement>();
	}
	private Dictionary<int, BangHuiManagerElement> m_mapElements = null;
	private List<BangHuiManagerElement>	m_vecAllElements = null;
	private BangHuiManagerElement m_emptyItem = null;
	private static BangHuiManagerTable sInstance = null;

	public static BangHuiManagerTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new BangHuiManagerTable();
			return sInstance;
		}
	}

	public BangHuiManagerElement GetElement(int key)
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

  public List<BangHuiManagerElement> GetAllElement(Predicate<BangHuiManagerElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("BangHuiManager.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("BangHuiManager.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[BangHuiManager.bin]未找到");
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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("BangHuiManager.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Type"){Ex.Logger.Log("BangHuiManager.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BangHuiManager.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="RenMing"){Ex.Logger.Log("BangHuiManager.csv中字段[RenMing]位置不对应"); return false; }
		if(vecLine[3]!="PiZhun"){Ex.Logger.Log("BangHuiManager.csv中字段[PiZhun]位置不对应"); return false; }
		if(vecLine[4]!="YaoQing"){Ex.Logger.Log("BangHuiManager.csv中字段[YaoQing]位置不对应"); return false; }
		if(vecLine[5]!="TiChu"){Ex.Logger.Log("BangHuiManager.csv中字段[TiChu]位置不对应"); return false; }
		if(vecLine[6]!="IsRenMing"){Ex.Logger.Log("BangHuiManager.csv中字段[IsRenMing]位置不对应"); return false; }
		if(vecLine[7]!="CiZhi"){Ex.Logger.Log("BangHuiManager.csv中字段[CiZhi]位置不对应"); return false; }
		if(vecLine[8]!="Num"){Ex.Logger.Log("BangHuiManager.csv中字段[Num]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			BangHuiManagerElement member = new BangHuiManagerElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.RenMing );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PiZhun );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.YaoQing );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiChu );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IsRenMing );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CiZhi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Num );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Type] = member;
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
		if(vecLine.Count != 9)
		{
			Ex.Logger.Log("BangHuiManager.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Type"){Ex.Logger.Log("BangHuiManager.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("BangHuiManager.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="RenMing"){Ex.Logger.Log("BangHuiManager.csv中字段[RenMing]位置不对应"); return false; }
		if(vecLine[3]!="PiZhun"){Ex.Logger.Log("BangHuiManager.csv中字段[PiZhun]位置不对应"); return false; }
		if(vecLine[4]!="YaoQing"){Ex.Logger.Log("BangHuiManager.csv中字段[YaoQing]位置不对应"); return false; }
		if(vecLine[5]!="TiChu"){Ex.Logger.Log("BangHuiManager.csv中字段[TiChu]位置不对应"); return false; }
		if(vecLine[6]!="IsRenMing"){Ex.Logger.Log("BangHuiManager.csv中字段[IsRenMing]位置不对应"); return false; }
		if(vecLine[7]!="CiZhi"){Ex.Logger.Log("BangHuiManager.csv中字段[CiZhi]位置不对应"); return false; }
		if(vecLine[8]!="Num"){Ex.Logger.Log("BangHuiManager.csv中字段[Num]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)9)
			{
				return false;
			}
			BangHuiManagerElement member = new BangHuiManagerElement();
			member.Type=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.RenMing=Convert.ToInt32(vecLine[2]);
			member.PiZhun=Convert.ToInt32(vecLine[3]);
			member.YaoQing=Convert.ToInt32(vecLine[4]);
			member.TiChu=Convert.ToInt32(vecLine[5]);
			member.IsRenMing=Convert.ToInt32(vecLine[6]);
			member.CiZhi=Convert.ToInt32(vecLine[7]);
			member.Num=Convert.ToInt32(vecLine[8]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Type] = member;
		}
		return true;
	}
};
