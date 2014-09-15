namespace CornTracker
{
    partial class CommentBlob
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
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.rtfEditor = new CornTracker.NonScrollableRichTextBox();
            this.SuspendLayout();
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(5, 0);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(40, 13);
            this.lblPerson.TabIndex = 20;
            this.lblPerson.Text = "Автор:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Location = new System.Drawing.Point(220, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(172, 13);
            this.lblDate.TabIndex = 21;
            this.lblDate.Text = "01.01.1970";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rtfEditor
            // 
            this.rtfEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfEditor.BackColor = System.Drawing.Color.White;
            this.rtfEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfEditor.Location = new System.Drawing.Point(8, 16);
            this.rtfEditor.Name = "rtfEditor";
            this.rtfEditor.ReadOnly = true;
            this.rtfEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfEditor.Size = new System.Drawing.Size(384, 108);
            this.rtfEditor.TabIndex = 22;
            this.rtfEditor.Text = "";
            this.rtfEditor.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.rtfEditor_ContentsResized);
            this.rtfEditor.SizeChanged += new System.EventHandler(this.rtfEditor_SizeChanged);
            this.rtfEditor.TextChanged += new System.EventHandler(this.rtfEditor_TextChanged);
            // 
            // CommentBlob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtfEditor);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblDate);
            this.Name = "CommentBlob";
            this.Size = new System.Drawing.Size(401, 132);
            this.Load += new System.EventHandler(this.HistoryMessage_Load);
            this.SizeChanged += new System.EventHandler(this.CommentBlob_SizeChanged);
            this.Enter += new System.EventHandler(this.CommentBlob_Enter);
            this.Resize += new System.EventHandler(this.CommentBlob_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.Label lblDate;
        public NonScrollableRichTextBox rtfEditor;


    }
}
