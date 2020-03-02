/**
 * 
 * Author:JoeyHuang
 * Time: 2019/8/25 15:23:27
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    /// <summary>
    /// 顺序存储二叉树
    /// </summary>
    public class OrderTree<T>
    {

        private T[] data;
        /// <summary>
        /// 当前二叉树保存的数据有多少个
        /// </summary>
        private int count = 0; //

        /// <summary>
        /// 二叉树容量
        /// </summary>
        /// <param name="capacity"></param>
        public OrderTree(int capacity)
        {
            data = new T[capacity];
        }

        public bool Add(T _item)
        {
            if (count >= data.Length) return false;

            data[count] = _item;
            count++;
            return true;
        }

        public void FirstTraversal()
        {
            FirstTraversal(0);
        }

        /// <summary>
        /// 先序排列
        /// </summary>
        /// <param name="index"></param>
        private void FirstTraversal(int index)
        {
            if (index >= count || data[index].Equals(-1)) return;
            int number = index + 1;
            T _value = data[index];
            Console.Write(" " + _value);
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;
            FirstTraversal(leftNumber - 1);
            FirstTraversal(rightNumber - 1);

        }

        public void MiddleTravesal()
        {
            MiddleTravesal(0);
        }

        /// <summary>
        /// 中序排列
        /// </summary>
        /// <param name="index"></param>
        private void MiddleTravesal(int index)
        {
            if (index >= count || data[index].Equals(-1)) return;
            int number = index + 1;
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;
            MiddleTravesal(leftNumber - 1);
            T _value = data[index];
            Console.Write(" "+_value);
            MiddleTravesal(rightNumber - 1);
        }

        public void LastTraversal()
        {
            LastTraversal(0);
        }

        /// <summary>
        /// 后序排列
        /// </summary>
        /// <param name="index"></param>
        private void LastTraversal(int index)
        {
            if (index >= count || data[index].Equals(-1)) return;
            int number = index + 1;
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;
            LastTraversal(leftNumber - 1);
            LastTraversal(rightNumber - 1);
            T _value = data[index];
            Console.Write(" " + _value);

        }

        /// <summary>
        /// 层次排列
        /// </summary>
        public void LayerTraversal()
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(-1)) continue;
                T _value = data[i];
                Console.Write(" " + _value);
            }
        }

    }
}
