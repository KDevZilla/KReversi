using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KReversi;
using KReversi.AI;

namespace KReversiUnitTest
{
    [TestClass]
    public class EvaluateTest
    {

        private int[,] OpenGamePostionScore = new int[,] {
            { 100, -20, 20, 5, 5, 20, -20, 100},
            {-20 , -30, -5, -5, -5, -5, -30, -20},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-20 , -30, -5, -5, -5, -5, -30, -20},
            {100 , -20, 20, 5, 5, 20, -20, 100}
        };

        private int[,] All1GamePostionScore = new int[,] {
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1}
        };

        private int[,] All0GamePostionScore = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0}
        };


        [TestMethod]
        public void EvaluateScore()
        {
            BasicMiniMaxEvaluate.EvaluateScore botScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore OpponentScore = new BasicMiniMaxEvaluate.EvaluateScore();
            botScore.DiskCount = 5;
            botScore.NoofPossibleMove = 10;

            //  botScore.ScoreAvilableMoveWeight = 20;
            botScore.ScorePassWeight = 1000;
            botScore.ScorePositionWeight = 500;
            botScore.ScoreStableDiskWeight = 50;
            botScore.ScoreDiskCanFlip = 50;
            OpponentScore.DiskCount = 50;
            OpponentScore.NoofPossibleMove = 20;
            //  OpponentScore.ScoreAvilableMoveWeight = 120;
            OpponentScore.ScorePassWeight = 1200;
            OpponentScore.ScorePositionWeight = 2500;
            OpponentScore.ScoreStableDiskWeight = 500;
            OpponentScore.ScoreDiskCanFlip = 100;

            BasicMiniMaxEvaluate.EvaluateScore ResultScore = new BasicMiniMaxEvaluate.EvaluateScore();
            ResultScore = botScore - OpponentScore;
            Test.Assert(ResultScore.DiskCount == botScore.DiskCount - OpponentScore.DiskCount);
            Test.Assert(ResultScore.NoofPossibleMove == botScore.NoofPossibleMove - OpponentScore.NoofPossibleMove);
            // Test.Assert(ResultScore.ScoreAvilableMoveWeight == botScore.ScoreAvilableMoveWeight - OpponentScore.ScoreAvilableMoveWeight);
            Test.Assert(ResultScore.ScorePassWeight == botScore.ScorePassWeight - OpponentScore.ScorePassWeight);
            Test.Assert(ResultScore.ScorePositionWeight == botScore.ScorePositionWeight - OpponentScore.ScorePositionWeight);
            Test.Assert(ResultScore.ScoreStableDiskWeight == botScore.ScoreStableDiskWeight - OpponentScore.ScoreStableDiskWeight);
            Test.Assert(ResultScore.ScoreDiskCanFlip == botScore.ScoreDiskCanFlip - OpponentScore.ScoreDiskCanFlip);

            Test.Assert(ResultScore.GetTotalScore() ==
                // ResultScore.ScoreAvilableMoveWeight +
                ResultScore.ScorePassWeight +
                ResultScore.ScorePositionWeight +
                ResultScore.ScoreStableDiskWeight +
                ResultScore.ScoreDiskCanFlip);

        }
        [TestMethod]
        public void Calculate1()
        {
            BasicMiniMaxEvaluate.EvaluateScore botScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore OpponentScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore ResultScore = null;
            int StableDiskScore = 20;
            int MobilityScore = 30;
            //  int ScoreDiskCanFlip = 10;
            bool IsUsingPositionScore = true;
            int Result = 0;
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();



            Board board1 = (Board)board.Clone();
            board1.PutAndAlsoSwithCurrentTurn(2, 3, Board.PlayerColor.Black);

            Result = Evu.Calculate(board1, true, Board.PlayerColor.Black,
             botScore,
             OpponentScore,
             All1GamePostionScore,
             StableDiskScore,
             MobilityScore,
             IsUsingPositionScore);
            Test.Assert(botScore.DiskCount == 4);
            Test.Assert(botScore.NoofPossibleMove == 3);

            Test.Assert(botScore.ScorePassWeight == 0);
            Test.Assert(botScore.ScorePositionWeight == 4);
            Test.Assert(botScore.ScoreStableDiskWeight == 0);
            Test.Assert(botScore.ScoreDiskCanFlip == 90);
            Test.Assert(botScore.ScoreDiskCanFlip == botScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(botScore.GetTotalScore() == 94);

            Test.Assert(OpponentScore.DiskCount == 1);
            Test.Assert(OpponentScore.NoofPossibleMove == 3);
            //Test.Assert(OpponentScore.ScoreAvilableMoveWeight == OpponentScore.NoofPossibleMove * MobilityScore);
            Test.Assert(OpponentScore.ScorePassWeight == 0);
            Test.Assert(OpponentScore.ScorePositionWeight == 1);
            Test.Assert(OpponentScore.ScoreStableDiskWeight == 0);
            Test.Assert(OpponentScore.ScoreDiskCanFlip == 90);
            Test.Assert(OpponentScore.ScoreDiskCanFlip == OpponentScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(OpponentScore.GetTotalScore() == 91);

            ResultScore = botScore - OpponentScore;

            Test.Assert(ResultScore.DiskCount == 3);
            Test.Assert(ResultScore.NoofPossibleMove == 0);
            // Test.Assert(ResultScore.ScoreAvilableMoveWeight == ResultScore.NoofPossibleMove * MobilityScore);
            Test.Assert(ResultScore.ScorePassWeight == 0);
            Test.Assert(ResultScore.ScorePositionWeight == 3);
            Test.Assert(ResultScore.ScoreStableDiskWeight == 0);
            Test.Assert(ResultScore.ScoreDiskCanFlip == 0);
            Test.Assert(ResultScore.ScoreDiskCanFlip == ResultScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(ResultScore.GetTotalScore() == 3);

            Test.Assert(ResultScore.GetTotalScore() == Result);
        }


        [TestMethod]
        public void Calculate2()
        {
            BasicMiniMaxEvaluate.EvaluateScore botScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore OpponentScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore ResultScore = null;
            int StableDiskScore = 20;
            int MobilityScore = 30;

            bool IsUsingPositionScore = true;
            int Result = 0;
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();



            Board board1 = (Board)board.Clone();
            board1.PutAndAlsoSwithCurrentTurn(2, 3, Board.PlayerColor.Black);
            board1.SetCellsByRow(0, "BBBBBBBB");

            Result = Evu.Calculate(board1, true, Board.PlayerColor.Black,
              botScore,
              OpponentScore,
              All1GamePostionScore,
              StableDiskScore,
              MobilityScore,
              IsUsingPositionScore);
            Test.Assert(botScore.DiskCount == 12);
            Test.Assert(botScore.NoofPossibleMove == 3);

            Test.Assert(botScore.ScorePassWeight == 0);
            Test.Assert(botScore.ScorePositionWeight == 12);
            Test.Assert(botScore.ScoreStableDiskWeight == 560);
            //Test.Assert(botScore.ScoreDiskCanFlip == 30);
            Test.Assert(botScore.ScoreDiskCanFlip == botScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(botScore.GetTotalScore() == 662);

            Test.Assert(OpponentScore.DiskCount == 1);
            Test.Assert(OpponentScore.NoofPossibleMove == 3);

            Test.Assert(OpponentScore.ScorePassWeight == 0);
            Test.Assert(OpponentScore.ScorePositionWeight == 1);
            Test.Assert(OpponentScore.ScoreStableDiskWeight == 0);
            //Test.Assert(OpponentScore.ScoreDiskCanFlip == 30);
            Test.Assert(OpponentScore.ScoreDiskCanFlip == OpponentScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(OpponentScore.GetTotalScore() == 91);

            ResultScore = botScore - OpponentScore;

            Test.Assert(ResultScore.DiskCount == 11);
            Test.Assert(ResultScore.NoofPossibleMove == 0);

            Test.Assert(ResultScore.ScorePassWeight == 0);
            Test.Assert(ResultScore.ScorePositionWeight == 11);
            Test.Assert(ResultScore.ScoreStableDiskWeight == 560);
            //Test.Assert(ResultScore.ScoreDiskCanFlip == 0);
            Test.Assert(ResultScore.ScoreDiskCanFlip == ResultScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(ResultScore.GetTotalScore() == 571);


        }
        [TestMethod]
        public void TestToStringBoard()
        {
            Board board = BoardUtil.CreateStandardReversiBoard();
            int i;
            Boolean IsWriteLog = true;

            for (i = 0; i <= 50000; i++)
            {
                String strTemp = "Hello" + i;

                if (IsWriteLog)
                {
                    strTemp += board.ToString() + i.ToString();
                }
                //String strTemp = i.ToString();
            }

        }

        [TestMethod]
        public void Calculate3()
        {
            BasicMiniMaxEvaluate.EvaluateScore botScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore OpponentScore = new BasicMiniMaxEvaluate.EvaluateScore();
            BasicMiniMaxEvaluate.EvaluateScore ResultScore = null;
            int StableDiskScore = 20;
            int MobilityScore = 30;
            // int ScoreDiskCanFlip = 10;
            bool IsUsingPositionScore = true;
            int Result = 0;
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();

            int[,] GamePostionScore = new int[,] {
            { 100, -20, 20, 5, 5, 20, -20, 100},
            {-20 , -30, -5, -5, -5, -5, -30, -20},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-20 , -30, -5, -5, -5, -5, -30, -20},
            {100 , -20, 20, 5, 5, 20, -20, 100}
        };

            Board board1 = (Board)board.Clone();
            // board1.PutAndAlsoSwithCurrentTurn(2, 3, Board.PlayerColor.Black);
            board1.SetCellsByRow(2, "   BBB B");
            board1.SetCellsByRow(3, "   BBWBB");
            board1.SetCellsByRow(4, "  BWWWBB");
            board1.SetCellsByRow(5, " BBWWBBB");
            board1.SetCellsByRow(6, "   BBB B");
            board1.SetCellsByRow(7, " BBBBBW ");

            Result = Evu.Calculate(board1, true, Board.PlayerColor.White,
              botScore,
              OpponentScore,
              GamePostionScore,
              StableDiskScore,
              MobilityScore,
              IsUsingPositionScore);

            board1.SetCellsByRow(5, " BBWWWBB");
            board1.SetCellsByRow(6, "   BBBWB");
            board1.SetCellsByRow(7, "  BBBBW ");

            Result = Evu.Calculate(board1, true, Board.PlayerColor.White,
  botScore,
  OpponentScore,
  GamePostionScore,
  StableDiskScore,
  MobilityScore,
  IsUsingPositionScore);
            Test.Assert(botScore.DiskCount == 9);
            Test.Assert(botScore.NoofPossibleMove == 14);

            Test.Assert(botScore.ScorePassWeight == 0);
            Test.Assert(botScore.ScorePositionWeight == -17);
            Test.Assert(botScore.ScoreStableDiskWeight == 0);
            Test.Assert(botScore.ScoreDiskCanFlip == 840);
            Test.Assert(botScore.ScoreDiskCanFlip == botScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(botScore.GetTotalScore() == 823);

            Test.Assert(OpponentScore.DiskCount == 23);
            Test.Assert(OpponentScore.NoofPossibleMove == 2);

            Test.Assert(OpponentScore.ScorePassWeight == 0);
            Test.Assert(OpponentScore.ScorePositionWeight == 90);
            Test.Assert(OpponentScore.ScoreStableDiskWeight == 0);
            Test.Assert(OpponentScore.ScoreDiskCanFlip == 180);
            Test.Assert(OpponentScore.ScoreDiskCanFlip == OpponentScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(OpponentScore.GetTotalScore() == 270);

            ResultScore = botScore - OpponentScore;

            Test.Assert(ResultScore.DiskCount == -14);
            Test.Assert(ResultScore.NoofPossibleMove == 12);

            Test.Assert(ResultScore.ScorePassWeight == 0);
            Test.Assert(ResultScore.ScorePositionWeight == -107);
            Test.Assert(ResultScore.ScoreStableDiskWeight == 0);
            Test.Assert(ResultScore.ScoreDiskCanFlip == 660);
            Test.Assert(ResultScore.ScoreDiskCanFlip == ResultScore.NoofDiskCanFlip * MobilityScore);
            Test.Assert(ResultScore.GetTotalScore() == 553);


        }
        [TestMethod]
        public void ScoreFromPosition()
        {
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;
            int BotScore = 0;
            int OpponenetScore = 0;
            int BotDiskCount = 0;
            int OpponentDiskCount = 0;
            //  Board boardN = (Board)board.Clone();
            Evu.GetScoreFromPosition(board, All1GamePostionScore, Board.PlayerColor.Black, ref BotScore, ref OpponenetScore, ref BotDiskCount, ref OpponentDiskCount);


            Test.Assert(BotScore == 2);
            Test.Assert(OpponenetScore == 2);
            Test.Assert(BotDiskCount == 2);
            Test.Assert(OpponentDiskCount == 2);

            Evu.GetScoreFromPosition(board, All0GamePostionScore, Board.PlayerColor.Black, ref BotScore, ref OpponenetScore, ref BotDiskCount, ref OpponentDiskCount);
            Test.Assert(BotScore == 0);
            Test.Assert(OpponenetScore == 0);
            Test.Assert(BotDiskCount == 2);
            Test.Assert(OpponentDiskCount == 2);

            board.SetCell(0, 0, Board.CellValue.Black);
            board.SetCell(0, 1, Board.CellValue.White);
            board.SetCell(1, 0, Board.CellValue.White);
            board.SetCell(1, 1, Board.CellValue.White);

            Evu.GetScoreFromPosition(board, All1GamePostionScore, Board.PlayerColor.Black, ref BotScore, ref OpponenetScore, ref BotDiskCount, ref OpponentDiskCount);
            Test.Assert(BotScore == 3);
            Test.Assert(OpponenetScore == 5);
            Test.Assert(BotDiskCount == 3);
            Test.Assert(OpponentDiskCount == 5);


            Evu.GetScoreFromPosition(board, OpenGamePostionScore, Board.PlayerColor.Black, ref BotScore, ref OpponenetScore, ref BotDiskCount, ref OpponentDiskCount);
            Test.Assert(BotScore == 106);
            Test.Assert(OpponenetScore == -64);
            Test.Assert(BotDiskCount == 3);
            Test.Assert(OpponentDiskCount == 5);

        }
        [TestMethod]
        public void NoofDiskCanbeFlipped()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            //  Board boardN = (Board)board.Clone();

            List<Position> possibleMove = board.generateMoves();
            Result = Evu.GetNoofDiskCanBeFlipped(board, Board.PlayerColor.Black, possibleMove);
            Test.Assert(Result == 4);



        }

        [TestMethod]
        public void StablefromCornerTopLeft()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            //  Board boardN = (Board)board.Clone();

            BasicMiniMaxEvaluate.Corner corner = BasicMiniMaxEvaluate.Corner.TopLeft;
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 0);


            board.SetCellsByRow(0, "BBBWW   ");
            board.SetCellsByRow(1, "BBWWW   ");
            board.SetCellsByRow(2, "B       ");

            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(1, "BBBWW   ");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(2, "BB      ");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);


            board.SetCellsByRow(0, "BBBWW   ");
            board.SetCellsByRow(1, "BBWWW   ");
            board.SetCellsByRow(2, "        ");
            board.SetCellsByRow(3, "B       ");

            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 5);
        }
        [TestMethod]
        public void StablefromCornerTopRight()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            //  Board boardN = (Board)board.Clone();

            BasicMiniMaxEvaluate.Corner corner = BasicMiniMaxEvaluate.Corner.TopRight;
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 0);


            board.SetCellsByRow(0, "   WWBBB");
            board.SetCellsByRow(1, "   WWWBB");
            board.SetCellsByRow(2, "       B");

            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(1, "   WWBBB");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(2, "      BB");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);


            board.SetCellsByRow(0, "   WWBBB");
            board.SetCellsByRow(1, "   WWWBB");
            board.SetCellsByRow(2, "        ");
            board.SetCellsByRow(3, "       B");

            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 5);
        }
        [TestMethod]
        public void StablefromCornerBottomLeft()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            //  Board boardN = (Board)board.Clone();

            BasicMiniMaxEvaluate.Corner corner = BasicMiniMaxEvaluate.Corner.BottomLeft;
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 0);




            board.SetCellsByRow(5, "B       ");
            board.SetCellsByRow(6, "BBWWW   ");
            board.SetCellsByRow(7, "BBBWW   ");

            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(6, "BBBWW   ");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(5, "BB      ");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);





            board.SetCellsByRow(4, "B       ");
            board.SetCellsByRow(5, "        ");
            board.SetCellsByRow(6, "BBWWW   ");
            board.SetCellsByRow(7, "BBBWW   ");

            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 5);
        }


        [TestMethod]
        public void StablefromCornerBottomRight()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            //  Board boardN = (Board)board.Clone();

            BasicMiniMaxEvaluate.Corner corner = BasicMiniMaxEvaluate.Corner.BottomRigth;
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 0);




            board.SetCellsByRow(5, "       B");
            board.SetCellsByRow(6, "   WWWBB");
            board.SetCellsByRow(7, "   WWBBB");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(6, "   WWBBB");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);

            board.SetCellsByRow(5, "      BB");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 6);





            board.SetCellsByRow(4, "       B");
            board.SetCellsByRow(5, "        ");
            board.SetCellsByRow(6, "   WWWBB");
            board.SetCellsByRow(7, "   WWBBB");
            Result = Evu.GetNumberofStableDiscsFromCorner(board, Board.PlayerColor.Black, corner);
            Test.Assert(Result == 5);
        }
        [TestMethod]
        public void StablefromEdgeNorth()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            Board boardN = (Board)board.Clone();



            BasicMiniMaxEvaluate.NEWS news = BasicMiniMaxEvaluate.NEWS.North;

            boardN.SetCellsByRow(0, "WWBBBBBW");

            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 5);


            boardN.SetCellsByRow(0, "WWBBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);



            boardN.SetCellsByRow(0, "WBWBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 1);


            boardN.SetCellsByRow(0, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByRow(0, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.White, news);
            Test.Assert(Result == 0);



            boardN.SetCellsByRow(0, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByRow(0, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.White, news);
            Test.Assert(Result == 6);
        }





        [TestMethod]
        public void StablefromEdgeEast()
        {
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            Board boardE = (Board)board.Clone();



            BasicMiniMaxEvaluate.NEWS news = BasicMiniMaxEvaluate.NEWS.East;

            boardE.SetCellsByColumn(7, "WWBBBBBW");

            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 5);


            boardE.SetCellsByColumn(7, "WWBBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);



            boardE.SetCellsByColumn(7, "WBWBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 1);


            boardE.SetCellsByColumn(7, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByColumn(7, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.White, news);
            Test.Assert(Result == 0);



            boardE.SetCellsByColumn(7, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByColumn(7, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.White, news);
            Test.Assert(Result == 6);
        }

        [TestMethod]
        public void StablefromEdgeWest()
        {
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            Board boardE = (Board)board.Clone();



            BasicMiniMaxEvaluate.NEWS news = BasicMiniMaxEvaluate.NEWS.West;

            boardE.SetCellsByColumn(0, "WWBBBBBW");

            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 5);


            boardE.SetCellsByColumn(0, "WWBBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);



            boardE.SetCellsByColumn(0, "WBWBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 1);


            boardE.SetCellsByColumn(0, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByColumn(0, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.White, news);
            Test.Assert(Result == 0);



            boardE.SetCellsByColumn(0, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByColumn(7, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardE, Board.PlayerColor.White, news);
            Test.Assert(Result == 6);
        }


        [TestMethod]
        public void StablefromEdgeSouth()
        {

            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            int Result = 0;

            Board boardN = (Board)board.Clone();



            BasicMiniMaxEvaluate.NEWS news = BasicMiniMaxEvaluate.NEWS.South;

            boardN.SetCellsByRow(7, "WWBBBBBW");

            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 5);


            boardN.SetCellsByRow(7, "WWBBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);



            boardN.SetCellsByRow(7, "WBWBBBBB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 1);


            boardN.SetCellsByRow(7, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByRow(0, "WWWWWWWW");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.White, news);
            Test.Assert(Result == 0);



            boardN.SetCellsByRow(7, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.Black, news);
            Test.Assert(Result == 0);

            // boardN.SetCellsByRow(0, "BWWWWWWB");
            Result = Evu.GetStableDiscsFromFullEdge(boardN, Board.PlayerColor.White, news);
            Test.Assert(Result == 6);
        }
        [TestMethod]
        public void IsEdgeFull()
        {
            //IsEdgeFullV2
            // MiniMax3 m = new MiniMax3();
            Board board = BoardUtil.CreateStandardReversiBoard();
            BasicMiniMaxEvaluate Evu = new BasicMiniMaxEvaluate();
            Test.Assert(!Evu.IsEdgeFull(board, BasicMiniMaxEvaluate.NEWS.North));
            Test.Assert(!Evu.IsEdgeFull(board, BasicMiniMaxEvaluate.NEWS.East));
            Test.Assert(!Evu.IsEdgeFull(board, BasicMiniMaxEvaluate.NEWS.West));
            Test.Assert(!Evu.IsEdgeFull(board, BasicMiniMaxEvaluate.NEWS.South));

            Board boardN = (Board)board.Clone();
            Board boardE = (Board)board.Clone();
            Board boardW = (Board)board.Clone();
            Board boardS = (Board)board.Clone();

            int i;
            for (i = 0; i < 8; i++)
            {

                boardN.SetCell(0, i, Board.CellValue.Black);
                boardE.SetCell(i, 7, Board.CellValue.Black);
                boardW.SetCell(i, 0, Board.CellValue.Black);
                boardS.SetCell(7, i, Board.CellValue.Black);

            }

            Test.Assert(Evu.IsEdgeFull(boardN, BasicMiniMaxEvaluate.NEWS.North));
            Test.Assert(Evu.IsEdgeFull(boardE, BasicMiniMaxEvaluate.NEWS.East));
            Test.Assert(Evu.IsEdgeFull(boardW, BasicMiniMaxEvaluate.NEWS.West));
            Test.Assert(Evu.IsEdgeFull(boardS, BasicMiniMaxEvaluate.NEWS.South));




        }
    }
}
