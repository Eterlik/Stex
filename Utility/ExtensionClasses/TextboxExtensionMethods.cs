using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Point = System.Windows.Point;

namespace SuntoTexteditorExtensionWPF.Utility.ExtensionClasses
{
    public static class TextboxExtensionMethods
    {
        static public string GetWordAtCaret(this TextBox _textBox)
        {
            int cursorPosition = _textBox.SelectionStart;
            int nextSpace = _textBox.Text.IndexOf(',', cursorPosition);
            int selectionStart = 0;
            string trimmedString = string.Empty;
            if (nextSpace != -1)
            {
                trimmedString = _textBox.Text.Substring(0, nextSpace);
            }
            else
            {
                trimmedString = _textBox.Text;
            }

            if (trimmedString.LastIndexOf(',') != -1)
            {
                selectionStart = 1 + trimmedString.LastIndexOf(',');
                trimmedString = trimmedString.Substring(1 + trimmedString.LastIndexOf(','));
            }

            string wordAtCaret = _textBox.Text.Substring(selectionStart, trimmedString.Length);

            Debug.WriteLine(wordAtCaret);

            return wordAtCaret.Trim();
        }

        //static public Point GetWordStartPosition(this TextBox _textBox)
        //{
        //    int cursorPosition = _textBox.SelectionStart;
        //    int nextSpace = _textBox.Text.IndexOf(',', cursorPosition);
        //    int selectionStart = 0;
        //    string trimmedString = string.Empty;
        //    if (nextSpace != -1)
        //    {
        //        trimmedString = _textBox.Text.Substring(0, nextSpace);
        //    }
        //    else
        //    {
        //        trimmedString = _textBox.Text;
        //    }


        //    if (trimmedString.LastIndexOf(',') != -1)
        //    {
        //        selectionStart = 1 + trimmedString.LastIndexOf(',');
        //    }

        //    Point point = _textbox.PointToScreen(rect.BottomRight);
        //    return point;
        //}
    }
}
