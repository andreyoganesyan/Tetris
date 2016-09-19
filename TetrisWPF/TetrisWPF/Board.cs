using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWPF
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

        public void Progress(out int completedRowsCount)
        {
            completedRowsCount = 0;
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
                CurrentFigure = null;

                RemoveCompletedRows(out completedRowsCount);

            }
        }

        void RemoveCompletedRows(out int completedRowsCount)
        {
            completedRowsCount = 0;
            for (int i = takenPoints.GetLength(0)-1; i >= 0; i--)
            {
                if (RowIsCompleted(i))
                {
                    RemoveRow(i);
                    completedRowsCount++;
                    i++;
                }
            }

        }
        bool RowIsCompleted(int numberOfRow)
        {
            for (int i = 0; i < takenPoints.GetLength(1); i++)
            {
                if (takenPoints[numberOfRow,i] == 0) {
                    return false;
                }
            }
            return true;
        }
        void RemoveRow(int numberOfRow)
        {
            for (int i = numberOfRow; i > 0; i--)
            {
                for (int j = 0; j < takenPoints.GetLength(1); j++)
                {
                    takenPoints[i, j] = takenPoints[i - 1, j];
                }
            }
            for (int j = 0; j < takenPoints.GetLength(1); j++)
            {
                takenPoints[0, j] = 0;
            }
        }
    }
}
