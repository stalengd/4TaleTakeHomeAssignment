using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using FourTale.TestCardGame.Cards.Collections;
using FourTale.TestCardGame.Cards.UI;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Cards
{
    public sealed class DeckPresenter : IDeckPresenter, ITickable
    {
        private readonly List<RaycastResult> _raycastResults = new();
        private readonly IDeckView _deckView;
        private readonly EventSystem _eventSystem;
        private readonly PointerEventData _pointerEvent;
        private IBattleDeck _deck;
        private System.Action<ICard, ICharacter> _cardUsed;
        private ICard _selectedCard;

        public DeckPresenter(IDeckView deckView, EventSystem eventSystem)
        {
            _deckView = deckView;
            _eventSystem = eventSystem;
            _pointerEvent = new(eventSystem);
        }

        public void Tick()
        {
            UpdateSelectedCard();
        }

        public void MountDeck(IBattleDeck deck, System.Action<ICard, ICharacter> cardUsed)
        {
            DismountDeck();
            _deckView.ClearHand();
            _deck = deck;
            _cardUsed = cardUsed;
            foreach (var card in deck.Hand.Cards)
            {
                _deckView.CreateCardView(card, OnCardUseStarted);
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
            _deckView.SetDrawPile(_deck.DrawPileCount);
        }

        private void RefreshDiscardPileView()
        {
            _deckView.SetDiscardPile(_deck.DiscardPileCount);
        }

        private void OnCardUseStarted(ICard card)
        {
            _selectedCard = card;
        }

        private void OnCardDrawn(ICard card)
        {
            _deckView.CreateCardView(card, OnCardUseStarted);
            RefreshDrawPileView();
        }

        private void OnCardDiscarded(ICard card)
        {
            _deckView.RemoveCardView(card);
            RefreshDiscardPileView();
        }

        private void OnCardAddedToDrawPile(ICard card)
        {
            RefreshDrawPileView();
            RefreshDiscardPileView();
        }
    }
}