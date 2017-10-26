
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBDropItem.cs
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


//物品掉落通知通知封装类
[System.Serializable]
public class DropItemRpcDropItemNoticeNotifyWraper
{

	//构造函数
	public DropItemRpcDropItemNoticeNotifyWraper()
	{
		m_DropItem = new List<DropItemObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_DropItem = new List<DropItemObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public DropItemRpcDropItemNoticeNotify ToPB()
	{
		DropItemRpcDropItemNoticeNotify v = new DropItemRpcDropItemNoticeNotify();
		for (int i=0; i<(int)m_DropItem.Count; i++)
			v.DropItem.Add( m_DropItem[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DropItemRpcDropItemNoticeNotify v)
	{
        if (v == null)
            return;
		m_DropItem.Clear();
		for( int i=0; i<v.DropItem.Count; i++)
			m_DropItem.Add( new DropItemObjWraper());
		for( int i=0; i<v.DropItem.Count; i++)
			m_DropItem[i].FromPB(v.DropItem[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DropItemRpcDropItemNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DropItemRpcDropItemNoticeNotify pb = ProtoBuf.Serializer.Deserialize<DropItemRpcDropItemNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//掉落的物品
	public List<DropItemObjWraper> m_DropItem;
	public int SizeDropItem()
	{
		return m_DropItem.Count;
	}
	public List<DropItemObjWraper> GetDropItem()
	{
		return m_DropItem;
	}
	public DropItemObjWraper GetDropItem(int Index)
	{
		if(Index<0 || Index>=(int)m_DropItem.Count)
			return new DropItemObjWraper();
		return m_DropItem[Index];
	}
	public void SetDropItem( List<DropItemObjWraper> v )
	{
		m_DropItem=v;
	}
	public void SetDropItem( int Index, DropItemObjWraper v )
	{
		if(Index<0 || Index>=(int)m_DropItem.Count)
			return;
		m_DropItem[Index] = v;
	}
	public void AddDropItem( DropItemObjWraper v )
	{
		m_DropItem.Add(v);
	}
	public void ClearDropItem( )
	{
		m_DropItem.Clear();
	}


};
//捡物品请求封装类
[System.Serializable]
public class DropItemRpcPickupItemAskWraper
{

	//构造函数
	public DropItemRpcPickupItemAskWraper()
	{
		 m_UId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UId = -1;

	}

 	//转化成Protobuffer类型函数
	public DropItemRpcPickupItemAsk ToPB()
	{
		DropItemRpcPickupItemAsk v = new DropItemRpcPickupItemAsk();
		v.UId = m_UId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DropItemRpcPickupItemAsk v)
	{
        if (v == null)
            return;
		m_UId = v.UId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DropItemRpcPickupItemAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DropItemRpcPickupItemAsk pb = ProtoBuf.Serializer.Deserialize<DropItemRpcPickupItemAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//下标
	public int m_UId;
	public int UId
	{
		get { return m_UId;}
		set { m_UId = value; }
	}


};
//捡物品回应封装类
[System.Serializable]
public class DropItemRpcPickupItemReplyWraper
{

	//构造函数
	public DropItemRpcPickupItemReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public DropItemRpcPickupItemReply ToPB()
	{
		DropItemRpcPickupItemReply v = new DropItemRpcPickupItemReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DropItemRpcPickupItemReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DropItemRpcPickupItemReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DropItemRpcPickupItemReply pb = ProtoBuf.Serializer.Deserialize<DropItemRpcPickupItemReply>(protoMS);
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
//删除掉落通知封装类
[System.Serializable]
public class DropItemRpcDelDropItemNotifyWraper
{

	//构造函数
	public DropItemRpcDelDropItemNotifyWraper()
	{
		 m_UId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UId = -1;

	}

 	//转化成Protobuffer类型函数
	public DropItemRpcDelDropItemNotify ToPB()
	{
		DropItemRpcDelDropItemNotify v = new DropItemRpcDelDropItemNotify();
		v.UId = m_UId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DropItemRpcDelDropItemNotify v)
	{
        if (v == null)
            return;
		m_UId = v.UId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DropItemRpcDelDropItemNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DropItemRpcDelDropItemNotify pb = ProtoBuf.Serializer.Deserialize<DropItemRpcDelDropItemNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//下标
	public int m_UId;
	public int UId
	{
		get { return m_UId;}
		set { m_UId = value; }
	}


};
