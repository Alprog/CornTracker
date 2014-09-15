using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CornTracker.Properties;

namespace CornTracker
{
    class Global
    {
        public static User loggedUser = null;
        public static Dictionary<int, Node> NodesDictionary;
        public static Form activeForm = null;
        public static NotifyIcon notifyIcon;
        public static bool isRunning = false;
        public static bool plainMode = false;
        public static bool needUpdate = false;

        public static void StartUp()
        {
            DataProvider.TryConnect();
            InitIcon();

            TryLogin(Settings.Default.Login, Settings.Default.Password, true);
            if (loggedUser == null)
                activeForm = new LoginForm();

            ShowActiveForm();
            isRunning = true;
            Application.Run();
            notifyIcon.Visible = false;
        }

        public static bool TryLogin(string login, string password, bool auto = false)
        {
            try
            {
                if (login == "")
                    throw new Exception("Имя пользователя не может быть пустым");
                
                string queryString = String.Format("SELECT * FROM users WHERE login = '{0}'", login );
                List<User> userList = DataProvider.GetRecordsFromQuery<User>(queryString);
                if (userList.Count == 0)
                    throw new Exception(String.Format("Пользователь {0} отсутствует в базе", login));

                User user = userList[0];
                if (user.password == null)
                {
                    DialogResult result = new ChangePasswordForm(user).ShowDialog();
                    if (result != DialogResult.OK)
                        return false;
                }
                else
                {
                    if (user.password != Utils.MD5(password))
                        throw new Exception("Пароль не подходит");
                }

                loggedUser = user;

                if (activeForm != null)
                    activeForm.Close();
                activeForm = new MainForm();
                ShowActiveForm();

            }
            catch (Exception error)
            {
                if(!auto)
                    Utils.ErrorMessage(error.Message);
                return false;
            }

            return true;
        }

        public static void LogOut()
        {
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            loggedUser = null;
            if (activeForm != null)
                activeForm.Close();
            activeForm = new LoginForm();
            ShowActiveForm();
        }

        public static void ShowActiveForm()
        {
            if (activeForm == null)
                return;

            if( !activeForm.Visible )
                activeForm.Show();

            if (activeForm.WindowState == FormWindowState.Minimized)
                activeForm.WindowState = FormWindowState.Normal;

            // Переместить на передний план
            activeForm.TopMost = true;
            activeForm.TopMost = false;
        }

        public static void Exit()
        {
            isRunning = false;
            Application.Exit();
        }

        public static void InitIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = new System.Drawing.Icon("corn.ico");

            ContextMenuStrip menu = new ContextMenuStrip();
            Utils.AddMenuItem(menu, "Показать", ShowActiveForm, true);
            Utils.AddMenuItem(menu, "Выход", Exit);

            notifyIcon.MouseClick += delegate(Object sender, MouseEventArgs e) {
                if( e.Button == MouseButtons.Left )
                    ShowActiveForm();
            };

            notifyIcon.ContextMenuStrip = menu;
        }

    }
}
