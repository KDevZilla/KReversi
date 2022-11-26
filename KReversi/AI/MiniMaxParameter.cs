using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public class MiniMaxParameterNew
    {
        public PositionScore PositionScore { get; set; } = new PositionScore();

        public int Depth { get; set; }
        public Board board { get; set; }
        public Boolean IsMax { get; set; }
        public int Alpha = 0;
        public int Beta = 0;
        public Board.PlayerColor BotColor = Board.PlayerColor.White;
        public MiniMaxParameterNew CloneWithotuBoard()
        {
            MiniMaxParameterNew CloneObject = new MiniMaxParameterNew();
            CloneObject.Depth = this.Depth;
            CloneObject.IsMax = this.IsMax;
            CloneObject.Alpha = this.Alpha;
            CloneObject.Beta = this.Beta;
            CloneObject.BotColor = this.BotColor;
            return CloneObject;
        }
        public MiniMaxParameterNew Clone()
        {
            MiniMaxParameterNew CloneObject = this.CloneWithotuBoard();
            CloneObject.board = (Board)this.board.Clone();

            return CloneObject;
        }
    }
    [Serializable]
    public class MiniMaxParameter
    {
        public int Depth { get; set; }
        public Board board { get; set; }
        public Boolean IsMax { get; set; }
        public int Alpha = 0;
        public int Beta = 0;
        public Board.PlayerColor BotColor = Board.PlayerColor.White;
        public MiniMaxParameter CloneWithotuBoard()
        {
            MiniMaxParameter CloneObject = new MiniMaxParameter();
            CloneObject.Depth = this.Depth;
            CloneObject.IsMax = this.IsMax;
            CloneObject.Alpha = this.Alpha;
            CloneObject.Beta = this.Beta;
            CloneObject.BotColor = this.BotColor;
            return CloneObject;
        }
        public MiniMaxParameter Clone()
        {
            MiniMaxParameter CloneObject = this.CloneWithotuBoard();
            CloneObject.board = (Board)this.board.Clone();

            return CloneObject;
        }
    }

    [Serializable]
    public class MiniMaxParameterExtend : MiniMaxParameter
    {
        public List<MiniMaxParameterExtend> child = new List<MiniMaxParameterExtend>();
        //public int Score = 0;
        public PositionScore PositionScore { get; set; } = new PositionScore();
        public MiniMaxParameterExtend CloneExtendWithoutBoard()
        {
            MiniMaxParameterExtend CloneObject = new MiniMaxParameterExtend();
            CloneObject.Depth = this.Depth;
            // CloneObject.board = this.board.Clone();
            CloneObject.IsMax = this.IsMax;
            CloneObject.Alpha = this.Alpha;
            CloneObject.Beta = this.Beta;
            CloneObject.BotColor = this.BotColor;
            // CloneObject.Score = this.Score;
            if (this.PositionScore != null)
            {
                CloneObject.PositionScore = this.PositionScore.ClonePositionScore();
            }
            //CloneObject.child = 
            return CloneObject;
        }
        public MiniMaxParameterExtend CloneExtend()
        {
            MiniMaxParameterExtend CloneObject = CloneExtendWithoutBoard();
            CloneObject.board = (Board)this.board.Clone();


            return CloneObject;
        }
    }
}
