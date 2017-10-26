/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleMail.cs
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


public class MailRPC
{
	public const int ModuleId = 44;
	
	public const int RPC_CODE_MAIL_MAILHEAD_REQUEST = 4451;
	public const int RPC_CODE_MAIL_OPENMAIL_REQUEST = 4452;
	public const int RPC_CODE_MAIL_NEWMAIL_NOTIFY = 4453;
	public const int RPC_CODE_MAIL_DELMAIL_REQUEST = 4454;
	public const int RPC_CODE_MAIL_GETREWARD_REQUEST = 4455;
	public const int RPC_CODE_MAIL_ONEKEYGETREWARD_REQUEST = 4456;

	
	private static MailRPC m_Instance = null;
	public static MailRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new MailRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, MailData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_MAIL_NEWMAIL_NOTIFY, NewMailCB);


		return true;
	}


	/**
	*邮件-->获得邮件头 RPC请求
	*/
	public void MailHead(int Count, long UId, ReplyHandler replyCB)
	{
		MailRpcMailHeadAskWraper askPBWraper = new MailRpcMailHeadAskWraper();
		askPBWraper.Count = Count;
		askPBWraper.UId = UId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_MAIL_MAILHEAD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			MailRpcMailHeadReplyWraper replyPBWraper = new MailRpcMailHeadReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*邮件-->获得邮件内容 RPC请求
	*/
	public void OpenMail(long UId, ReplyHandler replyCB)
	{
		MailRpcOpenMailAskWraper askPBWraper = new MailRpcOpenMailAskWraper();
		askPBWraper.UId = UId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_MAIL_OPENMAIL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			MailRpcOpenMailReplyWraper replyPBWraper = new MailRpcOpenMailReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*邮件-->删除邮件 RPC请求
	*/
	public void DelMail(List<long> UidList, ReplyHandler replyCB)
	{
		MailRpcDelMailAskWraper askPBWraper = new MailRpcDelMailAskWraper();
		askPBWraper.SetUidList(UidList);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_MAIL_DELMAIL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			MailRpcDelMailReplyWraper replyPBWraper = new MailRpcDelMailReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*邮件-->领取奖励 RPC请求
	*/
	public void GetReward(long UId, ReplyHandler replyCB)
	{
		MailRpcGetRewardAskWraper askPBWraper = new MailRpcGetRewardAskWraper();
		askPBWraper.UId = UId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_MAIL_GETREWARD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			MailRpcGetRewardReplyWraper replyPBWraper = new MailRpcGetRewardReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*邮件-->一键领取 RPC请求
	*/
	public void OneKeyGetReward(ReplyHandler replyCB)
	{
		MailRpcOneKeyGetRewardAskWraper askPBWraper = new MailRpcOneKeyGetRewardAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_MAIL_ONEKEYGETREWARD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			MailRpcOneKeyGetRewardReplyWraper replyPBWraper = new MailRpcOneKeyGetRewardReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*邮件-->获得新邮件 服务器通知回调
	*/
	public static void NewMailCB( ModMessage notifyMsg )
	{
		MailRpcNewMailNotifyWraper notifyPBWraper = new MailRpcNewMailNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( NewMailCBDelegate != null )
			NewMailCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback NewMailCBDelegate = null;



}

public class MailData
{
	public enum SyncIdE
	{

	}
	
	private static MailData m_Instance = null;
	public static MailData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new MailData();
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
			Ex.Logger.Log("MailData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
