
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBActivityStorm.cs
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


//报名请求封装类
[System.Serializable]
public class ActivityStormRpcSignUpAskWraper
{

	//构造函数
	public ActivityStormRpcSignUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcSignUpAsk ToPB()
	{
		ActivityStormRpcSignUpAsk v = new ActivityStormRpcSignUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcSignUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcSignUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcSignUpAsk pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcSignUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//报名回应封装类
[System.Serializable]
public class ActivityStormRpcSignUpReplyWraper
{

	//构造函数
	public ActivityStormRpcSignUpReplyWraper()
	{
		 m_Result = -9999;
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcSignUpReply ToPB()
	{
		ActivityStormRpcSignUpReply v = new ActivityStormRpcSignUpReply();
		v.Result = m_Result;
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcSignUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcSignUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcSignUpReply pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcSignUpReply>(protoMS);
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
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//取消报名请求封装类
[System.Serializable]
public class ActivityStormRpcCancelSignUpAskWraper
{

	//构造函数
	public ActivityStormRpcCancelSignUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcCancelSignUpAsk ToPB()
	{
		ActivityStormRpcCancelSignUpAsk v = new ActivityStormRpcCancelSignUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcCancelSignUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcCancelSignUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcCancelSignUpAsk pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcCancelSignUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//取消报名回应封装类
[System.Serializable]
public class ActivityStormRpcCancelSignUpReplyWraper
{

	//构造函数
	public ActivityStormRpcCancelSignUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcCancelSignUpReply ToPB()
	{
		ActivityStormRpcCancelSignUpReply v = new ActivityStormRpcCancelSignUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcCancelSignUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcCancelSignUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcCancelSignUpReply pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcCancelSignUpReply>(protoMS);
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
//进入战场请求封装类
[System.Serializable]
public class ActivityStormRpcInsertBattlefieldAskWraper
{

	//构造函数
	public ActivityStormRpcInsertBattlefieldAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcInsertBattlefieldAsk ToPB()
	{
		ActivityStormRpcInsertBattlefieldAsk v = new ActivityStormRpcInsertBattlefieldAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcInsertBattlefieldAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcInsertBattlefieldAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcInsertBattlefieldAsk pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcInsertBattlefieldAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//进入战场回应封装类
[System.Serializable]
public class ActivityStormRpcInsertBattlefieldReplyWraper
{

	//构造函数
	public ActivityStormRpcInsertBattlefieldReplyWraper()
	{
		 m_Result = -9999;
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcInsertBattlefieldReply ToPB()
	{
		ActivityStormRpcInsertBattlefieldReply v = new ActivityStormRpcInsertBattlefieldReply();
		v.Result = m_Result;
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcInsertBattlefieldReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcInsertBattlefieldReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcInsertBattlefieldReply pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcInsertBattlefieldReply>(protoMS);
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
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//战场信息通知封装类
[System.Serializable]
public class ActivityStormRpcBattlefieldMessageNotifyWraper
{

	//构造函数
	public ActivityStormRpcBattlefieldMessageNotifyWraper()
	{
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcBattlefieldMessageNotify ToPB()
	{
		ActivityStormRpcBattlefieldMessageNotify v = new ActivityStormRpcBattlefieldMessageNotify();
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcBattlefieldMessageNotify v)
	{
        if (v == null)
            return;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcBattlefieldMessageNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcBattlefieldMessageNotify pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcBattlefieldMessageNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//倒计时时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//超时消息主推通知封装类
[System.Serializable]
public class ActivityStormRpcTimeOutMessageNotifyWraper
{

	//构造函数
	public ActivityStormRpcTimeOutMessageNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcTimeOutMessageNotify ToPB()
	{
		ActivityStormRpcTimeOutMessageNotify v = new ActivityStormRpcTimeOutMessageNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcTimeOutMessageNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcTimeOutMessageNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcTimeOutMessageNotify pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcTimeOutMessageNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
//同步数据请求封装类
[System.Serializable]
public class ActivityStormRpcSyncDataAskWraper
{

	//构造函数
	public ActivityStormRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcSyncDataAsk ToPB()
	{
		ActivityStormRpcSyncDataAsk v = new ActivityStormRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//同步数据回应封装类
[System.Serializable]
public class ActivityStormRpcSyncDataReplyWraper
{

	//构造函数
	public ActivityStormRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcSyncDataReply ToPB()
	{
		ActivityStormRpcSyncDataReply v = new ActivityStormRpcSyncDataReply();
		v.Result = m_Result;
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcSyncDataReply>(protoMS);
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
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//加入离开notify通知封装类
[System.Serializable]
public class ActivityStormRpcJoinLevevNotifyNotifyWraper
{

	//构造函数
	public ActivityStormRpcJoinLevevNotifyNotifyWraper()
	{
		 m_UserID = -1;
		 m_NickName = "";
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserID = -1;
		 m_NickName = "";
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcJoinLevevNotifyNotify ToPB()
	{
		ActivityStormRpcJoinLevevNotifyNotify v = new ActivityStormRpcJoinLevevNotifyNotify();
		v.UserID = m_UserID;
		v.NickName = m_NickName;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcJoinLevevNotifyNotify v)
	{
        if (v == null)
            return;
		m_UserID = v.UserID;
		m_NickName = v.NickName;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcJoinLevevNotifyNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcJoinLevevNotifyNotify pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcJoinLevevNotifyNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//USERID
	public long m_UserID;
	public long UserID
	{
		get { return m_UserID;}
		set { m_UserID = value; }
	}
	//昵称
	public string m_NickName;
	public string NickName
	{
		get { return m_NickName;}
		set { m_NickName = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//取消进入战场请求封装类
[System.Serializable]
public class ActivityStormRpcCanceInsertBattleAskWraper
{

	//构造函数
	public ActivityStormRpcCanceInsertBattleAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcCanceInsertBattleAsk ToPB()
	{
		ActivityStormRpcCanceInsertBattleAsk v = new ActivityStormRpcCanceInsertBattleAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcCanceInsertBattleAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcCanceInsertBattleAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcCanceInsertBattleAsk pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcCanceInsertBattleAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//取消进入战场回应封装类
[System.Serializable]
public class ActivityStormRpcCanceInsertBattleReplyWraper
{

	//构造函数
	public ActivityStormRpcCanceInsertBattleReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcCanceInsertBattleReply ToPB()
	{
		ActivityStormRpcCanceInsertBattleReply v = new ActivityStormRpcCanceInsertBattleReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcCanceInsertBattleReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcCanceInsertBattleReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcCanceInsertBattleReply pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcCanceInsertBattleReply>(protoMS);
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
//重置报名通知封装类
[System.Serializable]
public class ActivityStormRpcResetSignUpNotifyNotifyWraper
{

	//构造函数
	public ActivityStormRpcResetSignUpNotifyNotifyWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityStormRpcResetSignUpNotifyNotify ToPB()
	{
		ActivityStormRpcResetSignUpNotifyNotify v = new ActivityStormRpcResetSignUpNotifyNotify();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityStormRpcResetSignUpNotifyNotify v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityStormRpcResetSignUpNotifyNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityStormRpcResetSignUpNotifyNotify pb = ProtoBuf.Serializer.Deserialize<ActivityStormRpcResetSignUpNotifyNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
