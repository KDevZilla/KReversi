using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KReversi.AI;
using KReversi.UI;

namespace KReversi.Game
{

    public class KReversiGame
    {

        public enum PlayerMode
        {
            FirstHuman_SecondHuman = 0,
            FirstHuman_SecondBot = 1,
            FirstBot_SecondHuman = 2,
            FirstBot_SecondBot = 3
        }
        public Boolean IsPlayer1Bot
        {
            get
            {
                return PMode == PlayerMode.FirstBot_SecondBot ||
                    PMode == PlayerMode.FirstBot_SecondHuman;
            }
        }
        public Boolean IsPlayer2Bot
        {
            get
            {
                return PMode == PlayerMode.FirstBot_SecondBot ||
                    PMode == PlayerMode.FirstHuman_SecondBot;
            }
        }
        private Board.PlayerColor _Player1Color = Board.PlayerColor.Black;
        private Board.PlayerColor _Player2Color = Board.PlayerColor.White;
        public Board.PlayerColor Player1Color
        {
            get
            {
                return _Player1Color;
            }
            /*
             * Come to think of it
             * We should not allow the game to change the player color.
             * In Chess, the first player color is alwasy white
             * In Otherllo, the first player disk color is always black
             * So Player1Color cannot be set
             */
            /*
            set
            {
                _Player1Color = value;
                if (value== Board.PlayerColor.White)
                {
                    _Player2Color = Board.PlayerColor.Black;
                } else
                {
                    _Player2Color = Board.PlayerColor.White;
                    
                }
            }
            */
        }
        public Board.PlayerColor Player2Color
        {
            get
            {
                return _Player2Color;
            }
        }
        public void Begin()
        {

            this.GameState = GameStatusEnum.Playing;
            UIBoard.RenderBoard();
            if (GameBegin != null)
            {
                GameBegin(this, new EventArgs());
            }

            NextTurn();

        }
        public event EventHandler Player1BotBeginToThink;
        public event EventHandler Player2BotBeginToThink;
        public event EventHandler Player1BotFinishedToThink;
        public event EventHandler Player2BotFinishedToThink;

        public PlayerMode PMode;

        public UI.IUI UIBoard { get; private set; } = null;
        public void ReleaseUI()
        {

            if (this.UIBoard != null)
            {

                this.UIBoard.MoveBoardToFirstTurnClick -= UIBoard_MoveBoardToFirstTurnClick;
                this.UIBoard.MoveBoardToPreviousTurnClick -= UIBoard_MoveBoardToPreviousTurnClick;
                this.UIBoard.MoveBoardToNextTurnClick -= UIBoard_MoveBoardToNextTurnClick;
                this.UIBoard.MoveBoardToLastTurnClick -= UIBoard_MoveBoardToLastTurnClick;
                this.UIBoard.CellClick -= UIBoard_CellClick;
                this.UIBoard.MoveBoardToSpecificTurnClick -= UIBoard_MoveBoardToSpecificTurnClick;
                this.UIBoard.ContinuePlayingClick -= UIBoard_ContinuePlayingClick;
                this.UIBoard.ReleaseUIResource();
                this.UIBoard.RemoveGame();
                this.UIBoard = null;
            }
        }
        public void SetUI(UI.IUI UIboard)
        {
            ReleaseUI();
            this.UIBoard = UIboard;

            this.UIBoard.MoveBoardToFirstTurnClick -= UIBoard_MoveBoardToFirstTurnClick;
            this.UIBoard.MoveBoardToPreviousTurnClick -= UIBoard_MoveBoardToPreviousTurnClick;
            this.UIBoard.MoveBoardToNextTurnClick -= UIBoard_MoveBoardToNextTurnClick;
            this.UIBoard.MoveBoardToLastTurnClick -= UIBoard_MoveBoardToLastTurnClick;
            this.UIBoard.CellClick -= UIBoard_CellClick;
            this.UIBoard.MoveBoardToSpecificTurnClick -= UIBoard_MoveBoardToSpecificTurnClick;
            this.UIBoard.ContinuePlayingClick -= UIBoard_ContinuePlayingClick;




            this.UIBoard.MoveBoardToFirstTurnClick += UIBoard_MoveBoardToFirstTurnClick;
            this.UIBoard.MoveBoardToPreviousTurnClick += UIBoard_MoveBoardToPreviousTurnClick;
            this.UIBoard.MoveBoardToNextTurnClick += UIBoard_MoveBoardToNextTurnClick;
            this.UIBoard.MoveBoardToLastTurnClick += UIBoard_MoveBoardToLastTurnClick;
            this.UIBoard.CellClick += UIBoard_CellClick;
            this.UIBoard.MoveBoardToSpecificTurnClick += UIBoard_MoveBoardToSpecificTurnClick;
            this.UIBoard.ContinuePlayingClick += UIBoard_ContinuePlayingClick;
        }

        private void UIBoard_ContinuePlayingClick(object sender, EventArgs e)
        {
            this.boardHistory.ClearHistoryAfterCurrentIndex();
            this.CalculateResult();
            if (IsGameFinish())
            {
                this.GameState = GameStatusEnum.Finished;
            }
            else
            {
                this.GameState = GameStatusEnum.Playing;
            }
            this.UnPause();

        }

        private void UIBoard_MoveBoardToSpecificTurnClick(int value)
        {
            SimpleLog.WriteLog("UIBoard_MoveBoardToSpecificTurnClick::" + value);
            this.boardHistory.SetCurrentBoardToIndex(value);
            this.PointToBoardHistory();
            this.Pause();
            this.UIBoard.RenderBoard();
        }

        private void UIBoard_CellClick(object sender, Position position)
        {

            if (this.GameState == GameStatusEnum.Pause)
            {
                BoardWasClickedWhileTheGameWasPaused?.Invoke(this, new EventArgs());
                return;
            }
            if (this.GameState != GameStatusEnum.Playing)
            {
                return;
            }

            if (!board.IsLegalMove(position, board.CurrentTurn))
            {
                return;
            }
            bool CanMove = false;
            if (this.board.CurrentTurn == this.Player1Color)
            {
                if (!this.IsPlayer1Bot)
                {
                    this.HumanPlayer1MoveDecision(position, out CanMove);
                    if (!CanMove)
                    {
                        String message = @"
In order to reach this stage
Program already check that this position [{0},{1}] is Legal move
But the HumanPayer1MoveDecision function return CanMove out parameter as false
Please check in the log
";
                        message = String.Format(message, position.Row, position.Col);
                        SimpleLog.WriteLog("Please check this board postion");
                        SimpleLog.WriteLog(this.board.ToString());
                        SimpleLog.WriteLog(message);
                        throw new Exception(message);
                    }
                }
            }
            else
            {
                //this.Player2Move(position);
                if (!this.IsPlayer2Bot)
                {
                    this.HumanPlayer2MoveDecision(position, out CanMove);
                    if (!CanMove)
                    {
                        String message = @"
In order to reach this stage
Program already check that this position [{0},{1}] is Legal move
But the HumanPayer2MoveDecision function return CanMove out parameter as false
Please check in the log
";
                        message = String.Format(message, position.Row, position.Col);
                        SimpleLog.WriteLog("Please check this board postion");
                        SimpleLog.WriteLog(this.board.ToString());
                        SimpleLog.WriteLog(message);
                        throw new Exception(message);
                    }
                }
            }

            //    this.UIBoard.RenderBoard();
        }

        private void UIBoard_ClickAtCell(Position position)
        {

            if (this.GameState == GameStatusEnum.Finished)
            {
                return;
            }

            if (!board.IsLegalMove(position, board.CurrentTurn))
            {
                return;
            }
            bool CanMove = false;
            if (this.board.CurrentTurn == this.Player1Color)
            {
                this.HumanPlayer1MoveDecision(position, out CanMove);
            }
            else
            {

                this.HumanPlayer2MoveDecision(position, out CanMove);
            }

            this.UIBoard.RenderBoard();
        }

        private void UIBoard_MoveBoardToLastTurnClick(object sender, EventArgs e)
        {

            this.boardHistory.LastMoveBoard();
            this.PointToBoardHistory();
            this.Pause();
            this.UIBoard.RenderBoard();
        }

        private void UIBoard_MoveBoardToNextTurnClick(object sender, EventArgs e)
        {

            this.boardHistory.NextMoveBoard();
            this.PointToBoardHistory();
            this.Pause();
            this.UIBoard.RenderBoard();
        }

        private void UIBoard_MoveBoardToPreviousTurnClick(object sender, EventArgs e)
        {

            this.boardHistory.PreviousMoveBoard();
            this.PointToBoardHistory();
            this.Pause();
            this.UIBoard.RenderBoard();
        }

        private void UIBoard_MoveBoardToFirstTurnClick(object sender, EventArgs e)
        {

            this.boardHistory.FirstMoveBoard();
            this.PointToBoardHistory();
            this.Pause();
            this.UIBoard.RenderBoard();


        }

        public enum GameStatusEnum
        {
            Pause = -1,
            Playing = 0,
            Finished = 1
        }

        public enum GameResultEnum
        {
            NotDecideYet = -2,
            BlackWon = -1,
            Draw = 0,
            WhiteWon = 1,

        }
        public GameStatusEnum GameState { get; private set; } = GameStatusEnum.Finished;
        public GameStatusEnum GameStateBeforePause { get; private set; } = GameStatusEnum.Finished;
        public GameResultEnum GameResult { get; private set; } = GameResultEnum.NotDecideYet;
        public void PointToBoardHistory()
        {
            this.board = boardHistory.GetBoardToHistory();
            SimpleLog.WriteLog("PointToBoardHistory");
        }
        public Stack<Action> StAction = new Stack<Action>();

        public AI.Board board { get; set; }
        public IPlayer Player1 = null;
        public IPlayer Player2 = null;
        public String Player1Name { get; set; }
        public String Player2Name { get; set; }

        public Boolean IsAllowRandomDecision { get; set; } = true;
        public Boolean IsUsingAlphaBeta { get; set; } = true;
        public Boolean IsKeepLastDecisionTree { get; set; } = false;

        public BoardHistory boardHistory { get; private set; }
        public void SetGameStateForUnitTest(GameStatusEnum newGameState)
        {
            this.GameState = newGameState;
        }

        public void Pause()
        {
            if (this.GameState == GameStatusEnum.Pause)
            {
                return;
            }
            this.GameStateBeforePause = this.GameState;
            this.GameState = GameStatusEnum.Pause;
            this.GamePause?.Invoke(this, new EventArgs());
        }
        public void UnPause()
        {

            bool CanMove = false;
            if (board.CurrentTurn == this.Player1Color)
            {
                if (this.IsPlayer1Bot)
                {
                    BotPlayer1MoveDecision(out CanMove);

                }
                return;
            }
            else
            {
                if (this.IsPlayer2Bot)
                {
                    BotPlayer2MoveDecision(out CanMove);
                }
            }

            this.GameUnPause?.Invoke(this, new EventArgs());
        }


        private string _boardFileName = "";
        private void ExplicitConstructorForGameFile(String gameFileName)
        {
            GameValue gameValue = null;
            if (!String.IsNullOrEmpty(gameFileName))
            {
                gameValue = Utility.SerializeUtility.DeserializeGameValue(gameFileName);
            }
            else
            {
                gameValue = new GameValue();

            }
            this.boardHistory = gameValue.boardHistory.Clone();
            this.boardHistory.LastMoveBoard();

            this.PointToBoardHistory();

        }
        private void ExplicitConstructorForBoardFile(String boardFileName)
        {

            if (!String.IsNullOrEmpty(boardFileName))
            {
                this.board = this.LoadBoardFromFile(boardFileName);
            }
            else
            {
                board = new AI.Board();

            }
            this.boardHistory = new BoardHistory();


            AddCurrentBoardToHistory(board, null, board.CurrentTurn);
            this._boardFileName = boardFileName;


            this.PMode = PlayerMode.FirstHuman_SecondHuman;
            if (this.PMode == PlayerMode.FirstBot_SecondBot)
            {
                Player1 = new AI.BasicBot();
            }

            Player2 = new AI.BasicBot();

        }
        public static KReversiGame LoadGameFromBoardFile(string boardFileName)
        {

            KReversiGame game = new KReversiGame();
            game.ExplicitConstructorForBoardFile(boardFileName);
            return game;
        }
        public static KReversiGame LoadGameFromGameFile(string GameFileName)
        {
            KReversiGame game = new KReversiGame();
            game.ExplicitConstructorForGameFile(GameFileName);
            return game;
        }

        public KReversiGame(String boardFileName)
        {
            ExplicitConstructorForBoardFile(boardFileName);
        }
        public KReversiGame()
        {
            ExplicitConstructorForBoardFile("");


        }
        private AI.Board LoadBoardFromFile(String boardFileName)
        {
            BoardValue boardValue = Utility.SerializeUtility.DeserializeBoardValue(boardFileName);
            AI.Board board = new AI.Board(boardValue);
            return board;


            // this.UIBoard.RenderBoard();


        }
        private void AddCurrentBoardToHistory(Board board, Position position, Board.PlayerColor playercolor)
        {
            //, Board.PlayerColor playercolor
            //Board.PlayerColor CurrentPlayerColor = this.board.CurrentTurn;
            boardHistory.AddBoardHistory(board, position, playercolor);

        }
        private void Game_Player2Moved(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Game_Player1Moved(object sender, EventArgs e)
        {
            // throw new NotImplementedException();


        }

        public event EventHandler BotPass;
        public event EventHandler BotMoveEvent;
        // public event EventHandler Player1Moved;
        // public event EventHandler Player2Moved;
        public event EventHandler Player1Pass;
        public event EventHandler Player2Pass;
        public event EventHandler BoardWasClickedWhileTheGameWasPaused;
        public event EventHandler GameBegin;
        public event EventHandler GamePause;
        public event EventHandler GameUnPause;

        //    private Stack<IBoard> HistoryBoards { get; set; }





        public void UndoBoard()
        {

            //board =(AI.Board) HistoryBoards.Pop();

        }
        protected virtual void OnPlayer1Moved()
        {

            UIBoard?.RenderHistory();
            NextTurn();

        }

        protected virtual void OnPlayer2Moved()
        {


            UIBoard?.RenderHistory();
            NextTurn();

        }

        public Boolean IsPlayer1NeedtoPass()
        {
            if (board.generateMoves(this.Player1Color).Count == 0)
            {
                return true;

            }
            return false;
        }
        public Boolean IsPlayer2NeedtoPass()
        {
            if (board.generateMoves(this.Player2Color).Count == 0)
            {
                return true;

            }
            return false;
        }
        public void BotPlayer1MoveDecision(out bool CanMove)
        {

            CanMove = false;
            if (this.Player1 == null)
            {
                throw new Exception("Please Assign Player1bot");
            }
            if (this.GameState == GameStatusEnum.Finished ||
                this.GameState == GameStatusEnum.Pause)
            {

                return;
            }
            if (!IsPlayer1Bot)
            {

                return;
            }
            if (IsPlayer1NeedtoPass())
            {
                //This player1 is bot no need to inform
                //UIBoard.InformPlayer1NeedtoPass();
                board.SwitchTurnDueToPlayerPass();
            }
            else
            {
                Player1BotBeginToThink?.Invoke(this, new EventArgs());
                if (Player1 is MiniMaxBotProto)
                {
                    MiniMaxBotProto minimaxBot = (MiniMaxBotProto)Player1;
                    // minimaxBot.
                    //For Player1 IsKeepLastDecisionTree is always false;
                    minimaxBot.IsAllowRandomDecision = this.IsAllowRandomDecision;
                    minimaxBot.IsKeepLastDecisionTree = false;// this.IsKeepLastDecisionTree;
                    minimaxBot.IsUsingAlphaBeta = this.IsUsingAlphaBeta;
                }
                Position botPosition = Player1.MakeMove(board);
                Player1Move(botPosition, out CanMove);
                if (!CanMove)
                {
                    throw new Exception("There must be something wrong with Player 1 Move");
                }
                Player1BotFinishedToThink?.Invoke(this, new EventArgs());

            }
            OnPlayer1Moved();



        }
        public void HumanPlayer1MoveDecision(Position pos, out bool CanMove)
        {
            CanMove = false;
            if (this.GameState == GameStatusEnum.Finished ||
                this.GameState == GameStatusEnum.Pause)
            {
                return;
            }
            if (IsPlayer1Bot)
            {
                return;
            }

            Player1Move(pos, out CanMove);

            OnPlayer1Moved();

        }
        private void Player1Move(Position pos, out Boolean CanMove)
        {
            CanMove = false;
            if (this.board.CurrentTurn != Player1Color)
            {
                return;
            }
            if (!this.board.IsLegalMove(pos, Player1Color))
            {
                return;
            }


            board.PutAndAlsoSwithCurrentTurn(pos, this.Player1Color);
            CanMove = true;
            boardHistory.IndexMoveAdd();
            Boolean CanPlayer2MakeMove = board.generateMoves(Player2Color).Count > 0;
            Boolean CanPlayer1MakeMove = board.generateMoves(Player1Color).Count > 0;


            Board.PlayerColor PlayerColorForNextTurn = this.Player2Color;
            if (!CanPlayer2MakeMove)
            {
                if (CanPlayer1MakeMove)
                {
                    PlayerColorForNextTurn = this.Player1Color;
                   // board.CurrentTurn = this.Player1Color;
                }
            }

            Board boardForHistory = (Board)this.board.Clone();
            boardForHistory.CurrentTurn = PlayerColorForNextTurn;
            AddCurrentBoardToHistory(boardForHistory, pos, this.Player1Color);
            UIBoard.RenderBoard();

            if (!CanPlayer2MakeMove)
            {
                if (!CanPlayer1MakeMove)
                {
                    this.GameState = GameStatusEnum.Finished;
                    CalculateResult();

                    UIBoard.InformGameResult(this.GameResult);
                }
                else
                {

                    if (!IsPlayer2Bot || !IsPlayer1Bot)
                    {
                        this.UIBoard.InformPlayer2NeedtoPass();
                    }
                    board.SwitchTurnDueToPlayerPass();
                    UIBoard.RenderBoard();
                }
            }


        }

        public void BotPlayer2MoveDecision(out bool CanMove)
        {
            CanMove = false;
            if (this.Player2 == null)
            {
                throw new Exception("Please Assign Player2bot");
            }
            if (this.GameState == GameStatusEnum.Finished ||
                this.GameState == GameStatusEnum.Pause)
            {
                return;
            }
            if (!IsPlayer2Bot)
            {
                return;
            }
            if (IsPlayer2NeedtoPass())
            {
                //This player2 is bot no need to inform
                //UIBoard.InformPlayer2NeedtoPass();
                board.SwitchTurnDueToPlayerPass();

            }
            else
            {
                Player2BotBeginToThink?.Invoke(this, new EventArgs());

                if (Player2 is MiniMaxBotProto)
                {
                    MiniMaxBotProto minimaxBot = (MiniMaxBotProto)Player2;
                    minimaxBot.IsAllowRandomDecision = this.IsAllowRandomDecision;
                    minimaxBot.IsKeepLastDecisionTree = this.IsKeepLastDecisionTree;
                    minimaxBot.IsUsingAlphaBeta = this.IsUsingAlphaBeta;
                }
                Position botPosition = Player2.MakeMove(board);
                Player2Move(botPosition, out CanMove);
                if (!CanMove)
                {
                    throw new Exception("There must be something wrong with Player2 Move");
                }
                Player2BotFinishedToThink?.Invoke(this, new EventArgs());
            }
            OnPlayer2Moved();



        }


        public void HumanPlayer2MoveDecision(Position pos, out bool CanMove)
        {
            CanMove = false;
            if (this.GameState == GameStatusEnum.Finished ||
                this.GameState == GameStatusEnum.Pause)
            {
                return;
            }
            if (IsPlayer2Bot)
            {
                return;
                // No need to throw;
                //   throw new Exception("The mode is " + PMode + " Program cannot accept Player2Move Method");
            }

            Player2Move(pos, out CanMove);
            OnPlayer2Moved();

        }
        private void Player2Move(Position pos, out bool CanMove)
        {
            CanMove = false;
            if (this.board.CurrentTurn != Player2Color)
            {
                return;
            }
            if (!this.board.IsLegalMove(pos, Player2Color))
            {
                return;
            }
            board.PutAndAlsoSwithCurrentTurn(pos, board.CurrentTurn);
            CanMove = true;
            boardHistory.IndexMoveAdd();

            Boolean CanPlayer2MakeMove = board.generateMoves(Player2Color).Count > 0;
            Boolean CanPlayer1MakeMove = board.generateMoves(Player1Color).Count > 0;


            Board.PlayerColor PlayerColorForNextTurn = this.Player1Color;
            if (!CanPlayer1MakeMove)
            {
                if (CanPlayer2MakeMove)
                {
                    PlayerColorForNextTurn = this.Player2Color;
                }
            }

            Board boardForHistory = (Board)this.board.Clone();
            boardForHistory.CurrentTurn = PlayerColorForNextTurn;
            AddCurrentBoardToHistory(boardForHistory, pos, this.Player2Color);
            UIBoard.RenderBoard();

            if (!CanPlayer1MakeMove)
            {
                if (!CanPlayer2MakeMove)
                {
                    this.GameState = GameStatusEnum.Finished;
                    CalculateResult();

                    UIBoard.InformGameResult(this.GameResult);
                }
                else
                {

                    if (!IsPlayer1Bot || !IsPlayer2Bot)
                    {
                        this.UIBoard.InformPlayer1NeedtoPass();
                    }
                    board.SwitchTurnDueToPlayerPass();
                    UIBoard.RenderBoard();
                }
            }

        }



        private void NextTurn()
        {
            if (this.GameState != GameStatusEnum.Playing)
            {
                return;
            }
            if (this.IsPlayer1NeedtoPass() && this.IsPlayer2NeedtoPass())
            {
                this.GameState = GameStatusEnum.Finished;
                CalculateResult();
                this.UIBoard.InformGameResult(this.GameResult);
                return;
            }
            bool CanMove = false;
            if (this.board.CurrentTurn == Board.PlayerColor.Black)
            {
                if (this.IsPlayer1Bot)
                {

                    BotPlayer1MoveDecision(out CanMove);

                    return;
                }
                else
                {
                    if (this.IsPlayer1NeedtoPass())
                    {
                        this.UIBoard.InformPlayer1NeedtoPass();
                        this.board.SwitchTurnDueToPlayerPass();
                        this.UIBoard.RenderBoard();
                    }
                }
                return;
            }

            if (this.IsPlayer2Bot)
            {

                BotPlayer2MoveDecision(out CanMove);
                return;
            }
            else
            {
                if (this.IsPlayer2NeedtoPass())
                {
                    this.UIBoard.InformPlayer2NeedtoPass();
                    this.board.SwitchTurnDueToPlayerPass();
                    this.UIBoard.RenderBoard();
                }
            }

        }
        private void CalculateResult()
        {
            int NumberofWhiteDisk = board.NumberofWhiteDisk();
            int NumberofBlackDisk = board.NumberofBlackDisk();

            this.GameResult = GameResultEnum.NotDecideYet;
            if (NumberofWhiteDisk == NumberofBlackDisk)
            {
                this.GameResult = GameResultEnum.Draw;
            }
            else if (NumberofWhiteDisk < NumberofBlackDisk)
            {
                this.GameResult = GameResultEnum.BlackWon;
            }
            else
            {
                this.GameResult = GameResultEnum.WhiteWon;
            }

        }
        private bool IsGameFinish()
        {
            if (board.generateMoves(Player1Color).Count == 0 &&
                board.generateMoves(Player2Color).Count == 0)
            {
                return true;
            }
            return false;
        }

        public GameValue GetGameValue()
        {
            GameValue gameValue = new GameValue();
            gameValue.boardValue = this.board.GetBoardValue();
            gameValue.boardHistory = this.boardHistory.Clone();

            return gameValue;
        }

    }
}
