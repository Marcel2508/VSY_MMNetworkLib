using System;
using System.Linq;

namespace MMNetworkLib.GameProtocol{

    abstract class BasePacket{

        protected byte[] _rawPacket;
        protected PacketType _type;
        protected int _pointer = 1;

        public PacketType Type{
            get{
                return this._type;
            }
            set{
                this._type=value;
            }
        }

        protected int readInt(){
            return BitConverter.ToInt32(this._rawPacket,this._pointer+=sizeof(Int32));
        }
        protected double readDouble(){
            return BitConverter.ToInt32(this._rawPacket,this._pointer+=sizeof(double));
        }
        protected string readString(){
            string str = BitConverter.ToString(this._rawPacket,this._pointer);
            this._pointer+=ByteArray.DefaultEncoding.GetByteCount(str)+1;
            return str;
        }

        protected byte[] readByteArray(){
            int l = this.readInt();
            byte[] a = this._rawPacket.Skip(this._pointer).Take(l).ToArray();
            this._pointer+=l;
            return a;
        }
        protected byte readByte(){
            return this._rawPacket[this._pointer++];
        }


        public BasePacket(){
            //this._rawPacket=new byte[]{(byte)PacketType.PING};
        }

        public BasePacket(byte[] rawPacket){
            this._type=(PacketType)rawPacket[0];

            //rawPacket = rawPacket.Skip(1).ToArray();
            this._rawPacket = rawPacket;
        }
    }
}