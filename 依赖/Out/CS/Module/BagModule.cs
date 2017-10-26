/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:	 ModuleBag.cs
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


public class BagRPC
{
	public const int ModuleId = 14;
	
	public const int RPC_CODE_BAG_SYNCDATA_REQUEST = 1451;
	public const int RPC_CODE_BAG_SELL_REQUEST = 1452;
	public const int RPC_CODE_BAG_DECOMPOSE_REQUEST = 1453;
	public const int RPC_CODE_BAG_USE_REQUEST = 1454;
	public const int RPC_CODE_BAG_EQUIPWEAR_REQUEST = 1455;
	public const int RPC_CODE_BAG_EQUIPUNDRESS_REQUEST = 1456;
	public const int RPC_CODE_BAG_EQUIPENHANCE_REQUEST = 1457;
	public const int RPC_CODE_BAG_EQUIPPOLISHED_REQUEST = 1458;
	public const int RPC_CODE_BAG_EQUIPPOLISHEDREPLACE_REQUEST = 1459;
	public const int RPC_CODE_BAG_BAGTIDY_REQUEST = 1460;
	public const int RPC_CODE_BAG_BAGRECYCLESELL_REQUEST = 1461;
	public const int RPC_CODE_BAG_BAGRECYCLEBUY_REQUEST = 1462;
	public const int RPC_CODE_BAG_UNLOCKGRID_REQUEST = 1463;
	public const int RPC_CODE_BAG_SPLIT_REQUEST = 1464;
	public const int RPC_CODE_BAG_EQUIPBASEATTRPLISHED_REQUEST = 1465;
	public const int RPC_CODE_BAG_EQUIPBASEATTRPOLISHEDREPLACE_REQUEST = 1466;
	public const int RPC_CODE_BAG_EQUIPEXATTRMODIFY_REQUEST = 1467;
	public const int RPC_CODE_BAG_EQUIPINLAYGEM_REQUEST = 1468;
	public const int RPC_CODE_BAG_EQUIPGEMSLOTUNLOCK_REQUEST = 1469;
	public const int RPC_CODE_BAG_EQUIPENHANCESWAP_REQUEST = 1470;
	public const int RPC_CODE_BAG_EQUIPGEMREMOVE_REQUEST = 1471;
	public const int RPC_CODE_BAG_BAGPUTINSTORAGE_REQUEST = 1472;
	public const int RPC_CODE_BAG_BAGFETCHFROMSTORAGE_REQUEST = 1473;
	public const int RPC_CODE_BAG_BAGSTORAGESAVEMONEY_REQUEST = 1474;
	public const int RPC_CODE_BAG_BAGSTORAGEDRAWMONEY_REQUEST = 1475;
	public const int RPC_CODE_BAG_STORAGETIDY_REQUEST = 1476;
	public const int RPC_CODE_BAG_TALISMANLVUP_REQUEST = 1477;
	public const int RPC_CODE_BAG_TALISMANINHERIT_REQUEST = 1478;
	public const int RPC_CODE_BAG_BAGADDNEWITEM_NOTIFY = 1479;
	public const int RPC_CODE_BAG_BAGSETAUTOPICKUP_REQUEST = 1480;
	public const int RPC_CODE_BAG_GETNEWITEM_NOTIFY = 1481;
	public const int RPC_CODE_BAG_BAGERROR_NOTIFY = 1482;
	public const int RPC_CODE_BAG_TALISMANREFINDSTAR_REQUEST = 1483;
	public const int RPC_CODE_BAG_TALISMANUPSLOTSKILLLEVEL_REQUEST = 1484;
	public const int RPC_CODE_BAG_TALISMANATTRCHANGE_NOTIFY = 1485;
	public const int RPC_CODE_BAG_TALISMANGATHERSPRITE_REQUEST = 1486;

	
	private static BagRPC m_Instance = null;
	public static BagRPC Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new BagRPC();
			}
			return m_Instance;
		}
	}
	
	/**
	 *模块初始化 
	 */ 
	public bool initialize()
	{
		Singleton<GameSocket>.Instance.RegisterSyncUpdate( ModuleId, BagData.Instance.UpdateField );
		
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_BAG_BAGADDNEWITEM_NOTIFY, BagAddNewItemCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_BAG_GETNEWITEM_NOTIFY, GetNewItemCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_BAG_BAGERROR_NOTIFY, BagErrorCB);
		Singleton<GameSocket>.Instance.RegisterNotify(RPC_CODE_BAG_TALISMANATTRCHANGE_NOTIFY, TalismanAttrChangeCB);


		return true;
	}


	/**
	*背包-->同步背包数据 RPC请求
	*/
	public void SyncData(ReplyHandler replyCB)
	{
		BagRpcSyncDataAskWraper askPBWraper = new BagRpcSyncDataAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_SYNCDATA_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcSyncDataReplyWraper replyPBWraper = new BagRpcSyncDataReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->物品出售 RPC请求
	*/
	public void Sell(int ItemID, int Pos, int Num, ReplyHandler replyCB)
	{
		BagRpcSellAskWraper askPBWraper = new BagRpcSellAskWraper();
		askPBWraper.ItemID = ItemID;
		askPBWraper.Pos = Pos;
		askPBWraper.Num = Num;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_SELL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcSellReplyWraper replyPBWraper = new BagRpcSellReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->物品分解 RPC请求
	*/
	public void Decompose(int ItemID, int Pos, ReplyHandler replyCB)
	{
		BagRpcDecomposeAskWraper askPBWraper = new BagRpcDecomposeAskWraper();
		askPBWraper.ItemID = ItemID;
		askPBWraper.Pos = Pos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_DECOMPOSE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcDecomposeReplyWraper replyPBWraper = new BagRpcDecomposeReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->物品使用 RPC请求
	*/
	public void Use(int ItemID, int Pos, ReplyHandler replyCB)
	{
		BagRpcUseAskWraper askPBWraper = new BagRpcUseAskWraper();
		askPBWraper.ItemID = ItemID;
		askPBWraper.Pos = Pos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_USE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcUseReplyWraper replyPBWraper = new BagRpcUseReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备穿戴 RPC请求
	*/
	public void EquipWear(int ItemId, int BagPos, ReplyHandler replyCB)
	{
		BagRpcEquipWearAskWraper askPBWraper = new BagRpcEquipWearAskWraper();
		askPBWraper.ItemId = ItemId;
		askPBWraper.BagPos = BagPos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPWEAR_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipWearReplyWraper replyPBWraper = new BagRpcEquipWearReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备脱下 RPC请求
	*/
	public void EquipUndress(int ItemId, int EquipPos, ReplyHandler replyCB)
	{
		BagRpcEquipUndressAskWraper askPBWraper = new BagRpcEquipUndressAskWraper();
		askPBWraper.ItemId = ItemId;
		askPBWraper.EquipPos = EquipPos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPUNDRESS_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipUndressReplyWraper replyPBWraper = new BagRpcEquipUndressReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备强化 RPC请求
	*/
	public void EquipEnhance(int ItemId, int Pos, int BagContainerType, int Lv, ReplyHandler replyCB)
	{
		BagRpcEquipEnhanceAskWraper askPBWraper = new BagRpcEquipEnhanceAskWraper();
		askPBWraper.ItemId = ItemId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		askPBWraper.Lv = Lv;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPENHANCE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipEnhanceReplyWraper replyPBWraper = new BagRpcEquipEnhanceReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备洗炼 RPC请求
	*/
	public void EquipPolished(int ItemId, int Pos, int BagContainerType, ReplyHandler replyCB)
	{
		BagRpcEquipPolishedAskWraper askPBWraper = new BagRpcEquipPolishedAskWraper();
		askPBWraper.ItemId = ItemId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPPOLISHED_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipPolishedReplyWraper replyPBWraper = new BagRpcEquipPolishedReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备洗炼属性替换 RPC请求
	*/
	public void EquipPolishedReplace(int ItemId, int Pos, int BagContainerType, ReplyHandler replyCB)
	{
		BagRpcEquipPolishedReplaceAskWraper askPBWraper = new BagRpcEquipPolishedReplaceAskWraper();
		askPBWraper.ItemId = ItemId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPPOLISHEDREPLACE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipPolishedReplaceReplyWraper replyPBWraper = new BagRpcEquipPolishedReplaceReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->背包整理 RPC请求
	*/
	public void BagTidy(ReplyHandler replyCB)
	{
		BagRpcBagTidyAskWraper askPBWraper = new BagRpcBagTidyAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGTIDY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagTidyReplyWraper replyPBWraper = new BagRpcBagTidyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备回收出售 RPC请求
	*/
	public void BagRecycleSell(List<BagRpcSellGridObjWraper> GridList, ReplyHandler replyCB)
	{
		BagRpcBagRecycleSellAskWraper askPBWraper = new BagRpcBagRecycleSellAskWraper();
		askPBWraper.SetGridList(GridList);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGRECYCLESELL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagRecycleSellReplyWraper replyPBWraper = new BagRpcBagRecycleSellReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->物品回收，购回 RPC请求
	*/
	public void BagRecycleBuy(int GridPos, ReplyHandler replyCB)
	{
		BagRpcBagRecycleBuyAskWraper askPBWraper = new BagRpcBagRecycleBuyAskWraper();
		askPBWraper.GridPos = GridPos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGRECYCLEBUY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagRecycleBuyReplyWraper replyPBWraper = new BagRpcBagRecycleBuyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->开启格子 RPC请求
	*/
	public void UnlockGrid(int GridCount, ReplyHandler replyCB)
	{
		BagRpcUnlockGridAskWraper askPBWraper = new BagRpcUnlockGridAskWraper();
		askPBWraper.GridCount = GridCount;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_UNLOCKGRID_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcUnlockGridReplyWraper replyPBWraper = new BagRpcUnlockGridReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->物品拆分 RPC请求
	*/
	public void Split(int TemplateId, int Pos, int Num, ReplyHandler replyCB)
	{
		BagRpcSplitAskWraper askPBWraper = new BagRpcSplitAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.Num = Num;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_SPLIT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcSplitReplyWraper replyPBWraper = new BagRpcSplitReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备基础属性洗炼 RPC请求
	*/
	public void EquipBaseAttrPlished(int TemplateId, int Pos, int BagContainerType, ReplyHandler replyCB)
	{
		BagRpcEquipBaseAttrPlishedAskWraper askPBWraper = new BagRpcEquipBaseAttrPlishedAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPBASEATTRPLISHED_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipBaseAttrPlishedReplyWraper replyPBWraper = new BagRpcEquipBaseAttrPlishedReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备基础属性洗炼替换 RPC请求
	*/
	public void EquipBaseAttrPolishedReplace(int TemplateId, int Pos, int BagContainerType, ReplyHandler replyCB)
	{
		BagRpcEquipBaseAttrPolishedReplaceAskWraper askPBWraper = new BagRpcEquipBaseAttrPolishedReplaceAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPBASEATTRPOLISHEDREPLACE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipBaseAttrPolishedReplaceReplyWraper replyPBWraper = new BagRpcEquipBaseAttrPolishedReplaceReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备改造 RPC请求
	*/
	public void EquipExAttrModify(int TemplateId, int Pos, int BagContainerType, ReplyHandler replyCB)
	{
		BagRpcEquipExAttrModifyAskWraper askPBWraper = new BagRpcEquipExAttrModifyAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPEXATTRMODIFY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipExAttrModifyReplyWraper replyPBWraper = new BagRpcEquipExAttrModifyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->宝石镶嵌 RPC请求
	*/
	public void EquipInlayGem(int TemplateId, int Pos, int BagContainerType, int SlotPos, int GemId, int GemPos, ReplyHandler replyCB)
	{
		BagRpcEquipInlayGemAskWraper askPBWraper = new BagRpcEquipInlayGemAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		askPBWraper.SlotPos = SlotPos;
		askPBWraper.GemId = GemId;
		askPBWraper.GemPos = GemPos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPINLAYGEM_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipInlayGemReplyWraper replyPBWraper = new BagRpcEquipInlayGemReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备宝石槽位打孔 RPC请求
	*/
	public void EquipGemSlotUnlock(int TemplateId, int Pos, int BagContainerType, int SlotPos, ReplyHandler replyCB)
	{
		BagRpcEquipGemSlotUnlockAskWraper askPBWraper = new BagRpcEquipGemSlotUnlockAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		askPBWraper.SlotPos = SlotPos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPGEMSLOTUNLOCK_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipGemSlotUnlockReplyWraper replyPBWraper = new BagRpcEquipGemSlotUnlockReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备强化转移 RPC请求
	*/
	public void EquipEnhanceSwap(int TemplateId1, int Pos1, int TemplateId2, int Pos2, int BagContainerType1, int BagContainerType2, ReplyHandler replyCB)
	{
		BagRpcEquipEnhanceSwapAskWraper askPBWraper = new BagRpcEquipEnhanceSwapAskWraper();
		askPBWraper.TemplateId1 = TemplateId1;
		askPBWraper.Pos1 = Pos1;
		askPBWraper.TemplateId2 = TemplateId2;
		askPBWraper.Pos2 = Pos2;
		askPBWraper.BagContainerType1 = BagContainerType1;
		askPBWraper.BagContainerType2 = BagContainerType2;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPENHANCESWAP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipEnhanceSwapReplyWraper replyPBWraper = new BagRpcEquipEnhanceSwapReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->装备宝石移除 RPC请求
	*/
	public void EquipGemRemove(int TemplateId, int Pos, int BagContainerType, int SlotPos, ReplyHandler replyCB)
	{
		BagRpcEquipGemRemoveAskWraper askPBWraper = new BagRpcEquipGemRemoveAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.BagContainerType = BagContainerType;
		askPBWraper.SlotPos = SlotPos;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_EQUIPGEMREMOVE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcEquipGemRemoveReplyWraper replyPBWraper = new BagRpcEquipGemRemoveReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->存入仓库 RPC请求
	*/
	public void BagPutInStorage(int TemplateId, int Pos, int Num, ReplyHandler replyCB)
	{
		BagRpcBagPutInStorageAskWraper askPBWraper = new BagRpcBagPutInStorageAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.Num = Num;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGPUTINSTORAGE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagPutInStorageReplyWraper replyPBWraper = new BagRpcBagPutInStorageReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->从仓库取出 RPC请求
	*/
	public void BagFetchFromStorage(int TemplateId, int Pos, int Num, ReplyHandler replyCB)
	{
		BagRpcBagFetchFromStorageAskWraper askPBWraper = new BagRpcBagFetchFromStorageAskWraper();
		askPBWraper.TemplateId = TemplateId;
		askPBWraper.Pos = Pos;
		askPBWraper.Num = Num;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGFETCHFROMSTORAGE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagFetchFromStorageReplyWraper replyPBWraper = new BagRpcBagFetchFromStorageReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->仓库存钱 RPC请求
	*/
	public void BagStorageSaveMoney(int Money, ReplyHandler replyCB)
	{
		BagRpcBagStorageSaveMoneyAskWraper askPBWraper = new BagRpcBagStorageSaveMoneyAskWraper();
		askPBWraper.Money = Money;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGSTORAGESAVEMONEY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagStorageSaveMoneyReplyWraper replyPBWraper = new BagRpcBagStorageSaveMoneyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->仓库取钱 RPC请求
	*/
	public void BagStorageDrawMoney(int Money, ReplyHandler replyCB)
	{
		BagRpcBagStorageDrawMoneyAskWraper askPBWraper = new BagRpcBagStorageDrawMoneyAskWraper();
		askPBWraper.Money = Money;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGSTORAGEDRAWMONEY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagStorageDrawMoneyReplyWraper replyPBWraper = new BagRpcBagStorageDrawMoneyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->仓库整理 RPC请求
	*/
	public void StorageTidy(ReplyHandler replyCB)
	{
		BagRpcStorageTidyAskWraper askPBWraper = new BagRpcStorageTidyAskWraper();
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_STORAGETIDY_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcStorageTidyReplyWraper replyPBWraper = new BagRpcStorageTidyReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->法宝铸炼 RPC请求
	*/
	public void TalismanLvup(List<int> CostTalisman, ReplyHandler replyCB)
	{
		BagRpcTalismanLvupAskWraper askPBWraper = new BagRpcTalismanLvupAskWraper();
		askPBWraper.SetCostTalisman(CostTalisman);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_TALISMANLVUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcTalismanLvupReplyWraper replyPBWraper = new BagRpcTalismanLvupReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->法宝传承 RPC请求
	*/
	public void TalismanInherit(int RightSideTalisman, ReplyHandler replyCB)
	{
		BagRpcTalismanInheritAskWraper askPBWraper = new BagRpcTalismanInheritAskWraper();
		askPBWraper.RightSideTalisman = RightSideTalisman;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_TALISMANINHERIT_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcTalismanInheritReplyWraper replyPBWraper = new BagRpcTalismanInheritReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->设置自动拾取 RPC请求
	*/
	public void BagSetAutoPickup(List<KeyValue2IntBoolWraper> AutoPick, ReplyHandler replyCB)
	{
		BagRpcBagSetAutoPickupAskWraper askPBWraper = new BagRpcBagSetAutoPickupAskWraper();
		askPBWraper.SetAutoPick(AutoPick);
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_BAGSETAUTOPICKUP_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcBagSetAutoPickupReplyWraper replyPBWraper = new BagRpcBagSetAutoPickupReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->炼星 RPC请求
	*/
	public void TalismanRefindStar(long FabaoId, ReplyHandler replyCB)
	{
		BagRpcTalismanRefindStarAskWraper askPBWraper = new BagRpcTalismanRefindStarAskWraper();
		askPBWraper.FabaoId = FabaoId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_TALISMANREFINDSTAR_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcTalismanRefindStarReplyWraper replyPBWraper = new BagRpcTalismanRefindStarReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->升级聚灵槽位技能 RPC请求
	*/
	public void TalismanUpSlotSkillLevel(long FabaoId, int SlotId, ReplyHandler replyCB)
	{
		BagRpcTalismanUpSlotSkillLevelAskWraper askPBWraper = new BagRpcTalismanUpSlotSkillLevelAskWraper();
		askPBWraper.FabaoId = FabaoId;
		askPBWraper.SlotId = SlotId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_TALISMANUPSLOTSKILLLEVEL_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcTalismanUpSlotSkillLevelReplyWraper replyPBWraper = new BagRpcTalismanUpSlotSkillLevelReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}

	/**
	*背包-->宝石聚灵 RPC请求
	*/
	public void TalismanGatherSprite(long FabaoId, int GatherSpriteId, int SlotId, ReplyHandler replyCB)
	{
		BagRpcTalismanGatherSpriteAskWraper askPBWraper = new BagRpcTalismanGatherSpriteAskWraper();
		askPBWraper.FabaoId = FabaoId;
		askPBWraper.GatherSpriteId = GatherSpriteId;
		askPBWraper.SlotId = SlotId;
		ModMessage askMsg = new ModMessage();
		askMsg.MsgNum = RPC_CODE_BAG_TALISMANGATHERSPRITE_REQUEST;
		askMsg.protoMS = askPBWraper.ToMemoryStream();

		Singleton<GameSocket>.Instance.SendAsk(askMsg, delegate(ModMessage replyMsg){
			BagRpcTalismanGatherSpriteReplyWraper replyPBWraper = new BagRpcTalismanGatherSpriteReplyWraper();
			replyPBWraper.FromMemoryStream(replyMsg.protoMS);
			replyCB(replyPBWraper);
		});
	}


	/**
	*背包-->背包获得新物品 服务器通知回调
	*/
	public static void BagAddNewItemCB( ModMessage notifyMsg )
	{
		BagRpcBagAddNewItemNotifyWraper notifyPBWraper = new BagRpcBagAddNewItemNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BagAddNewItemCBDelegate != null )
			BagAddNewItemCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BagAddNewItemCBDelegate = null;
	/**
	*背包-->获得新物品 服务器通知回调
	*/
	public static void GetNewItemCB( ModMessage notifyMsg )
	{
		BagRpcGetNewItemNotifyWraper notifyPBWraper = new BagRpcGetNewItemNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( GetNewItemCBDelegate != null )
			GetNewItemCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback GetNewItemCBDelegate = null;
	/**
	*背包-->背包错误 服务器通知回调
	*/
	public static void BagErrorCB( ModMessage notifyMsg )
	{
		BagRpcBagErrorNotifyWraper notifyPBWraper = new BagRpcBagErrorNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( BagErrorCBDelegate != null )
			BagErrorCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback BagErrorCBDelegate = null;
	/**
	*背包-->属性变化通知 服务器通知回调
	*/
	public static void TalismanAttrChangeCB( ModMessage notifyMsg )
	{
		BagRpcTalismanAttrChangeNotifyWraper notifyPBWraper = new BagRpcTalismanAttrChangeNotifyWraper();
		notifyPBWraper.FromMemoryStream(notifyMsg.protoMS);
		if( TalismanAttrChangeCBDelegate != null )
			TalismanAttrChangeCBDelegate( notifyPBWraper );
	}
	public static ServerNotifyCallback TalismanAttrChangeCBDelegate = null;



}

public class BagData
{
	public enum SyncIdE
	{
 		GRIDARRAY                                  = 1401,  //背包格子数组
 		EQUIPALLDATA                               = 1404,  //装备全部数据
 		WEAREQUIPCONTAINER                         = 1405,  //穿戴装备容器
 		STORAGEBAGGRID                             = 1407,  //仓库
 		STORAGEBANK                                = 1408,  //仓库金钱
 		TALISMANDATA                               = 1409,  //法宝数据
 		TALISMANFOREVERATTR                        = 1410,  //装备过的法宝，可获得永久属性加成
 		AUTOPICKUP                                 = 1411,  //自动拾取设置
 		USEITEMDAY                                 = 1415,  //每天使用的道具
 		USEITEMWEEK                                = 1416,  //每周使用的道具

	}
	
	private static BagData m_Instance = null;
	public static BagData Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new BagData();
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
			case SyncIdE.GRIDARRAY:
				if(Index < 0){ m_Instance.ClearGridArray(); break; }
				if (Index >= m_Instance.SizeGridArray())
				{
					int Count = Index - m_Instance.SizeGridArray() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddGridArray(new BagGridInfoWraperV1());
				}
				m_Instance.GetGridArray(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.EQUIPALLDATA:
				if(Index < 0){ m_Instance.ClearEquipAllData(); break; }
				if (Index >= m_Instance.SizeEquipAllData())
				{
					int Count = Index - m_Instance.SizeEquipAllData() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddEquipAllData(new BagEquipObjWraper());
				}
				m_Instance.GetEquipAllData(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.WEAREQUIPCONTAINER:
				if(Index < 0){ m_Instance.ClearWearEquipContainer(); break; }
				if (Index >= m_Instance.SizeWearEquipContainer())
				{
					int Count = Index - m_Instance.SizeWearEquipContainer() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddWearEquipContainer(new BagGridInfoWraperV1());
				}
				m_Instance.GetWearEquipContainer(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.STORAGEBAGGRID:
				if(Index < 0){ m_Instance.ClearStorageBagGrid(); break; }
				if (Index >= m_Instance.SizeStorageBagGrid())
				{
					int Count = Index - m_Instance.SizeStorageBagGrid() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddStorageBagGrid(new BagGridInfoWraperV1());
				}
				m_Instance.GetStorageBagGrid(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.STORAGEBANK:
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.StorageBank = iValue;
				break;
			case SyncIdE.TALISMANDATA:
				if(Index < 0){ m_Instance.ClearTalismanData(); break; }
				if (Index >= m_Instance.SizeTalismanData())
				{
					int Count = Index - m_Instance.SizeTalismanData() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddTalismanData(new BagTalismanObjWraperV1());
				}
				m_Instance.GetTalismanData(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.TALISMANFOREVERATTR:
				if(Index < 0){ m_Instance.ClearTalismanForeverAttr(); break; }
				if (Index >= m_Instance.SizeTalismanForeverAttr())
				{
					int Count = Index - m_Instance.SizeTalismanForeverAttr() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddTalismanForeverAttr(-1);
				}
				GameAssist.ReadInt32Variant(updateBuffer, 0, out iValue);
				m_Instance.SetTalismanForeverAttr(Index, iValue);
				break;
			case SyncIdE.AUTOPICKUP:
				if(Index < 0){ m_Instance.ClearAutoPickup(); break; }
				if (Index >= m_Instance.SizeAutoPickup())
				{
					int Count = Index - m_Instance.SizeAutoPickup() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddAutoPickup(new KeyValue2IntBoolWraper());
				}
				m_Instance.GetAutoPickup(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.USEITEMDAY:
				if(Index < 0){ m_Instance.ClearUseItemDay(); break; }
				if (Index >= m_Instance.SizeUseItemDay())
				{
					int Count = Index - m_Instance.SizeUseItemDay() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddUseItemDay(new KeyValue2IntIntWraper());
				}
				m_Instance.GetUseItemDay(Index).FromMemoryStream(new MemoryStream(updateBuffer));
				break;
			case SyncIdE.USEITEMWEEK:
				if(Index < 0){ m_Instance.ClearUseItemWeek(); break; }
				if (Index >= m_Instance.SizeUseItemWeek())
				{
					int Count = Index - m_Instance.SizeUseItemWeek() + 1;
					for (int i = 0; i < Count; i++)
						m_Instance.AddUseItemWeek(new KeyValue2IntIntWraper());
				}
				m_Instance.GetUseItemWeek(Index).FromMemoryStream(new MemoryStream(updateBuffer));
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
			Ex.Logger.Log("BagData.NotifySyncValueChanged catch exception");
		}
		updateBuffer.GetType();
		iValue ++;
		lValue ++;
	}

	public NotifySyncValueChangedCB NotifySyncValueChanged = null;
  

	//构造函数
	public BagData()
	{
		m_GridArray = new List<BagGridInfoWraperV1>();
		m_EquipAllData = new List<BagEquipObjWraper>();
		m_WearEquipContainer = new List<BagGridInfoWraperV1>();
		m_StorageBagGrid = new List<BagGridInfoWraperV1>();
		 m_StorageBank = 0;
		m_TalismanData = new List<BagTalismanObjWraperV1>();
		m_TalismanForeverAttr = new List<int>();
		m_AutoPickup = new List<KeyValue2IntBoolWraper>();
		m_UseItemDay = new List<KeyValue2IntIntWraper>();
		m_UseItemWeek = new List<KeyValue2IntIntWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_GridArray = new List<BagGridInfoWraperV1>();
		m_EquipAllData = new List<BagEquipObjWraper>();
		m_WearEquipContainer = new List<BagGridInfoWraperV1>();
		m_StorageBagGrid = new List<BagGridInfoWraperV1>();
		 m_StorageBank = 0;
		m_TalismanData = new List<BagTalismanObjWraperV1>();
		m_TalismanForeverAttr = new List<int>();
		m_AutoPickup = new List<KeyValue2IntBoolWraper>();
		m_UseItemDay = new List<KeyValue2IntIntWraper>();
		m_UseItemWeek = new List<KeyValue2IntIntWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagPackageDataV1 ToPB()
	{
		BagPackageDataV1 v = new BagPackageDataV1();
		for (int i=0; i<(int)m_GridArray.Count; i++)
			v.GridArray.Add( m_GridArray[i].ToPB());
		for (int i=0; i<(int)m_EquipAllData.Count; i++)
			v.EquipAllData.Add( m_EquipAllData[i].ToPB());
		for (int i=0; i<(int)m_WearEquipContainer.Count; i++)
			v.WearEquipContainer.Add( m_WearEquipContainer[i].ToPB());
		for (int i=0; i<(int)m_StorageBagGrid.Count; i++)
			v.StorageBagGrid.Add( m_StorageBagGrid[i].ToPB());
		v.StorageBank = m_StorageBank;
		for (int i=0; i<(int)m_TalismanData.Count; i++)
			v.TalismanData.Add( m_TalismanData[i].ToPB());
		for (int i=0; i<(int)m_TalismanForeverAttr.Count; i++)
			v.TalismanForeverAttr.Add( m_TalismanForeverAttr[i]);
		for (int i=0; i<(int)m_AutoPickup.Count; i++)
			v.AutoPickup.Add( m_AutoPickup[i].ToPB());
		for (int i=0; i<(int)m_UseItemDay.Count; i++)
			v.UseItemDay.Add( m_UseItemDay[i].ToPB());
		for (int i=0; i<(int)m_UseItemWeek.Count; i++)
			v.UseItemWeek.Add( m_UseItemWeek[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagPackageDataV1 v)
	{
        if (v == null)
            return;
		m_GridArray.Clear();
		for( int i=0; i<v.GridArray.Count; i++)
			m_GridArray.Add( new BagGridInfoWraperV1());
		for( int i=0; i<v.GridArray.Count; i++)
			m_GridArray[i].FromPB(v.GridArray[i]);
		m_EquipAllData.Clear();
		for( int i=0; i<v.EquipAllData.Count; i++)
			m_EquipAllData.Add( new BagEquipObjWraper());
		for( int i=0; i<v.EquipAllData.Count; i++)
			m_EquipAllData[i].FromPB(v.EquipAllData[i]);
		m_WearEquipContainer.Clear();
		for( int i=0; i<v.WearEquipContainer.Count; i++)
			m_WearEquipContainer.Add( new BagGridInfoWraperV1());
		for( int i=0; i<v.WearEquipContainer.Count; i++)
			m_WearEquipContainer[i].FromPB(v.WearEquipContainer[i]);
		m_StorageBagGrid.Clear();
		for( int i=0; i<v.StorageBagGrid.Count; i++)
			m_StorageBagGrid.Add( new BagGridInfoWraperV1());
		for( int i=0; i<v.StorageBagGrid.Count; i++)
			m_StorageBagGrid[i].FromPB(v.StorageBagGrid[i]);
		m_StorageBank = v.StorageBank;
		m_TalismanData.Clear();
		for( int i=0; i<v.TalismanData.Count; i++)
			m_TalismanData.Add( new BagTalismanObjWraperV1());
		for( int i=0; i<v.TalismanData.Count; i++)
			m_TalismanData[i].FromPB(v.TalismanData[i]);
		m_TalismanForeverAttr.Clear();
		for( int i=0; i<v.TalismanForeverAttr.Count; i++)
			m_TalismanForeverAttr.Add(v.TalismanForeverAttr[i]);
		m_AutoPickup.Clear();
		for( int i=0; i<v.AutoPickup.Count; i++)
			m_AutoPickup.Add( new KeyValue2IntBoolWraper());
		for( int i=0; i<v.AutoPickup.Count; i++)
			m_AutoPickup[i].FromPB(v.AutoPickup[i]);
		m_UseItemDay.Clear();
		for( int i=0; i<v.UseItemDay.Count; i++)
			m_UseItemDay.Add( new KeyValue2IntIntWraper());
		for( int i=0; i<v.UseItemDay.Count; i++)
			m_UseItemDay[i].FromPB(v.UseItemDay[i]);
		m_UseItemWeek.Clear();
		for( int i=0; i<v.UseItemWeek.Count; i++)
			m_UseItemWeek.Add( new KeyValue2IntIntWraper());
		for( int i=0; i<v.UseItemWeek.Count; i++)
			m_UseItemWeek[i].FromPB(v.UseItemWeek[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagPackageDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagPackageDataV1 pb = ProtoBuf.Serializer.Deserialize<BagPackageDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//背包格子数组
	public List<BagGridInfoWraperV1> m_GridArray;
	public int SizeGridArray()
	{
		return m_GridArray.Count;
	}
	public List<BagGridInfoWraperV1> GetGridArray()
	{
		return m_GridArray;
	}
	public BagGridInfoWraperV1 GetGridArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GridArray.Count)
			return new BagGridInfoWraperV1();
		return m_GridArray[Index];
	}
	public void SetGridArray( List<BagGridInfoWraperV1> v )
	{
		m_GridArray=v;
	}
	public void SetGridArray( int Index, BagGridInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GridArray.Count)
			return;
		m_GridArray[Index] = v;
	}
	public void AddGridArray( BagGridInfoWraperV1 v )
	{
		m_GridArray.Add(v);
	}
	public void ClearGridArray( )
	{
		m_GridArray.Clear();
	}
	//装备全部数据
	public List<BagEquipObjWraper> m_EquipAllData;
	public int SizeEquipAllData()
	{
		return m_EquipAllData.Count;
	}
	public List<BagEquipObjWraper> GetEquipAllData()
	{
		return m_EquipAllData;
	}
	public BagEquipObjWraper GetEquipAllData(int Index)
	{
		if(Index<0 || Index>=(int)m_EquipAllData.Count)
			return new BagEquipObjWraper();
		return m_EquipAllData[Index];
	}
	public void SetEquipAllData( List<BagEquipObjWraper> v )
	{
		m_EquipAllData=v;
	}
	public void SetEquipAllData( int Index, BagEquipObjWraper v )
	{
		if(Index<0 || Index>=(int)m_EquipAllData.Count)
			return;
		m_EquipAllData[Index] = v;
	}
	public void AddEquipAllData( BagEquipObjWraper v )
	{
		m_EquipAllData.Add(v);
	}
	public void ClearEquipAllData( )
	{
		m_EquipAllData.Clear();
	}
	//穿戴装备容器
	public List<BagGridInfoWraperV1> m_WearEquipContainer;
	public int SizeWearEquipContainer()
	{
		return m_WearEquipContainer.Count;
	}
	public List<BagGridInfoWraperV1> GetWearEquipContainer()
	{
		return m_WearEquipContainer;
	}
	public BagGridInfoWraperV1 GetWearEquipContainer(int Index)
	{
		if(Index<0 || Index>=(int)m_WearEquipContainer.Count)
			return new BagGridInfoWraperV1();
		return m_WearEquipContainer[Index];
	}
	public void SetWearEquipContainer( List<BagGridInfoWraperV1> v )
	{
		m_WearEquipContainer=v;
	}
	public void SetWearEquipContainer( int Index, BagGridInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_WearEquipContainer.Count)
			return;
		m_WearEquipContainer[Index] = v;
	}
	public void AddWearEquipContainer( BagGridInfoWraperV1 v )
	{
		m_WearEquipContainer.Add(v);
	}
	public void ClearWearEquipContainer( )
	{
		m_WearEquipContainer.Clear();
	}
	//仓库
	public List<BagGridInfoWraperV1> m_StorageBagGrid;
	public int SizeStorageBagGrid()
	{
		return m_StorageBagGrid.Count;
	}
	public List<BagGridInfoWraperV1> GetStorageBagGrid()
	{
		return m_StorageBagGrid;
	}
	public BagGridInfoWraperV1 GetStorageBagGrid(int Index)
	{
		if(Index<0 || Index>=(int)m_StorageBagGrid.Count)
			return new BagGridInfoWraperV1();
		return m_StorageBagGrid[Index];
	}
	public void SetStorageBagGrid( List<BagGridInfoWraperV1> v )
	{
		m_StorageBagGrid=v;
	}
	public void SetStorageBagGrid( int Index, BagGridInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_StorageBagGrid.Count)
			return;
		m_StorageBagGrid[Index] = v;
	}
	public void AddStorageBagGrid( BagGridInfoWraperV1 v )
	{
		m_StorageBagGrid.Add(v);
	}
	public void ClearStorageBagGrid( )
	{
		m_StorageBagGrid.Clear();
	}
	//仓库金钱
	public int m_StorageBank;
	public int StorageBank
	{
		get { return m_StorageBank;}
		set { m_StorageBank = value; }
	}
	//法宝数据
	public List<BagTalismanObjWraperV1> m_TalismanData;
	public int SizeTalismanData()
	{
		return m_TalismanData.Count;
	}
	public List<BagTalismanObjWraperV1> GetTalismanData()
	{
		return m_TalismanData;
	}
	public BagTalismanObjWraperV1 GetTalismanData(int Index)
	{
		if(Index<0 || Index>=(int)m_TalismanData.Count)
			return new BagTalismanObjWraperV1();
		return m_TalismanData[Index];
	}
	public void SetTalismanData( List<BagTalismanObjWraperV1> v )
	{
		m_TalismanData=v;
	}
	public void SetTalismanData( int Index, BagTalismanObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_TalismanData.Count)
			return;
		m_TalismanData[Index] = v;
	}
	public void AddTalismanData( BagTalismanObjWraperV1 v )
	{
		m_TalismanData.Add(v);
	}
	public void ClearTalismanData( )
	{
		m_TalismanData.Clear();
	}
	//装备过的法宝，可获得永久属性加成
	public List<int> m_TalismanForeverAttr;
	public int SizeTalismanForeverAttr()
	{
		return m_TalismanForeverAttr.Count;
	}
	public List<int> GetTalismanForeverAttr()
	{
		return m_TalismanForeverAttr;
	}
	public int GetTalismanForeverAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_TalismanForeverAttr.Count)
			return -1;
		return m_TalismanForeverAttr[Index];
	}
	public void SetTalismanForeverAttr( List<int> v )
	{
		m_TalismanForeverAttr=v;
	}
	public void SetTalismanForeverAttr( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_TalismanForeverAttr.Count)
			return;
		m_TalismanForeverAttr[Index] = v;
	}
	public void AddTalismanForeverAttr( int v=-1 )
	{
		m_TalismanForeverAttr.Add(v);
	}
	public void ClearTalismanForeverAttr( )
	{
		m_TalismanForeverAttr.Clear();
	}
	//自动拾取设置
	public List<KeyValue2IntBoolWraper> m_AutoPickup;
	public int SizeAutoPickup()
	{
		return m_AutoPickup.Count;
	}
	public List<KeyValue2IntBoolWraper> GetAutoPickup()
	{
		return m_AutoPickup;
	}
	public KeyValue2IntBoolWraper GetAutoPickup(int Index)
	{
		if(Index<0 || Index>=(int)m_AutoPickup.Count)
			return new KeyValue2IntBoolWraper();
		return m_AutoPickup[Index];
	}
	public void SetAutoPickup( List<KeyValue2IntBoolWraper> v )
	{
		m_AutoPickup=v;
	}
	public void SetAutoPickup( int Index, KeyValue2IntBoolWraper v )
	{
		if(Index<0 || Index>=(int)m_AutoPickup.Count)
			return;
		m_AutoPickup[Index] = v;
	}
	public void AddAutoPickup( KeyValue2IntBoolWraper v )
	{
		m_AutoPickup.Add(v);
	}
	public void ClearAutoPickup( )
	{
		m_AutoPickup.Clear();
	}
	//每天使用的道具
	public List<KeyValue2IntIntWraper> m_UseItemDay;
	public int SizeUseItemDay()
	{
		return m_UseItemDay.Count;
	}
	public List<KeyValue2IntIntWraper> GetUseItemDay()
	{
		return m_UseItemDay;
	}
	public KeyValue2IntIntWraper GetUseItemDay(int Index)
	{
		if(Index<0 || Index>=(int)m_UseItemDay.Count)
			return new KeyValue2IntIntWraper();
		return m_UseItemDay[Index];
	}
	public void SetUseItemDay( List<KeyValue2IntIntWraper> v )
	{
		m_UseItemDay=v;
	}
	public void SetUseItemDay( int Index, KeyValue2IntIntWraper v )
	{
		if(Index<0 || Index>=(int)m_UseItemDay.Count)
			return;
		m_UseItemDay[Index] = v;
	}
	public void AddUseItemDay( KeyValue2IntIntWraper v )
	{
		m_UseItemDay.Add(v);
	}
	public void ClearUseItemDay( )
	{
		m_UseItemDay.Clear();
	}
	//每周使用的道具
	public List<KeyValue2IntIntWraper> m_UseItemWeek;
	public int SizeUseItemWeek()
	{
		return m_UseItemWeek.Count;
	}
	public List<KeyValue2IntIntWraper> GetUseItemWeek()
	{
		return m_UseItemWeek;
	}
	public KeyValue2IntIntWraper GetUseItemWeek(int Index)
	{
		if(Index<0 || Index>=(int)m_UseItemWeek.Count)
			return new KeyValue2IntIntWraper();
		return m_UseItemWeek[Index];
	}
	public void SetUseItemWeek( List<KeyValue2IntIntWraper> v )
	{
		m_UseItemWeek=v;
	}
	public void SetUseItemWeek( int Index, KeyValue2IntIntWraper v )
	{
		if(Index<0 || Index>=(int)m_UseItemWeek.Count)
			return;
		m_UseItemWeek[Index] = v;
	}
	public void AddUseItemWeek( KeyValue2IntIntWraper v )
	{
		m_UseItemWeek.Add(v);
	}
	public void ClearUseItemWeek( )
	{
		m_UseItemWeek.Clear();
	}



}
