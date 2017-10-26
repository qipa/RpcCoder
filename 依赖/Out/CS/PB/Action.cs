using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleKernel
{
    //战斗核心动作枚举
    public enum KernelActionE
    {
        ACTION_NOOP = 0,
        ACTION_USESKILL, //使用技能动作
        ACTION_BUFF, //BUFF操作动作类
        ACTION_CHARHIT, //攻击动作
        ACTION_OFFLINE, //断线动作
        ACTION_STATE, //状态机动作
        ACTION_CHARDEAD, //角色死亡动作
        ACTION_CHARREVIVE, //角色复活动作
        ACTION_COMBOSKILL, //连击技能动作
        ACTION_ENDSKILL, //结束技能动作
        ACTION_CITY, //主城状态同步
        ACTION_SNIPE, //狙击动作
        ACTION_HURT, //伤害动作
        ACTION_DODGE, //闪避动作
        ACTION_REMOVEOBJ, //删除对像
        ACTION_STORMBASE, //暴风基地信息
        ACTION_STORMRES, //暴风资源信息
        ACTION_STORMFLAG, //暴风旗信息
        ACTION_STORMCAMP, //暴风阵营信息
        ACTION_STORMRESULT, //暴风战斗结果信息
        ACTION_CREATE, //创建对像动作
        ACTION_QUICKFINISH, //快速杀怪动作
        ACTION_FINISHLEVEL, //节点或副本结束
        ACTION_TOWERLOCK, //塔锁定对象动作
        ACTION_STORMSTART, //暴风战斗开始
        ACTION_ESCAPESTART, //大逃杀开始
        ACTION_ESCAPERESULT, //大逃杀结果
        ACTION_GMADDHP, //GM加减血量
        ACTION_TRANDSKILL, //所有人随机放技能
        ACTION_GUILDDBEGIN, //帮会副本开始
        ACTION_GUILDDEND, //帮会副本结束
        ACTION_TRANSFER, //场景间传送
        ACTION_HEROFIGHTINFO, //英雄战斗信息
        ACTION_GUILDFIGHTBEGIN, //帮会战开始
        ACTION_GUILDFIGHTEND, //帮会战结束
        ACTION_GUILDFIGHTHP, //帮会战阵营血量信息
        ACTION_EFFECTTRANSLATE, //移动控制动作
        ACTION_COLLECT, //采集
        ACTION_COLLECTIONSHOWEFFECT, //采集物是否播特效
        ACTION_AUTOFIGHT, //自动战斗
        ACTION_USEITEM, //使用道具
        ACTION_STORMKILLEFFECT, //五行旗杀人特效
        ACTION_ONEVSONESTART, //1V1开始
        ACTION_ONEVSONERESULT, //1V1结果
        ACTION_SIGHT, //视野变化
        ACTION_EVENTTRIGGER, //事件触发
        ACTION_QUIT, //QuitAction
        ACTION_PRODUCT, //生产
        ACTION_STARTEND, //开始结束

    }

    public class ActionPoolManager {

        private static ActionPoolManager _instance;

        public static ActionPoolManager GetInstance() { 
            if (_instance == null) {
                _instance = new ActionPoolManager();
            }
            return _instance;
        }

        private Ex.ObjectPool<UseSkillAction> UseSkillActionPool = new Ex.ObjectPool<UseSkillAction>();
        private Ex.ObjectPool<BuffAction> BuffActionPool = new Ex.ObjectPool<BuffAction>();
        private Ex.ObjectPool<CharHitAction> CharHitActionPool = new Ex.ObjectPool<CharHitAction>();
        private Ex.ObjectPool<OfflineAction> OfflineActionPool = new Ex.ObjectPool<OfflineAction>();
        private Ex.ObjectPool<StateAction> StateActionPool = new Ex.ObjectPool<StateAction>();
        private Ex.ObjectPool<CharDeadAction> CharDeadActionPool = new Ex.ObjectPool<CharDeadAction>();
        private Ex.ObjectPool<CharReviveAction> CharReviveActionPool = new Ex.ObjectPool<CharReviveAction>();
        private Ex.ObjectPool<ComboSkillAction> ComboSkillActionPool = new Ex.ObjectPool<ComboSkillAction>();
        private Ex.ObjectPool<EndSkillAction> EndSkillActionPool = new Ex.ObjectPool<EndSkillAction>();
        private Ex.ObjectPool<CityAction> CityActionPool = new Ex.ObjectPool<CityAction>();
        private Ex.ObjectPool<SnipeAction> SnipeActionPool = new Ex.ObjectPool<SnipeAction>();
        private Ex.ObjectPool<HurtAction> HurtActionPool = new Ex.ObjectPool<HurtAction>();
        private Ex.ObjectPool<DodgeAction> DodgeActionPool = new Ex.ObjectPool<DodgeAction>();
        private Ex.ObjectPool<RemoveObjAction> RemoveObjActionPool = new Ex.ObjectPool<RemoveObjAction>();
        private Ex.ObjectPool<StormBaseAction> StormBaseActionPool = new Ex.ObjectPool<StormBaseAction>();
        private Ex.ObjectPool<StormResAction> StormResActionPool = new Ex.ObjectPool<StormResAction>();
        private Ex.ObjectPool<StormFlagAction> StormFlagActionPool = new Ex.ObjectPool<StormFlagAction>();
        private Ex.ObjectPool<StormCampAction> StormCampActionPool = new Ex.ObjectPool<StormCampAction>();
        private Ex.ObjectPool<StormResultAction> StormResultActionPool = new Ex.ObjectPool<StormResultAction>();
        private Ex.ObjectPool<CreateAction> CreateActionPool = new Ex.ObjectPool<CreateAction>();
        private Ex.ObjectPool<QuickFinishAction> QuickFinishActionPool = new Ex.ObjectPool<QuickFinishAction>();
        private Ex.ObjectPool<FinishLevelAction> FinishLevelActionPool = new Ex.ObjectPool<FinishLevelAction>();
        private Ex.ObjectPool<TowerLockAction> TowerLockActionPool = new Ex.ObjectPool<TowerLockAction>();
        private Ex.ObjectPool<StormStartAction> StormStartActionPool = new Ex.ObjectPool<StormStartAction>();
        private Ex.ObjectPool<EscapeStartAction> EscapeStartActionPool = new Ex.ObjectPool<EscapeStartAction>();
        private Ex.ObjectPool<EscapeResultAction> EscapeResultActionPool = new Ex.ObjectPool<EscapeResultAction>();
        private Ex.ObjectPool<GMAddHpAction> GMAddHpActionPool = new Ex.ObjectPool<GMAddHpAction>();
        private Ex.ObjectPool<TRandSkillAction> TRandSkillActionPool = new Ex.ObjectPool<TRandSkillAction>();
        private Ex.ObjectPool<GuildDBeginAction> GuildDBeginActionPool = new Ex.ObjectPool<GuildDBeginAction>();
        private Ex.ObjectPool<GuildDEndAction> GuildDEndActionPool = new Ex.ObjectPool<GuildDEndAction>();
        private Ex.ObjectPool<TransferAction> TransferActionPool = new Ex.ObjectPool<TransferAction>();
        private Ex.ObjectPool<HeroFightInfoAction> HeroFightInfoActionPool = new Ex.ObjectPool<HeroFightInfoAction>();
        private Ex.ObjectPool<GuildFightBeginAction> GuildFightBeginActionPool = new Ex.ObjectPool<GuildFightBeginAction>();
        private Ex.ObjectPool<GuildFightEndAction> GuildFightEndActionPool = new Ex.ObjectPool<GuildFightEndAction>();
        private Ex.ObjectPool<GuildFightHpAction> GuildFightHpActionPool = new Ex.ObjectPool<GuildFightHpAction>();
        private Ex.ObjectPool<EffectTranslateAction> EffectTranslateActionPool = new Ex.ObjectPool<EffectTranslateAction>();
        private Ex.ObjectPool<CollectAction> CollectActionPool = new Ex.ObjectPool<CollectAction>();
        private Ex.ObjectPool<CollectionShowEffectAction> CollectionShowEffectActionPool = new Ex.ObjectPool<CollectionShowEffectAction>();
        private Ex.ObjectPool<AutoFightAction> AutoFightActionPool = new Ex.ObjectPool<AutoFightAction>();
        private Ex.ObjectPool<UseItemAction> UseItemActionPool = new Ex.ObjectPool<UseItemAction>();
        private Ex.ObjectPool<StormKillEffectAction> StormKillEffectActionPool = new Ex.ObjectPool<StormKillEffectAction>();
        private Ex.ObjectPool<OneVSOneStartAction> OneVSOneStartActionPool = new Ex.ObjectPool<OneVSOneStartAction>();
        private Ex.ObjectPool<OneVSOneResultAction> OneVSOneResultActionPool = new Ex.ObjectPool<OneVSOneResultAction>();
        private Ex.ObjectPool<SightAction> SightActionPool = new Ex.ObjectPool<SightAction>();
        private Ex.ObjectPool<EventTriggerAction> EventTriggerActionPool = new Ex.ObjectPool<EventTriggerAction>();
        private Ex.ObjectPool<QuitAction> QuitActionPool = new Ex.ObjectPool<QuitAction>();
        private Ex.ObjectPool<ProductAction> ProductActionPool = new Ex.ObjectPool<ProductAction>();
        private Ex.ObjectPool<StartEndAction> StartEndActionPool = new Ex.ObjectPool<StartEndAction>();


        public Action CreateAction(KernelActionE actionType)
        {
            if (actionType == KernelActionE.ACTION_USESKILL) return UseSkillActionPool.New();
            if (actionType == KernelActionE.ACTION_BUFF) return BuffActionPool.New();
            if (actionType == KernelActionE.ACTION_CHARHIT) return CharHitActionPool.New();
            if (actionType == KernelActionE.ACTION_OFFLINE) return OfflineActionPool.New();
            if (actionType == KernelActionE.ACTION_STATE) return StateActionPool.New();
            if (actionType == KernelActionE.ACTION_CHARDEAD) return CharDeadActionPool.New();
            if (actionType == KernelActionE.ACTION_CHARREVIVE) return CharReviveActionPool.New();
            if (actionType == KernelActionE.ACTION_COMBOSKILL) return ComboSkillActionPool.New();
            if (actionType == KernelActionE.ACTION_ENDSKILL) return EndSkillActionPool.New();
            if (actionType == KernelActionE.ACTION_CITY) return CityActionPool.New();
            if (actionType == KernelActionE.ACTION_SNIPE) return SnipeActionPool.New();
            if (actionType == KernelActionE.ACTION_HURT) return HurtActionPool.New();
            if (actionType == KernelActionE.ACTION_DODGE) return DodgeActionPool.New();
            if (actionType == KernelActionE.ACTION_REMOVEOBJ) return RemoveObjActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMBASE) return StormBaseActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMRES) return StormResActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMFLAG) return StormFlagActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMCAMP) return StormCampActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMRESULT) return StormResultActionPool.New();
            if (actionType == KernelActionE.ACTION_CREATE) return CreateActionPool.New();
            if (actionType == KernelActionE.ACTION_QUICKFINISH) return QuickFinishActionPool.New();
            if (actionType == KernelActionE.ACTION_FINISHLEVEL) return FinishLevelActionPool.New();
            if (actionType == KernelActionE.ACTION_TOWERLOCK) return TowerLockActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMSTART) return StormStartActionPool.New();
            if (actionType == KernelActionE.ACTION_ESCAPESTART) return EscapeStartActionPool.New();
            if (actionType == KernelActionE.ACTION_ESCAPERESULT) return EscapeResultActionPool.New();
            if (actionType == KernelActionE.ACTION_GMADDHP) return GMAddHpActionPool.New();
            if (actionType == KernelActionE.ACTION_TRANDSKILL) return TRandSkillActionPool.New();
            if (actionType == KernelActionE.ACTION_GUILDDBEGIN) return GuildDBeginActionPool.New();
            if (actionType == KernelActionE.ACTION_GUILDDEND) return GuildDEndActionPool.New();
            if (actionType == KernelActionE.ACTION_TRANSFER) return TransferActionPool.New();
            if (actionType == KernelActionE.ACTION_HEROFIGHTINFO) return HeroFightInfoActionPool.New();
            if (actionType == KernelActionE.ACTION_GUILDFIGHTBEGIN) return GuildFightBeginActionPool.New();
            if (actionType == KernelActionE.ACTION_GUILDFIGHTEND) return GuildFightEndActionPool.New();
            if (actionType == KernelActionE.ACTION_GUILDFIGHTHP) return GuildFightHpActionPool.New();
            if (actionType == KernelActionE.ACTION_EFFECTTRANSLATE) return EffectTranslateActionPool.New();
            if (actionType == KernelActionE.ACTION_COLLECT) return CollectActionPool.New();
            if (actionType == KernelActionE.ACTION_COLLECTIONSHOWEFFECT) return CollectionShowEffectActionPool.New();
            if (actionType == KernelActionE.ACTION_AUTOFIGHT) return AutoFightActionPool.New();
            if (actionType == KernelActionE.ACTION_USEITEM) return UseItemActionPool.New();
            if (actionType == KernelActionE.ACTION_STORMKILLEFFECT) return StormKillEffectActionPool.New();
            if (actionType == KernelActionE.ACTION_ONEVSONESTART) return OneVSOneStartActionPool.New();
            if (actionType == KernelActionE.ACTION_ONEVSONERESULT) return OneVSOneResultActionPool.New();
            if (actionType == KernelActionE.ACTION_SIGHT) return SightActionPool.New();
            if (actionType == KernelActionE.ACTION_EVENTTRIGGER) return EventTriggerActionPool.New();
            if (actionType == KernelActionE.ACTION_QUIT) return QuitActionPool.New();
            if (actionType == KernelActionE.ACTION_PRODUCT) return ProductActionPool.New();
            if (actionType == KernelActionE.ACTION_STARTEND) return StartEndActionPool.New();

            return null;
        }

        public void StoreAction(Action action)
        {
            if (action is UseSkillAction) UseSkillActionPool.Store(action as UseSkillAction);
            if (action is BuffAction) BuffActionPool.Store(action as BuffAction);
            if (action is CharHitAction) CharHitActionPool.Store(action as CharHitAction);
            if (action is OfflineAction) OfflineActionPool.Store(action as OfflineAction);
            if (action is StateAction) StateActionPool.Store(action as StateAction);
            if (action is CharDeadAction) CharDeadActionPool.Store(action as CharDeadAction);
            if (action is CharReviveAction) CharReviveActionPool.Store(action as CharReviveAction);
            if (action is ComboSkillAction) ComboSkillActionPool.Store(action as ComboSkillAction);
            if (action is EndSkillAction) EndSkillActionPool.Store(action as EndSkillAction);
            if (action is CityAction) CityActionPool.Store(action as CityAction);
            if (action is SnipeAction) SnipeActionPool.Store(action as SnipeAction);
            if (action is HurtAction) HurtActionPool.Store(action as HurtAction);
            if (action is DodgeAction) DodgeActionPool.Store(action as DodgeAction);
            if (action is RemoveObjAction) RemoveObjActionPool.Store(action as RemoveObjAction);
            if (action is StormBaseAction) StormBaseActionPool.Store(action as StormBaseAction);
            if (action is StormResAction) StormResActionPool.Store(action as StormResAction);
            if (action is StormFlagAction) StormFlagActionPool.Store(action as StormFlagAction);
            if (action is StormCampAction) StormCampActionPool.Store(action as StormCampAction);
            if (action is StormResultAction) StormResultActionPool.Store(action as StormResultAction);
            if (action is CreateAction) CreateActionPool.Store(action as CreateAction);
            if (action is QuickFinishAction) QuickFinishActionPool.Store(action as QuickFinishAction);
            if (action is FinishLevelAction) FinishLevelActionPool.Store(action as FinishLevelAction);
            if (action is TowerLockAction) TowerLockActionPool.Store(action as TowerLockAction);
            if (action is StormStartAction) StormStartActionPool.Store(action as StormStartAction);
            if (action is EscapeStartAction) EscapeStartActionPool.Store(action as EscapeStartAction);
            if (action is EscapeResultAction) EscapeResultActionPool.Store(action as EscapeResultAction);
            if (action is GMAddHpAction) GMAddHpActionPool.Store(action as GMAddHpAction);
            if (action is TRandSkillAction) TRandSkillActionPool.Store(action as TRandSkillAction);
            if (action is GuildDBeginAction) GuildDBeginActionPool.Store(action as GuildDBeginAction);
            if (action is GuildDEndAction) GuildDEndActionPool.Store(action as GuildDEndAction);
            if (action is TransferAction) TransferActionPool.Store(action as TransferAction);
            if (action is HeroFightInfoAction) HeroFightInfoActionPool.Store(action as HeroFightInfoAction);
            if (action is GuildFightBeginAction) GuildFightBeginActionPool.Store(action as GuildFightBeginAction);
            if (action is GuildFightEndAction) GuildFightEndActionPool.Store(action as GuildFightEndAction);
            if (action is GuildFightHpAction) GuildFightHpActionPool.Store(action as GuildFightHpAction);
            if (action is EffectTranslateAction) EffectTranslateActionPool.Store(action as EffectTranslateAction);
            if (action is CollectAction) CollectActionPool.Store(action as CollectAction);
            if (action is CollectionShowEffectAction) CollectionShowEffectActionPool.Store(action as CollectionShowEffectAction);
            if (action is AutoFightAction) AutoFightActionPool.Store(action as AutoFightAction);
            if (action is UseItemAction) UseItemActionPool.Store(action as UseItemAction);
            if (action is StormKillEffectAction) StormKillEffectActionPool.Store(action as StormKillEffectAction);
            if (action is OneVSOneStartAction) OneVSOneStartActionPool.Store(action as OneVSOneStartAction);
            if (action is OneVSOneResultAction) OneVSOneResultActionPool.Store(action as OneVSOneResultAction);
            if (action is SightAction) SightActionPool.Store(action as SightAction);
            if (action is EventTriggerAction) EventTriggerActionPool.Store(action as EventTriggerAction);
            if (action is QuitAction) QuitActionPool.Store(action as QuitAction);
            if (action is ProductAction) ProductActionPool.Store(action as ProductAction);
            if (action is StartEndAction) StartEndActionPool.Store(action as StartEndAction);

        }

    }

    public abstract class Action : Ex.IResetable
    {
        public Action()
        {
            ActionType = KernelActionE.ACTION_NOOP;
        }
        public virtual MemoryStream GetWraperStream()
        {
            return new MemoryStream();
        }
        public virtual void SetWraperStream(MemoryStream ms)
        {
        }
        public virtual int Serialize(MemoryStream ms)
        {
            MemoryStream tmpStream = new MemoryStream();
            Int16 Len = 0;
            tmpStream.Write(BitConverter.GetBytes(Len), 0, 2);
            tmpStream.WriteByte(m_ActionType);
            tmpStream.Write(BitConverter.GetBytes(m_OccurTime), 0, 4);
            byte[] dataArr = GetWraperStream().ToArray();
            tmpStream.Write(dataArr, 0, dataArr.Length);
            Len = (Int16)tmpStream.Length;
            tmpStream.Position = 0;
            tmpStream.Write(BitConverter.GetBytes(Len), 0, 2);

            ms.Write(tmpStream.ToArray(), 0, (int)tmpStream.Length);
            return (int)tmpStream.Length;
        }
        public void Create(byte[] buf)
        {
            OccurTime = BitConverter.ToInt32(buf, 1);
            SetWraperStream(new MemoryStream(buf, 5, buf.Length - 5));
        }

        public static Action Deserialize(byte[] buf)
        {
            try 
            {
                KernelActionE aType = (KernelActionE)buf[0];
                switch (aType)
                {
                    case KernelActionE.ACTION_USESKILL:
                        UseSkillAction objUseSkillAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_USESKILL) as UseSkillAction;
                        objUseSkillAction.Create(buf);
                        return objUseSkillAction;
                    case KernelActionE.ACTION_BUFF:
                        BuffAction objBuffAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_BUFF) as BuffAction;
                        objBuffAction.Create(buf);
                        return objBuffAction;
                    case KernelActionE.ACTION_CHARHIT:
                        CharHitAction objCharHitAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_CHARHIT) as CharHitAction;
                        objCharHitAction.Create(buf);
                        return objCharHitAction;
                    case KernelActionE.ACTION_OFFLINE:
                        OfflineAction objOfflineAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_OFFLINE) as OfflineAction;
                        objOfflineAction.Create(buf);
                        return objOfflineAction;
                    case KernelActionE.ACTION_STATE:
                        StateAction objStateAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STATE) as StateAction;
                        objStateAction.Create(buf);
                        return objStateAction;
                    case KernelActionE.ACTION_CHARDEAD:
                        CharDeadAction objCharDeadAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_CHARDEAD) as CharDeadAction;
                        objCharDeadAction.Create(buf);
                        return objCharDeadAction;
                    case KernelActionE.ACTION_CHARREVIVE:
                        CharReviveAction objCharReviveAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_CHARREVIVE) as CharReviveAction;
                        objCharReviveAction.Create(buf);
                        return objCharReviveAction;
                    case KernelActionE.ACTION_COMBOSKILL:
                        ComboSkillAction objComboSkillAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_COMBOSKILL) as ComboSkillAction;
                        objComboSkillAction.Create(buf);
                        return objComboSkillAction;
                    case KernelActionE.ACTION_ENDSKILL:
                        EndSkillAction objEndSkillAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_ENDSKILL) as EndSkillAction;
                        objEndSkillAction.Create(buf);
                        return objEndSkillAction;
                    case KernelActionE.ACTION_CITY:
                        CityAction objCityAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_CITY) as CityAction;
                        objCityAction.Create(buf);
                        return objCityAction;
                    case KernelActionE.ACTION_SNIPE:
                        SnipeAction objSnipeAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_SNIPE) as SnipeAction;
                        objSnipeAction.Create(buf);
                        return objSnipeAction;
                    case KernelActionE.ACTION_HURT:
                        HurtAction objHurtAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_HURT) as HurtAction;
                        objHurtAction.Create(buf);
                        return objHurtAction;
                    case KernelActionE.ACTION_DODGE:
                        DodgeAction objDodgeAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_DODGE) as DodgeAction;
                        objDodgeAction.Create(buf);
                        return objDodgeAction;
                    case KernelActionE.ACTION_REMOVEOBJ:
                        RemoveObjAction objRemoveObjAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_REMOVEOBJ) as RemoveObjAction;
                        objRemoveObjAction.Create(buf);
                        return objRemoveObjAction;
                    case KernelActionE.ACTION_STORMBASE:
                        StormBaseAction objStormBaseAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMBASE) as StormBaseAction;
                        objStormBaseAction.Create(buf);
                        return objStormBaseAction;
                    case KernelActionE.ACTION_STORMRES:
                        StormResAction objStormResAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMRES) as StormResAction;
                        objStormResAction.Create(buf);
                        return objStormResAction;
                    case KernelActionE.ACTION_STORMFLAG:
                        StormFlagAction objStormFlagAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMFLAG) as StormFlagAction;
                        objStormFlagAction.Create(buf);
                        return objStormFlagAction;
                    case KernelActionE.ACTION_STORMCAMP:
                        StormCampAction objStormCampAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMCAMP) as StormCampAction;
                        objStormCampAction.Create(buf);
                        return objStormCampAction;
                    case KernelActionE.ACTION_STORMRESULT:
                        StormResultAction objStormResultAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMRESULT) as StormResultAction;
                        objStormResultAction.Create(buf);
                        return objStormResultAction;
                    case KernelActionE.ACTION_CREATE:
                        CreateAction objCreateAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_CREATE) as CreateAction;
                        objCreateAction.Create(buf);
                        return objCreateAction;
                    case KernelActionE.ACTION_QUICKFINISH:
                        QuickFinishAction objQuickFinishAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_QUICKFINISH) as QuickFinishAction;
                        objQuickFinishAction.Create(buf);
                        return objQuickFinishAction;
                    case KernelActionE.ACTION_FINISHLEVEL:
                        FinishLevelAction objFinishLevelAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_FINISHLEVEL) as FinishLevelAction;
                        objFinishLevelAction.Create(buf);
                        return objFinishLevelAction;
                    case KernelActionE.ACTION_TOWERLOCK:
                        TowerLockAction objTowerLockAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_TOWERLOCK) as TowerLockAction;
                        objTowerLockAction.Create(buf);
                        return objTowerLockAction;
                    case KernelActionE.ACTION_STORMSTART:
                        StormStartAction objStormStartAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMSTART) as StormStartAction;
                        objStormStartAction.Create(buf);
                        return objStormStartAction;
                    case KernelActionE.ACTION_ESCAPESTART:
                        EscapeStartAction objEscapeStartAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_ESCAPESTART) as EscapeStartAction;
                        objEscapeStartAction.Create(buf);
                        return objEscapeStartAction;
                    case KernelActionE.ACTION_ESCAPERESULT:
                        EscapeResultAction objEscapeResultAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_ESCAPERESULT) as EscapeResultAction;
                        objEscapeResultAction.Create(buf);
                        return objEscapeResultAction;
                    case KernelActionE.ACTION_GMADDHP:
                        GMAddHpAction objGMAddHpAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_GMADDHP) as GMAddHpAction;
                        objGMAddHpAction.Create(buf);
                        return objGMAddHpAction;
                    case KernelActionE.ACTION_TRANDSKILL:
                        TRandSkillAction objTRandSkillAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_TRANDSKILL) as TRandSkillAction;
                        objTRandSkillAction.Create(buf);
                        return objTRandSkillAction;
                    case KernelActionE.ACTION_GUILDDBEGIN:
                        GuildDBeginAction objGuildDBeginAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_GUILDDBEGIN) as GuildDBeginAction;
                        objGuildDBeginAction.Create(buf);
                        return objGuildDBeginAction;
                    case KernelActionE.ACTION_GUILDDEND:
                        GuildDEndAction objGuildDEndAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_GUILDDEND) as GuildDEndAction;
                        objGuildDEndAction.Create(buf);
                        return objGuildDEndAction;
                    case KernelActionE.ACTION_TRANSFER:
                        TransferAction objTransferAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_TRANSFER) as TransferAction;
                        objTransferAction.Create(buf);
                        return objTransferAction;
                    case KernelActionE.ACTION_HEROFIGHTINFO:
                        HeroFightInfoAction objHeroFightInfoAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_HEROFIGHTINFO) as HeroFightInfoAction;
                        objHeroFightInfoAction.Create(buf);
                        return objHeroFightInfoAction;
                    case KernelActionE.ACTION_GUILDFIGHTBEGIN:
                        GuildFightBeginAction objGuildFightBeginAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_GUILDFIGHTBEGIN) as GuildFightBeginAction;
                        objGuildFightBeginAction.Create(buf);
                        return objGuildFightBeginAction;
                    case KernelActionE.ACTION_GUILDFIGHTEND:
                        GuildFightEndAction objGuildFightEndAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_GUILDFIGHTEND) as GuildFightEndAction;
                        objGuildFightEndAction.Create(buf);
                        return objGuildFightEndAction;
                    case KernelActionE.ACTION_GUILDFIGHTHP:
                        GuildFightHpAction objGuildFightHpAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_GUILDFIGHTHP) as GuildFightHpAction;
                        objGuildFightHpAction.Create(buf);
                        return objGuildFightHpAction;
                    case KernelActionE.ACTION_EFFECTTRANSLATE:
                        EffectTranslateAction objEffectTranslateAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_EFFECTTRANSLATE) as EffectTranslateAction;
                        objEffectTranslateAction.Create(buf);
                        return objEffectTranslateAction;
                    case KernelActionE.ACTION_COLLECT:
                        CollectAction objCollectAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_COLLECT) as CollectAction;
                        objCollectAction.Create(buf);
                        return objCollectAction;
                    case KernelActionE.ACTION_COLLECTIONSHOWEFFECT:
                        CollectionShowEffectAction objCollectionShowEffectAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_COLLECTIONSHOWEFFECT) as CollectionShowEffectAction;
                        objCollectionShowEffectAction.Create(buf);
                        return objCollectionShowEffectAction;
                    case KernelActionE.ACTION_AUTOFIGHT:
                        AutoFightAction objAutoFightAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_AUTOFIGHT) as AutoFightAction;
                        objAutoFightAction.Create(buf);
                        return objAutoFightAction;
                    case KernelActionE.ACTION_USEITEM:
                        UseItemAction objUseItemAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_USEITEM) as UseItemAction;
                        objUseItemAction.Create(buf);
                        return objUseItemAction;
                    case KernelActionE.ACTION_STORMKILLEFFECT:
                        StormKillEffectAction objStormKillEffectAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STORMKILLEFFECT) as StormKillEffectAction;
                        objStormKillEffectAction.Create(buf);
                        return objStormKillEffectAction;
                    case KernelActionE.ACTION_ONEVSONESTART:
                        OneVSOneStartAction objOneVSOneStartAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_ONEVSONESTART) as OneVSOneStartAction;
                        objOneVSOneStartAction.Create(buf);
                        return objOneVSOneStartAction;
                    case KernelActionE.ACTION_ONEVSONERESULT:
                        OneVSOneResultAction objOneVSOneResultAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_ONEVSONERESULT) as OneVSOneResultAction;
                        objOneVSOneResultAction.Create(buf);
                        return objOneVSOneResultAction;
                    case KernelActionE.ACTION_SIGHT:
                        SightAction objSightAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_SIGHT) as SightAction;
                        objSightAction.Create(buf);
                        return objSightAction;
                    case KernelActionE.ACTION_EVENTTRIGGER:
                        EventTriggerAction objEventTriggerAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_EVENTTRIGGER) as EventTriggerAction;
                        objEventTriggerAction.Create(buf);
                        return objEventTriggerAction;
                    case KernelActionE.ACTION_QUIT:
                        QuitAction objQuitAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_QUIT) as QuitAction;
                        objQuitAction.Create(buf);
                        return objQuitAction;
                    case KernelActionE.ACTION_PRODUCT:
                        ProductAction objProductAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_PRODUCT) as ProductAction;
                        objProductAction.Create(buf);
                        return objProductAction;
                    case KernelActionE.ACTION_STARTEND:
                        StartEndAction objStartEndAction = ActionPoolManager.GetInstance().CreateAction(KernelActionE.ACTION_STARTEND) as StartEndAction;
                        objStartEndAction.Create(buf);
                        return objStartEndAction;

                    default:
                        break;
                }
            }
            catch( Exception e )
            {
                e.GetType();
            }
            return null;
        }

        public Int32 OccurTime
        {
            get { return m_OccurTime; }
            set { m_OccurTime = value; }
        }
        public KernelActionE ActionType
        {
            set { m_ActionType = (byte)value; }
            get { return (KernelActionE)m_ActionType; }
        }
        protected byte m_ActionType = 0;
        protected Int32 m_OccurTime = 0;

        public virtual void New()
        {
            ActionType = KernelActionE.ACTION_NOOP;
            m_OccurTime = 0;
        }

        public virtual void Reset()
        {
            ActionType = KernelActionE.ACTION_NOOP;
            m_OccurTime = 0;
        }
    }

    //使用技能动作
    public class UseSkillAction : FightUseSkillActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_USESKILL;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //BUFF操作动作类
    public class BuffAction : FightBuffActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_BUFF;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //攻击动作
    public class CharHitAction : FightCharHitActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_CHARHIT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //断线动作
    public class OfflineAction : FightOfflineActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_OFFLINE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //状态机动作
    public class StateAction : FightStateActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STATE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //角色死亡动作
    public class CharDeadAction : FightCharDeadActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_CHARDEAD;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //角色复活动作
    public class CharReviveAction : FightCharReviveActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_CHARREVIVE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //连击技能动作
    public class ComboSkillAction : FightComboSkillActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_COMBOSKILL;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //结束技能动作
    public class EndSkillAction : FightEndSkillActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_ENDSKILL;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //主城状态同步
    public class CityAction : FightCityActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_CITY;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //狙击动作
    public class SnipeAction : FightSnipeActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_SNIPE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //伤害动作
    public class HurtAction : FightHurtActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_HURT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //闪避动作
    public class DodgeAction : FightDodgeActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_DODGE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //删除对像
    public class RemoveObjAction : FightRemoveObjActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_REMOVEOBJ;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //暴风基地信息
    public class StormBaseAction : FightStormBaseActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMBASE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //暴风资源信息
    public class StormResAction : FightStormResActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMRES;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //暴风旗信息
    public class StormFlagAction : FightStormFlagActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMFLAG;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //暴风阵营信息
    public class StormCampAction : FightStormCampActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMCAMP;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //暴风战斗结果信息
    public class StormResultAction : FightStormResultActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMRESULT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //创建对像动作
    public class CreateAction : FightCreateActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_CREATE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //快速杀怪动作
    public class QuickFinishAction : FightQuickFinishActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_QUICKFINISH;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //节点或副本结束
    public class FinishLevelAction : FightFinishLevelActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_FINISHLEVEL;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //塔锁定对象动作
    public class TowerLockAction : FightTowerLockActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_TOWERLOCK;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //暴风战斗开始
    public class StormStartAction : FightStormStartActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMSTART;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //大逃杀开始
    public class EscapeStartAction : FightEscapeStartActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_ESCAPESTART;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //大逃杀结果
    public class EscapeResultAction : FightEscapeResultActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_ESCAPERESULT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //GM加减血量
    public class GMAddHpAction : FightGMAddHpActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_GMADDHP;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //所有人随机放技能
    public class TRandSkillAction : FightTRandSkillActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_TRANDSKILL;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //帮会副本开始
    public class GuildDBeginAction : FightGuildDBeginActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_GUILDDBEGIN;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //帮会副本结束
    public class GuildDEndAction : FightGuildDEndActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_GUILDDEND;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //场景间传送
    public class TransferAction : FightTransferActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_TRANSFER;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //英雄战斗信息
    public class HeroFightInfoAction : FightHeroFightInfoActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_HEROFIGHTINFO;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //帮会战开始
    public class GuildFightBeginAction : FightGuildFightBeginActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_GUILDFIGHTBEGIN;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //帮会战结束
    public class GuildFightEndAction : FightGuildFightEndActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_GUILDFIGHTEND;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //帮会战阵营血量信息
    public class GuildFightHpAction : FightGuildFightHpActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_GUILDFIGHTHP;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //移动控制动作
    public class EffectTranslateAction : FightEffectTranslateActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_EFFECTTRANSLATE;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //采集
    public class CollectAction : FightCollectActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_COLLECT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //采集物是否播特效
    public class CollectionShowEffectAction : FightCollectionShowEffectActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_COLLECTIONSHOWEFFECT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //自动战斗
    public class AutoFightAction : FightAutoFightActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_AUTOFIGHT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //使用道具
    public class UseItemAction : FightUseItemActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_USEITEM;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //五行旗杀人特效
    public class StormKillEffectAction : FightStormKillEffectActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STORMKILLEFFECT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //1V1开始
    public class OneVSOneStartAction : FightOneVSOneStartActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_ONEVSONESTART;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //1V1结果
    public class OneVSOneResultAction : FightOneVSOneResultActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_ONEVSONERESULT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //视野变化
    public class SightAction : FightSightActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_SIGHT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //事件触发
    public class EventTriggerAction : FightEventTriggerActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_EVENTTRIGGER;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //QuitAction
    public class QuitAction : FightQuitActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_QUIT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //生产
    public class ProductAction : FightProductActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_PRODUCT;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }
    //开始结束
    public class StartEndAction : FightStartEndActionWraper
    {
        public override MemoryStream GetWraperStream()
        {
            return ToMemoryStream();
        }
        public override void SetWraperStream(MemoryStream ms)
        {
            FromMemoryStream(ms);
        }
        public override void New()
        {
            base.New();
            ActionType = KernelActionE.ACTION_STARTEND;
        }
        public override void Reset()
        {
            base.Reset();
            ResetWraper();
        }
    }


}
