#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class TransportRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class TransportRpcFillAskWraperHelper
{
	public int FillID;
}
[System.Serializable]
public class TransportRpcHelpOtherAskWraperHelper
{
	public int ItemID;
	public long UserId;
}
[System.Serializable]
public class TransportRpcAskHelpAskWraperHelper
{
	public int ItemID;
}
[System.Serializable]
public class TransportRpcAskHelpReplyWraperHelper
{
	public int Result;
	public int ItemID;
}
[System.Serializable]
public class TransportRpcSetSailAskWraperHelper
{
}
[System.Serializable]
public class TransportRpcAddTransportAskWraperHelper
{
	public int Lv;
}
[System.Serializable]
public class TransportRpcIsHelpedNotifyWraperHelper
{
	public int TemplateId;
}



public class TransportTestHelper : MonoBehaviour
{
	public TransportRpcSyncDataAskWraperHelper TransportRpcSyncDataAskWraperVar;
	public TransportRpcFillAskWraperHelper TransportRpcFillAskWraperVar;
	public TransportRpcHelpOtherAskWraperHelper TransportRpcHelpOtherAskWraperVar;
	public TransportRpcAskHelpAskWraperHelper TransportRpcAskHelpAskWraperVar;
	public TransportRpcAskHelpReplyWraperHelper TransportRpcAskHelpReplyWraperVar;
	public TransportRpcSetSailAskWraperHelper TransportRpcSetSailAskWraperVar;
	public TransportRpcAddTransportAskWraperHelper TransportRpcAddTransportAskWraperVar;
	public TransportRpcIsHelpedNotifyWraperHelper TransportRpcIsHelpedNotifyWraperVar;


	public void TestSyncData()
	{
		TransportRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestFill()
	{
		TransportRPC.Instance.Fill(TransportRpcFillAskWraperVar.FillID,delegate(object obj){});
	}
	public void TestHelpOther()
	{
		TransportRPC.Instance.HelpOther(TransportRpcHelpOtherAskWraperVar.ItemID,TransportRpcHelpOtherAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestAskHelp()
	{
		TransportRPC.Instance.AskHelp(TransportRpcAskHelpAskWraperVar.ItemID,delegate(object obj){});
	}
	public void TestSetSail()
	{
		TransportRPC.Instance.SetSail(delegate(object obj){});
	}
	public void TestAddTransport()
	{
		TransportRPC.Instance.AddTransport(TransportRpcAddTransportAskWraperVar.Lv,delegate(object obj){});
	}


}

[CustomEditor(typeof(TransportTestHelper))]
public class TransportTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			TransportTestHelper rpc = target as TransportTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Fill"))
		{
			TransportTestHelper rpc = target as TransportTestHelper;
			if( rpc ) rpc.TestFill();
		}
		if (GUILayout.Button("HelpOther"))
		{
			TransportTestHelper rpc = target as TransportTestHelper;
			if( rpc ) rpc.TestHelpOther();
		}
		if (GUILayout.Button("AskHelp"))
		{
			TransportTestHelper rpc = target as TransportTestHelper;
			if( rpc ) rpc.TestAskHelp();
		}
		if (GUILayout.Button("SetSail"))
		{
			TransportTestHelper rpc = target as TransportTestHelper;
			if( rpc ) rpc.TestSetSail();
		}
		if (GUILayout.Button("AddTransport"))
		{
			TransportTestHelper rpc = target as TransportTestHelper;
			if( rpc ) rpc.TestAddTransport();
		}


    }

}
#endif