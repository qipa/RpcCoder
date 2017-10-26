#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class TeamRpcCreateTeamAskWraperHelper
{
	public int TargetId;
	public int TargetMinLv;
	public int TargetMaxLv;
}
[System.Serializable]
public class TeamRpcApplyForTeamAskWraperHelper
{
	public int TeamId;
}
[System.Serializable]
public class TeamRpcInviteToTeamAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class TeamRpcChangeTeamTargetAskWraperHelper
{
	public int TargetId;
	public int TargetMinLv;
	public int TargetMaxLv;
}
[System.Serializable]
public class TeamRpcBeInvitedNoticeNotifyWraperHelper
{
	public int TeamId;
	public long UserId;
	public string UserName;
	public string CaptainUserName;
}
[System.Serializable]
public class TeamRpcBeInviteHandleAskWraperHelper
{
	public int TeamId;
	public long UserId;
	public int Handle;
}
[System.Serializable]
public class TeamRpcNearbyTeamAskWraperHelper
{
	public int TargetId;
}
[System.Serializable]
public class TeamRpcApplyNoticeCaptainNotifyWraperHelper
{
	public TeamApplyUserObjWraper ApplyUser;
}
[System.Serializable]
public class TeamRpcApplyHandleAgreeAskWraperHelper
{
	public long UserId;
	public int TeamId;
	public int Handle;
}
[System.Serializable]
public class TeamRpcUpdateMyTeamNoticeNotifyWraperHelper
{
	public TeamObjWraper MyTeamData;
}
[System.Serializable]
public class TeamRpcQuitTeamNotifyWraperHelper
{
}
[System.Serializable]
public class TeamRpcLeaveTeamNoticeNotifyWraperHelper
{
	public int UserId;
	public string UserName;
}
[System.Serializable]
public class TeamRpcBreakUpNoticeNotifyWraperHelper
{
	public long UserId;
	public string UserName;
}
[System.Serializable]
public class TeamRpcReqMyTeamDataNotifyWraperHelper
{
}
[System.Serializable]
public class TeamRpcDeleteFromApplyListNotifyWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class TeamRpcAppointCaptainAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class TeamRpcCaptainChangeNoticeNotifyWraperHelper
{
	public long UserId;
	public string UserName;
}
[System.Serializable]
public class TeamRpcTeamMemberHPChangeNoticeNotifyWraperHelper
{
	public long UserId;
	public int HP;
	public int MaxHP;
}
[System.Serializable]
public class TeamRpcInviteHandleNoticeNotifyWraperHelper
{
	public int Result;
}
[System.Serializable]
public class TeamRpcNearbyRoleListAskWraperHelper
{
}
[System.Serializable]
public class TeamRpcKickRoleAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class TeamRpcBeingKickedNoticeNotifyWraperHelper
{
}
[System.Serializable]
public class TeamRpcBreakUpAskWraperHelper
{
}
[System.Serializable]
public class TeamRpcAddNewMemberNoticeNotifyWraperHelper
{
	public long UserId;
	public string UserName;
}
[System.Serializable]
public class TeamRpcCaptainAutoMatchAskWraperHelper
{
	public int Oper;
}
[System.Serializable]
public class TeamRpcNormalAutoMatchAskWraperHelper
{
	public int Oper;
	public int Target;
}
[System.Serializable]
public class TeamRpcFollowAskWraperHelper
{
}
[System.Serializable]
public class TeamRpcClearApplyListAskWraperHelper
{
}



public class TeamTestHelper : MonoBehaviour
{
	public TeamRpcCreateTeamAskWraperHelper TeamRpcCreateTeamAskWraperVar;
	public TeamRpcApplyForTeamAskWraperHelper TeamRpcApplyForTeamAskWraperVar;
	public TeamRpcInviteToTeamAskWraperHelper TeamRpcInviteToTeamAskWraperVar;
	public TeamRpcChangeTeamTargetAskWraperHelper TeamRpcChangeTeamTargetAskWraperVar;
	public TeamRpcBeInvitedNoticeNotifyWraperHelper TeamRpcBeInvitedNoticeNotifyWraperVar;
	public TeamRpcBeInviteHandleAskWraperHelper TeamRpcBeInviteHandleAskWraperVar;
	public TeamRpcNearbyTeamAskWraperHelper TeamRpcNearbyTeamAskWraperVar;
	public TeamRpcApplyNoticeCaptainNotifyWraperHelper TeamRpcApplyNoticeCaptainNotifyWraperVar;
	public TeamRpcApplyHandleAgreeAskWraperHelper TeamRpcApplyHandleAgreeAskWraperVar;
	public TeamRpcUpdateMyTeamNoticeNotifyWraperHelper TeamRpcUpdateMyTeamNoticeNotifyWraperVar;
	public TeamRpcQuitTeamNotifyWraperHelper TeamRpcQuitTeamNotifyWraperVar;
	public TeamRpcLeaveTeamNoticeNotifyWraperHelper TeamRpcLeaveTeamNoticeNotifyWraperVar;
	public TeamRpcBreakUpNoticeNotifyWraperHelper TeamRpcBreakUpNoticeNotifyWraperVar;
	public TeamRpcReqMyTeamDataNotifyWraperHelper TeamRpcReqMyTeamDataNotifyWraperVar;
	public TeamRpcDeleteFromApplyListNotifyWraperHelper TeamRpcDeleteFromApplyListNotifyWraperVar;
	public TeamRpcAppointCaptainAskWraperHelper TeamRpcAppointCaptainAskWraperVar;
	public TeamRpcCaptainChangeNoticeNotifyWraperHelper TeamRpcCaptainChangeNoticeNotifyWraperVar;
	public TeamRpcTeamMemberHPChangeNoticeNotifyWraperHelper TeamRpcTeamMemberHPChangeNoticeNotifyWraperVar;
	public TeamRpcInviteHandleNoticeNotifyWraperHelper TeamRpcInviteHandleNoticeNotifyWraperVar;
	public TeamRpcNearbyRoleListAskWraperHelper TeamRpcNearbyRoleListAskWraperVar;
	public TeamRpcKickRoleAskWraperHelper TeamRpcKickRoleAskWraperVar;
	public TeamRpcBeingKickedNoticeNotifyWraperHelper TeamRpcBeingKickedNoticeNotifyWraperVar;
	public TeamRpcBreakUpAskWraperHelper TeamRpcBreakUpAskWraperVar;
	public TeamRpcAddNewMemberNoticeNotifyWraperHelper TeamRpcAddNewMemberNoticeNotifyWraperVar;
	public TeamRpcCaptainAutoMatchAskWraperHelper TeamRpcCaptainAutoMatchAskWraperVar;
	public TeamRpcNormalAutoMatchAskWraperHelper TeamRpcNormalAutoMatchAskWraperVar;
	public TeamRpcFollowAskWraperHelper TeamRpcFollowAskWraperVar;
	public TeamRpcClearApplyListAskWraperHelper TeamRpcClearApplyListAskWraperVar;


	public void TestCreateTeam()
	{
		TeamRPC.Instance.CreateTeam(TeamRpcCreateTeamAskWraperVar.TargetId,TeamRpcCreateTeamAskWraperVar.TargetMinLv,TeamRpcCreateTeamAskWraperVar.TargetMaxLv,delegate(object obj){});
	}
	public void TestApplyForTeam()
	{
		TeamRPC.Instance.ApplyForTeam(TeamRpcApplyForTeamAskWraperVar.TeamId,delegate(object obj){});
	}
	public void TestQuitTeam()
	{
		TeamRPC.Instance.QuitTeam();
	}
	public void TestBreakUp()
	{
		TeamRPC.Instance.BreakUp(delegate(object obj){});
	}
	public void TestInviteToTeam()
	{
		TeamRPC.Instance.InviteToTeam(TeamRpcInviteToTeamAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestChangeTeamTarget()
	{
		TeamRPC.Instance.ChangeTeamTarget(TeamRpcChangeTeamTargetAskWraperVar.TargetId,TeamRpcChangeTeamTargetAskWraperVar.TargetMinLv,TeamRpcChangeTeamTargetAskWraperVar.TargetMaxLv,delegate(object obj){});
	}
	public void TestBeInviteHandle()
	{
		TeamRPC.Instance.BeInviteHandle(TeamRpcBeInviteHandleAskWraperVar.TeamId,TeamRpcBeInviteHandleAskWraperVar.UserId,TeamRpcBeInviteHandleAskWraperVar.Handle,delegate(object obj){});
	}
	public void TestNearbyTeam()
	{
		TeamRPC.Instance.NearbyTeam(TeamRpcNearbyTeamAskWraperVar.TargetId,delegate(object obj){});
	}
	public void TestApplyHandleAgree()
	{
		TeamRPC.Instance.ApplyHandleAgree(TeamRpcApplyHandleAgreeAskWraperVar.UserId,TeamRpcApplyHandleAgreeAskWraperVar.TeamId,TeamRpcApplyHandleAgreeAskWraperVar.Handle,delegate(object obj){});
	}
	public void TestReqMyTeamData()
	{
		TeamRPC.Instance.ReqMyTeamData();
	}
	public void TestAppointCaptain()
	{
		TeamRPC.Instance.AppointCaptain(TeamRpcAppointCaptainAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestNearbyRoleList()
	{
		TeamRPC.Instance.NearbyRoleList(delegate(object obj){});
	}
	public void TestKickRole()
	{
		TeamRPC.Instance.KickRole(TeamRpcKickRoleAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestCaptainAutoMatch()
	{
		TeamRPC.Instance.CaptainAutoMatch(TeamRpcCaptainAutoMatchAskWraperVar.Oper,delegate(object obj){});
	}
	public void TestNormalAutoMatch()
	{
		TeamRPC.Instance.NormalAutoMatch(TeamRpcNormalAutoMatchAskWraperVar.Oper,TeamRpcNormalAutoMatchAskWraperVar.Target,delegate(object obj){});
	}
	public void TestFollow()
	{
		TeamRPC.Instance.Follow(delegate(object obj){});
	}
	public void TestClearApplyList()
	{
		TeamRPC.Instance.ClearApplyList(delegate(object obj){});
	}


}

[CustomEditor(typeof(TeamTestHelper))]
public class TeamTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("CreateTeam"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestCreateTeam();
		}
		if (GUILayout.Button("ApplyForTeam"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestApplyForTeam();
		}
		if (GUILayout.Button("QuitTeam"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestQuitTeam();
		}
		if (GUILayout.Button("BreakUp"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestBreakUp();
		}
		if (GUILayout.Button("InviteToTeam"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestInviteToTeam();
		}
		if (GUILayout.Button("ChangeTeamTarget"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestChangeTeamTarget();
		}
		if (GUILayout.Button("BeInviteHandle"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestBeInviteHandle();
		}
		if (GUILayout.Button("NearbyTeam"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestNearbyTeam();
		}
		if (GUILayout.Button("ApplyHandleAgree"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestApplyHandleAgree();
		}
		if (GUILayout.Button("ReqMyTeamData"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestReqMyTeamData();
		}
		if (GUILayout.Button("AppointCaptain"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestAppointCaptain();
		}
		if (GUILayout.Button("NearbyRoleList"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestNearbyRoleList();
		}
		if (GUILayout.Button("KickRole"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestKickRole();
		}
		if (GUILayout.Button("CaptainAutoMatch"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestCaptainAutoMatch();
		}
		if (GUILayout.Button("NormalAutoMatch"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestNormalAutoMatch();
		}
		if (GUILayout.Button("Follow"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestFollow();
		}
		if (GUILayout.Button("ClearApplyList"))
		{
			TeamTestHelper rpc = target as TeamTestHelper;
			if( rpc ) rpc.TestClearApplyList();
		}


    }

}
#endif