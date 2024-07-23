using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Players
{
    public interface IPlayer
    {
        Fraction ControllableFraction { get; }
        void StartBattle(IBattle battle);
        void EndBattle(IBattle battle);
        void StartTurn();
    }
}
