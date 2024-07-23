using FourTale.TestCardGame.AI;

namespace FourTale.TestCardGame.Characters
{
    public interface IAICharacter : ICharacter
    {
        IAICharacterBehaviour Behaviour { get; }
    }
}
