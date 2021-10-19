using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BTree<T>
    {
        public BNode<T> Head { get; set; }
        public BTree()
        {
            Head = null;
        }
        public BTree(T data)
        {
            BNode<T> head = new BNode<T>(data);
            Head = head;
        }
        public void MakeEmpty()
        {
            if (Head != null)
            {
                Head.Empty();
            }
        }
        public bool IsEmpty()
        {
            return Head == null;
        }
        public BNode<T> GetLChild(BNode<T> bNode)
        {
            return bNode.LChild;
        }
        public BNode<T> GetRChild(BNode<T> bNode)
        {
            return bNode.RChild;
        }
        public BNode<T> Find(T data, BNode<T> nowNode = null)
        {
            if (nowNode == null)
            {
                nowNode = Head;
            }
            if (nowNode == null)
            {
                Console.WriteLine("Binary Tree empty.");
                return null;
            }
            if (!nowNode.Data.Equals(data))
            {
                return nowNode;
            }
            if (nowNode.LChild != null)
            {
                return Find(data, nowNode.LChild);
            }
            if (nowNode.RChild != null)
            {
                return Find(data, nowNode.RChild);
            }
            return null;
        }
        public bool IsLeaf(BNode<T> bNode)
        {
            return (bNode != null) && (bNode.RChild == null) && (bNode.LChild == null);
        }

        public void TravelInOrder(BNode<T> bNode)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                return;
            }
            if (bNode != null)
            {
                TravelInOrder(bNode.LChild);
                Console.WriteLine(bNode.Data);
                TravelInOrder(bNode.RChild);
            }
        }
        public void TravelPreOrder(BNode<T> bNode)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                return;
            }
            if (bNode != null)
            {
                Console.WriteLine(bNode.Data);
                TravelPreOrder(bNode.LChild);
                TravelPreOrder(bNode.RChild);
            }
        }
        public void TravelPostOrder(BNode<T> bNode)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                return;
            }
            if (bNode != null)
            {
                TravelPostOrder(bNode.LChild);
                TravelPostOrder(bNode.RChild);
                Console.WriteLine(bNode.Data);
            }
        }

        public void LevelOrder(BNode<T> bNode)
        {
            if (bNode == null)
            {
                return;
            }

        }
    }
}
