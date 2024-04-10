using Chess_WPF.Pieces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace Chess_WPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ChessboardState chessboardState;
        public ObservableCollection<SquareViewModel> Chessboard { get; set; }

        public MainViewModel()
        {
            chessboardState = new ChessboardState();
            Chessboard = new ObservableCollection<SquareViewModel>();
            InitializeChessboard();
            chessboardState.SetupPieces();
            UpdateChessboard();
        }

        private void InitializeChessboard()
        {

            for (int row = 0; row < Constants.Sizes.RowsAndCols; row++)
            {
                for (int col = 0; col < Constants.Sizes.RowsAndCols; col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        Chessboard.Add(new SquareViewModel { Color = Brushes.White });
                    }
                    else
                    {
                        Chessboard.Add(new SquareViewModel { Color = Brushes.Gray });
                    }
                }
            }
        }

        public void UpdateChessboard()
        {
            for (int row = 0; row < ChessboardState.COL_ROW_SIZE; row++)
            {
                for (int col = 0; col < ChessboardState.COL_ROW_SIZE; col++)
                {
                    ChessPiece piece = chessboardState.GetPiece(row, col);
                    if (piece != null)
                    {
                        // Determine the piece name based on the type of chess piece
                        string pieceName = "";
                        if (piece is Pawn)
                        {
                            pieceName = piece.IsWhite ? "♙" : "♟";
                        }
                        else if (piece is Rook)
                        {
                            pieceName = piece.IsWhite ? "♖" : "♜";
                        }
                        else if (piece is Knight)
                        {
                            pieceName = piece.IsWhite ? "♘" : "♞";
                        }
                        else if (piece is Bishop)
                        {
                            pieceName = piece.IsWhite ? "♗" : "♝";
                        }
                        else if (piece is Queen)
                        {
                            pieceName = piece.IsWhite ? "♕" : "♛";
                        }
                        else if (piece is King)
                        {
                            pieceName = piece.IsWhite ? "♔" : "♚";
                        }

                        // Update the PieceName property of the corresponding ChessboardSquare
                        Chessboard[row * ChessboardState.COL_ROW_SIZE + col].PieceName = pieceName;
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
