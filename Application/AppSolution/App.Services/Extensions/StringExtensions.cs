using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Extensions
{
    public static class StringExtensions
    {
        private static readonly char[] vowels = new char[]
        {
            'a', 'e', 'i', 'o', 'u'
        };
        public static string GetQuantityTextForm(this string text, long quantity) {

            if(quantity > 1)
            {
                if (!string.Equals(text, "kobo", StringComparison.InvariantCultureIgnoreCase) && (char.ToLower(text[^1]) == 'o' || char.ToLower(text[^1]) == 'e' || !vowels.Contains(char.ToLower(text[^1]))))
                {
                    text += 's';
                }
            }

            return text;
        }
    }
}
