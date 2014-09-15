namespace CornTracker
{
    partial class NewTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTaskForm));
            this.lblResonsible = new System.Windows.Forms.Label();
            this.lblChecker = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbResponsible = new System.Windows.Forms.ComboBox();
            this.cmbChecker = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtfEditor = new CornTracker.RTFEditor();
            this.SuspendLayout();
            // 
            // lblResonsible
            // 
            this.lblResonsible.AutoSize = true;
            this.lblResonsible.Location = new System.Drawing.Point(12, 48);
            this.lblResonsible.Name = "lblResonsible";
            this.lblResonsible.Size = new System.Drawing.Size(86, 13);
            this.lblResonsible.TabIndex = 0;
            this.lblResonsible.Text = "Ответственный";
            this.lblResonsible.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblChecker
            // 
            this.lblChecker.AutoSize = true;
            this.lblChecker.Location = new System.Drawing.Point(18, 80);
            this.lblChecker.Name = "lblChecker";
            this.lblChecker.Size = new System.Drawing.Size(80, 13);
            this.lblChecker.TabIndex = 1;
            this.lblChecker.Text = "Проверяющий";
            this.lblChecker.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(41, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Название";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(112, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(378, 20);
            this.txtName.TabIndex = 3;
            // 
            // cmbResponsible
            // 
            this.cmbResponsible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsible.FormattingEnabled = true;
            this.cmbResponsible.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbResponsible.Location = new System.Drawing.Point(112, 45);
            this.cmbResponsible.Name = "cmbResponsible";
            this.cmbResponsible.Size = new System.Drawing.Size(378, 21);
            this.cmbResponsible.TabIndex = 4;
            // 
            // cmbChecker
            // 
            this.cmbChecker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChecker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChecker.FormattingEnabled = true;
            this.cmbChecker.Location = new System.Drawing.Point(112, 77);
            this.cmbChecker.Name = "cmbChecker";
            this.cmbChecker.Size = new System.Drawing.Size(378, 21);
            this.cmbChecker.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreate.Location = new System.Drawing.Point(108, 337);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(143, 31);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(257, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtfEditor
            // 
            this.rtfEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfEditor.Location = new System.Drawing.Point(12, 110);
            this.rtfEditor.Name = "rtfEditor";
            this.rtfEditor.Size = new System.Drawing.Size(477, 221);
            this.rtfEditor.TabIndex = 6;
            this.rtfEditor.Load += new System.EventHandler(this.rtfEditor1_Load);
            // 
            // NewTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 373);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.rtfEditor);
            this.Controls.Add(this.cmbChecker);
            this.Controls.Add(this.cmbResponsible);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblChecker);
            this.Controls.Add(this.lblResonsible);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(327, 315);
            this.Name = "NewTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewTaskForm";
            this.Load += new System.EventHandler(this.NewTaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResonsible;
        private System.Windows.Forms.Label lblChecker;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbResponsible;
        private System.Windows.Forms.ComboBox cmbChecker;
        private RTFEditor rtfEditor;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}