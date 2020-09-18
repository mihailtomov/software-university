namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository players;
        private readonly ICardRepository cards;
        private readonly IBattleField battlefield;

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.battlefield = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = new PlayerFactory().CreatePlayer(type, username);
            this.players.Add(player);
            string msg = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
            return msg;
        }

        public string AddCard(string type, string name)
        {
            ICard card = new CardFactory().CreateCard(type, name);
            this.cards.Add(card);
            string msg = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
            return msg;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.players.Find(username);
            ICard card = this.cards.Find(cardName);
            player.CardRepository.Add(card);
            string msg = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
            return msg;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.players.Find(attackUser);
            IPlayer enemy = this.players.Find(enemyUser);
            this.battlefield.Fight(attacker, enemy);
            string msg = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
            return msg;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.players.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine("###");
            }

            return sb.ToString().Trim();
        }
    }
}
