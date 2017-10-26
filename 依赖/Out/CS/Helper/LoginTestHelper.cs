#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class LoginRpcKeyAuthAskWraperHelper
{
	public int DistId;
	public string RsaData;
}
[System.Serializable]
public class LoginRpcKickOffNotifyWraperHelper
{
}



public class LoginTestHelper : MonoBehaviour
{
	public LoginRpcKeyAuthAskWraperHelper LoginRpcKeyAuthAskWraperVar;
	public LoginRpcKickOffNotifyWraperHelper LoginRpcKickOffNotifyWraperVar;


	public void TestKeyAuth()
	{
		LoginRPC.Instance.KeyAuth(LoginRpcKeyAuthAskWraperVar.DistId,LoginRpcKeyAuthAskWraperVar.RsaData,delegate(object obj){});
	}


}

[CustomEditor(typeof(LoginTestHelper))]
public class LoginTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("KeyAuth"))
		{
			LoginTestHelper rpc = target as LoginTestHelper;
			if( rpc ) rpc.TestKeyAuth();
		}


    }

}
#endif