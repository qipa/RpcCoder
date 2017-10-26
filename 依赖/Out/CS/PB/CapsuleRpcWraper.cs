
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBCapsule.cs
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
public class CapsuleRpcSyncDataAskWraper
{

	//构造函数
	public CapsuleRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public CapsuleRpcSyncDataAsk ToPB()
	{
		CapsuleRpcSyncDataAsk v = new CapsuleRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<CapsuleRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class CapsuleRpcSyncDataReplyWraper
{

	//构造函数
	public CapsuleRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public CapsuleRpcSyncDataReply ToPB()
	{
		CapsuleRpcSyncDataReply v = new CapsuleRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<CapsuleRpcSyncDataReply>(protoMS);
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
//购买抽奖请求封装类
[System.Serializable]
public class CapsuleRpcBuyAskWraper
{

	//构造函数
	public CapsuleRpcBuyAskWraper()
	{
		 m_Id = -1;
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public CapsuleRpcBuyAsk ToPB()
	{
		CapsuleRpcBuyAsk v = new CapsuleRpcBuyAsk();
		v.Id = m_Id;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleRpcBuyAsk v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleRpcBuyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleRpcBuyAsk pb = ProtoBuf.Serializer.Deserialize<CapsuleRpcBuyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//扭蛋id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//购买次数类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//购买抽奖回应封装类
[System.Serializable]
public class CapsuleRpcBuyReplyWraper
{

	//构造函数
	public CapsuleRpcBuyReplyWraper()
	{
		 m_Result = -9999;
		m_ItemArray = new List<CapsuleItemObjWraper>();
		 m_Id = -1;
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_ItemArray = new List<CapsuleItemObjWraper>();
		 m_Id = -1;
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public CapsuleRpcBuyReply ToPB()
	{
		CapsuleRpcBuyReply v = new CapsuleRpcBuyReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_ItemArray.Count; i++)
			v.ItemArray.Add( m_ItemArray[i].ToPB());
		v.Id = m_Id;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleRpcBuyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemArray.Clear();
		for( int i=0; i<v.ItemArray.Count; i++)
			m_ItemArray.Add( new CapsuleItemObjWraper());
		for( int i=0; i<v.ItemArray.Count; i++)
			m_ItemArray[i].FromPB(v.ItemArray[i]);
		m_Id = v.Id;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleRpcBuyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleRpcBuyReply pb = ProtoBuf.Serializer.Deserialize<CapsuleRpcBuyReply>(protoMS);
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
	//道具
	public List<CapsuleItemObjWraper> m_ItemArray;
	public int SizeItemArray()
	{
		return m_ItemArray.Count;
	}
	public List<CapsuleItemObjWraper> GetItemArray()
	{
		return m_ItemArray;
	}
	public CapsuleItemObjWraper GetItemArray(int Index)
	{
		if(Index<0 || Index>=(int)m_ItemArray.Count)
			return new CapsuleItemObjWraper();
		return m_ItemArray[Index];
	}
	public void SetItemArray( List<CapsuleItemObjWraper> v )
	{
		m_ItemArray=v;
	}
	public void SetItemArray( int Index, CapsuleItemObjWraper v )
	{
		if(Index<0 || Index>=(int)m_ItemArray.Count)
			return;
		m_ItemArray[Index] = v;
	}
	public void AddItemArray( CapsuleItemObjWraper v )
	{
		m_ItemArray.Add(v);
	}
	public void ClearItemArray( )
	{
		m_ItemArray.Clear();
	}
	//扭蛋id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//购买次数类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//碎片兑换请求封装类
[System.Serializable]
public class CapsuleRpcExchangeAskWraper
{

	//构造函数
	public CapsuleRpcExchangeAskWraper()
	{
		 m_ItemId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;

	}

 	//转化成Protobuffer类型函数
	public CapsuleRpcExchangeAsk ToPB()
	{
		CapsuleRpcExchangeAsk v = new CapsuleRpcExchangeAsk();
		v.ItemId = m_ItemId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleRpcExchangeAsk v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleRpcExchangeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleRpcExchangeAsk pb = ProtoBuf.Serializer.Deserialize<CapsuleRpcExchangeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}


};
//碎片兑换回应封装类
[System.Serializable]
public class CapsuleRpcExchangeReplyWraper
{

	//构造函数
	public CapsuleRpcExchangeReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;

	}

 	//转化成Protobuffer类型函数
	public CapsuleRpcExchangeReply ToPB()
	{
		CapsuleRpcExchangeReply v = new CapsuleRpcExchangeReply();
		v.Result = m_Result;
		v.ItemId = m_ItemId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleRpcExchangeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemId = v.ItemId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleRpcExchangeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleRpcExchangeReply pb = ProtoBuf.Serializer.Deserialize<CapsuleRpcExchangeReply>(protoMS);
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
	//道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}


};
//道具对象封装类
[System.Serializable]
public class CapsuleItemObjWraper
{

	//构造函数
	public CapsuleItemObjWraper()
	{
		 m_ItemId = -1;
		 m_Count = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_Count = -1;

	}

 	//转化成Protobuffer类型函数
	public CapsuleItemObj ToPB()
	{
		CapsuleItemObj v = new CapsuleItemObj();
		v.ItemId = m_ItemId;
		v.Count = m_Count;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleItemObj v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_Count = v.Count;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleItemObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleItemObj pb = ProtoBuf.Serializer.Deserialize<CapsuleItemObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//数量
	public int m_Count;
	public int Count
	{
		get { return m_Count;}
		set { m_Count = value; }
	}


};
