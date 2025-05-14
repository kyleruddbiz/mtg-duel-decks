namespace VoidScribe.MtgDuelDecks
{
    public static class PropertiesUtility
    {
        public static string ToBackingFieldName(string propertyName)
        {
            return string.Format(PropertiesConstants.BackingFieldFormat, propertyName);
        }
    }
}