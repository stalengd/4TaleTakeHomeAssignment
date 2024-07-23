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
        [SerializeField] private RectTransform _body;
        [SerializeField] private Vector2 _bodyDefaultOffset;
        [SerializeField] private Vector2 _bodySelectedOffset;
        [SerializeField] private float _animationSmoothing = 5f;
        [SerializeField] private float _angleSpread = 5f;

        private readonly StringBuilder _description = new();
        private ICard _card;
        private System.Action<ICard> _selected;
        private bool _isSelected = false;

        private void Update()
        {
            _body.localPosition = Vector3.Lerp(
                _body.localPosition,
                _isSelected ? _bodySelectedOffset : _bodyDefaultOffset,
                _animationSmoothing * Time.deltaTime);
            var index = transform.GetSiblingIndex();
            _body.rotation = Quaternion.Euler(0f, 0f, -((float)index / Mathf.Max(transform.parent.childCount - 1, 1) * 2f - 1f) * _angleSpread);
        }

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

        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
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