using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Node<T>
    {
        private T data;//数据域
        //构造器
        public Node(T v)
        {
            data = v;
        }
        //数据域属性
        public T Data { get => data; set => data = value; }
    }
    //图的接口
    public interface IGraph<T>
    {
        //获取顶点数
        int GetNumOfVertex();
        //获取边或弧的数目
        int GetNumOfEdge();
        //在两个顶点之间添加权为v的边或弧
        void SetEdge(Node<T> v1, Node<T> v2, int v);
        //删除两个顶点之间的边或弧
        void DelEdge(Node<T> v1, Node<T> v2);
        //判断两个顶点之间是否有边或弧
        bool IsEdge(Node<T> v1, Node<T> v2);
    }
    //图类
    public class Graph<T> : IGraph<T>
    {
        public int NumEdges { get; set; } //边的数目
        public int[,] Matrix { get; set; } //邻接矩阵数组
        public Node<T>[] Nodes { get; set; } //顶点数组
        //顶点访问数组
        private int[] visited;
        //邻接表数组
        private VexNode<T>[] adjList;
        //构造器
        public Graph(int n)
        {
            Nodes = new Node<T>[n];
            Matrix = new int[n, n];
            NumEdges = 0;
            visited = new int[n];
            adjList = new VexNode<T>[n];
        }
        //获取索引为index的顶点信息
        public Node<T> GetNode(int index)
        {
            return Nodes[index];
        }
        //设置索引为index的顶点信息
        public void SetNode(int index, Node<T> v)
        {
            Nodes[index] = v;
            adjList[index] = new VexNode<T>(v);
        }
        public void SetNodes(Node<T>[] vs)
        {
            for(int i=0;i<vs.Length;i++)
            {
                Node<T> v = vs[i];
                SetNode(i, v);
            }
        }

        //获取matrix[index1,index2]的值
        public int GetMatrix(int index1, int index2)
        {
            return Matrix[index1, index2];
        }
        //设置matrix[index1,index2]的值
        public void SetMatrix(int index1, int index2)
        {
            Matrix[index1, index2] = 1;
        }
        //获取顶点数目
        public int GetNumOfVertex()
        {
            return Nodes.Length;
        }
        //获取边的数目
        public int GetNumOfEdge()
        {
            return NumEdges;
        }
        /// <summary>
        /// 判断v是否是图的顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool IsNode(Node<T> v)
        {
            //遍历顶点数组
            foreach (Node<T> nd in Nodes)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回true;
                if (v.Equals(nd))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 获取顶点v在顶点数组中的索引，若顶点不在图中的话返回-1（会先判断一遍IsNode，如果false直接返回-1
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int GetIndex(Node<T> v)
        {
            if (IsNode(v))
            {
                //遍历顶点数组
                for (int i = 0; i < Nodes.Length; i++)
                {
                    //如果顶点v与nodes[i]相等，则v是图的顶点，返回索引值i
                    //因为判断过IsNode以后，能进这个循环的的话顶点肯定在里面，迟早会返回值的
                    if (Nodes[i].Equals(v))
                        return i;
                }
            }
            // 如果顶点v不在图中的话会直接返回-1
            return -1;
        }
        //在顶点v1和v2之间添加权值为v的边
        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            ////不是无向图
            //if (v != 1)
            //{
            //    Console.WriteLine("Weight is not right!");
            //    return;
            //}
            // 无向，v为联通分量，（另一种情况是v全都为1，就是不考虑成本变化）
            //矩阵是对称矩阵
            Matrix[GetIndex(v1), GetIndex(v2)] = v;
            Matrix[GetIndex(v2), GetIndex(v1)] = v;
            //处理顶点v1的邻接表
            AdjListNode<T> p = new AdjListNode<T>(GetIndex(v2));
            //顶点v1没有邻接顶点
            if (adjList[GetIndex(v1)].FirstAdj == null)
                adjList[GetIndex(v1)].FirstAdj = p;
            else
            {
                p.Next = adjList[GetIndex(v1)].FirstAdj;
                adjList[GetIndex(v1)].FirstAdj = p;
            }
            //处理顶点v2的邻接表
            p = new AdjListNode<T>(GetIndex(v1));
            //顶点v2没有邻接顶点
            if (adjList[GetIndex(v2)].FirstAdj == null)
                adjList[GetIndex(v2)].FirstAdj = p;
            //顶点v2有邻接顶点
            else
            {
                p.Next = adjList[GetIndex(v2)].FirstAdj;
                adjList[GetIndex(v2)].FirstAdj = p;
            }
            ++NumEdges;
        }
        //删除顶点v1和v2之间的边
        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //v1和v2之间存在边
            if (Matrix[GetIndex(v1), GetIndex(v2)] == 1)
            {
                //矩阵是对称矩阵
                Matrix[GetIndex(v1), GetIndex(v2)] = 0;
                Matrix[GetIndex(v2), GetIndex(v1)] = 0;
                --NumEdges;
            }
        }
        //判断顶点v1与v2之间是否存在边
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return false;
            }
            //顶点v1与v2之间存在边
            if (Matrix[GetIndex(v1), GetIndex(v2)] > 0)
                return true;
            else
                return false;
        }
        //图的深度优先遍历算法实现
        //在写
        public void DFS()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                    DFSAL(i);
            }
            Reflesh();
        }

        //从某个顶点出发进行深度优先遍历
        public void DFSAL(int i)
        {
            Console.WriteLine(Nodes[i].Data);
            visited[i] = 1;
            AdjListNode<T> p = adjList[i].FirstAdj;
            while (p != null)
            {
                if (visited[p.Adjvex] == 0)
                    DFSAL(p.Adjvex);
                p = p.Next;
            }
        }
        public void Reflesh()
        {
            visited = new int[Nodes.Length];
        }
        //public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
        //{
        //    for (var i = 0; i < array.GetLength(0); i++)
        //    {
        //        yield return array[i, row];
        //    }
        //}
    }

    //图邻接表结点类
    public class AdjListNode<T>
    {
        //邻接顶点属性
        public int Adjvex { get; set; }
        //下一个邻接表结点属性
        public AdjListNode<T> Next { get; set; }
        //构造器
        public AdjListNode(int vex)
        {
            this.Adjvex = vex;
            this.Next = null;
        }
    }

    //图邻接表顶点结点类
    public class VexNode<T>
    {
        public Node<T> Data { get; set; } //图的顶点
        public AdjListNode<T> FirstAdj { get; set; } //邻接表的第1个结点
        //构造器
        public VexNode()
        {
            this.Data = null;
            this.FirstAdj = null;
        }
        public VexNode(Node<T> nd)
        {
            this.Data = nd;
            this.FirstAdj = null;
        }
        public VexNode(Node<T> nd, AdjListNode<T> aLNode)
        {
            this.Data = nd;
            this.FirstAdj = aLNode;
        }

    }

}
