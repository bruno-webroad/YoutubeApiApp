using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YoutubeAPIApp.Helpers
{
    public static class StringHelper
    {
        public static string LimitSize(this string str, int size)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            str = Regex.Replace(str, @"<[^>]*>", String.Empty);

            if ((size - 4) <= 0) return str;
            if (str.Length <= size - 4) return str;

            return string.Format("{0} ...", str.Substring(0, size - 4));

        }
                
        public static string StripHTML(string text)
        {
            return Regex.Replace(text, "<.*?>", String.Empty).TrimEnd().TrimStart();
        }

        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return text.ToLower().Replace("á", "a")
                        .Replace("à", "a")
                        .Replace("é", "e")
                        .Replace("í", "i")
                        .Replace("ğ", "g")
                        .Replace("ó", "o")
                        .Replace("ú", "u")
                        .Replace("ö", "o")
                        .Replace("ü", "u")
                        .Replace("ä", "a")
                        .Replace("ñ", "n")
                        .Replace("â", "a")
                        .Replace("ã", "a")                        
                        .Replace("õ", "o")
                        .Replace("ê", "e")
                        .Replace("î", "i")
                        .Replace("û", "u")
                        .Replace("ô", "o")
                        .Replace("ç", "c");
        }
    }
}
