using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCross
{
    class Node<T>
    {
        public T Data { get; set; }
        internal Node<T> Next { get; set; } = null;
        /// <summary>
        /// 构造器
        /// </summary>
        public Node()
        {
            this.Data = default;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            this.Data = data;
        }
        public new string ToString()
        {
            return this.Data.ToString();
        }
    }
}
