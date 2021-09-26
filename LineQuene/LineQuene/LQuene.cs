using System;

namespace LineQuene
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
        }
        // <summary>
        /// 在index处修改值
        /// </summary>
        /// <param name="data"></param>
        public void Modify(T data, int index)
        {
            Node<T> nowNode = font;
            int i = 0;
            while (nowNode != null)
            {
                i++;
                if (i == index)
                {
                nowNode.Data = data;
                    break;
                }
                nowNode = nowNode.Next;
            }
            if (i < index || index < 1)
            {
                Console.WriteLine("Input index out of range!");
            }
        }

        /// <summary>
        /// WARNING UNCOMPLETED FUNCTION
        /// 通过内容检索并且返回值并没有什么意思，就不写了
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Find(T data)
        {
            Node<T> nowNode = font;
            int i = 0;
            if (font.Data == null)
            {
                Console.WriteLine("LinkQuene already empty!");
                return default(T);
            }
            else
            {
                while (nowNode != null)
                {
                    i++;
                    if (nowNode.Data.Equals(data))
                    {
                        return nowNode.Data;
                    }
                    nowNode = nowNode.Next;
                }

                Console.WriteLine("Input index out of range!");
                return default(T);

            }

        }
        /// <summary>
        /// 循环打印链式表中的所有元素
        /// </summary>
        public void Loop()
        {
            Node<T> pn = font;
            int j = 0;
            while (pn != null)
            {
                j++;
                Console.WriteLine($"element{j}, data {pn.Data}" );
                pn = pn.Next;
            }
        }
        /// <summary>
        /// 找出并打印index位置的元素，如果超出范围则console报错并且返回null值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            Node<T> nowNode = font;
            int i = 0;
                while (nowNode != null)
                {
                    i++;
                    if (i == index)
                    {
                    return nowNode.Data;
                    }
                    nowNode = nowNode.Next;
                }
                if (i > index || index < 1)
                {
                    Console.WriteLine("Input index out of range!");
                }
            return default(T);
        }
        /// <summary>
        /// 判空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return font.Data == null;
        }
        /// <summary>
        /// 在index处入队
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data, int index)
        {
            //新建节点
            Node<T> tmp = new Node<T>(data);
            Node<T> nowNode = font;
            int i = 0;
            if (index == 1)
            {
                Node<T> store = font;
                font = tmp;
                if (store.Data != null)
                {
                    font.Next = store;
                }
                
                if (rear.Data == null)
                {
                    rear = font;
                }
                return;
            }
            else
            {
                while (nowNode != null)
                {
                   // nowNode = nowNode.Next;
                    i++;
                    if (i == index - 1)
                    {
                        Node<T> store = nowNode.Next;
                        nowNode.Next = tmp;
                        tmp.Next = store;
                        break;
                    }
                    nowNode = nowNode.Next;
                }
                if (i < index-1 || index < 1)
                {
                    Console.WriteLine("Input index out of range!");
                }
                
            }
            Console.WriteLine($"font data {font.Data} rear data {rear.Data}");
        }
        /// <summary>
        /// 删除index处的节点，如果index超出范围则console报错并且不执行操作
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            Node<T> nowNode = font;
            int i = 0;
            if (index == 1)
            {
                if (font.Data == null)
                {
                    Console.WriteLine("LinkQuene already empty!");
                }
                else
                {
                    font = font.Next;
                }
                return;
            }
            else
            {
                while (nowNode != null)
                {
                    // nowNode = nowNode.Next;
                    i++;
                    if (i == index - 1)
                    {
                        Node<T> store = nowNode.Next;
                        nowNode.Next = store.Next;
                        break;
                    }
                    nowNode = nowNode.Next;
                }
                if (i < index - 1|| index < 1)
                {
                    Console.WriteLine("Input index out of range!");
                }

            }
            //Console.WriteLine($"font data {font.Data} rear data {rear.Data}");
        }
    }
}