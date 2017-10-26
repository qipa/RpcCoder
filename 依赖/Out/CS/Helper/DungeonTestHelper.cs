#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class DungeonRpcEnterAskWraperHelper
{
	public int DungeonId;
	public int DungeonType;
	public int BirthPoint;
	public int FaceDir;
	public int GuildId;
}
[System.Serializable]
public class DungeonRpcOpenNotifyWraperHelper
{
	public string DungeonKey;
	public string Host;
	public int Port;
	public int DungeonId;
	public int DungeonType;
	public int GuildId;
}
[System.Serializable]
public class DungeonRpcTryEnterAskWraperHelper
{
	public int DungeonId;
	public int BirthPoint;
	public int FaceDir;
	public int GuildId;
}
[System.Serializable]
public class DungeonRpcTransferNotifyWraperHelper
{
	public int DungeonId;
}



public class DungeonTestHelper : MonoBehaviour
{
	public DungeonRpcEnterAskWraperHelper DungeonRpcEnterAskWraperVar;
	public DungeonRpcOpenNotifyWraperHelper DungeonRpcOpenNotifyWraperVar;
	public DungeonRpcTryEnterAskWraperHelper DungeonRpcTryEnterAskWraperVar;
	public DungeonRpcTransferNotifyWraperHelper DungeonRpcTransferNotifyWraperVar;


	public void TestEnter()
	{
		DungeonRPC.Instance.Enter(DungeonRpcEnterAskWraperVar.DungeonId,DungeonRpcEnterAskWraperVar.DungeonType,DungeonRpcEnterAskWraperVar.BirthPoint,DungeonRpcEnterAskWraperVar.FaceDir,DungeonRpcEnterAskWraperVar.GuildId,delegate(object obj){});
	}
	public void TestTryEnter()
	{
		DungeonRPC.Instance.TryEnter(DungeonRpcTryEnterAskWraperVar.DungeonId,DungeonRpcTryEnterAskWraperVar.BirthPoint,DungeonRpcTryEnterAskWraperVar.FaceDir,DungeonRpcTryEnterAskWraperVar.GuildId,delegate(object obj){});
	}


}

[CustomEditor(typeof(DungeonTestHelper))]
public class DungeonTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("Enter"))
		{
			DungeonTestHelper rpc = target as DungeonTestHelper;
			if( rpc ) rpc.TestEnter();
		}
		if (GUILayout.Button("TryEnter"))
		{
			DungeonTestHelper rpc = target as DungeonTestHelper;
			if( rpc ) rpc.TestTryEnter();
		}


    }

}
#endif