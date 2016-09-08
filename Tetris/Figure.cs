using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        abstract public List<Point> TakenPoints { get;  }

        protected Point coords;
        protected byte[,] figureMatrix;
        abstract public void Move(int dx, int dy);
        abstract public void Rotate();
       

    }
}
