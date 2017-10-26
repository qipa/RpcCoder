
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBAchievement.cs
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


//领取奖励请求封装类
[System.Serializable]
public class AchievementRpcGetTheRewardsAskWraper
{

	//构造函数
	public AchievementRpcGetTheRewardsAskWraper()
	{
		 m_GroupId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GroupId = -1;

	}

 	//转化成Protobuffer类型函数
	public AchievementRpcGetTheRewardsAsk ToPB()
	{
		AchievementRpcGetTheRewardsAsk v = new AchievementRpcGetTheRewardsAsk();
		v.GroupId = m_GroupId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(AchievementRpcGetTheRewardsAsk v)
	{
        if (v == null)
            return;
		m_GroupId = v.GroupId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<AchievementRpcGetTheRewardsAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		AchievementRpcGetTheRewardsAsk pb = ProtoBuf.Serializer.Deserialize<AchievementRpcGetTheRewardsAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//组id，使用解锁条件
	public int m_GroupId;
	public int GroupId
	{
		get { return m_GroupId;}
		set { m_GroupId = value; }
	}


};
//领取奖励回应封装类
[System.Serializable]
public class AchievementRpcGetTheRewardsReplyWraper
{

	//构造函数
	public AchievementRpcGetTheRewardsReplyWraper()
	{
		 m_Result = -9999;
		 m_GroupId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_GroupId = -1;

	}

 	//转化成Protobuffer类型函数
	public AchievementRpcGetTheRewardsReply ToPB()
	{
		AchievementRpcGetTheRewardsReply v = new AchievementRpcGetTheRewardsReply();
		v.Result = m_Result;
		v.GroupId = m_GroupId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(AchievementRpcGetTheRewardsReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GroupId = v.GroupId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<AchievementRpcGetTheRewardsReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		AchievementRpcGetTheRewardsReply pb = ProtoBuf.Serializer.Deserialize<AchievementRpcGetTheRewardsReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}
	//组id，使用解锁条件
	public int m_GroupId;
	public int GroupId
	{
		get { return m_GroupId;}
		set { m_GroupId = value; }
	}


};
//同步数据请求封装类
[System.Serializable]
public class AchievementRpcSyncDataAskWraper
{

	//构造函数
	public AchievementRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public AchievementRpcSyncDataAsk ToPB()
	{
		AchievementRpcSyncDataAsk v = new AchievementRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(AchievementRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<AchievementRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		AchievementRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<AchievementRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//同步数据回应封装类
[System.Serializable]
public class AchievementRpcSyncDataReplyWraper
{

	//构造函数
	public AchievementRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public AchievementRpcSyncDataReply ToPB()
	{
		AchievementRpcSyncDataReply v = new AchievementRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(AchievementRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<AchievementRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		AchievementRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<AchievementRpcSyncDataReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
