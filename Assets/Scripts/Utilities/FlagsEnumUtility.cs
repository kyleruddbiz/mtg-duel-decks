using System;

namespace VoidScribe.MtgDuelDecks
{
    public static class FlagsEnumUtility
    {
        /// <summary>
        /// Returns the bitwise NOT of the flags enum value.
        ///
        /// With flags enums you can't just invert everything because the unused bits to the left would be set to 1.
        /// We only want the values within the valid range to be inverted.
        /// </summary>
        public static T Not<T>(T value) where T : Enum, IConvertible
        {
            int all = FlagsEnumUtility<T>.AllAsInt;
            int valueAsInt = ((IConvertible)value).ToInt32(null);

            int result = ~all ^ ~valueAsInt;

            return (T)Enum.ToObject(typeof(T), result);
        }
    }

    public static class FlagsEnumUtility<T> where T : Enum, IConvertible
    {
        // Using a bool since I can't determine if T is nullable or not.
        private static bool isEnumInitialized = false;
        private static T all;

        public static T All
        {
            get
            {
                if (!isEnumInitialized)
                {
                    isEnumInitialized = true;

                    all = (T)Enum.ToObject(typeof(T), AllAsInt);
                }

                return all;
            }
        }

        private static int? allAsInt;

        public static int AllAsInt
        {
            get
            {
                if (!allAsInt.HasValue)
                {
                    allAsInt = GetAllAsInt();
                }

                return allAsInt.Value;
            }
        }

        private static int GetAllAsInt()
        {
            int result = 0;

            foreach (object value in Enum.GetValues(typeof(T)))
            {
                result |= ((IConvertible)value).ToInt32(null);
            }

            return result;
        }
    }
}