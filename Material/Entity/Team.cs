using System;
using System.Collections.Generic;

namespace Material.Entity
{
    public class Team
    {
        private string name;
        private Dictionary<long, Player> teammates = new Dictionary<long, Player>();//队伍内的玩家
        private long id;
        public string Name { get => name; set => name = value; }
        public Dictionary<long, Player> Teammates { get => teammates; set => teammates = value; }
        public long Id { get => id; set => id = value; }

        public void Foreach(Action<Player> action)
        {
            foreach (Player player in teammates.Values)
            {
                action(player);
            }
        }
    }
}
