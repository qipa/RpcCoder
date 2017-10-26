
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBTalisman.cs
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


//法宝信息封装类
[System.Serializable]
public class TalismanFabaoInfoWraperV1
{

	//构造函数
	public TalismanFabaoInfoWraperV1()
	{
		 m_ID = -1;
		 m_Lv = 1;
		 m_IsActived = 0;
		m_ActivedCondID = new List<int>();
		 m_Exp = 0;
		 m_HitType = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ID = -1;
		 m_Lv = 1;
		 m_IsActived = 0;
		m_ActivedCondID = new List<int>();
		 m_Exp = 0;
		 m_HitType = -1;

	}

 	//转化成Protobuffer类型函数
	public TalismanFabaoInfoV1 ToPB()
	{
		TalismanFabaoInfoV1 v = new TalismanFabaoInfoV1();
		v.ID = m_ID;
		v.Lv = m_Lv;
		v.IsActived = m_IsActived;
		for (int i=0; i<(int)m_ActivedCondID.Count; i++)
			v.ActivedCondID.Add( m_ActivedCondID[i]);
		v.Exp = m_Exp;
		v.HitType = m_HitType;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(TalismanFabaoInfoV1 v)
	{
        if (v == null)
            return;
		m_ID = v.ID;
		m_Lv = v.Lv;
		m_IsActived = v.IsActived;
		m_ActivedCondID.Clear();
		for( int i=0; i<v.ActivedCondID.Count; i++)
			m_ActivedCondID.Add(v.ActivedCondID[i]);
		m_Exp = v.Exp;
		m_HitType = v.HitType;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<TalismanFabaoInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		TalismanFabaoInfoV1 pb = ProtoBuf.Serializer.Deserialize<TalismanFabaoInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//ID
	public int m_ID;
	public int ID
	{
		get { return m_ID;}
		set { m_ID = value; }
	}
	//LV
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//是否激活
	public int m_IsActived;
	public int IsActived
	{
		get { return m_IsActived;}
		set { m_IsActived = value; }
	}
	//已激活的条件ID
	public List<int> m_ActivedCondID;
	public int SizeActivedCondID()
	{
		return m_ActivedCondID.Count;
	}
	public List<int> GetActivedCondID()
	{
		return m_ActivedCondID;
	}
	public int GetActivedCondID(int Index)
	{
		if(Index<0 || Index>=(int)m_ActivedCondID.Count)
			return -1;
		return m_ActivedCondID[Index];
	}
	public void SetActivedCondID( List<int> v )
	{
		m_ActivedCondID=v;
	}
	public void SetActivedCondID( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_ActivedCondID.Count)
			return;
		m_ActivedCondID[Index] = v;
	}
	public void AddActivedCondID( int v=-1 )
	{
		m_ActivedCondID.Add(v);
	}
	public void ClearActivedCondID( )
	{
		m_ActivedCondID.Clear();
	}
	//经验
	public int m_Exp;
	public int Exp
	{
		get { return m_Exp;}
		set { m_Exp = value; }
	}
	//爆击类型
	public int m_HitType;
	public int HitType
	{
		get { return m_HitType;}
		set { m_HitType = value; }
	}


};
