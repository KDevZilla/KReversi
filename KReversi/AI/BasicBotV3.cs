using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public class BasicBotV3 : IPlayer
    {
        /*
         It is the same as BasicBotV2 but now we would like to implement the static brain
         Everytime we calculate the score we will keep it in dictionary 
         The key we be the hash value of the board

        */
        public static int NoofBoardInBrain
        {
            get
            {
                return DicBlackScore.Count;
            }
        }
        private static Dictionary<int, int> _DicBlackScore = null;
        private static Dictionary<int, int> _DicWhiteScore = null;

        private static Dictionary<int, int> DicBlackScore
        {
            get
            {
                if (_DicBlackScore == null)
                {
                    _DicBlackScore = new Dictionary<int, int>();
                }
                return _DicBlackScore;
            }
        }

        private static Dictionary<int, int> DicWhiteScore
        {
            get
            {
                if (_DicWhiteScore == null)
                {
                    _DicWhiteScore = new Dictionary<int, int>();
                }
                return _DicWhiteScore;
            }
        }
        private static void AddScoreToBrain(Board pBoard, int WhiteScore, int BlackScore)
        {
            int HashValue = pBoard.GetHashValue();
            if (DicBlackScore.ContainsKey(HashValue) ||
                DicWhiteScore.ContainsKey(HashValue))
            {
                return;
            }
            DicWhiteScore.Add(HashValue, WhiteScore);
            DicBlackScore.Add(HashValue, BlackScore);
        }
        public static int NumberofTimeCanReadFromBrain { get; private set; } = 0;
        private static void GetScoreFromBrain(Board pBoard, out int WhiteScore, out int BlackScore)
        {
            WhiteScore = -1;
            BlackScore = -1;
            int HashValue = pBoard.GetHashValue();
            if (DicWhiteScore.ContainsKey(HashValue))
            {
                WhiteScore = DicWhiteScore[HashValue];
                BlackScore = DicBlackScore[HashValue];
                NumberofTimeCanReadFromBrain++;
            }

        }
        private List<PositionScore> GetListScore(Board pBoard, List<Position> LegalMove)
        {
            int[,] OpenGamePostionScore = new int[,] {
            { 100, -20, 20, 5, 5, 20, -20, 100},
            {-20 , -30, -5, -5, -5, -5, -30, -20},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-20 , -30, -5, -5, -5, -5, -30, -20},
            {100 , -20, 20, 5, 5, 20, -20, 100}
            };
            List<PositionScore> lst = new List<PositionScore>();
            int i;
            for (i = 0; i < LegalMove.Count; i++)
            {
                Board NewBoard = (Board)pBoard.Clone();
                NewBoard.PutAndAlsoSwithCurrentTurn(LegalMove[i], pBoard.CurrentTurn);
                int iBotScore = 0;
                int iOpponenetScore = 0;
                int BlackScore = 0;
                int WhiteScore = 0;
                GetScoreFromBrain(NewBoard, out WhiteScore, out BlackScore);

                if (WhiteScore == -1)
                {
                    int Row = 0;
                    int Col = 0;


                    for (Row = 0; Row <= 7; Row++)
                    {
                        for (Col = 0; Col <= 7; Col++)
                        {
                            switch ((Board.PlayerColor)NewBoard.boardMatrix[Row, Col])
                            {
                                case Board.PlayerColor.Black:
                                    BlackScore += OpenGamePostionScore[Row, Col];
                                    break;
                                case Board.PlayerColor.White:
                                    WhiteScore += OpenGamePostionScore[Row, Col];
                                    break;
                            }
                        }
                    }
                    AddScoreToBrain(NewBoard, WhiteScore, BlackScore);
                }
                PositionScore PosScore = new PositionScore(LegalMove[i].Row, LegalMove[i].Col);
                if (pBoard.CurrentTurn == Board.PlayerColor.Black)
                {
                    PosScore.Score = BlackScore - WhiteScore;
                }
                else
                {
                    PosScore.Score = WhiteScore - BlackScore;
                }
                //PosScore.Score = OpenGamePostionScore[PosScore.Row, PosScore.Col];

                lst.Add(PosScore);

            }
            lst = lst.OrderBy(x => x.Score).Reverse().ToList();
            return lst;
        }
        public Position MakeMove(AI.IBoard pBoard)
        {

            List<Position> LegalMove = pBoard.generateMoves();
            if (LegalMove.Count == 0)
            {
                return null;
            }

            List<PositionScore> lst = new List<PositionScore>();
            lst = GetListScore((Board)pBoard, LegalMove);
            //lst = lst.OrderBy(x => x.Score).Reverse().ToList();
            //Position Position = LegalMove[R.Next(LegalMove.Count)];
            return lst[0];
        }
    }
}
