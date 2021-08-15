namespace DataStructure.Node
{
    //单链表
    public class Node<T> 
    {
      

        // 数据域
        public T Item { get; set; }
        // 指针域
        public Node<T> Next { get; set; }

        public Node()
        {
        }

        public Node(T item)
        {
            this.Item = item;
        }

  
    }
}
