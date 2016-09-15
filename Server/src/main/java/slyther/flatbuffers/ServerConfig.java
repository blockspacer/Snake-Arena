// automatically generated by the FlatBuffers compiler, do not modify

package slyther.flatbuffers;

import java.nio.*;
import java.lang.*;
import java.util.*;
import com.google.flatbuffers.*;

@SuppressWarnings("unused")
public final class ServerConfig extends Table {
  public static ServerConfig getRootAsServerConfig(ByteBuffer _bb) { return getRootAsServerConfig(_bb, new ServerConfig()); }
  public static ServerConfig getRootAsServerConfig(ByteBuffer _bb, ServerConfig obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__init(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public ServerConfig __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int tickRate() { int o = __offset(4); return o != 0 ? bb.get(o + bb_pos) & 0xFF : 0; }

  public static int createServerConfig(FlatBufferBuilder builder,
      int tickRate) {
    builder.startObject(1);
    ServerConfig.addTickRate(builder, tickRate);
    return ServerConfig.endServerConfig(builder);
  }

  public static void startServerConfig(FlatBufferBuilder builder) { builder.startObject(1); }
  public static void addTickRate(FlatBufferBuilder builder, int tickRate) { builder.addByte(0, (byte)tickRate, 0); }
  public static int endServerConfig(FlatBufferBuilder builder) {
    int o = builder.endObject();
    return o;
  }
}

