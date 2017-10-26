/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleOneVSOneTop.cs
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


public class OneVSOneTopRPC
{
	public const int ModuleId = 42;
	

	
	private static OneVSOneTopRPC m_Instance = null;
	public static OneVSOneTopRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new OneVSOneTopRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, OneVSOneTopData.Instance.UpdateField );
		


		return true;
	}






}

public class OneVSOneTopData
{
	public enum SyncIdE
	{

	}
	
	private static OneVSOneTopData m_Instance = null;
	public static OneVSOneTopData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new OneVSOneTopData();
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
			Ex.Logger.Log("OneVSOneTopData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
