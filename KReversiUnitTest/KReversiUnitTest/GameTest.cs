using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KReversi;
using KReversi.AI;
using System.Diagnostics;
using KReversi.Game;

namespace KReversiUnitTest
{
    [TestClass]
    public class GameTest
    {

        public void PrepareGame(KReversiGame game)
        {
            KReversi.UI.IUI UIBoard = BoardUtil.SetUpBoardUI(game);
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Begin();

            /*
            game.Player1Moved -= Game_PlayerMoved;
            game.Player2Moved -= Game_PlayerMoved;
            game.BoardWasClickedWhileTheGameWasPaused -= Game_BoardWasClickedWhileTheGameWasPaused;
            game.GameUnPause -= Game_GameUnPause;
            game.Player1Moved += Game_PlayerMoved;
            game.Player2Moved += Game_PlayerMoved;
            game.BoardWasClickedWhileTheGameWasPaused += Game_BoardWasClickedWhileTheGameWasPaused;
            game.GameUnPause += Game_GameUnPause;
           */
        }

        public KReversi.Game.KReversiGame CreateGame()
        {
            KReversiGame game = new KReversiGame();
            PrepareGame(game);
            return game;
        }

        private void WriteGameBoard(KReversiGame game)
        {
            WriteGameBoard(game, null);

        }
        private void WriteGameBoard(KReversiGame game, Position lastestposPut)
        {
            if (lastestposPut != null)
            {
                Test.WriteLine("Latest put ::[" + lastestposPut.Row + "," + lastestposPut.Col + "]");
            }
            Test.WriteLine("IsPlayer1 Need to Pass ::" + game.IsPlayer1NeedtoPass());
            Test.WriteLine("IsPlayer2 Need to Pass ::" + game.IsPlayer2NeedtoPass());

            Test.WriteLine("Now After put Current Turn is ::" + game.board.CurrentTurn);
            Test.WriteLine("After put the current Board is ::");
            Test.WriteLine(Environment.NewLine + game.board.ToString());
            Test.WriteLine("==============================");

        }
        [TestMethod]
        public void Player2NeedtoPass()
        {
            KReversiGame game = CreateGame();
            Position[] posWhite =
           {

                new Position (5,5),
                new Position (5,6),
                new Position (5,7),
                new Position (6,5),
                new Position (6,6),
                new Position (7,5),
                new Position (7,6),

            };
            Position[] posBlack =
            {
                new Position(6,7),
                new Position(7,7),
            };
            int i;
            int j;
            game.board = BoardUtil.CreateBlankReversiBoard();

            game.board.SetCellList(posBlack.ToList(), Board.CellValue.Black);
            game.board.SetCellList(posWhite.ToList(), Board.CellValue.White);

            /*
  0  0  0  0  0  0  0  0

  0  0  0  0  0  0  0  0

  0  0  0  0  0  0  0  0

  0  0  0  0  0  0  0  0

  0  0  0  0  0  0  0  0

  0  0  0  0  0  1  1  1

  0  0  0  0  0  1  1 -1

  0  0  0  0  0  1  1 -1
             */
            //game.Player1Color =  Board.PlayerColor.Black;
            game.board.CurrentTurn = Board.PlayerColor.Black;

            this.WriteGameBoard(game);
            bool CanMove = false;
            Position posPut = new Position(4, 7);
            game.HumanPlayer1MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            this.WriteGameBoard(game, posPut);
            Assert.AreEqual(game.board.CurrentTurn, Board.PlayerColor.Black);
            Assert.AreEqual(game.IsPlayer2NeedtoPass(), true);





            posPut = new Position(6, 4);
            game.HumanPlayer1MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            this.WriteGameBoard(game, posPut);

            Assert.AreEqual(game.board.CurrentTurn, Board.PlayerColor.White);
            Assert.AreEqual(game.IsPlayer2NeedtoPass(), false, "Playser 2 Is not supposed to to Pass, but it turn out it is not");

            posPut = new Position(5, 3);
            game.HumanPlayer2MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            this.WriteGameBoard(game, posPut);

            Assert.AreEqual(game.board.CurrentTurn, Board.PlayerColor.Black);

            Assert.AreEqual(game.IsPlayer1NeedtoPass(), false);
            Assert.AreEqual(game.IsPlayer2NeedtoPass(), false);


        }





        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Bot_Invalid Bot 01")]
        public void Bot_InvalidBot01()
        {
            int NumberofGame = 1;
            IPlayer Bot1 = null;
            IPlayer Bot2 = null;
            KReversiGame game = GameBuilder.Builder.BeginBuild
                .GameMode(KReversiGame.PlayerMode.FirstBot_SecondBot)
                .BotPlayer1Is(Bot1)
                .BotPlayer2Is(Bot2)
                .FinishBuild();
            BoardUtil.SetUpBoardUI(game);
            game.Begin();


        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
"Bot_Invalid Bot 02")]
        public void Bot_InvalidBot02()
        {
            int NumberofGame = 1;
            IPlayer Bot1 = new RandomBot();
            IPlayer Bot2 = null;
            KReversiGame game = GameBuilder.Builder.BeginBuild
                .GameMode(KReversiGame.PlayerMode.FirstBot_SecondBot)
                .BotPlayer1Is(Bot1)
                .BotPlayer2Is(Bot2)
                .FinishBuild();
            BoardUtil.SetUpBoardUI(game);
            game.Begin();


        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
"Bot_Invalid Bot 03")]
        public void Bot_InvalidBot03()
        {
            int NumberofGame = 1;
            IPlayer Bot1 = null;
            IPlayer Bot2 = new RandomBot();
            KReversiGame game = GameBuilder.Builder.BeginBuild
                .GameMode(KReversiGame.PlayerMode.FirstBot_SecondBot)
                .BotPlayer1Is(Bot1)
                .BotPlayer2Is(Bot2)
                .FinishBuild();
            BoardUtil.SetUpBoardUI(game);
            game.Begin();


        }
        [TestMethod]
        public void Player1NeedtoPass()
        {
            KReversiGame game = CreateGame();
            Position[] posBlack =
           {

                new Position (5,5),
                new Position (5,6),
                new Position (5,7),
                new Position (6,5),
                new Position (6,6),
                new Position (7,5),
                new Position (7,6),

            };
            Position[] posWhite =
            {
                new Position(6,7),
                new Position(7,7),
            };
            int i;
            int j;
            game.board = BoardUtil.CreateBlankReversiBoard();
            game.board.SetCellList(posBlack.ToList(), Board.CellValue.Black);
            game.board.SetCellList(posWhite.ToList(), Board.CellValue.White);



            game.board.CurrentTurn = Board.PlayerColor.White;

            this.WriteGameBoard(game);
            bool CanMove = false;
            Position posPut = new Position(4, 7);
            game.HumanPlayer2MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            this.WriteGameBoard(game, posPut);
            Assert.AreEqual(game.board.CurrentTurn, Board.PlayerColor.White);
            Assert.IsTrue(game.IsPlayer1NeedtoPass());




            posPut = new Position(6, 4);
            game.HumanPlayer2MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            this.WriteGameBoard(game, posPut);
            Assert.AreEqual(game.board.CurrentTurn, Board.PlayerColor.Black);
            Assert.IsTrue(!game.IsPlayer1NeedtoPass(), "Playser 1 Is not supposed to to Pass, but it turn out it is not");

            posPut = new Position(5, 3);
            game.HumanPlayer1MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            this.WriteGameBoard(game, posPut);

            Assert.AreEqual(game.board.CurrentTurn, Board.PlayerColor.White);
            Assert.IsTrue(!game.IsPlayer1NeedtoPass());
            Assert.IsTrue(!game.IsPlayer2NeedtoPass());


        }

        [TestMethod]
        public void BotPlayer1MoveDesipteForgetToAssignBot()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondHuman;
            //Forget to assign Player1 as bot
            //game.Player1 = new RandomBot();

            bool CanMove = false;
            try
            {
                game.BotPlayer1MoveDecision(out CanMove);
                Test.Fail("BotPlayer1MoveDecision is called despite bot wasn't assigned yet");
            }
            catch (Exception ex)
            {

            }

        }

        [TestMethod]
        public void BotPlayer1MoveDesipteGameStateIsNotPlaying()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondHuman;
            game.Player1 = new RandomBot();

            game.SetGameStateForUnitTest(KReversiGame.GameStatusEnum.Finished);
            bool CanMove = false;
            game.BotPlayer1MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
            game.Pause();
            game.BotPlayer1MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);

            //  Assert.AreEqual(CanMove, true);
        }

        [TestMethod]
        public void BotPlayer2MoveDesipteForgetToAssignBot()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondBot;
            game.Player2 = null;
            //Forget to assign Player2 as bot
            //game.Player2 = new RandomBot();

            bool CanMove = false;
            try
            {
                game.BotPlayer2MoveDecision(out CanMove);
                Test.Fail("BotPlayer2MoveDecision is called despite bot wasn't assigned yet");
            }
            catch (Exception ex)
            {

            }

        }

        [TestMethod]
        public void BotPlayer2MoveDesipteGameStateIsNotPlaying()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondBot;
            game.Player1 = new RandomBot();
            game.Player2 = new RandomBot();
            game.SetGameStateForUnitTest(KReversiGame.GameStatusEnum.Finished);
            bool CanMove = false;
            game.BotPlayer2MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
            game.Pause();

            game.BotPlayer2MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
        }
        [TestMethod]
        public void BotPlayer1MoveDespitePlayer1Human01()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondBot;
            game.Player1 = new RandomBot();

            bool CanMove = false;
            game.BotPlayer1MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
        }

        [TestMethod]
        public void BotPlayer1MoveDespitePlayer1Human02()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Player1 = new RandomBot();

            bool CanMove = false;
            game.BotPlayer1MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
        }

        [TestMethod]
        public void BotPlayer2MoveDespitePlayer2Human01()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondHuman;
            game.Player2 = new RandomBot();

            bool CanMove = false;
            game.BotPlayer2MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
        }

        [TestMethod]
        public void BotPlayer2MoveDespitePlayer2Human02()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Player2 = new RandomBot();

            bool CanMove = false;
            game.BotPlayer2MoveDecision(out CanMove);
            Assert.AreEqual(CanMove, false);
        }

        [TestMethod]
        public void HumanPlayer1MoveDesipteItIsNotHisTurn()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondBot;
            //  game.Player1 = new RandomBot();
            bool CanMove = false;
            Position pos = new Position(3, 2);
            game.board.CurrentTurn = game.Player2Color;
            game.HumanPlayer1MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);

        }
        [TestMethod]
        public void HumanPlayer1MoveDesipteGameStateIsNotPlaying()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondBot;
            //  game.Player1 = new RandomBot();

            game.SetGameStateForUnitTest(KReversiGame.GameStatusEnum.Finished);
            bool CanMove = false;
            Position pos = new Position(3, 2);

            game.HumanPlayer1MoveDecision(pos, out CanMove);

            Assert.AreEqual(CanMove, false);
            game.Pause();
            game.HumanPlayer1MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);
        }

        [TestMethod]
        public void HumanPlayer1MoveDespitePlayer1IsBot01()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondBot;
            Position pos = new Position(3, 2);
            bool CanMove = false;
            game.HumanPlayer1MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);

            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondHuman;
            game.HumanPlayer1MoveDecision(pos, out CanMove);


        }
        [TestMethod]
        public void HumanPlayer1MoveDespitePlayer1IsBot02()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondBot;
            Position pos = new Position(3, 2);
            bool CanMove = false;
            game.HumanPlayer1MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);

        }

        [TestMethod]
        public void HumanPlayer2MoveDesipteItIsNotHisTurn()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            //  game.Player1 = new RandomBot();
            bool CanMove = false;
            Position pos = new Position(3, 2);
            game.board.CurrentTurn = game.Player1Color;
            game.HumanPlayer2MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);

        }

        [TestMethod]
        public void HumanPlayer2MoveDesipteGameStateIsNotPlaying()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            //  game.Player1 = new RandomBot();

            game.SetGameStateForUnitTest(KReversiGame.GameStatusEnum.Finished);
            bool CanMove = false;
            Position pos = new Position(3, 2);

            game.HumanPlayer2MoveDecision(pos, out CanMove);

            Assert.AreEqual(CanMove, false);
            game.Pause();
            game.HumanPlayer2MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);
        }
        [TestMethod]
        public void HumanPlayer2MoveDespitePlayer2IsBot01()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondBot;
            Position pos = new Position(3, 2);
            bool CanMove = false;
            game.HumanPlayer2MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);

        }


        [TestMethod]
        public void HumanPlayer2MoveDespitePlayer2IsBot02()
        {
            KReversiGame game = CreateGame();
            game.PMode = KReversiGame.PlayerMode.FirstBot_SecondBot;
            Position pos = new Position(3, 2);
            bool CanMove = false;
            game.HumanPlayer2MoveDecision(pos, out CanMove);
            Assert.AreEqual(CanMove, false);

        }
    }
}
