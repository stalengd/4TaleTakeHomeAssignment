namespace FourTale.TestCardGame.Characters
{
    public interface ICharacter 
    {
        Fraction Fraction { get; }
        int MaxHealth { get; }
        int Health { get; }
        bool IsAlive { get; }

        void OnActiveTurnStarted();
        void OnActiveTurnEnded();
        void AttackOther(ICharacter target, int damageAmount);
        void DealDamage(int amount);
        void ApplyArmor(int amount);
        void Heal(int amount);
        void Dispose();
    }
}
