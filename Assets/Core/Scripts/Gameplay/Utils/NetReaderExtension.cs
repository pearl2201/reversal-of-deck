using LiteNetLib.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Utils
{
    public static class NetReaderExtension
    {
        public static Dictionary<string, string> ReadHashtable(this NetDataReader reader)
        {
            Dictionary<string, string> ht = new Dictionary<string, string>();
            int c = reader.GetInt();
            for (int i = 0; i < c; i++)
            {
                var key = reader.GetString();
                var value = reader.GetString();
                ht[key] = value;
            }
            return ht;
        }

        public static void Write(this NetDataWriter writer, Dictionary<string,string> ht)
        {
            writer.Put(ht.Count);
            foreach (var kv in ht)
            {
                writer.Put(kv.Key);
                writer.Put(kv.Value);
            }

        }
    }
}
