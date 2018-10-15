using System;
using System.Text;
using System.Linq;

namespace MMNetworkLib.GameProtocol{
    class NewLobbyResponsePacket : BasePacket{
        private int _lobbyId=-1;

        public int LobbyId {
            get{return this._lobbyId;}
            set{this._lobbyId=value;}
        }

        public NewLobbyResponsePacket(int lobbyId) : base(){
            //NOTHING TO DO
            this._type=PacketType.NEW_LOBBY;
            this._lobbyId = lobbyId;
        }
        public NewLobbyResponsePacket(byte[] rawPacket) : base(rawPacket){
            //String ist der erste Wert in dem Paket
            this._lobbyId=this.readInt();
        }

        public byte[] getPacket(){
            // TYP, [LOBBY_ID_INT]
            return ByteArray.FromVars(PacketType.NEW_LOBBY_RESPONSE,this._lobbyId);
        }
    }
}