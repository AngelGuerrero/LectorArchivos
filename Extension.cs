using System;
using System.Drawing;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public static class Extension
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.AppendText(Environment.NewLine);
            box.AppendText(Environment.NewLine);
            box.SelectionColor = box.ForeColor;
        }
    }
}
