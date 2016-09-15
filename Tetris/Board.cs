using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Board
    {
      
        Point initialCoords;
        private byte[,] takenPoints;

        Figure currentFigure = null;

        public Board(int width, int height, Point initialCoords)
        {
            takenPoints = new byte[height, width];
            this.initialCoords = initialCoords;
        }

        private void Progress() {
            if (currentFigure == null)
            {
                currentFigure = Figure.GetRandomFigure(initialCoords);
            }
            else if (currentFigure.CanMove(takenPoints, Direction.Down))
            {
                currentFigure.Move()
            }
        }
        public void AddFigure() { }
    }
}
