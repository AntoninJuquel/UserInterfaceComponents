using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UserInterfaceComponents.Components
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private string title;
        [TextArea(5, 10)] [SerializeField] private string message;
        private GraphicRaycaster _canvasRaycaster;

        private void Awake()
        {
            _canvasRaycaster = transform.root.GetComponent<GraphicRaycaster>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Tooltip.Instance
                .SetTitle(title)
                .SetMessage(message)
                .Show(gameObject, _canvasRaycaster);
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
                .Show(gameObject, _canvasRaycaster);
        }

        private void OnMouseExit()
        {
            Tooltip.Instance.Hide();
        }
    }
}