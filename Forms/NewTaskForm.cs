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
    public partial class NewTaskForm : Form
    {
        Node owner;

        public NewTaskForm(Node ownerNode)
        {
            InitializeComponent();
            owner = ownerNode;
            this.Text = "Подзадача для " + owner.name;

            TextObject<ECheckerType> pair;
            pair = new TextObject<ECheckerType>("Не требуется", ECheckerType.AUTO);
            cmbChecker.Items.Add(pair);
            pair = new TextObject<ECheckerType>(
                String.Format("Ответственный за {0} ({1})",
                owner.name, owner.responsibleName), ECheckerType.PARENT
            );
            cmbChecker.Items.Add(pair);

            foreach (User user in Users.dictionary.Values)
            {
                cmbResponsible.Items.Add(user);
                cmbChecker.Items.Add(user);
            }

            cmbResponsible.SelectedIndex = 0;
            cmbChecker.SelectedIndex = 0;
        }

        private void NewTaskForm_Load(object sender, EventArgs e)
        {

        }

        private void rtfEditor1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                    throw new Exception("Название не задано");

                Node node = new Node();
                node.name = txtName.Text;
                node.type = ENodeType.TASK;
                node.parent = owner.id;
                node.responsible = ((User)cmbResponsible.SelectedItem).id;
                Object checker = cmbChecker.SelectedItem;
                if (checker.GetType() == typeof(User))
                {
                    node.checkertype = ECheckerType.PERSON;
                    node.checker = ((User)checker).id;
                }
                else
                {
                    node.checkertype = (ECheckerType)(TextObject<ECheckerType>)checker;
                }

                node.InsertWithCurrentTime();

                if (rtfEditor.richTextBox.Text != "")
                {
                    Comment comment = new Comment();
                    comment.text = rtfEditor.richTextBox.Rtf;
                    comment.node = node.id;
                    comment.author = Global.loggedUser.id;
                    comment.InsertWithCurrentTime();
                }

                node.interest = true;
                owner.AddNode(node);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception error)
            {
                Utils.ErrorMessage(error.Message);
            }
        }
    }
}
