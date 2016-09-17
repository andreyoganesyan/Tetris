using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWPF
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
        public bool CanRotate(byte[,] boardMatrix)
        {
            foreach (Point point in GetRelativeTakenPointsFromArray(rotationStates[(rotationState + 1) % rotationStates.Length]))
            {
                Point tempPoint = point + coords;
                if (tempPoint.Y < 0 || tempPoint.X < 0 || tempPoint.Y >= boardMatrix.GetLength(0) || tempPoint.X >= boardMatrix.GetLength(1) || boardMatrix[tempPoint.Y, tempPoint.X] == 1){
                    return false;
                }
            }
            return true;
        }
    }
}
