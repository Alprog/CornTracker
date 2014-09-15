using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CornTracker
{
    public partial class RTFEditor : UserControl
    {
        public RTFEditor()
        {
            InitializeComponent();
        }

        private void InvertFontStyleFlag(FontStyle flag)
        {
            FontStyle style = richTextBox.SelectionFont.Style;
            style = style ^ flag;
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, style);
            richTextBox.Focus();
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            InvertFontStyleFlag(FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            InvertFontStyleFlag(FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            InvertFontStyleFlag(FontStyle.Underline);
        }

        private void btnStrikeout_Click(object sender, EventArgs e)
        {
            InvertFontStyleFlag(FontStyle.Strikeout);
        }



    }
}
