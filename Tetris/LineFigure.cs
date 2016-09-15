using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class LineFigure : RotatableFigure
    {
        
        public LineFigure(Point initialCoords)
        {
            rotationStates = new byte[2][,];
            rotationStates[0] = new byte[,] { { 0, 1 },
                                              { 0, 1 },
                                              { 0, 1 },
                                              { 0, 1 } };

            rotationStates[1] = new byte[,] { { 0, 0, 0, 0 },
                                              { 1, 1, 1, 1 } };
            rotationState = 0;
            coords = initialCoords;
            RelativeTakenPoints = GetRelativeTakenPointsFromArray(rotationStates[rotationState]);
        }
        
    }
}
