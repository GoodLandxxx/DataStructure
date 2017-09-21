using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BST<Key, Value> where Key : IComparable where Value : IComparable
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node right, left;
            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                left = right = null;
            }

        }
        public class KeyLengthEqualValueLength : Exception
        {
            public override string Message
            {
                get
                {
                    return "The Length of key  not Equal The Length of Value";
                }
            }
        }
        private Node root;  // 根节点
        private int count;  // 树种的节点个数
        StringBuilder PreOrderSting = new StringBuilder();
        StringBuilder InOrderSting = new StringBuilder();
        StringBuilder PostOrderSting = new StringBuilder();
        public BST()
        {
            root = null;
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
        public void CreateTree(Key[] keys, Value[] values)
        {

            if (root == null)
            {
                root = new Node(keys[0], values[0]);
            }
            if (keys.Length != values.Length)
            { throw new KeyLengthEqualValueLength(); }

            for (int i = 1; i < keys.Length; i++)
            {
                Node temp = root;
                while (true)
                {
                    Node temp1 = temp.right;
                    Node temp2 = temp.left;
                    if (keys[i].CompareTo(temp.key) == 0)
                        break;
                        if (keys[i].CompareTo(temp.key) > 0)
                    {
                        
                        //
                        //Node tempTest = temp;
                        if (temp1 == null)
                        {
                            temp.right = new Node(keys[i], values[i]);
                            
                            break;
                        }
                        
                        temp = temp.right;
                    }
                    if (keys[i].CompareTo(temp.key) <0)
                    {
                        
                        //temp = temp.left;
                        //Node tempTest = temp;
                        if (temp2 == null)
                        {
                            temp.left = new Node(keys[i], values[i]);
                             break;
                        }
                        temp = temp.left;
                    }

                }
            }
        }




        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Insert(Key key, Value value)
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
        private Boolean Contain(Node node, Key key)
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
        private Value Search(Node node, Key key)
        {
            if (node == null)
                return default(Value);
            int flag = node.key.CompareTo(key);
            if (flag == 0)
            { return node.value; }
            if (flag > 0)
            {
                return Search(node.left, key);
            }
            else
            {
                return Search(node.right, key);
            }
        }
        /// <summary>
        ///  
        /// 二叉搜索树的前序遍历
        /// 
        /// </summary>
        /// <returns>前序遍历的字符串</returns>
        public string PreOrder()
        {
            PreOrderSting.Clear();
            PreOrder(root);
            return PreOrderSting.ToString();

        }

        private void PreOrder(Node node)
        {
            if (node != null)
            {
                PreOrderSting.Append(node.key + "-");
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }

        /// <summary>
        ///  
        /// 二叉搜索树的中序遍历
        /// 
        /// </summary>
        /// <returns>中序遍历的字符串</returns>
        public string InOrder()
        {
            InOrderSting.Clear();
            InOrder(root);
            return InOrderSting.ToString();
        }
        private void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.left);
                InOrderSting.Append(node.key + "-");
                InOrder(node.right);
            }
        }


        /// <summary>
        ///  
        /// 二叉搜索树的后序遍历
        /// 
        /// </summary>
        /// <returns>后序遍历的字符串</returns>
        public string PostOrder()
        {
            PostOrderSting.Clear();
            PostOrder(root);
            return PostOrderSting.ToString();

        }

        private void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.left);

                PostOrder(node.right);
                PostOrderSting.Append(node.key + "-");
            }
        }
    }

}
