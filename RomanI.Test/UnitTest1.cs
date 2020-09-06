using NUnit.Framework;

namespace RomanI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [TestCase("I",ExpectedResult =1)]
        public int Test2(string roman)
        {

            if (roman.Equals("I"))
                return 1;
            else
                return 0;
        }
    }
}