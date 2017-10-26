/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleSkill.cs
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


public class SkillRPC
{
	public const int ModuleId = 29;
	
	public const int RPC_CODE_SKILL_SYNCDATA_REQUEST = 2951;
	public const int RPC_CODE_SKILL_LEARN_REQUEST = 2952;
	public const int RPC_CODE_SKILL_LVUP_REQUEST = 2953;
	public const int RPC_CODE_SKILL_CHANGESHORTCUT_REQUEST = 2954;
	public const int RPC_CODE_SKILL_USESHORTCUT_REQUEST = 2955;
	public const int RPC_CODE_SKILL_ONEKEYLVUP_REQUEST = 2956;
	public const int RPC_CODE_SKILL_TALENTLVUP_REQUEST = 2957;
	public const int RPC_CODE_SKILL_TALENTCHANGESKILL_REQUEST = 2958;
	public const int RPC_CODE_SKILL_TALENTRESET_REQUEST = 2959;
	public const int RPC_CODE_SKILL_LIFESKILLUP_REQUEST = 2960;

	
	private static SkillRPC m_Instance = null;
	public static SkillRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new SkillRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, SkillData.Instance.UpdateField );
		


		return true;
	}


	/**
	*技能-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		SkillRpcSyncDataAskWraper askPBWraper = new SkillRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcSyncDataReplyWraper replyPBWraper = new SkillRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->学习 RPC请求
	*/
	public void Learn(int SkillId, ReplyHandler replyCB)
	{
		SkillRpcLearnAskWraper askPBWraper = new SkillRpcLearnAskWraper();
		askPBWraper.SkillId = SkillId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_LEARN_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcLearnReplyWraper replyPBWraper = new SkillRpcLearnReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->升级 RPC请求
	*/
	public void LvUp(int SkillId, ReplyHandler replyCB)
	{
		SkillRpcLvUpAskWraper askPBWraper = new SkillRpcLvUpAskWraper();
		askPBWraper.SkillId = SkillId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_LVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcLvUpReplyWraper replyPBWraper = new SkillRpcLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->修改快捷栏 RPC请求
	*/
	public void ChangeShortcut(int SkillId, int Pos, int Id, ReplyHandler replyCB)
	{
		SkillRpcChangeShortcutAskWraper askPBWraper = new SkillRpcChangeShortcutAskWraper();
		askPBWraper.SkillId = SkillId;
		askPBWraper.Pos = Pos;
		askPBWraper.Id = Id;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_CHANGESHORTCUT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcChangeShortcutReplyWraper replyPBWraper = new SkillRpcChangeShortcutReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->使用技能方案 RPC请求
	*/
	public void UseShortcut(int Id, ReplyHandler replyCB)
	{
		SkillRpcUseShortcutAskWraper askPBWraper = new SkillRpcUseShortcutAskWraper();
		askPBWraper.Id = Id;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_USESHORTCUT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcUseShortcutReplyWraper replyPBWraper = new SkillRpcUseShortcutReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->一键升级 RPC请求
	*/
	public void OneKeyLvUp(int SkillId, ReplyHandler replyCB)
	{
		SkillRpcOneKeyLvUpAskWraper askPBWraper = new SkillRpcOneKeyLvUpAskWraper();
		askPBWraper.SkillId = SkillId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_ONEKEYLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcOneKeyLvUpReplyWraper replyPBWraper = new SkillRpcOneKeyLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->天赋槽位升级 RPC请求
	*/
	public void TalentLvUp(List<SkillRpcTalentLvObjWraper> Talent, ReplyHandler replyCB)
	{
		SkillRpcTalentLvUpAskWraper askPBWraper = new SkillRpcTalentLvUpAskWraper();
		askPBWraper.SetTalent(Talent);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_TALENTLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcTalentLvUpReplyWraper replyPBWraper = new SkillRpcTalentLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->天赋槽位切换技能 RPC请求
	*/
	public void TalentChangeSkill(int Index, int SkillId, ReplyHandler replyCB)
	{
		SkillRpcTalentChangeSkillAskWraper askPBWraper = new SkillRpcTalentChangeSkillAskWraper();
		askPBWraper.Index = Index;
		askPBWraper.SkillId = SkillId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_TALENTCHANGESKILL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcTalentChangeSkillReplyWraper replyPBWraper = new SkillRpcTalentChangeSkillReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->天赋重置 RPC请求
	*/
	public void TalentReset(ReplyHandler replyCB)
	{
		SkillRpcTalentResetAskWraper askPBWraper = new SkillRpcTalentResetAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_TALENTRESET_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcTalentResetReplyWraper replyPBWraper = new SkillRpcTalentResetReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*技能-->升级生活技能 RPC请求
	*/
	public void LifeSkillUp(int LifeSkillId, ReplyHandler replyCB)
	{
		SkillRpcLifeSkillUpAskWraper askPBWraper = new SkillRpcLifeSkillUpAskWraper();
		askPBWraper.LifeSkillId = LifeSkillId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SKILL_LIFESKILLUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			SkillRpcLifeSkillUpReplyWraper replyPBWraper = new SkillRpcLifeSkillUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class SkillData
{
	public enum SyncIdE
	{
 		SKILLARRAY                                 = 2901,  //全部技能
 		SHORTCUTARRAY                              = 2902,  //快捷栏
 		SHORTCUTID                                 = 2903,  //方案Id，从0开始
 		TALENTSKILL                                = 2904,  //天赋技能
 		TOTALCOSTEXP                               = 2905,  //累计技能消耗经验
 		TALENTLEVEL                                = 2906,  //修为等级
 		TALENTPOINT                                = 2907,  //天赋点
 		LIFESKILLARRAY                             = 2908,  //生活技能

	}
	
	private static SkillData m_Instance = null;
	public static SkillData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new SkillData();
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
			case SyncIdE.SKILLARRAY:
				if(Index < 0){ m_Instance.ClearSkillArray(); break; }
				if (Index >= m_Instance.SizeSkillArray())
				{
					int Count = Index - m_Instance.SizeSkillArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddSkillArray(new SkillSkillObjWraperV1());
				}
				m_Instance.GetSkillArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.SHORTCUTARRAY:
				if(Index < 0){ m_Instance.ClearShortcutArray(); break; }
				if (Index >= m_Instance.SizeShortcutArray())
				{
					int Count = Index - m_Instance.SizeShortcutArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddShortcutArray(new SkillShortcutObjWraperV1());
				}
				m_Instance.GetShortcutArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.SHORTCUTID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ShortcutId = iValue;
				break;
			case SyncIdE.TALENTSKILL:
				if(Index < 0){ m_Instance.ClearTalentSkill(); break; }
				if (Index >= m_Instance.SizeTalentSkill())
				{
					int Count = Index - m_Instance.SizeTalentSkill() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddTalentSkill(new SkillTalentSlotWraperV1());
				}
				m_Instance.GetTalentSkill(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.TOTALCOSTEXP:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.TotalCostExp = iValue;
				break;
			case SyncIdE.TALENTLEVEL:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.TalentLevel = iValue;
				break;
			case SyncIdE.TALENTPOINT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.TalentPoint = iValue;
				break;
			case SyncIdE.LIFESKILLARRAY:
				if(Index < 0){ m_Instance.ClearLifeSkillArray(); break; }
				if (Index >= m_Instance.SizeLifeSkillArray())
				{
					int Count = Index - m_Instance.SizeLifeSkillArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddLifeSkillArray(new SkillSkillObjWraperV1());
				}
				m_Instance.GetLifeSkillArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("SkillData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public SkillData()
	{
		m_SkillArray = new List<SkillSkillObjWraperV1>();
		m_ShortcutArray = new List<SkillShortcutObjWraperV1>();
		 m_ShortcutId = -1;
		m_TalentSkill = new List<SkillTalentSlotWraperV1>();
		 m_TotalCostExp = 0;
		 m_TalentLevel = 0;
		 m_TalentPoint = 0;
		m_LifeSkillArray = new List<SkillSkillObjWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_SkillArray = new List<SkillSkillObjWraperV1>();
		m_ShortcutArray = new List<SkillShortcutObjWraperV1>();
		 m_ShortcutId = -1;
		m_TalentSkill = new List<SkillTalentSlotWraperV1>();
		 m_TotalCostExp = 0;
		 m_TalentLevel = 0;
		 m_TalentPoint = 0;
		m_LifeSkillArray = new List<SkillSkillObjWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public SkillSkillDataV1 ToPB()
	{
		SkillSkillDataV1 v = new SkillSkillDataV1();
		for (int i=0; i<(int)m_SkillArray.Count; i++)
			v.SkillArray.Add( m_SkillArray[i].ToPB());
		for (int i=0; i<(int)m_ShortcutArray.Count; i++)
			v.ShortcutArray.Add( m_ShortcutArray[i].ToPB());
		v.ShortcutId = m_ShortcutId;
		for (int i=0; i<(int)m_TalentSkill.Count; i++)
			v.TalentSkill.Add( m_TalentSkill[i].ToPB());
		v.TotalCostExp = m_TotalCostExp;
		v.TalentLevel = m_TalentLevel;
		v.TalentPoint = m_TalentPoint;
		for (int i=0; i<(int)m_LifeSkillArray.Count; i++)
			v.LifeSkillArray.Add( m_LifeSkillArray[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillSkillDataV1 v)
	{
        if (v == null)
            return;
		m_SkillArray.Clear();
		for( int i=0; i<v.SkillArray.Count; i++)
			m_SkillArray.Add( new SkillSkillObjWraperV1());
		for( int i=0; i<v.SkillArray.Count; i++)
			m_SkillArray[i].FromPB(v.SkillArray[i]);
		m_ShortcutArray.Clear();
		for( int i=0; i<v.ShortcutArray.Count; i++)
			m_ShortcutArray.Add( new SkillShortcutObjWraperV1());
		for( int i=0; i<v.ShortcutArray.Count; i++)
			m_ShortcutArray[i].FromPB(v.ShortcutArray[i]);
		m_ShortcutId = v.ShortcutId;
		m_TalentSkill.Clear();
		for( int i=0; i<v.TalentSkill.Count; i++)
			m_TalentSkill.Add( new SkillTalentSlotWraperV1());
		for( int i=0; i<v.TalentSkill.Count; i++)
			m_TalentSkill[i].FromPB(v.TalentSkill[i]);
		m_TotalCostExp = v.TotalCostExp;
		m_TalentLevel = v.TalentLevel;
		m_TalentPoint = v.TalentPoint;
		m_LifeSkillArray.Clear();
		for( int i=0; i<v.LifeSkillArray.Count; i++)
			m_LifeSkillArray.Add( new SkillSkillObjWraperV1());
		for( int i=0; i<v.LifeSkillArray.Count; i++)
			m_LifeSkillArray[i].FromPB(v.LifeSkillArray[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillSkillDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillSkillDataV1 pb = ProtoBuf.Serializer.Deserialize<SkillSkillDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//全部技能
	public List<SkillSkillObjWraperV1> m_SkillArray;
	public int SizeSkillArray()
	{
		return m_SkillArray.Count;
	}
	public List<SkillSkillObjWraperV1> GetSkillArray()
	{
		return m_SkillArray;
	}
	public SkillSkillObjWraperV1 GetSkillArray(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillArray.Count)
			return new SkillSkillObjWraperV1();
		return m_SkillArray[Index];
	}
	public void SetSkillArray( List<SkillSkillObjWraperV1> v )
	{
		m_SkillArray=v;
	}
	public void SetSkillArray( int Index, SkillSkillObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_SkillArray.Count)
			return;
		m_SkillArray[Index] = v;
	}
	public void AddSkillArray( SkillSkillObjWraperV1 v )
	{
		m_SkillArray.Add(v);
	}
	public void ClearSkillArray( )
	{
		m_SkillArray.Clear();
	}
	//快捷栏
	public List<SkillShortcutObjWraperV1> m_ShortcutArray;
	public int SizeShortcutArray()
	{
		return m_ShortcutArray.Count;
	}
	public List<SkillShortcutObjWraperV1> GetShortcutArray()
	{
		return m_ShortcutArray;
	}
	public SkillShortcutObjWraperV1 GetShortcutArray(int Index)
	{
		if(Index<0 || Index>=(int)m_ShortcutArray.Count)
			return new SkillShortcutObjWraperV1();
		return m_ShortcutArray[Index];
	}
	public void SetShortcutArray( List<SkillShortcutObjWraperV1> v )
	{
		m_ShortcutArray=v;
	}
	public void SetShortcutArray( int Index, SkillShortcutObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_ShortcutArray.Count)
			return;
		m_ShortcutArray[Index] = v;
	}
	public void AddShortcutArray( SkillShortcutObjWraperV1 v )
	{
		m_ShortcutArray.Add(v);
	}
	public void ClearShortcutArray( )
	{
		m_ShortcutArray.Clear();
	}
	//方案Id，从0开始
	public int m_ShortcutId;
	public int ShortcutId
	{
		get { return m_ShortcutId;}
		set { m_ShortcutId = value; }
	}
	//天赋技能
	public List<SkillTalentSlotWraperV1> m_TalentSkill;
	public int SizeTalentSkill()
	{
		return m_TalentSkill.Count;
	}
	public List<SkillTalentSlotWraperV1> GetTalentSkill()
	{
		return m_TalentSkill;
	}
	public SkillTalentSlotWraperV1 GetTalentSkill(int Index)
	{
		if(Index<0 || Index>=(int)m_TalentSkill.Count)
			return new SkillTalentSlotWraperV1();
		return m_TalentSkill[Index];
	}
	public void SetTalentSkill( List<SkillTalentSlotWraperV1> v )
	{
		m_TalentSkill=v;
	}
	public void SetTalentSkill( int Index, SkillTalentSlotWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_TalentSkill.Count)
			return;
		m_TalentSkill[Index] = v;
	}
	public void AddTalentSkill( SkillTalentSlotWraperV1 v )
	{
		m_TalentSkill.Add(v);
	}
	public void ClearTalentSkill( )
	{
		m_TalentSkill.Clear();
	}
	//累计技能消耗经验
	public int m_TotalCostExp;
	public int TotalCostExp
	{
		get { return m_TotalCostExp;}
		set { m_TotalCostExp = value; }
	}
	//修为等级
	public int m_TalentLevel;
	public int TalentLevel
	{
		get { return m_TalentLevel;}
		set { m_TalentLevel = value; }
	}
	//天赋点
	public int m_TalentPoint;
	public int TalentPoint
	{
		get { return m_TalentPoint;}
		set { m_TalentPoint = value; }
	}
	//生活技能
	public List<SkillSkillObjWraperV1> m_LifeSkillArray;
	public int SizeLifeSkillArray()
	{
		return m_LifeSkillArray.Count;
	}
	public List<SkillSkillObjWraperV1> GetLifeSkillArray()
	{
		return m_LifeSkillArray;
	}
	public SkillSkillObjWraperV1 GetLifeSkillArray(int Index)
	{
		if(Index<0 || Index>=(int)m_LifeSkillArray.Count)
			return new SkillSkillObjWraperV1();
		return m_LifeSkillArray[Index];
	}
	public void SetLifeSkillArray( List<SkillSkillObjWraperV1> v )
	{
		m_LifeSkillArray=v;
	}
	public void SetLifeSkillArray( int Index, SkillSkillObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_LifeSkillArray.Count)
			return;
		m_LifeSkillArray[Index] = v;
	}
	public void AddLifeSkillArray( SkillSkillObjWraperV1 v )
	{
		m_LifeSkillArray.Add(v);
	}
	public void ClearLifeSkillArray( )
	{
		m_LifeSkillArray.Clear();
	}



}
