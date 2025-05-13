//using UnityEditor;
//using UnityEngine;

//namespace VoidScribe.MtgDuelDecks
//{
//    [CustomPropertyDrawer(typeof(CommandParameter))]
//    public class CommandParameterDrawer : PropertyDrawer
//    {
//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);

//            position.height = EditorGUIUtility.singleLineHeight;
//            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

//            if (property.isExpanded)
//            {
//                EditorGUI.indentLevel++;

//                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

//                SerializedProperty typeProperty = property.FindPropertyRelative(CommandParameter.Properties.Type);
//                EditorGUI.PropertyField(position, typeProperty);

//                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

//                var type = (CommandParameter.Type)typeProperty.enumValueIndex;

//                SerializedProperty valueProperty = type switch
//                {
//                    CommandParameter.Type.String => property.FindPropertyRelative(CommandParameter.Properties.StringValue),
//                    CommandParameter.Type.Int => property.FindPropertyRelative(CommandParameter.Properties.IntValue),
//                    CommandParameter.Type.Float => property.FindPropertyRelative(CommandParameter.Properties.FloatValue),
//                    CommandParameter.Type.Bool => property.FindPropertyRelative(CommandParameter.Properties.BoolValue),
//                    _ => throw new System.ArgumentOutOfRangeException(type.ToString()),
//                };
//                EditorGUI.PropertyField(position, valueProperty);

//                EditorGUI.indentLevel--;
//            }

//            EditorGUI.EndProperty();
//        }

//        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//        {
//            float totalHeight = EditorGUIUtility.singleLineHeight;

//            if (property.isExpanded)
//            {
//                totalHeight += 2 * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
//            }

//            return totalHeight;
//        }
//    }
//}