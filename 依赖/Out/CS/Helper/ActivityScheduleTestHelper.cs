#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class ActivityScheduleRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class ActivityScheduleRpcThiefBeOpenedNotifyWraperHelper
{
	public ActivityNpcDataWraper ThiefData;
}
[System.Serializable]
public class ActivityScheduleRpcThiefRefreshNotifyWraperHelper
{
	public List<ActivityNpcDataWraper> ThiefData;
}
[System.Serializable]
public class ActivityScheduleRpcThiefOpenMonsterAskWraperHelper
{
	public ActivityNpcDataWraper ThiefData;
}
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterEnterAskWraperHelper
{
	public ActivityNpcDataWraper SubdueMonsterData;
}
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraperHelper
{
	public ActivityNpcDataWraper SubdueMonsterData;
}
[System.Serializable]
public class ActivityScheduleRpcSubdueMonsterRefreshNotifyWraperHelper
{
	public List<ActivityNpcDataWraper> SubdueMonsterData;
}
[System.Serializable]
public class ActivityScheduleRpcWorldBossEnterDungeonAskWraperHelper
{
}
[System.Serializable]
public class ActivityScheduleRpcWorldBossSyncDataAskWraperHelper
{
}



public class ActivityScheduleTestHelper : MonoBehaviour
{
	public ActivityScheduleRpcSyncDataAskWraperHelper ActivityScheduleRpcSyncDataAskWraperVar;
	public ActivityScheduleRpcThiefBeOpenedNotifyWraperHelper ActivityScheduleRpcThiefBeOpenedNotifyWraperVar;
	public ActivityScheduleRpcThiefRefreshNotifyWraperHelper ActivityScheduleRpcThiefRefreshNotifyWraperVar;
	public ActivityScheduleRpcThiefOpenMonsterAskWraperHelper ActivityScheduleRpcThiefOpenMonsterAskWraperVar;
	public ActivityScheduleRpcSubdueMonsterEnterAskWraperHelper ActivityScheduleRpcSubdueMonsterEnterAskWraperVar;
	public ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraperHelper ActivityScheduleRpcSubdueMonsterBeOpenedNotifyWraperVar;
	public ActivityScheduleRpcSubdueMonsterRefreshNotifyWraperHelper ActivityScheduleRpcSubdueMonsterRefreshNotifyWraperVar;
	public ActivityScheduleRpcWorldBossEnterDungeonAskWraperHelper ActivityScheduleRpcWorldBossEnterDungeonAskWraperVar;
	public ActivityScheduleRpcWorldBossSyncDataAskWraperHelper ActivityScheduleRpcWorldBossSyncDataAskWraperVar;


	public void TestSyncData()
	{
		ActivityScheduleRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestThiefOpenMonster()
	{
		ActivityScheduleRPC.Instance.ThiefOpenMonster(ActivityScheduleRpcThiefOpenMonsterAskWraperVar.ThiefData,delegate(object obj){});
	}
	public void TestSubdueMonsterEnter()
	{
		ActivityScheduleRPC.Instance.SubdueMonsterEnter(ActivityScheduleRpcSubdueMonsterEnterAskWraperVar.SubdueMonsterData,delegate(object obj){});
	}
	public void TestWorldBossEnterDungeon()
	{
		ActivityScheduleRPC.Instance.WorldBossEnterDungeon(delegate(object obj){});
	}
	public void TestWorldBossSyncData()
	{
		ActivityScheduleRPC.Instance.WorldBossSyncData(delegate(object obj){});
	}


}

[CustomEditor(typeof(ActivityScheduleTestHelper))]
public class ActivityScheduleTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			ActivityScheduleTestHelper rpc = target as ActivityScheduleTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("ThiefOpenMonster"))
		{
			ActivityScheduleTestHelper rpc = target as ActivityScheduleTestHelper;
			if( rpc ) rpc.TestThiefOpenMonster();
		}
		if (GUILayout.Button("SubdueMonsterEnter"))
		{
			ActivityScheduleTestHelper rpc = target as ActivityScheduleTestHelper;
			if( rpc ) rpc.TestSubdueMonsterEnter();
		}
		if (GUILayout.Button("WorldBossEnterDungeon"))
		{
			ActivityScheduleTestHelper rpc = target as ActivityScheduleTestHelper;
			if( rpc ) rpc.TestWorldBossEnterDungeon();
		}
		if (GUILayout.Button("WorldBossSyncData"))
		{
			ActivityScheduleTestHelper rpc = target as ActivityScheduleTestHelper;
			if( rpc ) rpc.TestWorldBossSyncData();
		}


    }

}
#endif