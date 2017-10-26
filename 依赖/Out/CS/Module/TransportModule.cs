/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleTransport.cs
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


public class TransportRPC
{
	public const int ModuleId = 40;
	
	public const int RPC_CODE_TRANSPORT_SYNCDATA_REQUEST = 4051;
	public const int RPC_CODE_TRANSPORT_FILL_REQUEST = 4052;
	public const int RPC_CODE_TRANSPORT_HELPOTHER_REQUEST = 4053;
	public const int RPC_CODE_TRANSPORT_ASKHELP_REQUEST = 4054;
	public const int RPC_CODE_TRANSPORT_SETSAIL_REQUEST = 4055;
	public const int RPC_CODE_TRANSPORT_ADDTRANSPORT_REQUEST = 4056;
	public const int RPC_CODE_TRANSPORT_ISHELPED_NOTIFY = 4057;

	
	private static TransportRPC m_Instance = null;
	public static TransportRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TransportRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, TransportData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TRANSPORT_ISHELPED_NOTIFY, IsHelpedCB);


		return true;
	}


	/**
	*货运-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		TransportRpcSyncDataAskWraper askPBWraper = new TransportRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TRANSPORT_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TransportRpcSyncDataReplyWraper replyPBWraper = new TransportRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*货运-->填充 RPC请求
	*/
	public void Fill(int FillID, ReplyHandler replyCB)
	{
		TransportRpcFillAskWraper askPBWraper = new TransportRpcFillAskWraper();
		askPBWraper.FillID = FillID;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TRANSPORT_FILL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TransportRpcFillReplyWraper replyPBWraper = new TransportRpcFillReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*货运-->帮助请求 RPC请求
	*/
	public void HelpOther(int ItemID, long UserId, ReplyHandler replyCB)
	{
		TransportRpcHelpOtherAskWraper askPBWraper = new TransportRpcHelpOtherAskWraper();
		askPBWraper.ItemID = ItemID;
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TRANSPORT_HELPOTHER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TransportRpcHelpOtherReplyWraper replyPBWraper = new TransportRpcHelpOtherReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*货运-->请求帮助 RPC请求
	*/
	public void AskHelp(int ItemID, ReplyHandler replyCB)
	{
		TransportRpcAskHelpAskWraper askPBWraper = new TransportRpcAskHelpAskWraper();
		askPBWraper.ItemID = ItemID;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TRANSPORT_ASKHELP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TransportRpcAskHelpReplyWraper replyPBWraper = new TransportRpcAskHelpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*货运-->起航请求 RPC请求
	*/
	public void SetSail(ReplyHandler replyCB)
	{
		TransportRpcSetSailAskWraper askPBWraper = new TransportRpcSetSailAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TRANSPORT_SETSAIL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TransportRpcSetSailReplyWraper replyPBWraper = new TransportRpcSetSailReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*货运-->添加货物 RPC请求
	*/
	public void AddTransport(int Lv, ReplyHandler replyCB)
	{
		TransportRpcAddTransportAskWraper askPBWraper = new TransportRpcAddTransportAskWraper();
		askPBWraper.Lv = Lv;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TRANSPORT_ADDTRANSPORT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TransportRpcAddTransportReplyWraper replyPBWraper = new TransportRpcAddTransportReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*货运-->自己被帮助通知 服务器通知回调
	*/
	public static void IsHelpedCB( ModMessage notifyMsg )
	{
		TransportRpcIsHelpedNotifyWraper notifyPBWraper = new TransportRpcIsHelpedNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( IsHelpedCBDelegate != null )
			IsHelpedCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback IsHelpedCBDelegate = null;



}

public class TransportData
{
	public enum SyncIdE
	{
 		GOODSARRAY                                 = 4001,  //货物容器
 		ASKNUM                                     = 4002,  //请求数量
 		HELPNUM                                    = 4003,  //帮助次数
 		REWARDARRY                                 = 4004,  //起航奖励
 		REWARDFLAG                                 = 4006,  //奖励是否领取标识
 		PICKTASKFLAG                               = 4007,  //是否接取任务

	}
	
	private static TransportData m_Instance = null;
	public static TransportData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TransportData();
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
			case SyncIdE.GOODSARRAY:
				if(Index < 0){ m_Instance.ClearGoodsArray(); break; }
				if (Index >= m_Instance.SizeGoodsArray())
				{
					int Count = Index - m_Instance.SizeGoodsArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddGoodsArray(new TransportGoodsObjWraperV1());
				}
				m_Instance.GetGoodsArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.ASKNUM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.AskNum = iValue;
				break;
			case SyncIdE.HELPNUM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.HelpNum = iValue;
				break;
			case SyncIdE.REWARDARRY:
				if(Index < 0){ m_Instance.ClearRewardArry(); break; }
				if (Index >= m_Instance.SizeRewardArry())
				{
					int Count = Index - m_Instance.SizeRewardArry() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddRewardArry(new TransportRewardObjWraperV1());
				}
				m_Instance.GetRewardArry(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.REWARDFLAG:
				m_Instance.RewardFlag = BitConverter.ToBoolean(updateBuffer,0);
				break;
			case SyncIdE.PICKTASKFLAG:
				m_Instance.PickTaskFlag = BitConverter.ToBoolean(updateBuffer,0);
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
			Ex.Logger.Log("TransportData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public TransportData()
	{
		m_GoodsArray = new List<TransportGoodsObjWraperV1>();
		 m_AskNum = -1;
		 m_HelpNum = -1;
		m_RewardArry = new List<TransportRewardObjWraperV1>();
		 m_RewardFlag = false;
		 m_PickTaskFlag = false;

	}

	//重置函数
	public void ResetWraper()
	{
		m_GoodsArray = new List<TransportGoodsObjWraperV1>();
		 m_AskNum = -1;
		 m_HelpNum = -1;
		m_RewardArry = new List<TransportRewardObjWraperV1>();
		 m_RewardFlag = false;
		 m_PickTaskFlag = false;

	}

 	//转化成Protobuffer类型函数
	public TransportGoodsDataV1 ToPB()
	{
		TransportGoodsDataV1 v = new TransportGoodsDataV1();
		for (int i=0; i<(int)m_GoodsArray.Count; i++)
			v.GoodsArray.Add( m_GoodsArray[i].ToPB());
		v.AskNum = m_AskNum;
		v.HelpNum = m_HelpNum;
		for (int i=0; i<(int)m_RewardArry.Count; i++)
			v.RewardArry.Add( m_RewardArry[i].ToPB());
		v.RewardFlag = m_RewardFlag;
		v.PickTaskFlag = m_PickTaskFlag;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportGoodsDataV1 v)
	{
        if (v == null)
            return;
		m_GoodsArray.Clear();
		for( int i=0; i<v.GoodsArray.Count; i++)
			m_GoodsArray.Add( new TransportGoodsObjWraperV1());
		for( int i=0; i<v.GoodsArray.Count; i++)
			m_GoodsArray[i].FromPB(v.GoodsArray[i]);
		m_AskNum = v.AskNum;
		m_HelpNum = v.HelpNum;
		m_RewardArry.Clear();
		for( int i=0; i<v.RewardArry.Count; i++)
			m_RewardArry.Add( new TransportRewardObjWraperV1());
		for( int i=0; i<v.RewardArry.Count; i++)
			m_RewardArry[i].FromPB(v.RewardArry[i]);
		m_RewardFlag = v.RewardFlag;
		m_PickTaskFlag = v.PickTaskFlag;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportGoodsDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportGoodsDataV1 pb = ProtoBuf.Serializer.Deserialize<TransportGoodsDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//货物容器
	public List<TransportGoodsObjWraperV1> m_GoodsArray;
	public int SizeGoodsArray()
	{
		return m_GoodsArray.Count;
	}
	public List<TransportGoodsObjWraperV1> GetGoodsArray()
	{
		return m_GoodsArray;
	}
	public TransportGoodsObjWraperV1 GetGoodsArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GoodsArray.Count)
			return new TransportGoodsObjWraperV1();
		return m_GoodsArray[Index];
	}
	public void SetGoodsArray( List<TransportGoodsObjWraperV1> v )
	{
		m_GoodsArray=v;
	}
	public void SetGoodsArray( int Index, TransportGoodsObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GoodsArray.Count)
			return;
		m_GoodsArray[Index] = v;
	}
	public void AddGoodsArray( TransportGoodsObjWraperV1 v )
	{
		m_GoodsArray.Add(v);
	}
	public void ClearGoodsArray( )
	{
		m_GoodsArray.Clear();
	}
	//请求数量
	public int m_AskNum;
	public int AskNum
	{
		get { return m_AskNum;}
		set { m_AskNum = value; }
	}
	//帮助次数
	public int m_HelpNum;
	public int HelpNum
	{
		get { return m_HelpNum;}
		set { m_HelpNum = value; }
	}
	//起航奖励
	public List<TransportRewardObjWraperV1> m_RewardArry;
	public int SizeRewardArry()
	{
		return m_RewardArry.Count;
	}
	public List<TransportRewardObjWraperV1> GetRewardArry()
	{
		return m_RewardArry;
	}
	public TransportRewardObjWraperV1 GetRewardArry(int Index)
	{
		if(Index<0 || Index>=(int)m_RewardArry.Count)
			return new TransportRewardObjWraperV1();
		return m_RewardArry[Index];
	}
	public void SetRewardArry( List<TransportRewardObjWraperV1> v )
	{
		m_RewardArry=v;
	}
	public void SetRewardArry( int Index, TransportRewardObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_RewardArry.Count)
			return;
		m_RewardArry[Index] = v;
	}
	public void AddRewardArry( TransportRewardObjWraperV1 v )
	{
		m_RewardArry.Add(v);
	}
	public void ClearRewardArry( )
	{
		m_RewardArry.Clear();
	}
	//奖励是否领取标识
	public bool m_RewardFlag;
	public bool RewardFlag
	{
		get { return m_RewardFlag;}
		set { m_RewardFlag = value; }
	}
	//是否接取任务
	public bool m_PickTaskFlag;
	public bool PickTaskFlag
	{
		get { return m_PickTaskFlag;}
		set { m_PickTaskFlag = value; }
	}



}
