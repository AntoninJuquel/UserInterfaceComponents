using UnityEngine;
using UnityEngine.UI;
using UserInterfaceComponents.ScriptableObjects;

namespace UserInterfaceComponents.Class
{
    [System.Serializable]
    public class ImageSpriteColor
    {
        [SerializeField] private Image image;
        [SerializeField] private SpriteColorPreset spriteColorPreset;

        public void Apply()
        {
            image.sprite = spriteColorPreset.sprite;
            image.color = spriteColorPreset.color;
        }
    }
}