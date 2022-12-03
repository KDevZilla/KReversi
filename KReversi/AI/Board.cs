using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.AI
{
    [Serializable]
    public class BoardValue
    {
        public int[,] boardMatrix { get; set; }
        public int CurrentTurnNumber = 0;
        public int Turn;
        public List<Position> listPutPosition = null;

    }

    [Serializable]
    public class Board : IBoard
    {
        public enum PlayerColor
        {
            Black = -1,
            White = 1

        }
        public enum CellValue
        {
            Black = -1,
            Blank = 0,
            White = 1,

        }
        public enum BoardPhaseEnum
        {
            Begining,
            Middle,
            EndGame
        }


        public int[,] boardMatrix;

        
        /*
         * Don't use array as property because it might be slow
         * Also for indexing, It might be so slow
         * Need Time to benchmark on Release build
         * For now avoid using it first.
         * http://msdn.microsoft.com/en-us/library/0fss9skc.aspx
         * https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1819
         * 
         */
        //public int[,] boardMatrix { get; set; }
        /*
        public int this[int row,int col]
        {
            get
            {
                return boardMatrix[row, col];
            }
            set
            {
                boardMatrix[row, col] = value;
            }
        }
        */
        public int GetHashValue()
        {
            int hash = 17;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    hash = hash * 31 + boardMatrix[i, j];
                }
            }
            return hash;
        }
        public String ToString()
        {
            StringBuilder strB = new StringBuilder();
            int rowLength = boardMatrix.GetLength(0);
            int colLength = boardMatrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    String valueString = boardMatrix[i, j].ToString();
                    if (valueString.Length == 1)
                    {
                        valueString = "  " + valueString;
                    }
                    else
                    {
                        valueString = " " + valueString;
                    }
                    strB.Append(valueString);

                }
                strB.Append(Environment.NewLine + Environment.NewLine);

            }
            return strB.ToString();
        }
        public CellValue CellsByPostion(Position position)
        {
            return (CellValue)boardMatrix[position.Row, position.Col];
            //return Cells[position.Row, position.Col];
        }
        public BoardPhaseEnum BoardPhase
        {
            get
            {
                // return BoardPhaseEnum.Begining;

                int NumberofDisk = this.NumberofBlackDisk() + this.NumberofWhiteDisk();

                if (NumberofDisk <= 20)
                {
                    return BoardPhaseEnum.Begining;
                }
                if (NumberofDisk <= 40)
                {
                    return BoardPhaseEnum.Middle;
                }
                return BoardPhaseEnum.EndGame;

            }
        }
        public PlayerColor GetOponentValue(PlayerColor cValue)
        {
            if (cValue == PlayerColor.Black)
            {
                return PlayerColor.White;
            }
            if (cValue == PlayerColor.White)
            {
                return PlayerColor.Black;
            }

            throw new Exception("CellValue is invalid");
        }
        public int NumberofBothDisk()
        {
            return NumberofWhiteDisk() + NumberofBlackDisk();
        }
        public int NumberofWhiteDisk()
        {

            int iCountWhiteDisk = 0;
            foreach (int iValue in boardMatrix)
            {
                if (iValue == 1)
                {
                    iCountWhiteDisk++;
                }
            }
            return iCountWhiteDisk;
        }
        public int NumberofDisk(Board.PlayerColor color)
        {
            if (color == PlayerColor.Black)
            {
                return NumberofBlackDisk();
            }
            return NumberofWhiteDisk();
        }
        public int NumberofBlackDisk()
        {
            int iCountBlackDisk = 0;
            foreach (int iValue in boardMatrix)
            {
                if (iValue == -1)
                {
                    iCountBlackDisk++;
                }
            }
            return iCountBlackDisk;
        }
        public Board(BoardValue pBoardValue)
        {
            this.boardMatrix = pBoardValue.boardMatrix;

            this.CurrentTurnNumber = pBoardValue.CurrentTurnNumber;
            this.CurrentTurn = (PlayerColor)pBoardValue.Turn;

        }
        public BoardValue GetBoardValue()
        {
            BoardValue boardValue = new BoardValue();

            boardValue.boardMatrix = new int[8, 8];
            Array.Copy(this.boardMatrix, boardValue.boardMatrix, this.boardMatrix.Length);

            boardValue.CurrentTurnNumber = this.CurrentTurnNumber;
            boardValue.Turn = (int)this.CurrentTurn;
            return boardValue;
        }
        public Board()
        {
            boardMatrix = new int[8, 8];
            SetCell(3, 3, CellValue.White);
            SetCell(3, 4, CellValue.Black);
            SetCell(4, 3, CellValue.Black);
            SetCell(4, 4, CellValue.White);
            listPutPosition.Clear();
        }

        public Board(Board OriginalBoard)
        {
            boardMatrix = new int[8, 8];
            Array.Copy(OriginalBoard.boardMatrix, this.boardMatrix, this.boardMatrix.Length);
            this.CurrentTurn = OriginalBoard.CurrentTurn;
            if (OriginalBoard.LastPutPosition != null)
            {
                this.SetLastPutPosition(OriginalBoard.LastPutPosition.Clone());
            }
        }

        private void SetCell(Position pPostion, int iValue)
        {
            SetCell(pPostion, (CellValue)iValue);
        }
        private void SetCell(Position pPosition, CellValue cellValue)
        {
            SetCell(pPosition.Row, pPosition.Col, cellValue);
        }
        private void SetCell(int Row, int Col, int iValue)
        {
            boardMatrix[Row, Col] = (int)iValue;
        }
        public void SetCell(int Row, int Col, CellValue cellValue)
        {
            boardMatrix[Row, Col] = (int)cellValue;
        }
        private CellValue GetCellValueByChar(char c)
        {
            CellValue cellValue = CellValue.Blank;
            switch (c)
            {
                case 'W':
                    cellValue = CellValue.White;
                    break;
                case 'B':
                    cellValue = CellValue.Black;
                    break;
                case ' ':
                    cellValue = CellValue.Blank;
                    break;
                default:
                    throw new Exception("cellValue as char value must be W,B or blank");
                    break;
            }
            return cellValue;

        }
        public void SetCellsByColumn(int Column, String cellValueAsString)
        {
            if (cellValueAsString.Length != BoardSize)
            {
                throw new Exception("cellValueAsString is " + cellValueAsString + " which the length need to be " + BoardSize);
            }
            int Row = 0;
            foreach (char cell in cellValueAsString)
            {
                if (cell != 'W' &&
                    cell != 'B' &&
                    cell != ' ')
                {
                    throw new Exception("cellValueAsString value value must be 8 characers of W,B or blank example WWWWBBBB");
                }
                CellValue cellValue = GetCellValueByChar(cell);
                SetCell(Row, Column, cellValue);
                Row++;
            }
        }
        public void SetCellsByRow(int Row, String cellValueAsString)
        {
            if (cellValueAsString.Length != BoardSize)
            {
                throw new Exception("cellValueAsString is " + cellValueAsString + " which the length need to be " + BoardSize);
            }
            int Col = 0;
            foreach (char cell in cellValueAsString)
            {
                if (cell != 'W' &&
                    cell != 'B' &&
                    cell != ' ')
                {
                    throw new Exception("cellValueAsString value value must be 8 characers of W,B or blank example WWWWBBBB");
                }
                CellValue cellValue = GetCellValueByChar(cell);
                SetCell(Row, Col, cellValue);
                Col++;
            }

        }
        public void SetCellList(List<Position> list, CellValue cellValue)
        {
            int i;
            for (i = 0; i < list.Count; i++)
            {
                this.SetCell(list[i].Row, list[i].Col, cellValue);

            }
        }
        private CellValue GetCell(Position pPosition)
        {
            return GetCell(pPosition.Row, pPosition.Col);
        }
        private CellValue GetCell(int Row, int Col)
        {
            return (CellValue)boardMatrix[Row, Col];
        }
        public CellValue GetCellValueFromPlayerColor(PlayerColor cValue)
        {
            if (cValue == PlayerColor.Black)
            {
                return CellValue.Black;
            }
            if (cValue == PlayerColor.White)
            {
                return CellValue.White;
            }
            throw new Exception("Player color value is invalid");
        }

        public Boolean IsLegalMove(int pRow, int pCol, PlayerColor cValue)
        {
            Position Position = new Position(pRow, pCol);
            return IsLegalMove(Position, cValue);
        }
        private int _NumberofLastFlipCell = 0;
        public int NumberofLastFlipCell
        {
            get
            {
                return _NumberofLastFlipCell;
            }
        }
        public void PutAndAlsoSwithCurrentTurn(int Row, int Column, PlayerColor cValue)
        {
            PutAndAlsoSwithCurrentTurn(new Position(Row, Column), cValue);
        }
        public void PutAndAlsoSwithCurrentTurn(Position pPosition, PlayerColor cValue)
        {
            _NumberofLastFlipCell = 0;
            if (!IsLegalMove(pPosition, cValue))
            {
                throw new Exception("Cannot put " + cValue + " at " + pPosition.Row.ToString() + " " + pPosition.Col.ToString());
            }

            SetCell(pPosition.Row, pPosition.Col, GetCellValueFromPlayerColor(cValue));

            int iRow;
            int iCol;
            CellValue OponentValue = CellValue.White;

            if (cValue == Board.PlayerColor.White)
            {
                OponentValue = CellValue.Black;
            }


            List<Position> PositionFlip = new List<Position>();

            Position positionCheck = null;
            CellValue PlayerColor = GetCellValueFromPlayerColor(cValue);

            for (iRow = -1; iRow <= 1; iRow++)
            {
                //Boolean HasAtLeasOneOpoonentColor = false;
                List<Position> PositionFlipInDirection = new List<Position>();
                for (iCol = -1; iCol <= 1; iCol++)
                {
                    if (iRow == 0 && iCol == 0)
                    {
                        continue;
                    }
                    positionCheck = pPosition.Clone();
                    PositionFlipInDirection = new List<Position>();
                    Boolean IsFished = false;
                    while (!IsFished)
                    {
                        positionCheck.Row += iRow;
                        positionCheck.Col += iCol;

                        if (positionCheck.Row < 0 ||
                           positionCheck.Row > 7 ||
                           positionCheck.Col < 0 ||
                           positionCheck.Col > 7)
                        {
                            IsFished = true;
                            break;
                        }
                        //SimpleLog.WriteLog("Put:: " + positionCheck.Row + " " + positionCheck.Col);


                        if (GetCell(positionCheck) == CellValue.Blank)
                        {
                            //SimpleLog.WriteLog("Put::   Got blank");
                            break;
                        }
                        else if (GetCell(positionCheck) == PlayerColor)
                        {
                            //SimpleLog.WriteLog("Put::   Same value");
                            if (PositionFlipInDirection != null && PositionFlipInDirection.Count > 0)
                            {
                                PositionFlip.AddRange(PositionFlipInDirection);

                            }
                            break;
                        }
                        else if (GetCell(positionCheck) == OponentValue)
                        {
                            //SimpleLog.WriteLog("Put::   Oppo value");
                            // HasAtLeasOneOpoonentColor = true;
                            PositionFlipInDirection.Add(new Position(positionCheck.Row, positionCheck.Col));
                        }
                    }
                }
            }
            foreach (Position pos in PositionFlip)
            {
                SetCell(pos, PlayerColor);
                //Cells[pos.Row, pos.Col] = GetCellValueFromPlayerColor(cValue);


            }
            _LastPutPositon = pPosition.Clone();
            _NumberofLastFlipCell = PositionFlip.Count;
            //listPutPosition.Add(pPosition);
            SwitchTurn();
        }

        private int CurrentTurnNumber = 0;

        private List<Position> _listPutPosition = null;
        private List<Position> listPutPosition
        {
            get
            {
                if (_listPutPosition == null)
                {
                    _listPutPosition = new List<Position>();
                }
                return _listPutPosition;
            }

        }
        public void SetLastPutPosition(Position pLastPutPosition)
        {
            _LastPutPositon = pLastPutPosition.Clone();
        }
        private Position _LastPutPositon = null;
        public Position LastPutPosition
        {
            get
            {
                return _LastPutPositon;
                /*
                if(_LastPutPositon == Position.Empty)
                {

                }
                if (listPutPosition.Count == 0)
                {
                    return null;
                }
                return listPutPosition[listPutPosition.Count - 1];
                */
            }
        }

        public int BoardSize => 8;// throw new NotImplementedException();

        private void KeepPutPostionHistory(Position pos)
        {
            //           _listPutPosition.Add(pos);
        }
        public Boolean IsTherePlaceToPut(PlayerColor cValue)
        {
            int i;
            int j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (IsLegalMove(i, j, cValue))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Boolean IsTherePlaceToPut()
        {
            int i;
            int j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (IsLegalMove(i, j, this.CurrentTurn))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private List<Position> GetLegalMove(PlayerColor cValue)
        {
            List<Position> lst = new List<Position>();
            int i;
            int j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (IsLegalMove(i, j, cValue))
                    {
                        lst.Add(new Position(i, j));
                    }
                }
            }
            return lst;
        }

        private List<Position> GetLegalMove()
        {
            return GetLegalMove(this.CurrentTurn);
        }
        // public PlayerColor CurrentTurn = PlayerColor.White;
        public Board.PlayerColor CurrentTurn = Board.PlayerColor.Black;
        public void SwitchTurnDueToPlayerPass()
        {
            this.SwitchTurn();
        }
        public PlayerColor OpponentTurn
        {
            get
            {
                if (CurrentTurn == PlayerColor.White)
                {
                    return PlayerColor.Black;
                }
                return PlayerColor.White;
            }
        }
        private void SwitchTurn()
        {
            if (CurrentTurn == PlayerColor.White)
            {
                CurrentTurn = PlayerColor.Black;
            }
            else
            {
                CurrentTurn = PlayerColor.White;
            }
        }

        public Boolean IsLegalMove(Position Position, PlayerColor cValue)
        {
            if (Position.Row < 0 ||
                Position.Col < 0 ||
                Position.Row > this.boardMatrix.GetLength(0) - 1 ||
                Position.Col > this.boardMatrix.GetLength(1) - 1)
            {
                return false;
            }

            if (GetCell(Position) != CellValue.Blank)
            {
                return false;
            }
            CellValue OponentValue = GetCellValueFromPlayerColor(GetOponentValue(cValue));
            int iRowChange;
            int iColChange;
            Position PositionCheck = Position;

            for (iRowChange = -1; iRowChange <= 1; iRowChange++)
            {
                for (iColChange = -1; iColChange <= 1; iColChange++)
                {
                    if (iRowChange == 0 && iColChange == 0)
                    {
                        continue;
                    }
                    Boolean HasAtLeasOneOpoonentColor = false;
                    PositionCheck = Position.Clone();
                    while (true)
                    {
                        PositionCheck.Row += iRowChange;
                        PositionCheck.Col += iColChange;


                        if (PositionCheck.Row < 0 ||
                           PositionCheck.Row > 7 ||
                           PositionCheck.Col < 0 ||
                           PositionCheck.Col > 7)
                        {
                            break;
                        }

                        if (CellsByPostion(PositionCheck) == CellValue.Blank)
                        {
                            break;
                        }
                        if (CellsByPostion(PositionCheck) == GetCellValueFromPlayerColor(cValue))
                        {
                            if (!HasAtLeasOneOpoonentColor)
                            {
                                break;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        if (CellsByPostion(PositionCheck) == OponentValue)
                        {
                            HasAtLeasOneOpoonentColor = true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Position> generateMoves()
        {
            return GetLegalMove();
        }
        public List<Position> generateMoves(PlayerColor color)
        {
            return GetLegalMove(color);
        }

        public IBoard Clone()
        {
            Board NewBoard = new Board(this);
            return NewBoard;

        }


        public void PutValue(int Row, int Col, int Value)
        {
            //this.Put(Row ,Col , (PlayerColor)Value);
            Position pos = new Position(Row, Col);
            PutValue(pos, Value);
        }

        public void PutValue(Position position, int Value)
        {
            // throw new NotImplementedException();
            this.PutAndAlsoSwithCurrentTurn(position, (PlayerColor)Value);
        }
    }



    public class BoardCompositScore
    {
        public Board board = null;
        public List<PositionScore> listPositionScore { get; set; } = new List<PositionScore>();
        public BoardCompositScore(Board pboard)
        {
            board = pboard;
        }
        public BoardCompositScore(Board pboard, List<PositionScore> plistPositionScore)
        {
            board = pboard;
            listPositionScore = new List<PositionScore>();
            plistPositionScore.ForEach(x => listPositionScore.Add(x.ClonePositionScore()));
        }
    }
}
