using UnityEngine;

namespace UserInterfaceComponents.ScriptableObjects
{
    [CreateAssetMenu(menuName = "User Interface Components/Sprite Color Preset")]
    public class SpriteColorPreset : ScriptableObject
    {
        public Sprite sprite;
        public Color color;
    }
}