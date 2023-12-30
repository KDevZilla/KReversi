using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KReversi.AI;
namespace KReversi
{
    public partial class FormNewGame : Form
    {
        public FormNewGame()
        {
            InitializeComponent();
        }
        UI.PictureBoxBoard PicBoard = null;
        Board Selectedboard = new Board();
        private void SetUpBoardUI()
        {
            // Selectedboard = new Board();
            if (this.panelPicboard.Contains(PicBoard))
            {
                this.panelPicboard.Controls.Remove(PicBoard);
            }
            PicBoard = new UI.PictureBoxBoard()
            {
                Top = 0,
                IsSmallBoard = true,
                IsHideLegent = true
            };


            PicBoard.InitialEditBoard(Selectedboard);
            this.panelPicboard.Controls.Add(PicBoard);


            this.panelPicboard.Controls.Add(PicBoard);
            this.panelPicboard.Height = PicBoard.Top + PicBoard.Height;
            this.panelPicboard.Width = PicBoard.Width;
            this.panelPicboard.BorderStyle = BorderStyle.None;

            Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(Global.CurrentTheme);
            themeUtil.SetGroupboxColor(this.groupBox1, this.groupBox2)
                    .SetButtonColor(btnOK, btnCancel)
                    .SetComboboxColor(cboMap, cboPlayer1, cboPlayer2)
                    .SetForm(this);


            Utility.UI.MakeComboBoxOwnerDrawBackColor(cboMap, cboPlayer1, cboPlayer2);
            Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);

        }
        private void LoadBoardToCombo()
        {
            List<string> listBoardName = Utility.FileUtility.GetAllBoardName();
            this.cboMap.Items.Clear();
            this.cboMap.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMap.Items.Add("Standard");
            listBoardName.ForEach(x => this.cboMap.Items.Add(x));
            this.cboMap.SelectedIndexChanged -= CboMap_SelectedIndexChanged;
            this.cboMap.SelectedIndexChanged += CboMap_SelectedIndexChanged;
            this.cboMap.SelectedIndex = 0;
        }
        Dictionary<String, String> DicBotFile = new Dictionary<string, string>();
        private void LoadPlayerToComboBox()
        {
            string[] botPath = System.IO.Directory.GetFiles(Utility.FileUtility.BotPath, "*.bot");
            int i;

            this.cboPlayer1.Items.Add("Human");
            this.cboPlayer2.Items.Add("Human");

            for (i = 0; i < botPath.Length; i++)
            {
                String fileName = new System.IO.FileInfo(botPath[i]).Name;
                fileName = fileName.Substring(0, fileName.Length - 4);
                this.cboPlayer1.Items.Add(fileName);
                this.cboPlayer2.Items.Add(fileName);
                DicBotFile.Add(fileName, botPath[i]);
            }
            this.cboPlayer1.Tag = "1";
            this.cboPlayer2.Tag = "2";
            this.cboPlayer1.SelectedIndexChanged -= CboPlayer_SelectedIndexChanged;
            this.cboPlayer2.SelectedIndexChanged -= CboPlayer_SelectedIndexChanged;

            this.cboPlayer1.SelectedIndexChanged += CboPlayer_SelectedIndexChanged;
            this.cboPlayer2.SelectedIndexChanged += CboPlayer_SelectedIndexChanged;
            this.cboPlayer1.SelectedIndex = 0;
            this.cboPlayer2.SelectedIndex = 0;

        }
        private Dictionary<String, AI.MiniMaxBotProto> dicBot = new Dictionary<string, MiniMaxBotProto>();
        private AI.MiniMaxBotProto GetBot(String botName)
        {
            if (dicBot.ContainsKey(botName))
            {
                return dicBot[botName];
            }
            string botFileName = Utility.FileUtility.GetBotFileNameFromBotName(botName);

            AI.MiniMaxBotProto MinimaxBot = Utility.SerializeUtility.DeserializeMinimaxBot(botFileName);
            dicBot.Add(botName, MinimaxBot);
            return MinimaxBot;
        }
        private void CboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {


            ComboBox cbo = (ComboBox)sender;

            Boolean IsThisforPlayer1 = true;
            String BotName = "";
            String Base64Image = "";
            if (cbo.Tag.ToString() == "2")
            {
                IsThisforPlayer1 = false;
            }


            if (cbo.SelectedIndex == 0)
            {
                // IsSelectPlayer = true;
                if (IsThisforPlayer1)
                {
                    // BotImageFileName = Global.Player1AsHumanPhotoPath;
                    Base64Image = Global.CurrentSettings.Player1AsHumanImagrBase64; // Global.Player1AsHumanPhotoPath 


                }
                else
                {
                    // BotImageFileName = Global.Player2AsHumanPhotoPath;
                    Base64Image = Global.CurrentSettings.Player2AsHumanImagrBase64;
                }
            }
            else
            {
                BotName = cbo.Items[cbo.SelectedIndex].ToString();

                Base64Image = GetBot(BotName).Base64Image;
            }

            PictureBox pictureShow = this.picPlayer1;

            if (!IsThisforPlayer1)
            {
                pictureShow = this.picPlayer2;
                //SelectedPlayer2BotFileName = BotFilePath;
                SelectedPlayer2BotName = BotName;

            }
            else
            {
                //SelectedPlayer1BotFileName = BotFilePath;
                SelectedPlayer1BotName = BotName;
            }
            ShowPlayerPicture(Base64Image, pictureShow);
        }

        private void ShowPlayerPicture(string Base64Image, PictureBox picturebox)
        {

            picturebox.Image = Utility.FileUtility.GetImageFromBase64(Base64Image);
        }

        private void CboMap_SelectedIndexChanged(object sender, EventArgs e)
        {

            AI.BoardValue boardValue = new Board().GetBoardValue();

            if (this.cboMap.SelectedIndex > 0)
            {
                String MapName = this.cboMap.Items[this.cboMap.SelectedIndex].ToString();
                String fileName = Utility.FileUtility.BoardPath + MapName + ".brd";
                SelectedBoardFileName = fileName;
                boardValue = Utility.SerializeUtility.DeserializeBoardValue(fileName);

            }
            else
            {
                if (IsInitalize)
                {
                    SelectedBoardFileName = "";
                }
            }

            Selectedboard = new Board(boardValue);
            SetUpBoardUI();

        }
        public string SelectedBoardFileName { get; set; }

        public string SelectedPlayer1BotName { get; set; }
        public string SelectedPlayer2BotName { get; set; }
        public string SelectedPlayer1BotNameFromFormGame { get; set; }
        public string SelectedPlayer2BotNameFromFormGame { get; set; }

        public Boolean IsBeginGame { get; set; } = false;
        private Boolean IsInitalize { get; set; } = false;
        private void FormNewGame_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.KReversiIcon;
            SetUpBoardUI();
            LoadBoardToCombo();
            LoadPlayerToComboBox();
            IsInitalize = true;

            SelectBotIfItExist();
            SelectBoardIfItExist();

        }
        private void SelectBoardIfItExist()
        {
            if (this.SelectedBoardFileName == null ||
                this.SelectedBoardFileName.Trim() == "")
            {
                return;
            }
            if (!System.IO.File.Exists(this.SelectedBoardFileName))
            {
                return;
            }

            int i;
            for (i = 1; i < this.cboMap.Items.Count; i++)
            {
                String mapNameinCbo = cboMap.Items[i].ToString().Trim().ToLower();
                System.IO.FileInfo finInfo = new System.IO.FileInfo(this.SelectedBoardFileName);
                String mapFileName = finInfo.Name.Replace(".brd", "").ToLower();
                if (mapNameinCbo.Equals(mapFileName))
                {
                    this.cboMap.SelectedIndex = i;
                    return;
                }
            }
        }
        private void SelectBotIfItExist()
        {
            int i;
            if (this.SelectedPlayer1BotNameFromFormGame != null)
            {
                for (i = 1; i < this.cboPlayer1.Items.Count; i++)
                {
                    if (cboPlayer1.Items[i].ToString().Trim().ToLower() ==
                        this.SelectedPlayer1BotNameFromFormGame.Trim().ToLower())
                    {
                        cboPlayer1.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (this.SelectedPlayer2BotNameFromFormGame != null)
            {
                for (i = 1; i < this.cboPlayer2.Items.Count; i++)
                {
                    if (cboPlayer2.Items[i].ToString().Trim().ToLower() ==
                        this.SelectedPlayer2BotNameFromFormGame.Trim().ToLower())
                    {
                        cboPlayer2.SelectedIndex = i;
                        break;
                    }
                }
            }

        }
        //public string SelectedBoardFileName { get; private set; };

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
    }
}
