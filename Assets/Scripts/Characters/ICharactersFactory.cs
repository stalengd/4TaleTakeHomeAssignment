using FourTale.TestCardGame.Battles;

namespace FourTale.TestCardGame.Characters
{
    public interface ICharactersFactory
    {
        IBattleCharacters Create(IBattleDescription battleDescription);
    }
}