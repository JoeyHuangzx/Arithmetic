using System.Collections;
using System.Collections.Generic;
using System;

namespace BinaryTrees
{

    /// <summary>
    /// 1、在二叉树的第i层上至多有2^(i-1)个结点（i≥1）。
    /// 2、深度为k的二叉树至多有2^k -1 个结点(k≥1)。
    /// 3、对任何一棵二叉树T，如果其终端结点数为n0，度为2的结点数为n2，则n0 = n2 +1
    /// 推导如下： 
    /// 分支总数 = 总节点数 - 1（1） 
    /// 分支总数 = 1*n1 + 2* n2 （n1表示度为1的结点数，n2表示度为2的结点数）（2） 
    /// 总节点数 = n0 + n1 + n2 （3） 
    /// 由（1），（2），（3）式即可得出n2 = n0 -1.
    /// 4、具有n个结点的完全二叉树的深度为log2 (n) + 1。
    /// 5、如果对一棵有n个结点的完全二叉树（其深度为log2 (n) + 1）的结点按层序编号，对任一结点i(1≤i≤n)有: 
    /// 如果i=1,则结点i是二叉树的根，无双亲；如果i>1，则起双亲是结点i/2。 
    /// 如果2i>n，则结点i无左孩子。 
    /// 如果2i+1>n,则结点i无右孩子；否则其右孩子是结点2i+1。
    /// 二叉树的构建
    /// 1、顺序存储：用数组进行保存 
    /// 2、链式存储：用两块指针域进行保存，主要思想是采用双向链表的思想
    /// </summary>
    public class BinaryTreeDemo
    {
        public BinaryTreeDemo()
        {
            OrderTreeDemo();
            LinkTreeDemo();
        }
       
        private void OrderTreeDemo()
        {
           
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderTree<int> orderTree = new OrderTree<int>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                orderTree.Add(arr[i]);
            }
            Console.Write("先序遍历:");
            orderTree.FirstTraversal();
            Console.WriteLine();
            Console.Write("中序遍历:");
            orderTree.MiddleTravesal();
            Console.WriteLine();
            Console.Write("后序遍历");
            orderTree.LastTraversal();
            Console.WriteLine();
            Console.Write("层次遍历");
            orderTree.LayerTraversal();
        }

        private void LinkTreeDemo()
        {

        }

        
    }

}

