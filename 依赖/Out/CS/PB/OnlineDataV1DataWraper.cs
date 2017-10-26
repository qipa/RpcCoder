
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBOnlineData.cs
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


//角色属性对象封装类
[System.Serializable]
public class OnlineDataRoleAttrObjWraperV1
{

	//构造函数
	public OnlineDataRoleAttrObjWraperV1()
	{
		 m_Id = -1;
		 m_Value = (float)-1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Value = (float)-1;

	}

 	//转化成Protobuffer类型函数
	public OnlineDataRoleAttrObjV1 ToPB()
	{
		OnlineDataRoleAttrObjV1 v = new OnlineDataRoleAttrObjV1();
		v.Id = m_Id;
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OnlineDataRoleAttrObjV1 v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Value = v.Value;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OnlineDataRoleAttrObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OnlineDataRoleAttrObjV1 pb = ProtoBuf.Serializer.Deserialize<OnlineDataRoleAttrObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//属性Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//值
	public float m_Value;
	public float Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
