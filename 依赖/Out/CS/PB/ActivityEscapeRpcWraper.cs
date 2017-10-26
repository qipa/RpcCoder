
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBActivityEscape.cs
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


//报名进入请求封装类
[System.Serializable]
public class ActivityEscapeRpcSignUpAskWraper
{

	//构造函数
	public ActivityEscapeRpcSignUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityEscapeRpcSignUpAsk ToPB()
	{
		ActivityEscapeRpcSignUpAsk v = new ActivityEscapeRpcSignUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityEscapeRpcSignUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityEscapeRpcSignUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityEscapeRpcSignUpAsk pb = ProtoBuf.Serializer.Deserialize<ActivityEscapeRpcSignUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//报名进入回应封装类
[System.Serializable]
public class ActivityEscapeRpcSignUpReplyWraper
{

	//构造函数
	public ActivityEscapeRpcSignUpReplyWraper()
	{
		 m_Result = -9999;
		m_LosePeopleID = new List<long>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_LosePeopleID = new List<long>();

	}

 	//转化成Protobuffer类型函数
	public ActivityEscapeRpcSignUpReply ToPB()
	{
		ActivityEscapeRpcSignUpReply v = new ActivityEscapeRpcSignUpReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_LosePeopleID.Count; i++)
			v.LosePeopleID.Add( m_LosePeopleID[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityEscapeRpcSignUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_LosePeopleID.Clear();
		for( int i=0; i<v.LosePeopleID.Count; i++)
			m_LosePeopleID.Add(v.LosePeopleID[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityEscapeRpcSignUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityEscapeRpcSignUpReply pb = ProtoBuf.Serializer.Deserialize<ActivityEscapeRpcSignUpReply>(protoMS);
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
	//次数已满的人员id
	public List<long> m_LosePeopleID;
	public int SizeLosePeopleID()
	{
		return m_LosePeopleID.Count;
	}
	public List<long> GetLosePeopleID()
	{
		return m_LosePeopleID;
	}
	public long GetLosePeopleID(int Index)
	{
		if(Index<0 || Index>=(int)m_LosePeopleID.Count)
			return -1;
		return m_LosePeopleID[Index];
	}
	public void SetLosePeopleID( List<long> v )
	{
		m_LosePeopleID=v;
	}
	public void SetLosePeopleID( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_LosePeopleID.Count)
			return;
		m_LosePeopleID[Index] = v;
	}
	public void AddLosePeopleID( long v=-1 )
	{
		m_LosePeopleID.Add(v);
	}
	public void ClearLosePeopleID( )
	{
		m_LosePeopleID.Clear();
	}


};
