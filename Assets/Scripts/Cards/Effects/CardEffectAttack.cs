using System.Text;
using UnityEngine;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards.Effects
{
    public sealed class CardEffectAttack : CardEffectComponent
    {
        [SerializeField] private int _damage = 5;

        public override bool CanApply(ICharacter actor, ICharacter target)
        {
            return actor.Fraction.IsAggressiveTo(target.Fraction);
        }
        
        public override void AppendDescription(StringBuilder description)
        {
            description.Append("Deal ");
            description.Append(_damage);
            description.Append(" damage.");
        }

        protected override void Apply(ICharacter actor, ICharacter target)
        {
            actor.AttackOther(target, _damage);
        }
    }
}
