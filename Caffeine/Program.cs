using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Caffeine
{
    class Program
    {
        private NotifyIcon bean = new NotifyIcon();
        private SystemControl system = new SystemControl();

        void bean_DoubleClick(object sender, EventArgs e)
        {
            new MainForm().ShowDialog();
        }

        private void Exit_Click(Object sender, System.EventArgs e)
        {
            bean.Visible = false;
            
            system.StopContinuousMode();

            Application.Exit();
        }

        public Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bean.Icon = Caffeine.Properties.Resources.BeanIconWhite;
            bean.Visible = true;
            bean.Text = "Caffeine";
            bean.DoubleClick += new EventHandler(bean_DoubleClick);
            bean.ContextMenu = new ContextMenu();

            bean.ContextMenu.MenuItems.Add(new MenuItem("About", new EventHandler(bean_DoubleClick))
            {
                DefaultItem = true
            });
            bean.ContextMenu.MenuItems.Add(new MenuItem("Exit", new EventHandler(Exit_Click)));
           
            bean.BalloonTipText = "This Computer is currently on Caffeine.";
            bean.BalloonTipIcon = ToolTipIcon.None;
            bean.ShowBalloonTip(5000); // 5 secs

            system.StartContinuousMode();
        }

        public void Run()
        {
            Application.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Program().Run();
        }
    }
}
