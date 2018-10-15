using System;
using System.Text;
using System.Linq;

namespace MMNetworkLib.GameProtocol{
    class NewLobbyPacket : BasePacket{
        private string _lobbyName="{UNKNOWN}";

        public string LobbyName {
            get{return this._lobbyName;}
            set{this._lobbyName=value;}
        }

        public NewLobbyPacket(string lobbyName) : base(){
            //NOTHING TO DO
            this._type=PacketType.NEW_LOBBY;
            this._lobbyName = lobbyName;
        }
        public NewLobbyPacket(byte[] rawPacket) : base(rawPacket){
            //String ist der erste Wert in dem Paket
            this._lobbyName=this.readString();
        }

        public byte[] getPacket(){
            // TYP, [LOBBY_NAME_STRING]
            return ByteArray.FromVars(PacketType.NEW_LOBBY,this._lobbyName);
        }
    }
}