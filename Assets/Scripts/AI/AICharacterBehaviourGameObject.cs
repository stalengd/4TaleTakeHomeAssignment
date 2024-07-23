using UnityEngine;
using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.AI
{
    public abstract class AICharacterBehaviourGameObject : MonoBehaviour, IAICharacterBehaviour
    {
        public ICharacter Character { get; private set; }

        public void MountCharacter(ICharacter character)
        {
            Character = character;
        }

        public abstract void DoTurn(IBattle battle);

        protected ICharacter GetOpposingTarget(IBattle battle)
        {
            var targets = battle.Characters.GetFractionCharacters(battle.GetOpponent(Character.Fraction));
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].IsAlive)
                {
                    return targets[i];
                }
            }
            return null;
        }
    }
}
