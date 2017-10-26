/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleDungeon.cs
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


public class DungeonRPC
{
	public const int ModuleId = 12;
	
	public const int RPC_CODE_DUNGEON_ENTER_REQUEST = 1251;
	public const int RPC_CODE_DUNGEON_OPEN_NOTIFY = 1252;
	public const int RPC_CODE_DUNGEON_TRYENTER_REQUEST = 1253;
	public const int RPC_CODE_DUNGEON_TRANSFER_NOTIFY = 1254;

	
	private static DungeonRPC m_Instance = null;
	public static DungeonRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new DungeonRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, DungeonData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_DUNGEON_OPEN_NOTIFY, OpenCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_DUNGEON_TRANSFER_NOTIFY, TransferCB);


		return true;
	}


	/**
	*进出副本模块-->进入 RPC请求
	*/
	public void Enter(int DungeonId, int DungeonType, int BirthPoint, int FaceDir, int GuildId, ReplyHandler replyCB)
	{
		DungeonRpcEnterAskWraper askPBWraper = new DungeonRpcEnterAskWraper();
		askPBWraper.DungeonId = DungeonId;
		askPBWraper.DungeonType = DungeonType;
		askPBWraper.BirthPoint = BirthPoint;
		askPBWraper.FaceDir = FaceDir;
		askPBWraper.GuildId = GuildId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_DUNGEON_ENTER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			DungeonRpcEnterReplyWraper replyPBWraper = new DungeonRpcEnterReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*进出副本模块-->能否进入 RPC请求
	*/
	public void TryEnter(int DungeonId, int BirthPoint, int FaceDir, int GuildId, ReplyHandler replyCB)
	{
		DungeonRpcTryEnterAskWraper askPBWraper = new DungeonRpcTryEnterAskWraper();
		askPBWraper.DungeonId = DungeonId;
		askPBWraper.BirthPoint = BirthPoint;
		askPBWraper.FaceDir = FaceDir;
		askPBWraper.GuildId = GuildId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_DUNGEON_TRYENTER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			DungeonRpcTryEnterReplyWraper replyPBWraper = new DungeonRpcTryEnterReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*进出副本模块-->打开副本通知 服务器通知回调
	*/
	public static void OpenCB( ModMessage notifyMsg )
	{
		DungeonRpcOpenNotifyWraper notifyPBWraper = new DungeonRpcOpenNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( OpenCBDelegate != null )
			OpenCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback OpenCBDelegate = null;
	/**
	*进出副本模块-->传送 服务器通知回调
	*/
	public static void TransferCB( ModMessage notifyMsg )
	{
		DungeonRpcTransferNotifyWraper notifyPBWraper = new DungeonRpcTransferNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( TransferCBDelegate != null )
			TransferCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback TransferCBDelegate = null;



}

public class DungeonData
{
	public enum SyncIdE
	{

	}
	
	private static DungeonData m_Instance = null;
	public static DungeonData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new DungeonData();
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
			Ex.Logger.Log("DungeonData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
