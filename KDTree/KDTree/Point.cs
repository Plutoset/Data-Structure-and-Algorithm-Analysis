using System;

namespace KDTree
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString() => $"({X}, {Y})";
        public static double Distance(Point point1, Point point2)
        {
            double distance = Math.Sqrt(
                Math.Pow(point1.X - point2.X, 2) +
                Math.Pow(point1.Y - point2.Y, 2));
            return distance;
        }
        public static double ManhanttanDistance(Point point1, Point point2)
        {
            double distance = (
                Math.Abs(point1.X - point2.X) +
                Math.Abs(point1.Y - point2.Y));
            return distance;
        }
    }
    
}
