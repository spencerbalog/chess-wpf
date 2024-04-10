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
        private bool IsDragging;
        private UIElement DraggedElement;

        public MainWindow(bool isDragging, UIElement draggedElement)
        {
            InitializeComponent();
            InitializeChessboardGrid();
            this.IsDragging = isDragging;
            this.DraggedElement = draggedElement;
        }

        private void InitializeChessboardGrid()
        {
            // Create the ChessboardGrid as a Grid
            var ChessboardGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

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
                DraggedElement = (UIElement)sender;
                IsDragging = true;
                DraggedElement.CaptureMouse();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging && DraggedElement != null)
            {
                var currentPosition = e.GetPosition(this);
                Canvas.SetLeft(DraggedElement, currentPosition.X - (DraggedElement.RenderSize.Width / 2));
                Canvas.SetTop(DraggedElement, currentPosition.Y - (DraggedElement.RenderSize.Height / 2));
            }
        }
    }
}
