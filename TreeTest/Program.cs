using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using System.IO;
using System.Diagnostics;
namespace TreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 100000;

            // 创建一个数组，包含[0...N)的所有元素
            int[] arr2 = new int[N];
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
                arr2[i] = i;

            // 打乱数组顺序
            Random s = new Random();
            for (int i = 0; i < N; i++)
            {
                int j = s.Next(0,N);
                arr[i] = arr2[j];
                
            }
            // 由于我们实现的二分搜索树不是平衡二叉树，
            // 所以如果按照顺序插入一组数据，我们的二分搜索树会退化成为一个链表
            // 平衡二叉树的实现，我们在这个课程中没有涉及，
            // 有兴趣的同学可以查看资料自学诸如红黑树的实现
            // 以后有机会，我会在别的课程里向大家介绍平衡二叉树的实现的：）


            // 我们测试用的的二分搜索树的键类型为Integer，值类型为String
            // 键值的对应关系为每个整型对应代表这个整型的字符串
            BST<int, String> bst = new BST<int, String>();
            for (int i = 0; i < N; i++)
                bst.Insert(arr[i], arr[i].ToString());

            // 对[0...2*N)的所有整型测试在二分搜索树中查找
            // 若i在[0...N)之间，则能查找到整型所对应的字符串
            // 若i在[N...2*N)之间，则结果为null
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
            }
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            //inis[] ints = new inis[5];
            //ints[0] = new inis(23);
            //ints[1] = new inis(27);
            //ints[2] = new inis(29);
            //ints[3] = new inis(33);
            //ints[4] = new inis(53);
            //int j = 0, type = 0;
            //sw.Stop();

            //TimeSpan ts2 = sw.Elapsed; sw.Reset(); Console.WriteLine("init time is {0}", ts2.TotalMilliseconds);
            //StringBuilder sb = new StringBuilder();
            //sw.Start();
            //BinarySearch.FindRe(ints, 53);
            //for (int i = 0; i < 1000000; i++)
            //{
            //    //if (i == 200220)
            //    //{
            //    //continue;
            //    //}
            //    ints[i] = new inis(j);
            //    //sb.Append(j +"-");
            //    if (type == 0)
            //    {
            //        j += 6;
            //        type = 1; continue;
            //    }
            //    if (type == 1)
            //    {
            //        j += 13;
            //        type = 2;
            //        continue;

            //    }
            //    if (type == 2)
            //    {
            //        j += 15;
            //        type = 0;
            //        continue;
            //    }






            //}
            //sw.Stop();
            //TimeSpan ts3 = sw.Elapsed; sw.Restart(); Console.WriteLine("初始化数组for time is {0}", ts3.TotalMilliseconds);
            ////IOOperation.Write(@"C:\Users\jordan\Desktop\testNum.txt", sb.ToString());
            //sw.Start();
            //int jordan1 = BinarySearch.FindRe(ints, 2269160);
            //sw.Stop(); TimeSpan ts4 = sw.Elapsed; sw.Restart(); Console.WriteLine(jordan1.ToString() + " 递归二叉树findrE time is {0}", ts4.TotalMilliseconds);
            //sw.Start();
            //int jordan = BinarySearch.Find(ints, 2269160);
            //sw.Stop(); TimeSpan ts5 = sw.Elapsed; sw.Restart(); Console.WriteLine(jordan.ToString() + "非递归Fide time is {0}", ts5.TotalMilliseconds);
            //sw.Start();
            //for (int l = 0; l < ints.Length; l++)
            //{
            //    if (ints[l].num == 2269160)
            //    {
            //        Console.Write(l);
            //        break;
            //    }
            //}
            //sw.Stop(); TimeSpan ts6 = sw.Elapsed; sw.Restart(); Console.WriteLine("循环 forSeach time is {0}", ts6.TotalMilliseconds);
            //List<inis> isList = new List<inis>(ints);
            //sw.Start();
            //foreach (inis s in isList)
            //{
            //    if (s.num == 2269160)
            //        break;
            //}
            //sw.Stop(); TimeSpan ts9 = sw.Elapsed; sw.Restart(); Console.WriteLine("列表循环ListForeach time is {0}", ts9.TotalMilliseconds); sw.Start();
            //inis sf = new inis(2269160);
            //isList.Contains(sf);
            //sw.Stop(); TimeSpan ts10 = sw.Elapsed; sw.Restart(); Console.WriteLine(" 列表方法 ListEquals time is {0}", ts10.TotalMilliseconds);
            ////Console.WriteLine(jordan.ToString());
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
