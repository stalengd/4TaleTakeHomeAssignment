using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards
{
    public interface ICollectedCardsService
    {
        IReadOnlyList<ICardType> Cards { get; }
    }
}