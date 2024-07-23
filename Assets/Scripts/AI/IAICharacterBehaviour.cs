using FourTale.TestCardGame.Battles;

namespace FourTale.TestCardGame.AI
{
    public interface IAICharacterBehaviour
    {
        void DoTurn(IBattle battle);
    }
}
