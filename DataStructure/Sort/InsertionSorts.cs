using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Sort
{
    public class InsertionSort
    {

        public static int InsertionSortFuncOpt(int[] arr)
        {

            var startTime = DateTime.Now;
            int o = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                int position ;
                int val = arr[i];
                //while (position > 0 &&  arr[position - 1] >val)
                //{
                //    arr[position] = arr[position - 1];
                //    position--;
                //    o++;
                //}
                for(position =i; position > 0 && arr[position-1] >val; position--)
                {
                    arr[position] = arr[position - 1];
                    o++;
                }
                arr[position] = val;
            }
            

            return o;
        }

        public static int InsertionSortFunc(int[] arr)
        {
            var startTime = DateTime.Now;
            int o = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && arr[j] < arr[j - 1]; j--)
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    o++;
                }
            }
            return o;
            //return Util.GetTimeSpan(startTime);
        }
    }
}
