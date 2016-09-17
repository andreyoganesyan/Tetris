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

namespace Tetris
{
    /// <summary>
    /// Interaction logic for BoardGraph.xaml
    /// </summary>
    public partial class BoardGraph : UserControl
    {
        Canvas canvas;
        public BoardGraph(int numOfRows, int numOfColumns, Point initialCoords)
        {
            InitializeComponent();
            Board board = new Board(numOfColumns,numOfRows, initialCoords);
            canvas = new Canvas();
            MainUC.AddChild(canvas);
            canvas.Height = MainUC.Height;
            canvas.Width = MainUC.Width;
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    Tile tempTile = new Tile();
                    canvas.Children.Add(tempTile);
                    Canvas.SetLeft(tempTile, j * (canvas.Width / board.Width));
                    Canvas.SetTop(tempTile, i * (canvas.Height / board.Height));
                    tempTile.Name = "Tile" + i + "-" + j;
                }
            }
        }

        private void MainUC_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public void PaintTileAt(Point point, Brush brush)
        {
            for (int k = 0; k < canvas.Children.Count; k++)
            {
                if (canvas.Children[k] is Tile) {
                    Tile tile = canvas.Children[k] as Tile;
                    if (tile.Name =="Tile"+point.Y+"-"+point.X)
                    {
                        tile.Paint(brush);
                        return;
                    }
                 }
            }
        }


    }
}
