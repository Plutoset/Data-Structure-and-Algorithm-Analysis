using System;
using System.Collections.Generic;

namespace KDTree
{
    class Program
    {
        static void Main(string[] args)
        {
            KDTreeNode<string> A = new KDTreeNode<string>(new Point(40, 60), "A");
            KDTreeNode<string> B = new KDTreeNode<string>(new Point(10, 75), "B");
            KDTreeNode<string> C = new KDTreeNode<string>(new Point(70, 20), "C");
            KDTreeNode<string> D = new KDTreeNode<string>(new Point(25, 15), "D");
            KDTreeNode<string> E = new KDTreeNode<string>(new Point(80, 70), "E");
            KDTreeNode<string> F = new KDTreeNode<string>(new Point(20, 45), "F");
            KDTreeNode<string> G = new KDTreeNode<string>(new Point(35, 45), "G");
            KDTreeNode<string> H = new KDTreeNode<string>(new Point(60, 50), "H");
            
            List<KDTreeNode<string>> list = new List<KDTreeNode<string>>() { A, B, C, D, E, F, G, H };

            KDTree<string> kDTree = new KDTree<string>();
            kDTree.AddNodes(list);
            KDTreeNode<string> fPosition = kDTree.Find(new Point(20, 45));
            KDTreeNode<string> fVvalue = kDTree.Find("F");
            
            kDTree.DeleteAt(new Point(20, 45));
            List<KDTreeNode<string>> list1 = kDTree.ToList();
        }
    }
}
