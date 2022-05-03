using UnityEditor;
using UnityEngine;

namespace UserInterfaceComponents.Editor
{
    public static class FlexibleUserInterfaceMenuItem
    {
        public static void AddGameObjectFrom(string path)
        {
            var obj = Object.Instantiate(Resources.Load<GameObject>(path), Selection.activeTransform, false);
            obj.name = path;
            Undo.RegisterCreatedObjectUndo(obj, $"Create {path}");
            Selection.activeGameObject = obj;
        }

        [MenuItem("GameObject/FlexibleUserInterface/Linear Progress Bar")]
        public static void AddLinearProgressBar()
        {
            AddGameObjectFrom("Linear Progress Bar");
        }

        [MenuItem("GameObject/FlexibleUserInterface/Linear Progress Bar", true)]
        public static bool ValidateAddLinearProgressBar()
        {
            // Return false if no transform is selected.
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/FlexibleUserInterface/Radial Progress Bar")]
        public static void AddRadialProgressBar()
        {
            AddGameObjectFrom("Radial Progress Bar");
        }

        [MenuItem("GameObject/FlexibleUserInterface/Radial Progress Bar", true)]
        public static bool ValidateAddRadialProgressBar()
        {
            // Return false if no transform is selected.
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/FlexibleUserInterface/Slider")]
        public static void AddSlider()
        {
            AddGameObjectFrom("Slider");
        }

        [MenuItem("GameObject/FlexibleUserInterface/Slider", true)]
        public static bool ValidateAddSlider()
        {
            // Return false if no transform is selected.
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/FlexibleUserInterface/Modal", false, -10)]
        public static void AddModal()
        {
            AddGameObjectFrom("Modal");
        }

        [MenuItem("GameObject/FlexibleUserInterface/Tooltip", false, -10)]
        public static void AddTooltip()
        {
            AddGameObjectFrom("Tooltip");
        }
    }
}