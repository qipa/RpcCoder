//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ShopV1Data.proto
// Note: requires additional types generated from: PublicStruct.proto
namespace GenPB
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ShopShopDataV1")]
  public partial class ShopShopDataV1 : global::ProtoBuf.IExtensible
  {
    public ShopShopDataV1() {}
    
    private readonly global::System.Collections.Generic.List<ShopShopObjV1> _ShopArray = new global::System.Collections.Generic.List<ShopShopObjV1>();
    [global::ProtoBuf.ProtoMember(1, Name=@"ShopArray", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ShopShopObjV1> ShopArray
    {
      get { return _ShopArray; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ShopShopObjV1")]
  public partial class ShopShopObjV1 : global::ProtoBuf.IExtensible
  {
    public ShopShopObjV1() {}
    
    private int _ShopType = (int)-1;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"ShopType", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int ShopType
    {
      get { return _ShopType; }
      set { _ShopType = value; }
    }
    private readonly global::System.Collections.Generic.List<ShopItemObjV1> _ItemArray = new global::System.Collections.Generic.List<ShopItemObjV1>();
    [global::ProtoBuf.ProtoMember(3, Name=@"ItemArray", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ShopItemObjV1> ItemArray
    {
      get { return _ItemArray; }
    }
  
    private long _LastRefreshTime = (long)-1;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"LastRefreshTime", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((long)-1)]
    public long LastRefreshTime
    {
      get { return _LastRefreshTime; }
      set { _LastRefreshTime = value; }
    }
    private int _RefreshTimes = (int)-1;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"RefreshTimes", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int RefreshTimes
    {
      get { return _RefreshTimes; }
      set { _RefreshTimes = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ShopItemObjV1")]
  public partial class ShopItemObjV1 : global::ProtoBuf.IExtensible
  {
    public ShopItemObjV1() {}
    
    private int _ItemId = (int)-1;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ItemId", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int ItemId
    {
      get { return _ItemId; }
      set { _ItemId = value; }
    }
    private int _Count = (int)-1;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"Count", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int Count
    {
      get { return _Count; }
      set { _Count = value; }
    }
    private int _Pos = (int)-1;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"Pos", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int Pos
    {
      get { return _Pos; }
      set { _Pos = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}