namespace CornTracker
{
    partial class TaskDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.history = new CornTracker.History();
            this.btnSend = new System.Windows.Forms.Button();
            this.message = new CornTracker.RTFEditor();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.history);
            this.SplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.btnSend);
            this.SplitContainer.Panel2.Controls.Add(this.message);
            this.SplitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitContainer_Panel2_Paint);
            this.SplitContainer.Size = new System.Drawing.Size(610, 425);
            this.SplitContainer.SplitterDistance = 277;
            this.SplitContainer.TabIndex = 0;
            // 
            // history
            // 
            this.history.AutoScroll = true;
            this.history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.history.Location = new System.Drawing.Point(0, 0);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(610, 277);
            this.history.TabIndex = 0;
            this.history.Load += new System.EventHandler(this.history_Load);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(494, 114);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(113, 27);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.message.Location = new System.Drawing.Point(3, 2);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(607, 106);
            this.message.TabIndex = 0;
            this.message.Load += new System.EventHandler(this.Message_Load);
            // 
            // TaskDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer);
            this.Name = "TaskDetail";
            this.Size = new System.Drawing.Size(610, 425);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private RTFEditor message;
        private System.Windows.Forms.Button btnSend;
        private History history;
    }
}
