using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BTree
    {
        public int value { get; set; }
        public BTree left { get; set; }
        public BTree right { get; set; }
        public BTree parent { get; set; }
        static int count = 0;
        public BTree(){}
        public BTree(int v) {
            this.value = v;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
        public static BTree createMinimalBT(BTree root, int[] array, int start, int end)
        {
            try
            {
              
            
            if(start >= 0 && array.Length-1 >= end && end >= start)
            {
                BTree.count++;
                int m = (end + start) / 2;
                root = new BTree(array[m]);
                
                root.left = createMinimalBT(root.left, array, start, m - 1);
                root.right = createMinimalBT(root.right, array, m +1, end);

                return root;

            }else
            {
                return root;
            }
            }
            catch
            {
                return root;
            }


        }
        //先序遍历
        public string PreorderTraversal()
        {
            StringBuilder sb = new StringBuilder();
            
            BTree Pop;// 用来保存出栈节点
            BTree pCur = this;//定义用来指向当前访问的节点的指针  
            Stack<BTree> TempStack = new Stack<BTree> { };//创建一个空栈  
            
            //直到当前节点pCur为NULL且栈空时，循环结束  
            while (pCur !=null && TempStack.Count !=0)
            {
                //从根节点开始，输出当前节点，并将其入栈，  
                //同时置其左孩子为当前节点，直至其没有左孩子，及当前节点为NULL  
                sb.Append(pCur.ToString() +'-');
                TempStack.Push(pCur);
                pCur = pCur.left;                
                //如果当前节点pCur为NULL且栈不空，则将栈顶节点出栈，  
                //同时置其右孩子为当前节点,循环判断，直至pCur不为空  
                while (pCur!=null && TempStack.Count != 0)
                {
                    Pop = TempStack.Pop();
                    pCur = Pop;
                    pCur = pCur.right;
                }
            }


            return sb.ToString(); ;
        }
        //递归方法实现。
        public void Pre_Traversal(BTree pTree)
        {
            if (pTree !=null)
            {   
                if (pTree.left!=null)
                    Pre_Traversal(pTree.left);
                if (pTree.right != null)
                    Pre_Traversal(pTree.right);
            }
        }
        public override string ToString()
        {
            return value.ToString() +'-';
        }
    }
}
