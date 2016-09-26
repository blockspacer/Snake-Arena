// automatically generated by the FlatBuffers compiler, do not modify

namespace slyther.flatbuffers
{

using System;
using FlatBuffers;

public sealed class NetworkMessage : Table {
  public static NetworkMessage GetRootAsNetworkMessage(ByteBuffer _bb) { return GetRootAsNetworkMessage(_bb, new NetworkMessage()); }
  public static NetworkMessage GetRootAsNetworkMessage(ByteBuffer _bb, NetworkMessage obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NetworkMessage __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint Id { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public NetworkMessageType MsgType { get { int o = __offset(6); return o != 0 ? (NetworkMessageType)bb.Get(o + bb_pos) : NetworkMessageType.NONE; } }
  public TTable GetMsg<TTable>(TTable obj) where TTable : Table { int o = __offset(8); return o != 0 ? __union(obj, o) : null; }

  public static Offset<NetworkMessage> CreateNetworkMessage(FlatBufferBuilder builder,
      uint id = 0,
      NetworkMessageType msg_type = NetworkMessageType.NONE,
      int msgOffset = 0) {
    builder.StartObject(3);
    NetworkMessage.AddMsg(builder, msgOffset);
    NetworkMessage.AddId(builder, id);
    NetworkMessage.AddMsgType(builder, msg_type);
    return NetworkMessage.EndNetworkMessage(builder);
  }

  public static void StartNetworkMessage(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddId(FlatBufferBuilder builder, uint id) { builder.AddUint(0, id, 0); }
  public static void AddMsgType(FlatBufferBuilder builder, NetworkMessageType msgType) { builder.AddByte(1, (byte)msgType, 0); }
  public static void AddMsg(FlatBufferBuilder builder, int msgOffset) { builder.AddOffset(2, msgOffset, 0); }
  public static Offset<NetworkMessage> EndNetworkMessage(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NetworkMessage>(o);
  }
  public static void FinishNetworkMessageBuffer(FlatBufferBuilder builder, Offset<NetworkMessage> offset) { builder.Finish(offset.Value); }
};


}