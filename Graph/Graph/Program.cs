using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化图矩阵
            Node<string> A = new Node<string>("A");
            Node<string> B = new Node<string>("B");
            Node<string> C = new Node<string>("C");
            Node<string> D = new Node<string>("D");
            Node<string> E = new Node<string>("E");
            Node<string>[] Nodes = new Node<string>[5] { A,B,C,D,E };
            Graph<string> graph = new Graph<string>(5);
            graph.SetNodes(Nodes);
            graph.SetEdge(A, B, 60);
            graph.SetEdge(A, C, 80);
            graph.SetEdge(A, D, 30);
            graph.SetEdge(B, C, 40);
            graph.SetEdge(B, D, 75);
            graph.SetEdge(C, E, 35);
            graph.SetEdge(D, E, 45);

            graph.DFS();
            //初始化结束，开始深度优先算法

        }
        
    }

    
}
