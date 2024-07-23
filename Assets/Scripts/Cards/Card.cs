namespace FourTale.TestCardGame.Cards
{
    public sealed class Card : ICard
    {
        public ICardType Type { get; }

        public Card(ICardType type)
        {
            Type = type;
        }
    }
}
