using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Code
{
    /// <summary>
    /// 贪心算法
    /// （1）建立数学模型来描述问题。
    /// （2）把求解的问题分成若干个子问题。
    /// （3）对每一子问题求解，得到子问题的局部最优解。
    /// （4）把子问题的局部最优解合成原来问题的一个解。
    /// </summary>
    public class GreedyAlgorithm
    {
        public int N = 5;
        public int[] Count = { 5, 2, 2, 3, 5 };
        public int[] Value = { 1, 5, 10, 50, 100 };


        public GreedyAlgorithm()
        {

        }

        /// <summary>
        /// 小明手中有 1，5，10，50，100 五种面额的纸币，每种纸币对应张数分别为 5，2，2，3，5 张。若小明需要支付 456 元，
        /// 则需要多少张纸币？* 选取面值为 100 的纸币，则 X1 = 100, V = 456 - 100 = 356；继续选取面值为 100 的纸币，
        /// 则 X2 = 100, V = 356 - 100 = 256；继续选取面值为 100 的纸币，则 X3 = 100, V = 256 - 100 = 156；
        /// 继续选取面值为 100 的纸币，则 X4 = 100, V = 156 - 100 = 56；选取面值为 50 的纸币，
        /// 则 X5 = 50, V = 56 - 50 = 6；选取面值为 5 的纸币，则 X6 = 5, V = 6 - 5 = 1；
        /// 选取面值为 1 的纸币，则 X7 = 1, V = 1 - 1 = 0；求解结束
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public int Solve(int money)
        {
            int sum = 0;

            for (int i = N - 1; i >= 0; i--)
            {
                int c = Math.Min(money / Value[i], Count[i]);  //每一个所需要的张数
                money -= c * Count[i];
                sum += c;
            }
            if (money > 0) sum = -1;
            return sum;
        }


        public int Min(int a, int b)
        {
            return Math.Min(a, b);
        }
    }

    /// <summary>
    /// 背包问题
    /// 有一个背包，最多能承载重量为 C=150的物品，现在有7个物品（物品不能分割成任意大小），
    /// 编号为 1~7
    /// 重量分别是 wi=[35,30,60,50,40,10,25]，
    /// 价值分别是 pi=[10,40,30,50,35,40,30]，
    /// 现在从这 7 个物品中选择一个或多个装入背包，要求在物品总重量不超过 C 的前提下，所装入的物品总价值最高。
    /// </summary>
    public class PackageProblem
    {
        public class TagObject
        {
            public int Weight;
            public int Price;
            public int Status;
        }

        public class TagProblem
        {
            public List<TagObject> objs = new List<TagObject>();
            public int total;
        }

        private List<TagObject> tagObjects = new List<TagObject>();

        public delegate int MethodDelegate(List<TagObject> lists, int c);
        private static MethodDelegate method;


        public PackageProblem()
        {
            tagObjects.Add(new TagObject() { Weight = 35, Price = 10, Status = 0 });
            tagObjects.Add(new TagObject() { Weight = 30, Price = 40, Status = 0 });
            tagObjects.Add(new TagObject() { Weight = 60, Price = 30, Status = 0 });
            tagObjects.Add(new TagObject() { Weight = 50, Price = 50, Status = 0 });
            tagObjects.Add(new TagObject() { Weight = 40, Price = 35, Status = 0 });
            tagObjects.Add(new TagObject() { Weight = 10, Price = 40, Status = 0 });
            tagObjects.Add(new TagObject() { Weight = 25, Price = 30, Status = 0 });


            TagProblem problem = new TagProblem();
            problem.objs = tagObjects;
            problem.total = 150;
            method = new MethodDelegate(CostToPriceWeight);
            CalculateResult(problem, method);
            Console.ReadLine();
        }

        /// <summary>
        /// 有了物品，有了方法，下面就是将两者结合起来的贪心算法GreedyAlgo
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="greedyCallback"></param>
        public void CalculateResult(TagProblem problem, MethodDelegate greedyCallback)
        {
            int index = 0;
            int currSumWeight = 0;
            //先选
            while ((index = greedyCallback(problem.objs, currSumWeight)) != -1)
            {
                if (problem.objs[index].Weight + currSumWeight <= problem.total)
                {
                    ////如果背包没有装满，还可以再装,标记下装进去的物品状态为1
                    problem.objs[index].Status = 1;
                    //把这个idx的物体的重量装进去，计算当前的重量
                    currSumWeight += problem.objs[index].Weight;

                    Console.WriteLine("index:{0},price:{1},weight:{2}",index,problem.objs[index].Price,problem.objs[index].Weight);
                }
                else
                {
                    //不能选这个物品了，做个标记2后重新选剩下的
                    problem.objs[index].Status = 2;
                }
                Console.WriteLine("currSumWeight:{0}", currSumWeight);
            }
            
        }


        /// <summary>
        /// 价值主导选择，每次都选价值最高的物品放进背包
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CostToPrice(List<TagObject> lists, int c)
        {
            int index = -1;
            int maxPrice = 0;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Status == 0 && lists[i].Price > maxPrice)
                {
                    maxPrice = lists[i].Price;
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// 重量主导选择，每次都选择重量最轻(小)的物品放进背包
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CostToWeight(List<TagObject> lists, int c)
        {
            int index = -1;
            int minWeight = 10000;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Status == 0 && lists[i].Weight < minWeight)
                {
                    minWeight = lists[i].Weight;
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// 价值密度主导选择，每次选择都选价值/重量最高(大)的物品放进背包
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CostToPriceWeight(List<TagObject> lists, int c)
        {
            int index = -1;
            float si = 0;

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Status == 0 && lists[i].Price / lists[i].Weight > si)
                {
                    si = lists[i].Price / lists[i].Weight;
                    index = i;
                }
            }

            return index;
        }
    }

}
