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
    public partial class FormBoardEditor : Form
    {
        public FormBoardEditor()
        {
            InitializeComponent();
        }
        UI.PictureBoxBoard pictureBoard = null;
        // Game game = null;
        AI.Board board = null;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Boolean IsChek = chk.Checked;

            chk.Checked = IsChek;
        }
        const int Black = -1;
        const int Blank = 0;
        const int White = 1;
        public AI.BoardValue boardValueForOpenning = null;
        private void FormTestBoardPictureBox_Load(object sender, EventArgs e)
        {


            Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);


            Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(Global.CurrentTheme);


            themeUtil.SetLabelColor(this.lblNumberofBlackDisk,
                this.lblNumberofWhiteDisk,
                this.lblSideToMove)
                  .SetButtonColor(
                this.btnSwap,
                this.btnClearBoard)
                   .SetGroupboxColor(grpChooseCellType,
                   grpNumberDisk)
                   .SetMenu(this.menuStrip1)
                    .SetForm(this);

            Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);


            if (boardValueForOpenning != null)
            {
                OpenBoard(boardValueForOpenning);
                return;
            }


            New();
            btnBlack_Click(null, null);
            toolStripMenuItemRecentlyEmpty.Click += ToolStripMenuItemRecentlyEmpty_Click;
            RenderRecentlyBoardOpenFileMenu();


        }
        private void ToolStripMenuItemRecentlyEmpty_Click(object sender, EventArgs e)
        {
            Global.BoardRecentlyFile.Clear();
            Global.SaveBoardRecentlyFile();
            RenderRecentlyBoardOpenFileMenu();
        }

        Dictionary<int, ToolStripMenuItem> dicRecentlyOpen = new Dictionary<int, ToolStripMenuItem>();

        private void RenderRecentlyBoardOpenFileMenu()
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
                if (Global.BoardRecentlyFile.ListRecentyFile[i].Trim() == "")
                {
                    break;
                }
                dicRecentlyOpen[i].Visible = true;
                dicRecentlyOpen[i].Text = (i + 1) + "." + Global.BoardRecentlyFile.ListRecentyFile[i];
                toolStripMenuItemRecentlyLine.Visible = true;
                toolStripMenuItemRecentlyEmpty.Visible = true;
            }


        }

        private void ToolStripMenuItemRecently_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int index = (int)item.Tag;
            String boardPath = Global.BoardRecentlyFile.ListRecentyFile[index];
            LoadBoardFromFile(boardPath);
            //MessageBox.Show(botPath);
            // LoadBotFromFile(botPath, true);

        }
        private void btnBlack_Click(object sender, EventArgs e)
        {
            // Board.BoardPhaseEnum
            this.pictureBoard.SelectedCellTypeEditMode = Black;
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            this.pictureBoard.SelectedCellTypeEditMode = White;
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            this.pictureBoard.SelectedCellTypeEditMode = Blank;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsUseTempBoard = false;
            this.CurrentBoardFileName = "";
            this.Close();
        }
        private void New()
        {
            //game = new Game();


            board = new AI.Board();
            this.board.CurrentTurn = Board.PlayerColor.Black;
            this.CurrentBoardFileName = "";
            SetUpBoardUI();
        }
        private void SetUpBoardUI()
        {
            if (this.Controls.Contains(pictureBoard))
            {
                this.Controls.Remove(pictureBoard);
            }
            pictureBoard = new UI.PictureBoxBoard();
            pictureBoard.InitialEditBoard(board);
            pictureBoard.Top = this.menuStrip1.Height;
            pictureBoard.CellClick += UIboard_CellClick;
            this.btnWhite.BackColor = Color.White;
            this.btnBlack.BackColor = Color.Black;
            this.btnBlank.BackColor = Color.FromArgb(255, 0, 144, 103);


            this.Controls.Add(pictureBoard);
            this.Height = pictureBoard.Top + pictureBoard.Height + 40;


            this.comboSideToMove.SelectedIndex = 0;
            if (this.board.CurrentTurn == Board.PlayerColor.White)
            {
                this.comboSideToMove.SelectedIndex = 1;
            }
            ShowNumberofDisk();
            DisplayCurrentFileName();
        }
        private void ShowNumberofDisk()
        {

            this.lblNumberofBlackDisk.Text = this.board.NumberofBlackDisk().ToString();
            this.lblNumberofWhiteDisk.Text = this.board.NumberofWhiteDisk().ToString();
        }
        private void UIboard_CellClick(object sender, Position position)
        {
            ShowNumberofDisk();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.New();

        }
        private string WindowsName = "Board Editor ";
        private void DisplayCurrentFileName()
        {
            this.Text = WindowsName + this.CurrentBoardFileName;
        }
        private void OpenBoard(AI.BoardValue boardValue)
        {
            this.board = new AI.Board(boardValue);
            this.Text = "";
            SetUpBoardUI();

        }
        private void LoadBoardFromFile(String fileName)
        {
            try
            {
                this.CurrentBoardFileName = fileName;
                AI.BoardValue boardValue = Utility.SerializeUtility.DeserializeBoardValue(this.CurrentBoardFileName);
                OpenBoard(boardValue);

            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("There is a problem to load the board from " + fileName);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = UI.Dialog.ChooseBoardOpenPath();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            LoadBoardFromFile(fileName);
            this.AddRecentlyFile(fileName);
            //game = new Game();
            // game.board 
        }
        public string CurrentBoardFileName { get; private set; } = "";
        AI.BoardValue boadValue = null;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boadValue = board.GetBoardValue();

            if (String.IsNullOrWhiteSpace(CurrentBoardFileName))
            {
                SaveAsBoard();
                return;
            }

            SaveCurrentBoard();

            Utility.SerializeUtility.SerializeBoardValue(boadValue, CurrentBoardFileName);

        }
        private void AddRecentlyFile(String fileName)
        {
            try
            {
                Global.BoardRecentlyFile.InsertNewPath(fileName);
                Global.SaveBoardRecentlyFile();
                this.RenderRecentlyBoardOpenFileMenu();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
            }

        }
        private Boolean VerifyBoard(ref String AlertMessage)
        {

            AlertMessage = "";
            if (this.board.generateMoves(this.board.CurrentTurn).Count == 0 &&
                this.board.generateMoves(this.board.OpponentTurn).Count == 0)
            {
                AlertMessage = "There is no valid cell to put as disk for either black/white disk";
            }
            this.boadValue = this.board.GetBoardValue();

            return AlertMessage == "";
            // if(this.txtBotName )
        }
        private void SaveCurrentBoard()
        {
            try
            {
                String AlertMessage = "";
                if (!VerifyBoard(ref AlertMessage))
                {

                    UI.Dialog.ShowMessage(AlertMessage);
                    return;
                }
                SaveBoard(this.CurrentBoardFileName);
                AddRecentlyFile(this.CurrentBoardFileName);
                //No need to inform user

            }
            catch (Exception ex)
            {
                //Write log
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("Having a problem to save Board. Please contact an Administrator.");

            }
        }

        private void SaveAsBoard()
        {
            String AlertMessage = "";
            if (!VerifyBoard(ref AlertMessage))
            {

                UI.Dialog.ShowMessage(AlertMessage);
                return;
            }



            string fileName = UI.Dialog.ChooseBoardSavePath();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            try
            {

                if (System.IO.File.Exists(fileName))
                {

                    DeleteBoard(fileName);
                }
            }
            catch (Exception ex)
            {
                UI.Dialog.ShowErrorMessage(String.Format("We are facing the problem to delete {0} ", fileName));


            }
            try
            {
                SaveBoard(fileName);
                AddRecentlyFile(fileName);
                //No need to inform user

            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);

                UI.Dialog.ShowErrorMessage(String.Format("We facing the problem to save {0} ", fileName));
            }


        }

        private Boolean DeleteBoard(String fileName)
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
        private void SaveBoard(String fileName)
        {
            Utility.SerializeUtility.SerializeBoardValue(boadValue, fileName);

        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsBoard();

        }

        private void btnClearBoard_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {
                    this.board.boardMatrix[i, j] = 0;
                }
            }
            this.pictureBoard.UpdateRender();
            ShowNumberofDisk();
        }

        private void comboSideToMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboSideToMove.SelectedIndex != 0)
            {
                this.board.CurrentTurn = AI.Board.PlayerColor.White;
                return;
            }
            this.board.CurrentTurn = AI.Board.PlayerColor.Black;
        }
        //public KReversi.AI.BoardValue SelectedBoardValue { get; private set; }
        public Boolean IsUseTempBoard { get; private set; } = false;
        private void ClearOldTempFile()
        {
            try
            {
                string[] fileName = System.IO.Directory.GetFiles(Utility.FileUtility.TempPath);
                int i;
                for (i = 0; i < fileName.Length; i++)
                {
                    try
                    {
                        System.IO.File.Delete(fileName[i]);
                        SimpleLog.WriteLog("Has deleted temp file ::" + fileName[i]);
                    }
                    catch (Exception ex)
                    {
                        SimpleLog.WriteLog(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
            }
        }
        private void closeBoardEditorAndPlayFromThisBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String AlertMessage = "";
                if (!VerifyBoard(ref AlertMessage))
                {

                    UI.Dialog.ShowMessage(AlertMessage);
                    return;
                }
                ClearOldTempFile();
                String tempFileName = Utility.FileUtility.TempPath + Utility.Utility.NowAsString() + ".brd";
                SaveBoard(tempFileName);
                this.CurrentBoardFileName = tempFileName;
                IsUseTempBoard = true;

                this.Close();
            }
            catch (Exception ex)
            {
                //Write log
                SimpleLog.WriteLog(ex);

                UI.Dialog.ShowErrorMessage("Having a problem to save Board. Please contact an Administrator.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    switch (this.board.boardMatrix[i, j])
                    {
                        case (int)Board.PlayerColor.Black:
                            this.board.boardMatrix[i, j] = (int)Board.PlayerColor.White;
                            break;
                        case (int)Board.PlayerColor.White:
                            this.board.boardMatrix[i, j] = (int)Board.PlayerColor.Black;
                            break;


                    }
                }
            }
            this.pictureBoard.UpdateRender();
            ShowNumberofDisk();
        }
    }
}
