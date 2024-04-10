using System;

namespace Chess_WPF.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(bool isWhite, int row, int column) : base(Constants.Pieces.Pawn, isWhite, row, column)
        {

        }

        public override bool IsValidMove(int newRow, int newColumn)
        {
            throw new NotImplementedException();
        }
    }
}
