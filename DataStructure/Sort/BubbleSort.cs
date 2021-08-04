using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Sort
{
    public class BubbleSort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static TimeSpan BubbleSortFunc(int[] arr)
        {
            var startTime = DateTime.Now;
            int n = arr.Length;
            for (int i = n - 1; i > -1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return Util.GetTimeSpan(startTime);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static TimeSpan BubbleSortFuncOpt(int[] arr )
        {
            var startTime = DateTime.Now;
            int n = arr.Length;
            bool isExchange = false;
            for (int i = n - 1; i > -1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isExchange = true;
                    }
                    
                }
                if (!isExchange)
                    break;
            }
            return Util.GetTimeSpan(startTime);
        }

    }
}
