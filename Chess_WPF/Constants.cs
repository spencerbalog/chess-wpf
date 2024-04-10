using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_WPF
{
    public class Constants
    {
        public struct Sizes
        {
            public const int RowsAndCols = 8;
            public const int TotalSquares = 64;
        }

        public struct Pieces
        {
            public const string Pawn = "Pawn";
            public const string Rook = "Rook";
            public const string Bishop = "Bishop";
            public const string Knight = "Knight";
            public const string Queen = "Queen";
            public const string King = "King";
        }
    }
}
