using DG.Tweening;
using UnityEngine;

namespace UserInterfaceComponents.Animations
{
    public abstract class FlexAnimation : ScriptableObject
    {
        public float animationDuration;
        public AnimationCurve animationCurve;
        public Ease ease;
        public LoopType loopType;
        public int loops;
        public bool relativeStart, autoKill = true;
        protected bool UseCurve => ease == Ease.Unset;
        public abstract Tweener Animate(GameObject gameObject);
    }
}