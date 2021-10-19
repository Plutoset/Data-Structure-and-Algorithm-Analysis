using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree bSTree = new BSTree();
            IndexNode node1 = new IndexNode(1, 3);
            IndexNode node2 = new IndexNode(2, 4);
            IndexNode node3 = new IndexNode(6, 6);
            IndexNode node4 = new IndexNode(8, 3);
            IndexNode node5 = new IndexNode(5, 3);
            bSTree.Insert(node3);
            bSTree.Insert(node1);
            bSTree.Insert(node2);
            bSTree.Insert(node5);
            bSTree.Insert(node4);
        }
    }
}
