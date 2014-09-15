namespace CornTracker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.VSplit = new System.Windows.Forms.SplitContainer();
            this.Hierarchy = new BrightIdeasSoftware.TreeListView();
            this.hierarchyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.HSplit = new System.Windows.Forms.SplitContainer();
            this.TreeView = new BrightIdeasSoftware.TreeListView();
            this.tree_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tree_responsible = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tree_checker = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tree_status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tree_process = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tree_preferAction = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Detail = new CornTracker.TaskDetail();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentModeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlainModeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).BeginInit();
            this.VSplit.Panel1.SuspendLayout();
            this.VSplit.Panel2.SuspendLayout();
            this.VSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Hierarchy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).BeginInit();
            this.HSplit.Panel1.SuspendLayout();
            this.HSplit.Panel2.SuspendLayout();
            this.HSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.VSplit);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1020, 665);
            this.MainPanel.TabIndex = 0;
            // 
            // VSplit
            // 
            this.VSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.VSplit.Location = new System.Drawing.Point(0, 0);
            this.VSplit.Name = "VSplit";
            // 
            // VSplit.Panel1
            // 
            this.VSplit.Panel1.Controls.Add(this.Hierarchy);
            // 
            // VSplit.Panel2
            // 
            this.VSplit.Panel2.Controls.Add(this.HSplit);
            this.VSplit.Size = new System.Drawing.Size(1020, 665);
            this.VSplit.SplitterDistance = 215;
            this.VSplit.TabIndex = 3;
            // 
            // Hierarchy
            // 
            this.Hierarchy.AllColumns.Add(this.hierarchyColumn);
            this.Hierarchy.AllowDrop = true;
            this.Hierarchy.BackColor = System.Drawing.SystemColors.Window;
            this.Hierarchy.CheckBoxes = false;
            this.Hierarchy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hierarchyColumn});
            this.Hierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hierarchy.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.Hierarchy.HideSelection = false;
            this.Hierarchy.Location = new System.Drawing.Point(0, 0);
            this.Hierarchy.MultiSelect = false;
            this.Hierarchy.Name = "Hierarchy";
            this.Hierarchy.OwnerDraw = true;
            this.Hierarchy.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Hierarchy.ShowGroups = false;
            this.Hierarchy.Size = new System.Drawing.Size(215, 665);
            this.Hierarchy.TabIndex = 2;
            this.Hierarchy.UseCompatibleStateImageBehavior = false;
            this.Hierarchy.View = System.Windows.Forms.View.Details;
            this.Hierarchy.VirtualMode = true;
            this.Hierarchy.SelectedIndexChanged += new System.EventHandler(this.Hierarchy_SelectedIndexChanged);
            // 
            // hierarchyColumn
            // 
            this.hierarchyColumn.AspectName = "name";
            this.hierarchyColumn.Text = "Name";
            this.hierarchyColumn.Width = 200;
            // 
            // HSplit
            // 
            this.HSplit.BackColor = System.Drawing.SystemColors.Control;
            this.HSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.HSplit.Location = new System.Drawing.Point(0, 0);
            this.HSplit.Name = "HSplit";
            this.HSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HSplit.Panel1
            // 
            this.HSplit.Panel1.Controls.Add(this.TreeView);
            // 
            // HSplit.Panel2
            // 
            this.HSplit.Panel2.Controls.Add(this.Detail);
            this.HSplit.Size = new System.Drawing.Size(801, 665);
            this.HSplit.SplitterDistance = 417;
            this.HSplit.TabIndex = 0;
            // 
            // TreeView
            // 
            this.TreeView.AllColumns.Add(this.tree_name);
            this.TreeView.AllColumns.Add(this.tree_responsible);
            this.TreeView.AllColumns.Add(this.tree_checker);
            this.TreeView.AllColumns.Add(this.tree_status);
            this.TreeView.AllColumns.Add(this.tree_process);
            this.TreeView.AllColumns.Add(this.tree_preferAction);
            this.TreeView.AllowDrop = true;
            this.TreeView.CheckBoxes = false;
            this.TreeView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tree_name,
            this.tree_responsible,
            this.tree_checker,
            this.tree_status,
            this.tree_process,
            this.tree_preferAction});
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.FullRowSelect = true;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.OwnerDraw = true;
            this.TreeView.ShowGroups = false;
            this.TreeView.Size = new System.Drawing.Size(801, 417);
            this.TreeView.TabIndex = 4;
            this.TreeView.UseCellFormatEvents = true;
            this.TreeView.UseCompatibleStateImageBehavior = false;
            this.TreeView.UseCustomSelectionColors = true;
            this.TreeView.UseTranslucentSelection = true;
            this.TreeView.View = System.Windows.Forms.View.Details;
            this.TreeView.VirtualMode = true;
            this.TreeView.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.TreeView_CellClick);
            this.TreeView.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.TreeView_FormatCell);
            this.TreeView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.TreeView_FormatRow);
            this.TreeView.SelectionChanged += new System.EventHandler(this.TreeView_SelectionChanged);
            this.TreeView.SelectedIndexChanged += new System.EventHandler(this.TreeView_SelectedIndexChanged);
            this.TreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView_MouseDown);
            // 
            // tree_name
            // 
            this.tree_name.AspectName = "name";
            this.tree_name.Text = "Название";
            this.tree_name.Width = 200;
            // 
            // tree_responsible
            // 
            this.tree_responsible.AspectName = "responsibleName";
            this.tree_responsible.Text = "Ответственный";
            this.tree_responsible.Width = 150;
            // 
            // tree_checker
            // 
            this.tree_checker.AspectName = "checkerName";
            this.tree_checker.Text = "Проверяющий";
            this.tree_checker.Width = 150;
            // 
            // tree_status
            // 
            this.tree_status.AspectName = "statusName";
            this.tree_status.Text = "Статус";
            this.tree_status.Width = 100;
            // 
            // tree_process
            // 
            this.tree_process.AspectName = "processName";
            this.tree_process.Text = "В работе";
            // 
            // tree_preferAction
            // 
            this.tree_preferAction.AspectName = "preferActionName";
            this.tree_preferAction.Text = "Действие";
            this.tree_preferAction.Width = 90;
            // 
            // Detail
            // 
            this.Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Detail.Location = new System.Drawing.Point(0, 0);
            this.Detail.Name = "Detail";
            this.Detail.Size = new System.Drawing.Size(801, 244);
            this.Detail.TabIndex = 0;
            this.Detail.Load += new System.EventHandler(this.Detail_Load);
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.ViewMenu,
            this.ManageMenu,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogOut,
            this.RefreshMenu,
            this.ExitMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(48, 20);
            this.FileMenu.Text = "Файл";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(151, 22);
            this.btnLogOut.Text = "Отлогиниться";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // RefreshMenu
            // 
            this.RefreshMenu.Name = "RefreshMenu";
            this.RefreshMenu.Size = new System.Drawing.Size(151, 22);
            this.RefreshMenu.Text = "Обновить";
            this.RefreshMenu.Click += new System.EventHandler(this.RefreshMenu_Click);
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(151, 22);
            this.ExitMenu.Text = "Выход";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommentModeMenu,
            this.PlainModeMenu});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(39, 20);
            this.ViewMenu.Text = "Вид";
            // 
            // CommentModeMenu
            // 
            this.CommentModeMenu.Name = "CommentModeMenu";
            this.CommentModeMenu.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.CommentModeMenu.Size = new System.Drawing.Size(215, 22);
            this.CommentModeMenu.Text = "Режим комментариев";
            this.CommentModeMenu.Click += new System.EventHandler(this.CommentModeMenu_Click);
            // 
            // PlainModeMenu
            // 
            this.PlainModeMenu.Name = "PlainModeMenu";
            this.PlainModeMenu.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.PlainModeMenu.Size = new System.Drawing.Size(215, 22);
            this.PlainModeMenu.Text = "Плоский режим";
            this.PlainModeMenu.Click += new System.EventHandler(this.PlainModeMenu_Click);
            // 
            // ManageMenu
            // 
            this.ManageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mUsers});
            this.ManageMenu.Name = "ManageMenu";
            this.ManageMenu.Size = new System.Drawing.Size(85, 20);
            this.ManageMenu.Text = "Управление";
            // 
            // mUsers
            // 
            this.mUsers.Name = "mUsers";
            this.mUsers.Size = new System.Drawing.Size(152, 22);
            this.mUsers.Text = "Пользователи";
            this.mUsers.Click += new System.EventHandler(this.mUsers_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenu});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(65, 20);
            this.HelpMenu.Text = "Справка";
            // 
            // AboutMenu
            // 
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(149, 22);
            this.AboutMenu.Text = "О программе";
            this.AboutMenu.Click += new System.EventHandler(this.AboutMenu_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 689);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CornTracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainPanel.ResumeLayout(false);
            this.VSplit.Panel1.ResumeLayout(false);
            this.VSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).EndInit();
            this.VSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Hierarchy)).EndInit();
            this.HSplit.Panel1.ResumeLayout(false);
            this.HSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).EndInit();
            this.HSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.SplitContainer VSplit;
        private BrightIdeasSoftware.TreeListView Hierarchy;
        private BrightIdeasSoftware.OLVColumn hierarchyColumn;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.SplitContainer HSplit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem ManageMenu;
        private System.Windows.Forms.ToolStripMenuItem mUsers;
        private System.Windows.Forms.ToolStripMenuItem btnLogOut;
        private System.Windows.Forms.ToolStripMenuItem CommentModeMenu;
        private TaskDetail Detail;
        private System.Windows.Forms.ToolStripMenuItem RefreshMenu;
        private System.Windows.Forms.ToolStripMenuItem PlainModeMenu;
        private BrightIdeasSoftware.OLVColumn tree_name;
        private BrightIdeasSoftware.OLVColumn tree_responsible;
        private BrightIdeasSoftware.OLVColumn tree_checker;
        private BrightIdeasSoftware.OLVColumn tree_status;
        private BrightIdeasSoftware.OLVColumn tree_process;
        private System.Windows.Forms.Timer timer;
        private BrightIdeasSoftware.OLVColumn tree_preferAction;
        public BrightIdeasSoftware.TreeListView TreeView;


    }
}