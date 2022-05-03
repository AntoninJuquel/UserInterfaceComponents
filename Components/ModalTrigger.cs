using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UserInterfaceComponents.Components
{
    public class ModalTrigger : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string title;
        [TextArea(5, 10)] [SerializeField] private string message;
        [SerializeField] private Sprite image;
        [SerializeField] private string confirmButton;
        [SerializeField] private UnityEvent onConfirmEvent;
        [SerializeField] private string cancelButton;
        [SerializeField] private UnityEvent onCancelEvent;

        public void OnPointerDown(PointerEventData eventData)
        {
            Modal.Instance
                .Init()
                .SetTitle(title)
                .SetMessage(message)
                .SetImage(image)
                .SetConfirmButton(confirmButton, () => onConfirmEvent?.Invoke())
                .SetCancelButton(cancelButton, () => onCancelEvent?.Invoke())
                .Show();
        }
    }
}