using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
    }
}
