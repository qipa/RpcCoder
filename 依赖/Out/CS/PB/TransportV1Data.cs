//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: TransportV1Data.proto
// Note: requires additional types generated from: PublicStruct.proto
namespace GenPB
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TransportGoodsDataV1")]
  public partial class TransportGoodsDataV1 : global::ProtoBuf.IExtensible
  {
    public TransportGoodsDataV1() {}
    
    private readonly global::System.Collections.Generic.List<TransportGoodsObjV1> _GoodsArray = new global::System.Collections.Generic.List<TransportGoodsObjV1>();
    [global::ProtoBuf.ProtoMember(1, Name=@"GoodsArray", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<TransportGoodsObjV1> GoodsArray
    {
      get { return _GoodsArray; }
    }
  
    private int _AskNum = (int)-1;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"AskNum", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int AskNum
    {
      get { return _AskNum; }
      set { _AskNum = value; }
    }
    private int _HelpNum = (int)-1;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"HelpNum", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int HelpNum
    {
      get { return _HelpNum; }
      set { _HelpNum = value; }
    }
    private readonly global::System.Collections.Generic.List<TransportRewardObjV1> _RewardArry = new global::System.Collections.Generic.List<TransportRewardObjV1>();
    [global::ProtoBuf.ProtoMember(4, Name=@"RewardArry", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<TransportRewardObjV1> RewardArry
    {
      get { return _RewardArry; }
    }
  
    private bool _RewardFlag = (bool)false;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"RewardFlag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool RewardFlag
    {
      get { return _RewardFlag; }
      set { _RewardFlag = value; }
    }
    private bool _PickTaskFlag = (bool)false;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"PickTaskFlag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool PickTaskFlag
    {
      get { return _PickTaskFlag; }
      set { _PickTaskFlag = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TransportGoodsObjV1")]
  public partial class TransportGoodsObjV1 : global::ProtoBuf.IExtensible
  {
    public TransportGoodsObjV1() {}
    
    private int _GoodId = (int)-1;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"GoodId", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int GoodId
    {
      get { return _GoodId; }
      set { _GoodId = value; }
    }
    private int _TemplateId = (int)-1;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"TemplateId", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int TemplateId
    {
      get { return _TemplateId; }
      set { _TemplateId = value; }
    }
    private int _ItemNum = (int)-1;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"ItemNum", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int ItemNum
    {
      get { return _ItemNum; }
      set { _ItemNum = value; }
    }
    private int _CateGory = (int)-1;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"CateGory", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int CateGory
    {
      get { return _CateGory; }
      set { _CateGory = value; }
    }
    private bool _IsHelp = (bool)false;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"IsHelp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool IsHelp
    {
      get { return _IsHelp; }
      set { _IsHelp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TransportRewardObjV1")]
  public partial class TransportRewardObjV1 : global::ProtoBuf.IExtensible
  {
    public TransportRewardObjV1() {}
    
    private int _RewardId = (int)-1;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"RewardId", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int RewardId
    {
      get { return _RewardId; }
      set { _RewardId = value; }
    }
    private int _LV = (int)-1;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"LV", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int LV
    {
      get { return _LV; }
      set { _LV = value; }
    }
    private int _GoodType = (int)-1;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"GoodType", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int GoodType
    {
      get { return _GoodType; }
      set { _GoodType = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}