using System.Collections.Generic;
using UnityEngine;

namespace FourTale.TestCardGame.Cards
{
    [CreateAssetMenu(menuName = "Data/Cards/Card Types Provider")]
    public sealed class CardTypesProvider : ScriptableObject, ICardTypesProvider
    {
        [SerializeField] private List<CardTypeGameObject> _initialCards = new();
        [SerializeField] private List<CardTypeGameObject> _allCards = new();

        public IEnumerable<ICardType> GetInitial()
        {
            return _initialCards;
        }

        public IEnumerable<ICardType> GetAll()
        {
            return _allCards;
        }
    }
}
