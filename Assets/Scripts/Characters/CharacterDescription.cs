using UnityEngine;

namespace FourTale.TestCardGame.Characters
{
    [System.Serializable]
    public struct CharacterDescription
    {
        public int Health
        {
            get => _health;
            set => _health = value;
        }
        [SerializeField] private int _health;

        public GameObject Prefab
        {
            get => _prefab;
            set => _prefab = value;
        }
        [SerializeField] private GameObject _prefab;
    }
}
