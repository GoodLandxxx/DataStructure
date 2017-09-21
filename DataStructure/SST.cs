using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class LST<Key, Value> where Key : IComparable where Value : IComparable
    {
        public class Node
        {
            public Key key;
            public Value value;
            public Node next;
            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
            }
        }
        private Node Head;
        private int count;
        public LST()
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
        /// 插入节点在头节点的前面
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Insert(Key key, Value value)
        {
            Node node = Head;
            while (node != default(Node))
            {
                if (key.CompareTo(node.key) == 0)
                {
                    node.value = value;
                    return;
                }
                node = node.next;
            }
            Node newNode = new Node(key, value);
            newNode.next = Head;
            Head = newNode;
            count++;
        }
        public Value Search(Key key)
        {
            Node node = Head;
            while (node != null)
            {
                if (key.CompareTo(node.key) == 0)
                {
                    return node.value;
                }
                node = node.next;
            }
            return default(Value);
        }
        public bool Contain(Value value)
        {
            Node node = Head;
            while (node != null)
            {
                if (value.CompareTo(node.value) == 0)
                {
                    return true;
                }
                node = node.next;
            }
            return false;
        }
        public bool remove(Key key)
        {
            //Node node = Head;
            if (Head == null)
                return false;
            if (key.CompareTo(Head.key) == 0)
            {
                Node delnode = Head;
                this.Head = Head.next;
                delnode.next = null;
                count--;
                return true;
            }
            Node node = Head;
            while (node != null && key.CompareTo(node.key) != 0)
            {
                node = node.next;
            }
            if (node != null)
            {
                Node delNode = node.next;
                node.next = delNode.next;
                delNode.next = null;
                count--;
                return true;
            }
            return false;
        }
    }
}
