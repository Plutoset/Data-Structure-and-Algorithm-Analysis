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
        public void Insert(BNode<T> iNode)
        {
            BNode<T> currentNode = Head;
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
        public void FindLastParent(BNode<T> iNode, BNode<T> bNode, int depth, ref int nowDepth, ref bool ahead)
        {
            if (ahead)
            {
                BNode<T> lNode = bNode.LChild;
                BNode<T> rNode = bNode.RChild;
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
        public void InQuene(List<BNode<T>> bNodes)
        {
            foreach (BNode<T> bNode in bNodes)
            {
                Insert(bNode);
            }
        }
        ///// <summary>
        ///// ？写不下去了
        ///// </summary>
        ///// <param name="bNodes"></param>
        //[Obsolete]
        //public void InQuene(List<IndexNode<T>> bNodes)
        //{
        //    foreach (IndexNode<T> bNode in bNodes)
        //    {
        //        Insert(bNode);
        //    }
        //}
    }
    //class BCTree<T> : BTree<IndexNode<T>>
    //{
    //    public void Insert(BNode<T> iNode)
    //    {
    //        BNode<T> currentNode = Head;
    //        if (IsEmpty())
    //        {
    //            Head = iNode;
    //            return;
    //        }
    //        else
    //        {
    //            int depth = Depth();
    //            if (IsFull())//满二叉树 左边遍历到最后一个插左节点
    //            {
    //                while (currentNode.LChild != null)
    //                {
    //                    currentNode = currentNode.LChild;
    //                }
    //                currentNode.LChild = iNode;
    //            }
    //            else //普通的完全二叉树 遍历到深度-1
    //            {
    //                int nowDepth = 1;
    //                bool ahead = true;
    //                FindLastParent(iNode, currentNode, depth, ref nowDepth, ref ahead);
    //            }
    //        }
    //    }
    //    public void FindLastParent(BNode<T> iNode, BNode<T> bNode, int depth, ref int nowDepth, ref bool ahead)
    //    {
    //        if (ahead)
    //        {
    //            BNode<T> lNode = bNode.LChild;
    //            BNode<T> rNode = bNode.RChild;
    //            if (nowDepth != depth - 1)
    //            {
    //                nowDepth++;
    //                FindLastParent(iNode, lNode, depth, ref nowDepth, ref ahead);
    //                if (ahead)//插入了就停
    //                { FindLastParent(iNode, rNode, depth, ref nowDepth, ref ahead); }
    //            }
    //            else if (nowDepth == depth - 1)
    //            {
    //                if (lNode != null && rNode == null)
    //                {
    //                    bNode.RChild = iNode;
    //                    ahead = false;
    //                    return;
    //                }
    //                else if (lNode == null && rNode == null)
    //                {
    //                    bNode.LChild = iNode;
    //                    ahead = false;
    //                    return;
    //                }
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// 一个列表，挨个插入二叉树
    //    /// </summary>
    //    /// <param name="bNodes"></param>
    //    public void InQuene(List<BNode<T>> bNodes)
    //    {
    //        foreach (BNode<T> bNode in bNodes)
    //        {
    //            Insert(bNode);
    //        }
    //    }
    //    /// <summary>
    //    /// ？写不下去了
    //    /// </summary>
    //    /// <param name="bNodes"></param>
    //    [Obsolete]
    //    public void InQuene(List<IndexNode<T>> bNodes)
    //    {
    //        foreach (IndexNode<T> bNode in bNodes)
    //        {
    //            Insert(bNode);
    //        }
    //    }
    //}
}
