using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KReversi.Utility
{
    public static  class Utility
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max + 1);
            }
        }
        public static String NowAsString() => DateTime.Now.ToString("yyyyMMddHHmmssss");
        /*
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssss");
        }
        */
        public static String ConvertToReversiNotation(Position position)
            => ConvertToReversiNotation(position.Row, position.Col);
        /*
        {
            return ConvertToReversiNotation(position.Row ,position.Col );

        }
        */
        public static String ConvertToReversiNotation(int Row,int Column)
        {
            String stringColumn = "ABCDEFGH";
            if(Row < 0 || Row > 7 || Column < 0 || Column > 7)
            {
                return "";
            }
            return stringColumn.Substring(Column, 1) + (Row + 1);

        }
        public static  bool IsInt(String value)
        {
            int Result = 0;
            return int.TryParse(value, out Result);

        }
        public static int ToInt(this String value)
        {
            return int.Parse(value);
        }
        public static Boolean IsBetween(this int value, int MinValue, int MaxValue)
            => value >= MinValue && value <= MaxValue;
        /*
    {

        return (value >= MinValue && value <= MaxValue);
    }
    */
        public static Boolean IsBetween(this String value, int MinValue, int MaxValue)
            => value.ToInt() >= MinValue && value.ToInt() <= MaxValue;
        /*
        {
            
            return (value.ToInt () >= MinValue && value.ToInt () <= MaxValue);
        }
        */
        /*
        public static  Position From1DimensionTo2(int index, int NoofRow)
        {
            Position P = new Position(index / NoofRow, index % NoofRow);
            return P;
        }
        */
        public static Position From1DimensionTo2(int index, int NoofRow)
            => new Position(index / NoofRow, index % NoofRow);

        public static int From2DimensionTo1(int Row, int Column, int RowSize)
            => From2DimensionTo1(new Position(Row, Column), RowSize);
        /*
        {
            return From2DimensionTo1(new Position(Row, Column), RowSize);
        }
        */
        public static  int From2DimensionTo1(Position pos, int RowSize)
            => (pos.Row * (RowSize)) + pos.Col;
        /*
        {
            int Result = (pos.Row * (RowSize)) + pos.Col;
            return Result;
        }
        */



    }
}
