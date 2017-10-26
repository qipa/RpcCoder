/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleRefreshData.cs
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


public class RefreshDataRPC
{
	public const int ModuleId = 39;
	

	
	private static RefreshDataRPC m_Instance = null;
	public static RefreshDataRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new RefreshDataRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, RefreshDataData.Instance.UpdateField );
		


		return true;
	}






}

public class RefreshDataData
{
	public enum SyncIdE
	{
 		LASTREFRESHTIME                            = 3901,  //上次刷新

	}
	
	private static RefreshDataData m_Instance = null;
	public static RefreshDataData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new RefreshDataData();
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
			case SyncIdE.LASTREFRESHTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.LastRefreshTime = iValue;
				break;

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
			Ex.Logger.Log("RefreshDataData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public RefreshDataData()
	{
		 m_LastRefreshTime = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_LastRefreshTime = 0;

	}

 	//转化成Protobuffer类型函数
	public RefreshDataRefreshDataV1 ToPB()
	{
		RefreshDataRefreshDataV1 v = new RefreshDataRefreshDataV1();
		v.LastRefreshTime = m_LastRefreshTime;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(RefreshDataRefreshDataV1 v)
	{
        if (v == null)
            return;
		m_LastRefreshTime = v.LastRefreshTime;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<RefreshDataRefreshDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		RefreshDataRefreshDataV1 pb = ProtoBuf.Serializer.Deserialize<RefreshDataRefreshDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//上次刷新
	public int m_LastRefreshTime;
	public int LastRefreshTime
	{
		get { return m_LastRefreshTime;}
		set { m_LastRefreshTime = value; }
	}



}
