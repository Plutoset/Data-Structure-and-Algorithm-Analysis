using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    public class QuadNode<T>
    {
        public Point Position { get; set; }
        public T Value { get; set; }
        public QuadNode<T> NW { get; set; }
        public QuadNode<T> NE { get; set; }
        public QuadNode<T> SW { get; set; }
        public QuadNode<T> SE { get; set; }
        public QuadNode(Point position, T value)
        {
            this.Position = position;
            this.Value = value;
        }
        public double DistanceTo(Point point)
        {
            return Math.Sqrt(Math.Pow(Position.X - point.X, 2) + Math.Pow(Position.Y - point.Y, 2));
        }
    }
}
