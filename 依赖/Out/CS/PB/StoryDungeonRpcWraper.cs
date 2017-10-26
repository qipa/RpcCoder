
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBStoryDungeon.cs
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


//SyncData请求封装类
[System.Serializable]
public class StoryDungeonRpcSyncDataAskWraper
{

	//构造函数
	public StoryDungeonRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcSyncDataAsk ToPB()
	{
		StoryDungeonRpcSyncDataAsk v = new StoryDungeonRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//SyncData回应封装类
[System.Serializable]
public class StoryDungeonRpcSyncDataReplyWraper
{

	//构造函数
	public StoryDungeonRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcSyncDataReply ToPB()
	{
		StoryDungeonRpcSyncDataReply v = new StoryDungeonRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcSyncDataReply>(protoMS);
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
//挑战副本请求封装类
[System.Serializable]
public class StoryDungeonRpcChallengeAskWraper
{

	//构造函数
	public StoryDungeonRpcChallengeAskWraper()
	{
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcChallengeAsk ToPB()
	{
		StoryDungeonRpcChallengeAsk v = new StoryDungeonRpcChallengeAsk();
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcChallengeAsk v)
	{
        if (v == null)
            return;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcChallengeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcChallengeAsk pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcChallengeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//挑战副本回应封装类
[System.Serializable]
public class StoryDungeonRpcChallengeReplyWraper
{

	//构造函数
	public StoryDungeonRpcChallengeReplyWraper()
	{
		 m_Result = -9999;
		 m_ErrorUserName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ErrorUserName = "";

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcChallengeReply ToPB()
	{
		StoryDungeonRpcChallengeReply v = new StoryDungeonRpcChallengeReply();
		v.Result = m_Result;
		v.ErrorUserName = m_ErrorUserName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcChallengeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ErrorUserName = v.ErrorUserName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcChallengeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcChallengeReply pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcChallengeReply>(protoMS);
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
	//玩家名字
	public string m_ErrorUserName;
	public string ErrorUserName
	{
		get { return m_ErrorUserName;}
		set { m_ErrorUserName = value; }
	}


};
//等待玩家确认是否选择进入通知封装类
[System.Serializable]
public class StoryDungeonRpcWaitForConfirmationNotifyWraper
{

	//构造函数
	public StoryDungeonRpcWaitForConfirmationNotifyWraper()
	{
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcWaitForConfirmationNotify ToPB()
	{
		StoryDungeonRpcWaitForConfirmationNotify v = new StoryDungeonRpcWaitForConfirmationNotify();
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcWaitForConfirmationNotify v)
	{
        if (v == null)
            return;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcWaitForConfirmationNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcWaitForConfirmationNotify pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcWaitForConfirmationNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//确认是否进入请求封装类
[System.Serializable]
public class StoryDungeonRpcConfirmEnterAskWraper
{

	//构造函数
	public StoryDungeonRpcConfirmEnterAskWraper()
	{
		 m_IsAgree = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_IsAgree = false;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcConfirmEnterAsk ToPB()
	{
		StoryDungeonRpcConfirmEnterAsk v = new StoryDungeonRpcConfirmEnterAsk();
		v.IsAgree = m_IsAgree;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcConfirmEnterAsk v)
	{
        if (v == null)
            return;
		m_IsAgree = v.IsAgree;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcConfirmEnterAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcConfirmEnterAsk pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcConfirmEnterAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//同意进入
	public bool m_IsAgree;
	public bool IsAgree
	{
		get { return m_IsAgree;}
		set { m_IsAgree = value; }
	}


};
//确认是否进入回应封装类
[System.Serializable]
public class StoryDungeonRpcConfirmEnterReplyWraper
{

	//构造函数
	public StoryDungeonRpcConfirmEnterReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcConfirmEnterReply ToPB()
	{
		StoryDungeonRpcConfirmEnterReply v = new StoryDungeonRpcConfirmEnterReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcConfirmEnterReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcConfirmEnterReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcConfirmEnterReply pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcConfirmEnterReply>(protoMS);
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
//玩家确认或拒绝进入通知封装类
[System.Serializable]
public class StoryDungeonRpcPlayerConfirmResultNotifyWraper
{

	//构造函数
	public StoryDungeonRpcPlayerConfirmResultNotifyWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_IsAgree = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_IsAgree = false;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonRpcPlayerConfirmResultNotify ToPB()
	{
		StoryDungeonRpcPlayerConfirmResultNotify v = new StoryDungeonRpcPlayerConfirmResultNotify();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.IsAgree = m_IsAgree;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonRpcPlayerConfirmResultNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_IsAgree = v.IsAgree;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonRpcPlayerConfirmResultNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonRpcPlayerConfirmResultNotify pb = ProtoBuf.Serializer.Deserialize<StoryDungeonRpcPlayerConfirmResultNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//玩家名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//同意进入
	public bool m_IsAgree;
	public bool IsAgree
	{
		get { return m_IsAgree;}
		set { m_IsAgree = value; }
	}


};
