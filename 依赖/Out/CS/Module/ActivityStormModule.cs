/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleActivityStorm.cs
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


public class ActivityStormRPC
{
	public const int ModuleId = 30;
	
	public const int RPC_CODE_ACTIVITYSTORM_SIGNUP_REQUEST = 3051;
	public const int RPC_CODE_ACTIVITYSTORM_CANCELSIGNUP_REQUEST = 3052;
	public const int RPC_CODE_ACTIVITYSTORM_INSERTBATTLEFIELD_REQUEST = 3053;
	public const int RPC_CODE_ACTIVITYSTORM_BATTLEFIELDMESSAGE_NOTIFY = 3054;
	public const int RPC_CODE_ACTIVITYSTORM_TIMEOUTMESSAGE_NOTIFY = 3055;
	public const int RPC_CODE_ACTIVITYSTORM_SYNCDATA_REQUEST = 3056;
	public const int RPC_CODE_ACTIVITYSTORM_JOINLEVEVNOTIFY_NOTIFY = 3057;
	public const int RPC_CODE_ACTIVITYSTORM_CANCEINSERTBATTLE_REQUEST = 3058;
	public const int RPC_CODE_ACTIVITYSTORM_RESETSIGNUPNOTIFY_NOTIFY = 3059;

	
	private static ActivityStormRPC m_Instance = null;
	public static ActivityStormRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityStormRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, ActivityStormData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSTORM_BATTLEFIELDMESSAGE_NOTIFY, BattlefieldMessageCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSTORM_TIMEOUTMESSAGE_NOTIFY, TimeOutMessageCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSTORM_JOINLEVEVNOTIFY_NOTIFY, JoinLevevNotifyCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ACTIVITYSTORM_RESETSIGNUPNOTIFY_NOTIFY, ResetSignUpNotifyCB);


		return true;
	}


	/**
	*活动 风暴-->报名 RPC请求
	*/
	public void SignUp(ReplyHandler replyCB)
	{
		ActivityStormRpcSignUpAskWraper askPBWraper = new ActivityStormRpcSignUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSTORM_SIGNUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityStormRpcSignUpReplyWraper replyPBWraper = new ActivityStormRpcSignUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动 风暴-->取消报名 RPC请求
	*/
	public void CancelSignUp(ReplyHandler replyCB)
	{
		ActivityStormRpcCancelSignUpAskWraper askPBWraper = new ActivityStormRpcCancelSignUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSTORM_CANCELSIGNUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityStormRpcCancelSignUpReplyWraper replyPBWraper = new ActivityStormRpcCancelSignUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动 风暴-->进入战场 RPC请求
	*/
	public void InsertBattlefield(ReplyHandler replyCB)
	{
		ActivityStormRpcInsertBattlefieldAskWraper askPBWraper = new ActivityStormRpcInsertBattlefieldAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSTORM_INSERTBATTLEFIELD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityStormRpcInsertBattlefieldReplyWraper replyPBWraper = new ActivityStormRpcInsertBattlefieldReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动 风暴-->同步数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		ActivityStormRpcSyncDataAskWraper askPBWraper = new ActivityStormRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSTORM_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityStormRpcSyncDataReplyWraper replyPBWraper = new ActivityStormRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*活动 风暴-->取消进入战场 RPC请求
	*/
	public void CanceInsertBattle(ReplyHandler replyCB)
	{
		ActivityStormRpcCanceInsertBattleAskWraper askPBWraper = new ActivityStormRpcCanceInsertBattleAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYSTORM_CANCEINSERTBATTLE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityStormRpcCanceInsertBattleReplyWraper replyPBWraper = new ActivityStormRpcCanceInsertBattleReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*活动 风暴-->战场信息 服务器通知回调
	*/
	public static void BattlefieldMessageCB( ModMessage notifyMsg )
	{
		ActivityStormRpcBattlefieldMessageNotifyWraper notifyPBWraper = new ActivityStormRpcBattlefieldMessageNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BattlefieldMessageCBDelegate != null )
			BattlefieldMessageCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BattlefieldMessageCBDelegate = null;
	/**
	*活动 风暴-->超时消息主推 服务器通知回调
	*/
	public static void TimeOutMessageCB( ModMessage notifyMsg )
	{
		ActivityStormRpcTimeOutMessageNotifyWraper notifyPBWraper = new ActivityStormRpcTimeOutMessageNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( TimeOutMessageCBDelegate != null )
			TimeOutMessageCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback TimeOutMessageCBDelegate = null;
	/**
	*活动 风暴-->加入离开notify 服务器通知回调
	*/
	public static void JoinLevevNotifyCB( ModMessage notifyMsg )
	{
		ActivityStormRpcJoinLevevNotifyNotifyWraper notifyPBWraper = new ActivityStormRpcJoinLevevNotifyNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( JoinLevevNotifyCBDelegate != null )
			JoinLevevNotifyCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback JoinLevevNotifyCBDelegate = null;
	/**
	*活动 风暴-->重置报名 服务器通知回调
	*/
	public static void ResetSignUpNotifyCB( ModMessage notifyMsg )
	{
		ActivityStormRpcResetSignUpNotifyNotifyWraper notifyPBWraper = new ActivityStormRpcResetSignUpNotifyNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ResetSignUpNotifyCBDelegate != null )
			ResetSignUpNotifyCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ResetSignUpNotifyCBDelegate = null;



}

public class ActivityStormData
{
	public enum SyncIdE
	{

	}
	
	private static ActivityStormData m_Instance = null;
	public static ActivityStormData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityStormData();
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
			Ex.Logger.Log("ActivityStormData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
