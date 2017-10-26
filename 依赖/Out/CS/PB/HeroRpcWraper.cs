
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBHero.cs
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


//英雄数据更新请求封装类
[System.Serializable]
public class HeroRpcSyncDataAskWraper
{

	//构造函数
	public HeroRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public HeroRpcSyncDataAsk ToPB()
	{
		HeroRpcSyncDataAsk v = new HeroRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//英雄数据更新回应封装类
[System.Serializable]
public class HeroRpcSyncDataReplyWraper
{

	//构造函数
	public HeroRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcSyncDataReply ToPB()
	{
		HeroRpcSyncDataReply v = new HeroRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcSyncDataReply>(protoMS);
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
//合成请求封装类
[System.Serializable]
public class HeroRpcComposeAskWraper
{

	//构造函数
	public HeroRpcComposeAskWraper()
	{
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcComposeAsk ToPB()
	{
		HeroRpcComposeAsk v = new HeroRpcComposeAsk();
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcComposeAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcComposeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcComposeAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcComposeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//合成回应封装类
[System.Serializable]
public class HeroRpcComposeReplyWraper
{

	//构造函数
	public HeroRpcComposeReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcComposeReply ToPB()
	{
		HeroRpcComposeReply v = new HeroRpcComposeReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcComposeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcComposeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcComposeReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcComposeReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//升级请求封装类
[System.Serializable]
public class HeroRpcLvUpAskWraper
{

	//构造函数
	public HeroRpcLvUpAskWraper()
	{
		 m_HerdId = -1;
		 m_ItemId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;
		 m_ItemId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcLvUpAsk ToPB()
	{
		HeroRpcLvUpAsk v = new HeroRpcLvUpAsk();
		v.HerdId = m_HerdId;
		v.ItemId = m_ItemId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcLvUpAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;
		m_ItemId = v.ItemId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcLvUpAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//升级道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}


};
//升级回应封装类
[System.Serializable]
public class HeroRpcLvUpReplyWraper
{

	//构造函数
	public HeroRpcLvUpReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_ItemId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_ItemId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcLvUpReply ToPB()
	{
		HeroRpcLvUpReply v = new HeroRpcLvUpReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;
		v.ItemId = m_ItemId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;
		m_ItemId = v.ItemId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcLvUpReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcLvUpReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//升级道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}


};
//英雄升星请求封装类
[System.Serializable]
public class HeroRpcStarLvUpAskWraper
{

	//构造函数
	public HeroRpcStarLvUpAskWraper()
	{
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcStarLvUpAsk ToPB()
	{
		HeroRpcStarLvUpAsk v = new HeroRpcStarLvUpAsk();
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcStarLvUpAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcStarLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcStarLvUpAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcStarLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//英雄升星回应封装类
[System.Serializable]
public class HeroRpcStarLvUpReplyWraper
{

	//构造函数
	public HeroRpcStarLvUpReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcStarLvUpReply ToPB()
	{
		HeroRpcStarLvUpReply v = new HeroRpcStarLvUpReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcStarLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcStarLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcStarLvUpReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcStarLvUpReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//星阶进化请求封装类
[System.Serializable]
public class HeroRpcStarStageUpAskWraper
{

	//构造函数
	public HeroRpcStarStageUpAskWraper()
	{
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcStarStageUpAsk ToPB()
	{
		HeroRpcStarStageUpAsk v = new HeroRpcStarStageUpAsk();
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcStarStageUpAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcStarStageUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcStarStageUpAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcStarStageUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//星阶进化回应封装类
[System.Serializable]
public class HeroRpcStarStageUpReplyWraper
{

	//构造函数
	public HeroRpcStarStageUpReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcStarStageUpReply ToPB()
	{
		HeroRpcStarStageUpReply v = new HeroRpcStarStageUpReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcStarStageUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcStarStageUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcStarStageUpReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcStarStageUpReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//碎片转化请求封装类
[System.Serializable]
public class HeroRpcDebrisChangeAskWraper
{

	//构造函数
	public HeroRpcDebrisChangeAskWraper()
	{
		 m_HerdId = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcDebrisChangeAsk ToPB()
	{
		HeroRpcDebrisChangeAsk v = new HeroRpcDebrisChangeAsk();
		v.HerdId = m_HerdId;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcDebrisChangeAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcDebrisChangeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcDebrisChangeAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcDebrisChangeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//次数
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//碎片转化回应封装类
[System.Serializable]
public class HeroRpcDebrisChangeReplyWraper
{

	//构造函数
	public HeroRpcDebrisChangeReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcDebrisChangeReply ToPB()
	{
		HeroRpcDebrisChangeReply v = new HeroRpcDebrisChangeReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcDebrisChangeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcDebrisChangeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcDebrisChangeReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcDebrisChangeReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//次数
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//天命穿戴请求封装类
[System.Serializable]
public class HeroRpcDestinyEuipAskWraper
{

	//构造函数
	public HeroRpcDestinyEuipAskWraper()
	{
		 m_HerdId = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcDestinyEuipAsk ToPB()
	{
		HeroRpcDestinyEuipAsk v = new HeroRpcDestinyEuipAsk();
		v.HerdId = m_HerdId;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcDestinyEuipAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcDestinyEuipAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcDestinyEuipAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcDestinyEuipAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//位置 -1为穿戴所有
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//天命穿戴回应封装类
[System.Serializable]
public class HeroRpcDestinyEuipReplyWraper
{

	//构造函数
	public HeroRpcDestinyEuipReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcDestinyEuipReply ToPB()
	{
		HeroRpcDestinyEuipReply v = new HeroRpcDestinyEuipReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcDestinyEuipReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcDestinyEuipReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcDestinyEuipReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcDestinyEuipReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//位置 -1为穿戴所有
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//天命升级请求封装类
[System.Serializable]
public class HeroRpcDestinyLvUpAskWraper
{

	//构造函数
	public HeroRpcDestinyLvUpAskWraper()
	{
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcDestinyLvUpAsk ToPB()
	{
		HeroRpcDestinyLvUpAsk v = new HeroRpcDestinyLvUpAsk();
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcDestinyLvUpAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcDestinyLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcDestinyLvUpAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcDestinyLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//天命升级回应封装类
[System.Serializable]
public class HeroRpcDestinyLvUpReplyWraper
{

	//构造函数
	public HeroRpcDestinyLvUpReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcDestinyLvUpReply ToPB()
	{
		HeroRpcDestinyLvUpReply v = new HeroRpcDestinyLvUpReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcDestinyLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcDestinyLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcDestinyLvUpReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcDestinyLvUpReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}


};
//附魔请求封装类
[System.Serializable]
public class HeroRpcAddMagicAskWraper
{

	//构造函数
	public HeroRpcAddMagicAskWraper()
	{
		 m_HerdId = -1;
		 m_StonePos = -1;
		m_ItemId = new List<int>();
		m_Pos = new List<int>();
		 m_Type = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;
		 m_StonePos = -1;
		m_ItemId = new List<int>();
		m_Pos = new List<int>();
		 m_Type = 0;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcAddMagicAsk ToPB()
	{
		HeroRpcAddMagicAsk v = new HeroRpcAddMagicAsk();
		v.HerdId = m_HerdId;
		v.StonePos = m_StonePos;
		for (int i=0; i<(int)m_ItemId.Count; i++)
			v.ItemId.Add( m_ItemId[i]);
		for (int i=0; i<(int)m_Pos.Count; i++)
			v.Pos.Add( m_Pos[i]);
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcAddMagicAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;
		m_StonePos = v.StonePos;
		m_ItemId.Clear();
		for( int i=0; i<v.ItemId.Count; i++)
			m_ItemId.Add(v.ItemId[i]);
		m_Pos.Clear();
		for( int i=0; i<v.Pos.Count; i++)
			m_Pos.Add(v.Pos[i]);
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcAddMagicAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcAddMagicAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcAddMagicAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//星石位置
	public int m_StonePos;
	public int StonePos
	{
		get { return m_StonePos;}
		set { m_StonePos = value; }
	}
	//道具id
	public List<int> m_ItemId;
	public int SizeItemId()
	{
		return m_ItemId.Count;
	}
	public List<int> GetItemId()
	{
		return m_ItemId;
	}
	public int GetItemId(int Index)
	{
		if(Index<0 || Index>=(int)m_ItemId.Count)
			return -1;
		return m_ItemId[Index];
	}
	public void SetItemId( List<int> v )
	{
		m_ItemId=v;
	}
	public void SetItemId( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_ItemId.Count)
			return;
		m_ItemId[Index] = v;
	}
	public void AddItemId( int v=-1 )
	{
		m_ItemId.Add(v);
	}
	public void ClearItemId( )
	{
		m_ItemId.Clear();
	}
	//物品位置
	public List<int> m_Pos;
	public int SizePos()
	{
		return m_Pos.Count;
	}
	public List<int> GetPos()
	{
		return m_Pos;
	}
	public int GetPos(int Index)
	{
		if(Index<0 || Index>=(int)m_Pos.Count)
			return -1;
		return m_Pos[Index];
	}
	public void SetPos( List<int> v )
	{
		m_Pos=v;
	}
	public void SetPos( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_Pos.Count)
			return;
		m_Pos[Index] = v;
	}
	public void AddPos( int v=-1 )
	{
		m_Pos.Add(v);
	}
	public void ClearPos( )
	{
		m_Pos.Clear();
	}
	//附魔类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//附魔回应封装类
[System.Serializable]
public class HeroRpcAddMagicReplyWraper
{

	//构造函数
	public HeroRpcAddMagicReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_StarStoneId = -1;
		 m_ItemId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_StarStoneId = -1;
		 m_ItemId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcAddMagicReply ToPB()
	{
		HeroRpcAddMagicReply v = new HeroRpcAddMagicReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;
		v.StarStoneId = m_StarStoneId;
		v.ItemId = m_ItemId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcAddMagicReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;
		m_StarStoneId = v.StarStoneId;
		m_ItemId = v.ItemId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcAddMagicReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcAddMagicReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcAddMagicReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//星石id
	public int m_StarStoneId;
	public int StarStoneId
	{
		get { return m_StarStoneId;}
		set { m_StarStoneId = value; }
	}
	//道具id
	public int m_ItemId;
	public int ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}


};
//技能升级请求封装类
[System.Serializable]
public class HeroRpcSkillLvUpAskWraper
{

	//构造函数
	public HeroRpcSkillLvUpAskWraper()
	{
		 m_HerdId = -1;
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HerdId = -1;
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcSkillLvUpAsk ToPB()
	{
		HeroRpcSkillLvUpAsk v = new HeroRpcSkillLvUpAsk();
		v.HerdId = m_HerdId;
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcSkillLvUpAsk v)
	{
        if (v == null)
            return;
		m_HerdId = v.HerdId;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcSkillLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcSkillLvUpAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcSkillLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//技能id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//技能升级回应封装类
[System.Serializable]
public class HeroRpcSkillLvUpReplyWraper
{

	//构造函数
	public HeroRpcSkillLvUpReplyWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_HerdId = -1;
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcSkillLvUpReply ToPB()
	{
		HeroRpcSkillLvUpReply v = new HeroRpcSkillLvUpReply();
		v.Result = m_Result;
		v.HerdId = m_HerdId;
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcSkillLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_HerdId = v.HerdId;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcSkillLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcSkillLvUpReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcSkillLvUpReply>(protoMS);
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
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//技能id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//武圣升级请求封装类
[System.Serializable]
public class HeroRpcWuShengLvUpAskWraper
{

	//构造函数
	public HeroRpcWuShengLvUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public HeroRpcWuShengLvUpAsk ToPB()
	{
		HeroRpcWuShengLvUpAsk v = new HeroRpcWuShengLvUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcWuShengLvUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcWuShengLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcWuShengLvUpAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcWuShengLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//武圣升级回应封装类
[System.Serializable]
public class HeroRpcWuShengLvUpReplyWraper
{

	//构造函数
	public HeroRpcWuShengLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcWuShengLvUpReply ToPB()
	{
		HeroRpcWuShengLvUpReply v = new HeroRpcWuShengLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcWuShengLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcWuShengLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcWuShengLvUpReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcWuShengLvUpReply>(protoMS);
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
//技能点计时请求封装类
[System.Serializable]
public class HeroRpcSkillTimeAskWraper
{

	//构造函数
	public HeroRpcSkillTimeAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public HeroRpcSkillTimeAsk ToPB()
	{
		HeroRpcSkillTimeAsk v = new HeroRpcSkillTimeAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcSkillTimeAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcSkillTimeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcSkillTimeAsk pb = ProtoBuf.Serializer.Deserialize<HeroRpcSkillTimeAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//技能点计时回应封装类
[System.Serializable]
public class HeroRpcSkillTimeReplyWraper
{

	//构造函数
	public HeroRpcSkillTimeReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public HeroRpcSkillTimeReply ToPB()
	{
		HeroRpcSkillTimeReply v = new HeroRpcSkillTimeReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroRpcSkillTimeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroRpcSkillTimeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroRpcSkillTimeReply pb = ProtoBuf.Serializer.Deserialize<HeroRpcSkillTimeReply>(protoMS);
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
