//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UIElements;

//namespace VoidScribe.MtgDuelDecks
//{
//    [CustomPropertyDrawer(typeof(SpellAbility<>))]
//    public class SpellAbilityDrawer : VoidScriptPropertyDrawer
//    {
//        protected override float GetPropertyHeightInternal(SerializedProperty property, GUIContent label, float startingTotalHeight)
//        {
//            position.y += GetLineHeight();

//            SerializedProperty colorsProperty = property.FindPropertyRelative(SpellAbility<>.Properities.IsWip);
//            EditorGUI.PropertyField(position, colorsProperty);

//        }

//        protected override void OnGUIInternal(Rect position, SerializedProperty property, GUIContent label)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}