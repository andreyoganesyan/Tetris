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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardGraph boardGraph;
        public MainWindow()
        {
            InitializeComponent();
            boardGraph = new BoardGraph(20, 10, 200, 400, new Point(4, 0));
            Grid.Children.Add(boardGraph);

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            boardGraph.KeyIsDown(e);
        }
    }
}
