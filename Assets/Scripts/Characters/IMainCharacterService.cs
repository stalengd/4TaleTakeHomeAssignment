namespace FourTale.TestCardGame.Characters
{
    public interface IMainCharacterService
    {
        CharacterDescription CharacterDescription { get; }
        public int Energy { get; }
        public int CardsDrawCount { get; }
    }
}