using FourTale.TestCardGame.AI;
using FourTale.TestCardGame.Characters.Rendering;

namespace FourTale.TestCardGame.Characters
{
    public sealed class AICharacter : Character, IAICharacter
    {
        public IAICharacterBehaviour Behaviour { get; }

        public AICharacter(Fraction fraction, int maxHealth, ICharacterRenderer renderer, IAICharacterBehaviour behaviour)
            : base(fraction, maxHealth, renderer)
        {
            Behaviour = behaviour;
        }
    }
}
