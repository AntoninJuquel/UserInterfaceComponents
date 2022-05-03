using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UserInterfaceComponents.Components
{
    public class Tooltip : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI title, message;
        [SerializeField] private int characterWrapLimit;
        private LayoutElement _layoutElement;
        private Canvas _canvas;
        private RectTransform _rectTransform, _parent;
        private GraphicRaycaster _raycaster, _triggerRaycaster;
        private GameObject _lastTrigger;
        public static Tooltip Instance;

        private void Awake()
        {
            Instance = this;
            _layoutElement = GetComponent<LayoutElement>();
            _canvas = GetComponentInParent<Canvas>();
            _raycaster = GetComponentInParent<GraphicRaycaster>();
            _rectTransform = GetComponent<RectTransform>();
            _parent = transform.parent as RectTransform;
            Hide();
        }

        private Vector2 ComputedAnchor(Vector2 anchoredPos)
        {
            if (anchoredPos.x + _rectTransform.rect.width > _parent.rect.width * .5f)
            {
                anchoredPos.x = _parent.rect.width * .5f - _rectTransform.rect.width;
            }

            if (anchoredPos.y + _rectTransform.rect.height > _parent.rect.height * .5f)
            {
                anchoredPos.y = _parent.rect.height * .5f - _rectTransform.rect.height;
            }

            return anchoredPos;
        }

        private static bool MouseOver(Object toCheck, GraphicRaycaster raycaster)
        {
            if (!raycaster) return false;

            //Set up the new Pointer Event
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                //Set the Pointer Event Position to that of the mouse position
                position = Mouse.current.position.ReadValue()
            };

            //Create a list of Raycast Results
            var results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            raycaster.Raycast(pointerEventData, results);

            return results.Exists(res => res.gameObject == toCheck);
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
            if (MouseOver(gameObject, _raycaster) || MouseOver(_lastTrigger, _triggerRaycaster)) return;

            title.gameObject.SetActive(false);
            title.text = "";
            message.gameObject.SetActive(false);
            message.text = "";
            gameObject.SetActive(false);
            _lastTrigger = null;
            _triggerRaycaster = null;
        }

        public void Show(GameObject trigger, GraphicRaycaster raycaster)
        {
            if (trigger == _lastTrigger) return;

            gameObject.SetActive(true);

            var titleLength = title.text.Length;
            var messageLength = message.text.Length;

            _layoutElement.enabled = (titleLength > characterWrapLimit || messageLength > characterWrapLimit);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_parent, Mouse.current.position.ReadValue(), _canvas.worldCamera, out var anchoredPos);

            _rectTransform.anchoredPosition = ComputedAnchor(anchoredPos);

            _triggerRaycaster = raycaster;
            _lastTrigger = trigger;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Hide();
        }
    }
}