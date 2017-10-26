/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleGuild.cs
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


public class GuildRPC
{
	public const int ModuleId = 34;
	
	public const int RPC_CODE_GUILD_SYNCDATA_REQUEST = 3451;
	public const int RPC_CODE_GUILD_CREATEGUILD_REQUEST = 3452;
	public const int RPC_CODE_GUILD_APPLYGUILD_REQUEST = 3453;
	public const int RPC_CODE_GUILD_QUICKAPPLY_REQUEST = 3454;
	public const int RPC_CODE_GUILD_CHANGEGUILDNAME_REQUEST = 3455;
	public const int RPC_CODE_GUILD_CHANGEANNOUNCEMENT_REQUEST = 3456;
	public const int RPC_CODE_GUILD_REQGUILDLIST_REQUEST = 3457;
	public const int RPC_CODE_GUILD_APPOINTDUTY_REQUEST = 3458;
	public const int RPC_CODE_GUILD_KICKOUT_REQUEST = 3459;
	public const int RPC_CODE_GUILD_EXITGUILD_REQUEST = 3460;
	public const int RPC_CODE_GUILD_BREAKUP_REQUEST = 3461;
	public const int RPC_CODE_GUILD_INVITETOJOIN_REQUEST = 3462;
	public const int RPC_CODE_GUILD_BEINVITEDNOTICE_NOTIFY = 3463;
	public const int RPC_CODE_GUILD_BEINVITEDHANDLE_REQUEST = 3464;
	public const int RPC_CODE_GUILD_RESIGNDUTY_REQUEST = 3465;
	public const int RPC_CODE_GUILD_SYNCMYTEAMDATA_NOTIFY = 3466;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFGUILDBASEDATA_NOTIFY = 3467;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFGUILDMEMBERCHANGE_NOTIFY = 3468;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFADDMEMBER_NOTIFY = 3469;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFDELMEMBER_NOTIFY = 3470;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFADDEVENT_NOTIFY = 3471;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFADDAPPLYLIST_NOTIFY = 3472;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFDELAPPLYLIST_NOTIFY = 3473;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFCHANGEANNOUNCEMENT_NOTIFY = 3474;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFBREAKUP_NOTIFY = 3475;
	public const int RPC_CODE_GUILD_HALLLVUP_REQUEST = 3476;
	public const int RPC_CODE_GUILD_HOUSELVUP_REQUEST = 3477;
	public const int RPC_CODE_GUILD_STOREROOMLVUP_REQUEST = 3478;
	public const int RPC_CODE_GUILD_KONGFUHALLLVUP_REQUEST = 3479;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFHALLLVUP_NOTIFY = 3480;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFHOUSELVUP_NOTIFY = 3481;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFSTOREROMMLVUP_NOTIFY = 3482;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFKONGFUHALLLVUP_NOTIFY = 3483;
	public const int RPC_CODE_GUILD_APPLYGUILDHANDLE_REQUEST = 3484;
	public const int RPC_CODE_GUILD_CREATEGUILDDUNGEON_REQUEST = 3485;
	public const int RPC_CODE_GUILD_ENTERGUILDDUNGEON_REQUEST = 3486;
	public const int RPC_CODE_GUILD_RPCSYNCNOTICEOFCREATEGUILDDUNGEON_NOTIFY = 3487;
	public const int RPC_CODE_GUILD_CREATEGUILDWAR_REQUEST = 3488;
	public const int RPC_CODE_GUILD_SYNCNOTICEOFOPENGUILDWAR_NOTIFY = 3489;
	public const int RPC_CODE_GUILD_ENTERGUILDWAR_REQUEST = 3490;
	public const int RPC_CODE_GUILD_OPENSCIENCEATTR_REQUEST = 3491;
	public const int RPC_CODE_GUILD_GUILDSCIENCELVUP_REQUEST = 3492;

	
	private static GuildRPC m_Instance = null;
	public static GuildRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GuildRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, GuildData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_BEINVITEDNOTICE_NOTIFY, BeInvitedNoticeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCMYTEAMDATA_NOTIFY, SyncMyTeamDataCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFGUILDBASEDATA_NOTIFY, SyncNoticeOfGuildBaseDataCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFGUILDMEMBERCHANGE_NOTIFY, SyncNoticeOfGuildMemberChangeCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFADDMEMBER_NOTIFY, SyncNoticeOfAddMemberCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFDELMEMBER_NOTIFY, SyncNoticeOfDelMemberCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFADDEVENT_NOTIFY, SyncNoticeOfAddEventCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFADDAPPLYLIST_NOTIFY, SyncNoticeOfAddApplyListCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFDELAPPLYLIST_NOTIFY, SyncNoticeOfDelApplyListCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFCHANGEANNOUNCEMENT_NOTIFY, SyncNoticeOfChangeAnnouncementCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFBREAKUP_NOTIFY, SyncNoticeOfBreakupCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFHALLLVUP_NOTIFY, SyncNoticeOfHallLvUpCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFHOUSELVUP_NOTIFY, SyncNoticeOfHouseLvUpCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFSTOREROMMLVUP_NOTIFY, SyncNoticeOfStorerommLvUpCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFKONGFUHALLLVUP_NOTIFY, SyncNoticeOfKongfuHallLvUpCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_RPCSYNCNOTICEOFCREATEGUILDDUNGEON_NOTIFY, RpcSyncNoticeOfCreateGuildDungeonCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_GUILD_SYNCNOTICEOFOPENGUILDWAR_NOTIFY, SyncNoticeOfOpenGuildWarCB);


		return true;
	}


	/**
	*帮派-->登陆后，同步一次数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		GuildRpcSyncDataAskWraper askPBWraper = new GuildRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcSyncDataReplyWraper replyPBWraper = new GuildRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->创建帮会 RPC请求
	*/
	public void CreateGuild(string GuildName, string Announcement, ReplyHandler replyCB)
	{
		GuildRpcCreateGuildAskWraper askPBWraper = new GuildRpcCreateGuildAskWraper();
		askPBWraper.GuildName = GuildName;
		askPBWraper.Announcement = Announcement;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_CREATEGUILD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcCreateGuildReplyWraper replyPBWraper = new GuildRpcCreateGuildReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->申请入帮 RPC请求
	*/
	public void ApplyGuild(int Guild, int Oper, ReplyHandler replyCB)
	{
		GuildRpcApplyGuildAskWraper askPBWraper = new GuildRpcApplyGuildAskWraper();
		askPBWraper.Guild = Guild;
		askPBWraper.Oper = Oper;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_APPLYGUILD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcApplyGuildReplyWraper replyPBWraper = new GuildRpcApplyGuildReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->快速申请 RPC请求
	*/
	public void QuickApply(ReplyHandler replyCB)
	{
		GuildRpcQuickApplyAskWraper askPBWraper = new GuildRpcQuickApplyAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_QUICKAPPLY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcQuickApplyReplyWraper replyPBWraper = new GuildRpcQuickApplyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->修改帮会名字 RPC请求
	*/
	public void ChangeGuildName(string GuildName, ReplyHandler replyCB)
	{
		GuildRpcChangeGuildNameAskWraper askPBWraper = new GuildRpcChangeGuildNameAskWraper();
		askPBWraper.GuildName = GuildName;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_CHANGEGUILDNAME_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcChangeGuildNameReplyWraper replyPBWraper = new GuildRpcChangeGuildNameReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->修改公告 RPC请求
	*/
	public void ChangeAnnouncement(string Announcement, ReplyHandler replyCB)
	{
		GuildRpcChangeAnnouncementAskWraper askPBWraper = new GuildRpcChangeAnnouncementAskWraper();
		askPBWraper.Announcement = Announcement;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_CHANGEANNOUNCEMENT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcChangeAnnouncementReplyWraper replyPBWraper = new GuildRpcChangeAnnouncementReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->请求帮会列表 RPC请求
	*/
	public void ReqGuildList(ReplyHandler replyCB)
	{
		GuildRpcReqGuildListAskWraper askPBWraper = new GuildRpcReqGuildListAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_REQGUILDLIST_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcReqGuildListReplyWraper replyPBWraper = new GuildRpcReqGuildListReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->任命职位 RPC请求
	*/
	public void AppointDuty(long UserId, int Duty, ReplyHandler replyCB)
	{
		GuildRpcAppointDutyAskWraper askPBWraper = new GuildRpcAppointDutyAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.Duty = Duty;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_APPOINTDUTY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcAppointDutyReplyWraper replyPBWraper = new GuildRpcAppointDutyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->踢人 RPC请求
	*/
	public void Kickout(long UserId, ReplyHandler replyCB)
	{
		GuildRpcKickoutAskWraper askPBWraper = new GuildRpcKickoutAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_KICKOUT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcKickoutReplyWraper replyPBWraper = new GuildRpcKickoutReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->退出帮会 RPC请求
	*/
	public void ExitGuild(ReplyHandler replyCB)
	{
		GuildRpcExitGuildAskWraper askPBWraper = new GuildRpcExitGuildAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_EXITGUILD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcExitGuildReplyWraper replyPBWraper = new GuildRpcExitGuildReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->解散帮会 RPC请求
	*/
	public void BreakUp(ReplyHandler replyCB)
	{
		GuildRpcBreakUpAskWraper askPBWraper = new GuildRpcBreakUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_BREAKUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcBreakUpReplyWraper replyPBWraper = new GuildRpcBreakUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->邀请入帮 RPC请求
	*/
	public void InviteToJoin(long UserId, ReplyHandler replyCB)
	{
		GuildRpcInviteToJoinAskWraper askPBWraper = new GuildRpcInviteToJoinAskWraper();
		askPBWraper.UserId = UserId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_INVITETOJOIN_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcInviteToJoinReplyWraper replyPBWraper = new GuildRpcInviteToJoinReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->被邀请处理 RPC请求
	*/
	public void BeInvitedHandle(int Guild, int Oper, ReplyHandler replyCB)
	{
		GuildRpcBeInvitedHandleAskWraper askPBWraper = new GuildRpcBeInvitedHandleAskWraper();
		askPBWraper.Guild = Guild;
		askPBWraper.Oper = Oper;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_BEINVITEDHANDLE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcBeInvitedHandleReplyWraper replyPBWraper = new GuildRpcBeInvitedHandleReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->辞职 RPC请求
	*/
	public void ResignDuty(ReplyHandler replyCB)
	{
		GuildRpcResignDutyAskWraper askPBWraper = new GuildRpcResignDutyAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_RESIGNDUTY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcResignDutyReplyWraper replyPBWraper = new GuildRpcResignDutyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->帮会大厅升级 RPC请求
	*/
	public void HallLvUp(ReplyHandler replyCB)
	{
		GuildRpcHallLvUpAskWraper askPBWraper = new GuildRpcHallLvUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_HALLLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcHallLvUpReplyWraper replyPBWraper = new GuildRpcHallLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->帮会房屋升级 RPC请求
	*/
	public void HouseLvUp(ReplyHandler replyCB)
	{
		GuildRpcHouseLvUpAskWraper askPBWraper = new GuildRpcHouseLvUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_HOUSELVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcHouseLvUpReplyWraper replyPBWraper = new GuildRpcHouseLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->帮会库房升级 RPC请求
	*/
	public void StoreroomLvUp(ReplyHandler replyCB)
	{
		GuildRpcStoreroomLvUpAskWraper askPBWraper = new GuildRpcStoreroomLvUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_STOREROOMLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcStoreroomLvUpReplyWraper replyPBWraper = new GuildRpcStoreroomLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->帮会练武堂升级 RPC请求
	*/
	public void KongfuHallLvUp(ReplyHandler replyCB)
	{
		GuildRpcKongfuHallLvUpAskWraper askPBWraper = new GuildRpcKongfuHallLvUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_KONGFUHALLLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcKongfuHallLvUpReplyWraper replyPBWraper = new GuildRpcKongfuHallLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->申请入帮，帮主处理 RPC请求
	*/
	public void ApplyGuildHandle(long UserId, int Oper, ReplyHandler replyCB)
	{
		GuildRpcApplyGuildHandleAskWraper askPBWraper = new GuildRpcApplyGuildHandleAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.Oper = Oper;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_APPLYGUILDHANDLE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcApplyGuildHandleReplyWraper replyPBWraper = new GuildRpcApplyGuildHandleReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->创建帮会副本 RPC请求
	*/
	public void CreateGuildDungeon(int DungeonNum, ReplyHandler replyCB)
	{
		GuildRpcCreateGuildDungeonAskWraper askPBWraper = new GuildRpcCreateGuildDungeonAskWraper();
		askPBWraper.DungeonNum = DungeonNum;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_CREATEGUILDDUNGEON_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcCreateGuildDungeonReplyWraper replyPBWraper = new GuildRpcCreateGuildDungeonReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->进入帮会副本 RPC请求
	*/
	public void EnterGuildDungeon(int Index, ReplyHandler replyCB)
	{
		GuildRpcEnterGuildDungeonAskWraper askPBWraper = new GuildRpcEnterGuildDungeonAskWraper();
		askPBWraper.Index = Index;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_ENTERGUILDDUNGEON_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcEnterGuildDungeonReplyWraper replyPBWraper = new GuildRpcEnterGuildDungeonReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->创建帮会战 RPC请求
	*/
	public void CreateGuildWar(int Guild, ReplyHandler replyCB)
	{
		GuildRpcCreateGuildWarAskWraper askPBWraper = new GuildRpcCreateGuildWarAskWraper();
		askPBWraper.Guild = Guild;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_CREATEGUILDWAR_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcCreateGuildWarReplyWraper replyPBWraper = new GuildRpcCreateGuildWarReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->进入帮会战 RPC请求
	*/
	public void EnterGuildWar(ReplyHandler replyCB)
	{
		GuildRpcEnterGuildWarAskWraper askPBWraper = new GuildRpcEnterGuildWarAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_ENTERGUILDWAR_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcEnterGuildWarReplyWraper replyPBWraper = new GuildRpcEnterGuildWarReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->开启帮会修炼项目 RPC请求
	*/
	public void OpenScienceAttr(int ScienceId, ReplyHandler replyCB)
	{
		GuildRpcOpenScienceAttrAskWraper askPBWraper = new GuildRpcOpenScienceAttrAskWraper();
		askPBWraper.ScienceId = ScienceId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_OPENSCIENCEATTR_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcOpenScienceAttrReplyWraper replyPBWraper = new GuildRpcOpenScienceAttrReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*帮派-->帮会属性升级 RPC请求
	*/
	public void GuildScienceLvUp(int ScienceId, bool IsKeyUpLv, ReplyHandler replyCB)
	{
		GuildRpcGuildScienceLvUpAskWraper askPBWraper = new GuildRpcGuildScienceLvUpAskWraper();
		askPBWraper.ScienceId = ScienceId;
		askPBWraper.IsKeyUpLv = IsKeyUpLv;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_GUILD_GUILDSCIENCELVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			GuildRpcGuildScienceLvUpReplyWraper replyPBWraper = new GuildRpcGuildScienceLvUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*帮派-->被邀请提示 服务器通知回调
	*/
	public static void BeInvitedNoticeCB( ModMessage notifyMsg )
	{
		GuildRpcBeInvitedNoticeNotifyWraper notifyPBWraper = new GuildRpcBeInvitedNoticeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BeInvitedNoticeCBDelegate != null )
			BeInvitedNoticeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BeInvitedNoticeCBDelegate = null;
	/**
	*帮派-->发送我的帮会数据 服务器通知回调
	*/
	public static void SyncMyTeamDataCB( ModMessage notifyMsg )
	{
		GuildRpcSyncMyTeamDataNotifyWraper notifyPBWraper = new GuildRpcSyncMyTeamDataNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncMyTeamDataCBDelegate != null )
			SyncMyTeamDataCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncMyTeamDataCBDelegate = null;
	/**
	*帮派-->同步帮会基础数据 服务器通知回调
	*/
	public static void SyncNoticeOfGuildBaseDataCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfGuildBaseDataNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfGuildBaseDataNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfGuildBaseDataCBDelegate != null )
			SyncNoticeOfGuildBaseDataCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfGuildBaseDataCBDelegate = null;
	/**
	*帮派-->同步帮会成员数据变化 服务器通知回调
	*/
	public static void SyncNoticeOfGuildMemberChangeCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfGuildMemberChangeCBDelegate != null )
			SyncNoticeOfGuildMemberChangeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfGuildMemberChangeCBDelegate = null;
	/**
	*帮派-->同步帮会增加成员 服务器通知回调
	*/
	public static void SyncNoticeOfAddMemberCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfAddMemberNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfAddMemberNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfAddMemberCBDelegate != null )
			SyncNoticeOfAddMemberCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfAddMemberCBDelegate = null;
	/**
	*帮派-->同步帮会删除成员 服务器通知回调
	*/
	public static void SyncNoticeOfDelMemberCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfDelMemberNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfDelMemberNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfDelMemberCBDelegate != null )
			SyncNoticeOfDelMemberCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfDelMemberCBDelegate = null;
	/**
	*帮派-->同步帮会增加事件 服务器通知回调
	*/
	public static void SyncNoticeOfAddEventCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfAddEventNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfAddEventNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfAddEventCBDelegate != null )
			SyncNoticeOfAddEventCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfAddEventCBDelegate = null;
	/**
	*帮派-->同步帮会增加申请列表 服务器通知回调
	*/
	public static void SyncNoticeOfAddApplyListCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfAddApplyListNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfAddApplyListNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfAddApplyListCBDelegate != null )
			SyncNoticeOfAddApplyListCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfAddApplyListCBDelegate = null;
	/**
	*帮派-->同步帮会删除申请列表 服务器通知回调
	*/
	public static void SyncNoticeOfDelApplyListCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfDelApplyListNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfDelApplyListNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfDelApplyListCBDelegate != null )
			SyncNoticeOfDelApplyListCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfDelApplyListCBDelegate = null;
	/**
	*帮派-->同步帮会公告修改 服务器通知回调
	*/
	public static void SyncNoticeOfChangeAnnouncementCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfChangeAnnouncementCBDelegate != null )
			SyncNoticeOfChangeAnnouncementCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfChangeAnnouncementCBDelegate = null;
	/**
	*帮派-->通知解散 服务器通知回调
	*/
	public static void SyncNoticeOfBreakupCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfBreakupNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfBreakupNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfBreakupCBDelegate != null )
			SyncNoticeOfBreakupCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfBreakupCBDelegate = null;
	/**
	*帮派-->同步帮会大厅升级 服务器通知回调
	*/
	public static void SyncNoticeOfHallLvUpCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfHallLvUpNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfHallLvUpNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfHallLvUpCBDelegate != null )
			SyncNoticeOfHallLvUpCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfHallLvUpCBDelegate = null;
	/**
	*帮派-->同步帮会房屋升级 服务器通知回调
	*/
	public static void SyncNoticeOfHouseLvUpCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfHouseLvUpNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfHouseLvUpNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfHouseLvUpCBDelegate != null )
			SyncNoticeOfHouseLvUpCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfHouseLvUpCBDelegate = null;
	/**
	*帮派-->同步帮会库房升级 服务器通知回调
	*/
	public static void SyncNoticeOfStorerommLvUpCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfStorerommLvUpNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfStorerommLvUpNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfStorerommLvUpCBDelegate != null )
			SyncNoticeOfStorerommLvUpCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfStorerommLvUpCBDelegate = null;
	/**
	*帮派-->同步练武堂升级 服务器通知回调
	*/
	public static void SyncNoticeOfKongfuHallLvUpCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfKongfuHallLvUpCBDelegate != null )
			SyncNoticeOfKongfuHallLvUpCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfKongfuHallLvUpCBDelegate = null;
	/**
	*帮派-->同步帮会副本创建 服务器通知回调
	*/
	public static void RpcSyncNoticeOfCreateGuildDungeonCB( ModMessage notifyMsg )
	{
		GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraper notifyPBWraper = new GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( RpcSyncNoticeOfCreateGuildDungeonCBDelegate != null )
			RpcSyncNoticeOfCreateGuildDungeonCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback RpcSyncNoticeOfCreateGuildDungeonCBDelegate = null;
	/**
	*帮派-->同步帮会战是否开启 服务器通知回调
	*/
	public static void SyncNoticeOfOpenGuildWarCB( ModMessage notifyMsg )
	{
		GuildRpcSyncNoticeOfOpenGuildWarNotifyWraper notifyPBWraper = new GuildRpcSyncNoticeOfOpenGuildWarNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SyncNoticeOfOpenGuildWarCBDelegate != null )
			SyncNoticeOfOpenGuildWarCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SyncNoticeOfOpenGuildWarCBDelegate = null;



}

public class GuildData
{
	public enum SyncIdE
	{

	}
	
	private static GuildData m_Instance = null;
	public static GuildData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GuildData();
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
			Ex.Logger.Log("GuildData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  


}
