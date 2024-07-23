using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using FourTale.TestCardGame.Battles;

namespace FourTale.TestCardGame.Entry
{
    public sealed class BattlesRunner : IInitializable
    {
        private readonly IBattlesProvider _battlesProvider;
        private readonly IBattleFactory _battleFactory;

        private IBattle _currentBattle;
        private int _currentBattleIndex = 0;

        public BattlesRunner(IBattlesProvider battlesProvider, IBattleFactory battleFactory)
        {
            _battlesProvider = battlesProvider;
            _battleFactory = battleFactory;
        }

        public void Initialize()
        {
            RunBattle();
        }

        private void RunBattle()
        {
            var description = _battlesProvider.GetOrDefault(_currentBattleIndex);
            if (description == null)
            {
                ExitSuccessfuly();
                return;
            }
            var battle = _battleFactory.CreateBattle(description);
            _currentBattle = battle;
            battle.Ended += OnBattleEnded; 
            battle.Begin();
        }

        private void ExitSuccessfuly()
        {
            Debug.Log("All battles ended");
        }

        private void ExitLoose()
        {
            Debug.Log("You lost!");
        }

        private void OnBattleEnded(bool isPlayerWin)
        {
            _currentBattle = null;
            if (isPlayerWin)
            {
                _currentBattleIndex++;
                RunBattle();
            }
            else
            {
                ExitLoose();
            }
        }
    }
}
