using System;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class S2C_SeedBoardPacket //: INetSerializable
    {
        public List<HandItem> handItems;

        //public void Serialize(NetDataWriter writer)
        //{
        //    writer.Serialize(handItems);
        //}

        //public void Deserialize(NetDataReader reader)
        //{
        //    handItems = reader.DeserializeHandItems();
        //}
    }


    public static class HandItemExtension
    {
        //public static void Serialize(this NetDataWriter writer, List<HandItem> handItems)
        //{
        //    writer.Put(handItems.Count);
        //    foreach (var handItem in handItems)
        //    {
        //        writer.Put(handItem.x);
        //        writer.Put(handItem.y);

        //        writer.Put(handItem.id);
        //    }
        //}

        //public static List<HandItem> DeserializeHandItems(this NetDataReader reader)
        //{
        //    var handItems = new List<HandItem>();
        //    int count = reader.GetInt();
        //    for (int i = 0; i < count; i++)
        //    {
        //        handItems.Add(new HandItem
        //        {
        //            x = reader.GetInt(),
        //            y = reader.GetInt(),
        //            id = reader.GetInt(),
        //        });
        //    }

        //    return handItems;
        //}

        //public static void Serialize<T>(this NetDataWriter writer, List<T> items) where T : INetSerializable
        //{
        //    writer.Put(items.Count);
        //    foreach (var handItem in items)
        //    {
        //        handItem.Serialize(writer);
        //    }
        //}

        //public static List<T> Deserialize<T>(this NetDataReader reader) where T : INetSerializable
        //{
        //    List<T> items = new List<T>();
        //    int count = reader.GetInt();
        //    for (int i = 0; i < count; i++)
        //    {
        //        var item = Activator.CreateInstance<T>();
        //        item.Deserialize(reader);
        //        items.Add(item);
        //    }
        //    return items;
        //}
    }
    public class HandItem
    {
        public int x;
        public int y;
        public int id;
    }
}
