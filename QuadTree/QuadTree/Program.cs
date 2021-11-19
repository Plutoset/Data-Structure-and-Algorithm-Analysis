using System;
using System.Collections.Generic;

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
            List<QuadNode<string>> list = new List<QuadNode<string>> { node1, node2, node3, node4, node5, node6, node7, node8, node9, node10 };
            QuadTree<string> quadTree = new QuadTree<string>();
            quadTree.AddNodes(list);
            List<QuadNode<string>> nlist = quadTree.GetChildren(quadTree.Root);
            List<QuadNode<string>> dlist = quadTree.Search(new Point(36, 80), 4);
            FQuadTree<string> fQuadTree = new FQuadTree<string>();
            QuadNode<string> neearestNode = quadTree.FindNearest(new Point(40, 79));
        }
    }
}
