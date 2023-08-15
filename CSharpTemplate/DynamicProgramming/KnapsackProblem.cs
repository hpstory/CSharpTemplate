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

        [Test]
        public void Test()
        {
            int[] weights = new int[] { 1, 2, 3, 4 };
            int[] values = new int[] { 2, 4, 4, 5 };
            int[] limits = new int[] { 3, 1, 3, 2 };
            Assert.AreEqual(Knapsack(weights, values, 5), 8);
            Assert.AreEqual(UnboundedKnapsack(weights, values, 5), 10);
            Assert.AreEqual(MultipleKnapsackI(weights, values, limits, 5), 10);
        }
    }
}
