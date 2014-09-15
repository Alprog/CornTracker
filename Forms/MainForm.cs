using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace CornTracker
{
    public partial class MainForm : Form
    {
        ContextMenuStrip TaskContextMenu;
        bool LockUpdate = false;

        public MainForm()
        {
            InitializeComponent();

            Users.UpdateInformation();

            this.Text = "CornTracker - " + Global.loggedUser.name;

            TreeView.CanExpandGetter = Node.CanExpandGetter;
            TreeView.ChildrenGetter = Node.ChildrenGetter;
            this.tree_name.ImageGetter = Node.ImageGetter;
            this.tree_preferAction.ImageGetter = Node.ActionImageGetter;
            Hierarchy.CanExpandGetter = Node.FolderCanExpandGetter;
            Hierarchy.ChildrenGetter = Node.ChildrenGetter;
            this.hierarchyColumn.ImageGetter = Node.ImageGetter;

            Utils.FillImageList(ImageList, Application.StartupPath + "\\Icons");
            TreeView.SmallImageList = ImageList;
            Hierarchy.SmallImageList = ImageList;

            Hierarchy.ModelFilter = new BrightIdeasSoftware.ModelFilter (
                delegate(object x) {
                    return ((Node)x).type == ENodeType.FOLDER; 
                }
            );
            Hierarchy.UseFiltering = true;

            TaskContextMenu = new ContextMenuStrip();
            Utils.AddMenuItem(TaskContextMenu, "Создать подзадачу", CreateTask);

            Global.needUpdate = false;
            Global.NodesDictionary = new Dictionary<int, Node>();
            AddNodes(DataProvider.GetAllActiveNodes());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.isRunning)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void CreateTask()
        {
            DialogResult result = new NewTaskForm((Node)TreeView.SelectedObject).ShowDialog();
            if (result == DialogResult.OK)
                RefreshHierarchy();
        }

        //----------------------------------------------------------------------------------------------------

        #region Модификация тасок

            private void ApplyChanges(Node node)
            {
                ApplyChanges(new Node[] { node });
            }

            private void ApplyChanges(IEnumerable<Node> nodes)
            {
                TreeView.Refresh();
                foreach (Node node in nodes)
                    node.UpdateWithCurrentTime();
                DataProvider.Notify("update");
            }

            private string GetNodesName(IEnumerable<Node> nodes)
            {
                if (nodes.Count() == 1)
                    return String.Format("\"{0}\"", nodes.First().name);
                else
                    return String.Format("задачи ({0})", nodes.Count());
            }

            private void ChangeState(IEnumerable<Node> nodes, ENodeStatus status, bool force = false)
            {
                if (force || Utils.Confirm("Сменить статус \"{0}\" на \"{1}\"?", GetNodesName(nodes), status.Tag()))
                {
                    foreach (Node node in nodes)
                    {
                        node.process = false;
                        node.status = status;
                    }
                    ApplyChanges(nodes);
                }
            }

            private void ChangeResponsible(IEnumerable<Node> nodes, int id, bool force = false)
            {
                if (force || Utils.Confirm("Сменить ответственного за \"{0}\" на \"{1}\"?", GetNodesName(nodes), Users.GetName(id)))
                {
                    foreach (Node node in nodes)
                    {
                        node.process = false;
                        node.responsible = id;
                    }
                    ApplyChanges(nodes);
                }
            }

            private void ChangeChecker(IEnumerable<Node> nodes, ECheckerType type, int id = 0, bool force = false)
            {
                string text = type == ECheckerType.PERSON ? Users.GetName(id) : type.Tag();
                if (force || Utils.Confirm("Сменить проверяющего \"{0}\" на \"{1}\"", GetNodesName(nodes), text))
                {
                    foreach (Node node in nodes)
                    {
                        node.process = false;
                        node.checkertype = type;
                        node.checker = id;
                    }
                    ApplyChanges(nodes);
                }
            }

            private void DoPreferAction(Node node)
            {
                switch (node.preferAction)
                {
                    case EAction.DONE:
                        ChangeState(new Node[] { node }, ENodeStatus.COMPLETED);
                        break;

                    case EAction.CHECK:
                        ChangeState(new Node[] { node }, ENodeStatus.CHECKED);
                        break;
                }
            }
            
        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Обработчики меню

            private void RefreshMenu_Click(object sender, EventArgs e)
            {
                UpdateNodes();
            }

            private void PlainModeMenu_Click(object sender, EventArgs e)
            {
                Global.plainMode = !Global.plainMode;
                RefreshHierarchy();
                PlainModeMenu.Checked = Global.plainMode;
            }

            private void CommentModeMenu_Click(object sender, EventArgs e)
            {
                bool check = !CommentModeMenu.Checked;
                CommentModeMenu.Checked = check;
                VSplit.Panel1Collapsed = check;
                HSplit.Panel1Collapsed = check;
            }

            private void mUsers_Click(object sender, EventArgs e)
            {
                (new UsersForm()).ShowDialog();
            }

            private void btnLogOut_Click(object sender, EventArgs e)
            {
                Global.LogOut();
            }

            private void ExitMenu_Click(object sender, EventArgs e)
            {
                Global.Exit();
            }

            private void AboutMenu_Click(object sender, EventArgs e)
            {
                (new AboutForm()).Show();
            }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Обработчики TreeView

            private void TreeView_MouseDown(object sender, MouseEventArgs e)
            {
                TreeView.Tag = TreeView.SelectedObject;
            }

            private void TreeView_CellClick(object sender, CellClickEventArgs e)
            {
                if (e.Item == null)
                    return;

                Node node = (Node)e.Item.RowObject;

                switch (e.Column.AspectName)
                {
                    case "processName":
                        if (node.preferAction != EAction.NONE)
                        {
                            node.process = !node.process;
                            ApplyChanges(node);
                        }
                        break;

                    case "preferActionName":
                        DoPreferAction(node);
                        return;
                }

                if (e.Item.RowObject != e.ListView.Tag)
                    return;

                if (node.type != ENodeType.TASK)
                    return;

                switch (e.Column.AspectName)
                {
                    case "name":
                        break;

                    case "responsibleName":
                        ShowUserSelectMenu(e, false);
                        break;

                    case "checkerName":
                        ShowUserSelectMenu(e, true);
                        break;

                    case "statusName":
                        ShowStatusMenu(e);
                        break;
                }
            }

            private void TreeView_SelectionChanged(object sender, EventArgs e)
            {
                if (TreeView.SelectedObject == null)
                {
                    TreeView.ContextMenuStrip = null;
                }
                else
                {
                    TreeView.ContextMenuStrip = TaskContextMenu;
                }
                Detail.SetNode((Node)TreeView.SelectedObject);
                TreeView.Refresh();
            }

            private void TreeView_FormatRow(object sender, FormatRowEventArgs e)
            {
                Node node = (Node)e.Item.RowObject;
                if (node.process)
                    e.Item.BackColor = Color.FromArgb(255, 255, 180);
            }

            private void TreeView_FormatCell(object sender, FormatCellEventArgs e)
            {
                Node node = (Node)e.Item.RowObject;
                if ((e.Column == this.tree_process && node.preferAction != EAction.NONE) || e.Column == this.tree_preferAction)
                {
                    e.SubItem.Font = new Font(e.Item.Font, FontStyle.Bold);
                }
            }

        #endregion 

        //----------------------------------------------------------------------------------------------------

        #region Обновление

            private void timer_Tick(object sender, EventArgs e)
            {
                if (Global.needUpdate)
                {
                    UpdateNodes();
                    Global.needUpdate = false;
                }
                else
                {
                    DataProvider.RunQuery("");
                }
            }

            public void UpdateNodes()
            {
                while (true)
                {
                    List<Node> nodes = DataProvider.GetUpdatedNodes();
                    if (nodes.Count > 0)
                        AddNodes(nodes);
                    else
                        break;
                }
            }

            private void AddNodes(IEnumerable<Node> updatedNodes)
            {
                Dictionary<int, Node> dict = Global.NodesDictionary;
                List<Node> newNodes = new List<Node>();
                foreach (Node node in updatedNodes)
                {
                    if (dict.Keys.Contains(node.id))
                    {
                        var oldNode = dict[node.id];
                        if (node.parent != oldNode.parent)
                        {
                            if (dict.Keys.Contains(node.parent))
                                dict[node.parent].RemoveNode(oldNode);
                            newNodes.Add(node);
                        }
                        dict[node.id].CopyPropertiesFrom(node);
                    }
                    else
                    {
                        dict.Add(node.id, node);
                        newNodes.Add(node);
                    }
                }

                foreach (Node node in newNodes)
                    if (dict.Keys.Contains(node.parent))
                        dict[node.parent].AddNode(node);

                RefreshHierarchy();
            }

            private void RefreshHierarchy()
            {
                var rootNodes = new List<Node>();
                rootNodes.Add(Global.NodesDictionary[1]);
                LockUpdate = true;
                Hierarchy.SetObjects(rootNodes);
                Hierarchy.RebuildAll(true);
                LockUpdate = false;
                RefreshViews();
            }

            private void Hierarchy_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (!LockUpdate)
                    RefreshViews();
            }

            private void RefreshViews()
            {
                var selObject = TreeView.SelectedObject;
                var selObjects = TreeView.SelectedObjects;

                if (Hierarchy.SelectedItem == null)
                {
                    TreeView.ClearObjects();
                    Detail.SetNode(null);
                }
                else
                {
                    Node node = (Node)Hierarchy.SelectedItem.RowObject;

                    TreeView.BeginUpdate();

                    if (Global.plainMode)
                    {
                        TreeView.CanExpandGetter = delegate(object x) { return false; };
                        TreeView.ChildrenGetter = delegate(object x) { return new List<Node>(); };
                        TreeView.SetObjects(node.GetPlainChildList());
                    }
                    else
                    {
                        TreeView.CanExpandGetter = Node.CanExpandGetter;
                        TreeView.ChildrenGetter = Node.ChildrenGetter;
                        TreeView.SetObjects(node.Nodes);
                    }

                    TreeView.RebuildAll(true);
                    TreeView.ExpandAll();

                    TreeView.ModelFilter = new BrightIdeasSoftware.ModelFilter(
                        delegate(object x)
                        {
                            Node n = (Node)x;

                            if (n.type != ENodeType.TASK)
                                return false;

                            if (n.status == ENodeStatus.CHECKED)
                                return false;

                            return true;
                        }
                    );

                    //string[] str = { "г", "2" };
                    //TreeView.ModelFilter = TextMatchFilter.Contains(TreeView, str);
                    //TreeView.DefaultRenderer = new HighlightTextRenderer(TextMatchFilter.Contains(TreeView, str));

                    TreeView.UseFiltering = true;

                    try
                    {
                        TreeView.SelectedObject = selObject;
                        TreeView.SelectedObjects = selObjects;
                    }
                    catch (Exception ex) { }

                    TreeView.EndUpdate();
                }
            }

        #endregion

        //----------------------------------------------------------------------------------------------------

        private void ShowStatusMenu(CellClickEventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            for (int i = 0; i < (int)ENodeStatus.COUNT; i++)
            {
                ENodeStatus status = (ENodeStatus)i;
                Utils.AddMenuItem(menu, status.Tag(), delegate()
                {
                    ChangeState(new Node[]{(Node)e.Item.RowObject}, status);
                });
            }
            ShowCellComboBox(menu, e);
        }

        private void ShowUserSelectMenu(BrightIdeasSoftware.CellClickEventArgs e, bool checker)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            Node[] nodes = {(Node)e.Item.RowObject};
            if (checker)
            {
                for (int i = 0; i < 2; i++)
                {
                    ECheckerType type = (ECheckerType)i;
                    Utils.AddMenuItem(menu, type.Tag(), delegate()
                    {
                        ChangeChecker(nodes, type);
                    });
                }
            }
            foreach (User user in Users.dictionary.Values)
            {
                int id = user.id;
                Utils.AddMenuItem(menu, user.name, delegate()
                {
                    if (checker)
                        ChangeChecker( nodes, ECheckerType.PERSON, id);
                    else
                        ChangeResponsible(nodes, id);
                });
            }
            ShowCellComboBox(menu, e);
        }

        private void ShowCellComboBox(ContextMenuStrip menu, CellClickEventArgs e)
        {
            menu.Items[0].Select();
            int X = 0;
            for (int i = 0; i <= e.ColumnIndex - 1; i++)
                X += e.ListView.Columns[i].Width;
            menu.Show(e.ListView, new Point(X, e.Item.Position.Y));
        }

        private void TreeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Detail_Load(object sender, EventArgs e)
        {

        }



    }
}
