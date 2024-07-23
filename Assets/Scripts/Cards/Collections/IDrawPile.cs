namespace FourTale.TestCardGame.Cards.Collections
{
    public interface IDrawPile
    {
        int CardsCount { get; }
        ICard DrawOrDefault();
        void AddRandom(ICard card);
        void AddToTop(ICard card);
    }
}