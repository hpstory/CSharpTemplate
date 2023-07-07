namespace CSharpTemplate.Utils
{
    public partial class BuildIn
    {
        public static void Sort(int[] nums, int[] nums1, int[] nums2)
        {
            int n = nums.Length;
            {
                // 常用排序
                // 升序
                Array.Sort(nums, (x, y) => x.CompareTo(y));
                // 降序
                Array.Sort(nums, (x, y) => y.CompareTo(x));
            }
            {
                // 创建下标数组, 并对下标数组排序
                int[] index = Enumerable.Range(0, n).ToArray();
                Array.Sort(index, (x, y) => nums[x].CompareTo(nums[y]));
            }
            {
                // 基于num1中值从大到小的排序对nums1和nums2排序
                Array.Sort(nums1, nums2, Comparer<int>.Create((x, y) => y.CompareTo(x)));
                // Linq实现
                var sorted = nums1.Zip(nums1).OrderByDescending(pair => pair.First).ToArray();
                nums1 = sorted.Select(pair => pair.First).ToArray();
                nums2 = sorted.Select(pair => pair.Second).ToArray();
            }            
        }      
    }
}
