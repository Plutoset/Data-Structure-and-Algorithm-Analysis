using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineQuene
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
        public Point(double x,double y)
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
    class PolygonPoints<T>
    {
        Node<Point> font;   // 队首
        Node<Point> rear;   // 队尾

        /// <summary>
        /// 构造器
        /// </summary>
        public PolygonPoints()
        {
            font = new Node<Point>();
            rear = font;
        }
        // <summary>
        /// 在index处修改值
        /// </summary>
        /// <param name="data"></param>
        public void Modify(Point data, int index)
        {
            Node<Point> nowNode = font;
            int i = 1;
            if (i == index)
            {
                nowNode.Data = data;
                return;
            }
            nowNode = nowNode.Next;
            while (nowNode != font)
            {
                i++;
                if (i == index)
                {
                    nowNode.Data = data;
                    break;
                }
                nowNode = nowNode.Next;
            }
            if (i > index || index < 1)
            {
                Console.WriteLine("Input index out of range!");
            }
        }

        /// <summary>
        /// WARNING UNCOMPLETED FUNCTION
        /// 通过内容检索并且返回值并没有什么意思，就不写了
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Point Find(Point data)
        {
            Node<Point> nowNode = font;
            int i = 1;
            if (font.Data == null)
            {
                Console.WriteLine("LinkQuene already empty!");
                return default(Point);
            }
            else
            {
                if (nowNode.Data.Equals(data))
                {
                    return nowNode.Data;
                }
                nowNode = nowNode.Next;
                while (nowNode != font)
                {
                    i++;
                    if (nowNode.Data.Equals(data))
                    {
                        return nowNode.Data;
                    }
                    nowNode = nowNode.Next;
                }

                Console.WriteLine("Input index out of range!");
                return default(Point);

            }

        }
        /// <summary>
        /// 循环打印链式表中的所有元素
        /// </summary>
        public void Loop()
        {
            Node<Point> pn = font;    
            int j = 1;
            Console.WriteLine($"point{j}, X {pn.Data.X} Y {pn.Data.Y}");
            pn = pn.Next;
            while (pn != font && pn != null)
            {
                j++;
                Console.WriteLine($"point{j}, X {pn.Data.X} Y {pn.Data.Y}");
                pn = pn.Next;
            }
        }
        /// <summary>
        /// 找出并打印index位置的元素，如果超出范围则console报错并且返回null值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point Get(int index)
        {
            Node<Point> nowNode = font;
            int i = 1;
            if (i == index)
            {
                return nowNode.Data;
            }
            nowNode = nowNode.Next;
            while (nowNode != font)
            {
                i++;
                if (i == index)
                {
                    return nowNode.Data;
                }
                nowNode = nowNode.Next;
            }
            if (i > index || index < 1)
            {
                Console.WriteLine("Input index out of range!");
            }
            return default(Point);
        }
        /// <summary>
        /// 判空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return font.Data == null;
        }
        /// <summary>
        /// 在index处入队
        /// </summary>
        /// <param name="data"></param>
        public void Insert(Point data, int index)
        {
            //新建节点
            Node<Point> tmp = new Node<Point>(data);
            Node<Point> nowNode = font;
            int i = 1;
            if (index == 1)
            {
                Node<Point> store = font;
                font = tmp;
                if (store.Data != null)
                {
                    font.Next = store;
                    rear.Next = font;
                }

                if (rear.Data == null)
                {
                    rear = font;
                }
                //Console.WriteLine($"font X {font.Data.X} Y {font.Data.Y} rear X {rear.Data.X} Y {rear.Data.Y}");
                return;
            }
            else
            {
                nowNode = nowNode.Next;
                if (nowNode == null && index == 2)
                {
                    nowNode = tmp;
                    font.Next = nowNode;
                    nowNode.Next = font;
                    rear = nowNode;
                    //Console.WriteLine($"font X {font.Data.X} Y {font.Data.Y} rear X {rear.Data.X} Y {rear.Data.Y}");
                    return;
                }
                if (nowNode == null && index > 2)
                {
                    Console.WriteLine("Input index out of range!");
                    return;
                }
                while (nowNode != font)
                {
                    i++;
                    if (i == index - 1)
                    {
                        Node<Point> store = nowNode.Next;
                        nowNode.Next = tmp;
                        tmp.Next = store;
                        break;
                    }
                    nowNode = nowNode.Next;
                }
                rear = nowNode.Next;
                if (i < index - 1 || index < 1)
                {
                    Console.WriteLine("Input index out of range!");
                }

            }
            //Console.WriteLine($"font X {font.Data.X} Y {font.Data.Y} rear X {rear.Data.X} Y {rear.Data.Y}");
        }
        /// <summary>
        /// 删除index处的节点，如果index超出范围则console报错并且不执行操作
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            Node<Point> nowNode = font;
            int i = 0;
            if (index == 1)
            {
                if (font.Data == null)
                {
                    Console.WriteLine("Invalid Polygon!");
                }
                else
                {
                    Node<Point> newNode = font.Next;
                    if (newNode.Next == font)
                    {
                        font = newNode;
                        font.Next = null;
                        rear = font;
                        return;
                    }
                    Node<Point> store = font;
                    font = font.Next;
                    nowNode = nowNode.Next;
                    while (nowNode.Next != store)
                    {
                        nowNode = nowNode.Next;
                    }
                    nowNode.Next = newNode;
                    rear = nowNode;
                }
                return;
            }
            else
            {
                while (nowNode.Next != font)
                {
                    // nowNode = nowNode.Next;
                    i++;
                    if (i == index - 1)
                    {
                        Node<Point> store = nowNode.Next.Next;
                        nowNode.Next = store;
                        nowNode = nowNode.Next;
                        break;
                    }
                    nowNode = nowNode.Next;
                }
                if (nowNode.Next == font)
                {
                    rear = nowNode;
                    return;
                }
                if (i < index - 1 || index < 1)
                {
                    Console.WriteLine("Input index out of range!");
                    return;
                }

            }
            //Console.WriteLine($"font data {font.Data} rear data {rear.Data}");
        }
        /// <summary>
        /// 计算多边形面积，倘若多边形的点数在三个以下则报错"Invalid Polygon!"并且返回0
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            Node<Point> nowNode = font;
            int i = 1;
            double area = 0;
            while (nowNode.Next != font && nowNode.Next != null)
            {
                nowNode = nowNode.Next;
                i++;
            }
            if (i < 3)
            {
                Console.WriteLine("Invalid Polygon!");
            }
            else
            {
                nowNode = font;
                while (true)
                {
                    area += 0.5 * Math.Abs(nowNode.Next.Data.Y + nowNode.Data.Y) * (nowNode.Next.Data.X - nowNode.Data.X);
                    nowNode = nowNode.Next;
                    if (nowNode == font)
                    {
                        break;
                    }
                }
            }
            return area;
        }
        /// <summary>
        /// 计算多边形周长，倘若多边形的点数在三个以下则报错"Invalid Polygon!"并且返回0
        /// </summary>
        /// <returns></returns>
        public double GetPer()
        {
            Node<Point> nowNode = font;
            int i = 1;
            double per = 0;
            while (nowNode.Next != font && nowNode.Next != null)
            {
                nowNode = nowNode.Next;
                i++;
            }
            if (i < 3)
            {
                Console.WriteLine("Invalid Polygon!");
            }
            else
            {
                nowNode = font;
                while (true)
                {
                    per += Math.Sqrt(Math.Pow(nowNode.Next.Data.Y - nowNode.Data.Y,2) +
                        Math.Pow(nowNode.Next.Data.X - nowNode.Data.X, 2)
                        );
                    nowNode = nowNode.Next;
                    if (nowNode == font)
                    {
                        break;
                    }
                }
            }
            return per;
        }
    }
}
