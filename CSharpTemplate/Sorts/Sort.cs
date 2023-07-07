namespace CSharpTemplate.Sorts
{
    public class Sort
    {
        private readonly int[] nums;

        private readonly int[] temp;

        public Sort() { }

        public Sort(int[] nums)
        {
            this.nums = nums;
            this.temp = new int[nums.Length];
        }

        void QuickSort(int left, int right)
        {
            if (left >= right) return;
            int pivot = nums[left + right >> 1];
            int i = left - 1, j = right + 1;
            while (i < j)
            {
                do
                {
                    i++;
                } while (nums[i] < pivot);

                do
                {
                    j--;
                } while (nums[j] > pivot);

                if (i < j)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }

            QuickSort(left, j);
            QuickSort(j + 1, right);
        }

        void MergeSort(int left, int right)
        {
            if (left >= right) return;
            int mid = left + right >> 1;
            MergeSort(left, mid);
            MergeSort(mid + 1, right);
            int i = left, j = mid + 1, k = 0;
            while (i <= mid && j <= right)
            {
                if (nums[i] <= nums[j]) temp[k++] = nums[i++];
                else temp[k++] = nums[j++];
            }

            while (i <= mid) temp[k++] = nums[i++];
            while (j <= right) temp[k++] = nums[j++];
            for (int a = left, b = 0; a <= right; a++, b++)
            {
                nums[a] = temp[b];
            }
        }

        [Test]
        public void Test()
        {
            int[] nums = { 3, 1, 2, 4 };
            int[] sorted = { 1, 2, 3, 4 };
            var sort = new Sort(nums);
            Assert.IsFalse(Enumerable.SequenceEqual(nums, sorted));
            sort.QuickSort(0, nums.Length - 1);
            Assert.IsTrue(Enumerable.SequenceEqual(nums, sorted));

            nums = new int[4] { 3, 1, 2, 4 };
            sort = new Sort(nums);
            Assert.IsFalse(Enumerable.SequenceEqual(nums, sorted));
            sort.MergeSort(0, nums.Length - 1);
            Assert.IsTrue(Enumerable.SequenceEqual(nums, sorted));
        }
    }
}
