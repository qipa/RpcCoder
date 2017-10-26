
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBFight.cs
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


//准备就绪请求封装类
[System.Serializable]
public class FightRpcReadyAskWraper
{

	//构造函数
	public FightRpcReadyAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public FightRpcReadyAsk ToPB()
	{
		FightRpcReadyAsk v = new FightRpcReadyAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcReadyAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcReadyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcReadyAsk pb = ProtoBuf.Serializer.Deserialize<FightRpcReadyAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//准备就绪回应封装类
[System.Serializable]
public class FightRpcReadyReplyWraper
{

	//构造函数
	public FightRpcReadyReplyWraper()
	{
		 m_Result = -9999;
		 m_Tick = -1;
		 m_RandNum = -1;
		 m_IdHelper = -1;
		m_ActionArr = new List<byte[]>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Tick = -1;
		 m_RandNum = -1;
		 m_IdHelper = -1;
		m_ActionArr = new List<byte[]>();

	}

 	//转化成Protobuffer类型函数
	public FightRpcReadyReply ToPB()
	{
		FightRpcReadyReply v = new FightRpcReadyReply();
		v.Result = m_Result;
		v.Tick = m_Tick;
		v.RandNum = m_RandNum;
		v.IdHelper = m_IdHelper;
		for (int i=0; i<(int)m_ActionArr.Count; i++)
			v.ActionArr.Add( m_ActionArr[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcReadyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Tick = v.Tick;
		m_RandNum = v.RandNum;
		m_IdHelper = v.IdHelper;
		m_ActionArr.Clear();
		for( int i=0; i<v.ActionArr.Count; i++)
			m_ActionArr.Add(v.ActionArr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcReadyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcReadyReply pb = ProtoBuf.Serializer.Deserialize<FightRpcReadyReply>(protoMS);
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
	//当前Tick
	public int m_Tick;
	public int Tick
	{
		get { return m_Tick;}
		set { m_Tick = value; }
	}
	//当前随机数
	public int m_RandNum;
	public int RandNum
	{
		get { return m_RandNum;}
		set { m_RandNum = value; }
	}
	//ID管理器的值
	public int m_IdHelper;
	public int IdHelper
	{
		get { return m_IdHelper;}
		set { m_IdHelper = value; }
	}
	//创建的Action列表
	public List<byte[]> m_ActionArr;
	public int SizeActionArr()
	{
		return m_ActionArr.Count;
	}
	public List<byte[]> GetActionArr()
	{
		return m_ActionArr;
	}
	public byte[] GetActionArr(int Index)
	{
		if(Index<0 || Index>=(int)m_ActionArr.Count)
			return new byte[0];
		return m_ActionArr[Index];
	}
	public void SetActionArr( List<byte[]> v )
	{
		m_ActionArr=v;
	}
	public void SetActionArr( int Index, byte[] v )
	{
		if(Index<0 || Index>=(int)m_ActionArr.Count)
			return;
		m_ActionArr[Index] = v;
	}
	public void AddActionArr( byte[] v )
	{
		m_ActionArr.Add(v);
	}
	public void ClearActionArr( )
	{
		m_ActionArr.Clear();
	}


};
//动作通知封装类
[System.Serializable]
public class FightRpcActionNotifyWraper
{

	//构造函数
	public FightRpcActionNotifyWraper()
	{
		 m_Data = new byte[0];
		 m_Frame = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Data = new byte[0];
		 m_Frame = -1;

	}

 	//转化成Protobuffer类型函数
	public FightRpcActionNotify ToPB()
	{
		FightRpcActionNotify v = new FightRpcActionNotify();
		v.Data = m_Data;
		v.Frame = m_Frame;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcActionNotify v)
	{
        if (v == null)
            return;
		m_Data = v.Data;
		m_Frame = v.Frame;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcActionNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcActionNotify pb = ProtoBuf.Serializer.Deserialize<FightRpcActionNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//动作数据
	public byte[] m_Data;
	public byte[] Data
	{
		get { return m_Data;}
		set { m_Data = value; }
	}
	//当前帧号
	public int m_Frame;
	public int Frame
	{
		get { return m_Frame;}
		set { m_Frame = value; }
	}


};
//战斗结果通知封装类
[System.Serializable]
public class FightRpcResultNotifyWraper
{

	//构造函数
	public FightRpcResultNotifyWraper()
	{
		 m_Result = -1;
		 m_DengeonId = -1;
		 m_Star = -1;
		 m_FightTime = -1;
		m_PrizeList = new List<FightPrizeInfoWraper>();
		m_KillList = new List<FightKillInfoWraper>();
		 m_FirstStarLight = -1;
		 m_SecondStarLight = -1;
		 m_ThirdStarLight = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -1;
		 m_DengeonId = -1;
		 m_Star = -1;
		 m_FightTime = -1;
		m_PrizeList = new List<FightPrizeInfoWraper>();
		m_KillList = new List<FightKillInfoWraper>();
		 m_FirstStarLight = -1;
		 m_SecondStarLight = -1;
		 m_ThirdStarLight = -1;

	}

 	//转化成Protobuffer类型函数
	public FightRpcResultNotify ToPB()
	{
		FightRpcResultNotify v = new FightRpcResultNotify();
		v.Result = m_Result;
		v.DengeonId = m_DengeonId;
		v.Star = m_Star;
		v.FightTime = m_FightTime;
		for (int i=0; i<(int)m_PrizeList.Count; i++)
			v.PrizeList.Add( m_PrizeList[i].ToPB());
		for (int i=0; i<(int)m_KillList.Count; i++)
			v.KillList.Add( m_KillList[i].ToPB());
		v.FirstStarLight = m_FirstStarLight;
		v.SecondStarLight = m_SecondStarLight;
		v.ThirdStarLight = m_ThirdStarLight;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcResultNotify v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_DengeonId = v.DengeonId;
		m_Star = v.Star;
		m_FightTime = v.FightTime;
		m_PrizeList.Clear();
		for( int i=0; i<v.PrizeList.Count; i++)
			m_PrizeList.Add( new FightPrizeInfoWraper());
		for( int i=0; i<v.PrizeList.Count; i++)
			m_PrizeList[i].FromPB(v.PrizeList[i]);
		m_KillList.Clear();
		for( int i=0; i<v.KillList.Count; i++)
			m_KillList.Add( new FightKillInfoWraper());
		for( int i=0; i<v.KillList.Count; i++)
			m_KillList[i].FromPB(v.KillList[i]);
		m_FirstStarLight = v.FirstStarLight;
		m_SecondStarLight = v.SecondStarLight;
		m_ThirdStarLight = v.ThirdStarLight;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcResultNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcResultNotify pb = ProtoBuf.Serializer.Deserialize<FightRpcResultNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}
	//副本Id
	public int m_DengeonId;
	public int DengeonId
	{
		get { return m_DengeonId;}
		set { m_DengeonId = value; }
	}
	//星级
	public int m_Star;
	public int Star
	{
		get { return m_Star;}
		set { m_Star = value; }
	}
	//战斗时间
	public int m_FightTime;
	public int FightTime
	{
		get { return m_FightTime;}
		set { m_FightTime = value; }
	}
	//奖励列表
	public List<FightPrizeInfoWraper> m_PrizeList;
	public int SizePrizeList()
	{
		return m_PrizeList.Count;
	}
	public List<FightPrizeInfoWraper> GetPrizeList()
	{
		return m_PrizeList;
	}
	public FightPrizeInfoWraper GetPrizeList(int Index)
	{
		if(Index<0 || Index>=(int)m_PrizeList.Count)
			return new FightPrizeInfoWraper();
		return m_PrizeList[Index];
	}
	public void SetPrizeList( List<FightPrizeInfoWraper> v )
	{
		m_PrizeList=v;
	}
	public void SetPrizeList( int Index, FightPrizeInfoWraper v )
	{
		if(Index<0 || Index>=(int)m_PrizeList.Count)
			return;
		m_PrizeList[Index] = v;
	}
	public void AddPrizeList( FightPrizeInfoWraper v )
	{
		m_PrizeList.Add(v);
	}
	public void ClearPrizeList( )
	{
		m_PrizeList.Clear();
	}
	//杀戮列表
	public List<FightKillInfoWraper> m_KillList;
	public int SizeKillList()
	{
		return m_KillList.Count;
	}
	public List<FightKillInfoWraper> GetKillList()
	{
		return m_KillList;
	}
	public FightKillInfoWraper GetKillList(int Index)
	{
		if(Index<0 || Index>=(int)m_KillList.Count)
			return new FightKillInfoWraper();
		return m_KillList[Index];
	}
	public void SetKillList( List<FightKillInfoWraper> v )
	{
		m_KillList=v;
	}
	public void SetKillList( int Index, FightKillInfoWraper v )
	{
		if(Index<0 || Index>=(int)m_KillList.Count)
			return;
		m_KillList[Index] = v;
	}
	public void AddKillList( FightKillInfoWraper v )
	{
		m_KillList.Add(v);
	}
	public void ClearKillList( )
	{
		m_KillList.Clear();
	}
	//第一颗星是否亮了
	public int m_FirstStarLight;
	public int FirstStarLight
	{
		get { return m_FirstStarLight;}
		set { m_FirstStarLight = value; }
	}
	//第二颗星是否亮了
	public int m_SecondStarLight;
	public int SecondStarLight
	{
		get { return m_SecondStarLight;}
		set { m_SecondStarLight = value; }
	}
	//第三颗星是否亮了
	public int m_ThirdStarLight;
	public int ThirdStarLight
	{
		get { return m_ThirdStarLight;}
		set { m_ThirdStarLight = value; }
	}


};
//进入副本请求封装类
[System.Serializable]
public class FightRpcEnterAskWraper
{

	//构造函数
	public FightRpcEnterAskWraper()
	{
		 m_UserId = -1;
		 m_DungeonKey = "";
		 m_SessionKey = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_DungeonKey = "";
		 m_SessionKey = "";

	}

 	//转化成Protobuffer类型函数
	public FightRpcEnterAsk ToPB()
	{
		FightRpcEnterAsk v = new FightRpcEnterAsk();
		v.UserId = m_UserId;
		v.DungeonKey = m_DungeonKey;
		v.SessionKey = m_SessionKey;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcEnterAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_DungeonKey = v.DungeonKey;
		m_SessionKey = v.SessionKey;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcEnterAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcEnterAsk pb = ProtoBuf.Serializer.Deserialize<FightRpcEnterAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//副本钥匙
	public string m_DungeonKey;
	public string DungeonKey
	{
		get { return m_DungeonKey;}
		set { m_DungeonKey = value; }
	}
	//SessionKey
	public string m_SessionKey;
	public string SessionKey
	{
		get { return m_SessionKey;}
		set { m_SessionKey = value; }
	}


};
//进入副本回应封装类
[System.Serializable]
public class FightRpcEnterReplyWraper
{

	//构造函数
	public FightRpcEnterReplyWraper()
	{
		 m_Result = -9999;
		 m_Tick = -1;
		 m_RandNum = -1;
		 m_IdHelper = -1;
		m_ActionArr = new List<byte[]>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_Tick = -1;
		 m_RandNum = -1;
		 m_IdHelper = -1;
		m_ActionArr = new List<byte[]>();

	}

 	//转化成Protobuffer类型函数
	public FightRpcEnterReply ToPB()
	{
		FightRpcEnterReply v = new FightRpcEnterReply();
		v.Result = m_Result;
		v.Tick = m_Tick;
		v.RandNum = m_RandNum;
		v.IdHelper = m_IdHelper;
		for (int i=0; i<(int)m_ActionArr.Count; i++)
			v.ActionArr.Add( m_ActionArr[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcEnterReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Tick = v.Tick;
		m_RandNum = v.RandNum;
		m_IdHelper = v.IdHelper;
		m_ActionArr.Clear();
		for( int i=0; i<v.ActionArr.Count; i++)
			m_ActionArr.Add(v.ActionArr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcEnterReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcEnterReply pb = ProtoBuf.Serializer.Deserialize<FightRpcEnterReply>(protoMS);
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
	//当前Tick
	public int m_Tick;
	public int Tick
	{
		get { return m_Tick;}
		set { m_Tick = value; }
	}
	//当前随机数
	public int m_RandNum;
	public int RandNum
	{
		get { return m_RandNum;}
		set { m_RandNum = value; }
	}
	//ID管理器的值
	public int m_IdHelper;
	public int IdHelper
	{
		get { return m_IdHelper;}
		set { m_IdHelper = value; }
	}
	//创建的Action列表
	public List<byte[]> m_ActionArr;
	public int SizeActionArr()
	{
		return m_ActionArr.Count;
	}
	public List<byte[]> GetActionArr()
	{
		return m_ActionArr;
	}
	public byte[] GetActionArr(int Index)
	{
		if(Index<0 || Index>=(int)m_ActionArr.Count)
			return new byte[0];
		return m_ActionArr[Index];
	}
	public void SetActionArr( List<byte[]> v )
	{
		m_ActionArr=v;
	}
	public void SetActionArr( int Index, byte[] v )
	{
		if(Index<0 || Index>=(int)m_ActionArr.Count)
			return;
		m_ActionArr[Index] = v;
	}
	public void AddActionArr( byte[] v )
	{
		m_ActionArr.Add(v);
	}
	public void ClearActionArr( )
	{
		m_ActionArr.Clear();
	}


};
//奖励列表封装类
[System.Serializable]
public class FightPrizeInfoWraper
{

	//构造函数
	public FightPrizeInfoWraper()
	{
		 m_Id = -1;
		 m_Count = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Count = -1;

	}

 	//转化成Protobuffer类型函数
	public FightPrizeInfo ToPB()
	{
		FightPrizeInfo v = new FightPrizeInfo();
		v.Id = m_Id;
		v.Count = m_Count;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightPrizeInfo v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Count = v.Count;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightPrizeInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightPrizeInfo pb = ProtoBuf.Serializer.Deserialize<FightPrizeInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//奖励ID
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//奖励数量
	public int m_Count;
	public int Count
	{
		get { return m_Count;}
		set { m_Count = value; }
	}


};
//杀戮信息封装类
[System.Serializable]
public class FightKillInfoWraper
{

	//构造函数
	public FightKillInfoWraper()
	{
		 m_Id = -1;
		 m_Count = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Count = -1;

	}

 	//转化成Protobuffer类型函数
	public FightKillInfo ToPB()
	{
		FightKillInfo v = new FightKillInfo();
		v.Id = m_Id;
		v.Count = m_Count;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightKillInfo v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Count = v.Count;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightKillInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightKillInfo pb = ProtoBuf.Serializer.Deserialize<FightKillInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//对方Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//数量
	public int m_Count;
	public int Count
	{
		get { return m_Count;}
		set { m_Count = value; }
	}


};
//战斗开始通知封装类
[System.Serializable]
public class FightRpcStartNotifyWraper
{

	//构造函数
	public FightRpcStartNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public FightRpcStartNotify ToPB()
	{
		FightRpcStartNotify v = new FightRpcStartNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRpcStartNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRpcStartNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRpcStartNotify pb = ProtoBuf.Serializer.Deserialize<FightRpcStartNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
//使用技能动作封装类
[System.Serializable]
public class FightUseSkillActionWraper : BattleKernel.Action
{

	//构造函数
	public FightUseSkillActionWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_PosInfo = new byte[0];
		 m_TargetObjId = -1;
		 m_TargetPos = new byte[0];
		 m_Type = 0;
		m_V3Pos = new List<float>();
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_PosInfo = new byte[0];
		 m_TargetObjId = -1;
		 m_TargetPos = new byte[0];
		 m_Type = 0;
		m_V3Pos = new List<float>();
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightUseSkillAction ToPB()
	{
		FightUseSkillAction v = new FightUseSkillAction();
		v.ObjId = m_ObjId;
		v.SkillId = m_SkillId;
		v.PosInfo = m_PosInfo;
		v.TargetObjId = m_TargetObjId;
		v.TargetPos = m_TargetPos;
		v.Type = m_Type;
		for (int i=0; i<(int)m_V3Pos.Count; i++)
			v.V3Pos.Add( m_V3Pos[i]);
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightUseSkillAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_SkillId = v.SkillId;
		m_PosInfo = v.PosInfo;
		m_TargetObjId = v.TargetObjId;
		m_TargetPos = v.TargetPos;
		m_Type = v.Type;
		m_V3Pos.Clear();
		for( int i=0; i<v.V3Pos.Count; i++)
			m_V3Pos.Add(v.V3Pos[i]);
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightUseSkillAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightUseSkillAction pb = ProtoBuf.Serializer.Deserialize<FightUseSkillAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//主目标ID
	public int m_TargetObjId;
	public int TargetObjId
	{
		get { return m_TargetObjId;}
		set { m_TargetObjId = value; }
	}
	//目标位置信息
	public byte[] m_TargetPos;
	public byte[] TargetPos
	{
		get { return m_TargetPos;}
		set { m_TargetPos = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//V3Pos
	public List<float> m_V3Pos;
	public int SizeV3Pos()
	{
		return m_V3Pos.Count;
	}
	public List<float> GetV3Pos()
	{
		return m_V3Pos;
	}
	public float GetV3Pos(int Index)
	{
		if(Index<0 || Index>=(int)m_V3Pos.Count)
			return -1;
		return m_V3Pos[Index];
	}
	public void SetV3Pos( List<float> v )
	{
		m_V3Pos=v;
	}
	public void SetV3Pos( int Index, float v )
	{
		if(Index<0 || Index>=(int)m_V3Pos.Count)
			return;
		m_V3Pos[Index] = v;
	}
	public void AddV3Pos( float v=-1 )
	{
		m_V3Pos.Add(v);
	}
	public void ClearV3Pos( )
	{
		m_V3Pos.Clear();
	}
	//吟唱或引导时间(毫秒)
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//BUFF操作动作类封装类
[System.Serializable]
public class FightBuffActionWraper : BattleKernel.Action
{

	//构造函数
	public FightBuffActionWraper()
	{
		 m_ObjId = -1;
		 m_AttackerId = -1;
		 m_OpType = -1;
		 m_BuffId = -1;
		 m_RemainTime = -1;
		 m_BuffLv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_AttackerId = -1;
		 m_OpType = -1;
		 m_BuffId = -1;
		 m_RemainTime = -1;
		 m_BuffLv = -1;

	}

 	//转化成Protobuffer类型函数
	public FightBuffAction ToPB()
	{
		FightBuffAction v = new FightBuffAction();
		v.ObjId = m_ObjId;
		v.AttackerId = m_AttackerId;
		v.OpType = m_OpType;
		v.BuffId = m_BuffId;
		v.RemainTime = m_RemainTime;
		v.BuffLv = m_BuffLv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightBuffAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_AttackerId = v.AttackerId;
		m_OpType = v.OpType;
		m_BuffId = v.BuffId;
		m_RemainTime = v.RemainTime;
		m_BuffLv = v.BuffLv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightBuffAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightBuffAction pb = ProtoBuf.Serializer.Deserialize<FightBuffAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//攻击者ObjId
	public int m_AttackerId;
	public int AttackerId
	{
		get { return m_AttackerId;}
		set { m_AttackerId = value; }
	}
	//操作类型
	public int m_OpType;
	public int OpType
	{
		get { return m_OpType;}
		set { m_OpType = value; }
	}
	//BuffId
	public int m_BuffId;
	public int BuffId
	{
		get { return m_BuffId;}
		set { m_BuffId = value; }
	}
	//剩余时间
	public int m_RemainTime;
	public int RemainTime
	{
		get { return m_RemainTime;}
		set { m_RemainTime = value; }
	}
	//Buff等级
	public int m_BuffLv;
	public int BuffLv
	{
		get { return m_BuffLv;}
		set { m_BuffLv = value; }
	}


};
//攻击动作封装类
[System.Serializable]
public class FightCharHitActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCharHitActionWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		m_TargetList = new List<FightHitTargetInfoWraper>();
		 m_Seq = -1;
		 m_PosInfo = new byte[0];
		 m_BackDir = 0;
		 m_SegmentIndex = -1;
		 m_AttackSegment = -1;
		 m_IsHitGround = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		m_TargetList = new List<FightHitTargetInfoWraper>();
		 m_Seq = -1;
		 m_PosInfo = new byte[0];
		 m_BackDir = 0;
		 m_SegmentIndex = -1;
		 m_AttackSegment = -1;
		 m_IsHitGround = false;

	}

 	//转化成Protobuffer类型函数
	public FightCharHitAction ToPB()
	{
		FightCharHitAction v = new FightCharHitAction();
		v.ObjId = m_ObjId;
		v.SkillId = m_SkillId;
		for (int i=0; i<(int)m_TargetList.Count; i++)
			v.TargetList.Add( m_TargetList[i].ToPB());
		v.Seq = m_Seq;
		v.PosInfo = m_PosInfo;
		v.BackDir = m_BackDir;
		v.SegmentIndex = m_SegmentIndex;
		v.AttackSegment = m_AttackSegment;
		v.IsHitGround = m_IsHitGround;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCharHitAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_SkillId = v.SkillId;
		m_TargetList.Clear();
		for( int i=0; i<v.TargetList.Count; i++)
			m_TargetList.Add( new FightHitTargetInfoWraper());
		for( int i=0; i<v.TargetList.Count; i++)
			m_TargetList[i].FromPB(v.TargetList[i]);
		m_Seq = v.Seq;
		m_PosInfo = v.PosInfo;
		m_BackDir = v.BackDir;
		m_SegmentIndex = v.SegmentIndex;
		m_AttackSegment = v.AttackSegment;
		m_IsHitGround = v.IsHitGround;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCharHitAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCharHitAction pb = ProtoBuf.Serializer.Deserialize<FightCharHitAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//目标列表
	public List<FightHitTargetInfoWraper> m_TargetList;
	public int SizeTargetList()
	{
		return m_TargetList.Count;
	}
	public List<FightHitTargetInfoWraper> GetTargetList()
	{
		return m_TargetList;
	}
	public FightHitTargetInfoWraper GetTargetList(int Index)
	{
		if(Index<0 || Index>=(int)m_TargetList.Count)
			return new FightHitTargetInfoWraper();
		return m_TargetList[Index];
	}
	public void SetTargetList( List<FightHitTargetInfoWraper> v )
	{
		m_TargetList=v;
	}
	public void SetTargetList( int Index, FightHitTargetInfoWraper v )
	{
		if(Index<0 || Index>=(int)m_TargetList.Count)
			return;
		m_TargetList[Index] = v;
	}
	public void AddTargetList( FightHitTargetInfoWraper v )
	{
		m_TargetList.Add(v);
	}
	public void ClearTargetList( )
	{
		m_TargetList.Clear();
	}
	//技能攻击到人的序列号
	public int m_Seq;
	public int Seq
	{
		get { return m_Seq;}
		set { m_Seq = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//后退方向
	public int m_BackDir;
	public int BackDir
	{
		get { return m_BackDir;}
		set { m_BackDir = value; }
	}
	//技能动作段索引
	public int m_SegmentIndex;
	public int SegmentIndex
	{
		get { return m_SegmentIndex;}
		set { m_SegmentIndex = value; }
	}
	//攻击段数
	public int m_AttackSegment;
	public int AttackSegment
	{
		get { return m_AttackSegment;}
		set { m_AttackSegment = value; }
	}
	//受击后目标倒地
	public bool m_IsHitGround;
	public bool IsHitGround
	{
		get { return m_IsHitGround;}
		set { m_IsHitGround = value; }
	}


};
//断线动作封装类
[System.Serializable]
public class FightOfflineActionWraper : BattleKernel.Action
{

	//构造函数
	public FightOfflineActionWraper()
	{
		 m_ObjId = -1;
		 m_IsOffline = false;
		 m_IsAIDelegate = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_IsOffline = false;
		 m_IsAIDelegate = false;

	}

 	//转化成Protobuffer类型函数
	public FightOfflineAction ToPB()
	{
		FightOfflineAction v = new FightOfflineAction();
		v.ObjId = m_ObjId;
		v.IsOffline = m_IsOffline;
		v.IsAIDelegate = m_IsAIDelegate;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightOfflineAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_IsOffline = v.IsOffline;
		m_IsAIDelegate = v.IsAIDelegate;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightOfflineAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightOfflineAction pb = ProtoBuf.Serializer.Deserialize<FightOfflineAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj Id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//是否下线
	public bool m_IsOffline;
	public bool IsOffline
	{
		get { return m_IsOffline;}
		set { m_IsOffline = value; }
	}
	//是否AI接管
	public bool m_IsAIDelegate;
	public bool IsAIDelegate
	{
		get { return m_IsAIDelegate;}
		set { m_IsAIDelegate = value; }
	}


};
//状态机动作封装类
[System.Serializable]
public class FightStateActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStateActionWraper()
	{
		 m_Type = -1;
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_TargetPos = new byte[0];
		 m_IntPara = -1;
		 m_LadderObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_TargetPos = new byte[0];
		 m_IntPara = -1;
		 m_LadderObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStateAction ToPB()
	{
		FightStateAction v = new FightStateAction();
		v.Type = m_Type;
		v.ObjId = m_ObjId;
		v.PosInfo = m_PosInfo;
		v.TargetPos = m_TargetPos;
		v.IntPara = m_IntPara;
		v.LadderObjId = m_LadderObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStateAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_ObjId = v.ObjId;
		m_PosInfo = v.PosInfo;
		m_TargetPos = v.TargetPos;
		m_IntPara = v.IntPara;
		m_LadderObjId = v.LadderObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStateAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStateAction pb = ProtoBuf.Serializer.Deserialize<FightStateAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//状态类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//目标位置信息
	public byte[] m_TargetPos;
	public byte[] TargetPos
	{
		get { return m_TargetPos;}
		set { m_TargetPos = value; }
	}
	//INT参数
	public int m_IntPara;
	public int IntPara
	{
		get { return m_IntPara;}
		set { m_IntPara = value; }
	}
	//梯子ObjId
	public int m_LadderObjId;
	public int LadderObjId
	{
		get { return m_LadderObjId;}
		set { m_LadderObjId = value; }
	}


};
//角色死亡动作封装类
[System.Serializable]
public class FightCharDeadActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCharDeadActionWraper()
	{
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];

	}

 	//转化成Protobuffer类型函数
	public FightCharDeadAction ToPB()
	{
		FightCharDeadAction v = new FightCharDeadAction();
		v.ObjId = m_ObjId;
		v.PosInfo = m_PosInfo;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCharDeadAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_PosInfo = v.PosInfo;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCharDeadAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCharDeadAction pb = ProtoBuf.Serializer.Deserialize<FightCharDeadAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}


};
//角色复活动作封装类
[System.Serializable]
public class FightCharReviveActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCharReviveActionWraper()
	{
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_CurHp = 0;
		 m_Type = -1;
		 m_Time = -1;
		 m_ManualRevive = 0;
		 m_RemainTimes = -1;
		 m_NeedMoney = -1;
		 m_MaxHP = 0;
		 m_TotalTimes = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_CurHp = 0;
		 m_Type = -1;
		 m_Time = -1;
		 m_ManualRevive = 0;
		 m_RemainTimes = -1;
		 m_NeedMoney = -1;
		 m_MaxHP = 0;
		 m_TotalTimes = -1;

	}

 	//转化成Protobuffer类型函数
	public FightCharReviveAction ToPB()
	{
		FightCharReviveAction v = new FightCharReviveAction();
		v.ObjId = m_ObjId;
		v.PosInfo = m_PosInfo;
		v.CurHp = m_CurHp;
		v.Type = m_Type;
		v.Time = m_Time;
		v.ManualRevive = m_ManualRevive;
		v.RemainTimes = m_RemainTimes;
		v.NeedMoney = m_NeedMoney;
		v.MaxHP = m_MaxHP;
		v.TotalTimes = m_TotalTimes;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCharReviveAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_PosInfo = v.PosInfo;
		m_CurHp = v.CurHp;
		m_Type = v.Type;
		m_Time = v.Time;
		m_ManualRevive = v.ManualRevive;
		m_RemainTimes = v.RemainTimes;
		m_NeedMoney = v.NeedMoney;
		m_MaxHP = v.MaxHP;
		m_TotalTimes = v.TotalTimes;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCharReviveAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCharReviveAction pb = ProtoBuf.Serializer.Deserialize<FightCharReviveAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//当前血量
	public int m_CurHp;
	public int CurHp
	{
		get { return m_CurHp;}
		set { m_CurHp = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//读条时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}
	//是否需要手动复活
	public int m_ManualRevive;
	public int ManualRevive
	{
		get { return m_ManualRevive;}
		set { m_ManualRevive = value; }
	}
	//免费复活剩余次数
	public int m_RemainTimes;
	public int RemainTimes
	{
		get { return m_RemainTimes;}
		set { m_RemainTimes = value; }
	}
	//需要复活的钱
	public int m_NeedMoney;
	public int NeedMoney
	{
		get { return m_NeedMoney;}
		set { m_NeedMoney = value; }
	}
	//最大血量
	public int m_MaxHP;
	public int MaxHP
	{
		get { return m_MaxHP;}
		set { m_MaxHP = value; }
	}
	//总复活次数
	public int m_TotalTimes;
	public int TotalTimes
	{
		get { return m_TotalTimes;}
		set { m_TotalTimes = value; }
	}


};
//攻击目标信息封装类
[System.Serializable]
public class FightHitTargetInfoWraper
{

	//构造函数
	public FightHitTargetInfoWraper()
	{
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_Flag = 0;
		 m_EnemyIndex = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_Flag = 0;
		 m_EnemyIndex = -1;

	}

 	//转化成Protobuffer类型函数
	public FightHitTargetInfo ToPB()
	{
		FightHitTargetInfo v = new FightHitTargetInfo();
		v.ObjId = m_ObjId;
		v.PosInfo = m_PosInfo;
		v.Flag = m_Flag;
		v.EnemyIndex = m_EnemyIndex;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightHitTargetInfo v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_PosInfo = v.PosInfo;
		m_Flag = v.Flag;
		m_EnemyIndex = v.EnemyIndex;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightHitTargetInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightHitTargetInfo pb = ProtoBuf.Serializer.Deserialize<FightHitTargetInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//ObjId
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//标记
	public int m_Flag;
	public int Flag
	{
		get { return m_Flag;}
		set { m_Flag = value; }
	}
	//本次攻击敌人计数
	public int m_EnemyIndex;
	public int EnemyIndex
	{
		get { return m_EnemyIndex;}
		set { m_EnemyIndex = value; }
	}


};
//连击技能动作封装类
[System.Serializable]
public class FightComboSkillActionWraper : BattleKernel.Action
{

	//构造函数
	public FightComboSkillActionWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_Flag = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_Flag = -1;

	}

 	//转化成Protobuffer类型函数
	public FightComboSkillAction ToPB()
	{
		FightComboSkillAction v = new FightComboSkillAction();
		v.ObjId = m_ObjId;
		v.SkillId = m_SkillId;
		v.Flag = m_Flag;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightComboSkillAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_SkillId = v.SkillId;
		m_Flag = v.Flag;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightComboSkillAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightComboSkillAction pb = ProtoBuf.Serializer.Deserialize<FightComboSkillAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//连击标志
	public int m_Flag;
	public int Flag
	{
		get { return m_Flag;}
		set { m_Flag = value; }
	}


};
//结束技能动作封装类
[System.Serializable]
public class FightEndSkillActionWraper : BattleKernel.Action
{

	//构造函数
	public FightEndSkillActionWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_PosInfo = new byte[0];
		 m_ComboSkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_PosInfo = new byte[0];
		 m_ComboSkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightEndSkillAction ToPB()
	{
		FightEndSkillAction v = new FightEndSkillAction();
		v.ObjId = m_ObjId;
		v.SkillId = m_SkillId;
		v.PosInfo = m_PosInfo;
		v.ComboSkillId = m_ComboSkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightEndSkillAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_SkillId = v.SkillId;
		m_PosInfo = v.PosInfo;
		m_ComboSkillId = v.ComboSkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightEndSkillAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightEndSkillAction pb = ProtoBuf.Serializer.Deserialize<FightEndSkillAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//连击技能ID
	public int m_ComboSkillId;
	public int ComboSkillId
	{
		get { return m_ComboSkillId;}
		set { m_ComboSkillId = value; }
	}


};
//主城状态同步封装类
[System.Serializable]
public class FightCityActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCityActionWraper()
	{
		 m_Type = -1;
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_TargetPos = new byte[0];
		 m_IntPara = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_TargetPos = new byte[0];
		 m_IntPara = -1;

	}

 	//转化成Protobuffer类型函数
	public FightCityAction ToPB()
	{
		FightCityAction v = new FightCityAction();
		v.Type = m_Type;
		v.ObjId = m_ObjId;
		v.PosInfo = m_PosInfo;
		v.TargetPos = m_TargetPos;
		v.IntPara = m_IntPara;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCityAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_ObjId = v.ObjId;
		m_PosInfo = v.PosInfo;
		m_TargetPos = v.TargetPos;
		m_IntPara = v.IntPara;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCityAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCityAction pb = ProtoBuf.Serializer.Deserialize<FightCityAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//状态类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//目标位置信息
	public byte[] m_TargetPos;
	public byte[] TargetPos
	{
		get { return m_TargetPos;}
		set { m_TargetPos = value; }
	}
	//INT参数
	public int m_IntPara;
	public int IntPara
	{
		get { return m_IntPara;}
		set { m_IntPara = value; }
	}


};
//狙击动作封装类
[System.Serializable]
public class FightSnipeActionWraper : BattleKernel.Action
{

	//构造函数
	public FightSnipeActionWraper()
	{
		 m_Type = -1;
		 m_ObjId = -1;
		 m_TargetPos = new byte[0];
		 m_CampId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_ObjId = -1;
		 m_TargetPos = new byte[0];
		 m_CampId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightSnipeAction ToPB()
	{
		FightSnipeAction v = new FightSnipeAction();
		v.Type = m_Type;
		v.ObjId = m_ObjId;
		v.TargetPos = m_TargetPos;
		v.CampId = m_CampId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightSnipeAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_ObjId = v.ObjId;
		m_TargetPos = v.TargetPos;
		m_CampId = v.CampId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightSnipeAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightSnipeAction pb = ProtoBuf.Serializer.Deserialize<FightSnipeAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//状态类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//目标位置信息
	public byte[] m_TargetPos;
	public byte[] TargetPos
	{
		get { return m_TargetPos;}
		set { m_TargetPos = value; }
	}
	//狙击者阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}


};
//伤害动作封装类
[System.Serializable]
public class FightHurtActionWraper : BattleKernel.Action
{

	//构造函数
	public FightHurtActionWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_AttackBack = false;
		 m_AttackAir = false;
		 m_BackDir = 0;
		 m_TargetObjId = -1;
		 m_OwnHP = -1;
		 m_TargetHP = -1;
		 m_OwnHPChange = -1;
		 m_TargetHPChange = -1;
		 m_IsCrit = false;
		 m_TotalDamage = -1;
		 m_SegmentIndex = -1;
		 m_HurtType = -1;
		 m_AttackSegment = -1;
		 m_IsHitGround = false;
		 m_TargetMaxHP = -1;
		 m_EnemyIndex = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_AttackBack = false;
		 m_AttackAir = false;
		 m_BackDir = 0;
		 m_TargetObjId = -1;
		 m_OwnHP = -1;
		 m_TargetHP = -1;
		 m_OwnHPChange = -1;
		 m_TargetHPChange = -1;
		 m_IsCrit = false;
		 m_TotalDamage = -1;
		 m_SegmentIndex = -1;
		 m_HurtType = -1;
		 m_AttackSegment = -1;
		 m_IsHitGround = false;
		 m_TargetMaxHP = -1;
		 m_EnemyIndex = -1;

	}

 	//转化成Protobuffer类型函数
	public FightHurtAction ToPB()
	{
		FightHurtAction v = new FightHurtAction();
		v.ObjId = m_ObjId;
		v.SkillId = m_SkillId;
		v.AttackBack = m_AttackBack;
		v.AttackAir = m_AttackAir;
		v.BackDir = m_BackDir;
		v.TargetObjId = m_TargetObjId;
		v.OwnHP = m_OwnHP;
		v.TargetHP = m_TargetHP;
		v.OwnHPChange = m_OwnHPChange;
		v.TargetHPChange = m_TargetHPChange;
		v.IsCrit = m_IsCrit;
		v.TotalDamage = m_TotalDamage;
		v.SegmentIndex = m_SegmentIndex;
		v.HurtType = m_HurtType;
		v.AttackSegment = m_AttackSegment;
		v.IsHitGround = m_IsHitGround;
		v.TargetMaxHP = m_TargetMaxHP;
		v.EnemyIndex = m_EnemyIndex;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightHurtAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_SkillId = v.SkillId;
		m_AttackBack = v.AttackBack;
		m_AttackAir = v.AttackAir;
		m_BackDir = v.BackDir;
		m_TargetObjId = v.TargetObjId;
		m_OwnHP = v.OwnHP;
		m_TargetHP = v.TargetHP;
		m_OwnHPChange = v.OwnHPChange;
		m_TargetHPChange = v.TargetHPChange;
		m_IsCrit = v.IsCrit;
		m_TotalDamage = v.TotalDamage;
		m_SegmentIndex = v.SegmentIndex;
		m_HurtType = v.HurtType;
		m_AttackSegment = v.AttackSegment;
		m_IsHitGround = v.IsHitGround;
		m_TargetMaxHP = v.TargetMaxHP;
		m_EnemyIndex = v.EnemyIndex;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightHurtAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightHurtAction pb = ProtoBuf.Serializer.Deserialize<FightHurtAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//是否击退
	public bool m_AttackBack;
	public bool AttackBack
	{
		get { return m_AttackBack;}
		set { m_AttackBack = value; }
	}
	//是否浮空
	public bool m_AttackAir;
	public bool AttackAir
	{
		get { return m_AttackAir;}
		set { m_AttackAir = value; }
	}
	//后退方向
	public int m_BackDir;
	public int BackDir
	{
		get { return m_BackDir;}
		set { m_BackDir = value; }
	}
	//目标ObjId
	public int m_TargetObjId;
	public int TargetObjId
	{
		get { return m_TargetObjId;}
		set { m_TargetObjId = value; }
	}
	//自己的血量
	public int m_OwnHP;
	public int OwnHP
	{
		get { return m_OwnHP;}
		set { m_OwnHP = value; }
	}
	//目标血量
	public int m_TargetHP;
	public int TargetHP
	{
		get { return m_TargetHP;}
		set { m_TargetHP = value; }
	}
	//自己血量变化
	public int m_OwnHPChange;
	public int OwnHPChange
	{
		get { return m_OwnHPChange;}
		set { m_OwnHPChange = value; }
	}
	//目标血量变化
	public int m_TargetHPChange;
	public int TargetHPChange
	{
		get { return m_TargetHPChange;}
		set { m_TargetHPChange = value; }
	}
	//是否暴击
	public bool m_IsCrit;
	public bool IsCrit
	{
		get { return m_IsCrit;}
		set { m_IsCrit = value; }
	}
	//总伤害
	public int m_TotalDamage;
	public int TotalDamage
	{
		get { return m_TotalDamage;}
		set { m_TotalDamage = value; }
	}
	//技能动作段索引
	public int m_SegmentIndex;
	public int SegmentIndex
	{
		get { return m_SegmentIndex;}
		set { m_SegmentIndex = value; }
	}
	//伤害类型
	public int m_HurtType;
	public int HurtType
	{
		get { return m_HurtType;}
		set { m_HurtType = value; }
	}
	//攻击段数
	public int m_AttackSegment;
	public int AttackSegment
	{
		get { return m_AttackSegment;}
		set { m_AttackSegment = value; }
	}
	//受击后目标倒地
	public bool m_IsHitGround;
	public bool IsHitGround
	{
		get { return m_IsHitGround;}
		set { m_IsHitGround = value; }
	}
	//目标最大血量
	public int m_TargetMaxHP;
	public int TargetMaxHP
	{
		get { return m_TargetMaxHP;}
		set { m_TargetMaxHP = value; }
	}
	//本次攻击敌人计数
	public int m_EnemyIndex;
	public int EnemyIndex
	{
		get { return m_EnemyIndex;}
		set { m_EnemyIndex = value; }
	}


};
//闪避动作封装类
[System.Serializable]
public class FightDodgeActionWraper : BattleKernel.Action
{

	//构造函数
	public FightDodgeActionWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_AttackerObjId = -1;
		 m_Type = 1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_SkillId = -1;
		 m_AttackerObjId = -1;
		 m_Type = 1;

	}

 	//转化成Protobuffer类型函数
	public FightDodgeAction ToPB()
	{
		FightDodgeAction v = new FightDodgeAction();
		v.ObjId = m_ObjId;
		v.SkillId = m_SkillId;
		v.AttackerObjId = m_AttackerObjId;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightDodgeAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_SkillId = v.SkillId;
		m_AttackerObjId = v.AttackerObjId;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightDodgeAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightDodgeAction pb = ProtoBuf.Serializer.Deserialize<FightDodgeAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//技能ID
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//攻击者ID
	public int m_AttackerObjId;
	public int AttackerObjId
	{
		get { return m_AttackerObjId;}
		set { m_AttackerObjId = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//删除对像封装类
[System.Serializable]
public class FightRemoveObjActionWraper : BattleKernel.Action
{

	//构造函数
	public FightRemoveObjActionWraper()
	{
		 m_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightRemoveObjAction ToPB()
	{
		FightRemoveObjAction v = new FightRemoveObjAction();
		v.ObjId = m_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightRemoveObjAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightRemoveObjAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightRemoveObjAction pb = ProtoBuf.Serializer.Deserialize<FightRemoveObjAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}


};
//暴风基地信息封装类
[System.Serializable]
public class FightStormBaseActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormBaseActionWraper()
	{
		 m_Type = -1;
		 m_Mark = -1;
		 m_CampId = -1;
		 m_ObjId = -1;
		 m_ID = -1;
		 m_Name = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Mark = -1;
		 m_CampId = -1;
		 m_ObjId = -1;
		 m_ID = -1;
		 m_Name = "";

	}

 	//转化成Protobuffer类型函数
	public FightStormBaseAction ToPB()
	{
		FightStormBaseAction v = new FightStormBaseAction();
		v.Type = m_Type;
		v.Mark = m_Mark;
		v.CampId = m_CampId;
		v.ObjId = m_ObjId;
		v.ID = m_ID;
		v.Name = m_Name;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormBaseAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Mark = v.Mark;
		m_CampId = v.CampId;
		m_ObjId = v.ObjId;
		m_ID = v.ID;
		m_Name = v.Name;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormBaseAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormBaseAction pb = ProtoBuf.Serializer.Deserialize<FightStormBaseAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//标记位置
	public int m_Mark;
	public int Mark
	{
		get { return m_Mark;}
		set { m_Mark = value; }
	}
	//归属阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}
	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//ID
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}
	//Name
	public string m_Name;
	public string Name
	{
		get { return m_Name;}
		set { m_Name = value; }
	}


};
//暴风资源信息封装类
[System.Serializable]
public class FightStormResActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormResActionWraper()
	{
		 m_BaseId = -1;
		 m_CampId = -1;
		 m_UpdateNum = -1;
		 m_TotalNum = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_BaseId = -1;
		 m_CampId = -1;
		 m_UpdateNum = -1;
		 m_TotalNum = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormResAction ToPB()
	{
		FightStormResAction v = new FightStormResAction();
		v.BaseId = m_BaseId;
		v.CampId = m_CampId;
		v.UpdateNum = m_UpdateNum;
		v.TotalNum = m_TotalNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormResAction v)
	{
        if (v == null)
            return;
		m_BaseId = v.BaseId;
		m_CampId = v.CampId;
		m_UpdateNum = v.UpdateNum;
		m_TotalNum = v.TotalNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormResAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormResAction pb = ProtoBuf.Serializer.Deserialize<FightStormResAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//基地ID
	public int m_BaseId;
	public int BaseId
	{
		get { return m_BaseId;}
		set { m_BaseId = value; }
	}
	//归属阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}
	//资源更新量
	public int m_UpdateNum;
	public int UpdateNum
	{
		get { return m_UpdateNum;}
		set { m_UpdateNum = value; }
	}
	//资源总量
	public int m_TotalNum;
	public int TotalNum
	{
		get { return m_TotalNum;}
		set { m_TotalNum = value; }
	}


};
//暴风旗信息封装类
[System.Serializable]
public class FightStormFlagActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormFlagActionWraper()
	{
		 m_Type = 1;
		 m_Time = -1;
		 m_FlagObjId = -1;
		 m_ObjId1 = -1;
		 m_ObjId2 = -1;
		 m_Result = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = 1;
		 m_Time = -1;
		 m_FlagObjId = -1;
		 m_ObjId1 = -1;
		 m_ObjId2 = -1;
		 m_Result = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormFlagAction ToPB()
	{
		FightStormFlagAction v = new FightStormFlagAction();
		v.Type = m_Type;
		v.Time = m_Time;
		v.FlagObjId = m_FlagObjId;
		v.ObjId1 = m_ObjId1;
		v.ObjId2 = m_ObjId2;
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormFlagAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;
		m_FlagObjId = v.FlagObjId;
		m_ObjId1 = v.ObjId1;
		m_ObjId2 = v.ObjId2;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormFlagAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormFlagAction pb = ProtoBuf.Serializer.Deserialize<FightStormFlagAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//动作类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}
	//旗ObjId
	public int m_FlagObjId;
	public int FlagObjId
	{
		get { return m_FlagObjId;}
		set { m_FlagObjId = value; }
	}
	//ObjId1
	public int m_ObjId1;
	public int ObjId1
	{
		get { return m_ObjId1;}
		set { m_ObjId1 = value; }
	}
	//ObjId2
	public int m_ObjId2;
	public int ObjId2
	{
		get { return m_ObjId2;}
		set { m_ObjId2 = value; }
	}
	//操作旗子结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//暴风阵营信息封装类
[System.Serializable]
public class FightStormCampActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormCampActionWraper()
	{
		m_ObjArr = new List<int>();
		 m_CampId = -1;
		 m_TotalNum = 0;
		 m_Color = -1;
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_ObjArr = new List<int>();
		 m_CampId = -1;
		 m_TotalNum = 0;
		 m_Color = -1;
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormCampAction ToPB()
	{
		FightStormCampAction v = new FightStormCampAction();
		for (int i=0; i<(int)m_ObjArr.Count; i++)
			v.ObjArr.Add( m_ObjArr[i]);
		v.CampId = m_CampId;
		v.TotalNum = m_TotalNum;
		v.Color = m_Color;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormCampAction v)
	{
        if (v == null)
            return;
		m_ObjArr.Clear();
		for( int i=0; i<v.ObjArr.Count; i++)
			m_ObjArr.Add(v.ObjArr[i]);
		m_CampId = v.CampId;
		m_TotalNum = v.TotalNum;
		m_Color = v.Color;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormCampAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormCampAction pb = ProtoBuf.Serializer.Deserialize<FightStormCampAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//阵营人员ObjId列表
	public List<int> m_ObjArr;
	public int SizeObjArr()
	{
		return m_ObjArr.Count;
	}
	public List<int> GetObjArr()
	{
		return m_ObjArr;
	}
	public int GetObjArr(int Index)
	{
		if(Index<0 || Index>=(int)m_ObjArr.Count)
			return -1;
		return m_ObjArr[Index];
	}
	public void SetObjArr( List<int> v )
	{
		m_ObjArr=v;
	}
	public void SetObjArr( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_ObjArr.Count)
			return;
		m_ObjArr[Index] = v;
	}
	public void AddObjArr( int v=-1 )
	{
		m_ObjArr.Add(v);
	}
	public void ClearObjArr( )
	{
		m_ObjArr.Clear();
	}
	//阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}
	//资源总量
	public int m_TotalNum;
	public int TotalNum
	{
		get { return m_TotalNum;}
		set { m_TotalNum = value; }
	}
	//阵营颜色
	public int m_Color;
	public int Color
	{
		get { return m_Color;}
		set { m_Color = value; }
	}
	//操作类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//暴风战斗结果信息封装类
[System.Serializable]
public class FightStormResultActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormResultActionWraper()
	{
		m_CampArr = new List<FightStormCampInfoWraper>();
		 m_IsSvrSend = false;

	}

	//重置函数
	public void ResetWraper()
	{
		m_CampArr = new List<FightStormCampInfoWraper>();
		 m_IsSvrSend = false;

	}

 	//转化成Protobuffer类型函数
	public FightStormResultAction ToPB()
	{
		FightStormResultAction v = new FightStormResultAction();
		for (int i=0; i<(int)m_CampArr.Count; i++)
			v.CampArr.Add( m_CampArr[i].ToPB());
		v.IsSvrSend = m_IsSvrSend;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormResultAction v)
	{
        if (v == null)
            return;
		m_CampArr.Clear();
		for( int i=0; i<v.CampArr.Count; i++)
			m_CampArr.Add( new FightStormCampInfoWraper());
		for( int i=0; i<v.CampArr.Count; i++)
			m_CampArr[i].FromPB(v.CampArr[i]);
		m_IsSvrSend = v.IsSvrSend;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormResultAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormResultAction pb = ProtoBuf.Serializer.Deserialize<FightStormResultAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//阵营列表
	public List<FightStormCampInfoWraper> m_CampArr;
	public int SizeCampArr()
	{
		return m_CampArr.Count;
	}
	public List<FightStormCampInfoWraper> GetCampArr()
	{
		return m_CampArr;
	}
	public FightStormCampInfoWraper GetCampArr(int Index)
	{
		if(Index<0 || Index>=(int)m_CampArr.Count)
			return new FightStormCampInfoWraper();
		return m_CampArr[Index];
	}
	public void SetCampArr( List<FightStormCampInfoWraper> v )
	{
		m_CampArr=v;
	}
	public void SetCampArr( int Index, FightStormCampInfoWraper v )
	{
		if(Index<0 || Index>=(int)m_CampArr.Count)
			return;
		m_CampArr[Index] = v;
	}
	public void AddCampArr( FightStormCampInfoWraper v )
	{
		m_CampArr.Add(v);
	}
	public void ClearCampArr( )
	{
		m_CampArr.Clear();
	}
	//是否为服务器发送
	public bool m_IsSvrSend;
	public bool IsSvrSend
	{
		get { return m_IsSvrSend;}
		set { m_IsSvrSend = value; }
	}


};
//暴风阵营结果统计信息封装类
[System.Serializable]
public class FightStormCampInfoWraper
{

	//构造函数
	public FightStormCampInfoWraper()
	{
		m_PlayerArr = new List<FightStormPlayerInfoWraper>();
		 m_CampId = -1;
		 m_TotalNum = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_PlayerArr = new List<FightStormPlayerInfoWraper>();
		 m_CampId = -1;
		 m_TotalNum = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormCampInfo ToPB()
	{
		FightStormCampInfo v = new FightStormCampInfo();
		for (int i=0; i<(int)m_PlayerArr.Count; i++)
			v.PlayerArr.Add( m_PlayerArr[i].ToPB());
		v.CampId = m_CampId;
		v.TotalNum = m_TotalNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormCampInfo v)
	{
        if (v == null)
            return;
		m_PlayerArr.Clear();
		for( int i=0; i<v.PlayerArr.Count; i++)
			m_PlayerArr.Add( new FightStormPlayerInfoWraper());
		for( int i=0; i<v.PlayerArr.Count; i++)
			m_PlayerArr[i].FromPB(v.PlayerArr[i]);
		m_CampId = v.CampId;
		m_TotalNum = v.TotalNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormCampInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormCampInfo pb = ProtoBuf.Serializer.Deserialize<FightStormCampInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//成员信息
	public List<FightStormPlayerInfoWraper> m_PlayerArr;
	public int SizePlayerArr()
	{
		return m_PlayerArr.Count;
	}
	public List<FightStormPlayerInfoWraper> GetPlayerArr()
	{
		return m_PlayerArr;
	}
	public FightStormPlayerInfoWraper GetPlayerArr(int Index)
	{
		if(Index<0 || Index>=(int)m_PlayerArr.Count)
			return new FightStormPlayerInfoWraper();
		return m_PlayerArr[Index];
	}
	public void SetPlayerArr( List<FightStormPlayerInfoWraper> v )
	{
		m_PlayerArr=v;
	}
	public void SetPlayerArr( int Index, FightStormPlayerInfoWraper v )
	{
		if(Index<0 || Index>=(int)m_PlayerArr.Count)
			return;
		m_PlayerArr[Index] = v;
	}
	public void AddPlayerArr( FightStormPlayerInfoWraper v )
	{
		m_PlayerArr.Add(v);
	}
	public void ClearPlayerArr( )
	{
		m_PlayerArr.Clear();
	}
	//阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}
	//资源总量
	public int m_TotalNum;
	public int TotalNum
	{
		get { return m_TotalNum;}
		set { m_TotalNum = value; }
	}


};
//暴风个人战斗统计信息封装类
[System.Serializable]
public class FightStormPlayerInfoWraper
{

	//构造函数
	public FightStormPlayerInfoWraper()
	{
		 m_KilledNum = 0;
		 m_DeadTimes = 0;
		 m_Name = "";
		 m_FlagTimes = 0;
		 m_Prof = -1;
		 m_OutputDamage = -1;
		 m_EndureDamage = -1;
		 m_TreatDamage = -1;
		 m_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_KilledNum = 0;
		 m_DeadTimes = 0;
		 m_Name = "";
		 m_FlagTimes = 0;
		 m_Prof = -1;
		 m_OutputDamage = -1;
		 m_EndureDamage = -1;
		 m_TreatDamage = -1;
		 m_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormPlayerInfo ToPB()
	{
		FightStormPlayerInfo v = new FightStormPlayerInfo();
		v.KilledNum = m_KilledNum;
		v.DeadTimes = m_DeadTimes;
		v.Name = m_Name;
		v.FlagTimes = m_FlagTimes;
		v.Prof = m_Prof;
		v.OutputDamage = m_OutputDamage;
		v.EndureDamage = m_EndureDamage;
		v.TreatDamage = m_TreatDamage;
		v.ObjId = m_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormPlayerInfo v)
	{
        if (v == null)
            return;
		m_KilledNum = v.KilledNum;
		m_DeadTimes = v.DeadTimes;
		m_Name = v.Name;
		m_FlagTimes = v.FlagTimes;
		m_Prof = v.Prof;
		m_OutputDamage = v.OutputDamage;
		m_EndureDamage = v.EndureDamage;
		m_TreatDamage = v.TreatDamage;
		m_ObjId = v.ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormPlayerInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormPlayerInfo pb = ProtoBuf.Serializer.Deserialize<FightStormPlayerInfo>(protoMS);
		FromPB(pb);
		return true;
	}

	//杀人数
	public int m_KilledNum;
	public int KilledNum
	{
		get { return m_KilledNum;}
		set { m_KilledNum = value; }
	}
	//死亡次数
	public int m_DeadTimes;
	public int DeadTimes
	{
		get { return m_DeadTimes;}
		set { m_DeadTimes = value; }
	}
	//名字
	public string m_Name;
	public string Name
	{
		get { return m_Name;}
		set { m_Name = value; }
	}
	//放旗数
	public int m_FlagTimes;
	public int FlagTimes
	{
		get { return m_FlagTimes;}
		set { m_FlagTimes = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}
	//总输出伤害
	public long m_OutputDamage;
	public long OutputDamage
	{
		get { return m_OutputDamage;}
		set { m_OutputDamage = value; }
	}
	//承受伤害
	public long m_EndureDamage;
	public long EndureDamage
	{
		get { return m_EndureDamage;}
		set { m_EndureDamage = value; }
	}
	//总治疗量
	public long m_TreatDamage;
	public long TreatDamage
	{
		get { return m_TreatDamage;}
		set { m_TreatDamage = value; }
	}
	//玩家ObjId
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}


};
//创建对像动作封装类
[System.Serializable]
public class FightCreateActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCreateActionWraper()
	{
		 m_UserId = -1;
		 m_ConfigId = -1;
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_ObjType = -1;
		 m_CampId = -1;
		 m_PosInfo2 = new byte[0];
		m_IntParaList = new List<int>();
		m_FloatParaList = new List<float>();
		 m_CurState = -1;
		 m_CurHp = -1;
		 m_Name = "";
		m_EquipBuffArr = new List<EquipSkillBuff2Wraper>();
		m_EquipSkillArr = new List<EquipSkillBuff2Wraper>();
		m_AttrArr = new List<KeyValue2Wraper>();
		 m_Level = -1;
		 m_TableType = -1;
		 m_IsShowEffect = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_ConfigId = -1;
		 m_ObjId = -1;
		 m_PosInfo = new byte[0];
		 m_ObjType = -1;
		 m_CampId = -1;
		 m_PosInfo2 = new byte[0];
		m_IntParaList = new List<int>();
		m_FloatParaList = new List<float>();
		 m_CurState = -1;
		 m_CurHp = -1;
		 m_Name = "";
		m_EquipBuffArr = new List<EquipSkillBuff2Wraper>();
		m_EquipSkillArr = new List<EquipSkillBuff2Wraper>();
		m_AttrArr = new List<KeyValue2Wraper>();
		 m_Level = -1;
		 m_TableType = -1;
		 m_IsShowEffect = false;

	}

 	//转化成Protobuffer类型函数
	public FightCreateAction ToPB()
	{
		FightCreateAction v = new FightCreateAction();
		v.UserId = m_UserId;
		v.ConfigId = m_ConfigId;
		v.ObjId = m_ObjId;
		v.PosInfo = m_PosInfo;
		v.ObjType = m_ObjType;
		v.CampId = m_CampId;
		v.PosInfo2 = m_PosInfo2;
		for (int i=0; i<(int)m_IntParaList.Count; i++)
			v.IntParaList.Add( m_IntParaList[i]);
		for (int i=0; i<(int)m_FloatParaList.Count; i++)
			v.FloatParaList.Add( m_FloatParaList[i]);
		v.CurState = m_CurState;
		v.CurHp = m_CurHp;
		v.Name = m_Name;
		for (int i=0; i<(int)m_EquipBuffArr.Count; i++)
			v.EquipBuffArr.Add( m_EquipBuffArr[i].ToPB());
		for (int i=0; i<(int)m_EquipSkillArr.Count; i++)
			v.EquipSkillArr.Add( m_EquipSkillArr[i].ToPB());
		for (int i=0; i<(int)m_AttrArr.Count; i++)
			v.AttrArr.Add( m_AttrArr[i].ToPB());
		v.Level = m_Level;
		v.TableType = m_TableType;
		v.IsShowEffect = m_IsShowEffect;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCreateAction v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_ConfigId = v.ConfigId;
		m_ObjId = v.ObjId;
		m_PosInfo = v.PosInfo;
		m_ObjType = v.ObjType;
		m_CampId = v.CampId;
		m_PosInfo2 = v.PosInfo2;
		m_IntParaList.Clear();
		for( int i=0; i<v.IntParaList.Count; i++)
			m_IntParaList.Add(v.IntParaList[i]);
		m_FloatParaList.Clear();
		for( int i=0; i<v.FloatParaList.Count; i++)
			m_FloatParaList.Add(v.FloatParaList[i]);
		m_CurState = v.CurState;
		m_CurHp = v.CurHp;
		m_Name = v.Name;
		m_EquipBuffArr.Clear();
		for( int i=0; i<v.EquipBuffArr.Count; i++)
			m_EquipBuffArr.Add( new EquipSkillBuff2Wraper());
		for( int i=0; i<v.EquipBuffArr.Count; i++)
			m_EquipBuffArr[i].FromPB(v.EquipBuffArr[i]);
		m_EquipSkillArr.Clear();
		for( int i=0; i<v.EquipSkillArr.Count; i++)
			m_EquipSkillArr.Add( new EquipSkillBuff2Wraper());
		for( int i=0; i<v.EquipSkillArr.Count; i++)
			m_EquipSkillArr[i].FromPB(v.EquipSkillArr[i]);
		m_AttrArr.Clear();
		for( int i=0; i<v.AttrArr.Count; i++)
			m_AttrArr.Add( new KeyValue2Wraper());
		for( int i=0; i<v.AttrArr.Count; i++)
			m_AttrArr[i].FromPB(v.AttrArr[i]);
		m_Level = v.Level;
		m_TableType = v.TableType;
		m_IsShowEffect = v.IsShowEffect;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCreateAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCreateAction pb = ProtoBuf.Serializer.Deserialize<FightCreateAction>(protoMS);
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
	//配置文件中的ID
	public int m_ConfigId;
	public int ConfigId
	{
		get { return m_ConfigId;}
		set { m_ConfigId = value; }
	}
	//内核中用到的对像ID
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//创建类型 
	public int m_ObjType;
	public int ObjType
	{
		get { return m_ObjType;}
		set { m_ObjType = value; }
	}
	//阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}
	//位置信息
	public byte[] m_PosInfo2;
	public byte[] PosInfo2
	{
		get { return m_PosInfo2;}
		set { m_PosInfo2 = value; }
	}
	//整数参数列表
	public List<int> m_IntParaList;
	public int SizeIntParaList()
	{
		return m_IntParaList.Count;
	}
	public List<int> GetIntParaList()
	{
		return m_IntParaList;
	}
	public int GetIntParaList(int Index)
	{
		if(Index<0 || Index>=(int)m_IntParaList.Count)
			return -1;
		return m_IntParaList[Index];
	}
	public void SetIntParaList( List<int> v )
	{
		m_IntParaList=v;
	}
	public void SetIntParaList( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_IntParaList.Count)
			return;
		m_IntParaList[Index] = v;
	}
	public void AddIntParaList( int v=-1 )
	{
		m_IntParaList.Add(v);
	}
	public void ClearIntParaList( )
	{
		m_IntParaList.Clear();
	}
	//字符串参数列表
	public List<float> m_FloatParaList;
	public int SizeFloatParaList()
	{
		return m_FloatParaList.Count;
	}
	public List<float> GetFloatParaList()
	{
		return m_FloatParaList;
	}
	public float GetFloatParaList(int Index)
	{
		if(Index<0 || Index>=(int)m_FloatParaList.Count)
			return -1;
		return m_FloatParaList[Index];
	}
	public void SetFloatParaList( List<float> v )
	{
		m_FloatParaList=v;
	}
	public void SetFloatParaList( int Index, float v )
	{
		if(Index<0 || Index>=(int)m_FloatParaList.Count)
			return;
		m_FloatParaList[Index] = v;
	}
	public void AddFloatParaList( float v=-1 )
	{
		m_FloatParaList.Add(v);
	}
	public void ClearFloatParaList( )
	{
		m_FloatParaList.Clear();
	}
	//当前状态
	public int m_CurState;
	public int CurState
	{
		get { return m_CurState;}
		set { m_CurState = value; }
	}
	//当前血量
	public int m_CurHp;
	public int CurHp
	{
		get { return m_CurHp;}
		set { m_CurHp = value; }
	}
	//名字
	public string m_Name;
	public string Name
	{
		get { return m_Name;}
		set { m_Name = value; }
	}
	//装备的BUFF列表
	public List<EquipSkillBuff2Wraper> m_EquipBuffArr;
	public int SizeEquipBuffArr()
	{
		return m_EquipBuffArr.Count;
	}
	public List<EquipSkillBuff2Wraper> GetEquipBuffArr()
	{
		return m_EquipBuffArr;
	}
	public EquipSkillBuff2Wraper GetEquipBuffArr(int Index)
	{
		if(Index<0 || Index>=(int)m_EquipBuffArr.Count)
			return new EquipSkillBuff2Wraper();
		return m_EquipBuffArr[Index];
	}
	public void SetEquipBuffArr( List<EquipSkillBuff2Wraper> v )
	{
		m_EquipBuffArr=v;
	}
	public void SetEquipBuffArr( int Index, EquipSkillBuff2Wraper v )
	{
		if(Index<0 || Index>=(int)m_EquipBuffArr.Count)
			return;
		m_EquipBuffArr[Index] = v;
	}
	public void AddEquipBuffArr( EquipSkillBuff2Wraper v )
	{
		m_EquipBuffArr.Add(v);
	}
	public void ClearEquipBuffArr( )
	{
		m_EquipBuffArr.Clear();
	}
	//装备的技能
	public List<EquipSkillBuff2Wraper> m_EquipSkillArr;
	public int SizeEquipSkillArr()
	{
		return m_EquipSkillArr.Count;
	}
	public List<EquipSkillBuff2Wraper> GetEquipSkillArr()
	{
		return m_EquipSkillArr;
	}
	public EquipSkillBuff2Wraper GetEquipSkillArr(int Index)
	{
		if(Index<0 || Index>=(int)m_EquipSkillArr.Count)
			return new EquipSkillBuff2Wraper();
		return m_EquipSkillArr[Index];
	}
	public void SetEquipSkillArr( List<EquipSkillBuff2Wraper> v )
	{
		m_EquipSkillArr=v;
	}
	public void SetEquipSkillArr( int Index, EquipSkillBuff2Wraper v )
	{
		if(Index<0 || Index>=(int)m_EquipSkillArr.Count)
			return;
		m_EquipSkillArr[Index] = v;
	}
	public void AddEquipSkillArr( EquipSkillBuff2Wraper v )
	{
		m_EquipSkillArr.Add(v);
	}
	public void ClearEquipSkillArr( )
	{
		m_EquipSkillArr.Clear();
	}
	//属性列表
	public List<KeyValue2Wraper> m_AttrArr;
	public int SizeAttrArr()
	{
		return m_AttrArr.Count;
	}
	public List<KeyValue2Wraper> GetAttrArr()
	{
		return m_AttrArr;
	}
	public KeyValue2Wraper GetAttrArr(int Index)
	{
		if(Index<0 || Index>=(int)m_AttrArr.Count)
			return new KeyValue2Wraper();
		return m_AttrArr[Index];
	}
	public void SetAttrArr( List<KeyValue2Wraper> v )
	{
		m_AttrArr=v;
	}
	public void SetAttrArr( int Index, KeyValue2Wraper v )
	{
		if(Index<0 || Index>=(int)m_AttrArr.Count)
			return;
		m_AttrArr[Index] = v;
	}
	public void AddAttrArr( KeyValue2Wraper v )
	{
		m_AttrArr.Add(v);
	}
	public void ClearAttrArr( )
	{
		m_AttrArr.Clear();
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//TableType
	public int m_TableType;
	public int TableType
	{
		get { return m_TableType;}
		set { m_TableType = value; }
	}
	//是否显示特效
	public bool m_IsShowEffect;
	public bool IsShowEffect
	{
		get { return m_IsShowEffect;}
		set { m_IsShowEffect = value; }
	}


};
//快速杀怪动作封装类
[System.Serializable]
public class FightQuickFinishActionWraper : BattleKernel.Action
{

	//构造函数
	public FightQuickFinishActionWraper()
	{
		 m_Type = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = 0;

	}

 	//转化成Protobuffer类型函数
	public FightQuickFinishAction ToPB()
	{
		FightQuickFinishAction v = new FightQuickFinishAction();
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightQuickFinishAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightQuickFinishAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightQuickFinishAction pb = ProtoBuf.Serializer.Deserialize<FightQuickFinishAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//杀对像类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//节点或副本结束封装类
[System.Serializable]
public class FightFinishLevelActionWraper : BattleKernel.Action
{

	//构造函数
	public FightFinishLevelActionWraper()
	{
		 m_Result = -1;
		 m_Type = 2;
		 m_WallObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -1;
		 m_Type = 2;
		 m_WallObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightFinishLevelAction ToPB()
	{
		FightFinishLevelAction v = new FightFinishLevelAction();
		v.Result = m_Result;
		v.Type = m_Type;
		v.WallObjId = m_WallObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightFinishLevelAction v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Type = v.Type;
		m_WallObjId = v.WallObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightFinishLevelAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightFinishLevelAction pb = ProtoBuf.Serializer.Deserialize<FightFinishLevelAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//战局情况
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//节点墙ObjId
	public int m_WallObjId;
	public int WallObjId
	{
		get { return m_WallObjId;}
		set { m_WallObjId = value; }
	}


};
//塔锁定对象动作封装类
[System.Serializable]
public class FightTowerLockActionWraper : BattleKernel.Action
{

	//构造函数
	public FightTowerLockActionWraper()
	{
		 m_TargetObjId = -1;
		 m_ObjId = -1;
		 m_Type = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TargetObjId = -1;
		 m_ObjId = -1;
		 m_Type = 0;

	}

 	//转化成Protobuffer类型函数
	public FightTowerLockAction ToPB()
	{
		FightTowerLockAction v = new FightTowerLockAction();
		v.TargetObjId = m_TargetObjId;
		v.ObjId = m_ObjId;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightTowerLockAction v)
	{
        if (v == null)
            return;
		m_TargetObjId = v.TargetObjId;
		m_ObjId = v.ObjId;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightTowerLockAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightTowerLockAction pb = ProtoBuf.Serializer.Deserialize<FightTowerLockAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//目标ObjId
	public int m_TargetObjId;
	public int TargetObjId
	{
		get { return m_TargetObjId;}
		set { m_TargetObjId = value; }
	}
	//obj id
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//暴风战斗开始封装类
[System.Serializable]
public class FightStormStartActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormStartActionWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormStartAction ToPB()
	{
		FightStormStartAction v = new FightStormStartAction();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormStartAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormStartAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormStartAction pb = ProtoBuf.Serializer.Deserialize<FightStormStartAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时或剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//大逃杀开始封装类
[System.Serializable]
public class FightEscapeStartActionWraper : BattleKernel.Action
{

	//构造函数
	public FightEscapeStartActionWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightEscapeStartAction ToPB()
	{
		FightEscapeStartAction v = new FightEscapeStartAction();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightEscapeStartAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightEscapeStartAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightEscapeStartAction pb = ProtoBuf.Serializer.Deserialize<FightEscapeStartAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时或剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//大逃杀结果封装类
[System.Serializable]
public class FightEscapeResultActionWraper : BattleKernel.Action
{

	//构造函数
	public FightEscapeResultActionWraper()
	{
		 m_Result = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -1;

	}

 	//转化成Protobuffer类型函数
	public FightEscapeResultAction ToPB()
	{
		FightEscapeResultAction v = new FightEscapeResultAction();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightEscapeResultAction v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightEscapeResultAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightEscapeResultAction pb = ProtoBuf.Serializer.Deserialize<FightEscapeResultAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//GM加减血量封装类
[System.Serializable]
public class FightGMAddHpActionWraper : BattleKernel.Action
{

	//构造函数
	public FightGMAddHpActionWraper()
	{
		 m_ObjId = -1;
		 m_AddNum = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_AddNum = -1;

	}

 	//转化成Protobuffer类型函数
	public FightGMAddHpAction ToPB()
	{
		FightGMAddHpAction v = new FightGMAddHpAction();
		v.ObjId = m_ObjId;
		v.AddNum = m_AddNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightGMAddHpAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_AddNum = v.AddNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightGMAddHpAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightGMAddHpAction pb = ProtoBuf.Serializer.Deserialize<FightGMAddHpAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//对像ID
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//加血量
	public int m_AddNum;
	public int AddNum
	{
		get { return m_AddNum;}
		set { m_AddNum = value; }
	}


};
//所有人随机放技能封装类
[System.Serializable]
public class FightTRandSkillActionWraper : BattleKernel.Action
{

	//构造函数
	public FightTRandSkillActionWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public FightTRandSkillAction ToPB()
	{
		FightTRandSkillAction v = new FightTRandSkillAction();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightTRandSkillAction v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightTRandSkillAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightTRandSkillAction pb = ProtoBuf.Serializer.Deserialize<FightTRandSkillAction>(protoMS);
		FromPB(pb);
		return true;
	}



};
//帮会副本开始封装类
[System.Serializable]
public class FightGuildDBeginActionWraper : BattleKernel.Action
{

	//构造函数
	public FightGuildDBeginActionWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightGuildDBeginAction ToPB()
	{
		FightGuildDBeginAction v = new FightGuildDBeginAction();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightGuildDBeginAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightGuildDBeginAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightGuildDBeginAction pb = ProtoBuf.Serializer.Deserialize<FightGuildDBeginAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//帮会副本结束封装类
[System.Serializable]
public class FightGuildDEndActionWraper : BattleKernel.Action
{

	//构造函数
	public FightGuildDEndActionWraper()
	{
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightGuildDEndAction ToPB()
	{
		FightGuildDEndAction v = new FightGuildDEndAction();
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightGuildDEndAction v)
	{
        if (v == null)
            return;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightGuildDEndAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightGuildDEndAction pb = ProtoBuf.Serializer.Deserialize<FightGuildDEndAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//场景间传送封装类
[System.Serializable]
public class FightTransferActionWraper : BattleKernel.Action
{

	//构造函数
	public FightTransferActionWraper()
	{
		 m_DungeonId = -1;
		 m_DungeonType = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;
		 m_DungeonType = -1;
		 m_BirthPoint = -1;
		 m_FaceDir = 0;

	}

 	//转化成Protobuffer类型函数
	public FightTransferAction ToPB()
	{
		FightTransferAction v = new FightTransferAction();
		v.DungeonId = m_DungeonId;
		v.DungeonType = m_DungeonType;
		v.BirthPoint = m_BirthPoint;
		v.FaceDir = m_FaceDir;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightTransferAction v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;
		m_DungeonType = v.DungeonType;
		m_BirthPoint = v.BirthPoint;
		m_FaceDir = v.FaceDir;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightTransferAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightTransferAction pb = ProtoBuf.Serializer.Deserialize<FightTransferAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//场景ID
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//场景类型
	public int m_DungeonType;
	public int DungeonType
	{
		get { return m_DungeonType;}
		set { m_DungeonType = value; }
	}
	//出生点
	public int m_BirthPoint;
	public int BirthPoint
	{
		get { return m_BirthPoint;}
		set { m_BirthPoint = value; }
	}
	//朝向
	public int m_FaceDir;
	public int FaceDir
	{
		get { return m_FaceDir;}
		set { m_FaceDir = value; }
	}


};
//英雄战斗信息封装类
[System.Serializable]
public class FightHeroFightInfoActionWraper : BattleKernel.Action
{

	//构造函数
	public FightHeroFightInfoActionWraper()
	{
		m_HeroInfoArr = new List<HeroFightInfoWraper>();
		 m_FunctionId = -1;
		 m_MyCampId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_HeroInfoArr = new List<HeroFightInfoWraper>();
		 m_FunctionId = -1;
		 m_MyCampId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightHeroFightInfoAction ToPB()
	{
		FightHeroFightInfoAction v = new FightHeroFightInfoAction();
		for (int i=0; i<(int)m_HeroInfoArr.Count; i++)
			v.HeroInfoArr.Add( m_HeroInfoArr[i].ToPB());
		v.FunctionId = m_FunctionId;
		v.MyCampId = m_MyCampId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightHeroFightInfoAction v)
	{
        if (v == null)
            return;
		m_HeroInfoArr.Clear();
		for( int i=0; i<v.HeroInfoArr.Count; i++)
			m_HeroInfoArr.Add( new HeroFightInfoWraper());
		for( int i=0; i<v.HeroInfoArr.Count; i++)
			m_HeroInfoArr[i].FromPB(v.HeroInfoArr[i]);
		m_FunctionId = v.FunctionId;
		m_MyCampId = v.MyCampId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightHeroFightInfoAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightHeroFightInfoAction pb = ProtoBuf.Serializer.Deserialize<FightHeroFightInfoAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//英雄信息列表
	public List<HeroFightInfoWraper> m_HeroInfoArr;
	public int SizeHeroInfoArr()
	{
		return m_HeroInfoArr.Count;
	}
	public List<HeroFightInfoWraper> GetHeroInfoArr()
	{
		return m_HeroInfoArr;
	}
	public HeroFightInfoWraper GetHeroInfoArr(int Index)
	{
		if(Index<0 || Index>=(int)m_HeroInfoArr.Count)
			return new HeroFightInfoWraper();
		return m_HeroInfoArr[Index];
	}
	public void SetHeroInfoArr( List<HeroFightInfoWraper> v )
	{
		m_HeroInfoArr=v;
	}
	public void SetHeroInfoArr( int Index, HeroFightInfoWraper v )
	{
		if(Index<0 || Index>=(int)m_HeroInfoArr.Count)
			return;
		m_HeroInfoArr[Index] = v;
	}
	public void AddHeroInfoArr( HeroFightInfoWraper v )
	{
		m_HeroInfoArr.Add(v);
	}
	public void ClearHeroInfoArr( )
	{
		m_HeroInfoArr.Clear();
	}
	//副本功能类型
	public int m_FunctionId;
	public int FunctionId
	{
		get { return m_FunctionId;}
		set { m_FunctionId = value; }
	}
	//自己的阵营ID
	public int m_MyCampId;
	public int MyCampId
	{
		get { return m_MyCampId;}
		set { m_MyCampId = value; }
	}


};
//帮会战开始封装类
[System.Serializable]
public class FightGuildFightBeginActionWraper : BattleKernel.Action
{

	//构造函数
	public FightGuildFightBeginActionWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightGuildFightBeginAction ToPB()
	{
		FightGuildFightBeginAction v = new FightGuildFightBeginAction();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightGuildFightBeginAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightGuildFightBeginAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightGuildFightBeginAction pb = ProtoBuf.Serializer.Deserialize<FightGuildFightBeginAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//帮会战结束封装类
[System.Serializable]
public class FightGuildFightEndActionWraper : BattleKernel.Action
{

	//构造函数
	public FightGuildFightEndActionWraper()
	{
		 m_Time = -1;
		 m_VictoryCampId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Time = -1;
		 m_VictoryCampId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightGuildFightEndAction ToPB()
	{
		FightGuildFightEndAction v = new FightGuildFightEndAction();
		v.Time = m_Time;
		v.VictoryCampId = m_VictoryCampId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightGuildFightEndAction v)
	{
        if (v == null)
            return;
		m_Time = v.Time;
		m_VictoryCampId = v.VictoryCampId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightGuildFightEndAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightGuildFightEndAction pb = ProtoBuf.Serializer.Deserialize<FightGuildFightEndAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}
	//胜利阵营
	public int m_VictoryCampId;
	public int VictoryCampId
	{
		get { return m_VictoryCampId;}
		set { m_VictoryCampId = value; }
	}


};
//帮会战阵营血量信息封装类
[System.Serializable]
public class FightGuildFightHpActionWraper : BattleKernel.Action
{

	//构造函数
	public FightGuildFightHpActionWraper()
	{
		 m_CampId = -1;
		 m_MaxHp = 0;
		 m_CurHp = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_CampId = -1;
		 m_MaxHp = 0;
		 m_CurHp = 0;

	}

 	//转化成Protobuffer类型函数
	public FightGuildFightHpAction ToPB()
	{
		FightGuildFightHpAction v = new FightGuildFightHpAction();
		v.CampId = m_CampId;
		v.MaxHp = m_MaxHp;
		v.CurHp = m_CurHp;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightGuildFightHpAction v)
	{
        if (v == null)
            return;
		m_CampId = v.CampId;
		m_MaxHp = v.MaxHp;
		m_CurHp = v.CurHp;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightGuildFightHpAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightGuildFightHpAction pb = ProtoBuf.Serializer.Deserialize<FightGuildFightHpAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//阵营ID
	public int m_CampId;
	public int CampId
	{
		get { return m_CampId;}
		set { m_CampId = value; }
	}
	//最大血量
	public int m_MaxHp;
	public int MaxHp
	{
		get { return m_MaxHp;}
		set { m_MaxHp = value; }
	}
	//当前血量
	public int m_CurHp;
	public int CurHp
	{
		get { return m_CurHp;}
		set { m_CurHp = value; }
	}


};
//移动控制动作封装类
[System.Serializable]
public class FightEffectTranslateActionWraper : BattleKernel.Action
{

	//构造函数
	public FightEffectTranslateActionWraper()
	{
		 m_ObjId = -1;
		 m_ObjType = -1;
		 m_TargetObjId = -1;
		 m_TargetPos = new byte[0];
		 m_Angle = -1;
		 m_Speed = -1;
		 m_Distance = -1;
		 m_PosInfo = new byte[0];
		 m_Status = 0;
		 m_SkillId = -1;
		 m_SegementIndex = -1;
		 m_SpriteName = "";
		 m_BulletType = -1;
		 m_IsIrregularityEffect = false;
		 m_TranslateType = 0;
		 m_Time = (float)-1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_ObjType = -1;
		 m_TargetObjId = -1;
		 m_TargetPos = new byte[0];
		 m_Angle = -1;
		 m_Speed = -1;
		 m_Distance = -1;
		 m_PosInfo = new byte[0];
		 m_Status = 0;
		 m_SkillId = -1;
		 m_SegementIndex = -1;
		 m_SpriteName = "";
		 m_BulletType = -1;
		 m_IsIrregularityEffect = false;
		 m_TranslateType = 0;
		 m_Time = (float)-1;

	}

 	//转化成Protobuffer类型函数
	public FightEffectTranslateAction ToPB()
	{
		FightEffectTranslateAction v = new FightEffectTranslateAction();
		v.ObjId = m_ObjId;
		v.ObjType = m_ObjType;
		v.TargetObjId = m_TargetObjId;
		v.TargetPos = m_TargetPos;
		v.Angle = m_Angle;
		v.Speed = m_Speed;
		v.Distance = m_Distance;
		v.PosInfo = m_PosInfo;
		v.Status = m_Status;
		v.SkillId = m_SkillId;
		v.SegementIndex = m_SegementIndex;
		v.SpriteName = m_SpriteName;
		v.BulletType = m_BulletType;
		v.IsIrregularityEffect = m_IsIrregularityEffect;
		v.TranslateType = m_TranslateType;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightEffectTranslateAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_ObjType = v.ObjType;
		m_TargetObjId = v.TargetObjId;
		m_TargetPos = v.TargetPos;
		m_Angle = v.Angle;
		m_Speed = v.Speed;
		m_Distance = v.Distance;
		m_PosInfo = v.PosInfo;
		m_Status = v.Status;
		m_SkillId = v.SkillId;
		m_SegementIndex = v.SegementIndex;
		m_SpriteName = v.SpriteName;
		m_BulletType = v.BulletType;
		m_IsIrregularityEffect = v.IsIrregularityEffect;
		m_TranslateType = v.TranslateType;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightEffectTranslateAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightEffectTranslateAction pb = ProtoBuf.Serializer.Deserialize<FightEffectTranslateAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//对像ID
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//对像类型
	public int m_ObjType;
	public int ObjType
	{
		get { return m_ObjType;}
		set { m_ObjType = value; }
	}
	//目标对像ID
	public int m_TargetObjId;
	public int TargetObjId
	{
		get { return m_TargetObjId;}
		set { m_TargetObjId = value; }
	}
	//目标位置
	public byte[] m_TargetPos;
	public byte[] TargetPos
	{
		get { return m_TargetPos;}
		set { m_TargetPos = value; }
	}
	//方向角
	public int m_Angle;
	public int Angle
	{
		get { return m_Angle;}
		set { m_Angle = value; }
	}
	//速度
	public int m_Speed;
	public int Speed
	{
		get { return m_Speed;}
		set { m_Speed = value; }
	}
	//距离
	public int m_Distance;
	public int Distance
	{
		get { return m_Distance;}
		set { m_Distance = value; }
	}
	//对像自身位置
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//状态
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}
	//SkillId
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//技能段索引
	public int m_SegementIndex;
	public int SegementIndex
	{
		get { return m_SegementIndex;}
		set { m_SegementIndex = value; }
	}
	//spriteName
	public string m_SpriteName;
	public string SpriteName
	{
		get { return m_SpriteName;}
		set { m_SpriteName = value; }
	}
	//子弹类型
	public int m_BulletType;
	public int BulletType
	{
		get { return m_BulletType;}
		set { m_BulletType = value; }
	}
	//IsIrregularityEffect
	public bool m_IsIrregularityEffect;
	public bool IsIrregularityEffect
	{
		get { return m_IsIrregularityEffect;}
		set { m_IsIrregularityEffect = value; }
	}
	//TranslateType
	public int m_TranslateType;
	public int TranslateType
	{
		get { return m_TranslateType;}
		set { m_TranslateType = value; }
	}
	//Time
	public float m_Time;
	public float Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//采集封装类
[System.Serializable]
public class FightCollectActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCollectActionWraper()
	{
		 m_Status = 1;
		 m_Player_ObjId = -1;
		 m_Collection_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Status = 1;
		 m_Player_ObjId = -1;
		 m_Collection_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightCollectAction ToPB()
	{
		FightCollectAction v = new FightCollectAction();
		v.Status = m_Status;
		v.Player_ObjId = m_Player_ObjId;
		v.Collection_ObjId = m_Collection_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCollectAction v)
	{
        if (v == null)
            return;
		m_Status = v.Status;
		m_Player_ObjId = v.Player_ObjId;
		m_Collection_ObjId = v.Collection_ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCollectAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCollectAction pb = ProtoBuf.Serializer.Deserialize<FightCollectAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//1是开始,2是结束,3是中断
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}
	//玩家的ObjId
	public int m_Player_ObjId;
	public int Player_ObjId
	{
		get { return m_Player_ObjId;}
		set { m_Player_ObjId = value; }
	}
	//采集物品的ObjId
	public int m_Collection_ObjId;
	public int Collection_ObjId
	{
		get { return m_Collection_ObjId;}
		set { m_Collection_ObjId = value; }
	}


};
//采集物是否播特效封装类
[System.Serializable]
public class FightCollectionShowEffectActionWraper : BattleKernel.Action
{

	//构造函数
	public FightCollectionShowEffectActionWraper()
	{
		 m_ObjId = -1;
		 m_IsShowEffect = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_IsShowEffect = false;

	}

 	//转化成Protobuffer类型函数
	public FightCollectionShowEffectAction ToPB()
	{
		FightCollectionShowEffectAction v = new FightCollectionShowEffectAction();
		v.ObjId = m_ObjId;
		v.IsShowEffect = m_IsShowEffect;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightCollectionShowEffectAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_IsShowEffect = v.IsShowEffect;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightCollectionShowEffectAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightCollectionShowEffectAction pb = ProtoBuf.Serializer.Deserialize<FightCollectionShowEffectAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//内核中用到的对像ID
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//是否显示特效
	public bool m_IsShowEffect;
	public bool IsShowEffect
	{
		get { return m_IsShowEffect;}
		set { m_IsShowEffect = value; }
	}


};
//自动战斗封装类
[System.Serializable]
public class FightAutoFightActionWraper : BattleKernel.Action
{

	//构造函数
	public FightAutoFightActionWraper()
	{
		 m_Type = 0;
		 m_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = 0;
		 m_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightAutoFightAction ToPB()
	{
		FightAutoFightAction v = new FightAutoFightAction();
		v.Type = m_Type;
		v.ObjId = m_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightAutoFightAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_ObjId = v.ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightAutoFightAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightAutoFightAction pb = ProtoBuf.Serializer.Deserialize<FightAutoFightAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//内核中用到的对像ID
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}


};
//使用道具封装类
[System.Serializable]
public class FightUseItemActionWraper : BattleKernel.Action
{

	//构造函数
	public FightUseItemActionWraper()
	{
		 m_TemplateId = -1;
		 m_Status = 1;
		 m_Player_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TemplateId = -1;
		 m_Status = 1;
		 m_Player_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightUseItemAction ToPB()
	{
		FightUseItemAction v = new FightUseItemAction();
		v.TemplateId = m_TemplateId;
		v.Status = m_Status;
		v.Player_ObjId = m_Player_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightUseItemAction v)
	{
        if (v == null)
            return;
		m_TemplateId = v.TemplateId;
		m_Status = v.Status;
		m_Player_ObjId = v.Player_ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightUseItemAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightUseItemAction pb = ProtoBuf.Serializer.Deserialize<FightUseItemAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//道具配置Id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//1是开始,2是结束,3是中断
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}
	//玩家的ObjId
	public int m_Player_ObjId;
	public int Player_ObjId
	{
		get { return m_Player_ObjId;}
		set { m_Player_ObjId = value; }
	}


};
//五行旗杀人特效封装类
[System.Serializable]
public class FightStormKillEffectActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStormKillEffectActionWraper()
	{
		 m_ObjId = -1;
		 m_Num = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ObjId = -1;
		 m_Num = -1;

	}

 	//转化成Protobuffer类型函数
	public FightStormKillEffectAction ToPB()
	{
		FightStormKillEffectAction v = new FightStormKillEffectAction();
		v.ObjId = m_ObjId;
		v.Num = m_Num;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStormKillEffectAction v)
	{
        if (v == null)
            return;
		m_ObjId = v.ObjId;
		m_Num = v.Num;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStormKillEffectAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStormKillEffectAction pb = ProtoBuf.Serializer.Deserialize<FightStormKillEffectAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//自己
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//杀人数量
	public int m_Num;
	public int Num
	{
		get { return m_Num;}
		set { m_Num = value; }
	}


};
//1V1开始封装类
[System.Serializable]
public class FightOneVSOneStartActionWraper : BattleKernel.Action
{

	//构造函数
	public FightOneVSOneStartActionWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public FightOneVSOneStartAction ToPB()
	{
		FightOneVSOneStartAction v = new FightOneVSOneStartAction();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightOneVSOneStartAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightOneVSOneStartAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightOneVSOneStartAction pb = ProtoBuf.Serializer.Deserialize<FightOneVSOneStartAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//倒计时或剩余时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//1V1结果封装类
[System.Serializable]
public class FightOneVSOneResultActionWraper : BattleKernel.Action
{

	//构造函数
	public FightOneVSOneResultActionWraper()
	{
		 m_Result = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -1;

	}

 	//转化成Protobuffer类型函数
	public FightOneVSOneResultAction ToPB()
	{
		FightOneVSOneResultAction v = new FightOneVSOneResultAction();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightOneVSOneResultAction v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightOneVSOneResultAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightOneVSOneResultAction pb = ProtoBuf.Serializer.Deserialize<FightOneVSOneResultAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//结果
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//视野变化封装类
[System.Serializable]
public class FightSightActionWraper : BattleKernel.Action
{

	//构造函数
	public FightSightActionWraper()
	{
		m_ActionArr = new List<byte[]>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_ActionArr = new List<byte[]>();

	}

 	//转化成Protobuffer类型函数
	public FightSightAction ToPB()
	{
		FightSightAction v = new FightSightAction();
		for (int i=0; i<(int)m_ActionArr.Count; i++)
			v.ActionArr.Add( m_ActionArr[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightSightAction v)
	{
        if (v == null)
            return;
		m_ActionArr.Clear();
		for( int i=0; i<v.ActionArr.Count; i++)
			m_ActionArr.Add(v.ActionArr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightSightAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightSightAction pb = ProtoBuf.Serializer.Deserialize<FightSightAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//创建的Action列表
	public List<byte[]> m_ActionArr;
	public int SizeActionArr()
	{
		return m_ActionArr.Count;
	}
	public List<byte[]> GetActionArr()
	{
		return m_ActionArr;
	}
	public byte[] GetActionArr(int Index)
	{
		if(Index<0 || Index>=(int)m_ActionArr.Count)
			return new byte[0];
		return m_ActionArr[Index];
	}
	public void SetActionArr( List<byte[]> v )
	{
		m_ActionArr=v;
	}
	public void SetActionArr( int Index, byte[] v )
	{
		if(Index<0 || Index>=(int)m_ActionArr.Count)
			return;
		m_ActionArr[Index] = v;
	}
	public void AddActionArr( byte[] v )
	{
		m_ActionArr.Add(v);
	}
	public void ClearActionArr( )
	{
		m_ActionArr.Clear();
	}


};
//事件触发封装类
[System.Serializable]
public class FightEventTriggerActionWraper : BattleKernel.Action
{

	//构造函数
	public FightEventTriggerActionWraper()
	{
		 m_EventId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_EventId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightEventTriggerAction ToPB()
	{
		FightEventTriggerAction v = new FightEventTriggerAction();
		v.EventId = m_EventId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightEventTriggerAction v)
	{
        if (v == null)
            return;
		m_EventId = v.EventId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightEventTriggerAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightEventTriggerAction pb = ProtoBuf.Serializer.Deserialize<FightEventTriggerAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//事件配置Id
	public int m_EventId;
	public int EventId
	{
		get { return m_EventId;}
		set { m_EventId = value; }
	}


};
//QuitAction封装类
[System.Serializable]
public class FightQuitActionWraper : BattleKernel.Action
{

	//构造函数
	public FightQuitActionWraper()
	{
		 m_Type = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = 0;

	}

 	//转化成Protobuffer类型函数
	public FightQuitAction ToPB()
	{
		FightQuitAction v = new FightQuitAction();
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightQuitAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightQuitAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightQuitAction pb = ProtoBuf.Serializer.Deserialize<FightQuitAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//type类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//生产封装类
[System.Serializable]
public class FightProductActionWraper : BattleKernel.Action
{

	//构造函数
	public FightProductActionWraper()
	{
		 m_Status = -1;
		 m_LifeSkillId = -1;
		 m_Player_ObjId = -1;
		 m_ProductionId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Status = -1;
		 m_LifeSkillId = -1;
		 m_Player_ObjId = -1;
		 m_ProductionId = -1;

	}

 	//转化成Protobuffer类型函数
	public FightProductAction ToPB()
	{
		FightProductAction v = new FightProductAction();
		v.Status = m_Status;
		v.LifeSkillId = m_LifeSkillId;
		v.Player_ObjId = m_Player_ObjId;
		v.ProductionId = m_ProductionId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightProductAction v)
	{
        if (v == null)
            return;
		m_Status = v.Status;
		m_LifeSkillId = v.LifeSkillId;
		m_Player_ObjId = v.Player_ObjId;
		m_ProductionId = v.ProductionId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightProductAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightProductAction pb = ProtoBuf.Serializer.Deserialize<FightProductAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//1是开始,2是结束,3是中断
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}
	//生活技能表ID
	public int m_LifeSkillId;
	public int LifeSkillId
	{
		get { return m_LifeSkillId;}
		set { m_LifeSkillId = value; }
	}
	//玩家的ObjId
	public int m_Player_ObjId;
	public int Player_ObjId
	{
		get { return m_Player_ObjId;}
		set { m_Player_ObjId = value; }
	}
	//产出物品id
	public int m_ProductionId;
	public int ProductionId
	{
		get { return m_ProductionId;}
		set { m_ProductionId = value; }
	}


};
//开始结束封装类
[System.Serializable]
public class FightStartEndActionWraper : BattleKernel.Action
{

	//构造函数
	public FightStartEndActionWraper()
	{
		 m_Type = 0;
		 m_Time = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = 0;
		 m_Time = 0;

	}

 	//转化成Protobuffer类型函数
	public FightStartEndAction ToPB()
	{
		FightStartEndAction v = new FightStartEndAction();
		v.Type = m_Type;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(FightStartEndAction v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<FightStartEndAction>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		FightStartEndAction pb = ProtoBuf.Serializer.Deserialize<FightStartEndAction>(protoMS);
		FromPB(pb);
		return true;
	}

	//0:开始, 1:结束
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//秒时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
