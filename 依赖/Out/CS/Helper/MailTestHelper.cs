#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class MailRpcMailHeadAskWraperHelper
{
	public int Count;
	public long UId;
}
[System.Serializable]
public class MailRpcDelMailAskWraperHelper
{
	public List<long> UidList;
}
[System.Serializable]
public class MailRpcOpenMailAskWraperHelper
{
	public long UId;
}
[System.Serializable]
public class MailRpcGetRewardAskWraperHelper
{
	public long UId;
}
[System.Serializable]
public class MailRpcNewMailNotifyWraperHelper
{
	public List<MailHeadObjWraper> MailHeadList;
}
[System.Serializable]
public class MailRpcOneKeyGetRewardAskWraperHelper
{
}



public class MailTestHelper : MonoBehaviour
{
	public MailRpcMailHeadAskWraperHelper MailRpcMailHeadAskWraperVar;
	public MailRpcDelMailAskWraperHelper MailRpcDelMailAskWraperVar;
	public MailRpcOpenMailAskWraperHelper MailRpcOpenMailAskWraperVar;
	public MailRpcGetRewardAskWraperHelper MailRpcGetRewardAskWraperVar;
	public MailRpcNewMailNotifyWraperHelper MailRpcNewMailNotifyWraperVar;
	public MailRpcOneKeyGetRewardAskWraperHelper MailRpcOneKeyGetRewardAskWraperVar;


	public void TestMailHead()
	{
		MailRPC.Instance.MailHead(MailRpcMailHeadAskWraperVar.Count,MailRpcMailHeadAskWraperVar.UId,delegate(object obj){});
	}
	public void TestOpenMail()
	{
		MailRPC.Instance.OpenMail(MailRpcOpenMailAskWraperVar.UId,delegate(object obj){});
	}
	public void TestDelMail()
	{
		MailRPC.Instance.DelMail(MailRpcDelMailAskWraperVar.UidList,delegate(object obj){});
	}
	public void TestGetReward()
	{
		MailRPC.Instance.GetReward(MailRpcGetRewardAskWraperVar.UId,delegate(object obj){});
	}
	public void TestOneKeyGetReward()
	{
		MailRPC.Instance.OneKeyGetReward(delegate(object obj){});
	}


}

[CustomEditor(typeof(MailTestHelper))]
public class MailTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("MailHead"))
		{
			MailTestHelper rpc = target as MailTestHelper;
			if( rpc ) rpc.TestMailHead();
		}
		if (GUILayout.Button("OpenMail"))
		{
			MailTestHelper rpc = target as MailTestHelper;
			if( rpc ) rpc.TestOpenMail();
		}
		if (GUILayout.Button("DelMail"))
		{
			MailTestHelper rpc = target as MailTestHelper;
			if( rpc ) rpc.TestDelMail();
		}
		if (GUILayout.Button("GetReward"))
		{
			MailTestHelper rpc = target as MailTestHelper;
			if( rpc ) rpc.TestGetReward();
		}
		if (GUILayout.Button("OneKeyGetReward"))
		{
			MailTestHelper rpc = target as MailTestHelper;
			if( rpc ) rpc.TestOneKeyGetReward();
		}


    }

}
#endif