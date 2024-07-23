using FourTale.TestCardGame.Characters;
using FourTale.TestCardGame.Players;

namespace FourTale.TestCardGame.Battles
{
    public interface IBattle
    {
        IPlayer ActivePlayer { get; }
        IBattleCharacters Characters { get; }

        public event System.Action<bool> Ended;

        void Begin();
        void End(Fraction winner);
        void EndTurn();
        Fraction GetOpponent(Fraction fraction);
    }
}