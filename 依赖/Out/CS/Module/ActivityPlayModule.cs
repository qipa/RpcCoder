/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleActivityPlay.cs
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


public class ActivityPlayRPC
{
	public const int ModuleId = 38;
	

	
	private static ActivityPlayRPC m_Instance = null;
	public static ActivityPlayRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityPlayRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, ActivityPlayData.Instance.UpdateField );
		


		return true;
	}






}

public class ActivityPlayData
{
	public enum SyncIdE
	{

	}
	
	private static ActivityPlayData m_Instance = null;
	public static ActivityPlayData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ActivityPlayData();
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
			Ex.Logger.Log("ActivityPlayData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
