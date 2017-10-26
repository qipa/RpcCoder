
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBSkill.cs
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


//技能对象封装类
[System.Serializable]
public class SkillSkillObjWraperV1
{

	//构造函数
	public SkillSkillObjWraperV1()
	{
		 m_SkillId = -1;
		 m_Lv = 1;
		 m_IsLearn = false;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;
		 m_Lv = 1;
		 m_IsLearn = false;

	}

 	//转化成Protobuffer类型函数
	public SkillSkillObjV1 ToPB()
	{
		SkillSkillObjV1 v = new SkillSkillObjV1();
		v.SkillId = m_SkillId;
		v.Lv = m_Lv;
		v.IsLearn = m_IsLearn;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillSkillObjV1 v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;
		m_Lv = v.Lv;
		m_IsLearn = v.IsLearn;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillSkillObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillSkillObjV1 pb = ProtoBuf.Serializer.Deserialize<SkillSkillObjV1>(protoMS);
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
	//等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//是否学习
	public bool m_IsLearn;
	public bool IsLearn
	{
		get { return m_IsLearn;}
		set { m_IsLearn = value; }
	}


};
//一个技能方案封装类
[System.Serializable]
public class SkillShortcutObjWraperV1
{

	//构造函数
	public SkillShortcutObjWraperV1()
	{
		m_SkillId = new List<int>();
		 m_Type = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		m_SkillId = new List<int>();
		 m_Type = -1;

	}

 	//转化成Protobuffer类型函数
	public SkillShortcutObjV1 ToPB()
	{
		SkillShortcutObjV1 v = new SkillShortcutObjV1();
		for (int i=0; i<(int)m_SkillId.Count; i++)
			v.SkillId.Add( m_SkillId[i]);
		v.Type = m_Type;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillShortcutObjV1 v)
	{
        if (v == null)
            return;
		m_SkillId.Clear();
		for( int i=0; i<v.SkillId.Count; i++)
			m_SkillId.Add(v.SkillId[i]);
		m_Type = v.Type;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillShortcutObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillShortcutObjV1 pb = ProtoBuf.Serializer.Deserialize<SkillShortcutObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能Id
	public List<int> m_SkillId;
	public int SizeSkillId()
	{
		return m_SkillId.Count;
	}
	public List<int> GetSkillId()
	{
		return m_SkillId;
	}
	public int GetSkillId(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillId.Count)
			return -1;
		return m_SkillId[Index];
	}
	public void SetSkillId( List<int> v )
	{
		m_SkillId=v;
	}
	public void SetSkillId( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_SkillId.Count)
			return;
		m_SkillId[Index] = v;
	}
	public void AddSkillId( int v=-1 )
	{
		m_SkillId.Add(v);
	}
	public void ClearSkillId( )
	{
		m_SkillId.Clear();
	}
	//类型
	public int m_Type;
	public int Type
	{
		get { return m_Type;}
		set { m_Type = value; }
	}


};
//天赋槽位封装类
[System.Serializable]
public class SkillTalentSlotWraperV1
{

	//构造函数
	public SkillTalentSlotWraperV1()
	{
		 m_SkillId = -1;
		 m_Level = 0;
		 m_IsLock = true;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;
		 m_Level = 0;
		 m_IsLock = true;

	}

 	//转化成Protobuffer类型函数
	public SkillTalentSlotV1 ToPB()
	{
		SkillTalentSlotV1 v = new SkillTalentSlotV1();
		v.SkillId = m_SkillId;
		v.Level = m_Level;
		v.IsLock = m_IsLock;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(SkillTalentSlotV1 v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;
		m_Level = v.Level;
		m_IsLock = v.IsLock;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<SkillTalentSlotV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		SkillTalentSlotV1 pb = ProtoBuf.Serializer.Deserialize<SkillTalentSlotV1>(protoMS);
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
	//槽位等级
	public int m_Level;
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}
	//是否开启
	public bool m_IsLock;
	public bool IsLock
	{
		get { return m_IsLock;}
		set { m_IsLock = value; }
	}


};
