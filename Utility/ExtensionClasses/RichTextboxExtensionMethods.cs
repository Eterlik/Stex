using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using SuntoTexteditorExtensionWPF.Classes.Database;

namespace SuntoTexteditorExtensionWPF.Utility.ExtensionClasses
{
    static public class RichTextboxExtensionMethods
    {
        static public void SetText(this RichTextBox _RichTextBox, string _text)
        {
            _RichTextBox.Document.Blocks.Clear();
            _RichTextBox.Document.Blocks.Add(new Paragraph(new Run(_text)));
        }

        static public string GetText(this RichTextBox _RichTextBox)
        {
            return new TextRange(_RichTextBox.Document.ContentStart, _RichTextBox.Document.ContentEnd).Text;
        }

        static public string GetWordAtCaret(this RichTextBox _RichTextBox)
        {
            TextPointer start = _RichTextBox.CaretPosition;  // this is the variable we will advance to the left until a non-letter character is found
            TextPointer end = _RichTextBox.CaretPosition;    // this is the variable we will advance to the right until a non-letter character is found

            String stringBeforeCaret = start.GetTextInRun(LogicalDirection.Backward);   // extract the text in the current run from the caret to the left
            String stringAfterCaret = start.GetTextInRun(LogicalDirection.Forward);     // extract the text in the current run from the caret to the left

            Int32 countToMoveLeft = 0;  // we record how many positions we move to the left until a non-letter character is found
            Int32 countToMoveRight = 0; // we record how many positions we move to the right until a non-letter character is found

            for (Int32 i = stringBeforeCaret.Length - 1; i >= 0; --i)
            {
                if(stringBeforeCaret[i] == '[')
                {
                    ++countToMoveLeft;
                    break;
                }
                // if the character at the location CaretPosition-LeftOffset is a letter, we move more to the left
                else if (Char.IsLetter(stringBeforeCaret[i]) || stringBeforeCaret[i] == ' ')
                    ++countToMoveLeft;
                else break; // otherwise we have found the beginning of the word
            }

            for (Int32 i = 0; i < stringAfterCaret.Length; ++i)
            {
                // if the character at the location CaretPosition+RightOffset is a letter, we move more to the right
                if (Char.IsLetter(stringAfterCaret[i]))
                    ++countToMoveRight;
                else break; // otherwise we have found the end of the word
            }

            start = start.GetPositionAtOffset(-countToMoveLeft);    // modify the start pointer by the offset we have calculated
            end = end.GetPositionAtOffset(countToMoveRight);        // modify the end pointer by the offset we have calculated

            // extract the text between those two pointers
            TextRange textRange = new TextRange(start, end);
            String wordAtCaret = textRange.Text;

            //Debug.WriteLine(wordAtCaret);

            return wordAtCaret.Trim();
        }

        static public void ReplaceWordAtCaret(this RichTextBox _RichTextBox, string _word, bool ignoreSpace)
        {
            TextPointer start = _RichTextBox.CaretPosition;  // this is the variable we will advance to the left until a non-letter character is found
            TextPointer end = _RichTextBox.CaretPosition;    // this is the variable we will advance to the right until a non-letter character is found

            String stringBeforeCaret = start.GetTextInRun(LogicalDirection.Backward);   // extract the text in the current run from the caret to the left
            String stringAfterCaret = start.GetTextInRun(LogicalDirection.Forward);     // extract the text in the current run from the caret to the left

            Int32 countToMoveLeft = 0;  // we record how many positions we move to the left until a non-letter character is found
            Int32 countToMoveRight = 0; // we record how many positions we move to the right until a non-letter character is found

            for (Int32 i = stringBeforeCaret.Length - 1; i >= 0; --i)
            {
                if (stringBeforeCaret[i] == '[')
                {
                    ++countToMoveLeft;
                    break;
                }
                // if the character at the location CaretPosition-LeftOffset is a letter, we move more to the left
                else if (Char.IsLetter(stringBeforeCaret[i]) || (ignoreSpace && stringBeforeCaret[i] == ' '))
                    ++countToMoveLeft;
                else break; // otherwise we have found the beginning of the word
            }

            for (Int32 i = 0; i < stringAfterCaret.Length; ++i)
            {
                // if the character at the location CaretPosition+RightOffset is a letter, we move more to the right
                if (Char.IsLetter(stringAfterCaret[i]))
                    ++countToMoveRight;
                else break; // otherwise we have found the end of the word
            }

            start = start.GetPositionAtOffset(-countToMoveLeft);    // modify the start pointer by the offset we have calculated
            end = end.GetPositionAtOffset(countToMoveRight);        // modify the end pointer by the offset we have calculated

            _RichTextBox.Selection.Select(start, end);

            _RichTextBox.Selection.Text = _word;
            // Position carret at the end of the inserted word
            _RichTextBox.Selection.Select(start.GetPositionAtOffset(_word.Length), start.GetPositionAtOffset(_word.Length));

        }

        static public Point GetWordStartPosition(this RichTextBox _RichTextBox)
        {
            TextPointer cur = _RichTextBox.CaretPosition;
            TextPointer startOfLinePointer = cur.GetLineStartPosition(0);
            
            char[] textbuffer = new char[1];
            do
            {
                int offset = _RichTextBox.Document.ContentStart.GetOffsetToPosition(cur);
                cur.GetTextInRun(LogicalDirection.Backward, textbuffer, 0, 1);
                cur = cur.GetNextInsertionPosition(LogicalDirection.Backward);
            } while (Char.IsLetter(textbuffer[0]) && cur != null);
            //} while (textbuffer[0] != ' ' && cur != null);
            if (cur != null)
                cur = cur.GetNextInsertionPosition(LogicalDirection.Forward);
            if (cur == null)
                cur = _RichTextBox.Document.ContentStart;
            Rect rect = cur.GetCharacterRect(LogicalDirection.Backward);
            Point point = _RichTextBox.PointToScreen(rect.BottomRight);
            return point;
        }
    }
}
