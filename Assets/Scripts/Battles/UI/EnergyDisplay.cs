using TMPro;
using UnityEngine;

namespace FourTale.TestCardGame.Battles.UI
{
    public sealed class EnergyDisplay : MonoBehaviour, IEnergyDisplay
    {
        [SerializeField] private TMP_Text _energyText;

        public void Show(int energy, int maxEnergy)
        {
            _energyText.text = $"{energy}/{maxEnergy}";
        }
    }
}
