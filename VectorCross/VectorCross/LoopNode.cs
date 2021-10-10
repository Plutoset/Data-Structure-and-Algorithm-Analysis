using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCross
{
    class LoopNode<T>
    {
        T data;
        LoopNode<T> next;
        bool visit = false;

        /// <summary>
        /// 构造器
        /// </summary>
        public LoopNode()
        {
            this.Data = default;
            this.Next = null;
            this.Visit = visit;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="data"></param>
        public LoopNode(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Visit = false;
        }
        public T Data { get => data; set => data = value; }
        internal LoopNode<T> Next { get => next; set => next = value; }
        public bool Visit { get => visit; set => visit = value; }
    }
}
