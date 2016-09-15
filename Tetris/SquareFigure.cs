using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class SquareFigure : Figure
    {
        byte[,] figureMatrix;
        public SquareFigure(Point initialCoords)
        {
            figureMatrix = new byte[,]{ { 1, 1 },
                                        { 1, 1 } };
            coords = initialCoords;
            RelativeTakenPoints = GetRelativeTakenPointsFromArray(figureMatrix);
        }

    }
}
