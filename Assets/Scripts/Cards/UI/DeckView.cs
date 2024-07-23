using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FourTale.TestCardGame.Cards.UI
{
    public sealed class DeckView : MonoBehaviour, IDeckView
    {
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private Transform _handCardsHolder;
        [SerializeField] private TMP_Text _drawPileText;
        [SerializeField] private TMP_Text _discardPileText;

        private readonly Dictionary<ICard, CardView> _cardViews = new();


        public CardView CreateCardView(ICard card, System.Action<ICard> useStarted)
        {
            if (!_cardViews.TryGetValue(card, out CardView view))
            {
                view = Instantiate(_cardPrefab, _handCardsHolder.transform)
                    .GetComponent<CardView>();
                _cardViews[card] = view;
            }
            view.Render(card, useStarted);
            return view;
        }

        public void RemoveCardView(ICard card)
        {
            if (!_cardViews.Remove(card, out var view))
            {
                return;
            }
            Destroy(view.gameObject);
        }

        public void ClearHand()
        {
            foreach (Transform child in _handCardsHolder)
            {
                Destroy(child.gameObject);
            }
            _cardViews.Clear();
        }

        public void SetDrawPile(int count)
        {
            _drawPileText.text = count.ToString();
        }

        public void SetDiscardPile(int count)
        {
            _discardPileText.text = count.ToString();
        }
    }
}
