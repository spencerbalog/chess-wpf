using System;

namespace Chess_WPF.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(bool isWhite, int row, int column) : base(Constants.Pieces.Knight, isWhite, row, column)
        {

        }

        public override bool IsValidMove(int newRow, int newColumn)
        {
            throw new NotImplementedException();
        }
    }
}
