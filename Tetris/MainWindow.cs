using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Board board = new Board(10, 20, new Point(6, 6));
            //BoardDGV.ColumnCount = board.Width;
            //BoardDGV[0,0].
            //BoardDGV.RowCount = board.Height;
        }

        private void BoardDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BoardHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
