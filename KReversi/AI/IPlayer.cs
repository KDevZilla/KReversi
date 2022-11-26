using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi
{
    public interface IPlayer
    {

        //void SetBotColor(Board.ePlayerColor BotColor);
        Position MakeMove(AI.IBoard pBoard);

    }
}
