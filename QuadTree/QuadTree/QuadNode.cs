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
    }
}
