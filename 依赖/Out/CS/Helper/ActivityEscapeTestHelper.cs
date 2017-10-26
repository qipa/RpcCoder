#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class ActivityEscapeRpcSignUpAskWraperHelper
{
}



public class ActivityEscapeTestHelper : MonoBehaviour
{
	public ActivityEscapeRpcSignUpAskWraperHelper ActivityEscapeRpcSignUpAskWraperVar;


	public void TestSignUp()
	{
		ActivityEscapeRPC.Instance.SignUp(delegate(object obj){});
	}


}

[CustomEditor(typeof(ActivityEscapeTestHelper))]
public class ActivityEscapeTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SignUp"))
		{
			ActivityEscapeTestHelper rpc = target as ActivityEscapeTestHelper;
			if( rpc ) rpc.TestSignUp();
		}


    }

}
#endif