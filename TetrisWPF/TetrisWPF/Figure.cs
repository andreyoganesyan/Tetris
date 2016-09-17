using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWPF
{
    public enum Direction {Left, Right, Down, Up}
    public abstract class Figure
    {
        public List<Point> RelativeTakenPoints { get; protected set; }
        
        public Point coords { get; protected set; }
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
                    if (figureMatrix[i, j] == 1)
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
            Random rand = new Random();
            int randNumber = rand.Next(0,6);
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
                case 5:
                    {
                        return new RightStepsFigure(initialCoords);
                    }
                default: return null;
            }
        }
        public void SettleOn(ref byte[,] boardMatrix)
        {
            foreach (Point point in RelativeTakenPoints)
            {
                Point tempPoint = point + coords;
                boardMatrix[tempPoint.Y, tempPoint.X] = 1;
            }
            
        }
    }
}
