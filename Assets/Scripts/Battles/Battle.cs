using System.Collections.Generic;
using FourTale.TestCardGame.Characters;
using FourTale.TestCardGame.Players;

using UnityEngine.TextCore.Text;

namespace FourTale.TestCardGame.Battles
{
    public sealed class Battle : IBattle
    {
        public IBattleCharacters Characters { get; }
        public IPlayer ActivePlayer => _players[_activePlayer];

        public event System.Action<bool> Ended;

        private readonly IReadOnlyList<IPlayer> _players;
        private int _turnIndex = 0;
        private int _activePlayer = 0;

        public Battle(IBattleCharacters characters, IReadOnlyList<IPlayer> players)
        {
            Characters = characters;
            _players = players;
        }

        public void Begin()
        {
            foreach (var player in _players)
            {
                player.StartBattle(this);
            }
            StartTurn();
        }

        public void EndTurn()
        {
            foreach (var character in GetPlayerCharacters(ActivePlayer))
            {
                character.OnActiveTurnEnded();
            }
            if (CheckForPlayerLoose(_players[0]))
            {
                return;
            }
            if (CheckForPlayerLoose(_players[1]))
            {
                return;
            }

            _turnIndex++;
            _activePlayer = (_activePlayer + 1) % _players.Count;
            StartTurn();
        }

        public void End(Fraction winner)
        {
            foreach (var player in _players)
            {
                player.EndBattle(this);
                foreach (var character in GetPlayerCharacters(ActivePlayer))
                {
                    character.Dispose();
                }
            }
            Ended?.Invoke(winner == Fraction.Player);
        }

        public Fraction GetOpponent(Fraction fraction)
        {
            return fraction.Match(Fraction.Enemy, Fraction.Player);
        }

        private void StartTurn()
        {
            foreach (var character in GetPlayerCharacters(ActivePlayer))
            {
                character.OnActiveTurnStarted();
            }
            ActivePlayer.StartTurn();
        }

        private bool CheckForPlayerLoose(IPlayer player)
        {
            if (!IsAnyAlive(GetPlayerCharacters(player)))
            {
                End(GetOpponent(player.ControllableFraction));
                return true;
            }
            return false;
        }

        private bool IsAnyAlive(IReadOnlyList<ICharacter> characters)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].IsAlive)
                {
                    return true;
                }
            }
            return false;
        }

        private IReadOnlyList<ICharacter> GetPlayerCharacters(IPlayer player)
        {
            return Characters.GetFractionCharacters(player.ControllableFraction);
        }
    }
}
