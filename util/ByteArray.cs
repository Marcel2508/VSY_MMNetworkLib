using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace MMNetworkLib{

    static class ByteArray{

        private static Encoding _defaultEncoding = Encoding.UTF8;

        public static Encoding DefaultEncoding{
            get{return _defaultEncoding;}
        }

        public static byte[] FromVars(params object[] args){
            byte[] curByteArray = new  byte[0]; 
            IEnumerable<byte> cur=curByteArray;
            for(int i=0;i<args.Length;i++){
                Type t = args[i].GetType();
                if(t.IsArray){
                    if(((byte[])args[i]).Length>0){
                        if(args[i] is byte[]){
                            byte[] d = (byte[])args[i];
                            //KONVENTION: erst die länge als 4 Byte, dann das Array ...
                            cur=cur.Concat(BitConverter.GetBytes(Convert.ToInt32(d.Length))).Concat(d);
                        }
                        else{
                            throw new ArgumentException("Only Byte Arrays supported at the moment!");
                        } 
                    }
                    else{
                        throw new ArgumentOutOfRangeException("Array darf nicht leer sein!");
                    }
                }
                else{
                    if(args[i] is byte){
                        cur=cur.Concat(new byte[]{(byte)args[i]});
                    }
                    else if(args[i] is string){
                        cur=cur.Concat(_defaultEncoding.GetBytes((string)args[i])).Concat(new byte[]{0x00});
                    }
                    else if(args[i] is int){
                        cur=cur.Concat(BitConverter.GetBytes((int)args[i]));
                    }
                    else if(args[i] is double){
                        cur=cur.Concat(BitConverter.GetBytes((double)args[i]));
                    }
                    else{
                        throw new ArgumentException("Unzulässiger Datentyp: "+t.ToString());
                    }
                }
            }
            return cur.ToArray();
        }
    }
}