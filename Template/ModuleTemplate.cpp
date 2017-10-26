/********************************************************************************************
* Copyright (C), 2011-2025, AGAN Tech. Co., Ltd.
* FileName:     Module$Template$.cpp
* Author:       ��ҵ��
* Description:  $ModCName$�࣬������������
*               ��ģ�������Ϣ����
*               ���ʼ�������ص�����
*               ��ʱ���൱�ص�����
*               ���û����������߻ص�����
*               ��ģ�������޸ļ�ͬ���ص�����
* Version:      1.0
* History:
* <author>  <time>   <version >   <desc>
* 
********************************************************************************************/

#include "$Template$Module.h"
#include "BASE.h"
#include "MsgIdMgr.h"


IMPLEMENT_INSTANCE(Module$Template$);

//$ModCName$ʵ���๹�캯��
Module$Template$::Module$Template$()
{

$CliOperationImpl$

	
	m_mapSyncDataVersionName[$SyncDataVersion$] = "SyncData$Template$V$SyncDataVersion$";
		
}

//$ModCName$ʵ������������
Module$Template$::~Module$Template$()
{

}


//��ȡģ��ID
UINT8 Module$Template$::GetModuleId()
{
	return MODULE_ID_$TEMPLATE$;
}

//��ȡģ������
TStr Module$Template$::GetModuleName()
{
	return "$Template$";
}

//��ȡģ��ͬ��(����)���ݰ汾������
map<INT32,TStr> Module$Template$::GetModuleDataVersionName()
{

	return m_mapSyncDataVersionName;
}

//ģ�����ݱ�������
SavedDataTypeE	Module$Template$::GetSavedDataType()
{
	return $DataSaveType$;
}


//��ȡ��ʼ��˳��
int	Module$Template$::GetInitializeOrder()
{
	return MODULE_ID_$TEMPLATE$;
}

//��ȡ�����˳�˳��
int Module$Template$::GetFinalizeOrder()
{
	return MODULE_ID_$TEMPLATE$;
}

//��ʼ��
bool Module$Template$::Initialize()
{

$LoadConfig$	

	return true;
}

//�����˳�
void Module$Template$::Finalize()
{

}


//���뼶Tick�ص�
void Module$Template$::OnTick( INT64 currentMiliSecond )
{

}

//�뼶Tick�ص�
void Module$Template$::OnSecondTick( time_t currentSecond )
{

}

//���Ӹı�ص�
void Module$Template$::OnMinuteChange( time_t currentSecond)
{

}

//Сʱ�ı�ص�
void Module$Template$::OnHourChange( time_t currentSecond )
{

}

//��ı�ص�
void Module$Template$::OnDayChange( time_t currentSecond )
{

}

//�����û��ص�
void Module$Template$::OnUserCreate( INT64 userId, const TStr& userName )
{

}

//�û����߻ص�
void Module$Template$::OnUserOnline( INT64 userId, time_t lastLogoutTime )
{

}

//�û����߻ص�
void Module$Template$::OnUserOffline( INT64 userId )
{

}

//�Ƿ�Ҫͬ�����ݵ��ͻ���
bool Module$Template$::NotSyncToClient( UINT16 usSyncId )
{

	return false;
}

//ͬ�������޸ĺ�ص�
void Module$Template$::NotifySyncValueChanged(INT64 Key,UINT16 usSyncId, int nIndex)
{

}

