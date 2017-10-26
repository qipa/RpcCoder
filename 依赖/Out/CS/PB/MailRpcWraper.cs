
/************************************************************
Copyright (C), 2011-2015, AGAN Tech. Co., Ltd.
FileName:     WraperRpcPBMail.cs
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


//获得邮件头请求封装类
[System.Serializable]
public class MailRpcMailHeadAskWraper
{

	//构造函数
	public MailRpcMailHeadAskWraper()
	{
		 m_Count = 0;
		 m_UId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Count = 0;
		 m_UId = -1;

	}

 	//转化成Protobuffer类型函数
	public MailRpcMailHeadAsk ToPB()
	{
		MailRpcMailHeadAsk v = new MailRpcMailHeadAsk();
		v.Count = m_Count;
		v.UId = m_UId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcMailHeadAsk v)
	{
        if (v == null)
            return;
		m_Count = v.Count;
		m_UId = v.UId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcMailHeadAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcMailHeadAsk pb = ProtoBuf.Serializer.Deserialize<MailRpcMailHeadAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//数量
	public int m_Count;
	public int Count
	{
		get { return m_Count;}
		set { m_Count = value; }
	}
	//UId
	public long m_UId;
	public long UId
	{
		get { return m_UId;}
		set { m_UId = value; }
	}


};
//获得邮件头回应封装类
[System.Serializable]
public class MailRpcMailHeadReplyWraper
{

	//构造函数
	public MailRpcMailHeadReplyWraper()
	{
		 m_Result = -9999;
		m_MailHeadList = new List<MailHeadObjWraper>();
		 m_MaxCount = 0;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_MailHeadList = new List<MailHeadObjWraper>();
		 m_MaxCount = 0;

	}

 	//转化成Protobuffer类型函数
	public MailRpcMailHeadReply ToPB()
	{
		MailRpcMailHeadReply v = new MailRpcMailHeadReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_MailHeadList.Count; i++)
			v.MailHeadList.Add( m_MailHeadList[i].ToPB());
		v.MaxCount = m_MaxCount;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcMailHeadReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_MailHeadList.Clear();
		for( int i=0; i<v.MailHeadList.Count; i++)
			m_MailHeadList.Add( new MailHeadObjWraper());
		for( int i=0; i<v.MailHeadList.Count; i++)
			m_MailHeadList[i].FromPB(v.MailHeadList[i]);
		m_MaxCount = v.MaxCount;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcMailHeadReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcMailHeadReply pb = ProtoBuf.Serializer.Deserialize<MailRpcMailHeadReply>(protoMS);
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
	//邮件头信息列表
	public List<MailHeadObjWraper> m_MailHeadList;
	public int SizeMailHeadList()
	{
		return m_MailHeadList.Count;
	}
	public List<MailHeadObjWraper> GetMailHeadList()
	{
		return m_MailHeadList;
	}
	public MailHeadObjWraper GetMailHeadList(int Index)
	{
		if(Index<0 || Index>=(int)m_MailHeadList.Count)
			return new MailHeadObjWraper();
		return m_MailHeadList[Index];
	}
	public void SetMailHeadList( List<MailHeadObjWraper> v )
	{
		m_MailHeadList=v;
	}
	public void SetMailHeadList( int Index, MailHeadObjWraper v )
	{
		if(Index<0 || Index>=(int)m_MailHeadList.Count)
			return;
		m_MailHeadList[Index] = v;
	}
	public void AddMailHeadList( MailHeadObjWraper v )
	{
		m_MailHeadList.Add(v);
	}
	public void ClearMailHeadList( )
	{
		m_MailHeadList.Clear();
	}
	//最大邮件数量
	public int m_MaxCount;
	public int MaxCount
	{
		get { return m_MaxCount;}
		set { m_MaxCount = value; }
	}


};
//删除邮件请求封装类
[System.Serializable]
public class MailRpcDelMailAskWraper
{

	//构造函数
	public MailRpcDelMailAskWraper()
	{
		m_UidList = new List<long>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_UidList = new List<long>();

	}

 	//转化成Protobuffer类型函数
	public MailRpcDelMailAsk ToPB()
	{
		MailRpcDelMailAsk v = new MailRpcDelMailAsk();
		for (int i=0; i<(int)m_UidList.Count; i++)
			v.UidList.Add( m_UidList[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcDelMailAsk v)
	{
        if (v == null)
            return;
		m_UidList.Clear();
		for( int i=0; i<v.UidList.Count; i++)
			m_UidList.Add(v.UidList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcDelMailAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcDelMailAsk pb = ProtoBuf.Serializer.Deserialize<MailRpcDelMailAsk>(protoMS);
		FromPB(pb);
		return true;
	}

	//UidList
	public List<long> m_UidList;
	public int SizeUidList()
	{
		return m_UidList.Count;
	}
	public List<long> GetUidList()
	{
		return m_UidList;
	}
	public long GetUidList(int Index)
	{
		if(Index<0 || Index>=(int)m_UidList.Count)
			return -1;
		return m_UidList[Index];
	}
	public void SetUidList( List<long> v )
	{
		m_UidList=v;
	}
	public void SetUidList( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_UidList.Count)
			return;
		m_UidList[Index] = v;
	}
	public void AddUidList( long v=-1 )
	{
		m_UidList.Add(v);
	}
	public void ClearUidList( )
	{
		m_UidList.Clear();
	}


};
//删除邮件回应封装类
[System.Serializable]
public class MailRpcDelMailReplyWraper
{

	//构造函数
	public MailRpcDelMailReplyWraper()
	{
		 m_Result = -9999;
		m_UidList = new List<long>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_UidList = new List<long>();

	}

 	//转化成Protobuffer类型函数
	public MailRpcDelMailReply ToPB()
	{
		MailRpcDelMailReply v = new MailRpcDelMailReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_UidList.Count; i++)
			v.UidList.Add( m_UidList[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcDelMailReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UidList.Clear();
		for( int i=0; i<v.UidList.Count; i++)
			m_UidList.Add(v.UidList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcDelMailReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcDelMailReply pb = ProtoBuf.Serializer.Deserialize<MailRpcDelMailReply>(protoMS);
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
	//UidList
	public List<long> m_UidList;
	public int SizeUidList()
	{
		return m_UidList.Count;
	}
	public List<long> GetUidList()
	{
		return m_UidList;
	}
	public long GetUidList(int Index)
	{
		if(Index<0 || Index>=(int)m_UidList.Count)
			return -1;
		return m_UidList[Index];
	}
	public void SetUidList( List<long> v )
	{
		m_UidList=v;
	}
	public void SetUidList( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_UidList.Count)
			return;
		m_UidList[Index] = v;
	}
	public void AddUidList( long v=-1 )
	{
		m_UidList.Add(v);
	}
	public void ClearUidList( )
	{
		m_UidList.Clear();
	}


};
//获得邮件内容请求封装类
[System.Serializable]
public class MailRpcOpenMailAskWraper
{

	//构造函数
	public MailRpcOpenMailAskWraper()
	{
		 m_UId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UId = -1;

	}

 	//转化成Protobuffer类型函数
	public MailRpcOpenMailAsk ToPB()
	{
		MailRpcOpenMailAsk v = new MailRpcOpenMailAsk();
		v.UId = m_UId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcOpenMailAsk v)
	{
        if (v == null)
            return;
		m_UId = v.UId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcOpenMailAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcOpenMailAsk pb = ProtoBuf.Serializer.Deserialize<MailRpcOpenMailAsk>(protoMS);
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


};
//获得邮件内容回应封装类
[System.Serializable]
public class MailRpcOpenMailReplyWraper
{

	//构造函数
	public MailRpcOpenMailReplyWraper()
	{
		 m_Result = -9999;
		 m_MailBody = new MailBodyObjWraper();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		 m_MailBody = new MailBodyObjWraper();

	}

 	//转化成Protobuffer类型函数
	public MailRpcOpenMailReply ToPB()
	{
		MailRpcOpenMailReply v = new MailRpcOpenMailReply();
		v.Result = m_Result;
		v.MailBody = m_MailBody.ToPB();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcOpenMailReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_MailBody.FromPB(v.MailBody);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcOpenMailReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcOpenMailReply pb = ProtoBuf.Serializer.Deserialize<MailRpcOpenMailReply>(protoMS);
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
	//邮件内容
	public MailBodyObjWraper m_MailBody;
	public MailBodyObjWraper MailBody
	{
		get { return m_MailBody;}
		set { m_MailBody = value; }
	}


};
//领取奖励请求封装类
[System.Serializable]
public class MailRpcGetRewardAskWraper
{

	//构造函数
	public MailRpcGetRewardAskWraper()
	{
		 m_UId = -1;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_UId = -1;

	}

 	//转化成Protobuffer类型函数
	public MailRpcGetRewardAsk ToPB()
	{
		MailRpcGetRewardAsk v = new MailRpcGetRewardAsk();
		v.UId = m_UId;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcGetRewardAsk v)
	{
        if (v == null)
            return;
		m_UId = v.UId;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcGetRewardAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcGetRewardAsk pb = ProtoBuf.Serializer.Deserialize<MailRpcGetRewardAsk>(protoMS);
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


};
//领取奖励回应封装类
[System.Serializable]
public class MailRpcGetRewardReplyWraper
{

	//构造函数
	public MailRpcGetRewardReplyWraper()
	{
		 m_Result = -9999;

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;

	}

 	//转化成Protobuffer类型函数
	public MailRpcGetRewardReply ToPB()
	{
		MailRpcGetRewardReply v = new MailRpcGetRewardReply();
		v.Result = m_Result;

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcGetRewardReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcGetRewardReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcGetRewardReply pb = ProtoBuf.Serializer.Deserialize<MailRpcGetRewardReply>(protoMS);
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
//获得新邮件通知封装类
[System.Serializable]
public class MailRpcNewMailNotifyWraper
{

	//构造函数
	public MailRpcNewMailNotifyWraper()
	{
		m_MailHeadList = new List<MailHeadObjWraper>();

	}

	//重置函数
	public void ResetWraper()
	{
		m_MailHeadList = new List<MailHeadObjWraper>();

	}

 	//转化成Protobuffer类型函数
	public MailRpcNewMailNotify ToPB()
	{
		MailRpcNewMailNotify v = new MailRpcNewMailNotify();
		for (int i=0; i<(int)m_MailHeadList.Count; i++)
			v.MailHeadList.Add( m_MailHeadList[i].ToPB());

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcNewMailNotify v)
	{
        if (v == null)
            return;
		m_MailHeadList.Clear();
		for( int i=0; i<v.MailHeadList.Count; i++)
			m_MailHeadList.Add( new MailHeadObjWraper());
		for( int i=0; i<v.MailHeadList.Count; i++)
			m_MailHeadList[i].FromPB(v.MailHeadList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcNewMailNotify>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcNewMailNotify pb = ProtoBuf.Serializer.Deserialize<MailRpcNewMailNotify>(protoMS);
		FromPB(pb);
		return true;
	}

	//邮件头信息列表
	public List<MailHeadObjWraper> m_MailHeadList;
	public int SizeMailHeadList()
	{
		return m_MailHeadList.Count;
	}
	public List<MailHeadObjWraper> GetMailHeadList()
	{
		return m_MailHeadList;
	}
	public MailHeadObjWraper GetMailHeadList(int Index)
	{
		if(Index<0 || Index>=(int)m_MailHeadList.Count)
			return new MailHeadObjWraper();
		return m_MailHeadList[Index];
	}
	public void SetMailHeadList( List<MailHeadObjWraper> v )
	{
		m_MailHeadList=v;
	}
	public void SetMailHeadList( int Index, MailHeadObjWraper v )
	{
		if(Index<0 || Index>=(int)m_MailHeadList.Count)
			return;
		m_MailHeadList[Index] = v;
	}
	public void AddMailHeadList( MailHeadObjWraper v )
	{
		m_MailHeadList.Add(v);
	}
	public void ClearMailHeadList( )
	{
		m_MailHeadList.Clear();
	}


};
//一键领取请求封装类
[System.Serializable]
public class MailRpcOneKeyGetRewardAskWraper
{

	//构造函数
	public MailRpcOneKeyGetRewardAskWraper()
	{

	}

	//重置函数
	public void ResetWraper()
	{

	}

 	//转化成Protobuffer类型函数
	public MailRpcOneKeyGetRewardAsk ToPB()
	{
		MailRpcOneKeyGetRewardAsk v = new MailRpcOneKeyGetRewardAsk();

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcOneKeyGetRewardAsk v)
	{
        if (v == null)
            return;

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcOneKeyGetRewardAsk>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcOneKeyGetRewardAsk pb = ProtoBuf.Serializer.Deserialize<MailRpcOneKeyGetRewardAsk>(protoMS);
		FromPB(pb);
		return true;
	}



};
//一键领取回应封装类
[System.Serializable]
public class MailRpcOneKeyGetRewardReplyWraper
{

	//构造函数
	public MailRpcOneKeyGetRewardReplyWraper()
	{
		 m_Result = -9999;
		m_UidList = new List<long>();

	}

	//重置函数
	public void ResetWraper()
	{
		 m_Result = -9999;
		m_UidList = new List<long>();

	}

 	//转化成Protobuffer类型函数
	public MailRpcOneKeyGetRewardReply ToPB()
	{
		MailRpcOneKeyGetRewardReply v = new MailRpcOneKeyGetRewardReply();
		v.Result = m_Result;
		for (int i=0; i<(int)m_UidList.Count; i++)
			v.UidList.Add( m_UidList[i]);

		return v;
	}
	
	//从Protobuffer类型初始化
	public void FromPB(MailRpcOneKeyGetRewardReply v)
	{
        if (v == null)
            return;
		m_Result = v.Result;
		m_UidList.Clear();
		for( int i=0; i<v.UidList.Count; i++)
			m_UidList.Add(v.UidList[i]);

	}
	
	//Protobuffer序列化到MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<MailRpcOneKeyGetRewardReply>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer从MemoryStream进行反序列化
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		MailRpcOneKeyGetRewardReply pb = ProtoBuf.Serializer.Deserialize<MailRpcOneKeyGetRewardReply>(protoMS);
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
	//UidList
	public List<long> m_UidList;
	public int SizeUidList()
	{
		return m_UidList.Count;
	}
	public List<long> GetUidList()
	{
		return m_UidList;
	}
	public long GetUidList(int Index)
	{
		if(Index<0 || Index>=(int)m_UidList.Count)
			return -1;
		return m_UidList[Index];
	}
	public void SetUidList( List<long> v )
	{
		m_UidList=v;
	}
	public void SetUidList( int Index, long v )
	{
		if(Index<0 || Index>=(int)m_UidList.Count)
			return;
		m_UidList[Index] = v;
	}
	public void AddUidList( long v=-1 )
	{
		m_UidList.Add(v);
	}
	public void ClearUidList( )
	{
		m_UidList.Clear();
	}


};
