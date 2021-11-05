using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace QuadTree
{
    public class QuadTree<T>

    {
        public QuadNode<T> Root { get; set; }
        public void AddNode(QuadNode<T> quadNode)
        {
            if (IsEmpty())
            {
                Root = quadNode;
            }
            else
            {
                QuadNode<T> nowNode = Root;
                while (true)
                {
                    int direction = 0;
                    QuadNode<T> nextNode;
                    if ((quadNode.Position.X == nowNode.Position.X) && (quadNode.Position.Y == nowNode.Position.Y))
                    {
                        throw new Exception("Duplicate Node positions not allowed. ");
                    }
                    if ((quadNode.Position.X >= nowNode.Position.X) && (quadNode.Position.Y >= nowNode.Position.Y))
                    {
                        direction = 1;//NW
                    }
                    else if ((quadNode.Position.X >= nowNode.Position.X) && (quadNode.Position.Y < nowNode.Position.Y))
                    {
                        direction = 2;//NE
                    }
                    else if ((quadNode.Position.X < nowNode.Position.X) && (quadNode.Position.Y >= nowNode.Position.Y))
                    {
                        direction = 3;//SW
                    }
                    else if ((quadNode.Position.X < nowNode.Position.X) && (quadNode.Position.Y < nowNode.Position.Y))
                    {
                        direction = 4;//SE
                    }
                    if (direction == 1)
                    {
                        nextNode = nowNode.NW;
                        if (nextNode == null)
                        {
                            nowNode.NW = quadNode;
                            break;
                        }
                        nowNode = nextNode;
                    }
                    else if (direction == 2)
                    {
                        nextNode = nowNode.NE;
                        if (nextNode == null)
                        {
                            nowNode.NE = quadNode;
                            break;
                        }
                        nowNode = nextNode;
                    }
                    else if (direction == 3)
                    {
                        nextNode = nowNode.SW;
                        if (nextNode == null)
                        {
                            nowNode.SW = quadNode;
                            break;
                        }
                        nowNode = nextNode;
                    }
                    else if (direction == 4)
                    {
                        nextNode = nowNode.SE;
                        if (nextNode == null)
                        {
                            nowNode.SE = quadNode;
                            break;
                        }
                        nowNode = nextNode;
                    }
                }
            }
        }
        public void AddNodes(List<QuadNode<T>> quadNodes)
        {
            foreach(QuadNode<T> quadNode in quadNodes)
            {
                AddNode(quadNode);
            }
        }
        public bool IsEmpty()
        {
            return Root == null;
        }
        public List<QuadNode<T>> GetChildren(QuadNode<T> quadNode)
        {
            List<QuadNode<T>> quadNodes = new List<QuadNode<T>> { quadNode };
            quadNodes = Loop(quadNode, quadNodes);
            return quadNodes;
        }
        public List<QuadNode<T>> Loop(QuadNode<T> quadNode, List<QuadNode<T>> quadNodes)
        {

            if (quadNode.NW != null)
            {
                quadNodes.Add(quadNode.NW);
                quadNodes = Loop(quadNode.NW, quadNodes);
            }
            if (quadNode.NE != null)
            {
                quadNodes.Add(quadNode.NE);
                quadNodes = Loop(quadNode.NE, quadNodes);
            }
            if (quadNode.SW != null)
            {
                quadNodes.Add(quadNode.SW);
                quadNodes = Loop(quadNode.SW, quadNodes);
            }
            if (quadNode.SE != null)
            {
                quadNodes.Add(quadNode.SE);
                quadNodes = Loop(quadNode.SE, quadNodes);
            }
            return quadNodes;
        }
        public List<QuadNode<T>> Loop(QuadNode<T> quadNode, List<QuadNode<T>> quadNodes, Point position, double d)
        {

            if (quadNode.NW != null)
            {
                if(quadNode.NW.Position.Distance(position, d))
                {
                    quadNodes.Add(quadNode.NW);
                }
                quadNodes = Loop(quadNode.NW, quadNodes, position, d);
            }
            if (quadNode.NE != null)
            {
                if (quadNode.NE.Position.Distance(position, d))
                {
                    quadNodes.Add(quadNode.NE);
                }
                quadNodes = Loop(quadNode.NE, quadNodes, position, d);
            }
            if (quadNode.SW != null)
            {
                if (quadNode.SW.Position.Distance(position, d))
                {
                    quadNodes.Add(quadNode.SW);
                }
                quadNodes = Loop(quadNode.SW, quadNodes, position, d);
            }
            if (quadNode.SE != null)
            {
                if (quadNode.SE.Position.Distance(position, d))
                {
                    quadNodes.Add(quadNode.SE);
                }
                quadNodes = Loop(quadNode.SE, quadNodes, position, d);
            }
            return quadNodes;
        }
        public  QuadNode<T> Loop(Point position, ref double minDistance, QuadNode<T> quadNode, QuadNode<T> nowNode)
        {
            if (quadNode.NW != null)
            {
                if (quadNode.NW.DistanceTo(position) < minDistance)
                {
                    nowNode = quadNode.NW;
                    minDistance = quadNode.NW.DistanceTo(position);
                }
                nowNode = Loop(position, ref minDistance, quadNode.NW, nowNode);
            }
            if (quadNode.NE != null)
            {
                if (quadNode.NE.DistanceTo(position) < minDistance)
                {
                    nowNode = quadNode.NE;
                    minDistance = quadNode.NE.DistanceTo(position);
                }
                nowNode = Loop(position, ref minDistance, quadNode.NE, nowNode);
            }
            if (quadNode.SW != null)
            {
                if (quadNode.SW.DistanceTo(position) < minDistance)
                {
                    nowNode = quadNode.SW;
                    minDistance = quadNode.SW.DistanceTo(position);
                }
                nowNode = Loop(position, ref minDistance, quadNode.SW, nowNode);
            }
            if (quadNode.SE != null)
            {
                if (quadNode.SE.DistanceTo(position) < minDistance)
                {
                    nowNode = quadNode.SE;
                    minDistance = quadNode.SE.DistanceTo(position);
                }
                nowNode = Loop(position, ref minDistance, quadNode.SE, nowNode);
            }
            return nowNode;
        }
        public List<QuadNode<T>> Search(Point position, double d)
        {
            List<QuadNode<T>> quadNodes = new List<QuadNode<T>>();
            quadNodes = Loop(Root, quadNodes, position, d);
            return quadNodes;
        }
        public QuadNode<T> FindNearest(Point position)
        {
            QuadNode<T> nowNode = Root;
            double distance = nowNode.DistanceTo(position);
            nowNode = Loop(position, ref distance, nowNode, nowNode);
            return nowNode;
        }
    }
}
