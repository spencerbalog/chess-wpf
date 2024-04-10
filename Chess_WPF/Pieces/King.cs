using System;

namespace Chess_WPF.Pieces
{
    internal class King : ChessPiece
    {
        public King(bool isWhite, int row, int column) : base(Constants.Pieces.King, isWhite, row, column)
        {

        }

        public override bool IsValidMove(int newRow, int newColumn)
        {
            throw new NotImplementedException();
        }
    }
}
