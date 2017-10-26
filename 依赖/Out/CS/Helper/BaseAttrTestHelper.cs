#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class BaseAttrRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class BaseAttrRpcGetRankRewardAskWraperHelper
{
}
[System.Serializable]
public class BaseAttrRpcUpGradeRankAskWraperHelper
{
}
[System.Serializable]
public class BaseAttrRpcChooseRoleAskWraperHelper
{
	public int Prof;
}
[System.Serializable]
public class BaseAttrRpcLevelUpAskWraperHelper
{
}
[System.Serializable]
public class BaseAttrRpcGetTimerAskWraperHelper
{
}
[System.Serializable]
public class BaseAttrRpcReviveAskWraperHelper
{
}
[System.Serializable]
public class BaseAttrRpcQueryEquipAskWraperHelper
{
	public long UserId;
	public int Pos;
	public int TemplateID;
	public long Index;
}
[System.Serializable]
public class BaseAttrRpcUpdateNewbieGuideAskWraperHelper
{
	public int GroupId;
	public int Step;
}
[System.Serializable]
public class BaseAttrRpcSysTipsNotifyWraperHelper
{
	public int Id;
}
[System.Serializable]
public class BaseAttrRpcChangPKStateAskWraperHelper
{
	public int ChangState;
}
[System.Serializable]
public class BaseAttrRpcChangePKProtectAskWraperHelper
{
	public List<KeyValue2IntBoolWraper> ProtectList;
}



public class BaseAttrTestHelper : MonoBehaviour
{
	public BaseAttrRpcSyncDataAskWraperHelper BaseAttrRpcSyncDataAskWraperVar;
	public BaseAttrRpcGetRankRewardAskWraperHelper BaseAttrRpcGetRankRewardAskWraperVar;
	public BaseAttrRpcUpGradeRankAskWraperHelper BaseAttrRpcUpGradeRankAskWraperVar;
	public BaseAttrRpcChooseRoleAskWraperHelper BaseAttrRpcChooseRoleAskWraperVar;
	public BaseAttrRpcLevelUpAskWraperHelper BaseAttrRpcLevelUpAskWraperVar;
	public BaseAttrRpcGetTimerAskWraperHelper BaseAttrRpcGetTimerAskWraperVar;
	public BaseAttrRpcReviveAskWraperHelper BaseAttrRpcReviveAskWraperVar;
	public BaseAttrRpcQueryEquipAskWraperHelper BaseAttrRpcQueryEquipAskWraperVar;
	public BaseAttrRpcUpdateNewbieGuideAskWraperHelper BaseAttrRpcUpdateNewbieGuideAskWraperVar;
	public BaseAttrRpcSysTipsNotifyWraperHelper BaseAttrRpcSysTipsNotifyWraperVar;
	public BaseAttrRpcChangPKStateAskWraperHelper BaseAttrRpcChangPKStateAskWraperVar;
	public BaseAttrRpcChangePKProtectAskWraperHelper BaseAttrRpcChangePKProtectAskWraperVar;


	public void TestSyncData()
	{
		BaseAttrRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestGetRankReward()
	{
		BaseAttrRPC.Instance.GetRankReward(delegate(object obj){});
	}
	public void TestUpGradeRank()
	{
		BaseAttrRPC.Instance.UpGradeRank(delegate(object obj){});
	}
	public void TestChooseRole()
	{
		BaseAttrRPC.Instance.ChooseRole(BaseAttrRpcChooseRoleAskWraperVar.Prof,delegate(object obj){});
	}
	public void TestLevelUp()
	{
		BaseAttrRPC.Instance.LevelUp(delegate(object obj){});
	}
	public void TestGetTimer()
	{
		BaseAttrRPC.Instance.GetTimer(delegate(object obj){});
	}
	public void TestRevive()
	{
		BaseAttrRPC.Instance.Revive(delegate(object obj){});
	}
	public void TestQueryEquip()
	{
		BaseAttrRPC.Instance.QueryEquip(BaseAttrRpcQueryEquipAskWraperVar.UserId,BaseAttrRpcQueryEquipAskWraperVar.Pos,BaseAttrRpcQueryEquipAskWraperVar.TemplateID,BaseAttrRpcQueryEquipAskWraperVar.Index,delegate(object obj){});
	}
	public void TestUpdateNewbieGuide()
	{
		BaseAttrRPC.Instance.UpdateNewbieGuide(BaseAttrRpcUpdateNewbieGuideAskWraperVar.GroupId,BaseAttrRpcUpdateNewbieGuideAskWraperVar.Step,delegate(object obj){});
	}
	public void TestChangPKState()
	{
		BaseAttrRPC.Instance.ChangPKState(BaseAttrRpcChangPKStateAskWraperVar.ChangState,delegate(object obj){});
	}
	public void TestChangePKProtect()
	{
		BaseAttrRPC.Instance.ChangePKProtect(BaseAttrRpcChangePKProtectAskWraperVar.ProtectList,delegate(object obj){});
	}


}

[CustomEditor(typeof(BaseAttrTestHelper))]
public class BaseAttrTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("GetRankReward"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestGetRankReward();
		}
		if (GUILayout.Button("UpGradeRank"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestUpGradeRank();
		}
		if (GUILayout.Button("ChooseRole"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestChooseRole();
		}
		if (GUILayout.Button("LevelUp"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestLevelUp();
		}
		if (GUILayout.Button("GetTimer"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestGetTimer();
		}
		if (GUILayout.Button("Revive"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestRevive();
		}
		if (GUILayout.Button("QueryEquip"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestQueryEquip();
		}
		if (GUILayout.Button("UpdateNewbieGuide"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestUpdateNewbieGuide();
		}
		if (GUILayout.Button("ChangPKState"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestChangPKState();
		}
		if (GUILayout.Button("ChangePKProtect"))
		{
			BaseAttrTestHelper rpc = target as BaseAttrTestHelper;
			if( rpc ) rpc.TestChangePKProtect();
		}


    }

}
#endif