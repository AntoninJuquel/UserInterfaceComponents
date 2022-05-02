using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UserInterfaceComponents
{
    public class FlexButton : Button
    {
        [SerializeField] private float animationDuration;
        [SerializeField] private AnimationCurve animationCurve;

        private Tweener _tweener;

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            _tweener = DOVirtual
                .Vector3(transform.localScale, Vector3.one * 1.1f, animationDuration, scale => transform.localScale = scale)
                .SetEase(animationCurve)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            _tweener.Kill();
            DOVirtual
                .Vector3(transform.localScale, Vector3.one, animationDuration * .1f, scale => transform.localScale = scale)
                .SetEase(animationCurve);
        }


        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
        }
    }
}