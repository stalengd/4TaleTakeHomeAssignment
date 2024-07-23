using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using FourTale.TestCardGame.Entry;
using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Battles.UI;
using FourTale.TestCardGame.Players;
using FourTale.TestCardGame.Characters;
using FourTale.TestCardGame.Characters.Rendering;
using FourTale.TestCardGame.Cards;

namespace FourTale.TestCardGame.DI
{
    public sealed class MainInstaller : MonoInstaller
    {
        [SerializeField] private BattlesProvider _battlesProvider;
        [SerializeField] private MainCharacterService _mainCharacterService;
        [SerializeField] private CharacterRenderersField _characterRenderersField;
        [SerializeField] private CardTypesProvider _cardTypesProvider;
        [SerializeField] private EventSystem _eventSystem;
        [Header("UI")]
        [SerializeField] private DeckInteractor _deckInteractor;
        [SerializeField] private EnergyDisplay _energyDisplay;
        [SerializeField] private NextTurnButton _nextTurnButton;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<BattlesRunner>()
                .AsSingle();

            Container
                .BindInterfacesTo<BattlesProvider>()
                .FromInstance(_battlesProvider);
            Container
                .BindInterfacesTo<BattleFactory>()
                .AsSingle();
            Container
                .BindInterfacesTo<LocalPlayerFactory>()
                .AsSingle();
            Container
                .BindInterfacesTo<CharactersFactory>()
                .AsSingle();
            Container
                .BindInterfacesTo<MainCharacterService>()
                .FromInstance(_mainCharacterService);
            Container
                .BindInterfacesTo<CharacterRenderersField>()
                .FromInstance(_characterRenderersField);
            Container
                .BindInterfacesTo<CollectedCardsService>()
                .AsSingle();
            Container
                .BindInterfacesTo<CardTypesProvider>()
                .FromInstance(_cardTypesProvider);
            Container
                .Bind<EventSystem>()
                .FromInstance(_eventSystem);

            Container
                .BindInterfacesTo<DeckInteractor>()
                .FromInstance(_deckInteractor);
            Container
                .BindInterfacesTo<EnergyDisplay>()
                .FromInstance(_energyDisplay);
            Container
                .BindInterfacesTo<NextTurnButton>()
                .FromInstance(_nextTurnButton);
        }
    }
}