using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Enum.TryParse(type, out CardType cardType);

            ICard card = null;

            switch (cardType)
            {
                case CardType.Magic: 
                    card = new Magic(name);
                    break;
                case CardType.Trap:
                    card = new Trap(name);
                    break;
            }

            return card;
        }
    }
}
