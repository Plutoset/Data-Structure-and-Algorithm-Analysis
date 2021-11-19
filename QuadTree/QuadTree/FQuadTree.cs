using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    class FQuadTree<T>
    {
        public QuadTreeNode<T> Root { get; set; }
        public bool IsEmpty()
        {
            return Root == null;
        }
        public void AddNode(QuadTreeNode<T> quadTreeNode)
        {
            if (IsEmpty())
            {
                Root = quadTreeNode;
            }
            else
            {
                QuadTreeNode<T> nowNode = Root;
                while (true)
                {
                    if (nowNode.IsLeaf())
                    {

                    }
                }
            }
            
        }
        public new void AddNodes(List<QuadTreeNode<T>> quadNodes)
        {
            double xsum = 0, ysum = 0;
            double xmin, xmax, ymin, ymax;
            xmin = xmax = quadNodes[0].Position.X;
            ymin = ymax = quadNodes[0].Position.Y;
            foreach (QuadTreeNode<T> quadNode in quadNodes)
            {
                xsum += quadNode.Position.X;
                ysum += quadNode.Position.Y;
                
                xmin = quadNode.Position.X < xmin ? quadNode.Position.X : xmin;
                xmax = quadNode.Position.X > xmax ? quadNode.Position.X : xmax;
                ymin = quadNode.Position.Y < ymin ? quadNode.Position.Y : ymin;
                ymax = quadNode.Position.Y > ymax ? quadNode.Position.Y : ymax;
            }
            double xmean = xsum / quadNodes.Count;
            double ymean = ysum / quadNodes.Count;
            quadNodes.OrderBy(distance => Math.Pow(distance.Position.Y - ymean, 2) + Math.Pow(distance.Position.X - xmean, 2));
            QuadTreeNode<T> nowNode = quadNodes[0];
            quadNodes.RemoveAt(0);
            List<QuadTreeNode<T>> nwNodes = new();
            List<QuadTreeNode<T>> neNodes = new();
            List<QuadTreeNode<T>> swNodes = new();
            List<QuadTreeNode<T>> seNodes = new();
            foreach (QuadTreeNode<T> quadNode in quadNodes)
            {
                double direction = quadNode.Direction(nowNode.Position);
                if (direction == 1) nwNodes.Add(quadNode);
                else if (direction == 2) neNodes.Add(quadNode);
                else if (direction == 3) swNodes.Add(quadNode);
                else if (direction == 4) seNodes.Add(quadNode);
            }

        }
    }
}
