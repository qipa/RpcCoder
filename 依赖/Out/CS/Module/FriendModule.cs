/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleFriend.cs
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


public class FriendRPC
{
	public const int ModuleId = 33;
	
	public const int RPC_CODE_FRIEND_SYNCFRIENDDATA_REQUEST = 3351;
	public const int RPC_CODE_FRIEND_ADDFRIEND_REQUEST = 3352;
	public const int RPC_CODE_FRIEND_DELFRIEND_REQUEST = 3353;
	public const int RPC_CODE_FRIEND_ADDBLACKLIST_REQUEST = 3354;
	public const int RPC_CODE_FRIEND_DELBLACKLIST_REQUEST = 3355;
	public const int RPC_CODE_FRIEND_ADDCONTACT_REQUEST = 3356;
	public const int RPC_CODE_FRIEND_DELCONTACT_REQUEST = 3357;
	public const int RPC_CODE_FRIEND_SEARCHPLAYER_REQUEST = 3358;
	public const int RPC_CODE_FRIEND_RECOMMEND_REQUEST = 3359;
	public const int RPC_CODE_FRIEND_VIEWUSERSIMPLEINFO_REQUEST = 3360;
	public const int RPC_CODE_FRIEND_FRIENDONLINEOFFLINE_NOTIFY = 3361;

	
	private static FriendRPC m_Instance = null;
	public static FriendRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new FriendRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, FriendData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_FRIEND_FRIENDONLINEOFFLINE_NOTIFY, FriendOnlineOfflineCB);


		return true;
	}


	/**
	*好友-->每次打开界面，请求一次数据 RPC请求
	*/
	public void SyncFriendData(ReplyHandler replyCB)
	{
		FriendRpcSyncFriendDataAskWraper askPBWraper = new FriendRpcSyncFriendDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_SYNCFRIENDDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcSyncFriendDataReplyWraper replyPBWraper = new FriendRpcSyncFriendDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->增加好友 RPC请求
	*/
	public void AddFriend(long UserId, ReplyHandler replyCB)
	{
		FriendRpcAddFriendAskWraper askPBWraper = new FriendRpcAddFriendAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_ADDFRIEND_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcAddFriendReplyWraper replyPBWraper = new FriendRpcAddFriendReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->删除好友 RPC请求
	*/
	public void DelFriend(List<long> UserId, ReplyHandler replyCB)
	{
		FriendRpcDelFriendAskWraper askPBWraper = new FriendRpcDelFriendAskWraper();
		askPBWraper.SetUserId(UserId);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_DELFRIEND_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcDelFriendReplyWraper replyPBWraper = new FriendRpcDelFriendReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->增加黑名单 RPC请求
	*/
	public void AddBlackList(long UserId, ReplyHandler replyCB)
	{
		FriendRpcAddBlackListAskWraper askPBWraper = new FriendRpcAddBlackListAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_ADDBLACKLIST_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcAddBlackListReplyWraper replyPBWraper = new FriendRpcAddBlackListReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->删除黑名单 RPC请求
	*/
	public void DelBlackList(long UserId, ReplyHandler replyCB)
	{
		FriendRpcDelBlackListAskWraper askPBWraper = new FriendRpcDelBlackListAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_DELBLACKLIST_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcDelBlackListReplyWraper replyPBWraper = new FriendRpcDelBlackListReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->增加最近联系人 RPC请求
	*/
	public void AddContact(long UserId, ReplyHandler replyCB)
	{
		FriendRpcAddContactAskWraper askPBWraper = new FriendRpcAddContactAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_ADDCONTACT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcAddContactReplyWraper replyPBWraper = new FriendRpcAddContactReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->删除最近联系人 RPC请求
	*/
	public void DelContact(long UserId, ReplyHandler replyCB)
	{
		FriendRpcDelContactAskWraper askPBWraper = new FriendRpcDelContactAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_DELCONTACT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcDelContactReplyWraper replyPBWraper = new FriendRpcDelContactReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->搜索好友 RPC请求
	*/
	public void SearchPlayer(string SearchString, ReplyHandler replyCB)
	{
		FriendRpcSearchPlayerAskWraper askPBWraper = new FriendRpcSearchPlayerAskWraper();
		askPBWraper.SearchString = SearchString;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_SEARCHPLAYER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcSearchPlayerReplyWraper replyPBWraper = new FriendRpcSearchPlayerReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->推荐玩家 RPC请求
	*/
	public void Recommend(ReplyHandler replyCB)
	{
		FriendRpcRecommendAskWraper askPBWraper = new FriendRpcRecommendAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_RECOMMEND_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcRecommendReplyWraper replyPBWraper = new FriendRpcRecommendReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*好友-->查看资料简单数据 RPC请求
	*/
	public void ViewUserSimpleInfo(long UserId, ReplyHandler replyCB)
	{
		FriendRpcViewUserSimpleInfoAskWraper askPBWraper = new FriendRpcViewUserSimpleInfoAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_FRIEND_VIEWUSERSIMPLEINFO_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			FriendRpcViewUserSimpleInfoReplyWraper replyPBWraper = new FriendRpcViewUserSimpleInfoReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*好友-->好友上下线 服务器通知回调
	*/
	public static void FriendOnlineOfflineCB( ModMessage notifyMsg )
	{
		FriendRpcOnlineOfflineNotifyWraper notifyPBWraper = new FriendRpcOnlineOfflineNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( FriendOnlineOfflineCBDelegate != null )
			FriendOnlineOfflineCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback FriendOnlineOfflineCBDelegate = null;



}

public class FriendData
{
	public enum SyncIdE
	{
 		FRIENDLIST                                 = 3301,  //好友列表
 		BLACKLIST                                  = 3302,  //黑名单
 		CONTACTSLIST                               = 3303,  //最近联系人
 		STRANGERFRIENDLIST                         = 3304,  //加过我的人

	}
	
	private static FriendData m_Instance = null;
	public static FriendData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new FriendData();
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
			case SyncIdE.FRIENDLIST:
				if(Index < 0){ m_Instance.ClearFriendList(); break; }
				if (Index >= m_Instance.SizeFriendList())
				{
					int Count = Index - m_Instance.SizeFriendList() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddFriendList(new FriendFriendObjWraperV1());
				}
				m_Instance.GetFriendList(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.BLACKLIST:
				if(Index < 0){ m_Instance.ClearBlackList(); break; }
				if (Index >= m_Instance.SizeBlackList())
				{
					int Count = Index - m_Instance.SizeBlackList() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddBlackList(new FriendFriendObjWraperV1());
				}
				m_Instance.GetBlackList(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.CONTACTSLIST:
				if(Index < 0){ m_Instance.ClearContactsList(); break; }
				if (Index >= m_Instance.SizeContactsList())
				{
					int Count = Index - m_Instance.SizeContactsList() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddContactsList(new FriendFriendObjWraperV1());
				}
				m_Instance.GetContactsList(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.STRANGERFRIENDLIST:
				if(Index < 0){ m_Instance.ClearStrangerFriendList(); break; }
				if (Index >= m_Instance.SizeStrangerFriendList())
				{
					int Count = Index - m_Instance.SizeStrangerFriendList() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddStrangerFriendList(-1);
				}
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.SetStrangerFriendList(Index, lValue);
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
			Ex.Logger.Log("FriendData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public FriendData()
	{
		m_FriendList = new List<FriendFriendObjWraperV1>();
		m_BlackList = new List<FriendFriendObjWraperV1>();
		m_ContactsList = new List<FriendFriendObjWraperV1>();
		m_StrangerFriendList = new List<long>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_FriendList = new List<FriendFriendObjWraperV1>();
		m_BlackList = new List<FriendFriendObjWraperV1>();
		m_ContactsList = new List<FriendFriendObjWraperV1>();
		m_StrangerFriendList = new List<long>();

	}

 	//转化成Protobuffer类型函数
	public FriendFriendDataV1 ToPB()
	{
		FriendFriendDataV1 v = new FriendFriendDataV1();
		for (int i=0; i<(int)m_FriendList.Count; i++)
			v.FriendList.Add( m_FriendList[i].ToPB());
		for (int i=0; i<(int)m_BlackList.Count; i++)
			v.BlackList.Add( m_BlackList[i].ToPB());
		for (int i=0; i<(int)m_ContactsList.Count; i++)
			v.ContactsList.Add( m_ContactsList[i].ToPB());
		for (int i=0; i<(int)m_StrangerFriendList.Count; i++)
			v.StrangerFriendList.Add( m_StrangerFriendList[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendFriendDataV1 v)
	{
        if (v == null)
            return;
		m_FriendList.Clear();
		for( int i=0; i<v.FriendList.Count; i++)
			m_FriendList.Add( new FriendFriendObjWraperV1());
		for( int i=0; i<v.FriendList.Count; i++)
			m_FriendList[i].FromPB(v.FriendList[i]);
		m_BlackList.Clear();
		for( int i=0; i<v.BlackList.Count; i++)
			m_BlackList.Add( new FriendFriendObjWraperV1());
		for( int i=0; i<v.BlackList.Count; i++)
			m_BlackList[i].FromPB(v.BlackList[i]);
		m_ContactsList.Clear();
		for( int i=0; i<v.ContactsList.Count; i++)
			m_ContactsList.Add( new FriendFriendObjWraperV1());
		for( int i=0; i<v.ContactsList.Count; i++)
			m_ContactsList[i].FromPB(v.ContactsList[i]);
		m_StrangerFriendList.Clear();
		for( int i=0; i<v.StrangerFriendList.Count; i++)
			m_StrangerFriendList.Add(v.StrangerFriendList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendFriendDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendFriendDataV1 pb = ProtoBuf.Serializer.Deserialize<FriendFriendDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//好友列表
	public List<FriendFriendObjWraperV1> m_FriendList;
	public int SizeFriendList()
	{
		return m_FriendList.Count;
	}
	public List<FriendFriendObjWraperV1> GetFriendList()
	{
		return m_FriendList;
	}
	public FriendFriendObjWraperV1 GetFriendList(int Index)
	{
		if(Index<0 || Index>=(int)m_FriendList.Count)
			return new FriendFriendObjWraperV1();
		return m_FriendList[Index];
	}
	public void SetFriendList( List<FriendFriendObjWraperV1> v )
	{
		m_FriendList=v;
	}
	public void SetFriendList( int Index, FriendFriendObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_FriendList.Count)
			return;
		m_FriendList[Index] = v;
	}
	public void AddFriendList( FriendFriendObjWraperV1 v )
	{
		m_FriendList.Add(v);
	}
	public void ClearFriendList( )
	{
		m_FriendList.Clear();
	}
	//黑名单
	public List<FriendFriendObjWraperV1> m_BlackList;
	public int SizeBlackList()
	{
		return m_BlackList.Count;
	}
	public List<FriendFriendObjWraperV1> GetBlackList()
	{
		return m_BlackList;
	}
	public FriendFriendObjWraperV1 GetBlackList(int Index)
	{
		if(Index<0 || Index>=(int)m_BlackList.Count)
			return new FriendFriendObjWraperV1();
		return m_BlackList[Index];
	}
	public void SetBlackList( List<FriendFriendObjWraperV1> v )
	{
		m_BlackList=v;
	}
	public void SetBlackList( int Index, FriendFriendObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_BlackList.Count)
			return;
		m_BlackList[Index] = v;
	}
	public void AddBlackList( FriendFriendObjWraperV1 v )
	{
		m_BlackList.Add(v);
	}
	public void ClearBlackList( )
	{
		m_BlackList.Clear();
	}
	//最近联系人
	public List<FriendFriendObjWraperV1> m_ContactsList;
	public int SizeContactsList()
	{
		return m_ContactsList.Count;
	}
	public List<FriendFriendObjWraperV1> GetContactsList()
	{
		return m_ContactsList;
	}
	public FriendFriendObjWraperV1 GetContactsList(int Index)
	{
		if(Index<0 || Index>=(int)m_ContactsList.Count)
			return new FriendFriendObjWraperV1();
		return m_ContactsList[Index];
	}
	public void SetContactsList( List<FriendFriendObjWraperV1> v )
	{
		m_ContactsList=v;
	}
	public void SetContactsList( int Index, FriendFriendObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_ContactsList.Count)
			return;
		m_ContactsList[Index] = v;
	}
	public void AddContactsList( FriendFriendObjWraperV1 v )
	{
		m_ContactsList.Add(v);
	}
	public void ClearContactsList( )
	{
		m_ContactsList.Clear();
	}
	//加过我的人
	public List<long> m_StrangerFriendList;
	public int SizeStrangerFriendList()
	{
		return m_StrangerFriendList.Count;
	}
	public List<long> GetStrangerFriendList()
	{
		return m_StrangerFriendList;
	}
	public long GetStrangerFriendList(int Index)
	{
		if(Index<0 || Index>=(int)m_StrangerFriendList.Count)
			return -1;
		return m_StrangerFriendList[Index];
	}
	public void SetStrangerFriendList( List<long> v )
	{
		m_StrangerFriendList=v;
	}
	public void SetStrangerFriendList( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_StrangerFriendList.Count)
			return;
		m_StrangerFriendList[Index] = v;
	}
	public void AddStrangerFriendList( long v=-1 )
	{
		m_StrangerFriendList.Add(v);
	}
	public void ClearStrangerFriendList( )
	{
		m_StrangerFriendList.Clear();
	}



}
