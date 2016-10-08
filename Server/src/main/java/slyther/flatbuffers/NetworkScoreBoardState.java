// automatically generated by the FlatBuffers compiler, do not modify

package slyther.flatbuffers;

import java.nio.*;
import java.lang.*;
import java.util.*;
import com.google.flatbuffers.*;

@SuppressWarnings("unused")
public final class NetworkScoreBoardState extends Table {
  public static NetworkScoreBoardState getRootAsNetworkScoreBoardState(ByteBuffer _bb) { return getRootAsNetworkScoreBoardState(_bb, new NetworkScoreBoardState()); }
  public static NetworkScoreBoardState getRootAsNetworkScoreBoardState(ByteBuffer _bb, NetworkScoreBoardState obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__init(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public NetworkScoreBoardState __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public ScoreboardEntry entries(int j) { return entries(new ScoreboardEntry(), j); }
  public ScoreboardEntry entries(ScoreboardEntry obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int entriesLength() { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; }

  public static int createNetworkScoreBoardState(FlatBufferBuilder builder,
      int entriesOffset) {
    builder.startObject(1);
    NetworkScoreBoardState.addEntries(builder, entriesOffset);
    return NetworkScoreBoardState.endNetworkScoreBoardState(builder);
  }

  public static void startNetworkScoreBoardState(FlatBufferBuilder builder) { builder.startObject(1); }
  public static void addEntries(FlatBufferBuilder builder, int entriesOffset) { builder.addOffset(0, entriesOffset, 0); }
  public static int createEntriesVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addOffset(data[i]); return builder.endVector(); }
  public static void startEntriesVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static int endNetworkScoreBoardState(FlatBufferBuilder builder) {
    int o = builder.endObject();
    return o;
  }
}
