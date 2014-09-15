using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CornTracker
{
    public partial class UsersForm : Form
    {
        private class EditableUser : User
        {
            UsersForm form = null;

            public EditableUser(UsersForm pForm)
            {
                form = pForm;
                form.txtName.TextChanged += new EventHandler(form.OnUserEditorChange);
                form.txtLogin.TextChanged += new EventHandler(form.OnUserEditorChange);
            }

            public override string GetTableName()
            {
                return "users";
            }

            [Field] public override string name
            {
                get { return form.txtName.Text; }
                set { form.txtName.Text = value; }
            }

            [Field] public override string login
            {
                get { return form.txtLogin.Text; }
                set { form.txtLogin.Text = value; }
            }
        }

        //-------------------------------------------------------------------------------

        List<User> userList;
        EditableUser editableUser = null;
        User selectedUser = null;
        private bool ignoreChangeEvents = false;

        public UsersForm()
        {
            InitializeComponent();
            editableUser = new EditableUser(this);
            ReloadListView();
        }

        private void ReloadListView()
        {
            userList = DataProvider.GetAllRecords<User>();
            ListView.Clear();
            foreach (User user in userList)
                ListView.Items.Add(user.name);
        }

        private void UpdateListView()
        {
            for (int i = 0; i < ListView.Items.Count; i++)
                ListView.Items[i].Text = userList[i].name;
        }

        private void FillFields()
        {
            ignoreChangeEvents = true;
            editableUser.CopyPropertiesFrom(selectedUser);
            ignoreChangeEvents = false;
            SetChanged(false);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Apply(true);
            DataProvider.RunQuery(@"INSERT INTO users (name) VALUES ('Новый Пользователь')");
            ReloadListView();
            ListView.SelectedIndices.Add(ListView.Items.Count - 1);
        }

        private void Apply(bool confirmation = false)
        {
            if( selectedUser != null && selectedUser.id == editableUser.id )
            {
                var parameters = editableUser.GetUniqueParameters(selectedUser);
                if (parameters.Count > 0)
                {
                    if (!confirmation || MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        editableUser.Update(selectedUser);
                        selectedUser.CopyPropertiesFrom(editableUser);
                        UpdateListView();
                    }
                }
            }
            SetChanged(false);
        }

        private void SetChanged(bool value)
        {
            btnApply.Enabled = value;
            btnCancel.Enabled = value;
        }

        private void OnUserEditorChange(object sender, EventArgs e)
        {
            if ((!ignoreChangeEvents) && (selectedUser != null))
                SetChanged(editableUser.GetUniqueParameters(selectedUser).Count > 0);
        }

        private void btnApply_Click(object sender, EventArgs e) 
        { 
            Apply();
        }
        
        private void btnCancel_Click(object sender, EventArgs e) { 
            FillFields();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Apply(true);
            if (ListView.SelectedIndices.Count == 0)
            {
                selectedUser = null;
                return;
            }
            selectedUser = userList[ListView.SelectedIndices[0]];
            FillFields();
        }

        private void groupBox_Enter(object sender, EventArgs e)
        {
        }


    }
}
