using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards.Collections
{
    public interface IDiscardPile
    {
        int CardsCount { get; }
        IReadOnlyList<ICard> Cards { get; }

        void Add(ICard card);
        void Clear();
    }
}