using DG.Tweening;
using UnityEngine;

namespace UserInterfaceComponents.Animations
{
    [CreateAssetMenu(menuName = "User Interface Components/Animation/Scale")]
    public class ScaleAnimation : FlexAnimation
    {
        public Vector3 from, to;

        public override Tweener Animate(GameObject gameObject)
        {
            var animationTime = Vector3.Distance(to, relativeStart ? gameObject.transform.localScale : from) / Vector3.Distance(to, from) * animationDuration;
            var animation = DOVirtual
                .Vector3(relativeStart ? gameObject.transform.localScale : from, to, animationTime, v => gameObject.transform.localScale = v)
                .SetLoops(loops, loopType);
            return UseCurve ? animation.SetEase(animationCurve) : animation.SetEase(ease);
        }
    }
}