#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class StoryDungeonRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class StoryDungeonRpcChallengeAskWraperHelper
{
	public int Id;
}
[System.Serializable]
public class StoryDungeonRpcWaitForConfirmationNotifyWraperHelper
{
	public int Id;
}
[System.Serializable]
public class StoryDungeonRpcConfirmEnterAskWraperHelper
{
	public bool IsAgree;
}
[System.Serializable]
public class StoryDungeonRpcPlayerConfirmResultNotifyWraperHelper
{
	public long UserId;
	public string UserName;
	public bool IsAgree;
}



public class StoryDungeonTestHelper : MonoBehaviour
{
	public StoryDungeonRpcSyncDataAskWraperHelper StoryDungeonRpcSyncDataAskWraperVar;
	public StoryDungeonRpcChallengeAskWraperHelper StoryDungeonRpcChallengeAskWraperVar;
	public StoryDungeonRpcWaitForConfirmationNotifyWraperHelper StoryDungeonRpcWaitForConfirmationNotifyWraperVar;
	public StoryDungeonRpcConfirmEnterAskWraperHelper StoryDungeonRpcConfirmEnterAskWraperVar;
	public StoryDungeonRpcPlayerConfirmResultNotifyWraperHelper StoryDungeonRpcPlayerConfirmResultNotifyWraperVar;


	public void TestSyncData()
	{
		StoryDungeonRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestChallenge()
	{
		StoryDungeonRPC.Instance.Challenge(StoryDungeonRpcChallengeAskWraperVar.Id,delegate(object obj){});
	}
	public void TestConfirmEnter()
	{
		StoryDungeonRPC.Instance.ConfirmEnter(StoryDungeonRpcConfirmEnterAskWraperVar.IsAgree,delegate(object obj){});
	}


}

[CustomEditor(typeof(StoryDungeonTestHelper))]
public class StoryDungeonTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			StoryDungeonTestHelper rpc = target as StoryDungeonTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Challenge"))
		{
			StoryDungeonTestHelper rpc = target as StoryDungeonTestHelper;
			if( rpc ) rpc.TestChallenge();
		}
		if (GUILayout.Button("ConfirmEnter"))
		{
			StoryDungeonTestHelper rpc = target as StoryDungeonTestHelper;
			if( rpc ) rpc.TestConfirmEnter();
		}


    }

}
#endif