using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TFigure : RotatableFigure
    {
        public TFigure(Point initialCoords)
        {
            rotationStates = new byte[4][,];
            rotationStates[0] = new byte[,] { { 0, 1, 0 },
                                              { 1, 1, 1 } };

            rotationStates[1] = new byte[,] { { 1, 0 },
                                              { 1, 1 },
                                              { 1, 0 } };

            rotationStates[2] = new byte[,] { { 1, 1, 1 },
                                              { 0, 1, 0 } };

            rotationStates[3] = new byte[,] { { 0, 1 },
                                              { 1, 1 },
                                              { 0, 1 } };
            rotationState = 0;
            coords = initialCoords;
            RelativeTakenPoints = GetRelativeTakenPointsFromArray(rotationStates[rotationState]);
        }

    }
}
