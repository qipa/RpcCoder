
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBLogin.cs
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


//密钥认证请求封装类
[System.Serializable]
public class LoginRpcKeyAuthAskWraper
{

	//构造函数
	public LoginRpcKeyAuthAskWraper()
	{
		 m_DistId = -1;
		 m_RsaData = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DistId = -1;
		 m_RsaData = "";

	}

 	//转化成Protobuffer类型函数
	public LoginRpcKeyAuthAsk ToPB()
	{
		LoginRpcKeyAuthAsk v = new LoginRpcKeyAuthAsk();
		v.DistId = m_DistId;
		v.RsaData = m_RsaData;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(LoginRpcKeyAuthAsk v)
	{
        if (v == null)
            return;
		m_DistId = v.DistId;
		m_RsaData = v.RsaData;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<LoginRpcKeyAuthAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		LoginRpcKeyAuthAsk pb = ProtoBuf.Serializer.Deserialize<LoginRpcKeyAuthAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//区ID
	public int m_DistId;
	public int DistId
	{
		get { return m_DistId;}
		set { m_DistId = value; }
	}
	//加密数据
	public string m_RsaData;
	public string RsaData
	{
		get { return m_RsaData;}
		set { m_RsaData = value; }
	}


};
//密钥认证回应封装类
[System.Serializable]
public class LoginRpcKeyAuthReplyWraper
{

	//构造函数
	public LoginRpcKeyAuthReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_PlatName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_PlatName = "";

	}

 	//转化成Protobuffer类型函数
	public LoginRpcKeyAuthReply ToPB()
	{
		LoginRpcKeyAuthReply v = new LoginRpcKeyAuthReply();
		v.Result = m_Result;
		v.UserId = m_UserId;
		v.PlatName = m_PlatName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(LoginRpcKeyAuthReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;
		m_PlatName = v.PlatName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<LoginRpcKeyAuthReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		LoginRpcKeyAuthReply pb = ProtoBuf.Serializer.Deserialize<LoginRpcKeyAuthReply>(protoMS);
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
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//平台账号名
	public string m_PlatName;
	public string PlatName
	{
		get { return m_PlatName;}
		set { m_PlatName = value; }
	}


};
//被踢下线通知封装类
[System.Serializable]
public class LoginRpcKickOffNotifyWraper
{

	//构造函数
	public LoginRpcKickOffNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public LoginRpcKickOffNotify ToPB()
	{
		LoginRpcKickOffNotify v = new LoginRpcKickOffNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(LoginRpcKickOffNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<LoginRpcKickOffNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		LoginRpcKickOffNotify pb = ProtoBuf.Serializer.Deserialize<LoginRpcKickOffNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
