using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UserInterfaceComponents.Animations;

namespace UserInterfaceComponents.Components
{
    public class FlexAnimationTweener
    {
        public FlexAnimation FlexAnimation { get; private set; }
        public Tweener Tweener { get; private set; }

        public FlexAnimationTweener(FlexAnimation animation, Tweener tweener)
        {
            FlexAnimation = animation;
            Tweener = tweener;
        }
    }

    public class FlexAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler
    {
        [SerializeField] private FlexAnimation[] onEnableAnimations, onPointerEnterAnimations, onPointerExitAnimations, onPointerDownAnimations, onPointerUpAnimations;
        private readonly List<FlexAnimationTweener> _tweeners = new List<FlexAnimationTweener>();

        private void StartTweeners(IEnumerable<FlexAnimation> flexAnimations)
        {
            foreach (var flexAnimation in flexAnimations)
            {
                _tweeners.Add(new FlexAnimationTweener(flexAnimation, flexAnimation.Animate(gameObject)));
            }
        }

        private void StopAllTweeners()
        {
            foreach (var tweener in _tweeners)
            {
                if (tweener.FlexAnimation.autoKill)
                    tweener.Tweener.Kill();
            }

            _tweeners.RemoveAll(tweener => tweener.FlexAnimation.autoKill);
        }

        private void OnEnable()
        {
            StopAllTweeners();
            StartTweeners(onEnableAnimations);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            StopAllTweeners();
            StartTweeners(onPointerEnterAnimations);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllTweeners();
            StartTweeners(onPointerExitAnimations);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StopAllTweeners();
            StartTweeners(onPointerDownAnimations);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StopAllTweeners();
            StartTweeners(onPointerUpAnimations);
        }

        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log("Selected");
        }
    }
}