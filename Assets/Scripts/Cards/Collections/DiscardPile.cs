using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards.Collections
{
    public sealed class DiscardPile : IDiscardPile
    {
        public int CardsCount => _cards.Count;
        public IReadOnlyList<ICard> Cards => _cards;

        private readonly List<ICard> _cards = new();

        public void Add(ICard card)
        {
            _cards.Add(card);
        }

        public void Clear()
        {
            _cards.Clear();
        }
    }
}
