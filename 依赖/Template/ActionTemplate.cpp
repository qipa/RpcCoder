#include "Action.h"


#define  NEW_ACTION(_ACT, _ActType) case _ACT: { _ActType* pAction = new _ActType();pAction->Create(buf);return pAction; }
//�����л�
Action* Action::Deserialize(const string& buf)
{
	//ȡ�ö�������
	KernelActionE aType = (KernelActionE)buf[0];
	//���ݶ������ʹ�������ʵ��
	switch (aType)
	{
$NEW_ACTION$
	}
	return nullptr;
}
