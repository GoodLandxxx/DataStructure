using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Sort
{
    public class ShellSort
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static TimeSpan ShellSortFunc(int[] arr,int l=2)
        {
            var startTime = DateTime.Now;
            int len = arr.Length;
            int gap = len / l;
            while (gap > 0)
            {
                for(int i =0; i< gap; i++)
                {
                    HalfInsertionSort(arr, i, gap);
                }
                gap = gap / l;
            }
            return Util.GetTimeSpan(startTime); 
        }
        public static void HalfInsertionSort(int[] arr, int start, int gap)
        {
            int n = start + gap;
            
            for (int i =n; i < arr.Length; i += gap)
            {
                int flag = i;
                int currentValue = arr[i];
                while(flag >start && arr[flag- gap] > currentValue)
                {
                    arr[flag] = arr[flag - gap];
                    flag = flag - gap;
                }
                arr[flag] = currentValue;
            }
        }




        
    }
}
