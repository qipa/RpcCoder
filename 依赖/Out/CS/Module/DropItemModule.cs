/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleDropItem.cs
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


public class DropItemRPC
{
	public const int ModuleId = 35;
	
	public const int RPC_CODE_DROPITEM_DROPITEMNOTICE_NOTIFY = 3551;
	public const int RPC_CODE_DROPITEM_PICKUPITEM_REQUEST = 3552;
	public const int RPC_CODE_DROPITEM_DELDROPITEM_NOTIFY = 3553;

	
	private static DropItemRPC m_Instance = null;
	public static DropItemRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new DropItemRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, DropItemData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_DROPITEM_DROPITEMNOTICE_NOTIFY, DropItemNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_DROPITEM_DELDROPITEM_NOTIFY, DelDropItemCB);


		return true;
	}


	/**
	*掉落物-->捡物品 RPC请求
	*/
	public void PickupItem(int UId, ReplyHandler replyCB)
	{
		DropItemRpcPickupItemAskWraper askPBWraper = new DropItemRpcPickupItemAskWraper();
		askPBWraper.UId = UId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_DROPITEM_PICKUPITEM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			DropItemRpcPickupItemReplyWraper replyPBWraper = new DropItemRpcPickupItemReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*掉落物-->物品掉落通知 服务器通知回调
	*/
	public static void DropItemNoticeCB( ModMessage notifyMsg )
	{
		DropItemRpcDropItemNoticeNotifyWraper notifyPBWraper = new DropItemRpcDropItemNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( DropItemNoticeCBDelegate != null )
			DropItemNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback DropItemNoticeCBDelegate = null;
	/**
	*掉落物-->删除掉落 服务器通知回调
	*/
	public static void DelDropItemCB( ModMessage notifyMsg )
	{
		DropItemRpcDelDropItemNotifyWraper notifyPBWraper = new DropItemRpcDelDropItemNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( DelDropItemCBDelegate != null )
			DelDropItemCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback DelDropItemCBDelegate = null;



}

public class DropItemData
{
	public enum SyncIdE
	{

	}
	
	private static DropItemData m_Instance = null;
	public static DropItemData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new DropItemData();
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
			Ex.Logger.Log("DropItemData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
