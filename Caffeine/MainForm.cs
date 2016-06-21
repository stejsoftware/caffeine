using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Caffeine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Icon = Caffeine.Properties.Resources.BeanIcon;
            niBean.Icon = Caffeine.Properties.Resources.BeanIcon;
            niBean.ShowBalloonTip(100, "Caffeine","Don't Go to sleep!", ToolTipIcon.None);
        }
    }
}
