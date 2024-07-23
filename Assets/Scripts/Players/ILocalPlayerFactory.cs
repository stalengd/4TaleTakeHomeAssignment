using FourTale.TestCardGame.Cards.Collections;

namespace FourTale.TestCardGame.Players
{
    public interface ILocalPlayerFactory
    {
        LocalPlayer Create(IBattleDeck battleDeck);
    }
}