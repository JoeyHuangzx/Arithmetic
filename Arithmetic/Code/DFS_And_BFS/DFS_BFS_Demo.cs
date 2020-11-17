using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Code.DFS_And_BFS
{

    public class DFS_BFS_Demo
    {
        private int row = 10;
        private int col = 10;
        private int[] px = { -1, 0, 1, 0 };
        private int[] py = { 0, 1, 0, -1 };
        private int[][] grids = new int[10][];
        private int miniStep = 0;
        private int step = 0;
        private int roadIndex = 0;

        public DFS_BFS_Demo()
        {
            grids[0] = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 };
            grids[1] = new int[] { 1, 1, 1, 0, 0, 0, 0, 1, 0, 1 };
            grids[2] = new int[] { 1, 0, 0, 0, 0, 1, 0, 1, 0, 1 };
            grids[3] = new int[] { 1, 0, 0, 1, 1, 1, 0, 0, 0, 1 };
            grids[4] = new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 1, 1 };
            grids[5] = new int[] { 1, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            grids[6] = new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 1, 1 };
            grids[7] = new int[] { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1 };
            grids[8] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1 };
            grids[9] = new int[] { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 };
            miniStep = row * col;
            BFS();
            //DFS(grids, 0, 4);
            Console.WriteLine("done........");
        }

        /// <summary>
        /// 深度优先算法（Death First Search），是一种用于遍历图或者搜索树的算法，是一种盲目搜索
        /// 沿着树的深度去搜索节点，尽可能深的搜索树的分支，当节点V的所在边都已搜索完，搜索将回溯到节点V所在边的起始节点。
        /// 这个过程一直进行到已发现从源节点可达的所有节点为止。如果还有其他节点未访问，则另选一个未被访问到的节点重复上述过程。
        /// 重复上述过程，知道所有节点全部被访问。
        /// 思想：不撞南墙不回头/一条路走到黑。
        /// </summary>
        /// <param name="use"></param>
        /// <param name="_targetX"></param>
        /// <param name="_targetY"></param>
        public void DFS(int[][] use, int _targetX, int _targetY)
        {
            //int num = 0;
            if (_targetX == 9 && _targetY == 7)
            {
                // Console.WriteLine("===========================================");
                for (int m = 0; m < row; m++)
                {
                    for (int n = 0; n < col; n++)
                    {
                        if (use[m][n] == 2) Console.Write("+ ");
                        else Console.Write("O ");
                    }
                    Console.WriteLine();
                }
                roadIndex++;
                Console.WriteLine("---------------------------------------------------------------"+roadIndex);

                return;
            }
            for (int i = 0; i < 4; i++)
            {
                int _newX = _targetX + px[i];
                int _newY = _targetY + py[i];
                // Console.WriteLine(_newX+","+ _newY);
                if (_newX >= 0 && _newX < row && _newY >= 0 && _newY < col)
                {

                    if (use[_newX][_newY] == 0)
                    {
                        //  Console.WriteLine(_newX+","+_newY);
                        use[_newX][_newY] = 2;
                        step++;
                        //递归
                        DFS(use, _newX, _newY);
                        //回溯
                        use[_newX][_newY] = 0;
                    }

                }
            }
        }


        /// <summary>
        /// 广度优先搜索（Breadth First Search），是一种图形搜索算法，属于盲目搜索
        /// 1、将根节点放入队列中
        /// 2、从队列中取出第一个节点，并检验是否为目标节点,找到了则结束搜索并回传结果。否则将他尚未检验的子节点加入到队列中。
        /// 3、若队列为空，则说明整个图都检验完了 
        /// 4、重复步骤2
        /// 思想：多米若骨牌，层层倒塌，层层访问。
        /// </summary>
        public void BFS()
        {
            int[][] next = new int[4][];
            //定义4个方向，每次递归根据这4个方向来
            next[0] =new int[]{ 0,1};
            next[1] =new int[]{ 1,0};
            next[2] = new int[] { -1, 0 };
            next[3] = new int[] { 0, -1 };

            List<int[]> temps = new List<int[]>();
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[]{0,4});
            while(queue.Count>0)
            {
                int[] pos = queue.Dequeue();
                if(pos[0]==9 && pos[1]==7)
                {
                    for (int m = 0; m < row; m++)
                    {
                        for (int n = 0; n < col; n++)
                        {
                            if (grids[m][n] == 2) Console.Write("+ ");
                            else Console.Write("O ");
                        }
                        Console.WriteLine();
                    }
                    roadIndex++;
                    Console.WriteLine("---------------------------------------------------------------"+roadIndex);
                    Console.WriteLine("到达。。。。。。。。。。。");
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    int _x = pos[0] + next[i][1];
                    int _y = pos[1] + next[i][0];
                    if(_x>=0 && _x<row && _y>=0 && _y<col)
                    {
                        if (grids[_x][_y]==0)
                        {
                            grids[_x][_y] = 2;
                            
                            queue.Enqueue(new int[] { _x, _y });
                        }
                    }
                }
            }
        }

        public void BFS2()
        {
            int[][] next = new int[4][];
            next[0] = new int[] { 0, 1 };
            next[1] = new int[] { 1, 0 };
            next[2] = new int[] { -1, 0 };
            next[3] = new int[] { 0, -1 };

            List<int[]> temps = new List<int[]>();
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 4 });
            while (queue.Count > 0)
            {
                int[] pos = queue.Dequeue();

                if (pos[0] == 9 && pos[1] == 7)
                {
                    for (int m = 0; m < row; m++)
                    {
                        for (int n = 0; n < col; n++)
                        {
                            if (grids[m][n] == 2) Console.Write("+ ");
                            else Console.Write("O ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine("到达。。。。。。。。。。。");
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    int _x = pos[0] + next[i][1];
                    int _y = pos[1] + next[i][0];
                    if (_x >= 0 && _x < row && _y >= 0 && _y < col)
                    {
                        if (grids[_x][_y] == 0)
                        {
                            grids[_x][_y] = 2;

                            queue.Enqueue(new int[] { _x, _y });
                        }
                    }
                }
            }
        }
    }

    public struct Walks
    {
        public int x;
        public int y;
        public int step;
    }


}
