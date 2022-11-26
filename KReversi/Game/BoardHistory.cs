using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KReversi.AI;
using KReversi.UI;

namespace KReversi.Game
{

    [Serializable]
    public class BoardHistory
    {
        public List<IBoard> HistoryBoards { get; private set; }
        public List<Position> HistoryPosition { get; private set; }
        public List<Board.PlayerColor> HistoryTurn { get; private set; }
        public event EventInt IndexHistoryChanged;
        public event EventInt ClearHistoryAfterCurrentIndexEvent;
        public BoardHistory Clone()
        {
            SimpleLog.WriteLog("BoardHistory::Clone");
            BoardHistory NewBoardHistory = new BoardHistory();
            int i;
            for (i = 0; i < this.HistoryBoards.Count; i++)
            {
                NewBoardHistory.HistoryBoards.Add(HistoryBoards[i].Clone());
                NewBoardHistory.HistoryPosition.Add(HistoryPosition[i].Clone());
                NewBoardHistory.HistoryTurn.Add(HistoryTurn[i]);

            }
            NewBoardHistory.IndexMove = this.IndexMove;
            return NewBoardHistory;
        }
        public BoardHistory()
        {
            SimpleLog.WriteLog("BoardHistory::Constructor");
            HistoryBoards = new List<IBoard>();
            HistoryPosition = new List<Position>();
            HistoryTurn = new List<Board.PlayerColor>();

        }
        public void ClearAllHistory()
        {
            IndexMove = -1;
            HistoryBoards = new List<IBoard>();
            HistoryPosition = new List<Position>();
            HistoryTurn = new List<Board.PlayerColor>();
        }
        public void ClearHistoryAfterCurrentIndex()
        {
            SimpleLog.WriteLog("BoardHistory::ClearHistoryAfterCurrentIndex");
            int i;
            int iLastIndex = HistoryBoards.Count - 1;
            for (i = iLastIndex; i > IndexMove; i--)
            {
                HistoryBoards.RemoveAt(i);
                HistoryPosition.RemoveAt(i);
                HistoryTurn.RemoveAt(i);
            }

            if (ClearHistoryAfterCurrentIndexEvent != null)
            {
                ClearHistoryAfterCurrentIndexEvent(IndexMove);
            }

        }
        public void AddBoardHistory(AI.Board board, Position position, Board.PlayerColor playercolor)
        {

            int i;

            for (i = HistoryBoards.Count - 1; i >= 0; i--)
            {
                if (i < IndexMove)
                {
                    break;
                }
                HistoryBoards.RemoveAt(i);
                HistoryPosition.RemoveAt(i);
                HistoryTurn.RemoveAt(i);
            }

            //HistoryBoards.Push(this.board.Clone());
            HistoryBoards.Add(board.Clone());
            if (position == null)
            {
                position = Position.Empty;
            }

            HistoryPosition.Add(position.Clone());

            HistoryTurn.Add(playercolor);
        }
        public void SetCurrentBoardToIndex(int index)
        {
            // return HistoryBoards[index];
            IndexMove = index;

        }

        protected void OnIndexHistoryChanged()
        {
            if (IndexHistoryChanged == null)
            {
                return;
            }
            IndexHistoryChanged(IndexMove);
        }
        public void NextMoveBoard()
        {
            if (IndexMove >= HistoryBoards.Count - 1)
            {
                return;
            }
            /*
            if (IndexMove == HistoryBoards.Count - 1)
            {
                IndexMove += 1;
                return;
            }
            IndexMove += 2;
            */
            IndexMove++;
        }
        public AI.Board GetBoardToHistory()
        {
            return (AI.Board)HistoryBoards[IndexMove].Clone();
        }
        public void IndexMoveAdd()
        {
            IndexMove++;
        }
        int _IndexMove = 0;
        public int IndexMove
        {
            get
            {
                return _IndexMove;
            }
            private set
            {
                _IndexMove = value;
                OnIndexHistoryChanged();
            }
        }
        public void PreviousMoveBoard()
        {
            if (IndexMove <= 0)
            {
                return;
            }

            IndexMove--;


        }
        public void FirstMoveBoard()
        {
            IndexMove = 0;

        }
        public void LastMoveBoard()
        {
            IndexMove = this.HistoryBoards.Count - 1;
        }
    }
}
