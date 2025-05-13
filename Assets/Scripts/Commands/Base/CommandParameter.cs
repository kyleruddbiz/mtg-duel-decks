//using System;
//using UnityEngine;

//namespace VoidScribe.MtgDuelDecks
//{
//    [Serializable]
//    public class CommandParameter
//    {
//        public static class Properties
//        {
//            public const string Type = nameof(type);
//            public const string StringValue = nameof(stringValue);
//            public const string BoolValue = nameof(boolValue);
//            public const string IntValue = nameof(intValue);
//            public const string FloatValue = nameof(floatValue);
//        }

//        public enum Type
//        {
//            String,
//            Int,
//            Float,
//            Bool,
//        }

//        [SerializeField] private Type type;

//        [SerializeField] private string stringValue;
//        [SerializeField] private int intValue;
//        [SerializeField] private float floatValue;
//        [SerializeField] private bool boolValue;

//        public object Value
//        {
//            get
//            {
//                return type switch
//                {
//                    Type.String => stringValue,
//                    Type.Int => intValue,
//                    Type.Float => floatValue,
//                    Type.Bool => boolValue,
//                    _ => throw new ArgumentOutOfRangeException(type.ToString()),
//                };
//            }
//        }

//        public override string ToString()
//        {
//            return Value.ToString();
//        }
//    }
//}