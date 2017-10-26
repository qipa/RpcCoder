/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleFight.cs
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


public class FightRPC
{
	public const int ModuleId = 9;
	
	public const int RPC_CODE_FIGHT_READY_REQUEST = 951;
	public const int RPC_CODE_FIGHT_ACTION_NOTIFY = 952;
	public const int RPC_CODE_FIGHT_RESULT_NOTIFY = 953;
	public const int RPC_CODE_FIGHT_ENTER_REQUEST = 954;
	public const int RPC_CODE_FIGHT_START_NOTIFY = 955;

	
	private static FightRPC m_Instance = null;
	public static FightRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new FightRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, FightData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_FIGHT_ACTION_NOTIFY, ActionCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_FIGHT_RESULT_NOTIFY, ResultCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_FIGHT_START_NOTIFY, StartCB);


		return true;
	}

	/**
	*战斗-->动作 RPC通知
	*/
	public void Action(byte[] Data, int Frame)
	{
		FightRpcActionNotifyWraper notifyPBWraper = new FightRpcActionNotifyWraper();
		notifyPBWraper.Data = Data;
		notifyPBWraper.Frame = Frame;
		ModMessage notifyMsg = new ModMessage();
		notifyMsg.MsgNum = RPC_CODE_FIGHT_ACTION_NOTIFY;
		notifyMsg.protoMS = notifyPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendNotify(notifyMsg);
	}


	/**
	*战斗-->游戏准备就绪 RPC请求
	*/
	public void Ready(ReplyHandler replyCB)
	{
		FightRpcReadyAskWraper askPBWraper = new FightRpcReadyAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FIGHT_READY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FightRpcReadyReplyWraper replyPBWraper = new FightRpcReadyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战斗-->进入副本 RPC请求
	*/
	public void Enter(long UserId, string DungeonKey, string SessionKey, ReplyHandler replyCB)
	{
		FightRpcEnterAskWraper askPBWraper = new FightRpcEnterAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.DungeonKey = DungeonKey;
		askPBWraper.SessionKey = SessionKey;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FIGHT_ENTER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FightRpcEnterReplyWraper replyPBWraper = new FightRpcEnterReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*战斗-->动作 服务器通知回调
	*/
	public static void ActionCB( ModMessage notifyMsg )
	{
		FightRpcActionNotifyWraper notifyPBWraper = new FightRpcActionNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ActionCBDelegate != null )
			ActionCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ActionCBDelegate = null;
	/**
	*战斗-->战斗结果 服务器通知回调
	*/
	public static void ResultCB( ModMessage notifyMsg )
	{
		FightRpcResultNotifyWraper notifyPBWraper = new FightRpcResultNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ResultCBDelegate != null )
			ResultCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ResultCBDelegate = null;
	/**
	*战斗-->战斗开始 服务器通知回调
	*/
	public static void StartCB( ModMessage notifyMsg )
	{
		FightRpcStartNotifyWraper notifyPBWraper = new FightRpcStartNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( StartCBDelegate != null )
			StartCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback StartCBDelegate = null;



}

public class FightData
{
	public enum SyncIdE
	{

	}
	
	private static FightData m_Instance = null;
	public static FightData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new FightData();
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
			Ex.Logger.Log("FightData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
