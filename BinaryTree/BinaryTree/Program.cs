using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 用数组按完全二叉树规则存储数据元素
            BCSTree<int> bCSTree = new BCSTree<int>();
            IndexNode<int> bNode1 = new IndexNode<int>(1,31);
            IndexNode<int> bNode2 = new IndexNode<int>(2,23);
            IndexNode<int> bNode3 = new IndexNode<int>(3,12);
            IndexNode<int> bNode4 = new IndexNode<int>(4,66);
            IndexNode<int> bNode6 = new IndexNode<int>(6,5);
            IndexNode<int> bNode7 = new IndexNode<int>(7,17);
            IndexNode<int> bNode8 = new IndexNode<int>(8,70);
            IndexNode<int> bNode9 = new IndexNode<int>(9,62);
            IndexNode<int> bNode13 = new IndexNode<int>(13,88);
            IndexNode<int> bNode15 = new IndexNode<int>(15,55);
            List<IndexNode<int>> bNodes = new List<IndexNode<int>> { bNode1, bNode2, bNode3, bNode4, bNode6, bNode7, bNode8, bNode9, bNode13, bNode15 };
            bCSTree.InQuene(bNodes);
            List<BNode<IndexNode<int>>> biNodes = bCSTree.ToQuene();
            ////测试二叉查找树
            //BSTree<int> bSTree = new BSTree<int>();
            //IndexNode<int> node1 = new IndexNode<int>(7, 3);
            //IndexNode<int> node2 = new IndexNode<int>(2, 4);
            //IndexNode<int> node3 = new IndexNode<int>(6, 6);
            //IndexNode<int> node4 = new IndexNode<int>(8, 5);
            //IndexNode<int> node5 = new IndexNode<int>(1, 3);
            //bSTree.Insert(node3);
            //bSTree.Insert(node1);
            //bSTree.Insert(node2);
            //bSTree.Insert(node4);
            //Console.WriteLine(bSTree.Depth());
            //bSTree.Insert(node4);
        }
    }
}
