using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi
{
    public partial class FormTestDynamicMenu : Form
    {
        public FormTestDynamicMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fileToolStripMenuItem.DropDownItems[1].Visible = false;

        }
    }
}
