using DG.Tweening;
using UnityEngine;

namespace UserInterfaceComponents.Animations
{
    [CreateAssetMenu(menuName = "Animation/Rotation")]
    public class RotationAnimation : FlexAnimation
    {
        public Vector3 from, to;

        public override Tweener Animate(GameObject gameObject)
        {
            var animationTime = (to - (relativeStart ? gameObject.transform.eulerAngles : from)).magnitude / (to - from).magnitude * animationDuration;
            var animation = DOVirtual
                .Vector3(relativeStart ? gameObject.transform.eulerAngles : from, to, animationTime, v => gameObject.transform.eulerAngles = v)
                .SetLoops(loops, loopType);
            return UseCurve ? animation.SetEase(animationCurve) : animation.SetEase(ease);
        }
    }
}