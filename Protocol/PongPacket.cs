using System;

namespace MMNetworkLib.GameProtocol{
    class PongPacket : BasePacket{
        public PongPacket() : base(){
            //NOTHING TO DO
            this._type=PacketType.PONG;
        }
        public PongPacket(byte[] rawPacket) : base(rawPacket){
            //NOTHING TO DO
        }

        public byte[] getPacket(){
            return new byte[]{(byte)this._type};
        }
    }
}