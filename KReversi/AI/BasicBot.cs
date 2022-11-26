using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public class BasicBot : IPlayer
    {
        /* Very BasicBot
         * Just choose which position should put base on the table score
         * Does not count for other position in board at all
         */
        public Position MakeMove(AI.IBoard pBoard)
        {

            List<Position> LegalMove = pBoard.generateMoves();
            if (LegalMove.Count == 0)
            {
                return null;
            }
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
                PositionScore PosScore = new PositionScore(LegalMove[i].Row, LegalMove[i].Col);
                PosScore.Score = OpenGamePostionScore[PosScore.Row, PosScore.Col];

                lst.Add(PosScore);

            }
            lst = lst.OrderBy(x => x.Score).Reverse().ToList();
            //Position Position = LegalMove[R.Next(LegalMove.Count)];
            return lst[0];
        }
    }

}
