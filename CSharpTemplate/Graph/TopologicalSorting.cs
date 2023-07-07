namespace CSharpTemplate.Graph
{
    public class TopologicalSorting
    {
        private int[] inorder;

        private readonly List<List<int>> graph = new List<List<int>>();

        public void BuildGraph(int n, int[][] edges)
        {
            this.inorder = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                graph.Add(new List<int>());
            }

            foreach (int[] edge in edges)
            {
                int x = edge[0], y = edge[1];
                graph[x].Add(y);
                inorder[y]++;
            }
        }

        public List<int> TopSort(int n)
        {
            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (inorder[i] == 0) queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                int t = queue.Dequeue();
                result.Add(t);
                foreach (int i in graph[t])
                {
                    if (--inorder[i] == 0)
                    {
                        queue.Enqueue(i);
                    }
                }
            }

            if (result.Count == n)
            {
                return result;
            }
            else
            {
                return new List<int>();
            }
        }

        [Test]
        public void Test()
        {
            int[][] edges =
            {
                new int[2] { 1, 2 },
                new int[2] { 2, 3 },
                new int[2] { 1, 3 }
            };

            BuildGraph(3, edges);
            int[] ans = { 1, 2, 3 };
            Assert.IsTrue(Enumerable.SequenceEqual(ans, TopSort(3)));
        }
    }
}
