
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBGuild.cs
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


//登陆后，同步一次数据请求封装类
[System.Serializable]
public class GuildRpcSyncDataAskWraper
{

	//构造函数
	public GuildRpcSyncDataAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncDataAsk ToPB()
	{
		GuildRpcSyncDataAsk v = new GuildRpcSyncDataAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncDataAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncDataAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncDataAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncDataAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//登陆后，同步一次数据回应封装类
[System.Serializable]
public class GuildRpcSyncDataReplyWraper
{

	//构造函数
	public GuildRpcSyncDataReplyWraper()
	{
		 m_Result = -9999;
		 m_GuildData = new GuildInfoObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_GuildData = new GuildInfoObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncDataReply ToPB()
	{
		GuildRpcSyncDataReply v = new GuildRpcSyncDataReply();
		v.Result = m_Result;
		v.GuildData = m_GuildData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncDataReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GuildData.FromPB(v.GuildData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncDataReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncDataReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncDataReply>(protoMS);
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
	//帮会数据
	public GuildInfoObjWraper m_GuildData;
	public GuildInfoObjWraper GuildData
	{
		get { return m_GuildData;}
		set { m_GuildData = value; }
	}


};
//创建帮会请求封装类
[System.Serializable]
public class GuildRpcCreateGuildAskWraper
{

	//构造函数
	public GuildRpcCreateGuildAskWraper()
	{
		 m_GuildName = "";
		 m_Announcement = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildName = "";
		 m_Announcement = "";

	}

 	//转化成Protobuffer类型函数
	public GuildRpcCreateGuildAsk ToPB()
	{
		GuildRpcCreateGuildAsk v = new GuildRpcCreateGuildAsk();
		v.GuildName = m_GuildName;
		v.Announcement = m_Announcement;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcCreateGuildAsk v)
	{
        if (v == null)
            return;
		m_GuildName = v.GuildName;
		m_Announcement = v.Announcement;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcCreateGuildAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcCreateGuildAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcCreateGuildAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮派名字
	public string m_GuildName;
	public string GuildName
	{
		get { return m_GuildName;}
		set { m_GuildName = value; }
	}
	//公告
	public string m_Announcement;
	public string Announcement
	{
		get { return m_Announcement;}
		set { m_Announcement = value; }
	}


};
//创建帮会回应封装类
[System.Serializable]
public class GuildRpcCreateGuildReplyWraper
{

	//构造函数
	public GuildRpcCreateGuildReplyWraper()
	{
		 m_Result = -9999;
		 m_GuildData = new GuildInfoObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_GuildData = new GuildInfoObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcCreateGuildReply ToPB()
	{
		GuildRpcCreateGuildReply v = new GuildRpcCreateGuildReply();
		v.Result = m_Result;
		v.GuildData = m_GuildData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcCreateGuildReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GuildData.FromPB(v.GuildData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcCreateGuildReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcCreateGuildReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcCreateGuildReply>(protoMS);
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
	//帮会数据
	public GuildInfoObjWraper m_GuildData;
	public GuildInfoObjWraper GuildData
	{
		get { return m_GuildData;}
		set { m_GuildData = value; }
	}


};
//申请入帮请求封装类
[System.Serializable]
public class GuildRpcApplyGuildAskWraper
{

	//构造函数
	public GuildRpcApplyGuildAskWraper()
	{
		 m_Guild = -1;
		 m_Oper = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Guild = -1;
		 m_Oper = 0;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcApplyGuildAsk ToPB()
	{
		GuildRpcApplyGuildAsk v = new GuildRpcApplyGuildAsk();
		v.Guild = m_Guild;
		v.Oper = m_Oper;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcApplyGuildAsk v)
	{
        if (v == null)
            return;
		m_Guild = v.Guild;
		m_Oper = v.Oper;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcApplyGuildAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcApplyGuildAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcApplyGuildAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮派Id
	public int m_Guild;
	public int Guild
	{
		get { return m_Guild;}
		set { m_Guild = value; }
	}
	//0是申请1是取消
	public int m_Oper;
	public int Oper
	{
		get { return m_Oper;}
		set { m_Oper = value; }
	}


};
//申请入帮回应封装类
[System.Serializable]
public class GuildRpcApplyGuildReplyWraper
{

	//构造函数
	public GuildRpcApplyGuildReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcApplyGuildReply ToPB()
	{
		GuildRpcApplyGuildReply v = new GuildRpcApplyGuildReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcApplyGuildReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcApplyGuildReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcApplyGuildReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcApplyGuildReply>(protoMS);
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
//快速申请请求封装类
[System.Serializable]
public class GuildRpcQuickApplyAskWraper
{

	//构造函数
	public GuildRpcQuickApplyAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcQuickApplyAsk ToPB()
	{
		GuildRpcQuickApplyAsk v = new GuildRpcQuickApplyAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcQuickApplyAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcQuickApplyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcQuickApplyAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcQuickApplyAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//快速申请回应封装类
[System.Serializable]
public class GuildRpcQuickApplyReplyWraper
{

	//构造函数
	public GuildRpcQuickApplyReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcQuickApplyReply ToPB()
	{
		GuildRpcQuickApplyReply v = new GuildRpcQuickApplyReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcQuickApplyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcQuickApplyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcQuickApplyReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcQuickApplyReply>(protoMS);
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
//修改帮会名字请求封装类
[System.Serializable]
public class GuildRpcChangeGuildNameAskWraper
{

	//构造函数
	public GuildRpcChangeGuildNameAskWraper()
	{
		 m_GuildName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildName = "";

	}

 	//转化成Protobuffer类型函数
	public GuildRpcChangeGuildNameAsk ToPB()
	{
		GuildRpcChangeGuildNameAsk v = new GuildRpcChangeGuildNameAsk();
		v.GuildName = m_GuildName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcChangeGuildNameAsk v)
	{
        if (v == null)
            return;
		m_GuildName = v.GuildName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcChangeGuildNameAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcChangeGuildNameAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcChangeGuildNameAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮派名字
	public string m_GuildName;
	public string GuildName
	{
		get { return m_GuildName;}
		set { m_GuildName = value; }
	}


};
//修改帮会名字回应封装类
[System.Serializable]
public class GuildRpcChangeGuildNameReplyWraper
{

	//构造函数
	public GuildRpcChangeGuildNameReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcChangeGuildNameReply ToPB()
	{
		GuildRpcChangeGuildNameReply v = new GuildRpcChangeGuildNameReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcChangeGuildNameReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcChangeGuildNameReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcChangeGuildNameReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcChangeGuildNameReply>(protoMS);
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
//修改公告请求封装类
[System.Serializable]
public class GuildRpcChangeAnnouncementAskWraper
{

	//构造函数
	public GuildRpcChangeAnnouncementAskWraper()
	{
		 m_Announcement = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Announcement = "";

	}

 	//转化成Protobuffer类型函数
	public GuildRpcChangeAnnouncementAsk ToPB()
	{
		GuildRpcChangeAnnouncementAsk v = new GuildRpcChangeAnnouncementAsk();
		v.Announcement = m_Announcement;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcChangeAnnouncementAsk v)
	{
        if (v == null)
            return;
		m_Announcement = v.Announcement;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcChangeAnnouncementAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcChangeAnnouncementAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcChangeAnnouncementAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//公告
	public string m_Announcement;
	public string Announcement
	{
		get { return m_Announcement;}
		set { m_Announcement = value; }
	}


};
//修改公告回应封装类
[System.Serializable]
public class GuildRpcChangeAnnouncementReplyWraper
{

	//构造函数
	public GuildRpcChangeAnnouncementReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcChangeAnnouncementReply ToPB()
	{
		GuildRpcChangeAnnouncementReply v = new GuildRpcChangeAnnouncementReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcChangeAnnouncementReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcChangeAnnouncementReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcChangeAnnouncementReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcChangeAnnouncementReply>(protoMS);
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
//请求帮会列表请求封装类
[System.Serializable]
public class GuildRpcReqGuildListAskWraper
{

	//构造函数
	public GuildRpcReqGuildListAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcReqGuildListAsk ToPB()
	{
		GuildRpcReqGuildListAsk v = new GuildRpcReqGuildListAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcReqGuildListAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcReqGuildListAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcReqGuildListAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcReqGuildListAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//请求帮会列表回应封装类
[System.Serializable]
public class GuildRpcReqGuildListReplyWraper
{

	//构造函数
	public GuildRpcReqGuildListReplyWraper()
	{
		 m_Result = -9999;
		m_GuildList = new List<GuildListObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_GuildList = new List<GuildListObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcReqGuildListReply ToPB()
	{
		GuildRpcReqGuildListReply v = new GuildRpcReqGuildListReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_GuildList.Count; i++)
			v.GuildList.Add( m_GuildList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcReqGuildListReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_GuildList.Clear();
		for( int i=0; i<v.GuildList.Count; i++)
			m_GuildList.Add( new GuildListObjWraper());
		for( int i=0; i<v.GuildList.Count; i++)
			m_GuildList[i].FromPB(v.GuildList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcReqGuildListReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcReqGuildListReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcReqGuildListReply>(protoMS);
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
	//帮会列表
	public List<GuildListObjWraper> m_GuildList;
	public int SizeGuildList()
	{
		return m_GuildList.Count;
	}
	public List<GuildListObjWraper> GetGuildList()
	{
		return m_GuildList;
	}
	public GuildListObjWraper GetGuildList(int Index)
	{
		if(Index<0 || Index>=(int)m_GuildList.Count)
			return new GuildListObjWraper();
		return m_GuildList[Index];
	}
	public void SetGuildList( List<GuildListObjWraper> v )
	{
		m_GuildList=v;
	}
	public void SetGuildList( int Index, GuildListObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GuildList.Count)
			return;
		m_GuildList[Index] = v;
	}
	public void AddGuildList( GuildListObjWraper v )
	{
		m_GuildList.Add(v);
	}
	public void ClearGuildList( )
	{
		m_GuildList.Clear();
	}


};
//任命职位请求封装类
[System.Serializable]
public class GuildRpcAppointDutyAskWraper
{

	//构造函数
	public GuildRpcAppointDutyAskWraper()
	{
		 m_UserId = -1;
		 m_Duty = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_Duty = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcAppointDutyAsk ToPB()
	{
		GuildRpcAppointDutyAsk v = new GuildRpcAppointDutyAsk();
		v.UserId = m_UserId;
		v.Duty = m_Duty;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcAppointDutyAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_Duty = v.Duty;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcAppointDutyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcAppointDutyAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcAppointDutyAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//职位
	public int m_Duty;
	public int Duty
	{
		get { return m_Duty;}
		set { m_Duty = value; }
	}


};
//任命职位回应封装类
[System.Serializable]
public class GuildRpcAppointDutyReplyWraper
{

	//构造函数
	public GuildRpcAppointDutyReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcAppointDutyReply ToPB()
	{
		GuildRpcAppointDutyReply v = new GuildRpcAppointDutyReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcAppointDutyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcAppointDutyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcAppointDutyReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcAppointDutyReply>(protoMS);
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
//踢人请求封装类
[System.Serializable]
public class GuildRpcKickoutAskWraper
{

	//构造函数
	public GuildRpcKickoutAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcKickoutAsk ToPB()
	{
		GuildRpcKickoutAsk v = new GuildRpcKickoutAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcKickoutAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcKickoutAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcKickoutAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcKickoutAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//踢人回应封装类
[System.Serializable]
public class GuildRpcKickoutReplyWraper
{

	//构造函数
	public GuildRpcKickoutReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcKickoutReply ToPB()
	{
		GuildRpcKickoutReply v = new GuildRpcKickoutReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcKickoutReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcKickoutReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcKickoutReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcKickoutReply>(protoMS);
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
//退出帮会请求封装类
[System.Serializable]
public class GuildRpcExitGuildAskWraper
{

	//构造函数
	public GuildRpcExitGuildAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcExitGuildAsk ToPB()
	{
		GuildRpcExitGuildAsk v = new GuildRpcExitGuildAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcExitGuildAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcExitGuildAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcExitGuildAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcExitGuildAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//退出帮会回应封装类
[System.Serializable]
public class GuildRpcExitGuildReplyWraper
{

	//构造函数
	public GuildRpcExitGuildReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcExitGuildReply ToPB()
	{
		GuildRpcExitGuildReply v = new GuildRpcExitGuildReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcExitGuildReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcExitGuildReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcExitGuildReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcExitGuildReply>(protoMS);
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
//解散帮会请求封装类
[System.Serializable]
public class GuildRpcBreakUpAskWraper
{

	//构造函数
	public GuildRpcBreakUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcBreakUpAsk ToPB()
	{
		GuildRpcBreakUpAsk v = new GuildRpcBreakUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcBreakUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcBreakUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcBreakUpAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcBreakUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//解散帮会回应封装类
[System.Serializable]
public class GuildRpcBreakUpReplyWraper
{

	//构造函数
	public GuildRpcBreakUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcBreakUpReply ToPB()
	{
		GuildRpcBreakUpReply v = new GuildRpcBreakUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcBreakUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcBreakUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcBreakUpReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcBreakUpReply>(protoMS);
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
//邀请入帮请求封装类
[System.Serializable]
public class GuildRpcInviteToJoinAskWraper
{

	//构造函数
	public GuildRpcInviteToJoinAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcInviteToJoinAsk ToPB()
	{
		GuildRpcInviteToJoinAsk v = new GuildRpcInviteToJoinAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcInviteToJoinAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcInviteToJoinAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcInviteToJoinAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcInviteToJoinAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//邀请入帮回应封装类
[System.Serializable]
public class GuildRpcInviteToJoinReplyWraper
{

	//构造函数
	public GuildRpcInviteToJoinReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcInviteToJoinReply ToPB()
	{
		GuildRpcInviteToJoinReply v = new GuildRpcInviteToJoinReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcInviteToJoinReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcInviteToJoinReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcInviteToJoinReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcInviteToJoinReply>(protoMS);
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
//被邀请提示通知封装类
[System.Serializable]
public class GuildRpcBeInvitedNoticeNotifyWraper
{

	//构造函数
	public GuildRpcBeInvitedNoticeNotifyWraper()
	{
		 m_UserId = -1;
		 m_Guild = -1;
		 m_GuildName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_Guild = -1;
		 m_GuildName = "";

	}

 	//转化成Protobuffer类型函数
	public GuildRpcBeInvitedNoticeNotify ToPB()
	{
		GuildRpcBeInvitedNoticeNotify v = new GuildRpcBeInvitedNoticeNotify();
		v.UserId = m_UserId;
		v.Guild = m_Guild;
		v.GuildName = m_GuildName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcBeInvitedNoticeNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_Guild = v.Guild;
		m_GuildName = v.GuildName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcBeInvitedNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcBeInvitedNoticeNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcBeInvitedNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//帮派Id
	public int m_Guild;
	public int Guild
	{
		get { return m_Guild;}
		set { m_Guild = value; }
	}
	//帮派名字
	public string m_GuildName;
	public string GuildName
	{
		get { return m_GuildName;}
		set { m_GuildName = value; }
	}


};
//被邀请处理请求封装类
[System.Serializable]
public class GuildRpcBeInvitedHandleAskWraper
{

	//构造函数
	public GuildRpcBeInvitedHandleAskWraper()
	{
		 m_Guild = -1;
		 m_Oper = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Guild = -1;
		 m_Oper = 0;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcBeInvitedHandleAsk ToPB()
	{
		GuildRpcBeInvitedHandleAsk v = new GuildRpcBeInvitedHandleAsk();
		v.Guild = m_Guild;
		v.Oper = m_Oper;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcBeInvitedHandleAsk v)
	{
        if (v == null)
            return;
		m_Guild = v.Guild;
		m_Oper = v.Oper;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcBeInvitedHandleAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcBeInvitedHandleAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcBeInvitedHandleAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮派Id
	public int m_Guild;
	public int Guild
	{
		get { return m_Guild;}
		set { m_Guild = value; }
	}
	//0是同意1是拒绝
	public int m_Oper;
	public int Oper
	{
		get { return m_Oper;}
		set { m_Oper = value; }
	}


};
//被邀请处理回应封装类
[System.Serializable]
public class GuildRpcBeInvitedHandleReplyWraper
{

	//构造函数
	public GuildRpcBeInvitedHandleReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcBeInvitedHandleReply ToPB()
	{
		GuildRpcBeInvitedHandleReply v = new GuildRpcBeInvitedHandleReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcBeInvitedHandleReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcBeInvitedHandleReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcBeInvitedHandleReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcBeInvitedHandleReply>(protoMS);
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
//辞职请求封装类
[System.Serializable]
public class GuildRpcResignDutyAskWraper
{

	//构造函数
	public GuildRpcResignDutyAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcResignDutyAsk ToPB()
	{
		GuildRpcResignDutyAsk v = new GuildRpcResignDutyAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcResignDutyAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcResignDutyAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcResignDutyAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcResignDutyAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//辞职回应封装类
[System.Serializable]
public class GuildRpcResignDutyReplyWraper
{

	//构造函数
	public GuildRpcResignDutyReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcResignDutyReply ToPB()
	{
		GuildRpcResignDutyReply v = new GuildRpcResignDutyReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcResignDutyReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcResignDutyReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcResignDutyReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcResignDutyReply>(protoMS);
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
//发送我的帮会数据通知封装类
[System.Serializable]
public class GuildRpcSyncMyTeamDataNotifyWraper
{

	//构造函数
	public GuildRpcSyncMyTeamDataNotifyWraper()
	{
		 m_GuildData = new GuildInfoObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildData = new GuildInfoObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncMyTeamDataNotify ToPB()
	{
		GuildRpcSyncMyTeamDataNotify v = new GuildRpcSyncMyTeamDataNotify();
		v.GuildData = m_GuildData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncMyTeamDataNotify v)
	{
        if (v == null)
            return;
		m_GuildData.FromPB(v.GuildData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncMyTeamDataNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncMyTeamDataNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncMyTeamDataNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮会数据
	public GuildInfoObjWraper m_GuildData;
	public GuildInfoObjWraper GuildData
	{
		get { return m_GuildData;}
		set { m_GuildData = value; }
	}


};
//同步帮会基础数据通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfGuildBaseDataNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfGuildBaseDataNotifyWraper()
	{
		 m_GuildName = "";
		 m_Level = 1;
		 m_CaptainId = -1;
		 m_CaptainName = "";
		 m_Funds = -1;
		 m_LeagueMatchesRank = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildName = "";
		 m_Level = 1;
		 m_CaptainId = -1;
		 m_CaptainName = "";
		 m_Funds = -1;
		 m_LeagueMatchesRank = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfGuildBaseDataNotify ToPB()
	{
		GuildRpcSyncNoticeOfGuildBaseDataNotify v = new GuildRpcSyncNoticeOfGuildBaseDataNotify();
		v.GuildName = m_GuildName;
		v.Level = m_Level;
		v.CaptainId = m_CaptainId;
		v.CaptainName = m_CaptainName;
		v.Funds = m_Funds;
		v.LeagueMatchesRank = m_LeagueMatchesRank;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfGuildBaseDataNotify v)
	{
        if (v == null)
            return;
		m_GuildName = v.GuildName;
		m_Level = v.Level;
		m_CaptainId = v.CaptainId;
		m_CaptainName = v.CaptainName;
		m_Funds = v.Funds;
		m_LeagueMatchesRank = v.LeagueMatchesRank;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfGuildBaseDataNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfGuildBaseDataNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfGuildBaseDataNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮派名字
	public string m_GuildName;
	public string GuildName
	{
		get { return m_GuildName;}
		set { m_GuildName = value; }
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//帮主Id
	public long m_CaptainId;
	public long CaptainId
	{
		get { return m_CaptainId;}
		set { m_CaptainId = value; }
	}
	//帮主名字
	public string m_CaptainName;
	public string CaptainName
	{
		get { return m_CaptainName;}
		set { m_CaptainName = value; }
	}
	//资金
	public int m_Funds;
	public int Funds
	{
		get { return m_Funds;}
		set { m_Funds = value; }
	}
	//联赛排名
	public int m_LeagueMatchesRank;
	public int LeagueMatchesRank
	{
		get { return m_LeagueMatchesRank;}
		set { m_LeagueMatchesRank = value; }
	}


};
//同步帮会成员数据变化通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfGuildMemberChangeNotifyWraper()
	{
		 m_GuildMember = new GuildMemberObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildMember = new GuildMemberObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfGuildMemberChangeNotify ToPB()
	{
		GuildRpcSyncNoticeOfGuildMemberChangeNotify v = new GuildRpcSyncNoticeOfGuildMemberChangeNotify();
		v.GuildMember = m_GuildMember.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfGuildMemberChangeNotify v)
	{
        if (v == null)
            return;
		m_GuildMember.FromPB(v.GuildMember);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfGuildMemberChangeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfGuildMemberChangeNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfGuildMemberChangeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮会成员
	public GuildMemberObjWraper m_GuildMember;
	public GuildMemberObjWraper GuildMember
	{
		get { return m_GuildMember;}
		set { m_GuildMember = value; }
	}


};
//同步帮会增加成员通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfAddMemberNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfAddMemberNotifyWraper()
	{
		 m_GuildMember = new GuildMemberObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildMember = new GuildMemberObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfAddMemberNotify ToPB()
	{
		GuildRpcSyncNoticeOfAddMemberNotify v = new GuildRpcSyncNoticeOfAddMemberNotify();
		v.GuildMember = m_GuildMember.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfAddMemberNotify v)
	{
        if (v == null)
            return;
		m_GuildMember.FromPB(v.GuildMember);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfAddMemberNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfAddMemberNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfAddMemberNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮会成员
	public GuildMemberObjWraper m_GuildMember;
	public GuildMemberObjWraper GuildMember
	{
		get { return m_GuildMember;}
		set { m_GuildMember = value; }
	}


};
//同步帮会删除成员通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfDelMemberNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfDelMemberNotifyWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfDelMemberNotify ToPB()
	{
		GuildRpcSyncNoticeOfDelMemberNotify v = new GuildRpcSyncNoticeOfDelMemberNotify();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfDelMemberNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfDelMemberNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfDelMemberNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfDelMemberNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//同步帮会增加事件通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfAddEventNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfAddEventNotifyWraper()
	{
		 m_EventId = -1;
		 m_Param1 = "";
		 m_Param2 = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_EventId = -1;
		 m_Param1 = "";
		 m_Param2 = "";

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfAddEventNotify ToPB()
	{
		GuildRpcSyncNoticeOfAddEventNotify v = new GuildRpcSyncNoticeOfAddEventNotify();
		v.EventId = m_EventId;
		v.Param1 = m_Param1;
		v.Param2 = m_Param2;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfAddEventNotify v)
	{
        if (v == null)
            return;
		m_EventId = v.EventId;
		m_Param1 = v.Param1;
		m_Param2 = v.Param2;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfAddEventNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfAddEventNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfAddEventNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//事件Id
	public int m_EventId;
	public int EventId
	{
		get { return m_EventId;}
		set { m_EventId = value; }
	}
	//参数1
	public string m_Param1;
	public string Param1
	{
		get { return m_Param1;}
		set { m_Param1 = value; }
	}
	//参数2
	public string m_Param2;
	public string Param2
	{
		get { return m_Param2;}
		set { m_Param2 = value; }
	}


};
//同步帮会增加申请列表通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfAddApplyListNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfAddApplyListNotifyWraper()
	{
		 m_ApplyPlayer = new ApplyListRoleInfoObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ApplyPlayer = new ApplyListRoleInfoObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfAddApplyListNotify ToPB()
	{
		GuildRpcSyncNoticeOfAddApplyListNotify v = new GuildRpcSyncNoticeOfAddApplyListNotify();
		v.ApplyPlayer = m_ApplyPlayer.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfAddApplyListNotify v)
	{
        if (v == null)
            return;
		m_ApplyPlayer.FromPB(v.ApplyPlayer);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfAddApplyListNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfAddApplyListNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfAddApplyListNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//申请玩家
	public ApplyListRoleInfoObjWraper m_ApplyPlayer;
	public ApplyListRoleInfoObjWraper ApplyPlayer
	{
		get { return m_ApplyPlayer;}
		set { m_ApplyPlayer = value; }
	}


};
//同步帮会删除申请列表通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfDelApplyListNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfDelApplyListNotifyWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfDelApplyListNotify ToPB()
	{
		GuildRpcSyncNoticeOfDelApplyListNotify v = new GuildRpcSyncNoticeOfDelApplyListNotify();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfDelApplyListNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfDelApplyListNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfDelApplyListNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfDelApplyListNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//同步帮会公告修改通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfChangeAnnouncementNotifyWraper()
	{
		 m_Announcement = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Announcement = "";

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfChangeAnnouncementNotify ToPB()
	{
		GuildRpcSyncNoticeOfChangeAnnouncementNotify v = new GuildRpcSyncNoticeOfChangeAnnouncementNotify();
		v.Announcement = m_Announcement;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfChangeAnnouncementNotify v)
	{
        if (v == null)
            return;
		m_Announcement = v.Announcement;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfChangeAnnouncementNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfChangeAnnouncementNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfChangeAnnouncementNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//公告
	public string m_Announcement;
	public string Announcement
	{
		get { return m_Announcement;}
		set { m_Announcement = value; }
	}


};
//通知解散通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfBreakupNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfBreakupNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfBreakupNotify ToPB()
	{
		GuildRpcSyncNoticeOfBreakupNotify v = new GuildRpcSyncNoticeOfBreakupNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfBreakupNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfBreakupNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfBreakupNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfBreakupNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
//帮会大厅升级请求封装类
[System.Serializable]
public class GuildRpcHallLvUpAskWraper
{

	//构造函数
	public GuildRpcHallLvUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcHallLvUpAsk ToPB()
	{
		GuildRpcHallLvUpAsk v = new GuildRpcHallLvUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcHallLvUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcHallLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcHallLvUpAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcHallLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//帮会大厅升级回应封装类
[System.Serializable]
public class GuildRpcHallLvUpReplyWraper
{

	//构造函数
	public GuildRpcHallLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcHallLvUpReply ToPB()
	{
		GuildRpcHallLvUpReply v = new GuildRpcHallLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcHallLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcHallLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcHallLvUpReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcHallLvUpReply>(protoMS);
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
//帮会房屋升级请求封装类
[System.Serializable]
public class GuildRpcHouseLvUpAskWraper
{

	//构造函数
	public GuildRpcHouseLvUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcHouseLvUpAsk ToPB()
	{
		GuildRpcHouseLvUpAsk v = new GuildRpcHouseLvUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcHouseLvUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcHouseLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcHouseLvUpAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcHouseLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//帮会房屋升级回应封装类
[System.Serializable]
public class GuildRpcHouseLvUpReplyWraper
{

	//构造函数
	public GuildRpcHouseLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcHouseLvUpReply ToPB()
	{
		GuildRpcHouseLvUpReply v = new GuildRpcHouseLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcHouseLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcHouseLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcHouseLvUpReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcHouseLvUpReply>(protoMS);
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
//帮会库房升级请求封装类
[System.Serializable]
public class GuildRpcStoreroomLvUpAskWraper
{

	//构造函数
	public GuildRpcStoreroomLvUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcStoreroomLvUpAsk ToPB()
	{
		GuildRpcStoreroomLvUpAsk v = new GuildRpcStoreroomLvUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcStoreroomLvUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcStoreroomLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcStoreroomLvUpAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcStoreroomLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//帮会库房升级回应封装类
[System.Serializable]
public class GuildRpcStoreroomLvUpReplyWraper
{

	//构造函数
	public GuildRpcStoreroomLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcStoreroomLvUpReply ToPB()
	{
		GuildRpcStoreroomLvUpReply v = new GuildRpcStoreroomLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcStoreroomLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcStoreroomLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcStoreroomLvUpReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcStoreroomLvUpReply>(protoMS);
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
//帮会练武堂升级请求封装类
[System.Serializable]
public class GuildRpcKongfuHallLvUpAskWraper
{

	//构造函数
	public GuildRpcKongfuHallLvUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcKongfuHallLvUpAsk ToPB()
	{
		GuildRpcKongfuHallLvUpAsk v = new GuildRpcKongfuHallLvUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcKongfuHallLvUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcKongfuHallLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcKongfuHallLvUpAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcKongfuHallLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//帮会练武堂升级回应封装类
[System.Serializable]
public class GuildRpcKongfuHallLvUpReplyWraper
{

	//构造函数
	public GuildRpcKongfuHallLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcKongfuHallLvUpReply ToPB()
	{
		GuildRpcKongfuHallLvUpReply v = new GuildRpcKongfuHallLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcKongfuHallLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcKongfuHallLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcKongfuHallLvUpReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcKongfuHallLvUpReply>(protoMS);
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
//同步帮会大厅升级通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfHallLvUpNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfHallLvUpNotifyWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfHallLvUpNotify ToPB()
	{
		GuildRpcSyncNoticeOfHallLvUpNotify v = new GuildRpcSyncNoticeOfHallLvUpNotify();
		v.Lv = m_Lv;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfHallLvUpNotify v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfHallLvUpNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfHallLvUpNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfHallLvUpNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//当前等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//开始时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//同步帮会房屋升级通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfHouseLvUpNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfHouseLvUpNotifyWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfHouseLvUpNotify ToPB()
	{
		GuildRpcSyncNoticeOfHouseLvUpNotify v = new GuildRpcSyncNoticeOfHouseLvUpNotify();
		v.Lv = m_Lv;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfHouseLvUpNotify v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfHouseLvUpNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfHouseLvUpNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfHouseLvUpNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//当前等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//开始时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//同步帮会库房升级通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfStorerommLvUpNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfStorerommLvUpNotifyWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfStorerommLvUpNotify ToPB()
	{
		GuildRpcSyncNoticeOfStorerommLvUpNotify v = new GuildRpcSyncNoticeOfStorerommLvUpNotify();
		v.Lv = m_Lv;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfStorerommLvUpNotify v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfStorerommLvUpNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfStorerommLvUpNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfStorerommLvUpNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//当前等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//开始时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//同步练武堂升级通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfKongfuHallLvUpNotifyWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = -1;
		 m_Time = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfKongfuHallLvUpNotify ToPB()
	{
		GuildRpcSyncNoticeOfKongfuHallLvUpNotify v = new GuildRpcSyncNoticeOfKongfuHallLvUpNotify();
		v.Lv = m_Lv;
		v.Time = m_Time;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfKongfuHallLvUpNotify v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;
		m_Time = v.Time;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfKongfuHallLvUpNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfKongfuHallLvUpNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfKongfuHallLvUpNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//当前等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//开始时间
	public int m_Time;
	public int Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}


};
//申请入帮，帮主处理请求封装类
[System.Serializable]
public class GuildRpcApplyGuildHandleAskWraper
{

	//构造函数
	public GuildRpcApplyGuildHandleAskWraper()
	{
		 m_UserId = -1;
		 m_Oper = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_Oper = 0;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcApplyGuildHandleAsk ToPB()
	{
		GuildRpcApplyGuildHandleAsk v = new GuildRpcApplyGuildHandleAsk();
		v.UserId = m_UserId;
		v.Oper = m_Oper;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcApplyGuildHandleAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_Oper = v.Oper;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcApplyGuildHandleAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcApplyGuildHandleAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcApplyGuildHandleAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//0是同意1是拒绝
	public int m_Oper;
	public int Oper
	{
		get { return m_Oper;}
		set { m_Oper = value; }
	}


};
//申请入帮，帮主处理回应封装类
[System.Serializable]
public class GuildRpcApplyGuildHandleReplyWraper
{

	//构造函数
	public GuildRpcApplyGuildHandleReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcApplyGuildHandleReply ToPB()
	{
		GuildRpcApplyGuildHandleReply v = new GuildRpcApplyGuildHandleReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcApplyGuildHandleReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcApplyGuildHandleReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcApplyGuildHandleReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcApplyGuildHandleReply>(protoMS);
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
//创建帮会副本请求封装类
[System.Serializable]
public class GuildRpcCreateGuildDungeonAskWraper
{

	//构造函数
	public GuildRpcCreateGuildDungeonAskWraper()
	{
		 m_DungeonNum = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonNum = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcCreateGuildDungeonAsk ToPB()
	{
		GuildRpcCreateGuildDungeonAsk v = new GuildRpcCreateGuildDungeonAsk();
		v.DungeonNum = m_DungeonNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcCreateGuildDungeonAsk v)
	{
        if (v == null)
            return;
		m_DungeonNum = v.DungeonNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcCreateGuildDungeonAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcCreateGuildDungeonAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcCreateGuildDungeonAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本数量
	public int m_DungeonNum;
	public int DungeonNum
	{
		get { return m_DungeonNum;}
		set { m_DungeonNum = value; }
	}


};
//创建帮会副本回应封装类
[System.Serializable]
public class GuildRpcCreateGuildDungeonReplyWraper
{

	//构造函数
	public GuildRpcCreateGuildDungeonReplyWraper()
	{
		 m_Result = -9999;
		 m_DungeonNum = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_DungeonNum = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcCreateGuildDungeonReply ToPB()
	{
		GuildRpcCreateGuildDungeonReply v = new GuildRpcCreateGuildDungeonReply();
		v.Result = m_Result;
		v.DungeonNum = m_DungeonNum;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcCreateGuildDungeonReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_DungeonNum = v.DungeonNum;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcCreateGuildDungeonReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcCreateGuildDungeonReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcCreateGuildDungeonReply>(protoMS);
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
	//创建成功的副本数量
	public int m_DungeonNum;
	public int DungeonNum
	{
		get { return m_DungeonNum;}
		set { m_DungeonNum = value; }
	}


};
//进入帮会副本请求封装类
[System.Serializable]
public class GuildRpcEnterGuildDungeonAskWraper
{

	//构造函数
	public GuildRpcEnterGuildDungeonAskWraper()
	{
		 m_Index = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Index = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcEnterGuildDungeonAsk ToPB()
	{
		GuildRpcEnterGuildDungeonAsk v = new GuildRpcEnterGuildDungeonAsk();
		v.Index = m_Index;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcEnterGuildDungeonAsk v)
	{
        if (v == null)
            return;
		m_Index = v.Index;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcEnterGuildDungeonAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcEnterGuildDungeonAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcEnterGuildDungeonAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮会副本下标
	public int m_Index;
	public int Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}


};
//进入帮会副本回应封装类
[System.Serializable]
public class GuildRpcEnterGuildDungeonReplyWraper
{

	//构造函数
	public GuildRpcEnterGuildDungeonReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcEnterGuildDungeonReply ToPB()
	{
		GuildRpcEnterGuildDungeonReply v = new GuildRpcEnterGuildDungeonReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcEnterGuildDungeonReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcEnterGuildDungeonReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcEnterGuildDungeonReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcEnterGuildDungeonReply>(protoMS);
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
//同步帮会副本创建通知封装类
[System.Serializable]
public class GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraper
{

	//构造函数
	public GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotifyWraper()
	{
		m_DungeonList = new List<GuildDungeonObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_DungeonList = new List<GuildDungeonObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify ToPB()
	{
		GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify v = new GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify();
		for (int i=0; i<(int)m_DungeonList.Count; i++)
			v.DungeonList.Add( m_DungeonList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify v)
	{
        if (v == null)
            return;
		m_DungeonList.Clear();
		for( int i=0; i<v.DungeonList.Count; i++)
			m_DungeonList.Add( new GuildDungeonObjWraper());
		for( int i=0; i<v.DungeonList.Count; i++)
			m_DungeonList[i].FromPB(v.DungeonList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcRpcSyncNoticeOfCreateGuildDungeonNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本列表
	public List<GuildDungeonObjWraper> m_DungeonList;
	public int SizeDungeonList()
	{
		return m_DungeonList.Count;
	}
	public List<GuildDungeonObjWraper> GetDungeonList()
	{
		return m_DungeonList;
	}
	public GuildDungeonObjWraper GetDungeonList(int Index)
	{
		if(Index<0 || Index>=(int)m_DungeonList.Count)
			return new GuildDungeonObjWraper();
		return m_DungeonList[Index];
	}
	public void SetDungeonList( List<GuildDungeonObjWraper> v )
	{
		m_DungeonList=v;
	}
	public void SetDungeonList( int Index, GuildDungeonObjWraper v )
	{
		if(Index<0 || Index>=(int)m_DungeonList.Count)
			return;
		m_DungeonList[Index] = v;
	}
	public void AddDungeonList( GuildDungeonObjWraper v )
	{
		m_DungeonList.Add(v);
	}
	public void ClearDungeonList( )
	{
		m_DungeonList.Clear();
	}


};
//创建帮会战请求封装类
[System.Serializable]
public class GuildRpcCreateGuildWarAskWraper
{

	//构造函数
	public GuildRpcCreateGuildWarAskWraper()
	{
		 m_Guild = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Guild = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcCreateGuildWarAsk ToPB()
	{
		GuildRpcCreateGuildWarAsk v = new GuildRpcCreateGuildWarAsk();
		v.Guild = m_Guild;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcCreateGuildWarAsk v)
	{
        if (v == null)
            return;
		m_Guild = v.Guild;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcCreateGuildWarAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcCreateGuildWarAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcCreateGuildWarAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//对方的帮会
	public int m_Guild;
	public int Guild
	{
		get { return m_Guild;}
		set { m_Guild = value; }
	}


};
//创建帮会战回应封装类
[System.Serializable]
public class GuildRpcCreateGuildWarReplyWraper
{

	//构造函数
	public GuildRpcCreateGuildWarReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcCreateGuildWarReply ToPB()
	{
		GuildRpcCreateGuildWarReply v = new GuildRpcCreateGuildWarReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcCreateGuildWarReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcCreateGuildWarReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcCreateGuildWarReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcCreateGuildWarReply>(protoMS);
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
//同步帮会战是否开启通知封装类
[System.Serializable]
public class GuildRpcSyncNoticeOfOpenGuildWarNotifyWraper
{

	//构造函数
	public GuildRpcSyncNoticeOfOpenGuildWarNotifyWraper()
	{
		 m_GuildWar = new GuildWarObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GuildWar = new GuildWarObjWraper();

	}

 	//转化成Protobuffer类型函数
	public GuildRpcSyncNoticeOfOpenGuildWarNotify ToPB()
	{
		GuildRpcSyncNoticeOfOpenGuildWarNotify v = new GuildRpcSyncNoticeOfOpenGuildWarNotify();
		v.GuildWar = m_GuildWar.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcSyncNoticeOfOpenGuildWarNotify v)
	{
        if (v == null)
            return;
		m_GuildWar.FromPB(v.GuildWar);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcSyncNoticeOfOpenGuildWarNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcSyncNoticeOfOpenGuildWarNotify pb = ProtoBuf.Serializer.Deserialize<GuildRpcSyncNoticeOfOpenGuildWarNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//帮会战
	public GuildWarObjWraper m_GuildWar;
	public GuildWarObjWraper GuildWar
	{
		get { return m_GuildWar;}
		set { m_GuildWar = value; }
	}


};
//进入帮会战请求封装类
[System.Serializable]
public class GuildRpcEnterGuildWarAskWraper
{

	//构造函数
	public GuildRpcEnterGuildWarAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public GuildRpcEnterGuildWarAsk ToPB()
	{
		GuildRpcEnterGuildWarAsk v = new GuildRpcEnterGuildWarAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcEnterGuildWarAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcEnterGuildWarAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcEnterGuildWarAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcEnterGuildWarAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//进入帮会战回应封装类
[System.Serializable]
public class GuildRpcEnterGuildWarReplyWraper
{

	//构造函数
	public GuildRpcEnterGuildWarReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcEnterGuildWarReply ToPB()
	{
		GuildRpcEnterGuildWarReply v = new GuildRpcEnterGuildWarReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcEnterGuildWarReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcEnterGuildWarReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcEnterGuildWarReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcEnterGuildWarReply>(protoMS);
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
//开启帮会修炼项目请求封装类
[System.Serializable]
public class GuildRpcOpenScienceAttrAskWraper
{

	//构造函数
	public GuildRpcOpenScienceAttrAskWraper()
	{
		 m_ScienceId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ScienceId = -1;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcOpenScienceAttrAsk ToPB()
	{
		GuildRpcOpenScienceAttrAsk v = new GuildRpcOpenScienceAttrAsk();
		v.ScienceId = m_ScienceId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcOpenScienceAttrAsk v)
	{
        if (v == null)
            return;
		m_ScienceId = v.ScienceId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcOpenScienceAttrAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcOpenScienceAttrAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcOpenScienceAttrAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//修炼属性id
	public int m_ScienceId;
	public int ScienceId
	{
		get { return m_ScienceId;}
		set { m_ScienceId = value; }
	}


};
//开启帮会修炼项目回应封装类
[System.Serializable]
public class GuildRpcOpenScienceAttrReplyWraper
{

	//构造函数
	public GuildRpcOpenScienceAttrReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcOpenScienceAttrReply ToPB()
	{
		GuildRpcOpenScienceAttrReply v = new GuildRpcOpenScienceAttrReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcOpenScienceAttrReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcOpenScienceAttrReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcOpenScienceAttrReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcOpenScienceAttrReply>(protoMS);
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
//帮会属性升级请求封装类
[System.Serializable]
public class GuildRpcGuildScienceLvUpAskWraper
{

	//构造函数
	public GuildRpcGuildScienceLvUpAskWraper()
	{
		 m_ScienceId = -1;
		 m_IsKeyUpLv = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ScienceId = -1;
		 m_IsKeyUpLv = false;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcGuildScienceLvUpAsk ToPB()
	{
		GuildRpcGuildScienceLvUpAsk v = new GuildRpcGuildScienceLvUpAsk();
		v.ScienceId = m_ScienceId;
		v.IsKeyUpLv = m_IsKeyUpLv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcGuildScienceLvUpAsk v)
	{
        if (v == null)
            return;
		m_ScienceId = v.ScienceId;
		m_IsKeyUpLv = v.IsKeyUpLv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcGuildScienceLvUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcGuildScienceLvUpAsk pb = ProtoBuf.Serializer.Deserialize<GuildRpcGuildScienceLvUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//修炼id
	public int m_ScienceId;
	public int ScienceId
	{
		get { return m_ScienceId;}
		set { m_ScienceId = value; }
	}
	//是否一键升级
	public bool m_IsKeyUpLv;
	public bool IsKeyUpLv
	{
		get { return m_IsKeyUpLv;}
		set { m_IsKeyUpLv = value; }
	}


};
//帮会属性升级回应封装类
[System.Serializable]
public class GuildRpcGuildScienceLvUpReplyWraper
{

	//构造函数
	public GuildRpcGuildScienceLvUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public GuildRpcGuildScienceLvUpReply ToPB()
	{
		GuildRpcGuildScienceLvUpReply v = new GuildRpcGuildScienceLvUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildRpcGuildScienceLvUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildRpcGuildScienceLvUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildRpcGuildScienceLvUpReply pb = ProtoBuf.Serializer.Deserialize<GuildRpcGuildScienceLvUpReply>(protoMS);
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
