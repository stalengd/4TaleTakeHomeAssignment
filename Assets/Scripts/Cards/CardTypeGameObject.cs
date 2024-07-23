using System.Text;
using System.Collections.Generic;
using UnityEngine;
using FourTale.TestCardGame.Characters;
using FourTale.TestCardGame.Cards.Effects;

namespace FourTale.TestCardGame.Cards
{
    public sealed class CardTypeGameObject : MonoBehaviour, ICardType
    {
        [SerializeField] private int _energyPrice = 1;
        [SerializeField] private string _name = "Noname";

        public int EnergyPrice => _energyPrice;
        public string Name => _name;

        private List<ICardEffect> _effects = new();
        [System.NonSerialized]
        private bool _isInitialized = false;

        public bool CanUse(ICharacter actor, ICharacter target)
        {
            EnsureInitialized();
            foreach (var effect in _effects)
            {
                if (!effect.CanApply(actor, target))
                {
                    return false;
                }
            }
            return true;
        }

        public void ApplyEffects(ICharacter actor, ICharacter target)
        {
            EnsureInitialized();
            foreach (var effect in _effects)
            {
                effect.TryApply(actor, target);
            }
        }

        public void FillDescription(StringBuilder descriptionBuilder)
        {
            EnsureInitialized();
            foreach(var effect in _effects)
            {
                effect.AppendDescription(descriptionBuilder);
                descriptionBuilder.AppendLine();
            }
        }

        private void EnsureInitialized()
        {
            if (_isInitialized)
            {
                return;
            }
            _isInitialized = true;
            GetComponents(_effects);
        }
    }
}
