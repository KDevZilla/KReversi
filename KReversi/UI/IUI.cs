using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KReversi.Game;
namespace KReversi.UI
{
    public class PositionEventArg : EventArgs
    {
        public Position position;
        public PositionEventArg(Position position)
        {
            this.position = position;
        }
    }
    public class intEventArgs : EventArgs
    {
        public int Value;
        public intEventArgs(int value)
        {
            this.Value = value;
        }
    }
    public delegate void EventPostion(Position position);
    public delegate void EventInt(int value);
    public interface IUI
    {
        void RenderHistory();
        void RenderNumberofDisk(int WhiteDisk, int BlackDisk);
        void ShowBoardAtTurn(int NumberofTurn);
        void MoveBoardToNextTurn();
        void MoveBoardToPreviousTurn();
        void RenderBoard();
        void SetGame(KReversiGame game);
        void RemoveGame();
        void BlackPutCellAt(Position position);
        void WhitePutCellAt(Position position);
        void Initial();
        void ReleaseUIResource();
        void InformPlayer1NeedtoPass();
        void InformPlayer2NeedtoPass();

        void InformGameResult(KReversiGame.GameResultEnum result);

        event EventHandler MoveBoardToNextTurnClick;
        event EventHandler MoveBoardToPreviousTurnClick;
        event EventHandler MoveBoardToFirstTurnClick;
        event EventHandler MoveBoardToLastTurnClick;
        event PictureBoxBoard.PictureBoxCellClick CellClick;
        event EventInt MoveBoardToSpecificTurnClick;
        event EventHandler ContinuePlayingClick;
    }



}
