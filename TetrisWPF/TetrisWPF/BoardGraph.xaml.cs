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
        System.Timers.Timer timer;
        bool GameIsOn = true;
        public BoardGraph(int numOfRows, int numOfColumns, double width, double height, Point initialCoords)
        {
            InitializeComponent();
            board = new Board(numOfColumns, numOfRows, initialCoords);
            board.onGameOver += Board_onGameOver;
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
            timer = new System.Timers.Timer(300);

            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        private void Board_onGameOver(object sender, EventArgs e)
        {
            GameIsOn = false;
            MainWindow.mainWindow.Gameover();


        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (GameIsOn)
            {
                //CleanFigure();
                CleanFreeTiles();
                int completedRowsCount;
                board.Progress(out completedRowsCount);
                DrawFigure(board.CurrentFigure);
                if (completedRowsCount != 0)
                {
                    CleanFreeTiles();
                }
                DrawFrom(board.TakenPoints);
            }
        }

        public void PaintTileAt(Point point, Brush brush)
        {
            this.Dispatcher.Invoke(() =>
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
            });
        }
        void DrawFrom(byte[,] takenPoints)
        {

            for (int i = 0; i < takenPoints.GetLength(0); i++)
            {
                for (int j = 0; j < takenPoints.GetLength(1); j++)
                {
                    if (takenPoints[i, j] == 1)
                    {
                        PaintTileAt(new Point(j, i), Brushes.Black);
                    }
                }
            }
        }
        void DrawFigure(Figure figure)
        {
            if (figure != null)
            {
                foreach (Point point in figure.RelativeTakenPoints)
                {
                    PaintTileAt(point + figure.coords, Brushes.Black);
                }
            }
        }
        void CleanFreeTiles()
        {
            this.Dispatcher.Invoke(() =>
            {
                for (int i = 0; i < board.TakenPoints.GetLength(0); i++)
                {
                    for (int j = 0; j < board.TakenPoints.GetLength(1); j++)
                    {
                        if (board.TakenPoints[i, j] == 0)
                        {
                            PaintTileAt(new Point(j, i), Brushes.White);
                        }
                    }
                }
            });
        }
        void CleanFigure()
        {
            if (board.CurrentFigure != null)
            {
                foreach (Point point in board.CurrentFigure.RelativeTakenPoints)
                {

                    if (board.CurrentFigure != null) PaintTileAt(point + board.CurrentFigure.coords, Brushes.White);
                    else break;
                }
            }
        }
        public void KeyIsDown(KeyEventArgs e)
        {
            if (board != null && board.CurrentFigure != null)
            {
                switch (e.Key)
                {
                    case (Key.Left):
                        {
                            if (board.CurrentFigure.CanMove(board.TakenPoints, Direction.Left))
                            {
                                CleanFigure();
                                board.CurrentFigure.Move(Direction.Left);
                                DrawFigure(board.CurrentFigure);
                            }
                            break;
                        }
                    case (Key.Right):
                        {
                            if (board.CurrentFigure.CanMove(board.TakenPoints, Direction.Right))
                            {
                                CleanFigure();
                                board.CurrentFigure.Move(Direction.Right);
                                DrawFigure(board.CurrentFigure);
                            }
                            break;
                        }
                    case (Key.Up):
                        {
                            if (board.CurrentFigure is RotatableFigure)
                            {

                                if ((board.CurrentFigure as RotatableFigure).CanRotate(board.TakenPoints))
                                {
                                    CleanFigure();
                                    (board.CurrentFigure as RotatableFigure).Rotate();
                                    DrawFigure(board.CurrentFigure);
                                }

                            }
                            break;
                        }
                    case (Key.Down):
                        {
                            
                            while (board.CurrentFigure != null && board.CurrentFigure.CanMove(board.TakenPoints, Direction.Down))
                            {
                                CleanFigure();
                                board.CurrentFigure.Move(Direction.Down);
                                DrawFigure(board.CurrentFigure);
                            }
                            if (GameIsOn)
                            {
                                CleanFigure();
                                int completedRowsCount;
                                board.Progress(out completedRowsCount);
                                DrawFigure(board.CurrentFigure);
                                if (completedRowsCount != 0)
                                {
                                    CleanFreeTiles();
                                }
                                DrawFrom(board.TakenPoints);
                            }
                            break;
                        }
                }
            }
        }

    }
}
