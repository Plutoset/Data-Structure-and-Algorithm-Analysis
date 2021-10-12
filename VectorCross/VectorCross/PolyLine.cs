//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VectorCross
//{
//    class PolyLine
//    {
//        private List<Point> data = new List<Point>();
//        public List<Point> Data { get => data; set => data = value; }
//        public PolyLine() { }
//        public PolyLine(List<Point> data)
//        {
//            this.Data = data;
//        }
//        /// <summary>
//        /// 判断point是否在第index段折线段上
//        /// </summary>
//        /// <param name="point"></param>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public string PointOnLine(Point point, int index)
//        {
//            if (index < 1)
//            {
//                return "Invalid Index place. Please enter an index larger than 1.";
//            }
//            if (GetSegCount() < index)
//            {
//                return "No PolyLine Detected. Please add more points to this polyline, inspect the input index, or checkout another.";
//            }
//            try
//            {
//                Point p1 = Data[index - 1];
//                Point p2 = Data[index];
//                double intersection = (point.X - p1.X) * (p2.Y - p1.Y) - (point.Y - p1.Y) * (p2.X - p1.X);
//                if (Math.Min(p1.X, p2.X) <= point.X
//                    & point.X <= Math.Max(p1.X, p2.X)
//                    & Math.Min(p1.Y, p2.Y) <= point.Y
//                    & point.Y <= Math.Max(p1.Y, p2.Y)
//                    & intersection == 0
//                    )
//                {
//                    return "Point is on the Polyline.";
//                }
//                else
//                {
//                    return "Point is not on the Polyline.";
//                }
//            }
//            catch { }
//            return "No PolyLine Detected. Please add more points to this polyline, inspect the input index, or checkout another.";
//        }
//        /// <summary>
//        /// 在PolyLine的末尾添加线段
//        /// </summary>
//        /// <param name="point"></param>
//        public void Add(Point point)
//        {
//            this.Data.Add(point);
//        }
//        public double GetSegCount()
//        {
//            return Data.Count;
//        }
//        /// <summary>
//        /// 第index个节点的拐向
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public string GetSegDirection(int index)
//        {
//            if (index <= 1)
//            {
//                return "Invalid Index place. Please enter an index larger than 1.";
//            }
//            if(GetSegCount() < index)
//            {
//                return "No Segment Detected. Please add more points to this polyline, inspect the input index, or checkout another.";
//            }
//            try
//            {
//                Point p0 = Data[index - 2];
//                Point p1 = Data[index - 1];
//                Point p2 = Data[index];
//                double direction = ((p2.X - p0.X) * (p1.Y - p0.Y)) - ((p1.X - p0.X) * (p2.Y - p0.Y));
//                if (direction < 0)
//                {
//                    return "Segment anticlockwise";
//                }
//                if (direction == 0)
//                {
//                    return "Segment collinear";
//                }
//                if (direction > 0)
//                {
//                    return "Segment clockwise";
//                }
//            }
//            catch
//            {
//            }
//            return "No Segment Detected. Please add more points to this polyline, inspect the input index, or checkout another.";
//        }
//        /// <summary>
//        /// 判断polyLine1的第index1段线与polyLine2的第index2段线是否相交。
//        /// </summary>
//        /// <param name="polyLine1"></param>
//        /// <param name="index1"></param>
//        /// <param name="polyLine2"></param>
//        /// <param name="index2"></param>
//        /// <returns></returns>
//        public static string LineIntersect(PolyLine polyLine1, int index1, PolyLine polyLine2, int index2)
//        {
//            if (index1 < 1)
//            {
//                return "Invalid Index place for the first polyLine input. Please enter an index larger than 1.";
//            }
//            if (index2 < 1)
//            {
//                return "Invalid Index place for the second polyLine input. Please enter an index larger than 1.";
//            }
//            if (polyLine1.Data.Count() < index1 & polyLine2.Data.Count() < index2)
//            {
//                return "The two PolyLines input are invalid. Please add more points to the wrong polylines, inspect the input index, or checkout another.";
//            }
//            else if (polyLine1.Data.Count() < index1 & polyLine2.Data.Count() > index2)
//            {
//                return "The first PolyLine input is invalid. Please add more points to the wrong polyline, inspect the input index, or checkout another.";
//            }
//            else if (polyLine1.Data.Count() > index1 & polyLine2.Data.Count() < index2)
//            {
//                return "The second PolyLine input is invalid. Please add more points to the wrong polyline, inspect the input index, or checkout another.";
//            }
//            else
//            {
//                Point p1 = polyLine1.Data[index1 - 1];
//                Point p2 = polyLine1.Data[index1];
//                Point q1 = polyLine2.Data[index2 - 1];
//                Point q2 = polyLine2.Data[index2];

//                double intersection1 = (p1.X - p2.X) * (p1.Y - q1.Y) - (p1.Y - p2.Y) * (p1.X - q1.X);
//                double intersection2 = (p1.X - p2.X) * (p1.Y - q2.Y) - (p1.Y - p2.Y) * (p1.X - q2.X);

//                if (intersection1 * intersection2 < 0)
//                {
//                    return "The two Polylines intersect.";
//                }
//                else if (intersection1 * intersection2 > 0)
//                {
//                    return "The two Polylines do not intersect.";
//                }
//                else
//                {
//                    if (intersection1 == 0 && intersection2 == 0)
//                    {
//                        return "The two Polylines have a common endpoint, and overlap each other.";
//                    }
//                    else if (intersection1 == 0 || intersection2 == 0)
//                    {
//                        return "The two Polylines have a common endpoint.";
//                    }
                    
//                    return "The two Polylines overlap each other.";
//                }
//            }
//        }
//    }
//}
    

