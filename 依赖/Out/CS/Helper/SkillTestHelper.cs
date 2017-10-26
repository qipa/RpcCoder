#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class SkillRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class SkillRpcLearnAskWraperHelper
{
	public int SkillId;
}
[System.Serializable]
public class SkillRpcLvUpAskWraperHelper
{
	public int SkillId;
}
[System.Serializable]
public class SkillRpcChangeShortcutAskWraperHelper
{
	public int SkillId;
	public int Pos;
	public int Id;
}
[System.Serializable]
public class SkillRpcUseShortcutAskWraperHelper
{
	public int Id;
}
[System.Serializable]
public class SkillRpcOneKeyLvUpAskWraperHelper
{
	public int SkillId;
}
[System.Serializable]
public class SkillRpcTalentChangeSkillAskWraperHelper
{
	public int Index;
	public int SkillId;
}
[System.Serializable]
public class SkillRpcTalentResetAskWraperHelper
{
}
[System.Serializable]
public class SkillRpcTalentLvUpAskWraperHelper
{
	public List<SkillRpcTalentLvObjWraper> Talent;
}
[System.Serializable]
public class SkillRpcLifeSkillUpAskWraperHelper
{
	public int LifeSkillId;
}



public class SkillTestHelper : MonoBehaviour
{
	public SkillRpcSyncDataAskWraperHelper SkillRpcSyncDataAskWraperVar;
	public SkillRpcLearnAskWraperHelper SkillRpcLearnAskWraperVar;
	public SkillRpcLvUpAskWraperHelper SkillRpcLvUpAskWraperVar;
	public SkillRpcChangeShortcutAskWraperHelper SkillRpcChangeShortcutAskWraperVar;
	public SkillRpcUseShortcutAskWraperHelper SkillRpcUseShortcutAskWraperVar;
	public SkillRpcOneKeyLvUpAskWraperHelper SkillRpcOneKeyLvUpAskWraperVar;
	public SkillRpcTalentChangeSkillAskWraperHelper SkillRpcTalentChangeSkillAskWraperVar;
	public SkillRpcTalentResetAskWraperHelper SkillRpcTalentResetAskWraperVar;
	public SkillRpcTalentLvUpAskWraperHelper SkillRpcTalentLvUpAskWraperVar;
	public SkillRpcLifeSkillUpAskWraperHelper SkillRpcLifeSkillUpAskWraperVar;


	public void TestSyncData()
	{
		SkillRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestLearn()
	{
		SkillRPC.Instance.Learn(SkillRpcLearnAskWraperVar.SkillId,delegate(object obj){});
	}
	public void TestLvUp()
	{
		SkillRPC.Instance.LvUp(SkillRpcLvUpAskWraperVar.SkillId,delegate(object obj){});
	}
	public void TestChangeShortcut()
	{
		SkillRPC.Instance.ChangeShortcut(SkillRpcChangeShortcutAskWraperVar.SkillId,SkillRpcChangeShortcutAskWraperVar.Pos,SkillRpcChangeShortcutAskWraperVar.Id,delegate(object obj){});
	}
	public void TestUseShortcut()
	{
		SkillRPC.Instance.UseShortcut(SkillRpcUseShortcutAskWraperVar.Id,delegate(object obj){});
	}
	public void TestOneKeyLvUp()
	{
		SkillRPC.Instance.OneKeyLvUp(SkillRpcOneKeyLvUpAskWraperVar.SkillId,delegate(object obj){});
	}
	public void TestTalentLvUp()
	{
		SkillRPC.Instance.TalentLvUp(SkillRpcTalentLvUpAskWraperVar.Talent,delegate(object obj){});
	}
	public void TestTalentChangeSkill()
	{
		SkillRPC.Instance.TalentChangeSkill(SkillRpcTalentChangeSkillAskWraperVar.Index,SkillRpcTalentChangeSkillAskWraperVar.SkillId,delegate(object obj){});
	}
	public void TestTalentReset()
	{
		SkillRPC.Instance.TalentReset(delegate(object obj){});
	}
	public void TestLifeSkillUp()
	{
		SkillRPC.Instance.LifeSkillUp(SkillRpcLifeSkillUpAskWraperVar.LifeSkillId,delegate(object obj){});
	}


}

[CustomEditor(typeof(SkillTestHelper))]
public class SkillTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Learn"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestLearn();
		}
		if (GUILayout.Button("LvUp"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestLvUp();
		}
		if (GUILayout.Button("ChangeShortcut"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestChangeShortcut();
		}
		if (GUILayout.Button("UseShortcut"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestUseShortcut();
		}
		if (GUILayout.Button("OneKeyLvUp"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestOneKeyLvUp();
		}
		if (GUILayout.Button("TalentLvUp"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestTalentLvUp();
		}
		if (GUILayout.Button("TalentChangeSkill"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestTalentChangeSkill();
		}
		if (GUILayout.Button("TalentReset"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestTalentReset();
		}
		if (GUILayout.Button("LifeSkillUp"))
		{
			SkillTestHelper rpc = target as SkillTestHelper;
			if( rpc ) rpc.TestLifeSkillUp();
		}


    }

}
#endif