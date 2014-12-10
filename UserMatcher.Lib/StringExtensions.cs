using System;
using System.Collections.Generic;
using System.Linq;

namespace UserMatcher.Lib
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            return string.Join(" ", 
                s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(token => string.Concat(char.ToUpper(token[0]), token.Substring(1))));
        }

        public static string RemoveNoise(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            return new string(s.Replace('.', ',')
                .Replace(';', '.')
                .Where(ch => char.IsLetterOrDigit(ch) || ch == ',').ToArray()).Trim(',').ToTitleCase();
        }

        public static string ReverseString(this string s)
        {
            if (s == null)
                return s;

            return new string(s.Reverse().ToArray());
        }
    }
}
