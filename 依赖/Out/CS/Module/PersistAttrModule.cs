/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModulePersistAttr.cs
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


public class PersistAttrRPC
{
	public const int ModuleId = 10;
	
	public const int RPC_CODE_PERSISTATTR_SYNCDATA_REQUEST = 1051;

	
	private static PersistAttrRPC m_Instance = null;
	public static PersistAttrRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new PersistAttrRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, PersistAttrData.Instance.UpdateField );
		


		return true;
	}


	/**
	*常驻内存属性模块-->同步背包数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		PersistAttrRpcSyncDataAskWraper askPBWraper = new PersistAttrRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_PERSISTATTR_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			PersistAttrRpcSyncDataReplyWraper replyPBWraper = new PersistAttrRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}





}

public class PersistAttrData
{
	public enum SyncIdE
	{
 		USERNAME                                   = 1001,  //战队名字
 		USERID                                     = 1003,  //用户ID
 		PLATNAME                                   = 1004,  //游戏中心账号名
 		ACCOUNTID                                  = 1021,  //游戏中心账号ID
 		LEVEL                                      = 1030,  //战队等级
 		RANK                                       = 1031,  //官阶
 		FIGHTPOWER                                 = 1032,  //战力
 		SEC                                        = 1033,  //登录时间秒
 		PROF                                       = 1035,  //职业
 		ONLINESTATE                                = 1036,  //在线状态
 		TEAMID                                     = 1037,  //组队id
 		SHOPSCORE                                  = 1039,  //几分商城
 		DUNGEONID                                  = 1042,  //当前场景Id
 		SESSIONKEY                                 = 1043,  //SessionKey
 		GUILDID                                    = 1044,  //帮会Id

	}
	
	private static PersistAttrData m_Instance = null;
	public static PersistAttrData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new PersistAttrData();
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
			case SyncIdE.USERNAME:
				m_Instance.UserName = System.Text.Encoding.UTF8.GetString(updateBuffer);
				break;
			case SyncIdE.USERID:
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.UserId = lValue;
				break;
			case SyncIdE.PLATNAME:
				m_Instance.PlatName = System.Text.Encoding.UTF8.GetString(updateBuffer);
				break;
			case SyncIdE.ACCOUNTID:
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.AccountId = lValue;
				break;
			case SyncIdE.LEVEL:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Level = iValue;
				break;
			case SyncIdE.RANK:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Rank = iValue;
				break;
			case SyncIdE.FIGHTPOWER:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.FightPower = iValue;
				break;
			case SyncIdE.SEC:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Sec = iValue;
				break;
			case SyncIdE.PROF:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Prof = iValue;
				break;
			case SyncIdE.ONLINESTATE:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.OnlineState = iValue;
				break;
			case SyncIdE.TEAMID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.TeamId = iValue;
				break;
			case SyncIdE.SHOPSCORE:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ShopScore = iValue;
				break;
			case SyncIdE.DUNGEONID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.DungeonId = iValue;
				break;
			case SyncIdE.SESSIONKEY:
				m_Instance.SessionKey = System.Text.Encoding.UTF8.GetString(updateBuffer);
				break;
			case SyncIdE.GUILDID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.GuildId = iValue;
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
			Ex.Logger.Log("PersistAttrData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public PersistAttrData()
	{
		 m_UserName = "";
		 m_UserId = -1;
		 m_PlatName = "";
		 m_AccountId = -1;
		 m_Level = -1;
		 m_Rank = -1;
		 m_FightPower = -1;
		 m_Sec = -1;
		 m_Prof = -1;
		 m_OnlineState = -1;
		 m_TeamId = -1;
		 m_ShopScore = -1;
		 m_DungeonId = -1;
		 m_SessionKey = "";
		 m_GuildId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserName = "";
		 m_UserId = -1;
		 m_PlatName = "";
		 m_AccountId = -1;
		 m_Level = -1;
		 m_Rank = -1;
		 m_FightPower = -1;
		 m_Sec = -1;
		 m_Prof = -1;
		 m_OnlineState = -1;
		 m_TeamId = -1;
		 m_ShopScore = -1;
		 m_DungeonId = -1;
		 m_SessionKey = "";
		 m_GuildId = -1;

	}

 	//转化成Protobuffer类型函数
	public PersistAttrPersistAttrV1 ToPB()
	{
		PersistAttrPersistAttrV1 v = new PersistAttrPersistAttrV1();
		v.UserName = m_UserName;
		v.UserId = m_UserId;
		v.PlatName = m_PlatName;
		v.AccountId = m_AccountId;
		v.Level = m_Level;
		v.Rank = m_Rank;
		v.FightPower = m_FightPower;
		v.Sec = m_Sec;
		v.Prof = m_Prof;
		v.OnlineState = m_OnlineState;
		v.TeamId = m_TeamId;
		v.ShopScore = m_ShopScore;
		v.DungeonId = m_DungeonId;
		v.SessionKey = m_SessionKey;
		v.GuildId = m_GuildId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(PersistAttrPersistAttrV1 v)
	{
        if (v == null)
            return;
		m_UserName = v.UserName;
		m_UserId = v.UserId;
		m_PlatName = v.PlatName;
		m_AccountId = v.AccountId;
		m_Level = v.Level;
		m_Rank = v.Rank;
		m_FightPower = v.FightPower;
		m_Sec = v.Sec;
		m_Prof = v.Prof;
		m_OnlineState = v.OnlineState;
		m_TeamId = v.TeamId;
		m_ShopScore = v.ShopScore;
		m_DungeonId = v.DungeonId;
		m_SessionKey = v.SessionKey;
		m_GuildId = v.GuildId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<PersistAttrPersistAttrV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		PersistAttrPersistAttrV1 pb = ProtoBuf.Serializer.Deserialize<PersistAttrPersistAttrV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//战队名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//游戏中心账号名
	public string m_PlatName;
	public string PlatName
	{
		get { return m_PlatName;}
		set { m_PlatName = value; }
	}
	//游戏中心账号ID
	public long m_AccountId;
	public long AccountId
	{
		get { return m_AccountId;}
		set { m_AccountId = value; }
	}
	//战队等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//官阶
	public int m_Rank;
	public int Rank
	{
		get { return m_Rank;}
		set { m_Rank = value; }
	}
	//战力
	public int m_FightPower;
	public int FightPower
	{
		get { return m_FightPower;}
		set { m_FightPower = value; }
	}
	//登录时间秒
	public int m_Sec;
	public int Sec
	{
		get { return m_Sec;}
		set { m_Sec = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}
	//在线状态
	public int m_OnlineState;
	public int OnlineState
	{
		get { return m_OnlineState;}
		set { m_OnlineState = value; }
	}
	//组队id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//几分商城
	public int m_ShopScore;
	public int ShopScore
	{
		get { return m_ShopScore;}
		set { m_ShopScore = value; }
	}
	//当前场景Id
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//SessionKey
	public string m_SessionKey;
	public string SessionKey
	{
		get { return m_SessionKey;}
		set { m_SessionKey = value; }
	}
	//帮会Id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}



}
