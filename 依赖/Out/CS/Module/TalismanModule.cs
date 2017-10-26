/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleTalisman.cs
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


public class TalismanRPC
{
	public const int ModuleId = 18;
	
	public const int RPC_CODE_TALISMAN_SYNCDATA_REQUEST = 1851;
	public const int RPC_CODE_TALISMAN_ACTIVE_REQUEST = 1852;
	public const int RPC_CODE_TALISMAN_UPGRADE_REQUEST = 1853;

	
	private static TalismanRPC m_Instance = null;
	public static TalismanRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TalismanRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, TalismanData.Instance.UpdateField );
		


		return true;
	}


	/**
	*法宝-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		TalismanRpcSyncDataAskWraper askPBWraper = new TalismanRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TALISMAN_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TalismanRpcSyncDataReplyWraper replyPBWraper = new TalismanRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*法宝-->激活 RPC请求
	*/
	public void Active(int ID, ReplyHandler replyCB)
	{
		TalismanRpcActiveAskWraper askPBWraper = new TalismanRpcActiveAskWraper();
		askPBWraper.ID = ID;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TALISMAN_ACTIVE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TalismanRpcActiveReplyWraper replyPBWraper = new TalismanRpcActiveReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*法宝-->升级 RPC请求
	*/
	public void Upgrade(int ID, int Type, ReplyHandler replyCB)
	{
		TalismanRpcUpgradeAskWraper askPBWraper = new TalismanRpcUpgradeAskWraper();
		askPBWraper.ID = ID;
		askPBWraper.Type = Type;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TALISMAN_UPGRADE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TalismanRpcUpgradeReplyWraper replyPBWraper = new TalismanRpcUpgradeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class TalismanData
{
	public enum SyncIdE
	{
 		FABAOARR                                   = 1801,  //法宝列表

	}
	
	private static TalismanData m_Instance = null;
	public static TalismanData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TalismanData();
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
			case SyncIdE.FABAOARR:
				if(Index < 0){ m_Instance.ClearFabaoArr(); break; }
				if (Index >= m_Instance.SizeFabaoArr())
				{
					int Count = Index - m_Instance.SizeFabaoArr() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddFabaoArr(new TalismanFabaoInfoWraperV1());
				}
				m_Instance.GetFabaoArr(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("TalismanData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public TalismanData()
	{
		m_FabaoArr = new List<TalismanFabaoInfoWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_FabaoArr = new List<TalismanFabaoInfoWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public TalismanDataFabaoV1 ToPB()
	{
		TalismanDataFabaoV1 v = new TalismanDataFabaoV1();
		for (int i=0; i<(int)m_FabaoArr.Count; i++)
			v.FabaoArr.Add( m_FabaoArr[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanDataFabaoV1 v)
	{
        if (v == null)
            return;
		m_FabaoArr.Clear();
		for( int i=0; i<v.FabaoArr.Count; i++)
			m_FabaoArr.Add( new TalismanFabaoInfoWraperV1());
		for( int i=0; i<v.FabaoArr.Count; i++)
			m_FabaoArr[i].FromPB(v.FabaoArr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanDataFabaoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanDataFabaoV1 pb = ProtoBuf.Serializer.Deserialize<TalismanDataFabaoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//法宝列表
	public List<TalismanFabaoInfoWraperV1> m_FabaoArr;
	public int SizeFabaoArr()
	{
		return m_FabaoArr.Count;
	}
	public List<TalismanFabaoInfoWraperV1> GetFabaoArr()
	{
		return m_FabaoArr;
	}
	public TalismanFabaoInfoWraperV1 GetFabaoArr(int Index)
	{
		if(Index<0 || Index>=(int)m_FabaoArr.Count)
			return new TalismanFabaoInfoWraperV1();
		return m_FabaoArr[Index];
	}
	public void SetFabaoArr( List<TalismanFabaoInfoWraperV1> v )
	{
		m_FabaoArr=v;
	}
	public void SetFabaoArr( int Index, TalismanFabaoInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_FabaoArr.Count)
			return;
		m_FabaoArr[Index] = v;
	}
	public void AddFabaoArr( TalismanFabaoInfoWraperV1 v )
	{
		m_FabaoArr.Add(v);
	}
	public void ClearFabaoArr( )
	{
		m_FabaoArr.Clear();
	}



}
