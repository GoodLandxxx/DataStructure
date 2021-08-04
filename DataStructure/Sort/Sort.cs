using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Sort
{
    public class Sort
    {
        public static int BinarySearch(int[] arr ,int size,int key )
        {

            int left =0, right = 0;
            size = -1;
            while (left <= right)
            {
                int mid = left + right >> 1;
                if (key == arr[mid])
                    return mid + 1;
                else if (key < arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
