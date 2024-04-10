using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_WPF
{
    public abstract class ChessPiece
    {
        public string Name { get; protected set; }
        public bool IsWhite { get; protected set; }
        public int Row { get; protected set; }
        public int Column { get; protected set; }

        public ChessPiece(string name, bool isWhite, int row, int column)
        {
            Name = name;
            IsWhite = isWhite;
            Row = row;
            Column = column;
        }

        public abstract bool IsValidMove(int newRow, int newColumn);
    }
}
