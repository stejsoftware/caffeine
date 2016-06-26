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
        }

        private void pbBean_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Caffeine.Properties.Resources.SITE_URL);
        }
    }
}
