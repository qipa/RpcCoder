/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleStoryDungeon.cs
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


public class StoryDungeonRPC
{
	public const int ModuleId = 43;
	
	public const int RPC_CODE_STORYDUNGEON_SYNCDATA_REQUEST = 4351;
	public const int RPC_CODE_STORYDUNGEON_CHALLENGE_REQUEST = 4352;
	public const int RPC_CODE_STORYDUNGEON_WAITFORCONFIRMATION_NOTIFY = 4353;
	public const int RPC_CODE_STORYDUNGEON_CONFIRMENTER_REQUEST = 4354;
	public const int RPC_CODE_STORYDUNGEON_PLAYERCONFIRMRESULT_NOTIFY = 4355;

	
	private static StoryDungeonRPC m_Instance = null;
	public static StoryDungeonRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new StoryDungeonRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, StoryDungeonData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_STORYDUNGEON_WAITFORCONFIRMATION_NOTIFY, WaitForConfirmationCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_STORYDUNGEON_PLAYERCONFIRMRESULT_NOTIFY, PlayerConfirmResultCB);


		return true;
	}


	/**
	*剧情副本-->SyncData RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		StoryDungeonRpcSyncDataAskWraper askPBWraper = new StoryDungeonRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_STORYDUNGEON_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			StoryDungeonRpcSyncDataReplyWraper replyPBWraper = new StoryDungeonRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*剧情副本-->挑战副本 RPC请求
	*/
	public void Challenge(int Id, ReplyHandler replyCB)
	{
		StoryDungeonRpcChallengeAskWraper askPBWraper = new StoryDungeonRpcChallengeAskWraper();
		askPBWraper.Id = Id;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_STORYDUNGEON_CHALLENGE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			StoryDungeonRpcChallengeReplyWraper replyPBWraper = new StoryDungeonRpcChallengeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*剧情副本-->确认是否进入 RPC请求
	*/
	public void ConfirmEnter(bool IsAgree, ReplyHandler replyCB)
	{
		StoryDungeonRpcConfirmEnterAskWraper askPBWraper = new StoryDungeonRpcConfirmEnterAskWraper();
		askPBWraper.IsAgree = IsAgree;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_STORYDUNGEON_CONFIRMENTER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			StoryDungeonRpcConfirmEnterReplyWraper replyPBWraper = new StoryDungeonRpcConfirmEnterReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*剧情副本-->等待玩家确认是否选择进入 服务器通知回调
	*/
	public static void WaitForConfirmationCB( ModMessage notifyMsg )
	{
		StoryDungeonRpcWaitForConfirmationNotifyWraper notifyPBWraper = new StoryDungeonRpcWaitForConfirmationNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( WaitForConfirmationCBDelegate != null )
			WaitForConfirmationCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback WaitForConfirmationCBDelegate = null;
	/**
	*剧情副本-->玩家确认或拒绝进入 服务器通知回调
	*/
	public static void PlayerConfirmResultCB( ModMessage notifyMsg )
	{
		StoryDungeonRpcPlayerConfirmResultNotifyWraper notifyPBWraper = new StoryDungeonRpcPlayerConfirmResultNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( PlayerConfirmResultCBDelegate != null )
			PlayerConfirmResultCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback PlayerConfirmResultCBDelegate = null;



}

public class StoryDungeonData
{
	public enum SyncIdE
	{
 		STORYDUNGEON                               = 4301,  //剧情副本数据
 		CHALLENGENUM                               = 4302,  //剩余挑战次数

	}
	
	private static StoryDungeonData m_Instance = null;
	public static StoryDungeonData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new StoryDungeonData();
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
			case SyncIdE.STORYDUNGEON:
				if(Index < 0){ m_Instance.ClearStoryDungeon(); break; }
				if (Index >= m_Instance.SizeStoryDungeon())
				{
					int Count = Index - m_Instance.SizeStoryDungeon() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddStoryDungeon(new StoryDungeonStoryDungeonObjWraperV1());
				}
				m_Instance.GetStoryDungeon(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.CHALLENGENUM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ChallengeNum = iValue;
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
			Ex.Logger.Log("StoryDungeonData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public StoryDungeonData()
	{
		m_StoryDungeon = new List<StoryDungeonStoryDungeonObjWraperV1>();
		 m_ChallengeNum = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		m_StoryDungeon = new List<StoryDungeonStoryDungeonObjWraperV1>();
		 m_ChallengeNum = 0;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonStoryDungeonV1 ToPB()
	{
		StoryDungeonStoryDungeonV1 v = new StoryDungeonStoryDungeonV1();
		for (int i=0; i<(int)m_StoryDungeon.Count; i++)
			v.StoryDungeon.Add( m_StoryDungeon[i].ToPB());
		v.ChallengeNum = m_ChallengeNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonStoryDungeonV1 v)
	{
        if (v == null)
            return;
		m_StoryDungeon.Clear();
		for( int i=0; i<v.StoryDungeon.Count; i++)
			m_StoryDungeon.Add( new StoryDungeonStoryDungeonObjWraperV1());
		for( int i=0; i<v.StoryDungeon.Count; i++)
			m_StoryDungeon[i].FromPB(v.StoryDungeon[i]);
		m_ChallengeNum = v.ChallengeNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonStoryDungeonV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonStoryDungeonV1 pb = ProtoBuf.Serializer.Deserialize<StoryDungeonStoryDungeonV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//剧情副本数据
	public List<StoryDungeonStoryDungeonObjWraperV1> m_StoryDungeon;
	public int SizeStoryDungeon()
	{
		return m_StoryDungeon.Count;
	}
	public List<StoryDungeonStoryDungeonObjWraperV1> GetStoryDungeon()
	{
		return m_StoryDungeon;
	}
	public StoryDungeonStoryDungeonObjWraperV1 GetStoryDungeon(int Index)
	{
		if(Index<0 || Index>=(int)m_StoryDungeon.Count)
			return new StoryDungeonStoryDungeonObjWraperV1();
		return m_StoryDungeon[Index];
	}
	public void SetStoryDungeon( List<StoryDungeonStoryDungeonObjWraperV1> v )
	{
		m_StoryDungeon=v;
	}
	public void SetStoryDungeon( int Index, StoryDungeonStoryDungeonObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_StoryDungeon.Count)
			return;
		m_StoryDungeon[Index] = v;
	}
	public void AddStoryDungeon( StoryDungeonStoryDungeonObjWraperV1 v )
	{
		m_StoryDungeon.Add(v);
	}
	public void ClearStoryDungeon( )
	{
		m_StoryDungeon.Clear();
	}
	//剩余挑战次数
	public int m_ChallengeNum;
	public int ChallengeNum
	{
		get { return m_ChallengeNum;}
		set { m_ChallengeNum = value; }
	}



}
