using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi
{
    public class RandomBot : IPlayer
    {
        /*
         * Don't use Random like this
         * I don't delete the code to remine myself that this Random R has the problem
         */
        //Random R = new Random();

        public Position MakeMove(AI.IBoard pBoard)
        {

            List<Position> LegalMove = pBoard.generateMoves();
            if (LegalMove.Count == 0)
            {
                return null;
            }
            Position Position = LegalMove[Utility.Utility.GetRandomNumber(0, LegalMove.Count - 1)];


            //Bad Random
            //Position Position =LegalMove [ R.Next(LegalMove.Count)];

            return Position;
        }
    }
}
