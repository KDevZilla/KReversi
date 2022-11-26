using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    [Serializable]
    public class MiniMaxBotProto : IPlayer
    {
        //private IEvaluate Evaluate;
        private BasicMiniMaxEvaluate Evaluate = null;
        public MiniMaxBotProto()
        {

        }

        public int ForcePassSocre { get; set; } = 1000;
        public int StableDiskScore { get; set; } = 10;
        public int TimeLimitPermove { get; set; } = 3;
        // public Boolean AllowRandom { get; set; } = false;

        public int ScoreNumberMoveAtBegingGame { get; set; }
        public int ScoreNumberMoveAtMiddleGame { get; set; }
        public int ScoreNumberMoveAtEndGame { get; set; }


        public int DepthLevelAtBeginGame { get; set; }
        public int DepthLevelAtMiddleGame { get; set; }
        public int DepthLevelAtEndGame { get; set; }
        // public string PhotoFileName { get; set; }
        public string BotName { get; set; }
        public string Base64Image { get; set; }
        public int[,] OpenGamePostionScore = new int[,] {
            { 100, -50, 20, 5, 5, 20, -50, 100},
            {-50 , -70, -5, -5, -5, -5, -70, -50},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-50 , -70, -5, -5, -5, -5, -70, -50},
            {100 , -50, 20, 5, 5, 20, -50, 100}
        };


        public int[,] MidGamePostionScore = new int[,] {
            { 140, -20, 20, 5, 5, 20, -20, 140},
            {-20 , -40, -5, -5, -5, -5, -40, -20},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {5   , -5 , 3, 3, 3, 3, -5, 5},
            {20  , -5 , 15, 3, 3, 15, -5, 20},
            {-20 , -40, -5, -5, -5, -5, -40, -20},
            {140 , -20, 20, 5, 5, 20, -20, 140}
        };

        public int[,] EndGamePostionScore = new int[,] {
            { 20, -5, 10, 5, 5, 10, -5, 20},
            {-5 , -10, 5, 5, 5, 5, -10, -5},
            {20  , 5 , 5, 5, 5, 5, 5, 10},
            {5   , 5 , 5, 5, 5, 5, 5, 5},
            {5   , 5 , 3, 5, 5, 5, 5, 5},
            {10  , 5 , 5, 5, 5, 5, 5, 10},
            {-5 , -10, 5, 5, 5, 5, -10, -5},
            {20 , -5, 10, 5, 5, 10, -5, 20}
        };

        public int DepthLevel(Board.BoardPhaseEnum boardPhase)
        {

            int depthLevel = 0;
            switch (boardPhase)
            {
                case Board.BoardPhaseEnum.Begining:
                    depthLevel = DepthLevelAtBeginGame;
                    break;
                case Board.BoardPhaseEnum.Middle:
                    depthLevel = DepthLevelAtMiddleGame;
                    break;
                case Board.BoardPhaseEnum.EndGame:
                    depthLevel = DepthLevelAtEndGame;
                    break;
                default:
                    depthLevel = 1;
                    break;
            }
            if (depthLevel < 1 ||
                    depthLevel > 10)
            {
                throw new Exception("Depth level is invalid");
            }

            return depthLevel;
        }
        public void FillEvaluateObject()
        {
            // this.Evaluate.ScoreNumberMoveAtBegingGame = this.ScoreNumberMoveAtBegingGame;

            this.Evaluate = new BasicMiniMaxEvaluate(this);
        }

        public bool IsUseScoreFromPosition = true;

        [NonSerialized()]
        public bool IsAllowRandomDecision = false;

        [NonSerialized()]
        public bool IsKeepLastDecisionTree = false;

        [NonSerialized()]
        public bool IsUsingAlphaBeta = false;


        [NonSerialized()] MiniMax m = null;
        public Position MakeMove(IBoard pBoard)
        {



            Board.PlayerColor BotColor = ((Board)pBoard).CurrentTurn;
            int depthLevel = DepthLevel(((Board)pBoard).BoardPhase);

            Utility.TimeMeasure time = new Utility.TimeMeasure();
            time.Start();
            //Boolean IsUsingAlphaBeta = true;
            //Boolean IsKeepingChildValue = false ;
            // Boolean IsUsingRandomIfNodeValueIsTheSame = true;
            Boolean IsSortedNode = true;
            if (m == null)
            {
                m = new MiniMax();
            }
            Position result = m.calculateNextMove(pBoard,
                depthLevel,
                Evaluate,
                BotColor,
                this.TimeLimitPermove,
                IsUsingAlphaBeta,
                IsKeepLastDecisionTree,
                IsAllowRandomDecision,
                IsSortedNode
                );
            time.Finish();
            String strTemp = time.TimeTakes.Seconds.ToString();

            return result;

        }
        public static MiniMaxBotProto CreateBot(String fileName)
        {
            // throw new NotImplementedException();
            MiniMaxBotProto Newbot = Utility.SerializeUtility.DeserializeMinimaxBot(fileName);
            Newbot.FillEvaluateObject();
            //Newbot.Evaluate.ScoreNumberMoveAtBegingGame = Newbot.ScoreNumberMoveAtBegingGame;

            return Newbot;



        }
        public static MiniMaxBotProto CreateBot()
        {
            //BasicMiniMaxEvaluate basicEva = new BasicMiniMaxEvaluate();
            //basicEva.SetOpenGamePostionScore ()


            MiniMaxBotProto M1 = new MiniMaxBotProto();
            M1.DepthLevelAtBeginGame = 2;
            M1.DepthLevelAtMiddleGame = 3;
            M1.DepthLevelAtEndGame = 5;


            M1.ScoreNumberMoveAtBegingGame = 10;
            M1.ScoreNumberMoveAtMiddleGame = 40;
            M1.ScoreNumberMoveAtEndGame = 20;



            M1.DepthLevelAtBeginGame = 2;
            M1.DepthLevelAtMiddleGame = 2;
            M1.DepthLevelAtEndGame = 2;




            //IEvaluate Evu = new BasicMiniMaxEvaluate();

            M1.Evaluate = new BasicMiniMaxEvaluate(M1);

            //  M1.Evaluate.evaluateBoardForOponent 
            return M1;
        }
        /*
        public Position MakeMove(IBoard pBoard)
        {
            throw new NotImplementedException();
        }
        */

    }
}
