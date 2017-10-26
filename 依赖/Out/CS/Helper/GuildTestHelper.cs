#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class GuildRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcCreateGuildAskWraperHelper
{
	public string GuildName;
	public string Announcement;
}
[System.Serializable]
public class GuildRpcApplyGuildAskWraperHelper
{
	public int Guild;
	public int Oper;
}
[System.Serializable]
public class GuildRpcQuickApplyAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcChangeGuildNameAskWraperHelper
{
	public string GuildName;
}
[System.Serializable]
public class GuildRpcChangeAnnouncementAskWraperHelper
{
	public string Announcement;
}
[System.Serializable]
public class GuildRpcReqGuildListAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcAppointDutyAskWraperHelper
{
	public long UserId;
	public int Duty;
}
[System.Serializable]
public class GuildRpcKickoutAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class GuildRpcExitGuildAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcBreakUpAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcInviteToJoinAskWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class GuildRpcBeInvitedNoticeNotifyWraperHelper
{
	public long UserId;
	public int Guild;
	public string GuildName;
}
[System.Serializable]
public class GuildRpcBeInvitedHandleAskWraperHelper
{
	public int Guild;
	public int Oper;
}
[System.Serializable]
public class GuildRpcResignDutyAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcSyncMyTeamDataNotifyWraperHelper
{
	public GuildInfoObjWraper GuildData;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfGuildBaseDataNotifyWraperHelper
{
	public string GuildName;
	public int Level;
	public long CaptainId;
	public string CaptainName;
	public int Funds;
	public int LeagueMatchesRank;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraperHelper
{
	public GuildMemberObjWraper GuildMember;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfAddMemberNotifyWraperHelper
{
	public GuildMemberObjWraper GuildMember;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfDelMemberNotifyWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfAddEventNotifyWraperHelper
{
	public int EventId;
	public string Param1;
	public string Param2;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfAddApplyListNotifyWraperHelper
{
	public ApplyListRoleInfoObjWraper ApplyPlayer;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfDelApplyListNotifyWraperHelper
{
	public long UserId;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraperHelper
{
	public string Announcement;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfBreakupNotifyWraperHelper
{
}
[System.Serializable]
public class GuildRpcHallLvUpAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcHouseLvUpAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcStoreroomLvUpAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcKongfuHallLvUpAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcSyncNoticeOfHallLvUpNotifyWraperHelper
{
	public int Lv;
	public int Time;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfHouseLvUpNotifyWraperHelper
{
	public int Lv;
	public int Time;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfStorerommLvUpNotifyWraperHelper
{
	public int Lv;
	public int Time;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraperHelper
{
	public int Lv;
	public int Time;
}
[System.Serializable]
public class GuildRpcApplyGuildHandleAskWraperHelper
{
	public long UserId;
	public int Oper;
}
[System.Serializable]
public class GuildRpcCreateGuildDungeonAskWraperHelper
{
	public int DungeonNum;
}
[System.Serializable]
public class GuildRpcEnterGuildDungeonAskWraperHelper
{
	public int Index;
}
[System.Serializable]
public class GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraperHelper
{
	public List<GuildDungeonObjWraper> DungeonList;
}
[System.Serializable]
public class GuildRpcCreateGuildWarAskWraperHelper
{
	public int Guild;
}
[System.Serializable]
public class GuildRpcSyncNoticeOfOpenGuildWarNotifyWraperHelper
{
	public GuildWarObjWraper GuildWar;
}
[System.Serializable]
public class GuildRpcEnterGuildWarAskWraperHelper
{
}
[System.Serializable]
public class GuildRpcOpenScienceAttrAskWraperHelper
{
	public int ScienceId;
}
[System.Serializable]
public class GuildRpcGuildScienceLvUpAskWraperHelper
{
	public int ScienceId;
	public bool IsKeyUpLv;
}



public class GuildTestHelper : MonoBehaviour
{
	public GuildRpcSyncDataAskWraperHelper GuildRpcSyncDataAskWraperVar;
	public GuildRpcCreateGuildAskWraperHelper GuildRpcCreateGuildAskWraperVar;
	public GuildRpcApplyGuildAskWraperHelper GuildRpcApplyGuildAskWraperVar;
	public GuildRpcQuickApplyAskWraperHelper GuildRpcQuickApplyAskWraperVar;
	public GuildRpcChangeGuildNameAskWraperHelper GuildRpcChangeGuildNameAskWraperVar;
	public GuildRpcChangeAnnouncementAskWraperHelper GuildRpcChangeAnnouncementAskWraperVar;
	public GuildRpcReqGuildListAskWraperHelper GuildRpcReqGuildListAskWraperVar;
	public GuildRpcAppointDutyAskWraperHelper GuildRpcAppointDutyAskWraperVar;
	public GuildRpcKickoutAskWraperHelper GuildRpcKickoutAskWraperVar;
	public GuildRpcExitGuildAskWraperHelper GuildRpcExitGuildAskWraperVar;
	public GuildRpcBreakUpAskWraperHelper GuildRpcBreakUpAskWraperVar;
	public GuildRpcInviteToJoinAskWraperHelper GuildRpcInviteToJoinAskWraperVar;
	public GuildRpcBeInvitedNoticeNotifyWraperHelper GuildRpcBeInvitedNoticeNotifyWraperVar;
	public GuildRpcBeInvitedHandleAskWraperHelper GuildRpcBeInvitedHandleAskWraperVar;
	public GuildRpcResignDutyAskWraperHelper GuildRpcResignDutyAskWraperVar;
	public GuildRpcSyncMyTeamDataNotifyWraperHelper GuildRpcSyncMyTeamDataNotifyWraperVar;
	public GuildRpcSyncNoticeOfGuildBaseDataNotifyWraperHelper GuildRpcSyncNoticeOfGuildBaseDataNotifyWraperVar;
	public GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraperHelper GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraperVar;
	public GuildRpcSyncNoticeOfAddMemberNotifyWraperHelper GuildRpcSyncNoticeOfAddMemberNotifyWraperVar;
	public GuildRpcSyncNoticeOfDelMemberNotifyWraperHelper GuildRpcSyncNoticeOfDelMemberNotifyWraperVar;
	public GuildRpcSyncNoticeOfAddEventNotifyWraperHelper GuildRpcSyncNoticeOfAddEventNotifyWraperVar;
	public GuildRpcSyncNoticeOfAddApplyListNotifyWraperHelper GuildRpcSyncNoticeOfAddApplyListNotifyWraperVar;
	public GuildRpcSyncNoticeOfDelApplyListNotifyWraperHelper GuildRpcSyncNoticeOfDelApplyListNotifyWraperVar;
	public GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraperHelper GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraperVar;
	public GuildRpcSyncNoticeOfBreakupNotifyWraperHelper GuildRpcSyncNoticeOfBreakupNotifyWraperVar;
	public GuildRpcHallLvUpAskWraperHelper GuildRpcHallLvUpAskWraperVar;
	public GuildRpcHouseLvUpAskWraperHelper GuildRpcHouseLvUpAskWraperVar;
	public GuildRpcStoreroomLvUpAskWraperHelper GuildRpcStoreroomLvUpAskWraperVar;
	public GuildRpcKongfuHallLvUpAskWraperHelper GuildRpcKongfuHallLvUpAskWraperVar;
	public GuildRpcSyncNoticeOfHallLvUpNotifyWraperHelper GuildRpcSyncNoticeOfHallLvUpNotifyWraperVar;
	public GuildRpcSyncNoticeOfHouseLvUpNotifyWraperHelper GuildRpcSyncNoticeOfHouseLvUpNotifyWraperVar;
	public GuildRpcSyncNoticeOfStorerommLvUpNotifyWraperHelper GuildRpcSyncNoticeOfStorerommLvUpNotifyWraperVar;
	public GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraperHelper GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraperVar;
	public GuildRpcApplyGuildHandleAskWraperHelper GuildRpcApplyGuildHandleAskWraperVar;
	public GuildRpcCreateGuildDungeonAskWraperHelper GuildRpcCreateGuildDungeonAskWraperVar;
	public GuildRpcEnterGuildDungeonAskWraperHelper GuildRpcEnterGuildDungeonAskWraperVar;
	public GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraperHelper GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraperVar;
	public GuildRpcCreateGuildWarAskWraperHelper GuildRpcCreateGuildWarAskWraperVar;
	public GuildRpcSyncNoticeOfOpenGuildWarNotifyWraperHelper GuildRpcSyncNoticeOfOpenGuildWarNotifyWraperVar;
	public GuildRpcEnterGuildWarAskWraperHelper GuildRpcEnterGuildWarAskWraperVar;
	public GuildRpcOpenScienceAttrAskWraperHelper GuildRpcOpenScienceAttrAskWraperVar;
	public GuildRpcGuildScienceLvUpAskWraperHelper GuildRpcGuildScienceLvUpAskWraperVar;


	public void TestSyncData()
	{
		GuildRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestCreateGuild()
	{
		GuildRPC.Instance.CreateGuild(GuildRpcCreateGuildAskWraperVar.GuildName,GuildRpcCreateGuildAskWraperVar.Announcement,delegate(object obj){});
	}
	public void TestApplyGuild()
	{
		GuildRPC.Instance.ApplyGuild(GuildRpcApplyGuildAskWraperVar.Guild,GuildRpcApplyGuildAskWraperVar.Oper,delegate(object obj){});
	}
	public void TestQuickApply()
	{
		GuildRPC.Instance.QuickApply(delegate(object obj){});
	}
	public void TestChangeGuildName()
	{
		GuildRPC.Instance.ChangeGuildName(GuildRpcChangeGuildNameAskWraperVar.GuildName,delegate(object obj){});
	}
	public void TestChangeAnnouncement()
	{
		GuildRPC.Instance.ChangeAnnouncement(GuildRpcChangeAnnouncementAskWraperVar.Announcement,delegate(object obj){});
	}
	public void TestReqGuildList()
	{
		GuildRPC.Instance.ReqGuildList(delegate(object obj){});
	}
	public void TestAppointDuty()
	{
		GuildRPC.Instance.AppointDuty(GuildRpcAppointDutyAskWraperVar.UserId,GuildRpcAppointDutyAskWraperVar.Duty,delegate(object obj){});
	}
	public void TestKickout()
	{
		GuildRPC.Instance.Kickout(GuildRpcKickoutAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestExitGuild()
	{
		GuildRPC.Instance.ExitGuild(delegate(object obj){});
	}
	public void TestBreakUp()
	{
		GuildRPC.Instance.BreakUp(delegate(object obj){});
	}
	public void TestInviteToJoin()
	{
		GuildRPC.Instance.InviteToJoin(GuildRpcInviteToJoinAskWraperVar.UserId,delegate(object obj){});
	}
	public void TestBeInvitedHandle()
	{
		GuildRPC.Instance.BeInvitedHandle(GuildRpcBeInvitedHandleAskWraperVar.Guild,GuildRpcBeInvitedHandleAskWraperVar.Oper,delegate(object obj){});
	}
	public void TestResignDuty()
	{
		GuildRPC.Instance.ResignDuty(delegate(object obj){});
	}
	public void TestHallLvUp()
	{
		GuildRPC.Instance.HallLvUp(delegate(object obj){});
	}
	public void TestHouseLvUp()
	{
		GuildRPC.Instance.HouseLvUp(delegate(object obj){});
	}
	public void TestStoreroomLvUp()
	{
		GuildRPC.Instance.StoreroomLvUp(delegate(object obj){});
	}
	public void TestKongfuHallLvUp()
	{
		GuildRPC.Instance.KongfuHallLvUp(delegate(object obj){});
	}
	public void TestApplyGuildHandle()
	{
		GuildRPC.Instance.ApplyGuildHandle(GuildRpcApplyGuildHandleAskWraperVar.UserId,GuildRpcApplyGuildHandleAskWraperVar.Oper,delegate(object obj){});
	}
	public void TestCreateGuildDungeon()
	{
		GuildRPC.Instance.CreateGuildDungeon(GuildRpcCreateGuildDungeonAskWraperVar.DungeonNum,delegate(object obj){});
	}
	public void TestEnterGuildDungeon()
	{
		GuildRPC.Instance.EnterGuildDungeon(GuildRpcEnterGuildDungeonAskWraperVar.Index,delegate(object obj){});
	}
	public void TestCreateGuildWar()
	{
		GuildRPC.Instance.CreateGuildWar(GuildRpcCreateGuildWarAskWraperVar.Guild,delegate(object obj){});
	}
	public void TestEnterGuildWar()
	{
		GuildRPC.Instance.EnterGuildWar(delegate(object obj){});
	}
	public void TestOpenScienceAttr()
	{
		GuildRPC.Instance.OpenScienceAttr(GuildRpcOpenScienceAttrAskWraperVar.ScienceId,delegate(object obj){});
	}
	public void TestGuildScienceLvUp()
	{
		GuildRPC.Instance.GuildScienceLvUp(GuildRpcGuildScienceLvUpAskWraperVar.ScienceId,GuildRpcGuildScienceLvUpAskWraperVar.IsKeyUpLv,delegate(object obj){});
	}


}

[CustomEditor(typeof(GuildTestHelper))]
public class GuildTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("CreateGuild"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestCreateGuild();
		}
		if (GUILayout.Button("ApplyGuild"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestApplyGuild();
		}
		if (GUILayout.Button("QuickApply"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestQuickApply();
		}
		if (GUILayout.Button("ChangeGuildName"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestChangeGuildName();
		}
		if (GUILayout.Button("ChangeAnnouncement"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestChangeAnnouncement();
		}
		if (GUILayout.Button("ReqGuildList"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestReqGuildList();
		}
		if (GUILayout.Button("AppointDuty"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestAppointDuty();
		}
		if (GUILayout.Button("Kickout"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestKickout();
		}
		if (GUILayout.Button("ExitGuild"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestExitGuild();
		}
		if (GUILayout.Button("BreakUp"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestBreakUp();
		}
		if (GUILayout.Button("InviteToJoin"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestInviteToJoin();
		}
		if (GUILayout.Button("BeInvitedHandle"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestBeInvitedHandle();
		}
		if (GUILayout.Button("ResignDuty"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestResignDuty();
		}
		if (GUILayout.Button("HallLvUp"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestHallLvUp();
		}
		if (GUILayout.Button("HouseLvUp"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestHouseLvUp();
		}
		if (GUILayout.Button("StoreroomLvUp"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestStoreroomLvUp();
		}
		if (GUILayout.Button("KongfuHallLvUp"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestKongfuHallLvUp();
		}
		if (GUILayout.Button("ApplyGuildHandle"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestApplyGuildHandle();
		}
		if (GUILayout.Button("CreateGuildDungeon"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestCreateGuildDungeon();
		}
		if (GUILayout.Button("EnterGuildDungeon"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestEnterGuildDungeon();
		}
		if (GUILayout.Button("CreateGuildWar"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestCreateGuildWar();
		}
		if (GUILayout.Button("EnterGuildWar"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestEnterGuildWar();
		}
		if (GUILayout.Button("OpenScienceAttr"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestOpenScienceAttr();
		}
		if (GUILayout.Button("GuildScienceLvUp"))
		{
			GuildTestHelper rpc = target as GuildTestHelper;
			if( rpc ) rpc.TestGuildScienceLvUp();
		}


    }

}
#endif