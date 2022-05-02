using UnityEngine;
using UnityEngine.Events;

namespace UserInterfaceComponents.Class
{
    public class ModalProps
    {
        public string Title, Message, CancelText, ConfirmText;
        public Sprite Image;
        public UnityAction[] CancelActions, ConfirmActions;
    }
}