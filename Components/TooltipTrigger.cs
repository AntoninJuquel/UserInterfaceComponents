using UnityEngine;
using UnityEngine.EventSystems;

namespace UserInterfaceComponents.Components
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private string title;
        [TextArea(5, 10)] [SerializeField] private string message;

        public void OnPointerEnter(PointerEventData eventData)
        {
            Tooltip.Instance
                .SetTitle(title)
                .SetMessage(message)
                .Show();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Tooltip.Instance.Hide();
        }

        private void OnMouseEnter()
        {
            Tooltip.Instance
                .SetTitle(title)
                .SetMessage(message)
                .Show();
        }

        private void OnMouseExit()
        {
            Tooltip.Instance.Hide();
        }
    }
}