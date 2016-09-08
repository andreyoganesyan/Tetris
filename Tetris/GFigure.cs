using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GFigure : Figure
    {
        public override List<Point> TakenPoints
        {
            get
            {
                List<Point> takenPoints = new List<Point>();
                for (int i = 0; i < figureMatrix.Length; i++)
                {

                }
            }
            
        }
        int rotationState;
        byte[][,] rotationStates;
        public GFigure()
        {
            rotationStates = new byte[4][,];
            rotationStates[0] = new byte[,] { { 1, 0, 0 },
                                              { 1, 1, 1 },
                                              { 0, 0, 0 } };

            rotationStates[1] = new byte[,] { { 1, 1, 0 },
                                              { 1, 0, 0 },
                                              { 1, 0, 0 } };

            rotationStates[2] = new byte[,] { { 1, 1, 1 },
                                              { 0, 0, 1 },
                                              { 0, 0, 0 } };

            rotationStates[3] = new byte[,] { { 0, 1, 0 },
                                              { 0, 1, 0 },
                                              { 1, 1, 0 } };
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
