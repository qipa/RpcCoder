#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class BagRpcSyncDataAskWraperHelper
{
}
[System.Serializable]
public class BagRpcSellAskWraperHelper
{
	public int ItemID;
	public int Pos;
	public int Num;
}
[System.Serializable]
public class BagRpcDecomposeAskWraperHelper
{
	public int ItemID;
	public int Pos;
}
[System.Serializable]
public class BagRpcUseAskWraperHelper
{
	public int ItemID;
	public int Pos;
}
[System.Serializable]
public class BagRpcEquipWearAskWraperHelper
{
	public int ItemId;
	public int BagPos;
}
[System.Serializable]
public class BagRpcEquipUndressAskWraperHelper
{
	public int ItemId;
	public int EquipPos;
}
[System.Serializable]
public class BagRpcEquipEnhanceAskWraperHelper
{
	public int ItemId;
	public int Pos;
	public int BagContainerType;
	public int Lv;
}
[System.Serializable]
public class BagRpcEquipPolishedAskWraperHelper
{
	public int ItemId;
	public int Pos;
	public int BagContainerType;
}
[System.Serializable]
public class BagRpcEquipPolishedReplaceAskWraperHelper
{
	public int ItemId;
	public int Pos;
	public int BagContainerType;
}
[System.Serializable]
public class BagRpcBagTidyAskWraperHelper
{
}
[System.Serializable]
public class BagRpcBagRecycleBuyAskWraperHelper
{
	public int GridPos;
}
[System.Serializable]
public class BagRpcUnlockGridAskWraperHelper
{
	public int GridCount;
}
[System.Serializable]
public class BagRpcBagRecycleSellAskWraperHelper
{
	public List<BagRpcSellGridObjWraper> GridList;
}
[System.Serializable]
public class BagRpcSplitAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int Num;
}
[System.Serializable]
public class BagRpcEquipBaseAttrPlishedAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int BagContainerType;
}
[System.Serializable]
public class BagRpcEquipBaseAttrPolishedReplaceAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int BagContainerType;
}
[System.Serializable]
public class BagRpcEquipExAttrModifyAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int BagContainerType;
}
[System.Serializable]
public class BagRpcEquipInlayGemAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int BagContainerType;
	public int SlotPos;
	public int GemId;
	public int GemPos;
}
[System.Serializable]
public class BagRpcEquipGemSlotUnlockAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int BagContainerType;
	public int SlotPos;
}
[System.Serializable]
public class BagRpcEquipEnhanceSwapAskWraperHelper
{
	public int TemplateId1;
	public int Pos1;
	public int TemplateId2;
	public int Pos2;
	public int BagContainerType1;
	public int BagContainerType2;
}
[System.Serializable]
public class BagRpcEquipGemRemoveAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int BagContainerType;
	public int SlotPos;
}
[System.Serializable]
public class BagRpcBagPutInStorageAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int Num;
}
[System.Serializable]
public class BagRpcBagFetchFromStorageAskWraperHelper
{
	public int TemplateId;
	public int Pos;
	public int Num;
}
[System.Serializable]
public class BagRpcBagStorageSaveMoneyAskWraperHelper
{
	public int Money;
}
[System.Serializable]
public class BagRpcBagStorageDrawMoneyAskWraperHelper
{
	public int Money;
}
[System.Serializable]
public class BagRpcStorageTidyAskWraperHelper
{
}
[System.Serializable]
public class BagRpcTalismanLvupAskWraperHelper
{
	public List<int> CostTalisman;
}
[System.Serializable]
public class BagRpcTalismanInheritAskWraperHelper
{
	public int RightSideTalisman;
}
[System.Serializable]
public class BagRpcBagAddNewItemNotifyWraperHelper
{
	public List<BagGridObjWraper> NewItem;
}
[System.Serializable]
public class BagRpcBagSetAutoPickupAskWraperHelper
{
	public List<KeyValue2IntBoolWraper> AutoPick;
}
[System.Serializable]
public class BagRpcGetNewItemNotifyWraperHelper
{
	public List<KeyValue2IntIntWraper> Item;
	public int ModuleId;
	public int PathWayId;
	public int ModuleParam;
}
[System.Serializable]
public class BagRpcBagErrorNotifyWraperHelper
{
	public int Result;
}
[System.Serializable]
public class BagRpcTalismanRefindStarAskWraperHelper
{
	public long FabaoId;
}
[System.Serializable]
public class BagRpcTalismanUpSlotSkillLevelAskWraperHelper
{
	public long FabaoId;
	public int SlotId;
}
[System.Serializable]
public class BagRpcTalismanAttrChangeNotifyWraperHelper
{
	public List<KeyValue2IntIntWraper> Attr;
}
[System.Serializable]
public class BagRpcTalismanGatherSpriteAskWraperHelper
{
	public long FabaoId;
	public int GatherSpriteId;
	public int SlotId;
}



public class BagTestHelper : MonoBehaviour
{
	public BagRpcSyncDataAskWraperHelper BagRpcSyncDataAskWraperVar;
	public BagRpcSellAskWraperHelper BagRpcSellAskWraperVar;
	public BagRpcDecomposeAskWraperHelper BagRpcDecomposeAskWraperVar;
	public BagRpcUseAskWraperHelper BagRpcUseAskWraperVar;
	public BagRpcEquipWearAskWraperHelper BagRpcEquipWearAskWraperVar;
	public BagRpcEquipUndressAskWraperHelper BagRpcEquipUndressAskWraperVar;
	public BagRpcEquipEnhanceAskWraperHelper BagRpcEquipEnhanceAskWraperVar;
	public BagRpcEquipPolishedAskWraperHelper BagRpcEquipPolishedAskWraperVar;
	public BagRpcEquipPolishedReplaceAskWraperHelper BagRpcEquipPolishedReplaceAskWraperVar;
	public BagRpcBagTidyAskWraperHelper BagRpcBagTidyAskWraperVar;
	public BagRpcBagRecycleBuyAskWraperHelper BagRpcBagRecycleBuyAskWraperVar;
	public BagRpcUnlockGridAskWraperHelper BagRpcUnlockGridAskWraperVar;
	public BagRpcBagRecycleSellAskWraperHelper BagRpcBagRecycleSellAskWraperVar;
	public BagRpcSplitAskWraperHelper BagRpcSplitAskWraperVar;
	public BagRpcEquipBaseAttrPlishedAskWraperHelper BagRpcEquipBaseAttrPlishedAskWraperVar;
	public BagRpcEquipBaseAttrPolishedReplaceAskWraperHelper BagRpcEquipBaseAttrPolishedReplaceAskWraperVar;
	public BagRpcEquipExAttrModifyAskWraperHelper BagRpcEquipExAttrModifyAskWraperVar;
	public BagRpcEquipInlayGemAskWraperHelper BagRpcEquipInlayGemAskWraperVar;
	public BagRpcEquipGemSlotUnlockAskWraperHelper BagRpcEquipGemSlotUnlockAskWraperVar;
	public BagRpcEquipEnhanceSwapAskWraperHelper BagRpcEquipEnhanceSwapAskWraperVar;
	public BagRpcEquipGemRemoveAskWraperHelper BagRpcEquipGemRemoveAskWraperVar;
	public BagRpcBagPutInStorageAskWraperHelper BagRpcBagPutInStorageAskWraperVar;
	public BagRpcBagFetchFromStorageAskWraperHelper BagRpcBagFetchFromStorageAskWraperVar;
	public BagRpcBagStorageSaveMoneyAskWraperHelper BagRpcBagStorageSaveMoneyAskWraperVar;
	public BagRpcBagStorageDrawMoneyAskWraperHelper BagRpcBagStorageDrawMoneyAskWraperVar;
	public BagRpcStorageTidyAskWraperHelper BagRpcStorageTidyAskWraperVar;
	public BagRpcTalismanLvupAskWraperHelper BagRpcTalismanLvupAskWraperVar;
	public BagRpcTalismanInheritAskWraperHelper BagRpcTalismanInheritAskWraperVar;
	public BagRpcBagAddNewItemNotifyWraperHelper BagRpcBagAddNewItemNotifyWraperVar;
	public BagRpcBagSetAutoPickupAskWraperHelper BagRpcBagSetAutoPickupAskWraperVar;
	public BagRpcGetNewItemNotifyWraperHelper BagRpcGetNewItemNotifyWraperVar;
	public BagRpcBagErrorNotifyWraperHelper BagRpcBagErrorNotifyWraperVar;
	public BagRpcTalismanRefindStarAskWraperHelper BagRpcTalismanRefindStarAskWraperVar;
	public BagRpcTalismanUpSlotSkillLevelAskWraperHelper BagRpcTalismanUpSlotSkillLevelAskWraperVar;
	public BagRpcTalismanAttrChangeNotifyWraperHelper BagRpcTalismanAttrChangeNotifyWraperVar;
	public BagRpcTalismanGatherSpriteAskWraperHelper BagRpcTalismanGatherSpriteAskWraperVar;


	public void TestSyncData()
	{
		BagRPC.Instance.SyncData(delegate(object obj){});
	}
	public void TestSell()
	{
		BagRPC.Instance.Sell(BagRpcSellAskWraperVar.ItemID,BagRpcSellAskWraperVar.Pos,BagRpcSellAskWraperVar.Num,delegate(object obj){});
	}
	public void TestDecompose()
	{
		BagRPC.Instance.Decompose(BagRpcDecomposeAskWraperVar.ItemID,BagRpcDecomposeAskWraperVar.Pos,delegate(object obj){});
	}
	public void TestUse()
	{
		BagRPC.Instance.Use(BagRpcUseAskWraperVar.ItemID,BagRpcUseAskWraperVar.Pos,delegate(object obj){});
	}
	public void TestEquipWear()
	{
		BagRPC.Instance.EquipWear(BagRpcEquipWearAskWraperVar.ItemId,BagRpcEquipWearAskWraperVar.BagPos,delegate(object obj){});
	}
	public void TestEquipUndress()
	{
		BagRPC.Instance.EquipUndress(BagRpcEquipUndressAskWraperVar.ItemId,BagRpcEquipUndressAskWraperVar.EquipPos,delegate(object obj){});
	}
	public void TestEquipEnhance()
	{
		BagRPC.Instance.EquipEnhance(BagRpcEquipEnhanceAskWraperVar.ItemId,BagRpcEquipEnhanceAskWraperVar.Pos,BagRpcEquipEnhanceAskWraperVar.BagContainerType,BagRpcEquipEnhanceAskWraperVar.Lv,delegate(object obj){});
	}
	public void TestEquipPolished()
	{
		BagRPC.Instance.EquipPolished(BagRpcEquipPolishedAskWraperVar.ItemId,BagRpcEquipPolishedAskWraperVar.Pos,BagRpcEquipPolishedAskWraperVar.BagContainerType,delegate(object obj){});
	}
	public void TestEquipPolishedReplace()
	{
		BagRPC.Instance.EquipPolishedReplace(BagRpcEquipPolishedReplaceAskWraperVar.ItemId,BagRpcEquipPolishedReplaceAskWraperVar.Pos,BagRpcEquipPolishedReplaceAskWraperVar.BagContainerType,delegate(object obj){});
	}
	public void TestBagTidy()
	{
		BagRPC.Instance.BagTidy(delegate(object obj){});
	}
	public void TestBagRecycleSell()
	{
		BagRPC.Instance.BagRecycleSell(BagRpcBagRecycleSellAskWraperVar.GridList,delegate(object obj){});
	}
	public void TestBagRecycleBuy()
	{
		BagRPC.Instance.BagRecycleBuy(BagRpcBagRecycleBuyAskWraperVar.GridPos,delegate(object obj){});
	}
	public void TestUnlockGrid()
	{
		BagRPC.Instance.UnlockGrid(BagRpcUnlockGridAskWraperVar.GridCount,delegate(object obj){});
	}
	public void TestSplit()
	{
		BagRPC.Instance.Split(BagRpcSplitAskWraperVar.TemplateId,BagRpcSplitAskWraperVar.Pos,BagRpcSplitAskWraperVar.Num,delegate(object obj){});
	}
	public void TestEquipBaseAttrPlished()
	{
		BagRPC.Instance.EquipBaseAttrPlished(BagRpcEquipBaseAttrPlishedAskWraperVar.TemplateId,BagRpcEquipBaseAttrPlishedAskWraperVar.Pos,BagRpcEquipBaseAttrPlishedAskWraperVar.BagContainerType,delegate(object obj){});
	}
	public void TestEquipBaseAttrPolishedReplace()
	{
		BagRPC.Instance.EquipBaseAttrPolishedReplace(BagRpcEquipBaseAttrPolishedReplaceAskWraperVar.TemplateId,BagRpcEquipBaseAttrPolishedReplaceAskWraperVar.Pos,BagRpcEquipBaseAttrPolishedReplaceAskWraperVar.BagContainerType,delegate(object obj){});
	}
	public void TestEquipExAttrModify()
	{
		BagRPC.Instance.EquipExAttrModify(BagRpcEquipExAttrModifyAskWraperVar.TemplateId,BagRpcEquipExAttrModifyAskWraperVar.Pos,BagRpcEquipExAttrModifyAskWraperVar.BagContainerType,delegate(object obj){});
	}
	public void TestEquipInlayGem()
	{
		BagRPC.Instance.EquipInlayGem(BagRpcEquipInlayGemAskWraperVar.TemplateId,BagRpcEquipInlayGemAskWraperVar.Pos,BagRpcEquipInlayGemAskWraperVar.BagContainerType,BagRpcEquipInlayGemAskWraperVar.SlotPos,BagRpcEquipInlayGemAskWraperVar.GemId,BagRpcEquipInlayGemAskWraperVar.GemPos,delegate(object obj){});
	}
	public void TestEquipGemSlotUnlock()
	{
		BagRPC.Instance.EquipGemSlotUnlock(BagRpcEquipGemSlotUnlockAskWraperVar.TemplateId,BagRpcEquipGemSlotUnlockAskWraperVar.Pos,BagRpcEquipGemSlotUnlockAskWraperVar.BagContainerType,BagRpcEquipGemSlotUnlockAskWraperVar.SlotPos,delegate(object obj){});
	}
	public void TestEquipEnhanceSwap()
	{
		BagRPC.Instance.EquipEnhanceSwap(BagRpcEquipEnhanceSwapAskWraperVar.TemplateId1,BagRpcEquipEnhanceSwapAskWraperVar.Pos1,BagRpcEquipEnhanceSwapAskWraperVar.TemplateId2,BagRpcEquipEnhanceSwapAskWraperVar.Pos2,BagRpcEquipEnhanceSwapAskWraperVar.BagContainerType1,BagRpcEquipEnhanceSwapAskWraperVar.BagContainerType2,delegate(object obj){});
	}
	public void TestEquipGemRemove()
	{
		BagRPC.Instance.EquipGemRemove(BagRpcEquipGemRemoveAskWraperVar.TemplateId,BagRpcEquipGemRemoveAskWraperVar.Pos,BagRpcEquipGemRemoveAskWraperVar.BagContainerType,BagRpcEquipGemRemoveAskWraperVar.SlotPos,delegate(object obj){});
	}
	public void TestBagPutInStorage()
	{
		BagRPC.Instance.BagPutInStorage(BagRpcBagPutInStorageAskWraperVar.TemplateId,BagRpcBagPutInStorageAskWraperVar.Pos,BagRpcBagPutInStorageAskWraperVar.Num,delegate(object obj){});
	}
	public void TestBagFetchFromStorage()
	{
		BagRPC.Instance.BagFetchFromStorage(BagRpcBagFetchFromStorageAskWraperVar.TemplateId,BagRpcBagFetchFromStorageAskWraperVar.Pos,BagRpcBagFetchFromStorageAskWraperVar.Num,delegate(object obj){});
	}
	public void TestBagStorageSaveMoney()
	{
		BagRPC.Instance.BagStorageSaveMoney(BagRpcBagStorageSaveMoneyAskWraperVar.Money,delegate(object obj){});
	}
	public void TestBagStorageDrawMoney()
	{
		BagRPC.Instance.BagStorageDrawMoney(BagRpcBagStorageDrawMoneyAskWraperVar.Money,delegate(object obj){});
	}
	public void TestStorageTidy()
	{
		BagRPC.Instance.StorageTidy(delegate(object obj){});
	}
	public void TestTalismanLvup()
	{
		BagRPC.Instance.TalismanLvup(BagRpcTalismanLvupAskWraperVar.CostTalisman,delegate(object obj){});
	}
	public void TestTalismanInherit()
	{
		BagRPC.Instance.TalismanInherit(BagRpcTalismanInheritAskWraperVar.RightSideTalisman,delegate(object obj){});
	}
	public void TestBagSetAutoPickup()
	{
		BagRPC.Instance.BagSetAutoPickup(BagRpcBagSetAutoPickupAskWraperVar.AutoPick,delegate(object obj){});
	}
	public void TestTalismanRefindStar()
	{
		BagRPC.Instance.TalismanRefindStar(BagRpcTalismanRefindStarAskWraperVar.FabaoId,delegate(object obj){});
	}
	public void TestTalismanUpSlotSkillLevel()
	{
		BagRPC.Instance.TalismanUpSlotSkillLevel(BagRpcTalismanUpSlotSkillLevelAskWraperVar.FabaoId,BagRpcTalismanUpSlotSkillLevelAskWraperVar.SlotId,delegate(object obj){});
	}
	public void TestTalismanGatherSprite()
	{
		BagRPC.Instance.TalismanGatherSprite(BagRpcTalismanGatherSpriteAskWraperVar.FabaoId,BagRpcTalismanGatherSpriteAskWraperVar.GatherSpriteId,BagRpcTalismanGatherSpriteAskWraperVar.SlotId,delegate(object obj){});
	}


}

[CustomEditor(typeof(BagTestHelper))]
public class BagTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
		if (GUILayout.Button("SyncData"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestSyncData();
		}
		if (GUILayout.Button("Sell"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestSell();
		}
		if (GUILayout.Button("Decompose"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestDecompose();
		}
		if (GUILayout.Button("Use"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestUse();
		}
		if (GUILayout.Button("EquipWear"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipWear();
		}
		if (GUILayout.Button("EquipUndress"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipUndress();
		}
		if (GUILayout.Button("EquipEnhance"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipEnhance();
		}
		if (GUILayout.Button("EquipPolished"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipPolished();
		}
		if (GUILayout.Button("EquipPolishedReplace"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipPolishedReplace();
		}
		if (GUILayout.Button("BagTidy"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagTidy();
		}
		if (GUILayout.Button("BagRecycleSell"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagRecycleSell();
		}
		if (GUILayout.Button("BagRecycleBuy"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagRecycleBuy();
		}
		if (GUILayout.Button("UnlockGrid"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestUnlockGrid();
		}
		if (GUILayout.Button("Split"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestSplit();
		}
		if (GUILayout.Button("EquipBaseAttrPlished"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipBaseAttrPlished();
		}
		if (GUILayout.Button("EquipBaseAttrPolishedReplace"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipBaseAttrPolishedReplace();
		}
		if (GUILayout.Button("EquipExAttrModify"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipExAttrModify();
		}
		if (GUILayout.Button("EquipInlayGem"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipInlayGem();
		}
		if (GUILayout.Button("EquipGemSlotUnlock"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipGemSlotUnlock();
		}
		if (GUILayout.Button("EquipEnhanceSwap"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipEnhanceSwap();
		}
		if (GUILayout.Button("EquipGemRemove"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestEquipGemRemove();
		}
		if (GUILayout.Button("BagPutInStorage"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagPutInStorage();
		}
		if (GUILayout.Button("BagFetchFromStorage"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagFetchFromStorage();
		}
		if (GUILayout.Button("BagStorageSaveMoney"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagStorageSaveMoney();
		}
		if (GUILayout.Button("BagStorageDrawMoney"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagStorageDrawMoney();
		}
		if (GUILayout.Button("StorageTidy"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestStorageTidy();
		}
		if (GUILayout.Button("TalismanLvup"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestTalismanLvup();
		}
		if (GUILayout.Button("TalismanInherit"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestTalismanInherit();
		}
		if (GUILayout.Button("BagSetAutoPickup"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestBagSetAutoPickup();
		}
		if (GUILayout.Button("TalismanRefindStar"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestTalismanRefindStar();
		}
		if (GUILayout.Button("TalismanUpSlotSkillLevel"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestTalismanUpSlotSkillLevel();
		}
		if (GUILayout.Button("TalismanGatherSprite"))
		{
			BagTestHelper rpc = target as BagTestHelper;
			if( rpc ) rpc.TestTalismanGatherSprite();
		}


    }

}
#endif