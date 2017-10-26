
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBDungeon.cs
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


//进入请求封装类
[System.Serializable]
public class DungeonRpcEnterAskWraper
{

	//构造函数
	public DungeonRpcEnterAskWraper()
	{
		 m_DungeonId = -1;
		 m_DungeonType = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = -1;
		 m_GuildId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;
		 m_DungeonType = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = -1;
		 m_GuildId = -1;

	}

 	//转化成Protobuffer类型函数
	public DungeonRpcEnterAsk ToPB()
	{
		DungeonRpcEnterAsk v = new DungeonRpcEnterAsk();
		v.DungeonId = m_DungeonId;
		v.DungeonType = m_DungeonType;
		v.BirthPoint = m_BirthPoint;
		v.FaceDir = m_FaceDir;
		v.GuildId = m_GuildId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DungeonRpcEnterAsk v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;
		m_DungeonType = v.DungeonType;
		m_BirthPoint = v.BirthPoint;
		m_FaceDir = v.FaceDir;
		m_GuildId = v.GuildId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DungeonRpcEnterAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DungeonRpcEnterAsk pb = ProtoBuf.Serializer.Deserialize<DungeonRpcEnterAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本ID
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//副本类型
	public int m_DungeonType;
	public int DungeonType
	{
		get { return m_DungeonType;}
		set { m_DungeonType = value; }
	}
	//出生点
	public int m_BirthPoint;
	public int BirthPoint
	{
		get { return m_BirthPoint;}
		set { m_BirthPoint = value; }
	}
	//朝向
	public int m_FaceDir;
	public int FaceDir
	{
		get { return m_FaceDir;}
		set { m_FaceDir = value; }
	}
	//帮会Id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}


};
//进入回应封装类
[System.Serializable]
public class DungeonRpcEnterReplyWraper
{

	//构造函数
	public DungeonRpcEnterReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public DungeonRpcEnterReply ToPB()
	{
		DungeonRpcEnterReply v = new DungeonRpcEnterReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DungeonRpcEnterReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DungeonRpcEnterReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DungeonRpcEnterReply pb = ProtoBuf.Serializer.Deserialize<DungeonRpcEnterReply>(protoMS);
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
//打开副本通知通知封装类
[System.Serializable]
public class DungeonRpcOpenNotifyWraper
{

	//构造函数
	public DungeonRpcOpenNotifyWraper()
	{
		 m_DungeonKey = "";
		 m_Host = "";
		 m_Port = -1;
		 m_DungeonId = -1;
		 m_DungeonType = -1;
		 m_GuildId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonKey = "";
		 m_Host = "";
		 m_Port = -1;
		 m_DungeonId = -1;
		 m_DungeonType = -1;
		 m_GuildId = -1;

	}

 	//转化成Protobuffer类型函数
	public DungeonRpcOpenNotify ToPB()
	{
		DungeonRpcOpenNotify v = new DungeonRpcOpenNotify();
		v.DungeonKey = m_DungeonKey;
		v.Host = m_Host;
		v.Port = m_Port;
		v.DungeonId = m_DungeonId;
		v.DungeonType = m_DungeonType;
		v.GuildId = m_GuildId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DungeonRpcOpenNotify v)
	{
        if (v == null)
            return;
		m_DungeonKey = v.DungeonKey;
		m_Host = v.Host;
		m_Port = v.Port;
		m_DungeonId = v.DungeonId;
		m_DungeonType = v.DungeonType;
		m_GuildId = v.GuildId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DungeonRpcOpenNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DungeonRpcOpenNotify pb = ProtoBuf.Serializer.Deserialize<DungeonRpcOpenNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//Key
	public string m_DungeonKey;
	public string DungeonKey
	{
		get { return m_DungeonKey;}
		set { m_DungeonKey = value; }
	}
	//Host
	public string m_Host;
	public string Host
	{
		get { return m_Host;}
		set { m_Host = value; }
	}
	//Port
	public int m_Port;
	public int Port
	{
		get { return m_Port;}
		set { m_Port = value; }
	}
	//副本ID
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//副本类型
	public int m_DungeonType;
	public int DungeonType
	{
		get { return m_DungeonType;}
		set { m_DungeonType = value; }
	}
	//帮会Id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}


};
//能否进入请求封装类
[System.Serializable]
public class DungeonRpcTryEnterAskWraper
{

	//构造函数
	public DungeonRpcTryEnterAskWraper()
	{
		 m_DungeonId = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = -1;
		 m_GuildId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = -1;
		 m_GuildId = -1;

	}

 	//转化成Protobuffer类型函数
	public DungeonRpcTryEnterAsk ToPB()
	{
		DungeonRpcTryEnterAsk v = new DungeonRpcTryEnterAsk();
		v.DungeonId = m_DungeonId;
		v.BirthPoint = m_BirthPoint;
		v.FaceDir = m_FaceDir;
		v.GuildId = m_GuildId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DungeonRpcTryEnterAsk v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;
		m_BirthPoint = v.BirthPoint;
		m_FaceDir = v.FaceDir;
		m_GuildId = v.GuildId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DungeonRpcTryEnterAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DungeonRpcTryEnterAsk pb = ProtoBuf.Serializer.Deserialize<DungeonRpcTryEnterAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本ID
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//出生点
	public int m_BirthPoint;
	public int BirthPoint
	{
		get { return m_BirthPoint;}
		set { m_BirthPoint = value; }
	}
	//朝向
	public int m_FaceDir;
	public int FaceDir
	{
		get { return m_FaceDir;}
		set { m_FaceDir = value; }
	}
	//帮会Id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}


};
//能否进入回应封装类
[System.Serializable]
public class DungeonRpcTryEnterReplyWraper
{

	//构造函数
	public DungeonRpcTryEnterReplyWraper()
	{
		 m_Result = -9999;
		 m_DungeonId = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = -1;
		 m_GuildId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_DungeonId = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = -1;
		 m_GuildId = -1;

	}

 	//转化成Protobuffer类型函数
	public DungeonRpcTryEnterReply ToPB()
	{
		DungeonRpcTryEnterReply v = new DungeonRpcTryEnterReply();
		v.Result = m_Result;
		v.DungeonId = m_DungeonId;
		v.BirthPoint = m_BirthPoint;
		v.FaceDir = m_FaceDir;
		v.GuildId = m_GuildId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DungeonRpcTryEnterReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_DungeonId = v.DungeonId;
		m_BirthPoint = v.BirthPoint;
		m_FaceDir = v.FaceDir;
		m_GuildId = v.GuildId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DungeonRpcTryEnterReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DungeonRpcTryEnterReply pb = ProtoBuf.Serializer.Deserialize<DungeonRpcTryEnterReply>(protoMS);
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
	//副本ID
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//出生点
	public int m_BirthPoint;
	public int BirthPoint
	{
		get { return m_BirthPoint;}
		set { m_BirthPoint = value; }
	}
	//朝向
	public int m_FaceDir;
	public int FaceDir
	{
		get { return m_FaceDir;}
		set { m_FaceDir = value; }
	}
	//帮会Id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}


};
//传送通知封装类
[System.Serializable]
public class DungeonRpcTransferNotifyWraper
{

	//构造函数
	public DungeonRpcTransferNotifyWraper()
	{
		 m_DungeonId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;

	}

 	//转化成Protobuffer类型函数
	public DungeonRpcTransferNotify ToPB()
	{
		DungeonRpcTransferNotify v = new DungeonRpcTransferNotify();
		v.DungeonId = m_DungeonId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DungeonRpcTransferNotify v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DungeonRpcTransferNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DungeonRpcTransferNotify pb = ProtoBuf.Serializer.Deserialize<DungeonRpcTransferNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本ID
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}


};
