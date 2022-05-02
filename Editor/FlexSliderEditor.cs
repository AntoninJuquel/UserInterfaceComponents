using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UserInterfaceComponents.Components;

namespace UserInterfaceComponents.Editor
{
    [CustomEditor(typeof(FlexSlider))]
    public class FlexSliderEditor : SliderEditor
    {
        private SerializedProperty _handle, _background, _fill;

        protected override void OnEnable()
        {
            base.OnEnable();
            // Setup the SerializedProperties.
            _handle = serializedObject.FindProperty("handle");
            _background = serializedObject.FindProperty("background");
            _fill = serializedObject.FindProperty("fill");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(_handle, new GUIContent("Handle"));
            EditorGUILayout.PropertyField(_background, new GUIContent("Background"));
            EditorGUILayout.PropertyField(_fill, new GUIContent("Fill"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}