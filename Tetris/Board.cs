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
        public byte[,] TakenPoints { get { return takenPoints; } }
        public int Width { get; }
        public int Height { get; }
        private byte[,] takenPoints;
        public Figure CurrentFigure { get; private set; }
        public Board(int width, int height, Point initialCoords)
        {
            Height = height;
            Width = width;
            takenPoints = new byte[height, width];
            this.initialCoords = initialCoords;
        }

        private void Progress() {
            if (CurrentFigure == null)
            {
                CurrentFigure = Figure.GetRandomFigure(initialCoords);
            }
            else if (CurrentFigure.CanMove(TakenPoints, Direction.Down))
            {
                CurrentFigure.Move(Direction.Down);
            }
            else
            {
                CurrentFigure.SettleOn(ref takenPoints);
            }
        }
    }
}
