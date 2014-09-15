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
    public partial class CommentBlob : UserControl
    {
        int width;

        public CommentBlob()
        {
            InitializeComponent();
            width = Width;
        }

        public void Init(Comment comment)
        {
            lblPerson.Text = Users.GetName(comment.author) + ":";

            lblDate.Text = comment.time.ToString();
            rtfEditor.Rtf = comment.text;
        }

        private void HistoryMessage_Load(object sender, EventArgs e)
        {

        }

        private void rtfEditor_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.Height = (this.Height - rtfEditor.Size.Height) + e.NewRectangle.Height;
        }
        
        private void rtfEditor_SizeChanged(object sender, EventArgs e)
        {
            /*string rtf = rtfEditor.Rtf;
            rtfEditor.Rtf = "";
            rtfEditor.Rtf = rtf;*/
        }

        private void rtfEditor_TextChanged(object sender, EventArgs e)
        {

        }

        private void CommentBlob_SizeChanged(object sender, EventArgs e)
        {
        }

        private void CommentBlob_Resize(object sender, EventArgs e)
        {
            
        }

        private void CommentBlob_Enter(object sender, EventArgs e)
        {

        }





    }
}
