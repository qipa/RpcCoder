
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBGodWeapon.cs
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


//宝石格子封装类
[System.Serializable]
public class GodWeaponGemGridObjWraperV1
{

	//构造函数
	public GodWeaponGemGridObjWraperV1()
	{
		 m_GemId = -1;
		 m_Count = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_GemId = -1;
		 m_Count = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponGemGridObjV1 ToPB()
	{
		GodWeaponGemGridObjV1 v = new GodWeaponGemGridObjV1();
		v.GemId = m_GemId;
		v.Count = m_Count;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponGemGridObjV1 v)
	{
        if (v == null)
            return;
		m_GemId = v.GemId;
		m_Count = v.Count;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponGemGridObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponGemGridObjV1 pb = ProtoBuf.Serializer.Deserialize<GodWeaponGemGridObjV1>(protoMS);
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
	//宝石数量
	public int m_Count;
	public int Count
	{
		get { return m_Count;}
		set { m_Count = value; }
	}


};
//神器宝石封装类
[System.Serializable]
public class GodWeaponGemObjWraperV1
{

	//构造函数
	public GodWeaponGemObjWraperV1()
	{
		 m_Id = -1;
		 m_Pos = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Pos = -1;

	}

 	//转化成Protobuffer类型函数
	public GodWeaponGemObjV1 ToPB()
	{
		GodWeaponGemObjV1 v = new GodWeaponGemObjV1();
		v.Id = m_Id;
		v.Pos = m_Pos;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponGemObjV1 v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Pos = v.Pos;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponGemObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponGemObjV1 pb = ProtoBuf.Serializer.Deserialize<GodWeaponGemObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//宝石id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//位置
	public int m_Pos;
	public int Pos
	{
		get { return m_Pos;}
		set { m_Pos = value; }
	}


};
//神器对象封装类
[System.Serializable]
public class GodWeaponGodWeaponObjWraperV1
{

	//构造函数
	public GodWeaponGodWeaponObjWraperV1()
	{
		 m_Id = -1;
		 m_Quality = 0;
		 m_Star = 0;
		m_GemArray = new List<GodWeaponGemObjWraperV1>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Quality = 0;
		 m_Star = 0;
		m_GemArray = new List<GodWeaponGemObjWraperV1>();

	}

 	//转化成Protobuffer类型函数
	public GodWeaponGodWeaponObjV1 ToPB()
	{
		GodWeaponGodWeaponObjV1 v = new GodWeaponGodWeaponObjV1();
		v.Id = m_Id;
		v.Quality = m_Quality;
		v.Star = m_Star;
		for (int i=0; i<(int)m_GemArray.Count; i++)
			v.GemArray.Add( m_GemArray[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(GodWeaponGodWeaponObjV1 v)
	{
        if (v == null)
            return;
		m_Id = v.Id;
		m_Quality = v.Quality;
		m_Star = v.Star;
		m_GemArray.Clear();
		for( int i=0; i<v.GemArray.Count; i++)
			m_GemArray.Add( new GodWeaponGemObjWraperV1());
		for( int i=0; i<v.GemArray.Count; i++)
			m_GemArray[i].FromPB(v.GemArray[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<GodWeaponGodWeaponObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		GodWeaponGodWeaponObjV1 pb = ProtoBuf.Serializer.Deserialize<GodWeaponGodWeaponObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//神器id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//品质
	public int m_Quality;
	public int Quality
	{
		get { return m_Quality;}
		set { m_Quality = value; }
	}
	//星级
	public int m_Star;
	public int Star
	{
		get { return m_Star;}
		set { m_Star = value; }
	}
	//宝石1
	public List<GodWeaponGemObjWraperV1> m_GemArray;
	public int SizeGemArray()
	{
		return m_GemArray.Count;
	}
	public List<GodWeaponGemObjWraperV1> GetGemArray()
	{
		return m_GemArray;
	}
	public GodWeaponGemObjWraperV1 GetGemArray(int Index)
	{
		if(Index<0 || Index>=(int)m_GemArray.Count)
			return new GodWeaponGemObjWraperV1();
		return m_GemArray[Index];
	}
	public void SetGemArray( List<GodWeaponGemObjWraperV1> v )
	{
		m_GemArray=v;
	}
	public void SetGemArray( int Index, GodWeaponGemObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GemArray.Count)
			return;
		m_GemArray[Index] = v;
	}
	public void AddGemArray( GodWeaponGemObjWraperV1 v )
	{
		m_GemArray.Add(v);
	}
	public void ClearGemArray( )
	{
		m_GemArray.Clear();
	}


};
