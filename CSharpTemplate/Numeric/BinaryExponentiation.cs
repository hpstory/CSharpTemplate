namespace CSharpTemplate.Numeric
{
    public class BinaryExponentiation
    {
        int Qmi(long a, long b, int p)
        {
            long ans = 1;
            while (b > 0)
            {
                if ((b & 1) > 0) ans = ans * a % p;
                a = a * a % p;
                b >>= 1;
            }

            return (int)ans;
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(Qmi(3, 2, 5), 4);
            Assert.AreEqual(Qmi(2, 500, 1000000007), 390483007);
        }
    }
}
