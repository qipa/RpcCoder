/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleAchievement.cs
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


public class AchievementRPC
{
	public const int ModuleId = 2;
	
	public const int RPC_CODE_ACHIEVEMENT_GETTHEREWARDS_REQUEST = 251;
	public const int RPC_CODE_ACHIEVEMENT_SYNCDATA_REQUEST = 252;

	
	private static AchievementRPC m_Instance = null;
	public static AchievementRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new AchievementRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, AchievementData.Instance.UpdateField );
		


		return true;
	}


	/**
	*成就-->领取奖励 RPC请求
	*/
	public void GetTheRewards(int GroupId, ReplyHandler replyCB)
	{
		AchievementRpcGetTheRewardsAskWraper askPBWraper = new AchievementRpcGetTheRewardsAskWraper();
		askPBWraper.GroupId = GroupId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACHIEVEMENT_GETTHEREWARDS_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			AchievementRpcGetTheRewardsReplyWraper replyPBWraper = new AchievementRpcGetTheRewardsReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*成就-->同步数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		AchievementRpcSyncDataAskWraper askPBWraper = new AchievementRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_ACHIEVEMENT_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			AchievementRpcSyncDataReplyWraper replyPBWraper = new AchievementRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class AchievementData
{
	public enum SyncIdE
	{
 		ACHIDATA                                   = 201,  //成就数据

	}
	
	private static AchievementData m_Instance = null;
	public static AchievementData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new AchievementData();
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
			case SyncIdE.ACHIDATA:
				if(Index < 0){ m_Instance.ClearAchiData(); break; }
				if (Index >= m_Instance.SizeAchiData())
				{
					int Count = Index - m_Instance.SizeAchiData() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddAchiData(new AchievementAchiObjWraperV1());
				}
				m_Instance.GetAchiData(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("AchievementData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public AchievementData()
	{
		m_AchiData = new List<AchievementAchiObjWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_AchiData = new List<AchievementAchiObjWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public AchievementAchiDataV1 ToPB()
	{
		AchievementAchiDataV1 v = new AchievementAchiDataV1();
		for (int i=0; i<(int)m_AchiData.Count; i++)
			v.AchiData.Add( m_AchiData[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(AchievementAchiDataV1 v)
	{
        if (v == null)
            return;
		m_AchiData.Clear();
		for( int i=0; i<v.AchiData.Count; i++)
			m_AchiData.Add( new AchievementAchiObjWraperV1());
		for( int i=0; i<v.AchiData.Count; i++)
			m_AchiData[i].FromPB(v.AchiData[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<AchievementAchiDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		AchievementAchiDataV1 pb = ProtoBuf.Serializer.Deserialize<AchievementAchiDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//成就数据
	public List<AchievementAchiObjWraperV1> m_AchiData;
	public int SizeAchiData()
	{
		return m_AchiData.Count;
	}
	public List<AchievementAchiObjWraperV1> GetAchiData()
	{
		return m_AchiData;
	}
	public AchievementAchiObjWraperV1 GetAchiData(int Index)
	{
		if(Index<0 || Index>=(int)m_AchiData.Count)
			return new AchievementAchiObjWraperV1();
		return m_AchiData[Index];
	}
	public void SetAchiData( List<AchievementAchiObjWraperV1> v )
	{
		m_AchiData=v;
	}
	public void SetAchiData( int Index, AchievementAchiObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_AchiData.Count)
			return;
		m_AchiData[Index] = v;
	}
	public void AddAchiData( AchievementAchiObjWraperV1 v )
	{
		m_AchiData.Add(v);
	}
	public void ClearAchiData( )
	{
		m_AchiData.Clear();
	}



}
