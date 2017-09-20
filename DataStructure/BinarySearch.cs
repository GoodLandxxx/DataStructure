using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class BinarySearch
    {
        public static int find (IComparable[] arr  ,int start,int end, IComparable target )
        {
            int mid = start + (end -start ) / 2;
            if (arr[mid].CompareTo(target) == 0)
                return mid;
            if (arr[mid].CompareTo(target) > 0)
                return find(arr, start, mid - 1, target);
            else
                return find(arr, start, mid - 1, target);
        }

        public static int find(IComparable[] arr, IComparable target)
        {

            return find(arr, 0, arr.Length - 1, target);
        }
    }
}
