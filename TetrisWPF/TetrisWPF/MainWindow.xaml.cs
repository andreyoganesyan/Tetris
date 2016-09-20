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
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (boardGraph == null)
                {
                    gamoverLbl.Visibility = Visibility.Hidden;
                    startLbl.Visibility = Visibility.Hidden;
                    boardGraph = new BoardGraph(20, 10, 200, 400, new Point(4, 0));
                    Grid.Children.Add(boardGraph);
                }
            }
            if (boardGraph!=null) boardGraph.KeyIsDown(e);
        }

        public void Gameover()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid.Children.Remove(boardGraph);
                boardGraph = null;
                gamoverLbl.Visibility = Visibility.Visible;
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
