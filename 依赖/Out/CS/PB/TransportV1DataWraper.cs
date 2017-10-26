
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBTransport.cs
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


//货物对象封装类
[System.Serializable]
public class TransportGoodsObjWraperV1
{

	//构造函数
	public TransportGoodsObjWraperV1()
	{
		 m_GoodId = -1;
		 m_TemplateId = -1;
		 m_ItemNum = -1;
		 m_CateGory = -1;
		 m_IsHelp = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GoodId = -1;
		 m_TemplateId = -1;
		 m_ItemNum = -1;
		 m_CateGory = -1;
		 m_IsHelp = false;

	}

 	//转化成Protobuffer类型函数
	public TransportGoodsObjV1 ToPB()
	{
		TransportGoodsObjV1 v = new TransportGoodsObjV1();
		v.GoodId = m_GoodId;
		v.TemplateId = m_TemplateId;
		v.ItemNum = m_ItemNum;
		v.CateGory = m_CateGory;
		v.IsHelp = m_IsHelp;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportGoodsObjV1 v)
	{
        if (v == null)
            return;
		m_GoodId = v.GoodId;
		m_TemplateId = v.TemplateId;
		m_ItemNum = v.ItemNum;
		m_CateGory = v.CateGory;
		m_IsHelp = v.IsHelp;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportGoodsObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportGoodsObjV1 pb = ProtoBuf.Serializer.Deserialize<TransportGoodsObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//货物id
	public int m_GoodId;
	public int GoodId
	{
		get { return m_GoodId;}
		set { m_GoodId = value; }
	}
	//物品配置id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//物品数量
	public int m_ItemNum;
	public int ItemNum
	{
		get { return m_ItemNum;}
		set { m_ItemNum = value; }
	}
	//类别id
	public int m_CateGory;
	public int CateGory
	{
		get { return m_CateGory;}
		set { m_CateGory = value; }
	}
	//是否请求帮助
	public bool m_IsHelp;
	public bool IsHelp
	{
		get { return m_IsHelp;}
		set { m_IsHelp = value; }
	}


};
//奖励对象封装类
[System.Serializable]
public class TransportRewardObjWraperV1
{

	//构造函数
	public TransportRewardObjWraperV1()
	{
		 m_RewardId = -1;
		 m_LV = -1;
		 m_GoodType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_RewardId = -1;
		 m_LV = -1;
		 m_GoodType = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRewardObjV1 ToPB()
	{
		TransportRewardObjV1 v = new TransportRewardObjV1();
		v.RewardId = m_RewardId;
		v.LV = m_LV;
		v.GoodType = m_GoodType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRewardObjV1 v)
	{
        if (v == null)
            return;
		m_RewardId = v.RewardId;
		m_LV = v.LV;
		m_GoodType = v.GoodType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRewardObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRewardObjV1 pb = ProtoBuf.Serializer.Deserialize<TransportRewardObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//索引
	public int m_RewardId;
	public int RewardId
	{
		get { return m_RewardId;}
		set { m_RewardId = value; }
	}
	//玩家等级
	public int m_LV;
	public int LV
	{
		get { return m_LV;}
		set { m_LV = value; }
	}
	//货物类别
	public int m_GoodType;
	public int GoodType
	{
		get { return m_GoodType;}
		set { m_GoodType = value; }
	}


};
