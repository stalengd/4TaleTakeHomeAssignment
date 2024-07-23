using System.Collections.Generic;
using FourTale.TestCardGame.AI;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Battles
{
    public interface IBattleDescription
    {
        IReadOnlyList<CharacterDescription> Enemies { get; }
        IReadOnlyList<AICharacterBehaviourGameObject> Behaviours { get; }
    }
}