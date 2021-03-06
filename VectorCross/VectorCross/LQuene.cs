using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace VectorCross
{
    
    class LQueue<T>
    {
        public Node<T> front;   // 队首
        public Node<T> rear;   // 队尾

        /// <summary>
        /// 构造器
        /// </summary>
        public LQueue()
        {
            front = new Node<T>();
            rear = front;
        }
        /// <summary>
        /// WARNING UNCOMPLETED FUNCTION
        /// 通过内容检索并且返回值并没有什么意思，就不写了
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Obsolete]
        public T Find(T data)
        {
            Node<T> nowNode = front;
            int i = 0;
            if (front.Data == null)
            {
                Console.WriteLine("LinkQuene already empty!");
                return default;
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
                throw new IndexOutOfRangeException();
            }

        }
        /// <summary>
        /// 循环打印链式表中的所有元素
        /// </summary>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Node<T> nowNode = front;
            int j = 0;
            if (nowNode.Data == null)
            {
                return "No elements in this LQuene. \n";
            }
            else
            {
                while (nowNode != null)
                {
                    j++;
                    stringBuilder.AppendLine($"Element {j}, data {nowNode.Data}");
                    nowNode = nowNode.Next;
                }
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// 返回index位置的值，或者对index位置重新赋值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                Node<T> nowNode = front;
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
                    throw new IndexOutOfRangeException();
                }
                return default;
            }
            set
            {
                Node<T> nowNode = front;
                int i = 0;
                while (index != 1 & nowNode.Next != null)
                {

                    if (i == index - 2 & nowNode.Next != null)
                    {
                        nowNode.Next.Data = value;
                        break;
                    }
                    else if (i == index - 2 & nowNode.Next == null)
                    {
                        nowNode.Next = new Node<T>{Data = value};
                        rear = nowNode.Next.Next.Next;
                        break;
                    }
                    nowNode = nowNode.Next;
                    i++;
                }
                if (i < index - 2 || index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                //需要修改第一个值
                if (index == 1)
                {
                    Node<T> store = nowNode;
                    front = new Node<T> { Data = value };
                    if (store.Data == null)//第一个值不存在，头就是尾
                    {
                        rear = front;
                    }
                    else//第一个值存在，新头接上旧头的索引
                    {
                        front.Next = store.Next;
                    }
                }
                else if (nowNode.Next == null )//末尾的值
                {
                    nowNode.Next = new Node<T> { Data = value };
                    rear = nowNode.Next;
                }
                return;
            }
        }
        
        /// <summary>
        /// 判空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return front.Data == null;
        }
        /// <summary>
        /// 在index处入队
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data, int index)
        {
            //新建节点
            Node<T> tmp = new(data);
            Node<T> nowNode = front;
            int i = 0;
            if (index == 1)
            {
                Node<T> store = front;
                front = tmp;
                if (store.Data != null)
                {
                    front.Next = store;
                }
                
                if (rear.Data == null)
                {
                    rear = front;
                }
                return;
            }
            else
            {
                while (nowNode != null)
                {
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
                    throw new IndexOutOfRangeException();
                }
                
            }
        }
        /// <summary>
        /// 删除index处的节点，如果index超出范围则console报错并且不执行操作
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            Node<T> nowNode = front;
            int i = 0;
            if (index == 1)
            {
                if (front.Data == null)
                {
                    Console.WriteLine("LinkQuene already empty!");
                }
                else
                {
                    front = front.Next;
                }
                return;
            }
            else
            {
                while (nowNode != null)
                {
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
                    throw new IndexOutOfRangeException();
                }

            }
        }
        public int Count()
        {
            int i = 0;
            Node<T> nowNode = front;
            while (nowNode != null)
            {
                i++;
                nowNode = nowNode.Next;
            }
            return i;
        }
    }
}