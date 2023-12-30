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
using KReversi.Game;
using KReversi.Utility;
namespace KReversi
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }
        UI.PictureBoxBoard pictureboxBoard = null;
        KReversiGame game = null;
        // AI.Board board = null;
        UI.IUI UIBoard = null;
        public Board CreateStandardOthelloBoard()
        {
            Board board = new Board();
            board.SetCell(3, 4, Board.CellValue.Black);
            board.SetCell(4, 3, Board.CellValue.Black);
            board.SetCell(3, 3, Board.CellValue.White);
            board.SetCell(4, 4, Board.CellValue.White);
            board.CurrentTurn = Board.PlayerColor.Black;
            return board;
        }
        private int WidthFullMode = 884;
        public void CompactMode(bool IsEnable)
        {
            if (IsEnable)
            {
                this.Width = this.pictureboxBoard.Width + this.pictureboxBoard.Left + 14;
            }
            else
            {
                this.Width = WidthFullMode;
            }
        }
        private bool HasSetThemeTheFirstTimeYet = false;
        private void FormGame_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.KReversiIcon;

            //SetTheme();
            this.Hide();
            if (!ChooseGameMode())
            {
                Application.Exit();
                //   return;
            }

            CurrentGameFileName = "";
            panelInfo.Visible = false;
            CreateNewGame();
            panelInfo.Visible = true;

            this.SetCompaceMode();
            UI.Dialog.fParent = this;

            toolStripMenuItemRecentlyEmpty.Click += ToolStripMenuItemRecentlyEmpty_Click;
            RenderRecentlyGameOpenFileMenu();
        }
        private void ToolStripMenuItemRecentlyEmpty_Click(object sender, EventArgs e)
        {
            Global.GameRecentlyFile.Clear();
            Global.SaveGameRecentlyFile();
            RenderRecentlyGameOpenFileMenu();
        }

        Dictionary<int, ToolStripMenuItem> dicRecentlyOpen = new Dictionary<int, ToolStripMenuItem>();

        private void RenderRecentlyGameOpenFileMenu()
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
                if (Global.GameRecentlyFile.ListRecentyFile[i].Trim() == "")
                {
                    break;
                }
                dicRecentlyOpen[i].Visible = true;
                dicRecentlyOpen[i].Text = (i + 1) + "." + Global.GameRecentlyFile.ListRecentyFile[i];
                toolStripMenuItemRecentlyLine.Visible = true;
                toolStripMenuItemRecentlyEmpty.Visible = true;
            }


        }

        private void ToolStripMenuItemRecently_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int index = (int)item.Tag;
            String GameFilePath = Global.GameRecentlyFile.ListRecentyFile[index];
            //MessageBox.Show(botPath);
            //LoadBotFromFile(botPath, true);
            try
            {
                this.CurrentGameFileName = GameFilePath;
                this.CurrentBoardFileName = "";
                CreateNewGame();
            }catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("There is a problem when program try to load " + this.CurrentGameFileName);
            }

        }
        private void SetCompaceMode()
        {
            this.CompactMode(Global.CurrentSettings.IsCompaceMode);

        }
        private void SetTheme()
        {
            SetTheme(Global.CurrentTheme);
        }
        public void SetTheme(UI.Theme theme)
        {
            // this.Visible = false;


            Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(theme);

            themeUtil.SetLabelColor(theme, lblNumberofBlackDisk,
                                            lblNumberofWhiteDisk,
                                            lblPlayer1Name,
                                            lblPlayer2Name)
                    .SetButtonColor(theme, btnFirst,
                        btnNext,
                        btnPrevious,
                        btnLast)
                    .SetMenu(this.menuStrip1)
                    .SetForm(this);

            this.panelNavigator.BackColor = theme.FormBackColor;
            this.tableLayoutPanel1.BackColor = theme.InputBoxBackColor;
            ((UI.ReverseUI)this.game.UIBoard).LinkHighLightLinkColor = theme.LinkLabelActiveForeColor;
            ((UI.ReverseUI)this.game.UIBoard).LinkForeColor = theme.LinkLabelForeColor;
            this.game.UIBoard.RenderHistory();


            if (!HasSetThemeTheFirstTimeYet)
            {
                this.Visible = false;
                Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);
                this.Visible = true;
                HasSetThemeTheFirstTimeYet = true;
            }
            else
            {
                Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);
            }


        }


        private void PrepareGame()
        {


            SetUpBoardUI();
            SetTheme();
            this.tableLayoutPanel1.Enabled = true;

            this.picPlayer1.Image = Utility.FileUtility.GetImageFromBase64(Global.Player1Base64);
            this.picPlayer2.Image = Utility.FileUtility.GetImageFromBase64(Global.Player2Base64);

            this.lblPlayer1Name.Text = Global.Player1Name;
            this.lblPlayer2Name.Text = Global.Player2Name;

            this.Show();
            Application.DoEvents();
            game.Begin();

        }


        private void SetUpBoardUI()
        {
            if (this.Controls.Contains(pictureboxBoard))
            {
                this.Controls.Remove(pictureboxBoard);
            }
            pictureboxBoard = new UI.PictureBoxBoard();
            pictureboxBoard.Top = this.menuStrip1.Height + 1;


            this.Controls.Add(pictureboxBoard);
            if (UIBoard != null)
            {
                UIBoard.ReleaseUIResource();
                UIBoard = null;
            }
            Application.DoEvents();
            this.panel1.Visible = false;

            UIBoard = new UI.ReverseUI(
  this.pictureboxBoard,
  this.lblNumberofWhiteDisk,
  this.lblNumberofBlackDisk,
  this.lblPlayer1Border,
  this.lblPlayer2Border,
  this.btnFirst,
  this.btnPrevious,
  this.btnNext,
  this.btnLast,
  this.btnContinuePlayingGamefromHere,
  this.tableLayoutPanel1);

            UIBoard.SetGame(game);
            UIBoard.Initial();
            this.panel1.Visible = true;

            this.Height = pictureboxBoard.Top + pictureboxBoard.Height + 35;

        }
        /*
        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {


        }
        */

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PauseGame();
                LoadGame();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("There is an error");

            }
        }



        private void saveGameAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PauseGame();
                SaveGameAs();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("There is an error");

            }

        }
        private string Player1BotName = "";
        private string Player2BotName = "";

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CreateNewGame();
            PauseGame();
            if (!ChooseGameMode())
            {
                UnPauseGame();
                return;
            }

            CurrentGameFileName = "";
            //   CurrentBoardFileName = "";

            CreateNewGame();
        }

        KReversiGame.PlayerMode Mode
        {
            get;
            set;
        } = KReversiGame.PlayerMode.FirstHuman_SecondHuman;

        MiniMaxBotProto BotPlayer1 = null;
        MiniMaxBotProto BotPlayer2 = null;
        String CurrentBoardFileName = "";
        private Boolean ChooseGameMode()
        {
            FormNewGame f = new FormNewGame();

            f.SelectedBoardFileName = Global.CurrentSettings.LastMapFileName;
            f.SelectedPlayer1BotNameFromFormGame = Global.CurrentSettings.LastPlayer1Name;
            f.SelectedPlayer2BotNameFromFormGame = Global.CurrentSettings.LastPlayer2Name;

            f.ShowDialog();

            if (f.DialogResult != DialogResult.OK)
            {
                return false;
            }


            this.CurrentBoardFileName = f.SelectedBoardFileName;
            Player1BotName = f.SelectedPlayer1BotName;
            Player2BotName = f.SelectedPlayer2BotName;

            Global.CurrentSettings.LastMapFileName = this.CurrentBoardFileName;
            Global.CurrentSettings.LastPlayer1Name = Player1BotName;
            Global.CurrentSettings.LastPlayer2Name = Player2BotName;
            BotPlayer1 = null;
            BotPlayer2 = null;
            Mode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            if (!String.IsNullOrEmpty(Player1BotName))
            {
                Mode = KReversiGame.PlayerMode.FirstBot_SecondHuman;
                BotPlayer1 = MiniMaxBotProto.CreateBot(FileUtility.GetBotFileNameFromBotName(Player1BotName));
                if (!String.IsNullOrEmpty(Player2BotName))
                {
                    Mode = KReversiGame.PlayerMode.FirstBot_SecondBot;
                    BotPlayer2 = MiniMaxBotProto.CreateBot(FileUtility.GetBotFileNameFromBotName(Player2BotName));
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(Player2BotName))
                {
                    Mode = KReversiGame.PlayerMode.FirstHuman_SecondBot;
                    BotPlayer2 = MiniMaxBotProto.CreateBot(FileUtility.GetBotFileNameFromBotName(Player2BotName));
                }
            }
            if (String.IsNullOrEmpty(Player1BotName))
            {
                Global.Player1Name = Global.CurrentSettings.Player1AsHumanName;
                Global.Player1Base64 = Global.CurrentSettings.Player1AsHumanImagrBase64;

            }
            else
            {
                Global.Player1Name = BotPlayer1.BotName;
                Global.Player1Base64 = BotPlayer1.Base64Image;

            }

            if (String.IsNullOrEmpty(Player2BotName))
            {
                Global.Player2Name = Global.CurrentSettings.Player2AsHumanName;
                Global.Player2Base64 = Global.CurrentSettings.Player2AsHumanImagrBase64;
            }
            else
            {
                Global.Player2Name = BotPlayer2.BotName;
                Global.Player2Base64 = BotPlayer2.Base64Image;

            }
            Global.SaveSettings();
            Application.DoEvents();
            return true;
        }
        private void CreateNewGame()
        {
            if (game != null)
            {
                game.ReleaseUI();

            }
            game = GameBuilder.Builder.BeginBuild
                     .GameMode(Mode)
                     .BotPlayer1Is(BotPlayer1)
                     .BotPlayer2Is(BotPlayer2)
                     .Player1NameIs(Global.Player1Name)
                     .Player2NameIs(Global.Player2Name)
                     .AllowRandomDecision(Global.CurrentSettings.IsAllowRandomDecision)
                     .UsingAlphaBeta(Global.CurrentSettings.IsUsingAlphaBeta)
                     .KeepLastDecisionTree(Global.CurrentSettings.IsKeepLastDecisionTree)
                     .OpenWithBoardFile(CurrentBoardFileName)
                     .OpenWithGameFile(CurrentGameFileName)
                     .FinishBuild();

            // We need a timer to delay a little bit to prevent
            // UI to freeze
            Timer timerGameStart = new Timer();
            timerGameStart.Tick += TimerGameStart_Tick;
            timerGameStart.Interval = 120;
            timerGameStart.Enabled = true;

        }
        private void TimerGameStart_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            PrepareGame();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                PauseGame();
                OpenBoard();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage("There is an error");

            }

        }

        private void setupBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGame();
            BoardEditor();
        }

        private void botEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGame();
            BotEditor();
        }
        private string CurrentGameFileName = "";
        private void LoadGame()
        {
            string fileName = UI.Dialog.ChooseGameOpenPath();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            this.CurrentGameFileName = fileName;

            this.CurrentBoardFileName = "";
            AddRecentlyFile(this.CurrentGameFileName);
            CreateNewGame();

        }
        private void AddRecentlyFile(String fileName)
        {
            try
            {
                Global.GameRecentlyFile.InsertNewPath(fileName);
                Global.SaveGameRecentlyFile();
                RenderRecentlyGameOpenFileMenu();
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                //It is not a bigdeal so we will not interrupt a use
            }
        }
        private void SaveGame(String fileName)
        {
            GameValue gamevalue = this.game.GetGameValue();
            Utility.SerializeUtility.SerializeGameValue(gamevalue, fileName);

        }
        private void SaveGameAs()
        {
            string fileName = "";
            try
            {
                fileName = UI.Dialog.ChooseGameSavePath("Untitled");
                if (String.IsNullOrEmpty(fileName))
                {
                    return;
                }
                SaveGame(fileName);
                UI.Dialog.ShowMessage(String.Format("{0} has been saved.", fileName));

            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);

                UI.Dialog.ShowErrorMessage(String.Format("We facing the problem to save {0} ", fileName));

            }
        }

        private void OpenBoard()
        {
            string fileName = UI.Dialog.ChooseBoardOpenPath();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            this.CurrentBoardFileName = fileName;
            this.CurrentGameFileName = "";
            CreateNewGame();

        }
        private void BoardEditor(AI.BoardValue boardValue)
        {
            FormBoardEditor f = new FormBoardEditor();
            f.boardValueForOpenning = boardValue;
            f.StartPosition = FormStartPosition.CenterParent;
            this.Visible = false;
            f.ShowDialog();
            if (f.IsUseTempBoard)
            {

                this.CurrentBoardFileName = f.CurrentBoardFileName;
                CreateNewGame();

            }
            this.Visible = true;
        }
        private void BoardEditor()
        {
            BoardEditor(null);

        }
        private void BotEditor()
        {
            FormBotCreator f = new FormBotCreator();
            f.StartPosition = FormStartPosition.CenterParent;
            this.Visible = false;
            f.ShowDialog(this);
            this.Visible = true;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();

        }

        private void btnContinuePlayingGamefromHere_Click(object sender, EventArgs e)
        {

        }

        private void saveCurrentBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGame();

            BoardEditor(game.board.GetBoardValue());

        }

        private void testNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            game = GameBuilder.Builder.BeginBuild
                .GameMode(KReversiGame.PlayerMode.FirstBot_SecondBot)
                .BotPlayer1Is(new BasicBotV2())
                .BotPlayer2Is(MiniMaxBotProto.CreateBot())
                .FinishBuild();



            SetUpBoardUI();
            this.tableLayoutPanel1.Enabled = true;

            game.Begin();

        }

        private void copyHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            StringBuilder strB = new StringBuilder();

            String template = @"game.HumanPlayer!iPlayer!MoveDecision(new Position(!iRow!, !iCol!), out CanMove);" + Environment.NewLine +
                            "IsBoardTheSame =  BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);" + Environment.NewLine +
                            "Assert.IsTrue(CanMove);" + Environment.NewLine +
                            "Assert.IsTrue(game.boardHistory.HistoryBoards.Count == !iLoop!);" + Environment.NewLine +
                            "Assert.IsTrue(game.boardHistory.IndexMove == !IndexMove!);" + Environment.NewLine +
                            "Assert.IsTrue(IsBoardTheSame);" + Environment.NewLine;
            int iCountPlayer1 = 0;
            int iCountPlayer2 = 0;
            for (i = 1; i < this.game.boardHistory.HistoryPosition.Count; i++)
            {
                String Player = "";

                Board.PlayerColor Color = this.game.boardHistory.HistoryTurn[i];
                if (Color == Board.PlayerColor.Black)
                {
                    if (Player == "1")
                    {
                        strB.Append("//Player 1 Pass case").Append(Environment.NewLine);
                    }
                    Player = "1";
                }
                else
                {
                    if (Player == "2")
                    {
                        strB.Append("//Player 2 Pass case").Append(Environment.NewLine);
                    }
                    Player = "2";
                }
                string line = template;
                line = line.Replace("!iPlayer!", Player)
                    .Replace("!iRow!", this.game.boardHistory.HistoryPosition[i].Row.ToString())
                    .Replace("!iCol!", this.game.boardHistory.HistoryPosition[i].Col.ToString())
                    .Replace("!iLoop!", (i + 1).ToString())
                    .Replace("!IndexMove!", i.ToString());
                strB.Append(line)
               .Append(Environment.NewLine);
            }
            Clipboard.SetText(strB.ToString());

        }

        private void lblNumberofBlackDisk_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            game = GameBuilder.Builder.BeginBuild
              .GameMode(KReversiGame.PlayerMode.FirstBot_SecondBot)
              .BotPlayer1Is(new RandomBot())
              .BotPlayer2Is(new RandomBot())
              //.OpenWithBoardFile (BoardFileName )
              .FinishBuild();



            SetUpBoardUI();
            this.tableLayoutPanel1.Enabled = true;

            game.Begin();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PauseGame();
            FormConfigure f = new FormConfigure();
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormGameCaller = this;
            f.ShowDialog();
            this.Visible = false;
            this.SetTheme();
            this.SetCompaceMode();
            this.Visible = true;

        }
        private void UnPauseGame()
        {
            if (game == null)
            {
                return;
            }

            if (game.GameState == KReversiGame.GameStatusEnum.Pause)
            {
                game.UnPause();
            }
        }
        private void PauseGame()
        {
            if (game == null)
            {
                return;
            }

            if (game.GameState == KReversiGame.GameStatusEnum.Playing)
            {
                game.Pause();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UI.Dialog.ShowConfirm("Are you sure you want to exist?") != DialogResult.OK)
            {
                return;
            }
            Application.DoEvents();
            Application.Exit();
            Environment.Exit(0);

        }

        private void showMiniMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // SerializeUtility.SerializeMiniMaxParameterExtend(MiniMax2.MiniMaxForDebug, FileUtility.MiniMaxParameterForDebugFilePath);
            MiniMaxParameterExtend Para = SerializeUtility.DeSerializeMiniMaxParameterExtend(FileUtility.MiniMaxParameterForDebugFilePath);



        }

        private void showMiniMaxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormShowMinimax f = new FormShowMinimax();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);


        }

        private void panelInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
