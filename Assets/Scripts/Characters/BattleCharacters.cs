using System.Collections.Generic;

namespace FourTale.TestCardGame.Characters
{
    public sealed class BattleCharacters : IBattleCharacters
    {
        private readonly List<ICharacter> _playerCharacters;
        private readonly List<ICharacter> _enemyCharacters;

        public BattleCharacters(List<ICharacter> playerCharacters, List<ICharacter> enemyCharacters)
        {
            _playerCharacters = playerCharacters;
            _enemyCharacters = enemyCharacters;
        }

        public IReadOnlyList<ICharacter> GetFractionCharacters(Fraction fraction)
        {
            return fraction.Match(_playerCharacters, _enemyCharacters);
        }
    }
}
