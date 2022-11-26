using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KReversi.Game;
namespace KReversi.UI
{
    public class ReverseUI : IUI
    {

        private PictureBoxBoard pictureBoxBoard = null;
        private Label lblNumberofWhiteDisk = null;
        private Label lblNumberofBlackDisk = null;
        private TableLayoutPanel tableLayoutPanel = null;
        private Button btnNext = null;
        private Button btnPrevious = null;
        private Button btnLast = null;
        private Button btnFirst = null;
        private Button btnContinuePlaying = null;

        private Label lblPlayer1Border = null;
        private Label lblPlayer2Border = null;

        private KReversiGame game = null;

        public event EventHandler MoveBoardToNextTurnClick;
        public event EventHandler MoveBoardToPreviousTurnClick;
        public event EventHandler MoveBoardToFirstTurnClick;
        public event EventHandler MoveBoardToLastTurnClick;
        public event PictureBoxBoard.PictureBoxCellClick CellClick;
        public event EventInt MoveBoardToSpecificTurnClick;
        public event EventHandler ContinuePlayingClick;

        public ReverseUI(PictureBoxBoard pictureBoxBoard,
            Label lblNumberofWhiteDisk,
            Label lblNumberofBlackDisk,
            Label lblPlayer1Border,
            Label lblPlayer2Border,
            Button btnFirst,
            Button btnPrevious,
            Button btnNext,
            Button btnLast,
            Button btnContinuePlaying,
            TableLayoutPanel tableLayoutPanel
            )
        {

            this.pictureBoxBoard = pictureBoxBoard;
            this.lblNumberofBlackDisk = lblNumberofBlackDisk;
            this.lblNumberofWhiteDisk = lblNumberofWhiteDisk;
            this.lblPlayer1Border = lblPlayer1Border;
            this.lblPlayer2Border = lblPlayer2Border;
            this.btnFirst = btnFirst;
            this.btnPrevious = btnPrevious;
            this.btnNext = btnNext;
            this.btnLast = btnLast;
            this.btnContinuePlaying = btnContinuePlaying;


            this.tableLayoutPanel = tableLayoutPanel;
            this.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            this.btnFirst.Click -= BtnFirst_Click;
            this.btnPrevious.Click -= BtnPrevious_Click;
            this.btnNext.Click -= BtnNext_Click;
            this.btnLast.Click -= BtnLast_Click;
            this.btnContinuePlaying.Click -= BtnContinuePlaying_Click;


            this.btnFirst.Click += BtnFirst_Click;
            this.btnPrevious.Click += BtnPrevious_Click;
            this.btnNext.Click += BtnNext_Click;
            this.btnLast.Click += BtnLast_Click;
            this.btnContinuePlaying.Click += BtnContinuePlaying_Click;
            this.pictureBoxBoard.CellClick += PictureBoxBoard_CellClick;


            //Just hide it, user does not need to click continue playing
            btnContinuePlaying.Visible = false;
            DisableContinuePlayingButton();

        }
        Timer timerProgressBar = new Timer();

        private void HidProgressBar()
        {

            Cursor.Current = Cursors.Default;
        }
        private void ShowProgressBar()
        {

            Cursor.Current = Cursors.WaitCursor;
        }



        public void ReleaseUIResource()
        {
            if (this.btnFirst == null)
            {
                //It is release already;
                return;
            }
            this.btnFirst.Click -= BtnFirst_Click;
            this.btnPrevious.Click -= BtnPrevious_Click;
            this.btnNext.Click -= BtnNext_Click;
            this.btnLast.Click -= BtnLast_Click;
            this.btnContinuePlaying.Click -= BtnContinuePlaying_Click;
            this.pictureBoxBoard.CellClick -= PictureBoxBoard_CellClick;
            int i;
            for (i = 0; i < this.tableLayoutPanel.Controls.Count; i++)
            {
                ((LinkLabel)this.tableLayoutPanel.Controls[i]).LinkClicked -= Link_LinkClicked;
            }


            this.pictureBoxBoard = null;
            this.lblNumberofBlackDisk = null;
            this.lblNumberofWhiteDisk = null;
            this.lblPlayer1Border = null;
            this.lblPlayer2Border = null;
            this.btnFirst = null;
            this.btnPrevious = null;
            this.btnNext = null;
            this.btnLast = null;
            this.btnContinuePlaying = null;
            this.tableLayoutPanel = null;

        }
        private void EnableContinuePlayingButton()
        {

            this.btnContinuePlaying.Visible = true;
        }
        private void DisableContinuePlayingButton()
        {

            this.btnContinuePlaying.Visible = false;
        }

        private void BtnContinuePlaying_Click(object sender, EventArgs e)
        {
            EventHandler handler = this.ContinuePlayingClick;
            handler?.Invoke(this, e);
            DisableContinuePlayingButton();
            RenderBoard();

        }
        public Color LinkForeColor { get; set; } = Color.White;
        public Color LinkLinkColor { get; set; } = Color.White;
        public Color LinkActiveLinkColor { get; set; } = Color.White;
        public Color LinkHighLightLinkColor { get; set; } = Color.FromArgb(200, 200, 200);
        private LinkLabel CreateLinkLabel(String text, int Tag)
        {
            LinkLabel link = new LinkLabel();
            link.Text = text;
            link.LinkBehavior = LinkBehavior.HoverUnderline;
            link.LinkClicked -= Link_LinkClicked;
            link.LinkClicked += Link_LinkClicked;
            link.ForeColor = LinkForeColor;
            link.LinkColor = LinkLinkColor;
            link.ActiveLinkColor = LinkActiveLinkColor;
            link.Tag = Tag;
            return link;
        }
        private void Game_GameBegin(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }
        private void HightLightLinkLabel(int index)
        {
            int i;

            if (index >= this.tableLayoutPanel.Controls.Count)
            {
                return;
            }
            UnActiveLinkLabel();
            LinkLabel link = null;

            if (!dicLinklabel.ContainsKey(index))
            {
                return;
            }
            link = (LinkLabel)dicLinklabel[index];
            link.LinkColor = LinkHighLightLinkColor;// Color.Gray ; //Color.Blue;
            link.Font = new Font(link.Font, FontStyle.Bold);

            link.LinkBehavior = LinkBehavior.AlwaysUnderline;

        }
        Dictionary<int, LinkLabel> dicLinklabel = new Dictionary<int, LinkLabel>();
        private void GenerateLinkLabel()
        {
            this.tableLayoutPanel.Visible = false;
            this.tableLayoutPanel.Controls.Clear();

            this.tableLayoutPanel.RowStyles.Clear();

            int i = 0;
            for (i = 1; i <= 32; i++)
            {
                this.tableLayoutPanel.RowStyles.Add(new RowStyle());
            }
            LinkLabel link = CreateLinkLabel("0.", 0);
            this.tableLayoutPanel.Controls.Add(link);
            LinkLabel linkBlank = CreateLinkLabel("", 0);
            dicLinklabel.Add(0, link);
            dicLinklabel.Add(-1, linkBlank);
            this.tableLayoutPanel.Top = 0;
            this.tableLayoutPanel.Controls.Add(link);
            this.tableLayoutPanel.Controls.Add(linkBlank);
            for (i = 1; i <= 60; i++)
            {
                String text = "";

                link = CreateLinkLabel(text, (i));
                dicLinklabel.Add(i, link);
                this.tableLayoutPanel.Controls.Add(link);
            }


            //Need to add some unused linklabel to make the appearnce of the grid fully showed.
            linkBlank = CreateLinkLabel("", -1);
            this.tableLayoutPanel.Controls.Add(linkBlank);
            linkBlank = CreateLinkLabel("", -1);
            this.tableLayoutPanel.Controls.Add(linkBlank);

            for (i = 0; i < this.tableLayoutPanel.RowStyles.Count; i++)
            {
                this.tableLayoutPanel.RowStyles[i].SizeType = SizeType.Absolute;
                this.tableLayoutPanel.RowStyles[i].Height = 20;

            }
            this.tableLayoutPanel.Height = this.tableLayoutPanel.RowStyles.Count * 21;
            this.tableLayoutPanel.Visible = true;
            this.tableLayoutPanel.Top = 0;

        }
        private string GetHistoryNotation(int index, AI.Board.PlayerColor Turn, Position pos)
        {
            String ColorTurn = "B ";
            if (Turn == AI.Board.PlayerColor.White)
            {
                ColorTurn = "W ";
            }
            String text = (index) + ". " + ColorTurn + " " +
       Utility.Utility.ConvertToReversiNotation(pos);

            return text;

        }
        private void RenderLinkLabelfromHistory()
        {
            int i;

            this.tableLayoutPanel.Visible = false;
            for (i = 1; i <= 60; i++)
            {
                String text = "";



                if (i < game.boardHistory.HistoryPosition.Count)
                {

                    text = GetHistoryNotation(i, game.boardHistory.HistoryTurn[i],
                        game.boardHistory.HistoryPosition[i]);

                }
                dicLinklabel[i].Text = text;

            }

            this.tableLayoutPanel.Visible = true;
        }


        public void RenderHistory()
        {
            Application.DoEvents();
            if (game == null)
            {
                return;
            }

            int i;
            int iLastIndex = game.boardHistory.HistoryPosition.Count - 1;
            Position LastPosition = game.boardHistory.HistoryPosition[iLastIndex];
            if (LastPosition.Row != -1 &&
                LastPosition.Col != -1 &&
                iLastIndex < this.tableLayoutPanel.Controls.Count)
            {

                String text = GetHistoryNotation(iLastIndex, game.boardHistory.HistoryTurn[iLastIndex],
                        game.boardHistory.HistoryPosition[iLastIndex]);

                LinkLabel link = dicLinklabel[iLastIndex];
                link.Text = text;
                link.Visible = true;
                link.Tag = iLastIndex;

            }


            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
            HightLightLinkLabel(iLastIndex);

        }
        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            //UnActiveLinkLabel();
            LinkLabel link = (LinkLabel)sender;

            int linkIndex = (int)link.Tag;
            if (MoveBoardToSpecificTurnClick != null)
            {
                EventArgs eArg = new EventArgs();
                MoveBoardToSpecificTurnClick(linkIndex);
                EnableContinuePlayingButton();
            }

        }
        private void UnActiveLinkLabel()
        {
            int i;
            foreach (int key in dicLinklabel.Keys)
            {
                dicLinklabel[key].Font = new Font(dicLinklabel[key].Font, FontStyle.Regular);

                dicLinklabel[key].LinkColor = LinkForeColor;
                dicLinklabel[key].LinkBehavior = LinkBehavior.NeverUnderline;
            }
        }

        private void PictureBoxBoard_CellClick(object sender, Position position)
        {

            CellClick?.Invoke(sender, position);

        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            EventHandler handler = this.MoveBoardToLastTurnClick;
            handler?.Invoke(this, e);
            EnableContinuePlayingButton();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            EventHandler handler = this.MoveBoardToNextTurnClick;
            handler?.Invoke(this, e);
            EnableContinuePlayingButton();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            EventHandler handler = this.MoveBoardToPreviousTurnClick;
            handler?.Invoke(this, e);
            EnableContinuePlayingButton();
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {

            EventHandler handler = this.MoveBoardToFirstTurnClick;
            handler?.Invoke(this, e);
            EnableContinuePlayingButton();
        }

        public void Initial()
        {
            if (this.pictureBoxBoard == null)
            {
                throw new Exception("Please set pictureBoxBoard");
            }
            if (this.game == null)
            {
                throw new Exception("Please set game object");
            }

            this.pictureBoxBoard.InitialGame(this.game);
            this.game.SetUI(this);
            this.game.boardHistory.IndexHistoryChanged += BoardHistory_IndexHistoryChanged;
            this.game.boardHistory.ClearHistoryAfterCurrentIndexEvent += BoardHistory_ClearHistoryAfterCurrentIndexEvent;
            GenerateLinkLabel();
            RenderLinkLabelfromHistory();
            BoardHistory_IndexHistoryChanged(this.tableLayoutPanel.Controls.Count - 1);
        }

        private void BoardHistory_ClearHistoryAfterCurrentIndexEvent(int CurrentIndex)
        {
            int iLastControlIndex = this.tableLayoutPanel.Controls.Count - 1;
            int i;
            this.tableLayoutPanel.Visible = false;
            foreach (int key in dicLinklabel.Keys)
            {
                if (key > CurrentIndex)
                {
                    dicLinklabel[key].Text = "";
                    dicLinklabel[key].Visible = false;
                }
            }

            this.tableLayoutPanel.Visible = true;

        }

        private void BoardHistory_IndexHistoryChanged(int value)
        {

            int CurrentIndex = value;
            Boolean IsCurrentIndexAlreadyAtFirst = CurrentIndex == 0;
            Boolean IsCurrentIndexAlreadyAtLast = CurrentIndex >= this.game.boardHistory.HistoryBoards.Count - 1;

            this.btnFirst.Enabled = !IsCurrentIndexAlreadyAtFirst;
            this.btnPrevious.Enabled = !IsCurrentIndexAlreadyAtFirst;
            this.btnNext.Enabled = !IsCurrentIndexAlreadyAtLast;
            this.btnLast.Enabled = !IsCurrentIndexAlreadyAtLast;
            HightLightLinkLabel(CurrentIndex);
        }

        public void BlackPutCellAt(Position position)
        {
            throw new NotImplementedException();
        }

        public void MoveBoardToNextTurn()
        {

        }

        public void MoveBoardToPreviousTurn()
        {

        }

        public void RenderBoard()
        {
            // throw new NotImplementedException();
            if (this.lblNumberofWhiteDisk != null)
            {
                this.lblNumberofWhiteDisk.Text = game.board.NumberofWhiteDisk().ToString();
            }
            if (this.lblNumberofBlackDisk != null)
            {
                this.lblNumberofBlackDisk.Text = game.board.NumberofBlackDisk().ToString();
            }


            this.lblPlayer1Border.Visible = false;
            this.lblPlayer2Border.Visible = false;
            if (game.GameState == KReversiGame.GameStatusEnum.Playing)
            {
                if (game.board.CurrentTurn == game.Player1Color)
                {
                    this.lblPlayer1Border.Visible = true;
                    this.lblPlayer2Border.Visible = false;
                }
                else
                {
                    this.lblPlayer1Border.Visible = false;
                    this.lblPlayer2Border.Visible = true;
                }
            }

            this.pictureBoxBoard.UpdateRender();
        }

        public void RenderNumberofDisk(int WhiteDisk, int BlackDisk)
        {
            throw new NotImplementedException();
        }
        private void RemoveGameResource()
        {
            if (game == null)
            {
                return;
            }
            game.BoardWasClickedWhileTheGameWasPaused -= Game_BoardWasClickedWhileTheGameWasPaused;
            game.GameUnPause -= Game_GameUnPause;
            game.Player1BotBeginToThink -= Game_Player1BotBeginToThink;
            game.Player2BotBeginToThink -= Game_Player2BotBeginToThink;
            game.Player1BotFinishedToThink -= Game_Player1BotFinishedToThink;
            game.Player2BotFinishedToThink -= Game_Player2BotFinishedToThink;
        }
        public void RemoveGame()
        {
            RemoveGameResource();
            this.game = null;
        }
        public void SetGame(KReversiGame game)
        {

            this.game = game;



            RemoveGameResource();
            game.GameBegin += Game_GameBegin;
            game.BoardWasClickedWhileTheGameWasPaused += Game_BoardWasClickedWhileTheGameWasPaused;
            game.GameUnPause += Game_GameUnPause;


            game.Player1BotBeginToThink += Game_Player1BotBeginToThink;
            game.Player2BotBeginToThink += Game_Player2BotBeginToThink;
            game.Player1BotFinishedToThink += Game_Player1BotFinishedToThink;
            game.Player2BotFinishedToThink += Game_Player2BotFinishedToThink;

        }

        private void Game_Player2BotFinishedToThink(object sender, EventArgs e)
        {

            HidProgressBar();

        }

        private void Game_Player1BotFinishedToThink(object sender, EventArgs e)
        {

            HidProgressBar();

        }

        private void Game_Player2BotBeginToThink(object sender, EventArgs e)
        {

            ShowProgressBar();
        }

        private void Game_Player1BotBeginToThink(object sender, EventArgs e)
        {

            ShowProgressBar();
        }

        private void Game_GameUnPause(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void Game_BoardWasClickedWhileTheGameWasPaused(object sender, EventArgs e)
        {
            //No need to warning, just conitnue 
            /*
            String Message = "The game was paused because you navigated though the turn player makes.\n"
                + "Please click on an Orange button first.";
            UI.Dialog.ShowMessage(Message);
            */
            BtnContinuePlaying_Click(null, null);
        }

        public void ShowBoardAtTurn(int NumberofTurn)
        {
            throw new NotImplementedException();
        }

        public void WhitePutCellAt(Position position)
        {
            throw new NotImplementedException();
        }

        public void InformPlayer1NeedtoPass()
        {

            UI.Dialog.ShowMessage(String.Format("There is no valid cell for {0} to put.", game.Player1Name));

        }

        public void InformPlayer2NeedtoPass()
        {
            UI.Dialog.ShowMessage(String.Format("There is no valid cell for {0} to put.", game.Player2Name));

        }
        public void InformGameResult(KReversiGame.GameResultEnum result)
        {

            int NumberOfBlackDisk = game.board.NumberofBlackDisk();
            int NumberofWhiteDisk = game.board.NumberofWhiteDisk();
            int NumberofPlayer1Disk = 0;
            int NumberofPlayer2Disk = 0;
            if (game.Player1Color == KReversi.AI.Board.PlayerColor.Black)
            {
                NumberofPlayer1Disk = NumberOfBlackDisk;
                NumberofPlayer2Disk = NumberofWhiteDisk;
            }
            else
            {
                NumberofPlayer1Disk = NumberofWhiteDisk;
                NumberofPlayer2Disk = NumberOfBlackDisk;
            }

            String Message = "";
            switch (result)
            {
                case KReversiGame.GameResultEnum.Draw:
                    Message = "Draw";
                    break;
                case KReversiGame.GameResultEnum.BlackWon:
                    if (game.Player1Color == KReversi.AI.Board.PlayerColor.Black)
                    {
                        Message = String.Format("{0} Won {1} - {2} ", game.Player1Name, NumberOfBlackDisk, NumberofWhiteDisk);
                    }
                    else
                    {
                        Message = String.Format("{0} Won {1} - {2} ", game.Player2Name, NumberofWhiteDisk, NumberOfBlackDisk);
                    }
                    //Message = String.Format("{0} Won {1} - {2} ", game.Player1Name);
                    break;
                case KReversiGame.GameResultEnum.WhiteWon:
                    if (game.Player1Color == KReversi.AI.Board.PlayerColor.White)
                    {
                        Message = String.Format("{0} Won {1} - {2} ", game.Player1Name, NumberofWhiteDisk, NumberOfBlackDisk);
                    }
                    else
                    {
                        Message = String.Format("{0} Won {1} - {2} ", game.Player2Name, NumberOfBlackDisk, NumberofWhiteDisk);
                    }
                    break;
                default:
                    throw new Exception("Please check game result");
                    break;
            }
            UI.Dialog.ShowMessage(Message);
        }
    }
}
