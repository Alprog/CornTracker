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
    public partial class TaskDetail : UserControl
    {
        public TaskDetail()
        {
            InitializeComponent();
            message.Enabled = false;
            btnSend.Enabled = false;
        }

        private Node node = null;

        public void SetNode(Node node)
        {
            this.node = node;
            message.Enabled = node != null;
            btnSend.Enabled = node != null;

            history.SetNode(node);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnCommentMode_Click(object sender, EventArgs e)
        {
        }

        private void SplitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (message.richTextBox.Text != "")
            {
                Comment comment = new Comment();
                comment.text = message.richTextBox.Rtf;
                comment.node = node.id;
                comment.author = Global.loggedUser.id;
                comment.InsertWithCurrentTime();
                message.richTextBox.Text = "";
                SetNode(node);
            }
            else
            {
                MessageBox.Show("Сообщение не может быть пустым");
            }
        }

        private void History_TextChanged(object sender, EventArgs e)
        {

        }

        private void History_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            Rectangle r = e.NewRectangle;
            //MessageBox.Show(r.Width + " " + r.Height);
            
        }

        private void history_Load(object sender, EventArgs e)
        {

        }

    }
}
