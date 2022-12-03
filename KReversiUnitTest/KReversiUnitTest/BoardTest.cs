using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KReversi;
using KReversi.AI;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;

namespace KReversiUnitTest
{
    [TestClass]
    public class BoardTest
    {
        const int BlackCell = (int)KReversi.AI.Board.CellValue.Black;
        const int WhiteCell = (int)KReversi.AI.Board.CellValue.White;



        [TestMethod]
        public void BoardValueAfterBeingPutTheDisk()
        {
            int NoofBlackDisk = 0;
            int NoofWhiteDisk = 0;
            KReversi.AI.Board board = new KReversi.AI.Board();
            board = BoardUtil.CreateStandardReversiBoard();
            Position pos = new Position(3, 2);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            KReversi.AI.Board boardExpectedResult = BoardUtil.CreateStandardReversiBoard();
            boardExpectedResult.SetCell(3, 2, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.SetCell(3, 3, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.CurrentTurn = Board.PlayerColor.White;

            Test.Assert(BoardUtil.IsThese2BoardThesame(board, boardExpectedResult));

            NoofBlackDisk = board.NumberofBlackDisk();
            NoofWhiteDisk = board.NumberofWhiteDisk();
            Test.Assert(NoofBlackDisk == 4);
            Test.Assert(NoofWhiteDisk == 1);

            board = BoardUtil.CreateStandardReversiBoard();
            pos = new Position(2, 3);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            boardExpectedResult = BoardUtil.CreateStandardReversiBoard();
            boardExpectedResult.SetCell(2, 3, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.SetCell(3, 3, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.CurrentTurn = Board.PlayerColor.White;



            Test.Assert(BoardUtil.IsThese2BoardThesame(board, boardExpectedResult));
            NoofBlackDisk = board.NumberofBlackDisk();
            NoofWhiteDisk = board.NumberofWhiteDisk();
            Test.Assert(NoofBlackDisk == 4);
            Test.Assert(NoofWhiteDisk == 1);


            board = BoardUtil.CreateStandardReversiBoard();
            pos = new Position(4, 5);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            boardExpectedResult = BoardUtil.CreateStandardReversiBoard();
            boardExpectedResult.SetCell(4, 4, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.SetCell(4, 5, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.CurrentTurn = Board.PlayerColor.White;

            Test.Assert(BoardUtil.IsThese2BoardThesame(board, boardExpectedResult));
            NoofBlackDisk = board.NumberofBlackDisk();
            NoofWhiteDisk = board.NumberofWhiteDisk();
            Test.Assert(NoofBlackDisk == 4);
            Test.Assert(NoofWhiteDisk == 1);

            board = BoardUtil.CreateStandardReversiBoard();
            pos = new Position(5, 4);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            boardExpectedResult = BoardUtil.CreateStandardReversiBoard();
            boardExpectedResult.SetCell(4, 4, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.SetCell(5, 4, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.CurrentTurn = Board.PlayerColor.White;

            Test.Assert(BoardUtil.IsThese2BoardThesame(board, boardExpectedResult));
            NoofBlackDisk = board.NumberofBlackDisk();
            NoofWhiteDisk = board.NumberofWhiteDisk();
            Test.Assert(NoofBlackDisk == 4);
            Test.Assert(NoofWhiteDisk == 1);


            pos = new Position(5, 3);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.White);
            boardExpectedResult.SetCell(4, 3, KReversi.AI.Board.CellValue.White);
            boardExpectedResult.SetCell(5, 3, KReversi.AI.Board.CellValue.White);
            boardExpectedResult.CurrentTurn = Board.PlayerColor.Black;
            Test.Assert(BoardUtil.IsThese2BoardThesame(board, boardExpectedResult));

            NoofBlackDisk = board.NumberofBlackDisk();
            NoofWhiteDisk = board.NumberofWhiteDisk();
            Test.Assert(NoofBlackDisk == 3);
            Test.Assert(NoofWhiteDisk == 3);
        }


        [TestMethod]
        public void BoardSetCellByRow()
        {
            int NoofBlackDisk = 0;
            int NoofWhiteDisk = 0;
            KReversi.AI.Board board = new KReversi.AI.Board();
            board = BoardUtil.CreateStandardReversiBoard();

            board.SetCellsByRow(0, "BBBWWW  ");
            Test.Assert(board.boardMatrix[0, 0] == (int)Board.CellValue.Black);
            Test.Assert(board.boardMatrix[0, 1] == (int)Board.CellValue.Black);
            Test.Assert(board.boardMatrix[0, 2] == (int)Board.CellValue.Black);
            Test.Assert(board.boardMatrix[0, 3] == (int)Board.CellValue.White);
            Test.Assert(board.boardMatrix[0, 4] == (int)Board.CellValue.White);
            Test.Assert(board.boardMatrix[0, 5] == (int)Board.CellValue.White);
            Test.Assert(board.boardMatrix[0, 6] == 0);
            Test.Assert(board.boardMatrix[0, 7] == 0);


        }

        [TestMethod]
        public void BoardSetCellByColumn()
        {
            int NoofBlackDisk = 0;
            int NoofWhiteDisk = 0;
            KReversi.AI.Board board = new KReversi.AI.Board();
            board = BoardUtil.CreateStandardReversiBoard();

            board.SetCellsByColumn(0, "BBBWWW  ");
            Test.Assert(board.boardMatrix[0, 0] == (int)Board.CellValue.Black);
            Test.Assert(board.boardMatrix[1, 0] == (int)Board.CellValue.Black);
            Test.Assert(board.boardMatrix[2, 0] == (int)Board.CellValue.Black);
            Test.Assert(board.boardMatrix[3, 0] == (int)Board.CellValue.White);
            Test.Assert(board.boardMatrix[4, 0] == (int)Board.CellValue.White);
            Test.Assert(board.boardMatrix[5, 0] == (int)Board.CellValue.White);
            Test.Assert(board.boardMatrix[6, 0] == 0);
            Test.Assert(board.boardMatrix[7, 0] == 0);
            try
            {
                board.SetCellsByColumn(0, "");
                Test.Fail("There is an error when set the blank value to SetCellByColumn");
            }
            catch
            {

            }
            try
            {
                board.SetCellsByColumn(0, "WWWWWWWWW");
                Test.Fail("There is an error when set the blank value to SetCellByColumn");
            }
            catch
            {

            }
        }

        [TestMethod]
        public void CanPutValidDisk()
        {

            KReversi.AI.Board board = new KReversi.AI.Board();

            Position[] posValid =
            {
                new Position (2,3),
                new Position (3,2),
                new Position (4,5),
                new Position (5,4)

            };

            int i;
            for (i = 0; i < posValid.GetLength(0); i++)
            {
                board = BoardUtil.CreateStandardReversiBoard();
                Boolean CanPut = board.IsLegalMove(posValid[i], Board.PlayerColor.Black);
                Test.Assert(CanPut, "Check at ::" + posValid[i].Row + "_" + posValid[i].Col);
            }



        }

        [TestMethod]
        public void CanPutInvalidDisk()
        {
            KReversi.AI.Board board = new KReversi.AI.Board();
            //    board = CreateStandardOthelloBoard();

            Position[] posInvalid =
            {

                new Position (3,3),
                new Position (3,4),
                new Position (4,3),
                new Position (4,4),


                new Position (2,2),
                new Position (2,4),
                new Position (2,5),
                new Position (4,2),
                new Position (5,2),
                new Position (5,3),
                new Position (5,5),
                new Position (3,3),


                new Position (-1,-1),
                new Position (8,8),
                new Position (-1,8),
                new Position (8,-1)


            };

            int i;
            for (i = 0; i < posInvalid.GetLength(0); i++)
            {
                board = BoardUtil.CreateStandardReversiBoard();
                Boolean CanPut = board.IsLegalMove(posInvalid[i], Board.PlayerColor.Black);

                Test.Assert(!CanPut, "Check at ::" + posInvalid[i].Row + "_" + posInvalid[i].Col);
            }
        }


        [TestMethod]
        public void BoardGenerateMove()
        {
            int NoofBlackDisk = 0;
            int NoofWhiteDisk = 0;
            KReversi.AI.Board board = new KReversi.AI.Board();
            board = BoardUtil.CreateStandardReversiBoard();
          
            board.SetCellsByRow(0, "B BBBBB ");
            board.SetCellsByRow(1, "B WWWWWB");
            board.SetCellsByRow(2, "BWWWBWWB");
            board.SetCellsByRow(3, "BWWWWBWB");
            board.SetCellsByRow(4, "BBBWWWWB");
            board.SetCellsByRow(5, "BWBBWWWB");
            board.SetCellsByRow(6, "BWWWWWW ");
            board.SetCellsByRow(7, "BBBBBBBB");

            Position pos = new Position(0, 7);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            List<Position> listpos = board.generateMoves();
            Assert.IsTrue(listpos.Count == 0);

            board.SwitchTurnDueToPlayerPass();
            listpos = board.generateMoves();

            Assert.IsTrue(listpos.Count == 3);

        }




    }
}
