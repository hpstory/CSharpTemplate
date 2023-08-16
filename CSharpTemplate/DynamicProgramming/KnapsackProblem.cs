using System.Reflection.Metadata;

namespace CSharpTemplate.DynamicProgramming
{
    public class KnapsackProblem
    {
        // 0-1背包
        public int Knapsack(int[] weights, int[] values, int capacity)
        {
            int n = weights.Length;
            // dp[i, j] -> 前i件物品, 总体积为j的最大价值
            int[,] dp = new int[n + 1, capacity + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j >= weights[i - 1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - weights[i - 1]] + values[i - 1]);
                    }
                }
            }

            return dp[n, capacity];
        }

        // 完全背包
        public int UnboundedKnapsack(int[] weights, int[] values, int capacity)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, capacity + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j >= weights[i - 1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i, j - weights[i - 1]] + values[i - 1]);
                    }
                }
            }

            return dp[n, capacity];
        }

        // 多重背包
        public int MultipleKnapsackI(int[] weights, int[] values, int[] limits, int capacity)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, capacity + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    for (int k = 0; k <= limits[i - 1] && k * weights[i - 1] <= j; k++)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i, j - k * weights[i - 1]] + values[i - 1] * k);
                    }
                }
            }

            return dp[n, capacity];
        }

        // 多重背包二进制优化
        public int MultipleKnapsackII(int[] weights, int[] values, int[] limits, int capacity)
        {
            int n = weights.Length;
            int[] dp = new int[capacity + 1];
            List<(int, int)> goods = new();
            for (int i = 0; i < n; i++)
            {
                int s = limits[i];
                for (int k = 1; k <= s; k *= 2)
                {
                    s -= k;
                    goods.Add((k * weights[i], k * values[i]));
                }

                if (s > 0) goods.Add((s * weights[i], s * values[i]));
            }

            foreach (var good in goods)
            {
                for (int j = capacity; j >= good.Item1; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - good.Item1] + good.Item2);
                }
            }

            return dp[capacity];
        }

        // 分组背包
        public int GroupKnapsack(int[][][] groups, int capacity)
        {
            int n = groups.Length;
            int[] dp = new int[capacity + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = capacity; j >= 0; j--)
                {
                    int m = groups[i].Length;
                    for (int k = 0; k < m; k++)
                    {
                        if (j >= groups[i][k][0])
                        {
                            dp[j] = Math.Max(dp[j], dp[j - groups[i][k][0]] + groups[i][k][1]);
                        }
                    }
                }
            }

            return dp[capacity];
        }

        [Test]
        public void Test()
        {
            int[] weights = new int[] { 1, 2, 3, 4 };
            int[] values = new int[] { 2, 4, 4, 5 };
            int[] limits = new int[] { 3, 1, 3, 2 };
            int[][][] groups = new int[][][]
            {
                new int[][]
                {
                    new int[] { 1, 2 },
                    new int[] { 2, 4 }
                },
                new int[][]
                {
                    new int[] { 3, 4}
                },
                new int[][]
                {
                    new int[] { 4, 5 }
                }
            };

            Assert.AreEqual(Knapsack(weights, values, 5), 8);
            Assert.AreEqual(UnboundedKnapsack(weights, values, 5), 10);
            Assert.AreEqual(MultipleKnapsackI(weights, values, limits, 5), 10);
            Assert.AreEqual(MultipleKnapsackII(weights, values, limits, 5), 10);
            Assert.AreEqual(GroupKnapsack(groups, 5), 8);
        }
    }
}
