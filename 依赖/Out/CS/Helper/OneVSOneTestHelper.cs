#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class OneVSOneRpcFlushAskWraperHelper
{
	public int IsOpen;
}
[System.Serializable]
public class OneVSOneRpcActAskWraperHelper
{
	public long UserId;
	public int Ranking;
}
[System.Serializable]
public class OneVSOneRpcActMessageNotifyWraperHelper
{
	public long UserId;
	public string PlanName;
}
[System.Serializable]
public class OneVSOneRpcReplyActAskWraperHelper
{
	public long UserId;
	public int IsOK;
}
[System.Serializable]
public class OneVSOneRpcGetTopAskWraperHelper
{
}
[System.Serializable]
public class OneVSOneRpcAdjustmentSkillAskWraperHelper
{
	public List<OneSDataWraper> SkillDate;
}
[System.Serializable]
public class OneVSOneRpcGetSkillAskWraperHelper
{
}
[System.Serializable]
public class OneVSOneRpcGetActMessageAskWraperHelper
{
}
[System.Serializable]
public class OneVSOneRpcACTResultNotifyNotifyWraperHelper
{
	public int IsChanllengorWon;
	public OneVSOneOVOResultInfoWraper Chanllengor;
	public OneVSOneOVOResultInfoWraper BeAttacked;
}



public class OneVSOneTestHelper : MonoBehaviour
{
	public OneVSOneRpcFlushAskWraperHelper OneVSOneRpcFlushAskWraperVar;
	public OneVSOneRpcActAskWraperHelper OneVSOneRpcActAskWraperVar;
	public OneVSOneRpcActMessageNotifyWraperHelper OneVSOneRpcActMessageNotifyWraperVar;
	public OneVSOneRpcReplyActAskWraperHelper OneVSOneRpcReplyActAskWraperVar;
	public OneVSOneRpcGetTopAskWraperHelper OneVSOneRpcGetTopAskWraperVar;
	public OneVSOneRpcAdjustmentSkillAskWraperHelper OneVSOneRpcAdjustmentSkillAskWraperVar;
	public OneVSOneRpcGetSkillAskWraperHelper OneVSOneRpcGetSkillAskWraperVar;
	public OneVSOneRpcGetActMessageAskWraperHelper OneVSOneRpcGetActMessageAskWraperVar;
	public OneVSOneRpcACTResultNotifyNotifyWraperHelper OneVSOneRpcACTResultNotifyNotifyWraperVar;


	public void TestFlush()
	{
		OneVSOneRPC.Instance.Flush(OneVSOneRpcFlushAskWraperVar.IsOpen,delegate(object obj){});
	}
	public void TestAct()
	{
		OneVSOneRPC.Instance.Act(OneVSOneRpcActAskWraperVar.UserId,OneVSOneRpcActAskWraperVar.Ranking,delegate(object obj){});
	}
	public void TestReplyAct()
	{
		OneVSOneRPC.Instance.ReplyAct(OneVSOneRpcReplyActAskWraperVar.UserId,OneVSOneRpcReplyActAskWraperVar.IsOK,delegate(object obj){});
	}
	public void TestGetTop()
	{
		OneVSOneRPC.Instance.GetTop(delegate(object obj){});
	}
	public void TestAdjustmentSkill()
	{
		OneVSOneRPC.Instance.AdjustmentSkill(OneVSOneRpcAdjustmentSkillAskWraperVar.SkillDate,delegate(object obj){});
	}
	public void TestGetSkill()
	{
		OneVSOneRPC.Instance.GetSkill(delegate(object obj){});
	}
	public void TestGetActMessage()
	{
		OneVSOneRPC.Instance.GetActMessage(delegate(object obj){});
	}


}

[CustomEditor(typeof(OneVSOneTestHelper))]
public class OneVSOneTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("Flush"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestFlush();
		}
		if (GUILayout.Button("Act"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestAct();
		}
		if (GUILayout.Button("ReplyAct"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestReplyAct();
		}
		if (GUILayout.Button("GetTop"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestGetTop();
		}
		if (GUILayout.Button("AdjustmentSkill"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestAdjustmentSkill();
		}
		if (GUILayout.Button("GetSkill"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestGetSkill();
		}
		if (GUILayout.Button("GetActMessage"))
		{
			OneVSOneTestHelper rpc = target as OneVSOneTestHelper;
			if( rpc ) rpc.TestGetActMessage();
		}


    }

}
#endif