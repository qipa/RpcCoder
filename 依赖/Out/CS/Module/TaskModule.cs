/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleTask.cs
Author:
Description:
Version:	  1.0
History:
  <author>  <time>   <version >   <desc>

***********************************************************/
using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class TaskRPC
{
	public const int ModuleId = 24;
	
	public const int RPC_CODE_TASK_SYNCDATA_REQUEST = 2451;
	public const int RPC_CODE_TASK_COMPLETETASK_REQUEST = 2452;
	public const int RPC_CODE_TASK_SUBMITTASK_REQUEST = 2453;
	public const int RPC_CODE_TASK_UPDATETASK_NOTIFY = 2454;
	public const int RPC_CODE_TASK_ACCEPTTASK_REQUEST = 2455;
	public const int RPC_CODE_TASK_STARTPROFTASK_REQUEST = 2456;
	public const int RPC_CODE_TASK_STARTONEDRAGON_REQUEST = 2457;
	public const int RPC_CODE_TASK_ADDTASK_NOTIFY = 2458;
	public const int RPC_CODE_TASK_DELTASK_NOTIFY = 2459;
	public const int RPC_CODE_TASK_STARTGUILDSPY_REQUEST = 2460;

	
	private static TaskRPC m_Instance = null;
	public static TaskRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TaskRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, TaskData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TASK_UPDATETASK_NOTIFY, UpdateTaskCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TASK_ADDTASK_NOTIFY, AddTaskCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TASK_DELTASK_NOTIFY, DelTaskCB);


		return true;
	}


	/**
	*任务-->数据同步 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		TaskRpcSyncDataAskWraper askPBWraper = new TaskRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcSyncDataReplyWraper replyPBWraper = new TaskRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*任务-->完成任务目标 RPC请求
	*/
	public void CompleteTask(int TaskId, int Target, ReplyHandler replyCB)
	{
		TaskRpcCompleteTaskAskWraper askPBWraper = new TaskRpcCompleteTaskAskWraper();
		askPBWraper.TaskId = TaskId;
		askPBWraper.Target = Target;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_COMPLETETASK_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcCompleteTaskReplyWraper replyPBWraper = new TaskRpcCompleteTaskReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*任务-->提交任务 RPC请求
	*/
	public void SubmitTask(int TaskId, ReplyHandler replyCB)
	{
		TaskRpcSubmitTaskAskWraper askPBWraper = new TaskRpcSubmitTaskAskWraper();
		askPBWraper.TaskId = TaskId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_SUBMITTASK_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcSubmitTaskReplyWraper replyPBWraper = new TaskRpcSubmitTaskReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*任务-->接受任务 RPC请求
	*/
	public void AcceptTask(int TaskId, ReplyHandler replyCB)
	{
		TaskRpcAcceptTaskAskWraper askPBWraper = new TaskRpcAcceptTaskAskWraper();
		askPBWraper.TaskId = TaskId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_ACCEPTTASK_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcAcceptTaskReplyWraper replyPBWraper = new TaskRpcAcceptTaskReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*任务-->开始师门任务 RPC请求
	*/
	public void StartProfTask(ReplyHandler replyCB)
	{
		TaskRpcStartProfTaskAskWraper askPBWraper = new TaskRpcStartProfTaskAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_STARTPROFTASK_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcStartProfTaskReplyWraper replyPBWraper = new TaskRpcStartProfTaskReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*任务-->开始一条龙 RPC请求
	*/
	public void StartOneDragon(ReplyHandler replyCB)
	{
		TaskRpcStartOneDragonAskWraper askPBWraper = new TaskRpcStartOneDragonAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_STARTONEDRAGON_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcStartOneDragonReplyWraper replyPBWraper = new TaskRpcStartOneDragonReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*任务-->开始帮会刺探 RPC请求
	*/
	public void StartGuildSpy(ReplyHandler replyCB)
	{
		TaskRpcStartGuildSpyAskWraper askPBWraper = new TaskRpcStartGuildSpyAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TASK_STARTGUILDSPY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TaskRpcStartGuildSpyReplyWraper replyPBWraper = new TaskRpcStartGuildSpyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*任务-->更新任务 服务器通知回调
	*/
	public static void UpdateTaskCB( ModMessage notifyMsg )
	{
		TaskRpcUpdateTaskNotifyWraper notifyPBWraper = new TaskRpcUpdateTaskNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( UpdateTaskCBDelegate != null )
			UpdateTaskCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback UpdateTaskCBDelegate = null;
	/**
	*任务-->增加任务 服务器通知回调
	*/
	public static void AddTaskCB( ModMessage notifyMsg )
	{
		TaskRpcAddTaskNotifyWraper notifyPBWraper = new TaskRpcAddTaskNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( AddTaskCBDelegate != null )
			AddTaskCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback AddTaskCBDelegate = null;
	/**
	*任务-->删除任务 服务器通知回调
	*/
	public static void DelTaskCB( ModMessage notifyMsg )
	{
		TaskRpcDelTaskNotifyWraper notifyPBWraper = new TaskRpcDelTaskNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( DelTaskCBDelegate != null )
			DelTaskCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback DelTaskCBDelegate = null;



}

public class TaskData
{
	public enum SyncIdE
	{
 		ALLTASKARRAY                               = 2402,  //全部任务数组
 		UNACCEPTEDTASKARRAY                        = 2403,  //可接任务
 		PROFTASKID                                 = 2404,  //师门任务环数
 		PROFTASKCOMPCOUNT                          = 2405,  //师门任务完成次数
 		ONEDRAGONTASKID                            = 2406,  //使用过的一条龙任务Id
 		ONEDRAGONRINGNUM                           = 2407,  //一条龙环数
 		ONEDRAGONCOMPLATECOUNT                     = 2408,  //一条龙完成次数
 		ONEDRAGONDUNGEONID                         = 2409,  //一条龙副本Id
 		GUILDSPYCOMPLATECOUNT                      = 2410,  //帮会刺探完成次数

	}
	
	private static TaskData m_Instance = null;
	public static TaskData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TaskData();
			}
			return m_Instance;

		}
	}
	

	public void UpdateField(int Id, int Index, byte[] buff, int start, int len )
	{
		SyncIdE SyncId = (SyncIdE)Id;
		byte[]  updateBuffer = new byte[len];
		Array.Copy(buff, start, updateBuffer, 0, len);
		int  iValue = 0;
		long lValue = 0;

		switch (SyncId)
		{
			case SyncIdE.ALLTASKARRAY:
				if(Index < 0){ m_Instance.ClearAllTaskArray(); break; }
				if (Index >= m_Instance.SizeAllTaskArray())
				{
					int Count = Index - m_Instance.SizeAllTaskArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddAllTaskArray(new TaskTaskObjWraperV1());
				}
				m_Instance.GetAllTaskArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.UNACCEPTEDTASKARRAY:
				if(Index < 0){ m_Instance.ClearUnacceptedTaskArray(); break; }
				if (Index >= m_Instance.SizeUnacceptedTaskArray())
				{
					int Count = Index - m_Instance.SizeUnacceptedTaskArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddUnacceptedTaskArray(new TaskUnacceptedTaskObjWraperV1());
				}
				m_Instance.GetUnacceptedTaskArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.PROFTASKID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ProfTaskId = iValue;
				break;
			case SyncIdE.PROFTASKCOMPCOUNT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ProfTaskCompCount = iValue;
				break;
			case SyncIdE.ONEDRAGONTASKID:
				if(Index < 0){ m_Instance.ClearOneDragonTaskId(); break; }
				if (Index >= m_Instance.SizeOneDragonTaskId())
				{
					int Count = Index - m_Instance.SizeOneDragonTaskId() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddOneDragonTaskId(-1);
				}
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SetOneDragonTaskId(Index, iValue);
				break;
			case SyncIdE.ONEDRAGONRINGNUM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.OneDragonRingNum = iValue;
				break;
			case SyncIdE.ONEDRAGONCOMPLATECOUNT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.OneDragonComplateCount = iValue;
				break;
			case SyncIdE.ONEDRAGONDUNGEONID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.OneDragonDungeonId = iValue;
				break;
			case SyncIdE.GUILDSPYCOMPLATECOUNT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.GuildSpyComplateCount = iValue;
				break;

			default:
				break;
		}

		try
		{
			if (NotifySyncValueChanged!=null)
				NotifySyncValueChanged(Id, Index);
		}
		catch
		{
			Ex.Logger.Log("TaskData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public TaskData()
	{
		m_AllTaskArray = new List<TaskTaskObjWraperV1>();
		m_UnacceptedTaskArray = new List<TaskUnacceptedTaskObjWraperV1>();
		 m_ProfTaskId = 0;
		 m_ProfTaskCompCount = 0;
		m_OneDragonTaskId = new List<int>();
		 m_OneDragonRingNum = 0;
		 m_OneDragonComplateCount = 0;
		 m_OneDragonDungeonId = -1;
		 m_GuildSpyComplateCount = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		m_AllTaskArray = new List<TaskTaskObjWraperV1>();
		m_UnacceptedTaskArray = new List<TaskUnacceptedTaskObjWraperV1>();
		 m_ProfTaskId = 0;
		 m_ProfTaskCompCount = 0;
		m_OneDragonTaskId = new List<int>();
		 m_OneDragonRingNum = 0;
		 m_OneDragonComplateCount = 0;
		 m_OneDragonDungeonId = -1;
		 m_GuildSpyComplateCount = 0;

	}

 	//转化成Protobuffer类型函数
	public TaskTaskDataV1 ToPB()
	{
		TaskTaskDataV1 v = new TaskTaskDataV1();
		for (int i=0; i<(int)m_AllTaskArray.Count; i++)
			v.AllTaskArray.Add( m_AllTaskArray[i].ToPB());
		for (int i=0; i<(int)m_UnacceptedTaskArray.Count; i++)
			v.UnacceptedTaskArray.Add( m_UnacceptedTaskArray[i].ToPB());
		v.ProfTaskId = m_ProfTaskId;
		v.ProfTaskCompCount = m_ProfTaskCompCount;
		for (int i=0; i<(int)m_OneDragonTaskId.Count; i++)
			v.OneDragonTaskId.Add( m_OneDragonTaskId[i]);
		v.OneDragonRingNum = m_OneDragonRingNum;
		v.OneDragonComplateCount = m_OneDragonComplateCount;
		v.OneDragonDungeonId = m_OneDragonDungeonId;
		v.GuildSpyComplateCount = m_GuildSpyComplateCount;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TaskTaskDataV1 v)
	{
        if (v == null)
            return;
		m_AllTaskArray.Clear();
		for( int i=0; i<v.AllTaskArray.Count; i++)
			m_AllTaskArray.Add( new TaskTaskObjWraperV1());
		for( int i=0; i<v.AllTaskArray.Count; i++)
			m_AllTaskArray[i].FromPB(v.AllTaskArray[i]);
		m_UnacceptedTaskArray.Clear();
		for( int i=0; i<v.UnacceptedTaskArray.Count; i++)
			m_UnacceptedTaskArray.Add( new TaskUnacceptedTaskObjWraperV1());
		for( int i=0; i<v.UnacceptedTaskArray.Count; i++)
			m_UnacceptedTaskArray[i].FromPB(v.UnacceptedTaskArray[i]);
		m_ProfTaskId = v.ProfTaskId;
		m_ProfTaskCompCount = v.ProfTaskCompCount;
		m_OneDragonTaskId.Clear();
		for( int i=0; i<v.OneDragonTaskId.Count; i++)
			m_OneDragonTaskId.Add(v.OneDragonTaskId[i]);
		m_OneDragonRingNum = v.OneDragonRingNum;
		m_OneDragonComplateCount = v.OneDragonComplateCount;
		m_OneDragonDungeonId = v.OneDragonDungeonId;
		m_GuildSpyComplateCount = v.GuildSpyComplateCount;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TaskTaskDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TaskTaskDataV1 pb = ProtoBuf.Serializer.Deserialize<TaskTaskDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//全部任务数组
	public List<TaskTaskObjWraperV1> m_AllTaskArray;
	public int SizeAllTaskArray()
	{
		return m_AllTaskArray.Count;
	}
	public List<TaskTaskObjWraperV1> GetAllTaskArray()
	{
		return m_AllTaskArray;
	}
	public TaskTaskObjWraperV1 GetAllTaskArray(int Index)
	{
		if(Index<0 || Index>=(int)m_AllTaskArray.Count)
			return new TaskTaskObjWraperV1();
		return m_AllTaskArray[Index];
	}
	public void SetAllTaskArray( List<TaskTaskObjWraperV1> v )
	{
		m_AllTaskArray=v;
	}
	public void SetAllTaskArray( int Index, TaskTaskObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_AllTaskArray.Count)
			return;
		m_AllTaskArray[Index] = v;
	}
	public void AddAllTaskArray( TaskTaskObjWraperV1 v )
	{
		m_AllTaskArray.Add(v);
	}
	public void ClearAllTaskArray( )
	{
		m_AllTaskArray.Clear();
	}
	//可接任务
	public List<TaskUnacceptedTaskObjWraperV1> m_UnacceptedTaskArray;
	public int SizeUnacceptedTaskArray()
	{
		return m_UnacceptedTaskArray.Count;
	}
	public List<TaskUnacceptedTaskObjWraperV1> GetUnacceptedTaskArray()
	{
		return m_UnacceptedTaskArray;
	}
	public TaskUnacceptedTaskObjWraperV1 GetUnacceptedTaskArray(int Index)
	{
		if(Index<0 || Index>=(int)m_UnacceptedTaskArray.Count)
			return new TaskUnacceptedTaskObjWraperV1();
		return m_UnacceptedTaskArray[Index];
	}
	public void SetUnacceptedTaskArray( List<TaskUnacceptedTaskObjWraperV1> v )
	{
		m_UnacceptedTaskArray=v;
	}
	public void SetUnacceptedTaskArray( int Index, TaskUnacceptedTaskObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_UnacceptedTaskArray.Count)
			return;
		m_UnacceptedTaskArray[Index] = v;
	}
	public void AddUnacceptedTaskArray( TaskUnacceptedTaskObjWraperV1 v )
	{
		m_UnacceptedTaskArray.Add(v);
	}
	public void ClearUnacceptedTaskArray( )
	{
		m_UnacceptedTaskArray.Clear();
	}
	//师门任务环数
	public int m_ProfTaskId;
	public int ProfTaskId
	{
		get { return m_ProfTaskId;}
		set { m_ProfTaskId = value; }
	}
	//师门任务完成次数
	public int m_ProfTaskCompCount;
	public int ProfTaskCompCount
	{
		get { return m_ProfTaskCompCount;}
		set { m_ProfTaskCompCount = value; }
	}
	//使用过的一条龙任务Id
	public List<int> m_OneDragonTaskId;
	public int SizeOneDragonTaskId()
	{
		return m_OneDragonTaskId.Count;
	}
	public List<int> GetOneDragonTaskId()
	{
		return m_OneDragonTaskId;
	}
	public int GetOneDragonTaskId(int Index)
	{
		if(Index<0 || Index>=(int)m_OneDragonTaskId.Count)
			return -1;
		return m_OneDragonTaskId[Index];
	}
	public void SetOneDragonTaskId( List<int> v )
	{
		m_OneDragonTaskId=v;
	}
	public void SetOneDragonTaskId( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_OneDragonTaskId.Count)
			return;
		m_OneDragonTaskId[Index] = v;
	}
	public void AddOneDragonTaskId( int v=-1 )
	{
		m_OneDragonTaskId.Add(v);
	}
	public void ClearOneDragonTaskId( )
	{
		m_OneDragonTaskId.Clear();
	}
	//一条龙环数
	public int m_OneDragonRingNum;
	public int OneDragonRingNum
	{
		get { return m_OneDragonRingNum;}
		set { m_OneDragonRingNum = value; }
	}
	//一条龙完成次数
	public int m_OneDragonComplateCount;
	public int OneDragonComplateCount
	{
		get { return m_OneDragonComplateCount;}
		set { m_OneDragonComplateCount = value; }
	}
	//一条龙副本Id
	public int m_OneDragonDungeonId;
	public int OneDragonDungeonId
	{
		get { return m_OneDragonDungeonId;}
		set { m_OneDragonDungeonId = value; }
	}
	//帮会刺探完成次数
	public int m_GuildSpyComplateCount;
	public int GuildSpyComplateCount
	{
		get { return m_GuildSpyComplateCount;}
		set { m_GuildSpyComplateCount = value; }
	}



}
