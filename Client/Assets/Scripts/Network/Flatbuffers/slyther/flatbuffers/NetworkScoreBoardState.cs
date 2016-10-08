// automatically generated by the FlatBuffers compiler, do not modify

namespace slyther.flatbuffers
{

using System;
using FlatBuffers;

public sealed class NetworkScoreBoardState : Table {
  public static NetworkScoreBoardState GetRootAsNetworkScoreBoardState(ByteBuffer _bb) { return GetRootAsNetworkScoreBoardState(_bb, new NetworkScoreBoardState()); }
  public static NetworkScoreBoardState GetRootAsNetworkScoreBoardState(ByteBuffer _bb, NetworkScoreBoardState obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NetworkScoreBoardState __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public ScoreboardEntry GetEntries(int j) { return GetEntries(new ScoreboardEntry(), j); }
  public ScoreboardEntry GetEntries(ScoreboardEntry obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int EntriesLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<NetworkScoreBoardState> CreateNetworkScoreBoardState(FlatBufferBuilder builder,
      VectorOffset entriesOffset = default(VectorOffset)) {
    builder.StartObject(1);
    NetworkScoreBoardState.AddEntries(builder, entriesOffset);
    return NetworkScoreBoardState.EndNetworkScoreBoardState(builder);
  }

  public static void StartNetworkScoreBoardState(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddEntries(FlatBufferBuilder builder, VectorOffset entriesOffset) { builder.AddOffset(0, entriesOffset.Value, 0); }
  public static VectorOffset CreateEntriesVector(FlatBufferBuilder builder, Offset<ScoreboardEntry>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartEntriesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<NetworkScoreBoardState> EndNetworkScoreBoardState(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NetworkScoreBoardState>(o);
  }
};


}
