using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Enum.TryParse(type, out PlayerType playerType);

            IPlayer player = null;

            switch (playerType)
            {
                case PlayerType.Advanced:
                    player = new Advanced(new CardRepository(), username);
                    break;
                case PlayerType.Beginner:
                    player = new Beginner(new CardRepository(), username);
                    break;
            }

            return player;
        }
    }
}
