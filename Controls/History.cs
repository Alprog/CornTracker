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

    public partial class History : UserControl
    {
        private Node node = null;
        List<Comment> comments = new List<Comment>();

        public History()
        {
            InitializeComponent();
        }

        public void SetNode(Node node)
        {
            this.node = node;
            comments.Clear();

            if (node != null)
            {
                String queryString = String.Format("SELECT * FROM comments WHERE node = {0} ORDER BY time", node.id);
                comments = DataProvider.GetRecordsFromQuery<Comment>(queryString);
            }

            RefreshBlobSizes();
        }

        public void RefreshBlobSizes()
        {
            panel.Controls.Clear();

            foreach (Comment comment in comments)
            {
                CommentBlob mes = new CommentBlob();
                mes.Width = panel.ClientSize.Width - 20;
                panel.Controls.Add(mes);
                mes.Init(comment);
            }

            int height = 0;
            foreach (CommentBlob blob in panel.Controls)
            {
                blob.Location = new Point(0, height);
                height += blob.Size.Height + 20;
            }
        }

        private void History_SizeChanged(object sender, EventArgs e)
        {
            RefreshBlobSizes();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (panel.Controls.Count > 0)
                panel.Controls[0].Focus();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
