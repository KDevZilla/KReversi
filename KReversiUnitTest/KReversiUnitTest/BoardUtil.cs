using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KReversi.AI;
using KReversi.Game;

namespace KReversiUnitTest
{
    public class BoardUtil
    {
        public static KReversi.UI.IUI SetUpBoardUI(KReversiGame game)
        {

            KReversi.UI.IUI UIBoard = new KReversi.UI.MockIUI();


            UIBoard.SetGame(game);
            UIBoard.Initial();
            return UIBoard;

        }
        public static Boolean IsThese2BoardThesame(Board board1, Board board2)
        {
            int i;
            int j;
            if (board1.CurrentTurn != board2.CurrentTurn)
            {
                return false;
            }
            for (i = 0; i < board1.boardMatrix.GetLength(0); i++)
            {
                for (j = 0; j < board1.boardMatrix.GetLength(1); j++)
                {
                    if (board1.boardMatrix[i, j] !=
                        board2.boardMatrix[i, j])
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public static Board CreateStandardReversiBoard()
        {
            Board board = new Board();
            board.SetCell(3, 4, Board.CellValue.Black);
            board.SetCell(4, 3, Board.CellValue.Black);
            board.SetCell(3, 3, Board.CellValue.White);
            board.SetCell(4, 4, Board.CellValue.White);
            board.CurrentTurn = Board.PlayerColor.Black;
            return board;
        }
        public static Board CreateBlankReversiBoard()
        {
            int i;
            int j;
            Board board = new Board();
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    board.SetCell(i, j, Board.CellValue.Blank);
                }
            }
            board.CurrentTurn = Board.PlayerColor.Black;

            return board;
        }
    }
}
