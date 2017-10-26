/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleActivityEscape.cs
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


public class ActivityEscapeRPC
{
	public const int ModuleId = 31;
	
	public const int RPC_CODE_ACTIVITYESCAPE_SIGNUP_REQUEST = 3151;

	
	private static ActivityEscapeRPC m_Instance = null;
	public static ActivityEscapeRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityEscapeRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, ActivityEscapeData.Instance.UpdateField );
		


		return true;
	}


	/**
	*活动 大逃杀-->报名进入 RPC请求
	*/
	public void SignUp(ReplyHandler replyCB)
	{
		ActivityEscapeRpcSignUpAskWraper askPBWraper = new ActivityEscapeRpcSignUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACTIVITYESCAPE_SIGNUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ActivityEscapeRpcSignUpReplyWraper replyPBWraper = new ActivityEscapeRpcSignUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class ActivityEscapeData
{
	public enum SyncIdE
	{

	}
	
	private static ActivityEscapeData m_Instance = null;
	public static ActivityEscapeData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityEscapeData();
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
			Ex.Logger.Log("ActivityEscapeData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
