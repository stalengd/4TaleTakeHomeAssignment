using System.Text;
using UnityEngine;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards.Effects
{
    public sealed class CardEffectHeal : CardEffectComponent
    {
        [SerializeField] private int _healAmount = 5;
        [SerializeField] private bool _isActorTargeted = false;

        public override bool CanApply(ICharacter actor, ICharacter target)
        {
            return _isActorTargeted || !actor.Fraction.IsAggressiveTo(target.Fraction);
        }

        public override void AppendDescription(StringBuilder description)
        {
            description.Append("Gain ");
            description.Append(_healAmount);
            description.Append(" HP.");
        }

        protected override void Apply(ICharacter actor, ICharacter target)
        {
            (_isActorTargeted ? actor : target).Heal(_healAmount);
        }
    }
}
