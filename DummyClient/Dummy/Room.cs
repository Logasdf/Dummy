// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: room.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.Packet.Room {

  /// <summary>Holder for reflection information generated from room.proto</summary>
  public static partial class RoomReflection {

    #region Descriptor
    /// <summary>File descriptor for room.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RoomReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgpyb29tLnByb3RvEgZwYWNrZXQiRwoGQ2xpZW50Eg4KBmNsbnRJZBgBIAEo",
            "BRIMCgRuYW1lGAIgASgJEhAKCHBvc2l0aW9uGAMgASgFEg0KBXJlYWR5GAQg",
            "ASgIIq0BCghSb29tSW5mbxIOCgZyb29tSWQYASABKAUSDAoEbmFtZRgCIAEo",
            "CRINCgVsaW1pdBgDIAEoBRIPCgdjdXJyZW50GAQgASgFEh8KB3JlZFRlYW0Y",
            "BSADKAsyDi5wYWNrZXQuQ2xpZW50EiAKCGJsdWVUZWFtGAYgAygLMg4ucGFj",
            "a2V0LkNsaWVudBISCgpyZWFkeUNvdW50GAcgASgFEgwKBGhvc3QYCCABKAUi",
            "dgoIUm9vbUxpc3QSKgoFcm9vbXMYASADKAsyGy5wYWNrZXQuUm9vbUxpc3Qu",
            "Um9vbXNFbnRyeRo+CgpSb29tc0VudHJ5EgsKA2tleRgBIAEoBRIfCgV2YWx1",
            "ZRgCIAEoCzIQLnBhY2tldC5Sb29tSW5mbzoCOAFCHqoCG0dvb2dsZS5Qcm90",
            "b2J1Zi5QYWNrZXQuUm9vbWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Packet.Room.Client), global::Google.Protobuf.Packet.Room.Client.Parser, new[]{ "ClntId", "Name", "Position", "Ready" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Packet.Room.RoomInfo), global::Google.Protobuf.Packet.Room.RoomInfo.Parser, new[]{ "RoomId", "Name", "Limit", "Current", "RedTeam", "BlueTeam", "ReadyCount", "Host" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Packet.Room.RoomList), global::Google.Protobuf.Packet.Room.RoomList.Parser, new[]{ "Rooms" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Client : pb::IMessage<Client> {
    private static readonly pb::MessageParser<Client> _parser = new pb::MessageParser<Client>(() => new Client());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Client> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Packet.Room.RoomReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Client() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Client(Client other) : this() {
      clntId_ = other.clntId_;
      name_ = other.name_;
      position_ = other.position_;
      ready_ = other.ready_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Client Clone() {
      return new Client(this);
    }

    /// <summary>Field number for the "clntId" field.</summary>
    public const int ClntIdFieldNumber = 1;
    private int clntId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ClntId {
      get { return clntId_; }
      set {
        clntId_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "position" field.</summary>
    public const int PositionFieldNumber = 3;
    private int position_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Position {
      get { return position_; }
      set {
        position_ = value;
      }
    }

    /// <summary>Field number for the "ready" field.</summary>
    public const int ReadyFieldNumber = 4;
    private bool ready_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Ready {
      get { return ready_; }
      set {
        ready_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Client);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Client other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ClntId != other.ClntId) return false;
      if (Name != other.Name) return false;
      if (Position != other.Position) return false;
      if (Ready != other.Ready) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ClntId != 0) hash ^= ClntId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Position != 0) hash ^= Position.GetHashCode();
      if (Ready != false) hash ^= Ready.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ClntId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ClntId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Position != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Position);
      }
      if (Ready != false) {
        output.WriteRawTag(32);
        output.WriteBool(Ready);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ClntId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ClntId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Position != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Position);
      }
      if (Ready != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Client other) {
      if (other == null) {
        return;
      }
      if (other.ClntId != 0) {
        ClntId = other.ClntId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Position != 0) {
        Position = other.Position;
      }
      if (other.Ready != false) {
        Ready = other.Ready;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ClntId = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            Position = input.ReadInt32();
            break;
          }
          case 32: {
            Ready = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RoomInfo : pb::IMessage<RoomInfo> {
    private static readonly pb::MessageParser<RoomInfo> _parser = new pb::MessageParser<RoomInfo>(() => new RoomInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Packet.Room.RoomReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomInfo(RoomInfo other) : this() {
      roomId_ = other.roomId_;
      name_ = other.name_;
      limit_ = other.limit_;
      current_ = other.current_;
      redTeam_ = other.redTeam_.Clone();
      blueTeam_ = other.blueTeam_.Clone();
      readyCount_ = other.readyCount_;
      host_ = other.host_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomInfo Clone() {
      return new RoomInfo(this);
    }

    /// <summary>Field number for the "roomId" field.</summary>
    public const int RoomIdFieldNumber = 1;
    private int roomId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int RoomId {
      get { return roomId_; }
      set {
        roomId_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "limit" field.</summary>
    public const int LimitFieldNumber = 3;
    private int limit_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Limit {
      get { return limit_; }
      set {
        limit_ = value;
      }
    }

    /// <summary>Field number for the "current" field.</summary>
    public const int CurrentFieldNumber = 4;
    private int current_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Current {
      get { return current_; }
      set {
        current_ = value;
      }
    }

    /// <summary>Field number for the "redTeam" field.</summary>
    public const int RedTeamFieldNumber = 5;
    private static readonly pb::FieldCodec<global::Google.Protobuf.Packet.Room.Client> _repeated_redTeam_codec
        = pb::FieldCodec.ForMessage(42, global::Google.Protobuf.Packet.Room.Client.Parser);
    private readonly pbc::RepeatedField<global::Google.Protobuf.Packet.Room.Client> redTeam_ = new pbc::RepeatedField<global::Google.Protobuf.Packet.Room.Client>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Protobuf.Packet.Room.Client> RedTeam {
      get { return redTeam_; }
    }

    /// <summary>Field number for the "blueTeam" field.</summary>
    public const int BlueTeamFieldNumber = 6;
    private static readonly pb::FieldCodec<global::Google.Protobuf.Packet.Room.Client> _repeated_blueTeam_codec
        = pb::FieldCodec.ForMessage(50, global::Google.Protobuf.Packet.Room.Client.Parser);
    private readonly pbc::RepeatedField<global::Google.Protobuf.Packet.Room.Client> blueTeam_ = new pbc::RepeatedField<global::Google.Protobuf.Packet.Room.Client>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Protobuf.Packet.Room.Client> BlueTeam {
      get { return blueTeam_; }
    }

    /// <summary>Field number for the "readyCount" field.</summary>
    public const int ReadyCountFieldNumber = 7;
    private int readyCount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ReadyCount {
      get { return readyCount_; }
      set {
        readyCount_ = value;
      }
    }

    /// <summary>Field number for the "host" field.</summary>
    public const int HostFieldNumber = 8;
    private int host_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Host {
      get { return host_; }
      set {
        host_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoomInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoomInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RoomId != other.RoomId) return false;
      if (Name != other.Name) return false;
      if (Limit != other.Limit) return false;
      if (Current != other.Current) return false;
      if(!redTeam_.Equals(other.redTeam_)) return false;
      if(!blueTeam_.Equals(other.blueTeam_)) return false;
      if (ReadyCount != other.ReadyCount) return false;
      if (Host != other.Host) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RoomId != 0) hash ^= RoomId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Limit != 0) hash ^= Limit.GetHashCode();
      if (Current != 0) hash ^= Current.GetHashCode();
      hash ^= redTeam_.GetHashCode();
      hash ^= blueTeam_.GetHashCode();
      if (ReadyCount != 0) hash ^= ReadyCount.GetHashCode();
      if (Host != 0) hash ^= Host.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RoomId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(RoomId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Limit != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Limit);
      }
      if (Current != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Current);
      }
      redTeam_.WriteTo(output, _repeated_redTeam_codec);
      blueTeam_.WriteTo(output, _repeated_blueTeam_codec);
      if (ReadyCount != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(ReadyCount);
      }
      if (Host != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(Host);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RoomId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(RoomId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Limit != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Limit);
      }
      if (Current != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Current);
      }
      size += redTeam_.CalculateSize(_repeated_redTeam_codec);
      size += blueTeam_.CalculateSize(_repeated_blueTeam_codec);
      if (ReadyCount != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ReadyCount);
      }
      if (Host != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Host);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoomInfo other) {
      if (other == null) {
        return;
      }
      if (other.RoomId != 0) {
        RoomId = other.RoomId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Limit != 0) {
        Limit = other.Limit;
      }
      if (other.Current != 0) {
        Current = other.Current;
      }
      redTeam_.Add(other.redTeam_);
      blueTeam_.Add(other.blueTeam_);
      if (other.ReadyCount != 0) {
        ReadyCount = other.ReadyCount;
      }
      if (other.Host != 0) {
        Host = other.Host;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RoomId = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            Limit = input.ReadInt32();
            break;
          }
          case 32: {
            Current = input.ReadInt32();
            break;
          }
          case 42: {
            redTeam_.AddEntriesFrom(input, _repeated_redTeam_codec);
            break;
          }
          case 50: {
            blueTeam_.AddEntriesFrom(input, _repeated_blueTeam_codec);
            break;
          }
          case 56: {
            ReadyCount = input.ReadInt32();
            break;
          }
          case 64: {
            Host = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RoomList : pb::IMessage<RoomList> {
    private static readonly pb::MessageParser<RoomList> _parser = new pb::MessageParser<RoomList>(() => new RoomList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Packet.Room.RoomReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomList(RoomList other) : this() {
      rooms_ = other.rooms_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomList Clone() {
      return new RoomList(this);
    }

    /// <summary>Field number for the "rooms" field.</summary>
    public const int RoomsFieldNumber = 1;
    private static readonly pbc::MapField<int, global::Google.Protobuf.Packet.Room.RoomInfo>.Codec _map_rooms_codec
        = new pbc::MapField<int, global::Google.Protobuf.Packet.Room.RoomInfo>.Codec(pb::FieldCodec.ForInt32(8), pb::FieldCodec.ForMessage(18, global::Google.Protobuf.Packet.Room.RoomInfo.Parser), 10);
    private readonly pbc::MapField<int, global::Google.Protobuf.Packet.Room.RoomInfo> rooms_ = new pbc::MapField<int, global::Google.Protobuf.Packet.Room.RoomInfo>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<int, global::Google.Protobuf.Packet.Room.RoomInfo> Rooms {
      get { return rooms_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoomList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoomList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!Rooms.Equals(other.Rooms)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= Rooms.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      rooms_.WriteTo(output, _map_rooms_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += rooms_.CalculateSize(_map_rooms_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoomList other) {
      if (other == null) {
        return;
      }
      rooms_.Add(other.rooms_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            rooms_.AddEntriesFrom(input, _map_rooms_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code