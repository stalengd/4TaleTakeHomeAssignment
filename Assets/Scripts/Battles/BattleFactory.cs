using System.Collections.Generic;
using FourTale.TestCardGame.Cards;
using FourTale.TestCardGame.Cards.Collections;
using FourTale.TestCardGame.Characters;
using FourTale.TestCardGame.Players;

namespace FourTale.TestCardGame.Battles
{
    public sealed class BattleFactory : IBattleFactory
    {
        private readonly ICharactersFactory _charactersFactory;
        private readonly ICollectedCardsService _collectedCardsService;
        private readonly ILocalPlayerFactory _localPlayerFactory;

        public BattleFactory(ICharactersFactory charactersFactory, ICollectedCardsService collectedCardsService, ILocalPlayerFactory localPlayerFactory)
        {
            _charactersFactory = charactersFactory;
            _collectedCardsService = collectedCardsService;
            _localPlayerFactory = localPlayerFactory;
        }

        public IBattle CreateBattle(IBattleDescription description)
        {
            var characters = _charactersFactory.Create(description);
            var deck = PrepareDeck();
            var localPlayer = _localPlayerFactory.Create(deck);
            var aiPlayer = new AIPlayer(Fraction.Enemy);
            return new Battle(characters, new IPlayer[] { localPlayer, aiPlayer });
        }

        // Worth it to move this to separate factory later
        private IBattleDeck PrepareDeck()
        {
            var cards = new List<ICard>();
            foreach (var cardType in _collectedCardsService.Cards)
            {
                cards.Add(new Card(cardType));
            }
            return new BattleDeck(cards);
        }
    }
}