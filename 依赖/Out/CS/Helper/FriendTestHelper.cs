#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class FriendRpcSyncFriendDataAskWraperHelper
{
}
[System.Serializable]
public class FriendRpcAddFriendAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class FriendRpcDelFriendAskWraperHelper
{
	public List<long> UserId;
}
[System.Serializable]
public class FriendRpcAddBlackListAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class FriendRpcDelBlackListAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class FriendRpcAddContactAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class FriendRpcDelContactAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class FriendRpcSearchPlayerAskWraperHelper
{
	public string SearchString;
}
[System.Serializable]
public class FriendRpcRecommendAskWraperHelper
{
}
[System.Serializable]
public class FriendRpcViewUserSimpleInfoAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class FriendRpcOnlineOfflineNotifyWraperHelper
{
	public long UserId;
	public string UserName;
	public bool Online;
}



public class FriendTestHelper : MonoBehaviour
{
	public FriendRpcSyncFriendDataAskWraperHelper FriendRpcSyncFriendDataAskWraperVar;
	public FriendRpcAddFriendAskWraperHelper FriendRpcAddFriendAskWraperVar;
	public FriendRpcDelFriendAskWraperHelper FriendRpcDelFriendAskWraperVar;
	public FriendRpcAddBlackListAskWraperHelper FriendRpcAddBlackListAskWraperVar;
	public FriendRpcDelBlackListAskWraperHelper FriendRpcDelBlackListAskWraperVar;
	public FriendRpcAddContactAskWraperHelper FriendRpcAddContactAskWraperVar;
	public FriendRpcDelContactAskWraperHelper FriendRpcDelContactAskWraperVar;
	public FriendRpcSearchPlayerAskWraperHelper FriendRpcSearchPlayerAskWraperVar;
	public FriendRpcRecommendAskWraperHelper FriendRpcRecommendAskWraperVar;
	public FriendRpcViewUserSimpleInfoAskWraperHelper FriendRpcViewUserSimpleInfoAskWraperVar;
	public FriendRpcOnlineOfflineNotifyWraperHelper FriendRpcOnlineOfflineNotifyWraperVar;


	public void TestSyncFriendData()
	{
		FriendRPC.Instance.SyncFriendData(delegate(object obj){});
	}
	public void TestAddFriend()
	{
		FriendRPC.Instance.AddFriend(FriendRpcAddFriendAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestDelFriend()
	{
		FriendRPC.Instance.DelFriend(FriendRpcDelFriendAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestAddBlackList()
	{
		FriendRPC.Instance.AddBlackList(FriendRpcAddBlackListAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestDelBlackList()
	{
		FriendRPC.Instance.DelBlackList(FriendRpcDelBlackListAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestAddContact()
	{
		FriendRPC.Instance.AddContact(FriendRpcAddContactAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestDelContact()
	{
		FriendRPC.Instance.DelContact(FriendRpcDelContactAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestSearchPlayer()
	{
		FriendRPC.Instance.SearchPlayer(FriendRpcSearchPlayerAskWraperVar.SearchString,delegate(object obj){});
	}
	public void TestRecommend()
	{
		FriendRPC.Instance.Recommend(delegate(object obj){});
	}
	public void TestViewUserSimpleInfo()
	{
		FriendRPC.Instance.ViewUserSimpleInfo(FriendRpcViewUserSimpleInfoAskWraperVar.UserId,delegate(object obj){});
	}


}

[CustomEditor(typeof(FriendTestHelper))]
public class FriendTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncFriendData"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestSyncFriendData();
		}
		if (GUILayout.Button("AddFriend"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestAddFriend();
		}
		if (GUILayout.Button("DelFriend"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestDelFriend();
		}
		if (GUILayout.Button("AddBlackList"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestAddBlackList();
		}
		if (GUILayout.Button("DelBlackList"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestDelBlackList();
		}
		if (GUILayout.Button("AddContact"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestAddContact();
		}
		if (GUILayout.Button("DelContact"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestDelContact();
		}
		if (GUILayout.Button("SearchPlayer"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestSearchPlayer();
		}
		if (GUILayout.Button("Recommend"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestRecommend();
		}
		if (GUILayout.Button("ViewUserSimpleInfo"))
		{
			FriendTestHelper rpc = target as FriendTestHelper;
			if( rpc ) rpc.TestViewUserSimpleInfo();
		}


    }

}
#endif