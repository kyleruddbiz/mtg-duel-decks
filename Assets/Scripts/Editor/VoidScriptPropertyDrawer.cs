using UnityEditor;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class VoidScriptPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;

                OnGUIInternal(position, property, label);

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }

        protected abstract void OnGUIInternal(Rect position, SerializedProperty property, GUIContent label);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUIUtility.singleLineHeight;

            if (property.isExpanded)
            {
                totalHeight = GetPropertyHeightInternal(property, label, totalHeight);
            }

            return totalHeight;
        }

        protected abstract float GetPropertyHeightInternal(SerializedProperty property, GUIContent label, float startingTotalHeight);

        protected float GetLineHeight(int numberOfLines = 1)
        {
            return numberOfLines * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
        }
    }
}