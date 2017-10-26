
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBSkill.cs
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


//数据同步请求封装类
[System.Serializable]
public class SkillRpcSyncDataAskWraper
{

	//构造函数
	public SkillRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public SkillRpcSyncDataAsk ToPB()
	{
		SkillRpcSyncDataAsk v = new SkillRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//数据同步回应封装类
[System.Serializable]
public class SkillRpcSyncDataReplyWraper
{

	//构造函数
	public SkillRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcSyncDataReply ToPB()
	{
		SkillRpcSyncDataReply v = new SkillRpcSyncDataReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcSyncDataReply>(protoMS);
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
//学习请求封装类
[System.Serializable]
public class SkillRpcLearnAskWraper
{

	//构造函数
	public SkillRpcLearnAskWraper()
	{
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcLearnAsk ToPB()
	{
		SkillRpcLearnAsk v = new SkillRpcLearnAsk();
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcLearnAsk v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcLearnAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcLearnAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcLearnAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//学习回应封装类
[System.Serializable]
public class SkillRpcLearnReplyWraper
{

	//构造函数
	public SkillRpcLearnReplyWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcLearnReply ToPB()
	{
		SkillRpcLearnReply v = new SkillRpcLearnReply();
		v.Result = m_Result;
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcLearnReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcLearnReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcLearnReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcLearnReply>(protoMS);
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
	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//升级请求封装类
[System.Serializable]
public class SkillRpcLvUpAskWraper
{

	//构造函数
	public SkillRpcLvUpAskWraper()
	{
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcLvUpAsk ToPB()
	{
		SkillRpcLvUpAsk v = new SkillRpcLvUpAsk();
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcLvUpAsk v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcLvUpAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//升级回应封装类
[System.Serializable]
public class SkillRpcLvUpReplyWraper
{

	//构造函数
	public SkillRpcLvUpReplyWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcLvUpReply ToPB()
	{
		SkillRpcLvUpReply v = new SkillRpcLvUpReply();
		v.Result = m_Result;
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcLvUpReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcLvUpReply>(protoMS);
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
	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//修改快捷栏请求封装类
[System.Serializable]
public class SkillRpcChangeShortcutAskWraper
{

	//构造函数
	public SkillRpcChangeShortcutAskWraper()
	{
		 m_SkillId = -1;
		 m_Pos = -1;
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;
		 m_Pos = -1;
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcChangeShortcutAsk ToPB()
	{
		SkillRpcChangeShortcutAsk v = new SkillRpcChangeShortcutAsk();
		v.SkillId = m_SkillId;
		v.Pos = m_Pos;
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcChangeShortcutAsk v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;
		m_Pos = v.Pos;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcChangeShortcutAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcChangeShortcutAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcChangeShortcutAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//方案1=0
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//修改快捷栏回应封装类
[System.Serializable]
public class SkillRpcChangeShortcutReplyWraper
{

	//构造函数
	public SkillRpcChangeShortcutReplyWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;
		 m_Pos = -1;
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;
		 m_Pos = -1;
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcChangeShortcutReply ToPB()
	{
		SkillRpcChangeShortcutReply v = new SkillRpcChangeShortcutReply();
		v.Result = m_Result;
		v.SkillId = m_SkillId;
		v.Pos = m_Pos;
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcChangeShortcutReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_SkillId = v.SkillId;
		m_Pos = v.Pos;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcChangeShortcutReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcChangeShortcutReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcChangeShortcutReply>(protoMS);
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
	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//方案1=0
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//使用技能方案请求封装类
[System.Serializable]
public class SkillRpcUseShortcutAskWraper
{

	//构造函数
	public SkillRpcUseShortcutAskWraper()
	{
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcUseShortcutAsk ToPB()
	{
		SkillRpcUseShortcutAsk v = new SkillRpcUseShortcutAsk();
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcUseShortcutAsk v)
	{
        if (v == null)
            return;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcUseShortcutAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcUseShortcutAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcUseShortcutAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//方案1=0
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//使用技能方案回应封装类
[System.Serializable]
public class SkillRpcUseShortcutReplyWraper
{

	//构造函数
	public SkillRpcUseShortcutReplyWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcUseShortcutReply ToPB()
	{
		SkillRpcUseShortcutReply v = new SkillRpcUseShortcutReply();
		v.Result = m_Result;
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcUseShortcutReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcUseShortcutReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcUseShortcutReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcUseShortcutReply>(protoMS);
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
	//方案1=0
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//一键升级请求封装类
[System.Serializable]
public class SkillRpcOneKeyLvUpAskWraper
{

	//构造函数
	public SkillRpcOneKeyLvUpAskWraper()
	{
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcOneKeyLvUpAsk ToPB()
	{
		SkillRpcOneKeyLvUpAsk v = new SkillRpcOneKeyLvUpAsk();
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcOneKeyLvUpAsk v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcOneKeyLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcOneKeyLvUpAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcOneKeyLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//一键升级回应封装类
[System.Serializable]
public class SkillRpcOneKeyLvUpReplyWraper
{

	//构造函数
	public SkillRpcOneKeyLvUpReplyWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcOneKeyLvUpReply ToPB()
	{
		SkillRpcOneKeyLvUpReply v = new SkillRpcOneKeyLvUpReply();
		v.Result = m_Result;
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcOneKeyLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcOneKeyLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcOneKeyLvUpReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcOneKeyLvUpReply>(protoMS);
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
	//技能Id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//天赋槽位切换技能请求封装类
[System.Serializable]
public class SkillRpcTalentChangeSkillAskWraper
{

	//构造函数
	public SkillRpcTalentChangeSkillAskWraper()
	{
		 m_Index = -1;
		 m_SkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Index = -1;
		 m_SkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentChangeSkillAsk ToPB()
	{
		SkillRpcTalentChangeSkillAsk v = new SkillRpcTalentChangeSkillAsk();
		v.Index = m_Index;
		v.SkillId = m_SkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentChangeSkillAsk v)
	{
        if (v == null)
            return;
		m_Index = v.Index;
		m_SkillId = v.SkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentChangeSkillAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentChangeSkillAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentChangeSkillAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//槽位索引
	public int m_Index;
	public int Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}
	//技能id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}


};
//天赋槽位切换技能回应封装类
[System.Serializable]
public class SkillRpcTalentChangeSkillReplyWraper
{

	//构造函数
	public SkillRpcTalentChangeSkillReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentChangeSkillReply ToPB()
	{
		SkillRpcTalentChangeSkillReply v = new SkillRpcTalentChangeSkillReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentChangeSkillReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentChangeSkillReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentChangeSkillReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentChangeSkillReply>(protoMS);
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
//天赋重置请求封装类
[System.Serializable]
public class SkillRpcTalentResetAskWraper
{

	//构造函数
	public SkillRpcTalentResetAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentResetAsk ToPB()
	{
		SkillRpcTalentResetAsk v = new SkillRpcTalentResetAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentResetAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentResetAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentResetAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentResetAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//天赋重置回应封装类
[System.Serializable]
public class SkillRpcTalentResetReplyWraper
{

	//构造函数
	public SkillRpcTalentResetReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentResetReply ToPB()
	{
		SkillRpcTalentResetReply v = new SkillRpcTalentResetReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentResetReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentResetReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentResetReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentResetReply>(protoMS);
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
//天赋升级对象封装类
[System.Serializable]
public class SkillRpcTalentLvObjWraper
{

	//构造函数
	public SkillRpcTalentLvObjWraper()
	{
		 m_Index = 0;
		 m_Level = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Index = 0;
		 m_Level = 0;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentLvObj ToPB()
	{
		SkillRpcTalentLvObj v = new SkillRpcTalentLvObj();
		v.Index = m_Index;
		v.Level = m_Level;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentLvObj v)
	{
        if (v == null)
            return;
		m_Index = v.Index;
		m_Level = v.Level;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentLvObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentLvObj pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentLvObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//槽位索引
	public int m_Index;
	public int Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}
	//槽位最终的等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}


};
//天赋槽位升级请求封装类
[System.Serializable]
public class SkillRpcTalentLvUpAskWraper
{

	//构造函数
	public SkillRpcTalentLvUpAskWraper()
	{
		m_Talent = new List<SkillRpcTalentLvObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_Talent = new List<SkillRpcTalentLvObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentLvUpAsk ToPB()
	{
		SkillRpcTalentLvUpAsk v = new SkillRpcTalentLvUpAsk();
		for (int i=0; i<(int)m_Talent.Count; i++)
			v.Talent.Add( m_Talent[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentLvUpAsk v)
	{
        if (v == null)
            return;
		m_Talent.Clear();
		for( int i=0; i<v.Talent.Count; i++)
			m_Talent.Add( new SkillRpcTalentLvObjWraper());
		for( int i=0; i<v.Talent.Count; i++)
			m_Talent[i].FromPB(v.Talent[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentLvUpAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//天赋
	public List<SkillRpcTalentLvObjWraper> m_Talent;
	public int SizeTalent()
	{
		return m_Talent.Count;
	}
	public List<SkillRpcTalentLvObjWraper> GetTalent()
	{
		return m_Talent;
	}
	public SkillRpcTalentLvObjWraper GetTalent(int Index)
	{
		if(Index<0 || Index>=(int)m_Talent.Count)
			return new SkillRpcTalentLvObjWraper();
		return m_Talent[Index];
	}
	public void SetTalent( List<SkillRpcTalentLvObjWraper> v )
	{
		m_Talent=v;
	}
	public void SetTalent( int Index, SkillRpcTalentLvObjWraper v )
	{
		if(Index<0 || Index>=(int)m_Talent.Count)
			return;
		m_Talent[Index] = v;
	}
	public void AddTalent( SkillRpcTalentLvObjWraper v )
	{
		m_Talent.Add(v);
	}
	public void ClearTalent( )
	{
		m_Talent.Clear();
	}


};
//天赋槽位升级回应封装类
[System.Serializable]
public class SkillRpcTalentLvUpReplyWraper
{

	//构造函数
	public SkillRpcTalentLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcTalentLvUpReply ToPB()
	{
		SkillRpcTalentLvUpReply v = new SkillRpcTalentLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcTalentLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcTalentLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcTalentLvUpReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcTalentLvUpReply>(protoMS);
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
//升级生活技能请求封装类
[System.Serializable]
public class SkillRpcLifeSkillUpAskWraper
{

	//构造函数
	public SkillRpcLifeSkillUpAskWraper()
	{
		 m_LifeSkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_LifeSkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcLifeSkillUpAsk ToPB()
	{
		SkillRpcLifeSkillUpAsk v = new SkillRpcLifeSkillUpAsk();
		v.LifeSkillId = m_LifeSkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcLifeSkillUpAsk v)
	{
        if (v == null)
            return;
		m_LifeSkillId = v.LifeSkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcLifeSkillUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcLifeSkillUpAsk pb = ProtoBuf.Serializer.Deserialize<SkillRpcLifeSkillUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//生活技能表id
	public int m_LifeSkillId;
	public int LifeSkillId
	{
		get { return m_LifeSkillId;}
		set { m_LifeSkillId = value; }
	}


};
//升级生活技能回应封装类
[System.Serializable]
public class SkillRpcLifeSkillUpReplyWraper
{

	//构造函数
	public SkillRpcLifeSkillUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public SkillRpcLifeSkillUpReply ToPB()
	{
		SkillRpcLifeSkillUpReply v = new SkillRpcLifeSkillUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillRpcLifeSkillUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillRpcLifeSkillUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillRpcLifeSkillUpReply pb = ProtoBuf.Serializer.Deserialize<SkillRpcLifeSkillUpReply>(protoMS);
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
