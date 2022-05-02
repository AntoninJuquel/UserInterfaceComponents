using UnityEditor;
using UnityEngine;

namespace UserInterfaceComponents.Editor
{
    public static class FlexibleUserInterfaceMenuItem
    {
        [MenuItem("GameObject/FlexibleUserInterface/Linear Progress Bar")]
        public static void AddLinearProgressBar()
        {
            var obj = Object.Instantiate(Resources.Load<GameObject>("Linear Progress Bar"), Selection.activeTransform, false);
            Undo.RegisterCreatedObjectUndo(obj, $"Create {obj.name}");
            Selection.activeGameObject = obj;
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
            var obj = Object.Instantiate(Resources.Load<GameObject>("Radial Progress Bar"), Selection.activeTransform, false);
            Undo.RegisterCreatedObjectUndo(obj, $"Create {obj.name}");
            Selection.activeGameObject = obj;
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
            var obj = Object.Instantiate(Resources.Load<GameObject>("Slider"), Selection.activeTransform, false);
            Undo.RegisterCreatedObjectUndo(obj, $"Create {obj.name}");
            Selection.activeGameObject = obj;
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
            var obj = Object.Instantiate(Resources.Load<GameObject>("Modal"), Selection.activeTransform, false);
            Undo.RegisterCreatedObjectUndo(obj, $"Create {obj.name}");
            Selection.activeGameObject = obj;
        }
    }
}