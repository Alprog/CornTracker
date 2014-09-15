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
    public partial class ChangePasswordForm : Form
    {
        int userId = 0;

        public ChangePasswordForm(User user)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.Text = user.login;
            userId = user.id;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == "")
                    throw new Exception("Пароль не может быть пустым");

                if (txtPassword.Text != txtRepeat.Text )
                    throw new Exception("Пароль и повтор пароля не совпадают");

                string queryString = String.Format(
                    "UPDATE users SET password = MD5('{0}') WHERE id = '{1}'",
                    txtPassword.Text, userId
                );
                DataProvider.RunQuery(queryString);

                if (Settings.Default.SavePassword)
                {
                    Settings.Default.Password = txtPassword.Text;
                    Settings.Default.Save();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception error)
            {
                Utils.ErrorMessage(error.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void lblRepeat_Click(object sender, EventArgs e)
        {

        }

    }
}
