using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ros
{
    public class BotService
    {

        private static BotService _instance = new BotService();

        public static BotService Instance { get { return _instance; } }
        public PlayerInfo FindBotProfile(int elo)
        {
            return new PlayerInfo();
        }
    }
}
