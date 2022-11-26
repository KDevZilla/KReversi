using KReversi.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KReversi.Utility;
using System.IO;

namespace KReversi
{
    public partial class FormBotCreator : Form
    {
        public FormBotCreator()
        {
            InitializeComponent();
        }
        private PanelBotConfigure panelBotOpen = new PanelBotConfigure();
        private PanelBotConfigure panelBotMiddle = new PanelBotConfigure();
        private PanelBotConfigure panelBotEnd = new PanelBotConfigure();
        List<PanelBotConfigure> listpanel = new List<PanelBotConfigure>();

        private void FormBotCreator_Load(object sender, EventArgs e)
        {


            //Some time IDE has the problem that it will not automatically added 
            //So I need to manually add them
            if (this.newToolStripMenuItem.DropDownItems.Count == 0)
            {
                this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripMenuItem1,
                this.openToolStripMenuItem,
                this.SavetoolStripMenuItem,
                this.toolStripMenuItem3,
                this.deleteToolStripMenuItem,
                this.toolStripMenuItemRecentlyLine,
                this.exitToolStripMenuItem});
            }
            listpanel.Add(panelBotOpen);
            listpanel.Add(panelBotMiddle);
            listpanel.Add(panelBotEnd);
            foreach (PanelBotConfigure panel in listpanel)
            {
                panel.Top = 0;
                panel.Left = 0;
                panel.Height = 700;
                panel.Width = 700;
                panel.Visible = true;
                panel.ControlForeColor = Global.CurrentTheme.LabelForeColor;

                panel.Initial();
                //  panel.BackColor = Color.Red;
            }
            panelBotOpen.btnCopyCellToOther1.Text = "Copy cell to Middle";
            panelBotOpen.btnCopyCellToOther2.Text = "Copy cell to End Game";

            panelBotMiddle.btnCopyCellToOther1.Text = "Copy cell to Opening";
            panelBotMiddle.btnCopyCellToOther2.Text = "Copy cell to End Game";

            panelBotEnd.btnCopyCellToOther1.Text = "Copy cell to Opening";
            panelBotEnd.btnCopyCellToOther2.Text = "Copy cell to Middle";

            EnablePositionScore(this.chkPositionScore.Checked);


            this.tabPage1.Controls.Add(panelBotOpen);
            this.tabPage2.Controls.Add(panelBotMiddle);
            this.tabPage3.Controls.Add(panelBotEnd);
            Utility.ThemeUtility themeUtil = new ThemeUtility(Global.CurrentTheme);
            themeUtil.SetLabelColor(lblBotName,
                                    lblTimeLimit,
                                    lblWarning,
                                    lblStableDiskscore,
                                    lblFOrcePassScore)
                      .SetButtonColor(btnChoosePhoto,
                          panelBotOpen.btnCopyCellToOther1,
                          panelBotOpen.btnCopyCellToOther2,
                          panelBotMiddle.btnCopyCellToOther1,
                          panelBotMiddle.btnCopyCellToOther2,
                          panelBotEnd.btnCopyCellToOther1,
                          panelBotEnd.btnCopyCellToOther2)
                       .SetTextBoxColor(txtBotName)
                       .SetTabControl(this.tabControl1)
                       .SetNumericUpDownColor(numTimeLimitPerMove,
                       numStableDiskScore,
                       numericForcePassScore,
                        panelBotOpen.numBotDepth,
                          panelBotOpen.numScoreMobilize,
                          panelBotMiddle.numBotDepth,
                          panelBotMiddle.numScoreMobilize,
                          panelBotEnd.numBotDepth,
                          panelBotEnd.numScoreMobilize
                       )
                       .SetCheckboxColor(this.chkPositionScore)
                       .SetMenu(this.menuStrip1)
                       .SetForm(this);



            this.panelBotOpen.btnCopyCellToOther1.Click -= BtnOpenCopyCellToMiddle_Click;
            this.panelBotOpen.btnCopyCellToOther2.Click -= BtnOpenCoplyCellToEndGame_Click;
            this.panelBotMiddle.btnCopyCellToOther1.Click -= BtnMiddleCopyCellToOpening_Click;
            this.panelBotMiddle.btnCopyCellToOther2.Click -= BtnMiddleCOpyCellToEndGmae_Click;
            this.panelBotEnd.btnCopyCellToOther1.Click -= BtnEndGameCopyCellToOpenning_Click;
            this.panelBotEnd.btnCopyCellToOther2.Click -= BtnEndGameCopyCellToMiddle_Click;

            this.panelBotOpen.btnCopyCellToOther1.Click += BtnOpenCopyCellToMiddle_Click;
            this.panelBotOpen.btnCopyCellToOther2.Click += BtnOpenCoplyCellToEndGame_Click;
            this.panelBotMiddle.btnCopyCellToOther1.Click += BtnMiddleCopyCellToOpening_Click;
            this.panelBotMiddle.btnCopyCellToOther2.Click += BtnMiddleCOpyCellToEndGmae_Click;
            this.panelBotEnd.btnCopyCellToOther1.Click += BtnEndGameCopyCellToOpenning_Click;
            this.panelBotEnd.btnCopyCellToOther2.Click += BtnEndGameCopyCellToMiddle_Click;



            Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);
            bool IsShowDialogIfCannotload = false;
            /*
            String LastBot = Global.CurrentSettings.LastBotSavedFileName;
            if (LastBot != "" &&
                System.IO.File.Exists(LastBot))
            {
                if (this.LoadBotFromFile(LastBot, IsShowDialogIfCannotload))
                {
                    return;
                }
                
            }
            */

            NewBot();
            toolStripMenuItemRecentlyEmpty.Click += ToolStripMenuItemRecentlyEmpty_Click;
            RenderRecentlyBotOpenFileMenu();

        }

        private void ToolStripMenuItemRecentlyEmpty_Click(object sender, EventArgs e)
        {
            Global.BotRecentlyFile.Clear();
            Global.SaveBotRecentlyFile();
            RenderRecentlyBotOpenFileMenu();
        }

        Dictionary<int, ToolStripMenuItem> dicRecentlyOpen = new Dictionary<int, ToolStripMenuItem>();

        private void RenderRecentlyBotOpenFileMenu()
        {
            //toolStripMenuItemRecently1
            int i;
            if (dicRecentlyOpen == null ||
                dicRecentlyOpen.Count == 0)
            {
                dicRecentlyOpen = new Dictionary<int, ToolStripMenuItem>();
                dicRecentlyOpen.Add(0, toolStripMenuItemRecently1);
                dicRecentlyOpen.Add(1, toolStripMenuItemRecently2);
                dicRecentlyOpen.Add(2, toolStripMenuItemRecently3);
                dicRecentlyOpen.Add(3, toolStripMenuItemRecently4);
                dicRecentlyOpen.Add(4, toolStripMenuItemRecently5);
                dicRecentlyOpen.Add(5, toolStripMenuItemRecently6);

                for (i = 0; i < dicRecentlyOpen.Count; i++)
                {
                    dicRecentlyOpen[i].Tag = i;
                    dicRecentlyOpen[i].Click += ToolStripMenuItemRecently_Click;
                }

            }

            for (i = 0; i < dicRecentlyOpen.Count; i++)
            {
                dicRecentlyOpen[i].Visible = false;
            }
            toolStripMenuItemRecentlyLine.Visible = false;
            toolStripMenuItemRecentlyEmpty.Visible = false;

            for (i = 0; i < dicRecentlyOpen.Count; i++)
            {
                if (Global.BotRecentlyFile.ListRecentyFile[i].Trim() == "")
                {
                    break;
                }
                dicRecentlyOpen[i].Visible = true;
                dicRecentlyOpen[i].Text = (i + 1) + "." + Global.BotRecentlyFile.ListRecentyFile[i];
                toolStripMenuItemRecentlyLine.Visible = true;
                toolStripMenuItemRecentlyEmpty.Visible = true;
            }


        }

        private void ToolStripMenuItemRecently_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int index = (int)item.Tag;
            String botPath = Global.BotRecentlyFile.ListRecentyFile[index];
            //MessageBox.Show(botPath);
            LoadBotFromFile(botPath, true);
        }

        private void EnablePositionScore(bool IsEnable)
        {
            this.panelBotOpen.panelposition.Enabled = IsEnable;
            this.panelBotMiddle.panelposition.Enabled = IsEnable;
            this.panelBotEnd.panelposition.Enabled = IsEnable;
        }
        private void CopyCell(PanelBotConfigure pnlOriginal, PanelBotConfigure pnlDestination)
        {

            int i;
            int j;
            pnlOriginal.panelposition.UpdateValuefromTextbox();

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    pnlDestination.arrValue[i, j] = pnlOriginal.arrValue[i, j];

                }

            }
            pnlDestination.UpdateRenderPosition();
        }
        private void BtnEndGameCopyCellToMiddle_Click(object sender, EventArgs e)
        {
            CopyCell(panelBotEnd, panelBotMiddle);
        }

        private void BtnEndGameCopyCellToOpenning_Click(object sender, EventArgs e)
        {
            CopyCell(panelBotEnd, panelBotOpen);
        }

        private void BtnMiddleCOpyCellToEndGmae_Click(object sender, EventArgs e)
        {
            CopyCell(panelBotMiddle, panelBotEnd);
        }

        private void BtnMiddleCopyCellToOpening_Click(object sender, EventArgs e)
        {
            CopyCell(panelBotMiddle, panelBotOpen);
        }

        private void BtnOpenCoplyCellToEndGame_Click(object sender, EventArgs e)
        {
            CopyCell(panelBotOpen, panelBotEnd);
        }

        private void BtnOpenCopyCellToMiddle_Click(object sender, EventArgs e)
        {
            CopyCell(panelBotOpen, panelBotMiddle);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NewBot()
        {
            MinimaxBot = AI.MiniMaxBotProto.CreateBot();

            this.OpenningBotFileName = "";
            ShowCurrentBotFileName();
            ShowBotValueInControl();
        }
        private void NewStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewBot();
            OpenningBotFileName = "";
            ShowBotValueInControl();
        }
        private void ShowBotValueInControl()
        {
            this.panelBotOpen.arrValue = MinimaxBot.OpenGamePostionScore;
            this.panelBotOpen.numScoreMobilize.Text = MinimaxBot.ScoreNumberMoveAtBegingGame.ToString();
            this.panelBotOpen.numBotDepth.Text = MinimaxBot.DepthLevelAtBeginGame.ToString();


            this.panelBotMiddle.arrValue = MinimaxBot.MidGamePostionScore;
            this.panelBotMiddle.numScoreMobilize.Text = MinimaxBot.ScoreNumberMoveAtMiddleGame.ToString();
            this.panelBotMiddle.numBotDepth.Text = MinimaxBot.DepthLevelAtMiddleGame.ToString();


            this.panelBotEnd.arrValue = MinimaxBot.EndGamePostionScore;
            this.panelBotEnd.numScoreMobilize.Text = MinimaxBot.ScoreNumberMoveAtEndGame.ToString();
            this.panelBotEnd.numBotDepth.Text = MinimaxBot.DepthLevelAtEndGame.ToString();

            this.txtBotName.Text = MinimaxBot.BotName;


            this.numStableDiskScore.Value = MinimaxBot.StableDiskScore;
            this.numTimeLimitPerMove.Value = MinimaxBot.TimeLimitPermove;
            this.numericForcePassScore.Value = MinimaxBot.ForcePassSocre;

            this.chkPositionScore.Checked = MinimaxBot.IsUseScoreFromPosition;
            ShowPictureByBase64Image(MinimaxBot.Base64Image);

        }
        private string OpenningBotFileName = "";

        private void ChooseBot()
        {

            string fileName = UI.Dialog.ChooseBotOpenPath();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            LoadBotFromFile(fileName, true);



        }
        private void AddRecentlyFile(String fileName)
        {
            try
            {
                Global.BotRecentlyFile.InsertNewPath(fileName);
                Global.SaveBotRecentlyFile();
                RenderRecentlyBotOpenFileMenu();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                //It is not a bigdeal so we will not interrupt a use
            }
        }
        private Boolean LoadBotFromFile(String fileName, bool IsShowDialogIfCannotLoad)
        {
            try
            {
                MinimaxBot = Utility.SerializeUtility.DeserializeMinimaxBot(fileName);

                OpenningBotFileName = fileName;
                ShowCurrentBotFileName();
                ShowBotValueInControl();
                AddRecentlyFile(fileName);
                return true;


            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                if (IsShowDialogIfCannotLoad)
                {
                    UI.Dialog.ShowErrorMessage("There is a problem to load the bot " + fileName);
                }
                return false;
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseBot();
        }
        private Boolean DeleteBot(String fileName)
        {
            try
            {


                System.IO.File.Delete(fileName);
                return true;
            }
            catch (Exception ex)
            {
                //Do not forget to write log
                return false;

            }
        }
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {

            if (UI.Dialog.ShowConfirm(String.Format("Are you sure that you want to delete {0}", this.OpenningBotFileName)) != DialogResult.OK)
            {
                return;
            }
            if (DeleteBot(this.OpenningBotFileName))
            {
                UI.Dialog.ShowMessage(String.Format("Successfully delete {0}", this.OpenningBotFileName));

                this.OpenningBotFileName = "";
                NewBot();
                return;
            }
            UI.Dialog.ShowErrorMessage(String.Format("Having a problem to delete {0}", this.OpenningBotFileName));

        }
        AI.MiniMaxBotProto MinimaxBot = null;
        int MinCellValue = -350;
        int MaxCellValue = 350;
        int MinDepthLevel = 1;
        int MaxDepthLevel = 10;
        int MinScoreAvilableMove = -70;
        int MaxScoreAvilableMove = 70;
        private Boolean VerifyPanelBotConfig(PanelBotConfigure pnl, String panelName, ref String AlertMessage)
        {
            String message = "";
            if (!pnl.panelposition.IsTextBoxValueValid(MinCellValue, MaxCellValue))
            {
                message += String.Format("Cell {0} value must be numeric value between {1} and {2}", panelName, MinCellValue, MaxCellValue) + Environment.NewLine;
            }
            if (!Utility.Utility.IsInt(pnl.numBotDepth.Text) ||
               !pnl.numBotDepth.Text.IsBetween(MinDepthLevel, MaxDepthLevel))
            {
                message += String.Format("Depth Level from and To for {0} must be numeric value between {1} and {2}", panelName, MinDepthLevel, MaxDepthLevel) + Environment.NewLine;

            }

            if (!Utility.Utility.IsInt(pnl.numScoreMobilize.Text) ||
                !pnl.numScoreMobilize.Text.IsBetween(MinScoreAvilableMove, MaxScoreAvilableMove))
            {
                message += String.Format("Score Avilable move for {0} must be numeric value between {1} and {2}", panelName, MinScoreAvilableMove, MaxScoreAvilableMove) + Environment.NewLine;
            }
            AlertMessage += message;
            return (message.Trim() == "");
        }
        private Boolean VerifyBot(ref String AlertMessage)
        {

            if (this.txtBotName.Text.Trim() == "")
            {
                AlertMessage += "Please enter bot name" + Environment.NewLine;
            }

            VerifyPanelBotConfig(this.panelBotOpen, "Openning", ref AlertMessage);
            VerifyPanelBotConfig(this.panelBotMiddle, "Middle", ref AlertMessage);
            VerifyPanelBotConfig(this.panelBotEnd, "End", ref AlertMessage);

            return AlertMessage == "";
            // if(this.txtBotName )
        }
        private void SaveBot(String fileName)
        {

            //    AI.MimiMaxBotProto MinimaxBot = Utility.SerializeUtility.DeserializeMinimaxBot(fileName);

            this.panelBotOpen.panelposition.UpdateValuefromTextbox();
            this.panelBotMiddle.panelposition.UpdateValuefromTextbox();
            this.panelBotEnd.panelposition.UpdateValuefromTextbox();

            MinimaxBot.OpenGamePostionScore = this.panelBotOpen.arrValue;
            MinimaxBot.ScoreNumberMoveAtBegingGame = int.Parse(this.panelBotOpen.numScoreMobilize.Text);
            MinimaxBot.DepthLevelAtBeginGame = int.Parse(this.panelBotOpen.numBotDepth.Text);

            MinimaxBot.MidGamePostionScore = this.panelBotMiddle.arrValue;
            MinimaxBot.ScoreNumberMoveAtMiddleGame = int.Parse(this.panelBotMiddle.numScoreMobilize.Text);
            MinimaxBot.DepthLevelAtMiddleGame = int.Parse(this.panelBotMiddle.numBotDepth.Text);

            MinimaxBot.EndGamePostionScore = this.panelBotEnd.arrValue;
            MinimaxBot.ScoreNumberMoveAtEndGame = int.Parse(this.panelBotEnd.numScoreMobilize.Text);
            MinimaxBot.DepthLevelAtEndGame = int.Parse(this.panelBotEnd.numBotDepth.Text);


            MinimaxBot.StableDiskScore = (int)this.numStableDiskScore.Value;
            MinimaxBot.TimeLimitPermove = (int)this.numTimeLimitPerMove.Value;
            MinimaxBot.ForcePassSocre = (int)this.numericForcePassScore.Value;

            MinimaxBot.IsUseScoreFromPosition = this.chkPositionScore.Checked;

            String base64Image = "";
            if (this.pictureboxBotPhoto.Tag != null)
            {
                base64Image = this.pictureboxBotPhoto.Tag.ToString();
            }

            MinimaxBot.BotName = this.txtBotName.Text;
            MinimaxBot.Base64Image = base64Image;

            Utility.SerializeUtility.SerializeMiniMaxBot(MinimaxBot, fileName);
            Global.CurrentSettings.LastBotSavedFileName = fileName;
            Global.SaveSettings();


        }

        private void ShowPictureByFileName(String fileName)
        {

            if (String.IsNullOrEmpty(fileName) ||
                !System.IO.File.Exists(fileName))
            {
                this.pictureboxBotPhoto.Image = null;
                this.pictureboxBotPhoto.Tag = "";
                return;
            }

            ShowPictureByBase64Image(Utility.FileUtility.GetBase64FromImageFile(fileName));

        }
        private void ShowPictureByBase64Image(String base64Image)
        {
            this.pictureboxBotPhoto.Image = Utility.FileUtility.GetImageFromBase64(base64Image);
            this.pictureboxBotPhoto.Tag = base64Image;
        }
        private void toolStripMenuSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.OpenningBotFileName))
            {
                SaveAsBot();
                ShowCurrentBotFileName();
                return;
            }

            SaveCurrentBot();
            ShowCurrentBotFileName();


        }
        private void SaveCurrentBot()
        {
            try
            {
                String AlertMessage = "";
                if (!VerifyBot(ref AlertMessage))
                {

                    UI.Dialog.ShowMessage(AlertMessage);
                    return;
                }
                SaveBot(this.OpenningBotFileName);
                AddRecentlyFile(this.OpenningBotFileName);
                ShowCurrentBotFileName();
                //No need to inform user, since we alrady Showcurrent bot file name 
                //UI.Dialog.ShowMessage(String.Format("{0} has been saved", this.OpenningBotFileName));
            }

            catch (Exception ex)
            {
                //Write log
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("Having a problem to save bot. Please contact an Administrator.");

            }
        }
        private void SaveAsBot()
        {
            String AlertMessage = "";
            if (!VerifyBot(ref AlertMessage))
            {

                UI.Dialog.ShowMessage(AlertMessage);
                return;
            }


            string fileName = UI.Dialog.ChooseBotSavePath(this.txtBotName.Text);
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            try
            {

                if (System.IO.File.Exists(fileName))
                {

                    if (UI.Dialog.ShowConfirm(String.Format("{0} alredy exits, would you like to overwrite it?", fileName)) != DialogResult.OK)
                    {
                        return;
                    }
                    DeleteBot(fileName);
                }
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage(String.Format("We are facing the problem to delete {0} ", fileName));

            }
            try
            {
                SaveBot(fileName);
                AddRecentlyFile(fileName);
                this.OpenningBotFileName = fileName;
                //No need to inform user in case of successful saved

            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage(String.Format("We are facing the problem to save {0} ", fileName));

            }


        }
        private void toolStripMenuSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsBot();
            this.ShowCurrentBotFileName();
        }
        private void ShowCurrentBotFileName()
        {
            if (!String.IsNullOrEmpty(this.OpenningBotFileName))
            {
                this.Text = new System.IO.FileInfo(this.OpenningBotFileName).Name;
            }
            else
            {
                this.Text = "*Untitled";
            }
        }
        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {

            string fileName = UI.Dialog.ChoosePhoto();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            ShowPictureByFileName(fileName);
            this.txtBotName.Text = Path.GetFileNameWithoutExtension(fileName);
        }

        private void chkPositionScore_CheckedChanged(object sender, EventArgs e)
        {
            EnablePositionScore(this.chkPositionScore.Checked);
        }
    }
}
