using UnityEngine;
using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Cards;

namespace FourTale.TestCardGame.AI
{
    public sealed class AICharacterBehaviourUseRandomCard : AICharacterBehaviourGameObject
    {
        [SerializeField] private CardTypeGameObject[] _cards;

        public override void DoTurn(IBattle battle)
        {
            var card = _cards[Random.Range(0, _cards.Length)];
            if (card.CanUse(Character, Character))
            {
                card.ApplyEffects(Character, Character);
                return;
            }
            var target = GetOpposingTarget(battle);
            if (target == null)
            {
                return;
            }
            if (card.CanUse(Character, target))
            {
                card.ApplyEffects(Character, target);
                return;
            }
        }
    }
}
