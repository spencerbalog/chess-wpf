using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chess_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging;
        private UIElement draggedElement;

        public MainWindow()
        {
            InitializeComponent();
            InitializeChessboardGrid();
        }

        private void InitializeChessboardGrid()
        {
            // Create the ChessboardGrid as a Grid
            Grid ChessboardGrid = new Grid();
            ChessboardGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            ChessboardGrid.VerticalAlignment = VerticalAlignment.Stretch;

            // Define rows and columns
            for (int i = 0; i < 8; i++)
            {
                ChessboardGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                ChessboardGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            }

            // Add the ChessboardGrid to the MainWindow
            Content = ChessboardGrid;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                draggedElement = (UIElement)sender;
                isDragging = true;
                draggedElement.CaptureMouse();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedElement != null)
            {
                var currentPosition = e.GetPosition(this);
                Canvas.SetLeft(draggedElement, currentPosition.X - (draggedElement.RenderSize.Width / 2));
                Canvas.SetTop(draggedElement, currentPosition.Y - (draggedElement.RenderSize.Height / 2));
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && isDragging && draggedElement != null)
            {
                isDragging = false;
                draggedElement.ReleaseMouseCapture();

                ChessboardSquare square = GetSquareAtMousePosition(e.GetPosition(ChessboardGrid));
            }
        }

        private ChessboardSquare GetSquareAtMousePosition(Point mousePoint)
        {
            foreach (var squareViewModel in MainViewModel.Chessboard)
            {
                // Perform hit testing on each square ViewModel
                if (IsMouseOverSquare(squareViewModel, mousePoint))
                {
                    // Extract row and column information from the ViewModel
                    int row = squareViewModel.Row;
                    int column = squareViewModel.Column;

                    // Create and return a ChessboardSquare with the corresponding ViewModel
                    return new ChessboardSquare(row, column)
                    {
                        SquareColor = squareViewModel.Color,
                        PieceName = squareViewModel.PieceName
                    };
                }
            }

            return null; // No ChessboardSquare found at the mouse position
        }

        private bool IsMouseOverSquare(SquareViewModel squareViewModel, Point mousePoint)
        {
            // Perform hit testing on the square ViewModel
            // You need to implement this method according to your specific requirements
            // This could involve checking the bounding rectangle of the square for mouse containment
            // or any other appropriate method for determining if the mouse is over the square
            // For example:
            //return squareViewModel.Bounds.Contains(mousePoint);
        }

    }
}
