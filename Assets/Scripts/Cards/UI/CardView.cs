using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FourTale.TestCardGame.Cards.UI
{
    public sealed class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private TMP_Text _energyPriceText;

        private readonly StringBuilder _description = new();
        private ICard _card;
        private System.Action<ICard> _selected;

        public void Render(ICard card, System.Action<ICard> selected)
        {
            _card = card;
            _selected = selected;
            _nameText.text = card.Type.Name;
            _description.Clear();
            card.Type.FillDescription(_description);
            _descriptionText.SetText(_description);
            _energyPriceText.text = card.Type.EnergyPrice.ToString();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _selected?.Invoke(_card);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // This should be implemented in order to OnBegin to work, hence do nothing
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // This should be implemented in order to OnBegin to work, hence do nothing
        }
    }
}