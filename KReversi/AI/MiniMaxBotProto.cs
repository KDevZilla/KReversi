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
        /*
         These value will be set to Evaluate object.
         The main purpose of this class is to hold these value
         */
        public int ForcePassSocre { get; set; } = 1000;
        public int StableDiskScore { get; set; } = 10;
        public int TimeLimitPermove { get; set; } = 3;// Number of second bot allowed to think in each turn.
        // public Boolean AllowRandom { get; set; } = false;

        public int ScoreNumberMoveAtBegingGame { get; set; }
        public int ScoreNumberMoveAtMiddleGame { get; set; }
        public int ScoreNumberMoveAtEndGame { get; set; }


        public int DepthLevelAtBeginGame { get; set; }
        public int DepthLevelAtMiddleGame { get; set; }
        public int DepthLevelAtEndGame { get; set; }
        
        public string BotName { get; set; }

        public string Base64Image { get; set; }
        // public string PhotoFileName { get; set; }
        // As of now don't use FileName, use Base64Image instead.



        /*
         These are default value of PostionScore
         For Open, Mid, End game.
        */
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
            //Select depth level according to the BoardPhase
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

            MiniMaxBotProto Newbot = Utility.SerializeUtility.DeserializeMinimaxBot(fileName);
            Newbot.FillEvaluateObject();
            return Newbot;

        }
        public static MiniMaxBotProto CreateBot()
        {
            //These are default value
            //They will be used incase we don't load Botvalue then FillEvaluateObject
            //
            MiniMaxBotProto minimaxBorProto = new MiniMaxBotProto();
            minimaxBorProto.DepthLevelAtBeginGame = 2;
            minimaxBorProto.DepthLevelAtMiddleGame = 3;
            minimaxBorProto.DepthLevelAtEndGame = 5;

            minimaxBorProto.ScoreNumberMoveAtBegingGame = 10;
            minimaxBorProto.ScoreNumberMoveAtMiddleGame = 40;
            minimaxBorProto.ScoreNumberMoveAtEndGame = 20;

            minimaxBorProto.DepthLevelAtBeginGame = 2;
            minimaxBorProto.DepthLevelAtMiddleGame = 2;
            minimaxBorProto.DepthLevelAtEndGame = 2;

            //IEvaluate Evu = new BasicMiniMaxEvaluate();

            minimaxBorProto.Evaluate = new BasicMiniMaxEvaluate(minimaxBorProto);
            return minimaxBorProto;
        }


    }
}
