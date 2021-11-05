using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    public class QuadTreeNode<T>
    {
        public int depth; // 结点深度
        public bool is_leaf; // 是否是叶子结点
        public Region region { get; set; }
        
        public Point Position { get; set; }
        public T Value { get; set; }
        public QuadTreeNode<T> NW { get; set; }
        public QuadTreeNode<T> NE { get; set; }
        public QuadTreeNode<T> SW { get; set; }
        public QuadTreeNode<T> SE { get; set; }
        public QuadTreeNode(Point position, T value)
        {
            this.Position = position;
            this.Value = value;
        }
        public bool IsLeaf()
        {
            return NW == null && NE == null && SW == null && SE == null;
        }
        public int Direction(Point point)
        {
            if(Position.X==point.X || Position.Y == point.Y)
            {
                throw new Exception("Duplicate locations not allowed. ");
            }
            if (Position.X > point.X && Position.Y > point.Y)
            {
                return 1;
            }
            else if (Position.X > point.X && Position.Y < point.Y)
            {
                return 2;
            }
            else if (Position.X < point.X && Position.Y > point.Y)
            {
                return 3;
            }
            else 
            {
                return 4;
            }
        }
    }
    public struct Region
    {
        double Top { get; set; }
        double Bottom { get; set; }
        double Left { get; set; }
        double Right { get; set; }
    }
}
