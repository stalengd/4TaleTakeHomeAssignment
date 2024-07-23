using System;

namespace FourTale.TestCardGame.Cards.UI
{
    public interface IDeckView
    {
        void ClearHand();
        CardView CreateCardView(ICard card, Action<ICard> useStarted);
        void RemoveCardView(ICard card);
        void SetDiscardPile(int count);
        void SetDrawPile(int count);
    }
}