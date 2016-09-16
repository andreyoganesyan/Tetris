using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TetrisWPF
{
    /// <summary>
    /// Interaction logic for BoardGraph.xaml
    /// </summary>
    public partial class BoardGraph : UserControl
    {
        Canvas canvas;
        Board board;
        public BoardGraph(int numOfRows, int numOfColumns, double width, double height, Point initialCoords)
        {
            InitializeComponent();
            board = new Board(numOfColumns, numOfRows, initialCoords);
            canvas = new Canvas();
            MainUC.AddChild(canvas);
            canvas.Height = MainUC.Height;
            canvas.Width = MainUC.Width;
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    Tile tempTile = new Tile();
                    canvas.Children.Add(tempTile);
                    Canvas.SetLeft(tempTile, j * (width / board.Width));
                    Canvas.SetTop(tempTile, i * (height / board.Height));
                    tempTile.Name = "Tile" + i + "_" + j;
                }
            }
            System.Timers.Timer timer = new System.Timers.Timer(3000);
            
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            board.Progress();
            DrawFrom(board.TakenPoints, board.CurrentFigure);

        }

        public void PaintTileAt(Point point, Brush brush)
        {
            for (int k = 0; k < canvas.Children.Count; k++)
            {
                if (canvas.Children[k] is Tile)
                {
                    Tile tile = canvas.Children[k] as Tile;
                    if (tile.Name == "Tile" + point.Y + "_" + point.X)
                    {
                        tile.Paint(brush);
                        return;
                    }
                }
            }
        }
        public void DrawFrom(byte[,] takenPoints, Figure currentFigure)
        {
            Clean();
            for (int i = 0; i < takenPoints.GetLength(0); i++)
            {
                for (int j = 0; j < takenPoints.GetLength(1); j++)
                {
                    if (takenPoints[i, j] == 1) {
                        PaintTileAt(new Point(j, i), Brushes.Black);
                    }
                }
            }
            if (board.CurrentFigure != null)
            {
                foreach (Point point in board.CurrentFigure.RelativeTakenPoints)
                {
                    PaintTileAt(point + board.CurrentFigure.coords, Brushes.Black);
                }
            }
        }
        void Clean()
        {
            foreach (object elem in canvas.Children)
            {
                if (elem is Tile)
                {
                    (elem as Tile).Paint(Brushes.White);
                }
            }
        }
    }
}
