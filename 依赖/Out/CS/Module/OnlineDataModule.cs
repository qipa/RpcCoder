/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleOnlineData.cs
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


public class OnlineDataRPC
{
	public const int ModuleId = 28;
	

	
	private static OnlineDataRPC m_Instance = null;
	public static OnlineDataRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new OnlineDataRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, OnlineDataData.Instance.UpdateField );
		


		return true;
	}






}

public class OnlineDataData
{
	public enum SyncIdE
	{
 		BAGRECYCLEBIN                              = 2801,  //回收站
 		ROLEATTR                                   = 2802,  //角色属性
 		RECOMMENDFRIENDOFFSET                      = 2804,  //推荐好友偏移
 		RECOMMENDFRIENDFLUSHTIME                   = 2805,  //推荐好友刷新时间
 		RECOMMENDFRIENDLASTLIST                    = 2806,  //上次推荐的好友
 		FOLLOWMEUSERID                             = 2807,  //跟随我的人
 		FOLLOWWHO                                  = 2809,  //跟随谁
 		THIEFOBJID                                 = 2810,  //江洋大盗

	}
	
	private static OnlineDataData m_Instance = null;
	public static OnlineDataData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new OnlineDataData();
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
			case SyncIdE.BAGRECYCLEBIN:
				if(Index < 0){ m_Instance.ClearBagRecycleBin(); break; }
				if (Index >= m_Instance.SizeBagRecycleBin())
				{
					int Count = Index - m_Instance.SizeBagRecycleBin() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddBagRecycleBin(new BagRecycleGridObjWraper());
				}
				m_Instance.GetBagRecycleBin(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.ROLEATTR:
				if(Index < 0){ m_Instance.ClearRoleAttr(); break; }
				if (Index >= m_Instance.SizeRoleAttr())
				{
					int Count = Index - m_Instance.SizeRoleAttr() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddRoleAttr(new OnlineDataRoleAttrObjWraperV1());
				}
				m_Instance.GetRoleAttr(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.RECOMMENDFRIENDOFFSET:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.RecommendFriendOffset = iValue;
				break;
			case SyncIdE.RECOMMENDFRIENDFLUSHTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.RecommendFriendFlushTime = iValue;
				break;
			case SyncIdE.RECOMMENDFRIENDLASTLIST:
				if(Index < 0){ m_Instance.ClearRecommendFriendLastList(); break; }
				if (Index >= m_Instance.SizeRecommendFriendLastList())
				{
					int Count = Index - m_Instance.SizeRecommendFriendLastList() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddRecommendFriendLastList(-1);
				}
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.SetRecommendFriendLastList(Index, lValue);
				break;
			case SyncIdE.FOLLOWMEUSERID:
				if(Index < 0){ m_Instance.ClearFollowmeUserId(); break; }
				if (Index >= m_Instance.SizeFollowmeUserId())
				{
					int Count = Index - m_Instance.SizeFollowmeUserId() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddFollowmeUserId(-1);
				}
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.SetFollowmeUserId(Index, lValue);
				break;
			case SyncIdE.FOLLOWWHO:
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.FollowWho = lValue;
				break;
			case SyncIdE.THIEFOBJID:
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.ThiefObjId = lValue;
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
			Ex.Logger.Log("OnlineDataData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public OnlineDataData()
	{
		m_BagRecycleBin = new List<BagRecycleGridObjWraper>();
		m_RoleAttr = new List<OnlineDataRoleAttrObjWraperV1>();
		 m_RecommendFriendOffset = 0;
		 m_RecommendFriendFlushTime = -1;
		m_RecommendFriendLastList = new List<long>();
		m_FollowmeUserId = new List<long>();
		 m_FollowWho = -1;
		 m_ThiefObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_BagRecycleBin = new List<BagRecycleGridObjWraper>();
		m_RoleAttr = new List<OnlineDataRoleAttrObjWraperV1>();
		 m_RecommendFriendOffset = 0;
		 m_RecommendFriendFlushTime = -1;
		m_RecommendFriendLastList = new List<long>();
		m_FollowmeUserId = new List<long>();
		 m_FollowWho = -1;
		 m_ThiefObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public OnlineDataOnlineDataV1 ToPB()
	{
		OnlineDataOnlineDataV1 v = new OnlineDataOnlineDataV1();
		for (int i=0; i<(int)m_BagRecycleBin.Count; i++)
			v.BagRecycleBin.Add( m_BagRecycleBin[i].ToPB());
		for (int i=0; i<(int)m_RoleAttr.Count; i++)
			v.RoleAttr.Add( m_RoleAttr[i].ToPB());
		v.RecommendFriendOffset = m_RecommendFriendOffset;
		v.RecommendFriendFlushTime = m_RecommendFriendFlushTime;
		for (int i=0; i<(int)m_RecommendFriendLastList.Count; i++)
			v.RecommendFriendLastList.Add( m_RecommendFriendLastList[i]);
		for (int i=0; i<(int)m_FollowmeUserId.Count; i++)
			v.FollowmeUserId.Add( m_FollowmeUserId[i]);
		v.FollowWho = m_FollowWho;
		v.ThiefObjId = m_ThiefObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OnlineDataOnlineDataV1 v)
	{
        if (v == null)
            return;
		m_BagRecycleBin.Clear();
		for( int i=0; i<v.BagRecycleBin.Count; i++)
			m_BagRecycleBin.Add( new BagRecycleGridObjWraper());
		for( int i=0; i<v.BagRecycleBin.Count; i++)
			m_BagRecycleBin[i].FromPB(v.BagRecycleBin[i]);
		m_RoleAttr.Clear();
		for( int i=0; i<v.RoleAttr.Count; i++)
			m_RoleAttr.Add( new OnlineDataRoleAttrObjWraperV1());
		for( int i=0; i<v.RoleAttr.Count; i++)
			m_RoleAttr[i].FromPB(v.RoleAttr[i]);
		m_RecommendFriendOffset = v.RecommendFriendOffset;
		m_RecommendFriendFlushTime = v.RecommendFriendFlushTime;
		m_RecommendFriendLastList.Clear();
		for( int i=0; i<v.RecommendFriendLastList.Count; i++)
			m_RecommendFriendLastList.Add(v.RecommendFriendLastList[i]);
		m_FollowmeUserId.Clear();
		for( int i=0; i<v.FollowmeUserId.Count; i++)
			m_FollowmeUserId.Add(v.FollowmeUserId[i]);
		m_FollowWho = v.FollowWho;
		m_ThiefObjId = v.ThiefObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OnlineDataOnlineDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OnlineDataOnlineDataV1 pb = ProtoBuf.Serializer.Deserialize<OnlineDataOnlineDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//回收站
	public List<BagRecycleGridObjWraper> m_BagRecycleBin;
	public int SizeBagRecycleBin()
	{
		return m_BagRecycleBin.Count;
	}
	public List<BagRecycleGridObjWraper> GetBagRecycleBin()
	{
		return m_BagRecycleBin;
	}
	public BagRecycleGridObjWraper GetBagRecycleBin(int Index)
	{
		if(Index<0 || Index>=(int)m_BagRecycleBin.Count)
			return new BagRecycleGridObjWraper();
		return m_BagRecycleBin[Index];
	}
	public void SetBagRecycleBin( List<BagRecycleGridObjWraper> v )
	{
		m_BagRecycleBin=v;
	}
	public void SetBagRecycleBin( int Index, BagRecycleGridObjWraper v )
	{
		if(Index<0 || Index>=(int)m_BagRecycleBin.Count)
			return;
		m_BagRecycleBin[Index] = v;
	}
	public void AddBagRecycleBin( BagRecycleGridObjWraper v )
	{
		m_BagRecycleBin.Add(v);
	}
	public void ClearBagRecycleBin( )
	{
		m_BagRecycleBin.Clear();
	}
	//角色属性
	public List<OnlineDataRoleAttrObjWraperV1> m_RoleAttr;
	public int SizeRoleAttr()
	{
		return m_RoleAttr.Count;
	}
	public List<OnlineDataRoleAttrObjWraperV1> GetRoleAttr()
	{
		return m_RoleAttr;
	}
	public OnlineDataRoleAttrObjWraperV1 GetRoleAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_RoleAttr.Count)
			return new OnlineDataRoleAttrObjWraperV1();
		return m_RoleAttr[Index];
	}
	public void SetRoleAttr( List<OnlineDataRoleAttrObjWraperV1> v )
	{
		m_RoleAttr=v;
	}
	public void SetRoleAttr( int Index, OnlineDataRoleAttrObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_RoleAttr.Count)
			return;
		m_RoleAttr[Index] = v;
	}
	public void AddRoleAttr( OnlineDataRoleAttrObjWraperV1 v )
	{
		m_RoleAttr.Add(v);
	}
	public void ClearRoleAttr( )
	{
		m_RoleAttr.Clear();
	}
	//推荐好友偏移
	public int m_RecommendFriendOffset;
	public int RecommendFriendOffset
	{
		get { return m_RecommendFriendOffset;}
		set { m_RecommendFriendOffset = value; }
	}
	//推荐好友刷新时间
	public int m_RecommendFriendFlushTime;
	public int RecommendFriendFlushTime
	{
		get { return m_RecommendFriendFlushTime;}
		set { m_RecommendFriendFlushTime = value; }
	}
	//上次推荐的好友
	public List<long> m_RecommendFriendLastList;
	public int SizeRecommendFriendLastList()
	{
		return m_RecommendFriendLastList.Count;
	}
	public List<long> GetRecommendFriendLastList()
	{
		return m_RecommendFriendLastList;
	}
	public long GetRecommendFriendLastList(int Index)
	{
		if(Index<0 || Index>=(int)m_RecommendFriendLastList.Count)
			return -1;
		return m_RecommendFriendLastList[Index];
	}
	public void SetRecommendFriendLastList( List<long> v )
	{
		m_RecommendFriendLastList=v;
	}
	public void SetRecommendFriendLastList( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_RecommendFriendLastList.Count)
			return;
		m_RecommendFriendLastList[Index] = v;
	}
	public void AddRecommendFriendLastList( long v=-1 )
	{
		m_RecommendFriendLastList.Add(v);
	}
	public void ClearRecommendFriendLastList( )
	{
		m_RecommendFriendLastList.Clear();
	}
	//跟随我的人
	public List<long> m_FollowmeUserId;
	public int SizeFollowmeUserId()
	{
		return m_FollowmeUserId.Count;
	}
	public List<long> GetFollowmeUserId()
	{
		return m_FollowmeUserId;
	}
	public long GetFollowmeUserId(int Index)
	{
		if(Index<0 || Index>=(int)m_FollowmeUserId.Count)
			return -1;
		return m_FollowmeUserId[Index];
	}
	public void SetFollowmeUserId( List<long> v )
	{
		m_FollowmeUserId=v;
	}
	public void SetFollowmeUserId( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_FollowmeUserId.Count)
			return;
		m_FollowmeUserId[Index] = v;
	}
	public void AddFollowmeUserId( long v=-1 )
	{
		m_FollowmeUserId.Add(v);
	}
	public void ClearFollowmeUserId( )
	{
		m_FollowmeUserId.Clear();
	}
	//跟随谁
	public long m_FollowWho;
	public long FollowWho
	{
		get { return m_FollowWho;}
		set { m_FollowWho = value; }
	}
	//江洋大盗
	public long m_ThiefObjId;
	public long ThiefObjId
	{
		get { return m_ThiefObjId;}
		set { m_ThiefObjId = value; }
	}



}
