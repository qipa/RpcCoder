/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleGM.cs
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


public class GMRPC
{
	public const int ModuleId = 17;
	
	public const int RPC_CODE_GM_ACTION_REQUEST = 1751;

	
	private static GMRPC m_Instance = null;
	public static GMRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GMRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, GMData.Instance.UpdateField );
		


		return true;
	}


	/**
	*GM指令-->指令动作 RPC请求
	*/
	public void Action(string Value, ReplyHandler replyCB)
	{
		GMRpcActionAskWraper askPBWraper = new GMRpcActionAskWraper();
		askPBWraper.Value = Value;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GM_ACTION_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GMRpcActionReplyWraper replyPBWraper = new GMRpcActionReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class GMData
{
	public enum SyncIdE
	{

	}
	
	private static GMData m_Instance = null;
	public static GMData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GMData();
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
			Ex.Logger.Log("GMData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
