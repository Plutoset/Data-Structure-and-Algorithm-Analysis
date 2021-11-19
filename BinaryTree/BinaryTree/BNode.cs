using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BNode<T>
    {
        public T Data { get; set; }
        public BNode<T> LChild { get; set; }
        public BNode<T> RChild { get; set; }
        //public BNode<T> Parent { get; set; }
        
        public BNode(T data)
        {
            this.Data = data;
        }
        //public BNode(T data, BNode<T> leftChild, BNode<T> rightChild, BNode<T> parent)
        //{
        //    this.Data = data;
        //    this.LChild = leftChild;
        //    this.RChild = rightChild;
        //    this.Parent = parent;
        //}
        public BNode(T data, BNode<T> leftChild, BNode<T> rightChild)
        {
            this.Data = data;
            this.LChild = leftChild;
            this.RChild = rightChild;
        }
        public BNode<T> Empty()
        {
            if (this.Data != null)
            {
                this.LChild.Empty();
                this.RChild.Empty();
            }
            return null;
        }
    }
   
}
