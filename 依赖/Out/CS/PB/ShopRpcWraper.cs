
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBShop.cs
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
public class ShopRpcSyncDataAskWraper
{

	//构造函数
	public ShopRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ShopRpcSyncDataAsk ToPB()
	{
		ShopRpcSyncDataAsk v = new ShopRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<ShopRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class ShopRpcSyncDataReplyWraper
{

	//构造函数
	public ShopRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ShopRpcSyncDataReply ToPB()
	{
		ShopRpcSyncDataReply v = new ShopRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<ShopRpcSyncDataReply>(protoMS);
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
//购买请求封装类
[System.Serializable]
public class ShopRpcBuyAskWraper
{

	//构造函数
	public ShopRpcBuyAskWraper()
	{
		 m_ShopType = -1;
		 m_ItemId = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ShopType = -1;
		 m_ItemId = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public ShopRpcBuyAsk ToPB()
	{
		ShopRpcBuyAsk v = new ShopRpcBuyAsk();
		v.ShopType = m_ShopType;
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopRpcBuyAsk v)
	{
        if (v == null)
            return;
		m_ShopType = v.ShopType;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopRpcBuyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopRpcBuyAsk pb = ProtoBuf.Serializer.Deserialize<ShopRpcBuyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//商店类型
	public int m_ShopType;
	public int ShopType
	{
		get { return m_ShopType;}
		set { m_ShopType = value; }
	}
	//道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//购买回应封装类
[System.Serializable]
public class ShopRpcBuyReplyWraper
{

	//构造函数
	public ShopRpcBuyReplyWraper()
	{
		 m_Result = -9999;
		 m_ShopType = -1;
		 m_ItemId = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ShopType = -1;
		 m_ItemId = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public ShopRpcBuyReply ToPB()
	{
		ShopRpcBuyReply v = new ShopRpcBuyReply();
		v.Result = m_Result;
		v.ShopType = m_ShopType;
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopRpcBuyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ShopType = v.ShopType;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopRpcBuyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopRpcBuyReply pb = ProtoBuf.Serializer.Deserialize<ShopRpcBuyReply>(protoMS);
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
	//商店类型
	public int m_ShopType;
	public int ShopType
	{
		get { return m_ShopType;}
		set { m_ShopType = value; }
	}
	//道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//刷新道具请求封装类
[System.Serializable]
public class ShopRpcRefreshItemAskWraper
{

	//构造函数
	public ShopRpcRefreshItemAskWraper()
	{
		 m_ShopType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ShopType = -1;

	}

 	//转化成Protobuffer类型函数
	public ShopRpcRefreshItemAsk ToPB()
	{
		ShopRpcRefreshItemAsk v = new ShopRpcRefreshItemAsk();
		v.ShopType = m_ShopType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopRpcRefreshItemAsk v)
	{
        if (v == null)
            return;
		m_ShopType = v.ShopType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopRpcRefreshItemAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopRpcRefreshItemAsk pb = ProtoBuf.Serializer.Deserialize<ShopRpcRefreshItemAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//商店类型
	public int m_ShopType;
	public int ShopType
	{
		get { return m_ShopType;}
		set { m_ShopType = value; }
	}


};
//刷新道具回应封装类
[System.Serializable]
public class ShopRpcRefreshItemReplyWraper
{

	//构造函数
	public ShopRpcRefreshItemReplyWraper()
	{
		 m_Result = -9999;
		 m_ShopType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ShopType = -1;

	}

 	//转化成Protobuffer类型函数
	public ShopRpcRefreshItemReply ToPB()
	{
		ShopRpcRefreshItemReply v = new ShopRpcRefreshItemReply();
		v.Result = m_Result;
		v.ShopType = m_ShopType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopRpcRefreshItemReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ShopType = v.ShopType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopRpcRefreshItemReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopRpcRefreshItemReply pb = ProtoBuf.Serializer.Deserialize<ShopRpcRefreshItemReply>(protoMS);
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
	//商店类型
	public int m_ShopType;
	public int ShopType
	{
		get { return m_ShopType;}
		set { m_ShopType = value; }
	}


};
