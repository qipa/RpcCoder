#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class PersistAttrRpcSyncDataAskWraperHelper
{
}



public class PersistAttrTestHelper : MonoBehaviour
{
	public PersistAttrRpcSyncDataAskWraperHelper PersistAttrRpcSyncDataAskWraperVar;


	public void TestSyncData()
	{
		PersistAttrRPC.Instance.SyncData(delegate(object obj){});
	}


}

[CustomEditor(typeof(PersistAttrTestHelper))]
public class PersistAttrTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			PersistAttrTestHelper rpc = target as PersistAttrTestHelper;
			if( rpc ) rpc.TestSyncData();
		}


    }

}
#endif