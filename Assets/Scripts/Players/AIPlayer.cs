using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Players
{
    public sealed class AIPlayer : IPlayer
    {
        public int MaxEnergy { get; }
        public int CurrentEnergy { get; }
        public Fraction ControllableFraction { get; }

        private IBattle _battle;

        public AIPlayer(Fraction fraction)
        {
            ControllableFraction = fraction;
        }

        public void StartBattle(IBattle battle)
        {
            _battle = battle;
        }

        public void EndBattle(IBattle battle)
        {

        }

        public void StartTurn()
        {
            var characters = _battle.Characters.GetFractionCharacters(ControllableFraction);
            for (int i = 0; i < characters.Count; i++)
            {
                var character = characters[i];
                if (character == null || !character.IsAlive || character is not IAICharacter aiCharacter)
                {
                    continue;
                }
                aiCharacter.Behaviour.DoTurn(_battle);
            }
            _battle.EndTurn();
        }
    }
}
