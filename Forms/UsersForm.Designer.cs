namespace CornTracker
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.ListView = new System.Windows.Forms.ListView();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnCancel);
            this.groupBox.Controls.Add(this.btnApply);
            this.groupBox.Controls.Add(this.txtName);
            this.groupBox.Controls.Add(this.lblName);
            this.groupBox.Controls.Add(this.lblLogin);
            this.groupBox.Controls.Add(this.txtLogin);
            this.groupBox.Location = new System.Drawing.Point(313, 7);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(346, 377);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            this.groupBox.Enter += new System.EventHandler(this.groupBox_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(91, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(182, 341);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 24);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 20);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(14, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Полное имя:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(44, 22);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 13);
            this.lblLogin.TabIndex = 14;
            this.lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(91, 19);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(242, 20);
            this.txtLogin.TabIndex = 13;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(12, 360);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(85, 24);
            this.btnAddUser.TabIndex = 10;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // ListView
            // 
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(12, 12);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(295, 342);
            this.ListView.TabIndex = 19;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.List;
            this.ListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 390);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView ListView;
    }
}