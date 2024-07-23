using System.Collections.Generic;

namespace FourTale.TestCardGame.Characters
{
    public interface IBattleCharacters
    {
        IReadOnlyList<ICharacter> GetFractionCharacters(Fraction fraction);
    }
}