using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Arithmetic.Code;
using Arithmetic.Code.DFS_And_BFS;
using BinaryTrees;

namespace Arithmetic
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //BinaryTreeDemo bt = new BinaryTreeDemo();
            //HanoiTower ht = new HanoiTower();
            DFS_BFS_Demo demo = new DFS_BFS_Demo();
            //ShellSort.ShellSort shellSort = new ShellSort.ShellSort();
            Console.ReadLine();
        }
    }
}
