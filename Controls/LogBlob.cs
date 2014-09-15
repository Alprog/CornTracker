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
    public partial class LogBlob : UserControl
    {
        public LogBlob()
        {
            InitializeComponent();
        }

        public void Init(string message, DateTime time)
        {
            lblMessage.Text = String.Format("{0} ({1})", message, time);
        }

        public void Init()
        {
        }

        private void LogBlob_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
