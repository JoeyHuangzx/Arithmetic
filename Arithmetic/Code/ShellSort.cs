/**
 * 
 * Author:JoeyHuang
 * Time: 2020/10/28 16:10:08
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    /// <summary>
    /// 希尔排序
    /// 希尔排序是把记录按下标的一定增量分组，对每组使用直接插入排序算法排序；
    /// 随着增量逐渐减少，每组包含的关键词越来越多，当增量减至1时，整个文件恰被分成一组，算法便终止。
    /// </summary>
    public class ShellSort
    {
        public ShellSort()
        {
            Sort(new int[]{7,2,5,9,8,10,1,15,12,3,8,15,63,55,74,36,85,74,55,56,47,65,21,13});
            Console.WriteLine();
        }

        public void Sort(int[] arr)
        {
            int len = arr.Length;
            int gap = 1;
            int num = 0;
            while(gap<len)
            {
                gap = gap * 3 + 1;
            }
            while(gap>0)
            {
                for (int i = gap; i < len; i++)
                {
                    int temp = arr[i];
                    int j = i - gap;
                    while(j>=0 && arr[j]>temp)
                    {
                        arr[j + gap] = arr[j];
                        j -= gap;
                        Console.WriteLine("change:" + (num++));
                    }
                    arr[j + gap] = temp;
                    
                }
                gap = gap / 3;
                //Console.WriteLine(gap);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "  ");
            }
        }
    }
}
