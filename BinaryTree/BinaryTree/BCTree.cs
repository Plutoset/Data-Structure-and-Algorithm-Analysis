using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// 完全二叉树
    /// </summary>
    class BCTree<T>: BTree<T>
    {
        public void Insert(BNode<IndexNode<T>> iNode)
        {
            BNode<IndexNode<T>> currentNode = Head;
            if (IsEmpty())
            {
                Head = iNode;
                return;
            }
            else
            {
                int depth = Depth();
                if (IsFull())//满二叉树 左边遍历到最后一个插左节点
                {
                    while (currentNode.LChild != null)
                    {
                        currentNode = currentNode.LChild;
                    }
                    currentNode.LChild = iNode;
                }
                else //普通的完全二叉树 遍历到深度-1
                {
                    int nowDepth = 1;
                    bool ahead = true;
                    FindLastParent(iNode, currentNode, depth, ref nowDepth, ref ahead);
                }
            }
        }
        public void Insert(IndexNode<T> iNode)
        {
            BNode<IndexNode<T>> inNode = new BNode<IndexNode<T>>(iNode);
            Insert(inNode);
        }
        /// <summary>
        /// 遍历到深度-1的时候，找到第一个孩子们非空的父节点，插入孩子
        /// </summary>
        /// <param name="iNode"></param>
        /// <param name="bNode"></param>
        /// <param name="depth"></param>
        /// <param name="nowDepth"></param>
        /// <param name="ahead"></param>
        public void FindLastParent(BNode<IndexNode<T>> iNode, BNode<IndexNode<T>> bNode, int depth, ref int nowDepth, ref bool ahead)
        {
            if (ahead)
            {
                BNode<IndexNode<T>> lNode = bNode.LChild;
                BNode<IndexNode<T>> rNode = bNode.RChild;
                if (nowDepth != depth - 1)
                {
                    nowDepth++;
                    FindLastParent(iNode, lNode, depth, ref nowDepth, ref ahead);
                    if (ahead)//插入了就停
                    { FindLastParent(iNode, rNode, depth, ref nowDepth, ref ahead); }
                }
                else if (nowDepth == depth - 1)
                {
                    if (lNode != null && rNode == null)
                    {
                        bNode.RChild = iNode;
                        ahead = false;
                        return;
                    }
                    else if (lNode == null && rNode == null)
                    {
                        bNode.LChild = iNode;
                        ahead = false;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 一个列表，挨个插入二叉树
        /// </summary>
        /// <param name="bNodes"></param>
        public void InQuene(List<BNode<IndexNode<T>>> bNodes)
        {
            foreach (BNode<IndexNode<T>> bNode in bNodes)
            {
                Insert(bNode);
            }
        }
        public void InQuene(List<IndexNode<T>> bNodes)
        {
            foreach (IndexNode<T> bNode in bNodes)
            {
                Insert(bNode);
            }
        }
        /// <summary>
        /// 还原成整个打包成完全二叉树的列表
        /// </summary>
        /// <returns></returns>
        public List<BNode<IndexNode<T>>> ToQuene()
        {
            List<BNode<IndexNode<T>>> indexNodes = new List<BNode<IndexNode<T>>>();
            if (!IsEmpty())
            {
                indexNodes.Add(Head);
                int depth = 1;
                do
                {
                    int nowDepth = 1;
                    bool ahead = true;
                    FindDepth(Head, ref indexNodes, depth, ref nowDepth, ref ahead);
                    depth++;
                } while (depth < Depth());
            }
            return indexNodes;
        }
        /// <summary>
        /// 把第depth层的元素都打包出来塞到列表bNodes里，bNode, nowDepth 和ahead都是传参，ahead判断终止
        /// </summary>
        /// <param name="bNode"></param>
        /// <param name="bNodes"></param>
        /// <param name="depth"></param>
        /// <param name="nowDepth"></param>
        /// <param name="ahead"></param>
        public void FindDepth(BNode<IndexNode<T>> bNode, ref List<BNode<IndexNode<T>>> bNodes, int depth, ref int nowDepth, ref bool ahead)
        {
            if (bNode == null)
            {
                return;
            }
            if (ahead == false)
            {
                return;
            }
            BNode<IndexNode<T>> lNode = bNode.LChild;
            BNode<IndexNode<T>> rNode = bNode.RChild;
            if (nowDepth != depth)
            {
                nowDepth++;
                FindDepth(lNode, ref bNodes, depth, ref nowDepth, ref ahead);
                FindDepth(rNode, ref bNodes, depth, ref nowDepth, ref ahead);
            }
            else if (nowDepth == depth)
            {
                if (lNode == null && rNode == null)
                {
                    ahead = false;
                }
                else if (lNode != null && rNode != null)
                {
                    bNodes.Add(lNode);
                    bNodes.Add(rNode);
                }
                else if (lNode != null && rNode == null)
                {
                    bNodes.Add(lNode);
                    ahead = false;
                }
            }
        }
        public BTree<T> ToBTree()
        {
            BTree<T> bTree = new BTree<T>();
            List<BNode<IndexNode<T>>> nodes = ToQuene();
            List<IndexNode<T>> indexNodes = new List<IndexNode<T>>();
            foreach (BNode<IndexNode<T>> node in nodes)
            {
                IndexNode<T> indexNode = node.Data;
                indexNodes.Add(indexNode);
            }
            // 对于元素按照key重新排序一下
            indexNodes = indexNodes.OrderBy(item => item.Key).ToList();
            foreach (IndexNode<T> indexNode in indexNodes)
            {
                bTree.OrderInsert(indexNode);
            }
            return bTree;
        }
    }
}
