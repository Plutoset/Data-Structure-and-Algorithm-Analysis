using System;

namespace VectorCross
{
    class PolyLine : LQueue<Point>
    {
        public enum Segment {Anticlockwise, Extending, Clockwise, Backturn };
        /// <summary>
        /// 判断point是否在第index段折线段上
        /// </summary>
        /// <param name="point"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool PointOnLine(Point point)
        {
            Node<Point> pn = front;
            if (front == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            while (pn != rear)
            {
                // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点
                // 因为嫌麻烦，所以我只判断了和左下角的连线。
                Point p1 = pn.Data;
                Point p2 = pn.Next.Data;
                double intersection = Point.Segment(p1, p2, point);
                if (intersection == 2)
                {
                    return true;
                }
                pn = pn.Next;
            }
            return false;
        }
        /// <summary>
        /// 第index个节点的拐向
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Segment GetSegDirection(int index)
        {
            Node<Point> nowNode = front;
            if (front == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            if (index < 1)
            {
                throw new IndexOutOfRangeException();
            }
            int i = 1;
            int seg;
            while (nowNode.Next != rear)
            {
                if(i == index)
                {
                    Point p1 = nowNode.Data;
                    Point p2 = nowNode.Next.Data;
                    Point p3 = nowNode.Next.Next.Data;
                    double intersection = Point.Segment(p1, p3, p2);
                    seg = intersection switch
                    {
                        -1 => 0,    //从首点到节点，到首点到终点，逆时针方向旋转，anticlockwise
                        2 => 1,     //节点位于首尾两点中间，即延长，extending
                        1 => 2,     //从首点到节点，到首点到终点，顺时针方向旋转，clockwise
                        _ => 3,     //节点在首位两点的延长线上，即折返，backturn
                    };
                    return (Segment)seg;
                }
                nowNode = nowNode.Next;
            }
            if (i < index - 1)
            {
                throw new IndexOutOfRangeException();
            }
            return default;
        }
        /// <summary>
        /// 判断polyLine1是否相交。
        /// </summary>
        /// <param name="polyLine1"></param>
        /// <param name="polyLine2"></param>
        /// <returns></returns>
        public static bool LineIntersect(PolyLine polyLine1, PolyLine polyLine2)
        {
            Node<Point> nowNode1 = polyLine1.front;
            Node<Point> nowNode2 = polyLine2.front;
            if (nowNode1 == null && nowNode2 == null)
            {
                throw new IndexOutOfRangeException("The two Polylines input are invalid.");
            }
            else if (nowNode1 == null)
            {
                throw new IndexOutOfRangeException("The First Polyline input is invalid.");
            }
            else if (nowNode2 == null)
            {
                throw new IndexOutOfRangeException("The Second Polyline input is invalid.");
            }
            else
            {
                do
                {
                    do
                    {
                        bool intersection = Point.Intersection(nowNode1.Data, nowNode1.Next.Data, nowNode2.Data, nowNode2.Next.Data);
                        if (intersection)
                        {
                            return true;
                        }
                        nowNode2 = nowNode2.Next;
                    } while (nowNode2.Next != polyLine2.rear);
                    nowNode1 = nowNode1.Next;
                } while (nowNode1.Next != polyLine1.rear);
            }
            return default;
        }
    }
}


