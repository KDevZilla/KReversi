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
    public class GameHistoryTest
    {
        /*
        If you have time please change these method to use loop
        */
        [TestMethod]
        public void HumanPlayTestHistoryNavigation()
        {
            Boolean IsBoardTheSame = false;
            KReversiGame game = new KReversiGame();
            KReversi.UI.IUI UIBoard = BoardUtil.SetUpBoardUI(game);
            Board boardHistoryIndexMove0 = (Board)game.board.Clone();
            Board boardHistoryIndexMove1 = null;
            Board boardHistoryIndexMove2 = null;
            Board boardHistoryIndexMove3 = null;
            game.board.CurrentTurn = Board.PlayerColor.Black;
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Begin();
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 1);
            bool CanMove = false;

            game.HumanPlayer1MoveDecision(new Position(5, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 2);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);
            Assert.IsTrue(IsBoardTheSame);
            boardHistoryIndexMove1 = (Board)game.board.Clone();

            game.HumanPlayer2MoveDecision(new Position(5, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 3);
            Assert.IsTrue(game.boardHistory.IndexMove == 2);
            Assert.IsTrue(IsBoardTheSame);
            boardHistoryIndexMove2 = (Board)game.board.Clone();


            game.HumanPlayer1MoveDecision(new Position(5, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 4);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);
            boardHistoryIndexMove3 = (Board)game.board.Clone();


            game.boardHistory.SetCurrentBoardToIndex(2);
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove2);
            Assert.IsTrue(game.boardHistory.IndexMove == 2);
            Assert.IsTrue(IsBoardTheSame);

            game.boardHistory.SetCurrentBoardToIndex(0);
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove0);
            Assert.IsTrue(game.boardHistory.IndexMove == 0);
            Assert.IsTrue(IsBoardTheSame);

            game.boardHistory.PreviousMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove0);
            Assert.IsTrue(game.boardHistory.IndexMove == 0);
            Assert.IsTrue(IsBoardTheSame);


            game.boardHistory.FirstMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove0);
            Assert.IsTrue(game.boardHistory.IndexMove == 0);
            Assert.IsTrue(IsBoardTheSame);

            game.boardHistory.NextMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove1);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);
            Assert.IsTrue(IsBoardTheSame);

            game.boardHistory.LastMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove3);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);


            game.boardHistory.NextMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove3);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);


            game.boardHistory.SetCurrentBoardToIndex(1);
            game.boardHistory.ClearHistoryAfterCurrentIndex();
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 2);

            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove1);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);


            // game.boardHistory.AddBoardHistory ()
        }
        [TestMethod]
        public void HumanPlayTestHistoryIncaseofPass()
        {

            KReversiGame game = new KReversiGame();
            KReversi.UI.IUI UIBoard = BoardUtil.SetUpBoardUI(game);

            game.board.CurrentTurn = Board.PlayerColor.Black;
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Begin();
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
            game.boardHistory.ClearAllHistory();
            game.board = BoardUtil.CreateBlankReversiBoard();

            game.board.SetCellList(posBlack.ToList(), Board.CellValue.Black);
            game.board.SetCellList(posWhite.ToList(), Board.CellValue.White);

            //game.Player1Color =  Board.PlayerColor.Black;
            game.board.CurrentTurn = Board.PlayerColor.Black;
            game.boardHistory.IndexMoveAdd();
            game.boardHistory.AddBoardHistory(game.board, null, Board.PlayerColor.Black);
            Board boardHistoryIndexMove0 = (Board)game.board.Clone();
            Board boardHistoryIndexMove1 = null;
            Board boardHistoryIndexMove2 = null;
            Board boardHistoryIndexMove3 = null;

            bool CanMove = false;
            Position posPut = new Position(4, 7);
            game.HumanPlayer1MoveDecision(posPut, out CanMove);

            bool IsBoardTheSame = false;
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 2);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);
            Assert.IsTrue(IsBoardTheSame);
            boardHistoryIndexMove1 = (Board)game.board.Clone();




            posPut = new Position(6, 4);
            game.HumanPlayer1MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 3);
            Assert.IsTrue(game.boardHistory.IndexMove == 2);
            Assert.IsTrue(IsBoardTheSame);
            boardHistoryIndexMove2 = (Board)game.board.Clone();

            posPut = new Position(5, 3);
            game.HumanPlayer2MoveDecision(posPut, out CanMove);
            Assert.AreEqual(CanMove, true); ;
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 4);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);
            boardHistoryIndexMove3 = (Board)game.board.Clone();

            game.boardHistory.PreviousMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove2);
            Assert.IsTrue(IsBoardTheSame);

            game.boardHistory.PreviousMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove1);
            Assert.IsTrue(IsBoardTheSame);

            game.boardHistory.FirstMoveBoard();
            game.PointToBoardHistory();
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame(game.board, boardHistoryIndexMove0);
            Assert.IsTrue(IsBoardTheSame);

        }
        [TestMethod]
        public void HumanPlayTestHistoryNumber3()
        {
            Boolean IsBoardTheSame = false;
            KReversiGame game = new KReversiGame();
            KReversi.UI.IUI UIBoard = BoardUtil.SetUpBoardUI(game);

            game.board.CurrentTurn = Board.PlayerColor.Black;
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Begin();
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 1);
            bool CanMove = false;

            game.HumanPlayer1MoveDecision(new Position(5, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 2);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 3);
            Assert.IsTrue(game.boardHistory.IndexMove == 2);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 4);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 5);
            Assert.IsTrue(game.boardHistory.IndexMove == 4);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 6);
            Assert.IsTrue(game.boardHistory.IndexMove == 5);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 7);
            Assert.IsTrue(game.boardHistory.IndexMove == 6);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 8);
            Assert.IsTrue(game.boardHistory.IndexMove == 7);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 9);
            Assert.IsTrue(game.boardHistory.IndexMove == 8);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 10);
            Assert.IsTrue(game.boardHistory.IndexMove == 9);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 11);
            Assert.IsTrue(game.boardHistory.IndexMove == 10);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(6, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 12);
            Assert.IsTrue(game.boardHistory.IndexMove == 11);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 13);
            Assert.IsTrue(game.boardHistory.IndexMove == 12);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 14);
            Assert.IsTrue(game.boardHistory.IndexMove == 13);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 15);
            Assert.IsTrue(game.boardHistory.IndexMove == 14);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 16);
            Assert.IsTrue(game.boardHistory.IndexMove == 15);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 17);
            Assert.IsTrue(game.boardHistory.IndexMove == 16);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 18);
            Assert.IsTrue(game.boardHistory.IndexMove == 17);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 19);
            Assert.IsTrue(game.boardHistory.IndexMove == 18);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 20);
            Assert.IsTrue(game.boardHistory.IndexMove == 19);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 21);
            Assert.IsTrue(game.boardHistory.IndexMove == 20);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 22);
            Assert.IsTrue(game.boardHistory.IndexMove == 21);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 23);
            Assert.IsTrue(game.boardHistory.IndexMove == 22);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 24);
            Assert.IsTrue(game.boardHistory.IndexMove == 23);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 25);
            Assert.IsTrue(game.boardHistory.IndexMove == 24);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 26);
            Assert.IsTrue(game.boardHistory.IndexMove == 25);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 27);
            Assert.IsTrue(game.boardHistory.IndexMove == 26);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 28);
            Assert.IsTrue(game.boardHistory.IndexMove == 27);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 29);
            Assert.IsTrue(game.boardHistory.IndexMove == 28);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 30);
            Assert.IsTrue(game.boardHistory.IndexMove == 29);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 31);
            Assert.IsTrue(game.boardHistory.IndexMove == 30);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 32);
            Assert.IsTrue(game.boardHistory.IndexMove == 31);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 33);
            Assert.IsTrue(game.boardHistory.IndexMove == 32);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(6, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 34);
            Assert.IsTrue(game.boardHistory.IndexMove == 33);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 35);
            Assert.IsTrue(game.boardHistory.IndexMove == 34);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 36);
            Assert.IsTrue(game.boardHistory.IndexMove == 35);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 37);
            Assert.IsTrue(game.boardHistory.IndexMove == 36);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 38);
            Assert.IsTrue(game.boardHistory.IndexMove == 37);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 39);
            Assert.IsTrue(game.boardHistory.IndexMove == 38);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 40);
            Assert.IsTrue(game.boardHistory.IndexMove == 39);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 41);
            Assert.IsTrue(game.boardHistory.IndexMove == 40);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 42);
            Assert.IsTrue(game.boardHistory.IndexMove == 41);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 43);
            Assert.IsTrue(game.boardHistory.IndexMove == 42);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 44);
            Assert.IsTrue(game.boardHistory.IndexMove == 43);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 45);
            Assert.IsTrue(game.boardHistory.IndexMove == 44);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 46);
            Assert.IsTrue(game.boardHistory.IndexMove == 45);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 47);
            Assert.IsTrue(game.boardHistory.IndexMove == 46);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 48);
            Assert.IsTrue(game.boardHistory.IndexMove == 47);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 49);
            Assert.IsTrue(game.boardHistory.IndexMove == 48);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 50);
            Assert.IsTrue(game.boardHistory.IndexMove == 49);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 51);
            Assert.IsTrue(game.boardHistory.IndexMove == 50);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 52);
            Assert.IsTrue(game.boardHistory.IndexMove == 51);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 53);
            Assert.IsTrue(game.boardHistory.IndexMove == 52);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(6, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 54);
            Assert.IsTrue(game.boardHistory.IndexMove == 53);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 55);
            Assert.IsTrue(game.boardHistory.IndexMove == 54);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(1, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 56);
            Assert.IsTrue(game.boardHistory.IndexMove == 55);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 57);
            Assert.IsTrue(game.boardHistory.IndexMove == 56);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(1, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 58);
            Assert.IsTrue(game.boardHistory.IndexMove == 57);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 59);
            Assert.IsTrue(game.boardHistory.IndexMove == 58);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 60);
            Assert.IsTrue(game.boardHistory.IndexMove == 59);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 61);
            Assert.IsTrue(game.boardHistory.IndexMove == 60);
            Assert.IsTrue(IsBoardTheSame);




        }

        [TestMethod]
        public void HumanPlayTestHistoryNumber1()
        {
            Boolean IsBoardTheSame = false;
            KReversiGame game = new KReversiGame();
            KReversi.UI.IUI UIBoard = BoardUtil.SetUpBoardUI(game);

            game.board.CurrentTurn = Board.PlayerColor.Black;
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Begin();
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 1);
            bool CanMove = false;


            game.HumanPlayer1MoveDecision(new Position(5, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 2);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 3);
            Assert.IsTrue(game.boardHistory.IndexMove == 2);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 4);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 5);
            Assert.IsTrue(game.boardHistory.IndexMove == 4);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 6);
            Assert.IsTrue(game.boardHistory.IndexMove == 5);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 7);
            Assert.IsTrue(game.boardHistory.IndexMove == 6);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 8);
            Assert.IsTrue(game.boardHistory.IndexMove == 7);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 9);
            Assert.IsTrue(game.boardHistory.IndexMove == 8);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 10);
            Assert.IsTrue(game.boardHistory.IndexMove == 9);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 11);
            Assert.IsTrue(game.boardHistory.IndexMove == 10);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 12);
            Assert.IsTrue(game.boardHistory.IndexMove == 11);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 13);
            Assert.IsTrue(game.boardHistory.IndexMove == 12);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 14);
            Assert.IsTrue(game.boardHistory.IndexMove == 13);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 15);
            Assert.IsTrue(game.boardHistory.IndexMove == 14);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 16);
            Assert.IsTrue(game.boardHistory.IndexMove == 15);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 17);
            Assert.IsTrue(game.boardHistory.IndexMove == 16);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 18);
            Assert.IsTrue(game.boardHistory.IndexMove == 17);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 19);
            Assert.IsTrue(game.boardHistory.IndexMove == 18);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 20);
            Assert.IsTrue(game.boardHistory.IndexMove == 19);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 21);
            Assert.IsTrue(game.boardHistory.IndexMove == 20);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 22);
            Assert.IsTrue(game.boardHistory.IndexMove == 21);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 23);
            Assert.IsTrue(game.boardHistory.IndexMove == 22);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 24);
            Assert.IsTrue(game.boardHistory.IndexMove == 23);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 25);
            Assert.IsTrue(game.boardHistory.IndexMove == 24);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 26);
            Assert.IsTrue(game.boardHistory.IndexMove == 25);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 27);
            Assert.IsTrue(game.boardHistory.IndexMove == 26);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 28);
            Assert.IsTrue(game.boardHistory.IndexMove == 27);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 29);
            Assert.IsTrue(game.boardHistory.IndexMove == 28);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 30);
            Assert.IsTrue(game.boardHistory.IndexMove == 29);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 31);
            Assert.IsTrue(game.boardHistory.IndexMove == 30);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 32);
            Assert.IsTrue(game.boardHistory.IndexMove == 31);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 33);
            Assert.IsTrue(game.boardHistory.IndexMove == 32);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 34);
            Assert.IsTrue(game.boardHistory.IndexMove == 33);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 35);
            Assert.IsTrue(game.boardHistory.IndexMove == 34);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 36);
            Assert.IsTrue(game.boardHistory.IndexMove == 35);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 37);
            Assert.IsTrue(game.boardHistory.IndexMove == 36);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 38);
            Assert.IsTrue(game.boardHistory.IndexMove == 37);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 39);
            Assert.IsTrue(game.boardHistory.IndexMove == 38);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 40);
            Assert.IsTrue(game.boardHistory.IndexMove == 39);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 41);
            Assert.IsTrue(game.boardHistory.IndexMove == 40);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 42);
            Assert.IsTrue(game.boardHistory.IndexMove == 41);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 43);
            Assert.IsTrue(game.boardHistory.IndexMove == 42);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 44);
            Assert.IsTrue(game.boardHistory.IndexMove == 43);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 45);
            Assert.IsTrue(game.boardHistory.IndexMove == 44);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 46);
            Assert.IsTrue(game.boardHistory.IndexMove == 45);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 47);
            Assert.IsTrue(game.boardHistory.IndexMove == 46);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(6, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 48);
            Assert.IsTrue(game.boardHistory.IndexMove == 47);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 49);
            Assert.IsTrue(game.boardHistory.IndexMove == 48);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(1, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 50);
            Assert.IsTrue(game.boardHistory.IndexMove == 49);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 51);
            Assert.IsTrue(game.boardHistory.IndexMove == 50);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 52);
            Assert.IsTrue(game.boardHistory.IndexMove == 51);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 53);
            Assert.IsTrue(game.boardHistory.IndexMove == 52);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 54);
            Assert.IsTrue(game.boardHistory.IndexMove == 53);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 55);
            Assert.IsTrue(game.boardHistory.IndexMove == 54);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 56);
            Assert.IsTrue(game.boardHistory.IndexMove == 55);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 57);
            Assert.IsTrue(game.boardHistory.IndexMove == 56);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(1, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 58);
            Assert.IsTrue(game.boardHistory.IndexMove == 57);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 59);
            Assert.IsTrue(game.boardHistory.IndexMove == 58);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 60);
            Assert.IsTrue(game.boardHistory.IndexMove == 59);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 61);
            Assert.IsTrue(game.boardHistory.IndexMove == 60);
            Assert.IsTrue(IsBoardTheSame);




        }


        [TestMethod]
        public void HumanPlayTestHistoryNumber2()
        {
            Boolean IsBoardTheSame = false;
            KReversiGame game = new KReversiGame();
            KReversi.UI.IUI UIBoard = BoardUtil.SetUpBoardUI(game);

            game.board.CurrentTurn = Board.PlayerColor.Black;
            game.PMode = KReversiGame.PlayerMode.FirstHuman_SecondHuman;
            game.Begin();
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 1);
            bool CanMove = false;


            game.HumanPlayer1MoveDecision(new Position(5, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 2);
            Assert.IsTrue(game.boardHistory.IndexMove == 1);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 3);
            Assert.IsTrue(game.boardHistory.IndexMove == 2);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 4);
            Assert.IsTrue(game.boardHistory.IndexMove == 3);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 5);
            Assert.IsTrue(game.boardHistory.IndexMove == 4);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 6);
            Assert.IsTrue(game.boardHistory.IndexMove == 5);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 7);
            Assert.IsTrue(game.boardHistory.IndexMove == 6);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 8);
            Assert.IsTrue(game.boardHistory.IndexMove == 7);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 9);
            Assert.IsTrue(game.boardHistory.IndexMove == 8);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 10);
            Assert.IsTrue(game.boardHistory.IndexMove == 9);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 11);
            Assert.IsTrue(game.boardHistory.IndexMove == 10);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 12);
            Assert.IsTrue(game.boardHistory.IndexMove == 11);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 13);
            Assert.IsTrue(game.boardHistory.IndexMove == 12);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(6, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 14);
            Assert.IsTrue(game.boardHistory.IndexMove == 13);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 15);
            Assert.IsTrue(game.boardHistory.IndexMove == 14);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 16);
            Assert.IsTrue(game.boardHistory.IndexMove == 15);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 17);
            Assert.IsTrue(game.boardHistory.IndexMove == 16);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 18);
            Assert.IsTrue(game.boardHistory.IndexMove == 17);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 19);
            Assert.IsTrue(game.boardHistory.IndexMove == 18);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 20);
            Assert.IsTrue(game.boardHistory.IndexMove == 19);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 21);
            Assert.IsTrue(game.boardHistory.IndexMove == 20);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 22);
            Assert.IsTrue(game.boardHistory.IndexMove == 21);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 23);
            Assert.IsTrue(game.boardHistory.IndexMove == 22);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 24);
            Assert.IsTrue(game.boardHistory.IndexMove == 23);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(4, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 25);
            Assert.IsTrue(game.boardHistory.IndexMove == 24);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 26);
            Assert.IsTrue(game.boardHistory.IndexMove == 25);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 27);
            Assert.IsTrue(game.boardHistory.IndexMove == 26);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 28);
            Assert.IsTrue(game.boardHistory.IndexMove == 27);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 29);
            Assert.IsTrue(game.boardHistory.IndexMove == 28);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 5), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 30);
            Assert.IsTrue(game.boardHistory.IndexMove == 29);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 31);
            Assert.IsTrue(game.boardHistory.IndexMove == 30);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 32);
            Assert.IsTrue(game.boardHistory.IndexMove == 31);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 33);
            Assert.IsTrue(game.boardHistory.IndexMove == 32);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 34);
            Assert.IsTrue(game.boardHistory.IndexMove == 33);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(2, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 35);
            Assert.IsTrue(game.boardHistory.IndexMove == 34);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(2, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 36);
            Assert.IsTrue(game.boardHistory.IndexMove == 35);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 37);
            Assert.IsTrue(game.boardHistory.IndexMove == 36);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 38);
            Assert.IsTrue(game.boardHistory.IndexMove == 37);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 39);
            Assert.IsTrue(game.boardHistory.IndexMove == 38);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 40);
            Assert.IsTrue(game.boardHistory.IndexMove == 39);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(0, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 41);
            Assert.IsTrue(game.boardHistory.IndexMove == 40);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 42);
            Assert.IsTrue(game.boardHistory.IndexMove == 41);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 7), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 43);
            Assert.IsTrue(game.boardHistory.IndexMove == 42);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(5, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 44);
            Assert.IsTrue(game.boardHistory.IndexMove == 43);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(5, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 45);
            Assert.IsTrue(game.boardHistory.IndexMove == 44);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 46);
            Assert.IsTrue(game.boardHistory.IndexMove == 45);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 47);
            Assert.IsTrue(game.boardHistory.IndexMove == 46);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 4), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 48);
            Assert.IsTrue(game.boardHistory.IndexMove == 47);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 49);
            Assert.IsTrue(game.boardHistory.IndexMove == 48);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(7, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 50);
            Assert.IsTrue(game.boardHistory.IndexMove == 49);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 51);
            Assert.IsTrue(game.boardHistory.IndexMove == 50);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(4, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 52);
            Assert.IsTrue(game.boardHistory.IndexMove == 51);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 53);
            Assert.IsTrue(game.boardHistory.IndexMove == 52);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(0, 3), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 54);
            Assert.IsTrue(game.boardHistory.IndexMove == 53);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(6, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 55);
            Assert.IsTrue(game.boardHistory.IndexMove == 54);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 56);
            Assert.IsTrue(game.boardHistory.IndexMove == 55);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(7, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 57);
            Assert.IsTrue(game.boardHistory.IndexMove == 56);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer1MoveDecision(new Position(3, 1), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 58);
            Assert.IsTrue(game.boardHistory.IndexMove == 57);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 6), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 59);
            Assert.IsTrue(game.boardHistory.IndexMove == 58);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(3, 0), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 60);
            Assert.IsTrue(game.boardHistory.IndexMove == 59);
            Assert.IsTrue(IsBoardTheSame);

            game.HumanPlayer2MoveDecision(new Position(1, 2), out CanMove);
            IsBoardTheSame = BoardUtil.IsThese2BoardThesame((Board)game.boardHistory.HistoryBoards[game.boardHistory.IndexMove], game.board);
            Assert.IsTrue(CanMove);
            Assert.IsTrue(game.boardHistory.HistoryBoards.Count == 61);
            Assert.IsTrue(game.boardHistory.IndexMove == 60);
            Assert.IsTrue(IsBoardTheSame);




        }
    }
}
