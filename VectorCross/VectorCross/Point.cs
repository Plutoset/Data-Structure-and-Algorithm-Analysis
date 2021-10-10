﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCross
{
    class Point
    {
        private double x;
        private double y;
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public Point()
        {
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void SetX(double x)
        {
            this.X = x;
        }
        public void SetY(double y)
        {
            this.Y = y;
        }

    }
}
