/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleLogin.cs
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


public class LoginRPC
{
	public const int ModuleId = 5;
	
	public const int RPC_CODE_LOGIN_KEYAUTH_REQUEST = 551;
	public const int RPC_CODE_LOGIN_KICKOFF_NOTIFY = 552;

	
	private static LoginRPC m_Instance = null;
	public static LoginRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new LoginRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, LoginData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_LOGIN_KICKOFF_NOTIFY, KickOffCB);


		return true;
	}


	/**
	*登录模块-->密钥认证 RPC请求
	*/
	public void KeyAuth(int DistId, string RsaData, ReplyHandler replyCB)
	{
		LoginRpcKeyAuthAskWraper askPBWraper = new LoginRpcKeyAuthAskWraper();
		askPBWraper.DistId = DistId;
		askPBWraper.RsaData = RsaData;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_LOGIN_KEYAUTH_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			LoginRpcKeyAuthReplyWraper replyPBWraper = new LoginRpcKeyAuthReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*登录模块-->被踢下线 服务器通知回调
	*/
	public static void KickOffCB( ModMessage notifyMsg )
	{
		LoginRpcKickOffNotifyWraper notifyPBWraper = new LoginRpcKickOffNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( KickOffCBDelegate != null )
			KickOffCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback KickOffCBDelegate = null;



}

public class LoginData
{
	public enum SyncIdE
	{

	}
	
	private static LoginData m_Instance = null;
	public static LoginData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new LoginData();
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
			Ex.Logger.Log("LoginData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
