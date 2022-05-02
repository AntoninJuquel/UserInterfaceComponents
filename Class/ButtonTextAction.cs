using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UserInterfaceComponents.ScriptableObjects;

namespace UserInterfaceComponents.Class
{
    [System.Serializable]
    public class ButtonTextAction
    {
        [SerializeField] private Button button;
        [SerializeField] private SpriteColorPreset background;
        private TextMeshProUGUI _text;
        private UnityAction[] _unityActions;

        public void Init()
        {
            _text = button.GetComponentInChildren<TextMeshProUGUI>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Action);
            button.image.sprite = background.sprite;
            button.image.color = background.color;
        }

        private void Action()
        {
            foreach (var unityAction in _unityActions)
            {
                unityAction?.Invoke();
            }
        }

        public ButtonTextAction SetText(string value)
        {
            _text.text = value;
            return this;
        }

        public ButtonTextAction SetAction(UnityAction action)
        {
            _unityActions = new[] {action};
            return this;
        }

        public ButtonTextAction SetActions(UnityAction[] actions)
        {
            _unityActions = actions;
            return this;
        }

        public void SetActive(bool value) => button.gameObject.SetActive(value);
    }
}