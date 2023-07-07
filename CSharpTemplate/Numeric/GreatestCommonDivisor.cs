namespace CSharpTemplate.Numeric
{
    public class GreatestCommonDivisor
    {
        int Gcd(int a, int b)
        {
            return b > 0 ? Gcd(b, a % b) : a;
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(Gcd(3, 6), 3);
        }
    }
}
