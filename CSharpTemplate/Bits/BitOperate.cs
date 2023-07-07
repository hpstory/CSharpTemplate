namespace CSharpTemplate.Bits
{
    public class BitOperate
    {
        int LowBit(int x)
        {
            return x & -x;
        }

        int BitCount(int x)
        {
            int ans = 0;
            while (x > 0)
            {
                x -= LowBit(x);
                ans++;
            }

            return ans;
        }

        [Test]
        public void Test()
        {
            var solution = new BitOperate();
            Assert.AreEqual(solution.LowBit(14), 2);
            Assert.AreEqual(solution.BitCount(14), 3);
        }
    }
}
