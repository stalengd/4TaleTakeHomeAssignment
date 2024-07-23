using UnityEngine;
using FourTale.TestCardGame.Characters;
using System.Text;

namespace FourTale.TestCardGame.Cards.Effects
{
    public abstract class CardEffectComponent : MonoBehaviour, ICardEffect
    {
        public abstract bool CanApply(ICharacter actor, ICharacter target);
        public abstract void AppendDescription(StringBuilder stringBuilder);

        public bool TryApply(ICharacter actor, ICharacter target)
        {
            if (!CanApply(actor, target))
            {
                return false;
            }
            Apply(actor, target);
            return true;
        }

        protected abstract void Apply(ICharacter actor, ICharacter target);
    }
}
