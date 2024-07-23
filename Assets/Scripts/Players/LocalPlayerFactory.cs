using Zenject;
using FourTale.TestCardGame.Cards.Collections;

namespace FourTale.TestCardGame.Players
{
    public sealed class LocalPlayerFactory : ILocalPlayerFactory
    {
        private readonly IInstantiator _instantiator;

        public LocalPlayerFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public LocalPlayer Create(IBattleDeck battleDeck)
        {
            var player = _instantiator.Instantiate<LocalPlayer>();
            player.Initialize(battleDeck);
            return player;
        }
    }
}
