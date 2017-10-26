
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBGM.cs
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


//指令动作请求封装类
[System.Serializable]
public class GMRpcActionAskWraper
{

	//构造函数
	public GMRpcActionAskWraper()
	{
		 m_Value = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Value = "";

	}

 	//转化成Protobuffer类型函数
	public GMRpcActionAsk ToPB()
	{
		GMRpcActionAsk v = new GMRpcActionAsk();
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GMRpcActionAsk v)
	{
        if (v == null)
            return;
		m_Value = v.Value;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GMRpcActionAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GMRpcActionAsk pb = ProtoBuf.Serializer.Deserialize<GMRpcActionAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//指令内容
	public string m_Value;
	public string Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
//指令动作回应封装类
[System.Serializable]
public class GMRpcActionReplyWraper
{

	//构造函数
	public GMRpcActionReplyWraper()
	{
		 m_Result = -9999;
		 m_Value = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Value = "";

	}

 	//转化成Protobuffer类型函数
	public GMRpcActionReply ToPB()
	{
		GMRpcActionReply v = new GMRpcActionReply();
		v.Result = m_Result;
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GMRpcActionReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Value = v.Value;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GMRpcActionReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GMRpcActionReply pb = ProtoBuf.Serializer.Deserialize<GMRpcActionReply>(protoMS);
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
	//指令内容
	public string m_Value;
	public string Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
