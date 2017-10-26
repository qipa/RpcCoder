
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBFriend.cs
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


//每次打开界面，请求一次数据请求封装类
[System.Serializable]
public class FriendRpcSyncFriendDataAskWraper
{

	//构造函数
	public FriendRpcSyncFriendDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public FriendRpcSyncFriendDataAsk ToPB()
	{
		FriendRpcSyncFriendDataAsk v = new FriendRpcSyncFriendDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcSyncFriendDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcSyncFriendDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcSyncFriendDataAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcSyncFriendDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//每次打开界面，请求一次数据回应封装类
[System.Serializable]
public class FriendRpcSyncFriendDataReplyWraper
{

	//构造函数
	public FriendRpcSyncFriendDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcSyncFriendDataReply ToPB()
	{
		FriendRpcSyncFriendDataReply v = new FriendRpcSyncFriendDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcSyncFriendDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcSyncFriendDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcSyncFriendDataReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcSyncFriendDataReply>(protoMS);
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
//增加好友请求封装类
[System.Serializable]
public class FriendRpcAddFriendAskWraper
{

	//构造函数
	public FriendRpcAddFriendAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcAddFriendAsk ToPB()
	{
		FriendRpcAddFriendAsk v = new FriendRpcAddFriendAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcAddFriendAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcAddFriendAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcAddFriendAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcAddFriendAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//增加好友回应封装类
[System.Serializable]
public class FriendRpcAddFriendReplyWraper
{

	//构造函数
	public FriendRpcAddFriendReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcAddFriendReply ToPB()
	{
		FriendRpcAddFriendReply v = new FriendRpcAddFriendReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcAddFriendReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcAddFriendReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcAddFriendReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcAddFriendReply>(protoMS);
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
//删除好友请求封装类
[System.Serializable]
public class FriendRpcDelFriendAskWraper
{

	//构造函数
	public FriendRpcDelFriendAskWraper()
	{
		m_UserId = new List<long>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_UserId = new List<long>();

	}

 	//转化成Protobuffer类型函数
	public FriendRpcDelFriendAsk ToPB()
	{
		FriendRpcDelFriendAsk v = new FriendRpcDelFriendAsk();
		for (int i=0; i<(int)m_UserId.Count; i++)
			v.UserId.Add( m_UserId[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcDelFriendAsk v)
	{
        if (v == null)
            return;
		m_UserId.Clear();
		for( int i=0; i<v.UserId.Count; i++)
			m_UserId.Add(v.UserId[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcDelFriendAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcDelFriendAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcDelFriendAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public List<long> m_UserId;
	public int SizeUserId()
	{
		return m_UserId.Count;
	}
	public List<long> GetUserId()
	{
		return m_UserId;
	}
	public long GetUserId(int Index)
	{
		if(Index<0 || Index>=(int)m_UserId.Count)
			return -1;
		return m_UserId[Index];
	}
	public void SetUserId( List<long> v )
	{
		m_UserId=v;
	}
	public void SetUserId( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_UserId.Count)
			return;
		m_UserId[Index] = v;
	}
	public void AddUserId( long v=-1 )
	{
		m_UserId.Add(v);
	}
	public void ClearUserId( )
	{
		m_UserId.Clear();
	}


};
//删除好友回应封装类
[System.Serializable]
public class FriendRpcDelFriendReplyWraper
{

	//构造函数
	public FriendRpcDelFriendReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcDelFriendReply ToPB()
	{
		FriendRpcDelFriendReply v = new FriendRpcDelFriendReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcDelFriendReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcDelFriendReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcDelFriendReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcDelFriendReply>(protoMS);
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
//增加黑名单请求封装类
[System.Serializable]
public class FriendRpcAddBlackListAskWraper
{

	//构造函数
	public FriendRpcAddBlackListAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcAddBlackListAsk ToPB()
	{
		FriendRpcAddBlackListAsk v = new FriendRpcAddBlackListAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcAddBlackListAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcAddBlackListAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcAddBlackListAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcAddBlackListAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//增加黑名单回应封装类
[System.Serializable]
public class FriendRpcAddBlackListReplyWraper
{

	//构造函数
	public FriendRpcAddBlackListReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcAddBlackListReply ToPB()
	{
		FriendRpcAddBlackListReply v = new FriendRpcAddBlackListReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcAddBlackListReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcAddBlackListReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcAddBlackListReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcAddBlackListReply>(protoMS);
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
//删除黑名单请求封装类
[System.Serializable]
public class FriendRpcDelBlackListAskWraper
{

	//构造函数
	public FriendRpcDelBlackListAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcDelBlackListAsk ToPB()
	{
		FriendRpcDelBlackListAsk v = new FriendRpcDelBlackListAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcDelBlackListAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcDelBlackListAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcDelBlackListAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcDelBlackListAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//删除黑名单回应封装类
[System.Serializable]
public class FriendRpcDelBlackListReplyWraper
{

	//构造函数
	public FriendRpcDelBlackListReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcDelBlackListReply ToPB()
	{
		FriendRpcDelBlackListReply v = new FriendRpcDelBlackListReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcDelBlackListReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcDelBlackListReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcDelBlackListReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcDelBlackListReply>(protoMS);
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
//增加最近联系人请求封装类
[System.Serializable]
public class FriendRpcAddContactAskWraper
{

	//构造函数
	public FriendRpcAddContactAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcAddContactAsk ToPB()
	{
		FriendRpcAddContactAsk v = new FriendRpcAddContactAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcAddContactAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcAddContactAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcAddContactAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcAddContactAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//增加最近联系人回应封装类
[System.Serializable]
public class FriendRpcAddContactReplyWraper
{

	//构造函数
	public FriendRpcAddContactReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcAddContactReply ToPB()
	{
		FriendRpcAddContactReply v = new FriendRpcAddContactReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcAddContactReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcAddContactReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcAddContactReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcAddContactReply>(protoMS);
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
//删除最近联系人请求封装类
[System.Serializable]
public class FriendRpcDelContactAskWraper
{

	//构造函数
	public FriendRpcDelContactAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcDelContactAsk ToPB()
	{
		FriendRpcDelContactAsk v = new FriendRpcDelContactAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcDelContactAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcDelContactAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcDelContactAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcDelContactAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//删除最近联系人回应封装类
[System.Serializable]
public class FriendRpcDelContactReplyWraper
{

	//构造函数
	public FriendRpcDelContactReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcDelContactReply ToPB()
	{
		FriendRpcDelContactReply v = new FriendRpcDelContactReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcDelContactReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcDelContactReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcDelContactReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcDelContactReply>(protoMS);
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
//搜索好友请求封装类
[System.Serializable]
public class FriendRpcSearchPlayerAskWraper
{

	//构造函数
	public FriendRpcSearchPlayerAskWraper()
	{
		 m_SearchString = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SearchString = "";

	}

 	//转化成Protobuffer类型函数
	public FriendRpcSearchPlayerAsk ToPB()
	{
		FriendRpcSearchPlayerAsk v = new FriendRpcSearchPlayerAsk();
		v.SearchString = m_SearchString;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcSearchPlayerAsk v)
	{
        if (v == null)
            return;
		m_SearchString = v.SearchString;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcSearchPlayerAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcSearchPlayerAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcSearchPlayerAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//搜索内容
	public string m_SearchString;
	public string SearchString
	{
		get { return m_SearchString;}
		set { m_SearchString = value; }
	}


};
//搜索好友回应封装类
[System.Serializable]
public class FriendRpcSearchPlayerReplyWraper
{

	//构造函数
	public FriendRpcSearchPlayerReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcSearchPlayerReply ToPB()
	{
		FriendRpcSearchPlayerReply v = new FriendRpcSearchPlayerReply();
		v.Result = m_Result;
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcSearchPlayerReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcSearchPlayerReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcSearchPlayerReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcSearchPlayerReply>(protoMS);
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
	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}


};
//推荐好友对象封装类
[System.Serializable]
public class FriendRpcRecommendObjWraper
{

	//构造函数
	public FriendRpcRecommendObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcRecommendObj ToPB()
	{
		FriendRpcRecommendObj v = new FriendRpcRecommendObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcRecommendObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcRecommendObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcRecommendObj pb = ProtoBuf.Serializer.Deserialize<FriendRpcRecommendObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}


};
//推荐玩家请求封装类
[System.Serializable]
public class FriendRpcRecommendAskWraper
{

	//构造函数
	public FriendRpcRecommendAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public FriendRpcRecommendAsk ToPB()
	{
		FriendRpcRecommendAsk v = new FriendRpcRecommendAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcRecommendAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcRecommendAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcRecommendAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcRecommendAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//推荐玩家回应封装类
[System.Serializable]
public class FriendRpcRecommendReplyWraper
{

	//构造函数
	public FriendRpcRecommendReplyWraper()
	{
		 m_Result = -9999;
		m_RecommendList = new List<FriendRpcRecommendObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_RecommendList = new List<FriendRpcRecommendObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public FriendRpcRecommendReply ToPB()
	{
		FriendRpcRecommendReply v = new FriendRpcRecommendReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_RecommendList.Count; i++)
			v.RecommendList.Add( m_RecommendList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcRecommendReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_RecommendList.Clear();
		for( int i=0; i<v.RecommendList.Count; i++)
			m_RecommendList.Add( new FriendRpcRecommendObjWraper());
		for( int i=0; i<v.RecommendList.Count; i++)
			m_RecommendList[i].FromPB(v.RecommendList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcRecommendReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcRecommendReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcRecommendReply>(protoMS);
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
	//推荐名单
	public List<FriendRpcRecommendObjWraper> m_RecommendList;
	public int SizeRecommendList()
	{
		return m_RecommendList.Count;
	}
	public List<FriendRpcRecommendObjWraper> GetRecommendList()
	{
		return m_RecommendList;
	}
	public FriendRpcRecommendObjWraper GetRecommendList(int Index)
	{
		if(Index<0 || Index>=(int)m_RecommendList.Count)
			return new FriendRpcRecommendObjWraper();
		return m_RecommendList[Index];
	}
	public void SetRecommendList( List<FriendRpcRecommendObjWraper> v )
	{
		m_RecommendList=v;
	}
	public void SetRecommendList( int Index, FriendRpcRecommendObjWraper v )
	{
		if(Index<0 || Index>=(int)m_RecommendList.Count)
			return;
		m_RecommendList[Index] = v;
	}
	public void AddRecommendList( FriendRpcRecommendObjWraper v )
	{
		m_RecommendList.Add(v);
	}
	public void ClearRecommendList( )
	{
		m_RecommendList.Clear();
	}


};
//查看资料简单数据请求封装类
[System.Serializable]
public class FriendRpcViewUserSimpleInfoAskWraper
{

	//构造函数
	public FriendRpcViewUserSimpleInfoAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcViewUserSimpleInfoAsk ToPB()
	{
		FriendRpcViewUserSimpleInfoAsk v = new FriendRpcViewUserSimpleInfoAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcViewUserSimpleInfoAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcViewUserSimpleInfoAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcViewUserSimpleInfoAsk pb = ProtoBuf.Serializer.Deserialize<FriendRpcViewUserSimpleInfoAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//查看资料简单数据回应封装类
[System.Serializable]
public class FriendRpcViewUserSimpleInfoReplyWraper
{

	//构造函数
	public FriendRpcViewUserSimpleInfoReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_TeamId = -1;
		 m_TeamMemberNum = -1;
		 m_GuildId = -1;
		 m_Signature = "";
		 m_Online = false;
		 m_GoodFeeling = 0;
		 m_GuildName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_TeamId = -1;
		 m_TeamMemberNum = -1;
		 m_GuildId = -1;
		 m_Signature = "";
		 m_Online = false;
		 m_GoodFeeling = 0;
		 m_GuildName = "";

	}

 	//转化成Protobuffer类型函数
	public FriendRpcViewUserSimpleInfoReply ToPB()
	{
		FriendRpcViewUserSimpleInfoReply v = new FriendRpcViewUserSimpleInfoReply();
		v.Result = m_Result;
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;
		v.TeamId = m_TeamId;
		v.TeamMemberNum = m_TeamMemberNum;
		v.GuildId = m_GuildId;
		v.Signature = m_Signature;
		v.Online = m_Online;
		v.GoodFeeling = m_GoodFeeling;
		v.GuildName = m_GuildName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcViewUserSimpleInfoReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;
		m_TeamId = v.TeamId;
		m_TeamMemberNum = v.TeamMemberNum;
		m_GuildId = v.GuildId;
		m_Signature = v.Signature;
		m_Online = v.Online;
		m_GoodFeeling = v.GoodFeeling;
		m_GuildName = v.GuildName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcViewUserSimpleInfoReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcViewUserSimpleInfoReply pb = ProtoBuf.Serializer.Deserialize<FriendRpcViewUserSimpleInfoReply>(protoMS);
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
	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}
	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//队伍当前人数
	public int m_TeamMemberNum;
	public int TeamMemberNum
	{
		get { return m_TeamMemberNum;}
		set { m_TeamMemberNum = value; }
	}
	//帮会id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}
	//签名
	public string m_Signature;
	public string Signature
	{
		get { return m_Signature;}
		set { m_Signature = value; }
	}
	//是否在线
	public bool m_Online;
	public bool Online
	{
		get { return m_Online;}
		set { m_Online = value; }
	}
	//好感度
	public int m_GoodFeeling;
	public int GoodFeeling
	{
		get { return m_GoodFeeling;}
		set { m_GoodFeeling = value; }
	}
	//帮会名字
	public string m_GuildName;
	public string GuildName
	{
		get { return m_GuildName;}
		set { m_GuildName = value; }
	}


};
//好友上下线通知封装类
[System.Serializable]
public class FriendRpcOnlineOfflineNotifyWraper
{

	//构造函数
	public FriendRpcOnlineOfflineNotifyWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Online = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Online = false;

	}

 	//转化成Protobuffer类型函数
	public FriendRpcOnlineOfflineNotify ToPB()
	{
		FriendRpcOnlineOfflineNotify v = new FriendRpcOnlineOfflineNotify();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Online = m_Online;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FriendRpcOnlineOfflineNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Online = v.Online;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FriendRpcOnlineOfflineNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FriendRpcOnlineOfflineNotify pb = ProtoBuf.Serializer.Deserialize<FriendRpcOnlineOfflineNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//是否在线
	public bool m_Online;
	public bool Online
	{
		get { return m_Online;}
		set { m_Online = value; }
	}


};
