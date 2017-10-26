
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBTeam.cs
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


//创建队伍请求封装类
[System.Serializable]
public class TeamRpcCreateTeamAskWraper
{

	//构造函数
	public TeamRpcCreateTeamAskWraper()
	{
		 m_TargetId = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TargetId = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcCreateTeamAsk ToPB()
	{
		TeamRpcCreateTeamAsk v = new TeamRpcCreateTeamAsk();
		v.TargetId = m_TargetId;
		v.TargetMinLv = m_TargetMinLv;
		v.TargetMaxLv = m_TargetMaxLv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcCreateTeamAsk v)
	{
        if (v == null)
            return;
		m_TargetId = v.TargetId;
		m_TargetMinLv = v.TargetMinLv;
		m_TargetMaxLv = v.TargetMaxLv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcCreateTeamAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcCreateTeamAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcCreateTeamAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//目标id
	public int m_TargetId;
	public int TargetId
	{
		get { return m_TargetId;}
		set { m_TargetId = value; }
	}
	//目标最小等级
	public int m_TargetMinLv;
	public int TargetMinLv
	{
		get { return m_TargetMinLv;}
		set { m_TargetMinLv = value; }
	}
	//目标最大等级
	public int m_TargetMaxLv;
	public int TargetMaxLv
	{
		get { return m_TargetMaxLv;}
		set { m_TargetMaxLv = value; }
	}


};
//创建队伍回应封装类
[System.Serializable]
public class TeamRpcCreateTeamReplyWraper
{

	//构造函数
	public TeamRpcCreateTeamReplyWraper()
	{
		 m_Result = -9999;
		 m_TeamData = new TeamObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TeamData = new TeamObjWraper();

	}

 	//转化成Protobuffer类型函数
	public TeamRpcCreateTeamReply ToPB()
	{
		TeamRpcCreateTeamReply v = new TeamRpcCreateTeamReply();
		v.Result = m_Result;
		v.TeamData = m_TeamData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcCreateTeamReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TeamData.FromPB(v.TeamData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcCreateTeamReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcCreateTeamReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcCreateTeamReply>(protoMS);
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
	//队伍数据
	public TeamObjWraper m_TeamData;
	public TeamObjWraper TeamData
	{
		get { return m_TeamData;}
		set { m_TeamData = value; }
	}


};
//申请入队请求封装类
[System.Serializable]
public class TeamRpcApplyForTeamAskWraper
{

	//构造函数
	public TeamRpcApplyForTeamAskWraper()
	{
		 m_TeamId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TeamId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcApplyForTeamAsk ToPB()
	{
		TeamRpcApplyForTeamAsk v = new TeamRpcApplyForTeamAsk();
		v.TeamId = m_TeamId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcApplyForTeamAsk v)
	{
        if (v == null)
            return;
		m_TeamId = v.TeamId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcApplyForTeamAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcApplyForTeamAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcApplyForTeamAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}


};
//申请入队回应封装类
[System.Serializable]
public class TeamRpcApplyForTeamReplyWraper
{

	//构造函数
	public TeamRpcApplyForTeamReplyWraper()
	{
		 m_Result = -9999;
		 m_TeamId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TeamId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcApplyForTeamReply ToPB()
	{
		TeamRpcApplyForTeamReply v = new TeamRpcApplyForTeamReply();
		v.Result = m_Result;
		v.TeamId = m_TeamId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcApplyForTeamReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TeamId = v.TeamId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcApplyForTeamReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcApplyForTeamReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcApplyForTeamReply>(protoMS);
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
	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}


};
//邀请入队请求封装类
[System.Serializable]
public class TeamRpcInviteToTeamAskWraper
{

	//构造函数
	public TeamRpcInviteToTeamAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcInviteToTeamAsk ToPB()
	{
		TeamRpcInviteToTeamAsk v = new TeamRpcInviteToTeamAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcInviteToTeamAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcInviteToTeamAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcInviteToTeamAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcInviteToTeamAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//邀请的对方Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//邀请入队回应封装类
[System.Serializable]
public class TeamRpcInviteToTeamReplyWraper
{

	//构造函数
	public TeamRpcInviteToTeamReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcInviteToTeamReply ToPB()
	{
		TeamRpcInviteToTeamReply v = new TeamRpcInviteToTeamReply();
		v.Result = m_Result;
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcInviteToTeamReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcInviteToTeamReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcInviteToTeamReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcInviteToTeamReply>(protoMS);
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
	//邀请的对方Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//更改队伍目标请求封装类
[System.Serializable]
public class TeamRpcChangeTeamTargetAskWraper
{

	//构造函数
	public TeamRpcChangeTeamTargetAskWraper()
	{
		 m_TargetId = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TargetId = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcChangeTeamTargetAsk ToPB()
	{
		TeamRpcChangeTeamTargetAsk v = new TeamRpcChangeTeamTargetAsk();
		v.TargetId = m_TargetId;
		v.TargetMinLv = m_TargetMinLv;
		v.TargetMaxLv = m_TargetMaxLv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcChangeTeamTargetAsk v)
	{
        if (v == null)
            return;
		m_TargetId = v.TargetId;
		m_TargetMinLv = v.TargetMinLv;
		m_TargetMaxLv = v.TargetMaxLv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcChangeTeamTargetAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcChangeTeamTargetAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcChangeTeamTargetAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//目标id
	public int m_TargetId;
	public int TargetId
	{
		get { return m_TargetId;}
		set { m_TargetId = value; }
	}
	//目标最小等级
	public int m_TargetMinLv;
	public int TargetMinLv
	{
		get { return m_TargetMinLv;}
		set { m_TargetMinLv = value; }
	}
	//目标最大等级
	public int m_TargetMaxLv;
	public int TargetMaxLv
	{
		get { return m_TargetMaxLv;}
		set { m_TargetMaxLv = value; }
	}


};
//更改队伍目标回应封装类
[System.Serializable]
public class TeamRpcChangeTeamTargetReplyWraper
{

	//构造函数
	public TeamRpcChangeTeamTargetReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcChangeTeamTargetReply ToPB()
	{
		TeamRpcChangeTeamTargetReply v = new TeamRpcChangeTeamTargetReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcChangeTeamTargetReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcChangeTeamTargetReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcChangeTeamTargetReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcChangeTeamTargetReply>(protoMS);
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
//被邀请入队通知通知封装类
[System.Serializable]
public class TeamRpcBeInvitedNoticeNotifyWraper
{

	//构造函数
	public TeamRpcBeInvitedNoticeNotifyWraper()
	{
		 m_TeamId = -1;
		 m_UserId = -1;
		 m_UserName = "";
		 m_CaptainUserName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TeamId = -1;
		 m_UserId = -1;
		 m_UserName = "";
		 m_CaptainUserName = "";

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBeInvitedNoticeNotify ToPB()
	{
		TeamRpcBeInvitedNoticeNotify v = new TeamRpcBeInvitedNoticeNotify();
		v.TeamId = m_TeamId;
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.CaptainUserName = m_CaptainUserName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBeInvitedNoticeNotify v)
	{
        if (v == null)
            return;
		m_TeamId = v.TeamId;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_CaptainUserName = v.CaptainUserName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBeInvitedNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBeInvitedNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcBeInvitedNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//邀请人的用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//邀请人的名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//队长名字
	public string m_CaptainUserName;
	public string CaptainUserName
	{
		get { return m_CaptainUserName;}
		set { m_CaptainUserName = value; }
	}


};
//被邀请处理请求封装类
[System.Serializable]
public class TeamRpcBeInviteHandleAskWraper
{

	//构造函数
	public TeamRpcBeInviteHandleAskWraper()
	{
		 m_TeamId = -1;
		 m_UserId = -1;
		 m_Handle = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TeamId = -1;
		 m_UserId = -1;
		 m_Handle = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBeInviteHandleAsk ToPB()
	{
		TeamRpcBeInviteHandleAsk v = new TeamRpcBeInviteHandleAsk();
		v.TeamId = m_TeamId;
		v.UserId = m_UserId;
		v.Handle = m_Handle;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBeInviteHandleAsk v)
	{
        if (v == null)
            return;
		m_TeamId = v.TeamId;
		m_UserId = v.UserId;
		m_Handle = v.Handle;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBeInviteHandleAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBeInviteHandleAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcBeInviteHandleAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//邀请人的用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//处理方式（0拒绝 1同意）
	public int m_Handle;
	public int Handle
	{
		get { return m_Handle;}
		set { m_Handle = value; }
	}


};
//被邀请处理回应封装类
[System.Serializable]
public class TeamRpcBeInviteHandleReplyWraper
{

	//构造函数
	public TeamRpcBeInviteHandleReplyWraper()
	{
		 m_Result = -9999;
		 m_TeamId = -1;
		 m_UserId = -1;
		 m_Handle = -1;
		 m_IsCapatain = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_TeamId = -1;
		 m_UserId = -1;
		 m_Handle = -1;
		 m_IsCapatain = false;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBeInviteHandleReply ToPB()
	{
		TeamRpcBeInviteHandleReply v = new TeamRpcBeInviteHandleReply();
		v.Result = m_Result;
		v.TeamId = m_TeamId;
		v.UserId = m_UserId;
		v.Handle = m_Handle;
		v.IsCapatain = m_IsCapatain;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBeInviteHandleReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_TeamId = v.TeamId;
		m_UserId = v.UserId;
		m_Handle = v.Handle;
		m_IsCapatain = v.IsCapatain;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBeInviteHandleReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBeInviteHandleReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcBeInviteHandleReply>(protoMS);
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
	//队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//邀请人的用户Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//处理方式（0拒绝 1同意）
	public int m_Handle;
	public int Handle
	{
		get { return m_Handle;}
		set { m_Handle = value; }
	}
	//邀请人是否为队长
	public bool m_IsCapatain;
	public bool IsCapatain
	{
		get { return m_IsCapatain;}
		set { m_IsCapatain = value; }
	}


};
//附近队伍对象封装类
[System.Serializable]
public class TeamRpcNearbyTeamObjWraper
{

	//构造函数
	public TeamRpcNearbyTeamObjWraper()
	{
		 m_TeamId = -1;
		 m_CaptainUserId = -1;
		 m_CaptainUserName = "";
		 m_CaptainLevel = -1;
		 m_MemberCount = -1;
		 m_CaptainProf = -1;
		 m_TeamTarget = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TeamId = -1;
		 m_CaptainUserId = -1;
		 m_CaptainUserName = "";
		 m_CaptainLevel = -1;
		 m_MemberCount = -1;
		 m_CaptainProf = -1;
		 m_TeamTarget = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNearbyTeamObj ToPB()
	{
		TeamRpcNearbyTeamObj v = new TeamRpcNearbyTeamObj();
		v.TeamId = m_TeamId;
		v.CaptainUserId = m_CaptainUserId;
		v.CaptainUserName = m_CaptainUserName;
		v.CaptainLevel = m_CaptainLevel;
		v.MemberCount = m_MemberCount;
		v.CaptainProf = m_CaptainProf;
		v.TeamTarget = m_TeamTarget;
		v.TargetMinLv = m_TargetMinLv;
		v.TargetMaxLv = m_TargetMaxLv;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNearbyTeamObj v)
	{
        if (v == null)
            return;
		m_TeamId = v.TeamId;
		m_CaptainUserId = v.CaptainUserId;
		m_CaptainUserName = v.CaptainUserName;
		m_CaptainLevel = v.CaptainLevel;
		m_MemberCount = v.MemberCount;
		m_CaptainProf = v.CaptainProf;
		m_TeamTarget = v.TeamTarget;
		m_TargetMinLv = v.TargetMinLv;
		m_TargetMaxLv = v.TargetMaxLv;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNearbyTeamObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNearbyTeamObj pb = ProtoBuf.Serializer.Deserialize<TeamRpcNearbyTeamObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//组队Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//队长用户Id
	public long m_CaptainUserId;
	public long CaptainUserId
	{
		get { return m_CaptainUserId;}
		set { m_CaptainUserId = value; }
	}
	//队长名字
	public string m_CaptainUserName;
	public string CaptainUserName
	{
		get { return m_CaptainUserName;}
		set { m_CaptainUserName = value; }
	}
	//队长等级
	public int m_CaptainLevel;
	public int CaptainLevel
	{
		get { return m_CaptainLevel;}
		set { m_CaptainLevel = value; }
	}
	//队伍人数
	public int m_MemberCount;
	public int MemberCount
	{
		get { return m_MemberCount;}
		set { m_MemberCount = value; }
	}
	//队长职业
	public int m_CaptainProf;
	public int CaptainProf
	{
		get { return m_CaptainProf;}
		set { m_CaptainProf = value; }
	}
	//队伍目标
	public int m_TeamTarget;
	public int TeamTarget
	{
		get { return m_TeamTarget;}
		set { m_TeamTarget = value; }
	}
	//目标最小等级
	public int m_TargetMinLv;
	public int TargetMinLv
	{
		get { return m_TargetMinLv;}
		set { m_TargetMinLv = value; }
	}
	//目标最大等级
	public int m_TargetMaxLv;
	public int TargetMaxLv
	{
		get { return m_TargetMaxLv;}
		set { m_TargetMaxLv = value; }
	}


};
//附近队伍请求封装类
[System.Serializable]
public class TeamRpcNearbyTeamAskWraper
{

	//构造函数
	public TeamRpcNearbyTeamAskWraper()
	{
		 m_TargetId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TargetId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNearbyTeamAsk ToPB()
	{
		TeamRpcNearbyTeamAsk v = new TeamRpcNearbyTeamAsk();
		v.TargetId = m_TargetId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNearbyTeamAsk v)
	{
        if (v == null)
            return;
		m_TargetId = v.TargetId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNearbyTeamAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNearbyTeamAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcNearbyTeamAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//目标id,-1是附近队伍
	public int m_TargetId;
	public int TargetId
	{
		get { return m_TargetId;}
		set { m_TargetId = value; }
	}


};
//附近队伍回应封装类
[System.Serializable]
public class TeamRpcNearbyTeamReplyWraper
{

	//构造函数
	public TeamRpcNearbyTeamReplyWraper()
	{
		 m_Result = -9999;
		m_Teams = new List<TeamRpcNearbyTeamObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_Teams = new List<TeamRpcNearbyTeamObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNearbyTeamReply ToPB()
	{
		TeamRpcNearbyTeamReply v = new TeamRpcNearbyTeamReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_Teams.Count; i++)
			v.Teams.Add( m_Teams[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNearbyTeamReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_Teams.Clear();
		for( int i=0; i<v.Teams.Count; i++)
			m_Teams.Add( new TeamRpcNearbyTeamObjWraper());
		for( int i=0; i<v.Teams.Count; i++)
			m_Teams[i].FromPB(v.Teams[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNearbyTeamReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNearbyTeamReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcNearbyTeamReply>(protoMS);
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
	//队伍
	public List<TeamRpcNearbyTeamObjWraper> m_Teams;
	public int SizeTeams()
	{
		return m_Teams.Count;
	}
	public List<TeamRpcNearbyTeamObjWraper> GetTeams()
	{
		return m_Teams;
	}
	public TeamRpcNearbyTeamObjWraper GetTeams(int Index)
	{
		if(Index<0 || Index>=(int)m_Teams.Count)
			return new TeamRpcNearbyTeamObjWraper();
		return m_Teams[Index];
	}
	public void SetTeams( List<TeamRpcNearbyTeamObjWraper> v )
	{
		m_Teams=v;
	}
	public void SetTeams( int Index, TeamRpcNearbyTeamObjWraper v )
	{
		if(Index<0 || Index>=(int)m_Teams.Count)
			return;
		m_Teams[Index] = v;
	}
	public void AddTeams( TeamRpcNearbyTeamObjWraper v )
	{
		m_Teams.Add(v);
	}
	public void ClearTeams( )
	{
		m_Teams.Clear();
	}


};
//有人申请入队,队长收到通知通知封装类
[System.Serializable]
public class TeamRpcApplyNoticeCaptainNotifyWraper
{

	//构造函数
	public TeamRpcApplyNoticeCaptainNotifyWraper()
	{
		 m_ApplyUser = new TeamApplyUserObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ApplyUser = new TeamApplyUserObjWraper();

	}

 	//转化成Protobuffer类型函数
	public TeamRpcApplyNoticeCaptainNotify ToPB()
	{
		TeamRpcApplyNoticeCaptainNotify v = new TeamRpcApplyNoticeCaptainNotify();
		v.ApplyUser = m_ApplyUser.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcApplyNoticeCaptainNotify v)
	{
        if (v == null)
            return;
		m_ApplyUser.FromPB(v.ApplyUser);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcApplyNoticeCaptainNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcApplyNoticeCaptainNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcApplyNoticeCaptainNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//申请列表
	public TeamApplyUserObjWraper m_ApplyUser;
	public TeamApplyUserObjWraper ApplyUser
	{
		get { return m_ApplyUser;}
		set { m_ApplyUser = value; }
	}


};
//申请入队,队长同意入队请求封装类
[System.Serializable]
public class TeamRpcApplyHandleAgreeAskWraper
{

	//构造函数
	public TeamRpcApplyHandleAgreeAskWraper()
	{
		 m_UserId = -1;
		 m_TeamId = -1;
		 m_Handle = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_TeamId = -1;
		 m_Handle = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcApplyHandleAgreeAsk ToPB()
	{
		TeamRpcApplyHandleAgreeAsk v = new TeamRpcApplyHandleAgreeAsk();
		v.UserId = m_UserId;
		v.TeamId = m_TeamId;
		v.Handle = m_Handle;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcApplyHandleAgreeAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_TeamId = v.TeamId;
		m_Handle = v.Handle;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcApplyHandleAgreeAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcApplyHandleAgreeAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcApplyHandleAgreeAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//申请人的UserId
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//申请人申请的队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//处理方式（0拒绝 1同意）
	public int m_Handle;
	public int Handle
	{
		get { return m_Handle;}
		set { m_Handle = value; }
	}


};
//申请入队,队长同意入队回应封装类
[System.Serializable]
public class TeamRpcApplyHandleAgreeReplyWraper
{

	//构造函数
	public TeamRpcApplyHandleAgreeReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_TeamId = -1;
		 m_Handle = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;
		 m_TeamId = -1;
		 m_Handle = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcApplyHandleAgreeReply ToPB()
	{
		TeamRpcApplyHandleAgreeReply v = new TeamRpcApplyHandleAgreeReply();
		v.Result = m_Result;
		v.UserId = m_UserId;
		v.TeamId = m_TeamId;
		v.Handle = m_Handle;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcApplyHandleAgreeReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;
		m_TeamId = v.TeamId;
		m_Handle = v.Handle;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcApplyHandleAgreeReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcApplyHandleAgreeReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcApplyHandleAgreeReply>(protoMS);
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
	//申请人的UserId
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//申请人申请的队伍Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}
	//处理方式（0拒绝 1同意）
	public int m_Handle;
	public int Handle
	{
		get { return m_Handle;}
		set { m_Handle = value; }
	}


};
//更新我的队伍通知通知封装类
[System.Serializable]
public class TeamRpcUpdateMyTeamNoticeNotifyWraper
{

	//构造函数
	public TeamRpcUpdateMyTeamNoticeNotifyWraper()
	{
		 m_MyTeamData = new TeamObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_MyTeamData = new TeamObjWraper();

	}

 	//转化成Protobuffer类型函数
	public TeamRpcUpdateMyTeamNoticeNotify ToPB()
	{
		TeamRpcUpdateMyTeamNoticeNotify v = new TeamRpcUpdateMyTeamNoticeNotify();
		v.MyTeamData = m_MyTeamData.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcUpdateMyTeamNoticeNotify v)
	{
        if (v == null)
            return;
		m_MyTeamData.FromPB(v.MyTeamData);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcUpdateMyTeamNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcUpdateMyTeamNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcUpdateMyTeamNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//组队数据
	public TeamObjWraper m_MyTeamData;
	public TeamObjWraper MyTeamData
	{
		get { return m_MyTeamData;}
		set { m_MyTeamData = value; }
	}


};
//离开队伍通知封装类
[System.Serializable]
public class TeamRpcQuitTeamNotifyWraper
{

	//构造函数
	public TeamRpcQuitTeamNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcQuitTeamNotify ToPB()
	{
		TeamRpcQuitTeamNotify v = new TeamRpcQuitTeamNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcQuitTeamNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcQuitTeamNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcQuitTeamNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcQuitTeamNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
//离开队伍通知通知封装类
[System.Serializable]
public class TeamRpcLeaveTeamNoticeNotifyWraper
{

	//构造函数
	public TeamRpcLeaveTeamNoticeNotifyWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

 	//转化成Protobuffer类型函数
	public TeamRpcLeaveTeamNoticeNotify ToPB()
	{
		TeamRpcLeaveTeamNoticeNotify v = new TeamRpcLeaveTeamNoticeNotify();
		v.UserId = m_UserId;
		v.UserName = m_UserName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcLeaveTeamNoticeNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcLeaveTeamNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcLeaveTeamNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcLeaveTeamNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//离开的玩家Id
	public int m_UserId;
	public int UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//离开的玩家名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}


};
//解散队伍通知通知封装类
[System.Serializable]
public class TeamRpcBreakUpNoticeNotifyWraper
{

	//构造函数
	public TeamRpcBreakUpNoticeNotifyWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBreakUpNoticeNotify ToPB()
	{
		TeamRpcBreakUpNoticeNotify v = new TeamRpcBreakUpNoticeNotify();
		v.UserId = m_UserId;
		v.UserName = m_UserName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBreakUpNoticeNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBreakUpNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBreakUpNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcBreakUpNoticeNotify>(protoMS);
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
	//用户名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}


};
//请求我的队伍数据通知封装类
[System.Serializable]
public class TeamRpcReqMyTeamDataNotifyWraper
{

	//构造函数
	public TeamRpcReqMyTeamDataNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcReqMyTeamDataNotify ToPB()
	{
		TeamRpcReqMyTeamDataNotify v = new TeamRpcReqMyTeamDataNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcReqMyTeamDataNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcReqMyTeamDataNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcReqMyTeamDataNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcReqMyTeamDataNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
//申请列表处理后删除申请的玩家通知封装类
[System.Serializable]
public class TeamRpcDeleteFromApplyListNotifyWraper
{

	//构造函数
	public TeamRpcDeleteFromApplyListNotifyWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcDeleteFromApplyListNotify ToPB()
	{
		TeamRpcDeleteFromApplyListNotify v = new TeamRpcDeleteFromApplyListNotify();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcDeleteFromApplyListNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcDeleteFromApplyListNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcDeleteFromApplyListNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcDeleteFromApplyListNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//离开的玩家Id
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//任命队长请求封装类
[System.Serializable]
public class TeamRpcAppointCaptainAskWraper
{

	//构造函数
	public TeamRpcAppointCaptainAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcAppointCaptainAsk ToPB()
	{
		TeamRpcAppointCaptainAsk v = new TeamRpcAppointCaptainAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcAppointCaptainAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcAppointCaptainAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcAppointCaptainAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcAppointCaptainAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//被任命的人
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//任命队长回应封装类
[System.Serializable]
public class TeamRpcAppointCaptainReplyWraper
{

	//构造函数
	public TeamRpcAppointCaptainReplyWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcAppointCaptainReply ToPB()
	{
		TeamRpcAppointCaptainReply v = new TeamRpcAppointCaptainReply();
		v.Result = m_Result;
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcAppointCaptainReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcAppointCaptainReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcAppointCaptainReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcAppointCaptainReply>(protoMS);
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
	//被任命的人
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}


};
//队长换人通知通知封装类
[System.Serializable]
public class TeamRpcCaptainChangeNoticeNotifyWraper
{

	//构造函数
	public TeamRpcCaptainChangeNoticeNotifyWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

 	//转化成Protobuffer类型函数
	public TeamRpcCaptainChangeNoticeNotify ToPB()
	{
		TeamRpcCaptainChangeNoticeNotify v = new TeamRpcCaptainChangeNoticeNotify();
		v.UserId = m_UserId;
		v.UserName = m_UserName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcCaptainChangeNoticeNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcCaptainChangeNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcCaptainChangeNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcCaptainChangeNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//被任命的人
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//被任命的人
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}


};
//队员血量变化通知通知封装类
[System.Serializable]
public class TeamRpcTeamMemberHPChangeNoticeNotifyWraper
{

	//构造函数
	public TeamRpcTeamMemberHPChangeNoticeNotifyWraper()
	{
		 m_UserId = -1;
		 m_HP = -1;
		 m_MaxHP = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_HP = -1;
		 m_MaxHP = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcTeamMemberHPChangeNoticeNotify ToPB()
	{
		TeamRpcTeamMemberHPChangeNoticeNotify v = new TeamRpcTeamMemberHPChangeNoticeNotify();
		v.UserId = m_UserId;
		v.HP = m_HP;
		v.MaxHP = m_MaxHP;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcTeamMemberHPChangeNoticeNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_HP = v.HP;
		m_MaxHP = v.MaxHP;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcTeamMemberHPChangeNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcTeamMemberHPChangeNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcTeamMemberHPChangeNoticeNotify>(protoMS);
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
	//HP
	public int m_HP;
	public int HP
	{
		get { return m_HP;}
		set { m_HP = value; }
	}
	//MaxHP
	public int m_MaxHP;
	public int MaxHP
	{
		get { return m_MaxHP;}
		set { m_MaxHP = value; }
	}


};
//邀请组队的人收到被邀请人的处理通知通知封装类
[System.Serializable]
public class TeamRpcInviteHandleNoticeNotifyWraper
{

	//构造函数
	public TeamRpcInviteHandleNoticeNotifyWraper()
	{
		 m_Result = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = 0;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcInviteHandleNoticeNotify ToPB()
	{
		TeamRpcInviteHandleNoticeNotify v = new TeamRpcInviteHandleNoticeNotify();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcInviteHandleNoticeNotify v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcInviteHandleNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcInviteHandleNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcInviteHandleNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//返回结果(0是拒绝，1是同意)
	public int m_Result;
	public int Result
	{
		get { return m_Result;}
		set { m_Result = value; }
	}


};
//附近玩家信息封装类
[System.Serializable]
public class TeamRpcNearbyRoleObjWraper
{

	//构造函数
	public TeamRpcNearbyRoleObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNearbyRoleObj ToPB()
	{
		TeamRpcNearbyRoleObj v = new TeamRpcNearbyRoleObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNearbyRoleObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNearbyRoleObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNearbyRoleObj pb = ProtoBuf.Serializer.Deserialize<TeamRpcNearbyRoleObj>(protoMS);
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
	//用户名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//玩家等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}


};
//附加玩家列表，邀请时使用请求封装类
[System.Serializable]
public class TeamRpcNearbyRoleListAskWraper
{

	//构造函数
	public TeamRpcNearbyRoleListAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNearbyRoleListAsk ToPB()
	{
		TeamRpcNearbyRoleListAsk v = new TeamRpcNearbyRoleListAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNearbyRoleListAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNearbyRoleListAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNearbyRoleListAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcNearbyRoleListAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//附加玩家列表，邀请时使用回应封装类
[System.Serializable]
public class TeamRpcNearbyRoleListReplyWraper
{

	//构造函数
	public TeamRpcNearbyRoleListReplyWraper()
	{
		 m_Result = -9999;
		m_NearbyRoleList = new List<TeamRpcNearbyRoleObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_NearbyRoleList = new List<TeamRpcNearbyRoleObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNearbyRoleListReply ToPB()
	{
		TeamRpcNearbyRoleListReply v = new TeamRpcNearbyRoleListReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_NearbyRoleList.Count; i++)
			v.NearbyRoleList.Add( m_NearbyRoleList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNearbyRoleListReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_NearbyRoleList.Clear();
		for( int i=0; i<v.NearbyRoleList.Count; i++)
			m_NearbyRoleList.Add( new TeamRpcNearbyRoleObjWraper());
		for( int i=0; i<v.NearbyRoleList.Count; i++)
			m_NearbyRoleList[i].FromPB(v.NearbyRoleList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNearbyRoleListReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNearbyRoleListReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcNearbyRoleListReply>(protoMS);
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
	//附近玩家列表
	public List<TeamRpcNearbyRoleObjWraper> m_NearbyRoleList;
	public int SizeNearbyRoleList()
	{
		return m_NearbyRoleList.Count;
	}
	public List<TeamRpcNearbyRoleObjWraper> GetNearbyRoleList()
	{
		return m_NearbyRoleList;
	}
	public TeamRpcNearbyRoleObjWraper GetNearbyRoleList(int Index)
	{
		if(Index<0 || Index>=(int)m_NearbyRoleList.Count)
			return new TeamRpcNearbyRoleObjWraper();
		return m_NearbyRoleList[Index];
	}
	public void SetNearbyRoleList( List<TeamRpcNearbyRoleObjWraper> v )
	{
		m_NearbyRoleList=v;
	}
	public void SetNearbyRoleList( int Index, TeamRpcNearbyRoleObjWraper v )
	{
		if(Index<0 || Index>=(int)m_NearbyRoleList.Count)
			return;
		m_NearbyRoleList[Index] = v;
	}
	public void AddNearbyRoleList( TeamRpcNearbyRoleObjWraper v )
	{
		m_NearbyRoleList.Add(v);
	}
	public void ClearNearbyRoleList( )
	{
		m_NearbyRoleList.Clear();
	}


};
//队长踢人请求封装类
[System.Serializable]
public class TeamRpcKickRoleAskWraper
{

	//构造函数
	public TeamRpcKickRoleAskWraper()
	{
		 m_UserId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcKickRoleAsk ToPB()
	{
		TeamRpcKickRoleAsk v = new TeamRpcKickRoleAsk();
		v.UserId = m_UserId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcKickRoleAsk v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcKickRoleAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcKickRoleAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcKickRoleAsk>(protoMS);
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
//队长踢人回应封装类
[System.Serializable]
public class TeamRpcKickRoleReplyWraper
{

	//构造函数
	public TeamRpcKickRoleReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcKickRoleReply ToPB()
	{
		TeamRpcKickRoleReply v = new TeamRpcKickRoleReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcKickRoleReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcKickRoleReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcKickRoleReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcKickRoleReply>(protoMS);
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
//被踢通知通知封装类
[System.Serializable]
public class TeamRpcBeingKickedNoticeNotifyWraper
{

	//构造函数
	public TeamRpcBeingKickedNoticeNotifyWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBeingKickedNoticeNotify ToPB()
	{
		TeamRpcBeingKickedNoticeNotify v = new TeamRpcBeingKickedNoticeNotify();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBeingKickedNoticeNotify v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBeingKickedNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBeingKickedNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcBeingKickedNoticeNotify>(protoMS);
		FromPB(pb);
		return true;
	}



};
//解散队伍请求封装类
[System.Serializable]
public class TeamRpcBreakUpAskWraper
{

	//构造函数
	public TeamRpcBreakUpAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBreakUpAsk ToPB()
	{
		TeamRpcBreakUpAsk v = new TeamRpcBreakUpAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBreakUpAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBreakUpAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBreakUpAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcBreakUpAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//解散队伍回应封装类
[System.Serializable]
public class TeamRpcBreakUpReplyWraper
{

	//构造函数
	public TeamRpcBreakUpReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcBreakUpReply ToPB()
	{
		TeamRpcBreakUpReply v = new TeamRpcBreakUpReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcBreakUpReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcBreakUpReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcBreakUpReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcBreakUpReply>(protoMS);
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
//队员增加新成员通知通知封装类
[System.Serializable]
public class TeamRpcAddNewMemberNoticeNotifyWraper
{

	//构造函数
	public TeamRpcAddNewMemberNoticeNotifyWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";

	}

 	//转化成Protobuffer类型函数
	public TeamRpcAddNewMemberNoticeNotify ToPB()
	{
		TeamRpcAddNewMemberNoticeNotify v = new TeamRpcAddNewMemberNoticeNotify();
		v.UserId = m_UserId;
		v.UserName = m_UserName;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcAddNewMemberNoticeNotify v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcAddNewMemberNoticeNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcAddNewMemberNoticeNotify pb = ProtoBuf.Serializer.Deserialize<TeamRpcAddNewMemberNoticeNotify>(protoMS);
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
	//用户名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}


};
//队长自己匹配请求封装类
[System.Serializable]
public class TeamRpcCaptainAutoMatchAskWraper
{

	//构造函数
	public TeamRpcCaptainAutoMatchAskWraper()
	{
		 m_Oper = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Oper = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcCaptainAutoMatchAsk ToPB()
	{
		TeamRpcCaptainAutoMatchAsk v = new TeamRpcCaptainAutoMatchAsk();
		v.Oper = m_Oper;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcCaptainAutoMatchAsk v)
	{
        if (v == null)
            return;
		m_Oper = v.Oper;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcCaptainAutoMatchAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcCaptainAutoMatchAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcCaptainAutoMatchAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//0是开始，1是结束
	public int m_Oper;
	public int Oper
	{
		get { return m_Oper;}
		set { m_Oper = value; }
	}


};
//队长自己匹配回应封装类
[System.Serializable]
public class TeamRpcCaptainAutoMatchReplyWraper
{

	//构造函数
	public TeamRpcCaptainAutoMatchReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcCaptainAutoMatchReply ToPB()
	{
		TeamRpcCaptainAutoMatchReply v = new TeamRpcCaptainAutoMatchReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcCaptainAutoMatchReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcCaptainAutoMatchReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcCaptainAutoMatchReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcCaptainAutoMatchReply>(protoMS);
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
//非队长匹配请求封装类
[System.Serializable]
public class TeamRpcNormalAutoMatchAskWraper
{

	//构造函数
	public TeamRpcNormalAutoMatchAskWraper()
	{
		 m_Oper = -1;
		 m_Target = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Oper = -1;
		 m_Target = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNormalAutoMatchAsk ToPB()
	{
		TeamRpcNormalAutoMatchAsk v = new TeamRpcNormalAutoMatchAsk();
		v.Oper = m_Oper;
		v.Target = m_Target;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNormalAutoMatchAsk v)
	{
        if (v == null)
            return;
		m_Oper = v.Oper;
		m_Target = v.Target;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNormalAutoMatchAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNormalAutoMatchAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcNormalAutoMatchAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//0是开始，1是结束
	public int m_Oper;
	public int Oper
	{
		get { return m_Oper;}
		set { m_Oper = value; }
	}
	//目标
	public int m_Target;
	public int Target
	{
		get { return m_Target;}
		set { m_Target = value; }
	}


};
//非队长匹配回应封装类
[System.Serializable]
public class TeamRpcNormalAutoMatchReplyWraper
{

	//构造函数
	public TeamRpcNormalAutoMatchReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcNormalAutoMatchReply ToPB()
	{
		TeamRpcNormalAutoMatchReply v = new TeamRpcNormalAutoMatchReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcNormalAutoMatchReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcNormalAutoMatchReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcNormalAutoMatchReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcNormalAutoMatchReply>(protoMS);
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
//跟随请求封装类
[System.Serializable]
public class TeamRpcFollowAskWraper
{

	//构造函数
	public TeamRpcFollowAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcFollowAsk ToPB()
	{
		TeamRpcFollowAsk v = new TeamRpcFollowAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcFollowAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcFollowAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcFollowAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcFollowAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//跟随回应封装类
[System.Serializable]
public class TeamRpcFollowReplyWraper
{

	//构造函数
	public TeamRpcFollowReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcFollowReply ToPB()
	{
		TeamRpcFollowReply v = new TeamRpcFollowReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcFollowReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcFollowReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcFollowReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcFollowReply>(protoMS);
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
//清空申请列表请求封装类
[System.Serializable]
public class TeamRpcClearApplyListAskWraper
{

	//构造函数
	public TeamRpcClearApplyListAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public TeamRpcClearApplyListAsk ToPB()
	{
		TeamRpcClearApplyListAsk v = new TeamRpcClearApplyListAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcClearApplyListAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcClearApplyListAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcClearApplyListAsk pb = ProtoBuf.Serializer.Deserialize<TeamRpcClearApplyListAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//清空申请列表回应封装类
[System.Serializable]
public class TeamRpcClearApplyListReplyWraper
{

	//构造函数
	public TeamRpcClearApplyListReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public TeamRpcClearApplyListReply ToPB()
	{
		TeamRpcClearApplyListReply v = new TeamRpcClearApplyListReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamRpcClearApplyListReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamRpcClearApplyListReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamRpcClearApplyListReply pb = ProtoBuf.Serializer.Deserialize<TeamRpcClearApplyListReply>(protoMS);
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
