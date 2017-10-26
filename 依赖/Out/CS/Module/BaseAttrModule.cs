/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleBaseAttr.cs
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


public class BaseAttrRPC
{
	public const int ModuleId = 13;
	
	public const int RPC_CODE_BASEATTR_SYNCDATA_REQUEST = 1351;
	public const int RPC_CODE_BASEATTR_GETRANKREWARD_REQUEST = 1352;
	public const int RPC_CODE_BASEATTR_UPGRADERANK_REQUEST = 1353;
	public const int RPC_CODE_BASEATTR_CHOOSEROLE_REQUEST = 1354;
	public const int RPC_CODE_BASEATTR_LEVELUP_REQUEST = 1355;
	public const int RPC_CODE_BASEATTR_GETTIMER_REQUEST = 1356;
	public const int RPC_CODE_BASEATTR_REVIVE_REQUEST = 1357;
	public const int RPC_CODE_BASEATTR_QUERYEQUIP_REQUEST = 1358;
	public const int RPC_CODE_BASEATTR_UPDATENEWBIEGUIDE_REQUEST = 1359;
	public const int RPC_CODE_BASEATTR_SYSTIPS_NOTIFY = 1360;
	public const int RPC_CODE_BASEATTR_CHANGPKSTATE_REQUEST = 1361;
	public const int RPC_CODE_BASEATTR_CHANGEPKPROTECT_REQUEST = 1362;

	
	private static BaseAttrRPC m_Instance = null;
	public static BaseAttrRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new BaseAttrRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, BaseAttrData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_BASEATTR_SYSTIPS_NOTIFY, SysTipsCB);


		return true;
	}


	/**
	*战队基础数据-->同步玩家数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		BaseAttrRpcSyncDataAskWraper askPBWraper = new BaseAttrRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcSyncDataReplyWraper replyPBWraper = new BaseAttrRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->领取官阶奖励 RPC请求
	*/
	public void GetRankReward(ReplyHandler replyCB)
	{
		BaseAttrRpcGetRankRewardAskWraper askPBWraper = new BaseAttrRpcGetRankRewardAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_GETRANKREWARD_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcGetRankRewardReplyWraper replyPBWraper = new BaseAttrRpcGetRankRewardReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->提升官阶 RPC请求
	*/
	public void UpGradeRank(ReplyHandler replyCB)
	{
		BaseAttrRpcUpGradeRankAskWraper askPBWraper = new BaseAttrRpcUpGradeRankAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_UPGRADERANK_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcUpGradeRankReplyWraper replyPBWraper = new BaseAttrRpcUpGradeRankReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->选人 RPC请求
	*/
	public void ChooseRole(int Prof, ReplyHandler replyCB)
	{
		BaseAttrRpcChooseRoleAskWraper askPBWraper = new BaseAttrRpcChooseRoleAskWraper();
		askPBWraper.Prof = Prof;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_CHOOSEROLE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcChooseRoleReplyWraper replyPBWraper = new BaseAttrRpcChooseRoleReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->升级 RPC请求
	*/
	public void LevelUp(ReplyHandler replyCB)
	{
		BaseAttrRpcLevelUpAskWraper askPBWraper = new BaseAttrRpcLevelUpAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_LEVELUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcLevelUpReplyWraper replyPBWraper = new BaseAttrRpcLevelUpReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->获取时间 RPC请求
	*/
	public void GetTimer(ReplyHandler replyCB)
	{
		BaseAttrRpcGetTimerAskWraper askPBWraper = new BaseAttrRpcGetTimerAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_GETTIMER_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcGetTimerReplyWraper replyPBWraper = new BaseAttrRpcGetTimerReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->复活 RPC请求
	*/
	public void Revive(ReplyHandler replyCB)
	{
		BaseAttrRpcReviveAskWraper askPBWraper = new BaseAttrRpcReviveAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_REVIVE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcReviveReplyWraper replyPBWraper = new BaseAttrRpcReviveReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->查询装备数据 RPC请求
	*/
	public void QueryEquip(long UserId, int Pos, int TemplateID, long Index, ReplyHandler replyCB)
	{
		BaseAttrRpcQueryEquipAskWraper askPBWraper = new BaseAttrRpcQueryEquipAskWraper();
		askPBWraper.UserId = UserId;
		askPBWraper.Pos = Pos;
		askPBWraper.TemplateID = TemplateID;
		askPBWraper.Index = Index;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_QUERYEQUIP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcQueryEquipReplyWraper replyPBWraper = new BaseAttrRpcQueryEquipReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->更新新手引导 RPC请求
	*/
	public void UpdateNewbieGuide(int GroupId, int Step, ReplyHandler replyCB)
	{
		BaseAttrRpcUpdateNewbieGuideAskWraper askPBWraper = new BaseAttrRpcUpdateNewbieGuideAskWraper();
		askPBWraper.GroupId = GroupId;
		askPBWraper.Step = Step;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_UPDATENEWBIEGUIDE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcUpdateNewbieGuideReplyWraper replyPBWraper = new BaseAttrRpcUpdateNewbieGuideReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->修改PK状态 RPC请求
	*/
	public void ChangPKState(int ChangState, ReplyHandler replyCB)
	{
		BaseAttrRpcChangPKStateAskWraper askPBWraper = new BaseAttrRpcChangPKStateAskWraper();
		askPBWraper.ChangState = ChangState;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_CHANGPKSTATE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcChangPKStateReplyWraper replyPBWraper = new BaseAttrRpcChangPKStateReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*战队基础数据-->修改PK保护 RPC请求
	*/
	public void ChangePKProtect(List<KeyValue2IntBoolWraper> ProtectList, ReplyHandler replyCB)
	{
		BaseAttrRpcChangePKProtectAskWraper askPBWraper = new BaseAttrRpcChangePKProtectAskWraper();
		askPBWraper.SetProtectList(ProtectList);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BASEATTR_CHANGEPKPROTECT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BaseAttrRpcChangePKProtectReplyWraper replyPBWraper = new BaseAttrRpcChangePKProtectReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*战队基础数据-->系统提示 服务器通知回调
	*/
	public static void SysTipsCB( ModMessage notifyMsg )
	{
		BaseAttrRpcSysTipsNotifyWraper notifyPBWraper = new BaseAttrRpcSysTipsNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( SysTipsCBDelegate != null )
			SysTipsCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback SysTipsCBDelegate = null;



}

public class BaseAttrData
{
	public enum SyncIdE
	{
 		HEADID                                     = 1301,  //头像id
 		EXP                                        = 1302,  //经验
 		CREATETIME                                 = 1303,  //创建时间
 		LASTLOGINTIME                              = 1304,  //最后登录时间
 		LAST2LOGINDATE                             = 1305,  //倒数第二登录日期
 		LASTLOGOUTTIME                             = 1306,  //最后登出时间
 		MONEY                                      = 1307,  //游戏币
 		DIAMOND                                    = 1308,  //钻石
 		STRENGTH                                   = 1310,  //体力
 		FEATS                                      = 1311,  //功勋
 		GOTRANKREWARDTIME                          = 1312,  //领取官阶奖励时间
 		MAXMILITARY                                = 1314,  //历史最大战力
 		MASTERATTRS                                = 1315,  //主公基础属性
 		CURMILITARY                                = 1318,  //当前玩家战力
 		USERNAME                                   = 1319,  //玩家名字
 		USERID                                     = 1320,  //用户ID
 		PLATNAME                                   = 1321,  //游戏中心账号名
 		ACCOUNTID                                  = 1322,  //游戏中心账号ID
 		LEVEL                                      = 1323,  //玩家等级
 		RANK                                       = 1324,  //官阶
 		FIGHTPOWER                                 = 1325,  //战力
 		SEC                                        = 1326,  //用户累加的数据
 		MILITARY                                   = 1327,  //当前战力
 		TEAMID                                     = 1328,  //队伍Id
 		PROF                                       = 1329,  //职业
 		DUNGEONREMAINCOUNT                         = 1330,  //副本剩余次数
 		MAPID                                      = 1331,  //地图Id
 		POSX                                       = 1332,  //X坐标
 		POSY                                       = 1333,  //Y坐标
 		POSZ                                       = 1334,  //Z坐标
 		RY                                         = 1335,  //位置方向
 		SKILLCDARR                                 = 1336,  //技能CD列表
 		BUFFCDARR                                  = 1337,  //BuffCD列表
 		CURRENTSCENE                               = 1338,  //当前所在场景
 		GUILDID                                    = 1339,  //帮会Id
 		EXITGUILDTIME                              = 1340,  //退出帮会时间
 		APPLYGUILDID                               = 1341,  //申请过的帮会
 		CURGUILDCONTRIBUTION                       = 1342,  //当前帮贡
 		MAXGUILDCONTRIBUTION                       = 1343,  //最大帮贡
 		BINDMONEY                                  = 1344,  //绑银
 		GEM                                        = 1345,  //宝石
 		SERVERTIME                                 = 1347,  //服务器时间
 		NEWBIEGUIDE                                = 1348,  //新手引导
 		THIEFREWARDNUM                             = 1349,  //江洋大盗奖励次数
 		SUBDUEMONSTERREWARDNUM                     = 1350,  //降妖奖励次数
 		WORLDBOSSREMAINTIMES                       = 1351,  //世界Boss剩余次数
 		WORLDBOSSHURT                              = 1352,  //世界Boss伤害
 		FUNCTIONOPENLIST                           = 1354,  //功能开启列表
 		TOTALENERGYVALUE                           = 1355,  //总活力值
 		ENERGYARRAY                                = 1357,  //活力值信息容器
 		PKSTATE                                    = 1358,  //PK状态
 		PKPROTECT                                  = 1359,  //PK保护列表
 		GUILDSCIENARRAY                            = 1360,  //帮会修炼
 		SCIENCETOTALMONEY                          = 1361,  //修炼升级消耗总金币

	}
	
	private static BaseAttrData m_Instance = null;
	public static BaseAttrData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new BaseAttrData();
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
			case SyncIdE.HEADID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.HeadID = iValue;
				break;
			case SyncIdE.EXP:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Exp = iValue;
				break;
			case SyncIdE.CREATETIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.CreateTime = iValue;
				break;
			case SyncIdE.LASTLOGINTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.LastLoginTime = iValue;
				break;
			case SyncIdE.LAST2LOGINDATE:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Last2LoginDate = iValue;
				break;
			case SyncIdE.LASTLOGOUTTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.LastLogoutTime = iValue;
				break;
			case SyncIdE.MONEY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Money = iValue;
				break;
			case SyncIdE.DIAMOND:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Diamond = iValue;
				break;
			case SyncIdE.STRENGTH:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Strength = iValue;
				break;
			case SyncIdE.FEATS:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Feats = iValue;
				break;
			case SyncIdE.GOTRANKREWARDTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.GotRankRewardTime = iValue;
				break;
			case SyncIdE.MAXMILITARY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.MaxMilitary = iValue;
				break;
			case SyncIdE.MASTERATTRS:
				if(Index < 0){ m_Instance.ClearMasterAttrs(); break; }
				if (Index >= m_Instance.SizeMasterAttrs())
				{
					int Count = Index - m_Instance.SizeMasterAttrs() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddMasterAttrs(-1);
				}
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SetMasterAttrs(Index, iValue);
				break;
			case SyncIdE.CURMILITARY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.CurMilitary = iValue;
				break;
			case SyncIdE.USERNAME:
				m_Instance.UserName = System.Text.Encoding.UTF8.GetString(updateBuffer);
				break;
			case SyncIdE.USERID:
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.UserId = lValue;
				break;
			case SyncIdE.PLATNAME:
				m_Instance.PlatName = System.Text.Encoding.UTF8.GetString(updateBuffer);
				break;
			case SyncIdE.ACCOUNTID:
				GameAssist.ReadInt64Variant(updateBuffer, 0, out lValue);
				m_Instance.AccountId = lValue;
				break;
			case SyncIdE.LEVEL:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Level = iValue;
				break;
			case SyncIdE.RANK:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Rank = iValue;
				break;
			case SyncIdE.FIGHTPOWER:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.FightPower = iValue;
				break;
			case SyncIdE.SEC:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Sec = iValue;
				break;
			case SyncIdE.MILITARY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Military = iValue;
				break;
			case SyncIdE.TEAMID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.TeamId = iValue;
				break;
			case SyncIdE.PROF:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Prof = iValue;
				break;
			case SyncIdE.DUNGEONREMAINCOUNT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.DungeonRemainCount = iValue;
				break;
			case SyncIdE.MAPID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.MapId = iValue;
				break;
			case SyncIdE.POSX:
				m_Instance.PosX = BitConverter.ToSingle(updateBuffer,0);
				break;
			case SyncIdE.POSY:
				m_Instance.PosY = BitConverter.ToSingle(updateBuffer,0);
				break;
			case SyncIdE.POSZ:
				m_Instance.PosZ = BitConverter.ToSingle(updateBuffer,0);
				break;
			case SyncIdE.RY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Ry = iValue;
				break;
			case SyncIdE.SKILLCDARR:
				if(Index < 0){ m_Instance.ClearSkillCdArr(); break; }
				if (Index >= m_Instance.SizeSkillCdArr())
				{
					int Count = Index - m_Instance.SizeSkillCdArr() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddSkillCdArr(new BaseAttrSkillCdInfoWraperV1());
				}
				m_Instance.GetSkillCdArr(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.BUFFCDARR:
				if(Index < 0){ m_Instance.ClearBuffCdArr(); break; }
				if (Index >= m_Instance.SizeBuffCdArr())
				{
					int Count = Index - m_Instance.SizeBuffCdArr() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddBuffCdArr(new BaseAttrBuffCdInfoWraperV1());
				}
				m_Instance.GetBuffCdArr(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.CURRENTSCENE:
				m_Instance.CurrentScene.FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.GUILDID:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.GuildId = iValue;
				break;
			case SyncIdE.EXITGUILDTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ExitGuildTime = iValue;
				break;
			case SyncIdE.APPLYGUILDID:
				if(Index < 0){ m_Instance.ClearApplyGuildId(); break; }
				if (Index >= m_Instance.SizeApplyGuildId())
				{
					int Count = Index - m_Instance.SizeApplyGuildId() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddApplyGuildId(-1);
				}
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SetApplyGuildId(Index, iValue);
				break;
			case SyncIdE.CURGUILDCONTRIBUTION:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.CurGuildContribution = iValue;
				break;
			case SyncIdE.MAXGUILDCONTRIBUTION:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.MaxGuildContribution = iValue;
				break;
			case SyncIdE.BINDMONEY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.BindMoney = iValue;
				break;
			case SyncIdE.GEM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.Gem = iValue;
				break;
			case SyncIdE.SERVERTIME:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ServerTime = iValue;
				break;
			case SyncIdE.NEWBIEGUIDE:
				if(Index < 0){ m_Instance.ClearNewbieGuide(); break; }
				if (Index >= m_Instance.SizeNewbieGuide())
				{
					int Count = Index - m_Instance.SizeNewbieGuide() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddNewbieGuide(new KeyValue2IntIntWraper());
				}
				m_Instance.GetNewbieGuide(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.THIEFREWARDNUM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ThiefRewardNum = iValue;
				break;
			case SyncIdE.SUBDUEMONSTERREWARDNUM:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SubdueMonsterRewardNum = iValue;
				break;
			case SyncIdE.WORLDBOSSREMAINTIMES:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.WorldBossRemainTimes = iValue;
				break;
			case SyncIdE.WORLDBOSSHURT:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.WorldBossHurt = iValue;
				break;
			case SyncIdE.FUNCTIONOPENLIST:
				if(Index < 0){ m_Instance.ClearFunctionOpenList(); break; }
				if (Index >= m_Instance.SizeFunctionOpenList())
				{
					int Count = Index - m_Instance.SizeFunctionOpenList() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddFunctionOpenList(new BaseAttrIconOpenInfoWraperV1());
				}
				m_Instance.GetFunctionOpenList(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.TOTALENERGYVALUE:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.TotalEnergyValue = iValue;
				break;
			case SyncIdE.ENERGYARRAY:
				if(Index < 0){ m_Instance.ClearEnergyArray(); break; }
				if (Index >= m_Instance.SizeEnergyArray())
				{
					int Count = Index - m_Instance.SizeEnergyArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddEnergyArray(new BaseAttrEnergyInfoWraperV1());
				}
				m_Instance.GetEnergyArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.PKSTATE:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.PKState = iValue;
				break;
			case SyncIdE.PKPROTECT:
				if(Index < 0){ m_Instance.ClearPKProtect(); break; }
				if (Index >= m_Instance.SizePKProtect())
				{
					int Count = Index - m_Instance.SizePKProtect() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddPKProtect(new KeyValue2IntBoolWraper());
				}
				m_Instance.GetPKProtect(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.GUILDSCIENARRAY:
				if(Index < 0){ m_Instance.ClearGuildScienArray(); break; }
				if (Index >= m_Instance.SizeGuildScienArray())
				{
					int Count = Index - m_Instance.SizeGuildScienArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddGuildScienArray(new BaseAttrScienceInfoWraperV1());
				}
				m_Instance.GetGuildScienArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.SCIENCETOTALMONEY:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.ScienceTotalMoney = iValue;
				break;

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
			Ex.Logger.Log("BaseAttrData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public BaseAttrData()
	{
		 m_HeadID = -1;
		 m_Exp = -1;
		 m_CreateTime = -1;
		 m_LastLoginTime = -1;
		 m_Last2LoginDate = -1;
		 m_LastLogoutTime = -1;
		 m_Money = 0;
		 m_Diamond = 0;
		 m_Strength = -1;
		 m_Feats = -1;
		 m_GotRankRewardTime = -1;
		 m_MaxMilitary = -1;
		m_MasterAttrs = new List<int>();
		 m_CurMilitary = -1;
		 m_UserName = "";
		 m_UserId = -1;
		 m_PlatName = "";
		 m_AccountId = -1;
		 m_Level = -1;
		 m_Rank = -1;
		 m_FightPower = -1;
		 m_Sec = -1;
		 m_Military = -1;
		 m_TeamId = -1;
		 m_Prof = -1;
		 m_DungeonRemainCount = -1;
		 m_MapId = -1;
		 m_PosX = (float)-1;
		 m_PosY = (float)-1;
		 m_PosZ = (float)-1;
		 m_Ry = -1;
		m_SkillCdArr = new List<BaseAttrSkillCdInfoWraperV1>();
		m_BuffCdArr = new List<BaseAttrBuffCdInfoWraperV1>();
		 m_CurrentScene = new BaseAttrSceneInfoWraperV1();
		 m_GuildId = -1;
		 m_ExitGuildTime = -1;
		m_ApplyGuildId = new List<int>();
		 m_CurGuildContribution = 0;
		 m_MaxGuildContribution = 0;
		 m_BindMoney = 0;
		 m_Gem = 0;
		 m_ServerTime = -1;
		m_NewbieGuide = new List<KeyValue2IntIntWraper>();
		 m_ThiefRewardNum = 0;
		 m_SubdueMonsterRewardNum = 0;
		 m_WorldBossRemainTimes = 0;
		 m_WorldBossHurt = 0;
		m_FunctionOpenList = new List<BaseAttrIconOpenInfoWraperV1>();
		 m_TotalEnergyValue = 0;
		m_EnergyArray = new List<BaseAttrEnergyInfoWraperV1>();
		 m_PKState = -1;
		m_PKProtect = new List<KeyValue2IntBoolWraper>();
		m_GuildScienArray = new List<BaseAttrScienceInfoWraperV1>();
		 m_ScienceTotalMoney = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_HeadID = -1;
		 m_Exp = -1;
		 m_CreateTime = -1;
		 m_LastLoginTime = -1;
		 m_Last2LoginDate = -1;
		 m_LastLogoutTime = -1;
		 m_Money = 0;
		 m_Diamond = 0;
		 m_Strength = -1;
		 m_Feats = -1;
		 m_GotRankRewardTime = -1;
		 m_MaxMilitary = -1;
		m_MasterAttrs = new List<int>();
		 m_CurMilitary = -1;
		 m_UserName = "";
		 m_UserId = -1;
		 m_PlatName = "";
		 m_AccountId = -1;
		 m_Level = -1;
		 m_Rank = -1;
		 m_FightPower = -1;
		 m_Sec = -1;
		 m_Military = -1;
		 m_TeamId = -1;
		 m_Prof = -1;
		 m_DungeonRemainCount = -1;
		 m_MapId = -1;
		 m_PosX = (float)-1;
		 m_PosY = (float)-1;
		 m_PosZ = (float)-1;
		 m_Ry = -1;
		m_SkillCdArr = new List<BaseAttrSkillCdInfoWraperV1>();
		m_BuffCdArr = new List<BaseAttrBuffCdInfoWraperV1>();
		 m_CurrentScene = new BaseAttrSceneInfoWraperV1();
		 m_GuildId = -1;
		 m_ExitGuildTime = -1;
		m_ApplyGuildId = new List<int>();
		 m_CurGuildContribution = 0;
		 m_MaxGuildContribution = 0;
		 m_BindMoney = 0;
		 m_Gem = 0;
		 m_ServerTime = -1;
		m_NewbieGuide = new List<KeyValue2IntIntWraper>();
		 m_ThiefRewardNum = 0;
		 m_SubdueMonsterRewardNum = 0;
		 m_WorldBossRemainTimes = 0;
		 m_WorldBossHurt = 0;
		m_FunctionOpenList = new List<BaseAttrIconOpenInfoWraperV1>();
		 m_TotalEnergyValue = 0;
		m_EnergyArray = new List<BaseAttrEnergyInfoWraperV1>();
		 m_PKState = -1;
		m_PKProtect = new List<KeyValue2IntBoolWraper>();
		m_GuildScienArray = new List<BaseAttrScienceInfoWraperV1>();
		 m_ScienceTotalMoney = 0;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrUserDataV1 ToPB()
	{
		BaseAttrUserDataV1 v = new BaseAttrUserDataV1();
		v.HeadID = m_HeadID;
		v.Exp = m_Exp;
		v.CreateTime = m_CreateTime;
		v.LastLoginTime = m_LastLoginTime;
		v.Last2LoginDate = m_Last2LoginDate;
		v.LastLogoutTime = m_LastLogoutTime;
		v.Money = m_Money;
		v.Diamond = m_Diamond;
		v.Strength = m_Strength;
		v.Feats = m_Feats;
		v.GotRankRewardTime = m_GotRankRewardTime;
		v.MaxMilitary = m_MaxMilitary;
		for (int i=0; i<(int)m_MasterAttrs.Count; i++)
			v.MasterAttrs.Add( m_MasterAttrs[i]);
		v.CurMilitary = m_CurMilitary;
		v.UserName = m_UserName;
		v.UserId = m_UserId;
		v.PlatName = m_PlatName;
		v.AccountId = m_AccountId;
		v.Level = m_Level;
		v.Rank = m_Rank;
		v.FightPower = m_FightPower;
		v.Sec = m_Sec;
		v.Military = m_Military;
		v.TeamId = m_TeamId;
		v.Prof = m_Prof;
		v.DungeonRemainCount = m_DungeonRemainCount;
		v.MapId = m_MapId;
		v.PosX = m_PosX;
		v.PosY = m_PosY;
		v.PosZ = m_PosZ;
		v.Ry = m_Ry;
		for (int i=0; i<(int)m_SkillCdArr.Count; i++)
			v.SkillCdArr.Add( m_SkillCdArr[i].ToPB());
		for (int i=0; i<(int)m_BuffCdArr.Count; i++)
			v.BuffCdArr.Add( m_BuffCdArr[i].ToPB());
		v.CurrentScene = m_CurrentScene.ToPB();
		v.GuildId = m_GuildId;
		v.ExitGuildTime = m_ExitGuildTime;
		for (int i=0; i<(int)m_ApplyGuildId.Count; i++)
			v.ApplyGuildId.Add( m_ApplyGuildId[i]);
		v.CurGuildContribution = m_CurGuildContribution;
		v.MaxGuildContribution = m_MaxGuildContribution;
		v.BindMoney = m_BindMoney;
		v.Gem = m_Gem;
		v.ServerTime = m_ServerTime;
		for (int i=0; i<(int)m_NewbieGuide.Count; i++)
			v.NewbieGuide.Add( m_NewbieGuide[i].ToPB());
		v.ThiefRewardNum = m_ThiefRewardNum;
		v.SubdueMonsterRewardNum = m_SubdueMonsterRewardNum;
		v.WorldBossRemainTimes = m_WorldBossRemainTimes;
		v.WorldBossHurt = m_WorldBossHurt;
		for (int i=0; i<(int)m_FunctionOpenList.Count; i++)
			v.FunctionOpenList.Add( m_FunctionOpenList[i].ToPB());
		v.TotalEnergyValue = m_TotalEnergyValue;
		for (int i=0; i<(int)m_EnergyArray.Count; i++)
			v.EnergyArray.Add( m_EnergyArray[i].ToPB());
		v.PKState = m_PKState;
		for (int i=0; i<(int)m_PKProtect.Count; i++)
			v.PKProtect.Add( m_PKProtect[i].ToPB());
		for (int i=0; i<(int)m_GuildScienArray.Count; i++)
			v.GuildScienArray.Add( m_GuildScienArray[i].ToPB());
		v.ScienceTotalMoney = m_ScienceTotalMoney;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrUserDataV1 v)
	{
        if (v == null)
            return;
		m_HeadID = v.HeadID;
		m_Exp = v.Exp;
		m_CreateTime = v.CreateTime;
		m_LastLoginTime = v.LastLoginTime;
		m_Last2LoginDate = v.Last2LoginDate;
		m_LastLogoutTime = v.LastLogoutTime;
		m_Money = v.Money;
		m_Diamond = v.Diamond;
		m_Strength = v.Strength;
		m_Feats = v.Feats;
		m_GotRankRewardTime = v.GotRankRewardTime;
		m_MaxMilitary = v.MaxMilitary;
		m_MasterAttrs.Clear();
		for( int i=0; i<v.MasterAttrs.Count; i++)
			m_MasterAttrs.Add(v.MasterAttrs[i]);
		m_CurMilitary = v.CurMilitary;
		m_UserName = v.UserName;
		m_UserId = v.UserId;
		m_PlatName = v.PlatName;
		m_AccountId = v.AccountId;
		m_Level = v.Level;
		m_Rank = v.Rank;
		m_FightPower = v.FightPower;
		m_Sec = v.Sec;
		m_Military = v.Military;
		m_TeamId = v.TeamId;
		m_Prof = v.Prof;
		m_DungeonRemainCount = v.DungeonRemainCount;
		m_MapId = v.MapId;
		m_PosX = v.PosX;
		m_PosY = v.PosY;
		m_PosZ = v.PosZ;
		m_Ry = v.Ry;
		m_SkillCdArr.Clear();
		for( int i=0; i<v.SkillCdArr.Count; i++)
			m_SkillCdArr.Add( new BaseAttrSkillCdInfoWraperV1());
		for( int i=0; i<v.SkillCdArr.Count; i++)
			m_SkillCdArr[i].FromPB(v.SkillCdArr[i]);
		m_BuffCdArr.Clear();
		for( int i=0; i<v.BuffCdArr.Count; i++)
			m_BuffCdArr.Add( new BaseAttrBuffCdInfoWraperV1());
		for( int i=0; i<v.BuffCdArr.Count; i++)
			m_BuffCdArr[i].FromPB(v.BuffCdArr[i]);
		m_CurrentScene.FromPB(v.CurrentScene);
		m_GuildId = v.GuildId;
		m_ExitGuildTime = v.ExitGuildTime;
		m_ApplyGuildId.Clear();
		for( int i=0; i<v.ApplyGuildId.Count; i++)
			m_ApplyGuildId.Add(v.ApplyGuildId[i]);
		m_CurGuildContribution = v.CurGuildContribution;
		m_MaxGuildContribution = v.MaxGuildContribution;
		m_BindMoney = v.BindMoney;
		m_Gem = v.Gem;
		m_ServerTime = v.ServerTime;
		m_NewbieGuide.Clear();
		for( int i=0; i<v.NewbieGuide.Count; i++)
			m_NewbieGuide.Add( new KeyValue2IntIntWraper());
		for( int i=0; i<v.NewbieGuide.Count; i++)
			m_NewbieGuide[i].FromPB(v.NewbieGuide[i]);
		m_ThiefRewardNum = v.ThiefRewardNum;
		m_SubdueMonsterRewardNum = v.SubdueMonsterRewardNum;
		m_WorldBossRemainTimes = v.WorldBossRemainTimes;
		m_WorldBossHurt = v.WorldBossHurt;
		m_FunctionOpenList.Clear();
		for( int i=0; i<v.FunctionOpenList.Count; i++)
			m_FunctionOpenList.Add( new BaseAttrIconOpenInfoWraperV1());
		for( int i=0; i<v.FunctionOpenList.Count; i++)
			m_FunctionOpenList[i].FromPB(v.FunctionOpenList[i]);
		m_TotalEnergyValue = v.TotalEnergyValue;
		m_EnergyArray.Clear();
		for( int i=0; i<v.EnergyArray.Count; i++)
			m_EnergyArray.Add( new BaseAttrEnergyInfoWraperV1());
		for( int i=0; i<v.EnergyArray.Count; i++)
			m_EnergyArray[i].FromPB(v.EnergyArray[i]);
		m_PKState = v.PKState;
		m_PKProtect.Clear();
		for( int i=0; i<v.PKProtect.Count; i++)
			m_PKProtect.Add( new KeyValue2IntBoolWraper());
		for( int i=0; i<v.PKProtect.Count; i++)
			m_PKProtect[i].FromPB(v.PKProtect[i]);
		m_GuildScienArray.Clear();
		for( int i=0; i<v.GuildScienArray.Count; i++)
			m_GuildScienArray.Add( new BaseAttrScienceInfoWraperV1());
		for( int i=0; i<v.GuildScienArray.Count; i++)
			m_GuildScienArray[i].FromPB(v.GuildScienArray[i]);
		m_ScienceTotalMoney = v.ScienceTotalMoney;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrUserDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrUserDataV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrUserDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//头像id
	public int m_HeadID;
	public int HeadID
	{
		get { return m_HeadID;}
		set { m_HeadID = value; }
	}
	//经验
	public int m_Exp;
	public int Exp
	{
		get { return m_Exp;}
		set { m_Exp = value; }
	}
	//创建时间
	public int m_CreateTime;
	public int CreateTime
	{
		get { return m_CreateTime;}
		set { m_CreateTime = value; }
	}
	//最后登录时间
	public int m_LastLoginTime;
	public int LastLoginTime
	{
		get { return m_LastLoginTime;}
		set { m_LastLoginTime = value; }
	}
	//倒数第二登录日期
	public int m_Last2LoginDate;
	public int Last2LoginDate
	{
		get { return m_Last2LoginDate;}
		set { m_Last2LoginDate = value; }
	}
	//最后登出时间
	public int m_LastLogoutTime;
	public int LastLogoutTime
	{
		get { return m_LastLogoutTime;}
		set { m_LastLogoutTime = value; }
	}
	//游戏币
	public int m_Money;
	public int Money
	{
		get { return m_Money;}
		set { m_Money = value; }
	}
	//钻石
	public int m_Diamond;
	public int Diamond
	{
		get { return m_Diamond;}
		set { m_Diamond = value; }
	}
	//体力
	public int m_Strength;
	public int Strength
	{
		get { return m_Strength;}
		set { m_Strength = value; }
	}
	//功勋
	public int m_Feats;
	public int Feats
	{
		get { return m_Feats;}
		set { m_Feats = value; }
	}
	//领取官阶奖励时间
	public int m_GotRankRewardTime;
	public int GotRankRewardTime
	{
		get { return m_GotRankRewardTime;}
		set { m_GotRankRewardTime = value; }
	}
	//历史最大战力
	public int m_MaxMilitary;
	public int MaxMilitary
	{
		get { return m_MaxMilitary;}
		set { m_MaxMilitary = value; }
	}
	//主公基础属性
	public List<int> m_MasterAttrs;
	public int SizeMasterAttrs()
	{
		return m_MasterAttrs.Count;
	}
	public List<int> GetMasterAttrs()
	{
		return m_MasterAttrs;
	}
	public int GetMasterAttrs(int Index)
	{
		if(Index<0 || Index>=(int)m_MasterAttrs.Count)
			return -1;
		return m_MasterAttrs[Index];
	}
	public void SetMasterAttrs( List<int> v )
	{
		m_MasterAttrs=v;
	}
	public void SetMasterAttrs( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_MasterAttrs.Count)
			return;
		m_MasterAttrs[Index] = v;
	}
	public void AddMasterAttrs( int v=-1 )
	{
		m_MasterAttrs.Add(v);
	}
	public void ClearMasterAttrs( )
	{
		m_MasterAttrs.Clear();
	}
	//当前玩家战力
	public int m_CurMilitary;
	public int CurMilitary
	{
		get { return m_CurMilitary;}
		set { m_CurMilitary = value; }
	}
	//玩家名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//游戏中心账号名
	public string m_PlatName;
	public string PlatName
	{
		get { return m_PlatName;}
		set { m_PlatName = value; }
	}
	//游戏中心账号ID
	public long m_AccountId;
	public long AccountId
	{
		get { return m_AccountId;}
		set { m_AccountId = value; }
	}
	//玩家等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//官阶
	public int m_Rank;
	public int Rank
	{
		get { return m_Rank;}
		set { m_Rank = value; }
	}
	//战力
	public int m_FightPower;
	public int FightPower
	{
		get { return m_FightPower;}
		set { m_FightPower = value; }
	}
	//用户累加的数据
	public int m_Sec;
	public int Sec
	{
		get { return m_Sec;}
		set { m_Sec = value; }
	}
	//当前战力
	public int m_Military;
	public int Military
	{
		get { return m_Military;}
		set { m_Military = value; }
	}
	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}
	//副本剩余次数
	public int m_DungeonRemainCount;
	public int DungeonRemainCount
	{
		get { return m_DungeonRemainCount;}
		set { m_DungeonRemainCount = value; }
	}
	//地图Id
	public int m_MapId;
	public int MapId
	{
		get { return m_MapId;}
		set { m_MapId = value; }
	}
	//X坐标
	public float m_PosX;
	public float PosX
	{
		get { return m_PosX;}
		set { m_PosX = value; }
	}
	//Y坐标
	public float m_PosY;
	public float PosY
	{
		get { return m_PosY;}
		set { m_PosY = value; }
	}
	//Z坐标
	public float m_PosZ;
	public float PosZ
	{
		get { return m_PosZ;}
		set { m_PosZ = value; }
	}
	//位置方向
	public int m_Ry;
	public int Ry
	{
		get { return m_Ry;}
		set { m_Ry = value; }
	}
	//技能CD列表
	public List<BaseAttrSkillCdInfoWraperV1> m_SkillCdArr;
	public int SizeSkillCdArr()
	{
		return m_SkillCdArr.Count;
	}
	public List<BaseAttrSkillCdInfoWraperV1> GetSkillCdArr()
	{
		return m_SkillCdArr;
	}
	public BaseAttrSkillCdInfoWraperV1 GetSkillCdArr(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillCdArr.Count)
			return new BaseAttrSkillCdInfoWraperV1();
		return m_SkillCdArr[Index];
	}
	public void SetSkillCdArr( List<BaseAttrSkillCdInfoWraperV1> v )
	{
		m_SkillCdArr=v;
	}
	public void SetSkillCdArr( int Index, BaseAttrSkillCdInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_SkillCdArr.Count)
			return;
		m_SkillCdArr[Index] = v;
	}
	public void AddSkillCdArr( BaseAttrSkillCdInfoWraperV1 v )
	{
		m_SkillCdArr.Add(v);
	}
	public void ClearSkillCdArr( )
	{
		m_SkillCdArr.Clear();
	}
	//BuffCD列表
	public List<BaseAttrBuffCdInfoWraperV1> m_BuffCdArr;
	public int SizeBuffCdArr()
	{
		return m_BuffCdArr.Count;
	}
	public List<BaseAttrBuffCdInfoWraperV1> GetBuffCdArr()
	{
		return m_BuffCdArr;
	}
	public BaseAttrBuffCdInfoWraperV1 GetBuffCdArr(int Index)
	{
		if(Index<0 || Index>=(int)m_BuffCdArr.Count)
			return new BaseAttrBuffCdInfoWraperV1();
		return m_BuffCdArr[Index];
	}
	public void SetBuffCdArr( List<BaseAttrBuffCdInfoWraperV1> v )
	{
		m_BuffCdArr=v;
	}
	public void SetBuffCdArr( int Index, BaseAttrBuffCdInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_BuffCdArr.Count)
			return;
		m_BuffCdArr[Index] = v;
	}
	public void AddBuffCdArr( BaseAttrBuffCdInfoWraperV1 v )
	{
		m_BuffCdArr.Add(v);
	}
	public void ClearBuffCdArr( )
	{
		m_BuffCdArr.Clear();
	}
	//当前所在场景
	public BaseAttrSceneInfoWraperV1 m_CurrentScene;
	public BaseAttrSceneInfoWraperV1 CurrentScene
	{
		get { return m_CurrentScene;}
		set { m_CurrentScene = value; }
	}
	//帮会Id
	public int m_GuildId;
	public int GuildId
	{
		get { return m_GuildId;}
		set { m_GuildId = value; }
	}
	//退出帮会时间
	public int m_ExitGuildTime;
	public int ExitGuildTime
	{
		get { return m_ExitGuildTime;}
		set { m_ExitGuildTime = value; }
	}
	//申请过的帮会
	public List<int> m_ApplyGuildId;
	public int SizeApplyGuildId()
	{
		return m_ApplyGuildId.Count;
	}
	public List<int> GetApplyGuildId()
	{
		return m_ApplyGuildId;
	}
	public int GetApplyGuildId(int Index)
	{
		if(Index<0 || Index>=(int)m_ApplyGuildId.Count)
			return -1;
		return m_ApplyGuildId[Index];
	}
	public void SetApplyGuildId( List<int> v )
	{
		m_ApplyGuildId=v;
	}
	public void SetApplyGuildId( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_ApplyGuildId.Count)
			return;
		m_ApplyGuildId[Index] = v;
	}
	public void AddApplyGuildId( int v=-1 )
	{
		m_ApplyGuildId.Add(v);
	}
	public void ClearApplyGuildId( )
	{
		m_ApplyGuildId.Clear();
	}
	//当前帮贡
	public int m_CurGuildContribution;
	public int CurGuildContribution
	{
		get { return m_CurGuildContribution;}
		set { m_CurGuildContribution = value; }
	}
	//最大帮贡
	public int m_MaxGuildContribution;
	public int MaxGuildContribution
	{
		get { return m_MaxGuildContribution;}
		set { m_MaxGuildContribution = value; }
	}
	//绑银
	public int m_BindMoney;
	public int BindMoney
	{
		get { return m_BindMoney;}
		set { m_BindMoney = value; }
	}
	//宝石
	public int m_Gem;
	public int Gem
	{
		get { return m_Gem;}
		set { m_Gem = value; }
	}
	//服务器时间
	public int m_ServerTime;
	public int ServerTime
	{
		get { return m_ServerTime;}
		set { m_ServerTime = value; }
	}
	//新手引导
	public List<KeyValue2IntIntWraper> m_NewbieGuide;
	public int SizeNewbieGuide()
	{
		return m_NewbieGuide.Count;
	}
	public List<KeyValue2IntIntWraper> GetNewbieGuide()
	{
		return m_NewbieGuide;
	}
	public KeyValue2IntIntWraper GetNewbieGuide(int Index)
	{
		if(Index<0 || Index>=(int)m_NewbieGuide.Count)
			return new KeyValue2IntIntWraper();
		return m_NewbieGuide[Index];
	}
	public void SetNewbieGuide( List<KeyValue2IntIntWraper> v )
	{
		m_NewbieGuide=v;
	}
	public void SetNewbieGuide( int Index, KeyValue2IntIntWraper v )
	{
		if(Index<0 || Index>=(int)m_NewbieGuide.Count)
			return;
		m_NewbieGuide[Index] = v;
	}
	public void AddNewbieGuide( KeyValue2IntIntWraper v )
	{
		m_NewbieGuide.Add(v);
	}
	public void ClearNewbieGuide( )
	{
		m_NewbieGuide.Clear();
	}
	//江洋大盗奖励次数
	public int m_ThiefRewardNum;
	public int ThiefRewardNum
	{
		get { return m_ThiefRewardNum;}
		set { m_ThiefRewardNum = value; }
	}
	//降妖奖励次数
	public int m_SubdueMonsterRewardNum;
	public int SubdueMonsterRewardNum
	{
		get { return m_SubdueMonsterRewardNum;}
		set { m_SubdueMonsterRewardNum = value; }
	}
	//世界Boss剩余次数
	public int m_WorldBossRemainTimes;
	public int WorldBossRemainTimes
	{
		get { return m_WorldBossRemainTimes;}
		set { m_WorldBossRemainTimes = value; }
	}
	//世界Boss伤害
	public int m_WorldBossHurt;
	public int WorldBossHurt
	{
		get { return m_WorldBossHurt;}
		set { m_WorldBossHurt = value; }
	}
	//功能开启列表
	public List<BaseAttrIconOpenInfoWraperV1> m_FunctionOpenList;
	public int SizeFunctionOpenList()
	{
		return m_FunctionOpenList.Count;
	}
	public List<BaseAttrIconOpenInfoWraperV1> GetFunctionOpenList()
	{
		return m_FunctionOpenList;
	}
	public BaseAttrIconOpenInfoWraperV1 GetFunctionOpenList(int Index)
	{
		if(Index<0 || Index>=(int)m_FunctionOpenList.Count)
			return new BaseAttrIconOpenInfoWraperV1();
		return m_FunctionOpenList[Index];
	}
	public void SetFunctionOpenList( List<BaseAttrIconOpenInfoWraperV1> v )
	{
		m_FunctionOpenList=v;
	}
	public void SetFunctionOpenList( int Index, BaseAttrIconOpenInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_FunctionOpenList.Count)
			return;
		m_FunctionOpenList[Index] = v;
	}
	public void AddFunctionOpenList( BaseAttrIconOpenInfoWraperV1 v )
	{
		m_FunctionOpenList.Add(v);
	}
	public void ClearFunctionOpenList( )
	{
		m_FunctionOpenList.Clear();
	}
	//总活力值
	public int m_TotalEnergyValue;
	public int TotalEnergyValue
	{
		get { return m_TotalEnergyValue;}
		set { m_TotalEnergyValue = value; }
	}
	//活力值信息容器
	public List<BaseAttrEnergyInfoWraperV1> m_EnergyArray;
	public int SizeEnergyArray()
	{
		return m_EnergyArray.Count;
	}
	public List<BaseAttrEnergyInfoWraperV1> GetEnergyArray()
	{
		return m_EnergyArray;
	}
	public BaseAttrEnergyInfoWraperV1 GetEnergyArray(int Index)
	{
		if(Index<0 || Index>=(int)m_EnergyArray.Count)
			return new BaseAttrEnergyInfoWraperV1();
		return m_EnergyArray[Index];
	}
	public void SetEnergyArray( List<BaseAttrEnergyInfoWraperV1> v )
	{
		m_EnergyArray=v;
	}
	public void SetEnergyArray( int Index, BaseAttrEnergyInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_EnergyArray.Count)
			return;
		m_EnergyArray[Index] = v;
	}
	public void AddEnergyArray( BaseAttrEnergyInfoWraperV1 v )
	{
		m_EnergyArray.Add(v);
	}
	public void ClearEnergyArray( )
	{
		m_EnergyArray.Clear();
	}
	//PK状态
	public int m_PKState;
	public int PKState
	{
		get { return m_PKState;}
		set { m_PKState = value; }
	}
	//PK保护列表
	public List<KeyValue2IntBoolWraper> m_PKProtect;
	public int SizePKProtect()
	{
		return m_PKProtect.Count;
	}
	public List<KeyValue2IntBoolWraper> GetPKProtect()
	{
		return m_PKProtect;
	}
	public KeyValue2IntBoolWraper GetPKProtect(int Index)
	{
		if(Index<0 || Index>=(int)m_PKProtect.Count)
			return new KeyValue2IntBoolWraper();
		return m_PKProtect[Index];
	}
	public void SetPKProtect( List<KeyValue2IntBoolWraper> v )
	{
		m_PKProtect=v;
	}
	public void SetPKProtect( int Index, KeyValue2IntBoolWraper v )
	{
		if(Index<0 || Index>=(int)m_PKProtect.Count)
			return;
		m_PKProtect[Index] = v;
	}
	public void AddPKProtect( KeyValue2IntBoolWraper v )
	{
		m_PKProtect.Add(v);
	}
	public void ClearPKProtect( )
	{
		m_PKProtect.Clear();
	}
	//帮会修炼
	public List<BaseAttrScienceInfoWraperV1> m_GuildScienArray;
	public int SizeGuildScienArray()
	{
		return m_GuildScienArray.Count;
	}
	public List<BaseAttrScienceInfoWraperV1> GetGuildScienArray()
	{
		return m_GuildScienArray;
	}
	public BaseAttrScienceInfoWraperV1 GetGuildScienArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GuildScienArray.Count)
			return new BaseAttrScienceInfoWraperV1();
		return m_GuildScienArray[Index];
	}
	public void SetGuildScienArray( List<BaseAttrScienceInfoWraperV1> v )
	{
		m_GuildScienArray=v;
	}
	public void SetGuildScienArray( int Index, BaseAttrScienceInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GuildScienArray.Count)
			return;
		m_GuildScienArray[Index] = v;
	}
	public void AddGuildScienArray( BaseAttrScienceInfoWraperV1 v )
	{
		m_GuildScienArray.Add(v);
	}
	public void ClearGuildScienArray( )
	{
		m_GuildScienArray.Clear();
	}
	//修炼升级消耗总金币
	public int m_ScienceTotalMoney;
	public int ScienceTotalMoney
	{
		get { return m_ScienceTotalMoney;}
		set { m_ScienceTotalMoney = value; }
	}



}
