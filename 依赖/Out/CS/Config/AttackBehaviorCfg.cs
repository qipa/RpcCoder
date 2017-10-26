using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//攻击行为配置数据类
public class AttackBehaviorElement
{
	public int Id;               	//编号	编号
	public int AttackerType;     	//攻击者类型	1我2他3小怪4boss5机关
	public int HitterType;       	//受击者类型	1我2他3小怪4boss5机关
	public int SkillType;        	//技能类型	1普攻2技能
	public int AttackFlash;      	//闪白	1是 0否
	public int ShakeCamera;      	//震屏	1是 0否
	public int HitIdleAnim;      	//是否待机受击动作	1是 0否
	public int HitMoveAnim;      	//是否移动受击动作	1是 0否
	public int HitAnim;          	//是否攻击受击动作	1是 0否
	public int AttackBack;       	//是否击退	1是 0否
	public int AttackAir;        	//是否浮空	1是 0否
	public int AttackWaggle;     	//是否晃动	1是 0否
	public int AttackTumble;     	//是否倒地	1是 0否

	public bool IsValidate = false;
	public AttackBehaviorElement()
	{
		Id = -1;
	}
};

//攻击行为配置封装类
public class AttackBehaviorTable
{

	private AttackBehaviorTable()
	{
		m_mapElements = new Dictionary<int, AttackBehaviorElement>();
		m_emptyItem = new AttackBehaviorElement();
		m_vecAllElements = new List<AttackBehaviorElement>();
	}
	private Dictionary<int, AttackBehaviorElement> m_mapElements = null;
	private List<AttackBehaviorElement>	m_vecAllElements = null;
	private AttackBehaviorElement m_emptyItem = null;
	private static AttackBehaviorTable sInstance = null;

	public static AttackBehaviorTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new AttackBehaviorTable();
			return sInstance;
		}
	}

	public AttackBehaviorElement GetElement(int key)
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

  public List<AttackBehaviorElement> GetAllElement(Predicate<AttackBehaviorElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("AttackBehavior.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("AttackBehavior.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[AttackBehavior.bin]未找到");
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
		if(vecLine.Count != 13)
		{
			Ex.Logger.Log("AttackBehavior.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Id"){Ex.Logger.Log("AttackBehavior.csv中字段[Id]位置不对应"); return false; }
		if(vecLine[1]!="AttackerType"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackerType]位置不对应"); return false; }
		if(vecLine[2]!="HitterType"){Ex.Logger.Log("AttackBehavior.csv中字段[HitterType]位置不对应"); return false; }
		if(vecLine[3]!="SkillType"){Ex.Logger.Log("AttackBehavior.csv中字段[SkillType]位置不对应"); return false; }
		if(vecLine[4]!="AttackFlash"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackFlash]位置不对应"); return false; }
		if(vecLine[5]!="ShakeCamera"){Ex.Logger.Log("AttackBehavior.csv中字段[ShakeCamera]位置不对应"); return false; }
		if(vecLine[6]!="HitIdleAnim"){Ex.Logger.Log("AttackBehavior.csv中字段[HitIdleAnim]位置不对应"); return false; }
		if(vecLine[7]!="HitMoveAnim"){Ex.Logger.Log("AttackBehavior.csv中字段[HitMoveAnim]位置不对应"); return false; }
		if(vecLine[8]!="HitAnim"){Ex.Logger.Log("AttackBehavior.csv中字段[HitAnim]位置不对应"); return false; }
		if(vecLine[9]!="AttackBack"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackBack]位置不对应"); return false; }
		if(vecLine[10]!="AttackAir"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackAir]位置不对应"); return false; }
		if(vecLine[11]!="AttackWaggle"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackWaggle]位置不对应"); return false; }
		if(vecLine[12]!="AttackTumble"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackTumble]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			AttackBehaviorElement member = new AttackBehaviorElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Id );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttackerType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitterType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SkillType );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttackFlash );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ShakeCamera );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitIdleAnim );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitMoveAnim );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HitAnim );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttackBack );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttackAir );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttackWaggle );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AttackTumble );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Id] = member;
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
		if(vecLine.Count != 13)
		{
			Ex.Logger.Log("AttackBehavior.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="Id"){Ex.Logger.Log("AttackBehavior.csv中字段[Id]位置不对应"); return false; }
		if(vecLine[1]!="AttackerType"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackerType]位置不对应"); return false; }
		if(vecLine[2]!="HitterType"){Ex.Logger.Log("AttackBehavior.csv中字段[HitterType]位置不对应"); return false; }
		if(vecLine[3]!="SkillType"){Ex.Logger.Log("AttackBehavior.csv中字段[SkillType]位置不对应"); return false; }
		if(vecLine[4]!="AttackFlash"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackFlash]位置不对应"); return false; }
		if(vecLine[5]!="ShakeCamera"){Ex.Logger.Log("AttackBehavior.csv中字段[ShakeCamera]位置不对应"); return false; }
		if(vecLine[6]!="HitIdleAnim"){Ex.Logger.Log("AttackBehavior.csv中字段[HitIdleAnim]位置不对应"); return false; }
		if(vecLine[7]!="HitMoveAnim"){Ex.Logger.Log("AttackBehavior.csv中字段[HitMoveAnim]位置不对应"); return false; }
		if(vecLine[8]!="HitAnim"){Ex.Logger.Log("AttackBehavior.csv中字段[HitAnim]位置不对应"); return false; }
		if(vecLine[9]!="AttackBack"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackBack]位置不对应"); return false; }
		if(vecLine[10]!="AttackAir"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackAir]位置不对应"); return false; }
		if(vecLine[11]!="AttackWaggle"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackWaggle]位置不对应"); return false; }
		if(vecLine[12]!="AttackTumble"){Ex.Logger.Log("AttackBehavior.csv中字段[AttackTumble]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)13)
			{
				return false;
			}
			AttackBehaviorElement member = new AttackBehaviorElement();
			member.Id=Convert.ToInt32(vecLine[0]);
			member.AttackerType=Convert.ToInt32(vecLine[1]);
			member.HitterType=Convert.ToInt32(vecLine[2]);
			member.SkillType=Convert.ToInt32(vecLine[3]);
			member.AttackFlash=Convert.ToInt32(vecLine[4]);
			member.ShakeCamera=Convert.ToInt32(vecLine[5]);
			member.HitIdleAnim=Convert.ToInt32(vecLine[6]);
			member.HitMoveAnim=Convert.ToInt32(vecLine[7]);
			member.HitAnim=Convert.ToInt32(vecLine[8]);
			member.AttackBack=Convert.ToInt32(vecLine[9]);
			member.AttackAir=Convert.ToInt32(vecLine[10]);
			member.AttackWaggle=Convert.ToInt32(vecLine[11]);
			member.AttackTumble=Convert.ToInt32(vecLine[12]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.Id] = member;
		}
		return true;
	}
};
