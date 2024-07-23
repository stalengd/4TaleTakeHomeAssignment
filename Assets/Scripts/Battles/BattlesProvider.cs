using UnityEngine;

namespace FourTale.TestCardGame.Battles
{
    [CreateAssetMenu(menuName = "Data/Battles Provider")]
    public sealed class BattlesProvider : ScriptableObject, IBattlesProvider
    {
        [SerializeField] private BattleDescriptionStatic[] _battles;

        public IBattleDescription GetOrDefault(int index)
        {
            return index < _battles.Length ? _battles[index] : null;
        }
    }
}
