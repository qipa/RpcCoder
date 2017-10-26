#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class CapsuleRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class CapsuleRpcBuyAskWraperHelper
{
	public int Id;
	public int Type;
}
[System.Serializable]
public class CapsuleRpcExchangeAskWraperHelper
{
	public int ItemId;
}



public class CapsuleTestHelper : MonoBehaviour
{
	public CapsuleRpcSyncDataAskWraperHelper CapsuleRpcSyncDataAskWraperVar;
	public CapsuleRpcBuyAskWraperHelper CapsuleRpcBuyAskWraperVar;
	public CapsuleRpcExchangeAskWraperHelper CapsuleRpcExchangeAskWraperVar;


	public void TestSyncData()
	{
		CapsuleRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestBuy()
	{
		CapsuleRPC.Instance.Buy(CapsuleRpcBuyAskWraperVar.Id,CapsuleRpcBuyAskWraperVar.Type,delegate(object obj){});
	}
	public void TestExchange()
	{
		CapsuleRPC.Instance.Exchange(CapsuleRpcExchangeAskWraperVar.ItemId,delegate(object obj){});
	}


}

[CustomEditor(typeof(CapsuleTestHelper))]
public class CapsuleTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			CapsuleTestHelper rpc = target as CapsuleTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Buy"))
		{
			CapsuleTestHelper rpc = target as CapsuleTestHelper;
			if( rpc ) rpc.TestBuy();
		}
		if (GUILayout.Button("Exchange"))
		{
			CapsuleTestHelper rpc = target as CapsuleTestHelper;
			if( rpc ) rpc.TestExchange();
		}


    }

}
#endif