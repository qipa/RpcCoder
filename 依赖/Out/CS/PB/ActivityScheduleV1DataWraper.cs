
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBActivitySchedule.cs
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


//活动数据信息封装类
[System.Serializable]
public class ActivityScheduleActiveValueWraperV1
{

	//构造函数
	public ActivityScheduleActiveValueWraperV1()
	{
		 m_ID = 0;
		 m_Num = 0;
		 m_Vitality = 0;
		 m_StartTime = -1;
		 m_FinishTime = -1;
		 m_ActivityMaxNum = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ID = 0;
		 m_Num = 0;
		 m_Vitality = 0;
		 m_StartTime = -1;
		 m_FinishTime = -1;
		 m_ActivityMaxNum = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityScheduleActiveValueV1 ToPB()
	{
		ActivityScheduleActiveValueV1 v = new ActivityScheduleActiveValueV1();
		v.ID = m_ID;
		v.Num = m_Num;
		v.Vitality = m_Vitality;
		v.StartTime = m_StartTime;
		v.FinishTime = m_FinishTime;
		v.ActivityMaxNum = m_ActivityMaxNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityScheduleActiveValueV1 v)
	{
        if (v == null)
            return;
		m_ID = v.ID;
		m_Num = v.Num;
		m_Vitality = v.Vitality;
		m_StartTime = v.StartTime;
		m_FinishTime = v.FinishTime;
		m_ActivityMaxNum = v.ActivityMaxNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityScheduleActiveValueV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityScheduleActiveValueV1 pb = ProtoBuf.Serializer.Deserialize<ActivityScheduleActiveValueV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//id
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}
	//次数
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}
	//体力
	public int m_Vitality;
	public int Vitality
	{
		get { return m_Vitality;}
		set { m_Vitality = value; }
	}
	//活动开始时间
	public int m_StartTime;
	public int StartTime
	{
		get { return m_StartTime;}
		set { m_StartTime = value; }
	}
	//结束时间
	public int m_FinishTime;
	public int FinishTime
	{
		get { return m_FinishTime;}
		set { m_FinishTime = value; }
	}
	//限时活动最大次数
	public int m_ActivityMaxNum;
	public int ActivityMaxNum
	{
		get { return m_ActivityMaxNum;}
		set { m_ActivityMaxNum = value; }
	}


};
