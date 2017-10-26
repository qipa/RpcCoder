/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleActivitySchedule.cs
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


public class ActivityScheduleRPC
{
	public const int ModuleId = 32;
	
	public const int RPC_CODE_ACTIVITYSCHEDULE_SYNCDATA_REQUEST = 3251;
	public const int RPC_CODE_ACTIVITYSCHEDULE_THIEFBEOPENED_NOTIFY = 3252;
	public const int RPC_CODE_ACTIVITYSCHEDULE_THIEFREFRESH_NOTIFY = 3253;
	public const int RPC_CODE_ACTIVITYSCHEDULE_THIEFOPENMONSTER_REQUEST = 3254;
	public const int RPC_CODE_ACTIVITYSCHEDULE_SUBDUEMONSTERENTER_REQUEST = 3255;
	public const int RPC_CODE_ACTIVITYSCHEDULE_SUBDUEMONSTERBEOPENED_NOTIFY = 3256;
	public const int RPC_CODE_ACTIVITYSCHEDULE_SUBDUEMONSTERREFRESH_NOTIFY = 3257;
	public const int RPC_CODE_ACTIVITYSCHEDULE_WORLDBOSSENTERDUNGEON_REQUEST = 3258;
	public const int RPC_CODE_ACTIVITYSCHEDULE_WORLDBOSSSYNCDATA_REQUEST = 3259;

	
	private static ActivityScheduleRPC m_Instance = null;
	public static ActivityScheduleRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityScheduleRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, ActivityScheduleData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSCHEDULE_THIEFBEOPENED_NOTIFY, ThiefBeOpenedCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSCHEDULE_THIEFREFRESH_NOTIFY, ThiefRefreshCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSCHEDULE_SUBDUEMONSTERBEOPENED_NOTIFY, SubdueMonsterBeOpenedCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSCHEDULE_SUBDUEMONSTERREFRESH_NOTIFY, SubdueMonsterRefreshCB);


		return true;
	}


	/**
	*活动日常-->活动日常数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		ActivityScheduleRpcSyncDataAskWraper askPBWraper = new ActivityScheduleRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSCHEDULE_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityScheduleRpcSyncDataReplyWraper replyPBWraper = new ActivityScheduleRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动日常-->江洋大盗开怪 RPC请求
	*/
	public void ThiefOpenMonster(ActivityNpcDataWraper ThiefData, ReplyHandler replyCB)
	{
		ActivityScheduleRpcThiefOpenMonsterAskWraper askPBWraper = new ActivityScheduleRpcThiefOpenMonsterAskWraper();
		askPBWraper.ThiefData = ThiefData;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSCHEDULE_THIEFOPENMONSTER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityScheduleRpcThiefOpenMonsterReplyWraper replyPBWraper = new ActivityScheduleRpcThiefOpenMonsterReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动日常-->降妖进入副本 RPC请求
	*/
	public void SubdueMonsterEnter(ActivityNpcDataWraper SubdueMonsterData, ReplyHandler replyCB)
	{
		ActivityScheduleRpcSubdueMonsterEnterAskWraper askPBWraper = new ActivityScheduleRpcSubdueMonsterEnterAskWraper();
		askPBWraper.SubdueMonsterData = SubdueMonsterData;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSCHEDULE_SUBDUEMONSTERENTER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityScheduleRpcSubdueMonsterEnterReplyWraper replyPBWraper = new ActivityScheduleRpcSubdueMonsterEnterReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动日常-->世界Boss进行副本 RPC请求
	*/
	public void WorldBossEnterDungeon(ReplyHandler replyCB)
	{
		ActivityScheduleRpcWorldBossEnterDungeonAskWraper askPBWraper = new ActivityScheduleRpcWorldBossEnterDungeonAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSCHEDULE_WORLDBOSSENTERDUNGEON_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityScheduleRpcWorldBossEnterDungeonReplyWraper replyPBWraper = new ActivityScheduleRpcWorldBossEnterDungeonReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动日常-->世界Boss,打开界面刷新数据 RPC请求
	*/
	public void WorldBossSyncData(ReplyHandler replyCB)
	{
		ActivityScheduleRpcWorldBossSyncDataAskWraper askPBWraper = new ActivityScheduleRpcWorldBossSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSCHEDULE_WORLDBOSSSYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityScheduleRpcWorldBossSyncDataReplyWraper replyPBWraper = new ActivityScheduleRpcWorldBossSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*活动日常-->江洋大盗被开启通知 服务器通知回调
	*/
	public static void ThiefBeOpenedCB( ModMessage notifyMsg )
	{
		ActivityScheduleRpcThiefBeOpenedNotifyWraper notifyPBWraper = new ActivityScheduleRpcThiefBeOpenedNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ThiefBeOpenedCBDelegate != null )
			ThiefBeOpenedCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ThiefBeOpenedCBDelegate = null;
	/**
	*活动日常-->江洋大盗刷新 服务器通知回调
	*/
	public static void ThiefRefreshCB( ModMessage notifyMsg )
	{
		ActivityScheduleRpcThiefRefreshNotifyWraper notifyPBWraper = new ActivityScheduleRpcThiefRefreshNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ThiefRefreshCBDelegate != null )
			ThiefRefreshCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ThiefRefreshCBDelegate = null;
	/**
	*活动日常-->降妖被其他人开启 服务器通知回调
	*/
	public static void SubdueMonsterBeOpenedCB( ModMessage notifyMsg )
	{
		ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraper notifyPBWraper = new ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SubdueMonsterBeOpenedCBDelegate != null )
			SubdueMonsterBeOpenedCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SubdueMonsterBeOpenedCBDelegate = null;
	/**
	*活动日常-->降妖除魔刷新Npc 服务器通知回调
	*/
	public static void SubdueMonsterRefreshCB( ModMessage notifyMsg )
	{
		ActivityScheduleRpcSubdueMonsterRefreshNotifyWraper notifyPBWraper = new ActivityScheduleRpcSubdueMonsterRefreshNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SubdueMonsterRefreshCBDelegate != null )
			SubdueMonsterRefreshCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SubdueMonsterRefreshCBDelegate = null;



}

public class ActivityScheduleData
{
	public enum SyncIdE
	{
 		VALUE                                      = 3201,  //数据
 		TIME                                       = 3202,  //时间（服务器专用）

	}
	
	private static ActivityScheduleData m_Instance = null;
	public static ActivityScheduleData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityScheduleData();
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
			case SyncIdE.VALUE:
				if(Index < 0){ m_Instance.ClearValue(); break; }
				if (Index >= m_Instance.SizeValue())
				{
					int Count = Index - m_Instance.SizeValue() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddValue(new ActivityScheduleActiveValueWraperV1());
				}
				m_Instance.GetValue(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.TIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Time = iValue;
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
			Ex.Logger.Log("ActivityScheduleData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public ActivityScheduleData()
	{
		m_Value = new List<ActivityScheduleActiveValueWraperV1>();
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_Value = new List<ActivityScheduleActiveValueWraperV1>();
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleActiveDateV1 ToPB()
	{
		ActivityScheduleActiveDateV1 v = new ActivityScheduleActiveDateV1();
		for (int i=0; i<(int)m_Value.Count; i++)
			v.Value.Add( m_Value[i].ToPB());
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleActiveDateV1 v)
	{
        if (v == null)
            return;
		m_Value.Clear();
		for( int i=0; i<v.Value.Count; i++)
			m_Value.Add( new ActivityScheduleActiveValueWraperV1());
		for( int i=0; i<v.Value.Count; i++)
			m_Value[i].FromPB(v.Value[i]);
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleActiveDateV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleActiveDateV1 pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleActiveDateV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//数据
	public List<ActivityScheduleActiveValueWraperV1> m_Value;
	public int SizeValue()
	{
		return m_Value.Count;
	}
	public List<ActivityScheduleActiveValueWraperV1> GetValue()
	{
		return m_Value;
	}
	public ActivityScheduleActiveValueWraperV1 GetValue(int Index)
	{
		if(Index<0 || Index>=(int)m_Value.Count)
			return new ActivityScheduleActiveValueWraperV1();
		return m_Value[Index];
	}
	public void SetValue( List<ActivityScheduleActiveValueWraperV1> v )
	{
		m_Value=v;
	}
	public void SetValue( int Index, ActivityScheduleActiveValueWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_Value.Count)
			return;
		m_Value[Index] = v;
	}
	public void AddValue( ActivityScheduleActiveValueWraperV1 v )
	{
		m_Value.Add(v);
	}
	public void ClearValue( )
	{
		m_Value.Clear();
	}
	//时间（服务器专用）
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}



}
