#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class TalismanRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class TalismanRpcUpgradeAskWraperHelper
{
	public int ID;
	public int Type;
}
[System.Serializable]
public class TalismanRpcActiveAskWraperHelper
{
	public int ID;
}



public class TalismanTestHelper : MonoBehaviour
{
	public TalismanRpcSyncDataAskWraperHelper TalismanRpcSyncDataAskWraperVar;
	public TalismanRpcUpgradeAskWraperHelper TalismanRpcUpgradeAskWraperVar;
	public TalismanRpcActiveAskWraperHelper TalismanRpcActiveAskWraperVar;


	public void TestSyncData()
	{
		TalismanRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestActive()
	{
		TalismanRPC.Instance.Active(TalismanRpcActiveAskWraperVar.ID,delegate(object obj){});
	}
	public void TestUpgrade()
	{
		TalismanRPC.Instance.Upgrade(TalismanRpcUpgradeAskWraperVar.ID,TalismanRpcUpgradeAskWraperVar.Type,delegate(object obj){});
	}


}

[CustomEditor(typeof(TalismanTestHelper))]
public class TalismanTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			TalismanTestHelper rpc = target as TalismanTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Active"))
		{
			TalismanTestHelper rpc = target as TalismanTestHelper;
			if( rpc ) rpc.TestActive();
		}
		if (GUILayout.Button("Upgrade"))
		{
			TalismanTestHelper rpc = target as TalismanTestHelper;
			if( rpc ) rpc.TestUpgrade();
		}


    }

}
#endif