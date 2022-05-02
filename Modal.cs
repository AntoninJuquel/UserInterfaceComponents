using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UserInterfaceComponents.Class;

namespace UserInterfaceComponents
{
    public class Modal : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title, message;
        [SerializeField] private Image image;
        [SerializeField] private ButtonTextAction cancelButton, confirmButton;
        private Canvas _canvas;
        private Queue<ModalProps> _modalQueue = new Queue<ModalProps>();
        private ModalProps _modalProps;

        public static Modal Instance;

        private void Awake()
        {
            Instance = this;
            _canvas = GetComponent<Canvas>();
            cancelButton.Init();
            confirmButton.Init();
            Hide();
        }

        private void ResetModal()
        {
            title.gameObject.SetActive(false);
            message.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
            cancelButton.SetActive(false);
            confirmButton.SetActive(false);
        }

        private void Hide()
        {
            _canvas.enabled = false;
            HandleQueue();
        }

        private void HandleQueue()
        {
            if (_modalQueue.Count == 0) return;
            if (_canvas.enabled) return;

            ResetModal();

            var modal = _modalQueue.Dequeue();

            if (modal.Title != default)
            {
                title.text = modal.Title;
                title.gameObject.SetActive(true);
            }

            if (modal.Message != default)
            {
                message.text = modal.Message;
                message.gameObject.SetActive(true);
            }

            if (modal.Image != default)
            {
                image.sprite = modal.Image;
                image.gameObject.SetActive(true);
            }

            if (modal.CancelText != default)
            {
                cancelButton.SetText(modal.CancelText);
                cancelButton.SetActions(modal.CancelActions);
                cancelButton.SetActive(true);
            }

            if (modal.ConfirmText != default)
            {
                confirmButton.SetText(modal.ConfirmText);
                confirmButton.SetActions(modal.ConfirmActions);
                confirmButton.SetActive(true);
            }

            _canvas.enabled = true;
        }

        public Modal Init()
        {
            _modalProps = new ModalProps();
            return Instance;
        }

        public Modal SetTitle(string text)
        {
            _modalProps.Title = text;
            return Instance;
        }

        public Modal SetMessage(string text)
        {
            _modalProps.Message = text;
            return Instance;
        }

        public Modal SetImage(Sprite sprite)
        {
            _modalProps.Image = sprite;
            return Instance;
        }

        public Modal SetCancelButton(string text)
        {
            _modalProps.CancelText = text;
            _modalProps.CancelActions = new UnityAction[] {Hide};
            return Instance;
        }

        public Modal SetCancelButton(string text, UnityAction action)
        {
            _modalProps.CancelText = text;
            _modalProps.CancelActions = new[] {action, Hide};
            return Instance;
        }

        public Modal SetConfirmButton(string text)
        {
            _modalProps.ConfirmText = text;
            _modalProps.ConfirmActions = new UnityAction[] {Hide};
            return Instance;
        }

        public Modal SetConfirmButton(string text, UnityAction action)
        {
            _modalProps.ConfirmText = text;
            _modalProps.ConfirmActions = new[] {action, Hide};
            return Instance;
        }

        public void Show()
        {
            _modalQueue.Enqueue(_modalProps);
            HandleQueue();
        }
    }
}