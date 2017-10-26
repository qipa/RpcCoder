/********************************************************************************************
* Copyright (C), 2011-2025, AGAN Tech. Co., Ltd.
* FileName:     $Template$DBCache.h
* Author:       ��ҵ��
* Description:  $ModCName$������
* Version:      1.0
* History:
* <author>  <time>   <version >   <desc>
* 
********************************************************************************************/

#ifndef __DATA_$TEMPLATE$_H
#define __DATA_$TEMPLATE$_H


#include "ModuleData.h"
$DBCacheSyncDataHeader$

//ͬ���������ö��������
enum DataWraperItemIdE
{
	MODULE_ID_$TEMPLATE$ = $ModId$,
$syncIds$
};


//$ModCName$������
class Data$Template$ : public ModuleData
{
	DECLARE_INSTANCE(Data$Template$);
public:
	friend class			ModuleDataMgr;

public:
	//$ModCName$ʵ���๹�캯��
	Data$Template$();
	
	//$ModCName$ʵ������������
	virtual					~Data$Template$();

	//��ȡģ��ID
	virtual	UINT8			GetModuleId();
	
	//��ȡģ������
	virtual	TStr			GetModuleName();
	
	//��ȡģ��ͬ��(����)���ݰ汾������
	virtual map<INT32,TStr>	GetDataWraperVersionName();
	
	//ģ�����ݱ�������
	virtual SavedDataTypeE	GetSavedDataType();

	//�Ƿ񱣴����ݵ����ݿ���
	virtual bool			IsSaveModuleDataToDB();

	//ģ��ͬ��(����)������������
	virtual bool			UpdateModuleData(ModuleDataInterface* pre, ModuleDataInterface* cur );
	
	//��������֪ͨ
	virtual bool			OnIncrementUpdate( INT64 key, int syncId, int IndexPos, const char* pBuffer, int dataLen );


private:
	 map<INT32,TStr>		m_mapDataWraperVersionName;
};

#endif