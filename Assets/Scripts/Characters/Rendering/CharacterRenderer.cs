using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FourTale.TestCardGame.Characters.Rendering
{
    public sealed class CharacterRenderer : MonoBehaviour, ICharacterRenderer
    {
        [SerializeField] private GameObject _effectPrefab;
        [SerializeField] private Image _healthFill;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _armorText;

        public void DisplayBlock(int amount)
        {
            CreateTextEffect("Block", amount);
        }

        public void DisplayAttack(int amount)
        {
            CreateTextEffect("Attack", amount);
        }

        public void DisplayDamage(int amount)
        {
            CreateTextEffect("Damage", amount);
        }

        public void DisplayBlockedDamage(int amount)
        {
            CreateTextEffect("Blocked", amount);
        }

        public void DisplayHeal(int amount)
        {
            CreateTextEffect("Heal", amount);
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

        private void CreateTextEffect(string name, int count)
        {
            var effect = Instantiate(_effectPrefab, transform.position, Quaternion.identity)
                .GetComponent<SimpleCharacterActionEffect>();
            effect.Render(name, count);
        }
    }
}
