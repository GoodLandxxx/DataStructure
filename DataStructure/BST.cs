using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BST<Key, Value> where Key : IComparable where Value : IComparable
    {
        //ConparaTo >0 big, <0 smart , =0 equal
        #region Private Class Of The Binary Seach Tree  二叉搜索树的私有类
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
        private class KeyLengthEqualValueLength : Exception
        {
            public override string Message
            {
                get
                {
                    return "The Length of key  not Equal The Length of Value";
                }
            }
        }
        #endregion
        private string Interval;
        private Node root;  // 根节点
        private int count;  // 节点个数
        //遍历的字符串
        private StringBuilder PreOrderSting;
        private StringBuilder InOrderSting;
        private StringBuilder PostOrderSting;
        //广度优先遍历字符串
        private StringBuilder BFSString;
        private StringBuilder DFSString;
        public BST()
        {
            PreOrderSting = new StringBuilder("先序遍历:");
            InOrderSting = new StringBuilder("中序遍历:");
            PostOrderSting = new StringBuilder("后序遍历:");
            BFSString = new StringBuilder("广度优先遍历:");
            DFSString = new StringBuilder("广度优先遍历:");
            Interval = ">";
            root = null;
            count = 0;
        }
        public BST(string interval) : base()
        {
            this.Interval = interval;
            root = null;
            count = 0;
        }
        //非递归创建二叉树
        public void CreateBinarySearchTree(Key[] keys, Value[] values)
        {
            CreateBST(keys, values);
        }
        //返回二叉树的大小
        public int Size()
        {
            return count;
        }
        //判断二叉树是否为空。
        public Boolean IsEmety()
        {
            return count == 0;
        }
        //在二叉树插入一个节点。可以用来创建二叉树。
        public void Insert(Key key, Value value)
        {
            root = Insert(root, key, value);
        }
        //二叉树中是否存在key
        public Boolean Contain(Key key)
        {
            return Contain(root, key);
        }
        //在二分搜索树中搜索键key所对应的值。如果这个值不存在, 则返回null
        public Value Search(Key key)
        {
            return Search(root, key);
        }
        // 二叉搜索树的前序遍历，返回前序遍历的字符串
        public string PreOrder()
        {
            PreOrderSting.Clear();
            PreOrder(root);
            return PreOrderSting.ToString();

        }
        // 二叉搜索树的中序遍历，返回中序遍历的字符串
        public string InOrder()
        {
            InOrderSting.Clear();
            InOrder(root);
            return InOrderSting.ToString();
        }
        // 二叉搜索树的后序遍历，返回后序遍历的字符串
        public string PostOrder()
        {
            PostOrderSting.Clear();
            PostOrder(root);
            return PostOrderSting.ToString();
        }
        public void Remove(Key key)
        {
            Remove(root, key);
        }

        public Key Ceil(Key key) 
        {
            if (count == 0 || key.CompareTo(MaxNode(root).key) > 0) 
                return default(Key);
            return Ceil(root, key).key;
        }
        #region    The private function of the binary tree 二叉树私有函数  
        /// <summary>
        /// 二叉搜索树使用非递归方式创建。但是效率会比较慢
        /// </summary>
        /// <param name="keys">键</param>
        /// <param name="values">值</param>
        private void CreateBST(Key[] keys, Value[] values)
        {

            if (root == null)
            {
                count++;
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
                        if (temp1 == null)
                        {
                            temp.right = new Node(keys[i], values[i]);
                            temp = temp.right;
                            count++;
                            break;
                        }
                        temp = temp1;
                    }
                    else if (keys[i].CompareTo(temp.key) < 0)
                    {

                        //temp = temp.left;
                        //Node tempTest = temp;
                        if (temp2 == null)
                        {
                            temp.left = new Node(keys[i], values[i]);
                            temp = temp.left; count++; break;
                        }

                        temp = temp2;
                    }

                }
            }
        }
        /// <summary>
        /// 二叉搜索树的插入操作，
        /// </summary>
        /// <param name="node">//默认根节点</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>节点</returns>
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
        /// 二叉搜索树的二分搜索
        /// 时间复杂度为O(logN)
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="key">键</param>
        /// <returns>返回对应的键的值</returns>
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
        private void PreOrder(Node node)
        {
            if (node != null)
            {
                PreOrderSting.Append(Interval + node.key);
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }
        private void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.left);
                InOrderSting.Append(Interval + node.key);
                InOrder(node.right);
            }
        }
        private void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.left);
                PostOrder(node.right);
                PostOrderSting.Append(Interval + node.key);
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="node">根节点//NODE ==root;</param>
        /// <returns></returns>
        private Node MaxNode(Node node)
        {

            if (node.right == null)
                return node;
            return MaxNode(node.right);
        }
        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="node">根节点</param>
        /// <returns></returns>
        private Node MinNode(Node node)
        {

            if (node.left == null)
                return node;
            return MinNode(node.left);
        }
        private Node RemoveMax(Node node)
        {
            if (node.right == null)
            {
                Node LeftNode = node.left;
                node.left = null;
                count--;
                return LeftNode;
            }

            node.right = RemoveMax(node.right);
            return node;
        }
        private Node RemoveMin(Node node)
        {
            if (node.left == null)
            {
                Node RightNode = node.right;
                node.right = null;
                count--;
                return RightNode;
            }

            node.left = RemoveMin(node.left);
            return node;
        }
        private Node Remove(Node node, Key key)
        {
            if (node == null)
                return null;
            int flag = key.CompareTo(node.key);
            if (flag > 0)
            {
                node.right = Remove(node.right, key);
                return node;
            }
            else if (flag < 0)
            {
                node.left = Remove(node.left, key);
                return node;
            }
            else
            {
                if (node.left == null)
                {
                    Node Rtemp = node.right;
                    node.right = null;
                    count--;
                    return Rtemp;
                }
                if (node.right == null)
                {
                    Node Ltemp = node.left;
                    node.left = null;
                    count--;
                    return Ltemp;
                }
                Node TTemp = MaxNode(node.left);
                count++;
                TTemp.left = RemoveMax(node.left);
                TTemp.right = node.right;
                node.left = node.right = null;
                count--;
                return TTemp;
            }
        }

        private void BFS()
        {
            Queue<Node> QueueOfNode = new Queue<Node> { };
            QueueOfNode.Enqueue(root);
            while (QueueOfNode.Count != 0)
            {
                Node TempNode = QueueOfNode.Dequeue();
                BFSString.Append(TempNode.key);
                if (TempNode.left != null)
                {
                    QueueOfNode.Enqueue(TempNode.left);
                }
                if (TempNode.right != null)
                {
                    QueueOfNode.Enqueue(TempNode.right);
                }

            }
        }
        private void DFS()
        {
            Stack<Node> StackOfNode = new Stack<Node>() { };
            StackOfNode.Push(root);
            while(StackOfNode.Count!=0)
            {
                Node TempNode = StackOfNode.Pop();
                DFSString.Append(TempNode.key);
                if(TempNode.right!=null)
                {
                    StackOfNode.Push(TempNode.right);
                }
                if (TempNode.left != null)
                {
                    StackOfNode.Push(TempNode.left);
                }
            }
        }
        private Node Ceil(Node node ,Key key)
        {
            int flag = key.CompareTo(node.key);
            if (flag == 0)
                return node;
             if( flag > 0)
            {
                return Ceil(node.right, key);
            }
            Node tempNode = Ceil(node.left, key);
            if (tempNode != null)
                return tempNode;  
            
            return null;
        }

        private Key floor(Node node ,Key key)
        {
            
            while (node != null)
            {
                int flag = key.CompareTo(node.key);
                if (flag < 0)
                {
                    node = node.left;
                }
                else
                {
                    return node.key;
                }
            }
            return default(Key);
        }
        #endregion
    }

}
