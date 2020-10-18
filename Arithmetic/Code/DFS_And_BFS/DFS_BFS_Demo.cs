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

        public void DFS(int[][] use, int _targetX, int _targetY)
        {
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
                Console.WriteLine("---------------------------------------------------------------");

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

        public void BFS()
        {
            int[][] next = new int[4][];
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
                    Console.WriteLine("---------------------------------------------------------------");
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
