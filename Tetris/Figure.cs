using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum Direction {Left, Right, Down, Up}
    abstract class Figure
    {
        protected List<Point> RelativeTakenPoints { get; set; }
        
        protected Point coords;
        public void Move(Direction direction) {
            switch (direction)
            {
                case Direction.Right:
                    coords += new Point(1, 0);
                    break;
                case Direction.Left:
                    coords += new Point(-1, 0);
                    break;
                case Direction.Up:
                    coords += new Point(0, -1);
                    break;
                case Direction.Down:
                    coords += new Point(0, 1);
                    break;
            }
        }
        protected List<Point> GetRelativeTakenPointsFromArray(byte[,] figureMatrix)
        {
            List<Point> relativeTakenPoints = new List<Point>();
            for (int i = 0; i < figureMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < figureMatrix.GetLength(1); j++)
                {
                    if (figureMatrix[j, i] == 1)
                    {
                        relativeTakenPoints.Add(new Point(j, i));
                    }
                }
            }
            return relativeTakenPoints;
        }
        public bool CanMove(byte[,] boardMatrix, Direction direction)
        {
            Point moveVector = null;
            switch (direction) { 
                case Direction.Right: moveVector = new Point(1, 0);
                                      break;
                case Direction.Left: moveVector = new Point(-1, 0);
                                     break;
                case Direction.Up: moveVector = new Point(0, -1);
                                     break;
                case Direction.Down: moveVector = new Point(0, 1);
                                     break;
            }
            Point tempPoint;
            foreach (Point point in RelativeTakenPoints)
            {
                tempPoint = point + coords + moveVector;
                if (tempPoint.Y<0||tempPoint.X<0||tempPoint.Y>=boardMatrix.GetLength(0)||tempPoint.X>=boardMatrix.GetLength(1)|| boardMatrix[tempPoint.Y, tempPoint.X]==1)
                {
                    return false;
                }
            }
            return true;
        }
        public static Figure GetRandomFigure(Point initialCoords)
        {
            int randNumber = (new Random()).Next() * 5;
            switch (randNumber)
            {
                case 0:
                    {
                        return new GFigure(initialCoords);
                    }
                case 1:
                    {
                        return new LineFigure(initialCoords);
                    }
                case 2:
                    {
                        return new SquareFigure(initialCoords);
                    }
                case 3:
                    {
                        return new TFigure(initialCoords);
                    }
                case 4:
                    {
                        return new LeftStepsFigure(initialCoords);
                    }
                default:
                    {
                        return new RightStepsFigure(initialCoords);
                    }
            }
        }

    }
}
