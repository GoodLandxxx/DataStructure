using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class DST<Key, Value> where Key : IComparable where Value : IComparable
    {
        public class Node
        {
            public Key key;
            public Value value;
            public Node next;
            public Node previous;
            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
                this.previous = null;
            }
        }
        private Node Head;
        private int count;
        public DST()
        {
            Head = null;
            count = 0;
        }
        public int Size()
        {
            return count;
        }
        public Boolean IsEmety()
        {
            return count == 0;
        }
        /// <summary>
        /// 插入节点在头节点的后面
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Insert(Key key ,Value value)
        {
            Node node = Head;
            while(node!=default(Node))
            {
                if (key.CompareTo(node.key) == 0)
                {
                    node.value = value;
                    return;
                }
                node = node.next;
            }
            Node newNode = new Node(key, value);
            Head.next = newNode;//下一个节点
            newNode.previous = Head;//下一个节点的的前一个节点。
            Head = newNode;
            count++;
        }
    }
}
