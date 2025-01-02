
using System;

namespace ReversalOfSpirit.Gameplay.Ros
{
    //[System.Serializable]
    //public class RosRealPlayer : RosPlayer
    //{
    //    private int _id;

    //    public RosRealPlayer(int id, int peerId, RosGame game) : base(game)
    //    {
    //        PeerId = peerId;
    //        _id = id;
            
    //        var profile = game.PlayerDataService.GetPlayerProfile(peerId);
    //        SetupProfile(profile);
    //    }

    //    public int PeerId { get; set; }

    //    public override int Id => _id;

    //    //public override void Send<T>(string packetId, T packet)
    //    //{
    //    //    this.game.ChannelSender.Send<T>(PeerId, packetId, packet);
    //    //}

    //    //public override void Broadcast<T>(string packetId, T packet)
    //    //{
    //    //    this.game.ChannelSender.Broadcast<T>(packetId, packet);
    //    //}

    //    //public override void Send(string packetId, Action<NetDataWriter> writerFunc)
    //    //{
    //    //    this.game.ChannelSender.Send(PeerId, packetId, writerFunc);
    //    //}
    //}
}
