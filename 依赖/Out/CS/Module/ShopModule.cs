/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleShop.cs
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


public class ShopRPC
{
	public const int ModuleId = 22;
	
	public const int RPC_CODE_SHOP_SYNCDATA_REQUEST = 2251;
	public const int RPC_CODE_SHOP_BUY_REQUEST = 2252;
	public const int RPC_CODE_SHOP_REFRESHITEM_REQUEST = 2253;

	
	private static ShopRPC m_Instance = null;
	public static ShopRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ShopRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, ShopData.Instance.UpdateField );
		


		return true;
	}


	/**
	*商城-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		ShopRpcSyncDataAskWraper askPBWraper = new ShopRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SHOP_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ShopRpcSyncDataReplyWraper replyPBWraper = new ShopRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*商城-->购买 RPC请求
	*/
	public void Buy(int ShopType, int ItemId, int Pos, ReplyHandler replyCB)
	{
		ShopRpcBuyAskWraper askPBWraper = new ShopRpcBuyAskWraper();
		askPBWraper.ShopType = ShopType;
		askPBWraper.ItemId = ItemId;
		askPBWraper.Pos = Pos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SHOP_BUY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ShopRpcBuyReplyWraper replyPBWraper = new ShopRpcBuyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*商城-->刷新道具 RPC请求
	*/
	public void RefreshItem(int ShopType, ReplyHandler replyCB)
	{
		ShopRpcRefreshItemAskWraper askPBWraper = new ShopRpcRefreshItemAskWraper();
		askPBWraper.ShopType = ShopType;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_SHOP_REFRESHITEM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			ShopRpcRefreshItemReplyWraper replyPBWraper = new ShopRpcRefreshItemReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class ShopData
{
	public enum SyncIdE
	{
 		SHOPARRAY                                  = 2201,  //商店

	}
	
	private static ShopData m_Instance = null;
	public static ShopData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new ShopData();
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
			case SyncIdE.SHOPARRAY:
				if(Index < 0){ m_Instance.ClearShopArray(); break; }
				if (Index >= m_Instance.SizeShopArray())
				{
					int Count = Index - m_Instance.SizeShopArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddShopArray(new ShopShopObjWraperV1());
				}
				m_Instance.GetShopArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("ShopData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public ShopData()
	{
		m_ShopArray = new List<ShopShopObjWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_ShopArray = new List<ShopShopObjWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public ShopShopDataV1 ToPB()
	{
		ShopShopDataV1 v = new ShopShopDataV1();
		for (int i=0; i<(int)m_ShopArray.Count; i++)
			v.ShopArray.Add( m_ShopArray[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopShopDataV1 v)
	{
        if (v == null)
            return;
		m_ShopArray.Clear();
		for( int i=0; i<v.ShopArray.Count; i++)
			m_ShopArray.Add( new ShopShopObjWraperV1());
		for( int i=0; i<v.ShopArray.Count; i++)
			m_ShopArray[i].FromPB(v.ShopArray[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopShopDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopShopDataV1 pb = ProtoBuf.Serializer.Deserialize<ShopShopDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//商店
	public List<ShopShopObjWraperV1> m_ShopArray;
	public int SizeShopArray()
	{
		return m_ShopArray.Count;
	}
	public List<ShopShopObjWraperV1> GetShopArray()
	{
		return m_ShopArray;
	}
	public ShopShopObjWraperV1 GetShopArray(int Index)
	{
		if(Index<0 || Index>=(int)m_ShopArray.Count)
			return new ShopShopObjWraperV1();
		return m_ShopArray[Index];
	}
	public void SetShopArray( List<ShopShopObjWraperV1> v )
	{
		m_ShopArray=v;
	}
	public void SetShopArray( int Index, ShopShopObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_ShopArray.Count)
			return;
		m_ShopArray[Index] = v;
	}
	public void AddShopArray( ShopShopObjWraperV1 v )
	{
		m_ShopArray.Add(v);
	}
	public void ClearShopArray( )
	{
		m_ShopArray.Clear();
	}



}
