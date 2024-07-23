using UnityEngine;
using UnityEngine.UI;

namespace FourTale.TestCardGame.Battles.UI
{
    public sealed class NextTurnButton : MonoBehaviour, INextTurnButton
    {
        [SerializeField] private Button _button;

        private System.Action _clicked;

        private void Start()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public void Show(System.Action clicked)
        {
            gameObject.SetActive(true);
            _clicked = clicked;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnClicked()
        {
            _clicked?.Invoke();
        }
    }
}
