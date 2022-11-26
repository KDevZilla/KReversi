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
    public partial class FormConfigure : Form
    {
        public FormConfigure()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetTheme()
        {

        }

        private void ShowTheme()
        {
            this.Visible = false;
            UI.Theme SelectedTheme = Global.LightTheme;
            if (this.chkDarkMode.Checked)
            {
                SelectedTheme = Global.DarkTheme;
            }
            Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(SelectedTheme);

            themeUtil.SetAllofControlInForm(this);

            Utility.UI.MakeFormCaptionToBeDarkMode(this, SelectedTheme.IsFormCaptionDarkMode);
            if (this.FormGameCaller != null)
            {
                this.FormGameCaller.Visible = false;
                this.FormGameCaller.SetTheme(SelectedTheme);
                this.FormGameCaller.Visible = true;

            }
            this.Visible = true;
        }
        public FormGame FormGameCaller = null;
        private void FormConfigure_Load(object sender, EventArgs e)
        {
            this.lblLogfileLocation.Text = "Log file location (Click to open):" + Environment.NewLine +
                Utility.FileUtility.LogFilePath;
            this.txtHumanPlayer1Name.Text = Global.CurrentSettings.Player1AsHumanName;
            this.txtHumanPlayer2Name.Text = Global.CurrentSettings.Player2AsHumanName;

            this.pictureboxBotPhoto1.Image = Utility.FileUtility.GetImageFromBase64(Global.CurrentSettings.Player1AsHumanImagrBase64);
            this.pictureboxBotPhoto1.Tag = Global.CurrentSettings.Player1AsHumanImagrBase64;
            this.pictureboxBotPhoto2.Image = Utility.FileUtility.GetImageFromBase64(Global.CurrentSettings.Player2AsHumanImagrBase64);
            this.pictureboxBotPhoto2.Tag = Global.CurrentSettings.Player2AsHumanImagrBase64;



            this.chkWriteLog.Checked = Global.CurrentSettings.IsWriteLog;
            this.chkDarkMode.Checked = Global.CurrentSettings.IsDarkMode;
            this.chkCompactMode.Checked = Global.CurrentSettings.IsCompaceMode;
            this.chkWriteDebugLog.Checked = Global.CurrentSettings.IsWriteDebugLog;
            this.chkWriteDebugLogL2.Checked = Global.CurrentSettings.IsWriteDebugLogL2;

            this.chkAllowRandomDecision.Checked = Global.CurrentSettings.IsAllowRandomDecision;
            this.chkUseAlphaBetaPruning.Checked = Global.CurrentSettings.IsUsingAlphaBeta;
            this.chkKeepLatestDecision.Checked = Global.CurrentSettings.IsKeepLastDecisionTree;

            this.SetTheme();

        }

        private void ShowPictureByFileName(String fileName, PictureBox pic)
        {

            if (String.IsNullOrEmpty(fileName) ||
                !System.IO.File.Exists(fileName))
            {
                pic.Image = null;
                pic.Tag = "";
                return;
            }

            ShowPictureByBase64Image(Utility.FileUtility.GetBase64FromImageFile(fileName), pic);


        }
        private void ShowPictureByBase64Image(String base64Image, PictureBox pic)
        {
            pic.Image = Utility.FileUtility.GetImageFromBase64(base64Image);
            pic.Tag = base64Image;
        }
        private void Save()
        {


            Global.CurrentSettings.Player1AsHumanName = this.txtHumanPlayer1Name.Text;
            Global.CurrentSettings.Player2AsHumanName = this.txtHumanPlayer2Name.Text;
            Global.CurrentSettings.Player1AsHumanImagrBase64 = this.pictureboxBotPhoto1.Tag.ToString();
            Global.CurrentSettings.Player2AsHumanImagrBase64 = this.pictureboxBotPhoto2.Tag.ToString();
            Global.CurrentSettings.IsDarkMode = this.chkDarkMode.Checked;
            Global.CurrentSettings.IsCompaceMode = this.chkCompactMode.Checked;
            Global.CurrentSettings.IsWriteLog = this.chkWriteLog.Checked;
            Global.CurrentSettings.IsWriteDebugLog = this.chkWriteDebugLog.Checked;
            Global.CurrentSettings.IsWriteDebugLogL2 = this.chkWriteDebugLogL2.Checked;

            Global.CurrentSettings.IsAllowRandomDecision = this.chkAllowRandomDecision.Checked;
            Global.CurrentSettings.IsUsingAlphaBeta = this.chkUseAlphaBetaPruning.Checked;
            Global.CurrentSettings.IsKeepLastDecisionTree = this.chkKeepLatestDecision.Checked;

            Global.SaveSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                String message = "The configuration has been saved. The changed from HumanPlayer, AI tab will be affected in a new game.";

                UI.Dialog.ShowMessage(message);
                this.Close();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage(ex.Message);
            }

        }
        private string Player1NewPhotoPath = "";
        private string Player2NewPhotoPath = "";
        private void btnChoosePhoto1_Click(object sender, EventArgs e)
        {
            string fileName = UI.Dialog.ChoosePhoto();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            Player1NewPhotoPath = fileName;

            ShowPictureByFileName(fileName, this.pictureboxBotPhoto1);
        }

        private void ShowPicture(String fileName, PictureBox pic)
        {

            if (String.IsNullOrEmpty(fileName) ||
                !System.IO.File.Exists(fileName))
            {
                pic.Image = null;
                return;
            }


            pic.Image = Utility.FileUtility.ReadImageWithoutLockFile(fileName);



        }

        private void btnChoosePhoto2_Click(object sender, EventArgs e)
        {
            string fileName = UI.Dialog.ChoosePhoto();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            Player2NewPhotoPath = fileName;
            ShowPictureByFileName(fileName, this.pictureboxBotPhoto2);
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {

            this.ShowTheme();
        }

        private void chkCompactMode_CheckedChanged(object sender, EventArgs e)
        {
            this.FormGameCaller.CompactMode(this.chkCompactMode.Checked);
            if (this.chkCompactMode.Checked)
            {

            }
        }

        private void lblLogfileLocation_Click(object sender, EventArgs e)
        {
            Utility.FileUtility.OpenFolder(Utility.FileUtility.LogFilePath);

        }
    }
}
