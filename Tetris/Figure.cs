using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        public Point[] TakenPoints;
        abstract public void Move(int dx, int dy);
        abstract public void RotateClockwise();
        abstract public void RotateCounterClockwise();

    }
}
