using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi
{
    [Serializable]
    public class Position
    {
        public int Row=-1;
        public int Col = -1;
        public static Position Empty
        {
            get { return new Position(-1, -1); }
        }
        public Position (int pRow, int pCol)
        {
            Row = pRow;
            Col = pCol;
        }
        public int GetHashCode()
        {
            return (Row.ToString() + "_" + Col.ToString()).GetHashCode();
        }
        public Position Clone()
        {
            Position NewPostion = new Position(this.Row, this.Col);
            return NewPostion;
        }
        public string PositionString()
        {
            return Row.ToString() + "," + Col.ToString();
        }
    }

    [Serializable]
    public class PositionScore:Position
    {
        public int Score = 0;
        public PositionScore (int pRow,int pCol ):base(pRow,pCol)
        {

        }
        public PositionScore() : base(-1, -1)
        {

        }
        public PositionScore (int Score):base(-1, -1)
        {
            this.Score = Score;
        }
        public PositionScore(int Score, int Row, int Col):base(Row,Col)
        {
            this.Score = Score;
            this.Row = Row;
            this.Col = Col;
        }
        public PositionScore(int Score,Position pos):base(pos.Row,pos.Col)
        {
            this.Score = Score;
            this.Row = pos.Row;
            this.Col = pos.Col;
        }
        public PositionScore ClonePositionScore()
        {
            PositionScore NewPostion = new PositionScore(this.Score ,this.Row, this.Col);
            
            return NewPostion;
        }

    }
}
