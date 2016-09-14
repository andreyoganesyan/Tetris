using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class RightStepsFigure:RotatableFigure
    {
        public RightStepsFigure()
        {
            rotationStates = new byte[2][,];
            rotationStates[0] = new byte[,] { { 0, 1, 1 },
                                              { 1, 1, 0 } };

            rotationStates[1] = new byte[,] { { 1, 0 },
                                              { 1, 1 },
                                              { 0, 1 } };

            rotationState = 0;
            coords = Board.board.initialCoords;
            RelativeTakenPoints = GetRelativeTakenPointsFromArray(rotationStates[rotationState]);
        }
    }
}
