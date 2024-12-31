using Mirror;
using UnityEngine;

namespace Ros
{
    public class BasePlayer : NetworkBehaviour
    {

        [SyncVar]
        public string playerName;
        [SyncVar]
        public int currentHp;
        [SyncVar]
        public int currentArmor;
        [SyncVar]
        public int currentMana;

        public override void OnStartServer()
        {
            playerName = (string)connectionToClient.authenticationData;
        }


        public override void OnStartClient()
        {
            base.OnStartClient();
        }
        public override void OnStartLocalPlayer()
        {
            // assign data
        }
    }
}
