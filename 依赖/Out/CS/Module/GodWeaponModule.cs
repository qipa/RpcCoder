/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleGodWeapon.cs
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


public class GodWeaponRPC
{
	public const int ModuleId = 21;
	
	public const int RPC_CODE_GODWEAPON_SYNCDATA_REQUEST = 2151;
	public const int RPC_CODE_GODWEAPON_AWAKEN_REQUEST = 2152;
	public const int RPC_CODE_GODWEAPON_INLAY_REQUEST = 2153;
	public const int RPC_CODE_GODWEAPON_UNLOAD_REQUEST = 2154;
	public const int RPC_CODE_GODWEAPON_COMPOUND_REQUEST = 2155;

	
	private static GodWeaponRPC m_Instance = null;
	public static GodWeaponRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GodWeaponRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, GodWeaponData.Instance.UpdateField );
		


		return true;
	}


	/**
	*神器-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		GodWeaponRpcSyncDataAskWraper askPBWraper = new GodWeaponRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GODWEAPON_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GodWeaponRpcSyncDataReplyWraper replyPBWraper = new GodWeaponRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*神器-->觉醒 RPC请求
	*/
	public void Awaken(int Id, ReplyHandler replyCB)
	{
		GodWeaponRpcAwakenAskWraper askPBWraper = new GodWeaponRpcAwakenAskWraper();
		askPBWraper.Id = Id;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GODWEAPON_AWAKEN_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GodWeaponRpcAwakenReplyWraper replyPBWraper = new GodWeaponRpcAwakenReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*神器-->宝石镶嵌 RPC请求
	*/
	public void Inlay(int Id, int GemId, int Pos, ReplyHandler replyCB)
	{
		GodWeaponRpcInlayAskWraper askPBWraper = new GodWeaponRpcInlayAskWraper();
		askPBWraper.Id = Id;
		askPBWraper.GemId = GemId;
		askPBWraper.Pos = Pos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GODWEAPON_INLAY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GodWeaponRpcInlayReplyWraper replyPBWraper = new GodWeaponRpcInlayReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*神器-->卸下宝石 RPC请求
	*/
	public void Unload(int Id, int Pos, ReplyHandler replyCB)
	{
		GodWeaponRpcUnloadAskWraper askPBWraper = new GodWeaponRpcUnloadAskWraper();
		askPBWraper.Id = Id;
		askPBWraper.Pos = Pos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GODWEAPON_UNLOAD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GodWeaponRpcUnloadReplyWraper replyPBWraper = new GodWeaponRpcUnloadReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*神器-->宝石合成 RPC请求
	*/
	public void Compound(ReplyHandler replyCB)
	{
		GodWeaponRpcCompoundAskWraper askPBWraper = new GodWeaponRpcCompoundAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GODWEAPON_COMPOUND_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GodWeaponRpcCompoundReplyWraper replyPBWraper = new GodWeaponRpcCompoundReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class GodWeaponData
{
	public enum SyncIdE
	{
 		GODWEAPONARRAY                             = 2101,  //神器数组
 		GEMBAGARRAY                                = 2102,  //宝石数组

	}
	
	private static GodWeaponData m_Instance = null;
	public static GodWeaponData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GodWeaponData();
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
			case SyncIdE.GODWEAPONARRAY:
				if(Index < 0){ m_Instance.ClearGodWeaponArray(); break; }
				if (Index >= m_Instance.SizeGodWeaponArray())
				{
					int Count = Index - m_Instance.SizeGodWeaponArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddGodWeaponArray(new GodWeaponGodWeaponObjWraperV1());
				}
				m_Instance.GetGodWeaponArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.GEMBAGARRAY:
				if(Index < 0){ m_Instance.ClearGemBagArray(); break; }
				if (Index >= m_Instance.SizeGemBagArray())
				{
					int Count = Index - m_Instance.SizeGemBagArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddGemBagArray(new GodWeaponGemGridObjWraperV1());
				}
				m_Instance.GetGemBagArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("GodWeaponData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public GodWeaponData()
	{
		m_GodWeaponArray = new List<GodWeaponGodWeaponObjWraperV1>();
		m_GemBagArray = new List<GodWeaponGemGridObjWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_GodWeaponArray = new List<GodWeaponGodWeaponObjWraperV1>();
		m_GemBagArray = new List<GodWeaponGemGridObjWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public GodWeaponGodWeaponDataV1 ToPB()
	{
		GodWeaponGodWeaponDataV1 v = new GodWeaponGodWeaponDataV1();
		for (int i=0; i<(int)m_GodWeaponArray.Count; i++)
			v.GodWeaponArray.Add( m_GodWeaponArray[i].ToPB());
		for (int i=0; i<(int)m_GemBagArray.Count; i++)
			v.GemBagArray.Add( m_GemBagArray[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponGodWeaponDataV1 v)
	{
        if (v == null)
            return;
		m_GodWeaponArray.Clear();
		for( int i=0; i<v.GodWeaponArray.Count; i++)
			m_GodWeaponArray.Add( new GodWeaponGodWeaponObjWraperV1());
		for( int i=0; i<v.GodWeaponArray.Count; i++)
			m_GodWeaponArray[i].FromPB(v.GodWeaponArray[i]);
		m_GemBagArray.Clear();
		for( int i=0; i<v.GemBagArray.Count; i++)
			m_GemBagArray.Add( new GodWeaponGemGridObjWraperV1());
		for( int i=0; i<v.GemBagArray.Count; i++)
			m_GemBagArray[i].FromPB(v.GemBagArray[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponGodWeaponDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponGodWeaponDataV1 pb = ProtoBuf.Serializer.Deserialize<GodWeaponGodWeaponDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//神器数组
	public List<GodWeaponGodWeaponObjWraperV1> m_GodWeaponArray;
	public int SizeGodWeaponArray()
	{
		return m_GodWeaponArray.Count;
	}
	public List<GodWeaponGodWeaponObjWraperV1> GetGodWeaponArray()
	{
		return m_GodWeaponArray;
	}
	public GodWeaponGodWeaponObjWraperV1 GetGodWeaponArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GodWeaponArray.Count)
			return new GodWeaponGodWeaponObjWraperV1();
		return m_GodWeaponArray[Index];
	}
	public void SetGodWeaponArray( List<GodWeaponGodWeaponObjWraperV1> v )
	{
		m_GodWeaponArray=v;
	}
	public void SetGodWeaponArray( int Index, GodWeaponGodWeaponObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GodWeaponArray.Count)
			return;
		m_GodWeaponArray[Index] = v;
	}
	public void AddGodWeaponArray( GodWeaponGodWeaponObjWraperV1 v )
	{
		m_GodWeaponArray.Add(v);
	}
	public void ClearGodWeaponArray( )
	{
		m_GodWeaponArray.Clear();
	}
	//宝石数组
	public List<GodWeaponGemGridObjWraperV1> m_GemBagArray;
	public int SizeGemBagArray()
	{
		return m_GemBagArray.Count;
	}
	public List<GodWeaponGemGridObjWraperV1> GetGemBagArray()
	{
		return m_GemBagArray;
	}
	public GodWeaponGemGridObjWraperV1 GetGemBagArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GemBagArray.Count)
			return new GodWeaponGemGridObjWraperV1();
		return m_GemBagArray[Index];
	}
	public void SetGemBagArray( List<GodWeaponGemGridObjWraperV1> v )
	{
		m_GemBagArray=v;
	}
	public void SetGemBagArray( int Index, GodWeaponGemGridObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GemBagArray.Count)
			return;
		m_GemBagArray[Index] = v;
	}
	public void AddGemBagArray( GodWeaponGemGridObjWraperV1 v )
	{
		m_GemBagArray.Add(v);
	}
	public void ClearGemBagArray( )
	{
		m_GemBagArray.Clear();
	}



}
