
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBChat.cs
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


//发送聊天请求封装类
[System.Serializable]
public class ChatRpcSendChatAskWraper
{

	//构造函数
	public ChatRpcSendChatAskWraper()
	{
		 m_ChatMsg = new ChatMsgObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ChatMsg = new ChatMsgObjWraper();

	}

 	//转化成Protobuffer类型函数
	public ChatRpcSendChatAsk ToPB()
	{
		ChatRpcSendChatAsk v = new ChatRpcSendChatAsk();
		v.ChatMsg = m_ChatMsg.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatRpcSendChatAsk v)
	{
        if (v == null)
            return;
		m_ChatMsg.FromPB(v.ChatMsg);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatRpcSendChatAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatRpcSendChatAsk pb = ProtoBuf.Serializer.Deserialize<ChatRpcSendChatAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//聊天消息
	public ChatMsgObjWraper m_ChatMsg;
	public ChatMsgObjWraper ChatMsg
	{
		get { return m_ChatMsg;}
		set { m_ChatMsg = value; }
	}


};
//发送聊天回应封装类
[System.Serializable]
public class ChatRpcSendChatReplyWraper
{

	//构造函数
	public ChatRpcSendChatReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ChatRpcSendChatReply ToPB()
	{
		ChatRpcSendChatReply v = new ChatRpcSendChatReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatRpcSendChatReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatRpcSendChatReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatRpcSendChatReply pb = ProtoBuf.Serializer.Deserialize<ChatRpcSendChatReply>(protoMS);
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
//同步聊天通知封装类
[System.Serializable]
public class ChatRpcSyncChatNotifyWraper
{

	//构造函数
	public ChatRpcSyncChatNotifyWraper()
	{
		 m_ChatData = new ChatObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ChatData = new ChatObjWraper();

	}

 	//转化成Protobuffer类型函数
	public ChatRpcSyncChatNotify ToPB()
	{
		ChatRpcSyncChatNotify v = new ChatRpcSyncChatNotify();
		v.ChatData = m_ChatData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatRpcSyncChatNotify v)
	{
        if (v == null)
            return;
		m_ChatData.FromPB(v.ChatData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatRpcSyncChatNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatRpcSyncChatNotify pb = ProtoBuf.Serializer.Deserialize<ChatRpcSyncChatNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//聊天对象
	public ChatObjWraper m_ChatData;
	public ChatObjWraper ChatData
	{
		get { return m_ChatData;}
		set { m_ChatData = value; }
	}


};
//同步私聊留言通知封装类
[System.Serializable]
public class ChatRpcSyncPrivateChatMsgNotifyWraper
{

	//构造函数
	public ChatRpcSyncPrivateChatMsgNotifyWraper()
	{
		m_ChatData = new List<ChatObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_ChatData = new List<ChatObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public ChatRpcSyncPrivateChatMsgNotify ToPB()
	{
		ChatRpcSyncPrivateChatMsgNotify v = new ChatRpcSyncPrivateChatMsgNotify();
		for (int i=0; i<(int)m_ChatData.Count; i++)
			v.ChatData.Add( m_ChatData[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatRpcSyncPrivateChatMsgNotify v)
	{
        if (v == null)
            return;
		m_ChatData.Clear();
		for( int i=0; i<v.ChatData.Count; i++)
			m_ChatData.Add( new ChatObjWraper());
		for( int i=0; i<v.ChatData.Count; i++)
			m_ChatData[i].FromPB(v.ChatData[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatRpcSyncPrivateChatMsgNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatRpcSyncPrivateChatMsgNotify pb = ProtoBuf.Serializer.Deserialize<ChatRpcSyncPrivateChatMsgNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//聊天对象
	public List<ChatObjWraper> m_ChatData;
	public int SizeChatData()
	{
		return m_ChatData.Count;
	}
	public List<ChatObjWraper> GetChatData()
	{
		return m_ChatData;
	}
	public ChatObjWraper GetChatData(int Index)
	{
		if(Index<0 || Index>=(int)m_ChatData.Count)
			return new ChatObjWraper();
		return m_ChatData[Index];
	}
	public void SetChatData( List<ChatObjWraper> v )
	{
		m_ChatData=v;
	}
	public void SetChatData( int Index, ChatObjWraper v )
	{
		if(Index<0 || Index>=(int)m_ChatData.Count)
			return;
		m_ChatData[Index] = v;
	}
	public void AddChatData( ChatObjWraper v )
	{
		m_ChatData.Add(v);
	}
	public void ClearChatData( )
	{
		m_ChatData.Clear();
	}


};
//服务器发送聊天通知封装类
[System.Serializable]
public class ChatRpcSvrChatNotifyWraper
{

	//构造函数
	public ChatRpcSvrChatNotifyWraper()
	{
		 m_ChatData = new ChatNetDataWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ChatData = new ChatNetDataWraper();

	}

 	//转化成Protobuffer类型函数
	public ChatRpcSvrChatNotify ToPB()
	{
		ChatRpcSvrChatNotify v = new ChatRpcSvrChatNotify();
		v.ChatData = m_ChatData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatRpcSvrChatNotify v)
	{
        if (v == null)
            return;
		m_ChatData.FromPB(v.ChatData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatRpcSvrChatNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatRpcSvrChatNotify pb = ProtoBuf.Serializer.Deserialize<ChatRpcSvrChatNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//聊天对象
	public ChatNetDataWraper m_ChatData;
	public ChatNetDataWraper ChatData
	{
		get { return m_ChatData;}
		set { m_ChatData = value; }
	}


};
//聊天功能1, 帮会求助封装类
[System.Serializable]
public class ChatRpcChatFun1Wraper
{

	//构造函数
	public ChatRpcChatFun1Wraper()
	{
		 m_TargetUserId = -1;
		 m_TemplateId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TargetUserId = -1;
		 m_TemplateId = -1;

	}

 	//转化成Protobuffer类型函数
	public ChatRpcChatFun1 ToPB()
	{
		ChatRpcChatFun1 v = new ChatRpcChatFun1();
		v.TargetUserId = m_TargetUserId;
		v.TemplateId = m_TemplateId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatRpcChatFun1 v)
	{
        if (v == null)
            return;
		m_TargetUserId = v.TargetUserId;
		m_TemplateId = v.TemplateId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatRpcChatFun1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatRpcChatFun1 pb = ProtoBuf.Serializer.Deserialize<ChatRpcChatFun1>(protoMS);
		FromPB(pb);
		return true;
	}

	//对方UserId
	public long m_TargetUserId;
	public long TargetUserId
	{
		get { return m_TargetUserId;}
		set { m_TargetUserId = value; }
	}
	//物品ID
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}


};
