using System;
using System.Collections.Generic;

namespace GISstructure
{
    public class myPoint
    {
        public double x;
        public double y;
        public myPoint(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
    }
    public class myPoints
    {
        List<myPoint> mypoints;
        public static void AddPoint(myPoint myPoint, List<myPoint> myPoints, int Index)
        {
            try
            {
                myPoints.Insert(Index, myPoint);
            }
            catch(IndexOutOfRangeException)
            {
            //    Console.WriteLine('Index Out Of Range');
                myPoints.Add(myPoint);
            }
        }
        public static void DeletePoint(List<myPoint> myPoints, int Index)
        {
            try
            {
                myPoints.RemoveAt(Index);
            }
            catch (IndexOutOfRangeException)
            {
             //   Console.WriteLine('invalid index. Please check again.');
            }
        }
        public static void ModifyPoint(myPoint myPoint, List<myPoint> myPoints, int Index)
        {
            try
            {
                myPoints[Index] = myPoint;
            }
            catch (IndexOutOfRangeException)
            {
               // Console.WriteLine('invalid index. Please check again.');
            }
        }
        public static void LoopPoints(List<myPoint> myPoints)
        {
            foreach (myPoint myPoint in myPoints)
            {
                Console.Write(myPoint);
            }
        }
    }
}
