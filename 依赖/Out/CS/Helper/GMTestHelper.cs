#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class GMRpcActionAskWraperHelper
{
	public string Value;
}



public class GMTestHelper : MonoBehaviour
{
	public GMRpcActionAskWraperHelper GMRpcActionAskWraperVar;


	public void TestAction()
	{
		GMRPC.Instance.Action(GMRpcActionAskWraperVar.Value,delegate(object obj){});
	}


}

[CustomEditor(typeof(GMTestHelper))]
public class GMTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("Action"))
		{
			GMTestHelper rpc = target as GMTestHelper;
			if( rpc ) rpc.TestAction();
		}


    }

}
#endif