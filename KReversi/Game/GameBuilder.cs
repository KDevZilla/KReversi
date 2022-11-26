using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KReversi.Game;
namespace KReversi.Game
{
    public class GameBuilder
    {
        private static GameBuilder _Builder;
        public static GameBuilder Builder
        {
            get
            {
                if (_Builder == null)
                {
                    _Builder = new GameBuilder();
                }
                return _Builder;
            }
        }
        private KReversiGame game = null;
        private String GameFileName = "";
        private String BoardFileName = "";
        private IPlayer BotPlayer1 = null;
        private IPlayer BotPlayer2 = null;
        private String Player1Name = "";
        private String Player2Name = "";

        private Boolean IsAllowRandomDecision = true;
        private Boolean IsUsingAlphaBeta = true;
        private Boolean IsKeepLastDecisionTree = false;
        private KReversiGame.PlayerMode Mode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
        public GameBuilder BeginBuild
        {
            get
            {
                //No need to create an object at this point
                //game = new KReversiGame();

                game = null;
                GameFileName = "";
                BoardFileName = "";
                BotPlayer1 = null;
                BotPlayer2 = null;
                Mode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
                return this;
            }
        }
        public GameBuilder GameMode(KReversiGame.PlayerMode pMode)
        {
            this.Mode = pMode;
            return this;
        }

        public GameBuilder OpenWithGameFile(String GameFileName)
        {
            this.GameFileName = GameFileName;
            return this;
        }
        public GameBuilder OpenWithBoardFile(String BoardFileName)
        {
            this.BoardFileName = BoardFileName;
            return this;
        }
        public GameBuilder BotPlayer1Is(IPlayer BotPlayer1)
        {
            this.BotPlayer1 = BotPlayer1;
            return this;
        }
        public GameBuilder BotPlayer2Is(IPlayer BotPlayer2)
        {
            this.BotPlayer2 = BotPlayer2;
            return this;
        }


        public GameBuilder Player1NameIs(String Player1Name)
        {
            this.Player1Name = Player1Name;
            return this;
        }
        public GameBuilder Player2NameIs(String Player2Name)
        {
            this.Player2Name = Player2Name;
            return this;
        }

        public GameBuilder AllowRandomDecision(bool pIsAllowRandomDecision)
        {
            this.IsAllowRandomDecision = pIsAllowRandomDecision;
            return this;

        }
        public GameBuilder UsingAlphaBeta(bool pIsUsingAlphaBeta)
        {
            this.IsUsingAlphaBeta = pIsUsingAlphaBeta;
            return this;
        }
        public GameBuilder KeepLastDecisionTree(bool pIsKeepLastDecisionTree)
        {
            this.IsKeepLastDecisionTree = pIsKeepLastDecisionTree;
            return this;
        }

        public KReversiGame FinishBuild()
        {
            if (!String.IsNullOrWhiteSpace(BoardFileName) &&
                !String.IsNullOrWhiteSpace(GameFileName))
            {
                throw new Exception(String.Format("This is board file name {0} \n and this is game file name {1} you have to choose only one\n", BoardFileName, GameFileName)
                    + "You cannot set both OpenWithGameFile and OpenWithBoardFile, you need to choose one only");
            }
            if (Mode == KReversiGame.PlayerMode.FirstBot_SecondBot ||
                Mode == KReversiGame.PlayerMode.FirstBot_SecondHuman)
            {
                if (BotPlayer1 == null)
                {
                    throw new Exception("You need to set BotPlayer1");
                }
            }
            if (Mode == KReversiGame.PlayerMode.FirstBot_SecondBot ||
                Mode == KReversiGame.PlayerMode.FirstHuman_SecondBot)
            {
                if (BotPlayer2 == null)
                {
                    throw new Exception("You need to set BotPlayer2");
                }
            }
            if (String.IsNullOrWhiteSpace(this.BoardFileName) && String.IsNullOrWhiteSpace(this.GameFileName))
            {
                game = new KReversiGame();
            }
            else
            {

                if (!String.IsNullOrWhiteSpace(this.BoardFileName))
                {
                    game = KReversiGame.LoadGameFromBoardFile(this.BoardFileName);
                }
                if (!String.IsNullOrWhiteSpace(this.GameFileName))
                {
                    game = KReversiGame.LoadGameFromGameFile(this.GameFileName);
                }
            }

            game.PMode = this.Mode;
            game.Player1 = this.BotPlayer1;
            game.Player2 = this.BotPlayer2;
            game.Player1Name = this.Player1Name;
            game.Player2Name = this.Player2Name;
            game.IsKeepLastDecisionTree = this.IsKeepLastDecisionTree;
            game.IsAllowRandomDecision = this.IsAllowRandomDecision;
            game.IsUsingAlphaBeta = this.IsUsingAlphaBeta;

            return game;
        }

    }
}
