
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBShop.cs
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


//商店对象封装类
[System.Serializable]
public class ShopShopObjWraperV1
{

	//构造函数
	public ShopShopObjWraperV1()
	{
		 m_ShopType = -1;
		m_ItemArray = new List<ShopItemObjWraperV1>();
		 m_LastRefreshTime = -1;
		 m_RefreshTimes = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ShopType = -1;
		m_ItemArray = new List<ShopItemObjWraperV1>();
		 m_LastRefreshTime = -1;
		 m_RefreshTimes = -1;

	}

 	//转化成Protobuffer类型函数
	public ShopShopObjV1 ToPB()
	{
		ShopShopObjV1 v = new ShopShopObjV1();
		v.ShopType = m_ShopType;
		for (int i=0; i<(int)m_ItemArray.Count; i++)
			v.ItemArray.Add( m_ItemArray[i].ToPB());
		v.LastRefreshTime = m_LastRefreshTime;
		v.RefreshTimes = m_RefreshTimes;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopShopObjV1 v)
	{
        if (v == null)
            return;
		m_ShopType = v.ShopType;
		m_ItemArray.Clear();
		for( int i=0; i<v.ItemArray.Count; i++)
			m_ItemArray.Add( new ShopItemObjWraperV1());
		for( int i=0; i<v.ItemArray.Count; i++)
			m_ItemArray[i].FromPB(v.ItemArray[i]);
		m_LastRefreshTime = v.LastRefreshTime;
		m_RefreshTimes = v.RefreshTimes;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopShopObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopShopObjV1 pb = ProtoBuf.Serializer.Deserialize<ShopShopObjV1>(protoMS);
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
	//道具
	public List<ShopItemObjWraperV1> m_ItemArray;
	public int SizeItemArray()
	{
		return m_ItemArray.Count;
	}
	public List<ShopItemObjWraperV1> GetItemArray()
	{
		return m_ItemArray;
	}
	public ShopItemObjWraperV1 GetItemArray(int Index)
	{
		if(Index<0 || Index>=(int)m_ItemArray.Count)
			return new ShopItemObjWraperV1();
		return m_ItemArray[Index];
	}
	public void SetItemArray( List<ShopItemObjWraperV1> v )
	{
		m_ItemArray=v;
	}
	public void SetItemArray( int Index, ShopItemObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_ItemArray.Count)
			return;
		m_ItemArray[Index] = v;
	}
	public void AddItemArray( ShopItemObjWraperV1 v )
	{
		m_ItemArray.Add(v);
	}
	public void ClearItemArray( )
	{
		m_ItemArray.Clear();
	}
	//上次刷新时间
	public long m_LastRefreshTime;
	public long LastRefreshTime
	{
		get { return m_LastRefreshTime;}
		set { m_LastRefreshTime = value; }
	}
	//刷新次数
	public int m_RefreshTimes;
	public int RefreshTimes
	{
		get { return m_RefreshTimes;}
		set { m_RefreshTimes = value; }
	}


};
//道具对象封装类
[System.Serializable]
public class ShopItemObjWraperV1
{

	//构造函数
	public ShopItemObjWraperV1()
	{
		 m_ItemId = -1;
		 m_Count = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_Count = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public ShopItemObjV1 ToPB()
	{
		ShopItemObjV1 v = new ShopItemObjV1();
		v.ItemId = m_ItemId;
		v.Count = m_Count;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ShopItemObjV1 v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_Count = v.Count;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ShopItemObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ShopItemObjV1 pb = ProtoBuf.Serializer.Deserialize<ShopItemObjV1>(protoMS);
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
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
