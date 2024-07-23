using System.Text;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards
{
    public interface ICardType
    {
        int EnergyPrice { get; }
        string Name { get; }
        bool CanUse(ICharacter actor, ICharacter target);
        void ApplyEffects(ICharacter actor, ICharacter target);
        void FillDescription(StringBuilder descriptionBuilder);
    }
}
