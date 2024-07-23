namespace FourTale.TestCardGame.Cards.Collections
{
    public interface IBattleDeck
    {
        IReadOnlyPlayerHand Hand { get; }
        int DrawPileCount { get; }
        int DiscardPileCount { get; }

        event System.Action<ICard> CardDrawn;
        event System.Action<ICard> CardDiscarded;
        event System.Action<ICard> CardAddedToDrawPile;

        void Draw(int amount);
        void Discard(ICard card);
        void DiscardAll();
    }
}