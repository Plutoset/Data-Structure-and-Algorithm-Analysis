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
        public void Insert(BNode<T> bNode, bool lr)
        {
            
            BNode<T> currentNode = Head;
            if (IsEmpty())
            {
                Head = bNode;
            }
            else
            {
                //lr == true插左边，lr == false插右边
            }
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

        public void TravelInOrder(BNode<T> bNode, ref List<BNode<T>> bNodes)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<T>>();
                return;
            }
            if (bNode != null)
            {
                TravelInOrder(bNode.LChild, ref bNodes);
                Console.WriteLine(bNode.Data);
                bNodes.Add(bNode);
                TravelInOrder(bNode.RChild, ref bNodes);
            }
        }
        public void TravelPreOrder(BNode<T> bNode, ref List<BNode<T>> bNodes)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<T>>();
                return;
            }
            if (bNode != null)
            {
                Console.WriteLine(bNode.Data);
                bNodes.Add(bNode);
                TravelPreOrder(bNode.LChild, ref bNodes);
                TravelPreOrder(bNode.RChild, ref bNodes);
            }
        }
        public void TravelPostOrder(BNode<T> bNode, ref List<BNode<T>> bNodes)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<T>>();
                return;
            }
            if (bNode != null)
            {
                TravelPostOrder(bNode.LChild, ref bNodes);
                TravelPostOrder(bNode.RChild, ref bNodes);
                Console.WriteLine(bNode.Data);
                bNodes.Add(bNode);
            }
        }

        public void LevelOrder(BNode<T> bNode, ref List<BNode<T>> bNodes)
        {
            if (bNode == null)
            {
                return;
            }

        }

        /// <summary>
        /// 返回深度
        /// </summary>
        /// <param name="bNode"></param>
        /// <param name="depth"></param>
        public void GetDepth(BNode<T> bNode, ref int depth)
        {
            if (IsEmpty())
            {
                depth = 0;
            }
            if (bNode != null)
            {
                BNode<T> lNode = bNode.LChild;
                BNode<T> rNode = bNode.RChild;
                if (lNode != null && rNode != null)//左右节点都实
                {
                    depth++;
                    int ldepth = depth, rdepth = depth;
                    GetDepth(lNode, ref ldepth);
                    GetDepth(rNode, ref rdepth);
                    depth = Math.Max(ldepth, rdepth);
                }
                else if (lNode != null && rNode == null)//左节点实，右节点空
                {
                    depth++;
                    GetDepth(lNode, ref depth);
                }
                else if (rNode != null && lNode == null)//左节点空，右节点实
                {
                    depth++;
                    GetDepth(rNode, ref depth);
                }
            }
        }
        public int Depth()
        {
            int depth = 1;
            GetDepth(Head, ref depth);
            return depth;
        }
        public int Count()
        {
            int count = 0;
            GetCount(Head, ref count);
            return count;
        }
        public void GetCount(BNode<T> bNode, ref int count)
        {
            if (bNode != null)
            {
                count++;
                GetCount(bNode.LChild,ref count);
                GetCount(bNode.RChild, ref count);
            }
        }
        /// <summary>
        /// 判断是否为满二叉树，深度为k，节点数为2的k次方减1
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            int depth = Depth();
            int count = Count();
            if(count == Math.Pow(2, depth) - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
