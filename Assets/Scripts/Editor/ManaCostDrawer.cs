using UnityEditor;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CustomPropertyDrawer(typeof(ManaCost))]
    public class ManaCostDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;

                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                SerializedProperty colorsProperty = property.FindPropertyRelative(ManaCost.Properties.Colors);
                EditorGUI.PropertyField(position, colorsProperty);

                var selectedColors = (MtgCostColors)colorsProperty.enumValueFlag;

                DrawAmountProperty(MtgCostColors.Generic);
                DrawAmountProperty(MtgCostColors.White);
                DrawAmountProperty(MtgCostColors.Blue);
                DrawAmountProperty(MtgCostColors.Black);
                DrawAmountProperty(MtgCostColors.Red);
                DrawAmountProperty(MtgCostColors.Green);

                void DrawAmountProperty(MtgCostColors color)
                {
                    if (selectedColors.HasFlag(color))
                    {
                        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                        SerializedProperty amountProperty = property.FindPropertyRelative(ManaCost.Properties.ForColorAmount(color));
                        EditorGUI.PropertyField(position, amountProperty);
                    }
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUIUtility.singleLineHeight;

            if (property.isExpanded)
            {
                // Colors Dropdown
                totalHeight += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                // Dynamically show/hide Amounts based on colors selected.
                SerializedProperty colorsProperty = property.FindPropertyRelative(ManaCost.Properties.Colors);
                var colors = (MtgCostColors)colorsProperty.enumValueFlag;
                int activeFlagsCount = FlagsEnumUtility.GetActiveFlagsCount(colors);

                totalHeight += activeFlagsCount * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
            }

            return totalHeight;
        }
    }
}