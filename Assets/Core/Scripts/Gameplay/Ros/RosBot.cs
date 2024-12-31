
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Packets;
using System;
using System.Linq;

namespace ReversalOfSpirit.Gameplay.Ros
{
    [System.Serializable]
    public class RosBot : RosPlayer
    {
        private int currentSlot = 0;
        public RosBot(RosGame game) : base(game)
        {
            var profile = game.PlayerDataService.GetBotPlayerProfile(game.GetOpponent(this).Id);
            SetupProfile(profile);
        }

        //public override void Send<T>(string packetId, T packet)
        //{
        //    if (packetId == nameof(S2C_SeedBoardPacket) && packet is S2C_SeedBoardPacket payload)
        //    {
        //        currentSlot = 0;
        //        int cardId = handItems.GroupBy(x => x.id).ToDictionary(x => x.Key, x => x.Count()).OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();
        //        game.C2S_SetSelectionCard(Id, new C2S_PlayerSelectionCard
        //        {
        //            slot = (GameTerritory)currentSlot,
        //            cardId = cardId
        //        });
        //    }
        //    else if (packet is S2C_SelectCardSuccess)
        //    {
        //        if (currentSlot < 2)
        //        {
        //            currentSlot++;
        //            int cardId = handItems.GroupBy(x => x.id).Select(x => new { Key = x.Key, Value = x.Count() }).OrderBy(x => x.Value).Select(x => x.Key).FirstOrDefault();
        //            game.C2S_SetSelectionCard(Id, new C2S_PlayerSelectionCard
        //            {
        //                slot = (GameTerritory)currentSlot,
        //                cardId = cardId
        //            });
        //            if (currentSlot == 2)
        //            {
        //                game.C2S_PlayerSelectionFinish(Id, new C2S_PlayerSelectionFinish());
        //            }
        //        }

        //    }

        //}

        public override int Id => -1;

        //public override void Broadcast<T>(string packetId, T packet)
        //{
        //    if (packet is S2C_SendRoundActions)
        //    {
        //        game.C2S_PlayerPresentRoundDone(Id, new C2S_PlayerPresentRoundDone());
        //    }
        //}

        //public override void Send(string packetId, Action<NetDataWriter> writerFunc)
        //{
        //    NetDataWriter writer = new NetDataWriter();
        //    writerFunc(writer);
        //    NetDataReader reader = new NetDataReader(writer);
        //    if (packetId == nameof(S2C_SendRoundActions))
        //    {
        //        S2C_SendRoundActions act = new S2C_SendRoundActions();
        //        act.Deserialize(game, reader);
        //        game.C2S_PlayerPresentRoundDone(Id, new C2S_PlayerPresentRoundDone());
        //    }
        //}
    }
}
