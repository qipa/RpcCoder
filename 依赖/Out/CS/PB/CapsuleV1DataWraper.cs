
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBCapsule.cs
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


//扭蛋对象封装类
[System.Serializable]
public class CapsuleCapsuleObjWraperV1
{

	//构造函数
	public CapsuleCapsuleObjWraperV1()
	{
		 m_Id = -1;
		 m_CumulativeUse = -1;
		 m_FreeCount = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_CumulativeUse = -1;
		 m_FreeCount = -1;

	}

 	//转化成Protobuffer类型函数
	public CapsuleCapsuleObjV1 ToPB()
	{
		CapsuleCapsuleObjV1 v = new CapsuleCapsuleObjV1();
		v.Id = m_Id;
		v.CumulativeUse = m_CumulativeUse;
		v.FreeCount = m_FreeCount;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(CapsuleCapsuleObjV1 v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_CumulativeUse = v.CumulativeUse;
		m_FreeCount = v.FreeCount;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<CapsuleCapsuleObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		CapsuleCapsuleObjV1 pb = ProtoBuf.Serializer.Deserialize<CapsuleCapsuleObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//扭蛋id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//累计使用次数
	public int m_CumulativeUse;
	public int CumulativeUse
	{
		get { return m_CumulativeUse;}
		set { m_CumulativeUse = value; }
	}
	//每日免费次数
	public int m_FreeCount;
	public int FreeCount
	{
		get { return m_FreeCount;}
		set { m_FreeCount = value; }
	}


};
