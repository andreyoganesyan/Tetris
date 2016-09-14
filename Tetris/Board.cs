using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Board
    {
        public static Board board
        {
            get;
            private set;
        }
       
        public Point initialCoords;
        private bool[,] takenPoints;

        public Board()
        {
            board = this;
        }

        private void Progress() { }
        public void AddFigure() { }
    }
}
