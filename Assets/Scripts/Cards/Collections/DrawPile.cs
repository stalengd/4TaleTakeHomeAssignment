using System.Collections.Generic;
using UnityEngine;

namespace FourTale.TestCardGame.Cards.Collections
{
    public sealed class DrawPile : IDrawPile
    {
        public int CardsCount => _stack.Count;

        private readonly List<ICard> _stack = new();

        public ICard DrawOrDefault()
        {
            if (CardsCount == 0)
            {
                return null;
            }
            var cardAtTop = _stack[^1];
            _stack.RemoveAt(_stack.Count - 1);
            return cardAtTop;
        }

        public void AddRandom(ICard card)
        {
            _stack.Insert(Random.Range(0, _stack.Count), card);
        }

        public void AddToTop(ICard card)
        {
            _stack.Add(card);
        }
    }
}
