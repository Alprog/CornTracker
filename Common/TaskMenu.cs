using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CornTracker
{
    public class TaskMenu : ContextMenuStrip
    {
        MainForm form = null;


        public TaskMenu(MainForm form)
        {
            this.form = form;
        }

    }
}
