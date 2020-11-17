/**
 * 
 * Author:JoeyHuang
 * Time: 2020/11/2 16:58:41
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public class HeapSort
    {
        public HeapSort()
        {

        }

        public void Sort(int[] arr)
        {
            int length = arr.Length;
            CreateHeap(arr, length);
            for (int i = length-1; i >0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                length--;
                SortHeap(arr, 0, length);
            }
        }

        public void CreateHeap(int[] arr,int length)
        {
            for (int i = length/2; i>=0; i--)
            {
                SortHeap(arr,i,length); 
            }
        }

        public void SortHeap(int[] arr,int index,int length)
        {
            int lf = index * 2 + 1;
            int lr = index * 2 + 2;
            int current = index;
            if(lf<length && arr[lf]>arr[current])
            {
                current = lf;
            }
            if(lr<length && arr[lr]>arr[current])
            {
                current = lr;
            }
            if(current!=index)
            {
                int temp = arr[current];
                arr[current] = arr[index];
                arr[index] = temp;

                SortHeap(arr, current, length);
            }
        }
    }
}
