/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleTeam.cs
Author:
Description:
Version:	  1.0
History:
  <author>  <time>   <version >   <desc>

***********************************************************/
using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class TeamRPC
{
	public const int ModuleId = 26;
	
	public const int RPC_CODE_TEAM_CREATETEAM_REQUEST = 2651;
	public const int RPC_CODE_TEAM_APPLYFORTEAM_REQUEST = 2652;
	public const int RPC_CODE_TEAM_QUITTEAM_NOTIFY = 2653;
	public const int RPC_CODE_TEAM_BREAKUP_REQUEST = 2654;
	public const int RPC_CODE_TEAM_INVITETOTEAM_REQUEST = 2655;
	public const int RPC_CODE_TEAM_CHANGETEAMTARGET_REQUEST = 2656;
	public const int RPC_CODE_TEAM_BEINVITEDNOTICE_NOTIFY = 2657;
	public const int RPC_CODE_TEAM_BEINVITEHANDLE_REQUEST = 2658;
	public const int RPC_CODE_TEAM_NEARBYTEAM_REQUEST = 2659;
	public const int RPC_CODE_TEAM_APPLYNOTICECAPTAIN_NOTIFY = 2660;
	public const int RPC_CODE_TEAM_APPLYHANDLEAGREE_REQUEST = 2661;
	public const int RPC_CODE_TEAM_UPDATEMYTEAMNOTICE_NOTIFY = 2662;
	public const int RPC_CODE_TEAM_LEAVETEAMNOTICE_NOTIFY = 2663;
	public const int RPC_CODE_TEAM_BREAKUPNOTICE_NOTIFY = 2664;
	public const int RPC_CODE_TEAM_REQMYTEAMDATA_NOTIFY = 2665;
	public const int RPC_CODE_TEAM_DELETEFROMAPPLYLIST_NOTIFY = 2666;
	public const int RPC_CODE_TEAM_APPOINTCAPTAIN_REQUEST = 2667;
	public const int RPC_CODE_TEAM_CAPTAINCHANGENOTICE_NOTIFY = 2668;
	public const int RPC_CODE_TEAM_TEAMMEMBERHPCHANGENOTICE_NOTIFY = 2669;
	public const int RPC_CODE_TEAM_INVITEHANDLENOTICE_NOTIFY = 2670;
	public const int RPC_CODE_TEAM_NEARBYROLELIST_REQUEST = 2671;
	public const int RPC_CODE_TEAM_KICKROLE_REQUEST = 2672;
	public const int RPC_CODE_TEAM_BEINGKICKEDNOTICE_NOTIFY = 2673;
	public const int RPC_CODE_TEAM_ADDNEWMEMBERNOTICE_NOTIFY = 2674;
	public const int RPC_CODE_TEAM_CAPTAINAUTOMATCH_REQUEST = 2675;
	public const int RPC_CODE_TEAM_NORMALAUTOMATCH_REQUEST = 2676;
	public const int RPC_CODE_TEAM_FOLLOW_REQUEST = 2677;
	public const int RPC_CODE_TEAM_CLEARAPPLYLIST_REQUEST = 2678;

	
	private static TeamRPC m_Instance = null;
	public static TeamRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TeamRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, TeamData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_BEINVITEDNOTICE_NOTIFY, BeInvitedNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_APPLYNOTICECAPTAIN_NOTIFY, ApplyNoticeCaptainCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_UPDATEMYTEAMNOTICE_NOTIFY, UpdateMyTeamNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_LEAVETEAMNOTICE_NOTIFY, LeaveTeamNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_BREAKUPNOTICE_NOTIFY, BreakUpNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_DELETEFROMAPPLYLIST_NOTIFY, DeleteFromApplyListCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_CAPTAINCHANGENOTICE_NOTIFY, CaptainChangeNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_TEAMMEMBERHPCHANGENOTICE_NOTIFY, TeamMemberHPChangeNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_INVITEHANDLENOTICE_NOTIFY, InviteHandleNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_BEINGKICKEDNOTICE_NOTIFY, BeingKickedNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_TEAM_ADDNEWMEMBERNOTICE_NOTIFY, AddNewMemberNoticeCB);


		return true;
	}

	/**
	*组队-->离开队伍 RPC通知
	*/
	public void QuitTeam()
	{
		TeamRpcQuitTeamNotifyWraper notifyPBWraper = new TeamRpcQuitTeamNotifyWraper();
		ModMessage notifyMsg = new ModMessage();
		notifyMsg.MsgNum = RPC_CODE_TEAM_QUITTEAM_NOTIFY;
		notifyMsg.protoMS = notifyPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendNotify(notifyMsg);
	}

	/**
	*组队-->请求我的队伍数据 RPC通知
	*/
	public void ReqMyTeamData()
	{
		TeamRpcReqMyTeamDataNotifyWraper notifyPBWraper = new TeamRpcReqMyTeamDataNotifyWraper();
		ModMessage notifyMsg = new ModMessage();
		notifyMsg.MsgNum = RPC_CODE_TEAM_REQMYTEAMDATA_NOTIFY;
		notifyMsg.protoMS = notifyPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendNotify(notifyMsg);
	}


	/**
	*组队-->创建队伍 RPC请求
	*/
	public void CreateTeam(int TargetId, int TargetMinLv, int TargetMaxLv, ReplyHandler replyCB)
	{
		TeamRpcCreateTeamAskWraper askPBWraper = new TeamRpcCreateTeamAskWraper();
		askPBWraper.TargetId = TargetId;
		askPBWraper.TargetMinLv = TargetMinLv;
		askPBWraper.TargetMaxLv = TargetMaxLv;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_CREATETEAM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcCreateTeamReplyWraper replyPBWraper = new TeamRpcCreateTeamReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->申请入队 RPC请求
	*/
	public void ApplyForTeam(int TeamId, ReplyHandler replyCB)
	{
		TeamRpcApplyForTeamAskWraper askPBWraper = new TeamRpcApplyForTeamAskWraper();
		askPBWraper.TeamId = TeamId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_APPLYFORTEAM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcApplyForTeamReplyWraper replyPBWraper = new TeamRpcApplyForTeamReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->解散队伍 RPC请求
	*/
	public void BreakUp(ReplyHandler replyCB)
	{
		TeamRpcBreakUpAskWraper askPBWraper = new TeamRpcBreakUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_BREAKUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcBreakUpReplyWraper replyPBWraper = new TeamRpcBreakUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->邀请入队 RPC请求
	*/
	public void InviteToTeam(long UserId, ReplyHandler replyCB)
	{
		TeamRpcInviteToTeamAskWraper askPBWraper = new TeamRpcInviteToTeamAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_INVITETOTEAM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcInviteToTeamReplyWraper replyPBWraper = new TeamRpcInviteToTeamReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->更改队伍目标 RPC请求
	*/
	public void ChangeTeamTarget(int TargetId, int TargetMinLv, int TargetMaxLv, ReplyHandler replyCB)
	{
		TeamRpcChangeTeamTargetAskWraper askPBWraper = new TeamRpcChangeTeamTargetAskWraper();
		askPBWraper.TargetId = TargetId;
		askPBWraper.TargetMinLv = TargetMinLv;
		askPBWraper.TargetMaxLv = TargetMaxLv;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_CHANGETEAMTARGET_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcChangeTeamTargetReplyWraper replyPBWraper = new TeamRpcChangeTeamTargetReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->被邀请处理 RPC请求
	*/
	public void BeInviteHandle(int TeamId, long UserId, int Handle, ReplyHandler replyCB)
	{
		TeamRpcBeInviteHandleAskWraper askPBWraper = new TeamRpcBeInviteHandleAskWraper();
		askPBWraper.TeamId = TeamId;
		askPBWraper.UserId = UserId;
		askPBWraper.Handle = Handle;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_BEINVITEHANDLE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcBeInviteHandleReplyWraper replyPBWraper = new TeamRpcBeInviteHandleReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->附近队伍 RPC请求
	*/
	public void NearbyTeam(int TargetId, ReplyHandler replyCB)
	{
		TeamRpcNearbyTeamAskWraper askPBWraper = new TeamRpcNearbyTeamAskWraper();
		askPBWraper.TargetId = TargetId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_NEARBYTEAM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcNearbyTeamReplyWraper replyPBWraper = new TeamRpcNearbyTeamReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->申请入队,队长同意入队 RPC请求
	*/
	public void ApplyHandleAgree(long UserId, int TeamId, int Handle, ReplyHandler replyCB)
	{
		TeamRpcApplyHandleAgreeAskWraper askPBWraper = new TeamRpcApplyHandleAgreeAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.TeamId = TeamId;
		askPBWraper.Handle = Handle;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_APPLYHANDLEAGREE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcApplyHandleAgreeReplyWraper replyPBWraper = new TeamRpcApplyHandleAgreeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->任命队长 RPC请求
	*/
	public void AppointCaptain(long UserId, ReplyHandler replyCB)
	{
		TeamRpcAppointCaptainAskWraper askPBWraper = new TeamRpcAppointCaptainAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_APPOINTCAPTAIN_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcAppointCaptainReplyWraper replyPBWraper = new TeamRpcAppointCaptainReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->附加玩家列表，邀请时使用 RPC请求
	*/
	public void NearbyRoleList(ReplyHandler replyCB)
	{
		TeamRpcNearbyRoleListAskWraper askPBWraper = new TeamRpcNearbyRoleListAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_NEARBYROLELIST_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcNearbyRoleListReplyWraper replyPBWraper = new TeamRpcNearbyRoleListReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->队长踢人 RPC请求
	*/
	public void KickRole(long UserId, ReplyHandler replyCB)
	{
		TeamRpcKickRoleAskWraper askPBWraper = new TeamRpcKickRoleAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_KICKROLE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcKickRoleReplyWraper replyPBWraper = new TeamRpcKickRoleReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->队长自己匹配 RPC请求
	*/
	public void CaptainAutoMatch(int Oper, ReplyHandler replyCB)
	{
		TeamRpcCaptainAutoMatchAskWraper askPBWraper = new TeamRpcCaptainAutoMatchAskWraper();
		askPBWraper.Oper = Oper;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_CAPTAINAUTOMATCH_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcCaptainAutoMatchReplyWraper replyPBWraper = new TeamRpcCaptainAutoMatchReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->非队长匹配 RPC请求
	*/
	public void NormalAutoMatch(int Oper, int Target, ReplyHandler replyCB)
	{
		TeamRpcNormalAutoMatchAskWraper askPBWraper = new TeamRpcNormalAutoMatchAskWraper();
		askPBWraper.Oper = Oper;
		askPBWraper.Target = Target;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_NORMALAUTOMATCH_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcNormalAutoMatchReplyWraper replyPBWraper = new TeamRpcNormalAutoMatchReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->跟随 RPC请求
	*/
	public void Follow(ReplyHandler replyCB)
	{
		TeamRpcFollowAskWraper askPBWraper = new TeamRpcFollowAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_FOLLOW_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcFollowReplyWraper replyPBWraper = new TeamRpcFollowReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*组队-->清空申请列表 RPC请求
	*/
	public void ClearApplyList(ReplyHandler replyCB)
	{
		TeamRpcClearApplyListAskWraper askPBWraper = new TeamRpcClearApplyListAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_TEAM_CLEARAPPLYLIST_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			TeamRpcClearApplyListReplyWraper replyPBWraper = new TeamRpcClearApplyListReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*组队-->被邀请入队通知 服务器通知回调
	*/
	public static void BeInvitedNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcBeInvitedNoticeNotifyWraper notifyPBWraper = new TeamRpcBeInvitedNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BeInvitedNoticeCBDelegate != null )
			BeInvitedNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BeInvitedNoticeCBDelegate = null;
	/**
	*组队-->申请入队通知,所有人都可以看,但只有队长才能同意 服务器通知回调
	*/
	public static void ApplyNoticeCaptainCB( ModMessage notifyMsg )
	{
		TeamRpcApplyNoticeCaptainNotifyWraper notifyPBWraper = new TeamRpcApplyNoticeCaptainNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( ApplyNoticeCaptainCBDelegate != null )
			ApplyNoticeCaptainCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback ApplyNoticeCaptainCBDelegate = null;
	/**
	*组队-->更新我的队伍通知 服务器通知回调
	*/
	public static void UpdateMyTeamNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcUpdateMyTeamNoticeNotifyWraper notifyPBWraper = new TeamRpcUpdateMyTeamNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( UpdateMyTeamNoticeCBDelegate != null )
			UpdateMyTeamNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback UpdateMyTeamNoticeCBDelegate = null;
	/**
	*组队-->离开队伍通知 服务器通知回调
	*/
	public static void LeaveTeamNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcLeaveTeamNoticeNotifyWraper notifyPBWraper = new TeamRpcLeaveTeamNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( LeaveTeamNoticeCBDelegate != null )
			LeaveTeamNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback LeaveTeamNoticeCBDelegate = null;
	/**
	*组队-->解散队伍通知 服务器通知回调
	*/
	public static void BreakUpNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcBreakUpNoticeNotifyWraper notifyPBWraper = new TeamRpcBreakUpNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BreakUpNoticeCBDelegate != null )
			BreakUpNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BreakUpNoticeCBDelegate = null;
	/**
	*组队-->申请列表处理后删除申请的玩家 服务器通知回调
	*/
	public static void DeleteFromApplyListCB( ModMessage notifyMsg )
	{
		TeamRpcDeleteFromApplyListNotifyWraper notifyPBWraper = new TeamRpcDeleteFromApplyListNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( DeleteFromApplyListCBDelegate != null )
			DeleteFromApplyListCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback DeleteFromApplyListCBDelegate = null;
	/**
	*组队-->队长换人通知 服务器通知回调
	*/
	public static void CaptainChangeNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcCaptainChangeNoticeNotifyWraper notifyPBWraper = new TeamRpcCaptainChangeNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( CaptainChangeNoticeCBDelegate != null )
			CaptainChangeNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback CaptainChangeNoticeCBDelegate = null;
	/**
	*组队-->队员血量变化通知 服务器通知回调
	*/
	public static void TeamMemberHPChangeNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcTeamMemberHPChangeNoticeNotifyWraper notifyPBWraper = new TeamRpcTeamMemberHPChangeNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( TeamMemberHPChangeNoticeCBDelegate != null )
			TeamMemberHPChangeNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback TeamMemberHPChangeNoticeCBDelegate = null;
	/**
	*组队-->邀请组队的人收到被邀请人的处理通知 服务器通知回调
	*/
	public static void InviteHandleNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcInviteHandleNoticeNotifyWraper notifyPBWraper = new TeamRpcInviteHandleNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( InviteHandleNoticeCBDelegate != null )
			InviteHandleNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback InviteHandleNoticeCBDelegate = null;
	/**
	*组队-->被踢通知 服务器通知回调
	*/
	public static void BeingKickedNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcBeingKickedNoticeNotifyWraper notifyPBWraper = new TeamRpcBeingKickedNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BeingKickedNoticeCBDelegate != null )
			BeingKickedNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BeingKickedNoticeCBDelegate = null;
	/**
	*组队-->队员增加新成员通知 服务器通知回调
	*/
	public static void AddNewMemberNoticeCB( ModMessage notifyMsg )
	{
		TeamRpcAddNewMemberNoticeNotifyWraper notifyPBWraper = new TeamRpcAddNewMemberNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( AddNewMemberNoticeCBDelegate != null )
			AddNewMemberNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback AddNewMemberNoticeCBDelegate = null;



}

public class TeamData
{
	public enum SyncIdE
	{

	}
	
	private static TeamData m_Instance = null;
	public static TeamData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new TeamData();
			}
			return m_Instance;

		}
	}
	

	public void UpdateField(int Id, int Index, byte[] buff, int start, int len )
	{
		SyncIdE SyncId = (SyncIdE)Id;
		byte[]  updateBuffer = new byte[len];
		Array.Copy(buff, start, updateBuffer, 0, len);
		int  iValue = 0;
		long lValue = 0;

		switch (SyncId)
		{

			default:
				break;
		}

		try
		{
			if (NotifySyncValueChanged!=null)
				NotifySyncValueChanged(Id, Index);
		}
		catch
		{
			Ex.Logger.Log("TeamData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
