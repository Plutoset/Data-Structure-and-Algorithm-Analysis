using System;
using System.Collections.Generic;


namespace KDTree
{
    /// <summary>
    ///   K-dimensional tree.
    /// </summary>
    class KDTree<T>
    {
        public KDTreeNode<T> Root { get; set; }

        //节点个数
        public int Count { get; } 

        //叶子节点个数
        public int Leaves { get; }

        protected void CreateRoot(Point position, T value)
        {
            if (Root != null) return;
            if (position == null) throw new ArgumentNullException();
            Root = new KDTreeNode<T>(position, value);
        }
        public bool IsEmpty()
        {
            return Root == null;
        }
        public void AddNode(KDTreeNode<T> kDTreeNode)
        {
            if (IsEmpty())
            {
                Root = kDTreeNode;
                Root.Axis = true;
                return;
            }
            KDTreeNode<T> nowNode = Root;
            bool direction = true;//x轴true，y轴false
            while(true)
            {
                bool lr;
                KDTreeNode<T> nextNode;
                if (nowNode.Axis)
                {
                    lr = (kDTreeNode.Position.X < nowNode.Position.X);
                }
                else
                {
                    lr = (kDTreeNode.Position.Y < nowNode.Position.Y);
                }
                //lr true查左，false查右
                if (lr)
                {
                    nextNode = nowNode.Left;
                    if (nextNode == null)
                    {
                        nowNode.Left = kDTreeNode;
                        nowNode.Left.Axis = !nowNode.Axis;
                        break;
                    }
                    nowNode = nextNode;
                }
                else
                {
                    nextNode = nowNode.Right;
                    if (nextNode == null)
                    {
                        nowNode.Right = kDTreeNode;
                        nowNode.Right.Axis = !nowNode.Axis;
                        break;
                    }
                    nowNode = nextNode;
                }
            }
        }
        public void AddNodes(List<KDTreeNode<T>> kDTreeNodes)
        {
            foreach(KDTreeNode<T> kDTreeNode in kDTreeNodes)
            {
                AddNode(kDTreeNode);
            }
        }
        /// <summary>
        /// 根据位置查找算法
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public KDTreeNode<T> Find(Point position)
        {
            KDTreeNode<T> nowNode = Root;
            bool direction = true;//x轴true，y轴false
            while (true)
            {
                bool lr;
                KDTreeNode<T> nextNode;
                if(position.X.Equals(nowNode.Position.X) && position.Y.Equals(nowNode.Position.Y))
                {
                    break;
                }
                    if (direction)
                {
                    lr = (position.X < nowNode.Position.X);
                }
                else
                {
                    lr = (position.Y < nowNode.Position.Y);
                }
                //lr true查左，false查右
                if (lr)
                {
                    nextNode = nowNode.Left;
                    if (nextNode == null)
                    {
                        break;
                    }
                    nowNode = nextNode;
                }
                else
                {
                    nextNode = nowNode.Right;
                    if (nextNode == null)
                    {
                        break;
                    }
                    nowNode = nextNode;
                }
                direction = !direction;
            }
            if (!position.X.Equals(nowNode.Position.X) || !position.Y.Equals(nowNode.Position.Y))
            {
                throw new Exception("No such Point exists!");
            }
            return nowNode;
        }
        /// <summary>
        /// 根据内容查找算法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public KDTreeNode<T> Find(T value)
        {
            KDTreeNode<T> nowNode = Root;
            nowNode = Find(value, nowNode);
            if (!nowNode.Value.Equals(value))
            {
                throw new Exception("No such Point exists!");
            }
            return nowNode;
        }
        /// <summary>
        /// 内嵌根据内容查找函数
        /// </summary>
        /// <param name="nowNode"></param>
        /// <param name="value"></param>
        /// <param name="onot"></param>
        public KDTreeNode<T> Find(T value, KDTreeNode<T> nowNode)
        {
            if (nowNode.Value.Equals(value))
            {
                return nowNode;
            }
            else
            {
                KDTreeNode<T> lNode = nowNode.Left;
                KDTreeNode<T> rNode = nowNode.Right;
                KDTreeNode<T> aNode = null;
                if (lNode != null)
                {
                    aNode = Find(value, lNode);
                }
                if (aNode == null && rNode!=null)
                {
                    aNode = Find(value, rNode);
                }
                return aNode;
            }
        }
        /// <summary>
        /// 导出为list
        /// </summary>
        /// <returns></returns>
        public List<KDTreeNode<T>> ToList()
        {
            List<KDTreeNode<T>> kDTreeNodes = new List<KDTreeNode<T>>();
            kDTreeNodes = Loop(Root, kDTreeNodes);
            return kDTreeNodes;
        }
        /// <summary>
        /// 循环遍历得到从nowNode出发的所有子节点
        /// </summary>
        /// <param name="nowNode"></param>
        /// <param name="kDTreeNodes"></param>
        /// <returns></returns>
        public List<KDTreeNode<T>> Loop(KDTreeNode<T> nowNode, List<KDTreeNode<T>> kDTreeNodes)
        {
            if (nowNode!=null)
            {
                kDTreeNodes.Add(nowNode);
                KDTreeNode<T> lNode = nowNode.Left;
                KDTreeNode<T> rNode = nowNode.Right;
                if (lNode != null)
                {
                    kDTreeNodes = Loop(lNode, kDTreeNodes);
                }
                if (rNode != null)
                {
                    kDTreeNodes = Loop(rNode, kDTreeNodes);
                }
            }
            return kDTreeNodes;
        }
        public void Delete(Point position)
        {
            if(position.X.Equals(Root.Position.X) && position.Y.Equals(Root.Position.Y))
            {
                Root = null;
                return;
            }
            KDTreeNode<T> nowNode = Root;
            //x轴true，y轴false
            while (true)
            {
                bool lr;
                KDTreeNode<T> nextNode;
                if (
                    (position.X.Equals(nowNode.Left.Position.X) && position.Y.Equals(nowNode.Left.Position.Y))  ||
                    (position.X.Equals(nowNode.Right.Position.X) && position.Y.Equals(nowNode.Right.Position.Y))
                    )
                {
                    break;
                }
                if (nowNode.Axis)
                {
                    lr = (position.X < nowNode.Position.X);
                }
                else
                {
                    lr = (position.Y < nowNode.Position.Y);
                }
                //lr true查左，false查右
                if (lr)
                {
                    nextNode = nowNode.Left;
                    if (nextNode == null)
                    {
                        break;
                    }
                    nowNode = nextNode;
                }
                else
                {
                    nextNode = nowNode.Right;
                    if (nextNode == null)
                    {
                        break;
                    }
                    nowNode = nextNode;
                }
            }
            if (position.X.Equals(nowNode.Left.Position.X) && position.Y.Equals(nowNode.Left.Position.Y))
            {
                KDTreeNode<T> Node = nowNode.Left;
                if (Node.Left == null && Node.Right == null)
                {
                    nowNode.Left = null;
                }
                else if(Node.Left != null && Node.Right == null)
                {
                    nowNode.Left = Node.Left;
                    nowNode.Left.Axis = !nowNode.Left.Axis;
                }
                else if (Node.Left == null && Node.Right != null)
                {
                    nowNode.Left = Node.Right;
                    nowNode.Left.Axis = !nowNode.Right.Axis;
                }
                else
                {
                    bool lr;
                    if (nowNode.Axis)
                    {
                        lr = (nowNode.Left.Left.Position.X < nowNode.Left.Right.Position.X);
                    }
                    else
                    {
                        lr = (nowNode.Left.Left.Position.Y < nowNode.Left.Right.Position.Y);
                    }
                    if (lr)
                    {

                        nowNode.Left = Node.Left;
                        nowNode.Left.Right = Node.Right;
                        nowNode.Left.Axis = !nowNode.Right.Axis;
                    }
                    else
                    {
                        nowNode.Left = Node.Right;
                        nowNode.Left.Right = Node.Left;
                        nowNode.Left.Axis = !nowNode.Left.Axis;
                    }
                }
            }
            else if(position.X.Equals(nowNode.Right.Position.X) && position.Y.Equals(nowNode.Right.Position.Y))
            {
                KDTreeNode<T> Node = nowNode.Right;
                if (Node.Left == null && Node.Right == null)
                {
                    nowNode.Right = null;
                }
                else if (Node.Left != null && Node.Right == null)
                {
                    nowNode.Right = Node.Left;
                    nowNode.Right.Axis = !nowNode.Left.Axis;
                }
                else if (Node.Left == null && Node.Right != null)
                {
                    nowNode.Right = Node.Right;
                    nowNode.Right.Axis = !nowNode.Right.Axis;
                }
                else
                {
                    bool lr;
                    if (nowNode.Axis)
                    {
                        lr = (nowNode.Right.Left.Position.X < nowNode.Right.Right.Position.X);
                    }
                    else
                    {
                        lr = (nowNode.Right.Left.Position.Y < nowNode.Right.Right.Position.Y);
                    }
                    if (lr)
                    {

                        nowNode.Right = Node.Left;
                        nowNode.Right.Right = Node.Right;
                        nowNode.Right.Axis = !nowNode.Right.Axis;
                    }
                    else
                    {
                        nowNode.Right = Node.Right;
                        nowNode.Right.Right = Node.Left;
                        nowNode.Right.Axis = !nowNode.Right.Axis;
                    }
                }
            }
            else
            {
                throw new Exception("No such Point exists!");
            }
        }
        public void DeleteAt(Point position)
        {
            KDTreeNode<T> node = Find(position);
            List<KDTreeNode<T>> kDTreeNodes = ToList();
            kDTreeNodes.Remove(node);
            Empty();
            kDTreeNodes = Clear(kDTreeNodes);
            AddNodes(kDTreeNodes);
        }
        public static List<KDTreeNode<T>> Clear(List<KDTreeNode<T>> kDTreeNodes)
        {
            if (kDTreeNodes.Count > 0)
            {
                foreach (KDTreeNode<T> kDTreeNode in kDTreeNodes)
                {
                    kDTreeNode.Left = null;
                    kDTreeNode.Right = null;
                }
            }
            return kDTreeNodes;
        }
        public void DeleteAt(T value)
        {
            KDTreeNode<T> node = Find(value);
            List<KDTreeNode<T>> kDTreeNodes = ToList();
            kDTreeNodes.Remove(node);
            Empty();
            kDTreeNodes = Clear(kDTreeNodes);
            AddNodes(kDTreeNodes);
        }
        public void Empty()
        {
            Root = null;
        }
    }
    public struct KDTreeNodeDistance<T> : IComparable, IComparable<KDTreeNodeDistance<T>>, IEquatable<KDTreeNodeDistance<T>> 
    { 
        public double Distance { get; } 
        public KDTreeNode<T> Node { get; } 
        public KDTreeNodeDistance(KDTreeNode<T> node, double distance) 
        { 
            this.Node = node; 
            this.Distance = distance; 
        } 
        public int CompareTo(object obj) 
        { 
            return Distance.CompareTo((KDTreeNodeDistance<T>)obj); 
        } 
        public int CompareTo(KDTreeNodeDistance<T> other) 
        { 
            return Distance.CompareTo(other.Distance); 
        } 
        public bool Equals(KDTreeNodeDistance<T> other) 
        { 
            return Distance == other.Distance && Node == other.Node; 
        } 
    }

}
