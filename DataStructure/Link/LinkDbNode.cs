using DataStructure.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Link
{
    public class LinkDbNode<T>
    {
        private int count { get; set; }
        private DbNode<T> head { get; set; }

        public T this[int index]
        {
            get
            {
                return this.GetNodeByIndex(index).Item;
            }
            set
            {
                this.GetNodeByIndex(index).Item = value;
            }
        }
        public void AddAfter(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
                // 调整插入节点与前驱节点指针关系
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            this.count++;
        }

        private DbNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            DbNode<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }


        /// <summary>
        ///  
        /// </summary>
        /// <param name="value"></param>
        public void AddBefore(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
                DbNode<T> prevNode = lastNode.Prev;
                // 调整倒数第2个节点与插入节点的关系
                prevNode.Next = newNode;
                newNode.Prev = prevNode;
                // 调整倒数第1个节点与插入节点的关系
                lastNode.Prev = newNode;
                newNode.Next = lastNode;
            }
            this.count++;
        }


    }
}
