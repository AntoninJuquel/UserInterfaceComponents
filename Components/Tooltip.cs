using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace UserInterfaceComponents.Components
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private InputSystemUIInputModule inputModule;
        [SerializeField] private TextMeshProUGUI title, message;
        [SerializeField] private int characterWrapLimit;
        private LayoutElement _layoutElement;
        private Canvas _canvas;
        private RectTransform _rectTransform, _parent;
        public static Tooltip Instance;

        private void Awake()
        {
            Instance = this;
            _layoutElement = GetComponent<LayoutElement>();
            _canvas = GetComponentInParent<Canvas>();
            _rectTransform = GetComponent<RectTransform>();
            _parent = transform.parent as RectTransform;
            Hide();
        }

        public Tooltip SetTitle(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text)) return Instance;
            title.text = text;
            title.gameObject.SetActive(true);
            return Instance;
        }

        public Tooltip SetMessage(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text)) return Instance;
            message.text = text;
            message.gameObject.SetActive(true);
            return Instance;
        }

        public void Hide()
        {
            title.gameObject.SetActive(false);
            title.text = "";
            message.gameObject.SetActive(false);
            message.text = "";
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            var titleLength = title.text.Length;
            var messageLength = message.text.Length;

            _layoutElement.enabled = (titleLength > characterWrapLimit || messageLength > characterWrapLimit);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_parent, Mouse.current.position.ReadValue(), _canvas.worldCamera, out var anchoredPos);

            if (anchoredPos.x + _rectTransform.rect.width > _parent.rect.width * .5f)
            {
                anchoredPos.x = _parent.rect.width * .5f - _rectTransform.rect.width;
            }

            if (anchoredPos.y + _rectTransform.rect.height > _parent.rect.height * .5f)
            {
                anchoredPos.y = _parent.rect.height * .5f - _rectTransform.rect.height;
            }

            _rectTransform.anchoredPosition = anchoredPos;
        }
    }
}