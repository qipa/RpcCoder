#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class DropItemRpcDropItemNoticeNotifyWraperHelper
{
	public List<DropItemObjWraper> DropItem;
}
[System.Serializable]
public class DropItemRpcPickupItemAskWraperHelper
{
	public int UId;
}
[System.Serializable]
public class DropItemRpcDelDropItemNotifyWraperHelper
{
	public int UId;
}



public class DropItemTestHelper : MonoBehaviour
{
	public DropItemRpcDropItemNoticeNotifyWraperHelper DropItemRpcDropItemNoticeNotifyWraperVar;
	public DropItemRpcPickupItemAskWraperHelper DropItemRpcPickupItemAskWraperVar;
	public DropItemRpcDelDropItemNotifyWraperHelper DropItemRpcDelDropItemNotifyWraperVar;


	public void TestPickupItem()
	{
		DropItemRPC.Instance.PickupItem(DropItemRpcPickupItemAskWraperVar.UId,delegate(object obj){});
	}


}

[CustomEditor(typeof(DropItemTestHelper))]
public class DropItemTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("PickupItem"))
		{
			DropItemTestHelper rpc = target as DropItemTestHelper;
			if( rpc ) rpc.TestPickupItem();
		}


    }

}
#endif