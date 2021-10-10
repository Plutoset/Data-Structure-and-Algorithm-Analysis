using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCross
{
    class Node<T>
    {
        T data;
        Node<T> next;

        /// <summary>
        /// 构造器
        /// </summary>
        public Node()
        {
            this.Data = default;
            this.Next = null;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
        }
        public T Data { get => data; set => data = value; }
        internal Node<T> Next { get => next; set => next = value; }
    }
}
