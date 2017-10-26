#ifndef __SYNC_DATA_$TEMPLATE$_V$SyncDataVersion$_H
#define __SYNC_DATA_$TEMPLATE$_V$SyncDataVersion$_H

#include "BASE.h"

#include "ModuleDataInterface.h"
#include "ModuleDataClassFactory.h"
#include "MsgStreamMgr.h"
#include "$Template$V$SyncDataVersion$DataWraper.h"


//ͬ���������ö��������
enum $Template$SyncDataItemIdE
{
$syncIds$
};


//��ͬ�����ݲ�����
class SyncData$Template$V$SyncDataVersion$ : public ModuleDataInterface , public ModuleDataRegister<SyncData$Template$V$SyncDataVersion$>
{
public:
			SyncData$Template$V$SyncDataVersion$();
	virtual	~SyncData$Template$V$SyncDataVersion$();
	void	SendAllMembers(bool OnlyToClient=true);
	string  ToHtml(){ return m_syncData$SyncDataName$.ToHtml(); }
	string  HtmlDescHeader() { return m_syncData$SyncDataName$.HtmlDescHeader(); }
$SyncOpDefine$

private:
	$SyncDataDefine$

};



#endif
