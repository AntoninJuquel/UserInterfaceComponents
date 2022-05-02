using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UserInterfaceComponents.Class;

namespace UserInterfaceComponents
{
    [ExecuteInEditMode]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private AnimationCurve fillCurve;
        [SerializeField] private Image mask;
        [SerializeField] private ImageSpriteColor background, fill;
        [SerializeField] private float fillAmount, minimum, maximum = 100, animationTime = 1f;
        private float CurrentOffset => fillAmount - minimum;
        private float MaximumOffset => maximum - minimum;

        public float FillAmount
        {
            get => fillAmount;
            set => DOVirtual.Float(fillAmount, value, animationTime, x =>
                {
                    fillAmount = x;
                    UpdateBar();
                })
                .SetEase(fillCurve);
        }

        public float Maximum
        {
            get => maximum;
            set => DOVirtual.Float(maximum, value, animationTime, x =>
                {
                    maximum = x;
                    UpdateBar();
                })
                .SetEase(fillCurve);
        }

        public float Minimum
        {
            get => minimum;
            set => DOVirtual.Float(minimum, value, animationTime, x =>
                {
                    minimum = x;
                    UpdateBar();
                })
                .SetEase(fillCurve);
        }

        private void OnValidate()
        {
            UpdateBar();
        }

        private void Awake()
        {
            background.Apply();
            fill.Apply();
            UpdateBar();
        }

        private void UpdateBar() => mask.fillAmount = CurrentOffset / MaximumOffset;
    }
}