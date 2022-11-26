using KReversi;
using KReversi.AI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversiUnitTest
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void TestHashClass()
        {
            int HashEvalBoardValue = 9001;
            int HashBoardValue = 5001;
            int HashNotExistBoardValue = 5002;

            Hash hash = new Hash();
            hash.AddEvalScore(HashEvalBoardValue, 50);
            Test.Assert(hash.ContainEvalScore(HashEvalBoardValue));
            Test.Assert(hash.GetEvalScore(HashEvalBoardValue) == 50);

            hash.Add(HashBoardValue, 30, 5);
            Test.Assert(!hash.ContainScore(HashNotExistBoardValue, 5));
            Test.Assert(!hash.ContainScore(HashBoardValue, 6));



            Test.Assert(hash.ContainScore(HashBoardValue, 5));
            Test.Assert(hash.ContainScore(HashBoardValue, 4));
            Test.Assert(hash.ContainScore(HashBoardValue, 3));
            Test.Assert(hash.ContainScore(HashBoardValue, 2));
            Test.Assert(hash.ContainScore(HashBoardValue, 1));
            Test.Assert(hash.ContainScore(HashBoardValue, 0));



        }
        [TestMethod]
        public void TestHashValue()
        {
           
            KReversi.AI.Board board = new KReversi.AI.Board();
            board = BoardUtil.CreateStandardReversiBoard();

           // int Depth = 0;
            int HashValueForWhiteTurn = Hash.GetHashForBoard(board);

            board.CurrentTurn = Board.PlayerColor.White;
            int HashValueForBlackTurn = Hash.GetHashForBoard(board);
            Test.Assert(HashValueForWhiteTurn != HashValueForBlackTurn);
            /*
            int[] arrHashVAlueForWhiteTurnDepth = new int[7];

            int[] arrHashVAlueForBlackTurnDepth = new int[7];

            int i;
            HashSet<int> hashsetValueForBothTurnDepth = new HashSet<int>();
            board.CurrentTurn = Board.PlayerColor.White  ;
            for (i = 0; i < arrHashVAlueForWhiteTurnDepth.Length; i++)
            {
                arrHashVAlueForWhiteTurnDepth[i] = Hash.GetHashForBoard(board, i);
                Test.Assert(!hashsetValueForBothTurnDepth.Contains(arrHashVAlueForWhiteTurnDepth[i]));

                hashsetValueForBothTurnDepth.Add(arrHashVAlueForWhiteTurnDepth[i]);

            }

            board.CurrentTurn = Board.PlayerColor.Black ;
            for (i = 0; i < arrHashVAlueForBlackTurnDepth.Length; i++)
            {
                arrHashVAlueForBlackTurnDepth[i] = Hash.GetHashForBoard(board, i);
                Test.Assert(!hashsetValueForBothTurnDepth.Contains(arrHashVAlueForBlackTurnDepth[i]));

                hashsetValueForBothTurnDepth.Add(arrHashVAlueForBlackTurnDepth[i]);
            }
            */
            HashSet<int> hashsetValueForBothTurnDepth = new HashSet<int>();
            Position pos = new Position(3, 2);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            hashsetValueForBothTurnDepth.Add(Hash.GetHashForBoard(board));

            pos = new Position(2, 3);
            board = BoardUtil.CreateStandardReversiBoard();
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            hashsetValueForBothTurnDepth.Add(Hash.GetHashForBoard(board));

            String strTemp = "HEllo";
            /*
            Position pos = new Position(3, 2);
            board.PutAndAlsoSwithCurrentTurn(pos, Board.PlayerColor.Black);
            KReversi.AI.Board boardExpectedResult = BoardUtil.CreateStandardReversiBoard();
            boardExpectedResult.SetCell(3, 2, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.SetCell(3, 3, KReversi.AI.Board.CellValue.Black);
            boardExpectedResult.CurrentTurn = Board.PlayerColor.White;
            */
            //Test.Assert(BoardUtil.IsThese2BoardThesame(board, boardExpectedResult));


        }
    }


}
