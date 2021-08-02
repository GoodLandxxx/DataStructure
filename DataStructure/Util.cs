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

    }
    public enum OrderBy
    {
        Asc = 0,
        Desc = 1
    }

}
