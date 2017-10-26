#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class FightRpcReadyAskWraperHelper
{
}
[System.Serializable]
public class FightRpcActionNotifyWraperHelper
{
	public byte[] Data;
	public int Frame;
}
[System.Serializable]
public class FightRpcResultNotifyWraperHelper
{
	public int Result;
	public int DengeonId;
	public int Star;
	public int FightTime;
	public List<FightPrizeInfoWraper> PrizeList;
	public List<FightKillInfoWraper> KillList;
	public int FirstStarLight;
	public int SecondStarLight;
	public int ThirdStarLight;
}
[System.Serializable]
public class FightRpcEnterAskWraperHelper
{
	public long UserId;
	public string DungeonKey;
	public string SessionKey;
}
[System.Serializable]
public class FightRpcStartNotifyWraperHelper
{
}



public class FightTestHelper : MonoBehaviour
{
	public FightRpcReadyAskWraperHelper FightRpcReadyAskWraperVar;
	public FightRpcActionNotifyWraperHelper FightRpcActionNotifyWraperVar;
	public FightRpcResultNotifyWraperHelper FightRpcResultNotifyWraperVar;
	public FightRpcEnterAskWraperHelper FightRpcEnterAskWraperVar;
	public FightRpcStartNotifyWraperHelper FightRpcStartNotifyWraperVar;


	public void TestReady()
	{
		FightRPC.Instance.Ready(delegate(object obj){});
	}
	public void TestAction()
	{
		FightRPC.Instance.Action(FightRpcActionNotifyWraperVar.Data,FightRpcActionNotifyWraperVar.Frame);
	}
	public void TestEnter()
	{
		FightRPC.Instance.Enter(FightRpcEnterAskWraperVar.UserId,FightRpcEnterAskWraperVar.DungeonKey,FightRpcEnterAskWraperVar.SessionKey,delegate(object obj){});
	}


}

[CustomEditor(typeof(FightTestHelper))]
public class FightTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("Ready"))
		{
			FightTestHelper rpc = target as FightTestHelper;
			if( rpc ) rpc.TestReady();
		}
		if (GUILayout.Button("Action"))
		{
			FightTestHelper rpc = target as FightTestHelper;
			if( rpc ) rpc.TestAction();
		}
		if (GUILayout.Button("Enter"))
		{
			FightTestHelper rpc = target as FightTestHelper;
			if( rpc ) rpc.TestEnter();
		}


    }

}
#endif