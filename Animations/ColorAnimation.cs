using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterfaceComponents.Animations
{
    [CreateAssetMenu(menuName = "Animation/Color")]
    public class ColorAnimation : FlexAnimation
    {
        public Color from, to;
        public bool r = true, g = true, b = true, a = true;

        public override Tweener Animate(GameObject gameObject)
        {
            var graphic = gameObject.GetComponent<Graphic>();
            var animation = DOVirtual
                .Color(relativeStart ? graphic.color : from, to, animationDuration, c =>
                {
                    var tmpColor = graphic.color;
                    tmpColor.r = r ? c.r : tmpColor.r;
                    tmpColor.g = g ? c.g : tmpColor.g;
                    tmpColor.b = b ? c.b : tmpColor.b;
                    tmpColor.a = a ? c.a : tmpColor.a;
                    graphic.color = tmpColor;
                })
                .SetLoops(loops, loopType);
            return UseCurve ? animation.SetEase(animationCurve) : animation.SetEase(ease);
        }
    }
}