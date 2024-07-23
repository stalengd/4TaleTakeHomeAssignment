using System;

namespace FourTale.TestCardGame.Battles.UI
{
    public interface INextTurnButton
    {
        void Show(Action clicked);
        void Hide();
    }
}