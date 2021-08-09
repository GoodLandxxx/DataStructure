using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Sort
{

    /// <summary>
    /// 
    /// </summary>
    public class Merge
    {
        //是一种稳定的排序
        //利用二叉树的特性
        public static void MergeSort(int[] arr)
        {
            int length = arr.Length;
            if (length < 2)
            {
                return;
            }
            MergeSort(arr, 0, length - 1);



        }

       
        public static void MergeSort(int[] arr, int left, int right)
        {
            //数组一分为2，不断拆分，直到数组长度为1，直接返回
            if (left >= right)
            {
                return;
            }
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            //按mid将数组分组，然后将两组数据归并为1组
            int[] arr2 = new int[right - left + 1];
            int index = 0;
            int i = left;
            int j = mid + 1;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    arr2[index] = arr[i];
                    i++;
                    index++;
                }
                else
                {
                    arr2[index] = arr[j];
                    j++;
                    index++;

                }
            }

            while (i <= mid)
            {
                arr2[index] = arr[i];
                i++;
                index++;
            }

            while (j <= right)
            {
                arr2[index] = arr[j];
                j++;
                index++;
            }


            for (int n = 0; n < index; n++)
            {
                arr[left + n] = arr2[n];
            }
        }

        public static int[] MergeSort(int[] arr1, int[] arr2)
        {
            int length1 = arr1.Length;
            int length2 = arr2.Length;

            int[] arr = new int[length1 + length2];
            int index = 0;
            int i = 0;
            int j = 0;

            //从前往后比较两个数组的值，谁小，谁放在新数组前面
            //直到一个数组比较完毕
            while (i < length1 && j < length2)
            {
                if (arr1[i] <= arr2[j])
                {
                    arr[index] = arr1[i];
                    i++;
                    index++;
                }
                else
                {
                    arr[index] = arr2[j];
                    j++;
                    index++;

                }

            }
            //将还没有比较的数依次放在新数组后面
            while (i < length1)
            {
                arr[index] = arr1[i];
                i++;
                index++;
            }

            while (j < length2)
            {
                arr[index] = arr2[j];
                j++;
                index++;
            }
            return arr;
        }

        public static void MergeSort2(int[] arr)
        {
            int length = arr.Length;
            if (length < 2)
            {
                return;
            }

            //按gap对数组进行分组，并在组内进行归并
            int gap = 1;
            while (gap <= length)
            {
                int i = 0;
                int left = i * (gap * 2);
                while (left < length)
                {
                    int right = (i + 1) * (gap * 2) - 1;
                    //数组数组越界的情况
                    if (right >= length)
                    {
                        right = length - 1;
                    }
                    MergeSort2(arr, left, right);
                    i++;
                    left = i * (gap * 2);
                }
                gap *= 2;
            }

        }

        //将数组分组为left-mid,mid+1-right两组进行归并
        public static void MergeSort2(int[] arr, int left, int right)
        {
            if (right <= left)
            {
                return;
            }
            int mid = left + (right - left) / 2;
            int[] arr2 = new int[right - left + 1];
            int index = 0;
            int i = left;
            int j = mid + 1;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    arr2[index] = arr[i];
                    i++;
                    index++;
                }
                else
                {
                    arr2[index] = arr[j];
                    j++;
                    index++;

                }

            }

            while (i <= mid)
            {
                arr2[index] = arr[i];
                i++;
                index++;
            }

            while (j <= right)
            {
                arr2[index] = arr[j];
                j++;
                index++;
            }


            for (int n = 0; n < index; n++)
            {
                arr[left + n] = arr2[n];
            }
        }
    }
}
