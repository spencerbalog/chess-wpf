public class ChessboardGrid
{
    private readonly ChessboardSquare[,] squares;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public ChessboardGrid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        squares = new ChessboardSquare[rows, columns];

        // Initialize the chessboard squares
        InitializeSquares();
    }

    private void InitializeSquares()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                squares[row, col] = new ChessboardSquare(row, col);
            }
        }
    }

    public ChessboardSquare GetSquare(int row, int column)
    {
        if (IsValidPosition(row, column))
        {
            return squares[row, column];
        }
        else
        {
            return null;
        }
    }

    private bool IsValidPosition(int row, int column)
    {
        return row >= 0 && row < Rows && column >= 0 && column < Columns;
    }
}
