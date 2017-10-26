/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleOneVSOne.cs
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


public class OneVSOneRPC
{
	public const int ModuleId = 41;
	
	public const int RPC_CODE_ONEVSONE_FLUSH_REQUEST = 4151;
	public const int RPC_CODE_ONEVSONE_ACT_REQUEST = 4152;
	public const int RPC_CODE_ONEVSONE_ACTMESSAGE_NOTIFY = 4153;
	public const int RPC_CODE_ONEVSONE_REPLYACT_REQUEST = 4154;
	public const int RPC_CODE_ONEVSONE_GETTOP_REQUEST = 4155;
	public const int RPC_CODE_ONEVSONE_ADJUSTMENTSKILL_REQUEST = 4156;
	public const int RPC_CODE_ONEVSONE_GETSKILL_REQUEST = 4157;
	public const int RPC_CODE_ONEVSONE_GETACTMESSAGE_REQUEST = 4158;
	public const int RPC_CODE_ONEVSONE_ACTRESULTNOTIFY_NOTIFY = 4159;

	
	private static OneVSOneRPC m_Instance = null;
	public static OneVSOneRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new OneVSOneRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, OneVSOneData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ONEVSONE_ACTMESSAGE_NOTIFY, ActMessageCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_ONEVSONE_ACTRESULTNOTIFY_NOTIFY, ACTResultNotifyCB);


		return true;
	}


	/**
	*一v一-->刷新自己的数据 RPC请求
	*/
	public void Flush(int IsOpen, ReplyHandler replyCB)
	{
		OneVSOneRpcFlushAskWraper askPBWraper = new OneVSOneRpcFlushAskWraper();
		askPBWraper.IsOpen = IsOpen;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_FLUSH_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcFlushReplyWraper replyPBWraper = new OneVSOneRpcFlushReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*一v一-->发起挑战 RPC请求
	*/
	public void Act(long UserId, int Ranking, ReplyHandler replyCB)
	{
		OneVSOneRpcActAskWraper askPBWraper = new OneVSOneRpcActAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.Ranking = Ranking;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_ACT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcActReplyWraper replyPBWraper = new OneVSOneRpcActReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*一v一-->回应谁的挑战 RPC请求
	*/
	public void ReplyAct(long UserId, int IsOK, ReplyHandler replyCB)
	{
		OneVSOneRpcReplyActAskWraper askPBWraper = new OneVSOneRpcReplyActAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.IsOK = IsOK;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_REPLYACT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcReplyActReplyWraper replyPBWraper = new OneVSOneRpcReplyActReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*一v一-->排行榜数据 RPC请求
	*/
	public void GetTop(ReplyHandler replyCB)
	{
		OneVSOneRpcGetTopAskWraper askPBWraper = new OneVSOneRpcGetTopAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_GETTOP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcGetTopReplyWraper replyPBWraper = new OneVSOneRpcGetTopReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*一v一-->调整技能 RPC请求
	*/
	public void AdjustmentSkill(List<OneSDataWraper> SkillDate, ReplyHandler replyCB)
	{
		OneVSOneRpcAdjustmentSkillAskWraper askPBWraper = new OneVSOneRpcAdjustmentSkillAskWraper();
		askPBWraper.SetSkillDate(SkillDate);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_ADJUSTMENTSKILL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcAdjustmentSkillReplyWraper replyPBWraper = new OneVSOneRpcAdjustmentSkillReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*一v一-->获取设置的技能 RPC请求
	*/
	public void GetSkill(ReplyHandler replyCB)
	{
		OneVSOneRpcGetSkillAskWraper askPBWraper = new OneVSOneRpcGetSkillAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_GETSKILL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcGetSkillReplyWraper replyPBWraper = new OneVSOneRpcGetSkillReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*一v一-->获得攻守的信息 RPC请求
	*/
	public void GetActMessage(ReplyHandler replyCB)
	{
		OneVSOneRpcGetActMessageAskWraper askPBWraper = new OneVSOneRpcGetActMessageAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ONEVSONE_GETACTMESSAGE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			OneVSOneRpcGetActMessageReplyWraper replyPBWraper = new OneVSOneRpcGetActMessageReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*一v一-->挑战消息 服务器通知回调
	*/
	public static void ActMessageCB( ModMessage notifyMsg )
	{
		OneVSOneRpcActMessageNotifyWraper notifyPBWraper = new OneVSOneRpcActMessageNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ActMessageCBDelegate != null )
			ActMessageCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ActMessageCBDelegate = null;
	/**
	*一v一-->战斗结果Notify 叶青给我我就给客户端 服务器通知回调
	*/
	public static void ACTResultNotifyCB( ModMessage notifyMsg )
	{
		OneVSOneRpcACTResultNotifyNotifyWraper notifyPBWraper = new OneVSOneRpcACTResultNotifyNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ACTResultNotifyCBDelegate != null )
			ACTResultNotifyCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ACTResultNotifyCBDelegate = null;



}

public class OneVSOneData
{
	public enum SyncIdE
	{

	}
	
	private static OneVSOneData m_Instance = null;
	public static OneVSOneData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new OneVSOneData();
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
			Ex.Logger.Log("OneVSOneData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
