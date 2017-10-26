#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class AchievementRpcGetTheRewardsAskWraperHelper
{
	public int GroupId;
}
[System.Serializable]
public class AchievementRpcSyncDataAskWraperHelper
{
}



public class AchievementTestHelper : MonoBehaviour
{
	public AchievementRpcGetTheRewardsAskWraperHelper AchievementRpcGetTheRewardsAskWraperVar;
	public AchievementRpcSyncDataAskWraperHelper AchievementRpcSyncDataAskWraperVar;


	public void TestGetTheRewards()
	{
		AchievementRPC.Instance.GetTheRewards(AchievementRpcGetTheRewardsAskWraperVar.GroupId,delegate(object obj){});
	}
	public void TestSyncData()
	{
		AchievementRPC.Instance.SyncData(delegate(object obj){});
	}


}

[CustomEditor(typeof(AchievementTestHelper))]
public class AchievementTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("GetTheRewards"))
		{
			AchievementTestHelper rpc = target as AchievementTestHelper;
			if( rpc ) rpc.TestGetTheRewards();
		}
		if (GUILayout.Button("SyncData"))
		{
			AchievementTestHelper rpc = target as AchievementTestHelper;
			if( rpc ) rpc.TestSyncData();
		}


    }

}
#endif