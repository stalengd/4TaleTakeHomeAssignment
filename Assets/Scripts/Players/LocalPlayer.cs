using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Battles.UI;
using FourTale.TestCardGame.Cards;
using FourTale.TestCardGame.Cards.Collections;
using FourTale.TestCardGame.Characters;

namespace FourTale.TestCardGame.Players
{
    public sealed class LocalPlayer : IPlayer
    {
        public int MaxEnergy { get; private set; }
        public int CurrentEnergy
        {
            get => _currentEnergy;
            private set
            {
                _currentEnergy = value;
                _energyDisplay.Show(_currentEnergy, MaxEnergy);
            }
        }
        public Fraction ControllableFraction => Fraction.Player;

        private bool IsMyTurn => _battle.ActivePlayer == this;

        private readonly IDeckInteractor _deckInteractor;
        private readonly IMainCharacterService _mainCharacterService;
        private readonly INextTurnButton _nextTurnButton;
        private readonly IEnergyDisplay _energyDisplay;

        private IBattle _battle;
        private IBattleDeck _deck;
        private ICharacter _mainCharacter;
        private int _currentEnergy;

        public LocalPlayer(
            IDeckInteractor deckInteractor,
            IMainCharacterService mainCharacterService,
            INextTurnButton nextTurnButton,
            IEnergyDisplay energyDisplay)
        {
            _deckInteractor = deckInteractor;
            _mainCharacterService = mainCharacterService;
            _nextTurnButton = nextTurnButton;
            _energyDisplay = energyDisplay;
        }

        public void Initialize(IBattleDeck deck)
        {
            _deck = deck;
        }

        public void StartBattle(IBattle battle)
        {
            _battle = battle;
            _deckInteractor.MountDeck(_deck, OnCardUse);
            _mainCharacter = _battle.Characters.GetFractionCharacters(ControllableFraction)[0];
            MaxEnergy = _mainCharacterService.Energy;
        }

        public void EndBattle(IBattle battle)
        {
            _deckInteractor.DismountDeck();
        }

        public void StartTurn()
        {
            var drawAmount = _mainCharacterService.CardsDrawCount;
            _deck.Draw(drawAmount);
            CurrentEnergy = MaxEnergy;
            _nextTurnButton.Show(EndTurn);
        }

        private void EndTurn()
        {
            if (!IsMyTurn)
            {
                return;
            }
            _nextTurnButton.Hide();
            _deck.DiscardAll();
            _battle.EndTurn();
        }

        private void OnCardUse(ICard card, ICharacter target)
        {
            if (!IsMyTurn)
            {
                return;
            }
            if (CurrentEnergy < card.Type.EnergyPrice)
            {
                return;
            }
            var actor = _mainCharacter;
            if (!card.Type.CanUse(_mainCharacter, target))
            {
                return;
            }
            CurrentEnergy -= card.Type.EnergyPrice;
            _deck.Discard(card);
            card.Type.ApplyEffects(actor, target);
        }
    }
}
