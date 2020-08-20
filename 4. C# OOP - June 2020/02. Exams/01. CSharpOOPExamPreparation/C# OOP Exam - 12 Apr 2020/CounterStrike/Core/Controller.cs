using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Enumerations;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            Enum.TryParse(type, out GunType gunType);

            switch (gunType)
            {
                case GunType.Pistol: 
                    this.guns.Add(new Pistol(name, bulletsCount));
                    break;
                case GunType.Rifle:
                    this.guns.Add(new Rifle(name, bulletsCount));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            string msg = string.Format(OutputMessages.SuccessfullyAddedGun, name);
            return msg;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            Enum.TryParse(type, out PlayerType playerType);

            switch (playerType)
            {
                case PlayerType.CounterTerrorist: 
                    this.players.Add(new CounterTerrorist(username, health, armor, gun));
                    break;
                case PlayerType.Terrorist:
                    this.players.Add(new Terrorist(username, health, armor, gun));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            string msg = string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return msg;
        }

        public string Report()
        {
            List<IPlayer> playersReport = this.players.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username)
                .ToList();

            StringBuilder report = new StringBuilder();

            foreach (var player in playersReport)
            {
                report.AppendLine(player.ToString());
            }

            return report.ToString().Trim();
        }

        public string StartGame()
        {
            ICollection<IPlayer> alivePlayers = this.players.Models.Where(p => p.IsAlive).ToList();

            return this.map.Start(alivePlayers);
        }
    }
}
