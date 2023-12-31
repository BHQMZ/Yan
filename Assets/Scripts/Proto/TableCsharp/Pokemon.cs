// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Pokemon.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtoDataTable {

  /// <summary>Holder for reflection information generated from Pokemon.proto</summary>
  public static partial class PokemonReflection {

    #region Descriptor
    /// <summary>File descriptor for Pokemon.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PokemonReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg1Qb2tlbW9uLnByb3RvEg5Qcm90b0RhdGFUYWJsZSKsAQoLUG9rZW1vbkRh",
            "dGESCgoCSWQYASABKAUSDAoETmFtZRgCIAEoCRIOCgZTa2lsbDEYAyABKAUS",
            "DgoGU2tpbGwyGAQgASgFEg4KBlNraWxsMxgFIAEoBRIOCgZTa2lsbDQYBiAB",
            "KAUSFAoMQXR0cmlidXRlc0lkGAcgASgFEhEKCUNoYXJhY3RlchgIIAEoCRIM",
            "CgRTaXplGAkgASgCEgwKBEljb24YCiABKAkiOgoMUG9rZW1vblRhYmxlEioK",
            "BVRhYmxlGAEgAygLMhsuUHJvdG9EYXRhVGFibGUuUG9rZW1vbkRhdGFiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtoDataTable.PokemonData), global::ProtoDataTable.PokemonData.Parser, new[]{ "Id", "Name", "Skill1", "Skill2", "Skill3", "Skill4", "AttributesId", "Character", "Size", "Icon" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtoDataTable.PokemonTable), global::ProtoDataTable.PokemonTable.Parser, new[]{ "Table" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PokemonData : pb::IMessage<PokemonData>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PokemonData> _parser = new pb::MessageParser<PokemonData>(() => new PokemonData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PokemonData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtoDataTable.PokemonReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PokemonData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PokemonData(PokemonData other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      skill1_ = other.skill1_;
      skill2_ = other.skill2_;
      skill3_ = other.skill3_;
      skill4_ = other.skill4_;
      attributesId_ = other.attributesId_;
      character_ = other.character_;
      size_ = other.size_;
      icon_ = other.icon_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PokemonData Clone() {
      return new PokemonData(this);
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

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Skill1" field.</summary>
    public const int Skill1FieldNumber = 3;
    private int skill1_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Skill1 {
      get { return skill1_; }
      set {
        skill1_ = value;
      }
    }

    /// <summary>Field number for the "Skill2" field.</summary>
    public const int Skill2FieldNumber = 4;
    private int skill2_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Skill2 {
      get { return skill2_; }
      set {
        skill2_ = value;
      }
    }

    /// <summary>Field number for the "Skill3" field.</summary>
    public const int Skill3FieldNumber = 5;
    private int skill3_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Skill3 {
      get { return skill3_; }
      set {
        skill3_ = value;
      }
    }

    /// <summary>Field number for the "Skill4" field.</summary>
    public const int Skill4FieldNumber = 6;
    private int skill4_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Skill4 {
      get { return skill4_; }
      set {
        skill4_ = value;
      }
    }

    /// <summary>Field number for the "AttributesId" field.</summary>
    public const int AttributesIdFieldNumber = 7;
    private int attributesId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int AttributesId {
      get { return attributesId_; }
      set {
        attributesId_ = value;
      }
    }

    /// <summary>Field number for the "Character" field.</summary>
    public const int CharacterFieldNumber = 8;
    private string character_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Character {
      get { return character_; }
      set {
        character_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Size" field.</summary>
    public const int SizeFieldNumber = 9;
    private float size_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float Size {
      get { return size_; }
      set {
        size_ = value;
      }
    }

    /// <summary>Field number for the "Icon" field.</summary>
    public const int IconFieldNumber = 10;
    private string icon_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Icon {
      get { return icon_; }
      set {
        icon_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PokemonData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PokemonData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (Skill1 != other.Skill1) return false;
      if (Skill2 != other.Skill2) return false;
      if (Skill3 != other.Skill3) return false;
      if (Skill4 != other.Skill4) return false;
      if (AttributesId != other.AttributesId) return false;
      if (Character != other.Character) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Size, other.Size)) return false;
      if (Icon != other.Icon) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Skill1 != 0) hash ^= Skill1.GetHashCode();
      if (Skill2 != 0) hash ^= Skill2.GetHashCode();
      if (Skill3 != 0) hash ^= Skill3.GetHashCode();
      if (Skill4 != 0) hash ^= Skill4.GetHashCode();
      if (AttributesId != 0) hash ^= AttributesId.GetHashCode();
      if (Character.Length != 0) hash ^= Character.GetHashCode();
      if (Size != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Size);
      if (Icon.Length != 0) hash ^= Icon.GetHashCode();
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
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Skill1 != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Skill1);
      }
      if (Skill2 != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Skill2);
      }
      if (Skill3 != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Skill3);
      }
      if (Skill4 != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Skill4);
      }
      if (AttributesId != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(AttributesId);
      }
      if (Character.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Character);
      }
      if (Size != 0F) {
        output.WriteRawTag(77);
        output.WriteFloat(Size);
      }
      if (Icon.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(Icon);
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
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Skill1 != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Skill1);
      }
      if (Skill2 != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Skill2);
      }
      if (Skill3 != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Skill3);
      }
      if (Skill4 != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Skill4);
      }
      if (AttributesId != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(AttributesId);
      }
      if (Character.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Character);
      }
      if (Size != 0F) {
        output.WriteRawTag(77);
        output.WriteFloat(Size);
      }
      if (Icon.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(Icon);
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
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Skill1 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Skill1);
      }
      if (Skill2 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Skill2);
      }
      if (Skill3 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Skill3);
      }
      if (Skill4 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Skill4);
      }
      if (AttributesId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(AttributesId);
      }
      if (Character.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Character);
      }
      if (Size != 0F) {
        size += 1 + 4;
      }
      if (Icon.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Icon);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PokemonData other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Skill1 != 0) {
        Skill1 = other.Skill1;
      }
      if (other.Skill2 != 0) {
        Skill2 = other.Skill2;
      }
      if (other.Skill3 != 0) {
        Skill3 = other.Skill3;
      }
      if (other.Skill4 != 0) {
        Skill4 = other.Skill4;
      }
      if (other.AttributesId != 0) {
        AttributesId = other.AttributesId;
      }
      if (other.Character.Length != 0) {
        Character = other.Character;
      }
      if (other.Size != 0F) {
        Size = other.Size;
      }
      if (other.Icon.Length != 0) {
        Icon = other.Icon;
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
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            Skill1 = input.ReadInt32();
            break;
          }
          case 32: {
            Skill2 = input.ReadInt32();
            break;
          }
          case 40: {
            Skill3 = input.ReadInt32();
            break;
          }
          case 48: {
            Skill4 = input.ReadInt32();
            break;
          }
          case 56: {
            AttributesId = input.ReadInt32();
            break;
          }
          case 66: {
            Character = input.ReadString();
            break;
          }
          case 77: {
            Size = input.ReadFloat();
            break;
          }
          case 82: {
            Icon = input.ReadString();
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
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            Skill1 = input.ReadInt32();
            break;
          }
          case 32: {
            Skill2 = input.ReadInt32();
            break;
          }
          case 40: {
            Skill3 = input.ReadInt32();
            break;
          }
          case 48: {
            Skill4 = input.ReadInt32();
            break;
          }
          case 56: {
            AttributesId = input.ReadInt32();
            break;
          }
          case 66: {
            Character = input.ReadString();
            break;
          }
          case 77: {
            Size = input.ReadFloat();
            break;
          }
          case 82: {
            Icon = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class PokemonTable : pb::IMessage<PokemonTable>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PokemonTable> _parser = new pb::MessageParser<PokemonTable>(() => new PokemonTable());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PokemonTable> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtoDataTable.PokemonReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PokemonTable() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PokemonTable(PokemonTable other) : this() {
      table_ = other.table_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PokemonTable Clone() {
      return new PokemonTable(this);
    }

    /// <summary>Field number for the "Table" field.</summary>
    public const int TableFieldNumber = 1;
    private static readonly pb::FieldCodec<global::ProtoDataTable.PokemonData> _repeated_table_codec
        = pb::FieldCodec.ForMessage(10, global::ProtoDataTable.PokemonData.Parser);
    private readonly pbc::RepeatedField<global::ProtoDataTable.PokemonData> table_ = new pbc::RepeatedField<global::ProtoDataTable.PokemonData>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::ProtoDataTable.PokemonData> Table {
      get { return table_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PokemonTable);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PokemonTable other) {
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
    public void MergeFrom(PokemonTable other) {
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
