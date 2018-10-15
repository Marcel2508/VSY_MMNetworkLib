using System;

namespace MMNetworkLib.GameProtocol{
    class PingPacket : BasePacket{
        public PingPacket() : base(){
            //NOTHING TO DO
            this._type=PacketType.PING;
        }
        public PingPacket(byte[] rawPacket) : base(rawPacket){
            //NOTHING TO DO
        }

        public byte[] getPacket(){
            return new byte[]{(byte)this._type};
        }
    }
}