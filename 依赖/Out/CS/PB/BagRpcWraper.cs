
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBBag.cs
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


//同步背包数据请求封装类
[System.Serializable]
public class BagRpcSyncDataAskWraper
{

	//构造函数
	public BagRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BagRpcSyncDataAsk ToPB()
	{
		BagRpcSyncDataAsk v = new BagRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//同步背包数据回应封装类
[System.Serializable]
public class BagRpcSyncDataReplyWraper
{

	//构造函数
	public BagRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcSyncDataReply ToPB()
	{
		BagRpcSyncDataReply v = new BagRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<BagRpcSyncDataReply>(protoMS);
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
//出售请求封装类
[System.Serializable]
public class BagRpcSellAskWraper
{

	//构造函数
	public BagRpcSellAskWraper()
	{
		 m_ItemID = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcSellAsk ToPB()
	{
		BagRpcSellAsk v = new BagRpcSellAsk();
		v.ItemID = m_ItemID;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSellAsk v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSellAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSellAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcSellAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品id
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//出售回应封装类
[System.Serializable]
public class BagRpcSellReplyWraper
{

	//构造函数
	public BagRpcSellReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcSellReply ToPB()
	{
		BagRpcSellReply v = new BagRpcSellReply();
		v.Result = m_Result;
		v.ItemID = m_ItemID;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSellReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemID = v.ItemID;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSellReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSellReply pb = ProtoBuf.Serializer.Deserialize<BagRpcSellReply>(protoMS);
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
	//物品id
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//分解请求封装类
[System.Serializable]
public class BagRpcDecomposeAskWraper
{

	//构造函数
	public BagRpcDecomposeAskWraper()
	{
		 m_ItemID = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcDecomposeAsk ToPB()
	{
		BagRpcDecomposeAsk v = new BagRpcDecomposeAsk();
		v.ItemID = m_ItemID;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcDecomposeAsk v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcDecomposeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcDecomposeAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcDecomposeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品id
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//分解回应封装类
[System.Serializable]
public class BagRpcDecomposeReplyWraper
{

	//构造函数
	public BagRpcDecomposeReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcDecomposeReply ToPB()
	{
		BagRpcDecomposeReply v = new BagRpcDecomposeReply();
		v.Result = m_Result;
		v.ItemID = m_ItemID;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcDecomposeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemID = v.ItemID;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcDecomposeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcDecomposeReply pb = ProtoBuf.Serializer.Deserialize<BagRpcDecomposeReply>(protoMS);
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
	//物品id
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//物品使用请求封装类
[System.Serializable]
public class BagRpcUseAskWraper
{

	//构造函数
	public BagRpcUseAskWraper()
	{
		 m_ItemID = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcUseAsk ToPB()
	{
		BagRpcUseAsk v = new BagRpcUseAsk();
		v.ItemID = m_ItemID;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcUseAsk v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcUseAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcUseAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcUseAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品id
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//物品使用回应封装类
[System.Serializable]
public class BagRpcUseReplyWraper
{

	//构造函数
	public BagRpcUseReplyWraper()
	{
		 m_Result = -9999;
		 m_Pos = -1;
		 m_ItemID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Pos = -1;
		 m_ItemID = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcUseReply ToPB()
	{
		BagRpcUseReply v = new BagRpcUseReply();
		v.Result = m_Result;
		v.Pos = m_Pos;
		v.ItemID = m_ItemID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcUseReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Pos = v.Pos;
		m_ItemID = v.ItemID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcUseReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcUseReply pb = ProtoBuf.Serializer.Deserialize<BagRpcUseReply>(protoMS);
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
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//物品id
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}


};
//装备穿戴请求封装类
[System.Serializable]
public class BagRpcEquipWearAskWraper
{

	//构造函数
	public BagRpcEquipWearAskWraper()
	{
		 m_ItemId = -1;
		 m_BagPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_BagPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipWearAsk ToPB()
	{
		BagRpcEquipWearAsk v = new BagRpcEquipWearAsk();
		v.ItemId = m_ItemId;
		v.BagPos = m_BagPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipWearAsk v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_BagPos = v.BagPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipWearAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipWearAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipWearAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ItemId
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//在背包中的位置
	public int m_BagPos;
	public int BagPos
	{
		get { return m_BagPos;}
		set { m_BagPos = value; }
	}


};
//装备穿戴回应封装类
[System.Serializable]
public class BagRpcEquipWearReplyWraper
{

	//构造函数
	public BagRpcEquipWearReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_BagPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_BagPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipWearReply ToPB()
	{
		BagRpcEquipWearReply v = new BagRpcEquipWearReply();
		v.Result = m_Result;
		v.ItemId = m_ItemId;
		v.BagPos = m_BagPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipWearReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemId = v.ItemId;
		m_BagPos = v.BagPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipWearReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipWearReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipWearReply>(protoMS);
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
	//ItemId
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//在背包中的位置
	public int m_BagPos;
	public int BagPos
	{
		get { return m_BagPos;}
		set { m_BagPos = value; }
	}


};
//装备脱下请求封装类
[System.Serializable]
public class BagRpcEquipUndressAskWraper
{

	//构造函数
	public BagRpcEquipUndressAskWraper()
	{
		 m_ItemId = -1;
		 m_EquipPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_EquipPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipUndressAsk ToPB()
	{
		BagRpcEquipUndressAsk v = new BagRpcEquipUndressAsk();
		v.ItemId = m_ItemId;
		v.EquipPos = m_EquipPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipUndressAsk v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_EquipPos = v.EquipPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipUndressAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipUndressAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipUndressAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ItemId
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//选择的装备位
	public int m_EquipPos;
	public int EquipPos
	{
		get { return m_EquipPos;}
		set { m_EquipPos = value; }
	}


};
//装备脱下回应封装类
[System.Serializable]
public class BagRpcEquipUndressReplyWraper
{

	//构造函数
	public BagRpcEquipUndressReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_EquipPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_EquipPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipUndressReply ToPB()
	{
		BagRpcEquipUndressReply v = new BagRpcEquipUndressReply();
		v.Result = m_Result;
		v.ItemId = m_ItemId;
		v.EquipPos = m_EquipPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipUndressReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemId = v.ItemId;
		m_EquipPos = v.EquipPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipUndressReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipUndressReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipUndressReply>(protoMS);
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
	//ItemId
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//选择的装备位
	public int m_EquipPos;
	public int EquipPos
	{
		get { return m_EquipPos;}
		set { m_EquipPos = value; }
	}


};
//装备强化请求封装类
[System.Serializable]
public class BagRpcEquipEnhanceAskWraper
{

	//构造函数
	public BagRpcEquipEnhanceAskWraper()
	{
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_Lv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_Lv = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipEnhanceAsk ToPB()
	{
		BagRpcEquipEnhanceAsk v = new BagRpcEquipEnhanceAsk();
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.Lv = m_Lv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipEnhanceAsk v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_Lv = v.Lv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipEnhanceAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipEnhanceAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipEnhanceAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ItemId
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
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//需要强化的等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}


};
//装备强化回应封装类
[System.Serializable]
public class BagRpcEquipEnhanceReplyWraper
{

	//构造函数
	public BagRpcEquipEnhanceReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_Lv = -1;
		 m_IsFirstEnhance = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_Lv = -1;
		 m_IsFirstEnhance = false;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipEnhanceReply ToPB()
	{
		BagRpcEquipEnhanceReply v = new BagRpcEquipEnhanceReply();
		v.Result = m_Result;
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.Lv = m_Lv;
		v.IsFirstEnhance = m_IsFirstEnhance;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipEnhanceReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_Lv = v.Lv;
		m_IsFirstEnhance = v.IsFirstEnhance;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipEnhanceReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipEnhanceReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipEnhanceReply>(protoMS);
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
	//ItemId
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
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//需要强化的等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//是否第一次强化
	public bool m_IsFirstEnhance;
	public bool IsFirstEnhance
	{
		get { return m_IsFirstEnhance;}
		set { m_IsFirstEnhance = value; }
	}


};
//装备洗炼请求封装类
[System.Serializable]
public class BagRpcEquipPolishedAskWraper
{

	//构造函数
	public BagRpcEquipPolishedAskWraper()
	{
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipPolishedAsk ToPB()
	{
		BagRpcEquipPolishedAsk v = new BagRpcEquipPolishedAsk();
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipPolishedAsk v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipPolishedAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipPolishedAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipPolishedAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ItemId
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
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备洗炼回应封装类
[System.Serializable]
public class BagRpcEquipPolishedReplyWraper
{

	//构造函数
	public BagRpcEquipPolishedReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipPolishedReply ToPB()
	{
		BagRpcEquipPolishedReply v = new BagRpcEquipPolishedReply();
		v.Result = m_Result;
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipPolishedReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipPolishedReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipPolishedReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipPolishedReply>(protoMS);
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
	//ItemId
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
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备洗炼属性替换请求封装类
[System.Serializable]
public class BagRpcEquipPolishedReplaceAskWraper
{

	//构造函数
	public BagRpcEquipPolishedReplaceAskWraper()
	{
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipPolishedReplaceAsk ToPB()
	{
		BagRpcEquipPolishedReplaceAsk v = new BagRpcEquipPolishedReplaceAsk();
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipPolishedReplaceAsk v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipPolishedReplaceAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipPolishedReplaceAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipPolishedReplaceAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//ItemId
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
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备洗炼属性替换回应封装类
[System.Serializable]
public class BagRpcEquipPolishedReplaceReplyWraper
{

	//构造函数
	public BagRpcEquipPolishedReplaceReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipPolishedReplaceReply ToPB()
	{
		BagRpcEquipPolishedReplaceReply v = new BagRpcEquipPolishedReplaceReply();
		v.Result = m_Result;
		v.ItemId = m_ItemId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipPolishedReplaceReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemId = v.ItemId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipPolishedReplaceReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipPolishedReplaceReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipPolishedReplaceReply>(protoMS);
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
	//ItemId
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
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//背包整理请求封装类
[System.Serializable]
public class BagRpcBagTidyAskWraper
{

	//构造函数
	public BagRpcBagTidyAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagTidyAsk ToPB()
	{
		BagRpcBagTidyAsk v = new BagRpcBagTidyAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagTidyAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagTidyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagTidyAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagTidyAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//背包整理回应封装类
[System.Serializable]
public class BagRpcBagTidyReplyWraper
{

	//构造函数
	public BagRpcBagTidyReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagTidyReply ToPB()
	{
		BagRpcBagTidyReply v = new BagRpcBagTidyReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagTidyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagTidyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagTidyReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagTidyReply>(protoMS);
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
//物品回收，购回请求封装类
[System.Serializable]
public class BagRpcBagRecycleBuyAskWraper
{

	//构造函数
	public BagRpcBagRecycleBuyAskWraper()
	{
		 m_GridPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GridPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagRecycleBuyAsk ToPB()
	{
		BagRpcBagRecycleBuyAsk v = new BagRpcBagRecycleBuyAsk();
		v.GridPos = m_GridPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagRecycleBuyAsk v)
	{
        if (v == null)
            return;
		m_GridPos = v.GridPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagRecycleBuyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagRecycleBuyAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagRecycleBuyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//格子位置
	public int m_GridPos;
	public int GridPos
	{
		get { return m_GridPos;}
		set { m_GridPos = value; }
	}


};
//物品回收，购回回应封装类
[System.Serializable]
public class BagRpcBagRecycleBuyReplyWraper
{

	//构造函数
	public BagRpcBagRecycleBuyReplyWraper()
	{
		 m_Result = -9999;
		 m_GridPos = -1;
		m_GridList = new List<BagRecycleGridObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_GridPos = -1;
		m_GridList = new List<BagRecycleGridObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagRecycleBuyReply ToPB()
	{
		BagRpcBagRecycleBuyReply v = new BagRpcBagRecycleBuyReply();
		v.Result = m_Result;
		v.GridPos = m_GridPos;
		for (int i=0; i<(int)m_GridList.Count; i++)
			v.GridList.Add( m_GridList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagRecycleBuyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GridPos = v.GridPos;
		m_GridList.Clear();
		for( int i=0; i<v.GridList.Count; i++)
			m_GridList.Add( new BagRecycleGridObjWraper());
		for( int i=0; i<v.GridList.Count; i++)
			m_GridList[i].FromPB(v.GridList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagRecycleBuyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagRecycleBuyReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagRecycleBuyReply>(protoMS);
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
	//格子位置
	public int m_GridPos;
	public int GridPos
	{
		get { return m_GridPos;}
		set { m_GridPos = value; }
	}
	//在回收站中的格子
	public List<BagRecycleGridObjWraper> m_GridList;
	public int SizeGridList()
	{
		return m_GridList.Count;
	}
	public List<BagRecycleGridObjWraper> GetGridList()
	{
		return m_GridList;
	}
	public BagRecycleGridObjWraper GetGridList(int Index)
	{
		if(Index<0 || Index>=(int)m_GridList.Count)
			return new BagRecycleGridObjWraper();
		return m_GridList[Index];
	}
	public void SetGridList( List<BagRecycleGridObjWraper> v )
	{
		m_GridList=v;
	}
	public void SetGridList( int Index, BagRecycleGridObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GridList.Count)
			return;
		m_GridList[Index] = v;
	}
	public void AddGridList( BagRecycleGridObjWraper v )
	{
		m_GridList.Add(v);
	}
	public void ClearGridList( )
	{
		m_GridList.Clear();
	}


};
//开启格子请求封装类
[System.Serializable]
public class BagRpcUnlockGridAskWraper
{

	//构造函数
	public BagRpcUnlockGridAskWraper()
	{
		 m_GridCount = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GridCount = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcUnlockGridAsk ToPB()
	{
		BagRpcUnlockGridAsk v = new BagRpcUnlockGridAsk();
		v.GridCount = m_GridCount;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcUnlockGridAsk v)
	{
        if (v == null)
            return;
		m_GridCount = v.GridCount;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcUnlockGridAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcUnlockGridAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcUnlockGridAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//格子数量
	public int m_GridCount;
	public int GridCount
	{
		get { return m_GridCount;}
		set { m_GridCount = value; }
	}


};
//开启格子回应封装类
[System.Serializable]
public class BagRpcUnlockGridReplyWraper
{

	//构造函数
	public BagRpcUnlockGridReplyWraper()
	{
		 m_Result = -9999;
		 m_GridCount = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_GridCount = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcUnlockGridReply ToPB()
	{
		BagRpcUnlockGridReply v = new BagRpcUnlockGridReply();
		v.Result = m_Result;
		v.GridCount = m_GridCount;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcUnlockGridReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GridCount = v.GridCount;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcUnlockGridReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcUnlockGridReply pb = ProtoBuf.Serializer.Deserialize<BagRpcUnlockGridReply>(protoMS);
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
	//格子数量
	public int m_GridCount;
	public int GridCount
	{
		get { return m_GridCount;}
		set { m_GridCount = value; }
	}


};
//回收格子封装类
[System.Serializable]
public class BagRpcSellGridObjWraper
{

	//构造函数
	public BagRpcSellGridObjWraper()
	{
		 m_TemplateId = -1;
		 m_Num = -1;
		 m_Pos = -1;
		 m_ItemId = -1;
		 m_ItemType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Num = -1;
		 m_Pos = -1;
		 m_ItemId = -1;
		 m_ItemType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcSellGridObj ToPB()
	{
		BagRpcSellGridObj v = new BagRpcSellGridObj();
		v.TemplateId = m_TemplateId;
		v.Num = m_Num;
		v.Pos = m_Pos;
		v.ItemId = m_ItemId;
		v.ItemType = m_ItemType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSellGridObj v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Num = v.Num;
		m_Pos = v.Pos;
		m_ItemId = v.ItemId;
		m_ItemType = v.ItemType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSellGridObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSellGridObj pb = ProtoBuf.Serializer.Deserialize<BagRpcSellGridObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//ItemId（背包格子的Index）
	public long m_ItemId;
	public long ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//物品类型
	public int m_ItemType;
	public int ItemType
	{
		get { return m_ItemType;}
		set { m_ItemType = value; }
	}


};
//装备回收出售请求封装类
[System.Serializable]
public class BagRpcBagRecycleSellAskWraper
{

	//构造函数
	public BagRpcBagRecycleSellAskWraper()
	{
		m_GridList = new List<BagRpcSellGridObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_GridList = new List<BagRpcSellGridObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagRecycleSellAsk ToPB()
	{
		BagRpcBagRecycleSellAsk v = new BagRpcBagRecycleSellAsk();
		for (int i=0; i<(int)m_GridList.Count; i++)
			v.GridList.Add( m_GridList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagRecycleSellAsk v)
	{
        if (v == null)
            return;
		m_GridList.Clear();
		for( int i=0; i<v.GridList.Count; i++)
			m_GridList.Add( new BagRpcSellGridObjWraper());
		for( int i=0; i<v.GridList.Count; i++)
			m_GridList[i].FromPB(v.GridList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagRecycleSellAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagRecycleSellAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagRecycleSellAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//回收，出售的格子
	public List<BagRpcSellGridObjWraper> m_GridList;
	public int SizeGridList()
	{
		return m_GridList.Count;
	}
	public List<BagRpcSellGridObjWraper> GetGridList()
	{
		return m_GridList;
	}
	public BagRpcSellGridObjWraper GetGridList(int Index)
	{
		if(Index<0 || Index>=(int)m_GridList.Count)
			return new BagRpcSellGridObjWraper();
		return m_GridList[Index];
	}
	public void SetGridList( List<BagRpcSellGridObjWraper> v )
	{
		m_GridList=v;
	}
	public void SetGridList( int Index, BagRpcSellGridObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GridList.Count)
			return;
		m_GridList[Index] = v;
	}
	public void AddGridList( BagRpcSellGridObjWraper v )
	{
		m_GridList.Add(v);
	}
	public void ClearGridList( )
	{
		m_GridList.Clear();
	}


};
//装备回收出售回应封装类
[System.Serializable]
public class BagRpcBagRecycleSellReplyWraper
{

	//构造函数
	public BagRpcBagRecycleSellReplyWraper()
	{
		 m_Result = -9999;
		m_GridList = new List<BagRecycleGridObjWraper>();
		 m_Money = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_GridList = new List<BagRecycleGridObjWraper>();
		 m_Money = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagRecycleSellReply ToPB()
	{
		BagRpcBagRecycleSellReply v = new BagRpcBagRecycleSellReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_GridList.Count; i++)
			v.GridList.Add( m_GridList[i].ToPB());
		v.Money = m_Money;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagRecycleSellReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GridList.Clear();
		for( int i=0; i<v.GridList.Count; i++)
			m_GridList.Add( new BagRecycleGridObjWraper());
		for( int i=0; i<v.GridList.Count; i++)
			m_GridList[i].FromPB(v.GridList[i]);
		m_Money = v.Money;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagRecycleSellReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagRecycleSellReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagRecycleSellReply>(protoMS);
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
	//在回收站中的格子
	public List<BagRecycleGridObjWraper> m_GridList;
	public int SizeGridList()
	{
		return m_GridList.Count;
	}
	public List<BagRecycleGridObjWraper> GetGridList()
	{
		return m_GridList;
	}
	public BagRecycleGridObjWraper GetGridList(int Index)
	{
		if(Index<0 || Index>=(int)m_GridList.Count)
			return new BagRecycleGridObjWraper();
		return m_GridList[Index];
	}
	public void SetGridList( List<BagRecycleGridObjWraper> v )
	{
		m_GridList=v;
	}
	public void SetGridList( int Index, BagRecycleGridObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GridList.Count)
			return;
		m_GridList[Index] = v;
	}
	public void AddGridList( BagRecycleGridObjWraper v )
	{
		m_GridList.Add(v);
	}
	public void ClearGridList( )
	{
		m_GridList.Clear();
	}
	//金钱
	public int m_Money;
	public int Money
	{
		get { return m_Money;}
		set { m_Money = value; }
	}


};
//物品拆分请求封装类
[System.Serializable]
public class BagRpcSplitAskWraper
{

	//构造函数
	public BagRpcSplitAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcSplitAsk ToPB()
	{
		BagRpcSplitAsk v = new BagRpcSplitAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSplitAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSplitAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSplitAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcSplitAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//拆分出来的数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//物品拆分回应封装类
[System.Serializable]
public class BagRpcSplitReplyWraper
{

	//构造函数
	public BagRpcSplitReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcSplitReply ToPB()
	{
		BagRpcSplitReply v = new BagRpcSplitReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcSplitReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcSplitReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcSplitReply pb = ProtoBuf.Serializer.Deserialize<BagRpcSplitReply>(protoMS);
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
	//物品模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//拆分出来的数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//装备基础属性洗炼请求封装类
[System.Serializable]
public class BagRpcEquipBaseAttrPlishedAskWraper
{

	//构造函数
	public BagRpcEquipBaseAttrPlishedAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipBaseAttrPlishedAsk ToPB()
	{
		BagRpcEquipBaseAttrPlishedAsk v = new BagRpcEquipBaseAttrPlishedAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipBaseAttrPlishedAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipBaseAttrPlishedAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipBaseAttrPlishedAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipBaseAttrPlishedAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备基础属性洗炼回应封装类
[System.Serializable]
public class BagRpcEquipBaseAttrPlishedReplyWraper
{

	//构造函数
	public BagRpcEquipBaseAttrPlishedReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipBaseAttrPlishedReply ToPB()
	{
		BagRpcEquipBaseAttrPlishedReply v = new BagRpcEquipBaseAttrPlishedReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipBaseAttrPlishedReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipBaseAttrPlishedReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipBaseAttrPlishedReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipBaseAttrPlishedReply>(protoMS);
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
	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备基础属性洗炼替换请求封装类
[System.Serializable]
public class BagRpcEquipBaseAttrPolishedReplaceAskWraper
{

	//构造函数
	public BagRpcEquipBaseAttrPolishedReplaceAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipBaseAttrPolishedReplaceAsk ToPB()
	{
		BagRpcEquipBaseAttrPolishedReplaceAsk v = new BagRpcEquipBaseAttrPolishedReplaceAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipBaseAttrPolishedReplaceAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipBaseAttrPolishedReplaceAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipBaseAttrPolishedReplaceAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipBaseAttrPolishedReplaceAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备基础属性洗炼替换回应封装类
[System.Serializable]
public class BagRpcEquipBaseAttrPolishedReplaceReplyWraper
{

	//构造函数
	public BagRpcEquipBaseAttrPolishedReplaceReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipBaseAttrPolishedReplaceReply ToPB()
	{
		BagRpcEquipBaseAttrPolishedReplaceReply v = new BagRpcEquipBaseAttrPolishedReplaceReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipBaseAttrPolishedReplaceReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipBaseAttrPolishedReplaceReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipBaseAttrPolishedReplaceReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipBaseAttrPolishedReplaceReply>(protoMS);
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
	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备改造请求封装类
[System.Serializable]
public class BagRpcEquipExAttrModifyAskWraper
{

	//构造函数
	public BagRpcEquipExAttrModifyAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipExAttrModifyAsk ToPB()
	{
		BagRpcEquipExAttrModifyAsk v = new BagRpcEquipExAttrModifyAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipExAttrModifyAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipExAttrModifyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipExAttrModifyAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipExAttrModifyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}


};
//装备改造回应封装类
[System.Serializable]
public class BagRpcEquipExAttrModifyReplyWraper
{

	//构造函数
	public BagRpcEquipExAttrModifyReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_Index = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_Index = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipExAttrModifyReply ToPB()
	{
		BagRpcEquipExAttrModifyReply v = new BagRpcEquipExAttrModifyReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.Index = m_Index;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipExAttrModifyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_Index = v.Index;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipExAttrModifyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipExAttrModifyReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipExAttrModifyReply>(protoMS);
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
	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//属性Index
	public int m_Index;
	public int Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}


};
//宝石镶嵌请求封装类
[System.Serializable]
public class BagRpcEquipInlayGemAskWraper
{

	//构造函数
	public BagRpcEquipInlayGemAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;
		 m_GemId = -1;
		 m_GemPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;
		 m_GemId = -1;
		 m_GemPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipInlayGemAsk ToPB()
	{
		BagRpcEquipInlayGemAsk v = new BagRpcEquipInlayGemAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.SlotPos = m_SlotPos;
		v.GemId = m_GemId;
		v.GemPos = m_GemPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipInlayGemAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_SlotPos = v.SlotPos;
		m_GemId = v.GemId;
		m_GemPos = v.GemPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipInlayGemAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipInlayGemAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipInlayGemAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//槽位位置
	public int m_SlotPos;
	public int SlotPos
	{
		get { return m_SlotPos;}
		set { m_SlotPos = value; }
	}
	//宝石id
	public int m_GemId;
	public int GemId
	{
		get { return m_GemId;}
		set { m_GemId = value; }
	}
	//在背包中的位置
	public int m_GemPos;
	public int GemPos
	{
		get { return m_GemPos;}
		set { m_GemPos = value; }
	}


};
//宝石镶嵌回应封装类
[System.Serializable]
public class BagRpcEquipInlayGemReplyWraper
{

	//构造函数
	public BagRpcEquipInlayGemReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;
		 m_GemId = -1;
		 m_GemPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;
		 m_GemId = -1;
		 m_GemPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipInlayGemReply ToPB()
	{
		BagRpcEquipInlayGemReply v = new BagRpcEquipInlayGemReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.SlotPos = m_SlotPos;
		v.GemId = m_GemId;
		v.GemPos = m_GemPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipInlayGemReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_SlotPos = v.SlotPos;
		m_GemId = v.GemId;
		m_GemPos = v.GemPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipInlayGemReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipInlayGemReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipInlayGemReply>(protoMS);
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
	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//槽位位置
	public int m_SlotPos;
	public int SlotPos
	{
		get { return m_SlotPos;}
		set { m_SlotPos = value; }
	}
	//宝石id
	public int m_GemId;
	public int GemId
	{
		get { return m_GemId;}
		set { m_GemId = value; }
	}
	//在背包中的位置
	public int m_GemPos;
	public int GemPos
	{
		get { return m_GemPos;}
		set { m_GemPos = value; }
	}


};
//装备宝石槽位打孔请求封装类
[System.Serializable]
public class BagRpcEquipGemSlotUnlockAskWraper
{

	//构造函数
	public BagRpcEquipGemSlotUnlockAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipGemSlotUnlockAsk ToPB()
	{
		BagRpcEquipGemSlotUnlockAsk v = new BagRpcEquipGemSlotUnlockAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.SlotPos = m_SlotPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipGemSlotUnlockAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_SlotPos = v.SlotPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipGemSlotUnlockAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipGemSlotUnlockAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipGemSlotUnlockAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//槽位位置
	public int m_SlotPos;
	public int SlotPos
	{
		get { return m_SlotPos;}
		set { m_SlotPos = value; }
	}


};
//装备宝石槽位打孔回应封装类
[System.Serializable]
public class BagRpcEquipGemSlotUnlockReplyWraper
{

	//构造函数
	public BagRpcEquipGemSlotUnlockReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipGemSlotUnlockReply ToPB()
	{
		BagRpcEquipGemSlotUnlockReply v = new BagRpcEquipGemSlotUnlockReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.SlotPos = m_SlotPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipGemSlotUnlockReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_SlotPos = v.SlotPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipGemSlotUnlockReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipGemSlotUnlockReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipGemSlotUnlockReply>(protoMS);
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
	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//槽位位置
	public int m_SlotPos;
	public int SlotPos
	{
		get { return m_SlotPos;}
		set { m_SlotPos = value; }
	}


};
//装备强化转移请求封装类
[System.Serializable]
public class BagRpcEquipEnhanceSwapAskWraper
{

	//构造函数
	public BagRpcEquipEnhanceSwapAskWraper()
	{
		 m_TemplateId1 = -1;
		 m_Pos1 = -1;
		 m_TemplateId2 = -1;
		 m_Pos2 = -1;
		 m_BagContainerType1 = -1;
		 m_BagContainerType2 = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId1 = -1;
		 m_Pos1 = -1;
		 m_TemplateId2 = -1;
		 m_Pos2 = -1;
		 m_BagContainerType1 = -1;
		 m_BagContainerType2 = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipEnhanceSwapAsk ToPB()
	{
		BagRpcEquipEnhanceSwapAsk v = new BagRpcEquipEnhanceSwapAsk();
		v.TemplateId1 = m_TemplateId1;
		v.Pos1 = m_Pos1;
		v.TemplateId2 = m_TemplateId2;
		v.Pos2 = m_Pos2;
		v.BagContainerType1 = m_BagContainerType1;
		v.BagContainerType2 = m_BagContainerType2;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipEnhanceSwapAsk v)
	{
        if (v == null)
            return;
		m_TemplateId1 = v.TemplateId1;
		m_Pos1 = v.Pos1;
		m_TemplateId2 = v.TemplateId2;
		m_Pos2 = v.Pos2;
		m_BagContainerType1 = v.BagContainerType1;
		m_BagContainerType2 = v.BagContainerType2;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipEnhanceSwapAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipEnhanceSwapAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipEnhanceSwapAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId1
	public int m_TemplateId1;
	public int TemplateId1
	{
		get { return m_TemplateId1;}
		set { m_TemplateId1 = value; }
	}
	//道具位置1
	public int m_Pos1;
	public int Pos1
	{
		get { return m_Pos1;}
		set { m_Pos1 = value; }
	}
	//TemplateId2
	public int m_TemplateId2;
	public int TemplateId2
	{
		get { return m_TemplateId2;}
		set { m_TemplateId2 = value; }
	}
	//道具位置2
	public int m_Pos2;
	public int Pos2
	{
		get { return m_Pos2;}
		set { m_Pos2 = value; }
	}
	//背包容器类型1
	public int m_BagContainerType1;
	public int BagContainerType1
	{
		get { return m_BagContainerType1;}
		set { m_BagContainerType1 = value; }
	}
	//背包容器类型2
	public int m_BagContainerType2;
	public int BagContainerType2
	{
		get { return m_BagContainerType2;}
		set { m_BagContainerType2 = value; }
	}


};
//装备强化转移回应封装类
[System.Serializable]
public class BagRpcEquipEnhanceSwapReplyWraper
{

	//构造函数
	public BagRpcEquipEnhanceSwapReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId1 = -1;
		 m_Pos1 = -1;
		 m_TemplateId2 = -1;
		 m_Pos2 = -1;
		 m_BagContainerType1 = -1;
		 m_BagContainerType2 = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId1 = -1;
		 m_Pos1 = -1;
		 m_TemplateId2 = -1;
		 m_Pos2 = -1;
		 m_BagContainerType1 = -1;
		 m_BagContainerType2 = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipEnhanceSwapReply ToPB()
	{
		BagRpcEquipEnhanceSwapReply v = new BagRpcEquipEnhanceSwapReply();
		v.Result = m_Result;
		v.TemplateId1 = m_TemplateId1;
		v.Pos1 = m_Pos1;
		v.TemplateId2 = m_TemplateId2;
		v.Pos2 = m_Pos2;
		v.BagContainerType1 = m_BagContainerType1;
		v.BagContainerType2 = m_BagContainerType2;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipEnhanceSwapReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId1 = v.TemplateId1;
		m_Pos1 = v.Pos1;
		m_TemplateId2 = v.TemplateId2;
		m_Pos2 = v.Pos2;
		m_BagContainerType1 = v.BagContainerType1;
		m_BagContainerType2 = v.BagContainerType2;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipEnhanceSwapReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipEnhanceSwapReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipEnhanceSwapReply>(protoMS);
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
	//TemplateId1
	public int m_TemplateId1;
	public int TemplateId1
	{
		get { return m_TemplateId1;}
		set { m_TemplateId1 = value; }
	}
	//道具位置1
	public int m_Pos1;
	public int Pos1
	{
		get { return m_Pos1;}
		set { m_Pos1 = value; }
	}
	//TemplateId2
	public int m_TemplateId2;
	public int TemplateId2
	{
		get { return m_TemplateId2;}
		set { m_TemplateId2 = value; }
	}
	//道具位置2
	public int m_Pos2;
	public int Pos2
	{
		get { return m_Pos2;}
		set { m_Pos2 = value; }
	}
	//背包容器类型1
	public int m_BagContainerType1;
	public int BagContainerType1
	{
		get { return m_BagContainerType1;}
		set { m_BagContainerType1 = value; }
	}
	//背包容器类型2
	public int m_BagContainerType2;
	public int BagContainerType2
	{
		get { return m_BagContainerType2;}
		set { m_BagContainerType2 = value; }
	}


};
//装备宝石移除请求封装类
[System.Serializable]
public class BagRpcEquipGemRemoveAskWraper
{

	//构造函数
	public BagRpcEquipGemRemoveAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipGemRemoveAsk ToPB()
	{
		BagRpcEquipGemRemoveAsk v = new BagRpcEquipGemRemoveAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.SlotPos = m_SlotPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipGemRemoveAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_SlotPos = v.SlotPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipGemRemoveAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipGemRemoveAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipGemRemoveAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//槽位位置
	public int m_SlotPos;
	public int SlotPos
	{
		get { return m_SlotPos;}
		set { m_SlotPos = value; }
	}


};
//装备宝石移除回应封装类
[System.Serializable]
public class BagRpcEquipGemRemoveReplyWraper
{

	//构造函数
	public BagRpcEquipGemRemoveReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_BagContainerType = -1;
		 m_SlotPos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcEquipGemRemoveReply ToPB()
	{
		BagRpcEquipGemRemoveReply v = new BagRpcEquipGemRemoveReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.BagContainerType = m_BagContainerType;
		v.SlotPos = m_SlotPos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcEquipGemRemoveReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_BagContainerType = v.BagContainerType;
		m_SlotPos = v.SlotPos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcEquipGemRemoveReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcEquipGemRemoveReply pb = ProtoBuf.Serializer.Deserialize<BagRpcEquipGemRemoveReply>(protoMS);
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
	//TemplateId
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//道具位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//背包容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//槽位位置
	public int m_SlotPos;
	public int SlotPos
	{
		get { return m_SlotPos;}
		set { m_SlotPos = value; }
	}


};
//存入仓库请求封装类
[System.Serializable]
public class BagRpcBagPutInStorageAskWraper
{

	//构造函数
	public BagRpcBagPutInStorageAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagPutInStorageAsk ToPB()
	{
		BagRpcBagPutInStorageAsk v = new BagRpcBagPutInStorageAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagPutInStorageAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagPutInStorageAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagPutInStorageAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagPutInStorageAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//拆分出来的数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//存入仓库回应封装类
[System.Serializable]
public class BagRpcBagPutInStorageReplyWraper
{

	//构造函数
	public BagRpcBagPutInStorageReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagPutInStorageReply ToPB()
	{
		BagRpcBagPutInStorageReply v = new BagRpcBagPutInStorageReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagPutInStorageReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagPutInStorageReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagPutInStorageReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagPutInStorageReply>(protoMS);
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
	//物品模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//拆分出来的数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//从仓库取出请求封装类
[System.Serializable]
public class BagRpcBagFetchFromStorageAskWraper
{

	//构造函数
	public BagRpcBagFetchFromStorageAskWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagFetchFromStorageAsk ToPB()
	{
		BagRpcBagFetchFromStorageAsk v = new BagRpcBagFetchFromStorageAsk();
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagFetchFromStorageAsk v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagFetchFromStorageAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagFetchFromStorageAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagFetchFromStorageAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//拆分出来的数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//从仓库取出回应封装类
[System.Serializable]
public class BagRpcBagFetchFromStorageReplyWraper
{

	//构造函数
	public BagRpcBagFetchFromStorageReplyWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TemplateId = -1;
		 m_Pos = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagFetchFromStorageReply ToPB()
	{
		BagRpcBagFetchFromStorageReply v = new BagRpcBagFetchFromStorageReply();
		v.Result = m_Result;
		v.TemplateId = m_TemplateId;
		v.Pos = m_Pos;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagFetchFromStorageReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TemplateId = v.TemplateId;
		m_Pos = v.Pos;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagFetchFromStorageReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagFetchFromStorageReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagFetchFromStorageReply>(protoMS);
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
	//物品模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//拆分出来的数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//仓库存钱请求封装类
[System.Serializable]
public class BagRpcBagStorageSaveMoneyAskWraper
{

	//构造函数
	public BagRpcBagStorageSaveMoneyAskWraper()
	{
		 m_Money = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Money = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagStorageSaveMoneyAsk ToPB()
	{
		BagRpcBagStorageSaveMoneyAsk v = new BagRpcBagStorageSaveMoneyAsk();
		v.Money = m_Money;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagStorageSaveMoneyAsk v)
	{
        if (v == null)
            return;
		m_Money = v.Money;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagStorageSaveMoneyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagStorageSaveMoneyAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagStorageSaveMoneyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//钱数
	public int m_Money;
	public int Money
	{
		get { return m_Money;}
		set { m_Money = value; }
	}


};
//仓库存钱回应封装类
[System.Serializable]
public class BagRpcBagStorageSaveMoneyReplyWraper
{

	//构造函数
	public BagRpcBagStorageSaveMoneyReplyWraper()
	{
		 m_Result = -9999;
		 m_Money = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Money = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagStorageSaveMoneyReply ToPB()
	{
		BagRpcBagStorageSaveMoneyReply v = new BagRpcBagStorageSaveMoneyReply();
		v.Result = m_Result;
		v.Money = m_Money;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagStorageSaveMoneyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Money = v.Money;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagStorageSaveMoneyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagStorageSaveMoneyReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagStorageSaveMoneyReply>(protoMS);
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
	//钱数
	public int m_Money;
	public int Money
	{
		get { return m_Money;}
		set { m_Money = value; }
	}


};
//仓库取钱请求封装类
[System.Serializable]
public class BagRpcBagStorageDrawMoneyAskWraper
{

	//构造函数
	public BagRpcBagStorageDrawMoneyAskWraper()
	{
		 m_Money = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Money = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagStorageDrawMoneyAsk ToPB()
	{
		BagRpcBagStorageDrawMoneyAsk v = new BagRpcBagStorageDrawMoneyAsk();
		v.Money = m_Money;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagStorageDrawMoneyAsk v)
	{
        if (v == null)
            return;
		m_Money = v.Money;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagStorageDrawMoneyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagStorageDrawMoneyAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagStorageDrawMoneyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//钱数
	public int m_Money;
	public int Money
	{
		get { return m_Money;}
		set { m_Money = value; }
	}


};
//仓库取钱回应封装类
[System.Serializable]
public class BagRpcBagStorageDrawMoneyReplyWraper
{

	//构造函数
	public BagRpcBagStorageDrawMoneyReplyWraper()
	{
		 m_Result = -9999;
		 m_Money = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Money = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagStorageDrawMoneyReply ToPB()
	{
		BagRpcBagStorageDrawMoneyReply v = new BagRpcBagStorageDrawMoneyReply();
		v.Result = m_Result;
		v.Money = m_Money;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagStorageDrawMoneyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Money = v.Money;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagStorageDrawMoneyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagStorageDrawMoneyReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagStorageDrawMoneyReply>(protoMS);
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
	//钱数
	public int m_Money;
	public int Money
	{
		get { return m_Money;}
		set { m_Money = value; }
	}


};
//仓库整理请求封装类
[System.Serializable]
public class BagRpcStorageTidyAskWraper
{

	//构造函数
	public BagRpcStorageTidyAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BagRpcStorageTidyAsk ToPB()
	{
		BagRpcStorageTidyAsk v = new BagRpcStorageTidyAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcStorageTidyAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcStorageTidyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcStorageTidyAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcStorageTidyAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//仓库整理回应封装类
[System.Serializable]
public class BagRpcStorageTidyReplyWraper
{

	//构造函数
	public BagRpcStorageTidyReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcStorageTidyReply ToPB()
	{
		BagRpcStorageTidyReply v = new BagRpcStorageTidyReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcStorageTidyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcStorageTidyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcStorageTidyReply pb = ProtoBuf.Serializer.Deserialize<BagRpcStorageTidyReply>(protoMS);
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
//法宝铸炼请求封装类
[System.Serializable]
public class BagRpcTalismanLvupAskWraper
{

	//构造函数
	public BagRpcTalismanLvupAskWraper()
	{
		m_CostTalisman = new List<int>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_CostTalisman = new List<int>();

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanLvupAsk ToPB()
	{
		BagRpcTalismanLvupAsk v = new BagRpcTalismanLvupAsk();
		for (int i=0; i<(int)m_CostTalisman.Count; i++)
			v.CostTalisman.Add( m_CostTalisman[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanLvupAsk v)
	{
        if (v == null)
            return;
		m_CostTalisman.Clear();
		for( int i=0; i<v.CostTalisman.Count; i++)
			m_CostTalisman.Add(v.CostTalisman[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanLvupAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanLvupAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanLvupAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//材料法宝在背包中的位置
	public List<int> m_CostTalisman;
	public int SizeCostTalisman()
	{
		return m_CostTalisman.Count;
	}
	public List<int> GetCostTalisman()
	{
		return m_CostTalisman;
	}
	public int GetCostTalisman(int Index)
	{
		if(Index<0 || Index>=(int)m_CostTalisman.Count)
			return -1;
		return m_CostTalisman[Index];
	}
	public void SetCostTalisman( List<int> v )
	{
		m_CostTalisman=v;
	}
	public void SetCostTalisman( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_CostTalisman.Count)
			return;
		m_CostTalisman[Index] = v;
	}
	public void AddCostTalisman( int v=-1 )
	{
		m_CostTalisman.Add(v);
	}
	public void ClearCostTalisman( )
	{
		m_CostTalisman.Clear();
	}


};
//法宝铸炼回应封装类
[System.Serializable]
public class BagRpcTalismanLvupReplyWraper
{

	//构造函数
	public BagRpcTalismanLvupReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanLvupReply ToPB()
	{
		BagRpcTalismanLvupReply v = new BagRpcTalismanLvupReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanLvupReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanLvupReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanLvupReply pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanLvupReply>(protoMS);
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
//法宝传承请求封装类
[System.Serializable]
public class BagRpcTalismanInheritAskWraper
{

	//构造函数
	public BagRpcTalismanInheritAskWraper()
	{
		 m_RightSideTalisman = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_RightSideTalisman = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanInheritAsk ToPB()
	{
		BagRpcTalismanInheritAsk v = new BagRpcTalismanInheritAsk();
		v.RightSideTalisman = m_RightSideTalisman;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanInheritAsk v)
	{
        if (v == null)
            return;
		m_RightSideTalisman = v.RightSideTalisman;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanInheritAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanInheritAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanInheritAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//材料法宝在背包的位置
	public int m_RightSideTalisman;
	public int RightSideTalisman
	{
		get { return m_RightSideTalisman;}
		set { m_RightSideTalisman = value; }
	}


};
//法宝传承回应封装类
[System.Serializable]
public class BagRpcTalismanInheritReplyWraper
{

	//构造函数
	public BagRpcTalismanInheritReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanInheritReply ToPB()
	{
		BagRpcTalismanInheritReply v = new BagRpcTalismanInheritReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanInheritReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanInheritReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanInheritReply pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanInheritReply>(protoMS);
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
//背包获得新物品通知封装类
[System.Serializable]
public class BagRpcBagAddNewItemNotifyWraper
{

	//构造函数
	public BagRpcBagAddNewItemNotifyWraper()
	{
		m_NewItem = new List<BagGridObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_NewItem = new List<BagGridObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagAddNewItemNotify ToPB()
	{
		BagRpcBagAddNewItemNotify v = new BagRpcBagAddNewItemNotify();
		for (int i=0; i<(int)m_NewItem.Count; i++)
			v.NewItem.Add( m_NewItem[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagAddNewItemNotify v)
	{
        if (v == null)
            return;
		m_NewItem.Clear();
		for( int i=0; i<v.NewItem.Count; i++)
			m_NewItem.Add( new BagGridObjWraper());
		for( int i=0; i<v.NewItem.Count; i++)
			m_NewItem[i].FromPB(v.NewItem[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagAddNewItemNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagAddNewItemNotify pb = ProtoBuf.Serializer.Deserialize<BagRpcBagAddNewItemNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品
	public List<BagGridObjWraper> m_NewItem;
	public int SizeNewItem()
	{
		return m_NewItem.Count;
	}
	public List<BagGridObjWraper> GetNewItem()
	{
		return m_NewItem;
	}
	public BagGridObjWraper GetNewItem(int Index)
	{
		if(Index<0 || Index>=(int)m_NewItem.Count)
			return new BagGridObjWraper();
		return m_NewItem[Index];
	}
	public void SetNewItem( List<BagGridObjWraper> v )
	{
		m_NewItem=v;
	}
	public void SetNewItem( int Index, BagGridObjWraper v )
	{
		if(Index<0 || Index>=(int)m_NewItem.Count)
			return;
		m_NewItem[Index] = v;
	}
	public void AddNewItem( BagGridObjWraper v )
	{
		m_NewItem.Add(v);
	}
	public void ClearNewItem( )
	{
		m_NewItem.Clear();
	}


};
//设置自动拾取请求封装类
[System.Serializable]
public class BagRpcBagSetAutoPickupAskWraper
{

	//构造函数
	public BagRpcBagSetAutoPickupAskWraper()
	{
		m_AutoPick = new List<KeyValue2IntBoolWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_AutoPick = new List<KeyValue2IntBoolWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagSetAutoPickupAsk ToPB()
	{
		BagRpcBagSetAutoPickupAsk v = new BagRpcBagSetAutoPickupAsk();
		for (int i=0; i<(int)m_AutoPick.Count; i++)
			v.AutoPick.Add( m_AutoPick[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagSetAutoPickupAsk v)
	{
        if (v == null)
            return;
		m_AutoPick.Clear();
		for( int i=0; i<v.AutoPick.Count; i++)
			m_AutoPick.Add( new KeyValue2IntBoolWraper());
		for( int i=0; i<v.AutoPick.Count; i++)
			m_AutoPick[i].FromPB(v.AutoPick[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagSetAutoPickupAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagSetAutoPickupAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcBagSetAutoPickupAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//自动拾取
	public List<KeyValue2IntBoolWraper> m_AutoPick;
	public int SizeAutoPick()
	{
		return m_AutoPick.Count;
	}
	public List<KeyValue2IntBoolWraper> GetAutoPick()
	{
		return m_AutoPick;
	}
	public KeyValue2IntBoolWraper GetAutoPick(int Index)
	{
		if(Index<0 || Index>=(int)m_AutoPick.Count)
			return new KeyValue2IntBoolWraper();
		return m_AutoPick[Index];
	}
	public void SetAutoPick( List<KeyValue2IntBoolWraper> v )
	{
		m_AutoPick=v;
	}
	public void SetAutoPick( int Index, KeyValue2IntBoolWraper v )
	{
		if(Index<0 || Index>=(int)m_AutoPick.Count)
			return;
		m_AutoPick[Index] = v;
	}
	public void AddAutoPick( KeyValue2IntBoolWraper v )
	{
		m_AutoPick.Add(v);
	}
	public void ClearAutoPick( )
	{
		m_AutoPick.Clear();
	}


};
//设置自动拾取回应封装类
[System.Serializable]
public class BagRpcBagSetAutoPickupReplyWraper
{

	//构造函数
	public BagRpcBagSetAutoPickupReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagSetAutoPickupReply ToPB()
	{
		BagRpcBagSetAutoPickupReply v = new BagRpcBagSetAutoPickupReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagSetAutoPickupReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagSetAutoPickupReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagSetAutoPickupReply pb = ProtoBuf.Serializer.Deserialize<BagRpcBagSetAutoPickupReply>(protoMS);
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
//获得新物品通知封装类
[System.Serializable]
public class BagRpcGetNewItemNotifyWraper
{

	//构造函数
	public BagRpcGetNewItemNotifyWraper()
	{
		m_Item = new List<KeyValue2IntIntWraper>();
		 m_ModuleId = -1;
		 m_PathWayId = -1;
		 m_ModuleParam = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_Item = new List<KeyValue2IntIntWraper>();
		 m_ModuleId = -1;
		 m_PathWayId = -1;
		 m_ModuleParam = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcGetNewItemNotify ToPB()
	{
		BagRpcGetNewItemNotify v = new BagRpcGetNewItemNotify();
		for (int i=0; i<(int)m_Item.Count; i++)
			v.Item.Add( m_Item[i].ToPB());
		v.ModuleId = m_ModuleId;
		v.PathWayId = m_PathWayId;
		v.ModuleParam = m_ModuleParam;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcGetNewItemNotify v)
	{
        if (v == null)
            return;
		m_Item.Clear();
		for( int i=0; i<v.Item.Count; i++)
			m_Item.Add( new KeyValue2IntIntWraper());
		for( int i=0; i<v.Item.Count; i++)
			m_Item[i].FromPB(v.Item[i]);
		m_ModuleId = v.ModuleId;
		m_PathWayId = v.PathWayId;
		m_ModuleParam = v.ModuleParam;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcGetNewItemNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcGetNewItemNotify pb = ProtoBuf.Serializer.Deserialize<BagRpcGetNewItemNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品
	public List<KeyValue2IntIntWraper> m_Item;
	public int SizeItem()
	{
		return m_Item.Count;
	}
	public List<KeyValue2IntIntWraper> GetItem()
	{
		return m_Item;
	}
	public KeyValue2IntIntWraper GetItem(int Index)
	{
		if(Index<0 || Index>=(int)m_Item.Count)
			return new KeyValue2IntIntWraper();
		return m_Item[Index];
	}
	public void SetItem( List<KeyValue2IntIntWraper> v )
	{
		m_Item=v;
	}
	public void SetItem( int Index, KeyValue2IntIntWraper v )
	{
		if(Index<0 || Index>=(int)m_Item.Count)
			return;
		m_Item[Index] = v;
	}
	public void AddItem( KeyValue2IntIntWraper v )
	{
		m_Item.Add(v);
	}
	public void ClearItem( )
	{
		m_Item.Clear();
	}
	//模块Id
	public int m_ModuleId;
	public int ModuleId
	{
		get { return m_ModuleId;}
		set { m_ModuleId = value; }
	}
	//获得途径Id
	public int m_PathWayId;
	public int PathWayId
	{
		get { return m_PathWayId;}
		set { m_PathWayId = value; }
	}
	//模块参数
	public int m_ModuleParam;
	public int ModuleParam
	{
		get { return m_ModuleParam;}
		set { m_ModuleParam = value; }
	}


};
//背包错误通知封装类
[System.Serializable]
public class BagRpcBagErrorNotifyWraper
{

	//构造函数
	public BagRpcBagErrorNotifyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcBagErrorNotify ToPB()
	{
		BagRpcBagErrorNotify v = new BagRpcBagErrorNotify();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcBagErrorNotify v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcBagErrorNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcBagErrorNotify pb = ProtoBuf.Serializer.Deserialize<BagRpcBagErrorNotify>(protoMS);
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
//炼星请求封装类
[System.Serializable]
public class BagRpcTalismanRefindStarAskWraper
{

	//构造函数
	public BagRpcTalismanRefindStarAskWraper()
	{
		 m_FabaoId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_FabaoId = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanRefindStarAsk ToPB()
	{
		BagRpcTalismanRefindStarAsk v = new BagRpcTalismanRefindStarAsk();
		v.FabaoId = m_FabaoId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanRefindStarAsk v)
	{
        if (v == null)
            return;
		m_FabaoId = v.FabaoId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanRefindStarAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanRefindStarAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanRefindStarAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//法宝实例Id
	public long m_FabaoId;
	public long FabaoId
	{
		get { return m_FabaoId;}
		set { m_FabaoId = value; }
	}


};
//炼星回应封装类
[System.Serializable]
public class BagRpcTalismanRefindStarReplyWraper
{

	//构造函数
	public BagRpcTalismanRefindStarReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanRefindStarReply ToPB()
	{
		BagRpcTalismanRefindStarReply v = new BagRpcTalismanRefindStarReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanRefindStarReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanRefindStarReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanRefindStarReply pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanRefindStarReply>(protoMS);
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
//升级聚灵槽位技能请求封装类
[System.Serializable]
public class BagRpcTalismanUpSlotSkillLevelAskWraper
{

	//构造函数
	public BagRpcTalismanUpSlotSkillLevelAskWraper()
	{
		 m_FabaoId = -1;
		 m_SlotId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_FabaoId = -1;
		 m_SlotId = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanUpSlotSkillLevelAsk ToPB()
	{
		BagRpcTalismanUpSlotSkillLevelAsk v = new BagRpcTalismanUpSlotSkillLevelAsk();
		v.FabaoId = m_FabaoId;
		v.SlotId = m_SlotId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanUpSlotSkillLevelAsk v)
	{
        if (v == null)
            return;
		m_FabaoId = v.FabaoId;
		m_SlotId = v.SlotId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanUpSlotSkillLevelAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanUpSlotSkillLevelAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanUpSlotSkillLevelAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//法宝实例ID
	public long m_FabaoId;
	public long FabaoId
	{
		get { return m_FabaoId;}
		set { m_FabaoId = value; }
	}
	//聚灵槽位Id
	public int m_SlotId;
	public int SlotId
	{
		get { return m_SlotId;}
		set { m_SlotId = value; }
	}


};
//升级聚灵槽位技能回应封装类
[System.Serializable]
public class BagRpcTalismanUpSlotSkillLevelReplyWraper
{

	//构造函数
	public BagRpcTalismanUpSlotSkillLevelReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanUpSlotSkillLevelReply ToPB()
	{
		BagRpcTalismanUpSlotSkillLevelReply v = new BagRpcTalismanUpSlotSkillLevelReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanUpSlotSkillLevelReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanUpSlotSkillLevelReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanUpSlotSkillLevelReply pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanUpSlotSkillLevelReply>(protoMS);
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
//属性变化通知通知封装类
[System.Serializable]
public class BagRpcTalismanAttrChangeNotifyWraper
{

	//构造函数
	public BagRpcTalismanAttrChangeNotifyWraper()
	{
		m_Attr = new List<KeyValue2IntIntWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_Attr = new List<KeyValue2IntIntWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanAttrChangeNotify ToPB()
	{
		BagRpcTalismanAttrChangeNotify v = new BagRpcTalismanAttrChangeNotify();
		for (int i=0; i<(int)m_Attr.Count; i++)
			v.Attr.Add( m_Attr[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanAttrChangeNotify v)
	{
        if (v == null)
            return;
		m_Attr.Clear();
		for( int i=0; i<v.Attr.Count; i++)
			m_Attr.Add( new KeyValue2IntIntWraper());
		for( int i=0; i<v.Attr.Count; i++)
			m_Attr[i].FromPB(v.Attr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanAttrChangeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanAttrChangeNotify pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanAttrChangeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//属性值
	public List<KeyValue2IntIntWraper> m_Attr;
	public int SizeAttr()
	{
		return m_Attr.Count;
	}
	public List<KeyValue2IntIntWraper> GetAttr()
	{
		return m_Attr;
	}
	public KeyValue2IntIntWraper GetAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_Attr.Count)
			return new KeyValue2IntIntWraper();
		return m_Attr[Index];
	}
	public void SetAttr( List<KeyValue2IntIntWraper> v )
	{
		m_Attr=v;
	}
	public void SetAttr( int Index, KeyValue2IntIntWraper v )
	{
		if(Index<0 || Index>=(int)m_Attr.Count)
			return;
		m_Attr[Index] = v;
	}
	public void AddAttr( KeyValue2IntIntWraper v )
	{
		m_Attr.Add(v);
	}
	public void ClearAttr( )
	{
		m_Attr.Clear();
	}


};
//宝石聚灵请求封装类
[System.Serializable]
public class BagRpcTalismanGatherSpriteAskWraper
{

	//构造函数
	public BagRpcTalismanGatherSpriteAskWraper()
	{
		 m_FabaoId = -1;
		 m_GatherSpriteId = -1;
		 m_SlotId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_FabaoId = -1;
		 m_GatherSpriteId = -1;
		 m_SlotId = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanGatherSpriteAsk ToPB()
	{
		BagRpcTalismanGatherSpriteAsk v = new BagRpcTalismanGatherSpriteAsk();
		v.FabaoId = m_FabaoId;
		v.GatherSpriteId = m_GatherSpriteId;
		v.SlotId = m_SlotId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanGatherSpriteAsk v)
	{
        if (v == null)
            return;
		m_FabaoId = v.FabaoId;
		m_GatherSpriteId = v.GatherSpriteId;
		m_SlotId = v.SlotId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanGatherSpriteAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanGatherSpriteAsk pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanGatherSpriteAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//法宝Id
	public long m_FabaoId;
	public long FabaoId
	{
		get { return m_FabaoId;}
		set { m_FabaoId = value; }
	}
	//聚灵技能Id
	public int m_GatherSpriteId;
	public int GatherSpriteId
	{
		get { return m_GatherSpriteId;}
		set { m_GatherSpriteId = value; }
	}
	//聚灵槽位ID
	public int m_SlotId;
	public int SlotId
	{
		get { return m_SlotId;}
		set { m_SlotId = value; }
	}


};
//宝石聚灵回应封装类
[System.Serializable]
public class BagRpcTalismanGatherSpriteReplyWraper
{

	//构造函数
	public BagRpcTalismanGatherSpriteReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BagRpcTalismanGatherSpriteReply ToPB()
	{
		BagRpcTalismanGatherSpriteReply v = new BagRpcTalismanGatherSpriteReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRpcTalismanGatherSpriteReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRpcTalismanGatherSpriteReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRpcTalismanGatherSpriteReply pb = ProtoBuf.Serializer.Deserialize<BagRpcTalismanGatherSpriteReply>(protoMS);
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
