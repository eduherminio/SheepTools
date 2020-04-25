namespace SheepTools.Extensions
{
    public static class StringHelpers
    {
        public static bool IsEmpty(this string str)
        {
            return str?.Length == 0;
        }

        public static bool HasWhiteSpaces(this string str)
        {
            return str?.Contains(" ") == true;
        }

        public static string Truncate(this string str, int maxLength)
        {
            return (str?.Length > maxLength)
                ? str.Substring(0, maxLength)
                : str;
        }
    }
}
