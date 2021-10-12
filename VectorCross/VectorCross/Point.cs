using System;

namespace VectorCross
{
    //class Point
    //{
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //    public Point()
    //    {
    //    }
    //    public Point(double x, double y)
    //    {
    //        this.X = x;
    //        this.Y = y;
    //    }

    //}
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        /// <summary>
        /// P1P2是否跨立Q1Q2, 共线返回0，跨立返回1，不跨立返回-1
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        public static int Straddle(Point p1,Point p2, Point q1, Point q2)
        {
            if(Math.Min(p1.X, p2.X) <= Math.Max(q1.X, q2.X)
                    & Math.Min(q1.X, q2.X) <= Math.Max(p1.X, p2.X)
                    & Math.Min(p1.Y, p2.Y) <= Math.Max(q1.Y, q2.Y)
                    & Math.Min(q1.Y, q2.Y) <= Math.Max(p1.Y, p2.Y)
                    )
            {
                double straddle = (q1.X - p1.X) * (q2.Y - p2.Y) - (q1.Y - p1.Y) * (q2.X - p2.X);
                if (straddle > 0)
                {
                    return 1;
                }
                else if (straddle < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        ///  P1-point-P2的旋转方向，在延长线上返回0，逆时针返回-1，顺时针返回1，point在P1P2线段上返回2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static int Segment(Point p1, Point p2, Point point)
        {
            double intersection = ((point.X - p1.X) * (p2.Y - p1.Y) - (point.Y - p1.Y) * (p2.X - p1.X));
            if (intersection < 0)
            {
                return -1;
            }
            else if (intersection > 0)
            {
                return 1;
            }
            else
            {
                if (Math.Min(p1.X, p2.X) <= point.X
                & point.X <= Math.Max(p1.X, p2.X)
                & Math.Min(p1.Y, p2.Y) <= point.Y
                & point.Y <= Math.Max(p1.Y, p2.Y)
                & intersection == 0
                )
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// P1P2和Q1Q2是否相交
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        public static bool Intersection(Point p1, Point p2, Point q1, Point q2)
        {
            int straddle1 = Straddle(p1, p2, q1, q2);
            int straddle2 = Straddle(q1, q2, p1, p2);
            if (straddle1 > 0  & straddle2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Point IntersectionPoint(Point p1, Point p2, Point p3, Point p4)
        {
            double b1 = (p2.Y - p1.Y) * p1.X - (p2.X - p1.X) * p1.Y;
            double b2 = (p4.Y - p3.Y) * p3.X - (p4.X - p3.X) * p3.Y;
            double D = (p2.X - p1.X) * (p4.Y - p3.Y) - (p4.X - p3.X) * (p2.Y - p1.Y);
            double D1 = b2 * (p2.X - p1.X) - b1 * (p4.X - p3.X);
            double D2 = b2 * (p2.Y - p1.Y) - b1 * (p4.Y - p3.Y);
            return new Point(D1 / D, D2 / D);
        }
        public override string ToString() => $"({X}, {Y})";
    }
    
}
