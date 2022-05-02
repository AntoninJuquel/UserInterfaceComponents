using DG.Tweening;
using UnityEngine;

namespace UserInterfaceComponents.Animations
{
    [CreateAssetMenu(menuName = "Animation/Scale")]
    public class ScaleAnimation : FlexAnimation
    {
        public Vector3 from, to;

        public override Tweener Animate(GameObject gameObject)
        {
            var animationTime = (to - (relativeStart ? gameObject.transform.localScale : from)).magnitude / (to - from).magnitude * animationDuration;
            var animation = DOVirtual
                .Vector3(relativeStart ? gameObject.transform.localScale : from, to, animationTime, v => gameObject.transform.localScale = v)
                .SetLoops(loops, loopType);
            return UseCurve ? animation.SetEase(animationCurve) : animation.SetEase(ease);
        }
    }
}