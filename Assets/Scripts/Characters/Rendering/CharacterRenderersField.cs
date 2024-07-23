using UnityEngine;

namespace FourTale.TestCardGame.Characters.Rendering
{
    public sealed class CharacterRenderersField : MonoBehaviour, ICharacterRenderersField
    {
        [SerializeField] private Transform _mainCharacterPlace;
        [SerializeField] private Transform[] _enemyCharactersPlaces;

        public void PlaceCharacter(Fraction fraction, int index, GameObject gameObject)
        {
            if (fraction == Fraction.Player)
            {
                PlaceTo(gameObject, _mainCharacterPlace);
            }
            else
            {
                var l = _enemyCharactersPlaces.Length;
                PlaceTo(gameObject, _enemyCharactersPlaces[index % l], Vector2.up * (index / l));
            }
        }

        private void PlaceTo(GameObject gameObject, Transform place, Vector2 offset = default)
        {
            gameObject.transform.SetParent(place);
            gameObject.transform.position = place.position + (Vector3)offset;
        }
    }
}
