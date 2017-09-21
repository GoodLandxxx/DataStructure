using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BST<Key , Value> where Key :IComparable where Value:IComparable
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node right, left;
            public Node(Key key ,Value value)
            {
                this.key = key;
                this.value = value;
                left = right = null;
            }

        }
        private Node root;  // 根节点
        private int count;  // 树种的节点个数

        public BST()
        {
            root = null;
            count = 0;
        }
        public int  Size()
        {
            return count;
        }
        public Boolean IsEmety()
        {
            return count == 0;
        }
        public void Insert(Key key ,Value value)
        {
            root = Insert(root, key, value);
        }
        private Node Insert(Node node, Key key, Value value)
        {
            if (node == null)
            {
                count++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) == 0)
                node.value = value;
            else if (key.CompareTo(node.key) < 0)
                node.left = Insert(node.left, key, value);
            else    // key > node->key
                node.right = Insert(node.right, key, value);

            return node;
        }
        /// <summary>
        /// 查看二分搜索树中是否存在键key
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>bool</returns>
        public Boolean Contain(Key key)
        {
            return Contain(root, key);
        }
        /// <summary>
        /// 查看二分搜索树中是否存在键key的私有方法
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="key">键</param>
        /// <returns>布尔值</returns>
        private Boolean Contain(Node node,Key key )
        {
            if (node == null)
                return false;
            int flag = node.key.CompareTo(key);
            if (flag == 0)
            { return true; }
            if (flag > 0)
            {
                return Contain(node.left, key);
            }
            else
            {
                return Contain(node.right, key);
            }
        }
        /// <summary>
        ///在二分搜索树中搜索键key所对应的值。如果这个值不存在, 则返回null
        /// 
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public Value Search(Key key)
        {
            return Search(root, key);
        }
        private Value Search(Node node,Key key)
        {
            if (node == null)
                return default(Value);
            int flag=  node.key.CompareTo(key);
            if (flag == 0)
            { return node.value; }
            if(flag > 0)
            {
                return Search(node.left, key);
            }
            else
            {
                return Search(node.right, key);
            }
        }
    }
    //public class Key :IComparable<Key>
    //{
    //    public int CompareTo(Key obj)
    //    {
    //        return CompareTo(obj);
    //        throw new NotImplementedException();
    //    }
    //}
    //public class Value : IComparable
    //{
    //    public int CompareTo(object obj)
    //    {
    //        return CompareTo(obj);
    //        throw new NotImplementedException();
    //    }
    //}
}
