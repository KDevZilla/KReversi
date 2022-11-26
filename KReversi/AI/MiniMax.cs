using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public class MiniMax
    {
        private IEvaluate EvaluateObject = null;

        private static MiniMaxParameterExtend _MiniMaxForDebug = null;
        public static MiniMaxParameterExtend MiniMaxForDebug => _MiniMaxForDebug;

        public static void ClearMinimaxForDebug() => _MiniMaxForDebug = null;
        int NodeCount = 0;
        int EvaluateCount = 0;

        private DateTime EndTime;
        private Boolean IsExceedTimeLimitPermove()
        {
            DateTime CurrentTime = DateTime.Now;

            return CurrentTime.TimeOfDay > EndTime.TimeOfDay;

        }
        public Position calculateNextMove(IBoard board,
            int depth,
            IEvaluate pEvaluateObject,
            Board.PlayerColor BotColor,
            int SecondsLimitPerMove,
            Boolean IsUsingAlphaBeta,
            Boolean IsKeepingChildValue,
            Boolean IsUsingRandomIfNodeValueIsTheSame,
            Boolean IsSortedNode)
        {

            Log("CalculateNextMove begin");

            EvaluateObject = pEvaluateObject;

            //  EvaluateObject = new Evaluate1();

            Position move = new Position(-1, -1);




            PositionScore bestMove = new PositionScore();



            MiniMaxParameterExtend Para = new MiniMaxParameterExtend();

            Para.Depth = depth - 1;
            Para.board = (Board)board.Clone();
            Para.IsMax = true;
            Para.Alpha = int.MinValue;
            Para.Beta = int.MaxValue;
            Para.BotColor = BotColor;
            NodeCount = 0;
            EvaluateCount = 0;
            EndTime = DateTime.Now.AddSeconds(SecondsLimitPerMove);
            Log("CalculateNextMove :: SecondLimitPerMove ::" + SecondsLimitPerMove);
            Log("CalculateNextMove :: Depth ::" + Para.Depth);


            Utility.TimeMeasure timeM = new Utility.TimeMeasure();
            iCountHashCanAccess = 0;
            timeM.Start();
            this.FirstLevelDepth = Para.Depth;
            listFirstLevelDepthMoves = new List<PositionScore>();
            PositionScore score = MinimaxAlphaBetaExtend(Para,
                IsUsingAlphaBeta,
                IsKeepingChildValue,
                IsSortedNode);
            move = new Position(score.Row,
                score.Col);
            timeM.Finish();
            int i;
            Log("CalculateNextMove :: [" + score.Row + "," + score.Col + "]");
            Log("CalculateNextMove :: Score::" + score.Score);
            Log("CalculateNextMove :: iCountHashCanAccess::" + iCountHashCanAccess);
            Log("CalculateNextMove ::  Before Get Random");

            // Boolean IsUsingRandomIfNodeValueIsTheSame =true    ;
            // IsUsingRandomIfNodeValueIsTheSame = false;
            if (Para.board.NumberofBothDisk() <= 14)
            {
                if (IsUsingRandomIfNodeValueIsTheSame)
                {
                    Log("CalculateNextMove ::  IsUsingRandomIfNodeValueIsTheSame");
                    score = GetRandomFromMaxScoreNode(listFirstLevelDepthMoves);

                    move = new Position(score.Row,
                        score.Col);

                }
            }
            /*
            if (((Board)Para.board).NumberofBothDisk() <= 64)
            {
               
            }
            */


            //NodeCount = 0;
            Log("CalculateNextMove :: hashTranportable :: " + hashTranportable.NumberofNodeCount());

            Log("CalculateNextMove :: [" + score.Row + "," + score.Col + "]");
            Log("CalculateNextMove :: Score::" + score.Score);


            Log("CalculateNextMove :: NodeCount ::" + NodeCount);
            Log("CalculateNextMove :: EvaluateCount ::" + EvaluateCount);
            Log("CalculateNextMove :: Time takes (Seconds)::" + timeM.TimeTakes.Milliseconds / 1000.00);
            Log("CalculateNextMove End");

            ClearMinimaxForDebug();
            _MiniMaxForDebug = Para;
            Utility.SerializeUtility.SerializeMiniMaxParameterExtend(_MiniMaxForDebug,
                Utility.FileUtility.MiniMaxParameterForDebugFilePath
                );

            return move;

        }
        private PositionScore GetRandomFromMaxScoreNode(List<PositionScore> plistFirstLevelDepthMoves)
        {
            Log("GetRandomFromMaxScoreNode Begin");
            if (plistFirstLevelDepthMoves == null ||
                plistFirstLevelDepthMoves.Count == 0)
            {
                throw new Exception("plistFirstLevelDepthMoves is null");
            }

            List<PositionScore> SortedList = plistFirstLevelDepthMoves.OrderByDescending(o => o.Score).ToList();
            int i = 0;
            PositionScore resultPosition = null;
            if (SortedList.Count > 0)
            {
                int iMaxScore = SortedList[0].Score;
                Log("   GetRandomFromMaxScoreNode :: " + iMaxScore);
                Log("   GetRandomFromMaxScoreNode Before Cut Node that Score is less than " + iMaxScore);
                for (i = 0; i < SortedList.Count; i++)
                {
                    Log("   GetRandomFromMaxScoreNode :: " + SortedList[i].PositionString() +
                        " :: " + SortedList[i].Score);
                }

                for (i = SortedList.Count - 1; i >= 0; i--)
                {
                    if (SortedList[i].Score >= iMaxScore)
                    {
                        break;
                    }
                    SortedList.RemoveAt(i);
                }
                Log("   GetRandomFromMaxScoreNode After Cut Node that Score is less than " + iMaxScore);
                for (i = 0; i < SortedList.Count; i++)
                {
                    Log("   GetRandomFromMaxScoreNode :: " + SortedList[i].PositionString() +
                        " :: " + SortedList[i].Score);
                }
                int randomIndex = Utility.Utility.GetRandomNumber(0, SortedList.Count - 1);
                resultPosition = SortedList[randomIndex];
                /*
                resultPosition = new Position ( SortedList[randomIndex].Row ,
                    SortedList[randomIndex].Col );
                */
                Log("   GetRandomFromMaxScoreNode :: randomIndex ::" + randomIndex);

            }
            Log("   GetRandomFromMaxScoreNode End");
            return resultPosition;

        }
        private void Log(String message)
        {
            SimpleLog.WriteLog(message);
        }
        private void LogDebug(String message)
        {


            SimpleLog.WriteDebugLog(message);
        }

        private string Tab(int depth)
        {
            int NMaxLevel = 11;
            //return "D_" + depth + new string('\t', depth + 1);
            return "D_" + depth + new string('\t', NMaxLevel - depth);
        }
        private int FirstLevelDepth = 0;
        private List<PositionScore> listFirstLevelDepthMoves = null;
        private Hash hashTranportable = new Hash();
        private int iCountHashCanAccess = 0;



        private PositionScore MinimaxAlphaBetaExtend(
         MiniMaxParameterExtend Para,
         Boolean IsUsingAlphaBeta,
         Boolean IsKeepingChildValue,
         Boolean IsSortedNode
        )
        {

            String tab = Tab(Para.Depth);
            String methodName = tab + "Minimax::";
            NodeCount++;


            Board.PlayerColor DiskColor = Para.BotColor;
            Board.PlayerColor OpponentColor = ((Board)Para.board).GetOponentValue(Para.BotColor);
            //            Board.PlayerColor BotColor = Board.PlayerColor.Black;
            LogDebug(methodName + "IsMax::" + Para.IsMax);
            if (!Para.IsMax)
            {
                DiskColor = OpponentColor;
            }
            Boolean IsMyTurn = false;
            if (DiskColor == Para.BotColor)
            {
                IsMyTurn = true;
            }
            if (IsExceedTimeLimitPermove())
            {
                LogDebug(methodName + " Exceed Time");

            }
            bool IsNeedtoPass = false;

            List<Position> avilableMovePositions = new List<Position>();
            bool isFinalMove = false;
            if (Para.Depth <= 0 || IsExceedTimeLimitPermove())
            {
                isFinalMove = true;
            }

            LogDebug(methodName + "IsFinalMove::" + isFinalMove);
            if (!isFinalMove)
            {

                avilableMovePositions = Para.board.generateMoves();
                if (avilableMovePositions.Count == 0)
                {
                    LogDebug(methodName + "possbileMove.Count of " + DiskColor + "is 0 ");
                    IsNeedtoPass = true;
                    List<Position> avilableMovePositionsForOppositeColor = null;
                    if (DiskColor == Para.BotColor)
                    {
                        avilableMovePositionsForOppositeColor = ((Board)Para.board).generateMoves(OpponentColor);
                        DiskColor = OpponentColor;
                        LogDebug(methodName + "Gen possbileMove from OpponentColor it is " + avilableMovePositions.Count);

                    }
                    else
                    {
                        avilableMovePositionsForOppositeColor = ((Board)Para.board).generateMoves(Para.BotColor);

                        DiskColor = Para.BotColor;
                        LogDebug(methodName + "Gen possbileMove from BotColor it is " + avilableMovePositions.Count);
                    }

                    avilableMovePositions = avilableMovePositionsForOppositeColor;
                }

                if (avilableMovePositions.Count == 0)
                {
                    isFinalMove = true;
                }

            }

            PositionScore BestScore = new PositionScore(-1, -1);

            if (isFinalMove)
            {
                //   int Score = this.EvaluateBoard(Para.board);


                int BoardHash = Hash.GetHashForBoard(Para.board);
                int Score = 0;
                if (hashTranportable.ContainEvalScore(BoardHash))
                {
                    iCountHashCanAccess++;
                    Score = hashTranportable.GetEvalScore(BoardHash);
                }
                else
                {

                    //  Score = this.EvaluateBoardV2((Board)Para.board, IsMyTurn, Para.BotColor);
                    EvaluateCount++;
                    Score = this.EvaluateObject.evaluateBoard(Para.board, IsMyTurn, Para.BotColor);

                    // Score = this.EvaluateBoard(Para.board);
                    hashTranportable.AddEvalScore(BoardHash, Score);
                    LogDebug("hashPutEvalScore::" + Para.board.LastPutPosition.PositionString());

                }

                LogDebug(methodName + "Score::" + Score);
                BestScore = new PositionScore(Score, -1, -1);
                return BestScore;

            }

            //int bestBoardValue = 0;
            BestScore = new PositionScore(int.MaxValue, -1, -1);
            if (Para.IsMax)
            {
                BestScore.Score = int.MinValue;
            }
            if (IsSortedNode && Para.Depth >= this.FirstLevelDepth - 1)
            {
                LogDebug(methodName + "IsSortedNode is true");
                List<PositionScore> lstPostion = new List<PositionScore>();

                Dictionary<int, Board> DicBoard = new Dictionary<int, Board>();
                LogDebug(methodName + "Begin calculate score");
                foreach (Position nextMove in avilableMovePositions)
                {
                    Board tempBoard = (Board)Para.board.Clone();

                    tempBoard.PutAndAlsoSwithCurrentTurn(nextMove, DiskColor);

                    EvaluateCount++;
                    int Score = this.EvaluateObject.evaluateBoard(tempBoard, IsMyTurn, Para.BotColor);


                    lstPostion.Add(new PositionScore(Score, nextMove.Row, nextMove.Col));
                    DicBoard.Add(nextMove.GetHashCode(), tempBoard);

                    LogDebug(methodName + "   Score::" + Score);
                    LogDebug(methodName + "        move::" + nextMove.PositionString());
                }
                LogDebug(methodName + "End calculate score");
                List<PositionScore> SortedList = null;

                if (Para.IsMax)
                {
                    SortedList = lstPostion.OrderByDescending(o => o.Score).ToList();
                }
                else
                {
                    SortedList = lstPostion.OrderBy(o => o.Score).ToList();
                }

                //foreach (Position move in allPossibleMoves)
                LogDebug("Max Begin ViewSortedList");
                avilableMovePositions.Clear();
                foreach (PositionScore move in SortedList)
                {
                    LogDebug(methodName + "   Score::" + move.Score);
                    LogDebug(methodName + "        move::" + move.PositionString());

                    avilableMovePositions.Add(new Position(move.Row, move.Col));
                }
                // avilableMovePositions = SortedList.ToList();
            }

            LogDebug(methodName + "Before loop");
            foreach (Position nextMove in avilableMovePositions)
            {

                LogDebug(methodName + "  position[" + nextMove.Row + "," + nextMove.Col + "]");
                MiniMaxParameterExtend childPara = Para.CloneExtend();


                LogDebug(methodName + "DiskColor::" + DiskColor);

                ((Board)childPara.board).PutAndAlsoSwithCurrentTurn(nextMove, DiskColor);
                LogDebug(methodName + " After put");
                if (IsKeepingChildValue)
                {
                    Para.child.Add(childPara);
                }


                childPara.IsMax = !Para.IsMax;

                if (IsNeedtoPass)
                {

                    childPara.IsMax = Para.IsMax;
                    ((Board)childPara.board).SwitchTurnDueToPlayerPass();
                }

                childPara.Depth--;

                int Score = 0;
                int BoardHash = Hash.GetHashForBoard(childPara.board);

                PositionScore childScore = null;
                int ScoreFromHash = hashTranportable.GetScore(BoardHash, childPara.Depth);
                if (ScoreFromHash != Hash.ScoreForNonExist)
                {
                    iCountHashCanAccess++;
                    childScore = new PositionScore(hashTranportable.GetScore(BoardHash, childPara.Depth));
                }
                else
                {
                    childScore = this.MinimaxAlphaBetaExtend(childPara, IsUsingAlphaBeta, IsKeepingChildValue, IsSortedNode);
                    hashTranportable.Add(BoardHash, childScore.Score, childPara.Depth);
                    LogDebug("hashPut::" + nextMove.PositionString() + " depth::" + childPara.Depth + "::CUrrentTurn:: " + childPara.board.CurrentTurn + " :: BoardHash::" + BoardHash);
                    //hashTranportable.Add(BoardHash, childScore.Score);
                }
                childPara.PositionScore = new PositionScore(childScore.Score, nextMove);



                if (Para.Depth == this.FirstLevelDepth)
                {
                    LogDebug("First Level::" + nextMove.PositionString() + "   ::" + childScore.Score);
                    listFirstLevelDepthMoves.Add(new PositionScore(childScore.Score, nextMove));

                }
                LogDebug(methodName + "  childScore.Score::" + childScore.Score);
                if (Para.IsMax)
                {
                    LogDebug(methodName + "  BestScore.Score::" + BestScore.Score);
                    if (childScore.Score > BestScore.Score)
                    {
                        LogDebug(methodName + "  childScore.Score  > BestScore.Score");
                        BestScore = new PositionScore(childScore.Score, nextMove);
                        if (IsUsingAlphaBeta)
                        {
                            Para.Alpha = Math.Max(BestScore.Score, Para.Alpha);

                            if (Para.Beta < BestScore.Score)
                            {
                                LogDebug(methodName + "  BoardValue >= Beta");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    LogDebug(methodName + "  BestScore.Score::" + BestScore.Score);
                    if (childScore.Score < BestScore.Score)
                    {
                        LogDebug(methodName + "  childScore.Score  < BestScore.Score");

                        BestScore = new PositionScore(childScore.Score, nextMove);
                        if (IsUsingAlphaBeta)
                        {
                            Para.Beta = Math.Min(Para.Beta, BestScore.Score);

                            if (BestScore.Score <= Para.Alpha)
                            {
                                LogDebug(methodName + "  BoardValue <= Alpha");
                                break;
                            }
                        }
                    }
                }
            }
            LogDebug(methodName + "After Loop");
            return BestScore;

        }




    }
}
