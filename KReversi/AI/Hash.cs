using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    public class Hash
    {

        public static int ScoreForNonExist = int.MaxValue / 2;

        public static int GetHashForBoard(Board board)
        {
            return board.GetHashCode() * (int)board.CurrentTurn ;
        }
        private Dictionary<int, Dictionary<int, int>> DicHash = new Dictionary<int, Dictionary<int, int>>();
        private Dictionary<int, int> DicEvoScore = new Dictionary<int, int>();
        public int NumberofNodeCount()
        {
            int NumberofNodeCount = 0;
            foreach (int HashBoard in DicHash.Keys)
            {
                foreach (int DepthExist in DicHash[HashBoard].Keys)
                {
                    NumberofNodeCount++;
                }
            }
            NumberofNodeCount += DicEvoScore.Count;
            return NumberofNodeCount;
        }
        public void Add(int HashCodeForBoard, int Score, int Depth)
        {
            Dictionary<int, int> DicDepthScore = new Dictionary<int, int>();
            if (DicHash.ContainsKey(HashCodeForBoard))
            {
                DicDepthScore = DicHash[HashCodeForBoard];
                if(DicDepthScore.ContainsKey(Depth))
                {
                    return;
                }
                foreach(int DepthExist in DicDepthScore.Keys)
                {
                    if(DepthExist >=Depth)
                    {
                        return;
                    }
                }
                
            } else
            {
                DicHash.Add(HashCodeForBoard, DicDepthScore);
            }
            DicDepthScore.Add(Depth, Score);

        }
        public void AddEvalScore(int HashCodeForBoard, int Score)
        {
            // Dic
            if(DicEvoScore.ContainsKey(HashCodeForBoard))
            {
                return;
            }
            DicEvoScore.Add(HashCodeForBoard, Score);
        }
        public int GetEvalScore(int HashCodeForBoard)
        {
            if(DicEvoScore.ContainsKey(HashCodeForBoard))
            {
                return DicEvoScore[HashCodeForBoard];

            }
            return ScoreForNonExist;
        }

        public int GetScore(int HashCodeForBoard, int DepthLeast)
        {
            if (!DicHash.ContainsKey(HashCodeForBoard))
            {
                return ScoreForNonExist;
            }
            foreach (int DepthExist in DicHash[HashCodeForBoard].Keys)
            {
                if(DepthLeast <= DepthExist)
                {
                    return DicHash[HashCodeForBoard][DepthExist];
                }
            }
            return ScoreForNonExist;
        }

        public Boolean ContainScore(int HashCodeForBoard, int DepthLeast)
        {
            return GetScore(HashCodeForBoard, DepthLeast) != ScoreForNonExist;
        }
        public Boolean ContainEvalScore(int HashCodeForBoard)
        {
            return GetEvalScore(HashCodeForBoard) != ScoreForNonExist;
        }
    }
}
