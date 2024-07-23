using UnityEngine;

namespace FourTale.TestCardGame.Characters.Rendering
{
    public interface ICharacterRenderersField
    {
        void PlaceCharacter(Fraction fraction, int index, GameObject gameObject);
    }
}