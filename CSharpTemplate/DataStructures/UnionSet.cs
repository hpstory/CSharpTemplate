namespace CSharpTemplate.DataStructures
{
    public class UnionSet
    {
        private readonly int[] parent;

        private readonly int[] count;

        public UnionSet() { }

        public UnionSet(int n)
        {
            parent = Enumerable.Range(0, n + 1).ToArray();
            count = Enumerable.Repeat(1, n + 1).ToArray();
        }

        public int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Unite(int a, int b)
        {
            int x = Find(a), y = Find(b);
            if (x == y) return;
            count[y] += count[x];
            parent[x] = y;
        }

        public bool InSameSet(int a, int b)
        {
            return Find(a) == Find(b);
        }

        public int GroupCount(int a)
        {
            return count[Find(a)];
        }

        [Test]
        public void Test()
        {
            var unionSet = new UnionSet(5);
            unionSet.Unite(1, 2);
            unionSet.Unite(1, 3);
            unionSet.Unite(4, 5);
            Assert.AreEqual(unionSet.Find(1), 3);
            Assert.IsTrue(unionSet.InSameSet(4, 5));
            Assert.IsFalse(unionSet.InSameSet(1, 5));
            Assert.AreEqual(unionSet.GroupCount(1), 3);
            Assert.AreEqual(unionSet.GroupCount(4), 2);
        }
    }
}
