namespace CSharpTemplate.Utils
{
    public partial class BuildIn
    {
        int BinarySearch(int[] nums, int target)
        {
            int index = Array.BinarySearch(nums, target);
            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }

        [Test]
        public void Test()
        {
            int[] nums = { 4, 2, 1, 3 };
            Assert.AreEqual(BinarySearch(nums, 2), 1);
            Assert.AreEqual(BinarySearch(nums, 5), 4);
            Assert.AreEqual(BinarySearch(nums, 0), 0);
        }
    }
}
