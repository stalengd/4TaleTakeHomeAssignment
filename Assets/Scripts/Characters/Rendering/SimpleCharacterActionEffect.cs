using TMPro;
using UnityEngine;

namespace FourTale.TestCardGame.Characters.Rendering
{
    public sealed class SimpleCharacterActionEffect : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _lifetime = 1f;
        [SerializeField] private Vector2 _movingSpeed = Vector2.up;

        private float _timer = 0f;

        private void Start()
        {
            Destroy(gameObject, _lifetime);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            transform.position += (Vector3)_movingSpeed * Time.deltaTime;
            var color = _text.color;
            color.a = 1f - _timer / _lifetime;
            _text.color = color;
        }

        public void Render(string name, int amount)
        {
            _text.text = $"{name} x{amount}";
        }
    }
}
