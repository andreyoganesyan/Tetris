using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class SquareFigure : Figure
    {
        public SquareFigure()
        {
            figureMatrix = new byte[,]{ { 1, 1, 0 },
                                        { 1, 1, 0 },
                                        { 0, 0, 0 } };
            coords = Board.board.initialCoords;
        }
        public override void Move(int dx, int dy)
        {
            throw new NotImplementedException();
        }

        public override void Rotate() { }
    }
}
