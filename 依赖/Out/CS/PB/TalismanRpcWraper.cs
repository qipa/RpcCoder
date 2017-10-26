
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBTalisman.cs
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


//数据同步请求封装类
[System.Serializable]
public class TalismanRpcSyncDataAskWraper
{

	//构造函数
	public TalismanRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TalismanRpcSyncDataAsk ToPB()
	{
		TalismanRpcSyncDataAsk v = new TalismanRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<TalismanRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class TalismanRpcSyncDataReplyWraper
{

	//构造函数
	public TalismanRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TalismanRpcSyncDataReply ToPB()
	{
		TalismanRpcSyncDataReply v = new TalismanRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<TalismanRpcSyncDataReply>(protoMS);
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
//升级请求封装类
[System.Serializable]
public class TalismanRpcUpgradeAskWraper
{

	//构造函数
	public TalismanRpcUpgradeAskWraper()
	{
		 m_ID = -1;
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ID = -1;
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public TalismanRpcUpgradeAsk ToPB()
	{
		TalismanRpcUpgradeAsk v = new TalismanRpcUpgradeAsk();
		v.ID = m_ID;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanRpcUpgradeAsk v)
	{
        if (v == null)
            return;
		m_ID = v.ID;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanRpcUpgradeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanRpcUpgradeAsk pb = ProtoBuf.Serializer.Deserialize<TalismanRpcUpgradeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ID 
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//升级回应封装类
[System.Serializable]
public class TalismanRpcUpgradeReplyWraper
{

	//构造函数
	public TalismanRpcUpgradeReplyWraper()
	{
		 m_Result = -9999;
		 m_ID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ID = -1;

	}

 	//转化成Protobuffer类型函数
	public TalismanRpcUpgradeReply ToPB()
	{
		TalismanRpcUpgradeReply v = new TalismanRpcUpgradeReply();
		v.Result = m_Result;
		v.ID = m_ID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanRpcUpgradeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ID = v.ID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanRpcUpgradeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanRpcUpgradeReply pb = ProtoBuf.Serializer.Deserialize<TalismanRpcUpgradeReply>(protoMS);
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
	//ID 
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}


};
//激活请求封装类
[System.Serializable]
public class TalismanRpcActiveAskWraper
{

	//构造函数
	public TalismanRpcActiveAskWraper()
	{
		 m_ID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ID = -1;

	}

 	//转化成Protobuffer类型函数
	public TalismanRpcActiveAsk ToPB()
	{
		TalismanRpcActiveAsk v = new TalismanRpcActiveAsk();
		v.ID = m_ID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanRpcActiveAsk v)
	{
        if (v == null)
            return;
		m_ID = v.ID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanRpcActiveAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanRpcActiveAsk pb = ProtoBuf.Serializer.Deserialize<TalismanRpcActiveAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ID 
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}


};
//激活回应封装类
[System.Serializable]
public class TalismanRpcActiveReplyWraper
{

	//构造函数
	public TalismanRpcActiveReplyWraper()
	{
		 m_Result = -9999;
		 m_ID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ID = -1;

	}

 	//转化成Protobuffer类型函数
	public TalismanRpcActiveReply ToPB()
	{
		TalismanRpcActiveReply v = new TalismanRpcActiveReply();
		v.Result = m_Result;
		v.ID = m_ID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanRpcActiveReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ID = v.ID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanRpcActiveReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanRpcActiveReply pb = ProtoBuf.Serializer.Deserialize<TalismanRpcActiveReply>(protoMS);
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
	//ID 
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}


};
