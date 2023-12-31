// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Attributes.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtoDataTable {

  /// <summary>Holder for reflection information generated from Attributes.proto</summary>
  public static partial class AttributesReflection {

    #region Descriptor
    /// <summary>File descriptor for Attributes.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AttributesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBBdHRyaWJ1dGVzLnByb3RvEg5Qcm90b0RhdGFUYWJsZSKZAQoOQXR0cmli",
            "dXRlc0RhdGESCgoCSWQYASABKAUSDAoEVHlwZRgCIAEoBRIOCgZIZWFsdGgY",
            "AyABKAUSDgoGQXR0YWNrGAQgASgFEg8KB0RlZmVuc2UYBSABKAUSFQoNU3Bl",
            "Y2lhbEF0dGFjaxgGIAEoBRIWCg5TcGVjaWFsRGVmZW5zZRgHIAEoBRINCgVT",
            "cGVlZBgIIAEoBSJACg9BdHRyaWJ1dGVzVGFibGUSLQoFVGFibGUYASADKAsy",
            "Hi5Qcm90b0RhdGFUYWJsZS5BdHRyaWJ1dGVzRGF0YWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtoDataTable.AttributesData), global::ProtoDataTable.AttributesData.Parser, new[]{ "Id", "Type", "Health", "Attack", "Defense", "SpecialAttack", "SpecialDefense", "Speed" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtoDataTable.AttributesTable), global::ProtoDataTable.AttributesTable.Parser, new[]{ "Table" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AttributesData : pb::IMessage<AttributesData>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<AttributesData> _parser = new pb::MessageParser<AttributesData>(() => new AttributesData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<AttributesData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtoDataTable.AttributesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AttributesData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AttributesData(AttributesData other) : this() {
      id_ = other.id_;
      type_ = other.type_;
      health_ = other.health_;
      attack_ = other.attack_;
      defense_ = other.defense_;
      specialAttack_ = other.specialAttack_;
      specialDefense_ = other.specialDefense_;
      speed_ = other.speed_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AttributesData Clone() {
      return new AttributesData(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "Type" field.</summary>
    public const int TypeFieldNumber = 2;
    private int type_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "Health" field.</summary>
    public const int HealthFieldNumber = 3;
    private int health_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Health {
      get { return health_; }
      set {
        health_ = value;
      }
    }

    /// <summary>Field number for the "Attack" field.</summary>
    public const int AttackFieldNumber = 4;
    private int attack_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Attack {
      get { return attack_; }
      set {
        attack_ = value;
      }
    }

    /// <summary>Field number for the "Defense" field.</summary>
    public const int DefenseFieldNumber = 5;
    private int defense_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Defense {
      get { return defense_; }
      set {
        defense_ = value;
      }
    }

    /// <summary>Field number for the "SpecialAttack" field.</summary>
    public const int SpecialAttackFieldNumber = 6;
    private int specialAttack_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int SpecialAttack {
      get { return specialAttack_; }
      set {
        specialAttack_ = value;
      }
    }

    /// <summary>Field number for the "SpecialDefense" field.</summary>
    public const int SpecialDefenseFieldNumber = 7;
    private int specialDefense_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int SpecialDefense {
      get { return specialDefense_; }
      set {
        specialDefense_ = value;
      }
    }

    /// <summary>Field number for the "Speed" field.</summary>
    public const int SpeedFieldNumber = 8;
    private int speed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Speed {
      get { return speed_; }
      set {
        speed_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as AttributesData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(AttributesData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Type != other.Type) return false;
      if (Health != other.Health) return false;
      if (Attack != other.Attack) return false;
      if (Defense != other.Defense) return false;
      if (SpecialAttack != other.SpecialAttack) return false;
      if (SpecialDefense != other.SpecialDefense) return false;
      if (Speed != other.Speed) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Type != 0) hash ^= Type.GetHashCode();
      if (Health != 0) hash ^= Health.GetHashCode();
      if (Attack != 0) hash ^= Attack.GetHashCode();
      if (Defense != 0) hash ^= Defense.GetHashCode();
      if (SpecialAttack != 0) hash ^= SpecialAttack.GetHashCode();
      if (SpecialDefense != 0) hash ^= SpecialDefense.GetHashCode();
      if (Speed != 0) hash ^= Speed.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (Type != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Type);
      }
      if (Health != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Health);
      }
      if (Attack != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Attack);
      }
      if (Defense != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Defense);
      }
      if (SpecialAttack != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(SpecialAttack);
      }
      if (SpecialDefense != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(SpecialDefense);
      }
      if (Speed != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(Speed);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (Type != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Type);
      }
      if (Health != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Health);
      }
      if (Attack != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Attack);
      }
      if (Defense != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Defense);
      }
      if (SpecialAttack != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(SpecialAttack);
      }
      if (SpecialDefense != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(SpecialDefense);
      }
      if (Speed != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(Speed);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Type);
      }
      if (Health != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Health);
      }
      if (Attack != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Attack);
      }
      if (Defense != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Defense);
      }
      if (SpecialAttack != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SpecialAttack);
      }
      if (SpecialDefense != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SpecialDefense);
      }
      if (Speed != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Speed);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(AttributesData other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      if (other.Health != 0) {
        Health = other.Health;
      }
      if (other.Attack != 0) {
        Attack = other.Attack;
      }
      if (other.Defense != 0) {
        Defense = other.Defense;
      }
      if (other.SpecialAttack != 0) {
        SpecialAttack = other.SpecialAttack;
      }
      if (other.SpecialDefense != 0) {
        SpecialDefense = other.SpecialDefense;
      }
      if (other.Speed != 0) {
        Speed = other.Speed;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Id = input.ReadInt32();
            break;
          }
          case 16: {
            Type = input.ReadInt32();
            break;
          }
          case 24: {
            Health = input.ReadInt32();
            break;
          }
          case 32: {
            Attack = input.ReadInt32();
            break;
          }
          case 40: {
            Defense = input.ReadInt32();
            break;
          }
          case 48: {
            SpecialAttack = input.ReadInt32();
            break;
          }
          case 56: {
            SpecialDefense = input.ReadInt32();
            break;
          }
          case 64: {
            Speed = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Id = input.ReadInt32();
            break;
          }
          case 16: {
            Type = input.ReadInt32();
            break;
          }
          case 24: {
            Health = input.ReadInt32();
            break;
          }
          case 32: {
            Attack = input.ReadInt32();
            break;
          }
          case 40: {
            Defense = input.ReadInt32();
            break;
          }
          case 48: {
            SpecialAttack = input.ReadInt32();
            break;
          }
          case 56: {
            SpecialDefense = input.ReadInt32();
            break;
          }
          case 64: {
            Speed = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class AttributesTable : pb::IMessage<AttributesTable>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<AttributesTable> _parser = new pb::MessageParser<AttributesTable>(() => new AttributesTable());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<AttributesTable> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtoDataTable.AttributesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AttributesTable() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AttributesTable(AttributesTable other) : this() {
      table_ = other.table_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AttributesTable Clone() {
      return new AttributesTable(this);
    }

    /// <summary>Field number for the "Table" field.</summary>
    public const int TableFieldNumber = 1;
    private static readonly pb::FieldCodec<global::ProtoDataTable.AttributesData> _repeated_table_codec
        = pb::FieldCodec.ForMessage(10, global::ProtoDataTable.AttributesData.Parser);
    private readonly pbc::RepeatedField<global::ProtoDataTable.AttributesData> table_ = new pbc::RepeatedField<global::ProtoDataTable.AttributesData>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::ProtoDataTable.AttributesData> Table {
      get { return table_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as AttributesTable);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(AttributesTable other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!table_.Equals(other.table_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= table_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      table_.WriteTo(output, _repeated_table_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      table_.WriteTo(ref output, _repeated_table_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += table_.CalculateSize(_repeated_table_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(AttributesTable other) {
      if (other == null) {
        return;
      }
      table_.Add(other.table_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            table_.AddEntriesFrom(input, _repeated_table_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            table_.AddEntriesFrom(ref input, _repeated_table_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
