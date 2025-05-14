using UnityEditor;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CustomPropertyDrawer(typeof(ManaCost))]
    public class ManaCostDrawer : VoidScriptPropertyDrawer
    {
        protected override void OnGUIInternal(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += GetLineHeight();

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
                    position.y += GetLineHeight();

                    SerializedProperty amountProperty = property.FindPropertyRelative(ManaCost.Properties.ForColorAmount(color));
                    EditorGUI.PropertyField(position, amountProperty);
                }
            }
        }

        protected override float GetPropertyHeightInternal(SerializedProperty property, GUIContent label, float totalHeight)
        {
            // Colors Dropdown
            totalHeight += GetLineHeight();

            // Dynamically show/hide Amounts based on colors selected.
            SerializedProperty colorsProperty = property.FindPropertyRelative(ManaCost.Properties.Colors);
            var colors = (MtgCostColors)colorsProperty.enumValueFlag;
            int numberOfLines = FlagsEnumUtility.GetActiveFlagsCount(colors);

            totalHeight += GetLineHeight(numberOfLines);

            return totalHeight;
        }
    }
}