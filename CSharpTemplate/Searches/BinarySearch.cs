namespace CSharpTemplate.Searches
{
    public class BinarySearch
    {
        private readonly int[] nums;

        private const int invalid = -1;

        public BinarySearch() { }

        public BinarySearch(int[] nums) => this.nums = nums;

        int GetLowBound(int left, int right, Func<int, bool> check)
        {
            while (left < right)
            {
                int mid = left + right >> 1;
                if (check(nums[mid]))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (!check(nums[left])) return invalid;
            return left;
        }

        int GetUpperBound(int left, int right, Func<int, bool> check)
        {
            while (left < right)
            {
                int mid = left + right + 1 >> 1;
                if (check(nums[mid]))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (!check(nums[left])) return invalid;
            return left;
        }

        [Test]
        public void Test()
        {
            int[] nums = { 1, 2, 2, 3, 4 };
            int n = nums.Length;
            var solution = new BinarySearch(nums);
            Assert.AreEqual(solution.GetLowBound(0, n - 1, (x) => x == 2), 1);
            Assert.AreEqual(solution.GetUpperBound(0, n - 1, (x) => x == 2), 2);
            Assert.AreEqual(solution.GetLowBound(0, n - 1, (x) => x == 0), -1);
            Assert.AreEqual(solution.GetUpperBound(0, n - 1, (x) => x == 5), -1);
            Assert.AreEqual(solution.GetLowBound(0, n - 1, (x) => x >= 2), 1);
            Assert.AreEqual(solution.GetUpperBound(0, n - 1, (x) => x <= 2), 2);
        }
    }
}
