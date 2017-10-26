using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//任务基础表配置数据类
public class MissionElement
{
	public int MissionID;        	//编号	任务ID
	public string Name;          	//任务名称	任务名称
	public int Type;             	//任务分类	1日常2主线3活动4师门任务5帮会
	public string Title;         	//任务标签	任务标签
	public int Lv;               	//任务等级	任务等级
	public int Reward;           	//奖励	奖励
	public int TiaoJian;         	//条件	条件
	public int JieNpc;           	//接任务NPC	接任务NPC
	public int JiaoNpc;          	//交任务NPC	交任务NPC
	public int Dialog1;          	//接任务对话	接任务对话
	public string Dialog2;       	//接任务面板显示	接任务面板显示
	public string Dialog3;       	//交任务面板对话	交任务面板对话
	public int IngDialog;        	//未完成时对白	未完成时对白
	public string Tips;          	//任务描述	任务描述
	public int Time;             	//限时	限时
	public int Index;            	//下个任务ID	下个任务ID
	public int QianZhi;          	//前置任务	前置任务
	public int Monster;          	//关联怪物	关联怪物
	public int Plant;            	//关联种植物	关联种植物
	public int Npc;              	//关联NPC	关联NPC
	public int FuBen;            	//关联副本	关联副本
	public int FuBenLimit;       	//进入副本限制	1条件 2 条件2 3条件3
	public int Target;           	//任务目标方案	1顺序 2 并列 3 只完成最后目标
	public int ZiDong;           	//自动完成	自动完成
	public int TiJiao;           	//是否自动提交	是否自动提交

	public bool IsValidate = false;
	public MissionElement()
	{
		MissionID = -1;
	}
};

//任务基础表配置封装类
public class MissionTable
{

	private MissionTable()
	{
		m_mapElements = new Dictionary<int, MissionElement>();
		m_emptyItem = new MissionElement();
		m_vecAllElements = new List<MissionElement>();
	}
	private Dictionary<int, MissionElement> m_mapElements = null;
	private List<MissionElement>	m_vecAllElements = null;
	private MissionElement m_emptyItem = null;
	private static MissionTable sInstance = null;

	public static MissionTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new MissionTable();
			return sInstance;
		}
	}

	public MissionElement GetElement(int key)
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

  public List<MissionElement> GetAllElement(Predicate<MissionElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("Mission.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("Mission.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[Mission.bin]未找到");
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
		if(vecLine.Count != 25)
		{
			Ex.Logger.Log("Mission.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MissionID"){Ex.Logger.Log("Mission.csv中字段[MissionID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Mission.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("Mission.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="Title"){Ex.Logger.Log("Mission.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[4]!="Lv"){Ex.Logger.Log("Mission.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[5]!="Reward"){Ex.Logger.Log("Mission.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[6]!="TiaoJian"){Ex.Logger.Log("Mission.csv中字段[TiaoJian]位置不对应"); return false; }
		if(vecLine[7]!="JieNpc"){Ex.Logger.Log("Mission.csv中字段[JieNpc]位置不对应"); return false; }
		if(vecLine[8]!="JiaoNpc"){Ex.Logger.Log("Mission.csv中字段[JiaoNpc]位置不对应"); return false; }
		if(vecLine[9]!="Dialog1"){Ex.Logger.Log("Mission.csv中字段[Dialog1]位置不对应"); return false; }
		if(vecLine[10]!="Dialog2"){Ex.Logger.Log("Mission.csv中字段[Dialog2]位置不对应"); return false; }
		if(vecLine[11]!="Dialog3"){Ex.Logger.Log("Mission.csv中字段[Dialog3]位置不对应"); return false; }
		if(vecLine[12]!="IngDialog"){Ex.Logger.Log("Mission.csv中字段[IngDialog]位置不对应"); return false; }
		if(vecLine[13]!="Tips"){Ex.Logger.Log("Mission.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[14]!="Time"){Ex.Logger.Log("Mission.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[15]!="Index"){Ex.Logger.Log("Mission.csv中字段[Index]位置不对应"); return false; }
		if(vecLine[16]!="QianZhi"){Ex.Logger.Log("Mission.csv中字段[QianZhi]位置不对应"); return false; }
		if(vecLine[17]!="Monster"){Ex.Logger.Log("Mission.csv中字段[Monster]位置不对应"); return false; }
		if(vecLine[18]!="Plant"){Ex.Logger.Log("Mission.csv中字段[Plant]位置不对应"); return false; }
		if(vecLine[19]!="Npc"){Ex.Logger.Log("Mission.csv中字段[Npc]位置不对应"); return false; }
		if(vecLine[20]!="FuBen"){Ex.Logger.Log("Mission.csv中字段[FuBen]位置不对应"); return false; }
		if(vecLine[21]!="FuBenLimit"){Ex.Logger.Log("Mission.csv中字段[FuBenLimit]位置不对应"); return false; }
		if(vecLine[22]!="Target"){Ex.Logger.Log("Mission.csv中字段[Target]位置不对应"); return false; }
		if(vecLine[23]!="ZiDong"){Ex.Logger.Log("Mission.csv中字段[ZiDong]位置不对应"); return false; }
		if(vecLine[24]!="TiJiao"){Ex.Logger.Log("Mission.csv中字段[TiJiao]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			MissionElement member = new MissionElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MissionID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Type );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Title);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lv );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Reward );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiaoJian );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.JieNpc );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.JiaoNpc );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Dialog1 );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Dialog2);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Dialog3);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.IngDialog );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Tips);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Time );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Index );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.QianZhi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Monster );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Plant );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Npc );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FuBen );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.FuBenLimit );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Target );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ZiDong );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TiJiao );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MissionID] = member;
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
		if(vecLine.Count != 25)
		{
			Ex.Logger.Log("Mission.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="MissionID"){Ex.Logger.Log("Mission.csv中字段[MissionID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("Mission.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="Type"){Ex.Logger.Log("Mission.csv中字段[Type]位置不对应"); return false; }
		if(vecLine[3]!="Title"){Ex.Logger.Log("Mission.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[4]!="Lv"){Ex.Logger.Log("Mission.csv中字段[Lv]位置不对应"); return false; }
		if(vecLine[5]!="Reward"){Ex.Logger.Log("Mission.csv中字段[Reward]位置不对应"); return false; }
		if(vecLine[6]!="TiaoJian"){Ex.Logger.Log("Mission.csv中字段[TiaoJian]位置不对应"); return false; }
		if(vecLine[7]!="JieNpc"){Ex.Logger.Log("Mission.csv中字段[JieNpc]位置不对应"); return false; }
		if(vecLine[8]!="JiaoNpc"){Ex.Logger.Log("Mission.csv中字段[JiaoNpc]位置不对应"); return false; }
		if(vecLine[9]!="Dialog1"){Ex.Logger.Log("Mission.csv中字段[Dialog1]位置不对应"); return false; }
		if(vecLine[10]!="Dialog2"){Ex.Logger.Log("Mission.csv中字段[Dialog2]位置不对应"); return false; }
		if(vecLine[11]!="Dialog3"){Ex.Logger.Log("Mission.csv中字段[Dialog3]位置不对应"); return false; }
		if(vecLine[12]!="IngDialog"){Ex.Logger.Log("Mission.csv中字段[IngDialog]位置不对应"); return false; }
		if(vecLine[13]!="Tips"){Ex.Logger.Log("Mission.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[14]!="Time"){Ex.Logger.Log("Mission.csv中字段[Time]位置不对应"); return false; }
		if(vecLine[15]!="Index"){Ex.Logger.Log("Mission.csv中字段[Index]位置不对应"); return false; }
		if(vecLine[16]!="QianZhi"){Ex.Logger.Log("Mission.csv中字段[QianZhi]位置不对应"); return false; }
		if(vecLine[17]!="Monster"){Ex.Logger.Log("Mission.csv中字段[Monster]位置不对应"); return false; }
		if(vecLine[18]!="Plant"){Ex.Logger.Log("Mission.csv中字段[Plant]位置不对应"); return false; }
		if(vecLine[19]!="Npc"){Ex.Logger.Log("Mission.csv中字段[Npc]位置不对应"); return false; }
		if(vecLine[20]!="FuBen"){Ex.Logger.Log("Mission.csv中字段[FuBen]位置不对应"); return false; }
		if(vecLine[21]!="FuBenLimit"){Ex.Logger.Log("Mission.csv中字段[FuBenLimit]位置不对应"); return false; }
		if(vecLine[22]!="Target"){Ex.Logger.Log("Mission.csv中字段[Target]位置不对应"); return false; }
		if(vecLine[23]!="ZiDong"){Ex.Logger.Log("Mission.csv中字段[ZiDong]位置不对应"); return false; }
		if(vecLine[24]!="TiJiao"){Ex.Logger.Log("Mission.csv中字段[TiJiao]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)25)
			{
				return false;
			}
			MissionElement member = new MissionElement();
			member.MissionID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.Type=Convert.ToInt32(vecLine[2]);
			member.Title=vecLine[3];
			member.Lv=Convert.ToInt32(vecLine[4]);
			member.Reward=Convert.ToInt32(vecLine[5]);
			member.TiaoJian=Convert.ToInt32(vecLine[6]);
			member.JieNpc=Convert.ToInt32(vecLine[7]);
			member.JiaoNpc=Convert.ToInt32(vecLine[8]);
			member.Dialog1=Convert.ToInt32(vecLine[9]);
			member.Dialog2=vecLine[10];
			member.Dialog3=vecLine[11];
			member.IngDialog=Convert.ToInt32(vecLine[12]);
			member.Tips=vecLine[13];
			member.Time=Convert.ToInt32(vecLine[14]);
			member.Index=Convert.ToInt32(vecLine[15]);
			member.QianZhi=Convert.ToInt32(vecLine[16]);
			member.Monster=Convert.ToInt32(vecLine[17]);
			member.Plant=Convert.ToInt32(vecLine[18]);
			member.Npc=Convert.ToInt32(vecLine[19]);
			member.FuBen=Convert.ToInt32(vecLine[20]);
			member.FuBenLimit=Convert.ToInt32(vecLine[21]);
			member.Target=Convert.ToInt32(vecLine[22]);
			member.ZiDong=Convert.ToInt32(vecLine[23]);
			member.TiJiao=Convert.ToInt32(vecLine[24]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.MissionID] = member;
		}
		return true;
	}
};
