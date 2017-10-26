/********************************************************************************************
* Copyright (C), 2011-2025, AGAN Tech. Co., Ltd.
* FileName:     $Template$DBCache.cpp
* Author:       ��ҵ��
* Description:  $ModCName$������
* Version:      1.0
* History:
* <author>  <time>   <version >   <desc>
* 
********************************************************************************************/

#include "$Template$DBCache.h"
#include "BASE.h"


IMPLEMENT_INSTANCE(Data$Template$);

//$ModCName$ʵ���๹�캯��
Data$Template$::Data$Template$()
{
	m_mapDataWraperVersionName[$SyncDataVersion$] = "$Template$$DSName$WraperV$SyncDataVersion$";
	
}

//$ModCName$ʵ������������
Data$Template$::~Data$Template$()
{

}


//��ȡģ��ID
UINT8 Data$Template$::GetModuleId()
{
	return MODULE_ID_$TEMPLATE$;
}

//��ȡģ������
TStr Data$Template$::GetModuleName()
{
	return "$Template$";
}

//��ȡģ��ͬ��(����)���ݰ汾������
map<INT32,TStr> Data$Template$::GetDataWraperVersionName()
{

	return m_mapDataWraperVersionName;
}

//ģ��ͬ��(����)������������
bool Data$Template$::UpdateModuleData(ModuleDataInterface* pre, ModuleDataInterface* cur )
{
	
	return true;
}
//ģ�����ݱ�������
SavedDataTypeE	Data$Template$::GetSavedDataType()
{
	return $DataSaveType$;
}

//�Ƿ񱣴����ݵ����ݿ���
bool Data$Template$::IsSaveModuleDataToDB()
{

	return $SaveToDB$;
}

//��������֪ͨ
bool Data$Template$::OnIncrementUpdate( INT64 key, int syncId, int Index, const char* pBuffer, int dataLen )
{
	$Template$$DSName$WraperV$SyncDataVersion$* pDataWraper = ($Template$$DSName$WraperV$SyncDataVersion$*)GetModuleData(key);
	if( pDataWraper == NULL )
	{
		assert(false);
		return false;
	}
	
	INT64 lValue = 0;
	int   iValue = 0;
	
	switch (syncId)
	{
$DBCacheField$
	default:
		break;
	}
	pDataWraper->OnDataChange();
	lValue ++;
	iValue ++;
	return true;
}
