
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBBaseAttr.cs
Author:
Description:
Version:      1.0
History:
  <author>  <time>   <version >   <desc>

***********************************************************/
using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//技能CD信息封装类
[System.Serializable]
public class BaseAttrSkillCdInfoWraperV1
{

	//构造函数
	public BaseAttrSkillCdInfoWraperV1()
	{
		 m_SkillId = -1;
		 m_EndTime = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;
		 m_EndTime = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrSkillCdInfoV1 ToPB()
	{
		BaseAttrSkillCdInfoV1 v = new BaseAttrSkillCdInfoV1();
		v.SkillId = m_SkillId;
		v.EndTime = m_EndTime;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrSkillCdInfoV1 v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;
		m_EndTime = v.EndTime;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrSkillCdInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrSkillCdInfoV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrSkillCdInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//结束时间
	public int m_EndTime;
	public int EndTime
	{
		get { return m_EndTime;}
		set { m_EndTime = value; }
	}


};
//BuffCD信息封装类
[System.Serializable]
public class BaseAttrBuffCdInfoWraperV1
{

	//构造函数
	public BaseAttrBuffCdInfoWraperV1()
	{
		 m_BuffId = -1;
		 m_EndTime = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_BuffId = -1;
		 m_EndTime = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrBuffCdInfoV1 ToPB()
	{
		BaseAttrBuffCdInfoV1 v = new BaseAttrBuffCdInfoV1();
		v.BuffId = m_BuffId;
		v.EndTime = m_EndTime;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrBuffCdInfoV1 v)
	{
        if (v == null)
            return;
		m_BuffId = v.BuffId;
		m_EndTime = v.EndTime;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrBuffCdInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrBuffCdInfoV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrBuffCdInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//BuffId
	public int m_BuffId;
	public int BuffId
	{
		get { return m_BuffId;}
		set { m_BuffId = value; }
	}
	//结束时间
	public int m_EndTime;
	public int EndTime
	{
		get { return m_EndTime;}
		set { m_EndTime = value; }
	}


};
//场景信息封装类
[System.Serializable]
public class BaseAttrSceneInfoWraperV1
{

	//构造函数
	public BaseAttrSceneInfoWraperV1()
	{
		 m_RelateUserId = -1;
		 m_ReviveNeedMoney = -1;
		 m_ReviveNeedMoneyType = 0;
		 m_DungeonKey = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_RelateUserId = -1;
		 m_ReviveNeedMoney = -1;
		 m_ReviveNeedMoneyType = 0;
		 m_DungeonKey = "";

	}

 	//转化成Protobuffer类型函数
	public BaseAttrSceneInfoV1 ToPB()
	{
		BaseAttrSceneInfoV1 v = new BaseAttrSceneInfoV1();
		v.RelateUserId = m_RelateUserId;
		v.ReviveNeedMoney = m_ReviveNeedMoney;
		v.ReviveNeedMoneyType = m_ReviveNeedMoneyType;
		v.DungeonKey = m_DungeonKey;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrSceneInfoV1 v)
	{
        if (v == null)
            return;
		m_RelateUserId = v.RelateUserId;
		m_ReviveNeedMoney = v.ReviveNeedMoney;
		m_ReviveNeedMoneyType = v.ReviveNeedMoneyType;
		m_DungeonKey = v.DungeonKey;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrSceneInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrSceneInfoV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrSceneInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//关系的用户ID
	public long m_RelateUserId;
	public long RelateUserId
	{
		get { return m_RelateUserId;}
		set { m_RelateUserId = value; }
	}
	//复活需要的钱数
	public int m_ReviveNeedMoney;
	public int ReviveNeedMoney
	{
		get { return m_ReviveNeedMoney;}
		set { m_ReviveNeedMoney = value; }
	}
	//复活需要的货币类型
	public int m_ReviveNeedMoneyType;
	public int ReviveNeedMoneyType
	{
		get { return m_ReviveNeedMoneyType;}
		set { m_ReviveNeedMoneyType = value; }
	}
	//DungeonKey
	public string m_DungeonKey;
	public string DungeonKey
	{
		get { return m_DungeonKey;}
		set { m_DungeonKey = value; }
	}


};
//图标开启信息封装类
[System.Serializable]
public class BaseAttrIconOpenInfoWraperV1
{

	//构造函数
	public BaseAttrIconOpenInfoWraperV1()
	{
		 m_IconId = -1;
		 m_IsOpen = false;
		 m_IsShow = false;
		 m_IsNew = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_IconId = -1;
		 m_IsOpen = false;
		 m_IsShow = false;
		 m_IsNew = false;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrIconOpenInfoV1 ToPB()
	{
		BaseAttrIconOpenInfoV1 v = new BaseAttrIconOpenInfoV1();
		v.IconId = m_IconId;
		v.IsOpen = m_IsOpen;
		v.IsShow = m_IsShow;
		v.IsNew = m_IsNew;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrIconOpenInfoV1 v)
	{
        if (v == null)
            return;
		m_IconId = v.IconId;
		m_IsOpen = v.IsOpen;
		m_IsShow = v.IsShow;
		m_IsNew = v.IsNew;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrIconOpenInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrIconOpenInfoV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrIconOpenInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//图标ID
	public int m_IconId;
	public int IconId
	{
		get { return m_IconId;}
		set { m_IconId = value; }
	}
	//功能是否打开
	public bool m_IsOpen;
	public bool IsOpen
	{
		get { return m_IsOpen;}
		set { m_IsOpen = value; }
	}
	//是否显示
	public bool m_IsShow;
	public bool IsShow
	{
		get { return m_IsShow;}
		set { m_IsShow = value; }
	}
	//是否为新
	public bool m_IsNew;
	public bool IsNew
	{
		get { return m_IsNew;}
		set { m_IsNew = value; }
	}


};
//活力值信息封装类
[System.Serializable]
public class BaseAttrEnergyInfoWraperV1
{

	//构造函数
	public BaseAttrEnergyInfoWraperV1()
	{
		 m_EnergyId = -1;
		 m_EnergyValue = 0;
		 m_ReceivedEnergy = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_EnergyId = -1;
		 m_EnergyValue = 0;
		 m_ReceivedEnergy = 0;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrEnergyInfoV1 ToPB()
	{
		BaseAttrEnergyInfoV1 v = new BaseAttrEnergyInfoV1();
		v.EnergyId = m_EnergyId;
		v.EnergyValue = m_EnergyValue;
		v.ReceivedEnergy = m_ReceivedEnergy;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrEnergyInfoV1 v)
	{
        if (v == null)
            return;
		m_EnergyId = v.EnergyId;
		m_EnergyValue = v.EnergyValue;
		m_ReceivedEnergy = v.ReceivedEnergy;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrEnergyInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrEnergyInfoV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrEnergyInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//活力ID，表id
	public int m_EnergyId;
	public int EnergyId
	{
		get { return m_EnergyId;}
		set { m_EnergyId = value; }
	}
	//活力值
	public int m_EnergyValue;
	public int EnergyValue
	{
		get { return m_EnergyValue;}
		set { m_EnergyValue = value; }
	}
	//已获得活力值
	public int m_ReceivedEnergy;
	public int ReceivedEnergy
	{
		get { return m_ReceivedEnergy;}
		set { m_ReceivedEnergy = value; }
	}


};
//修炼信息封装类
[System.Serializable]
public class BaseAttrScienceInfoWraperV1
{

	//构造函数
	public BaseAttrScienceInfoWraperV1()
	{
		 m_ScienceId = -1;
		 m_ScienceCurExp = 0;
		 m_ScienceLv = -1;
		 m_ScienceCurMoney = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ScienceId = -1;
		 m_ScienceCurExp = 0;
		 m_ScienceLv = -1;
		 m_ScienceCurMoney = 0;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrScienceInfoV1 ToPB()
	{
		BaseAttrScienceInfoV1 v = new BaseAttrScienceInfoV1();
		v.ScienceId = m_ScienceId;
		v.ScienceCurExp = m_ScienceCurExp;
		v.ScienceLv = m_ScienceLv;
		v.ScienceCurMoney = m_ScienceCurMoney;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrScienceInfoV1 v)
	{
        if (v == null)
            return;
		m_ScienceId = v.ScienceId;
		m_ScienceCurExp = v.ScienceCurExp;
		m_ScienceLv = v.ScienceLv;
		m_ScienceCurMoney = v.ScienceCurMoney;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrScienceInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrScienceInfoV1 pb = ProtoBuf.Serializer.Deserialize<BaseAttrScienceInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//修炼属性Id
	public int m_ScienceId;
	public int ScienceId
	{
		get { return m_ScienceId;}
		set { m_ScienceId = value; }
	}
	//修炼经验
	public int m_ScienceCurExp;
	public int ScienceCurExp
	{
		get { return m_ScienceCurExp;}
		set { m_ScienceCurExp = value; }
	}
	//帮会修炼技能等级
	public int m_ScienceLv;
	public int ScienceLv
	{
		get { return m_ScienceLv;}
		set { m_ScienceLv = value; }
	}
	//未升级钱所消耗金币
	public int m_ScienceCurMoney;
	public int ScienceCurMoney
	{
		get { return m_ScienceCurMoney;}
		set { m_ScienceCurMoney = value; }
	}


};
