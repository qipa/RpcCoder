/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleCapsule.cs
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


public class CapsuleRPC
{
	public const int ModuleId = 23;
	
	public const int RPC_CODE_CAPSULE_SYNCDATA_REQUEST = 2351;
	public const int RPC_CODE_CAPSULE_BUY_REQUEST = 2352;
	public const int RPC_CODE_CAPSULE_EXCHANGE_REQUEST = 2353;

	
	private static CapsuleRPC m_Instance = null;
	public static CapsuleRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new CapsuleRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, CapsuleData.Instance.UpdateField );
		


		return true;
	}


	/**
	*扭蛋抽奖-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		CapsuleRpcSyncDataAskWraper askPBWraper = new CapsuleRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_CAPSULE_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			CapsuleRpcSyncDataReplyWraper replyPBWraper = new CapsuleRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*扭蛋抽奖-->购买抽奖 RPC请求
	*/
	public void Buy(int Id, int Type, ReplyHandler replyCB)
	{
		CapsuleRpcBuyAskWraper askPBWraper = new CapsuleRpcBuyAskWraper();
		askPBWraper.Id = Id;
		askPBWraper.Type = Type;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_CAPSULE_BUY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			CapsuleRpcBuyReplyWraper replyPBWraper = new CapsuleRpcBuyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*扭蛋抽奖-->装备碎片兑换 RPC请求
	*/
	public void Exchange(int ItemId, ReplyHandler replyCB)
	{
		CapsuleRpcExchangeAskWraper askPBWraper = new CapsuleRpcExchangeAskWraper();
		askPBWraper.ItemId = ItemId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_CAPSULE_EXCHANGE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			CapsuleRpcExchangeReplyWraper replyPBWraper = new CapsuleRpcExchangeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class CapsuleData
{
	public enum SyncIdE
	{
 		EQUIPDEBRIS                                = 2301,  //装备抽奖给的碎片
 		CAPSULEARRAY                               = 2302,  //扭蛋数组

	}
	
	private static CapsuleData m_Instance = null;
	public static CapsuleData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new CapsuleData();
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
			case SyncIdE.EQUIPDEBRIS:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.EquipDebris = iValue;
				break;
			case SyncIdE.CAPSULEARRAY:
				if(Index < 0){ m_Instance.ClearCapsuleArray(); break; }
				if (Index >= m_Instance.SizeCapsuleArray())
				{
					int Count = Index - m_Instance.SizeCapsuleArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddCapsuleArray(new CapsuleCapsuleObjWraperV1());
				}
				m_Instance.GetCapsuleArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("CapsuleData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public CapsuleData()
	{
		 m_EquipDebris = -1;
		m_CapsuleArray = new List<CapsuleCapsuleObjWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_EquipDebris = -1;
		m_CapsuleArray = new List<CapsuleCapsuleObjWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public CapsuleCapsuleDataV1 ToPB()
	{
		CapsuleCapsuleDataV1 v = new CapsuleCapsuleDataV1();
		v.EquipDebris = m_EquipDebris;
		for (int i=0; i<(int)m_CapsuleArray.Count; i++)
			v.CapsuleArray.Add( m_CapsuleArray[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleCapsuleDataV1 v)
	{
        if (v == null)
            return;
		m_EquipDebris = v.EquipDebris;
		m_CapsuleArray.Clear();
		for( int i=0; i<v.CapsuleArray.Count; i++)
			m_CapsuleArray.Add( new CapsuleCapsuleObjWraperV1());
		for( int i=0; i<v.CapsuleArray.Count; i++)
			m_CapsuleArray[i].FromPB(v.CapsuleArray[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleCapsuleDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleCapsuleDataV1 pb = ProtoBuf.Serializer.Deserialize<CapsuleCapsuleDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//装备抽奖给的碎片
	public int m_EquipDebris;
	public int EquipDebris
	{
		get { return m_EquipDebris;}
		set { m_EquipDebris = value; }
	}
	//扭蛋数组
	public List<CapsuleCapsuleObjWraperV1> m_CapsuleArray;
	public int SizeCapsuleArray()
	{
		return m_CapsuleArray.Count;
	}
	public List<CapsuleCapsuleObjWraperV1> GetCapsuleArray()
	{
		return m_CapsuleArray;
	}
	public CapsuleCapsuleObjWraperV1 GetCapsuleArray(int Index)
	{
		if(Index<0 || Index>=(int)m_CapsuleArray.Count)
			return new CapsuleCapsuleObjWraperV1();
		return m_CapsuleArray[Index];
	}
	public void SetCapsuleArray( List<CapsuleCapsuleObjWraperV1> v )
	{
		m_CapsuleArray=v;
	}
	public void SetCapsuleArray( int Index, CapsuleCapsuleObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_CapsuleArray.Count)
			return;
		m_CapsuleArray[Index] = v;
	}
	public void AddCapsuleArray( CapsuleCapsuleObjWraperV1 v )
	{
		m_CapsuleArray.Add(v);
	}
	public void ClearCapsuleArray( )
	{
		m_CapsuleArray.Clear();
	}



}
