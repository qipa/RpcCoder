
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBTask.cs
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


//主线任务对象封装类
[System.Serializable]
public class TaskTaskObjWraperV1
{

	//构造函数
	public TaskTaskObjWraperV1()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;
		m_TaskTarget = new List<TaskTaskTargetObjWraperV1>();
		 m_TaskType = -1;
		 m_IsOrder = true;
		 m_IsAutoSubmit = false;
		 m_CollectionId = -1;
		 m_DungeonId = -1;
		 m_Guild = -1;
		 m_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;
		m_TaskTarget = new List<TaskTaskTargetObjWraperV1>();
		 m_TaskType = -1;
		 m_IsOrder = true;
		 m_IsAutoSubmit = false;
		 m_CollectionId = -1;
		 m_DungeonId = -1;
		 m_Guild = -1;
		 m_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskTaskObjV1 ToPB()
	{
		TaskTaskObjV1 v = new TaskTaskObjV1();
		v.TaskId = m_TaskId;
		v.TaskState = m_TaskState;
		for (int i=0; i<(int)m_TaskTarget.Count; i++)
			v.TaskTarget.Add( m_TaskTarget[i].ToPB());
		v.TaskType = m_TaskType;
		v.IsOrder = m_IsOrder;
		v.IsAutoSubmit = m_IsAutoSubmit;
		v.CollectionId = m_CollectionId;
		v.DungeonId = m_DungeonId;
		v.Guild = m_Guild;
		v.ObjId = m_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskTaskObjV1 v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;
		m_TaskState = v.TaskState;
		m_TaskTarget.Clear();
		for( int i=0; i<v.TaskTarget.Count; i++)
			m_TaskTarget.Add( new TaskTaskTargetObjWraperV1());
		for( int i=0; i<v.TaskTarget.Count; i++)
			m_TaskTarget[i].FromPB(v.TaskTarget[i]);
		m_TaskType = v.TaskType;
		m_IsOrder = v.IsOrder;
		m_IsAutoSubmit = v.IsAutoSubmit;
		m_CollectionId = v.CollectionId;
		m_DungeonId = v.DungeonId;
		m_Guild = v.Guild;
		m_ObjId = v.ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskTaskObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskTaskObjV1 pb = ProtoBuf.Serializer.Deserialize<TaskTaskObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}
	//任务状态
	public int m_TaskState;
	public int TaskState
	{
		get { return m_TaskState;}
		set { m_TaskState = value; }
	}
	//任务目标
	public List<TaskTaskTargetObjWraperV1> m_TaskTarget;
	public int SizeTaskTarget()
	{
		return m_TaskTarget.Count;
	}
	public List<TaskTaskTargetObjWraperV1> GetTaskTarget()
	{
		return m_TaskTarget;
	}
	public TaskTaskTargetObjWraperV1 GetTaskTarget(int Index)
	{
		if(Index<0 || Index>=(int)m_TaskTarget.Count)
			return new TaskTaskTargetObjWraperV1();
		return m_TaskTarget[Index];
	}
	public void SetTaskTarget( List<TaskTaskTargetObjWraperV1> v )
	{
		m_TaskTarget=v;
	}
	public void SetTaskTarget( int Index, TaskTaskTargetObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_TaskTarget.Count)
			return;
		m_TaskTarget[Index] = v;
	}
	public void AddTaskTarget( TaskTaskTargetObjWraperV1 v )
	{
		m_TaskTarget.Add(v);
	}
	public void ClearTaskTarget( )
	{
		m_TaskTarget.Clear();
	}
	//任务类型
	public int m_TaskType;
	public int TaskType
	{
		get { return m_TaskType;}
		set { m_TaskType = value; }
	}
	//顺序完成目标
	public bool m_IsOrder;
	public bool IsOrder
	{
		get { return m_IsOrder;}
		set { m_IsOrder = value; }
	}
	//是否自动提交
	public bool m_IsAutoSubmit;
	public bool IsAutoSubmit
	{
		get { return m_IsAutoSubmit;}
		set { m_IsAutoSubmit = value; }
	}
	//采集物Id
	public int m_CollectionId;
	public int CollectionId
	{
		get { return m_CollectionId;}
		set { m_CollectionId = value; }
	}
	//任务条件所在副本Id
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//帮派Id
	public int m_Guild;
	public int Guild
	{
		get { return m_Guild;}
		set { m_Guild = value; }
	}
	//ObjId
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}


};
//任务目标对象封装类
[System.Serializable]
public class TaskTaskTargetObjWraperV1
{

	//构造函数
	public TaskTaskTargetObjWraperV1()
	{
		 m_TargetType = -1;
		 m_TargetId = -1;
		 m_CurNum = -1;
		 m_TotalNum = -1;
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TargetType = -1;
		 m_TargetId = -1;
		 m_CurNum = -1;
		 m_TotalNum = -1;
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskTaskTargetObjV1 ToPB()
	{
		TaskTaskTargetObjV1 v = new TaskTaskTargetObjV1();
		v.TargetType = m_TargetType;
		v.TargetId = m_TargetId;
		v.CurNum = m_CurNum;
		v.TotalNum = m_TotalNum;
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskTaskTargetObjV1 v)
	{
        if (v == null)
            return;
		m_TargetType = v.TargetType;
		m_TargetId = v.TargetId;
		m_CurNum = v.CurNum;
		m_TotalNum = v.TotalNum;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskTaskTargetObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskTaskTargetObjV1 pb = ProtoBuf.Serializer.Deserialize<TaskTaskTargetObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//目标类型
	public int m_TargetType;
	public int TargetType
	{
		get { return m_TargetType;}
		set { m_TargetType = value; }
	}
	//目标Id
	public int m_TargetId;
	public int TargetId
	{
		get { return m_TargetId;}
		set { m_TargetId = value; }
	}
	//当前数量
	public int m_CurNum;
	public int CurNum
	{
		get { return m_CurNum;}
		set { m_CurNum = value; }
	}
	//总数量
	public int m_TotalNum;
	public int TotalNum
	{
		get { return m_TotalNum;}
		set { m_TotalNum = value; }
	}
	//第几个目标
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//未接任务对象封装类
[System.Serializable]
public class TaskUnacceptedTaskObjWraperV1
{

	//构造函数
	public TaskUnacceptedTaskObjWraperV1()
	{
		 m_TaskId = -1;
		 m_TaskType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;
		 m_TaskType = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskUnacceptedTaskObjV1 ToPB()
	{
		TaskUnacceptedTaskObjV1 v = new TaskUnacceptedTaskObjV1();
		v.TaskId = m_TaskId;
		v.TaskType = m_TaskType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskUnacceptedTaskObjV1 v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;
		m_TaskType = v.TaskType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskUnacceptedTaskObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskUnacceptedTaskObjV1 pb = ProtoBuf.Serializer.Deserialize<TaskUnacceptedTaskObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}
	//任务类型
	public int m_TaskType;
	public int TaskType
	{
		get { return m_TaskType;}
		set { m_TaskType = value; }
	}


};
