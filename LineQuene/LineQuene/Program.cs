using System;
using System.IO;

namespace LineQuene
{
    class Program
    {
        /// <summary>
        /// 链式表
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    LQueue<string> lq = new LQueue<string>();
        //    Console.WriteLine("LinkQuene init");

        //    Console.WriteLine($"LinkQuene is empty: {lq.IsEmpty()}");
        //     Console.WriteLine("insert 'a',1 ");
        //    lq.Insert("a", 1);
        //    lq.Loop();

        //    Console.WriteLine("insert 'b',1 ");
        //    lq.Insert("b", 1);
        //    lq.Loop();

        //    Console.WriteLine("insert 'c',2 ");
        //    lq.Insert("c", 2);
        //    lq.Loop();

        //    Console.WriteLine("insert 'd',7 ");
        //    lq.Insert("d", 4);
        //    lq.Loop();
        //    //Console.WriteLine(lq.Find(7));
        //    Console.WriteLine("modify 'e',3 ");
        //    lq.Modify("e", 3);
        //    lq.Loop();
        //    Console.WriteLine("delete element at 1 ");
        //    lq.Delete(1);
        //    lq.Loop();
        //}

        /// <summary>
        /// 循环表（多边形）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            PolygonPoints<Point> pg = new PolygonPoints<Point>();
            Console.WriteLine("LinkQuene init");
            Console.WriteLine($"LinkQuene is empty: {pg.IsEmpty()}");

            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 2);
            Point point3 = new Point(3, 2);
            Point point4 = new Point(2, 1);
            Point point5 = new Point(3, 1);
            pg.Insert(point1, 1);
            pg.Insert(point2, 2);
            pg.Insert(point3, 3);
            pg.Insert(point4, 4);
            pg.Modify(point5, 4);
            pg.Loop();
            double area = pg.GetArea();
            double per = pg.GetPer();
            Console.WriteLine($"area {area}");
            Console.WriteLine($"perimeter {per}");
        }
    }
}
