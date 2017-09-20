using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using System.IO;

namespace TreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            inis[] ints = new inis[100000000];
            inis tage = new inis(23);
            int j = 0, type = 0;
            sw.Stop();
      
            TimeSpan ts2 = sw.Elapsed; sw.Reset();Console.WriteLine("init time is {0}", ts2.TotalMilliseconds);
            StringBuilder sb = new StringBuilder();
            sw.Start(); 
            for (int i = 0; i < 100000000; i++)
            {
                //if (i == 10000020)
                //{
                //    continue;
                //}
                ints[i] = new inis(j);
                //sb.Append(j +"-");
                if (type == 0)
                { j+=6;
                    type = 1;continue;
                }
                if(type==1)
                {
                    j += 13;
                    type = 2;
                    continue;
                    
                }if(type ==2)
                {
                    j +=15;
                    type = 0;
                    continue;
                }
         
                

              

                
            }
            sw.Stop();
             TimeSpan ts3 = sw.Elapsed; sw.Restart(); Console.WriteLine("初始化数组for time is {0}", ts3.TotalMilliseconds);
            //IOOperation.Write(@"C:\Users\jordan\Desktop\testNum.txt", sb.ToString());
            sw.Start();
            int jordan1 = BinarySearch.find(ints, 113333560);
            sw.Stop(); TimeSpan ts4 = sw.Elapsed; sw.Restart(); Console.WriteLine(" 递归二叉树findrE time is {0}", ts4.TotalMilliseconds);sw.Start();
            
            int jordan = BinarySearch.Find(ints, 113333560);
            sw.Stop(); TimeSpan ts5 = sw.Elapsed; sw.Restart(); Console.WriteLine("非递归Fide time is {0}", ts5.TotalMilliseconds);
            sw.Start();
            for (int l = 0; l < ints.Length; l++)
            {
                if (ints[l].num == 113333560)
                    break;
            }
            sw.Stop(); TimeSpan ts6 = sw.Elapsed; sw.Restart(); Console.WriteLine("循环 forSeach time is {0}", ts6.TotalMilliseconds);
            List<inis> isList = new List<inis>(ints);
            sw.Start();
            foreach (inis s in isList)
            {
                if (s.num == 113333560)
                    break;
            }
            sw.Stop(); TimeSpan ts9 = sw.Elapsed; sw.Restart(); Console.WriteLine("列表循环ListForeach time is {0}", ts9.TotalMilliseconds); sw.Start();
            inis sf= new inis(113333560);
            isList.Equals(sf);
            sw.Stop(); TimeSpan ts10 = sw.Elapsed; sw.Restart(); Console.WriteLine(" 列表方法 ListEquals time is {0}", ts10.TotalMilliseconds); 
            //Console.WriteLine(jordan.ToString());
            Console.ReadKey();
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
            public static void Write(string path,String StreamString)
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
}
