
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBFriend.cs
Author:
Description:
Version:      1.0
History:
  <author>  <time>   <version >   <desc>

***********************************************************/
using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//好友对象封装类
[System.Serializable]
public class FriendFriendObjWraperV1
{

	//构造函数
	public FriendFriendObjWraperV1()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_Signature = "";
		 m_TeamId = -1;
		 m_TeamMemberNum = 0;
		 m_Online = false;
		 m_GoodFeeling = 0;
		 m_GuildId = -1;
		 m_GuildName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_Signature = "";
		 m_TeamId = -1;
		 m_TeamMemberNum = 0;
		 m_Online = false;
		 m_GoodFeeling = 0;
		 m_GuildId = -1;
		 m_GuildName = "";

	}

 	//转化成Protobuffer类型函数
	public FriendFriendObjV1 ToPB()
	{
		FriendFriendObjV1 v = new FriendFriendObjV1();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;
		v.Signature = m_Signature;
		v.TeamId = m_TeamId;
		v.TeamMemberNum = m_TeamMemberNum;
		v.Online = m_Online;
		v.GoodFeeling = m_GoodFeeling;
		v.GuildId = m_GuildId;
		v.GuildName = m_GuildName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendFriendObjV1 v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;
		m_Signature = v.Signature;
		m_TeamId = v.TeamId;
		m_TeamMemberNum = v.TeamMemberNum;
		m_Online = v.Online;
		m_GoodFeeling = v.GoodFeeling;
		m_GuildId = v.GuildId;
		m_GuildName = v.GuildName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendFriendObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendFriendObjV1 pb = ProtoBuf.Serializer.Deserialize<FriendFriendObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}
	//签名
	public string m_Signature;
	public string Signature
	{
		get { return m_Signature;}
		set { m_Signature = value; }
	}
	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//队伍当前人数
	public int m_TeamMemberNum;
	public int TeamMemberNum
	{
		get { return m_TeamMemberNum;}
		set { m_TeamMemberNum = value; }
	}
	//是否在线
	public bool m_Online;
	public bool Online
	{
		get { return m_Online;}
		set { m_Online = value; }
	}
	//好感度
	public int m_GoodFeeling;
	public int GoodFeeling
	{
		get { return m_GoodFeeling;}
		set { m_GoodFeeling = value; }
	}
	//帮会id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}
	//帮会名字
	public string m_GuildName;
	public string GuildName
	{
		get { return m_GuildName;}
		set { m_GuildName = value; }
	}


};
