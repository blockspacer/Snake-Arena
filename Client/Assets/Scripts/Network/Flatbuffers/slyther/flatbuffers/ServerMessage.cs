// automatically generated by the FlatBuffers compiler, do not modify

namespace slyther.flatbuffers
{

using System;
using FlatBuffers;

public sealed class ServerMessage : Table {
  public static ServerMessage GetRootAsServerMessage(ByteBuffer _bb) { return GetRootAsServerMessage(_bb, new ServerMessage()); }
  public static ServerMessage GetRootAsServerMessage(ByteBuffer _bb, ServerMessage obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public ServerMessage __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public ServerMessageType MsgType { get { int o = __offset(4); return o != 0 ? (ServerMessageType)bb.Get(o + bb_pos) : ServerMessageType.NONE; } }
  public TTable GetMsg<TTable>(TTable obj) where TTable : Table { int o = __offset(6); return o != 0 ? __union(obj, o) : null; }

  public static Offset<ServerMessage> CreateServerMessage(FlatBufferBuilder builder,
      ServerMessageType msg_type = ServerMessageType.NONE,
      int msgOffset = 0) {
    builder.StartObject(2);
    ServerMessage.AddMsg(builder, msgOffset);
    ServerMessage.AddMsgType(builder, msg_type);
    return ServerMessage.EndServerMessage(builder);
  }

  public static void StartServerMessage(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddMsgType(FlatBufferBuilder builder, ServerMessageType msgType) { builder.AddByte(0, (byte)msgType, 0); }
  public static void AddMsg(FlatBufferBuilder builder, int msgOffset) { builder.AddOffset(1, msgOffset, 0); }
  public static Offset<ServerMessage> EndServerMessage(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ServerMessage>(o);
  }
  public static void FinishServerMessageBuffer(FlatBufferBuilder builder, Offset<ServerMessage> offset) { builder.Finish(offset.Value); }
};


}
