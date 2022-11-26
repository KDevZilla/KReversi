using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{

    public interface IBoard
    {
        List<Position> generateMoves();
        IBoard Clone();
        int BoardSize { get; }
        void PutValue(int Row, int Col, int Value);
        void PutValue(Position position, int Value);
        // int[,] boardMatrix { get; set; }
        //int[,] boardMatrix;
        //(int posX, int posY, Boolean black)
    }




}
