using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCross 
{ 
    
    class Polygon
    {
        LoopNode<Point> font = new();
        enum PointAndPolygon { Inside, Outside, OnBoundary };
        /// <summary>
        /// 构造器
        /// </summary>
        public Polygon()
        {
            font = new LoopNode<Point>();
            font.Visit = true;
        }
        public Polygon(Point point)
        {
            font.Data = point;
        }
        double xmin, xmax, ymin, ymax;
        // <summary>
        /// 在index处修改值，被直接索引给替代，不再维护
        /// </summary>
        /// <param name="data"></param>
        [Obsolete]
        public void Modify(Point point, int index)
        {
            if(font.Visit == true)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            LoopNode<Point> nowNode = font;
            int i = 1;
            if (i == index)
            {
                nowNode.Data = point;
                return;
            }
            nowNode = nowNode.Next;
            while (nowNode != font)
            {
                i++;
                if (i == index)
                {
                    nowNode.Data = point;
                    break;
                }
                nowNode = nowNode.Next;
            }
            if (i > index || index < 1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// WARNING UNCOMPLETED FUNCTION
        /// 通过内容检索并且返回值并没有什么意思，就不写了
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [Obsolete]
        public Point Find(Point point)
        {
            LoopNode<Point> nowNode = font;
            int i = 1;
            if (font.Visit == true)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            while (nowNode.Visit == false)
            {
                if (nowNode.Data.Equals(point))
                {
                    return nowNode.Data;
                }
                i++;
                nowNode.Visit = true;
                nowNode = nowNode.Next;
            }
            Reflesh();
            throw new IndexOutOfRangeException("Input Point not in List!");
        }

        /// <summary>
        /// 循环打印链式表中的所有元素
        /// </summary>
        public override string ToString()
        {
            LoopNode<Point> pn = font;
            int j = 0;
            if (font.Visit == true)
            {
                return "No Points in this Polygon. \n";
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                while (pn.Visit == false)
                {
                    j++;
                    stringBuilder.AppendLine($"Point{j}, X {pn.Data.X} Y {pn.Data.Y}");
                    pn = pn.Next;
                }
                Reflesh();
                return stringBuilder.ToString();
            }
        }
            //}
            /// <summary>
            /// 找出并打印index位置的元素，如果超出范围则console报错并且返回null值
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                if (font.Visit == true)
                {
                    throw new IndexOutOfRangeException("Empty Polygon.");
                }
                LoopNode<Point> nowNode = font;
                int i = 1;
                if (index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                while (nowNode.Visit == false)
                {
                    if (i == index)
                    {
                        return nowNode.Data;
                    }
                    i++;
                    nowNode.Visit = true;
                    nowNode = nowNode.Next;
                }
                Reflesh();
                if (i > index || index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return default;
            }
            set
            {
                LoopNode<Point> nowNode = font;
                int i = 1;
                if (i == index)
                {
                    nowNode.Data = value;
                    Reflesh();
                    return;
                }
                if (font.Visit == true)
                {
                    throw new IndexOutOfRangeException("Empty Polygon.");
                }
                while(nowNode.Visit == false)
                {
                    if (i == index)
                    {
                        nowNode.Data = value;
                        break;
                    }
                    nowNode.Visit = true;
                    nowNode = nowNode.Next;
                    i++;
                }
                Reflesh();
                if (i > index || index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
            
        //}

        /// <summary>
        /// 判空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return font.Visit == true;
        }
        /// <summary>
        /// 在index处入队
        /// </summary>
        /// <param name="point"></param>
        public void Insert(Point point, int index)
        {
            //新建节点
            LoopNode<Point> tmp = new LoopNode<Point>(point);
            LoopNode<Point> nowNode = font;
            int i = 1;
            if (index == 1)
            {
                if (font.Visit == true)
                {
                    tmp.Next = tmp;
                    font = tmp;
                    return;
                }
                else
                {
                    LoopNode<Point> store = font;
                    font = tmp;
                    font.Next = store;
                    if (store == store.Next)
                    {
                        store.Next = font;
                    }
                    return;
                }
            }
            while (nowNode.Visit == false)
            {
                if (index == i + 1)
                {
                    LoopNode<Point> store = nowNode.Next;
                    tmp.Next = store;
                    nowNode.Next = tmp;
                    Reflesh();
                    return;
                }
                nowNode.Visit = true;
                nowNode = nowNode.Next;
                i++;
            }
            Reflesh();
            BoundaryOfPolygon();
            if (i < index || index < 1)
            {
                throw new IndexOutOfRangeException();
            }
        }
            /// <summary>
            /// 刷新Polygon中众多节点的索引状态为初始值false
            /// </summary>
            public void Reflesh()
            {
                LoopNode<Point> pn = font;
                while (pn.Visit == true)
                {
                    pn.Visit = false;
                    pn = pn.Next;
                }
            }
        /// <summary>
        /// 在链式表的最后加上点
        /// </summary>
        /// <param name="point"></param>
        public void Add(Point point)
        {
            //新建节点
            LoopNode<Point> tmp = new LoopNode<Point>(point);
            LoopNode<Point> nowNode = font;

            if (font.Visit == true)
            {
                tmp.Next = tmp;
                font = tmp;
                return;
            }
            while (nowNode.Next.Visit == false)
            {
                nowNode.Visit = true;
                nowNode = nowNode.Next;
            }
            LoopNode<Point> store = nowNode.Next;
            tmp.Next = store;
            nowNode.Next = tmp;
            Reflesh();
            BoundaryOfPolygon();
        }
        /// <summary>
        /// 删除index处的节点，如果index超出范围则console报错并且不执行操作
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            LoopNode<Point> nowNode = font;
            int i = 0;
            if (index == 1)
            {
                if (font.Visit == true)
                {
                    throw new IndexOutOfRangeException("No Points in this Polygon.");
                }
                LoopNode<Point> newNode = font.Next;
                if (newNode.Next == font)
                {
                    font = newNode;
                    font.Next = null;
                    return;
                }
                LoopNode<Point> store = font;
                font = font.Next;
                nowNode = nowNode.Next;
                while (nowNode.Next != store)
                {
                    nowNode = nowNode.Next;
                }
                nowNode.Next = newNode;
                return;
            }
            else
            {
                while (nowNode.Next != font)
                {
                    i++;
                    if (i == index - 1)
                    {
                        LoopNode<Point> store = nowNode.Next.Next;
                        nowNode.Next = store;
                        nowNode = nowNode.Next;
                        break;
                    }
                    nowNode = nowNode.Next;
                }
                if (i < index - 1 || index < 1)
                {
                    throw new IndexOutOfRangeException();
                }

            }
        }
        /// <summary>
        /// 计算多边形面积，倘若多边形的点数在三个以下则报错"Invalid Polygon!"
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            LoopNode<Point> nowNode = font;
            int number = 0;
            double area = 0;
            while (nowNode.Visit == false && nowNode.Next != null)
            {
                number++;
                nowNode.Visit = true;
                nowNode = nowNode.Next;
            }
            Reflesh();
            switch (number)
            {
                case < 3:
                    throw new IndexOutOfRangeException("Invalid Polygon with Points less than 3.");
                default:
                    nowNode = font;
                    while (nowNode.Visit == false)
                    {
                        area += 0.5 * Math.Abs((nowNode.Next.Data.Y + nowNode.Data.Y)) *
                                                (nowNode.Next.Data.X - nowNode.Data.X);
                        nowNode.Visit = true;
                        nowNode = nowNode.Next;
                    }
                    break;
            }
            Reflesh();
            return area;
        }
        /// <summary>
        /// 计算多边形周长，倘若多边形的点数在三个以下则报错"Invalid Polygon!"
        /// </summary>
        /// <returns></returns>
        public double GetPer()
        {
            LoopNode<Point> nowNode = font;
            int number = 0;
            double per = 0;
            while (nowNode.Visit == false && nowNode.Next != null)
            {
                number++;
                nowNode.Visit = true;
                nowNode = nowNode.Next;
            }
            Reflesh();
            switch (number)
            {
                case < 3:
                    throw new IndexOutOfRangeException("Invalid Polygon with Points less than 3.");
                default:
                    nowNode = font;
                    while (nowNode.Visit == false)
                    {
                        per += Math.Sqrt(Math.Pow((nowNode.Next.Data.Y - nowNode.Data.Y), 2) +
                                                    Math.Pow((nowNode.Next.Data.X - nowNode.Data.X), 2));
                        nowNode.Visit = true;
                        nowNode = nowNode.Next;
                    }
                    break;
            }
            Reflesh();
            return per;
        }
        /// <summary>
        /// 计算point是否在多边形的一条边上
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public string PointOnPolygon(Point point)
        {
            LoopNode<Point> pn = font;
            int? pp = null;
            while (pn.Visit == false)
            {
                // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点
                // 因为嫌麻烦，所以我只判断了和左下角的连线。
                Point p1 = pn.Data;
                Point p2 = pn.Next.Data;
                double intersection = ((point.X - p1.X) * (p2.Y - p1.Y) - (point.Y - p1.Y) * (p2.X - p1.X));
                if (Math.Min(p1.X, p2.X) <= point.X
                    & point.X <= Math.Max(p1.X, p2.X)
                    & Math.Min(p1.Y, p2.Y) <= point.Y
                    & point.Y <= Math.Max(p1.Y, p2.Y)
                    & intersection == 0
                    )
                {
                    pp = 1;
                    break;
                }
                pn.Visit = true;
                pn = pn.Next;
            }
            if (pp == null)
            {
                pp = 2;
            }
            Reflesh();
            PointAndPolygon b = (PointAndPolygon)pp;
            string b1 = b.ToString();
            //return b.ToString();
            return "Point is not on the boundary of the Polygon.";
        }
        /// <summary>
        /// 计算point是否在Polygon之内，首先调用PointOnPolygon(Point point)判断point是否在Polygon的边界上。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public string PointInPolygon(Point point)
        {
            LoopNode<Point> pn = font;
            int? pp = null;
            while (pn.Visit == false)
            {
                // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点
                // 因为嫌麻烦，所以我只判断了和左下角的连线。
                Point p1 = pn.Data;
                Point p2 = pn.Next.Data;
                double intersection = Point.Intersection(p1, p1, point, p2);
                if (Math.Min(p1.X, p2.X) <= point.X
                    & point.X <= Math.Max(p1.X, p2.X)
                    & Math.Min(p1.Y, p2.Y) <= point.Y
                    & point.Y <= Math.Max(p1.Y, p2.Y)
                    & intersection == 0
                    )
                {
                    pp = 1;
                    break;
                }
                pn.Visit = true;
                pn = pn.Next;
            }
            Reflesh();

            if (pp == null)
            {
                int intersection = 0;
                bool overlapSeg = false;
                pn = font;
                while (pn.Visit == false)
                {
                    // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点
                    // 因为嫌麻烦，所以我只判断了和左下角的连线。
                    Point LeftBottom = new Point(xmin, ymin);
                    double intersection1 = Point.Intersection(pn.Next.Data, point, pn.Data, pn.Data);
                    double intersection2 = Point.Intersection(pn.Next.Data, LeftBottom, pn.Data, pn.Data); ;
                    switch (intersection1 * intersection2)
                    {
                        case < 0: // 输入点与边界左下角的连线与当前多边形边界线有交点
                            intersection++;
                            break;
                        case 0:
                            // 为了防范两条连线拥有共同端点，重复计数
                            if (overlapSeg)
                            {
                                // 前一段多边形边界线和输入点与边界左下角的连线有交点，此时不计入相交
                                overlapSeg = false;
                            }
                            else
                            {
                                // 前一段多边形边界线和输入点与边界左下角的连线没有交点，此时计入一次相交
                                intersection++;
                                overlapSeg = true;
                            }
                            break;
                    }
                    pn.Visit = true;
                    pn = pn.Next;
                }
                pp = (intersection % 2) switch
                {
                    0 => 2,
                    _ => 0,
                };
            }
            Reflesh();
            PointAndPolygon b = (PointAndPolygon)pp;
            string b1 = b.ToString();
            return b1;
            //string result = PointOnPolygon(point);
            //if (result == "Point is on the boundary of the Polygon.")
            //{
            //    return result;
            //}
            //List<double> boundary = BoundaryOfPolygon();
            //if (boundary == null)
            //{
            //    return "Invalid Polygon!";
            //}
            //double xmax = boundary[0];
            //double xmin = boundary[1];
            //double ymax = boundary[2];
            //double ymin = boundary[3];
            //int intersection = 0;
            //bool overlapSeg = false;
            //LoopNode<Point> pn = font;

            //while (pn.Visit == false)
            //{
            //    // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点
            //    // 因为嫌麻烦，所以我只判断了和左下角的连线。
            //    double intersection1 = ((pn.Data.X - pn.Next.Data.X) * (pn.Data.Y - point.Y) - (pn.Data.Y - pn.Next.Data.Y) * (pn.Data.X - point.X));
            //    double intersection2 = ((pn.Data.X - pn.Next.Data.X) * (pn.Data.Y - ymin) - (pn.Data.Y - pn.Next.Data.Y) * (pn.Data.X - xmin));
            //    if (intersection1 * intersection2 < 0)
            //    {
            //        intersection++;
            //    }

            //    else if (intersection1 * intersection2 == 0)
            //    {
            //        // 为了防范两条连线拥有共同端点，重复计数
            //        if (overlapSeg)
            //        {
            //            // 前一段多边形边界线和输入点与边界左下角的连线有交点，此时不计入相交
            //            overlapSeg = false;
            //        }
            //        else
            //        {
            //            // 前一段多边形边界线和输入点与边界左下角的连线没有交点，此时计入一次相交
            //            intersection++;
            //            overlapSeg = true;
            //        }
            //    }
            //    pn.Visit = true;
            //    pn = pn.Next;
            //}
            //if (intersection % 2 == 0)
            //{
            //    return "The input point is outside the input polygon.";
            //}
            //else
            //{
            //    return "The input point is inside the input polygon.";
            //}
        }
        /// <summary>
        /// 计算Polygon在xy方向上的最大最小值，并且以List<double>返回。如果Polygon不具有三个及以上的节点，则返回空值。
        /// </summary>
        /// <returns></returns>
        public void BoundaryOfPolygon()
        {
            LoopNode<Point> pn = font;
            int j = 0;
            if (font.Visit == true)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            xmax = pn.Data.X;
            xmin = pn.Data.X;
            ymax = pn.Data.Y;
            ymin = pn.Data.Y;
            j++;
            pn = pn.Next;
            while (pn.Visit == false && pn != null)
            {
                if (pn.Data.X > xmax) { xmax = pn.Data.X; }
                if (pn.Data.X < xmin) { xmin = pn.Data.X; }
                if (pn.Data.Y > ymax) { ymax = pn.Data.Y; }
                if (pn.Data.Y < ymin) { ymin = pn.Data.Y; }
                j++;
                pn.Visit = true;
                pn = pn.Next;
            }
            Reflesh();
            if (j < 3) { throw new IndexOutOfRangeException("Invalid Polygon with Points less than 3."); }
        }
    }
}
