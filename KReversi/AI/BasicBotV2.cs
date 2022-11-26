using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public class BasicBotV2 : IPlayer
    {
        /*
        It 's brain has been improved
        Now it will not only calcualte the position that it put,
        It calculate the whole table
        So the position that it put has good score but the consequence is bad it will not choose that postion
        */
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
                int Row = 0;
                int Col = 0;

                int iBotScore = 0;
                int iOpponenetScore = 0;
                int BlackScore = 0;
                int WhiteScore = 0;
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
