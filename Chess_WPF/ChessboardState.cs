using Chess_WPF.Pieces;
using System;

namespace Chess_WPF
{
    public class ChessboardState
    {
        public const int COL_ROW_SIZE = 8;
        private readonly ChessPiece[,] board;
        public ChessboardState()
        {
            board = new ChessPiece[COL_ROW_SIZE, COL_ROW_SIZE];
            InitializeEmptyBoard();
        }

        private void InitializeEmptyBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = null; // Set each square to null (empty)
                }
            }
        }

        // Method to get the chess piece at a specified position
        public ChessPiece GetPiece(int row, int col)
        {
            // Check if the specified position is within the bounds of the board
            if (IsValidPosition(row, col))
            {
                return board[row, col]; // Return the chess piece at the specified position
            }
            else
            {
                return null; // Return null if the position is invalid
            }
        }

        // Method to place a chess piece on the board
        public void PlacePiece(ChessPiece piece, int row, int col)
        {
            // Check if the specified position is within the bounds of the board
            if (IsValidPosition(row, col))
            {
                // Create a new instance of the ChessPiece with updated position
                ChessPiece? newPiece = Activator.CreateInstance(piece.GetType(), piece.IsWhite, row, col) as ChessPiece;
                board[row, col] = newPiece; // Place the new piece on the board
            }
        }

        // Method to remove a chess piece from the board
        public void RemovePiece(int row, int col)
        {
            // Check if the specified position is within the bounds of the board
            if (IsValidPosition(row, col))
            {
                board[row, col] = null; // Remove the piece from the board
            }
        }

        private ChessPiece GetPieceFromCol(bool isWhite, int row, int col)
        {
            switch (col)
            {
                case 0: return new Rook(isWhite, row, col);
                case 1: return new Knight(isWhite, row, col);
                case 2: return new Bishop(isWhite, row, col);
                case 3: return new Queen(isWhite, row, col);
                case 4: return new King(isWhite, row, col);
                case 5: return new Bishop(isWhite, row, col);
                case 6: return new Knight(isWhite, row, col);
                case 7: return new Rook(isWhite, row, col);
                default: throw new ArgumentOutOfRangeException(nameof(col), "Invalid column index");
            }
        }

        private void PlacePieces(bool isWhite, int[] backRank, int[] pawnRank)
        {
            int backRankRow = isWhite ? 7 : 0;
            int pawnRankRow = isWhite ? 6 : 1;

            for (int col = 0; col < COL_ROW_SIZE; col++)
            {
                PlacePiece(GetPieceFromCol(isWhite, backRank[col], col), backRankRow, col);
                PlacePiece(new Pawn(isWhite, pawnRankRow, col), pawnRankRow, col);
            }
        }

        public void SetupPieces()
        {
            int[] whiteBackRank = { 0, 1, 2, 3, 4, 5, 6, 7 };
            int[] whitePawnRank = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] blackBackRank = { 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] blackPawnRank = { 6, 6, 6, 6, 6, 6, 6, 6 };

            PlacePieces(true, whiteBackRank, whitePawnRank);
            PlacePieces(false, blackBackRank, blackPawnRank);
            PlacePiece(new Bishop(true, 7, 2), 7, 2);
            PlacePiece(new Bishop(true, 7, 5), 7, 5);
            PlacePiece(new Rook(false, 0, 0), 0, 0);
            PlacePiece(new Rook(false, 0, 7), 0, 7);
        }



        // Helper method to check if a position is within the bounds of the board
        private static bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }
    }
}
