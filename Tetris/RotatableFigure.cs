using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class RotatableFigure:Figure
    {
        
        protected int rotationState;
        protected byte[][,] rotationStates;

        public void Rotate()
        {
            rotationState++;
            rotationState %= rotationStates.Length;
            RelativeTakenPoints = GetRelativeTakenPointsFromArray(rotationStates[rotationState]);
        }
    }
}
