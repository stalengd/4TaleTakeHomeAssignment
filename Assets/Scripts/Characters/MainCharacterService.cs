using UnityEngine;

namespace FourTale.TestCardGame.Characters
{
    [CreateAssetMenu(menuName = "Data/Main Character")]
    public sealed class MainCharacterService : ScriptableObject, IMainCharacterService
    {
        [SerializeField] private int _health = 100;
        [SerializeField] private int _energy = 5;
        [SerializeField] private int _cardsDrawCount = 5;
        [SerializeField] private GameObject _prefab;

        public CharacterDescription CharacterDescription => new()
        {
            Health = _health,
            Prefab = _prefab
        };

        public int Energy => _energy;
        public int CardsDrawCount => _cardsDrawCount;
    }
}
