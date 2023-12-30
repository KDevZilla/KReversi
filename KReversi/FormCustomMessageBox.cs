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
    public partial class FormCustomMessageBox : Form
    {
        public FormCustomMessageBox()
        {
            InitializeComponent();
        }
        public String Caption
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }
        public String Message {
            get
            {
                return this.txtMessage.Text ;
            }
            set
            {
                this.txtMessage.Text = value;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private Boolean _ShowCancel = false;
        public Boolean ShowCancel
        {
            get
            {
                return _ShowCancel;
            }
            set
            {
                _ShowCancel = value;
                SetCancelbuttonVisible();
            }
        }
        private void SetCancelbuttonVisible()
        {
            this.btnCancel.Visible = true;
            this.btnOK.Left = 247;
            if (!_ShowCancel)
            {
                this.btnCancel.Visible = false;
                this.btnOK.Left = this.btnCancel.Left;
            }
        }
        private void SetTheme()
        {

            this.txtMessage.BackColor = Global.CurrentTheme.FormBackColor;
            this.txtMessage.ForeColor = Global.CurrentTheme.LabelForeColor;
            Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);
            Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(Global.CurrentTheme);
            themeUtil
                .SetButtonColor(this.btnOK, this.btnCancel)
                .SetForm(this);

          
        }
        private void FormCustomMessageBox_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.KReversiIcon;
            this.pictureBox1.Image = SystemIcons.Information.ToBitmap();
            this.SetTheme();
           
        }
    }
}
