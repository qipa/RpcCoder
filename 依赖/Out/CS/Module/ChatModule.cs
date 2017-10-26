/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleChat.cs
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


public class ChatRPC
{
	public const int ModuleId = 36;
	
	public const int RPC_CODE_CHAT_SENDCHAT_REQUEST = 3651;
	public const int RPC_CODE_CHAT_SYNCCHAT_NOTIFY = 3652;
	public const int RPC_CODE_CHAT_SYNCPRIVATECHATMSG_NOTIFY = 3653;
	public const int RPC_CODE_CHAT_SVRCHAT_NOTIFY = 3654;

	
	private static ChatRPC m_Instance = null;
	public static ChatRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ChatRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, ChatData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_CHAT_SYNCCHAT_NOTIFY, SyncChatCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_CHAT_SYNCPRIVATECHATMSG_NOTIFY, SyncPrivateChatMsgCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_CHAT_SVRCHAT_NOTIFY, SvrChatCB);


		return true;
	}


	/**
	*聊天-->发送聊天 RPC请求
	*/
	public void SendChat(ChatMsgObjWraper ChatMsg, ReplyHandler replyCB)
	{
		ChatRpcSendChatAskWraper askPBWraper = new ChatRpcSendChatAskWraper();
		askPBWraper.ChatMsg = ChatMsg;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_CHAT_SENDCHAT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ChatRpcSendChatReplyWraper replyPBWraper = new ChatRpcSendChatReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*聊天-->同步聊天 服务器通知回调
	*/
	public static void SyncChatCB( ModMessage notifyMsg )
	{
		ChatRpcSyncChatNotifyWraper notifyPBWraper = new ChatRpcSyncChatNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncChatCBDelegate != null )
			SyncChatCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncChatCBDelegate = null;
	/**
	*聊天-->同步私聊留言 服务器通知回调
	*/
	public static void SyncPrivateChatMsgCB( ModMessage notifyMsg )
	{
		ChatRpcSyncPrivateChatMsgNotifyWraper notifyPBWraper = new ChatRpcSyncPrivateChatMsgNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncPrivateChatMsgCBDelegate != null )
			SyncPrivateChatMsgCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncPrivateChatMsgCBDelegate = null;
	/**
	*聊天-->服务器发送聊天 服务器通知回调
	*/
	public static void SvrChatCB( ModMessage notifyMsg )
	{
		ChatRpcSvrChatNotifyWraper notifyPBWraper = new ChatRpcSvrChatNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SvrChatCBDelegate != null )
			SvrChatCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SvrChatCBDelegate = null;



}

public class ChatData
{
	public enum SyncIdE
	{

	}
	
	private static ChatData m_Instance = null;
	public static ChatData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ChatData();
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
			Ex.Logger.Log("ChatData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
