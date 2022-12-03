using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public interface IEvaluate
    {
        int evaluateBoard(Board board, Boolean IsMyturn, Board.PlayerColor BotColor);
        int getScore(Board board, Boolean IsMyTurn, Board.PlayerColor BotColor);

    }

    [Serializable]
    public class BasicMiniMaxEvaluate : IEvaluate
    {
        public class EvaluateScore
        {
            public int DiskCount { get; set; } = 0;

            public int NoofPossibleMove { get; set; } = 0;
            public int NoofStableDisk { get; set; } = 0;
            public int NoofDiskCanFlip { get; set; } = 0;

            public int ScoreStableDiskWeight { get; set; } = 0;
            public int ScorePositionWeight { get; set; } = 0;
            public int ScorePassWeight { get; set; } = 0;
            // public int ScoreAvilableMoveWeight { get; set; } = 0;
            public int ScoreDiskCanFlip { get; set; } = 0;
            public int GetTotalScore()
            {
                return ScoreStableDiskWeight +
                    ScorePositionWeight +
                    ScorePassWeight +
                    //  ScoreAvilableMoveWeight +
                    ScoreDiskCanFlip;
            }
            public override String ToString()
            {
                return Environment.NewLine +
                    "NoofPossibleMove::" + NoofPossibleMove + Environment.NewLine +
                    "NoofStableDisk::" + NoofStableDisk + Environment.NewLine +
                    "ScoreStableDiskWeight::" + ScoreStableDiskWeight + Environment.NewLine +
                    "ScorePositionWeight::" + ScorePositionWeight + Environment.NewLine +
                    "ScorePassWeight::" + ScorePassWeight + Environment.NewLine +
                    // "ScoreAvilableMoveWeight::" + ScoreAvilableMoveWeight + Environment.NewLine +
                    "ScoreDiskCanFlip::" + ScoreDiskCanFlip + Environment.NewLine;

            }
            public static EvaluateScore operator -(EvaluateScore a, EvaluateScore b)
            {
                EvaluateScore newEvalScore = new EvaluateScore();
                newEvalScore.DiskCount = a.DiskCount - b.DiskCount;
                newEvalScore.NoofPossibleMove = a.NoofPossibleMove - b.NoofPossibleMove;
                newEvalScore.NoofStableDisk = a.NoofStableDisk - b.NoofStableDisk;
                newEvalScore.NoofDiskCanFlip = a.NoofDiskCanFlip - b.NoofDiskCanFlip;

                newEvalScore.ScoreStableDiskWeight = a.ScoreStableDiskWeight - b.ScoreStableDiskWeight;
                newEvalScore.ScorePositionWeight = a.ScorePositionWeight - b.ScorePositionWeight;
                newEvalScore.ScorePassWeight = a.ScorePassWeight - b.ScorePassWeight;
                // newEvalScore.ScoreAvilableMoveWeight = a.ScoreAvilableMoveWeight - b.ScoreAvilableMoveWeight;

                newEvalScore.ScoreDiskCanFlip = a.ScoreDiskCanFlip - b.ScoreDiskCanFlip;
                return newEvalScore;
            }



        }


        public int ForcePassSocre { get; set; }
        public int StableDiskScore { get; set; }
        public int TimeLimitPermove { get; set; }
        // public Boolean AllowRandom { get; set; }
        public Boolean IsUseScoreFromPosition { get; set; }
        public BasicMiniMaxEvaluate()
        {

        }
        public BasicMiniMaxEvaluate(MiniMaxBotProto botProto)
        {
            this.ScoreNumberMoveAtBegingGame = botProto.ScoreNumberMoveAtBegingGame;
            this.ScoreNumberMoveAtMiddleGame = botProto.ScoreNumberMoveAtMiddleGame;
            this.ScoreNumberMoveAtEndGame = botProto.ScoreNumberMoveAtEndGame;
            this.OpenGamePostionScore = botProto.OpenGamePostionScore;
            this.MidGamePostionScore = botProto.MidGamePostionScore;
            this.EndGamePostionScore = botProto.EndGamePostionScore;
            this.ForcePassSocre = botProto.ForcePassSocre;
            this.StableDiskScore = botProto.StableDiskScore;
            this.TimeLimitPermove = botProto.TimeLimitPermove;
            this.IsUseScoreFromPosition = botProto.IsUseScoreFromPosition;
            // this.AllowRandom = botProto.AllowRandom;
        }
        private void LogDebugL2(String message)
        {



            SimpleLog.WriteDebugLogL2("Evaluate::" + message);
        }
        private void Log(String message)
        {


            SimpleLog.WriteLog("Evaluate::" + message);
        }
        public int evaluateBoard(Board board, Boolean IsMyturn, Board.PlayerColor BotColor)
        {

            if (Global.CurrentSettings.IsWriteDebugLogL2)
            {
                LogDebugL2(Environment.NewLine + ((Board)board).ToString());
            }
            int EvaluateScore = getScore(board, IsMyturn, BotColor);
            LogDebugL2("EvaluateScore::" + EvaluateScore);
            return EvaluateScore;
        }
        public int ScoreNumberMoveAtBegingGame { get; private set; }
        public int ScoreNumberMoveAtMiddleGame { get; private set; }
        public int ScoreNumberMoveAtEndGame { get; private set; }
        public int ScoreNumberMove(Board.BoardPhaseEnum BoardPhase)
        {
            switch (BoardPhase)
            {
                case Board.BoardPhaseEnum.Begining:
                    return ScoreNumberMoveAtBegingGame;
                case Board.BoardPhaseEnum.Middle:
                    return ScoreNumberMoveAtMiddleGame;
                case Board.BoardPhaseEnum.EndGame:
                    return ScoreNumberMoveAtEndGame;
                default:
                    return 10;
            }

        }
        public int[,] PositionScore(Board.BoardPhaseEnum BoardPhase)
        {
            switch (BoardPhase)
            {
                case Board.BoardPhaseEnum.Begining:
                    return OpenGamePostionScore;
                case Board.BoardPhaseEnum.Middle:
                    return MidGamePostionScore;
                case Board.BoardPhaseEnum.EndGame:
                    return EndGamePostionScore;
                default:
                    throw new Exception("BoardPhase is incorrect ");
            }



        }
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

        private int[,] MidGamePostionScore = new int[,] {
            { 140, -20, 20, 5, 5, 20, -20, 140},
            {-20 , -40, -5, -5, -5, -5, -40, -20},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-20 , -40, -5, -5, -5, -5, -40, -20},
            {140 , -20, 20, 5, 5, 20, -20, 140}
        };

        private int[,] EndGamePostionScore = new int[,] {
            { 140, -20, 20, 5, 5, 20, -20, 140},
            {-20 , -40, -5, -5, -5, -5, -40, -20},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-20 , -40, -5, -5, -5, -5, -40, -20},
            {140 , -20, 20, 5, 5, 20, -20, 14}
        };
        public void SetOpenGamePostionScore(int[,] pOpenGamePostionScore)
        {
            this.OpenGamePostionScore = pOpenGamePostionScore;
        }
        public void SetMidGamePostionScore(int[,] pMidGamePostionScore)
        {
            this.MidGamePostionScore = pMidGamePostionScore;
        }

        public void SetEndGamePostionScore(int[,] pEndGamePostionScore)
        {
            this.EndGamePostionScore = pEndGamePostionScore;
        }

        /*
         * Please don't use int.Max nor int.Min as WonScore or LostSocre
         * Those value we use it with alpha beta
         */

        private int WonScore = 1000000;
        private int LostScore = -1000000;
        private int BoardSize = 8;
        public void GetScoreFromPosition(Board board, int[,] ppositionScore,
            Board.PlayerColor BotColor,
            EvaluateScore botEvaScore, EvaluateScore opponeetEvaScore)
        {
            int BotScore = 0;
            int OpponentScore = 0;
            int BotDiskCount = 0;
            int OpponentDiskCount = 0;
            GetScoreFromPosition(board, ppositionScore,
                BotColor,
                ref BotScore,
                ref OpponentScore,
                ref BotDiskCount,
                ref OpponentDiskCount);
            botEvaScore.ScorePositionWeight = BotScore;
            botEvaScore.DiskCount = BotDiskCount;

            opponeetEvaScore.ScorePositionWeight = OpponentScore;
            opponeetEvaScore.DiskCount = OpponentDiskCount;


        }


        public void GetScoreFromPosition(Board board, int[,] ppositionScore,
            Board.PlayerColor BotColor,
            ref int BotScore,
            ref int OpponentScore,
            ref int BotDiskCount,
            ref int OpponentDiskCount)
        {
            int iRow = 0;
            int iCol = 0;

            BotScore = 0;
            OpponentScore = 0;
            BotDiskCount = 0;
            OpponentDiskCount = 0;

            for (iRow = 0; iRow < BoardSize; iRow++)
            {
                for (iCol = 0; iCol < BoardSize; iCol++)
                {
                    //DisCount += (int)board.boardMatrix[iRow, iCol];
                    if (board.boardMatrix[iRow, iCol] == 0)
                    {
                        continue;
                    }

                    if (BotColor == (Board.PlayerColor)board.boardMatrix[iRow, iCol])
                    {
                        BotScore += ppositionScore[iRow, iCol];
                        BotDiskCount++;

                    }
                    else
                    {
                        OpponentScore += ppositionScore[iRow, iCol];
                        OpponentDiskCount++;
                    }
                }
            }

            // return ScorePositionWeight;
        }

        public int getScore(Board board, bool IsMyTurn, Board.PlayerColor BotColor)
        {
            var boardphase = board.BoardPhase;
            EvaluateScore BotScore = new EvaluateScore();
            EvaluateScore OpponentScore = new EvaluateScore();

            bool IsUseStatbleDiskScore = this.StableDiskScore != 0;
            bool IsUseAvailableScore = this.ScoreNumberMove(boardphase) != 0;
            // bool IsUseScoreFromPosition = true;

            LogDebugL2("IsUseStatbleDiskScore::" + IsUseStatbleDiskScore);
            LogDebugL2("IsUseAvailableScore::" + IsUseAvailableScore);
            LogDebugL2("IsUseScoreFromPosition::" + IsUseScoreFromPosition);

            int[,] positionScore = PositionScore(boardphase);

            return Calculate(board, IsMyTurn, BotColor,
                BotScore,
                OpponentScore,
                positionScore,
                this.StableDiskScore,
                this.ScoreNumberMove(boardphase),
                IsUseScoreFromPosition);

        }
        public int Calculate(Board board, bool IsMyTurn, Board.PlayerColor BotColor,
            EvaluateScore BotScore,
            EvaluateScore OpponentScore,
            int[,] ppositionScore,
            int StableDiskScore,
            int MobilityPieceScore,
            Boolean IsUseScoreFromPosition)
        {

            bool IsUseStatbleDiskScore = StableDiskScore != 0;

            LogDebugL2("IsUseStatbleDiskScore::" + IsUseStatbleDiskScore);
            LogDebugL2("IsUseScoreFromPosition::" + IsUseScoreFromPosition);

            Board.PlayerColor OppoColor = board.GetOponentValue(BotColor); // ((Board)board).OpponentTurn;
            List<Position> listNoofPossibleMoveForBot = board.generateMoves(BotColor);
            List<Position> listNoofPossibleMoveForOpponent = board.generateMoves(OppoColor);
            BotScore.NoofPossibleMove = listNoofPossibleMoveForBot.Count;
            OpponentScore.NoofPossibleMove = listNoofPossibleMoveForOpponent.Count;

            Boolean IsEndGame = false;
            Boolean IsIWon = false;
            Boolean IsDraw = false;

            if (BotScore.NoofPossibleMove == 0 &&
                OpponentScore.NoofPossibleMove == 0)
            {
                IsEndGame = true;
            }

            if (IsUseScoreFromPosition)
            {
                GetScoreFromPosition((Board)board, ppositionScore, BotColor, BotScore,
                    OpponentScore);
            }
            if (IsEndGame)
            {
                LogDebugL2("IsEndGame is true");
                BotScore.DiskCount = board.NumberofDisk(BotColor);
                OpponentScore.DiskCount = board.NumberofDisk(OppoColor);
                if (BotScore.DiskCount == OpponentScore.DiskCount)
                {
                    IsDraw = true;
                    LogDebugL2("IsDraw is true");
                }
                else
                {
                    IsIWon = BotScore.DiskCount > OpponentScore.DiskCount;
                    LogDebugL2("IsIWon is true");
                }

                if (IsDraw)
                {
                    return 0;
                }
                if (IsIWon)
                {
                    return WonScore;
                }

                return LostScore;
            }

            Boolean IsINeedtoPass = false;
            Boolean IsEnemyNeedtoPass = false;
            if (OpponentScore.NoofPossibleMove == 0 &&
                BotScore.NoofPossibleMove > 0)
            {
                IsEnemyNeedtoPass = true;
            }

            if (BotScore.NoofPossibleMove == 0 &&
                OpponentScore.NoofPossibleMove > 0)
            {
                IsINeedtoPass = true;
            }

            if (IsEnemyNeedtoPass)
            {
                BotScore.ScorePassWeight += this.ForcePassSocre;
            }
            if (IsINeedtoPass)
            {
                OpponentScore.ScorePassWeight += this.ForcePassSocre;
            }

            if (IsUseStatbleDiskScore)
            {

                BotScore.NoofStableDisk = GetNoStableDisk(board, BotColor);
                OpponentScore.NoofStableDisk = GetNoStableDisk(board, OppoColor);
                BotScore.ScoreStableDiskWeight = BotScore.NoofStableDisk * StableDiskScore;
                OpponentScore.ScoreStableDiskWeight = OpponentScore.NoofStableDisk * StableDiskScore;
            }


            BotScore.NoofDiskCanFlip = GetNoofDiskCanBeFlipped(board, BotColor, listNoofPossibleMoveForBot);
            OpponentScore.NoofDiskCanFlip = GetNoofDiskCanBeFlipped(board, OppoColor, listNoofPossibleMoveForOpponent);
            BotScore.ScoreDiskCanFlip = MobilityPieceScore * BotScore.NoofDiskCanFlip;
            OpponentScore.ScoreDiskCanFlip = MobilityPieceScore * OpponentScore.NoofDiskCanFlip;

            LogDebugL2("===BotScore");
            LogDebugL2("BotScore.NoofPossbleMove::" + BotScore.NoofPossibleMove);
            LogDebugL2("BotScore.NoofStableDisk::" + BotScore.NoofStableDisk);

            LogDebugL2("BotScore.ScoreStableDiskWeight::" + BotScore.ScoreStableDiskWeight);
            LogDebugL2("BotScore.ScorePositionWeight::" + BotScore.ScorePositionWeight);
            LogDebugL2("BotScore.ScorePassWeight::" + BotScore.ScorePassWeight);
            LogDebugL2("BotScore.ScoreDiskCanFlip::" + BotScore.ScoreDiskCanFlip);

            LogDebugL2("===OpponentScore");
            LogDebugL2("OpponentScore.NoofPossbleMove::" + OpponentScore.NoofPossibleMove);
            LogDebugL2("OpponentScore.NoofStableDisk::" + OpponentScore.NoofStableDisk);

            LogDebugL2("OpponentScore.ScoreStableDiskWeight::" + OpponentScore.ScoreStableDiskWeight);
            LogDebugL2("OpponentScore.ScorePositionWeight::" + OpponentScore.ScorePositionWeight);
            LogDebugL2("OpponentScore.ScorePassWeight::" + OpponentScore.ScorePassWeight);
            LogDebugL2("OpponentScore.ScoreDiskCanFlip::" + OpponentScore.ScoreDiskCanFlip);
            EvaluateScore ResultScore = BotScore - OpponentScore;

            int ScoreTotal = ResultScore.GetTotalScore();

            return ScoreTotal;
        }

        //private void AddPostionToHash()
        public int GetNoofDiskCanBeFlipped(Board board, Board.PlayerColor color, List<Position> possibleMoves)
        {
            int result = 0;
            foreach (Position move in possibleMoves)
            {
                Board newBoard = board.Clone() as Board;
                newBoard.PutAndAlsoSwithCurrentTurn(move, color);
                result += newBoard.NumberofLastFlipCell;
            }
            return result;
        }
        public int GetNoStableDisk(Board board, Board.PlayerColor color)
        {
            int NofromCorner =
            this.GetNumberofStableDiscsFromCorner(board, color, Corner.TopLeft) +
            this.GetNumberofStableDiscsFromCorner(board, color, Corner.TopRight) +
            this.GetNumberofStableDiscsFromCorner(board, color, Corner.BottomLeft) +
            this.GetNumberofStableDiscsFromCorner(board, color, Corner.BottomRigth);

            int NofromEdge =
                this.GetStableDiscsFromFullEdge(board, color, NEWS.North) +
                this.GetStableDiscsFromFullEdge(board, color, NEWS.East) +
                this.GetStableDiscsFromFullEdge(board, color, NEWS.West) +
                this.GetStableDiscsFromFullEdge(board, color, NEWS.South);

            return NofromCorner + NofromCorner;

        }
        private int GetScoreStableFromCorner(Board board, Board.PlayerColor CheckColor, HashSet<int> hashStable, Position positionCorner, int DeltaRow, int DeltaColumn)
        {
            if (CheckColor != (Board.PlayerColor)board.boardMatrix[positionCorner.Row, positionCorner.Col])
            {
                return 0;
            }
            int i;
            Boolean IsStillNeedtoCheckRow = true;
            Boolean IsStillNeedtoCheckColumn = true;
            for (i = 1; i <= 6; i++)
            {
                if (!IsStillNeedtoCheckColumn && !IsStillNeedtoCheckRow)
                {
                    break;
                }

                if (IsStillNeedtoCheckRow)
                {
                    Position positionRow = new Position(positionCorner.Row + (DeltaRow * i), positionCorner.Col);

                    if (CheckColor == (Board.PlayerColor)board.boardMatrix[positionRow.Row, positionRow.Col])
                    {

                        if (hashStable.Contains(positionRow.GetHashCode()))
                        {
                            IsStillNeedtoCheckRow = false;
                        }
                        else
                        {
                            hashStable.Add(positionRow.GetHashCode());
                        }
                    }
                }
                else
                {
                    IsStillNeedtoCheckRow = false;
                }

                if (IsStillNeedtoCheckColumn)
                {
                    Position positionColumn = new Position(positionCorner.Row, positionCorner.Col + (DeltaColumn * i));
                    if (CheckColor == (Board.PlayerColor)board.boardMatrix[positionColumn.Row, positionColumn.Col])
                    {
                        //Position p = new Position(i, 0);
                        if (hashStable.Contains(positionColumn.GetHashCode()))
                        {
                            IsStillNeedtoCheckColumn = false;
                        }
                        else
                        {
                            hashStable.Add(positionColumn.GetHashCode());
                        }
                    }
                    else
                    {
                        IsStillNeedtoCheckColumn = false;
                    }
                }
            }

            return hashStable.Count;


        }
        private int GetNoStableDiskuNUSED(Board board, Board.PlayerColor CheckColor)
        {
            HashSet<int> hashStable = new HashSet<int>();

            int Score = 0;
            Position[] arrPositionCorner = new Position[4]
            {
                new Position (0,0),
                new Position (0,7),
                new Position (7,0),
                new Position (7,7)
            };

            Position[] arrPostionDelta = new Position[4]
            {
                new Position (1,1),
                new Position (1,-1),
                new Position (-1,1),
                new Position (-1,-1)
            };
            int i;
            for (i = 0; i < 4; i++)
            {
                Score += GetScoreStableFromCorner(board, CheckColor, hashStable, arrPositionCorner[i], arrPostionDelta[i].Row,
                      arrPostionDelta[i].Col);
            }



            return Score;
        }


        public int GetNumberofStableDiscsFromCorner(Board board, Board.PlayerColor color, Corner corner)
        {
            return GetNumberofStableDiscsFromCorner(board, color, GetPostionCorner(corner));
        }
        public int GetNumberofStableDiscsFromCorner(Board board, Board.PlayerColor color, Position PositionCorner)
        {
            int noofDisk = 0;
            int rowDelta = 1;
            int columnDelta = 1;
            if (PositionCorner.Row != 0)
            {
                rowDelta = -1;
            }
            if (PositionCorner.Col != 0)
            {
                columnDelta = -1;
            }

            int LastRow = 7;
            int LastColumn = 7;
            if (PositionCorner.Row != 0)
            {
                LastRow = 0;
            }
            if (PositionCorner.Col != 0)
            {
                LastColumn = 0;
            }


            for (int indexRow = PositionCorner.Row; indexRow != LastRow; indexRow += rowDelta)
            {
                int indexColumn = 0;
                for (indexColumn = PositionCorner.Col; indexColumn != LastColumn; indexColumn += columnDelta)
                {
                    if (board.boardMatrix[indexRow, indexColumn] != (int)color)
                    {
                        break;

                    }
                    noofDisk++;
                }
                Boolean IsThereColumnNeedtoCheck = false;
                IsThereColumnNeedtoCheck =
                    (columnDelta > 0 && indexColumn < 7) ||
                    (columnDelta < 0 && indexColumn > 0);
                if (!IsThereColumnNeedtoCheck)
                {
                    continue;
                }

                LastColumn = indexColumn - columnDelta;
                if (columnDelta > 0 && LastColumn == 0)
                {
                    LastColumn++;
                }
                else if (columnDelta < 0 && LastColumn == 7)
                {
                    LastColumn--;
                }

                if ((columnDelta > 0 && LastColumn < 0)
                    || (columnDelta < 0 && LastColumn > 7))
                {
                    break;
                }

            }

            return noofDisk;
        }
        public int GetStableDiscsFromFullEdge(Board board, Board.PlayerColor color, NEWS news)
        {

            Board.PlayerColor OppositeColor = Board.PlayerColor.Black;
            if (color == Board.PlayerColor.Black)
            {
                OppositeColor = Board.PlayerColor.White;

            }
            if (!IsEdgeFull(board, news))
            {
                return 0;
            }
            int result = 0;
            Position positionBegin = null;
            Position positionEnd = null;
            GetPostionBeginandEnd(news, ref positionBegin, ref positionEnd);


            bool hasFoundOppositeColor = false;
            int NoofRepeatedDisk = 0;
            for (int iRow = positionBegin.Row; iRow <= positionEnd.Row; iRow++)
            {
                for (int iColumn = positionBegin.Col; iColumn <= positionEnd.Col; iColumn++)
                {
                    Board.PlayerColor DiskColor = (Board.PlayerColor)board.boardMatrix[iRow, iColumn];
                    if (!hasFoundOppositeColor &&
                        DiskColor == OppositeColor)
                    {
                        hasFoundOppositeColor = true;
                        NoofRepeatedDisk = 0;
                        continue;
                    }
                    if (hasFoundOppositeColor)
                    {
                        if (DiskColor == color)
                        {
                            NoofRepeatedDisk++;
                        }
                        else
                        {
                            result += NoofRepeatedDisk;
                            NoofRepeatedDisk = 0;
                        }
                    }

                }
            }

            return result;

        }

        public enum NEWS
        {
            North,
            East,
            West,
            South
        }
        public enum Corner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRigth
        }
        // private static 
        public static Position GetPostionCorner(Corner corner)
        {
            if (dicPositionCorner.ContainsKey(corner))
            {
                return dicPositionCorner[corner];
            }
            Position positonResult = null;
            switch (corner)
            {
                case Corner.TopLeft:
                    positonResult = new Position(0, 0);
                    break;
                case Corner.TopRight:
                    positonResult = new Position(0, 7);
                    break;
                case Corner.BottomLeft:
                    positonResult = new Position(7, 0);
                    break;
                case Corner.BottomRigth:
                    positonResult = new Position(7, 7);
                    break;
            }
            dicPositionCorner.Add(corner, positonResult);
            return positonResult;
        }
        private static Dictionary<Corner, Position> dicPositionCorner = new Dictionary<Corner, Position>();
        private static Dictionary<NEWS, Position> dicPositionBegin = new Dictionary<NEWS, Position>();
        private static Dictionary<NEWS, Position> dicPositionEnd = new Dictionary<NEWS, Position>();

        public static void GetPostionBeginandEnd(NEWS news, ref Position positionBegin, ref Position positionEnd)
        {
            int rowBegin = 0;
            int rowEnd = 0;
            int colBegin = 0;
            int colEnd = 0;
            if (dicPositionBegin.ContainsKey(news))
            {
                positionBegin = dicPositionBegin[news];
                positionEnd = dicPositionEnd[news];
                return;
            }
            switch (news)
            {
                case NEWS.North:
                    rowBegin = 0;
                    rowEnd = 0;
                    colBegin = 0;
                    colEnd = 7;
                    break;
                case NEWS.East:
                    rowBegin = 0;
                    rowEnd = 7;
                    colBegin = 7;
                    colEnd = 7;
                    break;
                case NEWS.West:
                    rowBegin = 0;
                    rowEnd = 7;
                    colBegin = 0;
                    colEnd = 0;
                    break;
                case NEWS.South:
                    rowBegin = 7;
                    rowEnd = 7;
                    colBegin = 0;
                    colEnd = 7;
                    break;
            }
            positionBegin = new Position(rowBegin, colBegin);
            positionEnd = new Position(rowEnd, colEnd);
            dicPositionBegin.Add(news, positionBegin);
            dicPositionEnd.Add(news, positionEnd);




        }
        public bool IsEdgeFull(Board board, NEWS news)
        {
            int i;

            Position positionBegin = null;
            Position positionEnd = null;
            GetPostionBeginandEnd(news, ref positionBegin, ref positionEnd);


            for (int iRow = positionBegin.Row; iRow <= positionEnd.Row; iRow++)
            {
                for (int iColumn = positionBegin.Col; iColumn <= positionEnd.Col; iColumn++)
                {
                    if (board.boardMatrix[iRow, iColumn] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;


        }
    }

}
