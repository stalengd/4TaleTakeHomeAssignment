using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards.Collections
{
    public sealed class PlayerHand : IPlayerHand
    {
        public IReadOnlyList<ICard> Cards => _cards;

        // We can use HashSet here, but I really like to enumerate with integer indices
        private readonly List<ICard> _cards = new();

        public void Add(ICard card)
        {
            _cards.Add(card);
        }

        public void Remove(ICard card)
        {
            _cards.Remove(card);
        }

        public void Clear()
        {
            _cards.Clear();
        }
    }
}
