using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//师门任务类别表配置数据类
public class ShimenTypeElement
{
	public int ID;               	//编号	仅仅是序号
	public int Lvl;              	//等级	玩家等级
	public int Res;              	//环数	每轮的环数
	public int TypePro1;         	//类别1	类别1的权重概率
	public string Type1;         	//类别1	类别1任务列表
	public int TypePro2;         	//类别2	类别2的权重概率
	public string Type2;         	//类别2	类别2任务列表
	public int TypePro3;         	//类别3	类别3的权重概率
	public string Type3;         	//类别3	类别3任务列表
	public int TypePro4;         	//类别4	类别4的权重概率
	public string Type4;         	//类别4	类别4任务列表
	public int ExpReward;        	//经验	经验奖励
	public int MoneyReward;      	//金钱	金钱奖励
	public int SpecialRewardId;  	//特殊奖励	特殊奖励的掉落列ID
	public int SpecialRewardPro; 	//特殊奖励概率	特殊奖励概率万分比

	public bool IsValidate = false;
	public ShimenTypeElement()
	{
		ID = -1;
	}
};

//师门任务类别表配置封装类
public class ShimenTypeTable
{

	private ShimenTypeTable()
	{
		m_mapElements = new Dictionary<int, ShimenTypeElement>();
		m_emptyItem = new ShimenTypeElement();
		m_vecAllElements = new List<ShimenTypeElement>();
	}
	private Dictionary<int, ShimenTypeElement> m_mapElements = null;
	private List<ShimenTypeElement>	m_vecAllElements = null;
	private ShimenTypeElement m_emptyItem = null;
	private static ShimenTypeTable sInstance = null;

	public static ShimenTypeTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ShimenTypeTable();
			return sInstance;
		}
	}

	public ShimenTypeElement GetElement(int key)
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

  public List<ShimenTypeElement> GetAllElement(Predicate<ShimenTypeElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("ShimenType.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("ShimenType.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[ShimenType.bin]未找到");
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
		if(vecLine.Count != 15)
		{
			Ex.Logger.Log("ShimenType.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("ShimenType.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Lvl"){Ex.Logger.Log("ShimenType.csv中字段[Lvl]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Ex.Logger.Log("ShimenType.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="TypePro1"){Ex.Logger.Log("ShimenType.csv中字段[TypePro1]位置不对应"); return false; }
		if(vecLine[4]!="Type1"){Ex.Logger.Log("ShimenType.csv中字段[Type1]位置不对应"); return false; }
		if(vecLine[5]!="TypePro2"){Ex.Logger.Log("ShimenType.csv中字段[TypePro2]位置不对应"); return false; }
		if(vecLine[6]!="Type2"){Ex.Logger.Log("ShimenType.csv中字段[Type2]位置不对应"); return false; }
		if(vecLine[7]!="TypePro3"){Ex.Logger.Log("ShimenType.csv中字段[TypePro3]位置不对应"); return false; }
		if(vecLine[8]!="Type3"){Ex.Logger.Log("ShimenType.csv中字段[Type3]位置不对应"); return false; }
		if(vecLine[9]!="TypePro4"){Ex.Logger.Log("ShimenType.csv中字段[TypePro4]位置不对应"); return false; }
		if(vecLine[10]!="Type4"){Ex.Logger.Log("ShimenType.csv中字段[Type4]位置不对应"); return false; }
		if(vecLine[11]!="ExpReward"){Ex.Logger.Log("ShimenType.csv中字段[ExpReward]位置不对应"); return false; }
		if(vecLine[12]!="MoneyReward"){Ex.Logger.Log("ShimenType.csv中字段[MoneyReward]位置不对应"); return false; }
		if(vecLine[13]!="SpecialRewardId"){Ex.Logger.Log("ShimenType.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[14]!="SpecialRewardPro"){Ex.Logger.Log("ShimenType.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ShimenTypeElement member = new ShimenTypeElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lvl );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Res );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TypePro1 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Type1);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TypePro2 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Type2);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TypePro3 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Type3);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TypePro4 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Type4);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ExpReward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MoneyReward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SpecialRewardId );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SpecialRewardPro );

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
		if(vecLine.Count != 15)
		{
			Ex.Logger.Log("ShimenType.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("ShimenType.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Lvl"){Ex.Logger.Log("ShimenType.csv中字段[Lvl]位置不对应"); return false; }
		if(vecLine[2]!="Res"){Ex.Logger.Log("ShimenType.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[3]!="TypePro1"){Ex.Logger.Log("ShimenType.csv中字段[TypePro1]位置不对应"); return false; }
		if(vecLine[4]!="Type1"){Ex.Logger.Log("ShimenType.csv中字段[Type1]位置不对应"); return false; }
		if(vecLine[5]!="TypePro2"){Ex.Logger.Log("ShimenType.csv中字段[TypePro2]位置不对应"); return false; }
		if(vecLine[6]!="Type2"){Ex.Logger.Log("ShimenType.csv中字段[Type2]位置不对应"); return false; }
		if(vecLine[7]!="TypePro3"){Ex.Logger.Log("ShimenType.csv中字段[TypePro3]位置不对应"); return false; }
		if(vecLine[8]!="Type3"){Ex.Logger.Log("ShimenType.csv中字段[Type3]位置不对应"); return false; }
		if(vecLine[9]!="TypePro4"){Ex.Logger.Log("ShimenType.csv中字段[TypePro4]位置不对应"); return false; }
		if(vecLine[10]!="Type4"){Ex.Logger.Log("ShimenType.csv中字段[Type4]位置不对应"); return false; }
		if(vecLine[11]!="ExpReward"){Ex.Logger.Log("ShimenType.csv中字段[ExpReward]位置不对应"); return false; }
		if(vecLine[12]!="MoneyReward"){Ex.Logger.Log("ShimenType.csv中字段[MoneyReward]位置不对应"); return false; }
		if(vecLine[13]!="SpecialRewardId"){Ex.Logger.Log("ShimenType.csv中字段[SpecialRewardId]位置不对应"); return false; }
		if(vecLine[14]!="SpecialRewardPro"){Ex.Logger.Log("ShimenType.csv中字段[SpecialRewardPro]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)15)
			{
				return false;
			}
			ShimenTypeElement member = new ShimenTypeElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Lvl=Convert.ToInt32(vecLine[1]);
			member.Res=Convert.ToInt32(vecLine[2]);
			member.TypePro1=Convert.ToInt32(vecLine[3]);
			member.Type1=vecLine[4];
			member.TypePro2=Convert.ToInt32(vecLine[5]);
			member.Type2=vecLine[6];
			member.TypePro3=Convert.ToInt32(vecLine[7]);
			member.Type3=vecLine[8];
			member.TypePro4=Convert.ToInt32(vecLine[9]);
			member.Type4=vecLine[10];
			member.ExpReward=Convert.ToInt32(vecLine[11]);
			member.MoneyReward=Convert.ToInt32(vecLine[12]);
			member.SpecialRewardId=Convert.ToInt32(vecLine[13]);
			member.SpecialRewardPro=Convert.ToInt32(vecLine[14]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
