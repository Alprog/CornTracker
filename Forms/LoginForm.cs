using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CornTracker.Properties;

namespace CornTracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            txtLogin.Text = Settings.Default.Login;
            cbSave.Checked = Settings.Default.SavePassword;
            txtPassword.Text = Settings.Default.Password;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Settings.Default.Login = txtLogin.Text;
            Settings.Default.SavePassword = cbSave.Checked;
            Settings.Default.Password = cbSave.Checked ? txtPassword.Text : "";
            Settings.Default.Save();

            Global.TryLogin(txtLogin.Text, txtPassword.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Global.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.isRunning)
            {
                e.Cancel = true;
                this.Hide();
            }
        }


    }
}
