using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards.Collections
{
    public sealed class BattleDeck : IBattleDeck
    {
        public IReadOnlyPlayerHand Hand => _hand;
        public int DrawPileCount => _drawPile.CardsCount;
        public int DiscardPileCount => _discardPile.CardsCount;

        public event System.Action<ICard> CardDrawn;
        public event System.Action<ICard> CardDiscarded;
        public event System.Action<ICard> CardAddedToDrawPile;

        private readonly IDrawPile _drawPile = new DrawPile();
        private readonly IDiscardPile _discardPile = new DiscardPile();
        private readonly IPlayerHand _hand = new PlayerHand();

        public BattleDeck(IEnumerable<ICard> cards)
        {
            foreach (var card in cards)
            {
                _drawPile.AddRandom(card);
            }
        }

        public void Draw(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Draw();
            }
        }

        public void Discard(ICard card)
        {
            if (card == null)
            {
                return;
            }
            _hand.Remove(card);
            _discardPile.Add(card);
            CardDiscarded?.Invoke(card);
        }

        public void DiscardAll()
        {
            for (int i = 0; i < _hand.Cards.Count; i++)
            {
                var card = _hand.Cards[i];
                _discardPile.Add(card);
                CardDiscarded?.Invoke(card);
            }
            _hand.Clear();
        }

        private void Draw()
        {
            var card = _drawPile.DrawOrDefault();
            if (card == null)
            {
                ReturnCardsToDrawPile();
                card = _drawPile.DrawOrDefault();
                if (card == null)
                {
                    return; // Not enouth cards to draw
                }
            }
            _hand.Add(card);
            CardDrawn?.Invoke(card);
        }

        private void ReturnCardsToDrawPile()
        {
            for (int i = 0; i < _discardPile.Cards.Count; i++)
            {
                var card = _discardPile.Cards[i];
                _drawPile.AddRandom(card);
                CardAddedToDrawPile?.Invoke(card);
            }
            _discardPile.Clear();
        }
    }
}
