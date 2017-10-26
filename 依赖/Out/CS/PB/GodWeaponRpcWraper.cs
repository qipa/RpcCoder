
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBGodWeapon.cs
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
public class GodWeaponRpcSyncDataAskWraper
{

	//构造函数
	public GodWeaponRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcSyncDataAsk ToPB()
	{
		GodWeaponRpcSyncDataAsk v = new GodWeaponRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class GodWeaponRpcSyncDataReplyWraper
{

	//构造函数
	public GodWeaponRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcSyncDataReply ToPB()
	{
		GodWeaponRpcSyncDataReply v = new GodWeaponRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcSyncDataReply>(protoMS);
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
//觉醒请求封装类
[System.Serializable]
public class GodWeaponRpcAwakenAskWraper
{

	//构造函数
	public GodWeaponRpcAwakenAskWraper()
	{
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcAwakenAsk ToPB()
	{
		GodWeaponRpcAwakenAsk v = new GodWeaponRpcAwakenAsk();
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcAwakenAsk v)
	{
        if (v == null)
            return;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcAwakenAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcAwakenAsk pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcAwakenAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//神器Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//觉醒回应封装类
[System.Serializable]
public class GodWeaponRpcAwakenReplyWraper
{

	//构造函数
	public GodWeaponRpcAwakenReplyWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcAwakenReply ToPB()
	{
		GodWeaponRpcAwakenReply v = new GodWeaponRpcAwakenReply();
		v.Result = m_Result;
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcAwakenReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcAwakenReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcAwakenReply pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcAwakenReply>(protoMS);
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
	//神器Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//宝石镶嵌请求封装类
[System.Serializable]
public class GodWeaponRpcInlayAskWraper
{

	//构造函数
	public GodWeaponRpcInlayAskWraper()
	{
		 m_Id = -1;
		 m_GemId = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_GemId = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcInlayAsk ToPB()
	{
		GodWeaponRpcInlayAsk v = new GodWeaponRpcInlayAsk();
		v.Id = m_Id;
		v.GemId = m_GemId;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcInlayAsk v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_GemId = v.GemId;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcInlayAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcInlayAsk pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcInlayAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//神器Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//宝石id
	public int m_GemId;
	public int GemId
	{
		get { return m_GemId;}
		set { m_GemId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//宝石镶嵌回应封装类
[System.Serializable]
public class GodWeaponRpcInlayReplyWraper
{

	//构造函数
	public GodWeaponRpcInlayReplyWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;
		 m_GemId = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;
		 m_GemId = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcInlayReply ToPB()
	{
		GodWeaponRpcInlayReply v = new GodWeaponRpcInlayReply();
		v.Result = m_Result;
		v.Id = m_Id;
		v.GemId = m_GemId;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcInlayReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Id = v.Id;
		m_GemId = v.GemId;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcInlayReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcInlayReply pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcInlayReply>(protoMS);
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
	//神器Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//宝石id
	public int m_GemId;
	public int GemId
	{
		get { return m_GemId;}
		set { m_GemId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//卸下宝石请求封装类
[System.Serializable]
public class GodWeaponRpcUnloadAskWraper
{

	//构造函数
	public GodWeaponRpcUnloadAskWraper()
	{
		 m_Id = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcUnloadAsk ToPB()
	{
		GodWeaponRpcUnloadAsk v = new GodWeaponRpcUnloadAsk();
		v.Id = m_Id;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcUnloadAsk v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcUnloadAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcUnloadAsk pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcUnloadAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//神器Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//卸下宝石回应封装类
[System.Serializable]
public class GodWeaponRpcUnloadReplyWraper
{

	//构造函数
	public GodWeaponRpcUnloadReplyWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcUnloadReply ToPB()
	{
		GodWeaponRpcUnloadReply v = new GodWeaponRpcUnloadReply();
		v.Result = m_Result;
		v.Id = m_Id;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcUnloadReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Id = v.Id;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcUnloadReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcUnloadReply pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcUnloadReply>(protoMS);
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
	//神器Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//宝石合成请求封装类
[System.Serializable]
public class GodWeaponRpcCompoundAskWraper
{

	//构造函数
	public GodWeaponRpcCompoundAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcCompoundAsk ToPB()
	{
		GodWeaponRpcCompoundAsk v = new GodWeaponRpcCompoundAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcCompoundAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcCompoundAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcCompoundAsk pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcCompoundAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//宝石合成回应封装类
[System.Serializable]
public class GodWeaponRpcCompoundReplyWraper
{

	//构造函数
	public GodWeaponRpcCompoundReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponRpcCompoundReply ToPB()
	{
		GodWeaponRpcCompoundReply v = new GodWeaponRpcCompoundReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponRpcCompoundReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponRpcCompoundReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponRpcCompoundReply pb = ProtoBuf.Serializer.Deserialize<GodWeaponRpcCompoundReply>(protoMS);
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
