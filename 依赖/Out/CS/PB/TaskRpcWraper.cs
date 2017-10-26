
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBTask.cs
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
public class TaskRpcSyncDataAskWraper
{

	//构造函数
	public TaskRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TaskRpcSyncDataAsk ToPB()
	{
		TaskRpcSyncDataAsk v = new TaskRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class TaskRpcSyncDataReplyWraper
{

	//构造函数
	public TaskRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcSyncDataReply ToPB()
	{
		TaskRpcSyncDataReply v = new TaskRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcSyncDataReply>(protoMS);
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
//完成任务目标请求封装类
[System.Serializable]
public class TaskRpcCompleteTaskAskWraper
{

	//构造函数
	public TaskRpcCompleteTaskAskWraper()
	{
		 m_TaskId = -1;
		 m_Target = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;
		 m_Target = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcCompleteTaskAsk ToPB()
	{
		TaskRpcCompleteTaskAsk v = new TaskRpcCompleteTaskAsk();
		v.TaskId = m_TaskId;
		v.Target = m_Target;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcCompleteTaskAsk v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;
		m_Target = v.Target;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcCompleteTaskAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcCompleteTaskAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcCompleteTaskAsk>(protoMS);
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
	//目标
	public int m_Target;
	public int Target
	{
		get { return m_Target;}
		set { m_Target = value; }
	}


};
//完成任务目标回应封装类
[System.Serializable]
public class TaskRpcCompleteTaskReplyWraper
{

	//构造函数
	public TaskRpcCompleteTaskReplyWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;
		 m_Target = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;
		 m_Target = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcCompleteTaskReply ToPB()
	{
		TaskRpcCompleteTaskReply v = new TaskRpcCompleteTaskReply();
		v.Result = m_Result;
		v.TaskId = m_TaskId;
		v.Target = m_Target;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcCompleteTaskReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TaskId = v.TaskId;
		m_Target = v.Target;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcCompleteTaskReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcCompleteTaskReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcCompleteTaskReply>(protoMS);
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
	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}
	//目标
	public int m_Target;
	public int Target
	{
		get { return m_Target;}
		set { m_Target = value; }
	}


};
//提交任务请求封装类
[System.Serializable]
public class TaskRpcSubmitTaskAskWraper
{

	//构造函数
	public TaskRpcSubmitTaskAskWraper()
	{
		 m_TaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcSubmitTaskAsk ToPB()
	{
		TaskRpcSubmitTaskAsk v = new TaskRpcSubmitTaskAsk();
		v.TaskId = m_TaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcSubmitTaskAsk v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcSubmitTaskAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcSubmitTaskAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcSubmitTaskAsk>(protoMS);
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


};
//提交任务回应封装类
[System.Serializable]
public class TaskRpcSubmitTaskReplyWraper
{

	//构造函数
	public TaskRpcSubmitTaskReplyWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;
		 m_NextTaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;
		 m_NextTaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcSubmitTaskReply ToPB()
	{
		TaskRpcSubmitTaskReply v = new TaskRpcSubmitTaskReply();
		v.Result = m_Result;
		v.TaskId = m_TaskId;
		v.NextTaskId = m_NextTaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcSubmitTaskReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TaskId = v.TaskId;
		m_NextTaskId = v.NextTaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcSubmitTaskReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcSubmitTaskReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcSubmitTaskReply>(protoMS);
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
	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}
	//下一个任务id
	public int m_NextTaskId;
	public int NextTaskId
	{
		get { return m_NextTaskId;}
		set { m_NextTaskId = value; }
	}


};
//更新任务通知封装类
[System.Serializable]
public class TaskRpcUpdateTaskNotifyWraper
{

	//构造函数
	public TaskRpcUpdateTaskNotifyWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;
		m_TaskTargetCount = new List<int>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;
		m_TaskTargetCount = new List<int>();

	}

 	//转化成Protobuffer类型函数
	public TaskRpcUpdateTaskNotify ToPB()
	{
		TaskRpcUpdateTaskNotify v = new TaskRpcUpdateTaskNotify();
		v.TaskId = m_TaskId;
		v.TaskState = m_TaskState;
		for (int i=0; i<(int)m_TaskTargetCount.Count; i++)
			v.TaskTargetCount.Add( m_TaskTargetCount[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcUpdateTaskNotify v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;
		m_TaskState = v.TaskState;
		m_TaskTargetCount.Clear();
		for( int i=0; i<v.TaskTargetCount.Count; i++)
			m_TaskTargetCount.Add(v.TaskTargetCount[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcUpdateTaskNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcUpdateTaskNotify pb = ProtoBuf.Serializer.Deserialize<TaskRpcUpdateTaskNotify>(protoMS);
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
	//任务目标数量
	public List<int> m_TaskTargetCount;
	public int SizeTaskTargetCount()
	{
		return m_TaskTargetCount.Count;
	}
	public List<int> GetTaskTargetCount()
	{
		return m_TaskTargetCount;
	}
	public int GetTaskTargetCount(int Index)
	{
		if(Index<0 || Index>=(int)m_TaskTargetCount.Count)
			return -1;
		return m_TaskTargetCount[Index];
	}
	public void SetTaskTargetCount( List<int> v )
	{
		m_TaskTargetCount=v;
	}
	public void SetTaskTargetCount( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_TaskTargetCount.Count)
			return;
		m_TaskTargetCount[Index] = v;
	}
	public void AddTaskTargetCount( int v=-1 )
	{
		m_TaskTargetCount.Add(v);
	}
	public void ClearTaskTargetCount( )
	{
		m_TaskTargetCount.Clear();
	}


};
//接受任务请求封装类
[System.Serializable]
public class TaskRpcAcceptTaskAskWraper
{

	//构造函数
	public TaskRpcAcceptTaskAskWraper()
	{
		 m_TaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcAcceptTaskAsk ToPB()
	{
		TaskRpcAcceptTaskAsk v = new TaskRpcAcceptTaskAsk();
		v.TaskId = m_TaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcAcceptTaskAsk v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcAcceptTaskAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcAcceptTaskAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcAcceptTaskAsk>(protoMS);
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


};
//接受任务回应封装类
[System.Serializable]
public class TaskRpcAcceptTaskReplyWraper
{

	//构造函数
	public TaskRpcAcceptTaskReplyWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcAcceptTaskReply ToPB()
	{
		TaskRpcAcceptTaskReply v = new TaskRpcAcceptTaskReply();
		v.Result = m_Result;
		v.TaskId = m_TaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcAcceptTaskReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TaskId = v.TaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcAcceptTaskReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcAcceptTaskReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcAcceptTaskReply>(protoMS);
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
	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}


};
//开始师门任务请求封装类
[System.Serializable]
public class TaskRpcStartProfTaskAskWraper
{

	//构造函数
	public TaskRpcStartProfTaskAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TaskRpcStartProfTaskAsk ToPB()
	{
		TaskRpcStartProfTaskAsk v = new TaskRpcStartProfTaskAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcStartProfTaskAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcStartProfTaskAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcStartProfTaskAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcStartProfTaskAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//开始师门任务回应封装类
[System.Serializable]
public class TaskRpcStartProfTaskReplyWraper
{

	//构造函数
	public TaskRpcStartProfTaskReplyWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcStartProfTaskReply ToPB()
	{
		TaskRpcStartProfTaskReply v = new TaskRpcStartProfTaskReply();
		v.Result = m_Result;
		v.TaskId = m_TaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcStartProfTaskReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TaskId = v.TaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcStartProfTaskReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcStartProfTaskReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcStartProfTaskReply>(protoMS);
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
	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}


};
//开始一条龙请求封装类
[System.Serializable]
public class TaskRpcStartOneDragonAskWraper
{

	//构造函数
	public TaskRpcStartOneDragonAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TaskRpcStartOneDragonAsk ToPB()
	{
		TaskRpcStartOneDragonAsk v = new TaskRpcStartOneDragonAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcStartOneDragonAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcStartOneDragonAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcStartOneDragonAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcStartOneDragonAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//开始一条龙回应封装类
[System.Serializable]
public class TaskRpcStartOneDragonReplyWraper
{

	//构造函数
	public TaskRpcStartOneDragonReplyWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcStartOneDragonReply ToPB()
	{
		TaskRpcStartOneDragonReply v = new TaskRpcStartOneDragonReply();
		v.Result = m_Result;
		v.TaskId = m_TaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcStartOneDragonReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TaskId = v.TaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcStartOneDragonReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcStartOneDragonReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcStartOneDragonReply>(protoMS);
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
	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}


};
//增加任务通知封装类
[System.Serializable]
public class TaskRpcAddTaskNotifyWraper
{

	//构造函数
	public TaskRpcAddTaskNotifyWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcAddTaskNotify ToPB()
	{
		TaskRpcAddTaskNotify v = new TaskRpcAddTaskNotify();
		v.TaskId = m_TaskId;
		v.TaskState = m_TaskState;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcAddTaskNotify v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;
		m_TaskState = v.TaskState;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcAddTaskNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcAddTaskNotify pb = ProtoBuf.Serializer.Deserialize<TaskRpcAddTaskNotify>(protoMS);
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


};
//删除任务通知封装类
[System.Serializable]
public class TaskRpcDelTaskNotifyWraper
{

	//构造函数
	public TaskRpcDelTaskNotifyWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TaskId = -1;
		 m_TaskState = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcDelTaskNotify ToPB()
	{
		TaskRpcDelTaskNotify v = new TaskRpcDelTaskNotify();
		v.TaskId = m_TaskId;
		v.TaskState = m_TaskState;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcDelTaskNotify v)
	{
        if (v == null)
            return;
		m_TaskId = v.TaskId;
		m_TaskState = v.TaskState;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcDelTaskNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcDelTaskNotify pb = ProtoBuf.Serializer.Deserialize<TaskRpcDelTaskNotify>(protoMS);
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


};
//开始帮会刺探请求封装类
[System.Serializable]
public class TaskRpcStartGuildSpyAskWraper
{

	//构造函数
	public TaskRpcStartGuildSpyAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TaskRpcStartGuildSpyAsk ToPB()
	{
		TaskRpcStartGuildSpyAsk v = new TaskRpcStartGuildSpyAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcStartGuildSpyAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcStartGuildSpyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcStartGuildSpyAsk pb = ProtoBuf.Serializer.Deserialize<TaskRpcStartGuildSpyAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//开始帮会刺探回应封装类
[System.Serializable]
public class TaskRpcStartGuildSpyReplyWraper
{

	//构造函数
	public TaskRpcStartGuildSpyReplyWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TaskId = -1;

	}

 	//转化成Protobuffer类型函数
	public TaskRpcStartGuildSpyReply ToPB()
	{
		TaskRpcStartGuildSpyReply v = new TaskRpcStartGuildSpyReply();
		v.Result = m_Result;
		v.TaskId = m_TaskId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskRpcStartGuildSpyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TaskId = v.TaskId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskRpcStartGuildSpyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskRpcStartGuildSpyReply pb = ProtoBuf.Serializer.Deserialize<TaskRpcStartGuildSpyReply>(protoMS);
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
	//任务Id
	public int m_TaskId;
	public int TaskId
	{
		get { return m_TaskId;}
		set { m_TaskId = value; }
	}


};
