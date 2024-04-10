using System;

namespace Chess_WPF.Pieces
{
    internal class Bishop : ChessPiece
    {
        public Bishop(bool isWhite, int row, int column) : base(Constants.Pieces.Bishop, isWhite, row, column)
        {

        }

        public override bool IsValidMove(int newRow, int newColumn)
        {
            throw new NotImplementedException();
        }
    }
}
