
	//���캯��
	public $WraperName$()
	{
$ConstructField$
	}

	//���ú���
	public void ResetWraper()
	{
$ConstructField$
	}

 	//ת����Protobuffer���ͺ���
	public $PBName$ ToPB()
	{
		$PBName$ v = new $PBName$();
$ToPBField$
		return v;
	}
	
	//��Protobuffer���ͳ�ʼ��
	public void FromPB($PBName$ v)
	{
        if (v == null)
            return;
$InitFuncField$
	}
	
	//Protobuffer���л���MemoryStream
	public MemoryStream ToMemoryStream()
	{
		MemoryStream protoMS = new MemoryStream();
		ProtoBuf.Serializer.Serialize<$PBName$>(protoMS, ToPB());
		return protoMS;
	}
	
	//Protobuffer��MemoryStream���з����л�
	public bool FromMemoryStream(MemoryStream protoMS)
	{
		$PBName$ pb = ProtoBuf.Serializer.Deserialize<$PBName$>(protoMS);
		FromPB(pb);
		return true;
	}

$GetSetSizeField$
