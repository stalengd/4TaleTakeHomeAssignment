using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FourTale.TestCardGame.Characters.Rendering
{
    public sealed class CharacterRenderer : MonoBehaviour, ICharacterRenderer
    {
        [SerializeField] private Image _healthFill;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _armorText;

        public void DisplayBlock(int amount)
        {

        }

        public void DisplayAttack(int amount)
        {

        }

        public void DisplayDamage(int amount)
        {

        }

        public void DisplayBlockedDamage(int amount)
        {

        }

        public void DisplayHeal(int amount)
        {

        }

        public void DisplayDeath()
        {
            gameObject.SetActive(false);
        }

        public void SetHealth(int health, int maxHealth)
        {
            _healthFill.fillAmount = (float)health / maxHealth;
            _healthText.text = $"{health}/{maxHealth}";
        }

        public void SetArmor(int armor)
        {
            _armorText.text = armor.ToString();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
