using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DataStructure;
using DataStructure.Sort;
namespace DataStructureInstanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkTest.LinkedListTest();



            const int count = 50000;
            int max = 100000;
            int arrCout = 10;
            int[] A = new int[count];
            int[] B = new int[count];
            List<int[]> listA = new List<int[]>() { };
            List<int[]> listB = new List<int[]>() { };
            for (int i = 0; i < arrCout; i++)
            {

                listA.Add(new int[count]);
                listB.Add(new int[count]);
            }
            A = Util.GenerateRandomArray(count, 0, max);
            B = Util.GenerateNearlyOrderedArray(count, arrCout);
            for (int i = 0; i < listA.Count; i++)
            {

                A.CopyTo(listA[i], 0);
                B.CopyTo(listB[i], 0);

            }

            var array = new int[10] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, };
            Merge.MergeSort(array);
            var array2 = new int[10] {  9, 8, 7, 6, 5, 9,4, 3, 2, 1, };
            Quick.QuickSort(listA[0]);
            var isSort = Util.IsSortForInt(listA[0]);
            var v0 = Bubble.BubbleSortFunc(listA[0]);
             isSort = Util.IsSortForInt(listA[0]);
            Console.WriteLine($"BubbleSortFunc --{v0} -/mulriple = {v0.TotalSeconds*1000},---{isSort} ");

            v0 = Bubble.BubbleSortFuncOpt(listA[1]);
            isSort = Util.IsSortForInt(listA[1]);
            Console.WriteLine($"BubbleSortFuncOpt ----{v0} -/mulriple = {v0.TotalSeconds * 1000},---{isSort} ");

            v0 = InsertionSort.InsertionSortFunc(listA[2]);
            isSort = Util.IsSortForInt(listA[2]);
            Console.WriteLine($"InsertionSortFunc ----{v0}-/mulriple = {v0.TotalSeconds * 1000}---{isSort} ");

            v0 = InsertionSort.InsertionSortFunc(listA[3]);
            isSort = Util.IsSortForInt(listA[3]);
            Console.WriteLine($"InsertionSortFunc ----{v0}-/mulriple = {v0.TotalSeconds * 1000}---{isSort} ");

            v0 = InsertionSort.InsertionSortFuncOpt(listA[4]);
            isSort = Util.IsSortForInt(listA[4]);
            Console.WriteLine($"InsertionSortFuncOpt ----{v0} -/mulriple = {v0.TotalSeconds * 1000} ---{isSort} ");

          
            Console.WriteLine($"ShellSortFunc ----{v0} -/mulriple = {v0.TotalSeconds * 1000} ---{isSort} ");
            v0 = ShellSort.ShellSortFunc(listA[6], 2);
            isSort = Util.IsSortForInt(listA[6]);
            Console.WriteLine($"ShellSortFunc ----{v0} -/mulriple = {v0.TotalSeconds * 1000} ---{isSort} ");
            v0 = ShellSort.ShellSortFunc(listA[7], 4);
            isSort = Util.IsSortForInt(listA[7]);
            Console.WriteLine($"ShellSortFunc ----{v0} -/mulriple = {v0.TotalSeconds * 1000} ---{isSort} ");
            v0 = ShellSort.ShellSortFunc(listA[8], 5);
            isSort = Util.IsSortForInt(listA[8]);
            Console.WriteLine($"ShellSortFunc ----{v0} -/mulriple = {v0.TotalSeconds * 1000} ---{isSort} ");

            v0 = ShellSort.ShellSortFunc(listA[5]);
            isSort = Util.IsSortForInt(listA[5]);
            Console.WriteLine($"ShellSortFunc ----{v0} -/mulriple = {v0.TotalSeconds * 1000} ---{isSort} ");

            


            int N = 20;
            //

            // 创建一个数组，包含[0...N)的所有元素
            int[] arr2 = new int[N];
            int[] arr = new int[N];
            Stopwatch sw = new Stopwatch();
            string[] Srr = new string[N];
            for (int i = 0; i < N; i++)
            {
                arr2[i] = i;
                Srr[i] = i.ToString();
            }
            // 打乱数组顺序
            Random s = new Random();
            for (int i = 0; i < N; i++)
            {
                int j = s.Next(0, N);
                arr[i] = arr2[j];
                Srr[i] = arr2[j].ToString();


            }
            // 实现的二分搜索树不是平衡二叉树，
            // 如果按照顺序插入一组数据，二分搜索树会退化成为一个链表
            // 平衡二叉树的实现---红黑树。


            // 我们测试用的的二分搜索树的键类型为Integer，值类型为String
            // 键值的对应关系为每个整型对应代表这个整型的字符串
            BST<int, String> bst = new BST<int, String>();
            BST<int, String> bst2 = new BST<int, String>();
            sw.Start();
            for (int i = 0; i < N; i++)
            {
                bst.Insert(arr[i], arr[i].ToString());
            }
            sw.Stop(); TimeSpan ts10 = sw.Elapsed; sw.Restart(); Console.WriteLine(" one time is {0}", ts10.TotalMilliseconds);

            sw.Start();
            bst2.CreateBinarySearchTree(arr, Srr);
            sw.Stop(); TimeSpan ts2 = sw.Elapsed; sw.Restart(); Console.WriteLine(" two time is {0}", ts2.TotalMilliseconds);


            Console.WriteLine(bst.PreOrder());
            Console.WriteLine(bst.InOrder());
            Console.WriteLine(bst.PostOrder());

            Console.WriteLine("BFS" + bst.BFS());
            Console.WriteLine("DFS" + bst.DFS());
            //int sf = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(bst.Ceil(sf));
            Console.WriteLine(bst.PreOrder());
            Console.WriteLine(bst.InOrder());
            Console.WriteLine(bst.PostOrder());

            // 对[0...2*N)的所有整型测试在二分搜索树中查找
            // 若i在[0...N)之间，则能查找到整型所对应的字符串
            // 若i在[N...2*N)之间，则结果为null
            /* 二叉搜索测试
            for (int i = 0; i <  N; i++)
            {
                String res = bst.Search(i);
                if (i < N) { 
                    if (res == i.ToString())
                        Console.WriteLine(i+"----");
                    if(res ==null)
                    {
                        Console.WriteLine(i+"+++");
                    }
                }
            }*/

            /*计算运行时间
            //sw.Start()
            //sw.Stop(); TimeSpan ts10 = sw.Elapsed; sw.Restart(); Console.WriteLine(" 列表方法 ListEquals time is {0}", ts10.TotalMilliseconds);
            ////Console.WriteLine(jordan.ToString());
            */
            Console.ReadKey();
        }
    }
    class inis : IComparable
    {
        public int num { get; set; }
        public inis(int num)
        {
            this.num = num;
        }

        public int CompareTo(object obj)
        {
            return num.CompareTo(obj);
            throw new NotImplementedException();
        }
    }
    class IOOperation
    {
        IOOperation() { }
        public void WriteStream(string path, String StreamString)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes("Hello World!");
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
        public static void Write(string path, String StreamString)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(StreamString);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

    }
}
