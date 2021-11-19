using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// 一颗普通的树，储存节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BTree<T>
    {
        public BNode<IndexNode<T>> Head { get; set; }
        public BTree()
        {
            Head = null;
        }
        public BTree(IndexNode<T> data)
        {
            BNode<IndexNode<T>> head = new BNode<IndexNode<T>>(data);
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

        public BNode<IndexNode<T>> Find(T data, BNode<IndexNode<T>> nowNode)
        {
            while (!nowNode.Data.Data.Equals(data))
            {
                BNode<IndexNode<T>> lNode = nowNode.LChild;
                BNode<IndexNode<T>> rNode = nowNode.RChild;
                if (IsLeaf(lNode) == true && IsLeaf(rNode) == true)
                {
                    if (lNode.Data.Data.Equals(data))
                    {
                        nowNode = lNode;
                        break;
                    }
                    else if (rNode.Data.Data.Equals(data))
                    {
                        nowNode = rNode;
                        break;
                    }
                }
                nowNode = Find(data, lNode);
                if (!nowNode.Data.Data.Equals(data))
                {
                    nowNode = Find(data, rNode);
                }
            }
            return nowNode;
        }
        public void FindParent(T data, ref BNode<IndexNode<T>> bNode, ref bool ahead)
        {
            if (ahead)
            {

                BNode<IndexNode<T>> lNode = bNode.LChild;
                BNode<IndexNode<T>> rNode = bNode.RChild;
                if (lNode.Data.Data.Equals(data) || rNode.Data.Data.Equals(data))
                {
                    ahead = false;
                    return;
                }
                if (IsLeaf(lNode) != true || IsLeaf(rNode) != true)
                {
                    FindParent(data, ref lNode, ref ahead);
                    if (ahead)//插入了就停
                    { FindParent(data, ref rNode, ref ahead); }
                }
            }
        }
        public BNode<IndexNode<T>> Find(IndexNode<T> indexNode)
        {
            T data = indexNode.Data;
            BNode<IndexNode<T>> nowNode = Head;
            nowNode = Find(data, Head);
            if (!nowNode.Data.Data.Equals(data))
            {
                throw new Exception("No such element in Binary Tree!");
            }
            return nowNode;
        }
        public bool IsLeaf(BNode<IndexNode<T>> bNode)
        {
            return (bNode != null) && (bNode.RChild == null) && (bNode.LChild == null);
        }

        public List<BNode<IndexNode<T>>> TravelInOrder()
        {
            List<BNode<IndexNode<T>>> bNodes = new List<BNode<IndexNode<T>>>();
            TravelInOrder(Head, ref bNodes);
            return bNodes;
        }
        public void TravelInOrder(BNode<IndexNode<T>> bNode, ref List<BNode<IndexNode<T>>> bNodes)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<IndexNode<T>>>();
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
        public List<BNode<IndexNode<T>>> TravelPreOrder()
        {
            List<BNode<IndexNode<T>>> bNodes = new List<BNode<IndexNode<T>>>();
            TravelPreOrder(Head, ref bNodes);
            return bNodes;
        }
        public void TravelPreOrder(BNode<IndexNode<T>> bNode, ref List<BNode<IndexNode<T>>> bNodes)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<IndexNode<T>>>();
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
        public List<BNode<IndexNode<T>>> TravelPostOrder()
        {
            List<BNode<IndexNode<T>>> bNodes = new List<BNode<IndexNode<T>>>();
            TravelPostOrder(Head, ref bNodes);
            return bNodes;
        }
        public void TravelPostOrder(BNode<IndexNode<T>> bNode, ref List<BNode<IndexNode<T>>> bNodes)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<IndexNode<T>>>();
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
        public List<BNode<IndexNode<T>>> LevelOrder()
        {
            List<BNode<IndexNode<T>>> bNodes = new List<BNode<IndexNode<T>>>();
            List<BNode<IndexNode<T>>> quene = new List<BNode<IndexNode<T>>>() { Head };
            LevelOrder(Head, ref bNodes,ref quene);
            return bNodes;
        }
        public void LevelOrder(BNode<IndexNode<T>> bNode, ref List<BNode<IndexNode<T>>> bNodes, ref List<BNode<IndexNode<T>>> quene)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Binary Tree empty. \n");
                bNodes = new List<BNode<IndexNode<T>>>();
                return;
            }
            if (bNode != null)
            {
                if (quene.Contains(bNode))
                {
                    if (bNode.LChild != null)
                    {
                        quene.Add(bNode.LChild);
                    }
                    if (bNode.RChild != null)
                    {
                        quene.Add(bNode.RChild);
                    }
                    bNodes.Add(bNode);
                    quene.Remove(bNode);
                }
                if (!bNodes.Contains(bNode))
                {
                    bNodes.Add(bNode);
                }
                if (quene.Count != 0)
                {
                    LevelOrder(quene[0], ref bNodes, ref quene);
                }
            }
        }

        /// <summary>
        /// 返回深度
        /// </summary>
        /// <param name="bNode"></param>
        /// <param name="depth"></param>
        public void GetDepth(BNode<IndexNode<T>> bNode, ref int depth)
        {
            if (IsEmpty())
            {
                depth = 0;
            }
            if (bNode != null)
            {
                BNode<IndexNode<T>> lNode = bNode.LChild;
                BNode<IndexNode<T>> rNode = bNode.RChild;
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
        public void GetCount(BNode<IndexNode<T>> bNode, ref int count)
        {
            if (bNode != null)
            {
                count++;
                GetCount(bNode.LChild, ref count);
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
            if (count == Math.Pow(2, depth) - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void OrderInsert(IndexNode<T> bNode)
        {
            int loopKey = bNode.Key;
            BNode<IndexNode<T>> iNode = new BNode<IndexNode<T>>(bNode);
            if (loopKey == 1)
            {
                Head = iNode;
                return;
            }
            List<int> mod = new List<int>();
            List<int> log = new List<int>();
            while (loopKey != 1)
            {
                int nowMod = loopKey % 2;
                loopKey = (loopKey - nowMod) / 2;
                mod.Add(nowMod);
            }
            BNode<IndexNode<T>> currentNode = Head;
            mod.Reverse();
            int LastMod = mod[^1];
            mod.RemoveAt(mod.Count - 1);
            foreach (int nowMod in mod)
            {
                currentNode = nowMod == 1 ? currentNode.RChild : currentNode.LChild;
                if (currentNode == null)
                {
                    throw new IndexOutOfRangeException("The parent node for the insert node is invalid. Please check the key index.");
                }
            }
            if (LastMod == 1)
            {
                currentNode.RChild = iNode;
            }
            else
            {
                currentNode.LChild = iNode;
            }
        }
    }
}
