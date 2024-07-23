namespace FourTale.TestCardGame.Characters.Rendering
{
    public interface ICharacterRenderer
    {
        void DisplayAttack(int amount);
        void DisplayBlock(int amount);
        void DisplayDamage(int amount);
        void DisplayBlockedDamage(int amount);
        void DisplayHeal(int amount);
        void DisplayDeath();
        void SetArmor(int armor);
        void SetHealth(int health, int maxHealth);
        void Dispose();
    }
}