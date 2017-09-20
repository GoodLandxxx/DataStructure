using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BinarySearch
    {
        private static int FindRe(IComparable[] arr, int start, int end, IComparable target)
        {
            int mid = start + (end - start) / 2;
            int flag = arr[mid].CompareTo(target);
            if (flag == 0)
                return mid;
            if (flag > 0)
                return FindRe(arr, start, mid - 1, target);
            else
                return FindRe(arr, mid+1, end, target);
        }


        public static int find(IComparable[] arr, IComparable target)
        {

            return FindRe(arr, 0, arr.Length - 1, target);
        }
        public static int Find(IComparable[] arr, IComparable target)
        {

            return Find(arr, 0, arr.Length - 1, target);
        }
        private static int Find(IComparable[] arr, int start, int end, IComparable target)
        {
            int mid = start + (end - start) / 2;
            int flag = arr[mid].CompareTo(target);
            if (flag == 0)
            {
                return mid;
            }

            while (true)
            {
                if (flag > 0)
                {
                    end = mid;
                    mid = (start + end - 1) / 2;
                    flag = arr[mid].CompareTo(target);
                    if (flag == 0)
                        return mid;
                    if (flag < 0)
                        start = 0;
                    
                }
                else
                {
                    start = mid;
                    mid = (mid + 1 + end) / 2;
                    flag = arr[mid].CompareTo(target);
                    if (flag == 0)
                        return mid;
                   
                }
            }
            
        }
    }
}
