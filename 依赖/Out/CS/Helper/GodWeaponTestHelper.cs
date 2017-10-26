#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class GodWeaponRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class GodWeaponRpcAwakenAskWraperHelper
{
	public int Id;
}
[System.Serializable]
public class GodWeaponRpcInlayAskWraperHelper
{
	public int Id;
	public int GemId;
	public int Pos;
}
[System.Serializable]
public class GodWeaponRpcUnloadAskWraperHelper
{
	public int Id;
	public int Pos;
}
[System.Serializable]
public class GodWeaponRpcCompoundAskWraperHelper
{
}



public class GodWeaponTestHelper : MonoBehaviour
{
	public GodWeaponRpcSyncDataAskWraperHelper GodWeaponRpcSyncDataAskWraperVar;
	public GodWeaponRpcAwakenAskWraperHelper GodWeaponRpcAwakenAskWraperVar;
	public GodWeaponRpcInlayAskWraperHelper GodWeaponRpcInlayAskWraperVar;
	public GodWeaponRpcUnloadAskWraperHelper GodWeaponRpcUnloadAskWraperVar;
	public GodWeaponRpcCompoundAskWraperHelper GodWeaponRpcCompoundAskWraperVar;


	public void TestSyncData()
	{
		GodWeaponRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestAwaken()
	{
		GodWeaponRPC.Instance.Awaken(GodWeaponRpcAwakenAskWraperVar.Id,delegate(object obj){});
	}
	public void TestInlay()
	{
		GodWeaponRPC.Instance.Inlay(GodWeaponRpcInlayAskWraperVar.Id,GodWeaponRpcInlayAskWraperVar.GemId,GodWeaponRpcInlayAskWraperVar.Pos,delegate(object obj){});
	}
	public void TestUnload()
	{
		GodWeaponRPC.Instance.Unload(GodWeaponRpcUnloadAskWraperVar.Id,GodWeaponRpcUnloadAskWraperVar.Pos,delegate(object obj){});
	}
	public void TestCompound()
	{
		GodWeaponRPC.Instance.Compound(delegate(object obj){});
	}


}

[CustomEditor(typeof(GodWeaponTestHelper))]
public class GodWeaponTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			GodWeaponTestHelper rpc = target as GodWeaponTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Awaken"))
		{
			GodWeaponTestHelper rpc = target as GodWeaponTestHelper;
			if( rpc ) rpc.TestAwaken();
		}
		if (GUILayout.Button("Inlay"))
		{
			GodWeaponTestHelper rpc = target as GodWeaponTestHelper;
			if( rpc ) rpc.TestInlay();
		}
		if (GUILayout.Button("Unload"))
		{
			GodWeaponTestHelper rpc = target as GodWeaponTestHelper;
			if( rpc ) rpc.TestUnload();
		}
		if (GUILayout.Button("Compound"))
		{
			GodWeaponTestHelper rpc = target as GodWeaponTestHelper;
			if( rpc ) rpc.TestCompound();
		}


    }

}
#endif