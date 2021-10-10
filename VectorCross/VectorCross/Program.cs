﻿using System;
using System.Collections.Generic;

namespace VectorCross
{
    class Program
    {
        static void Main(string[] args)
        {
            PolyLine pl1 = new PolyLine();
            PolyLine pl2 = new PolyLine();
            Polygon pg = new Polygon();
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 2);
            Point point3 = new Point(3, 2);
            Point point4 = new Point(2, 1);
            Point point5 = new Point(3, 1);
            Point point6 = new Point(1.5, 1);

            pl1.AddPoint(point1);
            pl1.AddPoint(point2);
            pl1.AddPoint(point3);
            pl1.AddPoint(point4);
            pl1.AddPoint(point5);

            pl2.AddPoint(point2);
            pl2.AddPoint(point6);
            pg.Add(point4);
            pg.Insert(point1, 1);
            pg.Insert(point2, 2);
            pg.Insert(point3, 4);
            pg.Add(point5);
            Console.WriteLine(pl1.GetSegDirection(3));
            Console.WriteLine(pl1.PointOnLine(point6, 2));
            Console.WriteLine(PolyLine.LineIntersect(pl1,2,pl2,1));
            Console.WriteLine(pg.PointInPolygon(point6));
        }
    }
}
