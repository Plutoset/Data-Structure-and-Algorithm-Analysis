using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// 定义索引文件结点的数据类型，Key为键，Data为键值。
    /// 在二叉树中，键和键值不能重复。
    /// </summary>
    public struct IndexNode<T>
    {
        public int Key { get; set; }
        public T Data { get; set; }
        public IndexNode(int key, T data)
        {
            this.Key = key;
            this.Data = data;
        }
    }
}
