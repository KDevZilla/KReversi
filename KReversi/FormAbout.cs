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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.linkLabel1.Text);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);
            //Global.SetButtonColor(this.btnClose);
            Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(Global.CurrentTheme);
            themeUtil.SetButtonColor(this.btnClose)
                .SetForm(this);

            this.richTextBox1.BackColor = Global.CurrentTheme.InputBoxBackColor;
            this.richTextBox1.ForeColor = Global.CurrentTheme.LabelForeColor;
            


            //this.BackColor = Global.CurrentTheme.FormBackColor;
            if (Global.CurrentTheme.IsFormCaptionDarkMode)
            {
                this.linkLabel1.LinkColor = Color.FromArgb(24, 97, 205);
                this.linkLabel2.LinkColor = Color.FromArgb(24, 97, 205);
            }

            this.richTextBox1.LinkClicked += RichTextBox1_LinkClicked;

        }
        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {

            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.linkLabel2.Text);
        }
    }
}
