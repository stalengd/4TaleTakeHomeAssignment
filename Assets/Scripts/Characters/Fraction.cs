namespace FourTale.TestCardGame.Characters
{
    public readonly struct Fraction 
    {
        public static Fraction Player => new(false);
        public static Fraction Enemy => new(true);

        private readonly bool _isEnemy;

        private Fraction(bool isEnemy)
        {
            _isEnemy = isEnemy;
        }

        public bool IsAggressiveTo(Fraction other)
        {
            // For now every fraction is aggressive to each other
            return this != other;
        }

        public T Match<T>(T playerValue, T enemyValue)
        {
            return _isEnemy ? enemyValue : playerValue;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a._isEnemy == b._isEnemy;
        }

        public static bool operator !=(Fraction a, Fraction b) => !(a == b);

        public override bool Equals(object obj)
        {
            return obj is Fraction otherFraction && this == otherFraction;
        }

        public override int GetHashCode()
        {
            return _isEnemy.GetHashCode();
        }
    }
}
