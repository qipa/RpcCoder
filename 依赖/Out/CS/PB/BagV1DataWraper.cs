
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBBag.cs
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


//格子信息封装类
[System.Serializable]
public class BagGridInfoWraperV1
{

	//构造函数
	public BagGridInfoWraperV1()
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
	public BagGridInfoV1 ToPB()
	{
		BagGridInfoV1 v = new BagGridInfoV1();
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
	public void FromPB(BagGridInfoV1 v)
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
		ProtoBuf.Serializer.Serialize<BagGridInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagGridInfoV1 pb = ProtoBuf.Serializer.Deserialize<BagGridInfoV1>(protoMS);
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
	//实例id，唯一id
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
//法宝对象封装类
[System.Serializable]
public class BagTalismanObjWraperV1
{

	//构造函数
	public BagTalismanObjWraperV1()
	{
		 m_ItemID = -1;
		 m_TemplateId = -1;
		 m_CurExp = 0;
		 m_EquipScore = 0;
		 m_StarLevel = 0;
		m_GatherSpriteSlot = new List<BagSlotInfoWraperV1>();
		 m_TailsManLevel = -1;
		m_TalismanAttr = new List<int>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_ItemID = -1;
		 m_TemplateId = -1;
		 m_CurExp = 0;
		 m_EquipScore = 0;
		 m_StarLevel = 0;
		m_GatherSpriteSlot = new List<BagSlotInfoWraperV1>();
		 m_TailsManLevel = -1;
		m_TalismanAttr = new List<int>();

	}

 	//转化成Protobuffer类型函数
	public BagTalismanObjV1 ToPB()
	{
		BagTalismanObjV1 v = new BagTalismanObjV1();
		v.ItemID = m_ItemID;
		v.TemplateId = m_TemplateId;
		v.CurExp = m_CurExp;
		v.EquipScore = m_EquipScore;
		v.StarLevel = m_StarLevel;
		for (int i=0; i<(int)m_GatherSpriteSlot.Count; i++)
			v.GatherSpriteSlot.Add( m_GatherSpriteSlot[i].ToPB());
		v.TailsManLevel = m_TailsManLevel;
		for (int i=0; i<(int)m_TalismanAttr.Count; i++)
			v.TalismanAttr.Add( m_TalismanAttr[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagTalismanObjV1 v)
	{
        if (v == null)
            return;
		m_ItemID = v.ItemID;
		m_TemplateId = v.TemplateId;
		m_CurExp = v.CurExp;
		m_EquipScore = v.EquipScore;
		m_StarLevel = v.StarLevel;
		m_GatherSpriteSlot.Clear();
		for( int i=0; i<v.GatherSpriteSlot.Count; i++)
			m_GatherSpriteSlot.Add( new BagSlotInfoWraperV1());
		for( int i=0; i<v.GatherSpriteSlot.Count; i++)
			m_GatherSpriteSlot[i].FromPB(v.GatherSpriteSlot[i]);
		m_TailsManLevel = v.TailsManLevel;
		m_TalismanAttr.Clear();
		for( int i=0; i<v.TalismanAttr.Count; i++)
			m_TalismanAttr.Add(v.TalismanAttr[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagTalismanObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagTalismanObjV1 pb = ProtoBuf.Serializer.Deserialize<BagTalismanObjV1>(protoMS);
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
	//模板id
	public int m_TemplateId;
	public int TemplateId
	{
		get { return m_TemplateId;}
		set { m_TemplateId = value; }
	}
	//当前经验
	public int m_CurExp;
	public int CurExp
	{
		get { return m_CurExp;}
		set { m_CurExp = value; }
	}
	//装备评分
	public int m_EquipScore;
	public int EquipScore
	{
		get { return m_EquipScore;}
		set { m_EquipScore = value; }
	}
	//星级
	public int m_StarLevel;
	public int StarLevel
	{
		get { return m_StarLevel;}
		set { m_StarLevel = value; }
	}
	//聚灵槽位
	public List<BagSlotInfoWraperV1> m_GatherSpriteSlot;
	public int SizeGatherSpriteSlot()
	{
		return m_GatherSpriteSlot.Count;
	}
	public List<BagSlotInfoWraperV1> GetGatherSpriteSlot()
	{
		return m_GatherSpriteSlot;
	}
	public BagSlotInfoWraperV1 GetGatherSpriteSlot(int Index)
	{
		if(Index<0 || Index>=(int)m_GatherSpriteSlot.Count)
			return new BagSlotInfoWraperV1();
		return m_GatherSpriteSlot[Index];
	}
	public void SetGatherSpriteSlot( List<BagSlotInfoWraperV1> v )
	{
		m_GatherSpriteSlot=v;
	}
	public void SetGatherSpriteSlot( int Index, BagSlotInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_GatherSpriteSlot.Count)
			return;
		m_GatherSpriteSlot[Index] = v;
	}
	public void AddGatherSpriteSlot( BagSlotInfoWraperV1 v )
	{
		m_GatherSpriteSlot.Add(v);
	}
	public void ClearGatherSpriteSlot( )
	{
		m_GatherSpriteSlot.Clear();
	}
	//法宝等级
	public int m_TailsManLevel;
	public int TailsManLevel
	{
		get { return m_TailsManLevel;}
		set { m_TailsManLevel = value; }
	}
	//法宝属性
	public List<int> m_TalismanAttr;
	public int SizeTalismanAttr()
	{
		return m_TalismanAttr.Count;
	}
	public List<int> GetTalismanAttr()
	{
		return m_TalismanAttr;
	}
	public int GetTalismanAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_TalismanAttr.Count)
			return -1;
		return m_TalismanAttr[Index];
	}
	public void SetTalismanAttr( List<int> v )
	{
		m_TalismanAttr=v;
	}
	public void SetTalismanAttr( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_TalismanAttr.Count)
			return;
		m_TalismanAttr[Index] = v;
	}
	public void AddTalismanAttr( int v=-1 )
	{
		m_TalismanAttr.Add(v);
	}
	public void ClearTalismanAttr( )
	{
		m_TalismanAttr.Clear();
	}


};
//槽位信息封装类
[System.Serializable]
public class BagSlotInfoWraperV1
{

	//构造函数
	public BagSlotInfoWraperV1()
	{
		 m_SlotId = -1;
		 m_SlotType = -1;
		 m_SlotSkillId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SlotId = -1;
		 m_SlotType = -1;
		 m_SlotSkillId = -1;

	}

 	//转化成Protobuffer类型函数
	public BagSlotInfoV1 ToPB()
	{
		BagSlotInfoV1 v = new BagSlotInfoV1();
		v.SlotId = m_SlotId;
		v.SlotType = m_SlotType;
		v.SlotSkillId = m_SlotSkillId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(BagSlotInfoV1 v)
	{
        if (v == null)
            return;
		m_SlotId = v.SlotId;
		m_SlotType = v.SlotType;
		m_SlotSkillId = v.SlotSkillId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<BagSlotInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		BagSlotInfoV1 pb = ProtoBuf.Serializer.Deserialize<BagSlotInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//槽位Id
	public int m_SlotId;
	public int SlotId
	{
		get { return m_SlotId;}
		set { m_SlotId = value; }
	}
	//槽位类别(0上古，1其他)
	public int m_SlotType;
	public int SlotType
	{
		get { return m_SlotType;}
		set { m_SlotType = value; }
	}
	//聚灵技能ID
	public int m_SlotSkillId;
	public int SlotSkillId
	{
		get { return m_SlotSkillId;}
		set { m_SlotSkillId = value; }
	}


};
