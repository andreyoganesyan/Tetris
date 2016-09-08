using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TFigure : Figure
    {
        int rotationState;
        byte[][,] rotationStates;
        public TFigure()
        {
            rotationStates = new byte[4][,];
            rotationStates[0] = new byte[,] { { 0, 1, 0 },
                                              { 1, 1, 1 },
                                              { 0, 0, 0 } };

            rotationStates[1] = new byte[,] { { 1, 0, 0 },
                                              { 1, 1, 0 },
                                              { 1, 0, 0 } };

            rotationStates[2] = new byte[,] { { 1, 1, 1 },
                                              { 0, 1, 0 },
                                              { 0, 0, 0 } };

            rotationStates[3] = new byte[,] { { 0, 1, 0 },
                                              { 1, 1, 0 },
                                              { 0, 1, 0 } };
            rotationState = 0;
            figureMatrix = rotationStates[rotationState];
            coords = Board.board.initialCoords;
        }
        public override void Move(int dx, int dy)
        {
            throw new NotImplementedException();
        }

        public override void Rotate()
        {
            rotationState++;
            rotationState %= rotationStates.Length;
            figureMatrix = rotationStates[rotationState];
        }
    }
}
