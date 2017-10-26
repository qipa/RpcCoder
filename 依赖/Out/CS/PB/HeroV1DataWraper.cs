
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperSyncPBHero.cs
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


//英雄数据封装类
[System.Serializable]
public class HeroHeroDataWraperV1
{

	//构造函数
	public HeroHeroDataWraperV1()
	{
		 m_Lv = 1;
		 m_Exp = 0;
		 m_StarStage = 1;
		 m_StarLv = 0;
		 m_HerdId = -1;
		m_StoneArr = new List<HeroStoneInfoWraperV1>();
		 m_DestinyLv = 0;
		m_SkillData = new List<HeroSkillObjWraperV1>();
		m_Attrs = new List<int>();
		 m_Military = -1;
		 m_StrAttr = -1;
		 m_DexAttr = -1;
		 m_IntAttr = -1;
		m_PercentAttrs = new List<float>();
		 m_SkillMilitary = -1;
		m_SpecialAttr = new List<HeroAttrObjWraperV1>();
		 m_ExtraMilitary = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = 1;
		 m_Exp = 0;
		 m_StarStage = 1;
		 m_StarLv = 0;
		 m_HerdId = -1;
		m_StoneArr = new List<HeroStoneInfoWraperV1>();
		 m_DestinyLv = 0;
		m_SkillData = new List<HeroSkillObjWraperV1>();
		m_Attrs = new List<int>();
		 m_Military = -1;
		 m_StrAttr = -1;
		 m_DexAttr = -1;
		 m_IntAttr = -1;
		m_PercentAttrs = new List<float>();
		 m_SkillMilitary = -1;
		m_SpecialAttr = new List<HeroAttrObjWraperV1>();
		 m_ExtraMilitary = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroHeroDataV1 ToPB()
	{
		HeroHeroDataV1 v = new HeroHeroDataV1();
		v.Lv = m_Lv;
		v.Exp = m_Exp;
		v.StarStage = m_StarStage;
		v.StarLv = m_StarLv;
		v.HerdId = m_HerdId;
		for (int i=0; i<(int)m_StoneArr.Count; i++)
			v.StoneArr.Add( m_StoneArr[i].ToPB());
		v.DestinyLv = m_DestinyLv;
		for (int i=0; i<(int)m_SkillData.Count; i++)
			v.SkillData.Add( m_SkillData[i].ToPB());
		for (int i=0; i<(int)m_Attrs.Count; i++)
			v.Attrs.Add( m_Attrs[i]);
		v.Military = m_Military;
		v.StrAttr = m_StrAttr;
		v.DexAttr = m_DexAttr;
		v.IntAttr = m_IntAttr;
		for (int i=0; i<(int)m_PercentAttrs.Count; i++)
			v.PercentAttrs.Add( m_PercentAttrs[i]);
		v.SkillMilitary = m_SkillMilitary;
		for (int i=0; i<(int)m_SpecialAttr.Count; i++)
			v.SpecialAttr.Add( m_SpecialAttr[i].ToPB());
		v.ExtraMilitary = m_ExtraMilitary;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroHeroDataV1 v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;
		m_Exp = v.Exp;
		m_StarStage = v.StarStage;
		m_StarLv = v.StarLv;
		m_HerdId = v.HerdId;
		m_StoneArr.Clear();
		for( int i=0; i<v.StoneArr.Count; i++)
			m_StoneArr.Add( new HeroStoneInfoWraperV1());
		for( int i=0; i<v.StoneArr.Count; i++)
			m_StoneArr[i].FromPB(v.StoneArr[i]);
		m_DestinyLv = v.DestinyLv;
		m_SkillData.Clear();
		for( int i=0; i<v.SkillData.Count; i++)
			m_SkillData.Add( new HeroSkillObjWraperV1());
		for( int i=0; i<v.SkillData.Count; i++)
			m_SkillData[i].FromPB(v.SkillData[i]);
		m_Attrs.Clear();
		for( int i=0; i<v.Attrs.Count; i++)
			m_Attrs.Add(v.Attrs[i]);
		m_Military = v.Military;
		m_StrAttr = v.StrAttr;
		m_DexAttr = v.DexAttr;
		m_IntAttr = v.IntAttr;
		m_PercentAttrs.Clear();
		for( int i=0; i<v.PercentAttrs.Count; i++)
			m_PercentAttrs.Add(v.PercentAttrs[i]);
		m_SkillMilitary = v.SkillMilitary;
		m_SpecialAttr.Clear();
		for( int i=0; i<v.SpecialAttr.Count; i++)
			m_SpecialAttr.Add( new HeroAttrObjWraperV1());
		for( int i=0; i<v.SpecialAttr.Count; i++)
			m_SpecialAttr[i].FromPB(v.SpecialAttr[i]);
		m_ExtraMilitary = v.ExtraMilitary;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroHeroDataV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroHeroDataV1 pb = ProtoBuf.Serializer.Deserialize<HeroHeroDataV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//经验
	public int m_Exp;
	public int Exp
	{
		get { return m_Exp;}
		set { m_Exp = value; }
	}
	//星阶
	public int m_StarStage;
	public int StarStage
	{
		get { return m_StarStage;}
		set { m_StarStage = value; }
	}
	//星级
	public int m_StarLv;
	public int StarLv
	{
		get { return m_StarLv;}
		set { m_StarLv = value; }
	}
	//英雄id
	public int m_HerdId;
	public int HerdId
	{
		get { return m_HerdId;}
		set { m_HerdId = value; }
	}
	//星石附魔
	public List<HeroStoneInfoWraperV1> m_StoneArr;
	public int SizeStoneArr()
	{
		return m_StoneArr.Count;
	}
	public List<HeroStoneInfoWraperV1> GetStoneArr()
	{
		return m_StoneArr;
	}
	public HeroStoneInfoWraperV1 GetStoneArr(int Index)
	{
		if(Index<0 || Index>=(int)m_StoneArr.Count)
			return new HeroStoneInfoWraperV1();
		return m_StoneArr[Index];
	}
	public void SetStoneArr( List<HeroStoneInfoWraperV1> v )
	{
		m_StoneArr=v;
	}
	public void SetStoneArr( int Index, HeroStoneInfoWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_StoneArr.Count)
			return;
		m_StoneArr[Index] = v;
	}
	public void AddStoneArr( HeroStoneInfoWraperV1 v )
	{
		m_StoneArr.Add(v);
	}
	public void ClearStoneArr( )
	{
		m_StoneArr.Clear();
	}
	//天命等级
	public int m_DestinyLv;
	public int DestinyLv
	{
		get { return m_DestinyLv;}
		set { m_DestinyLv = value; }
	}
	//技能数据
	public List<HeroSkillObjWraperV1> m_SkillData;
	public int SizeSkillData()
	{
		return m_SkillData.Count;
	}
	public List<HeroSkillObjWraperV1> GetSkillData()
	{
		return m_SkillData;
	}
	public HeroSkillObjWraperV1 GetSkillData(int Index)
	{
		if(Index<0 || Index>=(int)m_SkillData.Count)
			return new HeroSkillObjWraperV1();
		return m_SkillData[Index];
	}
	public void SetSkillData( List<HeroSkillObjWraperV1> v )
	{
		m_SkillData=v;
	}
	public void SetSkillData( int Index, HeroSkillObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_SkillData.Count)
			return;
		m_SkillData[Index] = v;
	}
	public void AddSkillData( HeroSkillObjWraperV1 v )
	{
		m_SkillData.Add(v);
	}
	public void ClearSkillData( )
	{
		m_SkillData.Clear();
	}
	//属性列表
	public List<int> m_Attrs;
	public int SizeAttrs()
	{
		return m_Attrs.Count;
	}
	public List<int> GetAttrs()
	{
		return m_Attrs;
	}
	public int GetAttrs(int Index)
	{
		if(Index<0 || Index>=(int)m_Attrs.Count)
			return -1;
		return m_Attrs[Index];
	}
	public void SetAttrs( List<int> v )
	{
		m_Attrs=v;
	}
	public void SetAttrs( int Index, int v )
	{
		if(Index<0 || Index>=(int)m_Attrs.Count)
			return;
		m_Attrs[Index] = v;
	}
	public void AddAttrs( int v=-1 )
	{
		m_Attrs.Add(v);
	}
	public void ClearAttrs( )
	{
		m_Attrs.Clear();
	}
	//战力
	public int m_Military;
	public int Military
	{
		get { return m_Military;}
		set { m_Military = value; }
	}
	//力量属性
	public int m_StrAttr;
	public int StrAttr
	{
		get { return m_StrAttr;}
		set { m_StrAttr = value; }
	}
	//敏捷属性
	public int m_DexAttr;
	public int DexAttr
	{
		get { return m_DexAttr;}
		set { m_DexAttr = value; }
	}
	//智力属性
	public int m_IntAttr;
	public int IntAttr
	{
		get { return m_IntAttr;}
		set { m_IntAttr = value; }
	}
	//百分比属性加成
	public List<float> m_PercentAttrs;
	public int SizePercentAttrs()
	{
		return m_PercentAttrs.Count;
	}
	public List<float> GetPercentAttrs()
	{
		return m_PercentAttrs;
	}
	public float GetPercentAttrs(int Index)
	{
		if(Index<0 || Index>=(int)m_PercentAttrs.Count)
			return -1;
		return m_PercentAttrs[Index];
	}
	public void SetPercentAttrs( List<float> v )
	{
		m_PercentAttrs=v;
	}
	public void SetPercentAttrs( int Index, float v )
	{
		if(Index<0 || Index>=(int)m_PercentAttrs.Count)
			return;
		m_PercentAttrs[Index] = v;
	}
	public void AddPercentAttrs( float v=-1 )
	{
		m_PercentAttrs.Add(v);
	}
	public void ClearPercentAttrs( )
	{
		m_PercentAttrs.Clear();
	}
	//技能战力
	public int m_SkillMilitary;
	public int SkillMilitary
	{
		get { return m_SkillMilitary;}
		set { m_SkillMilitary = value; }
	}
	//特殊属性
	public List<HeroAttrObjWraperV1> m_SpecialAttr;
	public int SizeSpecialAttr()
	{
		return m_SpecialAttr.Count;
	}
	public List<HeroAttrObjWraperV1> GetSpecialAttr()
	{
		return m_SpecialAttr;
	}
	public HeroAttrObjWraperV1 GetSpecialAttr(int Index)
	{
		if(Index<0 || Index>=(int)m_SpecialAttr.Count)
			return new HeroAttrObjWraperV1();
		return m_SpecialAttr[Index];
	}
	public void SetSpecialAttr( List<HeroAttrObjWraperV1> v )
	{
		m_SpecialAttr=v;
	}
	public void SetSpecialAttr( int Index, HeroAttrObjWraperV1 v )
	{
		if(Index<0 || Index>=(int)m_SpecialAttr.Count)
			return;
		m_SpecialAttr[Index] = v;
	}
	public void AddSpecialAttr( HeroAttrObjWraperV1 v )
	{
		m_SpecialAttr.Add(v);
	}
	public void ClearSpecialAttr( )
	{
		m_SpecialAttr.Clear();
	}
	//附加战力
	public int m_ExtraMilitary;
	public int ExtraMilitary
	{
		get { return m_ExtraMilitary;}
		set { m_ExtraMilitary = value; }
	}


};
//星石信息封装类
[System.Serializable]
public class HeroStoneInfoWraperV1
{

	//构造函数
	public HeroStoneInfoWraperV1()
	{
		 m_Lv = -1;
		 m_Exp = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Lv = -1;
		 m_Exp = 0;

	}

 	//转化成Protobuffer类型函数
	public HeroStoneInfoV1 ToPB()
	{
		HeroStoneInfoV1 v = new HeroStoneInfoV1();
		v.Lv = m_Lv;
		v.Exp = m_Exp;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroStoneInfoV1 v)
	{
        if (v == null)
            return;
		m_Lv = v.Lv;
		m_Exp = v.Exp;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroStoneInfoV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroStoneInfoV1 pb = ProtoBuf.Serializer.Deserialize<HeroStoneInfoV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//星石及附魔等级
	public int m_Lv;
	public int Lv
	{
		get { return m_Lv;}
		set { m_Lv = value; }
	}
	//经验
	public int m_Exp;
	public int Exp
	{
		get { return m_Exp;}
		set { m_Exp = value; }
	}


};
//技能封装类
[System.Serializable]
public class HeroSkillObjWraperV1
{

	//构造函数
	public HeroSkillObjWraperV1()
	{
		 m_SkillId = -1;
		 m_SkillLevel = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_SkillId = -1;
		 m_SkillLevel = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroSkillObjV1 ToPB()
	{
		HeroSkillObjV1 v = new HeroSkillObjV1();
		v.SkillId = m_SkillId;
		v.SkillLevel = m_SkillLevel;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroSkillObjV1 v)
	{
        if (v == null)
            return;
		m_SkillId = v.SkillId;
		m_SkillLevel = v.SkillLevel;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<HeroSkillObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroSkillObjV1 pb = ProtoBuf.Serializer.Deserialize<HeroSkillObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//技能id
	public int m_SkillId;
	public int SkillId
	{
		get { return m_SkillId;}
		set { m_SkillId = value; }
	}
	//技能等级
	public int m_SkillLevel;
	public int SkillLevel
	{
		get { return m_SkillLevel;}
		set { m_SkillLevel = value; }
	}


};
//属性对象封装类
[System.Serializable]
public class HeroAttrObjWraperV1
{

	//构造函数
	public HeroAttrObjWraperV1()
	{
		 m_Id = -1;
		 m_Value = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Id = -1;
		 m_Value = -1;

	}

 	//转化成Protobuffer类型函数
	public HeroAttrObjV1 ToPB()
	{
		HeroAttrObjV1 v = new HeroAttrObjV1();
		v.Id = m_Id;
		v.Value = m_Value;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(HeroAttrObjV1 v)
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
		ProtoBuf.Serializer.Serialize<HeroAttrObjV1>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		HeroAttrObjV1 pb = ProtoBuf.Serializer.Deserialize<HeroAttrObjV1>(protoMS);
		FromPB(pb);
		return true;
	}

	//属性id
	public int m_Id;
	public int Id
	{
		get { return m_Id;}
		set { m_Id = value; }
	}
	//属性值
	public int m_Value;
	public int Value
	{
		get { return m_Value;}
		set { m_Value = value; }
	}


};
