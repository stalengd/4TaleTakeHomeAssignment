using System.Collections.Generic;
using UnityEngine;
using FourTale.TestCardGame.Characters;
using FourTale.TestCardGame.AI;

namespace FourTale.TestCardGame.Battles
{
    [System.Serializable]
    public sealed class BattleDescriptionStatic : IBattleDescription
    {
        [SerializeField] private CharacterDescription[] _enemies;
        [SerializeField] private AICharacterBehaviourGameObject[] _behaviours;

        public IReadOnlyList<CharacterDescription> Enemies => _enemies;
        public IReadOnlyList<AICharacterBehaviourGameObject> Behaviours => _behaviours;
    }
}