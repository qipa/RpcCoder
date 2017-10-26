#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class ShopRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class ShopRpcBuyAskWraperHelper
{
	public int ShopType;
	public int ItemId;
	public int Pos;
}
[System.Serializable]
public class ShopRpcRefreshItemAskWraperHelper
{
	public int ShopType;
}



public class ShopTestHelper : MonoBehaviour
{
	public ShopRpcSyncDataAskWraperHelper ShopRpcSyncDataAskWraperVar;
	public ShopRpcBuyAskWraperHelper ShopRpcBuyAskWraperVar;
	public ShopRpcRefreshItemAskWraperHelper ShopRpcRefreshItemAskWraperVar;


	public void TestSyncData()
	{
		ShopRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestBuy()
	{
		ShopRPC.Instance.Buy(ShopRpcBuyAskWraperVar.ShopType,ShopRpcBuyAskWraperVar.ItemId,ShopRpcBuyAskWraperVar.Pos,delegate(object obj){});
	}
	public void TestRefreshItem()
	{
		ShopRPC.Instance.RefreshItem(ShopRpcRefreshItemAskWraperVar.ShopType,delegate(object obj){});
	}


}

[CustomEditor(typeof(ShopTestHelper))]
public class ShopTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			ShopTestHelper rpc = target as ShopTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Buy"))
		{
			ShopTestHelper rpc = target as ShopTestHelper;
			if( rpc ) rpc.TestBuy();
		}
		if (GUILayout.Button("RefreshItem"))
		{
			ShopTestHelper rpc = target as ShopTestHelper;
			if( rpc ) rpc.TestRefreshItem();
		}


    }

}
#endif