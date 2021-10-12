using System;
using System.Collections.Generic;

namespace VectorCross
{
    class Program
    {
        static void Main(string[] args)
        {
            Point myPoint = new Point(1,2);
            
            Polygon pg = new Polygon();
            Console.Write(pg.ToString());
            LQueue<string> lq = new LQueue<string>();
            //Console.Write(lq.ToString());
            lq.Insert("b", 1);
            lq.Insert("a", 2);
            lq.Insert("d", 3);
            //lq.Insert("c", 3);
            //Console.Write(lq.ToString());
            lq[4] = "4";
            //Console.Write(lq.ToString());
            //PolyLine pl1 = new PolyLine();
            //PolyLine pl2 = new PolyLine();
            //Polygon pg = new Polygon();
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 2);
            Point point3 = new Point(3, 2);
            Point point4 = new Point(2, 1);
            Point point5 = new Point(3, 1);
            Point point6 = new Point(2.5, 1.1);

            //pl1.Add(point1);
            //pl1.Add(point2);
            //pl1.Add(point3);
            //pl1.Add(point4);
            //pl1.Add(point5);

            //pl2.Add(point2);
            //pl2.Add(point6);
            
            pg.Add(point4);
            
            pg.Insert(point1, 1);
            
            pg.Insert(point2, 2);
            pg.Delete(3);
            pg.Insert(point3, 4);
            pg.Add(point5);
            pg.GetPer();
            Console.Write(pg.ToString());
            //Console.WriteLine(pl1.GetSegDirection(3));
            //Console.WriteLine(pl1.PointOnLine(point6, 2));
            //Console.WriteLine(PolyLine.LineIntersect(pl1,2,pl2,1));
        }
    }
}
