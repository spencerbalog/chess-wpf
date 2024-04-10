using System;

namespace Chess_WPF.Pieces
{
    public class Queen : ChessPiece
    {
        public Queen(bool isWhite, int row, int column) : base(Constants.Pieces.Queen, isWhite, row, column)
        {

        }

        public override bool IsValidMove(int newRow, int newColumn)
        {
            throw new NotImplementedException();
        }
    }
}
