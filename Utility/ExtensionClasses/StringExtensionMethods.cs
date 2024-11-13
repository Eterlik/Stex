using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuntoTexteditorExtensionWPF.Utility.ExtensionClasses
{
    static public class StringExtensionMethods
    {
        public static string FirstCharToUpper(this string input)
        {
            if (input.Length == 0)
                return input;
            else if (input.Length == 1)
                return char.ToUpper(input.First()).ToString();
            else
                return char.ToUpper(input.First()) + input.Substring(1).ToLower();
        }


        public static string RemoveInbetween(this string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.RightToLeft);
            string text = regex.Replace(sourceString, startTag + endTag);
            return text.Replace(startTag, "").Replace(endTag, "");
        }
    }
}
