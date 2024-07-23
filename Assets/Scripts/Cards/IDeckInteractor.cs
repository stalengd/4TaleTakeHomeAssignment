using System;
using FourTale.TestCardGame.Cards.Collections;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards
{
    public interface IDeckInteractor
    {
        void MountDeck(IBattleDeck deck, Action<ICard, ICharacter> cardUsed);
        void DismountDeck();
    }
}