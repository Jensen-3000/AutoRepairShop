using System.Text.RegularExpressions;

namespace AutoRepairShop.Logic.Utilities
{
    public static class StringUtil
    {
        public static string CleanString(this string input)
        {
            // Remove spaces, punctuation and convert the string to lowercase
            return Regex.Replace(input, @"[\s\p{P}]", "").ToLower();
        }
    }
}