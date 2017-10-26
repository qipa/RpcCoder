
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBOneVSOne.cs
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


//刷新自己的数据请求封装类
[System.Serializable]
public class OneVSOneRpcFlushAskWraper
{

	//构造函数
	public OneVSOneRpcFlushAskWraper()
	{
		 m_IsOpen = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_IsOpen = 0;

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcFlushAsk ToPB()
	{
		OneVSOneRpcFlushAsk v = new OneVSOneRpcFlushAsk();
		v.IsOpen = m_IsOpen;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcFlushAsk v)
	{
        if (v == null)
            return;
		m_IsOpen = v.IsOpen;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcFlushAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcFlushAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcFlushAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//是不是打开界面
	public int m_IsOpen;
	public int IsOpen
	{
		get { return m_IsOpen;}
		set { m_IsOpen = value; }
	}


};
//刷新自己的数据回应封装类
[System.Serializable]
public class OneVSOneRpcFlushReplyWraper
{

	//构造函数
	public OneVSOneRpcFlushReplyWraper()
	{
		 m_Result = -9999;
		 m_Ranking = -1;
		 m_FightingCapacity = -1;
		 m_OneVSOneNum = -1;
		m_TimeRankings = new List<TimeTopWraper>();
		m_ActPeos = new List<OneVSOneActPeoWraper>();
		 m_IsOpen = 0;
		 m_LockTime = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Ranking = -1;
		 m_FightingCapacity = -1;
		 m_OneVSOneNum = -1;
		m_TimeRankings = new List<TimeTopWraper>();
		m_ActPeos = new List<OneVSOneActPeoWraper>();
		 m_IsOpen = 0;
		 m_LockTime = -1;

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcFlushReply ToPB()
	{
		OneVSOneRpcFlushReply v = new OneVSOneRpcFlushReply();
		v.Result = m_Result;
		v.Ranking = m_Ranking;
		v.FightingCapacity = m_FightingCapacity;
		v.OneVSOneNum = m_OneVSOneNum;
		for (int i=0; i<(int)m_TimeRankings.Count; i++)
			v.TimeRankings.Add( m_TimeRankings[i].ToPB());
		for (int i=0; i<(int)m_ActPeos.Count; i++)
			v.ActPeos.Add( m_ActPeos[i].ToPB());
		v.IsOpen = m_IsOpen;
		v.LockTime = m_LockTime;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcFlushReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Ranking = v.Ranking;
		m_FightingCapacity = v.FightingCapacity;
		m_OneVSOneNum = v.OneVSOneNum;
		m_TimeRankings.Clear();
		for( int i=0; i<v.TimeRankings.Count; i++)
			m_TimeRankings.Add( new TimeTopWraper());
		for( int i=0; i<v.TimeRankings.Count; i++)
			m_TimeRankings[i].FromPB(v.TimeRankings[i]);
		m_ActPeos.Clear();
		for( int i=0; i<v.ActPeos.Count; i++)
			m_ActPeos.Add( new OneVSOneActPeoWraper());
		for( int i=0; i<v.ActPeos.Count; i++)
			m_ActPeos[i].FromPB(v.ActPeos[i]);
		m_IsOpen = v.IsOpen;
		m_LockTime = v.LockTime;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcFlushReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcFlushReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcFlushReply>(protoMS);
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
	//排行名次
	public int m_Ranking;
	public int Ranking
	{
		get { return m_Ranking;}
		set { m_Ranking = value; }
	}
	//战斗力
	public int m_FightingCapacity;
	public int FightingCapacity
	{
		get { return m_FightingCapacity;}
		set { m_FightingCapacity = value; }
	}
	//一对一的剩余次数
	public int m_OneVSOneNum;
	public int OneVSOneNum
	{
		get { return m_OneVSOneNum;}
		set { m_OneVSOneNum = value; }
	}
	//时间名次
	public List<TimeTopWraper> m_TimeRankings;
	public int SizeTimeRankings()
	{
		return m_TimeRankings.Count;
	}
	public List<TimeTopWraper> GetTimeRankings()
	{
		return m_TimeRankings;
	}
	public TimeTopWraper GetTimeRankings(int Index)
	{
		if(Index<0 || Index>=(int)m_TimeRankings.Count)
			return new TimeTopWraper();
		return m_TimeRankings[Index];
	}
	public void SetTimeRankings( List<TimeTopWraper> v )
	{
		m_TimeRankings=v;
	}
	public void SetTimeRankings( int Index, TimeTopWraper v )
	{
		if(Index<0 || Index>=(int)m_TimeRankings.Count)
			return;
		m_TimeRankings[Index] = v;
	}
	public void AddTimeRankings( TimeTopWraper v )
	{
		m_TimeRankings.Add(v);
	}
	public void ClearTimeRankings( )
	{
		m_TimeRankings.Clear();
	}
	//挑战的人
	public List<OneVSOneActPeoWraper> m_ActPeos;
	public int SizeActPeos()
	{
		return m_ActPeos.Count;
	}
	public List<OneVSOneActPeoWraper> GetActPeos()
	{
		return m_ActPeos;
	}
	public OneVSOneActPeoWraper GetActPeos(int Index)
	{
		if(Index<0 || Index>=(int)m_ActPeos.Count)
			return new OneVSOneActPeoWraper();
		return m_ActPeos[Index];
	}
	public void SetActPeos( List<OneVSOneActPeoWraper> v )
	{
		m_ActPeos=v;
	}
	public void SetActPeos( int Index, OneVSOneActPeoWraper v )
	{
		if(Index<0 || Index>=(int)m_ActPeos.Count)
			return;
		m_ActPeos[Index] = v;
	}
	public void AddActPeos( OneVSOneActPeoWraper v )
	{
		m_ActPeos.Add(v);
	}
	public void ClearActPeos( )
	{
		m_ActPeos.Clear();
	}
	//是不是打开界面
	public int m_IsOpen;
	public int IsOpen
	{
		get { return m_IsOpen;}
		set { m_IsOpen = value; }
	}
	//锁定时间 秒 小于等于0 忽略
	public int m_LockTime;
	public int LockTime
	{
		get { return m_LockTime;}
		set { m_LockTime = value; }
	}


};
//挑战的人封装类
[System.Serializable]
public class OneVSOneActPeoWraper
{

	//构造函数
	public OneVSOneActPeoWraper()
	{
		 m_PlanName = "";
		 m_Ranking = -1;
		 m_FightingCapacity = -1;
		 m_UserId = -1;
		 m_MardID = -1;
		 m_LV = -1;
		 m_HeadPath = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_PlanName = "";
		 m_Ranking = -1;
		 m_FightingCapacity = -1;
		 m_UserId = -1;
		 m_MardID = -1;
		 m_LV = -1;
		 m_HeadPath = "";

	}

 	//转化成Protobuffer类型函数
	public OneVSOneActPeo ToPB()
	{
		OneVSOneActPeo v = new OneVSOneActPeo();
		v.PlanName = m_PlanName;
		v.Ranking = m_Ranking;
		v.FightingCapacity = m_FightingCapacity;
		v.UserId = m_UserId;
		v.MardID = m_MardID;
		v.LV = m_LV;
		v.HeadPath = m_HeadPath;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneActPeo v)
	{
        if (v == null)
            return;
		m_PlanName = v.PlanName;
		m_Ranking = v.Ranking;
		m_FightingCapacity = v.FightingCapacity;
		m_UserId = v.UserId;
		m_MardID = v.MardID;
		m_LV = v.LV;
		m_HeadPath = v.HeadPath;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneActPeo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneActPeo pb = ProtoBuf.Serializer.Deserialize<OneVSOneActPeo>(protoMS);
		FromPB(pb);
		return true;
	}

	//昵称
	public string m_PlanName;
	public string PlanName
	{
		get { return m_PlanName;}
		set { m_PlanName = value; }
	}
	//排行名次
	public int m_Ranking;
	public int Ranking
	{
		get { return m_Ranking;}
		set { m_Ranking = value; }
	}
	//战斗力
	public int m_FightingCapacity;
	public int FightingCapacity
	{
		get { return m_FightingCapacity;}
		set { m_FightingCapacity = value; }
	}
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//职业id
	public int m_MardID;
	public int MardID
	{
		get { return m_MardID;}
		set { m_MardID = value; }
	}
	//等级
	public int m_LV;
	public int LV
	{
		get { return m_LV;}
		set { m_LV = value; }
	}
	//头像路径 防止个性化
	public string m_HeadPath;
	public string HeadPath
	{
		get { return m_HeadPath;}
		set { m_HeadPath = value; }
	}


};
//发起挑战请求封装类
[System.Serializable]
public class OneVSOneRpcActAskWraper
{

	//构造函数
	public OneVSOneRpcActAskWraper()
	{
		 m_UserId = -1;
		 m_Ranking = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_Ranking = -1;

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcActAsk ToPB()
	{
		OneVSOneRpcActAsk v = new OneVSOneRpcActAsk();
		v.UserId = m_UserId;
		v.Ranking = m_Ranking;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcActAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_Ranking = v.Ranking;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcActAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcActAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcActAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//排行名次
	public int m_Ranking;
	public int Ranking
	{
		get { return m_Ranking;}
		set { m_Ranking = value; }
	}


};
//发起挑战回应封装类
[System.Serializable]
public class OneVSOneRpcActReplyWraper
{

	//构造函数
	public OneVSOneRpcActReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_PlanName = "";
		 m_OneVSOneNum = -1;
		 m_Ranking = -1;
		 m_IsCopy = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_PlanName = "";
		 m_OneVSOneNum = -1;
		 m_Ranking = -1;
		 m_IsCopy = 0;

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcActReply ToPB()
	{
		OneVSOneRpcActReply v = new OneVSOneRpcActReply();
		v.Result = m_Result;
		v.UserId = m_UserId;
		v.PlanName = m_PlanName;
		v.OneVSOneNum = m_OneVSOneNum;
		v.Ranking = m_Ranking;
		v.IsCopy = m_IsCopy;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcActReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;
		m_PlanName = v.PlanName;
		m_OneVSOneNum = v.OneVSOneNum;
		m_Ranking = v.Ranking;
		m_IsCopy = v.IsCopy;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcActReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcActReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcActReply>(protoMS);
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
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//昵称
	public string m_PlanName;
	public string PlanName
	{
		get { return m_PlanName;}
		set { m_PlanName = value; }
	}
	//一对一的剩余次数
	public int m_OneVSOneNum;
	public int OneVSOneNum
	{
		get { return m_OneVSOneNum;}
		set { m_OneVSOneNum = value; }
	}
	//排行名次
	public int m_Ranking;
	public int Ranking
	{
		get { return m_Ranking;}
		set { m_Ranking = value; }
	}
	//对方是不是复制人1是0不是
	public int m_IsCopy;
	public int IsCopy
	{
		get { return m_IsCopy;}
		set { m_IsCopy = value; }
	}


};
//挑战消息通知封装类
[System.Serializable]
public class OneVSOneRpcActMessageNotifyWraper
{

	//构造函数
	public OneVSOneRpcActMessageNotifyWraper()
	{
		 m_UserId = -1;
		 m_PlanName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_PlanName = "";

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcActMessageNotify ToPB()
	{
		OneVSOneRpcActMessageNotify v = new OneVSOneRpcActMessageNotify();
		v.UserId = m_UserId;
		v.PlanName = m_PlanName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcActMessageNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_PlanName = v.PlanName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcActMessageNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcActMessageNotify pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcActMessageNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//昵称
	public string m_PlanName;
	public string PlanName
	{
		get { return m_PlanName;}
		set { m_PlanName = value; }
	}


};
//回应谁的挑战请求封装类
[System.Serializable]
public class OneVSOneRpcReplyActAskWraper
{

	//构造函数
	public OneVSOneRpcReplyActAskWraper()
	{
		 m_UserId = -1;
		 m_IsOK = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_IsOK = -1;

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcReplyActAsk ToPB()
	{
		OneVSOneRpcReplyActAsk v = new OneVSOneRpcReplyActAsk();
		v.UserId = m_UserId;
		v.IsOK = m_IsOK;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcReplyActAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_IsOK = v.IsOK;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcReplyActAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcReplyActAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcReplyActAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//是不是同意了 1是 其他不是
	public int m_IsOK;
	public int IsOK
	{
		get { return m_IsOK;}
		set { m_IsOK = value; }
	}


};
//回应谁的挑战回应封装类
[System.Serializable]
public class OneVSOneRpcReplyActReplyWraper
{

	//构造函数
	public OneVSOneRpcReplyActReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_IsOK = -1;
		 m_PlanName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_IsOK = -1;
		 m_PlanName = "";

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcReplyActReply ToPB()
	{
		OneVSOneRpcReplyActReply v = new OneVSOneRpcReplyActReply();
		v.Result = m_Result;
		v.UserId = m_UserId;
		v.IsOK = m_IsOK;
		v.PlanName = m_PlanName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcReplyActReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;
		m_IsOK = v.IsOK;
		m_PlanName = v.PlanName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcReplyActReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcReplyActReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcReplyActReply>(protoMS);
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
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//是不是同意了 1是 其他不是
	public int m_IsOK;
	public int IsOK
	{
		get { return m_IsOK;}
		set { m_IsOK = value; }
	}
	//昵称
	public string m_PlanName;
	public string PlanName
	{
		get { return m_PlanName;}
		set { m_PlanName = value; }
	}


};
//排行榜数据请求封装类
[System.Serializable]
public class OneVSOneRpcGetTopAskWraper
{

	//构造函数
	public OneVSOneRpcGetTopAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcGetTopAsk ToPB()
	{
		OneVSOneRpcGetTopAsk v = new OneVSOneRpcGetTopAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcGetTopAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcGetTopAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcGetTopAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcGetTopAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//排行榜数据回应封装类
[System.Serializable]
public class OneVSOneRpcGetTopReplyWraper
{

	//构造函数
	public OneVSOneRpcGetTopReplyWraper()
	{
		 m_Result = -9999;
		m_TopMesses = new List<TopMessWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_TopMesses = new List<TopMessWraper>();

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcGetTopReply ToPB()
	{
		OneVSOneRpcGetTopReply v = new OneVSOneRpcGetTopReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_TopMesses.Count; i++)
			v.TopMesses.Add( m_TopMesses[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcGetTopReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TopMesses.Clear();
		for( int i=0; i<v.TopMesses.Count; i++)
			m_TopMesses.Add( new TopMessWraper());
		for( int i=0; i<v.TopMesses.Count; i++)
			m_TopMesses[i].FromPB(v.TopMesses[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcGetTopReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcGetTopReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcGetTopReply>(protoMS);
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
	//排行榜数据
	public List<TopMessWraper> m_TopMesses;
	public int SizeTopMesses()
	{
		return m_TopMesses.Count;
	}
	public List<TopMessWraper> GetTopMesses()
	{
		return m_TopMesses;
	}
	public TopMessWraper GetTopMesses(int Index)
	{
		if(Index<0 || Index>=(int)m_TopMesses.Count)
			return new TopMessWraper();
		return m_TopMesses[Index];
	}
	public void SetTopMesses( List<TopMessWraper> v )
	{
		m_TopMesses=v;
	}
	public void SetTopMesses( int Index, TopMessWraper v )
	{
		if(Index<0 || Index>=(int)m_TopMesses.Count)
			return;
		m_TopMesses[Index] = v;
	}
	public void AddTopMesses( TopMessWraper v )
	{
		m_TopMesses.Add(v);
	}
	public void ClearTopMesses( )
	{
		m_TopMesses.Clear();
	}


};
//调整技能请求封装类
[System.Serializable]
public class OneVSOneRpcAdjustmentSkillAskWraper
{

	//构造函数
	public OneVSOneRpcAdjustmentSkillAskWraper()
	{
		m_SkillDate = new List<OneSDataWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_SkillDate = new List<OneSDataWraper>();

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcAdjustmentSkillAsk ToPB()
	{
		OneVSOneRpcAdjustmentSkillAsk v = new OneVSOneRpcAdjustmentSkillAsk();
		for (int i=0; i<(int)m_SkillDate.Count; i++)
			v.SkillDate.Add( m_SkillDate[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcAdjustmentSkillAsk v)
	{
        if (v == null)
            return;
		m_SkillDate.Clear();
		for( int i=0; i<v.SkillDate.Count; i++)
			m_SkillDate.Add( new OneSDataWraper());
		for( int i=0; i<v.SkillDate.Count; i++)
			m_SkillDate[i].FromPB(v.SkillDate[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcAdjustmentSkillAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcAdjustmentSkillAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcAdjustmentSkillAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能数据
	public List<OneSDataWraper> m_SkillDate;
	public int SizeSkillDate()
	{
		return m_SkillDate.Count;
	}
	public List<OneSDataWraper> GetSkillDate()
	{
		return m_SkillDate;
	}
	public OneSDataWraper GetSkillDate(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillDate.Count)
			return new OneSDataWraper();
		return m_SkillDate[Index];
	}
	public void SetSkillDate( List<OneSDataWraper> v )
	{
		m_SkillDate=v;
	}
	public void SetSkillDate( int Index, OneSDataWraper v )
	{
		if(Index<0 || Index>=(int)m_SkillDate.Count)
			return;
		m_SkillDate[Index] = v;
	}
	public void AddSkillDate( OneSDataWraper v )
	{
		m_SkillDate.Add(v);
	}
	public void ClearSkillDate( )
	{
		m_SkillDate.Clear();
	}


};
//调整技能回应封装类
[System.Serializable]
public class OneVSOneRpcAdjustmentSkillReplyWraper
{

	//构造函数
	public OneVSOneRpcAdjustmentSkillReplyWraper()
	{
		 m_Result = -9999;
		m_SkillDate = new List<OneSDataWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_SkillDate = new List<OneSDataWraper>();

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcAdjustmentSkillReply ToPB()
	{
		OneVSOneRpcAdjustmentSkillReply v = new OneVSOneRpcAdjustmentSkillReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_SkillDate.Count; i++)
			v.SkillDate.Add( m_SkillDate[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcAdjustmentSkillReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_SkillDate.Clear();
		for( int i=0; i<v.SkillDate.Count; i++)
			m_SkillDate.Add( new OneSDataWraper());
		for( int i=0; i<v.SkillDate.Count; i++)
			m_SkillDate[i].FromPB(v.SkillDate[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcAdjustmentSkillReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcAdjustmentSkillReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcAdjustmentSkillReply>(protoMS);
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
	//技能数据
	public List<OneSDataWraper> m_SkillDate;
	public int SizeSkillDate()
	{
		return m_SkillDate.Count;
	}
	public List<OneSDataWraper> GetSkillDate()
	{
		return m_SkillDate;
	}
	public OneSDataWraper GetSkillDate(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillDate.Count)
			return new OneSDataWraper();
		return m_SkillDate[Index];
	}
	public void SetSkillDate( List<OneSDataWraper> v )
	{
		m_SkillDate=v;
	}
	public void SetSkillDate( int Index, OneSDataWraper v )
	{
		if(Index<0 || Index>=(int)m_SkillDate.Count)
			return;
		m_SkillDate[Index] = v;
	}
	public void AddSkillDate( OneSDataWraper v )
	{
		m_SkillDate.Add(v);
	}
	public void ClearSkillDate( )
	{
		m_SkillDate.Clear();
	}


};
//获取设置的技能请求封装类
[System.Serializable]
public class OneVSOneRpcGetSkillAskWraper
{

	//构造函数
	public OneVSOneRpcGetSkillAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcGetSkillAsk ToPB()
	{
		OneVSOneRpcGetSkillAsk v = new OneVSOneRpcGetSkillAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcGetSkillAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcGetSkillAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcGetSkillAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcGetSkillAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//获取设置的技能回应封装类
[System.Serializable]
public class OneVSOneRpcGetSkillReplyWraper
{

	//构造函数
	public OneVSOneRpcGetSkillReplyWraper()
	{
		 m_Result = -9999;
		m_SkillDate = new List<OneSDataWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_SkillDate = new List<OneSDataWraper>();

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcGetSkillReply ToPB()
	{
		OneVSOneRpcGetSkillReply v = new OneVSOneRpcGetSkillReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_SkillDate.Count; i++)
			v.SkillDate.Add( m_SkillDate[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcGetSkillReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_SkillDate.Clear();
		for( int i=0; i<v.SkillDate.Count; i++)
			m_SkillDate.Add( new OneSDataWraper());
		for( int i=0; i<v.SkillDate.Count; i++)
			m_SkillDate[i].FromPB(v.SkillDate[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcGetSkillReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcGetSkillReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcGetSkillReply>(protoMS);
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
	//技能数据
	public List<OneSDataWraper> m_SkillDate;
	public int SizeSkillDate()
	{
		return m_SkillDate.Count;
	}
	public List<OneSDataWraper> GetSkillDate()
	{
		return m_SkillDate;
	}
	public OneSDataWraper GetSkillDate(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillDate.Count)
			return new OneSDataWraper();
		return m_SkillDate[Index];
	}
	public void SetSkillDate( List<OneSDataWraper> v )
	{
		m_SkillDate=v;
	}
	public void SetSkillDate( int Index, OneSDataWraper v )
	{
		if(Index<0 || Index>=(int)m_SkillDate.Count)
			return;
		m_SkillDate[Index] = v;
	}
	public void AddSkillDate( OneSDataWraper v )
	{
		m_SkillDate.Add(v);
	}
	public void ClearSkillDate( )
	{
		m_SkillDate.Clear();
	}


};
//获得攻守的信息请求封装类
[System.Serializable]
public class OneVSOneRpcGetActMessageAskWraper
{

	//构造函数
	public OneVSOneRpcGetActMessageAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcGetActMessageAsk ToPB()
	{
		OneVSOneRpcGetActMessageAsk v = new OneVSOneRpcGetActMessageAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcGetActMessageAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcGetActMessageAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcGetActMessageAsk pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcGetActMessageAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//获得攻守的信息回应封装类
[System.Serializable]
public class OneVSOneRpcGetActMessageReplyWraper
{

	//构造函数
	public OneVSOneRpcGetActMessageReplyWraper()
	{
		 m_Result = -9999;
		m_ActMessages = new List<ActMessageWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_ActMessages = new List<ActMessageWraper>();

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcGetActMessageReply ToPB()
	{
		OneVSOneRpcGetActMessageReply v = new OneVSOneRpcGetActMessageReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_ActMessages.Count; i++)
			v.ActMessages.Add( m_ActMessages[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcGetActMessageReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ActMessages.Clear();
		for( int i=0; i<v.ActMessages.Count; i++)
			m_ActMessages.Add( new ActMessageWraper());
		for( int i=0; i<v.ActMessages.Count; i++)
			m_ActMessages[i].FromPB(v.ActMessages[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcGetActMessageReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcGetActMessageReply pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcGetActMessageReply>(protoMS);
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
	//消息记录
	public List<ActMessageWraper> m_ActMessages;
	public int SizeActMessages()
	{
		return m_ActMessages.Count;
	}
	public List<ActMessageWraper> GetActMessages()
	{
		return m_ActMessages;
	}
	public ActMessageWraper GetActMessages(int Index)
	{
		if(Index<0 || Index>=(int)m_ActMessages.Count)
			return new ActMessageWraper();
		return m_ActMessages[Index];
	}
	public void SetActMessages( List<ActMessageWraper> v )
	{
		m_ActMessages=v;
	}
	public void SetActMessages( int Index, ActMessageWraper v )
	{
		if(Index<0 || Index>=(int)m_ActMessages.Count)
			return;
		m_ActMessages[Index] = v;
	}
	public void AddActMessages( ActMessageWraper v )
	{
		m_ActMessages.Add(v);
	}
	public void ClearActMessages( )
	{
		m_ActMessages.Clear();
	}


};
//战斗结果Notify 叶青给我我就给客户端通知封装类
[System.Serializable]
public class OneVSOneRpcACTResultNotifyNotifyWraper
{

	//构造函数
	public OneVSOneRpcACTResultNotifyNotifyWraper()
	{
		 m_IsChanllengorWon = 0;
		 m_Chanllengor = new OneVSOneOVOResultInfoWraper();
		 m_BeAttacked = new OneVSOneOVOResultInfoWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_IsChanllengorWon = 0;
		 m_Chanllengor = new OneVSOneOVOResultInfoWraper();
		 m_BeAttacked = new OneVSOneOVOResultInfoWraper();

	}

 	//转化成Protobuffer类型函数
	public OneVSOneRpcACTResultNotifyNotify ToPB()
	{
		OneVSOneRpcACTResultNotifyNotify v = new OneVSOneRpcACTResultNotifyNotify();
		v.IsChanllengorWon = m_IsChanllengorWon;
		v.Chanllengor = m_Chanllengor.ToPB();
		v.BeAttacked = m_BeAttacked.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneRpcACTResultNotifyNotify v)
	{
        if (v == null)
            return;
		m_IsChanllengorWon = v.IsChanllengorWon;
		m_Chanllengor.FromPB(v.Chanllengor);
		m_BeAttacked.FromPB(v.BeAttacked);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneRpcACTResultNotifyNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneRpcACTResultNotifyNotify pb = ProtoBuf.Serializer.Deserialize<OneVSOneRpcACTResultNotifyNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//挑战方是否赢了
	public int m_IsChanllengorWon;
	public int IsChanllengorWon
	{
		get { return m_IsChanllengorWon;}
		set { m_IsChanllengorWon = value; }
	}
	//攻击者信息
	public OneVSOneOVOResultInfoWraper m_Chanllengor;
	public OneVSOneOVOResultInfoWraper Chanllengor
	{
		get { return m_Chanllengor;}
		set { m_Chanllengor = value; }
	}
	//被攻击者信息
	public OneVSOneOVOResultInfoWraper m_BeAttacked;
	public OneVSOneOVOResultInfoWraper BeAttacked
	{
		get { return m_BeAttacked;}
		set { m_BeAttacked = value; }
	}


};
//1V1玩家战斗结果信息封装类
[System.Serializable]
public class OneVSOneOVOResultInfoWraper
{

	//构造函数
	public OneVSOneOVOResultInfoWraper()
	{
		 m_UserId = -1;
		 m_Damage = 0;
		 m_BeHurted = 0;
		 m_Healed = 0;
		 m_Name = "";
		 m_Ranking = 0;
		 m_BeforeRanking = -1;
		 m_JobID = -1;
		 m_HeadICO = "";
		 m_LV = -1;
		 m_IsWin = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_Damage = 0;
		 m_BeHurted = 0;
		 m_Healed = 0;
		 m_Name = "";
		 m_Ranking = 0;
		 m_BeforeRanking = -1;
		 m_JobID = -1;
		 m_HeadICO = "";
		 m_LV = -1;
		 m_IsWin = 0;

	}

 	//转化成Protobuffer类型函数
	public OneVSOneOVOResultInfo ToPB()
	{
		OneVSOneOVOResultInfo v = new OneVSOneOVOResultInfo();
		v.UserId = m_UserId;
		v.Damage = m_Damage;
		v.BeHurted = m_BeHurted;
		v.Healed = m_Healed;
		v.Name = m_Name;
		v.Ranking = m_Ranking;
		v.BeforeRanking = m_BeforeRanking;
		v.JobID = m_JobID;
		v.HeadICO = m_HeadICO;
		v.LV = m_LV;
		v.IsWin = m_IsWin;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneVSOneOVOResultInfo v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_Damage = v.Damage;
		m_BeHurted = v.BeHurted;
		m_Healed = v.Healed;
		m_Name = v.Name;
		m_Ranking = v.Ranking;
		m_BeforeRanking = v.BeforeRanking;
		m_JobID = v.JobID;
		m_HeadICO = v.HeadICO;
		m_LV = v.LV;
		m_IsWin = v.IsWin;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneVSOneOVOResultInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneVSOneOVOResultInfo pb = ProtoBuf.Serializer.Deserialize<OneVSOneOVOResultInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//USERId
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//伤害
	public int m_Damage;
	public int Damage
	{
		get { return m_Damage;}
		set { m_Damage = value; }
	}
	//承受伤害
	public int m_BeHurted;
	public int BeHurted
	{
		get { return m_BeHurted;}
		set { m_BeHurted = value; }
	}
	//治疗
	public int m_Healed;
	public int Healed
	{
		get { return m_Healed;}
		set { m_Healed = value; }
	}
	//昵称
	public string m_Name;
	public string Name
	{
		get { return m_Name;}
		set { m_Name = value; }
	}
	//现在的排行名次
	public int m_Ranking;
	public int Ranking
	{
		get { return m_Ranking;}
		set { m_Ranking = value; }
	}
	//之前的排名
	public int m_BeforeRanking;
	public int BeforeRanking
	{
		get { return m_BeforeRanking;}
		set { m_BeforeRanking = value; }
	}
	//职业ID
	public int m_JobID;
	public int JobID
	{
		get { return m_JobID;}
		set { m_JobID = value; }
	}
	//自定义头像
	public string m_HeadICO;
	public string HeadICO
	{
		get { return m_HeadICO;}
		set { m_HeadICO = value; }
	}
	//等级
	public int m_LV;
	public int LV
	{
		get { return m_LV;}
		set { m_LV = value; }
	}
	//是不是赢了1是0不是
	public int m_IsWin;
	public int IsWin
	{
		get { return m_IsWin;}
		set { m_IsWin = value; }
	}


};
