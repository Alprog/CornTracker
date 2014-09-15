using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CornTracker
{
    public class NonScrollableRichTextBox : RichTextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_MOUSEWHEEL = 0x020A;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL)
            {
                IntPtr handle = ((Control)this.Parent).Handle;
                SendMessage(handle, m.Msg, m.WParam, m.LParam);
                return;
            }
            base.WndProc(ref m);
        }
    }
}
