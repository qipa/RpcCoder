
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBAchievement.cs
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


//成就对象封装类
[System.Serializable]
public class AchievementAchiObjWraperV1
{

	//构造函数
	public AchievementAchiObjWraperV1()
	{
		 m_GroupId = -1;
		 m_Star = -1;
		 m_Status = -1;
		 m_Id = -1;
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GroupId = -1;
		 m_Star = -1;
		 m_Status = -1;
		 m_Id = -1;
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public AchievementAchiObjV1 ToPB()
	{
		AchievementAchiObjV1 v = new AchievementAchiObjV1();
		v.GroupId = m_GroupId;
		v.Star = m_Star;
		v.Status = m_Status;
		v.Id = m_Id;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(AchievementAchiObjV1 v)
	{
        if (v == null)
            return;
		m_GroupId = v.GroupId;
		m_Star = v.Star;
		m_Status = v.Status;
		m_Id = v.Id;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<AchievementAchiObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		AchievementAchiObjV1 pb = ProtoBuf.Serializer.Deserialize<AchievementAchiObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//组id，使用解锁条件
	public int m_GroupId;
	public int GroupId
	{
		get { return m_GroupId;}
		set { m_GroupId = value; }
	}
	//星级
	public int m_Star;
	public int Star
	{
		get { return m_Star;}
		set { m_Star = value; }
	}
	//完成状态(0未完成,1完成未领奖，2已领奖）
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}
	//成就Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//成长，活动，社交
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
