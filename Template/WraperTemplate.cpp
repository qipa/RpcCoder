
//$CNName$��װ��
class $WraperName$ : public DataWraperInterface $ModuleDataWraperDef$
{
public:
	//���캯��
	$WraperName$()
	{
		$ModuleDataSetWraper$
$ConstructField$
	}
	//��ֵ���캯��
	$WraperName$(const $PBName$& v){ Init(v); }
	//�Ⱥ����غ���
	void operator = (const $PBName$& v){ Init(v); }
 	//ת����Protobuffer���ͺ���
	$PBName$ ToPB() const
	{
		$PBName$ v;
$ToPBField$
		return v;
	}
	//��ȡProtobuffer���л����С����
	int ByteSize() const { return ToPB().ByteSize();}
	//Protobuffer���л���������
	bool SerializeToArray( void* data, int size ) const
	{
		return ToPB().SerializeToArray(data,size);
	}
	//Protobuffer���л����ַ���
	string SerializeAsString() const
	{
		return ToPB().SerializeAsString();
	}
	//Protobuffer���ַ������з����л�
	bool ParseFromString(const string& v)
	{
		return ParseFromArray(v.data(),v.size());
	}
	//Protobuffer�ӻ��������з����л�
	bool ParseFromArray(const void* data, int size)
	{
		$PBName$ pb;
		if(!pb.ParseFromArray(data,size)){return false;}
		Init(pb);
		return true;
	}

	string HtmlDescHeader()
	{
		string htmlBuff = "<div style=\"padding-left:30px\">\r\n";
$HtmlFieldHeader$
		
		htmlBuff += "</div>\r\n";
		return htmlBuff;
	}

	string ToHtml()
	{
		string htmlBuff = "<div style=\"padding-left:30px\">\r\n";
		TStr tmpLine;
$htmlField$
		
		htmlBuff += "</div>\r\n";
		return htmlBuff;
	}


private:
	//��Protobuffer���ͳ�ʼ��
	void Init(const $PBName$& v)
	{
$InitFuncField$
	}

$GetSetSizeField$
};