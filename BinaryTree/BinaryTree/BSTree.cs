using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// 二叉搜索树：结点的左子节点的值永远小于该结点的值，而右子结点的值永远大于该结点的值 称为二叉搜索树
    /// </summary>
    class BSTree :BTree<IndexNode>
    {
        /// <summary>
        /// 在二叉搜索树中插入IndexNode
        /// </summary>
        /// <param name="indexNode"></param>
        public void Insert(IndexNode indexNode)
        {
            BNode<IndexNode>  parent = null, currentNode = null;
            Find(indexNode, ref parent, ref currentNode);
            if (currentNode != null)
            {
                Console.WriteLine("Duplicate words not allowed.");
                return;
            }
            else
            {
                BNode<IndexNode> tmp = new BNode<IndexNode>(indexNode);
                if (parent == null)
                {
                    Head = tmp;
                }
                else
                {
                    if (indexNode.Key < parent.Data.Key)
                    {
                        parent.LChild = tmp;
                    }
                    else
                    {
                        parent.RChild = tmp;
                    }
                }
            }
        }
        // 好好学学ref
        public void Find(IndexNode indexNode,ref BNode<IndexNode> parent, ref BNode<IndexNode> currentNode)
        {
            currentNode = Head;
            parent = null;
            while ((currentNode != null) && (currentNode.Data.Key.ToString() != indexNode.Key.ToString()) && (currentNode.Data.Data.ToString() != indexNode.Data.ToString()))
            {
                parent = currentNode;
                if(indexNode.Key < currentNode.Data.Key)
                {
                    currentNode = currentNode.LChild;
                }
                else
                {
                    currentNode = currentNode.RChild;
                }
            }
        }
        public void Find(int key)
        {
            BNode<IndexNode> currentNode = Head;
            while (currentNode != null && (currentNode.Data.Key.ToString() != key.ToString()))
            {
                Console.WriteLine(currentNode.Data.Data.ToString());
                if (key < currentNode.Data.Key)
                {
                    currentNode = currentNode.LChild;
                    Find(key);
                }
                else if(key > currentNode.Data.Key)
                {
                    currentNode = currentNode.RChild;
                    Find(key);
                }
                else
                {
                    Console.WriteLine("Quit.");
                }
            }
        }
    }
}
