#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class HeroRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class HeroRpcComposeAskWraperHelper
{
	public int HerdId;
}
[System.Serializable]
public class HeroRpcLvUpAskWraperHelper
{
	public int HerdId;
	public int ItemId;
}
[System.Serializable]
public class HeroRpcStarLvUpAskWraperHelper
{
	public int HerdId;
}
[System.Serializable]
public class HeroRpcStarStageUpAskWraperHelper
{
	public int HerdId;
}
[System.Serializable]
public class HeroRpcDebrisChangeAskWraperHelper
{
	public int HerdId;
	public int Num;
}
[System.Serializable]
public class HeroRpcDestinyEuipAskWraperHelper
{
	public int HerdId;
	public int Pos;
}
[System.Serializable]
public class HeroRpcDestinyLvUpAskWraperHelper
{
	public int HerdId;
}
[System.Serializable]
public class HeroRpcAddMagicAskWraperHelper
{
	public int HerdId;
	public int StonePos;
	public List<int> ItemId;
	public List<int> Pos;
	public int Type;
}
[System.Serializable]
public class HeroRpcSkillLvUpAskWraperHelper
{
	public int HerdId;
	public int SkillId;
}
[System.Serializable]
public class HeroRpcWuShengLvUpAskWraperHelper
{
}
[System.Serializable]
public class HeroRpcSkillTimeAskWraperHelper
{
}



public class HeroTestHelper : MonoBehaviour
{
	public HeroRpcSyncDataAskWraperHelper HeroRpcSyncDataAskWraperVar;
	public HeroRpcComposeAskWraperHelper HeroRpcComposeAskWraperVar;
	public HeroRpcLvUpAskWraperHelper HeroRpcLvUpAskWraperVar;
	public HeroRpcStarLvUpAskWraperHelper HeroRpcStarLvUpAskWraperVar;
	public HeroRpcStarStageUpAskWraperHelper HeroRpcStarStageUpAskWraperVar;
	public HeroRpcDebrisChangeAskWraperHelper HeroRpcDebrisChangeAskWraperVar;
	public HeroRpcDestinyEuipAskWraperHelper HeroRpcDestinyEuipAskWraperVar;
	public HeroRpcDestinyLvUpAskWraperHelper HeroRpcDestinyLvUpAskWraperVar;
	public HeroRpcAddMagicAskWraperHelper HeroRpcAddMagicAskWraperVar;
	public HeroRpcSkillLvUpAskWraperHelper HeroRpcSkillLvUpAskWraperVar;
	public HeroRpcWuShengLvUpAskWraperHelper HeroRpcWuShengLvUpAskWraperVar;
	public HeroRpcSkillTimeAskWraperHelper HeroRpcSkillTimeAskWraperVar;


	public void TestSyncData()
	{
		HeroRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestCompose()
	{
		HeroRPC.Instance.Compose(HeroRpcComposeAskWraperVar.HerdId,delegate(object obj){});
	}
	public void TestLvUp()
	{
		HeroRPC.Instance.LvUp(HeroRpcLvUpAskWraperVar.HerdId,HeroRpcLvUpAskWraperVar.ItemId,delegate(object obj){});
	}
	public void TestStarLvUp()
	{
		HeroRPC.Instance.StarLvUp(HeroRpcStarLvUpAskWraperVar.HerdId,delegate(object obj){});
	}
	public void TestStarStageUp()
	{
		HeroRPC.Instance.StarStageUp(HeroRpcStarStageUpAskWraperVar.HerdId,delegate(object obj){});
	}
	public void TestDebrisChange()
	{
		HeroRPC.Instance.DebrisChange(HeroRpcDebrisChangeAskWraperVar.HerdId,HeroRpcDebrisChangeAskWraperVar.Num,delegate(object obj){});
	}
	public void TestDestinyEuip()
	{
		HeroRPC.Instance.DestinyEuip(HeroRpcDestinyEuipAskWraperVar.HerdId,HeroRpcDestinyEuipAskWraperVar.Pos,delegate(object obj){});
	}
	public void TestDestinyLvUp()
	{
		HeroRPC.Instance.DestinyLvUp(HeroRpcDestinyLvUpAskWraperVar.HerdId,delegate(object obj){});
	}
	public void TestAddMagic()
	{
		HeroRPC.Instance.AddMagic(HeroRpcAddMagicAskWraperVar.HerdId,HeroRpcAddMagicAskWraperVar.StonePos,HeroRpcAddMagicAskWraperVar.ItemId,HeroRpcAddMagicAskWraperVar.Pos,HeroRpcAddMagicAskWraperVar.Type,delegate(object obj){});
	}
	public void TestSkillLvUp()
	{
		HeroRPC.Instance.SkillLvUp(HeroRpcSkillLvUpAskWraperVar.HerdId,HeroRpcSkillLvUpAskWraperVar.SkillId,delegate(object obj){});
	}
	public void TestWuShengLvUp()
	{
		HeroRPC.Instance.WuShengLvUp(delegate(object obj){});
	}
	public void TestSkillTime()
	{
		HeroRPC.Instance.SkillTime(delegate(object obj){});
	}


}

[CustomEditor(typeof(HeroTestHelper))]
public class HeroTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Compose"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestCompose();
		}
		if (GUILayout.Button("LvUp"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestLvUp();
		}
		if (GUILayout.Button("StarLvUp"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestStarLvUp();
		}
		if (GUILayout.Button("StarStageUp"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestStarStageUp();
		}
		if (GUILayout.Button("DebrisChange"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestDebrisChange();
		}
		if (GUILayout.Button("DestinyEuip"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestDestinyEuip();
		}
		if (GUILayout.Button("DestinyLvUp"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestDestinyLvUp();
		}
		if (GUILayout.Button("AddMagic"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestAddMagic();
		}
		if (GUILayout.Button("SkillLvUp"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestSkillLvUp();
		}
		if (GUILayout.Button("WuShengLvUp"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestWuShengLvUp();
		}
		if (GUILayout.Button("SkillTime"))
		{
			HeroTestHelper rpc = target as HeroTestHelper;
			if( rpc ) rpc.TestSkillTime();
		}


    }

}
#endif