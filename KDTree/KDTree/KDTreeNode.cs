using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class KDTreeNode<T>
    {
        public bool Axis { get; set; }
        public Point Position { get; set; }
        public T Value { get; set; }
        public KDTreeNode<T> Left { get; set; }
        public KDTreeNode<T> Right { get; set; }

        public bool GetIsLeaf() => Left == null && Right == null;
        public KDTreeNode(Point position, T value)
        {
            this.Position = position;
            this.Value = value;
        }
    }
}
