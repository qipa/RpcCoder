
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBActivitySchedule.cs
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


//活动日常数据请求封装类
[System.Serializable]
public class ActivityScheduleRpcSyncDataAskWraper
{

	//构造函数
	public ActivityScheduleRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcSyncDataAsk ToPB()
	{
		ActivityScheduleRpcSyncDataAsk v = new ActivityScheduleRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//活动日常数据回应封装类
[System.Serializable]
public class ActivityScheduleRpcSyncDataReplyWraper
{

	//构造函数
	public ActivityScheduleRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;
		m_ThiefData = new List<ActivityNpcDataWraper>();
		m_SubdueMonsterData = new List<ActivityNpcDataWraper>();
		m_WorldBossData = new List<WorldBossObjWraper>();
		m_WorldBossRank = new List<WorldBossRankObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_ThiefData = new List<ActivityNpcDataWraper>();
		m_SubdueMonsterData = new List<ActivityNpcDataWraper>();
		m_WorldBossData = new List<WorldBossObjWraper>();
		m_WorldBossRank = new List<WorldBossRankObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcSyncDataReply ToPB()
	{
		ActivityScheduleRpcSyncDataReply v = new ActivityScheduleRpcSyncDataReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_ThiefData.Count; i++)
			v.ThiefData.Add( m_ThiefData[i].ToPB());
		for (int i=0; i<(int)m_SubdueMonsterData.Count; i++)
			v.SubdueMonsterData.Add( m_SubdueMonsterData[i].ToPB());
		for (int i=0; i<(int)m_WorldBossData.Count; i++)
			v.WorldBossData.Add( m_WorldBossData[i].ToPB());
		for (int i=0; i<(int)m_WorldBossRank.Count; i++)
			v.WorldBossRank.Add( m_WorldBossRank[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_ThiefData.Clear();
		for( int i=0; i<v.ThiefData.Count; i++)
			m_ThiefData.Add( new ActivityNpcDataWraper());
		for( int i=0; i<v.ThiefData.Count; i++)
			m_ThiefData[i].FromPB(v.ThiefData[i]);
		m_SubdueMonsterData.Clear();
		for( int i=0; i<v.SubdueMonsterData.Count; i++)
			m_SubdueMonsterData.Add( new ActivityNpcDataWraper());
		for( int i=0; i<v.SubdueMonsterData.Count; i++)
			m_SubdueMonsterData[i].FromPB(v.SubdueMonsterData[i]);
		m_WorldBossData.Clear();
		for( int i=0; i<v.WorldBossData.Count; i++)
			m_WorldBossData.Add( new WorldBossObjWraper());
		for( int i=0; i<v.WorldBossData.Count; i++)
			m_WorldBossData[i].FromPB(v.WorldBossData[i]);
		m_WorldBossRank.Clear();
		for( int i=0; i<v.WorldBossRank.Count; i++)
			m_WorldBossRank.Add( new WorldBossRankObjWraper());
		for( int i=0; i<v.WorldBossRank.Count; i++)
			m_WorldBossRank[i].FromPB(v.WorldBossRank[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcSyncDataReply>(protoMS);
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
	//当前有哪些江洋大盗
	public List<ActivityNpcDataWraper> m_ThiefData;
	public int SizeThiefData()
	{
		return m_ThiefData.Count;
	}
	public List<ActivityNpcDataWraper> GetThiefData()
	{
		return m_ThiefData;
	}
	public ActivityNpcDataWraper GetThiefData(int Index)
	{
		if(Index<0 || Index>=(int)m_ThiefData.Count)
			return new ActivityNpcDataWraper();
		return m_ThiefData[Index];
	}
	public void SetThiefData( List<ActivityNpcDataWraper> v )
	{
		m_ThiefData=v;
	}
	public void SetThiefData( int Index, ActivityNpcDataWraper v )
	{
		if(Index<0 || Index>=(int)m_ThiefData.Count)
			return;
		m_ThiefData[Index] = v;
	}
	public void AddThiefData( ActivityNpcDataWraper v )
	{
		m_ThiefData.Add(v);
	}
	public void ClearThiefData( )
	{
		m_ThiefData.Clear();
	}
	//降妖活动数据
	public List<ActivityNpcDataWraper> m_SubdueMonsterData;
	public int SizeSubdueMonsterData()
	{
		return m_SubdueMonsterData.Count;
	}
	public List<ActivityNpcDataWraper> GetSubdueMonsterData()
	{
		return m_SubdueMonsterData;
	}
	public ActivityNpcDataWraper GetSubdueMonsterData(int Index)
	{
		if(Index<0 || Index>=(int)m_SubdueMonsterData.Count)
			return new ActivityNpcDataWraper();
		return m_SubdueMonsterData[Index];
	}
	public void SetSubdueMonsterData( List<ActivityNpcDataWraper> v )
	{
		m_SubdueMonsterData=v;
	}
	public void SetSubdueMonsterData( int Index, ActivityNpcDataWraper v )
	{
		if(Index<0 || Index>=(int)m_SubdueMonsterData.Count)
			return;
		m_SubdueMonsterData[Index] = v;
	}
	public void AddSubdueMonsterData( ActivityNpcDataWraper v )
	{
		m_SubdueMonsterData.Add(v);
	}
	public void ClearSubdueMonsterData( )
	{
		m_SubdueMonsterData.Clear();
	}
	//世界Boss数据
	public List<WorldBossObjWraper> m_WorldBossData;
	public int SizeWorldBossData()
	{
		return m_WorldBossData.Count;
	}
	public List<WorldBossObjWraper> GetWorldBossData()
	{
		return m_WorldBossData;
	}
	public WorldBossObjWraper GetWorldBossData(int Index)
	{
		if(Index<0 || Index>=(int)m_WorldBossData.Count)
			return new WorldBossObjWraper();
		return m_WorldBossData[Index];
	}
	public void SetWorldBossData( List<WorldBossObjWraper> v )
	{
		m_WorldBossData=v;
	}
	public void SetWorldBossData( int Index, WorldBossObjWraper v )
	{
		if(Index<0 || Index>=(int)m_WorldBossData.Count)
			return;
		m_WorldBossData[Index] = v;
	}
	public void AddWorldBossData( WorldBossObjWraper v )
	{
		m_WorldBossData.Add(v);
	}
	public void ClearWorldBossData( )
	{
		m_WorldBossData.Clear();
	}
	//世界Boss排名
	public List<WorldBossRankObjWraper> m_WorldBossRank;
	public int SizeWorldBossRank()
	{
		return m_WorldBossRank.Count;
	}
	public List<WorldBossRankObjWraper> GetWorldBossRank()
	{
		return m_WorldBossRank;
	}
	public WorldBossRankObjWraper GetWorldBossRank(int Index)
	{
		if(Index<0 || Index>=(int)m_WorldBossRank.Count)
			return new WorldBossRankObjWraper();
		return m_WorldBossRank[Index];
	}
	public void SetWorldBossRank( List<WorldBossRankObjWraper> v )
	{
		m_WorldBossRank=v;
	}
	public void SetWorldBossRank( int Index, WorldBossRankObjWraper v )
	{
		if(Index<0 || Index>=(int)m_WorldBossRank.Count)
			return;
		m_WorldBossRank[Index] = v;
	}
	public void AddWorldBossRank( WorldBossRankObjWraper v )
	{
		m_WorldBossRank.Add(v);
	}
	public void ClearWorldBossRank( )
	{
		m_WorldBossRank.Clear();
	}


};
//江洋大盗被开启通知通知封装类
[System.Serializable]
public class ActivityScheduleRpcThiefBeOpenedNotifyWraper
{

	//构造函数
	public ActivityScheduleRpcThiefBeOpenedNotifyWraper()
	{
		 m_ThiefData = new ActivityNpcDataWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ThiefData = new ActivityNpcDataWraper();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcThiefBeOpenedNotify ToPB()
	{
		ActivityScheduleRpcThiefBeOpenedNotify v = new ActivityScheduleRpcThiefBeOpenedNotify();
		v.ThiefData = m_ThiefData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcThiefBeOpenedNotify v)
	{
        if (v == null)
            return;
		m_ThiefData.FromPB(v.ThiefData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcThiefBeOpenedNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcThiefBeOpenedNotify pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcThiefBeOpenedNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//被开启的江洋大盗
	public ActivityNpcDataWraper m_ThiefData;
	public ActivityNpcDataWraper ThiefData
	{
		get { return m_ThiefData;}
		set { m_ThiefData = value; }
	}


};
//江洋大盗刷新通知封装类
[System.Serializable]
public class ActivityScheduleRpcThiefRefreshNotifyWraper
{

	//构造函数
	public ActivityScheduleRpcThiefRefreshNotifyWraper()
	{
		m_ThiefData = new List<ActivityNpcDataWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_ThiefData = new List<ActivityNpcDataWraper>();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcThiefRefreshNotify ToPB()
	{
		ActivityScheduleRpcThiefRefreshNotify v = new ActivityScheduleRpcThiefRefreshNotify();
		for (int i=0; i<(int)m_ThiefData.Count; i++)
			v.ThiefData.Add( m_ThiefData[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcThiefRefreshNotify v)
	{
        if (v == null)
            return;
		m_ThiefData.Clear();
		for( int i=0; i<v.ThiefData.Count; i++)
			m_ThiefData.Add( new ActivityNpcDataWraper());
		for( int i=0; i<v.ThiefData.Count; i++)
			m_ThiefData[i].FromPB(v.ThiefData[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcThiefRefreshNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcThiefRefreshNotify pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcThiefRefreshNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//当前有哪些江洋大盗
	public List<ActivityNpcDataWraper> m_ThiefData;
	public int SizeThiefData()
	{
		return m_ThiefData.Count;
	}
	public List<ActivityNpcDataWraper> GetThiefData()
	{
		return m_ThiefData;
	}
	public ActivityNpcDataWraper GetThiefData(int Index)
	{
		if(Index<0 || Index>=(int)m_ThiefData.Count)
			return new ActivityNpcDataWraper();
		return m_ThiefData[Index];
	}
	public void SetThiefData( List<ActivityNpcDataWraper> v )
	{
		m_ThiefData=v;
	}
	public void SetThiefData( int Index, ActivityNpcDataWraper v )
	{
		if(Index<0 || Index>=(int)m_ThiefData.Count)
			return;
		m_ThiefData[Index] = v;
	}
	public void AddThiefData( ActivityNpcDataWraper v )
	{
		m_ThiefData.Add(v);
	}
	public void ClearThiefData( )
	{
		m_ThiefData.Clear();
	}


};
//江洋大盗开怪请求封装类
[System.Serializable]
public class ActivityScheduleRpcThiefOpenMonsterAskWraper
{

	//构造函数
	public ActivityScheduleRpcThiefOpenMonsterAskWraper()
	{
		 m_ThiefData = new ActivityNpcDataWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ThiefData = new ActivityNpcDataWraper();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcThiefOpenMonsterAsk ToPB()
	{
		ActivityScheduleRpcThiefOpenMonsterAsk v = new ActivityScheduleRpcThiefOpenMonsterAsk();
		v.ThiefData = m_ThiefData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcThiefOpenMonsterAsk v)
	{
        if (v == null)
            return;
		m_ThiefData.FromPB(v.ThiefData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcThiefOpenMonsterAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcThiefOpenMonsterAsk pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcThiefOpenMonsterAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//需要开启的江洋大盗
	public ActivityNpcDataWraper m_ThiefData;
	public ActivityNpcDataWraper ThiefData
	{
		get { return m_ThiefData;}
		set { m_ThiefData = value; }
	}


};
//江洋大盗开怪回应封装类
[System.Serializable]
public class ActivityScheduleRpcThiefOpenMonsterReplyWraper
{

	//构造函数
	public ActivityScheduleRpcThiefOpenMonsterReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcThiefOpenMonsterReply ToPB()
	{
		ActivityScheduleRpcThiefOpenMonsterReply v = new ActivityScheduleRpcThiefOpenMonsterReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcThiefOpenMonsterReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcThiefOpenMonsterReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcThiefOpenMonsterReply pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcThiefOpenMonsterReply>(protoMS);
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
//降妖进入副本请求封装类
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterEnterAskWraper
{

	//构造函数
	public ActivityScheduleRpcSubdueMonsterEnterAskWraper()
	{
		 m_SubdueMonsterData = new ActivityNpcDataWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SubdueMonsterData = new ActivityNpcDataWraper();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcSubdueMonsterEnterAsk ToPB()
	{
		ActivityScheduleRpcSubdueMonsterEnterAsk v = new ActivityScheduleRpcSubdueMonsterEnterAsk();
		v.SubdueMonsterData = m_SubdueMonsterData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcSubdueMonsterEnterAsk v)
	{
        if (v == null)
            return;
		m_SubdueMonsterData.FromPB(v.SubdueMonsterData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcSubdueMonsterEnterAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcSubdueMonsterEnterAsk pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcSubdueMonsterEnterAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//降妖活动数据
	public ActivityNpcDataWraper m_SubdueMonsterData;
	public ActivityNpcDataWraper SubdueMonsterData
	{
		get { return m_SubdueMonsterData;}
		set { m_SubdueMonsterData = value; }
	}


};
//降妖进入副本回应封装类
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterEnterReplyWraper
{

	//构造函数
	public ActivityScheduleRpcSubdueMonsterEnterReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcSubdueMonsterEnterReply ToPB()
	{
		ActivityScheduleRpcSubdueMonsterEnterReply v = new ActivityScheduleRpcSubdueMonsterEnterReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcSubdueMonsterEnterReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcSubdueMonsterEnterReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcSubdueMonsterEnterReply pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcSubdueMonsterEnterReply>(protoMS);
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
//降妖被其他人开启通知封装类
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraper
{

	//构造函数
	public ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraper()
	{
		 m_SubdueMonsterData = new ActivityNpcDataWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SubdueMonsterData = new ActivityNpcDataWraper();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcSubdueMonsterBeOpenedNotify ToPB()
	{
		ActivityScheduleRpcSubdueMonsterBeOpenedNotify v = new ActivityScheduleRpcSubdueMonsterBeOpenedNotify();
		v.SubdueMonsterData = m_SubdueMonsterData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcSubdueMonsterBeOpenedNotify v)
	{
        if (v == null)
            return;
		m_SubdueMonsterData.FromPB(v.SubdueMonsterData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcSubdueMonsterBeOpenedNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcSubdueMonsterBeOpenedNotify pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcSubdueMonsterBeOpenedNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//降妖活动数据
	public ActivityNpcDataWraper m_SubdueMonsterData;
	public ActivityNpcDataWraper SubdueMonsterData
	{
		get { return m_SubdueMonsterData;}
		set { m_SubdueMonsterData = value; }
	}


};
//降妖除魔刷新Npc通知封装类
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterRefreshNotifyWraper
{

	//构造函数
	public ActivityScheduleRpcSubdueMonsterRefreshNotifyWraper()
	{
		m_SubdueMonsterData = new List<ActivityNpcDataWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_SubdueMonsterData = new List<ActivityNpcDataWraper>();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcSubdueMonsterRefreshNotify ToPB()
	{
		ActivityScheduleRpcSubdueMonsterRefreshNotify v = new ActivityScheduleRpcSubdueMonsterRefreshNotify();
		for (int i=0; i<(int)m_SubdueMonsterData.Count; i++)
			v.SubdueMonsterData.Add( m_SubdueMonsterData[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcSubdueMonsterRefreshNotify v)
	{
        if (v == null)
            return;
		m_SubdueMonsterData.Clear();
		for( int i=0; i<v.SubdueMonsterData.Count; i++)
			m_SubdueMonsterData.Add( new ActivityNpcDataWraper());
		for( int i=0; i<v.SubdueMonsterData.Count; i++)
			m_SubdueMonsterData[i].FromPB(v.SubdueMonsterData[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcSubdueMonsterRefreshNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcSubdueMonsterRefreshNotify pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcSubdueMonsterRefreshNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//降妖活动数据
	public List<ActivityNpcDataWraper> m_SubdueMonsterData;
	public int SizeSubdueMonsterData()
	{
		return m_SubdueMonsterData.Count;
	}
	public List<ActivityNpcDataWraper> GetSubdueMonsterData()
	{
		return m_SubdueMonsterData;
	}
	public ActivityNpcDataWraper GetSubdueMonsterData(int Index)
	{
		if(Index<0 || Index>=(int)m_SubdueMonsterData.Count)
			return new ActivityNpcDataWraper();
		return m_SubdueMonsterData[Index];
	}
	public void SetSubdueMonsterData( List<ActivityNpcDataWraper> v )
	{
		m_SubdueMonsterData=v;
	}
	public void SetSubdueMonsterData( int Index, ActivityNpcDataWraper v )
	{
		if(Index<0 || Index>=(int)m_SubdueMonsterData.Count)
			return;
		m_SubdueMonsterData[Index] = v;
	}
	public void AddSubdueMonsterData( ActivityNpcDataWraper v )
	{
		m_SubdueMonsterData.Add(v);
	}
	public void ClearSubdueMonsterData( )
	{
		m_SubdueMonsterData.Clear();
	}


};
//世界Boss进行副本请求封装类
[System.Serializable]
public class ActivityScheduleRpcWorldBossEnterDungeonAskWraper
{

	//构造函数
	public ActivityScheduleRpcWorldBossEnterDungeonAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcWorldBossEnterDungeonAsk ToPB()
	{
		ActivityScheduleRpcWorldBossEnterDungeonAsk v = new ActivityScheduleRpcWorldBossEnterDungeonAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcWorldBossEnterDungeonAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcWorldBossEnterDungeonAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcWorldBossEnterDungeonAsk pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcWorldBossEnterDungeonAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//世界Boss进行副本回应封装类
[System.Serializable]
public class ActivityScheduleRpcWorldBossEnterDungeonReplyWraper
{

	//构造函数
	public ActivityScheduleRpcWorldBossEnterDungeonReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcWorldBossEnterDungeonReply ToPB()
	{
		ActivityScheduleRpcWorldBossEnterDungeonReply v = new ActivityScheduleRpcWorldBossEnterDungeonReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcWorldBossEnterDungeonReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcWorldBossEnterDungeonReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcWorldBossEnterDungeonReply pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcWorldBossEnterDungeonReply>(protoMS);
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
//世界Boss,打开界面刷新数据请求封装类
[System.Serializable]
public class ActivityScheduleRpcWorldBossSyncDataAskWraper
{

	//构造函数
	public ActivityScheduleRpcWorldBossSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcWorldBossSyncDataAsk ToPB()
	{
		ActivityScheduleRpcWorldBossSyncDataAsk v = new ActivityScheduleRpcWorldBossSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcWorldBossSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcWorldBossSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcWorldBossSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcWorldBossSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//世界Boss,打开界面刷新数据回应封装类
[System.Serializable]
public class ActivityScheduleRpcWorldBossSyncDataReplyWraper
{

	//构造函数
	public ActivityScheduleRpcWorldBossSyncDataReplyWraper()
	{
		 m_Result = -9999;
		m_WorldBossData = new List<WorldBossObjWraper>();
		m_WorldBossRank = new List<WorldBossRankObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_WorldBossData = new List<WorldBossObjWraper>();
		m_WorldBossRank = new List<WorldBossRankObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleRpcWorldBossSyncDataReply ToPB()
	{
		ActivityScheduleRpcWorldBossSyncDataReply v = new ActivityScheduleRpcWorldBossSyncDataReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_WorldBossData.Count; i++)
			v.WorldBossData.Add( m_WorldBossData[i].ToPB());
		for (int i=0; i<(int)m_WorldBossRank.Count; i++)
			v.WorldBossRank.Add( m_WorldBossRank[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleRpcWorldBossSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_WorldBossData.Clear();
		for( int i=0; i<v.WorldBossData.Count; i++)
			m_WorldBossData.Add( new WorldBossObjWraper());
		for( int i=0; i<v.WorldBossData.Count; i++)
			m_WorldBossData[i].FromPB(v.WorldBossData[i]);
		m_WorldBossRank.Clear();
		for( int i=0; i<v.WorldBossRank.Count; i++)
			m_WorldBossRank.Add( new WorldBossRankObjWraper());
		for( int i=0; i<v.WorldBossRank.Count; i++)
			m_WorldBossRank[i].FromPB(v.WorldBossRank[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleRpcWorldBossSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleRpcWorldBossSyncDataReply pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleRpcWorldBossSyncDataReply>(protoMS);
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
	//世界Boss数据
	public List<WorldBossObjWraper> m_WorldBossData;
	public int SizeWorldBossData()
	{
		return m_WorldBossData.Count;
	}
	public List<WorldBossObjWraper> GetWorldBossData()
	{
		return m_WorldBossData;
	}
	public WorldBossObjWraper GetWorldBossData(int Index)
	{
		if(Index<0 || Index>=(int)m_WorldBossData.Count)
			return new WorldBossObjWraper();
		return m_WorldBossData[Index];
	}
	public void SetWorldBossData( List<WorldBossObjWraper> v )
	{
		m_WorldBossData=v;
	}
	public void SetWorldBossData( int Index, WorldBossObjWraper v )
	{
		if(Index<0 || Index>=(int)m_WorldBossData.Count)
			return;
		m_WorldBossData[Index] = v;
	}
	public void AddWorldBossData( WorldBossObjWraper v )
	{
		m_WorldBossData.Add(v);
	}
	public void ClearWorldBossData( )
	{
		m_WorldBossData.Clear();
	}
	//世界Boss排名
	public List<WorldBossRankObjWraper> m_WorldBossRank;
	public int SizeWorldBossRank()
	{
		return m_WorldBossRank.Count;
	}
	public List<WorldBossRankObjWraper> GetWorldBossRank()
	{
		return m_WorldBossRank;
	}
	public WorldBossRankObjWraper GetWorldBossRank(int Index)
	{
		if(Index<0 || Index>=(int)m_WorldBossRank.Count)
			return new WorldBossRankObjWraper();
		return m_WorldBossRank[Index];
	}
	public void SetWorldBossRank( List<WorldBossRankObjWraper> v )
	{
		m_WorldBossRank=v;
	}
	public void SetWorldBossRank( int Index, WorldBossRankObjWraper v )
	{
		if(Index<0 || Index>=(int)m_WorldBossRank.Count)
			return;
		m_WorldBossRank[Index] = v;
	}
	public void AddWorldBossRank( WorldBossRankObjWraper v )
	{
		m_WorldBossRank.Add(v);
	}
	public void ClearWorldBossRank( )
	{
		m_WorldBossRank.Clear();
	}


};
