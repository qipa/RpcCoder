
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBStoryDungeon.cs
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


//剧情副本对象封装类
[System.Serializable]
public class StoryDungeonStoryDungeonObjWraperV1
{

	//构造函数
	public StoryDungeonStoryDungeonObjWraperV1()
	{
		 m_Id = -1;
		 m_IsLock = true;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_IsLock = true;

	}

 	//转化成Protobuffer类型函数
	public StoryDungeonStoryDungeonObjV1 ToPB()
	{
		StoryDungeonStoryDungeonObjV1 v = new StoryDungeonStoryDungeonObjV1();
		v.Id = m_Id;
		v.IsLock = m_IsLock;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(StoryDungeonStoryDungeonObjV1 v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_IsLock = v.IsLock;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<StoryDungeonStoryDungeonObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		StoryDungeonStoryDungeonObjV1 pb = ProtoBuf.Serializer.Deserialize<StoryDungeonStoryDungeonObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//副本锁定
	public bool m_IsLock;
	public bool IsLock
	{
		get { return m_IsLock;}
		set { m_IsLock = value; }
	}


};
