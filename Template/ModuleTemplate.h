/********************************************************************************************
* Copyright (C), 2011-2025, AGAN Tech. Co., Ltd.
* FileName:     Module$Template$.h
* Author:       ��ҵ��
* Description:  $ModCName$�࣬������������
*               ��ģ�������Ϣ����
*               ���ʼ�������ص�����
*               ��ʱ���൱�ص�����
*               ���û����������߻ص�����
*               ��ģ�������޸ļ�ͬ���ص�����
*               ���������̨RPC����
*               ��ͻ���RPC����
* Version:      1.0
* History:
* <author>  <time>   <version >   <desc>
* 
********************************************************************************************/

#ifndef __MODULE_$TEMPLATE$_H
#define __MODULE_$TEMPLATE$_H


#include "ModuleBase.h"
#include "$Template$RpcWraper.h"
$IncludeSyncDataHeader$
$HeaderConfig$


//$ModCName$ʵ����
class Module$Template$ : public ModuleBase
{
	DECLARE_INSTANCE(Module$Template$);
public:
	friend class			ModuleMgr;

public:
	//$ModCName$ʵ���๹�캯��
	Module$Template$();
	
	//$ModCName$ʵ������������
	virtual					~Module$Template$();

	//��ȡģ��ID
	virtual	UINT8			GetModuleId();
	
	//��ȡģ������
	virtual	TStr			GetModuleName();
	
	//��ȡģ��ͬ��(����)���ݰ汾������
	virtual map<INT32,TStr>	GetModuleDataVersionName();
	
	//ģ�����ݱ�������
	virtual SavedDataTypeE	GetSavedDataType();

	//��ȡ��ʼ��˳��
	virtual int				GetInitializeOrder();
	
	//��ȡ�����˳�˳��
	virtual int				GetFinalizeOrder();
	
	//��ʼ��
	virtual bool			Initialize();
	
	//�����˳�
	virtual void			Finalize();

	//���뼶Tick�ص�
	virtual void			OnTick( INT64 currentMiliSecond );
	
	//�뼶Tick�ص�
	virtual void			OnSecondTick( time_t currentSecond );
	
	//���Ӹı�ص�
	virtual void			OnMinuteChange( time_t currentSecond);
	
	//Сʱ�ı�ص�
	virtual void			OnHourChange( time_t currentSecond );
	
	//��ı�ص�
	virtual void			OnDayChange( time_t currentSecond );

	//�����û��ص�
	virtual void			OnUserCreate( INT64 userId, const TStr& userName );
	
	//�û����߻ص�
	virtual void			OnUserOnline( INT64 userId, time_t lastLogoutTime );
	
	//�û����߻ص�
	virtual void			OnUserOffline( INT64 userId );

	//�Ƿ�Ҫͬ�����ݵ��ͻ���
	virtual bool			NotSyncToClient( UINT16 usSyncId );
	
	//ͬ�������޸ĺ�ص�
	virtual void			NotifySyncValueChanged(INT64 Key,UINT16 usSyncId, int nIndex=-1);

public:
$CliOperationDeclare$

private:
	 map<INT32,TStr>		m_mapSyncDataVersionName;
};

#endif