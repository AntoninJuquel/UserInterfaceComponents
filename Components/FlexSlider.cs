using UnityEngine;
using UnityEngine.UI;
using UserInterfaceComponents.Class;

namespace UserInterfaceComponents
{
    public class FlexSlider : Slider
    {
        [SerializeField] private ImageSpriteColor handle, background, fill;
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            handle.Apply();
            background.Apply();
            fill.Apply();
        }
#endif
        protected override void OnEnable()
        {
            value = PlayerPrefs.GetFloat(name, value);
            base.OnEnable();
        }

        protected override void Set(float input, bool sendCallback = true)
        {
            base.Set(input, sendCallback);
            if (Application.isPlaying)
                PlayerPrefs.SetFloat(name, value);
        }
    }
}