using System.ComponentModel;
using System.Windows.Media;

public class ChessboardSquare : INotifyPropertyChanged
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    private Brush squareColor;
    public Brush SquareColor
    {
        get { return squareColor; }
        set
        {
            squareColor = value;
            OnPropertyChanged(nameof(SquareColor));
        }
    }

    private string pieceName;
    public string PieceName
    {
        get { return pieceName; }
        set
        {
            pieceName = value;
            OnPropertyChanged(nameof(PieceName));
        }
    }

    // Constructor with row and column parameters
    public ChessboardSquare(int row, int column)
    {
        Row = row;
        Column = column;
    }

    // Implement INotifyPropertyChanged interface
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
