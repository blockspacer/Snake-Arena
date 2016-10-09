// automatically generated by the FlatBuffers compiler, do not modify

namespace slyther.flatbuffers
{

using System;
using FlatBuffers;

public sealed class NetworkSnakeState : Table {
  public static NetworkSnakeState GetRootAsNetworkSnakeState(ByteBuffer _bb) { return GetRootAsNetworkSnakeState(_bb, new NetworkSnakeState()); }
  public static NetworkSnakeState GetRootAsNetworkSnakeState(ByteBuffer _bb, NetworkSnakeState obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NetworkSnakeState __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Name { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __vector_as_arraysegment(6); }
  public string Skin { get { int o = __offset(8); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetSkinBytes() { return __vector_as_arraysegment(8); }
  public uint Score { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public bool IsDead { get { int o = __offset(12); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }
  public bool IsTurbo { get { int o = __offset(14); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }
  public NetworkSnakePartState GetParts(int j) { return GetParts(new NetworkSnakePartState(), j); }
  public NetworkSnakePartState GetParts(NetworkSnakePartState obj, int j) { int o = __offset(16); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int PartsLength { get { int o = __offset(16); return o != 0 ? __vector_len(o) : 0; } }
  public ushort Head { get { int o = __offset(18); return o != 0 ? bb.GetUshort(o + bb_pos) : (ushort)0; } }
  public ushort Tail { get { int o = __offset(20); return o != 0 ? bb.GetUshort(o + bb_pos) : (ushort)0; } }

  public static Offset<NetworkSnakeState> CreateNetworkSnakeState(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      StringOffset skinOffset = default(StringOffset),
      uint score = 0,
      bool isDead = false,
      bool isTurbo = false,
      VectorOffset partsOffset = default(VectorOffset),
      ushort head = 0,
      ushort tail = 0) {
    builder.StartObject(9);
    NetworkSnakeState.AddParts(builder, partsOffset);
    NetworkSnakeState.AddScore(builder, score);
    NetworkSnakeState.AddSkin(builder, skinOffset);
    NetworkSnakeState.AddName(builder, nameOffset);
    NetworkSnakeState.AddTail(builder, tail);
    NetworkSnakeState.AddHead(builder, head);
    NetworkSnakeState.AddIsTurbo(builder, isTurbo);
    NetworkSnakeState.AddIsDead(builder, isDead);
    return NetworkSnakeState.EndNetworkSnakeState(builder);
  }

  public static void StartNetworkSnakeState(FlatBufferBuilder builder) { builder.StartObject(9); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(1, nameOffset.Value, 0); }
  public static void AddSkin(FlatBufferBuilder builder, StringOffset skinOffset) { builder.AddOffset(2, skinOffset.Value, 0); }
  public static void AddScore(FlatBufferBuilder builder, uint score) { builder.AddUint(3, score, 0); }
  public static void AddIsDead(FlatBufferBuilder builder, bool isDead) { builder.AddBool(4, isDead, false); }
  public static void AddIsTurbo(FlatBufferBuilder builder, bool isTurbo) { builder.AddBool(5, isTurbo, false); }
  public static void AddParts(FlatBufferBuilder builder, VectorOffset partsOffset) { builder.AddOffset(6, partsOffset.Value, 0); }
  public static VectorOffset CreatePartsVector(FlatBufferBuilder builder, Offset<NetworkSnakePartState>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartPartsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddHead(FlatBufferBuilder builder, ushort head) { builder.AddUshort(7, head, 0); }
  public static void AddTail(FlatBufferBuilder builder, ushort tail) { builder.AddUshort(8, tail, 0); }
  public static Offset<NetworkSnakeState> EndNetworkSnakeState(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NetworkSnakeState>(o);
  }
};


}
