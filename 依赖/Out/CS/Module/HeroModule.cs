/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleHero.cs
Author:
Description:
Version:	  1.0
History:
  <author>  <time>   <version >   <desc>

***********************************************************/
using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class HeroRPC
{
	public const int ModuleId = 19;
	
	public const int RPC_CODE_HERO_SYNCDATA_REQUEST = 1951;
	public const int RPC_CODE_HERO_COMPOSE_REQUEST = 1952;
	public const int RPC_CODE_HERO_LVUP_REQUEST = 1953;
	public const int RPC_CODE_HERO_STARLVUP_REQUEST = 1954;
	public const int RPC_CODE_HERO_STARSTAGEUP_REQUEST = 1955;
	public const int RPC_CODE_HERO_DEBRISCHANGE_REQUEST = 1956;
	public const int RPC_CODE_HERO_DESTINYEUIP_REQUEST = 1957;
	public const int RPC_CODE_HERO_DESTINYLVUP_REQUEST = 1958;
	public const int RPC_CODE_HERO_ADDMAGIC_REQUEST = 1959;
	public const int RPC_CODE_HERO_SKILLLVUP_REQUEST = 1960;
	public const int RPC_CODE_HERO_WUSHENGLVUP_REQUEST = 1961;
	public const int RPC_CODE_HERO_SKILLTIME_REQUEST = 1962;

	
	private static HeroRPC m_Instance = null;
	public static HeroRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new HeroRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, HeroData.Instance.UpdateField );
		


		return true;
	}


	/**
	*英雄-->英雄数据更新 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		HeroRpcSyncDataAskWraper askPBWraper = new HeroRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcSyncDataReplyWraper replyPBWraper = new HeroRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->合成 RPC请求
	*/
	public void Compose(int HerdId, ReplyHandler replyCB)
	{
		HeroRpcComposeAskWraper askPBWraper = new HeroRpcComposeAskWraper();
		askPBWraper.HerdId = HerdId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_COMPOSE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcComposeReplyWraper replyPBWraper = new HeroRpcComposeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->英雄升级 RPC请求
	*/
	public void LvUp(int HerdId, int ItemId, ReplyHandler replyCB)
	{
		HeroRpcLvUpAskWraper askPBWraper = new HeroRpcLvUpAskWraper();
		askPBWraper.HerdId = HerdId;
		askPBWraper.ItemId = ItemId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_LVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcLvUpReplyWraper replyPBWraper = new HeroRpcLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->英雄升星 RPC请求
	*/
	public void StarLvUp(int HerdId, ReplyHandler replyCB)
	{
		HeroRpcStarLvUpAskWraper askPBWraper = new HeroRpcStarLvUpAskWraper();
		askPBWraper.HerdId = HerdId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_STARLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcStarLvUpReplyWraper replyPBWraper = new HeroRpcStarLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->星阶进化 RPC请求
	*/
	public void StarStageUp(int HerdId, ReplyHandler replyCB)
	{
		HeroRpcStarStageUpAskWraper askPBWraper = new HeroRpcStarStageUpAskWraper();
		askPBWraper.HerdId = HerdId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_STARSTAGEUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcStarStageUpReplyWraper replyPBWraper = new HeroRpcStarStageUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->碎片转化 RPC请求
	*/
	public void DebrisChange(int HerdId, int Num, ReplyHandler replyCB)
	{
		HeroRpcDebrisChangeAskWraper askPBWraper = new HeroRpcDebrisChangeAskWraper();
		askPBWraper.HerdId = HerdId;
		askPBWraper.Num = Num;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_DEBRISCHANGE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcDebrisChangeReplyWraper replyPBWraper = new HeroRpcDebrisChangeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->天命穿戴 RPC请求
	*/
	public void DestinyEuip(int HerdId, int Pos, ReplyHandler replyCB)
	{
		HeroRpcDestinyEuipAskWraper askPBWraper = new HeroRpcDestinyEuipAskWraper();
		askPBWraper.HerdId = HerdId;
		askPBWraper.Pos = Pos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_DESTINYEUIP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcDestinyEuipReplyWraper replyPBWraper = new HeroRpcDestinyEuipReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->天命升级 RPC请求
	*/
	public void DestinyLvUp(int HerdId, ReplyHandler replyCB)
	{
		HeroRpcDestinyLvUpAskWraper askPBWraper = new HeroRpcDestinyLvUpAskWraper();
		askPBWraper.HerdId = HerdId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_DESTINYLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcDestinyLvUpReplyWraper replyPBWraper = new HeroRpcDestinyLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->附魔 RPC请求
	*/
	public void AddMagic(int HerdId, int StonePos, List<int> ItemId, List<int> Pos, int Type, ReplyHandler replyCB)
	{
		HeroRpcAddMagicAskWraper askPBWraper = new HeroRpcAddMagicAskWraper();
		askPBWraper.HerdId = HerdId;
		askPBWraper.StonePos = StonePos;
		askPBWraper.SetItemId(ItemId);
		askPBWraper.SetPos(Pos);
		askPBWraper.Type = Type;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_ADDMAGIC_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcAddMagicReplyWraper replyPBWraper = new HeroRpcAddMagicReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->技能升级 RPC请求
	*/
	public void SkillLvUp(int HerdId, int SkillId, ReplyHandler replyCB)
	{
		HeroRpcSkillLvUpAskWraper askPBWraper = new HeroRpcSkillLvUpAskWraper();
		askPBWraper.HerdId = HerdId;
		askPBWraper.SkillId = SkillId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_SKILLLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcSkillLvUpReplyWraper replyPBWraper = new HeroRpcSkillLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->武圣升级 RPC请求
	*/
	public void WuShengLvUp(ReplyHandler replyCB)
	{
		HeroRpcWuShengLvUpAskWraper askPBWraper = new HeroRpcWuShengLvUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_WUSHENGLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcWuShengLvUpReplyWraper replyPBWraper = new HeroRpcWuShengLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*英雄-->技能点计时 RPC请求
	*/
	public void SkillTime(ReplyHandler replyCB)
	{
		HeroRpcSkillTimeAskWraper askPBWraper = new HeroRpcSkillTimeAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_HERO_SKILLTIME_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			HeroRpcSkillTimeReplyWraper replyPBWraper = new HeroRpcSkillTimeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class HeroData
{
	public enum SyncIdE
	{
 		WUSHENGLV                                  = 1902,  //武圣等级
 		WUSHENGEXP                                 = 1903,  //武圣经验
 		EVERYHERO                                  = 1904,  //每一个英雄
 		SKILLPOINT                                 = 1905,  //技能点数
 		SKILLPOINTTIME                             = 1906,  //技能点时间计时
 		CURTIME                                    = 1907,  //当前时间
 		MILITARYEXP                                = 1908,  //战力换算剩余点数

	}
	
	private static HeroData m_Instance = null;
	public static HeroData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new HeroData();
			}
			return m_Instance;

		}
	}
	

	public void UpdateField(int Id, int Index, byte[] buff, int start, int len )
	{
		SyncIdE SyncId = (SyncIdE)Id;
		byte[]  updateBuffer = new byte[len];
		Array.Copy(buff, start, updateBuffer, 0, len);
		int  iValue = 0;
		long lValue = 0;

		switch (SyncId)
		{
			case SyncIdE.WUSHENGLV:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.WuShengLv = iValue;
				break;
			case SyncIdE.WUSHENGEXP:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.WuShengExp = iValue;
				break;
			case SyncIdE.EVERYHERO:
				if(Index < 0){ m_Instance.ClearEveryHero(); break; }
				if (Index >= m_Instance.SizeEveryHero())
				{
					int Count = Index - m_Instance.SizeEveryHero() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddEveryHero(new HeroHeroDataWraperV1());
				}
				m_Instance.GetEveryHero(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.SKILLPOINT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SkillPoint = iValue;
				break;
			case SyncIdE.SKILLPOINTTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SkillPointTime = iValue;
				break;
			case SyncIdE.CURTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.CurTime = iValue;
				break;
			case SyncIdE.MILITARYEXP:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.MilitaryExp = iValue;
				break;

			default:
				break;
		}

		try
		{
			if (NotifySyncValueChanged!=null)
				NotifySyncValueChanged(Id, Index);
		}
		catch
		{
			Ex.Logger.Log("HeroData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public HeroData()
	{
		 m_WuShengLv = 0;
		 m_WuShengExp = 0;
		m_EveryHero = new List<HeroHeroDataWraperV1>();
		 m_SkillPoint = -1;
		 m_SkillPointTime = -1;
		 m_CurTime = -1;
		 m_MilitaryExp = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_WuShengLv = 0;
		 m_WuShengExp = 0;
		m_EveryHero = new List<HeroHeroDataWraperV1>();
		 m_SkillPoint = -1;
		 m_SkillPointTime = -1;
		 m_CurTime = -1;
		 m_MilitaryExp = 0;

	}

 	//转化成Protobuffer类型函数
	public HeroHeroV1 ToPB()
	{
		HeroHeroV1 v = new HeroHeroV1();
		v.WuShengLv = m_WuShengLv;
		v.WuShengExp = m_WuShengExp;
		for (int i=0; i<(int)m_EveryHero.Count; i++)
			v.EveryHero.Add( m_EveryHero[i].ToPB());
		v.SkillPoint = m_SkillPoint;
		v.SkillPointTime = m_SkillPointTime;
		v.CurTime = m_CurTime;
		v.MilitaryExp = m_MilitaryExp;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroHeroV1 v)
	{
        if (v == null)
            return;
		m_WuShengLv = v.WuShengLv;
		m_WuShengExp = v.WuShengExp;
		m_EveryHero.Clear();
		for( int i=0; i<v.EveryHero.Count; i++)
			m_EveryHero.Add( new HeroHeroDataWraperV1());
		for( int i=0; i<v.EveryHero.Count; i++)
			m_EveryHero[i].FromPB(v.EveryHero[i]);
		m_SkillPoint = v.SkillPoint;
		m_SkillPointTime = v.SkillPointTime;
		m_CurTime = v.CurTime;
		m_MilitaryExp = v.MilitaryExp;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroHeroV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroHeroV1 pb = ProtoBuf.Serializer.Deserialize<HeroHeroV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//武圣等级
	public int m_WuShengLv;
	public int WuShengLv
	{
		get { return m_WuShengLv;}
		set { m_WuShengLv = value; }
	}
	//武圣经验
	public int m_WuShengExp;
	public int WuShengExp
	{
		get { return m_WuShengExp;}
		set { m_WuShengExp = value; }
	}
	//每一个英雄
	public List<HeroHeroDataWraperV1> m_EveryHero;
	public int SizeEveryHero()
	{
		return m_EveryHero.Count;
	}
	public List<HeroHeroDataWraperV1> GetEveryHero()
	{
		return m_EveryHero;
	}
	public HeroHeroDataWraperV1 GetEveryHero(int Index)
	{
		if(Index<0 || Index>=(int)m_EveryHero.Count)
			return new HeroHeroDataWraperV1();
		return m_EveryHero[Index];
	}
	public void SetEveryHero( List<HeroHeroDataWraperV1> v )
	{
		m_EveryHero=v;
	}
	public void SetEveryHero( int Index, HeroHeroDataWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_EveryHero.Count)
			return;
		m_EveryHero[Index] = v;
	}
	public void AddEveryHero( HeroHeroDataWraperV1 v )
	{
		m_EveryHero.Add(v);
	}
	public void ClearEveryHero( )
	{
		m_EveryHero.Clear();
	}
	//技能点数
	public int m_SkillPoint;
	public int SkillPoint
	{
		get { return m_SkillPoint;}
		set { m_SkillPoint = value; }
	}
	//技能点时间计时
	public int m_SkillPointTime;
	public int SkillPointTime
	{
		get { return m_SkillPointTime;}
		set { m_SkillPointTime = value; }
	}
	//当前时间
	public int m_CurTime;
	public int CurTime
	{
		get { return m_CurTime;}
		set { m_CurTime = value; }
	}
	//战力换算剩余点数
	public int m_MilitaryExp;
	public int MilitaryExp
	{
		get { return m_MilitaryExp;}
		set { m_MilitaryExp = value; }
	}



}
