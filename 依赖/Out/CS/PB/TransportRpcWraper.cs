
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBTransport.cs
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
public class TransportRpcSyncDataAskWraper
{

	//构造函数
	public TransportRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TransportRpcSyncDataAsk ToPB()
	{
		TransportRpcSyncDataAsk v = new TransportRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<TransportRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class TransportRpcSyncDataReplyWraper
{

	//构造函数
	public TransportRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcSyncDataReply ToPB()
	{
		TransportRpcSyncDataReply v = new TransportRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<TransportRpcSyncDataReply>(protoMS);
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
//填充请求封装类
[System.Serializable]
public class TransportRpcFillAskWraper
{

	//构造函数
	public TransportRpcFillAskWraper()
	{
		 m_FillID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_FillID = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcFillAsk ToPB()
	{
		TransportRpcFillAsk v = new TransportRpcFillAsk();
		v.FillID = m_FillID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcFillAsk v)
	{
        if (v == null)
            return;
		m_FillID = v.FillID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcFillAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcFillAsk pb = ProtoBuf.Serializer.Deserialize<TransportRpcFillAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品ID
	public int m_FillID;
	public int FillID
	{
		get { return m_FillID;}
		set { m_FillID = value; }
	}


};
//填充回应封装类
[System.Serializable]
public class TransportRpcFillReplyWraper
{

	//构造函数
	public TransportRpcFillReplyWraper()
	{
		 m_Result = -9999;
		 m_FillID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_FillID = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcFillReply ToPB()
	{
		TransportRpcFillReply v = new TransportRpcFillReply();
		v.Result = m_Result;
		v.FillID = m_FillID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcFillReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_FillID = v.FillID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcFillReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcFillReply pb = ProtoBuf.Serializer.Deserialize<TransportRpcFillReply>(protoMS);
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
	//物品ID
	public int m_FillID;
	public int FillID
	{
		get { return m_FillID;}
		set { m_FillID = value; }
	}


};
//帮助请求请求封装类
[System.Serializable]
public class TransportRpcHelpOtherAskWraper
{

	//构造函数
	public TransportRpcHelpOtherAskWraper()
	{
		 m_ItemID = -1;
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcHelpOtherAsk ToPB()
	{
		TransportRpcHelpOtherAsk v = new TransportRpcHelpOtherAsk();
		v.ItemID = m_ItemID;
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcHelpOtherAsk v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcHelpOtherAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcHelpOtherAsk pb = ProtoBuf.Serializer.Deserialize<TransportRpcHelpOtherAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品ID
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//发起请求的用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//帮助请求回应封装类
[System.Serializable]
public class TransportRpcHelpOtherReplyWraper
{

	//构造函数
	public TransportRpcHelpOtherReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcHelpOtherReply ToPB()
	{
		TransportRpcHelpOtherReply v = new TransportRpcHelpOtherReply();
		v.Result = m_Result;
		v.ItemID = m_ItemID;
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcHelpOtherReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemID = v.ItemID;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcHelpOtherReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcHelpOtherReply pb = ProtoBuf.Serializer.Deserialize<TransportRpcHelpOtherReply>(protoMS);
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
	//物品ID
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//发起请求的用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//请求帮助请求封装类
[System.Serializable]
public class TransportRpcAskHelpAskWraper
{

	//构造函数
	public TransportRpcAskHelpAskWraper()
	{
		 m_ItemID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcAskHelpAsk ToPB()
	{
		TransportRpcAskHelpAsk v = new TransportRpcAskHelpAsk();
		v.ItemID = m_ItemID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcAskHelpAsk v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcAskHelpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcAskHelpAsk pb = ProtoBuf.Serializer.Deserialize<TransportRpcAskHelpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品ID
	public int m_ItemID;
	public int ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}


};
//请求帮助回应封装类
[System.Serializable]
public class TransportRpcAskHelpReplyWraper
{

	//构造函数
	public TransportRpcAskHelpReplyWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_ItemID = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcAskHelpReply ToPB()
	{
		TransportRpcAskHelpReply v = new TransportRpcAskHelpReply();
		v.Result = m_Result;
		v.ItemID = m_ItemID;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcAskHelpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ItemID = v.ItemID;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcAskHelpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcAskHelpReply pb = ProtoBuf.Serializer.Deserialize<TransportRpcAskHelpReply>(protoMS);
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


};
//起航请求请求封装类
[System.Serializable]
public class TransportRpcSetSailAskWraper
{

	//构造函数
	public TransportRpcSetSailAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TransportRpcSetSailAsk ToPB()
	{
		TransportRpcSetSailAsk v = new TransportRpcSetSailAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcSetSailAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcSetSailAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcSetSailAsk pb = ProtoBuf.Serializer.Deserialize<TransportRpcSetSailAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//起航请求回应封装类
[System.Serializable]
public class TransportRpcSetSailReplyWraper
{

	//构造函数
	public TransportRpcSetSailReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcSetSailReply ToPB()
	{
		TransportRpcSetSailReply v = new TransportRpcSetSailReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcSetSailReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcSetSailReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcSetSailReply pb = ProtoBuf.Serializer.Deserialize<TransportRpcSetSailReply>(protoMS);
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
//添加货物请求封装类
[System.Serializable]
public class TransportRpcAddTransportAskWraper
{

	//构造函数
	public TransportRpcAddTransportAskWraper()
	{
		 m_Lv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcAddTransportAsk ToPB()
	{
		TransportRpcAddTransportAsk v = new TransportRpcAddTransportAsk();
		v.Lv = m_Lv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcAddTransportAsk v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcAddTransportAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcAddTransportAsk pb = ProtoBuf.Serializer.Deserialize<TransportRpcAddTransportAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//玩家等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}


};
//添加货物回应封装类
[System.Serializable]
public class TransportRpcAddTransportReplyWraper
{

	//构造函数
	public TransportRpcAddTransportReplyWraper()
	{
		 m_Result = -9999;
		 m_Lv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Lv = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcAddTransportReply ToPB()
	{
		TransportRpcAddTransportReply v = new TransportRpcAddTransportReply();
		v.Result = m_Result;
		v.Lv = m_Lv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcAddTransportReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Lv = v.Lv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcAddTransportReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcAddTransportReply pb = ProtoBuf.Serializer.Deserialize<TransportRpcAddTransportReply>(protoMS);
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
	//玩家等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}


};
//自己被帮助通知通知封装类
[System.Serializable]
public class TransportRpcIsHelpedNotifyWraper
{

	//构造函数
	public TransportRpcIsHelpedNotifyWraper()
	{
		 m_TemplateId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;

	}

 	//转化成Protobuffer类型函数
	public TransportRpcIsHelpedNotify ToPB()
	{
		TransportRpcIsHelpedNotify v = new TransportRpcIsHelpedNotify();
		v.TemplateId = m_TemplateId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TransportRpcIsHelpedNotify v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TransportRpcIsHelpedNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TransportRpcIsHelpedNotify pb = ProtoBuf.Serializer.Deserialize<TransportRpcIsHelpedNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//被帮助物品ID
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}


};
