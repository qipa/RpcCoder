
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBBaseAttr.cs
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


//同步玩家数据请求封装类
[System.Serializable]
public class BaseAttrRpcSyncDataAskWraper
{

	//构造函数
	public BaseAttrRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcSyncDataAsk ToPB()
	{
		BaseAttrRpcSyncDataAsk v = new BaseAttrRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//同步玩家数据回应封装类
[System.Serializable]
public class BaseAttrRpcSyncDataReplyWraper
{

	//构造函数
	public BaseAttrRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcSyncDataReply ToPB()
	{
		BaseAttrRpcSyncDataReply v = new BaseAttrRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcSyncDataReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//领取官阶奖励请求封装类
[System.Serializable]
public class BaseAttrRpcGetRankRewardAskWraper
{

	//构造函数
	public BaseAttrRpcGetRankRewardAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcGetRankRewardAsk ToPB()
	{
		BaseAttrRpcGetRankRewardAsk v = new BaseAttrRpcGetRankRewardAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcGetRankRewardAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcGetRankRewardAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcGetRankRewardAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcGetRankRewardAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//领取官阶奖励回应封装类
[System.Serializable]
public class BaseAttrRpcGetRankRewardReplyWraper
{

	//构造函数
	public BaseAttrRpcGetRankRewardReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcGetRankRewardReply ToPB()
	{
		BaseAttrRpcGetRankRewardReply v = new BaseAttrRpcGetRankRewardReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcGetRankRewardReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcGetRankRewardReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcGetRankRewardReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcGetRankRewardReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//提升官阶请求封装类
[System.Serializable]
public class BaseAttrRpcUpGradeRankAskWraper
{

	//构造函数
	public BaseAttrRpcUpGradeRankAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcUpGradeRankAsk ToPB()
	{
		BaseAttrRpcUpGradeRankAsk v = new BaseAttrRpcUpGradeRankAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcUpGradeRankAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcUpGradeRankAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcUpGradeRankAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcUpGradeRankAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//提升官阶回应封装类
[System.Serializable]
public class BaseAttrRpcUpGradeRankReplyWraper
{

	//构造函数
	public BaseAttrRpcUpGradeRankReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcUpGradeRankReply ToPB()
	{
		BaseAttrRpcUpGradeRankReply v = new BaseAttrRpcUpGradeRankReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcUpGradeRankReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcUpGradeRankReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcUpGradeRankReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcUpGradeRankReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//选人请求封装类
[System.Serializable]
public class BaseAttrRpcChooseRoleAskWraper
{

	//构造函数
	public BaseAttrRpcChooseRoleAskWraper()
	{
		 m_Prof = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Prof = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcChooseRoleAsk ToPB()
	{
		BaseAttrRpcChooseRoleAsk v = new BaseAttrRpcChooseRoleAsk();
		v.Prof = m_Prof;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcChooseRoleAsk v)
	{
        if (v == null)
            return;
		m_Prof = v.Prof;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcChooseRoleAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcChooseRoleAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcChooseRoleAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}


};
//选人回应封装类
[System.Serializable]
public class BaseAttrRpcChooseRoleReplyWraper
{

	//构造函数
	public BaseAttrRpcChooseRoleReplyWraper()
	{
		 m_Result = -9999;
		 m_Prof = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Prof = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcChooseRoleReply ToPB()
	{
		BaseAttrRpcChooseRoleReply v = new BaseAttrRpcChooseRoleReply();
		v.Result = m_Result;
		v.Prof = m_Prof;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcChooseRoleReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Prof = v.Prof;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcChooseRoleReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcChooseRoleReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcChooseRoleReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}


};
//升级请求封装类
[System.Serializable]
public class BaseAttrRpcLevelUpAskWraper
{

	//构造函数
	public BaseAttrRpcLevelUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcLevelUpAsk ToPB()
	{
		BaseAttrRpcLevelUpAsk v = new BaseAttrRpcLevelUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcLevelUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcLevelUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcLevelUpAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcLevelUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//升级回应封装类
[System.Serializable]
public class BaseAttrRpcLevelUpReplyWraper
{

	//构造函数
	public BaseAttrRpcLevelUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcLevelUpReply ToPB()
	{
		BaseAttrRpcLevelUpReply v = new BaseAttrRpcLevelUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcLevelUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcLevelUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcLevelUpReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcLevelUpReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//获取时间请求封装类
[System.Serializable]
public class BaseAttrRpcGetTimerAskWraper
{

	//构造函数
	public BaseAttrRpcGetTimerAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcGetTimerAsk ToPB()
	{
		BaseAttrRpcGetTimerAsk v = new BaseAttrRpcGetTimerAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcGetTimerAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcGetTimerAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcGetTimerAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcGetTimerAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//获取时间回应封装类
[System.Serializable]
public class BaseAttrRpcGetTimerReplyWraper
{

	//构造函数
	public BaseAttrRpcGetTimerReplyWraper()
	{
		 m_Result = -9999;
		 m_Timer = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Timer = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcGetTimerReply ToPB()
	{
		BaseAttrRpcGetTimerReply v = new BaseAttrRpcGetTimerReply();
		v.Result = m_Result;
		v.Timer = m_Timer;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcGetTimerReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Timer = v.Timer;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcGetTimerReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcGetTimerReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcGetTimerReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}
	//时间
	public long m_Timer;
	public long Timer
	{
		get { return m_Timer;}
		set { m_Timer = value; }
	}


};
//复活请求封装类
[System.Serializable]
public class BaseAttrRpcReviveAskWraper
{

	//构造函数
	public BaseAttrRpcReviveAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcReviveAsk ToPB()
	{
		BaseAttrRpcReviveAsk v = new BaseAttrRpcReviveAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcReviveAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcReviveAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcReviveAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcReviveAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//复活回应封装类
[System.Serializable]
public class BaseAttrRpcReviveReplyWraper
{

	//构造函数
	public BaseAttrRpcReviveReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcReviveReply ToPB()
	{
		BaseAttrRpcReviveReply v = new BaseAttrRpcReviveReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcReviveReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcReviveReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcReviveReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcReviveReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//查询装备数据请求封装类
[System.Serializable]
public class BaseAttrRpcQueryEquipAskWraper
{

	//构造函数
	public BaseAttrRpcQueryEquipAskWraper()
	{
		 m_UserId = -1;
		 m_Pos = -1;
		 m_TemplateID = -1;
		 m_Index = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_Pos = -1;
		 m_TemplateID = -1;
		 m_Index = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcQueryEquipAsk ToPB()
	{
		BaseAttrRpcQueryEquipAsk v = new BaseAttrRpcQueryEquipAsk();
		v.UserId = m_UserId;
		v.Pos = m_Pos;
		v.TemplateID = m_TemplateID;
		v.Index = m_Index;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcQueryEquipAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_Pos = v.Pos;
		m_TemplateID = v.TemplateID;
		m_Index = v.Index;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcQueryEquipAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcQueryEquipAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcQueryEquipAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//物品的配置Id
	public int m_TemplateID;
	public int TemplateID
	{
		get { return m_TemplateID;}
		set { m_TemplateID = value; }
	}
	//实例id，唯一id
	public long m_Index;
	public long Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}


};
//查询装备数据回应封装类
[System.Serializable]
public class BaseAttrRpcQueryEquipReplyWraper
{

	//构造函数
	public BaseAttrRpcQueryEquipReplyWraper()
	{
		 m_Result = -9999;
		 m_EquipData = new BagEquipObjWraper();
		 m_GridData = new BaseAttrRpcGridInfoWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_EquipData = new BagEquipObjWraper();
		 m_GridData = new BaseAttrRpcGridInfoWraper();

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcQueryEquipReply ToPB()
	{
		BaseAttrRpcQueryEquipReply v = new BaseAttrRpcQueryEquipReply();
		v.Result = m_Result;
		v.EquipData = m_EquipData.ToPB();
		v.GridData = m_GridData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcQueryEquipReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_EquipData.FromPB(v.EquipData);
		m_GridData.FromPB(v.GridData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcQueryEquipReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcQueryEquipReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcQueryEquipReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}
	//装备数据
	public BagEquipObjWraper m_EquipData;
	public BagEquipObjWraper EquipData
	{
		get { return m_EquipData;}
		set { m_EquipData = value; }
	}
	//背包格子
	public BaseAttrRpcGridInfoWraper m_GridData;
	public BaseAttrRpcGridInfoWraper GridData
	{
		get { return m_GridData;}
		set { m_GridData = value; }
	}


};
//更新新手引导请求封装类
[System.Serializable]
public class BaseAttrRpcUpdateNewbieGuideAskWraper
{

	//构造函数
	public BaseAttrRpcUpdateNewbieGuideAskWraper()
	{
		 m_GroupId = -1;
		 m_Step = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GroupId = -1;
		 m_Step = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcUpdateNewbieGuideAsk ToPB()
	{
		BaseAttrRpcUpdateNewbieGuideAsk v = new BaseAttrRpcUpdateNewbieGuideAsk();
		v.GroupId = m_GroupId;
		v.Step = m_Step;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcUpdateNewbieGuideAsk v)
	{
        if (v == null)
            return;
		m_GroupId = v.GroupId;
		m_Step = v.Step;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcUpdateNewbieGuideAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcUpdateNewbieGuideAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcUpdateNewbieGuideAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//组Id
	public int m_GroupId;
	public int GroupId
	{
		get { return m_GroupId;}
		set { m_GroupId = value; }
	}
	//步骤
	public int m_Step;
	public int Step
	{
		get { return m_Step;}
		set { m_Step = value; }
	}


};
//更新新手引导回应封装类
[System.Serializable]
public class BaseAttrRpcUpdateNewbieGuideReplyWraper
{

	//构造函数
	public BaseAttrRpcUpdateNewbieGuideReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcUpdateNewbieGuideReply ToPB()
	{
		BaseAttrRpcUpdateNewbieGuideReply v = new BaseAttrRpcUpdateNewbieGuideReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcUpdateNewbieGuideReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcUpdateNewbieGuideReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcUpdateNewbieGuideReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcUpdateNewbieGuideReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//背包格子封装类
[System.Serializable]
public class BaseAttrRpcGridInfoWraper
{

	//构造函数
	public BaseAttrRpcGridInfoWraper()
	{
		 m_TemplateID = -1;
		 m_Num = 0;
		 m_ItemType = -1;
		 m_Pos = -1;
		 m_Value = -1;
		 m_Index = -1;
		 m_Bind = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateID = -1;
		 m_Num = 0;
		 m_ItemType = -1;
		 m_Pos = -1;
		 m_Value = -1;
		 m_Index = -1;
		 m_Bind = false;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcGridInfo ToPB()
	{
		BaseAttrRpcGridInfo v = new BaseAttrRpcGridInfo();
		v.TemplateID = m_TemplateID;
		v.Num = m_Num;
		v.ItemType = m_ItemType;
		v.Pos = m_Pos;
		v.Value = m_Value;
		v.Index = m_Index;
		v.Bind = m_Bind;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcGridInfo v)
	{
        if (v == null)
            return;
		m_TemplateID = v.TemplateID;
		m_Num = v.Num;
		m_ItemType = v.ItemType;
		m_Pos = v.Pos;
		m_Value = v.Value;
		m_Index = v.Index;
		m_Bind = v.Bind;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcGridInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcGridInfo pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcGridInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品的配置Id
	public int m_TemplateID;
	public int TemplateID
	{
		get { return m_TemplateID;}
		set { m_TemplateID = value; }
	}
	//物品数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}
	//物品类型
	public int m_ItemType;
	public int ItemType
	{
		get { return m_ItemType;}
		set { m_ItemType = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//客户端通用数据
	public int m_Value;
	public int Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}
	//实例id，唯一id
	public long m_Index;
	public long Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}
	//绑定
	public bool m_Bind;
	public bool Bind
	{
		get { return m_Bind;}
		set { m_Bind = value; }
	}


};
//系统提示通知封装类
[System.Serializable]
public class BaseAttrRpcSysTipsNotifyWraper
{

	//构造函数
	public BaseAttrRpcSysTipsNotifyWraper()
	{
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcSysTipsNotify ToPB()
	{
		BaseAttrRpcSysTipsNotify v = new BaseAttrRpcSysTipsNotify();
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcSysTipsNotify v)
	{
        if (v == null)
            return;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcSysTipsNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcSysTipsNotify pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcSysTipsNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//配置Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//修改PK状态请求封装类
[System.Serializable]
public class BaseAttrRpcChangPKStateAskWraper
{

	//构造函数
	public BaseAttrRpcChangPKStateAskWraper()
	{
		 m_ChangState = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ChangState = -1;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcChangPKStateAsk ToPB()
	{
		BaseAttrRpcChangPKStateAsk v = new BaseAttrRpcChangPKStateAsk();
		v.ChangState = m_ChangState;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcChangPKStateAsk v)
	{
        if (v == null)
            return;
		m_ChangState = v.ChangState;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcChangPKStateAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcChangPKStateAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcChangPKStateAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//PK状态
	public int m_ChangState;
	public int ChangState
	{
		get { return m_ChangState;}
		set { m_ChangState = value; }
	}


};
//修改PK状态回应封装类
[System.Serializable]
public class BaseAttrRpcChangPKStateReplyWraper
{

	//构造函数
	public BaseAttrRpcChangPKStateReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcChangPKStateReply ToPB()
	{
		BaseAttrRpcChangPKStateReply v = new BaseAttrRpcChangPKStateReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcChangPKStateReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcChangPKStateReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcChangPKStateReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcChangPKStateReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//修改PK保护请求封装类
[System.Serializable]
public class BaseAttrRpcChangePKProtectAskWraper
{

	//构造函数
	public BaseAttrRpcChangePKProtectAskWraper()
	{
		m_ProtectList = new List<KeyValue2IntBoolWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_ProtectList = new List<KeyValue2IntBoolWraper>();

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcChangePKProtectAsk ToPB()
	{
		BaseAttrRpcChangePKProtectAsk v = new BaseAttrRpcChangePKProtectAsk();
		for (int i=0; i<(int)m_ProtectList.Count; i++)
			v.ProtectList.Add( m_ProtectList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcChangePKProtectAsk v)
	{
        if (v == null)
            return;
		m_ProtectList.Clear();
		for( int i=0; i<v.ProtectList.Count; i++)
			m_ProtectList.Add( new KeyValue2IntBoolWraper());
		for( int i=0; i<v.ProtectList.Count; i++)
			m_ProtectList[i].FromPB(v.ProtectList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcChangePKProtectAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcChangePKProtectAsk pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcChangePKProtectAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//保护列表
	public List<KeyValue2IntBoolWraper> m_ProtectList;
	public int SizeProtectList()
	{
		return m_ProtectList.Count;
	}
	public List<KeyValue2IntBoolWraper> GetProtectList()
	{
		return m_ProtectList;
	}
	public KeyValue2IntBoolWraper GetProtectList(int Index)
	{
		if(Index<0 || Index>=(int)m_ProtectList.Count)
			return new KeyValue2IntBoolWraper();
		return m_ProtectList[Index];
	}
	public void SetProtectList( List<KeyValue2IntBoolWraper> v )
	{
		m_ProtectList=v;
	}
	public void SetProtectList( int Index, KeyValue2IntBoolWraper v )
	{
		if(Index<0 || Index>=(int)m_ProtectList.Count)
			return;
		m_ProtectList[Index] = v;
	}
	public void AddProtectList( KeyValue2IntBoolWraper v )
	{
		m_ProtectList.Add(v);
	}
	public void ClearProtectList( )
	{
		m_ProtectList.Clear();
	}


};
//修改PK保护回应封装类
[System.Serializable]
public class BaseAttrRpcChangePKProtectReplyWraper
{

	//构造函数
	public BaseAttrRpcChangePKProtectReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public BaseAttrRpcChangePKProtectReply ToPB()
	{
		BaseAttrRpcChangePKProtectReply v = new BaseAttrRpcChangePKProtectReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BaseAttrRpcChangePKProtectReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BaseAttrRpcChangePKProtectReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BaseAttrRpcChangePKProtectReply pb = ProtoBuf.Serializer.Deserialize<BaseAttrRpcChangePKProtectReply>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
