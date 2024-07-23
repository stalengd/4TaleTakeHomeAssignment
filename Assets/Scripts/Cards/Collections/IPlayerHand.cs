using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards.Collections
{
    public interface IReadOnlyPlayerHand
    {
        IReadOnlyList<ICard> Cards { get; }
    }

    public interface IPlayerHand : IReadOnlyPlayerHand
    {
        void Add(ICard card);
        void Remove(ICard card);
        void Clear();
    }
}