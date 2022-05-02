using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace UserInterfaceComponents.Editor
{
    [CustomEditor(typeof(FlexButton))]
    public class FlexButtonEditor : ButtonEditor
    {
        private SerializedProperty _animationDuration, _animationCurve;

        protected override void OnEnable()
        {
            base.OnEnable();
            // Setup the SerializedProperties.
            _animationDuration = serializedObject.FindProperty("animationDuration");
            _animationCurve = serializedObject.FindProperty("animationCurve");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(_animationDuration, new GUIContent("Animation Duration"));
            EditorGUILayout.PropertyField(_animationCurve, new GUIContent("Animation Curve"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}