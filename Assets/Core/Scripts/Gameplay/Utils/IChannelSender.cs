using LiteNetLib;
using LiteNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Utils
{
    public interface IChannelSender
    {
        void Broadcast<T>(string packetId, T packet) where T : INetSerializable;

        void Broadcast(string packetId, Action<NetDataWriter> writerFunc);

        void Send<T>(int peerId, string packetId, T packet) where T : INetSerializable;

        void Send(int peerId, string packetId, Action<NetDataWriter> writerFunc);
    }
}
