using System;

namespace MMNetworkLib
{

    enum PacketType : byte{
        PING=0x01,
        PONG=0x02,

        NEW_LOBBY=0x11,
        NEW_LOBBY_RESPONSE=0x12,
        LOBBY_JOIN=0x13,
        LOBBY_JOIN_RESPONSE=0x14,
        LIST_LOBBY=0x15,
        LIST_LOBBY_RESPONSE=0x16,
        JOIN_LOBBY_VIEWER=0x17,
        JOIN_LOBBY_VIEWER_RESPONSE=0x18,
        DO_MOVE_COL=0x21,
        MOVE_UPDATE_PACKET=0x22,
        //TODO MEHR INGAME PAKETE...
        GAME_END=0x29

    };

    public class PacketHandler
    {
        public PacketHandler(){
            //Vill hier den Stream übergeben??
            // UND hier den listener dierekt einbauen?
        }

        private GameProtocol.BasePacket getPacket(byte[] raw){
            PacketType typ = (PacketType)raw[0];
            switch(typ){
                case PacketType.PING:
                    return new GameProtocol.PingPacket(raw);
                case PacketType.PONG:
                    return new GameProtocol.PongPacket(raw);
                case PacketType.NEW_LOBBY:
                    return new GameProtocol.NewLobbyPacket(raw);
                case PacketType.NEW_LOBBY_RESPONSE:
                    return new GameProtocol.NewLobbyResponsePacket(raw);
                default:
                    throw new MissingMemberException("Invalid Packet type!");
            }
            return null;
        }

        protected void sendPacket(GameProtocol.BasePacket packet){
            //sende das Paket iwie mittels socket an iwen..
            return;
        }

    }
}
