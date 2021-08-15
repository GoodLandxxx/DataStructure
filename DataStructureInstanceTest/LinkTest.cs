using DataStructure.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureInstanceTest
{
    public class LinkTest
    {
        public static void LinkedListTest()
        {

            LinkNode<int> linkedList = new LinkNode<int>();
            // 顺序插入N个节点
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                linkedList.Add(i);
            }
            printf(linkedList, "linkedList is :");
            linkedList.Insert(0, 10);
            printf(linkedList, "insert 10 in index of 0:");
            linkedList.Insert(5, 50);
            printf(linkedList, "insert 50 in index of 5:");
            linkedList.RemoveAt(4);
            printf(linkedList, "remover Link in index of 5:");
            linkedList.RemoveAt(3);
            printf(linkedList, "remover Link in index of 3:");
        }

        public static void printf(LinkNode<int> linkedList, string str)
        {
            //打印
            Console.WriteLine(str);
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write($"{linkedList[i]},");
            }
            Console.WriteLine("\n--------------------------");
        }
    }
}
