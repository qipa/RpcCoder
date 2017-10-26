
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBTeam.cs
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


//组队人员对象封装类
[System.Serializable]
public class TeamTeamUserObjWraperV1
{

	//构造函数
	public TeamTeamUserObjWraperV1()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_IsCaptain = false;
		 m_Level = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamTeamUserObjV1 ToPB()
	{
		TeamTeamUserObjV1 v = new TeamTeamUserObjV1();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.IsCaptain = m_IsCaptain;
		v.Level = m_Level;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamTeamUserObjV1 v)
	{
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_IsCaptain = v.IsCaptain;
		m_Level = v.Level;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamTeamUserObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamTeamUserObjV1 pb = ProtoBuf.Serializer.Deserialize<TeamTeamUserObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public int m_UserId;
	public int UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//用户名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//是否为队长
	public bool m_IsCaptain;
	public bool IsCaptain
	{
		get { return m_IsCaptain;}
		set { m_IsCaptain = value; }
	}
	//玩家等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}


};
