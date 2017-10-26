#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class ChatRpcSendChatAskWraperHelper
{
	public ChatMsgObjWraper ChatMsg;
}
[System.Serializable]
public class ChatRpcSyncChatNotifyWraperHelper
{
	public ChatObjWraper ChatData;
}
[System.Serializable]
public class ChatRpcSyncPrivateChatMsgNotifyWraperHelper
{
	public List<ChatObjWraper> ChatData;
}
[System.Serializable]
public class ChatRpcSvrChatNotifyWraperHelper
{
	public ChatNetDataWraper ChatData;
}



public class ChatTestHelper : MonoBehaviour
{
	public ChatRpcSendChatAskWraperHelper ChatRpcSendChatAskWraperVar;
	public ChatRpcSyncChatNotifyWraperHelper ChatRpcSyncChatNotifyWraperVar;
	public ChatRpcSyncPrivateChatMsgNotifyWraperHelper ChatRpcSyncPrivateChatMsgNotifyWraperVar;
	public ChatRpcSvrChatNotifyWraperHelper ChatRpcSvrChatNotifyWraperVar;


	public void TestSendChat()
	{
		ChatRPC.Instance.SendChat(ChatRpcSendChatAskWraperVar.ChatMsg,delegate(object obj){});
	}


}

[CustomEditor(typeof(ChatTestHelper))]
public class ChatTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SendChat"))
		{
			ChatTestHelper rpc = target as ChatTestHelper;
			if( rpc ) rpc.TestSendChat();
		}


    }

}
#endif