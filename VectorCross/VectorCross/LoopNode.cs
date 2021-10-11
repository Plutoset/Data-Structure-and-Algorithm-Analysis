namespace VectorCross
{
    class LoopNode<T>
    {
        public T Data { get; set; }
        internal LoopNode<T> Next { get; set; }
        public bool Visit { get; set; } = false;
        /// <summary>
        /// 构造器
        /// </summary>
        public LoopNode()
        {
            this.Data = default;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="data"></param>
        public LoopNode(T data)
        {
            this.Data = data;
        }

    }
}
