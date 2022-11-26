using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi
{
    [Serializable]
    public class KReversiSettings
    {
        public string LastPlayer1Name { get; set; } = "";
        public string LastPlayer2Name { get; set; } = "";
        public string LastMapFileName { get; set; } = "";
        public string LastBotSavedFileName { get; set; } = "";

        public string Player1AsHumanName { get; set; }
        public string Player2AsHumanName { get; set; }
        public string Player1AsHumanImagrBase64 { get; set; }
        public string Player2AsHumanImagrBase64 { get; set; }

        public Boolean IsWriteLog { get; set; }
        public Boolean IsWriteDebugLog { get; set; } = true;
        public Boolean IsWriteDebugLogL2 { get; set; } = true;
        public Boolean IsCompaceMode { get; set; } = false;
        public Boolean IsDarkMode { get; set; } = false;
        public Boolean IsAllowRandomDecision { get; set; } = true;
        public Boolean IsUsingAlphaBeta { get; set; } = true;
        public Boolean IsKeepLastDecisionTree { get; set; } = false;
    }
    
}
