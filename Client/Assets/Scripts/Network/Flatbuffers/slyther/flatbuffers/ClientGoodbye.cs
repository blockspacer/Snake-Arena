// automatically generated by the FlatBuffers compiler, do not modify

namespace slyther.flatbuffers
{

using System;
using FlatBuffers;

public sealed class ClientGoodbye : Table {
  public static ClientGoodbye GetRootAsClientGoodbye(ByteBuffer _bb) { return GetRootAsClientGoodbye(_bb, new ClientGoodbye()); }
  public static ClientGoodbye GetRootAsClientGoodbye(ByteBuffer _bb, ClientGoodbye obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public ClientGoodbye __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }


  public static void StartClientGoodbye(FlatBufferBuilder builder) { builder.StartObject(0); }
  public static Offset<ClientGoodbye> EndClientGoodbye(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ClientGoodbye>(o);
  }
};


}
