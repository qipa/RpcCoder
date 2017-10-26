#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class ActivityStormRpcSignUpAskWraperHelper
{
}
[System.Serializable]
public class ActivityStormRpcCancelSignUpAskWraperHelper
{
}
[System.Serializable]
public class ActivityStormRpcInsertBattlefieldAskWraperHelper
{
}
[System.Serializable]
public class ActivityStormRpcBattlefieldMessageNotifyWraperHelper
{
	public int Time;
}
[System.Serializable]
public class ActivityStormRpcTimeOutMessageNotifyWraperHelper
{
}
[System.Serializable]
public class ActivityStormRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class ActivityStormRpcJoinLevevNotifyNotifyWraperHelper
{
	public long UserID;
	public string NickName;
	public int Type;
}
[System.Serializable]
public class ActivityStormRpcCanceInsertBattleAskWraperHelper
{
}
[System.Serializable]
public class ActivityStormRpcResetSignUpNotifyNotifyWraperHelper
{
	public int Type;
	public int Time;
}



public class ActivityStormTestHelper : MonoBehaviour
{
	public ActivityStormRpcSignUpAskWraperHelper ActivityStormRpcSignUpAskWraperVar;
	public ActivityStormRpcCancelSignUpAskWraperHelper ActivityStormRpcCancelSignUpAskWraperVar;
	public ActivityStormRpcInsertBattlefieldAskWraperHelper ActivityStormRpcInsertBattlefieldAskWraperVar;
	public ActivityStormRpcBattlefieldMessageNotifyWraperHelper ActivityStormRpcBattlefieldMessageNotifyWraperVar;
	public ActivityStormRpcTimeOutMessageNotifyWraperHelper ActivityStormRpcTimeOutMessageNotifyWraperVar;
	public ActivityStormRpcSyncDataAskWraperHelper ActivityStormRpcSyncDataAskWraperVar;
	public ActivityStormRpcJoinLevevNotifyNotifyWraperHelper ActivityStormRpcJoinLevevNotifyNotifyWraperVar;
	public ActivityStormRpcCanceInsertBattleAskWraperHelper ActivityStormRpcCanceInsertBattleAskWraperVar;
	public ActivityStormRpcResetSignUpNotifyNotifyWraperHelper ActivityStormRpcResetSignUpNotifyNotifyWraperVar;


	public void TestSignUp()
	{
		ActivityStormRPC.Instance.SignUp(delegate(object obj){});
	}
	public void TestCancelSignUp()
	{
		ActivityStormRPC.Instance.CancelSignUp(delegate(object obj){});
	}
	public void TestInsertBattlefield()
	{
		ActivityStormRPC.Instance.InsertBattlefield(delegate(object obj){});
	}
	public void TestSyncData()
	{
		ActivityStormRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestCanceInsertBattle()
	{
		ActivityStormRPC.Instance.CanceInsertBattle(delegate(object obj){});
	}


}

[CustomEditor(typeof(ActivityStormTestHelper))]
public class ActivityStormTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SignUp"))
		{
			ActivityStormTestHelper rpc = target as ActivityStormTestHelper;
			if( rpc ) rpc.TestSignUp();
		}
		if (GUILayout.Button("CancelSignUp"))
		{
			ActivityStormTestHelper rpc = target as ActivityStormTestHelper;
			if( rpc ) rpc.TestCancelSignUp();
		}
		if (GUILayout.Button("InsertBattlefield"))
		{
			ActivityStormTestHelper rpc = target as ActivityStormTestHelper;
			if( rpc ) rpc.TestInsertBattlefield();
		}
		if (GUILayout.Button("SyncData"))
		{
			ActivityStormTestHelper rpc = target as ActivityStormTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("CanceInsertBattle"))
		{
			ActivityStormTestHelper rpc = target as ActivityStormTestHelper;
			if( rpc ) rpc.TestCanceInsertBattle();
		}


    }

}
#endif