using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KReversi.Game;

namespace KReversi.UI
{
    //If you have time please change it to be actual MockObject form the real testing framework
    public class MockIUI : IUI
    {
        public event EventHandler MoveBoardToNextTurnClick;
        public event EventHandler MoveBoardToPreviousTurnClick;
        public event EventHandler MoveBoardToFirstTurnClick;
        public event EventHandler MoveBoardToLastTurnClick;
        public event PictureBoxBoard.PictureBoxCellClick CellClick;
        public event EventInt MoveBoardToSpecificTurnClick;
        public event EventHandler ContinuePlayingClick;

        public void BlackPutCellAt(Position position)
        {
           // throw new NotImplementedException();
        }

        public void InformGameResult(KReversiGame.GameResultEnum result)
        {
//            throw new NotImplementedException();
        }

        public void InformPlayer1NeedtoPass()
        {
 //           throw new NotImplementedException();
        }

        public void InformPlayer2NeedtoPass()
        {
 //           throw new NotImplementedException();
        }

        public void Initial()
        {
           // throw new NotImplementedException();
        }

        public void MoveBoardToNextTurn()
        {
            //throw new NotImplementedException();
        }

        public void MoveBoardToPreviousTurn()
        {
           // throw new NotImplementedException();
        }

        public void ReleaseUIResource()
        {
           // throw new NotImplementedException();
        }

        public void RenderBoard()
        {
           // throw new NotImplementedException();
        }

        public void RenderNumberofDisk(int WhiteDisk, int BlackDisk)
        {
           // throw new NotImplementedException();
        }
        public void RenderHistory()
        {

        }
        public void SetGame(KReversi.Game.KReversiGame game)
        {
            // throw new NotImplementedException();
            game.SetUI(this);
        }

        public void ShowBoardAtTurn(int NumberofTurn)
        {
            //throw new NotImplementedException();
        }

        public void WhitePutCellAt(Position position)
        {
           // throw new NotImplementedException();
        }

        public void RemoveGame()
        {
            //throw new NotImplementedException();
        }
    }
}
