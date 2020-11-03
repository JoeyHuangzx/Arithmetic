using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Code
{
    /// <summary>
    /// 分治算法
    /// 实例：
    /// 1、快速排序
    /// 2、两个数组排序
    /// 3、归并排序
    /// 4、汉若塔问题
    /// </summary>
    public class DivideConquerAlgorithm
    {

        public DivideConquerAlgorithm()
        {

        }

        #region 快速排序
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void QuickSort(int[] arr, int start, int end)
        {
            if (end <= start) return;
            int left = start;
            int right = end - 1;
            int key = arr[end];
            while (left < right)
            {
                //如果left的值符合小于key，指针右移一位
                while (arr[left] <= key && left < right)
                    left++;
                //如果right的值符合大于key，指针左移一位
                while (arr[right] >= key && right > left)
                    right--;
                //这个时候只剩下左边大于key的值和右边小于key的值，兑换过来
                Swap(arr, left, right);

                if (arr[left] >= arr[end]) Swap(arr, left, end);
                else left++;
            }

            QuickSort(arr, start, left-1);
            QuickSort(arr, left + 1, end);
        }

        private void Swap(int[] a, int x, int y)
        {
            int temp = a[x];
            a[x] = a[y];
            a[y] = temp;
        }
        #endregion

        #region 两个数组排序
        /// <summary>
        /// 两个有序数组排序
        /// </summary>
        public void TwoArrSort(int[] a,int[] b,int[] results)
        {
            int i=0, j = 0,k=0;
            results = new int[a.Length + b.Length];
            while (i<a.Length && j<b.Length)
            {
                if(a[i]<b[j])
                {
                    results[k++] = a[i++];
                }
                else
                {
                    results[k++] = b[j++];
                }
                
            }

            while(i<a.Length)
            {
                results[k++] = a[i++];
            }
            while(j<b.Length)
            {
                results[k++] = b[j++];
            }

        }
        #endregion

        #region 归并排序

        /// <summary>
        /// 归并排序
        /// 归并（Merge）排序法是将两个（或两个以上）有序表合并成一个新的有序表，即把待排序序列分为若干个子序列，每个子序列是有序的。
        /// 然后再把有序子序列合并为整体有序序列。即先划分为两个部分，最后进行合并
        /// </summary>
        /// <param name="a"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void MergeSort(int[] a, int start, int end)
        {
            if (start < end)
            {
                Console.WriteLine("start:{0},end:{1}", start, end);
                int mid = (start + end) / 2;
                MergeSort(a, start, mid);
                MergeSort(a, mid + 1, end);
                Console.WriteLine("Merge start====start:{0},mid:{1},end:{2}", start, mid, end);
                // Merge(a, start, mid, end);
            }

        }

        /// <summary>
        /// 两路归并算法，两个拍好序的子序列合并为一个子序列
        /// </summary>
        /// <param name="a"></param>
        /// <param name="left"></param>
        /// <param name="mid"></param>
        /// <param name="right"></param>
        public void Merge(int[] a, int left, int mid, int right)
        {
            int[] temp = new int[a.Length];
            int p1 = left, p2 = mid + 1, k = left; //p1、p2是检测指针，k是存放指针
            //检索每个子序列的的数
            //p1是左边序列的，p2是右边序列的
            while (p1 <= mid && p2 <= right)
            {
                if (a[p1] <= a[p2])
                    temp[k++] = a[p1++];
                else
                    temp[k++] = a[p2++];
            }
            //如果第一个序列未检测完直接将后面所有元素加上去
            while (p1 <= mid) temp[k++] = a[p1++];
            while (p2 <= right) temp[k++] = a[p2++];

            for (int i = left; i <= right; i++)
            {
                a[i] = temp[i];
            }

        }
        #endregion

        #region 汉若塔问题
        /// <summary>
        /// 汉若塔问题
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sourceTower"></param>
        /// <param name="tempTower"></param>
        /// <param name="targetTower"></param>
        private void Hanoi(int n, string sourceTower, string tempTower, string targetTower)
        {

            if (n == 1)
            {
                Move(n, sourceTower, targetTower);
            }
            else
            {
                Hanoi(n - 1, sourceTower, targetTower, tempTower);
                Move(n, sourceTower, targetTower);
                Hanoi(n - 1, tempTower, sourceTower, targetTower);
            }
        }

        private void Move(int n, string sourceTower, string targetTower)
        {
            
            Console.WriteLine("move {0} tower from {1}==>{2}", n, sourceTower, targetTower);
        }
        #endregion
    }



}
