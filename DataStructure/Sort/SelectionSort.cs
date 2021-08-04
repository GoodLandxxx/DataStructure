using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Sort
{
    public class SelectionSort :Sort
    {

        public static TimeSpan SelectionSortFunc(int[] arr)
        {
            var startTime = DateTime.Now;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;

            }
            return Util.GetTimeSpan(startTime); ;
        }
    }
}
