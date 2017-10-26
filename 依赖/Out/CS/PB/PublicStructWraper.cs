
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperPubPBCommon.cs
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
public class TeamUserObjWraper
{

	//构造函数
	public TeamUserObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_IsCaptain = false;
		 m_Prof = -1;
		 m_HP = -1;
		 m_MaxHP = -1;
		 m_IsFollowing = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_IsCaptain = false;
		 m_Prof = -1;
		 m_HP = -1;
		 m_MaxHP = -1;
		 m_IsFollowing = false;

	}

 	//转化成Protobuffer类型函数
	public TeamUserObj ToPB()
	{
		TeamUserObj v = new TeamUserObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.IsCaptain = m_IsCaptain;
		v.Prof = m_Prof;
		v.HP = m_HP;
		v.MaxHP = m_MaxHP;
		v.IsFollowing = m_IsFollowing;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamUserObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_IsCaptain = v.IsCaptain;
		m_Prof = v.Prof;
		m_HP = v.HP;
		m_MaxHP = v.MaxHP;
		m_IsFollowing = v.IsFollowing;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamUserObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamUserObj pb = ProtoBuf.Serializer.Deserialize<TeamUserObj>(protoMS);
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
	//是否为队长
	public bool m_IsCaptain;
	public bool IsCaptain
	{
		get { return m_IsCaptain;}
		set { m_IsCaptain = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
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
	//是否在跟随状态中
	public bool m_IsFollowing;
	public bool IsFollowing
	{
		get { return m_IsFollowing;}
		set { m_IsFollowing = value; }
	}


};
//组队对象封装类
[System.Serializable]
public class TeamObjWraper
{

	//构造函数
	public TeamObjWraper()
	{
		 m_TeamId = -1;
		 m_CaptainUserId = -1;
		 m_MemberCount = -1;
		 m_TeamTarget = -1;
		m_TeamMember = new List<TeamUserObjWraper>();
		 m_CaptainProf = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;
		 m_IsMatching = false;
		 m_CaptainLevel = -1;
		 m_IsTeamFollow = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_TeamId = -1;
		 m_CaptainUserId = -1;
		 m_MemberCount = -1;
		 m_TeamTarget = -1;
		m_TeamMember = new List<TeamUserObjWraper>();
		 m_CaptainProf = -1;
		 m_TargetMinLv = -1;
		 m_TargetMaxLv = -1;
		 m_IsMatching = false;
		 m_CaptainLevel = -1;
		 m_IsTeamFollow = false;

	}

 	//转化成Protobuffer类型函数
	public TeamObj ToPB()
	{
		TeamObj v = new TeamObj();
		v.TeamId = m_TeamId;
		v.CaptainUserId = m_CaptainUserId;
		v.MemberCount = m_MemberCount;
		v.TeamTarget = m_TeamTarget;
		for (int i=0; i<(int)m_TeamMember.Count; i++)
			v.TeamMember.Add( m_TeamMember[i].ToPB());
		v.CaptainProf = m_CaptainProf;
		v.TargetMinLv = m_TargetMinLv;
		v.TargetMaxLv = m_TargetMaxLv;
		v.IsMatching = m_IsMatching;
		v.CaptainLevel = m_CaptainLevel;
		v.IsTeamFollow = m_IsTeamFollow;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamObj v)
	{
        if (v == null)
            return;
		m_TeamId = v.TeamId;
		m_CaptainUserId = v.CaptainUserId;
		m_MemberCount = v.MemberCount;
		m_TeamTarget = v.TeamTarget;
		m_TeamMember.Clear();
		for( int i=0; i<v.TeamMember.Count; i++)
			m_TeamMember.Add( new TeamUserObjWraper());
		for( int i=0; i<v.TeamMember.Count; i++)
			m_TeamMember[i].FromPB(v.TeamMember[i]);
		m_CaptainProf = v.CaptainProf;
		m_TargetMinLv = v.TargetMinLv;
		m_TargetMaxLv = v.TargetMaxLv;
		m_IsMatching = v.IsMatching;
		m_CaptainLevel = v.CaptainLevel;
		m_IsTeamFollow = v.IsTeamFollow;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamObj pb = ProtoBuf.Serializer.Deserialize<TeamObj>(protoMS);
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
	//队伍人数
	public int m_MemberCount;
	public int MemberCount
	{
		get { return m_MemberCount;}
		set { m_MemberCount = value; }
	}
	//队伍目标Id
	public int m_TeamTarget;
	public int TeamTarget
	{
		get { return m_TeamTarget;}
		set { m_TeamTarget = value; }
	}
	//成员
	public List<TeamUserObjWraper> m_TeamMember;
	public int SizeTeamMember()
	{
		return m_TeamMember.Count;
	}
	public List<TeamUserObjWraper> GetTeamMember()
	{
		return m_TeamMember;
	}
	public TeamUserObjWraper GetTeamMember(int Index)
	{
		if(Index<0 || Index>=(int)m_TeamMember.Count)
			return new TeamUserObjWraper();
		return m_TeamMember[Index];
	}
	public void SetTeamMember( List<TeamUserObjWraper> v )
	{
		m_TeamMember=v;
	}
	public void SetTeamMember( int Index, TeamUserObjWraper v )
	{
		if(Index<0 || Index>=(int)m_TeamMember.Count)
			return;
		m_TeamMember[Index] = v;
	}
	public void AddTeamMember( TeamUserObjWraper v )
	{
		m_TeamMember.Add(v);
	}
	public void ClearTeamMember( )
	{
		m_TeamMember.Clear();
	}
	//队长职业
	public int m_CaptainProf;
	public int CaptainProf
	{
		get { return m_CaptainProf;}
		set { m_CaptainProf = value; }
	}
	//匹配最小等级
	public int m_TargetMinLv;
	public int TargetMinLv
	{
		get { return m_TargetMinLv;}
		set { m_TargetMinLv = value; }
	}
	//匹配最大等级
	public int m_TargetMaxLv;
	public int TargetMaxLv
	{
		get { return m_TargetMaxLv;}
		set { m_TargetMaxLv = value; }
	}
	//是否匹配中
	public bool m_IsMatching;
	public bool IsMatching
	{
		get { return m_IsMatching;}
		set { m_IsMatching = value; }
	}
	//队长等级
	public int m_CaptainLevel;
	public int CaptainLevel
	{
		get { return m_CaptainLevel;}
		set { m_CaptainLevel = value; }
	}
	//队长是否开启跟随
	public bool m_IsTeamFollow;
	public bool IsTeamFollow
	{
		get { return m_IsTeamFollow;}
		set { m_IsTeamFollow = value; }
	}


};
//组队申请用户对象封装类
[System.Serializable]
public class TeamApplyUserObjWraper
{

	//构造函数
	public TeamApplyUserObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_TeamId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_TeamId = -1;

	}

 	//转化成Protobuffer类型函数
	public TeamApplyUserObj ToPB()
	{
		TeamApplyUserObj v = new TeamApplyUserObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;
		v.TeamId = m_TeamId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TeamApplyUserObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;
		m_TeamId = v.TeamId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TeamApplyUserObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TeamApplyUserObj pb = ProtoBuf.Serializer.Deserialize<TeamApplyUserObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//UserId
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
	//组队Id
	public int m_TeamId;
	public int TeamId
	{
		get { return m_TeamId;}
		set { m_TeamId = value; }
	}


};
//背包回收格子封装类
[System.Serializable]
public class BagRecycleGridObjWraper
{

	//构造函数
	public BagRecycleGridObjWraper()
	{
		 m_ItemId = -1;
		 m_TemplateId = -1;
		 m_Num = -1;
		 m_ItemType = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemId = -1;
		 m_TemplateId = -1;
		 m_Num = -1;
		 m_ItemType = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public BagRecycleGridObj ToPB()
	{
		BagRecycleGridObj v = new BagRecycleGridObj();
		v.ItemId = m_ItemId;
		v.TemplateId = m_TemplateId;
		v.Num = m_Num;
		v.ItemType = m_ItemType;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagRecycleGridObj v)
	{
        if (v == null)
            return;
		m_ItemId = v.ItemId;
		m_TemplateId = v.TemplateId;
		m_Num = v.Num;
		m_ItemType = v.ItemType;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagRecycleGridObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagRecycleGridObj pb = ProtoBuf.Serializer.Deserialize<BagRecycleGridObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//道具id
	public long m_ItemId;
	public long ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//数量
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


};
//键值对封装类
[System.Serializable]
public class KeyValue2Wraper
{

	//构造函数
	public KeyValue2Wraper()
	{
		 m_Key = -1;
		 m_Value = (float)-1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Key = -1;
		 m_Value = (float)-1;

	}

 	//转化成Protobuffer类型函数
	public KeyValue2 ToPB()
	{
		KeyValue2 v = new KeyValue2();
		v.Key = m_Key;
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(KeyValue2 v)
	{
        if (v == null)
            return;
		m_Key = v.Key;
		m_Value = v.Value;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<KeyValue2>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		KeyValue2 pb = ProtoBuf.Serializer.Deserialize<KeyValue2>(protoMS);
		FromPB(pb);
		return true;
	}

	//键
	public int m_Key;
	public int Key
	{
		get { return m_Key;}
		set { m_Key = value; }
	}
	//值
	public float m_Value;
	public float Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
//装备技能或BUFF信息封装类
[System.Serializable]
public class EquipSkillBuff2Wraper
{

	//构造函数
	public EquipSkillBuff2Wraper()
	{
		 m_Id = -1;
		 m_LV = -1;
		 m_Cd = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_LV = -1;
		 m_Cd = -1;

	}

 	//转化成Protobuffer类型函数
	public EquipSkillBuff2 ToPB()
	{
		EquipSkillBuff2 v = new EquipSkillBuff2();
		v.Id = m_Id;
		v.LV = m_LV;
		v.Cd = m_Cd;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(EquipSkillBuff2 v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_LV = v.LV;
		m_Cd = v.Cd;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<EquipSkillBuff2>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		EquipSkillBuff2 pb = ProtoBuf.Serializer.Deserialize<EquipSkillBuff2>(protoMS);
		FromPB(pb);
		return true;
	}

	//ID
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//等级
	public int m_LV;
	public int LV
	{
		get { return m_LV;}
		set { m_LV = value; }
	}
	//CD
	public int m_Cd;
	public int Cd
	{
		get { return m_Cd;}
		set { m_Cd = value; }
	}


};
//帮会成员对象封装类
[System.Serializable]
public class GuildMemberObjWraper
{

	//构造函数
	public GuildMemberObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_Duty = -1;
		 m_CurContribution = -1;
		 m_MaxContribution = -1;
		 m_LeagueMatchesCount = -1;
		 m_OfflineTime = -1;
		 m_JoinTime = -1;
		m_DropItemArray = new List<int>();
		 m_IsOnline = true;
		 m_IsGuildDungeon = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = -1;
		 m_Prof = -1;
		 m_Duty = -1;
		 m_CurContribution = -1;
		 m_MaxContribution = -1;
		 m_LeagueMatchesCount = -1;
		 m_OfflineTime = -1;
		 m_JoinTime = -1;
		m_DropItemArray = new List<int>();
		 m_IsOnline = true;
		 m_IsGuildDungeon = false;

	}

 	//转化成Protobuffer类型函数
	public GuildMemberObj ToPB()
	{
		GuildMemberObj v = new GuildMemberObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;
		v.Duty = m_Duty;
		v.CurContribution = m_CurContribution;
		v.MaxContribution = m_MaxContribution;
		v.LeagueMatchesCount = m_LeagueMatchesCount;
		v.OfflineTime = m_OfflineTime;
		v.JoinTime = m_JoinTime;
		for (int i=0; i<(int)m_DropItemArray.Count; i++)
			v.DropItemArray.Add( m_DropItemArray[i]);
		v.IsOnline = m_IsOnline;
		v.IsGuildDungeon = m_IsGuildDungeon;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildMemberObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;
		m_Duty = v.Duty;
		m_CurContribution = v.CurContribution;
		m_MaxContribution = v.MaxContribution;
		m_LeagueMatchesCount = v.LeagueMatchesCount;
		m_OfflineTime = v.OfflineTime;
		m_JoinTime = v.JoinTime;
		m_DropItemArray.Clear();
		for( int i=0; i<v.DropItemArray.Count; i++)
			m_DropItemArray.Add(v.DropItemArray[i]);
		m_IsOnline = v.IsOnline;
		m_IsGuildDungeon = v.IsGuildDungeon;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildMemberObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildMemberObj pb = ProtoBuf.Serializer.Deserialize<GuildMemberObj>(protoMS);
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
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//等级
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
	//职位
	public int m_Duty;
	public int Duty
	{
		get { return m_Duty;}
		set { m_Duty = value; }
	}
	//当前帮贡
	public int m_CurContribution;
	public int CurContribution
	{
		get { return m_CurContribution;}
		set { m_CurContribution = value; }
	}
	//最大帮贡
	public int m_MaxContribution;
	public int MaxContribution
	{
		get { return m_MaxContribution;}
		set { m_MaxContribution = value; }
	}
	//联赛次数
	public int m_LeagueMatchesCount;
	public int LeagueMatchesCount
	{
		get { return m_LeagueMatchesCount;}
		set { m_LeagueMatchesCount = value; }
	}
	//离线时间
	public int m_OfflineTime;
	public int OfflineTime
	{
		get { return m_OfflineTime;}
		set { m_OfflineTime = value; }
	}
	//加入时间
	public int m_JoinTime;
	public int JoinTime
	{
		get { return m_JoinTime;}
		set { m_JoinTime = value; }
	}
	//掉落包数组
	public List<int> m_DropItemArray;
	public int SizeDropItemArray()
	{
		return m_DropItemArray.Count;
	}
	public List<int> GetDropItemArray()
	{
		return m_DropItemArray;
	}
	public int GetDropItemArray(int Index)
	{
		if(Index<0 || Index>=(int)m_DropItemArray.Count)
			return -1;
		return m_DropItemArray[Index];
	}
	public void SetDropItemArray( List<int> v )
	{
		m_DropItemArray=v;
	}
	public void SetDropItemArray( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_DropItemArray.Count)
			return;
		m_DropItemArray[Index] = v;
	}
	public void AddDropItemArray( int v=-1 )
	{
		m_DropItemArray.Add(v);
	}
	public void ClearDropItemArray( )
	{
		m_DropItemArray.Clear();
	}
	//是否在线
	public bool m_IsOnline;
	public bool IsOnline
	{
		get { return m_IsOnline;}
		set { m_IsOnline = value; }
	}
	//是否正在参加帮会副本
	public bool m_IsGuildDungeon;
	public bool IsGuildDungeon
	{
		get { return m_IsGuildDungeon;}
		set { m_IsGuildDungeon = value; }
	}


};
//帮会信息对象封装类
[System.Serializable]
public class GuildInfoObjWraper
{

	//构造函数
	public GuildInfoObjWraper()
	{
		 m_Guild = -1;
		 m_GuildName = "";
		 m_Level = 1;
		 m_CaptainId = -1;
		 m_CaptainName = "";
		 m_Funds = -1;
		 m_CurMemberNum = 1;
		m_GuildMember = new List<GuildMemberObjWraper>();
		 m_MaintenanceCost = -1;
		 m_LeagueMatchesRank = -1;
		 m_Announcement = "";
		 m_TotalMilitary = -1;
		m_ApplyList = new List<ApplyListRoleInfoObjWraper>();
		 m_MaxMemberNum = -1;
		 m_HallLv = 1;
		 m_HallLvupTime = -1;
		 m_HouseLv = 1;
		 m_HouseLvupTime = -1;
		 m_StoreroomLv = 1;
		 m_StoreroomLvupTime = -1;
		 m_KongfuHallLv = 1;
		 m_KongfuHallLvupTime = -1;
		 m_CreateTime = -1;
		m_EventList = new List<GuildEventObjWraper>();
		m_GuildDungeonList = new List<GuildDungeonObjWraper>();
		 m_GuildWar = new GuildWarObjWraper();
		m_GuildOpenScience = new List<int>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Guild = -1;
		 m_GuildName = "";
		 m_Level = 1;
		 m_CaptainId = -1;
		 m_CaptainName = "";
		 m_Funds = -1;
		 m_CurMemberNum = 1;
		m_GuildMember = new List<GuildMemberObjWraper>();
		 m_MaintenanceCost = -1;
		 m_LeagueMatchesRank = -1;
		 m_Announcement = "";
		 m_TotalMilitary = -1;
		m_ApplyList = new List<ApplyListRoleInfoObjWraper>();
		 m_MaxMemberNum = -1;
		 m_HallLv = 1;
		 m_HallLvupTime = -1;
		 m_HouseLv = 1;
		 m_HouseLvupTime = -1;
		 m_StoreroomLv = 1;
		 m_StoreroomLvupTime = -1;
		 m_KongfuHallLv = 1;
		 m_KongfuHallLvupTime = -1;
		 m_CreateTime = -1;
		m_EventList = new List<GuildEventObjWraper>();
		m_GuildDungeonList = new List<GuildDungeonObjWraper>();
		 m_GuildWar = new GuildWarObjWraper();
		m_GuildOpenScience = new List<int>();

	}

 	//转化成Protobuffer类型函数
	public GuildInfoObj ToPB()
	{
		GuildInfoObj v = new GuildInfoObj();
		v.Guild = m_Guild;
		v.GuildName = m_GuildName;
		v.Level = m_Level;
		v.CaptainId = m_CaptainId;
		v.CaptainName = m_CaptainName;
		v.Funds = m_Funds;
		v.CurMemberNum = m_CurMemberNum;
		for (int i=0; i<(int)m_GuildMember.Count; i++)
			v.GuildMember.Add( m_GuildMember[i].ToPB());
		v.MaintenanceCost = m_MaintenanceCost;
		v.LeagueMatchesRank = m_LeagueMatchesRank;
		v.Announcement = m_Announcement;
		v.TotalMilitary = m_TotalMilitary;
		for (int i=0; i<(int)m_ApplyList.Count; i++)
			v.ApplyList.Add( m_ApplyList[i].ToPB());
		v.MaxMemberNum = m_MaxMemberNum;
		v.HallLv = m_HallLv;
		v.HallLvupTime = m_HallLvupTime;
		v.HouseLv = m_HouseLv;
		v.HouseLvupTime = m_HouseLvupTime;
		v.StoreroomLv = m_StoreroomLv;
		v.StoreroomLvupTime = m_StoreroomLvupTime;
		v.KongfuHallLv = m_KongfuHallLv;
		v.KongfuHallLvupTime = m_KongfuHallLvupTime;
		v.CreateTime = m_CreateTime;
		for (int i=0; i<(int)m_EventList.Count; i++)
			v.EventList.Add( m_EventList[i].ToPB());
		for (int i=0; i<(int)m_GuildDungeonList.Count; i++)
			v.GuildDungeonList.Add( m_GuildDungeonList[i].ToPB());
		v.GuildWar = m_GuildWar.ToPB();
		for (int i=0; i<(int)m_GuildOpenScience.Count; i++)
			v.GuildOpenScience.Add( m_GuildOpenScience[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildInfoObj v)
	{
        if (v == null)
            return;
		m_Guild = v.Guild;
		m_GuildName = v.GuildName;
		m_Level = v.Level;
		m_CaptainId = v.CaptainId;
		m_CaptainName = v.CaptainName;
		m_Funds = v.Funds;
		m_CurMemberNum = v.CurMemberNum;
		m_GuildMember.Clear();
		for( int i=0; i<v.GuildMember.Count; i++)
			m_GuildMember.Add( new GuildMemberObjWraper());
		for( int i=0; i<v.GuildMember.Count; i++)
			m_GuildMember[i].FromPB(v.GuildMember[i]);
		m_MaintenanceCost = v.MaintenanceCost;
		m_LeagueMatchesRank = v.LeagueMatchesRank;
		m_Announcement = v.Announcement;
		m_TotalMilitary = v.TotalMilitary;
		m_ApplyList.Clear();
		for( int i=0; i<v.ApplyList.Count; i++)
			m_ApplyList.Add( new ApplyListRoleInfoObjWraper());
		for( int i=0; i<v.ApplyList.Count; i++)
			m_ApplyList[i].FromPB(v.ApplyList[i]);
		m_MaxMemberNum = v.MaxMemberNum;
		m_HallLv = v.HallLv;
		m_HallLvupTime = v.HallLvupTime;
		m_HouseLv = v.HouseLv;
		m_HouseLvupTime = v.HouseLvupTime;
		m_StoreroomLv = v.StoreroomLv;
		m_StoreroomLvupTime = v.StoreroomLvupTime;
		m_KongfuHallLv = v.KongfuHallLv;
		m_KongfuHallLvupTime = v.KongfuHallLvupTime;
		m_CreateTime = v.CreateTime;
		m_EventList.Clear();
		for( int i=0; i<v.EventList.Count; i++)
			m_EventList.Add( new GuildEventObjWraper());
		for( int i=0; i<v.EventList.Count; i++)
			m_EventList[i].FromPB(v.EventList[i]);
		m_GuildDungeonList.Clear();
		for( int i=0; i<v.GuildDungeonList.Count; i++)
			m_GuildDungeonList.Add( new GuildDungeonObjWraper());
		for( int i=0; i<v.GuildDungeonList.Count; i++)
			m_GuildDungeonList[i].FromPB(v.GuildDungeonList[i]);
		m_GuildWar.FromPB(v.GuildWar);
		m_GuildOpenScience.Clear();
		for( int i=0; i<v.GuildOpenScience.Count; i++)
			m_GuildOpenScience.Add(v.GuildOpenScience[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildInfoObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildInfoObj pb = ProtoBuf.Serializer.Deserialize<GuildInfoObj>(protoMS);
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
	//当前成员数量
	public int m_CurMemberNum;
	public int CurMemberNum
	{
		get { return m_CurMemberNum;}
		set { m_CurMemberNum = value; }
	}
	//帮会成员
	public List<GuildMemberObjWraper> m_GuildMember;
	public int SizeGuildMember()
	{
		return m_GuildMember.Count;
	}
	public List<GuildMemberObjWraper> GetGuildMember()
	{
		return m_GuildMember;
	}
	public GuildMemberObjWraper GetGuildMember(int Index)
	{
		if(Index<0 || Index>=(int)m_GuildMember.Count)
			return new GuildMemberObjWraper();
		return m_GuildMember[Index];
	}
	public void SetGuildMember( List<GuildMemberObjWraper> v )
	{
		m_GuildMember=v;
	}
	public void SetGuildMember( int Index, GuildMemberObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GuildMember.Count)
			return;
		m_GuildMember[Index] = v;
	}
	public void AddGuildMember( GuildMemberObjWraper v )
	{
		m_GuildMember.Add(v);
	}
	public void ClearGuildMember( )
	{
		m_GuildMember.Clear();
	}
	//维护费用
	public int m_MaintenanceCost;
	public int MaintenanceCost
	{
		get { return m_MaintenanceCost;}
		set { m_MaintenanceCost = value; }
	}
	//联赛排名
	public int m_LeagueMatchesRank;
	public int LeagueMatchesRank
	{
		get { return m_LeagueMatchesRank;}
		set { m_LeagueMatchesRank = value; }
	}
	//公告
	public string m_Announcement;
	public string Announcement
	{
		get { return m_Announcement;}
		set { m_Announcement = value; }
	}
	//总战力
	public int m_TotalMilitary;
	public int TotalMilitary
	{
		get { return m_TotalMilitary;}
		set { m_TotalMilitary = value; }
	}
	//申请列表
	public List<ApplyListRoleInfoObjWraper> m_ApplyList;
	public int SizeApplyList()
	{
		return m_ApplyList.Count;
	}
	public List<ApplyListRoleInfoObjWraper> GetApplyList()
	{
		return m_ApplyList;
	}
	public ApplyListRoleInfoObjWraper GetApplyList(int Index)
	{
		if(Index<0 || Index>=(int)m_ApplyList.Count)
			return new ApplyListRoleInfoObjWraper();
		return m_ApplyList[Index];
	}
	public void SetApplyList( List<ApplyListRoleInfoObjWraper> v )
	{
		m_ApplyList=v;
	}
	public void SetApplyList( int Index, ApplyListRoleInfoObjWraper v )
	{
		if(Index<0 || Index>=(int)m_ApplyList.Count)
			return;
		m_ApplyList[Index] = v;
	}
	public void AddApplyList( ApplyListRoleInfoObjWraper v )
	{
		m_ApplyList.Add(v);
	}
	public void ClearApplyList( )
	{
		m_ApplyList.Clear();
	}
	//最大成员数量
	public int m_MaxMemberNum;
	public int MaxMemberNum
	{
		get { return m_MaxMemberNum;}
		set { m_MaxMemberNum = value; }
	}
	//帮会大厅等级
	public int m_HallLv;
	public int HallLv
	{
		get { return m_HallLv;}
		set { m_HallLv = value; }
	}
	//帮会大厅升级时间
	public int m_HallLvupTime;
	public int HallLvupTime
	{
		get { return m_HallLvupTime;}
		set { m_HallLvupTime = value; }
	}
	//帮会房屋等级
	public int m_HouseLv;
	public int HouseLv
	{
		get { return m_HouseLv;}
		set { m_HouseLv = value; }
	}
	//帮会房屋升级时间
	public int m_HouseLvupTime;
	public int HouseLvupTime
	{
		get { return m_HouseLvupTime;}
		set { m_HouseLvupTime = value; }
	}
	//帮会库房等级
	public int m_StoreroomLv;
	public int StoreroomLv
	{
		get { return m_StoreroomLv;}
		set { m_StoreroomLv = value; }
	}
	//帮会库房升级时间
	public int m_StoreroomLvupTime;
	public int StoreroomLvupTime
	{
		get { return m_StoreroomLvupTime;}
		set { m_StoreroomLvupTime = value; }
	}
	//练武堂等级
	public int m_KongfuHallLv;
	public int KongfuHallLv
	{
		get { return m_KongfuHallLv;}
		set { m_KongfuHallLv = value; }
	}
	//练武堂升级时间
	public int m_KongfuHallLvupTime;
	public int KongfuHallLvupTime
	{
		get { return m_KongfuHallLvupTime;}
		set { m_KongfuHallLvupTime = value; }
	}
	//创建时间
	public int m_CreateTime;
	public int CreateTime
	{
		get { return m_CreateTime;}
		set { m_CreateTime = value; }
	}
	//帮会事件
	public List<GuildEventObjWraper> m_EventList;
	public int SizeEventList()
	{
		return m_EventList.Count;
	}
	public List<GuildEventObjWraper> GetEventList()
	{
		return m_EventList;
	}
	public GuildEventObjWraper GetEventList(int Index)
	{
		if(Index<0 || Index>=(int)m_EventList.Count)
			return new GuildEventObjWraper();
		return m_EventList[Index];
	}
	public void SetEventList( List<GuildEventObjWraper> v )
	{
		m_EventList=v;
	}
	public void SetEventList( int Index, GuildEventObjWraper v )
	{
		if(Index<0 || Index>=(int)m_EventList.Count)
			return;
		m_EventList[Index] = v;
	}
	public void AddEventList( GuildEventObjWraper v )
	{
		m_EventList.Add(v);
	}
	public void ClearEventList( )
	{
		m_EventList.Clear();
	}
	//帮会副本列表
	public List<GuildDungeonObjWraper> m_GuildDungeonList;
	public int SizeGuildDungeonList()
	{
		return m_GuildDungeonList.Count;
	}
	public List<GuildDungeonObjWraper> GetGuildDungeonList()
	{
		return m_GuildDungeonList;
	}
	public GuildDungeonObjWraper GetGuildDungeonList(int Index)
	{
		if(Index<0 || Index>=(int)m_GuildDungeonList.Count)
			return new GuildDungeonObjWraper();
		return m_GuildDungeonList[Index];
	}
	public void SetGuildDungeonList( List<GuildDungeonObjWraper> v )
	{
		m_GuildDungeonList=v;
	}
	public void SetGuildDungeonList( int Index, GuildDungeonObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GuildDungeonList.Count)
			return;
		m_GuildDungeonList[Index] = v;
	}
	public void AddGuildDungeonList( GuildDungeonObjWraper v )
	{
		m_GuildDungeonList.Add(v);
	}
	public void ClearGuildDungeonList( )
	{
		m_GuildDungeonList.Clear();
	}
	//帮会战
	public GuildWarObjWraper m_GuildWar;
	public GuildWarObjWraper GuildWar
	{
		get { return m_GuildWar;}
		set { m_GuildWar = value; }
	}
	//开启修炼个数
	public List<int> m_GuildOpenScience;
	public int SizeGuildOpenScience()
	{
		return m_GuildOpenScience.Count;
	}
	public List<int> GetGuildOpenScience()
	{
		return m_GuildOpenScience;
	}
	public int GetGuildOpenScience(int Index)
	{
		if(Index<0 || Index>=(int)m_GuildOpenScience.Count)
			return -1;
		return m_GuildOpenScience[Index];
	}
	public void SetGuildOpenScience( List<int> v )
	{
		m_GuildOpenScience=v;
	}
	public void SetGuildOpenScience( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_GuildOpenScience.Count)
			return;
		m_GuildOpenScience[Index] = v;
	}
	public void AddGuildOpenScience( int v=-1 )
	{
		m_GuildOpenScience.Add(v);
	}
	public void ClearGuildOpenScience( )
	{
		m_GuildOpenScience.Clear();
	}


};
//申请列表数据封装类
[System.Serializable]
public class ApplyListRoleInfoObjWraper
{

	//构造函数
	public ApplyListRoleInfoObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = 1;
		 m_Prof = 0;
		 m_TalentLevel = 0;
		 m_Xiulian = 0;
		 m_Military = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = 1;
		 m_Prof = 0;
		 m_TalentLevel = 0;
		 m_Xiulian = 0;
		 m_Military = 0;

	}

 	//转化成Protobuffer类型函数
	public ApplyListRoleInfoObj ToPB()
	{
		ApplyListRoleInfoObj v = new ApplyListRoleInfoObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Prof = m_Prof;
		v.TalentLevel = m_TalentLevel;
		v.Xiulian = m_Xiulian;
		v.Military = m_Military;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ApplyListRoleInfoObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Prof = v.Prof;
		m_TalentLevel = v.TalentLevel;
		m_Xiulian = v.Xiulian;
		m_Military = v.Military;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ApplyListRoleInfoObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ApplyListRoleInfoObj pb = ProtoBuf.Serializer.Deserialize<ApplyListRoleInfoObj>(protoMS);
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
	//名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//等级
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
	//修为等级
	public int m_TalentLevel;
	public int TalentLevel
	{
		get { return m_TalentLevel;}
		set { m_TalentLevel = value; }
	}
	//修炼
	public int m_Xiulian;
	public int Xiulian
	{
		get { return m_Xiulian;}
		set { m_Xiulian = value; }
	}
	//战力
	public int m_Military;
	public int Military
	{
		get { return m_Military;}
		set { m_Military = value; }
	}


};
//帮会列表封装类
[System.Serializable]
public class GuildListObjWraper
{

	//构造函数
	public GuildListObjWraper()
	{
		 m_Guild = -1;
		 m_GuildName = "";
		 m_Level = 1;
		 m_CurMemberNum = 1;
		 m_TotalMilitary = 0;
		 m_Announcement = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Guild = -1;
		 m_GuildName = "";
		 m_Level = 1;
		 m_CurMemberNum = 1;
		 m_TotalMilitary = 0;
		 m_Announcement = "";

	}

 	//转化成Protobuffer类型函数
	public GuildListObj ToPB()
	{
		GuildListObj v = new GuildListObj();
		v.Guild = m_Guild;
		v.GuildName = m_GuildName;
		v.Level = m_Level;
		v.CurMemberNum = m_CurMemberNum;
		v.TotalMilitary = m_TotalMilitary;
		v.Announcement = m_Announcement;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildListObj v)
	{
        if (v == null)
            return;
		m_Guild = v.Guild;
		m_GuildName = v.GuildName;
		m_Level = v.Level;
		m_CurMemberNum = v.CurMemberNum;
		m_TotalMilitary = v.TotalMilitary;
		m_Announcement = v.Announcement;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildListObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildListObj pb = ProtoBuf.Serializer.Deserialize<GuildListObj>(protoMS);
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
	//当前成员数量
	public int m_CurMemberNum;
	public int CurMemberNum
	{
		get { return m_CurMemberNum;}
		set { m_CurMemberNum = value; }
	}
	//总战力
	public int m_TotalMilitary;
	public int TotalMilitary
	{
		get { return m_TotalMilitary;}
		set { m_TotalMilitary = value; }
	}
	//公告
	public string m_Announcement;
	public string Announcement
	{
		get { return m_Announcement;}
		set { m_Announcement = value; }
	}


};
//英雄战斗信息封装类
[System.Serializable]
public class HeroFightInfoWraper
{

	//构造函数
	public HeroFightInfoWraper()
	{
		 m_UserId = -1;
		 m_ObjId = -1;
		 m_Name = "";
		 m_DeadTimes = 0;
		 m_KilledNum = 0;
		 m_TotalDamage = -1;
		 m_TotalEndure = -1;
		m_IntParaArr = new List<int>();
		 m_Level = -1;
		 m_AssistKilled = -1;
		 m_CmapId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_ObjId = -1;
		 m_Name = "";
		 m_DeadTimes = 0;
		 m_KilledNum = 0;
		 m_TotalDamage = -1;
		 m_TotalEndure = -1;
		m_IntParaArr = new List<int>();
		 m_Level = -1;
		 m_AssistKilled = -1;
		 m_CmapId = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroFightInfo ToPB()
	{
		HeroFightInfo v = new HeroFightInfo();
		v.UserId = m_UserId;
		v.ObjId = m_ObjId;
		v.Name = m_Name;
		v.DeadTimes = m_DeadTimes;
		v.KilledNum = m_KilledNum;
		v.TotalDamage = m_TotalDamage;
		v.TotalEndure = m_TotalEndure;
		for (int i=0; i<(int)m_IntParaArr.Count; i++)
			v.IntParaArr.Add( m_IntParaArr[i]);
		v.Level = m_Level;
		v.AssistKilled = m_AssistKilled;
		v.CmapId = m_CmapId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroFightInfo v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_ObjId = v.ObjId;
		m_Name = v.Name;
		m_DeadTimes = v.DeadTimes;
		m_KilledNum = v.KilledNum;
		m_TotalDamage = v.TotalDamage;
		m_TotalEndure = v.TotalEndure;
		m_IntParaArr.Clear();
		for( int i=0; i<v.IntParaArr.Count; i++)
			m_IntParaArr.Add(v.IntParaArr[i]);
		m_Level = v.Level;
		m_AssistKilled = v.AssistKilled;
		m_CmapId = v.CmapId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroFightInfo>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroFightInfo pb = ProtoBuf.Serializer.Deserialize<HeroFightInfo>(protoMS);
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
	//对像ID
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}
	//名字
	public string m_Name;
	public string Name
	{
		get { return m_Name;}
		set { m_Name = value; }
	}
	//死亡次数
	public int m_DeadTimes;
	public int DeadTimes
	{
		get { return m_DeadTimes;}
		set { m_DeadTimes = value; }
	}
	//杀人数
	public int m_KilledNum;
	public int KilledNum
	{
		get { return m_KilledNum;}
		set { m_KilledNum = value; }
	}
	//总输出伤害
	public long m_TotalDamage;
	public long TotalDamage
	{
		get { return m_TotalDamage;}
		set { m_TotalDamage = value; }
	}
	//承受伤害
	public int m_TotalEndure;
	public int TotalEndure
	{
		get { return m_TotalEndure;}
		set { m_TotalEndure = value; }
	}
	//保留参数
	public List<int> m_IntParaArr;
	public int SizeIntParaArr()
	{
		return m_IntParaArr.Count;
	}
	public List<int> GetIntParaArr()
	{
		return m_IntParaArr;
	}
	public int GetIntParaArr(int Index)
	{
		if(Index<0 || Index>=(int)m_IntParaArr.Count)
			return -1;
		return m_IntParaArr[Index];
	}
	public void SetIntParaArr( List<int> v )
	{
		m_IntParaArr=v;
	}
	public void SetIntParaArr( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_IntParaArr.Count)
			return;
		m_IntParaArr[Index] = v;
	}
	public void AddIntParaArr( int v=-1 )
	{
		m_IntParaArr.Add(v);
	}
	public void ClearIntParaArr( )
	{
		m_IntParaArr.Clear();
	}
	//等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//助攻数
	public int m_AssistKilled;
	public int AssistKilled
	{
		get { return m_AssistKilled;}
		set { m_AssistKilled = value; }
	}
	//阵营ID
	public int m_CmapId;
	public int CmapId
	{
		get { return m_CmapId;}
		set { m_CmapId = value; }
	}


};
//帮会事件对象封装类
[System.Serializable]
public class GuildEventObjWraper
{

	//构造函数
	public GuildEventObjWraper()
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
	public GuildEventObj ToPB()
	{
		GuildEventObj v = new GuildEventObj();
		v.EventId = m_EventId;
		v.Param1 = m_Param1;
		v.Param2 = m_Param2;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildEventObj v)
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
		ProtoBuf.Serializer.Serialize<GuildEventObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildEventObj pb = ProtoBuf.Serializer.Deserialize<GuildEventObj>(protoMS);
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
//帮会副本对象封装类
[System.Serializable]
public class GuildDungeonObjWraper
{

	//构造函数
	public GuildDungeonObjWraper()
	{
		 m_DungeonId = -1;
		 m_Key = "";
		 m_Post = -1;
		 m_Host = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;
		 m_Key = "";
		 m_Post = -1;
		 m_Host = "";

	}

 	//转化成Protobuffer类型函数
	public GuildDungeonObj ToPB()
	{
		GuildDungeonObj v = new GuildDungeonObj();
		v.DungeonId = m_DungeonId;
		v.Key = m_Key;
		v.Post = m_Post;
		v.Host = m_Host;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildDungeonObj v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;
		m_Key = v.Key;
		m_Post = v.Post;
		m_Host = v.Host;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildDungeonObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildDungeonObj pb = ProtoBuf.Serializer.Deserialize<GuildDungeonObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本Id
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//Key
	public string m_Key;
	public string Key
	{
		get { return m_Key;}
		set { m_Key = value; }
	}
	//Post
	public int m_Post;
	public int Post
	{
		get { return m_Post;}
		set { m_Post = value; }
	}
	//Host
	public string m_Host;
	public string Host
	{
		get { return m_Host;}
		set { m_Host = value; }
	}


};
//帮会战对象封装类
[System.Serializable]
public class GuildWarObjWraper
{

	//构造函数
	public GuildWarObjWraper()
	{
		 m_Guild_A = -1;
		 m_Guild_B = -1;
		 m_DungeonId = -1;
		 m_Key = "";
		 m_Port = -1;
		 m_Host = "";

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Guild_A = -1;
		 m_Guild_B = -1;
		 m_DungeonId = -1;
		 m_Key = "";
		 m_Port = -1;
		 m_Host = "";

	}

 	//转化成Protobuffer类型函数
	public GuildWarObj ToPB()
	{
		GuildWarObj v = new GuildWarObj();
		v.Guild_A = m_Guild_A;
		v.Guild_B = m_Guild_B;
		v.DungeonId = m_DungeonId;
		v.Key = m_Key;
		v.Port = m_Port;
		v.Host = m_Host;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GuildWarObj v)
	{
        if (v == null)
            return;
		m_Guild_A = v.Guild_A;
		m_Guild_B = v.Guild_B;
		m_DungeonId = v.DungeonId;
		m_Key = v.Key;
		m_Port = v.Port;
		m_Host = v.Host;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GuildWarObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GuildWarObj pb = ProtoBuf.Serializer.Deserialize<GuildWarObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//A帮派Id
	public int m_Guild_A;
	public int Guild_A
	{
		get { return m_Guild_A;}
		set { m_Guild_A = value; }
	}
	//B帮派Id
	public int m_Guild_B;
	public int Guild_B
	{
		get { return m_Guild_B;}
		set { m_Guild_B = value; }
	}
	//副本Id
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//Key
	public string m_Key;
	public string Key
	{
		get { return m_Key;}
		set { m_Key = value; }
	}
	//Port
	public int m_Port;
	public int Port
	{
		get { return m_Port;}
		set { m_Port = value; }
	}
	//Host
	public string m_Host;
	public string Host
	{
		get { return m_Host;}
		set { m_Host = value; }
	}


};
//背包格子对象封装类
[System.Serializable]
public class BagGridObjWraper
{

	//构造函数
	public BagGridObjWraper()
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
	public BagGridObj ToPB()
	{
		BagGridObj v = new BagGridObj();
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
	public void FromPB(BagGridObj v)
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
		ProtoBuf.Serializer.Serialize<BagGridObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagGridObj pb = ProtoBuf.Serializer.Deserialize<BagGridObj>(protoMS);
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
	//ItemId，唯一id
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
//掉落物品对象封装类
[System.Serializable]
public class DropItemObjWraper
{

	//构造函数
	public DropItemObjWraper()
	{
		 m_ConfigId = -1;
		 m_UId = -1;
		 m_Num = 0;
		 m_ItemType = -1;
		 m_AttrNum = 0;
		 m_MonsterObjId = -1;
		 m_PosInfo = new byte[0];
		 m_CreateTime = 0;
		 m_IsPickup = false;
		 m_ItemId = -1;
		 m_DestroyTime = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ConfigId = -1;
		 m_UId = -1;
		 m_Num = 0;
		 m_ItemType = -1;
		 m_AttrNum = 0;
		 m_MonsterObjId = -1;
		 m_PosInfo = new byte[0];
		 m_CreateTime = 0;
		 m_IsPickup = false;
		 m_ItemId = -1;
		 m_DestroyTime = 0;

	}

 	//转化成Protobuffer类型函数
	public DropItemObj ToPB()
	{
		DropItemObj v = new DropItemObj();
		v.ConfigId = m_ConfigId;
		v.UId = m_UId;
		v.Num = m_Num;
		v.ItemType = m_ItemType;
		v.AttrNum = m_AttrNum;
		v.MonsterObjId = m_MonsterObjId;
		v.PosInfo = m_PosInfo;
		v.CreateTime = m_CreateTime;
		v.IsPickup = m_IsPickup;
		v.ItemId = m_ItemId;
		v.DestroyTime = m_DestroyTime;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(DropItemObj v)
	{
        if (v == null)
            return;
		m_ConfigId = v.ConfigId;
		m_UId = v.UId;
		m_Num = v.Num;
		m_ItemType = v.ItemType;
		m_AttrNum = v.AttrNum;
		m_MonsterObjId = v.MonsterObjId;
		m_PosInfo = v.PosInfo;
		m_CreateTime = v.CreateTime;
		m_IsPickup = v.IsPickup;
		m_ItemId = v.ItemId;
		m_DestroyTime = v.DestroyTime;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<DropItemObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		DropItemObj pb = ProtoBuf.Serializer.Deserialize<DropItemObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品的配置Id
	public int m_ConfigId;
	public int ConfigId
	{
		get { return m_ConfigId;}
		set { m_ConfigId = value; }
	}
	//下标
	public int m_UId;
	public int UId
	{
		get { return m_UId;}
		set { m_UId = value; }
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
	//属性数量
	public int m_AttrNum;
	public int AttrNum
	{
		get { return m_AttrNum;}
		set { m_AttrNum = value; }
	}
	//怪物ObjId
	public int m_MonsterObjId;
	public int MonsterObjId
	{
		get { return m_MonsterObjId;}
		set { m_MonsterObjId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//创建时间
	public int m_CreateTime;
	public int CreateTime
	{
		get { return m_CreateTime;}
		set { m_CreateTime = value; }
	}
	//是否已经拾取
	public bool m_IsPickup;
	public bool IsPickup
	{
		get { return m_IsPickup;}
		set { m_IsPickup = value; }
	}
	//物品唯一Id
	public long m_ItemId;
	public long ItemId
	{
		get { return m_ItemId;}
		set { m_ItemId = value; }
	}
	//销毁时间
	public int m_DestroyTime;
	public int DestroyTime
	{
		get { return m_DestroyTime;}
		set { m_DestroyTime = value; }
	}


};
//背包装备对象封装类
[System.Serializable]
public class BagEquipObjWraper
{

	//构造函数
	public BagEquipObjWraper()
	{
		 m_ItemID = -1;
		m_BaseAttr = new List<BagAttrIntObjWraper>();
		m_ExtraAttr = new List<BagExtraAttrObjWraper>();
		m_EnhanceLv = new List<int>();
		m_EquipPolishedResult = new List<BagExtraAttrObjWraper>();
		 m_PolishedScore = 0;
		 m_Index = -1;
		m_InitBaseAttr = new List<BagAttrIntObjWraper>();
		 m_BagContainerType = -1;
		 m_GridIndex = -1;
		m_PlishedAttrId = new List<BagExtraAttrIdObjWraper>();
		m_GemArray = new List<BagGemObjWraper>();
		m_PolishedBaseAttrResult = new List<BagAttrIntObjWraper>();
		 m_TemplateId = -1;
		 m_GemSuitId = -1;
		 m_EquipScore = 0;
		 m_PolishedEquipScore = 0;
		m_BaseAttrPolishedInitAttr = new List<BagAttrIntObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;
		m_BaseAttr = new List<BagAttrIntObjWraper>();
		m_ExtraAttr = new List<BagExtraAttrObjWraper>();
		m_EnhanceLv = new List<int>();
		m_EquipPolishedResult = new List<BagExtraAttrObjWraper>();
		 m_PolishedScore = 0;
		 m_Index = -1;
		m_InitBaseAttr = new List<BagAttrIntObjWraper>();
		 m_BagContainerType = -1;
		 m_GridIndex = -1;
		m_PlishedAttrId = new List<BagExtraAttrIdObjWraper>();
		m_GemArray = new List<BagGemObjWraper>();
		m_PolishedBaseAttrResult = new List<BagAttrIntObjWraper>();
		 m_TemplateId = -1;
		 m_GemSuitId = -1;
		 m_EquipScore = 0;
		 m_PolishedEquipScore = 0;
		m_BaseAttrPolishedInitAttr = new List<BagAttrIntObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public BagEquipObj ToPB()
	{
		BagEquipObj v = new BagEquipObj();
		v.ItemID = m_ItemID;
		for (int i=0; i<(int)m_BaseAttr.Count; i++)
			v.BaseAttr.Add( m_BaseAttr[i].ToPB());
		for (int i=0; i<(int)m_ExtraAttr.Count; i++)
			v.ExtraAttr.Add( m_ExtraAttr[i].ToPB());
		for (int i=0; i<(int)m_EnhanceLv.Count; i++)
			v.EnhanceLv.Add( m_EnhanceLv[i]);
		for (int i=0; i<(int)m_EquipPolishedResult.Count; i++)
			v.EquipPolishedResult.Add( m_EquipPolishedResult[i].ToPB());
		v.PolishedScore = m_PolishedScore;
		v.Index = m_Index;
		for (int i=0; i<(int)m_InitBaseAttr.Count; i++)
			v.InitBaseAttr.Add( m_InitBaseAttr[i].ToPB());
		v.BagContainerType = m_BagContainerType;
		v.GridIndex = m_GridIndex;
		for (int i=0; i<(int)m_PlishedAttrId.Count; i++)
			v.PlishedAttrId.Add( m_PlishedAttrId[i].ToPB());
		for (int i=0; i<(int)m_GemArray.Count; i++)
			v.GemArray.Add( m_GemArray[i].ToPB());
		for (int i=0; i<(int)m_PolishedBaseAttrResult.Count; i++)
			v.PolishedBaseAttrResult.Add( m_PolishedBaseAttrResult[i].ToPB());
		v.TemplateId = m_TemplateId;
		v.GemSuitId = m_GemSuitId;
		v.EquipScore = m_EquipScore;
		v.PolishedEquipScore = m_PolishedEquipScore;
		for (int i=0; i<(int)m_BaseAttrPolishedInitAttr.Count; i++)
			v.BaseAttrPolishedInitAttr.Add( m_BaseAttrPolishedInitAttr[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagEquipObj v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;
		m_BaseAttr.Clear();
		for( int i=0; i<v.BaseAttr.Count; i++)
			m_BaseAttr.Add( new BagAttrIntObjWraper());
		for( int i=0; i<v.BaseAttr.Count; i++)
			m_BaseAttr[i].FromPB(v.BaseAttr[i]);
		m_ExtraAttr.Clear();
		for( int i=0; i<v.ExtraAttr.Count; i++)
			m_ExtraAttr.Add( new BagExtraAttrObjWraper());
		for( int i=0; i<v.ExtraAttr.Count; i++)
			m_ExtraAttr[i].FromPB(v.ExtraAttr[i]);
		m_EnhanceLv.Clear();
		for( int i=0; i<v.EnhanceLv.Count; i++)
			m_EnhanceLv.Add(v.EnhanceLv[i]);
		m_EquipPolishedResult.Clear();
		for( int i=0; i<v.EquipPolishedResult.Count; i++)
			m_EquipPolishedResult.Add( new BagExtraAttrObjWraper());
		for( int i=0; i<v.EquipPolishedResult.Count; i++)
			m_EquipPolishedResult[i].FromPB(v.EquipPolishedResult[i]);
		m_PolishedScore = v.PolishedScore;
		m_Index = v.Index;
		m_InitBaseAttr.Clear();
		for( int i=0; i<v.InitBaseAttr.Count; i++)
			m_InitBaseAttr.Add( new BagAttrIntObjWraper());
		for( int i=0; i<v.InitBaseAttr.Count; i++)
			m_InitBaseAttr[i].FromPB(v.InitBaseAttr[i]);
		m_BagContainerType = v.BagContainerType;
		m_GridIndex = v.GridIndex;
		m_PlishedAttrId.Clear();
		for( int i=0; i<v.PlishedAttrId.Count; i++)
			m_PlishedAttrId.Add( new BagExtraAttrIdObjWraper());
		for( int i=0; i<v.PlishedAttrId.Count; i++)
			m_PlishedAttrId[i].FromPB(v.PlishedAttrId[i]);
		m_GemArray.Clear();
		for( int i=0; i<v.GemArray.Count; i++)
			m_GemArray.Add( new BagGemObjWraper());
		for( int i=0; i<v.GemArray.Count; i++)
			m_GemArray[i].FromPB(v.GemArray[i]);
		m_PolishedBaseAttrResult.Clear();
		for( int i=0; i<v.PolishedBaseAttrResult.Count; i++)
			m_PolishedBaseAttrResult.Add( new BagAttrIntObjWraper());
		for( int i=0; i<v.PolishedBaseAttrResult.Count; i++)
			m_PolishedBaseAttrResult[i].FromPB(v.PolishedBaseAttrResult[i]);
		m_TemplateId = v.TemplateId;
		m_GemSuitId = v.GemSuitId;
		m_EquipScore = v.EquipScore;
		m_PolishedEquipScore = v.PolishedEquipScore;
		m_BaseAttrPolishedInitAttr.Clear();
		for( int i=0; i<v.BaseAttrPolishedInitAttr.Count; i++)
			m_BaseAttrPolishedInitAttr.Add( new BagAttrIntObjWraper());
		for( int i=0; i<v.BaseAttrPolishedInitAttr.Count; i++)
			m_BaseAttrPolishedInitAttr[i].FromPB(v.BaseAttrPolishedInitAttr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagEquipObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagEquipObj pb = ProtoBuf.Serializer.Deserialize<BagEquipObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品实例id, 唯一id
	public long m_ItemID;
	public long ItemID
	{
		get { return m_ItemID;}
		set { m_ItemID = value; }
	}
	//基础属性值(包括附加的加成)
	public List<BagAttrIntObjWraper> m_BaseAttr;
	public int SizeBaseAttr()
	{
		return m_BaseAttr.Count;
	}
	public List<BagAttrIntObjWraper> GetBaseAttr()
	{
		return m_BaseAttr;
	}
	public BagAttrIntObjWraper GetBaseAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_BaseAttr.Count)
			return new BagAttrIntObjWraper();
		return m_BaseAttr[Index];
	}
	public void SetBaseAttr( List<BagAttrIntObjWraper> v )
	{
		m_BaseAttr=v;
	}
	public void SetBaseAttr( int Index, BagAttrIntObjWraper v )
	{
		if(Index<0 || Index>=(int)m_BaseAttr.Count)
			return;
		m_BaseAttr[Index] = v;
	}
	public void AddBaseAttr( BagAttrIntObjWraper v )
	{
		m_BaseAttr.Add(v);
	}
	public void ClearBaseAttr( )
	{
		m_BaseAttr.Clear();
	}
	//额外属性
	public List<BagExtraAttrObjWraper> m_ExtraAttr;
	public int SizeExtraAttr()
	{
		return m_ExtraAttr.Count;
	}
	public List<BagExtraAttrObjWraper> GetExtraAttr()
	{
		return m_ExtraAttr;
	}
	public BagExtraAttrObjWraper GetExtraAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_ExtraAttr.Count)
			return new BagExtraAttrObjWraper();
		return m_ExtraAttr[Index];
	}
	public void SetExtraAttr( List<BagExtraAttrObjWraper> v )
	{
		m_ExtraAttr=v;
	}
	public void SetExtraAttr( int Index, BagExtraAttrObjWraper v )
	{
		if(Index<0 || Index>=(int)m_ExtraAttr.Count)
			return;
		m_ExtraAttr[Index] = v;
	}
	public void AddExtraAttr( BagExtraAttrObjWraper v )
	{
		m_ExtraAttr.Add(v);
	}
	public void ClearExtraAttr( )
	{
		m_ExtraAttr.Clear();
	}
	//强化等级
	public List<int> m_EnhanceLv;
	public int SizeEnhanceLv()
	{
		return m_EnhanceLv.Count;
	}
	public List<int> GetEnhanceLv()
	{
		return m_EnhanceLv;
	}
	public int GetEnhanceLv(int Index)
	{
		if(Index<0 || Index>=(int)m_EnhanceLv.Count)
			return -1;
		return m_EnhanceLv[Index];
	}
	public void SetEnhanceLv( List<int> v )
	{
		m_EnhanceLv=v;
	}
	public void SetEnhanceLv( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_EnhanceLv.Count)
			return;
		m_EnhanceLv[Index] = v;
	}
	public void AddEnhanceLv( int v=-1 )
	{
		m_EnhanceLv.Add(v);
	}
	public void ClearEnhanceLv( )
	{
		m_EnhanceLv.Clear();
	}
	//装备洗炼结果
	public List<BagExtraAttrObjWraper> m_EquipPolishedResult;
	public int SizeEquipPolishedResult()
	{
		return m_EquipPolishedResult.Count;
	}
	public List<BagExtraAttrObjWraper> GetEquipPolishedResult()
	{
		return m_EquipPolishedResult;
	}
	public BagExtraAttrObjWraper GetEquipPolishedResult(int Index)
	{
		if(Index<0 || Index>=(int)m_EquipPolishedResult.Count)
			return new BagExtraAttrObjWraper();
		return m_EquipPolishedResult[Index];
	}
	public void SetEquipPolishedResult( List<BagExtraAttrObjWraper> v )
	{
		m_EquipPolishedResult=v;
	}
	public void SetEquipPolishedResult( int Index, BagExtraAttrObjWraper v )
	{
		if(Index<0 || Index>=(int)m_EquipPolishedResult.Count)
			return;
		m_EquipPolishedResult[Index] = v;
	}
	public void AddEquipPolishedResult( BagExtraAttrObjWraper v )
	{
		m_EquipPolishedResult.Add(v);
	}
	public void ClearEquipPolishedResult( )
	{
		m_EquipPolishedResult.Clear();
	}
	//洗炼积分
	public int m_PolishedScore;
	public int PolishedScore
	{
		get { return m_PolishedScore;}
		set { m_PolishedScore = value; }
	}
	//用于索引道具具体数据
	public long m_Index;
	public long Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}
	//初始基础属性
	public List<BagAttrIntObjWraper> m_InitBaseAttr;
	public int SizeInitBaseAttr()
	{
		return m_InitBaseAttr.Count;
	}
	public List<BagAttrIntObjWraper> GetInitBaseAttr()
	{
		return m_InitBaseAttr;
	}
	public BagAttrIntObjWraper GetInitBaseAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_InitBaseAttr.Count)
			return new BagAttrIntObjWraper();
		return m_InitBaseAttr[Index];
	}
	public void SetInitBaseAttr( List<BagAttrIntObjWraper> v )
	{
		m_InitBaseAttr=v;
	}
	public void SetInitBaseAttr( int Index, BagAttrIntObjWraper v )
	{
		if(Index<0 || Index>=(int)m_InitBaseAttr.Count)
			return;
		m_InitBaseAttr[Index] = v;
	}
	public void AddInitBaseAttr( BagAttrIntObjWraper v )
	{
		m_InitBaseAttr.Add(v);
	}
	public void ClearInitBaseAttr( )
	{
		m_InitBaseAttr.Clear();
	}
	//物品容器类型
	public int m_BagContainerType;
	public int BagContainerType
	{
		get { return m_BagContainerType;}
		set { m_BagContainerType = value; }
	}
	//装备格子的索引
	public int m_GridIndex;
	public int GridIndex
	{
		get { return m_GridIndex;}
		set { m_GridIndex = value; }
	}
	//洗炼属性id
	public List<BagExtraAttrIdObjWraper> m_PlishedAttrId;
	public int SizePlishedAttrId()
	{
		return m_PlishedAttrId.Count;
	}
	public List<BagExtraAttrIdObjWraper> GetPlishedAttrId()
	{
		return m_PlishedAttrId;
	}
	public BagExtraAttrIdObjWraper GetPlishedAttrId(int Index)
	{
		if(Index<0 || Index>=(int)m_PlishedAttrId.Count)
			return new BagExtraAttrIdObjWraper();
		return m_PlishedAttrId[Index];
	}
	public void SetPlishedAttrId( List<BagExtraAttrIdObjWraper> v )
	{
		m_PlishedAttrId=v;
	}
	public void SetPlishedAttrId( int Index, BagExtraAttrIdObjWraper v )
	{
		if(Index<0 || Index>=(int)m_PlishedAttrId.Count)
			return;
		m_PlishedAttrId[Index] = v;
	}
	public void AddPlishedAttrId( BagExtraAttrIdObjWraper v )
	{
		m_PlishedAttrId.Add(v);
	}
	public void ClearPlishedAttrId( )
	{
		m_PlishedAttrId.Clear();
	}
	//宝石数组
	public List<BagGemObjWraper> m_GemArray;
	public int SizeGemArray()
	{
		return m_GemArray.Count;
	}
	public List<BagGemObjWraper> GetGemArray()
	{
		return m_GemArray;
	}
	public BagGemObjWraper GetGemArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GemArray.Count)
			return new BagGemObjWraper();
		return m_GemArray[Index];
	}
	public void SetGemArray( List<BagGemObjWraper> v )
	{
		m_GemArray=v;
	}
	public void SetGemArray( int Index, BagGemObjWraper v )
	{
		if(Index<0 || Index>=(int)m_GemArray.Count)
			return;
		m_GemArray[Index] = v;
	}
	public void AddGemArray( BagGemObjWraper v )
	{
		m_GemArray.Add(v);
	}
	public void ClearGemArray( )
	{
		m_GemArray.Clear();
	}
	//基础属性洗炼结果
	public List<BagAttrIntObjWraper> m_PolishedBaseAttrResult;
	public int SizePolishedBaseAttrResult()
	{
		return m_PolishedBaseAttrResult.Count;
	}
	public List<BagAttrIntObjWraper> GetPolishedBaseAttrResult()
	{
		return m_PolishedBaseAttrResult;
	}
	public BagAttrIntObjWraper GetPolishedBaseAttrResult(int Index)
	{
		if(Index<0 || Index>=(int)m_PolishedBaseAttrResult.Count)
			return new BagAttrIntObjWraper();
		return m_PolishedBaseAttrResult[Index];
	}
	public void SetPolishedBaseAttrResult( List<BagAttrIntObjWraper> v )
	{
		m_PolishedBaseAttrResult=v;
	}
	public void SetPolishedBaseAttrResult( int Index, BagAttrIntObjWraper v )
	{
		if(Index<0 || Index>=(int)m_PolishedBaseAttrResult.Count)
			return;
		m_PolishedBaseAttrResult[Index] = v;
	}
	public void AddPolishedBaseAttrResult( BagAttrIntObjWraper v )
	{
		m_PolishedBaseAttrResult.Add(v);
	}
	public void ClearPolishedBaseAttrResult( )
	{
		m_PolishedBaseAttrResult.Clear();
	}
	//模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//宝石组合id
	public int m_GemSuitId;
	public int GemSuitId
	{
		get { return m_GemSuitId;}
		set { m_GemSuitId = value; }
	}
	//装备评分
	public int m_EquipScore;
	public int EquipScore
	{
		get { return m_EquipScore;}
		set { m_EquipScore = value; }
	}
	//洗炼装备评分
	public int m_PolishedEquipScore;
	public int PolishedEquipScore
	{
		get { return m_PolishedEquipScore;}
		set { m_PolishedEquipScore = value; }
	}
	//基础属性洗炼初始属性
	public List<BagAttrIntObjWraper> m_BaseAttrPolishedInitAttr;
	public int SizeBaseAttrPolishedInitAttr()
	{
		return m_BaseAttrPolishedInitAttr.Count;
	}
	public List<BagAttrIntObjWraper> GetBaseAttrPolishedInitAttr()
	{
		return m_BaseAttrPolishedInitAttr;
	}
	public BagAttrIntObjWraper GetBaseAttrPolishedInitAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_BaseAttrPolishedInitAttr.Count)
			return new BagAttrIntObjWraper();
		return m_BaseAttrPolishedInitAttr[Index];
	}
	public void SetBaseAttrPolishedInitAttr( List<BagAttrIntObjWraper> v )
	{
		m_BaseAttrPolishedInitAttr=v;
	}
	public void SetBaseAttrPolishedInitAttr( int Index, BagAttrIntObjWraper v )
	{
		if(Index<0 || Index>=(int)m_BaseAttrPolishedInitAttr.Count)
			return;
		m_BaseAttrPolishedInitAttr[Index] = v;
	}
	public void AddBaseAttrPolishedInitAttr( BagAttrIntObjWraper v )
	{
		m_BaseAttrPolishedInitAttr.Add(v);
	}
	public void ClearBaseAttrPolishedInitAttr( )
	{
		m_BaseAttrPolishedInitAttr.Clear();
	}


};
//装备属性封装类
[System.Serializable]
public class BagAttrIntObjWraper
{

	//构造函数
	public BagAttrIntObjWraper()
	{
		 m_AttrId = -1;
		 m_AttrValue = -1;
		 m_MaxAttrValue = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_AttrId = -1;
		 m_AttrValue = -1;
		 m_MaxAttrValue = -1;

	}

 	//转化成Protobuffer类型函数
	public BagAttrIntObj ToPB()
	{
		BagAttrIntObj v = new BagAttrIntObj();
		v.AttrId = m_AttrId;
		v.AttrValue = m_AttrValue;
		v.MaxAttrValue = m_MaxAttrValue;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagAttrIntObj v)
	{
        if (v == null)
            return;
		m_AttrId = v.AttrId;
		m_AttrValue = v.AttrValue;
		m_MaxAttrValue = v.MaxAttrValue;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagAttrIntObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagAttrIntObj pb = ProtoBuf.Serializer.Deserialize<BagAttrIntObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//属性Id
	public int m_AttrId;
	public int AttrId
	{
		get { return m_AttrId;}
		set { m_AttrId = value; }
	}
	//属性值
	public int m_AttrValue;
	public int AttrValue
	{
		get { return m_AttrValue;}
		set { m_AttrValue = value; }
	}
	//最大属性值
	public int m_MaxAttrValue;
	public int MaxAttrValue
	{
		get { return m_MaxAttrValue;}
		set { m_MaxAttrValue = value; }
	}


};
//装备属性对象封装类
[System.Serializable]
public class BagAttrFloatObjWraper
{

	//构造函数
	public BagAttrFloatObjWraper()
	{
		 m_AttrId = -1;
		 m_AttrValue = (float)-1;
		 m_Index = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_AttrId = -1;
		 m_AttrValue = (float)-1;
		 m_Index = -1;

	}

 	//转化成Protobuffer类型函数
	public BagAttrFloatObj ToPB()
	{
		BagAttrFloatObj v = new BagAttrFloatObj();
		v.AttrId = m_AttrId;
		v.AttrValue = m_AttrValue;
		v.Index = m_Index;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagAttrFloatObj v)
	{
        if (v == null)
            return;
		m_AttrId = v.AttrId;
		m_AttrValue = v.AttrValue;
		m_Index = v.Index;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagAttrFloatObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagAttrFloatObj pb = ProtoBuf.Serializer.Deserialize<BagAttrFloatObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//属性Id
	public int m_AttrId;
	public int AttrId
	{
		get { return m_AttrId;}
		set { m_AttrId = value; }
	}
	//属性值
	public float m_AttrValue;
	public float AttrValue
	{
		get { return m_AttrValue;}
		set { m_AttrValue = value; }
	}
	//索引
	public int m_Index;
	public int Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}


};
//装备宝石对象封装类
[System.Serializable]
public class BagGemObjWraper
{

	//构造函数
	public BagGemObjWraper()
	{
		 m_GemId = -1;
		 m_Pos = -1;
		 m_IsLock = false;
		 m_Level = -1;
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GemId = -1;
		 m_Pos = -1;
		 m_IsLock = false;
		 m_Level = -1;
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public BagGemObj ToPB()
	{
		BagGemObj v = new BagGemObj();
		v.GemId = m_GemId;
		v.Pos = m_Pos;
		v.IsLock = m_IsLock;
		v.Level = m_Level;
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagGemObj v)
	{
        if (v == null)
            return;
		m_GemId = v.GemId;
		m_Pos = v.Pos;
		m_IsLock = v.IsLock;
		m_Level = v.Level;
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagGemObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagGemObj pb = ProtoBuf.Serializer.Deserialize<BagGemObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//宝石id
	public int m_GemId;
	public int GemId
	{
		get { return m_GemId;}
		set { m_GemId = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}
	//锁着， 未打孔
	public bool m_IsLock;
	public bool IsLock
	{
		get { return m_IsLock;}
		set { m_IsLock = value; }
	}
	//宝石等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//配置的type
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//键值对封装类
[System.Serializable]
public class KeyValue2IntIntWraper
{

	//构造函数
	public KeyValue2IntIntWraper()
	{
		 m_Key = -1;
		 m_Value = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Key = -1;
		 m_Value = -1;

	}

 	//转化成Protobuffer类型函数
	public KeyValue2IntInt ToPB()
	{
		KeyValue2IntInt v = new KeyValue2IntInt();
		v.Key = m_Key;
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(KeyValue2IntInt v)
	{
        if (v == null)
            return;
		m_Key = v.Key;
		m_Value = v.Value;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<KeyValue2IntInt>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		KeyValue2IntInt pb = ProtoBuf.Serializer.Deserialize<KeyValue2IntInt>(protoMS);
		FromPB(pb);
		return true;
	}

	//键
	public int m_Key;
	public int Key
	{
		get { return m_Key;}
		set { m_Key = value; }
	}
	//值
	public int m_Value;
	public int Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
//键值对封装类
[System.Serializable]
public class KeyValue2IntBoolWraper
{

	//构造函数
	public KeyValue2IntBoolWraper()
	{
		 m_Key = -1;
		 m_Value = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Key = -1;
		 m_Value = false;

	}

 	//转化成Protobuffer类型函数
	public KeyValue2IntBool ToPB()
	{
		KeyValue2IntBool v = new KeyValue2IntBool();
		v.Key = m_Key;
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(KeyValue2IntBool v)
	{
        if (v == null)
            return;
		m_Key = v.Key;
		m_Value = v.Value;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<KeyValue2IntBool>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		KeyValue2IntBool pb = ProtoBuf.Serializer.Deserialize<KeyValue2IntBool>(protoMS);
		FromPB(pb);
		return true;
	}

	//键
	public int m_Key;
	public int Key
	{
		get { return m_Key;}
		set { m_Key = value; }
	}
	//值
	public bool m_Value;
	public bool Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
//背包装备附加属性封装类
[System.Serializable]
public class BagExtraAttrObjWraper
{

	//构造函数
	public BagExtraAttrObjWraper()
	{
		m_ExtraAttr = new List<BagAttrFloatObjWraper>();
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_ExtraAttr = new List<BagAttrFloatObjWraper>();
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public BagExtraAttrObj ToPB()
	{
		BagExtraAttrObj v = new BagExtraAttrObj();
		for (int i=0; i<(int)m_ExtraAttr.Count; i++)
			v.ExtraAttr.Add( m_ExtraAttr[i].ToPB());
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagExtraAttrObj v)
	{
        if (v == null)
            return;
		m_ExtraAttr.Clear();
		for( int i=0; i<v.ExtraAttr.Count; i++)
			m_ExtraAttr.Add( new BagAttrFloatObjWraper());
		for( int i=0; i<v.ExtraAttr.Count; i++)
			m_ExtraAttr[i].FromPB(v.ExtraAttr[i]);
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagExtraAttrObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagExtraAttrObj pb = ProtoBuf.Serializer.Deserialize<BagExtraAttrObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//附加属性
	public List<BagAttrFloatObjWraper> m_ExtraAttr;
	public int SizeExtraAttr()
	{
		return m_ExtraAttr.Count;
	}
	public List<BagAttrFloatObjWraper> GetExtraAttr()
	{
		return m_ExtraAttr;
	}
	public BagAttrFloatObjWraper GetExtraAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_ExtraAttr.Count)
			return new BagAttrFloatObjWraper();
		return m_ExtraAttr[Index];
	}
	public void SetExtraAttr( List<BagAttrFloatObjWraper> v )
	{
		m_ExtraAttr=v;
	}
	public void SetExtraAttr( int Index, BagAttrFloatObjWraper v )
	{
		if(Index<0 || Index>=(int)m_ExtraAttr.Count)
			return;
		m_ExtraAttr[Index] = v;
	}
	public void AddExtraAttr( BagAttrFloatObjWraper v )
	{
		m_ExtraAttr.Add(v);
	}
	public void ClearExtraAttr( )
	{
		m_ExtraAttr.Clear();
	}
	//词条Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//附加属性Id封装类
[System.Serializable]
public class BagExtraAttrIdObjWraper
{

	//构造函数
	public BagExtraAttrIdObjWraper()
	{
		m_AttrId = new List<int>();
		 m_Id = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_AttrId = new List<int>();
		 m_Id = -1;

	}

 	//转化成Protobuffer类型函数
	public BagExtraAttrIdObj ToPB()
	{
		BagExtraAttrIdObj v = new BagExtraAttrIdObj();
		for (int i=0; i<(int)m_AttrId.Count; i++)
			v.AttrId.Add( m_AttrId[i]);
		v.Id = m_Id;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagExtraAttrIdObj v)
	{
        if (v == null)
            return;
		m_AttrId.Clear();
		for( int i=0; i<v.AttrId.Count; i++)
			m_AttrId.Add(v.AttrId[i]);
		m_Id = v.Id;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagExtraAttrIdObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagExtraAttrIdObj pb = ProtoBuf.Serializer.Deserialize<BagExtraAttrIdObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//属性Id
	public List<int> m_AttrId;
	public int SizeAttrId()
	{
		return m_AttrId.Count;
	}
	public List<int> GetAttrId()
	{
		return m_AttrId;
	}
	public int GetAttrId(int Index)
	{
		if(Index<0 || Index>=(int)m_AttrId.Count)
			return -1;
		return m_AttrId[Index];
	}
	public void SetAttrId( List<int> v )
	{
		m_AttrId=v;
	}
	public void SetAttrId( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_AttrId.Count)
			return;
		m_AttrId[Index] = v;
	}
	public void AddAttrId( int v=-1 )
	{
		m_AttrId.Add(v);
	}
	public void ClearAttrId( )
	{
		m_AttrId.Clear();
	}
	//词条Id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}


};
//活动NPC数据封装类
[System.Serializable]
public class ActivityNpcDataWraper
{

	//构造函数
	public ActivityNpcDataWraper()
	{
		 m_DungeonId = -1;
		 m_PosInfo = new byte[0];
		 m_NPCId = -1;
		 m_ObjId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;
		 m_PosInfo = new byte[0];
		 m_NPCId = -1;
		 m_ObjId = -1;

	}

 	//转化成Protobuffer类型函数
	public ActivityNpcData ToPB()
	{
		ActivityNpcData v = new ActivityNpcData();
		v.DungeonId = m_DungeonId;
		v.PosInfo = m_PosInfo;
		v.NPCId = m_NPCId;
		v.ObjId = m_ObjId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActivityNpcData v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;
		m_PosInfo = v.PosInfo;
		m_NPCId = v.NPCId;
		m_ObjId = v.ObjId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActivityNpcData>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActivityNpcData pb = ProtoBuf.Serializer.Deserialize<ActivityNpcData>(protoMS);
		FromPB(pb);
		return true;
	}

	//DungeonId
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//位置信息
	public byte[] m_PosInfo;
	public byte[] PosInfo
	{
		get { return m_PosInfo;}
		set { m_PosInfo = value; }
	}
	//NPCId
	public int m_NPCId;
	public int NPCId
	{
		get { return m_NPCId;}
		set { m_NPCId = value; }
	}
	//ObjId
	public int m_ObjId;
	public int ObjId
	{
		get { return m_ObjId;}
		set { m_ObjId = value; }
	}


};
//世界Boss对象封装类
[System.Serializable]
public class WorldBossObjWraper
{

	//构造函数
	public WorldBossObjWraper()
	{
		 m_DungeonId = -1;
		 m_MonsterId = -1;
		 m_CurHP = -1;
		 m_IsDead = false;
		 m_Level = 1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_DungeonId = -1;
		 m_MonsterId = -1;
		 m_CurHP = -1;
		 m_IsDead = false;
		 m_Level = 1;

	}

 	//转化成Protobuffer类型函数
	public WorldBossObj ToPB()
	{
		WorldBossObj v = new WorldBossObj();
		v.DungeonId = m_DungeonId;
		v.MonsterId = m_MonsterId;
		v.CurHP = m_CurHP;
		v.IsDead = m_IsDead;
		v.Level = m_Level;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(WorldBossObj v)
	{
        if (v == null)
            return;
		m_DungeonId = v.DungeonId;
		m_MonsterId = v.MonsterId;
		m_CurHP = v.CurHP;
		m_IsDead = v.IsDead;
		m_Level = v.Level;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<WorldBossObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		WorldBossObj pb = ProtoBuf.Serializer.Deserialize<WorldBossObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//副本Id
	public int m_DungeonId;
	public int DungeonId
	{
		get { return m_DungeonId;}
		set { m_DungeonId = value; }
	}
	//怪物配置Id
	public int m_MonsterId;
	public int MonsterId
	{
		get { return m_MonsterId;}
		set { m_MonsterId = value; }
	}
	//当前血量
	public int m_CurHP;
	public int CurHP
	{
		get { return m_CurHP;}
		set { m_CurHP = value; }
	}
	//是否死亡
	public bool m_IsDead;
	public bool IsDead
	{
		get { return m_IsDead;}
		set { m_IsDead = value; }
	}
	//Boss等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}


};
//世界Boss排行封装类
[System.Serializable]
public class WorldBossRankObjWraper
{

	//构造函数
	public WorldBossRankObjWraper()
	{
		 m_Rank = 0;
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = 0;
		 m_Hurt = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Rank = 0;
		 m_UserId = -1;
		 m_UserName = "";
		 m_Level = 0;
		 m_Hurt = 0;

	}

 	//转化成Protobuffer类型函数
	public WorldBossRankObj ToPB()
	{
		WorldBossRankObj v = new WorldBossRankObj();
		v.Rank = m_Rank;
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Level = m_Level;
		v.Hurt = m_Hurt;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(WorldBossRankObj v)
	{
        if (v == null)
            return;
		m_Rank = v.Rank;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Level = v.Level;
		m_Hurt = v.Hurt;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<WorldBossRankObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		WorldBossRankObj pb = ProtoBuf.Serializer.Deserialize<WorldBossRankObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//排名
	public int m_Rank;
	public int Rank
	{
		get { return m_Rank;}
		set { m_Rank = value; }
	}
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//玩家名字
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
	//伤害
	public int m_Hurt;
	public int Hurt
	{
		get { return m_Hurt;}
		set { m_Hurt = value; }
	}


};
//排行榜数据封装类
[System.Serializable]
public class TopPeoValueWraper
{

	//构造函数
	public TopPeoValueWraper()
	{
		 m_PlanName = "";
		 m_UserId = -1;
		 m_LV = -1;
		 m_AllRanking = -1;
		 m_MyRanking = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_PlanName = "";
		 m_UserId = -1;
		 m_LV = -1;
		 m_AllRanking = -1;
		 m_MyRanking = -1;

	}

 	//转化成Protobuffer类型函数
	public TopPeoValue ToPB()
	{
		TopPeoValue v = new TopPeoValue();
		v.PlanName = m_PlanName;
		v.UserId = m_UserId;
		v.LV = m_LV;
		v.AllRanking = m_AllRanking;
		v.MyRanking = m_MyRanking;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TopPeoValue v)
	{
        if (v == null)
            return;
		m_PlanName = v.PlanName;
		m_UserId = v.UserId;
		m_LV = v.LV;
		m_AllRanking = v.AllRanking;
		m_MyRanking = v.MyRanking;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TopPeoValue>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TopPeoValue pb = ProtoBuf.Serializer.Deserialize<TopPeoValue>(protoMS);
		FromPB(pb);
		return true;
	}

	//昵称
	public string m_PlanName;
	public string PlanName
	{
		get { return m_PlanName;}
		set { m_PlanName = value; }
	}
	//用户ID
	public long m_UserId;
	public long UserId
	{
		get { return m_UserId;}
		set { m_UserId = value; }
	}
	//等级
	public int m_LV;
	public int LV
	{
		get { return m_LV;}
		set { m_LV = value; }
	}
	//总榜的名次
	public int m_AllRanking;
	public int AllRanking
	{
		get { return m_AllRanking;}
		set { m_AllRanking = value; }
	}
	//我在这个榜的名次
	public int m_MyRanking;
	public int MyRanking
	{
		get { return m_MyRanking;}
		set { m_MyRanking = value; }
	}


};
//一对一设定数据保存封装类
[System.Serializable]
public class OneSDataWraper
{

	//构造函数
	public OneSDataWraper()
	{
		 m_Type = -1;
		 m_SkillID = -1;
		 m_SkillLv = -1;
		 m_Index = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Type = -1;
		 m_SkillID = -1;
		 m_SkillLv = -1;
		 m_Index = -1;

	}

 	//转化成Protobuffer类型函数
	public OneSData ToPB()
	{
		OneSData v = new OneSData();
		v.Type = m_Type;
		v.SkillID = m_SkillID;
		v.SkillLv = m_SkillLv;
		v.Index = m_Index;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(OneSData v)
	{
        if (v == null)
            return;
		m_Type = v.Type;
		m_SkillID = v.SkillID;
		m_SkillLv = v.SkillLv;
		m_Index = v.Index;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<OneSData>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		OneSData pb = ProtoBuf.Serializer.Deserialize<OneSData>(protoMS);
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
	//技能id
	public int m_SkillID;
	public int SkillID
	{
		get { return m_SkillID;}
		set { m_SkillID = value; }
	}
	//技能等级
	public int m_SkillLv;
	public int SkillLv
	{
		get { return m_SkillLv;}
		set { m_SkillLv = value; }
	}
	//索引
	public int m_Index;
	public int Index
	{
		get { return m_Index;}
		set { m_Index = value; }
	}


};
//攻守方消息封装类
[System.Serializable]
public class ActMessageWraper
{

	//构造函数
	public ActMessageWraper()
	{
		 m_ActUserID = -1;
		 m_DepUserID = -1;
		 m_ActIsCopy = -1;
		 m_ActPlanName = "";
		 m_DepPlanName = "";
		 m_Time = "";
		 m_ActRanking = -1;
		 m_DepRanking = -1;
		 m_WinUserID = -1;
		 m_DepIsCopy = -1;
		 m_ActJobID = -1;
		 m_DepJobID = -1;
		 m_ActChangeSource = -1;
		 m_DepChangeSource = -1;
		 m_ActChangeOver = -1;
		 m_DepChangeOver = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ActUserID = -1;
		 m_DepUserID = -1;
		 m_ActIsCopy = -1;
		 m_ActPlanName = "";
		 m_DepPlanName = "";
		 m_Time = "";
		 m_ActRanking = -1;
		 m_DepRanking = -1;
		 m_WinUserID = -1;
		 m_DepIsCopy = -1;
		 m_ActJobID = -1;
		 m_DepJobID = -1;
		 m_ActChangeSource = -1;
		 m_DepChangeSource = -1;
		 m_ActChangeOver = -1;
		 m_DepChangeOver = -1;

	}

 	//转化成Protobuffer类型函数
	public ActMessage ToPB()
	{
		ActMessage v = new ActMessage();
		v.ActUserID = m_ActUserID;
		v.DepUserID = m_DepUserID;
		v.ActIsCopy = m_ActIsCopy;
		v.ActPlanName = m_ActPlanName;
		v.DepPlanName = m_DepPlanName;
		v.Time = m_Time;
		v.ActRanking = m_ActRanking;
		v.DepRanking = m_DepRanking;
		v.WinUserID = m_WinUserID;
		v.DepIsCopy = m_DepIsCopy;
		v.ActJobID = m_ActJobID;
		v.DepJobID = m_DepJobID;
		v.ActChangeSource = m_ActChangeSource;
		v.DepChangeSource = m_DepChangeSource;
		v.ActChangeOver = m_ActChangeOver;
		v.DepChangeOver = m_DepChangeOver;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ActMessage v)
	{
        if (v == null)
            return;
		m_ActUserID = v.ActUserID;
		m_DepUserID = v.DepUserID;
		m_ActIsCopy = v.ActIsCopy;
		m_ActPlanName = v.ActPlanName;
		m_DepPlanName = v.DepPlanName;
		m_Time = v.Time;
		m_ActRanking = v.ActRanking;
		m_DepRanking = v.DepRanking;
		m_WinUserID = v.WinUserID;
		m_DepIsCopy = v.DepIsCopy;
		m_ActJobID = v.ActJobID;
		m_DepJobID = v.DepJobID;
		m_ActChangeSource = v.ActChangeSource;
		m_DepChangeSource = v.DepChangeSource;
		m_ActChangeOver = v.ActChangeOver;
		m_DepChangeOver = v.DepChangeOver;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ActMessage>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ActMessage pb = ProtoBuf.Serializer.Deserialize<ActMessage>(protoMS);
		FromPB(pb);
		return true;
	}

	//攻击方Userid
	public long m_ActUserID;
	public long ActUserID
	{
		get { return m_ActUserID;}
		set { m_ActUserID = value; }
	}
	//防守方Userid
	public long m_DepUserID;
	public long DepUserID
	{
		get { return m_DepUserID;}
		set { m_DepUserID = value; }
	}
	//是不是复制人1是
	public int m_ActIsCopy;
	public int ActIsCopy
	{
		get { return m_ActIsCopy;}
		set { m_ActIsCopy = value; }
	}
	//攻击方名字
	public string m_ActPlanName;
	public string ActPlanName
	{
		get { return m_ActPlanName;}
		set { m_ActPlanName = value; }
	}
	//防守方名字
	public string m_DepPlanName;
	public string DepPlanName
	{
		get { return m_DepPlanName;}
		set { m_DepPlanName = value; }
	}
	//时间格林威治
	public string m_Time;
	public string Time
	{
		get { return m_Time;}
		set { m_Time = value; }
	}
	//挑战方当前名次
	public int m_ActRanking;
	public int ActRanking
	{
		get { return m_ActRanking;}
		set { m_ActRanking = value; }
	}
	//防守方的排名
	public int m_DepRanking;
	public int DepRanking
	{
		get { return m_DepRanking;}
		set { m_DepRanking = value; }
	}
	//胜利者USerID
	public long m_WinUserID;
	public long WinUserID
	{
		get { return m_WinUserID;}
		set { m_WinUserID = value; }
	}
	//是不是复制人1是
	public int m_DepIsCopy;
	public int DepIsCopy
	{
		get { return m_DepIsCopy;}
		set { m_DepIsCopy = value; }
	}
	//攻击方职业id
	public int m_ActJobID;
	public int ActJobID
	{
		get { return m_ActJobID;}
		set { m_ActJobID = value; }
	}
	//防守方职业id
	public int m_DepJobID;
	public int DepJobID
	{
		get { return m_DepJobID;}
		set { m_DepJobID = value; }
	}
	//攻击方原来的排名变化
	public int m_ActChangeSource;
	public int ActChangeSource
	{
		get { return m_ActChangeSource;}
		set { m_ActChangeSource = value; }
	}
	//防守方之前的排名变化
	public int m_DepChangeSource;
	public int DepChangeSource
	{
		get { return m_DepChangeSource;}
		set { m_DepChangeSource = value; }
	}
	//攻击方变化后的排名变化
	public int m_ActChangeOver;
	public int ActChangeOver
	{
		get { return m_ActChangeOver;}
		set { m_ActChangeOver = value; }
	}
	//防守方变换之后的排名变化
	public int m_DepChangeOver;
	public int DepChangeOver
	{
		get { return m_DepChangeOver;}
		set { m_DepChangeOver = value; }
	}


};
//排行榜职业数据封装类
[System.Serializable]
public class TopJobMessWraper
{

	//构造函数
	public TopJobMessWraper()
	{
		 m_JobID = -1;
		m_Top = new List<TopPeoValueWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_JobID = -1;
		m_Top = new List<TopPeoValueWraper>();

	}

 	//转化成Protobuffer类型函数
	public TopJobMess ToPB()
	{
		TopJobMess v = new TopJobMess();
		v.JobID = m_JobID;
		for (int i=0; i<(int)m_Top.Count; i++)
			v.Top.Add( m_Top[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TopJobMess v)
	{
        if (v == null)
            return;
		m_JobID = v.JobID;
		m_Top.Clear();
		for( int i=0; i<v.Top.Count; i++)
			m_Top.Add( new TopPeoValueWraper());
		for( int i=0; i<v.Top.Count; i++)
			m_Top[i].FromPB(v.Top[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TopJobMess>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TopJobMess pb = ProtoBuf.Serializer.Deserialize<TopJobMess>(protoMS);
		FromPB(pb);
		return true;
	}

	//职业-1所有
	public int m_JobID;
	public int JobID
	{
		get { return m_JobID;}
		set { m_JobID = value; }
	}
	//排行榜数据
	public List<TopPeoValueWraper> m_Top;
	public int SizeTop()
	{
		return m_Top.Count;
	}
	public List<TopPeoValueWraper> GetTop()
	{
		return m_Top;
	}
	public TopPeoValueWraper GetTop(int Index)
	{
		if(Index<0 || Index>=(int)m_Top.Count)
			return new TopPeoValueWraper();
		return m_Top[Index];
	}
	public void SetTop( List<TopPeoValueWraper> v )
	{
		m_Top=v;
	}
	public void SetTop( int Index, TopPeoValueWraper v )
	{
		if(Index<0 || Index>=(int)m_Top.Count)
			return;
		m_Top[Index] = v;
	}
	public void AddTop( TopPeoValueWraper v )
	{
		m_Top.Add(v);
	}
	public void ClearTop( )
	{
		m_Top.Clear();
	}


};
//排行榜数据封装类
[System.Serializable]
public class TopMessWraper
{

	//构造函数
	public TopMessWraper()
	{
		 m_MyType = -1;
		m_Top = new List<TopJobMessWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_MyType = -1;
		m_Top = new List<TopJobMessWraper>();

	}

 	//转化成Protobuffer类型函数
	public TopMess ToPB()
	{
		TopMess v = new TopMess();
		v.MyType = m_MyType;
		for (int i=0; i<(int)m_Top.Count; i++)
			v.Top.Add( m_Top[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TopMess v)
	{
        if (v == null)
            return;
		m_MyType = v.MyType;
		m_Top.Clear();
		for( int i=0; i<v.Top.Count; i++)
			m_Top.Add( new TopJobMessWraper());
		for( int i=0; i<v.Top.Count; i++)
			m_Top[i].FromPB(v.Top[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TopMess>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TopMess pb = ProtoBuf.Serializer.Deserialize<TopMess>(protoMS);
		FromPB(pb);
		return true;
	}

	//大类型1新锐2英武3神武
	public int m_MyType;
	public int MyType
	{
		get { return m_MyType;}
		set { m_MyType = value; }
	}
	//排行榜数据
	public List<TopJobMessWraper> m_Top;
	public int SizeTop()
	{
		return m_Top.Count;
	}
	public List<TopJobMessWraper> GetTop()
	{
		return m_Top;
	}
	public TopJobMessWraper GetTop(int Index)
	{
		if(Index<0 || Index>=(int)m_Top.Count)
			return new TopJobMessWraper();
		return m_Top[Index];
	}
	public void SetTop( List<TopJobMessWraper> v )
	{
		m_Top=v;
	}
	public void SetTop( int Index, TopJobMessWraper v )
	{
		if(Index<0 || Index>=(int)m_Top.Count)
			return;
		m_Top[Index] = v;
	}
	public void AddTop( TopJobMessWraper v )
	{
		m_Top.Add(v);
	}
	public void ClearTop( )
	{
		m_Top.Clear();
	}


};
//时间的排行榜封装类
[System.Serializable]
public class TimeTopWraper
{

	//构造函数
	public TimeTopWraper()
	{
		 m_ID = -1;
		 m_Ranking = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ID = -1;
		 m_Ranking = -1;

	}

 	//转化成Protobuffer类型函数
	public TimeTop ToPB()
	{
		TimeTop v = new TimeTop();
		v.ID = m_ID;
		v.Ranking = m_Ranking;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TimeTop v)
	{
        if (v == null)
            return;
		m_ID = v.ID;
		m_Ranking = v.Ranking;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TimeTop>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TimeTop pb = ProtoBuf.Serializer.Deserialize<TimeTop>(protoMS);
		FromPB(pb);
		return true;
	}

	//对照OneVSOneTime_排名时间.xlsl的id
	public long m_ID;
	public long ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}
	//排行名次
	public int m_Ranking;
	public int Ranking
	{
		get { return m_Ranking;}
		set { m_Ranking = value; }
	}


};
//邮件头信息对象封装类
[System.Serializable]
public class MailHeadObjWraper
{

	//构造函数
	public MailHeadObjWraper()
	{
		 m_UId = -1;
		 m_TiTleString = "";
		 m_CreateTime = -1;
		 m_Type = -1;
		 m_Status = 0;
		 m_IsAutoDel = false;
		 m_GUId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UId = -1;
		 m_TiTleString = "";
		 m_CreateTime = -1;
		 m_Type = -1;
		 m_Status = 0;
		 m_IsAutoDel = false;
		 m_GUId = -1;

	}

 	//转化成Protobuffer类型函数
	public MailHeadObj ToPB()
	{
		MailHeadObj v = new MailHeadObj();
		v.UId = m_UId;
		v.TiTleString = m_TiTleString;
		v.CreateTime = m_CreateTime;
		v.Type = m_Type;
		v.Status = m_Status;
		v.IsAutoDel = m_IsAutoDel;
		v.GUId = m_GUId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailHeadObj v)
	{
        if (v == null)
            return;
		m_UId = v.UId;
		m_TiTleString = v.TiTleString;
		m_CreateTime = v.CreateTime;
		m_Type = v.Type;
		m_Status = v.Status;
		m_IsAutoDel = v.IsAutoDel;
		m_GUId = v.GUId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailHeadObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailHeadObj pb = ProtoBuf.Serializer.Deserialize<MailHeadObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//UId
	public long m_UId;
	public long UId
	{
		get { return m_UId;}
		set { m_UId = value; }
	}
	//标题内容
	public string m_TiTleString;
	public string TiTleString
	{
		get { return m_TiTleString;}
		set { m_TiTleString = value; }
	}
	//创建时间
	public int m_CreateTime;
	public int CreateTime
	{
		get { return m_CreateTime;}
		set { m_CreateTime = value; }
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//邮件状态
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}
	//需要自动删除
	public bool m_IsAutoDel;
	public bool IsAutoDel
	{
		get { return m_IsAutoDel;}
		set { m_IsAutoDel = value; }
	}
	//GUId
	public long m_GUId;
	public long GUId
	{
		get { return m_GUId;}
		set { m_GUId = value; }
	}


};
//邮件内容对象封装类
[System.Serializable]
public class MailBodyObjWraper
{

	//构造函数
	public MailBodyObjWraper()
	{
		 m_Text = "";
		m_HyperlinkList = new List<ChatHyperLinkWraper>();
		m_ItemList = new List<KeyValue2IntIntWraper>();
		 m_Status = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Text = "";
		m_HyperlinkList = new List<ChatHyperLinkWraper>();
		m_ItemList = new List<KeyValue2IntIntWraper>();
		 m_Status = 0;

	}

 	//转化成Protobuffer类型函数
	public MailBodyObj ToPB()
	{
		MailBodyObj v = new MailBodyObj();
		v.Text = m_Text;
		for (int i=0; i<(int)m_HyperlinkList.Count; i++)
			v.HyperlinkList.Add( m_HyperlinkList[i].ToPB());
		for (int i=0; i<(int)m_ItemList.Count; i++)
			v.ItemList.Add( m_ItemList[i].ToPB());
		v.Status = m_Status;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailBodyObj v)
	{
        if (v == null)
            return;
		m_Text = v.Text;
		m_HyperlinkList.Clear();
		for( int i=0; i<v.HyperlinkList.Count; i++)
			m_HyperlinkList.Add( new ChatHyperLinkWraper());
		for( int i=0; i<v.HyperlinkList.Count; i++)
			m_HyperlinkList[i].FromPB(v.HyperlinkList[i]);
		m_ItemList.Clear();
		for( int i=0; i<v.ItemList.Count; i++)
			m_ItemList.Add( new KeyValue2IntIntWraper());
		for( int i=0; i<v.ItemList.Count; i++)
			m_ItemList[i].FromPB(v.ItemList[i]);
		m_Status = v.Status;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailBodyObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailBodyObj pb = ProtoBuf.Serializer.Deserialize<MailBodyObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//文本
	public string m_Text;
	public string Text
	{
		get { return m_Text;}
		set { m_Text = value; }
	}
	//所有的超链接信息
	public List<ChatHyperLinkWraper> m_HyperlinkList;
	public int SizeHyperlinkList()
	{
		return m_HyperlinkList.Count;
	}
	public List<ChatHyperLinkWraper> GetHyperlinkList()
	{
		return m_HyperlinkList;
	}
	public ChatHyperLinkWraper GetHyperlinkList(int Index)
	{
		if(Index<0 || Index>=(int)m_HyperlinkList.Count)
			return new ChatHyperLinkWraper();
		return m_HyperlinkList[Index];
	}
	public void SetHyperlinkList( List<ChatHyperLinkWraper> v )
	{
		m_HyperlinkList=v;
	}
	public void SetHyperlinkList( int Index, ChatHyperLinkWraper v )
	{
		if(Index<0 || Index>=(int)m_HyperlinkList.Count)
			return;
		m_HyperlinkList[Index] = v;
	}
	public void AddHyperlinkList( ChatHyperLinkWraper v )
	{
		m_HyperlinkList.Add(v);
	}
	public void ClearHyperlinkList( )
	{
		m_HyperlinkList.Clear();
	}
	//物品列表
	public List<KeyValue2IntIntWraper> m_ItemList;
	public int SizeItemList()
	{
		return m_ItemList.Count;
	}
	public List<KeyValue2IntIntWraper> GetItemList()
	{
		return m_ItemList;
	}
	public KeyValue2IntIntWraper GetItemList(int Index)
	{
		if(Index<0 || Index>=(int)m_ItemList.Count)
			return new KeyValue2IntIntWraper();
		return m_ItemList[Index];
	}
	public void SetItemList( List<KeyValue2IntIntWraper> v )
	{
		m_ItemList=v;
	}
	public void SetItemList( int Index, KeyValue2IntIntWraper v )
	{
		if(Index<0 || Index>=(int)m_ItemList.Count)
			return;
		m_ItemList[Index] = v;
	}
	public void AddItemList( KeyValue2IntIntWraper v )
	{
		m_ItemList.Add(v);
	}
	public void ClearItemList( )
	{
		m_ItemList.Clear();
	}
	//领取状态
	public int m_Status;
	public int Status
	{
		get { return m_Status;}
		set { m_Status = value; }
	}


};
//超链接作息封装类
[System.Serializable]
public class ChatHyperLinkWraper
{

	//构造函数
	public ChatHyperLinkWraper()
	{
		 m_Uid = -1;
		 m_ConfigID = -1;
		 m_Type = -1;
		 m_Text = "";
		 m_Userid = -1;
		 m_FunId = -1;
		 m_FunParam = new byte[0];

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Uid = -1;
		 m_ConfigID = -1;
		 m_Type = -1;
		 m_Text = "";
		 m_Userid = -1;
		 m_FunId = -1;
		 m_FunParam = new byte[0];

	}

 	//转化成Protobuffer类型函数
	public ChatHyperLink ToPB()
	{
		ChatHyperLink v = new ChatHyperLink();
		v.Uid = m_Uid;
		v.ConfigID = m_ConfigID;
		v.Type = m_Type;
		v.Text = m_Text;
		v.Userid = m_Userid;
		v.FunId = m_FunId;
		v.FunParam = m_FunParam;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatHyperLink v)
	{
        if (v == null)
            return;
		m_Uid = v.Uid;
		m_ConfigID = v.ConfigID;
		m_Type = v.Type;
		m_Text = v.Text;
		m_Userid = v.Userid;
		m_FunId = v.FunId;
		m_FunParam = v.FunParam;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatHyperLink>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatHyperLink pb = ProtoBuf.Serializer.Deserialize<ChatHyperLink>(protoMS);
		FromPB(pb);
		return true;
	}

	//物品唯一ID
	public long m_Uid;
	public long Uid
	{
		get { return m_Uid;}
		set { m_Uid = value; }
	}
	//配置表ID
	public int m_ConfigID;
	public int ConfigID
	{
		get { return m_ConfigID;}
		set { m_ConfigID = value; }
	}
	//超链类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}
	//描述
	public string m_Text;
	public string Text
	{
		get { return m_Text;}
		set { m_Text = value; }
	}
	//用户ID
	public long m_Userid;
	public long Userid
	{
		get { return m_Userid;}
		set { m_Userid = value; }
	}
	//功能Id
	public int m_FunId;
	public int FunId
	{
		get { return m_FunId;}
		set { m_FunId = value; }
	}
	//功能参数
	public byte[] m_FunParam;
	public byte[] FunParam
	{
		get { return m_FunParam;}
		set { m_FunParam = value; }
	}


};
//聊天对象封装类
[System.Serializable]
public class ChatObjWraper
{

	//构造函数
	public ChatObjWraper()
	{
		 m_ChatMsg = new ChatMsgObjWraper();
		 m_UserInfo = new ChatUserInfoObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ChatMsg = new ChatMsgObjWraper();
		 m_UserInfo = new ChatUserInfoObjWraper();

	}

 	//转化成Protobuffer类型函数
	public ChatObj ToPB()
	{
		ChatObj v = new ChatObj();
		v.ChatMsg = m_ChatMsg.ToPB();
		v.UserInfo = m_UserInfo.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatObj v)
	{
        if (v == null)
            return;
		m_ChatMsg.FromPB(v.ChatMsg);
		m_UserInfo.FromPB(v.UserInfo);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatObj pb = ProtoBuf.Serializer.Deserialize<ChatObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//聊天数据
	public ChatMsgObjWraper m_ChatMsg;
	public ChatMsgObjWraper ChatMsg
	{
		get { return m_ChatMsg;}
		set { m_ChatMsg = value; }
	}
	//发言人信息
	public ChatUserInfoObjWraper m_UserInfo;
	public ChatUserInfoObjWraper UserInfo
	{
		get { return m_UserInfo;}
		set { m_UserInfo = value; }
	}


};
//聊天消息对象封装类
[System.Serializable]
public class ChatMsgObjWraper
{

	//构造函数
	public ChatMsgObjWraper()
	{
		 m_Channel = 0;
		 m_Text = "";
		 m_Voice = new byte[0];
		 m_TargetUserId = -1;
		 m_URL = new byte[0];
		 m_ChildChannel = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Channel = 0;
		 m_Text = "";
		 m_Voice = new byte[0];
		 m_TargetUserId = -1;
		 m_URL = new byte[0];
		 m_ChildChannel = -1;

	}

 	//转化成Protobuffer类型函数
	public ChatMsgObj ToPB()
	{
		ChatMsgObj v = new ChatMsgObj();
		v.Channel = m_Channel;
		v.Text = m_Text;
		v.Voice = m_Voice;
		v.TargetUserId = m_TargetUserId;
		v.URL = m_URL;
		v.ChildChannel = m_ChildChannel;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatMsgObj v)
	{
        if (v == null)
            return;
		m_Channel = v.Channel;
		m_Text = v.Text;
		m_Voice = v.Voice;
		m_TargetUserId = v.TargetUserId;
		m_URL = v.URL;
		m_ChildChannel = v.ChildChannel;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatMsgObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatMsgObj pb = ProtoBuf.Serializer.Deserialize<ChatMsgObj>(protoMS);
		FromPB(pb);
		return true;
	}

	//频道
	public int m_Channel;
	public int Channel
	{
		get { return m_Channel;}
		set { m_Channel = value; }
	}
	//文字
	public string m_Text;
	public string Text
	{
		get { return m_Text;}
		set { m_Text = value; }
	}
	//语音
	public byte[] m_Voice;
	public byte[] Voice
	{
		get { return m_Voice;}
		set { m_Voice = value; }
	}
	//对方UserId
	public long m_TargetUserId;
	public long TargetUserId
	{
		get { return m_TargetUserId;}
		set { m_TargetUserId = value; }
	}
	//URL
	public byte[] m_URL;
	public byte[] URL
	{
		get { return m_URL;}
		set { m_URL = value; }
	}
	//子频道
	public int m_ChildChannel;
	public int ChildChannel
	{
		get { return m_ChildChannel;}
		set { m_ChildChannel = value; }
	}


};
//聊天用户信息对象封装类
[System.Serializable]
public class ChatUserInfoObjWraper
{

	//构造函数
	public ChatUserInfoObjWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Prof = -1;
		 m_Level = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UserId = -1;
		 m_UserName = "";
		 m_Prof = -1;
		 m_Level = -1;

	}

 	//转化成Protobuffer类型函数
	public ChatUserInfoObj ToPB()
	{
		ChatUserInfoObj v = new ChatUserInfoObj();
		v.UserId = m_UserId;
		v.UserName = m_UserName;
		v.Prof = m_Prof;
		v.Level = m_Level;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatUserInfoObj v)
	{
        if (v == null)
            return;
		m_UserId = v.UserId;
		m_UserName = v.UserName;
		m_Prof = v.Prof;
		m_Level = v.Level;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatUserInfoObj>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatUserInfoObj pb = ProtoBuf.Serializer.Deserialize<ChatUserInfoObj>(protoMS);
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
	//玩家名字
	public string m_UserName;
	public string UserName
	{
		get { return m_UserName;}
		set { m_UserName = value; }
	}
	//职业
	public int m_Prof;
	public int Prof
	{
		get { return m_Prof;}
		set { m_Prof = value; }
	}
	//玩家等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}


};
//聊天网络数据封装类
[System.Serializable]
public class ChatNetDataWraper
{

	//构造函数
	public ChatNetDataWraper()
	{
		m_HyperlinkList = new List<ChatHyperLinkWraper>();
		 m_Text = "";
		 m_UserInfo = new ChatUserInfoObjWraper();
		 m_Channel = 0;
		 m_ChildChannel = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_HyperlinkList = new List<ChatHyperLinkWraper>();
		 m_Text = "";
		 m_UserInfo = new ChatUserInfoObjWraper();
		 m_Channel = 0;
		 m_ChildChannel = -1;

	}

 	//转化成Protobuffer类型函数
	public ChatNetData ToPB()
	{
		ChatNetData v = new ChatNetData();
		for (int i=0; i<(int)m_HyperlinkList.Count; i++)
			v.HyperlinkList.Add( m_HyperlinkList[i].ToPB());
		v.Text = m_Text;
		v.UserInfo = m_UserInfo.ToPB();
		v.Channel = m_Channel;
		v.ChildChannel = m_ChildChannel;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(ChatNetData v)
	{
        if (v == null)
            return;
		m_HyperlinkList.Clear();
		for( int i=0; i<v.HyperlinkList.Count; i++)
			m_HyperlinkList.Add( new ChatHyperLinkWraper());
		for( int i=0; i<v.HyperlinkList.Count; i++)
			m_HyperlinkList[i].FromPB(v.HyperlinkList[i]);
		m_Text = v.Text;
		m_UserInfo.FromPB(v.UserInfo);
		m_Channel = v.Channel;
		m_ChildChannel = v.ChildChannel;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<ChatNetData>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		ChatNetData pb = ProtoBuf.Serializer.Deserialize<ChatNetData>(protoMS);
		FromPB(pb);
		return true;
	}

	//所有的超链接信息
	public List<ChatHyperLinkWraper> m_HyperlinkList;
	public int SizeHyperlinkList()
	{
		return m_HyperlinkList.Count;
	}
	public List<ChatHyperLinkWraper> GetHyperlinkList()
	{
		return m_HyperlinkList;
	}
	public ChatHyperLinkWraper GetHyperlinkList(int Index)
	{
		if(Index<0 || Index>=(int)m_HyperlinkList.Count)
			return new ChatHyperLinkWraper();
		return m_HyperlinkList[Index];
	}
	public void SetHyperlinkList( List<ChatHyperLinkWraper> v )
	{
		m_HyperlinkList=v;
	}
	public void SetHyperlinkList( int Index, ChatHyperLinkWraper v )
	{
		if(Index<0 || Index>=(int)m_HyperlinkList.Count)
			return;
		m_HyperlinkList[Index] = v;
	}
	public void AddHyperlinkList( ChatHyperLinkWraper v )
	{
		m_HyperlinkList.Add(v);
	}
	public void ClearHyperlinkList( )
	{
		m_HyperlinkList.Clear();
	}
	//文本
	public string m_Text;
	public string Text
	{
		get { return m_Text;}
		set { m_Text = value; }
	}
	//发言人信息
	public ChatUserInfoObjWraper m_UserInfo;
	public ChatUserInfoObjWraper UserInfo
	{
		get { return m_UserInfo;}
		set { m_UserInfo = value; }
	}
	//频道
	public int m_Channel;
	public int Channel
	{
		get { return m_Channel;}
		set { m_Channel = value; }
	}
	//子频道
	public int m_ChildChannel;
	public int ChildChannel
	{
		get { return m_ChildChannel;}
		set { m_ChildChannel = value; }
	}


};
