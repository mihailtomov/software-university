using System;
using System.Collections.Generic;
using System.Linq;

namespace P05FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public double Rating 
        { 
            get
            {
                return CalculateRating();
            }
        }

        private double CalculateRating()
        {
            double averageSkillLevel = 0;

            foreach (var player in players)
            {
                double playerSkillLevel 
                    = (player.Dribble + player.Endurance + player.Passing + player.Shooting + player.Sprint) / 5;

                averageSkillLevel += playerSkillLevel;
            }

            if (this.players.Count != 0)
            {
                return Math.Round(averageSkillLevel / this.players.Count);
            }
            else
            {
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(x => x.Name == playerName);

            if (player != null)
            {
                this.players.Remove(player);
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}