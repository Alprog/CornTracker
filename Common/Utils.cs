using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CornTracker
{
    public class Utils
    {
        public static void FillImageList(ImageList imageList, string path)
        {
            var files = Directory.EnumerateFiles(path, "*.png");
            foreach( string filePath in files )
            {
                var key = filePath.Substring(path.Length + 1);
                imageList.Images.Add(key, System.Drawing.Image.FromFile(filePath));
            }
        }

        public static String ToString(object value)
        {
            if (value == null)
                return "";
            else if (value.GetType().IsEnum)
                return ((int)value).ToString();
            else
                return value.ToString();
        }

        public static void ErrorMessage(string message, string caption = "Ошибка")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AddMenuItem(ContextMenuStrip menu, string name, Action onClick, bool bold = false)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name);
            item.Click += delegate(Object sender, System.EventArgs e) { onClick(); };
            if (bold)
                item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Bold);
            menu.Items.Add(item);
        }

        public static string MD5(string input)
        {
            var md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (byte b in data)
                builder.Append(b.ToString("x2").ToLower());
            return builder.ToString();
        }

        public static bool Confirm(string text, string arg1 = "", string arg2 = "", string arg3 = "")
        {
            text = String.Format(text, arg1, arg2, arg3);
            return MessageBox.Show(text, "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

    }
}
