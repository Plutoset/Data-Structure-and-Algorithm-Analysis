using System;

namespace QuadTree
{
    class Program
    {
        static void Main()
        {
            QuadNode<string> node1 = new QuadNode<string>(new Point(38, 85), "Louisville");
            QuadNode<string> node2 = new QuadNode<string>(new Point(41, 87), "Louisville");
            QuadNode<string> node3 = new QuadNode<string>(new Point(38, 77), "Louisville");
            QuadNode<string> node4 = new QuadNode<string>(new Point(36, 87), "Nashville");
            QuadNode<string> node5 = new QuadNode<string>(new Point(34, 84), "Atlanta");
            QuadNode<string> node6 = new QuadNode<string>(new Point(40, 79), "Pittsburgh");
            QuadNode<string> node7 = new QuadNode<string>(new Point(40, 74), "New York");
            QuadNode<string> node8 = new QuadNode<string>(new Point(41, 81), "Cleveland");
            QuadNode<string> node9 = new QuadNode<string>(new Point(39, 84), "Dayton");
            QuadNode<string> node10 = new QuadNode<string>(new Point(45, 73), "Montreal");
        }
    }
}
