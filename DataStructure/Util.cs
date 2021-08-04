using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Util
    {
        public static bool IsSortForInt(int[] arr, OrderBy orderBy1 = OrderBy.Asc)
        {
            //判断是否从小到大排序
            bool isAsc = OrderBy.Asc == orderBy1;

            for (int i = 0; i < arr.Length-1; i++)
            {
                if (isAsc)
                {                    
                    if(arr[i] > arr[i+1])
                    {
                        return false;
                    }
                            
                }
                else
                {
                    if (arr[i] < arr[i+1])
                    {
                        return false;
                    }
                }
            }
            return true;

        }


        public static int[] GenerateRandomArray(int count,int min,int max)
        {
            List<int> list = new List<int>() ;
            var Rand = new Random();
            // new Random() 不能写在for 里面
            for (int i =0;i < count; i++)
            {
                list.Add(Rand.Next(min, max));
            }
            return list.ToArray();
        }
        public static int[] GenerateNearlyOrderedArray(int count ,int swapTimes)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
            var Rand = new Random();
            for (int j = 0; j < swapTimes; j++)
            {
                var posX = Rand.Next(0, count - 1);
                var posY = Rand.Next(0, count - 1);
                int temp = list[posX];
                list[posX] = list[posY];
                list[posY] = temp;
            }
            return list.ToArray();
        }


        public static TimeSpan GetTimeSpan(DateTime PerTime)
        {
            DateTime now =  DateTime.Now;

            return  now - PerTime;

        }
    }
    public enum OrderBy
    {
        Asc = 0,
        Desc = 1
    }

}
