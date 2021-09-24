using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkQueue
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
            this.Data = default(T);
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
    class LQueue<T>
    {
        Node<T> font;   // 队首
        Node<T> rear;   // 队尾

        /// <summary>
        /// 构造器
        /// </summary>
        public LQueue()
        {
            font = new Node<T>();
            rear = font;
            font.Next = null;
        }

        /// <summary>
        /// 在表尾入队
        /// </summary>
        /// <param name="data"></param>
        public void Put(T data)
        {
            //新建节点
            Node<T> tmp = new Node<T>(data);
            //挂载节点到队尾
            rear.Next = tmp;
            //更新队尾
            rear = tmp;
        }

        /// <summary>
        /// 在表头出队
        /// </summary>
        public T Get()
        {
            if (font.Next == null) return default(T);
            //保存队首元素
            Node<T> tmp = font.Next;
            //悬空队首元素
            font.Next = font.Next.Next;
            return tmp.Data;
        }

        /// <summary>
        /// 判空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return font.Next == null;
        }
    }
}
