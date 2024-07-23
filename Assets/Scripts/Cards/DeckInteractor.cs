using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Zenject;
using FourTale.TestCardGame.Cards.Collections;
using FourTale.TestCardGame.Cards.UI;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards
{
    public sealed class DeckInteractor : MonoBehaviour, IDeckInteractor
    {
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private Transform _handCardsHolder;
        [SerializeField] private TMP_Text _drawPileText;
        [SerializeField] private TMP_Text _discardPileText;

        private readonly List<RaycastResult> _raycastResults = new();
        private readonly Dictionary<ICard, CardView> _cardViews = new();
        private EventSystem _eventSystem;
        private PointerEventData _pointerEvent;
        private IBattleDeck _deck;
        private System.Action<ICard, ICharacter> _cardUsed;
        private ICard _selectedCard;

        [Inject]
        public void Construct(EventSystem eventSystem)
        {
            _eventSystem = eventSystem;
            _pointerEvent = new(eventSystem);
        }

        private void Update()
        {
            UpdateSelectedCard();
        }

        public void MountDeck(IBattleDeck deck, System.Action<ICard, ICharacter> cardUsed)
        {
            DismountDeck();
            ClearHand();
            _deck = deck;
            _cardUsed = cardUsed;
            foreach (var card in deck.Hand.Cards)
            {
                CreateCardView(card);
            }
            deck.CardDrawn += OnCardDrawn;
            deck.CardDiscarded += OnCardDiscarded;
            deck.CardAddedToDrawPile += OnCardAddedToDrawPile;
            RefreshDiscardPileView();
            RefreshDrawPileView();
        }

        public void DismountDeck()
        {
            if (_deck == null)
            {
                return;
            }
            _deck.CardDrawn -= OnCardDrawn;
            _deck.CardDiscarded -= OnCardDiscarded;
            _deck.CardAddedToDrawPile -= OnCardAddedToDrawPile;
        }

        private CardView CreateCardView(ICard card)
        {
            if (!_cardViews.TryGetValue(card, out CardView view))
            {
                view = Instantiate(_cardPrefab, _handCardsHolder.transform)
                    .GetComponent<CardView>();
                _cardViews[card] = view;
            }
            view.Render(card, OnCardUseStarted);
            return view;
        }

        private void RemoveCardView(ICard card)
        {
            if (!_cardViews.Remove(card, out var view))
            {
                return;
            }
            Destroy(view.gameObject);
        }

        private void ClearHand()
        {
            foreach (Transform child in _handCardsHolder)
            {
                Destroy(child.gameObject);
            }
            _cardViews.Clear();
        }

        private void UpdateSelectedCard()
        {
            if (_selectedCard == null)
            {
                return;
            }
            if (!Input.GetKeyUp(KeyCode.Mouse0))
            {
                return;
            }
            var target = RaycastForCardTarget(Input.mousePosition);
            if (target != null)
            {
                _cardUsed?.Invoke(_selectedCard, target.Character);
            }
            _selectedCard = null;
        }

        private ICardTargetView RaycastForCardTarget(Vector2 screenPosition)
        {
            _pointerEvent.position = screenPosition;
            _raycastResults.Clear();

            _eventSystem.RaycastAll(_pointerEvent, _raycastResults);

            foreach (var result in _raycastResults)
            {
                if (result.gameObject.TryGetComponent<ICardTargetView>(out var target))
                {
                    return target;
                }
            }
            return null;
        }

        private void RefreshDrawPileView()
        {
            _drawPileText.text = _deck.DrawPileCount.ToString();
        }

        private void RefreshDiscardPileView()
        {
            _discardPileText.text = _deck.DiscardPileCount.ToString();
        }

        private void OnCardUseStarted(ICard card)
        {
            _selectedCard = card;
        }

        private void OnCardDrawn(ICard card)
        {
            CreateCardView(card);
            RefreshDrawPileView();
        }

        private void OnCardDiscarded(ICard card)
        {
            RemoveCardView(card);
            RefreshDiscardPileView();
        }

        private void OnCardAddedToDrawPile(ICard card)
        {
            RefreshDrawPileView();
            RefreshDiscardPileView();
        }
    }
}