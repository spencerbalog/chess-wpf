using System;

namespace Chess_WPF.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(bool isWhite, int row, int column) : base(Constants.Pieces.Rook, isWhite, row, column)
        {

        }

        public override bool IsValidMove(int newRow, int newColumn)
        {
            throw new NotImplementedException();
        }
    }
}
