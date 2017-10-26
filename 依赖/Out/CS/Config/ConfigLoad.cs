using UnityEngine;
using System.Collections;

public class ConfigLoad : MonoBehaviour {

	private string textContent;

	public IEnumerator LoadConfig () {

		yield return StartCoroutine(LoadData("AttackBehavior.csv"));
		AttackBehaviorTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BangHuiLvUp.csv"));
		BangHuiLvUpTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BangHuiManager.csv"));
		BangHuiManagerTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BangHuiXiuLian.csv"));
		BangHuiXiuLianTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BaoShiJiBan.csv"));
		BaoShiJiBanTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BaoShi.csv"));
		BaoShiTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BaseAI.csv"));
		BaseAITable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BASEConfig.csv"));
		BASEConfigTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("BuffPool.csv"));
		BuffPoolTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Buff.csv"));
		BuffTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("CargoReward.csv"));
		CargoRewardTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("CargoType.csv"));
		CargoTypeTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Cargo.csv"));
		CargoTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("ChatMsg.csv"));
		ChatMsgTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("ChengJiu.csv"));
		ChengJiuTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("CiTan.csv"));
		CiTanTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("CiTiao.csv"));
		CiTiaoTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Color.csv"));
		ColorTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("CopyList.csv"));
		CopyListTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Dialog.csv"));
		DialogTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Drop.csv"));
		DropTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Dungeons.csv"));
		DungeonsTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Equip.csv"));
		EquipTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("ExpandAI.csv"));
		ExpandAITable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("FaBaoSkill.csv"));
		FaBaoSkillTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("FaBaoStar.csv"));
		FaBaoStarTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("FaBao.csv"));
		FaBaoTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("FBDialog.csv"));
		FBDialogTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("FBEvent.csv"));
		FBEventTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Formula.csv"));
		FormulaTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Gather.csv"));
		GatherTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("GuideSteps.csv"));
		GuideStepsTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Guide.csv"));
		GuideTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Hero.csv"));
		HeroTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("HuoDong.csv"));
		HuoDongTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Item.csv"));
		ItemTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("JuLingLimit.csv"));
		JuLingLimitTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("JuLing.csv"));
		JuLingTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("LifeSkills.csv"));
		LifeSkillsTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Location.csv"));
		LocationTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("LVAttr.csv"));
		LVAttrTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("LvUp.csv"));
		LvUpTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("MailIcon.csv"));
		MailIconTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("MailMsg.csv"));
		MailMsgTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("MissionTiaoJian.csv"));
		MissionTiaoJianTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Mission.csv"));
		MissionTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("ModelBase.csv"));
		ModelBaseTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Monster.csv"));
		MonsterTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Npc.csv"));
		NpcTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("OneVSOneFlushTop.csv"));
		OneVSOneFlushTopTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("OneVSOneNumReward.csv"));
		OneVSOneNumRewardTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("OneVSOneTime.csv"));
		OneVSOneTimeTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("OneVSOneTopLV.csv"));
		OneVSOneTopLVTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("OneVSOneTopReward.csv"));
		OneVSOneTopRewardTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Phiz.csv"));
		PhizTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Produce.csv"));
		ProduceTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("QiangHua.csv"));
		QiangHuaTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("RandomName.csv"));
		RandomNameTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Ranking.csv"));
		RankingTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Revive.csv"));
		ReviveTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Reward.csv"));
		RewardTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Section.csv"));
		SectionTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("SensitiveWord.csv"));
		SensitiveWordTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("ShimenType.csv"));
		ShimenTypeTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("SkillConfig.csv"));
		SkillConfigTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("SkillLimit.csv"));
		SkillLimitTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Skill.csv"));
		SkillTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("SysIcon.csv"));
		SysIconTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Talent.csv"));
		TalentTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("TeamConfig.csv"));
		TeamConfigTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("TianFu.csv"));
		TianFuTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Trap.csv"));
		TrapTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Vitality.csv"));
		VitalityTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("WanFaConfig.csv"));
		WanFaConfigTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("WorldMap.csv"));
		WorldMapTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("YiTiaoLong.csv"));
		YiTiaoLongTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Localization.csv"));
		LocalizationTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("SysTips.csv"));
		SysTipsTable.Instance.LoadCsv(textContent);

		yield return StartCoroutine(LoadData("Plot.csv"));
		PlotTable.Instance.LoadCsv(textContent);



		yield return true;
	}

    IEnumerator LoadData (string name) {

		string path = Ex.Utils.GetStreamingAssetsFilePath(name, "CSV");
	
		WWW www = new WWW(path);
		yield return www;

		textContent = www.text;
		yield return true;
	}
}
