using System.Text;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards.Effects
{
    public interface ICardEffect
    {
        bool CanApply(ICharacter actor, ICharacter target);
        bool TryApply(ICharacter actor, ICharacter target);
        void AppendDescription(StringBuilder stringBuilder);
    }
}