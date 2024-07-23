using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards
{
    public sealed class CollectedCardsService : ICollectedCardsService
    {
        public IReadOnlyList<ICardType> Cards => _cards;

        private readonly List<ICardType> _cards = new();

        public CollectedCardsService(ICardTypesProvider cardTypesProvider)
        {
            _cards.AddRange(cardTypesProvider.GetInitial());
        }
    }
}
