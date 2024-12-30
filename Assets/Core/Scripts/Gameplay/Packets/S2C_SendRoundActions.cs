using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Ros;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class S2C_SendRoundActions : IActionNetSerialize
    {
        public List<GameAction> actions;

        public void Serialize(IRosGame game, NetDataWriter writer)
        {
            UnityEngine.Debug.Log("Total write action: " + actions.Count);
            writer.Put(actions.Count);
            foreach (var action in actions)
            {
                UnityEngine.Debug.Log("Put action: " + action.GetType().Name);
                writer.Put(action.GetType().Name);
                action.Serialize(game, writer);
            }
        }

        public void Deserialize(IRosGame game, NetDataReader reader)
        {



            var dictType = Assembly.GetAssembly(typeof(GameAction)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(GameAction))).ToDictionary(x => x.Name, x => x);

            actions = new List<GameAction>();
            int n = reader.GetInt();
            UnityEngine.Debug.Log("Total read action: " + n);
            for (int idxAction = 0; idxAction < n; idxAction++)
            {
                string actionType = reader.GetString();
                var type = dictType[actionType];
                var action = (GameAction)Activator.CreateInstance(type);
                action.Deserialize(game, reader);

                actions.Add(action);
                UnityEngine.Debug.Log("Read action: " + actionType);
            }
        }

     
    }

    public class S2C_SendExeImRoundActions : IActionNetSerialize
    {
        public List<GameAction> actions;

        public void Serialize(IRosGame game, NetDataWriter writer)
        {
            UnityEngine.Debug.Log("Total write action: " + actions.Count);
            writer.Put(actions.Count);
            foreach (var action in actions)
            {
                UnityEngine.Debug.Log("Put action: " +  action.GetType().Name);
                writer.Put(action.GetType().Name);
                action.Serialize(game, writer);

            }
        }

        public void Deserialize(IRosGame game, NetDataReader reader)
        {



            var dictType = Assembly.GetAssembly(typeof(GameAction)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(GameAction))).ToDictionary(x => x.Name, x => x);
            
            actions = new List<GameAction>();
            
            int n = reader.GetInt();
            UnityEngine.Debug.Log("Total read action: " + n);
            for (int idxAction = 0; idxAction < n; idxAction++)
            {
                string actionType = reader.GetString();
                UnityEngine.Debug.Log("Read action: " + actionType);
                var type = dictType[actionType];
                var action = (GameAction)Activator.CreateInstance(type);
                action.Deserialize(game, reader);
                actions.Add(action);
            }
        }
    }
}
