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
        public static double Intersection(Point point1,Point point2, Point point3, Point point4)
        {
            return (double)((point3.X - point1.X) * (point4.Y - point2.Y) - (point3.Y - point1.Y) * (point4.X - point2.X));
        }
        public override string ToString() => $"({X}, {Y})";
    }
    
}
