using System.Text.RegularExpressions;

namespace AutoRepairShop.Logic.Utilities
{
    public static class StringUtil
    {
        public static string CleanString(this string input)
        {
            // Fjerner whitespace, punktum og converter til lowercase.
            return Regex.Replace(input, @"[\s\p{P}]", "").ToLower();
        }
    }
}