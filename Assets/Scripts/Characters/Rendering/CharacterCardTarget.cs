using UnityEngine;
using FourTale.TestCardGame.Cards.UI;

namespace FourTale.TestCardGame.Characters.Rendering
{
    public sealed class CharacterCardTarget : MonoBehaviour, ICardTargetView
    {
        public ICharacter Character { get; private set; }

        public void Bind(ICharacter character)
        {
            Character = character;
        }
    }
}
