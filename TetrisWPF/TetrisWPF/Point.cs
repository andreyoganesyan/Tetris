﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWPF
{
    public class Point
    {
        public int X {
            get;
        }
        public int Y
        {
            get;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point point, Point vector)
        {
            return new Point(point.X + vector.X, point.Y + vector.Y);
        }
    }
}
