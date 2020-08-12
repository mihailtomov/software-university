using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>();
        }

        public int Count => this.roster.Count;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < Capacity)
            {
                this.roster.Add(player);
            }
        }
        
        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);
            return this.roster.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string Class)
        {
            Player[] filteredPlayers = this.roster.Where(x => x.Class == Class).ToArray();
            this.roster.RemoveAll(x => x.Class == Class);
            return filteredPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine($"{player}");
            }

            return sb.ToString().Trim();
        }
    }
}
