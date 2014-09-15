
using Npgsql;
using System;
using System.Collections.Generic;
using BrightIdeasSoftware;

namespace CornTracker
{
    public class Node : TimeRecord
    {
        public Node() { }

        public Node(NpgsqlDataReader reader) : base(reader) { }

        public void SetInterest(bool value)
        {
            interest = value;
        }

        [Field] virtual public string name { get; set; }
        [Field] virtual public int parent { get; set; }
        [Field] virtual public ENodeType type { get; set; }
        [Field] virtual public int responsible { get; set; }
        [Field] virtual public int checker { get; set; }
        [Field] virtual public ECheckerType checkertype { get; set; }
        [Field] virtual public ENodeStatus status { get; set; }
        [Field] virtual public bool process { get; set; }

        virtual public string statusName
        {
            get {
                if (type != ENodeType.TASK)
                    return "";
                if (process)
                    return ((ENodeProcessStatus)status).Tag();
                return status.Tag();
            }
        }

        virtual public string processName
        {
            get {
                if (type == ENodeType.FOLDER)
                    return "";
                return process ? "Да" : "Нет"; 
            }
        }

        virtual public EAction preferAction 
        {
            get
            {
                if (type == ENodeType.TASK)
                {
                    int id = Global.loggedUser.id;

                    if (status == ENodeStatus.ACTIVE && responsible == id)
                        return EAction.DONE;

                    if (status == ENodeStatus.COMPLETED && checker == id)
                        return EAction.CHECK;
                }
                return EAction.NONE;
            }
        }

        virtual public string preferActionName
        {
            get { return preferAction.Tag(); }
        }

        virtual public string responsibleName
        {
            get { return Users.GetName(responsible); }
        }

        virtual public string checkerName
        {
            get {
                switch( checkertype )
                {
                    case ECheckerType.PERSON:
                        return Users.GetName(checker);
                    case ECheckerType.PARENT:
                        return "Ответственный за родительскую задачу";
                    case ECheckerType.AUTO:
                        return "";
                }
                return "";
            }
        }

        virtual public bool interest { get; set; }

        public List<Node> Nodes;

        public void AddNode(Node node)
        {
            if( Nodes == null )
                Nodes = new List<Node>();
            Nodes.Add(node);
        }

        public void RemoveNode(Node node)
        {
            Nodes.Remove(node);
        }
        
        public List<Node> GetPlainChildList()
        {
            List<Node> plainList = new List<Node>();
            this.FillListRecursive(plainList);
            return plainList;
        }

        private void FillListRecursive( List<Node> plainList )
        {
            if (Nodes != null)
                foreach (Node node in Nodes)
                    node.FillListRecursive(plainList);
            plainList.Add(this);
        }

        //---------------------------------------------

        public static TreeListView.ChildrenGetterDelegate ChildrenGetter = delegate(object x)
        {
            return ((Node)x).Nodes;
        };

        public static TreeListView.CanExpandGetterDelegate CanExpandGetter = delegate(object x)
        {
            List<Node> nodes = ((Node)x).Nodes;
            return nodes != null && nodes.Count > 0;
        };

        public static TreeListView.CanExpandGetterDelegate FolderCanExpandGetter = delegate(object x)
        {
            List<Node> nodes = ((Node)x).Nodes;
            if( nodes != null )
                foreach (Node node in nodes)
                    if (node.type == ENodeType.FOLDER)
                        return true;
            return false;
        };

        public static ImageGetterDelegate ImageGetter = delegate(object x)
        {
            Node node = (Node)x;
            if (node.type == ENodeType.FOLDER)
            {
                return "folder.png";
            }
            else
            {
                return "task.png";
            }
        };

        public static ImageGetterDelegate ActionImageGetter = delegate(object x)
        {
            Node node = (Node)x;
            switch (node.preferAction)
            {
                case EAction.DONE:
                    return "done.png";
                case EAction.CHECK:
                    return "check.png";
            }
            return "";
        };

    }
}