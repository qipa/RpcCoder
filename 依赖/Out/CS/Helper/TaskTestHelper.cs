#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class TaskRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class TaskRpcCompleteTaskAskWraperHelper
{
	public int TaskId;
	public int Target;
}
[System.Serializable]
public class TaskRpcSubmitTaskAskWraperHelper
{
	public int TaskId;
}
[System.Serializable]
public class TaskRpcUpdateTaskNotifyWraperHelper
{
	public int TaskId;
	public int TaskState;
	public List<int> TaskTargetCount;
}
[System.Serializable]
public class TaskRpcAcceptTaskAskWraperHelper
{
	public int TaskId;
}
[System.Serializable]
public class TaskRpcStartProfTaskAskWraperHelper
{
}
[System.Serializable]
public class TaskRpcStartOneDragonAskWraperHelper
{
}
[System.Serializable]
public class TaskRpcAddTaskNotifyWraperHelper
{
	public int TaskId;
	public int TaskState;
}
[System.Serializable]
public class TaskRpcDelTaskNotifyWraperHelper
{
	public int TaskId;
	public int TaskState;
}
[System.Serializable]
public class TaskRpcStartGuildSpyAskWraperHelper
{
}



public class TaskTestHelper : MonoBehaviour
{
	public TaskRpcSyncDataAskWraperHelper TaskRpcSyncDataAskWraperVar;
	public TaskRpcCompleteTaskAskWraperHelper TaskRpcCompleteTaskAskWraperVar;
	public TaskRpcSubmitTaskAskWraperHelper TaskRpcSubmitTaskAskWraperVar;
	public TaskRpcUpdateTaskNotifyWraperHelper TaskRpcUpdateTaskNotifyWraperVar;
	public TaskRpcAcceptTaskAskWraperHelper TaskRpcAcceptTaskAskWraperVar;
	public TaskRpcStartProfTaskAskWraperHelper TaskRpcStartProfTaskAskWraperVar;
	public TaskRpcStartOneDragonAskWraperHelper TaskRpcStartOneDragonAskWraperVar;
	public TaskRpcAddTaskNotifyWraperHelper TaskRpcAddTaskNotifyWraperVar;
	public TaskRpcDelTaskNotifyWraperHelper TaskRpcDelTaskNotifyWraperVar;
	public TaskRpcStartGuildSpyAskWraperHelper TaskRpcStartGuildSpyAskWraperVar;


	public void TestSyncData()
	{
		TaskRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestCompleteTask()
	{
		TaskRPC.Instance.CompleteTask(TaskRpcCompleteTaskAskWraperVar.TaskId,TaskRpcCompleteTaskAskWraperVar.Target,delegate(object obj){});
	}
	public void TestSubmitTask()
	{
		TaskRPC.Instance.SubmitTask(TaskRpcSubmitTaskAskWraperVar.TaskId,delegate(object obj){});
	}
	public void TestAcceptTask()
	{
		TaskRPC.Instance.AcceptTask(TaskRpcAcceptTaskAskWraperVar.TaskId,delegate(object obj){});
	}
	public void TestStartProfTask()
	{
		TaskRPC.Instance.StartProfTask(delegate(object obj){});
	}
	public void TestStartOneDragon()
	{
		TaskRPC.Instance.StartOneDragon(delegate(object obj){});
	}
	public void TestStartGuildSpy()
	{
		TaskRPC.Instance.StartGuildSpy(delegate(object obj){});
	}


}

[CustomEditor(typeof(TaskTestHelper))]
public class TaskTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("CompleteTask"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestCompleteTask();
		}
		if (GUILayout.Button("SubmitTask"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestSubmitTask();
		}
		if (GUILayout.Button("AcceptTask"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestAcceptTask();
		}
		if (GUILayout.Button("StartProfTask"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestStartProfTask();
		}
		if (GUILayout.Button("StartOneDragon"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestStartOneDragon();
		}
		if (GUILayout.Button("StartGuildSpy"))
		{
			TaskTestHelper rpc = target as TaskTestHelper;
			if( rpc ) rpc.TestStartGuildSpy();
		}


    }

}
#endif