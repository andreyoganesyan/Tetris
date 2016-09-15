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
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        Rectangle newRect;
        public Tile()
        {

            InitializeComponent();
            newRect = new Rectangle();
            newRect.Width = this.Width;
            newRect.Height = this.Height;
            newRect.Fill = Brushes.White;
            this.AddChild(newRect);
        }
        public void Paint(Brush brush)
        {
            newRect.Fill = brush;
        }

    }
}
