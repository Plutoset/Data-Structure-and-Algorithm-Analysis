﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCross 
{ 
    class Polygon
    {
        LoopNode<Point> font;
        public enum PointAndPolygon { Inside, Outside, OnBoundary };
        double xmin, xmax, ymin, ymax;
        /// <summary>
        /// 构造器
        /// </summary>
        public Polygon(){}
        public Polygon(Point point)
        {
            font.Data = point;
        }
        // <summary>
        /// 在index处修改值，被直接索引给替代，不再维护
        /// </summary>
        /// <param name="data"></param>
        [Obsolete]
        public void Modify(Point point, int index)
        {
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
            if (nowNode == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
                return default;
            }
            do
            {
                if (nowNode.Data.Equals(point))
                {
                    return nowNode.Data;
                }
                i++;
                nowNode = nowNode.Next;
            } while (nowNode != font);
            throw new IndexOutOfRangeException("Input Point not in List!");
            return default;
        }

        /// <summary>
        /// 循环打印链式表中的所有元素
        /// </summary>
        public override string ToString()
        {
            LoopNode<Point> pn = font;
            int j = 0;
            if (font == null)
            {
                return "No Points in this Polygon. \n";
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                do
                {
                    j++;
                    stringBuilder.AppendLine($"Point{j}, X {pn.Data.X} Y {pn.Data.Y}");
                    pn = pn.Next;
                } while (pn != font);
                return stringBuilder.ToString();
            }
        }
            /// <summary>
            /// 对index位置的元素进行索引或者赋值，如果超出范围则报错
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                if (font == null)
                {
                    throw new IndexOutOfRangeException("Empty Polygon.");
                }
                LoopNode<Point> nowNode = font;
                int i = 1;
                if (index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                do
                {
                    if (i == index)
                    {
                        return nowNode.Data;
                    }
                    i++;
                    nowNode = nowNode.Next;
                } while (nowNode != font);
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
                    return;
                }
                if (font == null)
                {
                    throw new IndexOutOfRangeException("Empty Polygon.");
                }
                do
                {
                    if (i == index)
                    {
                        nowNode.Data = value;
                        break;
                    }
                    nowNode = nowNode.Next;
                    i++;
                } while (nowNode != font);
                BoundaryOfPolygon();
                if (i > index || index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        /// <summary>
        /// 判空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return font != null;
        }
        /// <summary>
        /// 点point是否属于多边形的节点（数据）
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Point point)
        {
            LoopNode<Point> nowNode = font;
            do
            {
                if (nowNode.Data.X == point.X && nowNode.Data.Y == point.Y)
                {
                    return true;
                }
                nowNode = nowNode.Next;
            } while (nowNode != font);
            return false;
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
                if (font == null)
                {
                    tmp.Next = tmp;
                    font = tmp;
                    BoundaryOfPolygon();
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
                    BoundaryOfPolygon();
                    return;
                }
            }
            do
            {
                if (index == i + 1)
                {
                    LoopNode<Point> store = nowNode.Next;
                    tmp.Next = store;
                    nowNode.Next = tmp;
                    BoundaryOfPolygon();
                    return;
                }
                nowNode = nowNode.Next;
                i++;
            } while (nowNode != font); 
            BoundaryOfPolygon();
            if (i < index || index < 1)
            {
                throw new IndexOutOfRangeException();
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

            if (font == null)
            {
                tmp.Next = tmp;
                font = tmp;
                return;
            }
            do
            {
                nowNode = nowNode.Next;
            } while (nowNode.Next != font) ;
            LoopNode<Point> store = nowNode.Next;
            tmp.Next = store;
            nowNode.Next = tmp;
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
                if (font == null)
                {
                    throw new IndexOutOfRangeException("No Points in this Polygon.");
                }
                LoopNode<Point> newNode = font.Next;
                if(newNode == font)
                {
                    font = null;
                    return;
                }
                if (newNode.Next == font)
                {
                    font = newNode;
                    font.Next = font;
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
            if (font == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            LoopNode<Point> nowNode = font;
            int number = 0;
            double area = 0;
            do
            {
                number++;
                nowNode = nowNode.Next;
            } while (nowNode != font && nowNode.Next != null);
            switch (number)
            {
                case < 3:
                    throw new IndexOutOfRangeException("Invalid Polygon with Points less than 3.");
                default:
                    nowNode = font;
                    do
                    {
                        area += 0.5 * Math.Abs((nowNode.Next.Data.Y + nowNode.Data.Y)) *
                                                (nowNode.Next.Data.X - nowNode.Data.X);
                        nowNode = nowNode.Next;
                    } while (nowNode != font);
                    break;
            }
            return area;
        }
        /// <summary>
        /// 计算多边形周长，倘若多边形的点数在三个以下则报错"Invalid Polygon!"
        /// </summary>
        /// <returns></returns>
        public double GetPer()
        {
            if (font == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            LoopNode<Point> nowNode = font;
            int number = 0;
            double per = 0;
            do
            {
                number++;
                nowNode = nowNode.Next;
            } while (nowNode != font && nowNode.Next != null);
            switch (number)
            {
                case < 3:
                    throw new IndexOutOfRangeException("Invalid Polygon with Points less than 3.");
                default:
                    nowNode = font;
                    do
                    {
                        per += Math.Sqrt(Math.Pow((nowNode.Next.Data.Y - nowNode.Data.Y), 2) +
                                                    Math.Pow((nowNode.Next.Data.X - nowNode.Data.X), 2));
                        nowNode = nowNode.Next;
                    } while (nowNode != font);
                        break;
            }
            return per;
        }
        /// <summary>
        /// 计算point是否在Polygon之内，首先调用PointOnPolygon(Point point)判断point是否在Polygon的边界上。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public PointAndPolygon PointInPolygon(Point point)
        {
            LoopNode<Point> pn = font;
            int? pp = null;
            if (font == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            do
            {
                // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点
                // 因为嫌麻烦，所以我只判断了和左下角的连线。
                Point p1 = pn.Data;
                Point p2 = pn.Next.Data;
                double intersection = Point.Segment(p1, p2, point);
                if (intersection == 2)
                {
                    pp = 2;
                    break;
                }
                pn = pn.Next;
            } while (pn != font);

            if (pp == null)
            {
                int intersection = 0;
                pn = font;
                do
                {
                    // 判断输入点与边界左下角的连线与当前多边形边界线是否有交点，如果有，则将交点计算出来存储进去
                    // 因为嫌麻烦，所以我只判断了和(xmin - 1, ymin - 1)的连线。
                    Point LeftBottom = new Point(xmin - 1, ymin - 1);
                    Point p1 = pn.Data;
                    Point p2 = pn.Next.Data;
                    bool now_intersection = Point.Intersection(p1, p2, point, LeftBottom);
                    if (now_intersection)
                    {
                        intersection++;
                    }
                    pn = pn.Next;
                } while (pn != font);
                if (intersection%2 == 0)
                {
                    pp = 1; //outside
                }
                else
                {
                    pp = 0; // inside
                }
            }
            return (PointAndPolygon)pp;
        }
        /// <summary>
        /// 计算Polygon在xy方向上的最大最小值，并且以List<double>返回。如果Polygon不具有三个及以上的节点，则返回空值。
        /// </summary>
        /// <returns></returns>
        public void BoundaryOfPolygon()
        {
            LoopNode<Point> nowNode = font;
            int j = 0;
            if (font == null)
            {
                throw new IndexOutOfRangeException("Empty Polygon.");
            }
            xmax = nowNode.Data.X;
            xmin = nowNode.Data.X;
            ymax = nowNode.Data.Y;
            ymin = nowNode.Data.Y;
            j++;
            nowNode = nowNode.Next;
            do
            {
                if (nowNode.Data.X > xmax) { xmax = nowNode.Data.X; }
                if (nowNode.Data.X < xmin) { xmin = nowNode.Data.X; }
                if (nowNode.Data.Y > ymax) { ymax = nowNode.Data.Y; }
                if (nowNode.Data.Y < ymin) { ymin = nowNode.Data.Y; }
                j++;
                nowNode = nowNode.Next;
            } while (nowNode != font && nowNode != null);
            //if (j < 3) { throw new IndexOutOfRangeException("Invalid Polygon with Points less than 3."); }
        }
    }
}